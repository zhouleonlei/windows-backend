namespace Tizen.NUI.CommonUI
{
    public class PopupAttributes : ViewAttributes
    {     
        public PopupAttributes() : base() { }
        public PopupAttributes(PopupAttributes attributes) : base(attributes)
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

            if (attributes.ButtonAttributes != null)
            {
                ButtonAttributes = attributes.ButtonAttributes.Clone() as ButtonAttributes;
            }

            ShadowOffset = new Vector4(attributes.ShadowOffset.W, attributes.ShadowOffset.X, attributes.ShadowOffset.Y, attributes.ShadowOffset.Z);
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

        public TextAttributes TitleTextAttributes
        {
            get;
            set;
        }

        public Vector4 ShadowOffset
        {
            get;
            set;
        }

        public ButtonAttributes ButtonAttributes
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new PopupAttributes(this);
        }
    }
}
