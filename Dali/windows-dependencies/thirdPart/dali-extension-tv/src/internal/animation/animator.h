#ifndef _DALI_VD_ANIMATOR_H_
#define _DALI_VD_ANIMATOR_H_

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

using namespace std;
using namespace Dali;

namespace DaliExtTV
{
	
typedef Signal< void (float, float) > AnimatorSignalType;

namespace Internal
{

/* App will not be allowed to access any APIs of Animators */
class Animator
{

public:

	/**
	* Constructor.
	* @param[in] period The effect will occur during this time period
	* @param[in] alpha The alpha function to apply
	*/
    Animator( TimePeriod period, AlphaFunction alpha )
    : mDuration( period.durationSeconds ),
    mInitialDelay( period.delaySeconds ),
	mAlphaFunction( alpha ),
	mAlphaResult(0.0f),
	mCurrentProgress( 0.0f ),
	mEnabled(true),
	mToRemove(false)
	{
	}
	
	/**
	* Virtual destructor.
	*/
	virtual ~Animator()
	{
	}
	
	/**
	* @brief Get the initial delay of the animator.
	*
	* @return true delay in seconds
	*/
	float GetInitialDelay()
	{
		return mInitialDelay;
	}
	
	/**
	* @brief Get the duration of the animator.(with delay included)
	*
	* @return true duration in seconds
	*/
    float GetDuration()
	{
		return mDuration;
	}
	
	/**
	* @brief Check if the animator is enabled/disabled
	*
	* @return true if enabled.
	*/
	bool IsEnabled()
	{
		return mEnabled;
	}
	
	/**
	* @brief Check if the animator is supposed to be deleted.
	*
	* @return true if to be deleted.
	*/
	bool IsMarkedForDelete()
	{
		return mToRemove;
	}
	
	/**
	* @brief Update animator attached to the animation.
	*
	* @param[in] progress current progress of the animation.
	*/
	void UpdateAnimator(float progress)
	{
		mCurrentProgress = progress;
		mAlphaResult = ApplyAlphaFunction(progress);
		
		EmitTickSignal();
	}
	
	/**
	* @brief Enable/Disable animator to emit UpdateSignal.
	*
	* @param[in] value true to enable.
	*/
	void Enable(bool value)
	{
		mEnabled = value;
	}
	
	/**
	* @brief Mark the animator for delete. (animation handles the deletion part)
	*/
	void MarkForDelete()
	{
		mEnabled = false;
		mToRemove = true;
	}
	
	/**
	* @brief Connects to this signal to be notified when an animator has updated the alpha value based on its progress and alpha function.
	*
	* @return A signal object to connect with
	*/
	AnimatorSignalType& GetTickSignal()
	{
		return mTickSignal;
	}
	
private:

	float					mDuration;
	float					mInitialDelay; ///> initial delay in seconds.
    AlphaFunction           mAlphaFunction;
	float					mAlphaResult;
	float					mCurrentProgress;
	bool 					mEnabled;
	bool					mToRemove;
	AnimatorSignalType		mTickSignal;
	
private:

	/**
	* Emit the UpdateSignal on animation timer tick.
	*/
	void EmitTickSignal()
	{
		if ( !mTickSignal.Empty() )
		{
			mTickSignal.Emit(mCurrentProgress, mAlphaResult);
		}
	}

	/**
	* Helper function to evaluate a cubic bezier curve assuming first point is at 0.0 and last point is at 1.0
	* @param[in] p0 First control point of the bezier curve
	* @param[in] p1 Second control point of the bezier curve
	* @param[in] t A floating point value between 0.0 and 1.0
	* @return Value of the curve at progress t
	*/
	inline float EvaluateCubicBezier( float p0, float p1, float t ) const
	{
		float tSquare = t*t;
		return 3.0f*(1.0f-t)*(1.0f-t)*t*p0 + 3.0f*(1.0f-t)*tSquare*p1 + tSquare*t;
	}
	
