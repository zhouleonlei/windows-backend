/*
 * Copyright (c) 2014 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

// CLASS HEADER
#include <dali-toolkit/internal/controls/page-turn-view/page-turn-portrait-view-impl.h>

// EXTERNAL INCLUDES
#include <dali/public-api/animation/animation.h>
#include <dali/public-api/object/type-registry.h>
#include <dali/public-api/object/type-registry-helper.h>

//INTERNAL INCLUDES
#include <dali-toolkit/internal/controls/page-turn-view/page-turn-effect.h>

namespace Dali
{

namespace Toolkit
{

namespace Internal
{

namespace
{
DALI_TYPE_REGISTRATION_BEGIN( Toolkit::PageTurnPortraitView, Toolkit::PageTurnView, NULL )
DALI_TYPE_REGISTRATION_END()

// the panning speed threshold, no matter how far is the pan displacement, pan fast to left/right quickly (speed > 0.3) will turn over/back the page
const float GESTURE_SPEED_THRESHOLD(0.3f);

// the animation duration of turning the previous page back when an outwards flick is detected
const float PAGE_TURN_OVER_ANIMATION_DURATION(0.5f);

}

PageTurnPortraitView::PageTurnPortraitView( PageFactory& pageFactory, const Vector2& viewPageSize )
: PageTurnView( pageFactory, viewPageSize )
{
}

PageTurnPortraitView::~PageTurnPortraitView()
{
}

Toolkit::PageTurnPortraitView PageTurnPortraitView::New( PageFactory& pageFactory, const Vector2& viewPageSize )
{
  // Create the implementation, temporarily owned on stack
  IntrusivePtr< PageTurnPortraitView > internalPageTurnView = new PageTurnPortraitView( pageFactory, viewPageSize );

  // Pass ownership to CustomActor
  Dali::Toolkit::PageTurnPortraitView pageTurnView( *internalPageTurnView );

  // Second-phase init of the implementation
  // This can only be done after the CustomActor connection has been made...
  internalPageTurnView->Initialize();

  return pageTurnView;
}

void PageTurnPortraitView::OnPageTurnViewInitialize()
{
  mTurnEffectShader.RegisterProperty(PROPERTY_TEXTURE_WIDTH, 1.f );
  mSpineEffectShader.RegisterProperty(PROPERTY_TEXTURE_WIDTH, 1.f );

  mControlSize = mPageSize;
  Self().SetSize( mPageSize );
  mTurningPageLayer.SetParentOrigin( ParentOrigin::CENTER_LEFT );
}

Vector2 PageTurnPortraitView::SetPanPosition( const Vector2& gesturePosition )
{
  return gesturePosition;
}

void PageTurnPortraitView::SetPanActor( const Vector2& panPosition )
{
  if( mCurrentPageIndex < mTotalPageCount )
  {
    mTurningPageIndex = mCurrentPageIndex;
  }
  else
  {
    mTurningPageIndex = -1;
  }
}

void PageTurnPortraitView::OnPossibleOutwardsFlick( const Vector2& panPosition, float gestureSpeed )
{
  Vector2 offset = panPosition - mPressDownPosition;
  // There is previous page and an outwards flick is detected
  if( mCurrentPageIndex > 0 && gestureSpeed > GESTURE_SPEED_THRESHOLD && offset.x > fabs( offset.y ))
  {
    int actorIndex = (mCurrentPageIndex-1) % NUMBER_OF_CACHED_PAGES;
    Actor actor = mPages[ actorIndex ].actor;
    if(actor.GetParent() != Self())
    {
      return;
    }

    // Guard against destruction during signal emission
    //Emit signal, to notify that page[mCurrentPageIndex-1] is turning backwards
    Toolkit::PageTurnView handle( GetOwner() );
    mTurningPageIndex = mCurrentPageIndex-1;
    mPageTurnStartedSignal.Emit( handle, static_cast<unsigned int>(mTurningPageIndex), false );

    //update pages
    mCurrentPageIndex--;
    RemovePage( mCurrentPageIndex+NUMBER_OF_CACHED_PAGES_EACH_SIDE );
    AddPage( mCurrentPageIndex-NUMBER_OF_CACHED_PAGES_EACH_SIDE );
    OrganizePageDepth();
    mPageUpdated = true;

    actor.SetVisible(true);

    // Add the page to tuning page layer and set up PageTurnEffect
    mShadowView.Add( actor );
    mPages[actorIndex].UseEffect( mTurnEffectShader );
    mAnimatingCount++;
    Vector2 originalCenter( mPageSize.width*1.5f, 0.5f*mPageSize.height );
    mPages[actorIndex].SetOriginalCenter( originalCenter );
    mPages[actorIndex].SetCurrentCenter( Vector2( mPageSize.width*0.5f, mPageSize.height*0.5f ) );
    PageTurnApplyInternalConstraint(actor, mPageSize.height);

    // Start an animation to turn the previous page back
    Animation animation = Animation::New( PAGE_TURN_OVER_ANIMATION_DURATION );
    mAnimationPageIdPair[animation] = mCurrentPageIndex;

    animation.AnimateTo( Property( actor, mPages[actorIndex].propertyCurrentCenter ),
                         originalCenter,
                         AlphaFunction::EASE_OUT, TimePeriod(PAGE_TURN_OVER_ANIMATION_DURATION*0.75f) );
    animation.AnimateBy( Property( actor, Actor::Property::ORIENTATION ), AngleAxis( Degree( 180.0f ), Vector3::YAXIS ) ,AlphaFunction::EASE_OUT );
    animation.Play();

    animation.FinishedSignal().Connect( this, &PageTurnPortraitView::TurnedOverBackwards );
  }
}

void PageTurnPortraitView::OnTurnedOver( Actor actor, bool isLeftSide )
{
  if( isLeftSide )
  {
    actor.SetVisible( false );
  }
}

void PageTurnPortraitView::TurnedOverBackwards( Animation& animation )
{
  TurnedOver( animation );
}

} // namespace Internal

} // namespace Toolkit

} // namespace Dali
