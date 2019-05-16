/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd.
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
#include <dali-toolkit/internal/frame-update-callback/frame-callback.h>

// EXTERNAL HEADER
#include <dali/devel-api/update/update-proxy.h>

// INTERNAL HEADER
#include <dali/integration-api/trigger-event-factory.h>

namespace Dali
{

namespace Toolkit
{

namespace Internal
{

FrameCallback::FrameCallback()
: mUpdateProxy(NULL),
  mFrameCallback(NULL),
  mMainThreadFrameCallback(NULL),
  mDurationSeconds(0.0f),
  mElapsedSeconds(0.0f),
  mAlphaFunction(Dali::AlphaFunction::DEFAULT),
  mProgress(0.0f)
{
  mTriggerFactory = new TriggerEventFactory();

  eventTrigger = mTriggerFactory->CreateTriggerEvent( MakeCallback( this, &FrameCallback::ProcessCallback ), TriggerEventInterface::KEEP_ALIVE_AFTER_TRIGGER );
}

FrameCallback::~FrameCallback()
{
  mUpdateProxy = NULL;
  mFrameCallback = NULL;
  mMainThreadFrameCallback = NULL;

  mTriggerFactory->DestroyTriggerEvent( eventTrigger );
  delete mTriggerFactory;
}

void FrameCallback::SetUpdateCallback( FrameCallbackFunction callback )
{
  mFrameCallback = callback;
}

void FrameCallback::SetMainThreadUpdateCallback( FrameCallbackFunction callback )
{
  mMainThreadFrameCallback = callback;
}

void FrameCallback::RemoveFrameUpdateCallback( )
{
  mElapsedSeconds = 0.0f;
  mProgress = 0.0f;
  //mDurationSeconds = 0.0f;
  mFrameCallback = NULL;
}

void FrameCallback::RemoveMainThreadFrameUpdateCallback()
{
  mMainThreadFrameCallback = NULL;
}

bool FrameCallback::GetPosition( unsigned int id, Vector3& position ) const
{
  if(mUpdateProxy != NULL)
  {
    return mUpdateProxy->GetPosition( id, position );
  }
  return false;
}

bool FrameCallback::SetPosition( unsigned int id, const Dali::Vector3& position )
{
  if( mUpdateProxy != NULL )
  {
    return mUpdateProxy->SetPosition( id, position );
  }
  return false;
}

bool FrameCallback::BakePosition( unsigned int id, const Vector3& position )
{
  if(mUpdateProxy != NULL)
  {
    return mUpdateProxy->BakePosition( id, position );
  }
  return false;
}

bool FrameCallback::GetSize( uint32_t id, Vector3& size ) const
{
  if( mUpdateProxy != NULL )
  {
    return mUpdateProxy->GetSize( id, size );
  }
  return false;
}

bool FrameCallback::SetSize( uint32_t id, const Vector3& size )
{
  if( mUpdateProxy != NULL )
  {
    return mUpdateProxy->SetSize( id, size );
  }
  return false;
}

bool FrameCallback::BakeSize( uint32_t id, const Vector3& size )
{
  if( mUpdateProxy != NULL )
  {
    return mUpdateProxy->BakeSize( id, size );
  }
  return false;
}

bool FrameCallback::GetScale( unsigned int id, Vector3& scale) const
{
  if(mUpdateProxy != NULL)
  {
    return	mUpdateProxy->GetScale( id, scale );
  }
  return false;
}

bool FrameCallback::SetScale( unsigned int id, const Dali::Vector3& scale )
{
  if( mUpdateProxy != NULL )
  {
    return	mUpdateProxy->SetScale( id, scale );
  }
  return false;
}

bool FrameCallback::BakeScale( unsigned int id, const Vector3& scale )
{
  if(mUpdateProxy != NULL)
  {
    return	mUpdateProxy->BakeScale( id, scale );
  }
  return false;
}

bool FrameCallback::GetColor( unsigned int id, Vector4& color ) const
{
  if(mUpdateProxy != NULL)
  {
    return	mUpdateProxy->GetColor( id, color);
  }
  return false;
}

bool FrameCallback::SetColor( unsigned int id, const Dali::Vector4& color ) const
{
  if( mUpdateProxy != NULL )
  {
    return mUpdateProxy->SetColor( id, color );
  }
  return false;
}

bool FrameCallback::BakeColor( unsigned int id, const Vector4& color ) const
{
  if(mUpdateProxy != NULL)
  {
    return mUpdateProxy->BakeColor( id, color );
  }
  return false;
}

void FrameCallback::SetAlphaFunction(Dali::AlphaFunction alphaFunction)
{
	mAlphaFunction = alphaFunction;
}

Dali::AlphaFunction FrameCallback::GetAlphaFunction() const
{
	return mAlphaFunction;
}

void FrameCallback::SetDuration(float seconds)
{
	mDurationSeconds = seconds;
}

float FrameCallback::GetDuration() const
{
	return mDurationSeconds;
}

float FrameCallback::ApplyAlphaFunction(float progress) const
{
	float result = progress;

	Dali::AlphaFunction::Mode alphaFunctionMode(mAlphaFunction.GetMode());
	if (alphaFunctionMode == AlphaFunction::BUILTIN_FUNCTION)
	{
		switch (mAlphaFunction.GetBuiltinFunction())
		{
		case AlphaFunction::DEFAULT:
		case AlphaFunction::LINEAR:
		{
			break;
		}
		case AlphaFunction::REVERSE:
		{
			result = 1.0f - progress;
			break;
		}
		case AlphaFunction::EASE_IN_SQUARE:
		{
			result = progress * progress;
			break;
		}
		case AlphaFunction::EASE_OUT_SQUARE:
		{
			result = 1.0f - (1.0f - progress) * (1.0f - progress);
			break;
		}
		case AlphaFunction::EASE_IN:
		{
			result = progress * progress * progress;
			break;
		}
		case AlphaFunction::EASE_OUT:
		{
			result = (progress - 1.0f) * (progress - 1.0f) * (progress - 1.0f) + 1.0f;
			break;
		}
		case AlphaFunction::EASE_IN_OUT:
		{
			result = progress * progress*(3.0f - 2.0f*progress);
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
			result = 1.0f + progress * progress * ((sqrt2 + 1.0f) * progress + sqrt2);
			break;
		}
		case AlphaFunction::COUNT:
		{
			break;
		}
		}
	}
	else if (alphaFunctionMode == AlphaFunction::CUSTOM_FUNCTION)
	{
		AlphaFunctionPrototype customFunction = mAlphaFunction.GetCustomFunction();
		if (customFunction)
		{
			result = customFunction(progress);
		}
	}
	else
	{
		//If progress is very close to 0 or very close to 1 we don't need to evaluate the curve as the result will
		//be almost 0 or almost 1 respectively
		if ((progress > Math::MACHINE_EPSILON_1) && ((1.0f - progress) > Math::MACHINE_EPSILON_1))
		{
			Dali::Vector4 controlPoints = mAlphaFunction.GetBezierControlPoints();

			static const float tolerance = 0.001f;  //10 iteration max

			//Perform a binary search on the curve
			float lowerBound(0.0f);
			float upperBound(1.0f);
			float currentT(0.5f);
			float currentX = EvaluateCubicBezier(controlPoints.x, controlPoints.z, currentT);
			while (fabsf(progress - currentX) > tolerance)
			{
				if (progress > currentX)
				{
					lowerBound = currentT;
				}
				else
				{
					upperBound = currentT;
				}
				currentT = (upperBound + lowerBound)*0.5f;
				currentX = EvaluateCubicBezier(controlPoints.x, controlPoints.z, currentT);
			}
			result = EvaluateCubicBezier(controlPoints.y, controlPoints.w, currentT);
		}
	}

	return result;

}

void FrameCallback::Update( Dali::UpdateProxy& updateProxy, float elapsedSeconds )
{
  mElapsedSeconds += elapsedSeconds;

  if(mUpdateProxy != NULL)
  {
    mUpdateProxy = NULL;
  }
  
  mUpdateProxy = &updateProxy;

  eventTrigger->Trigger();
  float elapsedSecondsClamped = Clamp(mElapsedSeconds, 0.0f, mDurationSeconds);
  float progress(1.0f);

  if (mDurationSeconds > 0.0f)
  {
	  progress = Clamp(elapsedSecondsClamped / mDurationSeconds, 0.0f, 1.0f);
  }

  float alpha = ApplyAlphaFunction(progress);
  mProgress = alpha;
  
  if(mFrameCallback != NULL)
  {
    mFrameCallback(alpha);
  }
}

void FrameCallback::ProcessCallback()
{
  if( mMainThreadFrameCallback != NULL )
  {
    mMainThreadFrameCallback( mProgress );
  }
}
} // namespace Internal
} // namespace Toolkit
} // namespace Dali
