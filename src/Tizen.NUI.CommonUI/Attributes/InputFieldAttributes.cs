namespace Tizen.NUI.CommonUI
{
    public class InputFieldAttributes : ViewAttributes
    {
        public InputFieldAttributes() : base() { }

        public InputFieldAttributes(InputFieldAttributes attrs) : base(attrs)
        {
            if (attrs.BackgroundImageAttributes != null)
            {
                BackgroundImageAttributes = attrs.BackgroundImageAttributes.Clone() as ImageAttributes;
            }
            if (attrs.InputBoxAttributes != null)
            {
                InputBoxAttributes = attrs.InputBoxAttributes.Clone() as TextFieldAttributes;
            }
            if (attrs.Space != null)
            {
                Space = attrs.Space;
            }
        }

        public ImageAttributes BackgroundImageAttributes
        {
            get;
            set;
        }

        public TextFieldAttributes InputBoxAttributes
        {
            get;
            set;
        }

        public int? Space
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new InputFieldAttributes(this);
        }
    }
}
