namespace Tizen.NUI.CommonUI
{
    public class PickerAttributes : ViewAttributes
    {        
        public PickerAttributes() : base() { }
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

            if (attributes.DateTextAttributes2 != null)
            {
                DateTextAttributes2 = attributes.DateTextAttributes2.Clone() as TextAttributes;
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

            if (attributes.DropDownAttrs != null)
            {
                DropDownAttrs = attributes.DropDownAttrs.Clone() as DropDownAttributes;
            }

            if (attributes.DropDownItemAttrs != null)
            {
                DropDownItemAttrs = attributes.DropDownItemAttrs.Clone() as DropDownItemAttributes;
            }

            YearRange = new Vector2(attributes.YearRange.X, attributes.YearRange.Y);

        }

        public ImageAttributes ShadowImageAttributes
        {
            get;
            set;
        }

        public ImageAttributes BackgroundImageAttributes
        {
            get;
            set;
        }

        public ImageAttributes FocusImageAttributes
        {
            get;
            set;
        }

        public ImageAttributes EndSelectedImageAttributes
        {
            get;
            set;
        }
        
        public ViewAttributes DateViewAttributes
        {
            get;
            set;
        }

        public TextAttributes SunTextAttributes
        {
            get;
            set;
        }

        public TextAttributes MonTextAttributes
        {
            get;
            set;
        }

        public TextAttributes TueTextAttributes
        {
            get;
            set;
        }

        public TextAttributes WenTextAttributes
        {
            get;
            set;
        }

        public TextAttributes ThuTextAttributes
        {
            get;
            set;
        }

        public TextAttributes FriTextAttributes
        {
            get;
            set;
        }

        public TextAttributes SatTextAttributes
        {
            get;
            set;
        }

        public TextAttributes DateTextAttributes
        {
            get;
            set;
        }

        public TextAttributes DateTextAttributes2
        {
            get;
            set;
        }

        public ImageAttributes LeftArrowImageAttributes
        {
            get;
            set;
        }

        public ImageAttributes RightArrowImageAttributes
        {
            get;
            set;
        }

        public TextAttributes MonthTextAttributes
        {
            get;
            set;
        }

        public DropDownAttributes DropDownAttrs
        {
            get;
            set;
        }

        public DropDownItemAttributes DropDownItemAttrs
        {
            get;
            set;
        }

        public Vector2 YearRange
        {
            get;
            set;
        }
        public override Attributes Clone()
        {
            return new PickerAttributes(this);
        }
    }
}
