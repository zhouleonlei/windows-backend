#ifndef _DALI_VD_ANIMATIONEX_H_
#define _DALI_VD_ANIMATIONEX_H_

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

#include <dali/dali.h>

#include <map>
#include <set>
#include <memory>
#define TIMER_INTERVAL 17 //timer interval is fixed at 17ms which is ~60fps


using namespace std;
using namespace Dali;

namespace DaliExtTV
{

namespace Internal
{
class Animator;
}
typedef Signal< void (float, float) > AnimatorSignalType; ///< AnimationEX update signal type

class AnimationEX;
typedef IntrusivePtr<AnimationEX> AnimationEXPtr; ///< AnimationEX IntrusivePtr type
typedef Signal< void () > AnimationEXSignalType; ///< AnimationEX finished signal type
typedef unsigned int AnimatorIndex;

/**
 * @brief DaliExtTV::AnimationEX can be used to animate the properties of any number of objects, typically Actors.
 * 
 * An example animation setup is shown below:
 *
 * @code
 *
 * struct MyProgram
 * {
 *   Actor mActor; // The object we wish to animate
 *   DaliExtTV::AnimationEXPtr mAnimation; // Keep this to control the animation
 *
 *	 void Callback(float progress, float alpha)
 *	 {
 *	 	//Code for handling the mActor's property (position, scale etc,.) based on the alpha.
 *	 }
 * }
 *
 * // ...To play the animation
 *
 * mAnimation = DaliExtTV::AnimationEX::New(3.0f, 1.0f); // duration 3 seconds, delay 1 second.
 * mAnimation->UpdateSignal().Connect(this, &MyProgram::Callback);
 * mAnimation->Play();
 *
 * @endcode
 *
 * Note that in the following example, the "Finish" signal will be emitted:
 *
 * @code
 *
 * void MyProgram::ExampleCallback()
 * {
 *   std::cout << "Animation has finished" << std::endl;
 * }
 *
 * void MyProgram::ExampleAnimation( DaliExtTV::AnimationEXPtr animation )
 * {
 *   unsigned int AnimatorID = 0; 		//Animator ID for furter reference
 *	 animation->SetDuration(5.0f); 		//duration changed to 5 seconds
 *	 animation->SetDelay(1.0f); 		//delay of 1 second
 *	 animation->UpdateSignal().Connect(this, &MyProgram::Callback);
 *   animation->FinishedSignal().Connect(this, &MyProgram::ExampleCallback);
 *   animation->Play();
 * }
 *
 * Actor actor = Actor::New();
 * Stage::GetCurrent().Add( actor );
 *
 *
 * DaliExtTV::AnimationEXPtr mAnimation = DaliExtTV::AnimationEX::New(3.0f); // duration 3 seconds
 *
 * // Fire animation and save the animator ID.
 * ExampleAnimation( mAnimation );
 *
 * // The animation will continue, and "Animation has finished" will be printed after 5 seconds.
 *
 * @endcode
 *
 * If the "Finish" signal or "Update" signal is connected to a member function of an object, it must be disconnected before the object is destroyed.
 * This is typically done in the object destructor, and requires either the Dali::Connection object or Dali::Animation handle to be stored.
 *
 * The overall animation time is the sum of duration and delay.
 * Only one Animator is created internally per AnimationEX.
 *
 * Signals
 * |Method                   |
 * |-------------------------|
 * |FinishedSignal()         |
 * |UpdateSignal()			 |
 *
 * Actions
 * |%Animation method called |
 * |-------------------------|
 * |Play()                   |
 * |Stop()                   |
 * |Pause()                  |
 * 
 */
class AnimationEX : public ConnectionTracker, public Dali::RefObject
{
public:
	
	/**
	* @brief Enumeration for what state the animation is in.
	*/
	enum EState
	{
		STOPPED,
        PLAYING,
        PAUSED
	};
	
public:

