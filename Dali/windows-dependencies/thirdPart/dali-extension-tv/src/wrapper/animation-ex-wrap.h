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

#ifndef __DALIEXTTV_ANIMATIONEX_WRAP_H__
#define __DALIEXTTV_ANIMATIONEX_WRAP_H__

#include "common-wrap.h"
#include "animation-ex.h"

#ifdef __cplusplus
extern "C"  {
#endif

SWIGEXPORT void * SWIGSTDCALL CSharp_DaliExt_AnimationEX_New(float jarg1, float jarg2) 
{
  void * jresult ;
  float arg1, arg2 ;
  DaliExtTV::AnimationEXPtr result;

  arg1 = (float)jarg1; 
  arg2 = (float)jarg2; 
  {
    try {
      result = DaliExtTV::AnimationEX::New(arg1, arg2);
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0; 
      };
    }
  }
  jresult = new DaliExtTV::AnimationEXPtr( (const DaliExtTV::AnimationEXPtr &)result );
  return jresult;
}


SWIGEXPORT void SWIGSTDCALL CSharp_DaliExt_delete_AnimationEX(void * jarg1) 
{
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  {
    try {
      delete arg1;
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return ; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return ; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return ; 
      };
    }
  }
}


SWIGEXPORT void SWIGSTDCALL CSharp_DaliExt_AnimationEX_SetDuration(void * jarg1, float jarg2) 
{

  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  float arg2 ;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  arg2 = (float)jarg2; 
  {
    try {
      (arg1)->Get()->SetDuration(arg2);
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return ; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return ; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return ; 
      };
    }
  }
}


SWIGEXPORT float SWIGSTDCALL CSharp_DaliExt_AnimationEX_GetDuration(void * jarg1) 
{

  float jresult ;
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  float result;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  {
    try {
	  result = (float)(arg1)->Get()->GetDuration();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0; 
      };
    }
  }
  jresult = result; 
  return jresult;
}


SWIGEXPORT void SWIGSTDCALL CSharp_DaliExt_AnimationEX_SetDelay(void * jarg1, float jarg2) 
{
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  float arg2 ;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  arg2 = (float)jarg2; 
  {
    try {
      (arg1)->Get()->SetDelay(arg2);
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return ; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return ; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return ; 
      };
    }
  }
}


SWIGEXPORT float SWIGSTDCALL CSharp_DaliExt_AnimationEX_GetDelay(void * jarg1) 
{
  float jresult ;
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  float result;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  {
    try {
	  result = (float)(arg1)->Get()->GetDelay();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0; 
      };
    }
  }
  jresult = result; 
  return jresult;
}


SWIGEXPORT void SWIGSTDCALL CSharp_DaliExt_AnimationEX_SetLooping(void * jarg1, unsigned int jarg2) 
{
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr  *) 0 ;
  bool arg2 ;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  arg2 = jarg2 ? true : false; 
  {
    try {
      (arg1)->Get()->SetLooping(arg2);
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return ; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return ; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return ; 
      };
    }
  }
}


SWIGEXPORT void SWIGSTDCALL CSharp_DaliExt_AnimationEX_SetLoopCount(void * jarg1, int jarg2) 
{
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  int arg2 ;

  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  arg2 = (int)jarg2; 
  {
    try {
      (arg1)->Get()->SetLoopCount(arg2);
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return ; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return ; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return ; 
      };
    }
  }
}


SWIGEXPORT int SWIGSTDCALL CSharp_DaliExt_AnimationEX_GetLoopCount(void * jarg1) 
{
  int jresult ;
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  int result;

  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  {
    try {
      result = (int)(arg1)->Get()->GetLoopCount();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0; 
      };
    }
  }
  jresult = result; 
  return jresult;
}


SWIGEXPORT int SWIGSTDCALL CSharp_DaliExt_AnimationEX_GetCurrentLoopCount(void * jarg1) 
{
  int jresult ;
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  int result;

  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  {
    try {
      result = (int)(arg1)->Get()->GetCurrentLoopCount();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0; 
      };
    }
  }
  jresult = result; 
  return jresult;
}


SWIGEXPORT unsigned int SWIGSTDCALL CSharp_DaliExt_AnimationEX_IsLooping(void * jarg1) 
{
  unsigned int jresult ;
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  bool result;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  {
    try {
	  result = (bool)(arg1)->Get()->IsLooping();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0; 
      };
    }
  }
  jresult = result; 
  return jresult;
}


