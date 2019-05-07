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
  mMainThreadFrameCallback(NULL)
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

void FrameCallback::Update( Dali::UpdateProxy& updateProxy, float elapsedSeconds )
{
  mElapsedSeconds = elapsedSeconds;

  if(mUpdateProxy != NULL)
  {
    mUpdateProxy = NULL;
  }
  
  mUpdateProxy = &updateProxy;

  eventTrigger->Trigger();
  
  if(mFrameCallback != NULL)
  {
    mFrameCallback( elapsedSeconds );
  }
}

void FrameCallback::ProcessCallback()
{
  if( mMainThreadFrameCallback != NULL )
  {
    mMainThreadFrameCallback( mElapsedSeconds );
  }
}
}
}
} // namespace DaliExt
