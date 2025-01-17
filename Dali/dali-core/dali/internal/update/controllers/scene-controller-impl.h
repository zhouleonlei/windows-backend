#ifndef DALI_INTERNAL_SCENE_GRAPH_SCENE_CONTROLLER_IMPL_H
#define DALI_INTERNAL_SCENE_GRAPH_SCENE_CONTROLLER_IMPL_H

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
#include <dali/internal/update/controllers/scene-controller.h>

namespace Dali
{

namespace Internal
{

namespace SceneGraph
{

/**
 * concrete implementation of the scene controller interface
 */
class SceneControllerImpl: public SceneController
{

public:

  /**
   * Constructor
   * @param[in] rendererDispatcher Used for passing ownership of renderers to the render-thread.
   * @param[in] renderQueue  The renderQueue
   * @param[in] discardQueue The discardQueue
   */
  SceneControllerImpl( RenderMessageDispatcher& renderMessageDispatcher,
                       RenderQueue& renderQueue,
                       DiscardQueue& discardQueue );

  /**
   * Destructor
   */
  virtual ~SceneControllerImpl();

public:  // from SceneController

  /**
   * @copydoc SceneController::GetRenderMessageDispatcher()
   */
  virtual RenderMessageDispatcher& GetRenderMessageDispatcher() { return mRenderMessageDispatcher; }

  /**
   * @copydoc SceneController::GetRenderQueue()
   */
  virtual RenderQueue& GetRenderQueue() { return mRenderQueue; }

  /**
   * @copydoc SceneController::GetDiscardQueue()
   */
  virtual DiscardQueue& GetDiscardQueue() { return mDiscardQueue; }

private:

  // Undefined copy constructor.
  SceneControllerImpl( const SceneControllerImpl& );

  // Undefined assignment operator.
  SceneControllerImpl& operator=( const SceneControllerImpl& );

private:

  RenderMessageDispatcher& mRenderMessageDispatcher;    ///< Used for passing messages to the render-thread
  RenderQueue&             mRenderQueue;           ///< render queue
  DiscardQueue&            mDiscardQueue;          ///< discard queue
};

} // namespace SceneGraph

} // namespace Internal

} // namespace Dali

#endif // DALI_INTERNAL_SCENE_GRAPH_SCENE_CONTROLLER_IMPL_H
