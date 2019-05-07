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

#include "common.h"
#include <dali-toolkit/devel-api/frame-update-callback/frame-update-callback.h>

#ifdef __cplusplus
extern "C" {
#endif


SWIGEXPORT void * SWIGSTDCALL CSharp_Dali_FrameUpdateCallback_New() {
  Dali::Toolkit::FrameUpdateCallback result = Dali::Toolkit::FrameUpdateCallback::New();
  void * jresult = new Dali::Toolkit::FrameUpdateCallback( result );

  return jresult;
}

SWIGEXPORT Dali::Toolkit::FrameUpdateCallback * SWIGSTDCALL CSharp_Dali_FrameUpdateCallback_SWIGUpcast( Dali::Toolkit::FrameUpdateCallback *jarg1 ) {
  return jarg1;
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_FrameUpdateCallback_AddCallback( Dali::Toolkit::FrameUpdateCallback *jarg1, Dali::Toolkit::FrameCallbackFunction callback )
{
  jarg1->AddCallback( callback );
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_FrameUpdateCallback_AddMainThreadCallback( Dali::Toolkit::FrameUpdateCallback *jarg1, Dali::Toolkit::FrameCallbackFunction callback )
{
  jarg1->AddMainThreadCallback( callback );
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_FrameUpdateCallback_RemoveCallback(Dali::Toolkit::FrameUpdateCallback *jarg1)
{
	jarg1->RemoveCallback();
}

SWIGEXPORT void* SWIGSTDCALL CSharp_Dali_FrameUpdateCallback_GetPosition( Dali::Toolkit::FrameUpdateCallback *jarg1, int actorID )
{
  void * jresult;
  Dali::Toolkit::FrameUpdateCallback *arg1 = jarg1;
  Dali::Vector3 result;

  {
    try {
      arg1->GetPosition( actorID, result );
    }
    catch( std::out_of_range& e ) {
      {
        SWIG_CSharpException( SWIG_IndexError, const_cast<char*>( e.what() ) ); return 0;
      };
    }
    catch( std::exception& e ) {
      {
        SWIG_CSharpException( SWIG_RuntimeError, const_cast<char*>( e.what() ) ); return 0;
      };
    }
    catch( Dali::DaliException e ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, e.condition ); return 0;
      };
    }
    catch( ... ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, "unknown error" ); return 0;
      };
    }
  }

  jresult = new Dali::Vector3( ( const Dali::Vector3 & )result );
  return jresult;
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_FrameUpdateCallback_SetPosition( Dali::Toolkit::FrameUpdateCallback *jarg1, int actorID, void * jarg2 )
{
  void * jresult;
  Dali::Toolkit::FrameUpdateCallback *arg1 = jarg1;
  Dali::Vector3 position = *((Dali::Vector3*)jarg2);

  {
    try {
      arg1->SetPosition( actorID, position );
    }
    catch( std::out_of_range& e ) {
      {
        SWIG_CSharpException( SWIG_IndexError, const_cast<char*>( e.what() ) ); return;
      };
    }
    catch( std::exception& e ) {
      {
        SWIG_CSharpException( SWIG_RuntimeError, const_cast<char*>( e.what() ) ); return;
      };
    }
    catch( Dali::DaliException e ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, e.condition ); return;
      };
    }
    catch( ... ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, "unknown error" ); return;
      };
    }
  }
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_FrameUpdateCallback_BakePosition( Dali::Toolkit::FrameUpdateCallback *jarg1, int actorID, void * jarg2 )
{
  void * jresult;
  Dali::Toolkit::FrameUpdateCallback *arg1 = jarg1;
  Dali::Vector3 position = *((Dali::Vector3*)jarg2);

  {
    try {
      arg1->BakePosition( actorID, position );
    }
    catch( std::out_of_range& e ) {
      {
        SWIG_CSharpException( SWIG_IndexError, const_cast<char*>( e.what() ) ); return;
      };
    }
    catch( std::exception& e ) {
      {
        SWIG_CSharpException( SWIG_RuntimeError, const_cast<char*>( e.what() ) ); return;
      };
    }
    catch( Dali::DaliException e ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, e.condition ); return;
      };
    }
    catch( ... ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, "unknown error" ); return;
      };
    }
  }
}

