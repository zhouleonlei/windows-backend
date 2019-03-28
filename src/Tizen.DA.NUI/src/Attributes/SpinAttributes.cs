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

        public ImageAttributes BackgroundImageAttributes
        {
            get;
            set;
        }

        public TextAttributes ItemTextAttributes
        {
            get;
            set;
        }

        public TextAttributes NameTextAttributes
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

        public ViewAttributes DividerRecAttributes
        {
            get;
            set;
        }

        public ViewAttributes DividerRec2Attributes
        {
            get;
            set;
        }

        public ViewAttributes TextFieldAttributes
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
