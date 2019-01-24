using Tizen.NUI.Binding;

namespace Tizen.NUI.Controls
{
    public class SwitchAttributes : ButtonAttributes
    {
        public static readonly BindableProperty SwitchHandlerImageAttributesProperty = BindableProperty.Create("SwitchHandlerImageAttributes", typeof(ImageAttributes), typeof(SwitchAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SwitchAttributes)bindable;
            if (newValue != null)
            {
                attrs.switchHandlerImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SwitchAttributes)bindable;
            return attrs.switchHandlerImageAttrs;
        });

        public static readonly BindableProperty SwitchBackgroundImageAttributesProperty = BindableProperty.Create("SwitchBackgroundImageAttributes", typeof(ImageAttributes), typeof(SwitchAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SwitchAttributes)bindable;
            if (newValue != null)
            {
                attrs.switchBackgroundImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SwitchAttributes)bindable;
            return attrs.switchBackgroundImageAttrs;
        });

        private ImageAttributes switchHandlerImageAttrs;
        private ImageAttributes switchBackgroundImageAttrs;

        public SwitchAttributes() : base() { }
        public SwitchAttributes(SwitchAttributes attributes) : base(attributes)
        {
            if (attributes.switchHandlerImageAttrs != null)
            {
                switchHandlerImageAttrs = attributes.switchHandlerImageAttrs.Clone() as ImageAttributes;
            }

            if (attributes.switchBackgroundImageAttrs != null)
            {
                switchBackgroundImageAttrs = attributes.switchBackgroundImageAttrs.Clone() as ImageAttributes;
            }
        }

        public ImageAttributes SwitchHandlerImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(SwitchHandlerImageAttributesProperty);
            }
            set
            {
                SetValue(SwitchHandlerImageAttributesProperty, value);
            }
        }

        public ImageAttributes SwitchBackgroundImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(SwitchBackgroundImageAttributesProperty);
            }
            set
            {
                SetValue(SwitchBackgroundImageAttributesProperty, value);
            }
        }

        public override Attributes Clone()
        {
            return new SwitchAttributes(this);
        }
    }
}
