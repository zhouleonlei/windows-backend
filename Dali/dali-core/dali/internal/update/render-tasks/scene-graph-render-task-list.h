#ifndef DALI_INTERNAL_SCENE_GRAPH_RENDER_TASK_LIST_H
#define DALI_INTERNAL_SCENE_GRAPH_RENDER_TASK_LIST_H

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
#include <dali/devel-api/common/owner-container.h>
#include <dali/internal/common/message.h>
#include <dali/internal/event/common/event-thread-services.h>
#include <dali/internal/update/render-tasks/scene-graph-render-task.h>

namespace Dali
{

namespace Internal
{

class CompleteNotificationInterface;

namespace SceneGraph
{
class RenderMessageDispatcher;
class RenderTask;

/**
 * An ordered list of render-tasks.
 */
class RenderTaskList
{
public:

  typedef OwnerContainer< RenderTask* > RenderTaskContainer;

  /**
   * Construct a new RenderTaskList.
   * @return A new RenderTaskList
   */
  static RenderTaskList* New();

  /**
   * Destructor
   */
  ~RenderTaskList();

  /**
   * Overriden delete operator
   * Deletes the RenderTaskList from its global memory pool
   */
  void operator delete( void* ptr );

  /**
   * Set the renderMessageDispatcher to send message.
   * @param[in] renderMessageDispatcher The renderMessageDispatcher to send messages.
   */
  void SetRenderMessageDispatcher( RenderMessageDispatcher* renderMessageDispatcher );

  /**
   * Add a new RenderTask to the list.
   * @param[in] newTask The RenderTaskList takes ownership of this task.
   */
  void AddTask( OwnerPointer< RenderTask >& newTask );

  /**
   * Remove a RenderTask from the list.
   * @param[in] task The RenderTaskList will destroy this task.
   */
  void RemoveTask( RenderTask* task );

  /**
   * Retrieve the count of RenderTasks.
   * @return The count.
   */
  uint32_t GetTaskCount();

  /**
   * Retrieve the container of RenderTasks.
   * @return The container.
   */
  RenderTaskContainer& GetTasks();

  /**
   * Retrieve the container of RenderTasks.
   * @return The container.
   */
  const RenderTaskContainer& GetTasks() const;

  /**
   * Set the notification method to package in the NotifyFinishedMessage
   * @param object to store in notification managers queue
   */
  void SetCompleteNotificationInterface( CompleteNotificationInterface* object );

  /**
   * Get the Notification interface for when 1+ render tasks have finished
   */
  CompleteNotificationInterface* GetCompleteNotificationInterface();

protected:

  /**
   * Protected constructor. See New()
   */
  RenderTaskList();

private:

  // Undefined
  RenderTaskList(const RenderTaskList&);

  // Undefined
  RenderTaskList& operator=(const RenderTaskList&);

private:

  CompleteNotificationInterface* mNotificationObject; ///< object to pass in to the complete notification
  RenderMessageDispatcher* mRenderMessageDispatcher; ///< for sending messages to render thread
  RenderTaskContainer mRenderTasks; ///< A container of owned RenderTasks

};

// Messages for RenderTaskList

inline void AddTaskMessage( EventThreadServices& eventThreadServices, const RenderTaskList& list, OwnerPointer< RenderTask >& task )
{
  // Message has ownership of the RenderTask while in transit from event -> update
  typedef MessageValue1< RenderTaskList, OwnerPointer< RenderTask > > LocalType;

  // Reserve some memory inside the message queue
  uint32_t* slot = eventThreadServices.ReserveMessageSlot( sizeof( LocalType ) );

  // Construct message in the message queue memory; note that delete should not be called on the return value
  new (slot) LocalType( &list, &RenderTaskList::AddTask, task );
}

inline void RemoveTaskMessage( EventThreadServices& eventThreadServices, const RenderTaskList& list, const RenderTask& constTask )
{
  // Scene graph thread can destroy this object.
  RenderTask& task = const_cast< RenderTask& >( constTask );

  typedef MessageValue1< RenderTaskList, RenderTask* > LocalType;

  // Reserve some memory inside the message queue
  uint32_t* slot = eventThreadServices.ReserveMessageSlot( sizeof( LocalType ) );

  // Construct message in the message queue memory; note that delete should not be called on the return value
  new (slot) LocalType( &list, &RenderTaskList::RemoveTask, &task );
}

} // namespace SceneGraph

} // namespace Internal

} // namespace Dali

#endif // DALI_INTERNAL_SCENE_GRAPH_RENDER_TASK_LIST_H
