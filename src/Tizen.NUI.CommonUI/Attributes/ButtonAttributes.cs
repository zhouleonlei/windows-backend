
namespace Tizen.NUI.CommonUI
{
    public class ButtonAttributes : ViewAttributes
    {
        public ButtonAttributes() : base() { }
        public ButtonAttributes(ButtonAttributes attributes) : base(attributes)
        {
            if(attributes == null)
            {
                return;
            }

            IsSelectable = attributes.IsSelectable;
            IconRelativeOrientation = attributes.IconRelativeOrientation;

            if (attributes.ShadowImageAttributes != null)
            {
                ShadowImageAttributes = attributes.ShadowImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.BackgroundImageAttributes != null)
            {
                BackgroundImageAttributes = attributes.BackgroundImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.OverlayImageAttributes != null)
            {
                OverlayImageAttributes = attributes.OverlayImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.TextAttributes != null)
            {
                TextAttributes = attributes.TextAttributes.Clone() as TextAttributes;
            }

            if (attributes.IconAttributes != null)
            {
                IconAttributes = attributes.IconAttributes.Clone() as ImageAttributes;
            }
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

        public ImageAttributes OverlayImageAttributes
        {
            get;
            set;
        }

        public TextAttributes TextAttributes
        {
            get;
            set;
        }

        public ImageAttributes IconAttributes
        {
            get;
            set;
        }

        public bool? IsSelectable
        {
            get;
            set;
        }
        public Button.IconOrientation? IconRelativeOrientation
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new ButtonAttributes(this);
        }
    }
}
