#ifndef __DALI_FRAME_UPDATE_CALLBACK_H__
#define __DALI_FRAME_UPDATE_CALLBACK_H__

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

// EXTERNAL INCLUDES
#include <dali/devel-api/common/stage-devel.h>
#include <dali/public-api/object/base-handle.h>
#include <dali/public-api/object/base-object.h>

// INTERNAL INCLUDES
#include <dali/public-api/dali-adaptor-common.h>

namespace Dali
{

namespace Internal
{
namespace Adaptor
{
class FrameUpdateCallback;
}
}

typedef void( *FrameCallbackFunction )( float elapsedSeconds );

class DALI_ADAPTOR_API FrameUpdateCallback : public BaseHandle
{
public:
  static FrameUpdateCallback New();

  FrameUpdateCallback( Internal::Adaptor::FrameUpdateCallback *implementation );

  void AddCallback( FrameCallbackFunction updateCallback );

  void AddMainThreadCallback( FrameCallbackFunction updateCallback );

  void RemoveCallback();

  /**
   * @brief Given the Actor ID, this retrieves that Actor's local position.
   * @param[in]  id  The Actor ID
   * @return If valid Actor ID, then the Actor's position is returned.
   */
  bool GetPosition( unsigned int id, Dali::Vector3& position );

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
  bool GetSize( uint32_t id, Vector3& size );

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
  bool GetScale( unsigned int id, Dali::Vector3& scale );

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
  bool GetColor( unsigned int id, Dali::Vector4& color );

  /**
   * @brief Allows seting an Actor's local color from the Frame callback function.
   * @param[in]  id     The Actor ID
   * @param[in]  color  The color to set
   * @note The value is saved so will cause undesired effects if this property is being animated.
   */
  bool SetColor( unsigned int id, const Dali::Vector4& color );

  /**
   * @brief Allows baking an Actor's local color from the Frame callback function.
   * @param[in]  id     The Actor ID
   * @param[in]  color  The color to set
   * @note The value is saved so will cause undesired effects if this property is being animated.
   */
  bool BakeColor( unsigned int id, const Dali::Vector4& color );

};
} // namespace Dali

#endif // __DALI_EXTENSION_FRAME_UPDATE_CALLBACK_H__
