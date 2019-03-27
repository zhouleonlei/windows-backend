namespace Tizen.NUI.Controls
{
    public class SelectButtonAttributes : ButtonAttributes
    {
        public SelectButtonAttributes() : base() { }
        public SelectButtonAttributes(SelectButtonAttributes attributes) : base(attributes)
        {
            if(attributes == null)
            {
                return;
            }
            if (attributes.CheckImageAttributes != null)
            {
                CheckImageAttributes = attributes.CheckImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.CheckBackgroundImageAttributes != null)
            {
                CheckBackgroundImageAttributes = attributes.CheckBackgroundImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.CheckShadowImageAttributes != null)
            {
                CheckShadowImageAttributes = attributes.CheckShadowImageAttributes.Clone() as ImageAttributes;
            }
        }

        public ImageAttributes CheckImageAttributes
        {
            get;
            set;
        }

        public ImageAttributes CheckBackgroundImageAttributes
        {
            get;
            set;
        }

        public ImageAttributes CheckShadowImageAttributes
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new SelectButtonAttributes(this);
        }
    }
}
