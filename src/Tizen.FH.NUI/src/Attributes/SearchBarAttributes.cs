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
using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.Components;
using System.ComponentModel;

namespace Tizen.FH.NUI.Controls
{
    /// <summary>
    /// SearchBarAttributes is a class which saves SearchBar's ux data.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SearchBarAttributes : Tizen.NUI.Components.ViewAttributes
    {
        /// <summary>
        /// Creates a new instance of a SearchBarAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SearchBarAttributes() : base() { }

        /// <summary>
        /// Creates a new instance of a SearchBarAttributes with attributes.
        /// </summary>
        /// <param name="attributes">Create SearchBarAttributes by attributes customized by user.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SearchBarAttributes(SearchBarAttributes attrs) : base(attrs)
        {
            if (attrs.SearchBoxAttributes != null)
            {
                SearchBoxAttributes = attrs.SearchBoxAttributes.Clone() as InputFieldAttributes;
            }
            if (attrs.ResultListAttributes != null)
            {
                ResultListAttributes = attrs.ResultListAttributes.Clone() as ViewAttributes;
            }
            if (attrs.Space != null)
            {
                Space = attrs.Space;
            }
        }
        /// <summary>
        /// SearchBox's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InputFieldAttributes SearchBoxAttributes
        {
            get;
            set;
        }
        /// <summary>
        /// ResultList's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewAttributes ResultListAttributes
        {
            get;
            set;
        }
        /// <summary>
        /// Space's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? Space
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
            return new SearchBarAttributes(this);
        }
    }
}
