#ifndef DALI_TOOLKIT_TEXT_ATLAS_RENDERER_H
#define DALI_TOOLKIT_TEXT_ATLAS_RENDERER_H

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
#include <dali-toolkit/internal/text/rendering/text-renderer.h>

namespace Dali
{

namespace Toolkit
{

namespace Text
{

/**
 * @brief Implementation of a text renderer based on dynamic atlases.
 *
 */
class AtlasRenderer : public Renderer
{
public:

  /**
   * @brief Create the renderer.
   */
  static RendererPtr New();

  /**
   * @copydoc Renderer::Render()
   */
  virtual Actor Render( ViewInterface& view,
                        Actor textControl,
                        Property::Index animatablePropertyIndex,
                        float& alignmentOffset,
                        int depth );

protected:

  /**
   * @brief Constructor.
   */
  AtlasRenderer();

  /**
   * @brief A reference counted object may only be deleted by calling Unreference().
   */
  virtual ~AtlasRenderer();

private:

  // Undefined
  AtlasRenderer( const AtlasRenderer& handle );

  // Undefined
  AtlasRenderer& operator=( const AtlasRenderer& handle );

private:

  struct Impl;
  Impl* mImpl;
};

} // namespace Text

} // namespace Toolkit

} // namespace Dali

#endif // DALI_TOOLKIT_TEXT_ATLAS_RENDERER_H
