/** Copyright (c) 2019 Samsung Electronics Co., Ltd.
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

#ifndef CSHARP_TRANSITION_EFFECTS
#define CSHARP_TRANSITION_EFFECTS
#endif

#include "common.h"
#include <dali-toolkit/devel-api/transition-effects/cube-transition-effect.h>
#include <dali-toolkit/devel-api/transition-effects/cube-transition-cross-effect.h>
#include <dali-toolkit/devel-api/transition-effects/cube-transition-fold-effect.h>
#include <dali-toolkit/devel-api/transition-effects/cube-transition-wave-effect.h>

#include <dali/public-api/rendering/texture.h>


SWIGINTERN bool Dali_Signal_Sl_void_Sp_Dali_Toolkit_CubeTransitionEffect_SP__Sg__Empty(Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > const *self) {
  return self->Empty();
}
SWIGINTERN std::size_t Dali_Signal_Sl_void_Sp_Dali_Toolkit_CubeTransitionEffect_SP__Sg__GetConnectionCount(Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > const *self) {
  return self->GetConnectionCount();
}
SWIGINTERN void Dali_Signal_Sl_void_Sp_Dali_Toolkit_CubeTransitionEffect_SP__Sg__Connect(Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *self, void(*func)(Dali::Toolkit::CubeTransitionEffect)) {
  self->Connect(func);
}
SWIGINTERN void Dali_Signal_Sl_void_Sp_Dali_Toolkit_CubeTransitionEffect_SP__Sg__Disconnect(Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *self, void(*func)(Dali::Toolkit::CubeTransitionEffect)) {
  self->Disconnect(func);
}
SWIGINTERN void Dali_Signal_Sl_void_Sp_Dali_Toolkit_CubeTransitionEffect_SP__Sg__Emit(Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *self, Dali::Toolkit::CubeTransitionEffect arg) {
  self->Emit(arg);
}


#ifdef __cplusplus
extern "C" {
#endif

// cube-transition-effect.h

SWIGEXPORT Dali::Toolkit::Control * SWIGSTDCALL CSharp_Dali_CubeTransitionEffect_SWIGUpcast(Dali::Toolkit::CubeTransitionEffect *jarg1) {
  return (Dali::Toolkit::Control *)jarg1;
}

SWIGEXPORT void * SWIGSTDCALL CSharp_Dali_new_CubeTransitionEffect() {
  Dali::Toolkit::CubeTransitionEffect* result;

  {
    try {
      result = new Dali::Toolkit::CubeTransitionEffect();
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0;
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0;
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition); return 0;
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0;
      };
    }
  }

  return result;
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_delete_CubeTransitionEffect(void * jarg1) {
  Dali::Toolkit::CubeTransitionEffect *arg1 = (Dali::Toolkit::CubeTransitionEffect *) 0;

  arg1 = (Dali::Toolkit::CubeTransitionEffect *)jarg1;
  {
    try {
      delete arg1;
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return;
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return;
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition); return;
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return;
      };
    }
  }
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_CubeTransitionEffect_SetTransitionDuration(void * jarg1, float duration) {
  Dali::Toolkit::CubeTransitionEffect *arg1 = (Dali::Toolkit::CubeTransitionEffect *) 0;

  arg1 = (Dali::Toolkit::CubeTransitionEffect *)jarg1;
  {
    try {
      (arg1)->SetTransitionDuration(duration);
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what()));
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what()));
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition);
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error");
      };
    }
  }
}

SWIGEXPORT float SWIGSTDCALL CSharp_Dali_CubeTransitionEffect_GetTransitionDuration(void * jarg1) {
  Dali::Toolkit::CubeTransitionEffect *arg1 = (Dali::Toolkit::CubeTransitionEffect *) 0;

  float result = 0.0f;
  arg1 = (Dali::Toolkit::CubeTransitionEffect *)jarg1;
  {
    try {
      result = (arg1)->GetTransitionDuration();
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0;
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0;
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition); return 0;
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0;
      };
    }
  }

  return result;
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_CubeTransitionEffect_SetCubeDisplacement(void * jarg1, float displacement) {
  Dali::Toolkit::CubeTransitionEffect *arg1 = (Dali::Toolkit::CubeTransitionEffect *) 0;

  arg1 = (Dali::Toolkit::CubeTransitionEffect *)jarg1;
  {
    try {
      (arg1)->SetCubeDisplacement(displacement);
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what()));
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what()));
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition);
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error");
      };
    }
  }
}

SWIGEXPORT float SWIGSTDCALL CSharp_Dali_CubeTransitionEffect_GetCubeDisplacement(void * jarg1) {
  Dali::Toolkit::CubeTransitionEffect *arg1 = (Dali::Toolkit::CubeTransitionEffect *) 0;

  float result = 0.0f;
  arg1 = (Dali::Toolkit::CubeTransitionEffect *)jarg1;
  {
    try {
      result = (arg1)->GetCubeDisplacement();
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what()));
        return 0.0f;
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what()));
        return 0.0f;
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition);
        return 0.0f;
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error");
        return 0.0f;
      };
    }
  }

  return result;
}

SWIGEXPORT unsigned int SWIGSTDCALL CSharp_Dali_CubeTransitionEffect_IsTransitioning(void * jarg1) {
  Dali::Toolkit::CubeTransitionEffect *arg1 = (Dali::Toolkit::CubeTransitionEffect *) 0;

  bool result = false;
  arg1 = (Dali::Toolkit::CubeTransitionEffect *)jarg1;
  {
    try {
      result = (arg1)->IsTransitioning();
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return false;
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return false;
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition); return false;
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return false;
      };
    }
  }

  unsigned int jresult = result; // convert bool to unsigned int.
  return jresult;
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_CubeTransitionEffect_SetCurrentTexture(void* jarg1, void* jarg2) {
  Dali::Toolkit::CubeTransitionEffect *arg1 = (Dali::Toolkit::CubeTransitionEffect *) 0;

  arg1 = (Dali::Toolkit::CubeTransitionEffect *)jarg1;
  Dali::Texture* argp2 = (Dali::Texture*)jarg2;
  if (!argp2) {
    SWIG_CSharpSetPendingExceptionArgument(SWIG_CSharpArgumentNullException, "Attempt to dereference null Dali::Texture", 0);
    return ;
  }

  {
    try {
      (arg1)->SetCurrentTexture(*argp2);
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what()));
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what()));
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition);
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error");
      };
    }
  }
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_CubeTransitionEffect_SetTargetTexture(void* jarg1, void* jarg2) {
  Dali::Toolkit::CubeTransitionEffect *arg1 = (Dali::Toolkit::CubeTransitionEffect *) 0;

  arg1 = (Dali::Toolkit::CubeTransitionEffect *)jarg1;
  Dali::Texture* argp2 = (Dali::Texture*)jarg2;
  if (!argp2) {
    SWIG_CSharpSetPendingExceptionArgument(SWIG_CSharpArgumentNullException, "Attempt to dereference null Dali::Texture", 0);
    return;
  }

  {
    try {
      (arg1)->SetTargetTexture(*argp2);
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what()));
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what()));
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition);
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error");
      };
    }
  }
}


SWIGEXPORT void SWIGSTDCALL CSharp_Dali_CubeTransitionEffect_StartTransition__SWIG1(void* jarg1, bool toNextImage) {
  Dali::Toolkit::CubeTransitionEffect *arg1 = (Dali::Toolkit::CubeTransitionEffect *) 0;

  arg1 = (Dali::Toolkit::CubeTransitionEffect *)jarg1;

  {
    try {
      (arg1)->StartTransition(toNextImage);
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what()));
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what()));
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition);
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error");
      };
    }
  }
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_CubeTransitionEffect_StartTransition__SWIG2(void* jarg1, void* jarg2, void* jarg3) {
  Dali::Toolkit::CubeTransitionEffect *arg1 = (Dali::Toolkit::CubeTransitionEffect *) 0;

  arg1 = (Dali::Toolkit::CubeTransitionEffect *)jarg1;

  Dali::Vector2* argp2 = (Dali::Vector2*)jarg2;
  if (!argp2) {
    SWIG_CSharpSetPendingExceptionArgument(SWIG_CSharpArgumentNullException, "Attempt to dereference null Dali::Vector2", 0);
    return;
  }

  Dali::Vector2* argp3 = (Dali::Vector2*)jarg3;
  if (!argp3) {
    SWIG_CSharpSetPendingExceptionArgument(SWIG_CSharpArgumentNullException, "Attempt to dereference null Dali::Vector2", 0);
    return;
  }

  {
    try {
      (arg1)->StartTransition(*argp2, *argp3);
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what()));
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what()));
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition);
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error");
      };
    }
  }
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_CubeTransitionEffect_PauseTransition(void * jarg1) {
  Dali::Toolkit::CubeTransitionEffect *arg1 = (Dali::Toolkit::CubeTransitionEffect *) 0;

  arg1 = (Dali::Toolkit::CubeTransitionEffect *)jarg1;
  {
    try {
      (arg1)->PauseTransition();
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what()));
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what()));
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition);
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error");
      };
    }
  }
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_CubeTransitionEffect_ResumeTransition(void * jarg1) {
  Dali::Toolkit::CubeTransitionEffect *arg1 = (Dali::Toolkit::CubeTransitionEffect *) 0;

  arg1 = (Dali::Toolkit::CubeTransitionEffect *)jarg1;
  {
    try {
      (arg1)->ResumeTransition();
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what()));
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what()));
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition);
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error");
      };
    }
  }
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_CubeTransitionEffect_StopTransition(void * jarg1) {
  Dali::Toolkit::CubeTransitionEffect *arg1 = (Dali::Toolkit::CubeTransitionEffect *) 0;

  arg1 = (Dali::Toolkit::CubeTransitionEffect *)jarg1;
  {
    try {
      (arg1)->StopTransition();
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what()));
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what()));
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition);
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error");
      };
    }
  }
}

SWIGEXPORT void * SWIGSTDCALL CSharp_Dali_CubeTransitionEffect_TransitionCompletedSignal(void * jarg1) {
  void * jresult;
  Dali::Toolkit::CubeTransitionEffect *arg1 = (Dali::Toolkit::CubeTransitionEffect *) 0;
  Dali::Toolkit::CubeTransitionEffect::TransitionCompletedSignalType *result = 0;

  arg1 = (Dali::Toolkit::CubeTransitionEffect *)jarg1;
  {
    try {
      result = (Dali::Toolkit::CubeTransitionEffect::TransitionCompletedSignalType *) &(arg1)->TransitionCompletedSignal();
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0;
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0;
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition); return 0;
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0;
      };
    }
  }

  jresult = (void *)result;
  return jresult;
}

SWIGEXPORT unsigned int SWIGSTDCALL CSharp_Dali_CubeTransitionEffectSignal_Empty(void * jarg1) {
  unsigned int jresult;
  Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *arg1 = (Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *) 0;
  bool result;

  arg1 = (Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *)jarg1;
  {
    try {
      result = (bool)Dali_Signal_Sl_void_Sp_Dali_Toolkit_CubeTransitionEffect_SP__Sg__Empty((Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > const *)arg1);
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0;
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0;
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition); return 0;
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0;
      };
    }
  }

  jresult = result;
  return jresult;
}


SWIGEXPORT unsigned long SWIGSTDCALL CSharp_Dali_CubeTransitionEffectSignal_GetConnectionCount(void * jarg1) {
  unsigned long jresult;
  Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *arg1 = (Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *) 0;
  std::size_t result;

  arg1 = (Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *)jarg1;
  {
    try {
      result = Dali_Signal_Sl_void_Sp_Dali_Toolkit_CubeTransitionEffect_SP__Sg__GetConnectionCount((Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > const *)arg1);
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0;
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0;
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition); return 0;
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0;
      };
    }
  }

  jresult = (unsigned long)result;
  return jresult;
}


SWIGEXPORT void SWIGSTDCALL CSharp_Dali_CubeTransitionEffectSignal_Connect(void * jarg1, void * jarg2) {
  Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *arg1 = (Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *) 0;
  void(*arg2)(Dali::Toolkit::CubeTransitionEffect) = (void(*)(Dali::Toolkit::CubeTransitionEffect)) 0;

  arg1 = (Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *)jarg1;
  arg2 = (void(*)(Dali::Toolkit::CubeTransitionEffect))jarg2;
  {
    try {
      Dali_Signal_Sl_void_Sp_Dali_Toolkit_CubeTransitionEffect_SP__Sg__Connect(arg1, arg2);
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return;
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return;
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition); return;
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return;
      };
    }
  }

}


SWIGEXPORT void SWIGSTDCALL CSharp_Dali_CubeTransitionEffectSignal_Disconnect(void * jarg1, void * jarg2) {
  Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *arg1 = (Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *) 0;
  void(*arg2)(Dali::Toolkit::CubeTransitionEffect) = (void(*)(Dali::Toolkit::CubeTransitionEffect)) 0;

  arg1 = (Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *)jarg1;
  arg2 = (void(*)(Dali::Toolkit::CubeTransitionEffect))jarg2;
  {
    try {
      Dali_Signal_Sl_void_Sp_Dali_Toolkit_CubeTransitionEffect_SP__Sg__Disconnect(arg1, arg2);
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return;
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return;
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition); return;
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return;
      };
    }
  }

}


SWIGEXPORT void SWIGSTDCALL CSharp_Dali_CubeTransitionEffectSignal_Emit(void * jarg1, void * jarg2) {
  Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *arg1 = (Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *) 0;
  Dali::Toolkit::CubeTransitionEffect arg2;
  Dali::Toolkit::CubeTransitionEffect *argp2;

  arg1 = (Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *)jarg1;
  argp2 = (Dali::Toolkit::CubeTransitionEffect *)jarg2;
  if (!argp2) {
    SWIG_CSharpSetPendingExceptionArgument(SWIG_CSharpArgumentNullException, "Attempt to dereference null Dali::Toolkit::CubeTransitionEffect", 0);
    return;
  }
  arg2 = *argp2;
  {
    try {
      Dali_Signal_Sl_void_Sp_Dali_Toolkit_CubeTransitionEffect_SP__Sg__Emit(arg1, arg2);
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return;
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return;
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition); return;
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return;
      };
    }
  }

}


SWIGEXPORT void * SWIGSTDCALL CSharp_Dali_new_CubeTransitionEffectSignal() {
  void * jresult;
  Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *result = 0;

  {
    try {
      result = (Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *)new Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) >();
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0;
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0;
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition); return 0;
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0;
      };
    }
  }

  jresult = (void *)result;
  return jresult;
}


SWIGEXPORT void SWIGSTDCALL CSharp_Dali_delete_CubeTransitionEffectSignal(void * jarg1) {
  Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *arg1 = (Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *) 0;

  arg1 = (Dali::Signal< void(Dali::Toolkit::CubeTransitionEffect) > *)jarg1;
  {
    try {
      delete arg1;
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return;
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return;
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition); return;
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return;
      };
    }
  }

}


// cube-transition-cross-effect.h

SWIGEXPORT Dali::Toolkit::Control * SWIGSTDCALL CSharp_Dali_CubeTransitionCrossEffect_SWIGUpcast(Dali::Toolkit::CubeTransitionCrossEffect *jarg1) {
  return (Dali::Toolkit::Control *)jarg1;
}

SWIGEXPORT void * SWIGSTDCALL CSharp_Dali_CubeTransitionCrossEffect_New(unsigned int numRows, unsigned int numColumns) {
  void * jresult;
  Dali::Toolkit::CubeTransitionCrossEffect result;

  {
    try {
      result = Dali::Toolkit::CubeTransitionCrossEffect::New(numRows, numColumns);
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0;
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0;
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition); return 0;
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0;
      };
    }
  }

  jresult = new Dali::Toolkit::CubeTransitionCrossEffect((const Dali::Toolkit::CubeTransitionCrossEffect &)result);

  return jresult;
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_delete_CubeTransitionCrossEffect(void * jarg1) {
  Dali::Toolkit::CubeTransitionCrossEffect *arg1 = (Dali::Toolkit::CubeTransitionCrossEffect *) 0;

  arg1 = (Dali::Toolkit::CubeTransitionCrossEffect *)jarg1;
  {
    try {
      delete arg1;
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return;
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return;
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition); return;
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return;
      };
    }
  }
}

// cube-transition-fold-effect.h

SWIGEXPORT Dali::Toolkit::Control * SWIGSTDCALL CSharp_Dali_CubeTransitionFoldEffect_SWIGUpcast(Dali::Toolkit::CubeTransitionFoldEffect *jarg1) {
  return (Dali::Toolkit::Control *)jarg1;
}

SWIGEXPORT void * SWIGSTDCALL CSharp_Dali_CubeTransitionFoldEffect_New(unsigned int numRows, unsigned int numColumns) {
  void * jresult;
  Dali::Toolkit::CubeTransitionFoldEffect result;

  {
    try {
      result = Dali::Toolkit::CubeTransitionFoldEffect::New(numRows, numColumns);
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0;
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0;
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition); return 0;
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0;
      };
    }
  }

  jresult = new Dali::Toolkit::CubeTransitionFoldEffect((const Dali::Toolkit::CubeTransitionFoldEffect &)result);

  return jresult;
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_delete_CubeTransitionFoldEffect(void * jarg1) {
  Dali::Toolkit::CubeTransitionFoldEffect *arg1 = (Dali::Toolkit::CubeTransitionFoldEffect *) 0;

  arg1 = (Dali::Toolkit::CubeTransitionFoldEffect *)jarg1;
  {
    try {
      delete arg1;
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return;
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return;
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition); return;
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return;
      };
    }
  }
}

// cube-transition-wave-effect.h

SWIGEXPORT Dali::Toolkit::Control * SWIGSTDCALL CSharp_Dali_CubeTransitionWaveEffect_SWIGUpcast(Dali::Toolkit::CubeTransitionWaveEffect *jarg1) {
  return (Dali::Toolkit::Control *)jarg1;
}

SWIGEXPORT void * SWIGSTDCALL CSharp_Dali_CubeTransitionWaveEffect_New(unsigned int numRows, unsigned int numColumns) {
  void * jresult;
  Dali::Toolkit::CubeTransitionWaveEffect result;

  {
    try {
      result = Dali::Toolkit::CubeTransitionWaveEffect::New(numRows, numColumns);
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return 0;
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return 0;
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition); return 0;
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return 0;
      };
    }
  }

  jresult = new Dali::Toolkit::CubeTransitionWaveEffect((const Dali::Toolkit::CubeTransitionWaveEffect &)result);

  return jresult;
}

SWIGEXPORT void SWIGSTDCALL CSharp_Dali_delete_CubeTransitionWaveEffect(void * jarg1) {
  Dali::Toolkit::CubeTransitionWaveEffect *arg1 = (Dali::Toolkit::CubeTransitionWaveEffect *) 0;

  arg1 = (Dali::Toolkit::CubeTransitionWaveEffect *)jarg1;
  {
    try {
      delete arg1;
    }
    catch (std::out_of_range& e) {
      {
        SWIG_CSharpException(SWIG_IndexError, const_cast<char*>(e.what())); return;
      };
    }
    catch (std::exception& e) {
      {
        SWIG_CSharpException(SWIG_RuntimeError, const_cast<char*>(e.what())); return;
      };
    }
    catch (Dali::DaliException e) {
      {
        SWIG_CSharpException(SWIG_UnknownError, e.condition); return;
      };
    }
    catch (...) {
      {
        SWIG_CSharpException(SWIG_UnknownError, "unknown error"); return;
      };
    }
  }
}


#ifdef __cplusplus
}
#endif