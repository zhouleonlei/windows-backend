#ifndef DALI_TOOLKIT_INTERNAL_CUBE_TRANSITION_WAVE_EFFECT_H
#define DALI_TOOLKIT_INTERNAL_CUBE_TRANSITION_WAVE_EFFECT_H

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

// EXTERNAL INCLUDES

// INTERNAL INCLUDES
#include <dali-toolkit/devel-api/transition-effects/cube-transition-wave-effect.h>
#include <dali-toolkit/internal/transition-effects/cube-transition-effect-impl.h>

namespace Dali
{

namespace Toolkit
{

class CubeTransitionWaveEffect;

namespace Internal
{

class CubeTransitionEffect;

class CubeTransitionWaveEffect : public CubeTransitionEffect
{

public:

  /**
   * @copydoc Toolkit::CubeTransitionWaveEffect::New
   */
  static Toolkit::CubeTransitionWaveEffect New(unsigned int numRows, unsigned int numColumns );

protected:

  /**
   * @copydoc Toolkit::Internal::CubeTransitionEffect::OnInitialize
   */
  virtual void OnInitialize();

  /**
   * @copydoc Toolkit::Internal::CubeTransitionEffect::OnStartTransition
   */
  virtual void OnStartTransition( Vector2 panPosition, Vector2 panDisplacement );

private:

  /**
   * Construct a new CubeTransitionWaveEffect object
   * @param[in] numRows How many rows of cubes
   * @param[in] numColumns How many columns of cubes
   */
  CubeTransitionWaveEffect( unsigned int numRows, unsigned int numColumns );

  /**
   * The Saddle surface (Hyperbolic paraboloid)function is used to calculate the delay of rotating animation for each cube
   * This function calculates the Hyperbolic paraboloid parameters,
   * and the translation and rotation params for mapping the current stage coordinate to the function defining coordinate system
   * @param[in] position The press down position of panGesture
   * @param[in] displacement The displacement vector of panGesture
   */
  void CalculateSaddleSurfaceParameters( Vector2 position, Vector2 displacement);

  /**
   * Calculate the delay of the animation for each cube
   * @param[in] x The X coordinate of the cube
   * @param[in] y The Y coordinate of the cube
   * @return The delay time of the animation
   */
  float CalculateDelay( float x, float y, bool forward );

private:

  //saddle surface(Hyperbolic paraboloid)function, used to calculate the delay time of each cube
  //z = 1.0 + y*y/a/a - x*x/b/b
  //with our selection of parameters(a and b), this value for any cube is between 0.0 and 2.0
  float                      mSaddleAA; //a*a
  float                      mSaddleBB; //b*b
  float                      mSaddleB;  //b
  Vector2                    mTranslation;
  Vector2                    mRotation;

}; // class CubeTransitionWaveEffect

} // namespace Internal

// Helpers for public-api forwarding methods

inline Internal::CubeTransitionWaveEffect& GetImpl( Dali::Toolkit::CubeTransitionWaveEffect& obj )
{
  DALI_ASSERT_ALWAYS( obj );

  Dali::RefObject& handle = obj.GetImplementation();

  return static_cast< Internal::CubeTransitionWaveEffect& >( handle );
}

inline const Internal::CubeTransitionWaveEffect& GetImpl( const Dali::Toolkit::CubeTransitionWaveEffect& obj )
{
  DALI_ASSERT_ALWAYS( obj );

  const Dali::RefObject& handle = obj.GetImplementation();

  return static_cast< const Internal::CubeTransitionWaveEffect& >( handle );
}

} // namespace Toolkit

} // namespace Dali

#endif // DALI_TOOLKIT_INTERNAL_CUBE_TRANSITION_WAVE_EFFECT_H
