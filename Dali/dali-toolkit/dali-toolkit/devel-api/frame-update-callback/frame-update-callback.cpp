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
#include <dali-toolkit/devel-api/frame-update-callback/frame-update-callback.h>

// EXTERNAL INCLUDES
#include <dali/dali.h>
#include <dali/devel-api/common/stage-devel.h>

// INTERNAL INCLUDES
#include <dali-toolkit/internal/frame-update-callback/frame-update-callback-impl.h>

namespace Dali
{

namespace Toolkit
{

FrameUpdateCallback FrameUpdateCallback::New()
{
  IntrusivePtr<Internal::FrameUpdateCallback> callback = Internal::FrameUpdateCallback::New();
  return FrameUpdateCallback( callback.Get() );
}

FrameUpdateCallback::FrameUpdateCallback( Toolkit::Internal::FrameUpdateCallback *implementation )
  : BaseHandle( implementation )
{

}

void FrameUpdateCallback::AddCallback( FrameCallbackFunction updateCallback )
{
  Internal::GetImplementation( *this ).AddCallback( updateCallback );
}

void FrameUpdateCallback::AddMainThreadCallback( FrameCallbackFunction updateCallback )
{
  Internal::GetImplementation( *this ).AddMainThreadCallback( updateCallback );
}

void FrameUpdateCallback::RemoveCallback()
{
	Internal::GetImplementation(*this).RemoveCallback();
}

bool FrameUpdateCallback::GetPosition( unsigned int id, Vector3& position )
{
  return Internal::GetImplementation( *this ).GetPosition( id, position );
}

bool FrameUpdateCallback::SetPosition( unsigned int id, const Vector3& position )
{
  return Internal::GetImplementation( *this ).SetPosition( id, position );
}

bool FrameUpdateCallback::BakePosition( unsigned int id, const Dali::Vector3& position )
{
  return Internal::GetImplementation( *this ).BakePosition( id, position );
}

bool FrameUpdateCallback::GetSize( uint32_t id, Vector3& size )
{
  return Internal::GetImplementation( *this ).GetSize( id, size );
}

bool FrameUpdateCallback::SetSize( uint32_t id, const Vector3& size )
{
  return Internal::GetImplementation( *this ).SetSize( id, size );
}

bool FrameUpdateCallback::BakeSize( uint32_t id, const Vector3& size )
{
  return Internal::GetImplementation( *this ).BakeSize( id, size );
}

bool FrameUpdateCallback::GetScale( unsigned int id, Dali::Vector3& scale )
{
  return Internal::GetImplementation( *this ).GetScale( id, scale );
}

bool FrameUpdateCallback::SetScale( unsigned int id, const Dali::Vector3& scale )
{
  return Internal::GetImplementation( *this ).SetScale( id, scale );
}

bool FrameUpdateCallback::BakeScale( unsigned int id, const Dali::Vector3& scale )
{
  return Internal::GetImplementation( *this ).BakeScale( id, scale );
}

bool FrameUpdateCallback::GetColor( unsigned int id, Dali::Vector4& color )
{
  return Internal::GetImplementation( *this ).GetColor( id, color );
}

bool FrameUpdateCallback::SetColor( unsigned int id, const Dali::Vector4& color )
{
  return Internal::GetImplementation( *this ).SetColor( id, color );
}

bool FrameUpdateCallback::BakeColor( unsigned int id, const Dali::Vector4& color )
{
  return Internal::GetImplementation( *this ).BakeColor( id, color );
}

void FrameUpdateCallback::SetAlphaFunction(Dali::AlphaFunction alphaFunction)
{
	return Internal::GetImplementation(*this).SetAlphaFunction(alphaFunction);
}

Dali::AlphaFunction FrameUpdateCallback::GetAlphaFunction() const
{
	return Internal::GetImplementation(*this).GetAlphaFunction();
}

void FrameUpdateCallback::SetDuration(float seconds)
{
	return Internal::GetImplementation(*this).SetDuration(seconds);
}

float FrameUpdateCallback::GetDuration() const
{
	return Internal::GetImplementation(*this).GetDuration();
}
} // namespace Toolkit
} // namespace Dali
