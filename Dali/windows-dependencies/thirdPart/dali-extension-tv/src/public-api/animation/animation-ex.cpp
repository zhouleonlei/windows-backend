/*
 * Copyright 2017 by Samsung Electronics, Inc.,
 *
 * This software is the confidential and proprietary information
 * of Samsung Electronics, Inc. ("Confidential Information").  You
 * shall not disclose such Confidential Information and shall use
 * it only in accordance with the terms of the license agreement
 * you entered into with Samsung.
 *
 */

// CLASS HEADER
#include <animation-ex.h>

// EXTERNAL INCLUDES
#include <cmath> // fmod
#include <limits.h> //UINT_MAX

// INTERNAL INCLUDES
#include <animator.h>
#include <dali-ext-dlog.h>

// Animator IDs range
#define ANI_BASE_INDEX   1
#define ANI_MAX_INDEX    UINT_MAX

namespace //Unnamed namespace
{

inline void WrapInPlayRange( float& elapsed, const Dali::Vector2& playRangeSeconds)
{
  if( elapsed > playRangeSeconds.y )
  {
    elapsed = playRangeSeconds.x + fmodf((elapsed-playRangeSeconds.x), (playRangeSeconds.y-playRangeSeconds.x));
  }
  else if( elapsed < playRangeSeconds.x )
  {
    elapsed = playRangeSeconds.y - fmodf( (playRangeSeconds.x - elapsed), (playRangeSeconds.y-playRangeSeconds.x) );
  }
}

}

