#ifndef DALI_TOOLKIT_INTERNAL_SCROLLABLE_H
#define DALI_TOOLKIT_INTERNAL_SCROLLABLE_H

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
#include <dali/public-api/animation/alpha-function.h>

// INTERNAL INCLUDES
#include <dali-toolkit/public-api/controls/control-impl.h>
#include <dali-toolkit/public-api/controls/scrollable/scrollable.h>

namespace Dali
{

namespace Toolkit
{

namespace Internal
{

class Scrollable;
typedef IntrusivePtr<Scrollable> ScrollablePtr;

/**
 * @copydoc Toolkit::Scrollable
 */
class Scrollable : public Control
{
public:

  /**
   * @copydoc Dali::Toolkit::Scrollable::IsOvershootEnabled
   */
  bool IsOvershootEnabled() const;

  /**
   * @copydoc Dali::Toolkit::Scrollable::SetOvershootEnabled
   */
  void SetOvershootEnabled(bool enable);

  /**
   * Adds actor as an Overlay to Scrollable
   * This method is called by Add-on UI components
   * such as scroll bars, page indicators.
   * @param[in] actor Actor to add as an overlay.
   */
  virtual void AddOverlay(Actor actor) = 0;

  /**
   * Removes overlay actor from Scrollable
   * This method is called by Add-on UI components
   * such as scroll bars, page indicators.
   * @param[in] actor Actor overlay to remove.
   */
  virtual void RemoveOverlay(Actor actor) = 0;

  /**
   * Retrieves current scroll position.
   * @returns The current scroll position.
   */
  virtual Vector2 GetCurrentScrollPosition() const = 0;

  /**
   * Scrolls Scrollable to position specified (contents will scroll to this position)
   * Position 0,0 is the origin. Increasing X scrolls contents left, while
   * increasing Y scrolls contents up.
   * @param[in] position The position to scroll to.
   * @param[in] duration The duration of the animation in seconds
   */
  virtual void ScrollTo(const Vector2 &position, float duration) = 0;

  /**
   * Set the color of the overshoot effect.
   * @parm[in] color The color of the overshoot effect
   */
  virtual void SetOvershootEffectColor( const Vector4& color ) = 0;

  /**
   * Retrieve the color of the overshoot effect.
   * @return The color of the overshoot effect.
   */
  Vector4 GetOvershootEffectColor() const;

  /**
   * @copydoc Dali::Toolkit::Scrollable::SetOvershootAnimationSpeed(float pixelsPerSecond)
   */
  void SetOvershootAnimationSpeed( float pixelsPerSecond );

  /**
   * @copydoc Dali::Toolkit::Scrollable::GetOvershootAnimationSpeed()
   */
  float GetOvershootAnimationSpeed() const;

  /**
   * @copydoc Dali::Toolkit::Scrollable::GetOvershootSize()
   */
  const Vector2& GetOvershootSize() const;

  /**
   * Set the size of the overshoot effect.
   * @parm[in] size The size of the overshoot effect
   */
  virtual void SetOvershootSize( const Vector2& size ) = 0;

private:

  /**
   * Temporary function to override EnableScrollOvershoot functionality for overshoot
   * Only ScrollView needs to override this as HQ has not requested disable functionality in ItemView
   * @param[in] enable true to enable, false to disable overshoot indicator
   */
  virtual void EnableScrollOvershoot(bool enable) {}

public: //Signals

  /**
   * @copydoc Dali::Toolkit::Scrollable::ScrollStartedSignal()
   */
  Toolkit::Scrollable::ScrollStartedSignalType& ScrollStartedSignal();

  /**
   * @copydoc Dali::Toolkit::Scrollable::ScrollUpdatedSignal()
   */
  Toolkit::Scrollable::ScrollUpdatedSignalType& ScrollUpdatedSignal();

  /**
   * @copydoc Dali::Toolkit::Scrollable::ScrollCompletedSignal()
   */
  Toolkit::Scrollable::ScrollCompletedSignalType& ScrollCompletedSignal();

  /**
   * Connects a callback function with the object's signals.
   * @param[in] object The object providing the signal.
   * @param[in] tracker Used to disconnect the signal.
   * @param[in] signalName The signal to connect to.
   * @param[in] functor A newly allocated FunctorDelegate.
   * @return True if the signal was connected.
   * @post If a signal was connected, ownership of functor was passed to CallbackBase. Otherwise the caller is responsible for deleting the unused functor.
   */
  static bool DoConnectSignal( BaseObject* object, ConnectionTrackerInterface* tracker, const std::string& signalName, FunctorDelegate* functor );

  //properties

  /**
   * Called when a property of an object of this type is set.
   * @param[in] object The object whose property is set.
   * @param[in] index The property index.
   * @param[in] value The new property value.
   */
  static void SetProperty( BaseObject* object, Property::Index index, const Property::Value& value );

  /**
   * Called to retrieve a property of an object of this type.
   * @param[in] object The object whose property is to be retrieved.
   * @param[in] index The property index.
   * @return The current value of the property.
   */
  static Property::Value GetProperty( BaseObject* object, Property::Index index );

protected:

  /**
   * Construct a new Scrollable.
   */
  Scrollable();

  /**
   * @brief Construct a new Scrollable.
   *
   * @param[in] behaviourFlags Flags to enable
   */
  Scrollable( ControlBehaviour behaviourFlags );

  /**
   * A reference counted object may only be deleted by calling Unreference()
   */
  virtual ~Scrollable();

private:

  /**
   * Gets position property.
   *
   * @return The current position
   */
  Vector2 GetPropertyPosition() const;

private:

  // Undefined
  Scrollable(const Scrollable&);

  // Undefined
  Scrollable& operator=(const Scrollable& rhs);

protected:

  Vector4         mOvershootEffectColor;    ///<The color of the overshoot bouncing effect
  float           mOvershootAnimationSpeed; ///<The speed of the overshoot animation (pixels per second)
  Vector2         mOvershootSize;           ///<The size of the overshoot effect

  Dali::AlphaFunction::BuiltinFunction mScrollToAlphaFunction; ///< The ScrollTo() animations use this

  Toolkit::Scrollable::ScrollStartedSignalType mScrollStartedSignal;
  Toolkit::Scrollable::ScrollUpdatedSignalType mScrollUpdatedSignal;
  Toolkit::Scrollable::ScrollCompletedSignalType mScrollCompletedSignal;

private:

  bool mOvershootEnabled:1;
};

} // namespace Internal

// Helpers for public-api forwarding methods

inline Toolkit::Internal::Scrollable& GetImpl(Toolkit::Scrollable& scrollable)
{
  DALI_ASSERT_ALWAYS(scrollable);

  Dali::RefObject& handle = scrollable.GetImplementation();

  return static_cast<Toolkit::Internal::Scrollable&>(handle);
}

inline const Toolkit::Internal::Scrollable& GetImpl(const Toolkit::Scrollable& scrollable)
{
  DALI_ASSERT_ALWAYS(scrollable);

  const Dali::RefObject& handle = scrollable.GetImplementation();

  return static_cast<const Toolkit::Internal::Scrollable&>(handle);
}

} // namespace Toolkit

} // namespace Dali

#endif // DALI_TOOLKIT_INTERNAL_SCROLLABLE_H
