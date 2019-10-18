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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// SpinAttributes is a class which saves Spin's ux data.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SpinAttributes : ViewAttributes
    {
        /// <summary>
        /// Creates a new instance of a SpinAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SpinAttributes() : base() { }

        /// <summary>
        /// Creates a new instance of a SpinAttributes with attributes.
        /// </summary>
        /// <param name="attributes">Create SpinAttributes by attributes customized by user.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SpinAttributes(SpinAttributes attributes) : base(attributes)
        {
            if (attributes.BackgroundImageAttributes != null)
            {
                BackgroundImageAttributes = attributes.BackgroundImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.ItemTextAttributes != null)
            {
                ItemTextAttributes = attributes.ItemTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.NameTextAttributes != null)
            {
                NameTextAttributes = attributes.NameTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.MaskTopImageAttributes != null)
            {
                MaskTopImageAttributes = attributes.MaskTopImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.MaskBottomImageAttributes != null)
            {
                MaskBottomImageAttributes = attributes.MaskBottomImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.AniViewAttributes != null)
            {
                AniViewAttributes = attributes.AniViewAttributes.Clone() as ViewAttributes;
            }
            
            if (attributes.ClipViewAttributes != null)
            {
                ClipViewAttributes = attributes.ClipViewAttributes.Clone() as ViewAttributes;
            }

            if (attributes.NameViewAttributes != null)
            {
                NameViewAttributes = attributes.NameViewAttributes.Clone() as ViewAttributes;
            }

            if (attributes.DividerRecAttributes != null)
            {
                DividerRecAttributes = attributes.DividerRecAttributes.Clone() as ViewAttributes;
            }

            if (attributes.DividerRec2Attributes != null)
            {
                DividerRec2Attributes = attributes.DividerRec2Attributes.Clone() as ViewAttributes;
            }

            if (attributes.TextFieldAttributes != null)
            {
                TextFieldAttributes = attributes.TextFieldAttributes.Clone() as TextFieldAttributes;
            }

            Min = attributes.Min;
            Max = attributes.Max;
            Cur = attributes.Cur;
            ItemHeight = attributes.ItemHeight;
            TextSize = attributes.TextSize;
            CenterTextSize = attributes.CenterTextSize;
        }

        /// <summary>
        /// Spin background image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes BackgroundImageAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Spin item text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes ItemTextAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Spin name text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes NameTextAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Spin top mask image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes MaskTopImageAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Spin bottom mask image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes MaskBottomImageAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Spin animation view's attributes. AniView is attached to Anination Control.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewAttributes AniViewAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Spin clip view's attributes. ClipView is used for hiding exceed content when animation.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewAttributes ClipViewAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Spin name view's attributes. NameView is used for adding name text.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewAttributes NameViewAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Spin first divider line's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewAttributes DividerRecAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Spin sencond divider line's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewAttributes DividerRec2Attributes
        {
            get;
            set;
        }

        /// <summary>
        /// Spin text field's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextFieldAttributes TextFieldAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Spin min value's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Min
        {
            get;
            set;
        }

        /// <summary>
        /// Spin max value's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Max
        {
            get;
            set;
        }

        /// <summary>
        /// Spin current value's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Cur
        {
            get;
            set;
        }

        /// <summary>
        /// Spin item height.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int ItemHeight
        {
            get;
            set;
        }

        /// <summary>
        /// Spin up and down item text size.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TextSize
        {
            get;
            set;
        }

        /// <summary>
        /// Spin center item text size.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CenterTextSize
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
            return new SpinAttributes(this);
        }
    }
}
