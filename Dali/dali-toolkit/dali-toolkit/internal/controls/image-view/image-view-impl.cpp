/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
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
#include "image-view-impl.h"

// EXTERNAL INCLUDES
#include <dali/public-api/images/resource-image.h>
#include <dali/public-api/object/type-registry.h>
#include <dali/public-api/object/type-registry-helper.h>
#include <dali/devel-api/scripting/scripting.h>

// INTERNAL INCLUDES
#include <dali-toolkit/public-api/controls/image-view/image-view.h>
#include <dali-toolkit/devel-api/controls/control-devel.h>
#include <dali-toolkit/public-api/visuals/visual-properties.h>
#include <dali-toolkit/devel-api/visual-factory/visual-factory.h>
#include <dali-toolkit/internal/visuals/visual-string-constants.h>
#include <dali-toolkit/internal/visuals/visual-base-impl.h>
#include <dali-toolkit/internal/visuals/visual-base-data-impl.h>

namespace Dali
{

namespace Toolkit
{

namespace Internal
{

namespace
{

BaseHandle Create()
{
  return Toolkit::ImageView::New();
}

// Setup properties, signals and actions using the type-registry.
DALI_TYPE_REGISTRATION_BEGIN( Toolkit::ImageView, Toolkit::Control, Create );
DALI_PROPERTY_REGISTRATION( Toolkit, ImageView, "reservedProperty01", STRING, RESERVED_PROPERTY_01 )
DALI_PROPERTY_REGISTRATION( Toolkit, ImageView, "image", MAP, IMAGE )
DALI_PROPERTY_REGISTRATION( Toolkit, ImageView, "preMultipliedAlpha", BOOLEAN, PRE_MULTIPLIED_ALPHA )

DALI_ANIMATABLE_PROPERTY_REGISTRATION_WITH_DEFAULT( Toolkit, ImageView, "pixelArea", Vector4(0.f, 0.f, 1.f, 1.f), PIXEL_AREA )
DALI_TYPE_REGISTRATION_END()

} // anonymous namespace

using namespace Dali;

ImageView::ImageView()
: Control( ControlBehaviour( CONTROL_BEHAVIOUR_DEFAULT ) ),
  mImageSize(),
  mImageVisualPaddingSetByTransform( false )
{
}

ImageView::~ImageView()
{
}

Toolkit::ImageView ImageView::New()
{
  ImageView* impl = new ImageView();

  Toolkit::ImageView handle = Toolkit::ImageView( *impl );

  // Second-phase init of the implementation
  // This can only be done after the CustomActor connection has been made...
  impl->Initialize();

  return handle;
}

/////////////////////////////////////////////////////////////

void ImageView::OnInitialize()
{
  // ImageView can relayout in the OnImageReady, alternative to a signal would be to have a upcall from the Control to ImageView
  Dali::Toolkit::Control handle( GetOwner() );
  handle.ResourceReadySignal().Connect( this, &ImageView::OnResourceReady );
}

void ImageView::SetImage( Image image )
{
  // Don't bother comparing if we had a visual previously, just drop old visual and create new one
  mImage = image;
  mUrl.clear();
  mPropertyMap.Clear();

  Toolkit::Visual::Base visual =  Toolkit::VisualFactory::Get().CreateVisual( image );
  if( visual )
  {
    if( !mVisual )
    {
      mVisual = visual;
    }

    if( !mShaderMap.Empty() )
    {
      Internal::Visual::Base& visualImpl = Toolkit::GetImplementation( visual );
      visualImpl.SetCustomShader( mShaderMap );
    }

    DevelControl::RegisterVisual( *this, Toolkit::ImageView::Property::IMAGE, visual );
  }
  else
  {
    // Unregister the existing visual
    DevelControl::UnregisterVisual( *this, Toolkit::ImageView::Property::IMAGE );

    // Trigger a size negotiation request that may be needed when unregistering a visual.
    RelayoutRequest();
  }

  // Signal that a Relayout may be needed
}

void ImageView::SetImage( const Property::Map& map )
{
  // Comparing a property map is too expensive so just creating a new visual
  mPropertyMap = map;
  mUrl.clear();
  mImage.Reset();

  Toolkit::Visual::Base visual =  Toolkit::VisualFactory::Get().CreateVisual( mPropertyMap );
  if( visual )
  {
    // Don't set mVisual until it is ready and shown. Getters will still use current visual.
    if( !mVisual )
    {
      mVisual = visual;
    }

    if( !mShaderMap.Empty() )
    {
      Internal::Visual::Base& visualImpl = Toolkit::GetImplementation( visual );
      visualImpl.SetCustomShader( mShaderMap );
    }

    DevelControl::RegisterVisual( *this, Toolkit::ImageView::Property::IMAGE, visual  );
  }
  else
  {
    // Unregister the exsiting visual
    DevelControl::UnregisterVisual( *this, Toolkit::ImageView::Property::IMAGE );

    // Trigger a size negotiation request that may be needed when unregistering a visual.
    RelayoutRequest();
  }

  // Signal that a Relayout may be needed
}

void ImageView::SetImage( const std::string& url, ImageDimensions size )
{
  // Don't bother comparing if we had a visual previously, just drop old visual and create new one
  mUrl = url;
  mImageSize = size;
  mImage.Reset();
  mPropertyMap.Clear();

  // Don't set mVisual until it is ready and shown. Getters will still use current visual.
  Toolkit::Visual::Base visual =  Toolkit::VisualFactory::Get().CreateVisual( url, size );
  if( visual )
  {
    if( !mVisual )
    {
      mVisual = visual;
    }

    if( !mShaderMap.Empty() )
    {
      Internal::Visual::Base& visualImpl = Toolkit::GetImplementation( visual );
      visualImpl.SetCustomShader( mShaderMap );
    }

    DevelControl::RegisterVisual( *this, Toolkit::ImageView::Property::IMAGE, visual );
  }
  else
  {
    // Unregister the exsiting visual
    DevelControl::UnregisterVisual( *this, Toolkit::ImageView::Property::IMAGE );

    // Trigger a size negotiation request that may be needed when unregistering a visual.
    RelayoutRequest();
  }

  // Signal that a Relayout may be needed
}

Image ImageView::GetImage() const
{
  return mImage;
}

void ImageView::EnablePreMultipliedAlpha( bool preMultipled )
{
  if( mVisual )
  {
    Toolkit::GetImplementation( mVisual ).EnablePreMultipliedAlpha( preMultipled );
  }
}

bool ImageView::IsPreMultipliedAlphaEnabled() const
{
  if( mVisual )
  {
    return Toolkit::GetImplementation( mVisual ).IsPreMultipliedAlphaEnabled();
  }
  return false;
}

void ImageView::SetDepthIndex( int depthIndex )
{
  if( mVisual )
  {
    mVisual.SetDepthIndex( depthIndex );
  }
}

Vector3 ImageView::GetNaturalSize()
{
  if( mVisual )
  {
    Vector2 rendererNaturalSize;
    mVisual.GetNaturalSize( rendererNaturalSize );

    Extents padding;
    padding = Self().GetProperty<Extents>( Toolkit::Control::Property::PADDING );

    rendererNaturalSize.width += ( padding.start + padding.end );
    rendererNaturalSize.height += ( padding.top + padding.bottom );
    return Vector3( rendererNaturalSize );
  }

  // if no visual then use Control's natural size
  return Control::GetNaturalSize();
}

float ImageView::GetHeightForWidth( float width )
{
  Extents padding;
  padding = Self().GetProperty<Extents>( Toolkit::Control::Property::PADDING );

  if( mVisual )
  {
    return mVisual.GetHeightForWidth( width ) + padding.top + padding.bottom;
  }
  else
  {
    return Control::GetHeightForWidth( width ) + padding.top + padding.bottom;
  }
}

float ImageView::GetWidthForHeight( float height )
{
  Extents padding;
  padding = Self().GetProperty<Extents>( Toolkit::Control::Property::PADDING );

  if( mVisual )
  {
    return mVisual.GetWidthForHeight( height ) + padding.start + padding.end;
  }
  else
  {
    return Control::GetWidthForHeight( height ) + padding.start + padding.end;
  }
}

void ImageView::OnRelayout( const Vector2& size, RelayoutContainer& container )
{
  Control::OnRelayout( size, container );

  if( mVisual )
  {
    Property::Map transformMap = Property::Map();

    Extents padding = Self().GetProperty<Extents>( Toolkit::Control::Property::PADDING );
    const Visual::FittingMode fittingMode = Toolkit::GetImplementation(mVisual).GetFittingMode();

    bool zeroPadding = ( padding == Extents() );
    if( ( !zeroPadding ) || // If padding is not zero
        ( fittingMode == Visual::FittingMode::FIT_KEEP_ASPECT_RATIO ) )
    {
      Dali::LayoutDirection::Type layoutDirection = static_cast<Dali::LayoutDirection::Type>(
            Self().GetProperty( Dali::Actor::Property::LAYOUT_DIRECTION ).Get<int>() );

      if( Dali::LayoutDirection::RIGHT_TO_LEFT == layoutDirection )
      {
        std::swap( padding.start, padding.end );
      }

      auto finalOffset = Vector2( padding.start, padding.top );
      mImageVisualPaddingSetByTransform = true;

      // remove padding from the size to know how much is left for the visual
      auto finalSize = size - Vector2( padding.start + padding.end, padding.top + padding.bottom );

      // Should provide a transform that handles aspect ratio according to image size
      if( fittingMode == Visual::FittingMode::FIT_KEEP_ASPECT_RATIO )
      {
        auto availableVisualSize = finalSize;

        Vector2 naturalSize;
        mVisual.GetNaturalSize( naturalSize );

        // scale to fit the padded area
        finalSize = naturalSize * std::min( ( naturalSize.width  ? ( availableVisualSize.width  / naturalSize.width  ) : 0 ),
                                            ( naturalSize.height ? ( availableVisualSize.height / naturalSize.height ) : 0 ) );

        // calculate final offset within the padded area
        finalOffset += ( availableVisualSize - finalSize ) * .5f;
      }

      // populate the transform map
      transformMap.Add( Toolkit::Visual::Transform::Property::OFFSET, finalOffset )
                  .Add( Toolkit::Visual::Transform::Property::OFFSET_POLICY,
                      Vector2( Toolkit::Visual::Transform::Policy::ABSOLUTE, Toolkit::Visual::Transform::Policy::ABSOLUTE ) )
                  .Add( Toolkit::Visual::Transform::Property::ORIGIN, Toolkit::Align::TOP_BEGIN )
                  .Add( Toolkit::Visual::Transform::Property::ANCHOR_POINT, Toolkit::Align::TOP_BEGIN )
                  .Add( Toolkit::Visual::Transform::Property::SIZE, finalSize )
                  .Add( Toolkit::Visual::Transform::Property::SIZE_POLICY,
                      Vector2( Toolkit::Visual::Transform::Policy::ABSOLUTE, Toolkit::Visual::Transform::Policy::ABSOLUTE ) );
    }
    else if ( mImageVisualPaddingSetByTransform && zeroPadding )  // Reset offset to zero only if padding applied previously
    {
      mImageVisualPaddingSetByTransform = false;
      // Reset the transform map
      transformMap.Add( Toolkit::Visual::Transform::Property::OFFSET, Vector2::ZERO )
                  .Add( Toolkit::Visual::Transform::Property::OFFSET_POLICY,
                        Vector2( Toolkit::Visual::Transform::Policy::RELATIVE, Toolkit::Visual::Transform::Policy::RELATIVE ) );
    }


    mVisual.SetTransformAndSize( transformMap, size );

    // mVisual is not updated util the resource is ready in the case of visual replacement.
    // So apply the transform and size to the new visual.
    Toolkit::Visual::Base visual = DevelControl::GetVisual( *this, Toolkit::ImageView::Property::IMAGE );
    if( visual && visual != mVisual )
    {
      visual.SetTransformAndSize( transformMap, size );
    }
  }
}

void ImageView::OnResourceReady( Toolkit::Control control )
{
  // Visual ready so update visual attached to this ImageView, following call to RelayoutRequest will use this visual.
  mVisual = DevelControl::GetVisual( *this, Toolkit::ImageView::Property::IMAGE );
  // Signal that a Relayout may be needed
}

///////////////////////////////////////////////////////////
//
// Properties
//

void ImageView::SetProperty( BaseObject* object, Property::Index index, const Property::Value& value )
{
  Toolkit::ImageView imageView = Toolkit::ImageView::DownCast( Dali::BaseHandle( object ) );

  if ( imageView )
  {
    ImageView& impl = GetImpl( imageView );
    switch ( index )
    {
      case Toolkit::ImageView::Property::IMAGE:
      {
        std::string imageUrl;
        Property::Map* map;
        if( value.Get( imageUrl ) )
        {
          impl.SetImage( imageUrl, ImageDimensions() );
        }
        // if its not a string then get a Property::Map from the property if possible.
        else
        {
          map = value.GetMap();
          if( map )
          {
            Property::Value* shaderValue = map->Find( Toolkit::Visual::Property::SHADER, CUSTOM_SHADER );
            // set image only if property map contains image information other than custom shader
            if( map->Count() > 1u ||  !shaderValue )
            {
              impl.SetImage( *map );
            }
            // the property map contains only the custom shader
            else if( ( map->Count() == 1u )&&( shaderValue ) )
            {
              Property::Map* shaderMap = shaderValue->GetMap();
              if( shaderMap )
              {
                impl.mShaderMap = *shaderMap;

                if( !impl.mUrl.empty() )
                {
                  impl.SetImage( impl.mUrl, impl.mImageSize );
                }
                else if( impl.mImage )
                {
                  impl.SetImage( impl.mImage );
                }
                else if( !impl.mPropertyMap.Empty() )
                {
                  impl.SetImage( impl.mPropertyMap );
                }
              }
            }
          }
        }
        break;
      }

      case Toolkit::ImageView::Property::PRE_MULTIPLIED_ALPHA:
      {
        bool isPre;
        if( value.Get( isPre ) )
        {
          impl.EnablePreMultipliedAlpha( isPre );
        }
        break;
      }
    }
  }
}

Property::Value ImageView::GetProperty( BaseObject* object, Property::Index propertyIndex )
{
  Property::Value value;

  Toolkit::ImageView imageview = Toolkit::ImageView::DownCast( Dali::BaseHandle( object ) );

  if ( imageview )
  {
    ImageView& impl = GetImpl( imageview );
    switch ( propertyIndex )
    {
      case Toolkit::ImageView::Property::IMAGE:
      {
        if ( !impl.mUrl.empty() )
        {
          value = impl.mUrl;
        }
        else if( impl.mImage )
        {
          Property::Map map;
          Scripting::CreatePropertyMap( impl.mImage, map );
          value = map;
        }
        else
        {
          Property::Map map;
          Toolkit::Visual::Base visual = DevelControl::GetVisual( impl, Toolkit::ImageView::Property::IMAGE );
          if( visual )
          {
            visual.CreatePropertyMap( map );
          }
          value = map;
        }
        break;
      }

      case Toolkit::ImageView::Property::PRE_MULTIPLIED_ALPHA:
      {
        value = impl.IsPreMultipliedAlphaEnabled();
        break;
      }
    }
  }

  return value;
}

} // namespace Internal
} // namespace Toolkit
} // namespace Dali
