namespace Tizen.NUI.CommonUI
{
    public class SwitchAttributes : ButtonAttributes
    {
        public SwitchAttributes() : base() { }
        public SwitchAttributes(SwitchAttributes attributes) : base(attributes)
        {
            if(attributes == null)
            {
                return;
            }
            if (attributes.SwitchHandlerImageAttributes != null)
            {
                SwitchHandlerImageAttributes = attributes.SwitchHandlerImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.SwitchBackgroundImageAttributes != null)
            {
                SwitchBackgroundImageAttributes = attributes.SwitchBackgroundImageAttributes.Clone() as ImageAttributes;
            }
        }

        public ImageAttributes SwitchHandlerImageAttributes
        {
            get;
            set;
        }

        public ImageAttributes SwitchBackgroundImageAttributes
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new SwitchAttributes(this);
        }
    }
}
