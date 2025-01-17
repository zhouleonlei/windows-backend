#ifndef DALI_PROPERTY_NOTIFICATION_DECLARATIONS_H
#define DALI_PROPERTY_NOTIFICATION_DECLARATIONS_H

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
#include <dali/public-api/signals/dali-signal.h>

namespace Dali
{
/**
 * @addtogroup dali_core_object
 * @{
 */

class PropertyNotification;

/**
 * @brief Signal type for Dali::PropertyNotification::NotifySignal().
 * @SINCE_1_0.0
 */
typedef Signal< void (PropertyNotification& source) > PropertyNotifySignalType;

/**
 * @}
 */
} // namespace Dali

#endif // DALI_PROPERTY_NOTIFICATION_DECLARATIONS_H
