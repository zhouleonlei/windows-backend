using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Controls
{
    public class ButtonAttributes : ViewAttributes
    {
        public static readonly BindableProperty ShadowImageAttributesProperty = BindableProperty.Create("ShadowImageAttributes", typeof(ImageAttributes), typeof(ButtonAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ButtonAttributes)bindable;
            if (newValue != null)
            {
                attrs.shadowImageAttrs = (ImageAttributes)newValue;
            }
        },
       defaultValueCreator: (bindable) =>
       {
           var attrs = (ButtonAttributes)bindable;
           return attrs.shadowImageAttrs;
       });
        public static readonly BindableProperty BackgroundImageAttributesProperty = BindableProperty.Create("BackgroundImageAttributes", typeof(ImageAttributes), typeof(ButtonAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ButtonAttributes)bindable;
            if (newValue != null)
            {
                attrs.backgroundImageAttrs = (ImageAttributes)newValue;
            }
        },
       defaultValueCreator: (bindable) =>
       {
           var attrs = (ButtonAttributes)bindable;
           return attrs.backgroundImageAttrs;
       });
        public static readonly BindableProperty OverlayImageAttributesProperty = BindableProperty.Create("OverlayImageAttributes", typeof(ImageAttributes), typeof(ButtonAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ButtonAttributes)bindable;
            if (newValue != null)
            {
                attrs.overlayImageAttrs = (ImageAttributes)newValue;
            }
        },
       defaultValueCreator: (bindable) =>
       {
           var attrs = (ButtonAttributes)bindable;
           return attrs.overlayImageAttrs;
       });
        public static readonly BindableProperty TextAttributesProperty = BindableProperty.Create("TextAttributes", typeof(TextAttributes), typeof(ButtonAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ButtonAttributes)bindable;
            if (newValue != null)
            {
                attrs.textAttrs = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ButtonAttributes)bindable;
            return attrs.textAttrs;
        });
        public static readonly BindableProperty IconAttributesProperty = BindableProperty.Create("IconAttributes", typeof(ImageAttributes), typeof(ButtonAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ButtonAttributes)bindable;
            if (newValue != null)
            {
                attrs.iconAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ButtonAttributes)bindable;
            return attrs.iconAttrs;
        });

        public static readonly BindableProperty IsSelectableProperty = BindableProperty.Create("IsSelectable", typeof(bool?), typeof(ButtonAttributes), default(bool?), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ButtonAttributes)bindable;
            if (newValue != null)
            {
                attrs.isSelectable = (bool?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ButtonAttributes)bindable;
            return attrs.isSelectable;
        });

        public static readonly BindableProperty IconRelativeOrientationProperty = BindableProperty.Create("IconRelativeOrientation", typeof(Button.IconOrientation?), typeof(ButtonAttributes), default(Button.IconOrientation?), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ButtonAttributes)bindable;
            if (newValue != null)
            {
                attrs.iconRelativeOrientation = (Button.IconOrientation?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ButtonAttributes)bindable;
            return attrs.iconRelativeOrientation;
        });

        private bool? isSelectable;
        private Button.IconOrientation? iconRelativeOrientation;
        private ImageAttributes shadowImageAttrs;
        private ImageAttributes backgroundImageAttrs;
        private ImageAttributes overlayImageAttrs;
        private TextAttributes textAttrs;
        private ImageAttributes iconAttrs;

        public ButtonAttributes() : base() { }
        public ButtonAttributes(ButtonAttributes attributes) : base(attributes)
        {
            isSelectable = attributes.isSelectable;
            iconRelativeOrientation = attributes.iconRelativeOrientation;

            if (attributes.shadowImageAttrs != null)
            {
                shadowImageAttrs = attributes.shadowImageAttrs.Clone() as ImageAttributes;
            }

            if (attributes.backgroundImageAttrs != null)
            {
                backgroundImageAttrs = attributes.backgroundImageAttrs.Clone() as ImageAttributes;
            }

            if (attributes.overlayImageAttrs != null)
            {
                overlayImageAttrs = attributes.overlayImageAttrs.Clone() as ImageAttributes;
            }

            if (attributes.textAttrs != null)
            {
                textAttrs = attributes.textAttrs.Clone() as TextAttributes;
            }

            if (attributes.iconAttrs != null)
            {
                iconAttrs = attributes.iconAttrs.Clone() as ImageAttributes;
            }
        }

        public ImageAttributes ShadowImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(ShadowImageAttributesProperty);
            }
            set
            {
                SetValue(ShadowImageAttributesProperty, value);
            }
        }

        public ImageAttributes BackgroundImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(BackgroundImageAttributesProperty);
            }
            set
            {
                SetValue(BackgroundImageAttributesProperty, value);
            }
        }

        public ImageAttributes OverlayImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(OverlayImageAttributesProperty);
            }
            set
            {
                SetValue(OverlayImageAttributesProperty, value);
            }
        }

        public TextAttributes TextAttributes
        {
            get
            {
                return (TextAttributes)GetValue(TextAttributesProperty);
            }
            set
            {
                SetValue(TextAttributesProperty, value);
            }
        }

        public ImageAttributes IconAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(IconAttributesProperty);
            }
            set
            {
                SetValue(IconAttributesProperty, value);
            }
        }

        public bool? IsSelectable
        {
            get
            {
                return (bool?)GetValue(IsSelectableProperty);
            }
            set
            {
                SetValue(IsSelectableProperty, value);
            }
        }
        public Button.IconOrientation? IconRelativeOrientation
        {
            get
            {
                return (Button.IconOrientation?)GetValue(IconRelativeOrientationProperty);
            }
            set
            {
                SetValue(IconRelativeOrientationProperty, value);
            }
        }

        public override Attributes Clone()
        {
            return new ButtonAttributes(this);
        }

    }
}
