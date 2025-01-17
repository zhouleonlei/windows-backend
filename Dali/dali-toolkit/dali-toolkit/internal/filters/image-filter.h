#ifndef DALI_TOOLKIT_INTERNAL_IMAGE_FILTER_H
#define DALI_TOOLKIT_INTERNAL_IMAGE_FILTER_H

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
#include <dali/public-api/actors/camera-actor.h>
#include <dali/public-api/rendering/frame-buffer.h>
#include <dali/public-api/rendering/texture.h>

// INTERNAL INCLUDES
#include <dali-toolkit/public-api/controls/control-impl.h>
#include <dali-toolkit/devel-api/controls/effects-view/effects-view.h>

namespace Dali
{

namespace Toolkit
{

namespace Internal
{

/**
 * An interface class that provides a interface for image filters that perform
 * a simple shader effect on an input texture, rendering the output to a FrameBuffer.
 */
class ImageFilter
{
public:
  typedef std::vector< Vector3 > FilterKernel;

public:

  /**
   * Default constructor
   */
  ImageFilter();

  /**
   * Destructor
   */
  virtual ~ImageFilter();

  /**
   * Enable effect, allocates any necessary resources
   */
  virtual void Enable() = 0;

  /**
   * Disable effect, releases any allocated resources
   */
  virtual void Disable() = 0;

  /**
   * Refresh the filter output
   */
  virtual void Refresh() = 0;

  /**
   * @copydoc Dali::Toolkit::EffectsView::SetRefreshOnDemand
   */
  void SetRefreshOnDemand( bool onDemand );

  /**
   * Set the input texture
   * @param[in] The input/original texture.
   */
  void SetInputTexture( Texture texture );

  /**
   * Set the output frame buffer
   * @return The output frame buffer.
   */
  void SetOutputFrameBuffer( FrameBuffer frameBuffer );

  /**
   * Set size of ImageFilter. Used to create internal offscreen buffers
   * @param[in] size  THe size.
   */
  virtual void SetSize( const Vector2& size );

  /**
   * Set the pixel format for internal offscreen buffers
   * @param[in] pixelFormat The pixel format.
   */
  void SetPixelFormat( Pixel::Format pixelFormat );

  /**
   * Set the filter kernel
   * @param[in] The filter kernel
   */
  void SetKernel( const FilterKernel& kernel );

  /**
   * Get a const reference to the internal filter kernel
   * @Return A a const reference to the internal filter kernel
   */
  const FilterKernel& GetKernel() const;

  /**
   * Get the number of steps/elements in the kernel
   * @return The number of steps/elements in the kernel
   */
  size_t GetKernelSize() const;

  /**
   * Create a kernel from an array of weights
   * @param[in] weights
   * @param[in] count
   */
  void CreateKernel( const float* weights, size_t count);

  /**
   * Set the actor which acts as the root actor for all internal actors for connection to stage
   * @param[in] rootActor   An actor which acts as the root actor for any internal actors that need
   *                        to be created
   */
  void SetRootActor( Actor rootActor );

  /**
   * Set the background / clear color
   * @param[in] color The background / clear color
   */
  void SetBackgroundColor( const Vector4& color );

protected:

  /**
   * Setup position and parameters for camera
   */
  void SetupCamera();

protected:
  Texture          mInputTexture;
  FrameBuffer      mOutputFrameBuffer;
  FilterKernel     mKernel;
  Actor            mRootActor;
  CameraActor      mCameraActor;
  Vector4          mBackgroundColor;
  Vector2          mTargetSize;
  Pixel::Format    mPixelFormat;
  bool             mRefreshOnDemand;

}; // class Imagefilter

} // namespace Internal

} // namespace Toolkit

} // namespace Dali

#endif // DALI_TOOLKIT_INTERNAL_IMAGE_FILTER_H