SWIGEXPORT void SWIGSTDCALL CSharp_DaliExt_AnimationEX_SetDefaultAlphaFunction(void * jarg1, void * jarg2) 
{
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  Dali::AlphaFunction arg2 ;
  Dali::AlphaFunction *argp2 ;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  argp2 = (Dali::AlphaFunction *)jarg2; 
  if (!argp2) {
    SWIG_CSharpSetPendingExceptionArgument(SWIG_CSharpArgumentNullException, "Attempt to dereference null Dali::AlphaFunction", 0);
    return ;
  }
  arg2 = *argp2; 
  {
    try {
      (arg1)->Get()->SetDefaultAlphaFunction(arg2);
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return ; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return ; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return ; 
      };
    }
  }
}


SWIGEXPORT void * SWIGSTDCALL CSharp_DaliExt_AnimationEX_GetDefaultAlphaFunction(void * jarg1) 
{
  void * jresult ;
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  Dali::AlphaFunction result;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  {
    try {
	  result = (arg1)->Get()->GetDefaultAlphaFunction();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0; 
      };
    }
  }
  jresult = new Dali::AlphaFunction((const Dali::AlphaFunction &)result); 
  return jresult;
}


SWIGEXPORT void SWIGSTDCALL CSharp_DaliExt_AnimationEX_SetCurrentProgress(void * jarg1, float jarg2) 
{
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  float arg2 ;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  arg2 = (float)jarg2; 
  {
    try {
      (arg1)->Get()->SetCurrentProgress(arg2);
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return ; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return ; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return ; 
      };
    }
  }
}


SWIGEXPORT float SWIGSTDCALL CSharp_DaliExt_AnimationEX_GetCurrentProgress(void * jarg1) 
{
  float jresult ;
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  float result;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  {
    try {
      result = (float)(arg1)->Get()->GetCurrentProgress();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0; 
      };
    }
  }
  jresult = result; 
  return jresult;
}


SWIGEXPORT void SWIGSTDCALL CSharp_DaliExt_AnimationEX_SetSpeedFactor(void * jarg1, float jarg2) 
{
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  float arg2 ;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  arg2 = (float)jarg2; 
  {
    try {
      (arg1)->Get()->SetSpeedFactor(arg2);
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return ; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return ; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return ; 
      };
    }
  }
}


SWIGEXPORT float SWIGSTDCALL CSharp_DaliExt_AnimationEX_GetSpeedFactor(void * jarg1) 
{
  float jresult ;
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  float result;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  {
    try {
	  result = (float)(arg1)->Get()->GetSpeedFactor();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0; 
      };
    }
  }
  jresult = result; 
  return jresult;
}


SWIGEXPORT void SWIGSTDCALL CSharp_DaliExt_AnimationEX_SetPlayRange(void * jarg1, void * jarg2) 
{
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  Dali::Vector2 *arg2 = 0 ;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  arg2 = (Dali::Vector2 *)jarg2;
  if (!arg2) {
    SWIG_CSharpSetPendingExceptionArgument(SWIG_CSharpArgumentNullException, "Dali::Vector2 const & type is null", 0);
    return ;
  } 
  {
    try {
      (arg1)->Get()->SetPlayRange((Dali::Vector2 const &)*arg2);
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return ; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return ; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return ; 
      };
    }
  }
}


SWIGEXPORT void * SWIGSTDCALL CSharp_DaliExt_AnimationEX_GetPlayRange(void * jarg1) 
{
  void * jresult ;
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  Dali::Vector2 result;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  {
    try {
      result = (arg1)->Get()->GetPlayRange();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0; 
      };
    }
  }
  jresult = new Dali::Vector2((const Dali::Vector2 &)result); 
  return jresult;
}


SWIGEXPORT float SWIGSTDCALL CSharp_DaliExt_AnimationEX_GetTime(void * jarg1) 
{
  float jresult ;
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  float result;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  {
    try {
	  result = (float)(arg1)->Get()->GetTime();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0; 
      };
    }
  }
  jresult = result; 
  return jresult;
}


SWIGEXPORT void SWIGSTDCALL CSharp_DaliExt_AnimationEX_Play(void * jarg1) 
{
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;

  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  {
    try {
      (arg1)->Get()->Play();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return ; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return ; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return ; 
      };
    }
  }
}

