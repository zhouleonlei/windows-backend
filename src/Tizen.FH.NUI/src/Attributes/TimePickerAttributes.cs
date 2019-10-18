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
    /// TimePickerAttributes is a class which saves Time Picker's ux data.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TimePickerAttributes : ViewAttributes
    {
        /// <summary>
        /// Creates a new instance of a TimePickerAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TimePickerAttributes() : base() { }

        /// <summary>
        /// Creates a new instance of a TimePickerAttributes with attributes.
        /// </summary>
        /// <param name="attributes">Create TimePickerAttributes by attributes customized by user.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TimePickerAttributes(TimePickerAttributes attributes) : base(attributes)
        {
            if (attributes.ShadowImageAttributes != null)
            {
                ShadowImageAttributes = attributes.ShadowImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.BackgroundImageAttributes != null)
            {
                BackgroundImageAttributes = attributes.BackgroundImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.TitleTextAttributes != null)
            {
                TitleTextAttributes = attributes.TitleTextAttributes.Clone() as TextAttributes;
            }
            
            ShadowOffset = new Vector4(attributes.ShadowOffset.W, attributes.ShadowOffset.X, attributes.ShadowOffset.Y, attributes.ShadowOffset.Z);

            if (attributes.HourSpinAttributes != null)
            {
                HourSpinAttributes = attributes.HourSpinAttributes.Clone() as SpinAttributes;
            }

            if (attributes.MinuteSpinAttributes != null)
            {
                MinuteSpinAttributes = attributes.MinuteSpinAttributes.Clone() as SpinAttributes;
            }

            if (attributes.SecondSpinAttributes != null)
            {
                SecondSpinAttributes = attributes.SecondSpinAttributes.Clone() as SpinAttributes;
            }

            if (attributes.AMPMSpinAttributes != null)
            {
                AMPMSpinAttributes = attributes.AMPMSpinAttributes.Clone() as SpinAttributes;
            }

            if (attributes.ColonImageAttributes != null)
            {
                ColonImageAttributes = attributes.ColonImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.WeekViewAttributes != null)
            {
                WeekViewAttributes = attributes.WeekViewAttributes.Clone() as ViewAttributes;
            }

            if (attributes.WeekTitleTextAttributes != null)
            {
                WeekTitleTextAttributes = attributes.WeekTitleTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.WeekSelectImageAttributes != null)
            {
                WeekSelectImageAttributes = attributes.WeekSelectImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.WeekTextAttributes != null)
            {
                WeekTextAttributes = attributes.WeekTextAttributes.Clone() as TextAttributes;
            }
        }

        /// <summary>
        /// Time Picker shaow image's attributes.
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
        /// Time Picker background image's attributes.
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
        /// Time Picker title text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes TitleTextAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// ShadowOffset.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 ShadowOffset
        {
            get;
            set;
        }

        /// <summary>
        /// Time Picker hour spin's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SpinAttributes HourSpinAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Time Picker minute spin's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SpinAttributes MinuteSpinAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Time Picker second spin's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SpinAttributes SecondSpinAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Time Picker AMPM spin's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SpinAttributes AMPMSpinAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Time Picker colon image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes ColonImageAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Time Picker week view's attributes. Used for add week title and week text.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewAttributes WeekViewAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Time Picker week title text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes WeekTitleTextAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Time Picker week select image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes WeekSelectImageAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Time Picker week text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes WeekTextAttributes
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
            return new TimePickerAttributes(this);
        }
    }
}
