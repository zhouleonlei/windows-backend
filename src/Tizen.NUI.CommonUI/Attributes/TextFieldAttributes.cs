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

namespace Tizen.NUI.CommonUI
{
    /// <summary>
    /// TextFieldAttributes is a class which saves TextField's ux data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TextFieldAttributes : ViewAttributes
    {
        /// <summary>
        /// Creates a new instance of a TextField.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextFieldAttributes() : base() { }
        /// <summary>
        /// Creates a new instance of a TextField with style.
        /// </summary>
        /// <param name="style">Create TextField by special style defined in UX.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextFieldAttributes(TextFieldAttributes attributes) : base(attributes)
        {
            if(attributes == null)
            {
                return;
            }
            if (attributes.Text != null)
            {
                Text = attributes.Text.Clone() as StringSelector;
            }
            if (attributes.PlaceholderText != null)
            {
                PlaceholderText = attributes.PlaceholderText.Clone() as StringSelector;
            }
            if (attributes.TranslatablePlaceholderText != null)
            {
                TranslatablePlaceholderText = attributes.TranslatablePlaceholderText.Clone() as StringSelector;
            }
            if (attributes.HorizontalAlignment != null)
            {
                HorizontalAlignment = attributes.HorizontalAlignment;
            }
            if (attributes.VerticalAlignment != null)
            {
                VerticalAlignment = attributes.VerticalAlignment;
            }
            if (attributes.EnableMarkup != null)
            {
                EnableMarkup = attributes.EnableMarkup;
            }
            if (attributes.TextColor != null)
            {
                TextColor = attributes.TextColor.Clone() as ColorSelector;
            }
            if (attributes.PlaceholderTextColor != null)
            {
                PlaceholderTextColor = attributes.PlaceholderTextColor.Clone() as ColorSelector;
            }
            if (attributes.PrimaryCursorColor != null)
            {
                PrimaryCursorColor = attributes.PrimaryCursorColor.Clone() as ColorSelector;
            }
            if (attributes.SecondaryCursorColor != null)
            {
                SecondaryCursorColor = attributes.SecondaryCursorColor.Clone() as ColorSelector;
            }
            if (attributes.FontFamily != null)
            {
                FontFamily = attributes.FontFamily;
            }
            if (attributes.PointSize != null)
            {
                PointSize = attributes.PointSize.Clone() as FloatSelector;
            }
            if (attributes.EnableCursorBlink != null)
            {
                EnableCursorBlink = attributes.EnableCursorBlink;
            }
            if (attributes.EnableSelection != null)
            {
                EnableSelection = attributes.EnableSelection;
            }
            if (attributes.CursorWidth != null)
            {
                CursorWidth = attributes.CursorWidth;
            }
            if (attributes.EnableEllipsis != null)
            {
                EnableEllipsis = attributes.EnableEllipsis;
            }
        }

        /// <summary>
        /// Text's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector Text
        {
            get;
            set;
        }

        /// <summary>
        /// Place holder text's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector PlaceholderText
        {
            get;
            set;
        }

        /// <summary>
        /// Translatable place holder text's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector TranslatablePlaceholderText
        {
            get;
            set;
        }

        /// <summary>
        /// Horizontal alignment's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalAlignment? HorizontalAlignment
        {
            get;
            set;
        }

        /// <summary>
        /// Vertical alignment's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalAlignment? VerticalAlignment
        {
            get;
            set;
        }

        /// <summary>
        /// Enable mark up's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableMarkup
        {
            get;
            set;
        }

        /// <summary>
        /// Text color's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorSelector TextColor
        {
            get;
            set;
        }

        /// <summary>
        /// Place holder text color's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorSelector PlaceholderTextColor
        {
            get;
            set;
        }

        /// <summary>
        /// Primary cursor color's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorSelector PrimaryCursorColor
        {
            get;
            set;
        }

        /// <summary>
        /// Secondary cursor color's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorSelector SecondaryCursorColor
        {
            get;
            set;
        }

        /// <summary>
        /// Font family's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FontFamily
        {
            get;
            set;
        }

        /// <summary>
        /// Poin size's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FloatSelector PointSize
        {
            get;
            set;
        }

        /// <summary>
        /// Enable cursor blink's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableCursorBlink
        {
            get;
            set;
        }

        /// <summary>
        /// Enable selection's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableSelection
        {
            get;
            set;
        }

        /// <summary>
        /// Cursor width's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? CursorWidth
        {
            get;
            set;
        }

        /// <summary>
        /// Enable ellipsisn's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableEllipsis
        {
            get;
            set;
        }

        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new TextFieldAttributes(this);
        }
    }
}
