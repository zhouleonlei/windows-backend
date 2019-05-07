#ifndef __DALI_FRAME_UPDATE_CALLBACK_IMPL_H__
#define __DALI_FRAME_UPDATE_CALLBACK_IMPL_H__

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
#include <dali-toolkit/devel-api/frame-update-callback/frame-update-callback.h>
#include <dali-toolkit/internal/frame-update-callback/frame-callback.h>

namespace Dali
{

namespace Toolkit
{

namespace Internal
{

class FrameUpdateCallback : public Dali::BaseObject
{
public:

  /**
   * @brief Creates an uninitialized FrameUpdateCallback object.
   */
  FrameUpdateCallback();

  static IntrusivePtr<FrameUpdateCallback> New();
  
  /**
   * @brief Destructor.
   */
  ~FrameUpdateCallback();
  
  /**
   * @brief sets frame callback.
   */
  void AddCallback( FrameCallbackFunction updateCallback );

  /**
   * @brief sets main thread frame callback.
   */
  void AddMainThreadCallback( FrameCallbackFunction updateCallback );
  
  /**
   * @brief removes frame callback.
   */
  void RemoveCallback();
  
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
  bool SetColor( unsigned int id, const Dali::Vector4& color );

  /**
   * @brief Allows baking an Actor's local color from the Frame callback function.
   * @param[in]  id     The Actor ID
   * @param[in]  color  The color to set
   * @note The value is saved so will cause undesired effects if this property is being animated.
   */
  bool BakeColor( unsigned int id, const Dali::Vector4& color ) const;

private: 

  FrameCallback mFrameCallback;
  bool mHasBeenAdded;
  Dali::Stage         mStage;
};

inline FrameUpdateCallback& GetImplementation( Dali::Toolkit::FrameUpdateCallback& handle )
{
  DALI_ASSERT_ALWAYS( handle && "FrameBuffer handle is empty" );

  BaseObject& object = handle.GetBaseObject();

  return static_cast<FrameUpdateCallback&>( object );
}
} // namespace Internal
} // namespace ToolKit
} // namespace Dali

#endif // __DALI_EXTENSION_FRAME_UPDATE_CALLBACK_H__