namespace DaliExtTV
{

AnimationEXPtr AnimationEX::New( float duration, float delay )
{
  //if delay or duration is less than 0 then reset them 0.
  delay = delay < 0.0f? 0.0f:delay;
  duration = duration < 0.0f? 0.0f:duration;

  AnimationEXPtr animation = new AnimationEX( duration, delay );
  return animation;
}

AnimationEX::AnimationEX( float duration, float delay, float speedFactor, int loopCount )
:mDurationSeconds(duration+delay),
mDelaySeconds(duration > 0.0f?delay:0.0f),
mPlayRange(Vector2(0.0f,1.0f)), 
mElapsedSeconds(mDurationSeconds * mPlayRange.x),
mSpeedFactor(speedFactor),
mLoopCount(loopCount),
mCurrentLoop(0.0f), 
mState(STOPPED),  
mStartCalled(false),
mDefaultAlphaFunction(AlphaFunction::DEFAULT),
mAnimatorDuration(TimePeriod(delay,duration))
{
  mAniTimer = Timer::New( TIMER_INTERVAL );
  mAniTimer.TickSignal().Connect( this, &AnimationEX::OnAniTimerTick );
}

AnimationEX::~AnimationEX()
{
  Clear();
}

void AnimationEX::Play()
{
  if(mState == PLAYING)
  {
    DALIEXT_ERRLOG("State is PLAYING");
    return;
  }

  if ( mSpeedFactor < 0.0f && mElapsedSeconds <= mPlayRange.x * mDurationSeconds )
  {
        mElapsedSeconds = mPlayRange.y * mDurationSeconds;
  }
  mCurrentLoop = 0;
  mState = PLAYING;
  mStartCalled = true;

  if( mAniTimer.IsRunning() ==  false )
  {
    mAniTimer.Start();
  }
}

void AnimationEX::Stop()
{
  if(mStartCalled == false)
  {
    DALIEXT_ERRLOG("Stop is called without calling Start");
    return;
  }
  mStartCalled = false;

  if( mAniTimer.IsRunning() )
  {
    mAniTimer.Stop();
  }


  mCurrentLoop = 0;
  mElapsedSeconds = mPlayRange.x * mDurationSeconds;
  mState = STOPPED;

  //Emit Finish signal 
  EmitFinishedSignal();
}

void AnimationEX::Pause()
{
  if (mState == PLAYING)
  {
    mState = PAUSED;
  }
}

void AnimationEX::Clear()
{
  if (mState != STOPPED)
  {
    Stop();
  }

  RemoveAllAnimators();
}

AnimationEX::EState AnimationEX::GetState() const
{
  return mState;
}

void AnimationEX::SetDuration(float duration)
{
  /*if(duration < 0.0f)
  {
    //duration should be greater than 0.0f.
    duration = 0.0f;
  }
  mDurationSeconds = duration;
  */

  //single animator.
  if(duration < 0.0f)
  {
    //duration should be greater than 0.0f.
    duration = 0.0f;
  }
  mAnimatorDuration.durationSeconds = duration;

  if(duration > 0.0f)
  {
    mDurationSeconds = duration + mDelaySeconds;
  }
  else
  {
    mDurationSeconds = duration;
    mDelaySeconds = 0.0f;
    mAnimatorDuration.delaySeconds = 0.0f;
  }
}

float AnimationEX::GetDuration() const
{
  return mDurationSeconds;
}

void AnimationEX::SetDelay(float delay)
{
  //remove existing delay from duration and set new delay.
  if(mDelaySeconds > 0.0f)
  {
    mDurationSeconds = mDurationSeconds - mDelaySeconds;
  }

  mDelaySeconds = delay;
  mAnimatorDuration.delaySeconds = delay;
  mDurationSeconds = mDurationSeconds + delay;
}

float AnimationEX::GetDelay() const
{
  return mDelaySeconds;
}

void AnimationEX::ExtendDuration( const TimePeriod& timePeriod )
{
  float duration = timePeriod.delaySeconds + timePeriod.durationSeconds;

  if( duration > mDurationSeconds )
  {
    SetDuration( duration );
  }
}

void AnimationEX::SetDefaultAlphaFunction(AlphaFunction alphaFunction)
{
  mDefaultAlphaFunction = alphaFunction;
}

AlphaFunction AnimationEX::GetDefaultAlphaFunction() const
{
  return mDefaultAlphaFunction;
}

void AnimationEX::SetSpeedFactor( float factor )
{
  mSpeedFactor = factor;
}

float AnimationEX::GetSpeedFactor() const
{
  return mSpeedFactor;
}

void AnimationEX::SetLoopCount(int count)
{
  mLoopCount = count;
  mCurrentLoop = 0;
}

int AnimationEX::GetLoopCount()
{
  return mLoopCount;
}

void AnimationEX::SetLooping(bool looping)
{
  SetLoopCount( looping ? 0 : 1 );
}

bool AnimationEX::IsLooping() const
{
  return mLoopCount != 1;
}

int AnimationEX::GetCurrentLoopCount() const
{
  return mCurrentLoop;
}

void AnimationEX::SetCurrentProgress( float progress )
{
  if( progress >= mPlayRange.x && progress <= mPlayRange.y )
  {
    mElapsedSeconds = mDurationSeconds * progress;
  }
}

float AnimationEX::GetCurrentProgress()
{
  if( mDurationSeconds > 0.0f )
  {
    return mElapsedSeconds / mDurationSeconds;
  }

  return 0.0f;
}

void AnimationEX::SetPlayRange( const Vector2& range)
{
  //Make sure the range specified is between 0.0 and 1.0
  if( range.x >= 0.0f && range.x <= 1.0f && range.y >= 0.0f && range.y <= 1.0f )
  {
    Vector2 orderedRange( range );
    //If the range is not in order swap values
    if( range.x > range.y )
    {
      orderedRange = Vector2(range.y, range.x);
    }

    // Cache for public getters
    mPlayRange = orderedRange;

    // mAnimation is being used in a separate thread; queue a message to set play range
    if( mState == STOPPED )
    {
      // Ensure that the animation starts at the right place
      mElapsedSeconds = mPlayRange.x * mDurationSeconds;
    }
    else
    {
      // If already past the end of the range, but before end of duration, then clamp will
      // ensure that the animation stops on the next update.
      // If not yet at the start of the range, clamping will jump to the start
      mElapsedSeconds = Clamp(mElapsedSeconds, mPlayRange.x * mDurationSeconds , mPlayRange.y * mDurationSeconds );
    }
  }
}

Vector2 AnimationEX::GetPlayRange() const
{
  return mPlayRange;
}

float AnimationEX::GetTime() const
{
  return mElapsedSeconds;
}

void AnimationEX::EmitFinishedSignal()
{
  if ( !mFinishedSignal.Empty() )
  {
    mFinishedSignal.Emit();
  }
}

AnimationEXSignalType& AnimationEX::FinishedSignal()
{
  return mFinishedSignal;
}

AnimatorIndex AnimationEX::GenerateAnimatorID()
{
  static AnimatorIndex startAnimatorID = ANI_BASE_INDEX - 1;
  AnimatorIndex animatorID = startAnimatorID;

  //if IDs are available, re-use the existing IDs.
  if (!mAvailableIndex.empty())
  {
    std::set<AnimatorIndex>::iterator iter = mAvailableIndex.begin();
    animatorID = *iter;
    mAvailableIndex.erase(iter);
    
    return animatorID;
  }

  animatorID++;

  if (animatorID >= ANI_MAX_INDEX)
  {
    DALIEXT_ERRLOG("No valid animator ID can be returned");
    return 0;
  }

  //not present in available index set, so the new ID is returned.
  startAnimatorID = animatorID;
  return animatorID;
}

AnimatorSignalType& AnimationEX::UpdateSignal()
{
  //Number of Animator objects per AnimationEX object is fixed to 1
  //if animator has already been created return Signal for it.
  if(!mAnimatorMap.empty())
  {
    return mAnimatorMap[1]->GetTickSignal();
  }

  //Create new shared pointer of animator and add to map.
  //Map is still maintained to not break multiple animators functionality.
  //Which can be added as enhancement in future.
  std::shared_ptr<Internal::Animator> animator( new DaliExtTV::Internal::Animator( mAnimatorDuration, mDefaultAlphaFunction ) );

  mAnimatorMap.insert(make_pair(1, animator));

  return animator->GetTickSignal();
}

/*
AnimatorSignalType& AnimationEX::UpdateSignal(TimePeriod duration, unsigned int& animatorID)
{
	return UpdateSignal(duration, mDefaultAlphaFunction, animatorID);
}

AnimatorSignalType& AnimationEX::UpdateSignal(TimePeriod duration, AlphaFunction alpha, unsigned int& animatorID)
{
	AnimatorIndex idx = GenerateAnimatorID();
	DALI_ASSERT_DEBUG(idx > 0);
	
	//Create new animator and add to map.
	Internal::Animator* animator = new DaliExtTV::Internal::Animator(duration, alpha);
	//Duration of AnimationEX will be extended to accomodate the duration of animator if AnimationEX duration is less than animator duration.
	ExtendDuration(duration);
	
	mAnimatorMap.insert(make_pair(idx, animator));
	
	// pass the ID to application.
	animatorID = idx;
	
	//animator id will be returned to app, so app can enable or disable/delete the animator
	//App will not be able to delete the animator by itself, instead it should be marked for delete
	//And AnimationEX will do it for the App in the next update loop.
	return animator->GetTickSignal();
}

void AnimationEX::AnimatorEnable(unsigned int id)
{
	ActivateAnimator(id, true);
}

void AnimationEX::AnimatorDisable(unsigned int id)
{
	ActivateAnimator(id, false);
}

void AnimationEX::ActivateAnimator(unsigned int id, bool flag)
{
	//invalid id check 
	if(id <= ANI_BASE_INDEX-1 || id > ANI_MAX_INDEX)
	{
		return;
	}
	
	AnimatorMapIter iter = mAnimatorMap.find(id);
	
	if(iter != mAnimatorMap.end())
	{
        Internal::Animator* animator = iter->second;
		
		animator->Enable(flag);
	}
}

void AnimationEX::AnimatorDelete(unsigned int id)
{
	//invalid id check 
	if(id <= ANI_BASE_INDEX-1 || id > ANI_MAX_INDEX)
	{
		return;
	}
	
	AnimatorMapIter iter = mAnimatorMap.find(id);
	
	if(iter != mAnimatorMap.end())
	{
        Internal::Animator* animator = iter->second;
		
		animator->MarkForDelete();
	}
}
*/

void AnimationEX::RemoveAllAnimators()
{
  if( mAnimatorMap.empty() )
  {
    DALIEXT_ERRLOG("AnimatorMap is empty");
    return;
  }
  mAnimatorMap.clear();
}

void AnimationEX::InsertIndexInAvailableIndexSet(AnimatorMapIter iter)
{
   //insert ID into available set.
  std::pair<std::set<AnimatorIndex>::iterator, bool> ret = mAvailableIndex.insert( iter->first );
  if( ret.second == false )
  {
    DALI_ASSERT_DEBUG( ! "ID already present in free pool" );
  }
}

bool AnimationEX::OnAniTimerTick()
{
  //update progress and alpha value for animators based on alphafunction.
  Update(); 
  return true;
}

void AnimationEX::Update()
{
  bool looped =  false;
  bool finished = false;

  if (mState == PAUSED)
  {
    DALIEXT_ERRLOG("State is PAUSED, No need to emit Update event");
    return;
  }

  if (mState == STOPPED)
  {
    // Short circuit when animation isn't running
    Stop();
    return;
  }

  if (mState == PLAYING)
  {
    float elapsedSeconds = mAniTimer.GetInterval()/1000.0f; //TIMER_INTERVAL/1000.0f;
    mElapsedSeconds += elapsedSeconds * mSpeedFactor;
  }

  Vector2 playRangeSeconds = mPlayRange * mDurationSeconds;

  if( 0 == mLoopCount )
  {
    // loop forever
    WrapInPlayRange(mElapsedSeconds, playRangeSeconds);

    UpdateAnimators();
  }
  else if( mCurrentLoop < mLoopCount - 1) // '-1' here so last loop iteration uses play once below
  {
    // looping
    looped =  (mState == PLAYING &&
           (( mSpeedFactor > 0.0f && mElapsedSeconds > playRangeSeconds.y )  ||
          ( mSpeedFactor < 0.0f && mElapsedSeconds < playRangeSeconds.x )) );

    WrapInPlayRange( mElapsedSeconds, playRangeSeconds );

    UpdateAnimators();

    if(looped)
    {
      ++mCurrentLoop;
    }
  }
  else
  {
    // playing once (and last mCurrentLoop)
    finished = (mState == PLAYING &&
          (( mSpeedFactor > 0.0f && mElapsedSeconds > playRangeSeconds.y )  ||
           ( mSpeedFactor < 0.0f && mElapsedSeconds < playRangeSeconds.x )) );

    UpdateAnimators();

    if(finished)
    {
      // loop iterations come to this else branch for their final iterations
      if( mCurrentLoop < mLoopCount )
      {
        ++mCurrentLoop;
        DALI_ASSERT_DEBUG(mCurrentLoop == mLoopCount);
      }

      mElapsedSeconds = playRangeSeconds.x;
      mState = STOPPED;
    }
  }
}

void AnimationEX::UpdateAnimators()
{
  const Vector2 playRange( mPlayRange * mDurationSeconds );
  float elapsedSecondsClamped = Clamp( mElapsedSeconds, playRange.x, playRange.y );
  AnimatorMap tickAnimationsMap;

  for ( AnimatorMapIter iter = mAnimatorMap.begin(); iter != mAnimatorMap.end(); )
  {
    std::shared_ptr<Internal::Animator> animator( iter->second );
    if( animator->IsMarkedForDelete() ) //Remove from animator map and delete animator.
    {
      InsertIndexInAvailableIndexSet( iter );
      iter = mAnimatorMap.erase( iter ); //erase animator pair from map
    }
    else
    {
      ++iter;
    }
  }
  // Since animations can be unreferenced during the signal emissions, iterators into animationPointers may be invalidated.
  // First copy and reference the animations, then emit signals
  tickAnimationsMap.insert( mAnimatorMap.begin(), mAnimatorMap.end() );

  for ( AnimatorMapIter iter = tickAnimationsMap.begin(); iter != tickAnimationsMap.end(); ++iter)
  {
    std::shared_ptr<Internal::Animator> animator( iter->second );
    if( animator->IsEnabled() )
    {
      const float initialDelay( mAnimatorDuration.delaySeconds );
      if( elapsedSecondsClamped >= initialDelay )
      {
        // Calculate a progress specific to each individual animator
        float progress( 1.0f );
        const float animatorDuration = mAnimatorDuration.durationSeconds;
        if( animatorDuration > 0.0f ) // animators can be "immediate"
        {
          progress = Clamp( ( elapsedSecondsClamped - initialDelay ) / animatorDuration, 0.0f , 1.0f );
        }
        animator->UpdateAnimator( progress );
      }
    }
  }
}

} // namespace DaliExtTv

