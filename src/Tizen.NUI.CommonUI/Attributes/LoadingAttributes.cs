namespace Tizen.NUI.CommonUI
{
    public class LoadingAttributes : ViewAttributes
    {
        public LoadingAttributes() : base() { }

        public LoadingAttributes(LoadingAttributes attributes) : base(attributes)
        {
            if(attributes == null)
            {
                return;
            }

            if (attributes.LoadingImageURLPrefix != null)
            {
                LoadingImageURLPrefix = attributes.LoadingImageURLPrefix.Clone() as StringSelector;
            }
            if (attributes.FPS != null)
            {
                FPS = attributes.FPS.Clone() as IntSelector;
            }
            if (attributes.LoadingImageAttributes != null)
            {
                LoadingImageAttributes = attributes.LoadingImageAttributes.Clone() as ImageAttributes;
            }
        }

        public StringSelector LoadingImageURLPrefix
        {
            get;
            set;
        }

        public IntSelector FPS
        {
            get;
            set;
        }

        public ImageAttributes LoadingImageAttributes
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new LoadingAttributes(this);
        }

    }
}
