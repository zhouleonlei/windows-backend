namespace Tizen.NUI.CommonUI
{
    public class ImageAttributes : ViewAttributes
    {
        public ImageAttributes() : base() { }
        public ImageAttributes(ImageAttributes attributes) : base(attributes)
        {
            if (attributes.ResourceURL != null)
            {
                ResourceURL = attributes.ResourceURL.Clone() as StringSelector;
            }

            if (attributes.Border != null)
            {
                Border = attributes.Border.Clone() as RectangleSelector;
            }
        }

        public StringSelector ResourceURL
        {
            get;
            set;
        }

        public RectangleSelector Border
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new ImageAttributes(this); ;
        }

    }
}