	/**
	* @brief Creates an initialized AnimationEX.
	*
	* The animation will not loop.
	* The default alpha function is linear.
	*
	* @param[in] duration The duration in seconds.
	* @param[in] delay The delay in seconds.
	* @return A IntrusivePtr<AnimationEX> to a newly allocated Dali resource.
	* @note duration or delay can not be negative(to be >= 0.0f) and delay is ignored if duration is 0 or negative
	*/
    static AnimationEXPtr New( float duration , float delay = 0.0f );

	/**
	* @brief Play the animation.
	*/
	void Play(void); 
	
	/**
	* @brief Stops the animation.
	*/
	void Stop(void);
	
	/**
	* @brief Pauses the animation.
	*/
	void Pause(void);
	
	/**
	* @brief Clears the animation.
	*
	* This will efectively stop the animation and clear all the animators connected with this animation.
	*/
	void Clear(void);
	
	/**
	* @brief Queries the state of the animation.
	*
	* @return The AnimationEX::EState
	*/
    EState GetState(void) const;
	
	/**
	* @brief Sets the default alpha function for an animation.
	*
	* This is applied to individual property animators, if no further alpha functions are supplied.
	* in UpdateSignal(duration, id) call.
	*
	* @param[in] alpha The default alpha function
	*/
    void SetDefaultAlphaFunction(AlphaFunction alphaFunction);
	
	/**
	* @brief Retrieves the default alpha function for an animation.
	*
	* @return The default alpha function
	*/
	AlphaFunction GetDefaultAlphaFunction(void) const;
	
	/**
	* @brief Sets the duration of an animation.
	*
	* @param[in] durationSeconds The duration in seconds
	* @pre DurationSeconds must be greater than zero.
	*/
	void SetDuration(float durationSeconds);
	
	/**
	* @brief Retrieves the duration of an animation.
	*
	* @return The duration in seconds
	*/
	float GetDuration(void) const;
	
	/**
	* @brief Sets the delay of an animation.
	*
	* @param[in] delay The delay in seconds
	*/
	void SetDelay(float delay);
	
	/**
	* @brief Retrieves the delay of an animation.
	*
	* @return The delay in seconds
	*/
	float GetDelay(void) const;
	
	/**
	* @brief Specifies a speed factor for the animation.
	*
	* The speed factor is a multiplier of the normal velocity of the animation. Values between [0,1] will
	* slow down the animation and values above one will speed up the animation. It is also possible to specify a negative multiplier
	* to play the animation in reverse.
	*
	* @param[in] factor A value which will multiply the velocity
	*/
	void SetSpeedFactor( float factor );
	
	/**
	* @brief Retrieves the speed factor of the animation.
	*
	* @return Speed factor
	*/
	float GetSpeedFactor(void) const;
	
	/**
	* @brief Enables looping for 'count' repeats.
	*
	* A zero is the same as SetLooping(true) i.e. repeat forever.
	* If Play() Stop() or 'count' loops is reached, the loop counter will reset.
	* Setting this parameter does not cause the animation to Play().
	*
	* @param[in] count The number of times to loop
	*/
	void SetLoopCount(int count);
	
	/**
	* @brief Gets the loop count.
	*
	* A zero is the same as SetLooping(true) ie repeat forever.
	* The loop count is initially 1 for play once.
	*
	* @return The number of times to loop
	*/
	int GetLoopCount(void);
	
	/**
	* @brief Sets whether the animation will loop.
	*
	* This function resets the loop count and should not be used with SetLoopCount(int).
	* Setting this parameter does not cause the animation to Play().
	*
	* @param[in] looping True if the animation will loop
	*/
	void SetLooping(bool looping);
	
	/**
	* @brief Queries whether the animation will loop.
	*
	* @return True if the animation will loop
	*/
	bool IsLooping() const;
	
	/**
	* @brief Gets the current loop count.
	*
	* A value 0 to GetLoopCount() indicating the current loop count when looping.
	*
	* @return The current number of loops that have occured
	*/
	int GetCurrentLoopCount(void) const;
	
