namespace Tizen.NUI.CommonUI
{
    public class SpinAttributes : ViewAttributes
    {
        public SpinAttributes() : base() { }
        public SpinAttributes(SpinAttributes attributes) : base(attributes)
        {
            if (attributes.BackgroundImageAttributes != null)
            {
                BackgroundImageAttributes = attributes.BackgroundImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.TextAttrs != null)
            {
                TextAttrs = attributes.TextAttrs.Clone() as TextAttributes;
            }

            if (attributes.NameTextAttrs != null)
            {
                NameTextAttrs = attributes.NameTextAttrs.Clone() as TextAttributes;
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

            if (attributes.DividerRecAttrs != null)
            {
                DividerRecAttrs = attributes.DividerRecAttrs.Clone() as ViewAttributes;
            }

            if (attributes.DividerRec2Attrs != null)
            {
                DividerRec2Attrs = attributes.DividerRec2Attrs.Clone() as ViewAttributes;
            }

            if (attributes.TextFieldAttrs != null)
            {
                TextFieldAttrs = attributes.TextFieldAttrs.Clone() as TextFieldAttributes;
            }

            Min = attributes.Min;
            Max = attributes.Max;
            Cur = attributes.Cur;
            ItemHeight = attributes.ItemHeight;
            TextSize = attributes.TextSize;
            CenterTextSize = attributes.CenterTextSize;
        }

        public ImageAttributes BackgroundImageAttributes
        {
            get;
            set;
        }

        public TextAttributes TextAttrs
        {
            get;
            set;
        }

        public TextAttributes NameTextAttrs
        {
            get;
            set;
        }

        public ImageAttributes MaskTopImageAttributes
        {
            get;
            set;
        }

        public ImageAttributes MaskBottomImageAttributes
        {
            get;
            set;
        }

        public ViewAttributes AniViewAttributes
        {
            get;
            set;
        }

        public ViewAttributes ClipViewAttributes
        {
            get;
            set;
        }

        public ViewAttributes NameViewAttributes
        {
            get;
            set;
        }

        public ViewAttributes DividerRecAttrs
        {
            get;
            set;
        }

        public ViewAttributes DividerRec2Attrs
        {
            get;
            set;
        }

        public ViewAttributes TextFieldAttrs
        {
            get;
            set;
        }

        public int Min
        {
            get;
            set;
        }

        public int Max
        {
            get;
            set;
        }

        public int Cur
        {
            get;
            set;
        }

        public int ItemHeight
        {
            get;
            set;
        }

        public int TextSize
        {
            get;
            set;
        }

        public int CenterTextSize
        {
            get;
            set;
        }
        public override Attributes Clone()
        {
            return new SpinAttributes(this);
        }
    }
}
