/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Tizen.Applications
{
    /// <summary>
    /// The class for the argument of the LowMemory EventHandler
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class LowMemoryEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes LowMemoryEventArgs class
        /// </summary>
        /// <param name="status">The information of the LowMemoryStatus</param>
        /// <since_tizen> 3 </since_tizen>
        public LowMemoryEventArgs(LowMemoryStatus status)
        {
            LowMemoryStatus = status;
        }

        /// <summary>
        /// The property to get the information of the LowMemoryStatus
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public LowMemoryStatus LowMemoryStatus { get; private set; }
    }
}
