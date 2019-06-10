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
using Tizen.NUI.CommonUI;
using System.ComponentModel;

namespace Tizen.FH.NUI.Controls
{
    /// <summary>
    /// InputFieldAttributes is a class which saves InputField's ux data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class InputFieldAttributes : Tizen.NUI.CommonUI.InputFieldAttributes
    {

        /// <summary>
        /// Creates a new instance of a InputFieldAttributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InputFieldAttributes() : base() { }


        /// <summary>
        /// Creates a new instance of a InputFieldAttributes with attributes.
        /// </summary>
        /// <param name="attributes">Create InputFieldAttributes by attributes customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InputFieldAttributes(InputFieldAttributes attrs) : base(attrs)
        {
            if (attrs.CancelButtonAttributes != null)
            {
                CancelButtonAttributes = attrs.CancelButtonAttributes.Clone() as ImageAttributes;
            }
            if (attrs.DeleteButtonAttributes != null)
            {
                DeleteButtonAttributes = attrs.DeleteButtonAttributes.Clone() as ImageAttributes;
            }
            if (attrs.AddButtonBgAttributes != null)
            {
                AddButtonBgAttributes = attrs.AddButtonBgAttributes.Clone() as ImageAttributes;
            }
            if (attrs.AddButtonOverlayAttributes != null)
            {
                AddButtonOverlayAttributes = attrs.AddButtonOverlayAttributes.Clone() as ImageAttributes;
            }
            if (attrs.AddButtonFgAttributes != null)
            {
                AddButtonFgAttributes = attrs.AddButtonFgAttributes.Clone() as ImageAttributes;
            }
            if (attrs.SearchButtonAttributes != null)
            {
                SearchButtonAttributes = attrs.SearchButtonAttributes.Clone() as ImageAttributes;
            }
            if (attrs.SpaceBetweenTextFieldAndRightButton != null)
            {
                SpaceBetweenTextFieldAndRightButton = attrs.SpaceBetweenTextFieldAndRightButton;
            }
            if (attrs.SpaceBetweenTextFieldAndLeftButton != null)
            {
                SpaceBetweenTextFieldAndLeftButton = attrs.SpaceBetweenTextFieldAndLeftButton;
            }
        }

        /// <summary>
        /// Cancel button's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes CancelButtonAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Delete button's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes DeleteButtonAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Add button background's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes AddButtonBgAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Add button over lay's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes AddButtonOverlayAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Add button foreground's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes AddButtonFgAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Search  button's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes SearchButtonAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Space bwtwwen text field and right button 's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? SpaceBetweenTextFieldAndRightButton
        {
            get;
            set;
        }

        /// <summary>
        /// Space betwwen text field and left button's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? SpaceBetweenTextFieldAndLeftButton
        {
            get;
            set;
        }

        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new InputFieldAttributes(this);
        }
    }
}
