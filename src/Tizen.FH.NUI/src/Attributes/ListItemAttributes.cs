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
    /// ListItemAttributes is a class which saves ListItem's ux data.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ListItemAttributes : Tizen.NUI.CommonUI.ViewAttributes
    {
        /// <summary>
        /// Creates a new instance of a ListItemAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]

        public ListItemAttributes() : base() { }

        /// <summary>
        /// Creates a new instance of a ListItemAttributes with attributes.
        /// </summary>
        /// <param name="attributes">Create ListItemAttributes by attributes customized by user.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ListItemAttributes(ListItemAttributes attrs) : base(attrs)
        {
            if (attrs.MainTextAttributes != null)
            {
                MainTextAttributes = attrs.MainTextAttributes.Clone() as TextAttributes;
            }
            if (attrs.SubTextAttributes != null)
            {
                SubTextAttributes = attrs.SubTextAttributes.Clone() as TextAttributes;
            }
            if (attrs.DividerViewAttributes != null)
            {
                DividerViewAttributes = attrs.DividerViewAttributes.Clone() as ImageAttributes;
            }
            if (attrs.LeftItemRootViewAttributes != null)
            {
                LeftItemRootViewAttributes = attrs.LeftItemRootViewAttributes.Clone() as ViewAttributes;
            }
            if (attrs.RightItemRootViewAttributes != null)
            {
                RightItemRootViewAttributes = attrs.RightItemRootViewAttributes.Clone() as ViewAttributes;
            }
            if (attrs.LeftIconAttributes != null)
            {
                LeftIconAttributes = attrs.LeftIconAttributes.Clone() as ImageAttributes;
            }
            if (attrs.RightIconAttributes != null)
            {
                RightIconAttributes = attrs.RightIconAttributes.Clone() as ImageAttributes;
            }
            if (attrs.RightTextAttributes != null)
            {
                RightTextAttributes = attrs.RightTextAttributes.Clone() as TextAttributes;
            }
            if (attrs.LeftSpace != null)
            {
                LeftSpace = attrs.LeftSpace;
            }
            if (attrs.RightSpace != null)
            {
                RightSpace = attrs.RightSpace;
            }
            if (attrs.SpaceBetweenLeftItemAndText != null)
            {
                SpaceBetweenLeftItemAndText = attrs.SpaceBetweenLeftItemAndText;
            }
            if (attrs.SpaceBetweenRightItemAndText != null)
            {
                SpaceBetweenRightItemAndText = attrs.SpaceBetweenRightItemAndText;
            }
            if (attrs.CheckBoxStyle != null)
            {
                CheckBoxStyle = attrs.CheckBoxStyle;
            }
            if (attrs.SwitchStyle != null)
            {
                SwitchStyle = attrs.SwitchStyle;
            }
            if (attrs.DropDownStyle != null)
            {
                DropDownStyle = attrs.DropDownStyle;
            }
            StyleType = attrs.StyleType;
        }
        /// <summary>
        /// MainText's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes MainTextAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// MainText's attributes when style is group index  and groupIndexType is none
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes MainText2Attributes
        {
            get;
            set;
        }
        /// <summary>
        /// Subtext's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes SubTextAttributes
        {
            get;
            set;
        }
        /// <summary>
        /// Divider view's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes DividerViewAttributes
        {
            get;
            set;
        }
        /// <summary>
        /// Left item root view's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewAttributes LeftItemRootViewAttributes
        {
            get;
            set;
        }
        /// <summary>
        /// Right item root view's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewAttributes RightItemRootViewAttributes
        {
            get;
            set;
        }
        /// <summary>
        /// Left icon's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes LeftIconAttributes
        {
            get;
            set;
        }
        /// <summary>
        /// Right icon's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes RightIconAttributes
        {
            get;
            set;
        }
        /// <summary>
        /// Right text's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes RightTextAttributes
        {
            get;
            set;
        }
        /// <summary>
        /// Left space's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint? LeftSpace
        {
            get;
            set;
        }
        /// <summary>
        /// Right space's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint? RightSpace
        {
            get;
            set;
        }
        /// <summary>
        /// Space between left item and text's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint? SpaceBetweenLeftItemAndText
        {
            get;
            set;
        }
        /// <summary>
        /// Space between right item and text's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint? SpaceBetweenRightItemAndText
        {
            get;
            set;
        }
        /// <summary>
        /// CheckBox style's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CheckBoxStyle
        {
            get;
            set;
        }
        /// <summary>
        /// Switch style's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SwitchStyle
        {
            get;
            set;
        }
        /// <summary>
        /// DropDown style's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DropDownStyle
        {
            get;
            set;
        }
        /// <summary>
        /// Style style's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ListItem.StyleTypes StyleType
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
            return new ListItemAttributes(this);
        }
    }
}
