using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Controls
{
    public class InputFieldAttributes : ViewAttributes
    {
        private ImageAttributes bgImageAttrs = null;
        private TextFieldAttributes inputBoxAttrs = null;
        private ImageAttributes cancelButtonAttrs = null;
        private ImageAttributes deleteButtonAttrs = null;
        private ImageAttributes addButtonBgAttrs = null;
        private ImageAttributes addButtonOverlayAttrs = null;
        private ImageAttributes addButtonTopAttrs = null;
        private int? space = null;
        private int? spaceBetweenTextFieldAndButton = null;

        public InputFieldAttributes() : base() { }

        public InputFieldAttributes(InputFieldAttributes attrs) : base(attrs)
        {
            if (attrs.bgImageAttrs != null)
            {
                bgImageAttrs = attrs.bgImageAttrs.Clone() as ImageAttributes;
            }
            if (attrs.inputBoxAttrs != null)
            {
                inputBoxAttrs = attrs.inputBoxAttrs.Clone() as TextFieldAttributes;
            }
            if (attrs.cancelButtonAttrs != null)
            {
                cancelButtonAttrs = attrs.cancelButtonAttrs.Clone() as ImageAttributes;
            }
            if (attrs.deleteButtonAttrs != null)
            {
                deleteButtonAttrs = attrs.deleteButtonAttrs.Clone() as ImageAttributes;
            }
            if (attrs.addButtonBgAttrs != null)
            {
                addButtonBgAttrs = attrs.addButtonBgAttrs.Clone() as ImageAttributes;
            }
            if (attrs.addButtonOverlayAttrs != null)
            {
                addButtonOverlayAttrs = attrs.addButtonOverlayAttrs.Clone() as ImageAttributes;
            }
            if (attrs.addButtonTopAttrs != null)
            {
                addButtonTopAttrs = attrs.addButtonTopAttrs.Clone() as ImageAttributes;
            }
            if (attrs.space != null)
            {
                space = attrs.space;
            }
            if (attrs.spaceBetweenTextFieldAndButton != null)
            {
                spaceBetweenTextFieldAndButton = attrs.spaceBetweenTextFieldAndButton;
            }
        }

        public static readonly BindableProperty BgImageAttributesProperty = 
            BindableProperty.Create("BgImageAttributes", typeof(ImageAttributes), typeof(InputFieldAttributes), default(ImageAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.bgImageAttrs = (ImageAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                return attrs.bgImageAttrs;
            });

        public static readonly BindableProperty InputBoxAttributesProperty =
            BindableProperty.Create("InputBoxAttributes", typeof(TextFieldAttributes), typeof(InputFieldAttributes), default(TextFieldAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.inputBoxAttrs = (TextFieldAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                return attrs.inputBoxAttrs;
            });

        public static readonly BindableProperty CancelButtonAttributesProperty =
            BindableProperty.Create("CancelButtonAttributes", typeof(ImageAttributes), typeof(InputFieldAttributes), default(ImageAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.cancelButtonAttrs = (ImageAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                return attrs.cancelButtonAttrs;
            });

        public static readonly BindableProperty DeleteButtonAttributesProperty =
            BindableProperty.Create("DeleteButtonAttributes", typeof(ImageAttributes), typeof(InputFieldAttributes), default(ImageAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.deleteButtonAttrs = (ImageAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                return attrs.deleteButtonAttrs;
            });

        public static readonly BindableProperty AddButtonBgAttributesProperty =
            BindableProperty.Create("AddButtonBgAttributes", typeof(ImageAttributes), typeof(InputFieldAttributes), default(ImageAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.addButtonBgAttrs = (ImageAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                return attrs.addButtonBgAttrs;
            });

        public static readonly BindableProperty AddButtonOverlayAttributesProperty =
            BindableProperty.Create("AddButtonOverlayAttributes", typeof(ImageAttributes), typeof(InputFieldAttributes), default(ImageAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.addButtonOverlayAttrs = (ImageAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                return attrs.addButtonOverlayAttrs;
            });

        public static readonly BindableProperty AddButtonTopAttributesProperty =
            BindableProperty.Create("AddButtonTopAttributes", typeof(ImageAttributes), typeof(InputFieldAttributes), default(ImageAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.addButtonTopAttrs = (ImageAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                return attrs.addButtonTopAttrs;
            });

        public static readonly BindableProperty SpaceProperty =
            BindableProperty.Create("Space", typeof(int?), typeof(InputFieldAttributes), default(int?),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.space = (int?)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                return attrs.space;
            });

        public static readonly BindableProperty SpaceBetweenTextFieldAndButtonProperty =
            BindableProperty.Create("SpaceBetweenTextFieldAndButton", typeof(int?), typeof(InputFieldAttributes), default(int?),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.spaceBetweenTextFieldAndButton = (int?)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                return attrs.spaceBetweenTextFieldAndButton;
            });

        public ImageAttributes BgImageAttributes
        {
            get { return (ImageAttributes)GetValue(BgImageAttributesProperty); }
            set { SetValue(BgImageAttributesProperty, value); }
        }

        public TextFieldAttributes InputBoxAttributes
        {
            get { return (TextFieldAttributes)GetValue(InputBoxAttributesProperty); }
            set { SetValue(InputBoxAttributesProperty, value); }
        }

        public ImageAttributes CancelButtonAttributes
        {
            get { return (ImageAttributes)GetValue(CancelButtonAttributesProperty); }
            set { SetValue(CancelButtonAttributesProperty, value); }
        }

        public ImageAttributes DeleteButtonAttributes
        {
            get { return (ImageAttributes)GetValue(DeleteButtonAttributesProperty); }
            set { SetValue(DeleteButtonAttributesProperty, value); }
        }

        public ImageAttributes AddButtonBgAttributes
        {
            get { return (ImageAttributes)GetValue(AddButtonBgAttributesProperty); }
            set { SetValue(AddButtonBgAttributesProperty, value); }
        }

        public ImageAttributes AddButtonOverlayAttributes
        {
            get { return (ImageAttributes)GetValue(AddButtonOverlayAttributesProperty); }
            set { SetValue(AddButtonOverlayAttributesProperty, value); }
        }

        public ImageAttributes AddButtonTopAttributes
        {
            get { return (ImageAttributes)GetValue(AddButtonTopAttributesProperty); }
            set { SetValue(AddButtonTopAttributesProperty, value); }
        }

        public int? Space
        {
            get { return (int?)GetValue(SpaceProperty); }
            set { SetValue(SpaceProperty, value); }
        }

        public int? SpaceBetweenTextFieldAndButton
        {
            get { return (int?)GetValue(SpaceBetweenTextFieldAndButtonProperty); }
            set { SetValue(SpaceBetweenTextFieldAndButtonProperty, value); }
        }

        public override Attributes Clone()
        {
            return new InputFieldAttributes(this);
        }
    }
}