SWIGEXPORT void SWIGSTDCALL CSharp_DaliExt_AnimationEX_Pause(void * jarg1) 
{
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  {
    try {
      (arg1)->Get()->Pause();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return ; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return ; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return ; 
      };
    }
  }
}


SWIGEXPORT int SWIGSTDCALL CSharp_DaliExt_AnimationEX_GetState(void * jarg1) 
{
  int jresult ;
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  DaliExtTV::AnimationEX::EState result;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  {
    try {
      result = (DaliExtTV::AnimationEX::EState)(arg1)->Get()->GetState();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0; 
      };
    }
  }
  jresult = (int)result; 
  return jresult;
}


SWIGEXPORT void SWIGSTDCALL CSharp_DaliExt_AnimationEX_Stop(void * jarg1) 
{
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  {
    try {
      (arg1)->Get()->Stop();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return ; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return ; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return ; 
      };
    }
  }
}


SWIGEXPORT void SWIGSTDCALL CSharp_DaliExt_AnimationEX_Clear(void * jarg1) 
{
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  {
    try {
      (arg1)->Get()->Clear();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return ; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return ; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return ; 
      };
    }
  }
}


SWIGEXPORT void * SWIGSTDCALL CSharp_DaliExt_AnimationEX_FinishedSignal(void * jarg1) 
{
  void * jresult ;
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  DaliExtTV::AnimationEXSignalType *result = 0 ;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  {
    try {
      result = (DaliExtTV::AnimationEXSignalType *) &(arg1)->Get()->FinishedSignal();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0; 
      };
    }
  }
  jresult = (void *)result; 
  return jresult;
}

SWIGEXPORT unsigned int SWIGSTDCALL CSharp_DaliExt_AnimationEX_FinishedSignal_Empty(void * jarg1) 
{
  unsigned int jresult ;
  Dali::Signal< void () > *arg1 = (Dali::Signal< void () > *) 0 ;
  bool result;
  
  arg1 = (Dali::Signal< void () > *)jarg1; 
  {
    try {
	  result = (bool)(arg1)->Empty();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0; 
      };
    }
  }
  jresult = result; 
  return jresult;
}


SWIGEXPORT unsigned long SWIGSTDCALL CSharp_DaliExt_AnimationEXSignal_FinishedSignal_GetConnectionCount(void * jarg1) 
{
  unsigned long jresult ;
  Dali::Signal< void () > *arg1 = (Dali::Signal< void () > *) 0 ;
  std::size_t result;
  
  arg1 = (Dali::Signal< void () > *)jarg1; 
  {
    try {
	  result = (arg1)->GetConnectionCount();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0; 
      };
    }
  }
  jresult = (unsigned long)result; 
  return jresult;
}


SWIGEXPORT void SWIGSTDCALL CSharp_DaliExt_AnimationEXSignal_FinishedSignal_Connect(void * jarg1, void * jarg2) 
{
  Dali::Signal< void () > *arg1 = (Dali::Signal< void () > *) 0 ;
  void (*func)() = (void (*)()) 0 ;
  
  arg1 = (Dali::Signal< void () > *)jarg1; 
  func = (void (*)())jarg2; 
  {
    try {
	  (arg1)->Connect( func );
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return ; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return ; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return ; 
      };
    }
  }
}


SWIGEXPORT void SWIGSTDCALL CSharp_DaliExt_AnimationEXSignal_FinishedSignal_Disconnect(void * jarg1, void * jarg2) 
{
  Dali::Signal< void () > *arg1 = (Dali::Signal< void () > *) 0 ;
  void (*func)() = (void (*)()) 0 ;
  
  arg1 = (Dali::Signal< void () > *)jarg1; 
  func = (void (*)())jarg2; 
  {
    try {
	  (arg1)->Disconnect( func );
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return ; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return ; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return ; 
      };
    }
  }
}

SWIGEXPORT void * SWIGSTDCALL CSharp_Dali_new_AnimationEX_FinishedSignal() 
{
  void * jresult ;
  Dali::Signal< void () > *result = 0 ;
  
  {
    try {
      result = (Dali::Signal< void () > *)new Dali::Signal< void () >();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0; 
      };
    }
  }
  jresult = (void *)result; 
  return jresult;
}


