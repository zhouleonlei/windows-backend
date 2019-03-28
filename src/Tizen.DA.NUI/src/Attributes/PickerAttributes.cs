using System.ComponentModel;

﻿namespace Tizen.NUI.CommonUI
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PickerAttributes : ViewAttributes
    {  
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PickerAttributes() : base() { }

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

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes ShadowImageAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes BackgroundImageAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes FocusImageAttributes
        {
            get;
            set;
        }
        
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes EndSelectedImageAttributes
        {
            get;
            set;
        }
        
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]        
        public ViewAttributes DateViewAttributes
        {
            get;
            set;
        }
        
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)] 
        public TextAttributes SunTextAttributes
        {
            get;
            set;
        }
        
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes MonTextAttributes
        {
            get;
            set;
        }
        
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes TueTextAttributes
        {
            get;
            set;
        }
        
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes WenTextAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes ThuTextAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes FriTextAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes SatTextAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes DateTextAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes DateText2Attributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes LeftArrowImageAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes RightArrowImageAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes MonthTextAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDownAttributes YearDropDownAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDownItemAttributes YearDropDownItemAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 YearRange
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new PickerAttributes(this);
        }
    }
}