	/**
	* @brief Sets the progress of the animation.
	*
	* The animation will play (or continue playing) from this point. The progress
	* must be in the 0-1 interval or in the play range interval if defined ( See @ref Animation::SetPlayRange ),
	* otherwise, it will be ignored.
	*
	* @SINCE_1_0.0
	* @param[in] progress The new progress as a normalized value between [0,1]
	* or between the play range if specified
	*/
	void SetCurrentProgress( float progress );
	
	/**
	* @brief Retrieves the current progress of the animation.
	*
	* @return The current progress as a normalized value between [0,1]
	*/
	float GetCurrentProgress(void);
	
	/**
	* @brief Sets the playing range.
	*
	* Animation will play between the values specified. Both values ( range.x and range.y ) should be between 0-1,
	* otherwise they will be ignored. If the range provided is not in proper order ( minimum,maximum ), it will be reordered.
	*
	* @param[in] range Two values between [0,1] to specify minimum and maximum progress. The
	* animation will play between those values
	*/
	void SetPlayRange( const Vector2& range );
	
	/**
	* @brief Gets the playing range.
	*
	* @return The play range defined for the animation
	*/
	Vector2 GetPlayRange() const;
	
	/**
	* @brief Gets the elapsed Time of animation
	*
	* @return The elapsed Time for the Animation.
	*/
	float GetTime(void) const;
	
	/*Do not find it necessary when Application itself calls Play for the Animation.
	if it is absolutely required to match clutter/volt implementation, will be done later*/
	//void StartSignal();
	
	/**
	* @brief Connects to this signal to be notified when an Animation's animators have finished.
	*
	* @return A signal object to connect with
	*/
	AnimationEXSignalType& FinishedSignal(void);
	
	/**
	* @brief Connects to this signal to be notified when the Animation's animator has updated the alpha value based on the progress and alpha function.
	*
	* Application needs to handle the animatable property of an actor based on the alpha value passed via signal emit.
	*
	* @return A signal object of the animator to connect with
	*/
	AnimatorSignalType& UpdateSignal(void);
	
	/********* Future Enhancements if required to support multiple animators per Animation *********/
	
	/**
	* @brief Connects to this signal to be notified when an Animation's animator has updated the alpha value based on its progress and alpha function.
	*
	* Application needs to handle the animatable property of an actor based on the alpha value passed via signal.
	* A new Animator is created internally on calling this function and id of this animator is returned to the caller.
	* This id can be used to modify the animator (see: AnimatorEnable(id), AnimatorDisable(id) and AnimatorDelete(id))
	*
	* @param[in] duration The effect will occur during this time period
	* @param[out] animatorID The unique ID returned to the caller to handle the animator.
	* @return A signal object of the animator to connect with
	*/
	//AnimatorSignalType& UpdateSignal(TimePeriod duration, unsigned int& animatorID);
	
	/**
	* @brief Connects to this signal to be notified when an Animation's animator has updated the alpha value based on its progress and alpha function.
	*
	* Application needs to handle the animatable property of an actor based on the alpha value passed via signal.
	* A new Animator is created internally on calling this function and id of this animator is returned to the caller.
	* This id can be used to modify the animator (see: AnimatorEnable(id), AnimatorDisable(id) and AnimatorDelete(id))
	*
	* @param[in] duration The effect will occur during this time period
	* @param[in] alpha The alpha function to apply
	* @param[out] animatorID The unique ID returned to the caller to handle the animator.
	* @return A signal object of the animator to connect with
	*/
	//AnimatorSignalType& UpdateSignal(TimePeriod duration, AlphaFunction alpha, unsigned int& animatorID);
	
	/**
	* @brief Enables the animator of the current animation.
	*
	* This animator will be enabled in next update loop (if Disabled before, see: AnimatorDisable(id))
	*
	* @param[in] id The unique ID of the animator.
	* @pre id needs to be of this AnimationEX.
	*/
	//void AnimatorEnable(unsigned int id);
	
