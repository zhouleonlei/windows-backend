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
    /// PickerAttributes is a class which saves Date Picker's ux data.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PickerAttributes : ViewAttributes
    {  
        /// <summary>
        /// Creates a new instance of a PickerAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PickerAttributes() : base() { }

        /// <summary>
        /// Creates a new instance of a PickerAttributes with attributes.
        /// </summary>
        /// <param name="attributes">Create PickerAttributes by attributes customized by user.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PickerAttributes(PickerAttributes attributes) : base(attributes)
        {
            if (attributes.ShadowImageAttributes != null)
            {
                ShadowImageAttributes = attributes.ShadowImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.BackgroundImageAttributes != null)
            {
                BackgroundImageAttributes = attributes.BackgroundImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.FocusImageAttributes != null)
            {
                FocusImageAttributes = attributes.FocusImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.EndSelectedImageAttributes != null)
            {
                EndSelectedImageAttributes = attributes.EndSelectedImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.SunTextAttributes != null)
            {
                SunTextAttributes = attributes.SunTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.DateViewAttributes != null)
            {
                DateViewAttributes = attributes.DateViewAttributes.Clone() as ViewAttributes;
            }

            if (attributes.MonTextAttributes != null)
            {
                MonTextAttributes = attributes.MonTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.TueTextAttributes != null)
            {
                TueTextAttributes = attributes.TueTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.WenTextAttributes != null)
            {
                WenTextAttributes = attributes.WenTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.ThuTextAttributes != null)
            {
                ThuTextAttributes = attributes.ThuTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.FriTextAttributes != null)
            {
                FriTextAttributes = attributes.FriTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.SatTextAttributes != null)
            {
                SatTextAttributes = attributes.SatTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.DateTextAttributes != null)
            {
                DateTextAttributes = attributes.DateTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.DateText2Attributes != null)
            {
                DateText2Attributes = attributes.DateText2Attributes.Clone() as TextAttributes;
            }

            if (attributes.LeftArrowImageAttributes != null)
            {
                LeftArrowImageAttributes = attributes.LeftArrowImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.RightArrowImageAttributes != null)
            {
                RightArrowImageAttributes = attributes.RightArrowImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.MonthTextAttributes != null)
            {
                MonthTextAttributes = attributes.MonthTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.YearDropDownAttributes != null)
            {
                YearDropDownAttributes = attributes.YearDropDownAttributes.Clone() as DropDownAttributes;
            }

            if (attributes.YearDropDownItemAttributes != null)
            {
                YearDropDownItemAttributes = attributes.YearDropDownItemAttributes.Clone() as DropDownItemAttributes;
            }

            YearRange = new Vector2(attributes.YearRange.X, attributes.YearRange.Y);

        }

        /// <summary>
        /// Date Picker shaow image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes ShadowImageAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Date Picker background image's attributes.
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
        /// Date Picker focus image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes FocusImageAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Date Picker end selected image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes EndSelectedImageAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Date Picker date view's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]        
        public ViewAttributes DateViewAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Date Picker sunday text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)] 
        public TextAttributes SunTextAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Date Picker mondy text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes MonTextAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Date Picker tuesday text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes TueTextAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Date Picker wensday text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes WenTextAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Date Picker thursday text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes ThuTextAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Date Picker friday text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes FriTextAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Date Picker saturday text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes SatTextAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Date Picker date text's attributes. Date of a month.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes DateTextAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Date Picker date text's attributes. Date of a month. They have width difference from DateTextAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes DateText2Attributes
        {
            get;
            set;
        }

        /// <summary>
        /// Date Picker left arrow image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes LeftArrowImageAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Date Picker right arrow image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes RightArrowImageAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Date Picker month text's attributes. Show the current month.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes MonthTextAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Date Picker year dropdown's attributes. It can change year.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDownAttributes YearDropDownAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Date Picker year dropdown item's attributes. used for YearDropDownAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDownItemAttributes YearDropDownItemAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Date Picker year range.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 YearRange
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
            return new PickerAttributes(this);
        }
    }
}