SWIGEXPORT void SWIGSTDCALL CSharp_DaliExt_delete_AnimationEX_FinishedSignal(void * jarg1) 
{
  Dali::Signal< void () > *arg1 = (Dali::Signal< void () > *) 0 ;
  
  arg1 = (Dali::Signal< void () > *)jarg1; 
  {
    try {
      delete arg1;
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return ; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return ; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return ; 
      };
    }
  }
}


SWIGEXPORT void * SWIGSTDCALL CSharp_DaliExt_AnimationEX_UpdateSignal(void * jarg1) 
{
  void * jresult ;
  DaliExtTV::AnimationEXPtr *arg1 = (DaliExtTV::AnimationEXPtr *) 0 ;
  DaliExtTV::AnimatorSignalType *result = 0 ;
  
  arg1 = (DaliExtTV::AnimationEXPtr *)jarg1; 
  {
    try {
      result = (DaliExtTV::AnimatorSignalType *) &(arg1)->Get()->UpdateSignal();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0; 
      };
    }
  }
  jresult = (void *)result; 
  return jresult;
}


SWIGEXPORT unsigned int SWIGSTDCALL CSharp_DaliExt_AnimationEX_UpdateSignal_Empty(void * jarg1) 
{
  unsigned int jresult ;
  Dali::Signal< void (float, float) > *arg1 = (Dali::Signal< void (float, float) > *) 0 ;
  bool result;
  
  arg1 = (Dali::Signal< void (float, float) > *)jarg1; 
  {
    try {
	  result = (bool)(arg1)->Empty();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0; 
      };
    }
  }
  jresult = result; 
  return jresult;
}


SWIGEXPORT unsigned long SWIGSTDCALL CSharp_DaliExt_AnimationEXSignal_UpdateSignal_GetConnectionCount(void * jarg1) 
{
  unsigned long jresult ;
  Dali::Signal< void (float, float) > *arg1 = (Dali::Signal< void (float, float) > *) 0 ;
  std::size_t result;
  
  arg1 = (Dali::Signal< void (float, float) > *)jarg1; 
  {
    try {
	  result = (arg1)->GetConnectionCount();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0; 
      };
    }
  }
  jresult = (unsigned long)result; 
  return jresult;
}


SWIGEXPORT void SWIGSTDCALL CSharp_DaliExt_AnimationEXSignal_UpdateSignal_Connect(void * jarg1, void * jarg2) 
{
  Dali::Signal< void (float, float) > *arg1 = (Dali::Signal< void (float, float) > *) 0 ;
  void (*func)(float, float) = (void (*)(float, float)) 0 ;
  
  arg1 = (Dali::Signal< void (float, float) > *)jarg1; 
  func = (void (*)(float, float))jarg2; 
  {
    try {
	  (arg1)->Connect( func );
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return ; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return ; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return ; 
      };
    }
  }
}


SWIGEXPORT void SWIGSTDCALL CSharp_DaliExt_AnimationEXSignal_UpdateSignal_Disconnect(void * jarg1, void * jarg2) 
{
  Dali::Signal< void (float, float) > *arg1 = (Dali::Signal< void (float, float) > *) 0 ;
  void (*func)(float, float) = (void (*)(float, float)) 0 ;
  
  arg1 = (Dali::Signal< void (float, float) > *)jarg1; 
  func = (void (*)(float, float))jarg2; 
  {
    try {
	  (arg1)->Disconnect( func );
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return ; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return ; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return ; 
      };
    }
  }
}

SWIGEXPORT void * SWIGSTDCALL CSharp_Dali_new_AnimationEX_UpdateSignal() 
{
  void * jresult ;
  Dali::Signal< void (float, float) > *result = 0 ;
  
  {
    try {
      result = (Dali::Signal< void (float, float) > *)new Dali::Signal< void (float, float) >();
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0; 
      };
    }
  }
  jresult = (void *)result; 
  return jresult;
}


SWIGEXPORT void SWIGSTDCALL CSharp_DaliExt_delete_AnimationEX_UpdateSignal(void * jarg1) 
{
  Dali::Signal< void (float, float) > *arg1 = (Dali::Signal< void (float, float) > *) 0 ;
  
  arg1 = (Dali::Signal< void (float, float) > *)jarg1; 
  {
    try {
      delete arg1;
    } catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return ; 
      };
    } catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return ; 
      };
    } catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return ; 
      };
    }
  }
}

#ifdef __cplusplus
}
#endif

#endif //__DALIEXTTV_ANIMATIONEX_WRAP_H__
