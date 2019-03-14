#ifndef __DALI_EXTENSION_INTERNAL_FRAME_CALLBACK_H
#define __DALI_EXTENSION_INTERNAL_FRAME_CALLBACK_H

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

// EXTERNAL INCLUDES
#include <dali/devel-api/update/frame-callback-interface.h>
#include <dali/devel-api/update/update-proxy.h>
#include <dali/public-api/common/dali-common.h>
#include <dali/public-api/math/matrix.h>
#include <dali/public-api/math/vector3.h>

// INTERNAL INCLUDES
#include <dali-toolkit/public-api/frame-update-callback/frame-update-callback.h>

namespace Dali
{

namespace ToolKit
{

namespace Internal
{

/**
 * @brief Implementation of the FrameCallbackInterface.
 *
 * When this is used, it will expand the size of the actors the closer they get to the horizontal edge.
 */
class FrameCallback : public Dali::FrameCallbackInterface
{
public:

  /**
   * @brief Constructor.
   */
  FrameCallback();

  /**
   * @brief Destructor.
   */
  ~FrameCallback();
  
  /**
   * @brief Allows setting Frame callback function.
   * @param[in]  updateCallback    The callback function
   */
  void SetUpdateCallback( FrameCallbackFunction callback );
  
  /**
   * @brief Removes frame callback function.
   */
  void RemoveFrameUpdateCallback( );
  
  /**
   * @brief Given the Actor ID, this retrieves that Actor's local position.
   * @param[in]  id  The Actor ID
   * @return If valid Actor ID, then the Actor's position is returned.
   */
  bool GetPosition( unsigned int id, Dali::Vector3& position ) const;

  /**
   * @brief Allows seting an Actor's local position from the Frame callback function.
   * @param[in]  id        The Actor ID
   * @param[in]  position  The position to set.
   * @note The value is saved so will cause undesired effects if this property is being animated.
   */
  bool SetPosition( unsigned int id, const Dali::Vector3& position );

  /**
   * @brief Allows baking an Actor's local position from the Frame callback function.
   * @param[in]  id        The Actor ID
   * @param[in]  position  The position to set.
   * @note The value is saved so will cause undesired effects if this property is being animated.
   */
  bool BakePosition( unsigned int id, const Dali::Vector3& position );

  /**
   * @brief Given the Actor ID, this retrieves that Actor's size.
   * @param[in]  id  The Actor ID
   * @return If valid Actor ID, then the Actor's size is returned.
   */
  bool GetSize( uint32_t id, Vector3& size ) const;

  /**
   * @brief Allows seting an Actor's size from the Frame callback function.
   * @param[in]  id        The Actor ID
   * @param[in]  position  The size to set.
   * @note The value is saved so will cause undesired effects if this property is being animated.
   */
  bool SetSize( uint32_t id, const Vector3& size );

  /**
   * @brief Allows baking an Actor's size from the Frame callback function.
   * @param[in]  id        The Actor ID
   * @param[in]  position  The size to set.
   * @note The value is saved so will cause undesired effects if this property is being animated.
   */
  bool BakeSize( uint32_t id, const Vector3& size );

  /**
   * @brief Given the Actor ID, this retrieves that Actor's local scale.
   * @param[in]  id  The Actor ID
   * @return If valid Actor ID, then the Actor's scale is returned.
   */
  bool GetScale( unsigned int id, Dali::Vector3& scale ) const;

  /**
   * @brief Allows seting an Actor's local scale from the Frame callback function.
   * @param[in]  id     The Actor ID
   * @param[in]  scale  The scale to set.
   * @note The value is saved so will cause undesired effects if this property is being animated.
   */
  bool SetScale( unsigned int id, const Dali::Vector3& scale );

  /**
   * @brief Allows baking an Actor's local scale from the Frame callback function.
   * @param[in]  id     The Actor ID
   * @param[in]  scale  The scale to set.
   * @note The value is saved so will cause undesired effects if this property is being animated.
   */
  bool BakeScale( unsigned int id, const Dali::Vector3& scale );

  /**
   * @brief Given the Actor ID, this retrieves that Actor's local color.
   * @param[in]   id        The Actor ID
   * @return If valid Actor ID, then Actor's color is returned, otherwise Vector4::ZERO.
   */
  bool GetColor( unsigned int id, Dali::Vector4& color ) const;

  /**
   * @brief Allows seting an Actor's local color from the Frame callback function.
   * @param[in]  id     The Actor ID
   * @param[in]  color  The color to set
   * @note The value is saved so will cause undesired effects if this property is being animated.
   */
  bool SetColor( unsigned int id, const Dali::Vector4& color ) const;

  /**
   * @brief Allows baking an Actor's local color from the Frame callback function.
   * @param[in]  id     The Actor ID
   * @param[in]  color  The color to set
   * @note The value is saved so will cause undesired effects if this property is being animated.
   */
  bool BakeColor( unsigned int id, const Dali::Vector4& color ) const;

private:

  /**
   * @brief Called when every frame is updated.
   * @param[in]  updateProxy  Used to set the world-matrix and sizes.
   */
  virtual void Update( Dali::UpdateProxy& updateProxy, float elapsedSeconds );

private:

  Dali::UpdateProxy* mUpdateProxy;
  
  FrameCallbackFunction mFrameCallback;
};
}
}
} // namespace DaliExtTv

#endif // __DALI_EXTENSION_INTERNAL_FRAME_CALLBACK_H
