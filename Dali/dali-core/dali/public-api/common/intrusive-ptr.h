#ifndef DALI_INTRUSIVE_PTR_H
#define DALI_INTRUSIVE_PTR_H

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

// INTERNAL INCLUDES
#include <dali/public-api/common/dali-common.h>

namespace Dali
{
/**
 * @addtogroup dali_core_common
 * @{
 */

/**
 * @brief Templated intrusive pointer class.
 *
 * Uses the Dali:RefObject type with actual reference counting.
 * The object is responsible for destroying itself.
 * @SINCE_1_0.0
 */
template<typename T>
class IntrusivePtr
{

public:

  /**
   * @brief Standard constructor to unassigned object.
   * @SINCE_1_0.0
   */
  IntrusivePtr() : mPtr( 0 ) {}

  /**
   * @brief Constructor to attach existing object.
   *
   * @SINCE_1_0.0
   * @param[in] p Pointer to object
   */
  IntrusivePtr( T* p ) : mPtr( p )
  {
    if( mPtr )
    {
      mPtr->Reference();
    }
  }

  /**
   * @brief Copy constructor.
   *
   * @SINCE_1_0.0
   * @param[in] rhs Const reference to an IntrusivePtr
   * @tparam U Reference counter object type
   */
  template<typename U>
  IntrusivePtr( IntrusivePtr<U> const& rhs ) : mPtr( rhs.Get() )
  {
    if( mPtr )
    {
      mPtr->Reference();
    }
  }

  /**
   * @brief Copy constructor.
   * @SINCE_1_0.0
   * @param[in] rhs Const reference to an IntrusivePtr
   */
  IntrusivePtr( IntrusivePtr const& rhs ) : mPtr( rhs.mPtr )
  {
    if( mPtr )
    {
      mPtr->Reference();
    }
  }

  /**
   * @brief Destructor.
   *
   * Object will self-destruct if reference count is zero.
   * @SINCE_1_0.0
   */
  ~IntrusivePtr()
  {
    if( mPtr )
    {
      mPtr->Unreference();
    }
  }

  /**
   * @brief Gets pointer to reference counted object.
   *
   * @SINCE_1_0.0
   * @return Pointer to reference counted object
   */
  T* Get() const
  {
    return mPtr;
  }

  /**
   * @brief Pointer operator override.
   *
   * @SINCE_1_0.0
   * @return Pointer to reference counted object
   */
  T* operator->() const
  {
    return mPtr;
  }

  /**
   * @brief Dereference operator override.
   *
   * @SINCE_1_0.0
   * @return Reference to reference counted object
   */
  T& operator*() const
  {
    return *mPtr;
  }

  /**
   * @brief Assignment operator.
   *
   * @SINCE_1_0.0
   * @param rhs Const reference to intrusive pointer
   * @return Reference to reference counted object
   */
  IntrusivePtr& operator=( IntrusivePtr const& rhs )
  {
    IntrusivePtr( rhs ).Swap( *this );
    return *this;
  }

  /**
   * @brief Assignment operator.
   *
   * @SINCE_1_0.0
   * @param rhs Pointer to object to wrap
   * @return A Reference to this object
   */
  IntrusivePtr& operator=( T* rhs )
  {
    IntrusivePtr( rhs ).Swap( *this );
    return *this;
  }

  /**
   * @brief Reset intrusive pointer.
   * @SINCE_1_0.0
   */
  void Reset()
  {
    IntrusivePtr().Swap( *this );
  }

  /**
   * @brief Reset intrusive pointer with reference counted object.
   *
   * @SINCE_1_0.0
   * @param[in] rhs Pointer to object
   */
  void Reset( T* rhs )
  {
    IntrusivePtr( rhs ).Swap( *this );
  }

  // IntrusivePtr comparisons - This is a variation of the safe bool idiom

  /**
   * @brief Pointer-to-member type.
   *
   * Objects can be implicitly converted to this for validity checks.
   */
  typedef void (IntrusivePtr::*BooleanType)() const;

