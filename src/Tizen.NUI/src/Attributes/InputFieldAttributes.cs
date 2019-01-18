using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Controls
{
    public class InputFieldAttributes : ViewAttributes
    {
        private ImageAttributes bgImageViewAttrs = null;
        private TextFieldAttributes textFieldViewAttrs = null;
        private ImageAttributes cancelBtnAttrs = null;
        private int? space = null;
        private int? spaceBetweenTextFieldAndButton = null;

        public InputFieldAttributes() : base() { }

        public InputFieldAttributes(InputFieldAttributes attrs) : base(attrs)
        {
            if (attrs.bgImageViewAttrs != null)
            {
                bgImageViewAttrs = attrs.bgImageViewAttrs.Clone() as ImageAttributes;
            }
            if (attrs.textFieldViewAttrs != null)
            {
                textFieldViewAttrs = attrs.textFieldViewAttrs.Clone() as TextFieldAttributes;
            }
            if (attrs.cancelBtnAttrs != null)
            {
                cancelBtnAttrs = attrs.cancelBtnAttrs.Clone() as ImageAttributes;
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

        public static readonly BindableProperty BgImageViewAttributesProperty = 
            BindableProperty.Create("BgImageViewAttributes", typeof(ImageAttributes), typeof(InputFieldAttributes), default(ImageAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.bgImageViewAttrs = (ImageAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                return attrs.bgImageViewAttrs;
            });

        public static readonly BindableProperty TextFieldViewAttributesProperty =
            BindableProperty.Create("TextFieldViewAttributes", typeof(TextFieldAttributes), typeof(InputFieldAttributes), default(TextFieldAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.textFieldViewAttrs = (TextFieldAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                return attrs.textFieldViewAttrs;
            });

        public static readonly BindableProperty CancelBtnAttributesProperty =
            BindableProperty.Create("CancelBtnAttributes", typeof(ImageAttributes), typeof(InputFieldAttributes), default(ImageAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.cancelBtnAttrs = (ImageAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                return attrs.cancelBtnAttrs;
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

        public ImageAttributes BgImageViewAttributes
        {
            get { return (ImageAttributes)GetValue(BgImageViewAttributesProperty); }
            set { SetValue(BgImageViewAttributesProperty, value); }
        }

        public TextFieldAttributes TextFieldViewAttributes
        {
            get { return (TextFieldAttributes)GetValue(TextFieldViewAttributesProperty); }
            set { SetValue(TextFieldViewAttributesProperty, value); }
        }

        public ImageAttributes CancelBtnAttributes
        {
            get { return (ImageAttributes)GetValue(CancelBtnAttributesProperty); }
            set { SetValue(CancelBtnAttributesProperty, value); }
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