SWIGEXPORT void* SWIGSTDCALL CSharp_Dali_FrameUpdateCallback_GetSize( Dali::Toolkit::FrameUpdateCallback *jarg1, int actorID )
{
  void * jresult;
  Dali::Toolkit::FrameUpdateCallback *arg1 = jarg1;
  Dali::Vector3 result;

  {
    try {
      arg1->GetSize( actorID, result );
    }
    catch( std::out_of_range& e ) {
      {
        SWIG_CSharpException( SWIG_IndexError, const_cast<char*>( e.what() ) ); return 0;
      };
    }
    catch( std::exception& e ) {
      {
        SWIG_CSharpException( SWIG_RuntimeError, const_cast<char*>( e.what() ) ); return 0;
      };
    }
    catch( Dali::DaliException e ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, e.condition ); return 0;
      };
    }
    catch( ... ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, "unknown error" ); return 0;
      };
    }
  }

  jresult = new Dali::Vector3( ( const Dali::Vector3 & )result );
  return jresult;
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_FrameUpdateCallback_SetSize( Dali::Toolkit::FrameUpdateCallback *jarg1, int actorID, void *jarg2 )
{
  void * jresult;
  Dali::Toolkit::FrameUpdateCallback *arg1 = jarg1;
  Dali::Vector3 size = *((Dali::Vector3*)jarg2);

  {
    try {
      arg1->SetSize( actorID, size );
    }
    catch( std::out_of_range& e ) {
      {
        SWIG_CSharpException( SWIG_IndexError, const_cast<char*>( e.what() ) ); return;
      };
    }
    catch( std::exception& e ) {
      {
        SWIG_CSharpException( SWIG_RuntimeError, const_cast<char*>( e.what() ) ); return;
      };
    }
    catch( Dali::DaliException e ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, e.condition ); return;
      };
    }
    catch( ... ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, "unknown error" ); return;
      };
    }
  }
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_FrameUpdateCallback_BakeSize( Dali::Toolkit::FrameUpdateCallback *jarg1, int actorID, void *jarg2 )
{
  void * jresult;
  Dali::Toolkit::FrameUpdateCallback *arg1 = jarg1;
  Dali::Vector3 size = *((Dali::Vector3*)jarg2);

  {
    try {
      arg1->BakeSize( actorID, size );
    }
    catch( std::out_of_range& e ) {
      {
        SWIG_CSharpException( SWIG_IndexError, const_cast<char*>( e.what() ) ); return;
      };
    }
    catch( std::exception& e ) {
      {
        SWIG_CSharpException( SWIG_RuntimeError, const_cast<char*>( e.what() ) ); return;
      };
    }
    catch( Dali::DaliException e ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, e.condition ); return;
      };
    }
    catch( ... ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, "unknown error" ); return;
      };
    }
  }
}

SWIGEXPORT void* SWIGSTDCALL CSharp_Dali_FrameUpdateCallback_GetScale( Dali::Toolkit::FrameUpdateCallback *jarg1, int actorID )
{
  void * jresult;
  Dali::Toolkit::FrameUpdateCallback *arg1 = jarg1;
  Dali::Vector3 result;

  {
    try {
      arg1->GetScale( actorID, result );
    }
    catch( std::out_of_range& e ) {
      {
        SWIG_CSharpException( SWIG_IndexError, const_cast<char*>( e.what() ) ); return 0;
      };
    }
    catch( std::exception& e ) {
      {
        SWIG_CSharpException( SWIG_RuntimeError, const_cast<char*>( e.what() ) ); return 0;
      };
    }
    catch( Dali::DaliException e ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, e.condition ); return 0;
      };
    }
    catch( ... ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, "unknown error" ); return 0;
      };
    }
  }

  jresult = new Dali::Vector3( ( const Dali::Vector3 & )result );
  return jresult;
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_FrameUpdateCallback_SetScale( Dali::Toolkit::FrameUpdateCallback *jarg1, int actorID, void *jarg2 )
{
  void * jresult;
  Dali::Toolkit::FrameUpdateCallback *arg1 = jarg1;
  Dali::Vector3 scale = *((Dali::Vector3*)jarg2);

  {
    try {
      arg1->SetScale( actorID, scale );
    }
    catch( std::out_of_range& e ) {
      {
        SWIG_CSharpException( SWIG_IndexError, const_cast<char*>( e.what() ) ); return;
      };
    }
    catch( std::exception& e ) {
      {
        SWIG_CSharpException( SWIG_RuntimeError, const_cast<char*>( e.what() ) ); return;
      };
    }
    catch( Dali::DaliException e ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, e.condition ); return;
      };
    }
    catch( ... ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, "unknown error" ); return;
      };
    }
  }
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_FrameUpdateCallback_BakeScale( Dali::Toolkit::FrameUpdateCallback *jarg1, int actorID, void *jarg2 )
{
  void * jresult;
  Dali::Toolkit::FrameUpdateCallback *arg1 = jarg1;
  Dali::Vector3 scale = *((Dali::Vector3*)jarg2);

  {
    try {
      arg1->BakeScale( actorID, scale );
    }
    catch( std::out_of_range& e ) {
      {
        SWIG_CSharpException( SWIG_IndexError, const_cast<char*>( e.what() ) ); return;
      };
    }
    catch( std::exception& e ) {
      {
        SWIG_CSharpException( SWIG_RuntimeError, const_cast<char*>( e.what() ) ); return;
      };
    }
    catch( Dali::DaliException e ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, e.condition ); return;
      };
    }
    catch( ... ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, "unknown error" ); return;
      };
    }
  }
}

