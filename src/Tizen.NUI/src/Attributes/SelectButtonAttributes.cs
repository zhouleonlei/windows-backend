using Tizen.NUI.Binding;

namespace Tizen.NUI.Controls
{
    public class SelectButtonAttributes : ButtonAttributes
    {
        public static readonly BindableProperty CheckImageAttributesProperty = BindableProperty.Create("CheckImageAttributes", typeof(ImageAttributes), typeof(SelectButtonAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SelectButtonAttributes)bindable;
            if (newValue != null)
            {
                attrs.checkImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SelectButtonAttributes)bindable;
            return attrs.checkImageAttrs;
        });

        public static readonly BindableProperty CheckBackgroundImageAttributesProperty = BindableProperty.Create("CheckBackgroundImageAttributes", typeof(ImageAttributes), typeof(SelectButtonAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SelectButtonAttributes)bindable;
            if (newValue != null)
            {
                attrs.checkBackgroundImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SelectButtonAttributes)bindable;
            return attrs.checkBackgroundImageAttrs;
        });

        public static readonly BindableProperty CheckShadowImageAttributesProperty = BindableProperty.Create("CheckShadowImageAttributes", typeof(ImageAttributes), typeof(SelectButtonAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SelectButtonAttributes)bindable;
            if (newValue != null)
            {
                attrs.checkShadowImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SelectButtonAttributes)bindable;
            return attrs.checkShadowImageAttrs;
        });

        private ImageAttributes checkImageAttrs;
        private ImageAttributes checkBackgroundImageAttrs;
        private ImageAttributes checkShadowImageAttrs;

        public SelectButtonAttributes() : base() { }
        public SelectButtonAttributes(SelectButtonAttributes attributes) : base(attributes)
        {
            if (attributes.checkImageAttrs != null)
            {
                checkImageAttrs = attributes.checkImageAttrs.Clone() as ImageAttributes;
            }

            if (attributes.checkBackgroundImageAttrs != null)
            {
                checkBackgroundImageAttrs = attributes.checkBackgroundImageAttrs.Clone() as ImageAttributes;
            }

            if (attributes.checkShadowImageAttrs != null)
            {
                checkShadowImageAttrs = attributes.checkShadowImageAttrs.Clone() as ImageAttributes;
            }
        }

        public ImageAttributes CheckImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(CheckImageAttributesProperty);
            }
            set
            {
                SetValue(CheckImageAttributesProperty, value);
            }
        }

        public ImageAttributes CheckBackgroundImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(CheckBackgroundImageAttributesProperty);
            }
            set
            {
                SetValue(CheckBackgroundImageAttributesProperty, value);
            }
        }

        public ImageAttributes CheckShadowImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(CheckShadowImageAttributesProperty);
            }
            set
            {
                SetValue(CheckShadowImageAttributesProperty, value);
            }
        }

        public override Attributes Clone()
        {
            return new SelectButtonAttributes(this);
        }
    }
}