  /**
   * @brief Converts an object handle to a BooleanType.
   *
   * This is useful for checking whether the handle is NULL.
   * @SINCE_1_0.0
   */
  operator BooleanType() const
  {
    return mPtr ? &IntrusivePtr::ThisIsSaferThanReturningVoidStar : 0;
  }

  /**
   * @brief Detaches pointer from intrusive ptr counting.
   *
   * Use with care.
   * @SINCE_1_0.0
   * @return Pointer to reference counted object
   */
  T* Detach()
  {
    T* ptr = mPtr;
    mPtr = 0;
    return ptr;
  }

private:

  /**
   * @brief Used by the safe bool idiom.
   * @SINCE_1_0.0
   */
  void ThisIsSaferThanReturningVoidStar() const {}

  /**
   * @brief Internal swap function.
   * @SINCE_1_0.0
   */
  void Swap( IntrusivePtr& rhs )
  {
    T* tmp = mPtr;
    mPtr = rhs.mPtr;
    rhs.mPtr = tmp;
  }

  T* mPtr;  ///< pointer to RefObject
};

/**
 * @brief Comparison overrides of objects wrapped by intrusive pointers.
 *
 * @SINCE_1_0.0
 * @param[in] lhs Intrusive pointer to compare with
 * @param[in] rhs Intrusive pointer to compare against
 * @return True if the pointers point at the same object
 */
template<typename T, typename U>
inline bool operator==( IntrusivePtr<T>const& lhs, IntrusivePtr<U>const& rhs )
{
  return lhs.Get() == rhs.Get();
}

/**
 * @brief Comparison overrides of objects wrapped by intrusive pointers.
 *
 * @SINCE_1_0.0
 * @param[in] lhs Intrusive pointer to compare with
 * @param[in] rhs Intrusive pointer to compare against
 * @return True if the pointers point at different objects
 */
template<typename T, typename U>
inline bool operator!=( IntrusivePtr<T>const& lhs, IntrusivePtr<U>const &rhs)
{
  return lhs.Get() != rhs.Get();
}

/**
 * @brief Comparison overrides of objects wrapped by intrusive pointers.
 *
 * @SINCE_1_0.0
 * @param[in] lhs Intrusive pointer to compare with
 * @param[in] rhs Object to compare against
 * @return True if the intrusive pointer points at the specified object
 */
template<typename T, typename U>
inline bool operator==( IntrusivePtr<T>const& lhs, U* rhs )
{
  return lhs.Get() == rhs;
}

/**
 * @brief Comparison overrides of objects wrapped by intrusive pointers.
 *
 * @SINCE_1_0.0
 * @param[in] lhs Intrusive pointer to compare with
 * @param[in] rhs Intrusive pointer to compare against
 * @return True if the intrusive pointer doesn't point at the specified object
 */
template<typename T, typename U>
inline bool operator!=( IntrusivePtr<T>const& lhs, U* rhs )
{
  return lhs.Get() != rhs;
}

/**
 * @brief Comparison overrides of objects wrapped by intrusive pointers.
 *
 * @SINCE_1_0.0
 * @param[in] lhs Object to compare with
 * @param[in] rhs Intrusive pointer to compare against
 * @return True if the intrusive pointer points at the specified object
 */
template<typename T, typename U>
inline bool operator==( T* lhs, IntrusivePtr<U>const& rhs )
{
  return lhs == rhs.Get();
}

/**
 * @brief Comparison overrides of objects wrapped by intrusive pointers.
 *
 * @SINCE_1_0.0
 * @param[in] lhs Object to compare with
 * @param[in] rhs Intrusive pointer to compare against
 * @return True if the intrusive pointer doesn't point at the specified object
 */
template<typename T, typename U>
inline bool operator!=( T* lhs, IntrusivePtr<U>const& rhs )
{
  return lhs != rhs.Get();
}

/**
 * @}
 */
} // namespace Dali

#endif // DALI_INTRUSIVE_PTR_H