	/**
	* @brief Disables the animator of the current animation.
	*
	* This animator will be disabled in next update loop and UpdateSignal will not be emited until enabled.
	*
	* @param[in] id The unique ID of the animator.
	* @pre id needs to be of this AnimationEX.
	*/
	//void AnimatorDisable(unsigned int id);
	
	/**
	* @brief Deletes the animator of the current animation.
	*
	* This animator will be deleted in next update loop and UpdateSignal will not be stopped.
	*
	* @param[in] id The unique ID of the animator.
	* @pre id needs to be of this AnimationEX.
	*/
    //void AnimatorDelete(unsigned int id);

private:
	
	/**
	* Construct a new AnimationEX.
	* @param[in] duration The duration of the animation in seconds.
	* @param[in] delay The delay of the animator in seconds.
	* @param[in] speedFactor A value which will multiply the velocity.
	* @param[in] loopCount The number of times to loop
	*/
    AnimationEX(float duration, float delay, float speedFactor = 1.0f, int loopCount = 1);
	
	/**
	* A reference counted object may only be deleted by calling Unreference()
	*/
    virtual ~AnimationEX();
	
    //undefined copy constructor.
    AnimationEX(const AnimationEX& timer);
	
    //undefined assignement operator.
    AnimationEX& operator=(const AnimationEX& timer);

private:
	float					mDurationSeconds;
	float					mDelaySeconds;
	Vector2 				mPlayRange;
	float					mElapsedSeconds;
	Timer 					mAniTimer;
	float					mSpeedFactor;
	int 					mLoopCount;
	int						mCurrentLoop;
	EState 					mState;
	bool					mStartCalled;
	AlphaFunction 			mDefaultAlphaFunction;
	
	std::set<AnimatorIndex> mAvailableIndex;
    typedef std::map<AnimatorIndex, std::shared_ptr<Internal::Animator>> AnimatorMap;
    typedef std::map<AnimatorIndex, std::shared_ptr<Internal::Animator>>::iterator AnimatorMapIter;
	AnimatorMap				mAnimatorMap;

	AnimationEXSignalType	mFinishedSignal;
	
	//Single animator.
	TimePeriod 				mAnimatorDuration;
	
private:

	/**
	* This is connected to Dali:Timer (mAniTimer) TickSignal.
	* @return True.
	*/
	bool OnAniTimerTick(void);
	
	/**
	* This causes the animators to change the properties of objects at the callers end based on alpa value.
	* @pre The animation is playing or paused.
	*/
	void Update(void);
	
	/**
	* Helper for Update, also used to Delete the animator when it is marked for delete.
	*/
	void UpdateAnimators(void);
	
	/**
	* Extends the duration when an animator is added with TimePeriod that exceeds current duration.
	* @param[in] timePeriod The time period for an animator.
	*/
	void ExtendDuration( const TimePeriod& timePeriod );
	
	/**
	* Helper to delete all the animators of the animation.
	*/
	void RemoveAllAnimators(void);
	
	/**
    * Helper to add the id to free pool (mAvailableIndex)
	* @param[in] iter iterator of animators map (AnimatorMap)
	*/
    void InsertIndexInAvailableIndexSet(AnimatorMapIter iter);
	
	/**
	* Helper to Enable/Disable an animator.
	* param[in] id The unique ID of the animator.
	* @param[in] flag True if animator needs to be enabled.
	*/
	void ActivateAnimator(unsigned int id, bool flag);
	
	/**
	* Emit the Finished signal
	*/
	void EmitFinishedSignal(void);
	
	/**
	* Helper to generate unique id for a newly created animator
	* @return The unique ID for the animator.
	*/
	AnimatorIndex GenerateAnimatorID(void);
};

} // namespace DaliExtTV

#endif	/* _DALI_VD_ANIMATIONEX_H_ */
