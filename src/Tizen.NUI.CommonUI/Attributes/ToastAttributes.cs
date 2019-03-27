using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.CommonUI
{
    public class ToastAttributes : ViewAttributes
    {

        public ToastAttributes() : base() { }

        public ToastAttributes(ToastAttributes attributes) : base(attributes)
        {
            if(attributes == null)
            {
                return;
            }
            if(attributes.BackgroundImageAttributes != null)
            {
                BackgroundImageAttributes = attributes.BackgroundImageAttributes.Clone() as ImageAttributes;
            }
            if(attributes.TextAttributes != null)
            {
                TextAttributes = attributes.TextAttributes.Clone() as TextAttributes;
            }
        }

        public ImageAttributes BackgroundImageAttributes
        {
            get;
            set;
        }

        public TextAttributes TextAttributes
        {
            get;
            set;
        }

        public int? UpSpace
        {
            get;
            set;
        }
        public override Attributes Clone()
        {
            return new ToastAttributes(this);
        }

    }
}