	/*
	* Applies the alpha function to the specified progress
	* @param[in] Current progress
	* @return The progress after the alpha function has been aplied
	*/
    float ApplyAlphaFunction( float progress )
	{
		float result = progress;
		AlphaFunction::Mode alphaFunctionMode( mAlphaFunction.GetMode() );

		if( alphaFunctionMode == AlphaFunction::BUILTIN_FUNCTION )
		{
			switch( mAlphaFunction.GetBuiltinFunction())
			{
				case AlphaFunction::DEFAULT:
				case AlphaFunction::LINEAR:
				{
				  break;
				}
				case AlphaFunction::REVERSE:
				{
				  result = 1.0f-progress;
				  break;
				}
				case AlphaFunction::EASE_IN_SQUARE:
				{
				  result = progress * progress;
				  break;
				}
				case AlphaFunction::EASE_OUT_SQUARE:
				{
				  result = 1.0f - (1.0f-progress) * (1.0f-progress);
				  break;
				}
				case AlphaFunction::EASE_IN:
				{
				  result = progress * progress * progress;
				  break;
				}
				case AlphaFunction::EASE_OUT:
				{
				  result = (progress-1.0f) * (progress-1.0f) * (progress-1.0f) + 1.0f;
				  break;
				}
				case AlphaFunction::EASE_IN_OUT:
				{
				  result = progress*progress*(3.0f-2.0f*progress);
				  break;
				}
				case AlphaFunction::EASE_IN_SINE:
				{
				  result = -1.0f * cosf(progress * Math::PI_2) + 1.0f;
				  break;
				}
				case AlphaFunction::EASE_OUT_SINE:
				{
				  result = sinf(progress * Math::PI_2);
				  break;
				}
				case AlphaFunction::EASE_IN_OUT_SINE:
				{
				  result = -0.5f * (cosf(Math::PI * progress) - 1.0f);
				  break;
				}
				case AlphaFunction::BOUNCE:
				{
				  result = sinf(progress * Math::PI);
				  break;
				}
				case AlphaFunction::SIN:
				{
				  result = 0.5f - cosf(progress * 2.0f * Math::PI) * 0.5f;
				  break;
				}
				case AlphaFunction::EASE_OUT_BACK:
				{
				  const float sqrt2 = 1.70158f;
				  progress -= 1.0f;
				  result = 1.0f + progress * progress * ( ( sqrt2 + 1.0f ) * progress + sqrt2 );
				  break;
				}
				case AlphaFunction::COUNT:
				{
				  break;
				}
			}
		}
		else if(  alphaFunctionMode == AlphaFunction::CUSTOM_FUNCTION )
		{
			AlphaFunctionPrototype customFunction = mAlphaFunction.GetCustomFunction();
			if( customFunction )
			{
				result = customFunction(progress);
			}
		}
		else
		{
			//If progress is very close to 0 or very close to 1 we don't need to evaluate the curve as the result will
			//be almost 0 or almost 1 respectively
			if( ( progress > Math::MACHINE_EPSILON_1 ) && ((1.0f - progress) > Math::MACHINE_EPSILON_1) )
			{
				Dali::Vector4 controlPoints = mAlphaFunction.GetBezierControlPoints();

				static const float tolerance = 0.001f;  //10 iteration max

				//Perform a binary search on the curve
				float lowerBound(0.0f);
				float upperBound(1.0f);
				float currentT(0.5f);
				float currentX = EvaluateCubicBezier( controlPoints.x, controlPoints.z, currentT);
				while( fabs( progress - currentX ) > tolerance )
				{
					if( progress > currentX )
					{
						lowerBound = currentT;
					}
					else
					{
						upperBound = currentT;
					}
					currentT = (upperBound+lowerBound)*0.5f;
					currentX = EvaluateCubicBezier( controlPoints.x, controlPoints.z, currentT);
				}
				result = EvaluateCubicBezier( controlPoints.y, controlPoints.w, currentT);
			}
		}

		return result;
	}
	
};

} // namespace Internal

} // namespace DaliExtTV

#endif	/* _DALI_VD_ANIMATOR_H_ */