SWIGEXPORT void* SWIGSTDCALL CSharp_Dali_FrameUpdateCallback_GetColor( Dali::Toolkit::FrameUpdateCallback *jarg1, int actorID )
{
  void * jresult;
  Dali::Toolkit::FrameUpdateCallback *arg1 = jarg1;
  Dali::Vector4 result;

  {
    try {
      arg1->GetColor( actorID, result );
    }
    catch( std::out_of_range& e ) {
      {
        SWIG_CSharpException( SWIG_IndexError, const_cast<char*>( e.what() ) ); return 0;
      };
    }
    catch( std::exception& e ) {
      {
        SWIG_CSharpException( SWIG_RuntimeError, const_cast<char*>( e.what() ) ); return 0;
      };
    }
    catch( Dali::DaliException e ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, e.condition ); return 0;
      };
    }
    catch( ... ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, "unknown error" ); return 0;
      };
    }
  }

  jresult = new Dali::Vector4( ( const Dali::Vector4 & )result );
  return jresult;
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_FrameUpdateCallback_SetColor( Dali::Toolkit::FrameUpdateCallback *jarg1, int actorID, void *jarg2 )
{
  void * jresult;
  Dali::Toolkit::FrameUpdateCallback *arg1 = jarg1;
  Dali::Vector4 color = *((Dali::Vector4*)jarg2);

  {
    try {
      arg1->SetColor( actorID, color );
    }
    catch( std::out_of_range& e ) {
      {
        SWIG_CSharpException( SWIG_IndexError, const_cast<char*>( e.what() ) ); return;
      };
    }
    catch( std::exception& e ) {
      {
        SWIG_CSharpException( SWIG_RuntimeError, const_cast<char*>( e.what() ) ); return;
      };
    }
    catch( Dali::DaliException e ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, e.condition ); return;
      };
    }
    catch( ... ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, "unknown error" ); return;
      };
    }
  }
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_FrameUpdateCallback_BakeColor( Dali::Toolkit::FrameUpdateCallback *jarg1, int actorID, void *jarg2)
{
  void * jresult;
  Dali::Toolkit::FrameUpdateCallback *arg1 = jarg1;
  Dali::Vector4 color = *((Dali::Vector4*)jarg2);

  {
    try {
      arg1->BakeColor( actorID, color );
    }
    catch( std::out_of_range& e ) {
      {
        SWIG_CSharpException( SWIG_IndexError, const_cast<char*>( e.what() ) ); return;
      };
    }
    catch( std::exception& e ) {
      {
        SWIG_CSharpException( SWIG_RuntimeError, const_cast<char*>( e.what() ) ); return;
      };
    }
    catch( Dali::DaliException e ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, e.condition ); return;
      };
    }
    catch( ... ) {
      {
        SWIG_CSharpException( SWIG_UnknownError, "unknown error" ); return;
      };
    }
  }
}

#ifdef __cplusplus
}
#endif

