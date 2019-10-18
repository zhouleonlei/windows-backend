/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Controls
{
    /// <summary>
    /// NaviFrameAttributes is a class which saves Naviframe's ux data.
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class NaviFrameAttributes : ViewAttributes
    {
        /// <summary>
        /// Creates a new instance of a NaviFrameAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NaviFrameAttributes() : base() { }

        /// <summary>
        /// Creates a new instance of a NaviFrameAttributes with attributes.
        /// </summary>
        /// <param name="attributes">Create NaviFrameAttributes by attributes customized by user.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NaviFrameAttributes(NaviFrameAttributes attributes) : base(attributes)
        {
            if (attributes.NaviHeaderAttributes != null)
            {
                NaviHeaderAttributes = attributes.NaviHeaderAttributes.Clone() as ViewAttributes;
            }
            if (attributes.ContentAttributes != null)
            {
                ContentAttributes = attributes.ContentAttributes.Clone() as ViewAttributes;
            }

        }

        /// <summary>
        /// NaviFrame header's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewAttributes NaviHeaderAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// NaviFrame content's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewAttributes ContentAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new NaviFrameAttributes(this);
        }
    }
}
