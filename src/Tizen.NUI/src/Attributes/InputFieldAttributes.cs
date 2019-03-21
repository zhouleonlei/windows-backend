using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Controls
{
    public class InputFieldAttributes : ViewAttributes
    {
        private ImageAttributes bgImageAttrs = null;
        private TextFieldAttributes inputBoxAttrs = null;
        private int? space = null;

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
            if (attrs.space != null)
            {
                space = attrs.space;
            }
        }

        public static readonly BindableProperty BackgroundImageAttributesProperty = 
            BindableProperty.Create("BackgroundImageAttributes", typeof(ImageAttributes), typeof(InputFieldAttributes), default(ImageAttributes),
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

        public ImageAttributes BackgroundImageAttributes
        {
            get { return (ImageAttributes)GetValue(BackgroundImageAttributesProperty); }
            set { SetValue(BackgroundImageAttributesProperty, value); }
        }

        public TextFieldAttributes InputBoxAttributes
        {
            get { return (TextFieldAttributes)GetValue(InputBoxAttributesProperty); }
            set { SetValue(InputBoxAttributesProperty, value); }
        }

        public int? Space
        {
            get { return (int?)GetValue(SpaceProperty); }
            set { SetValue(SpaceProperty, value); }
        }

        public override Attributes Clone()
        {
            return new InputFieldAttributes(this);
        }
    }
}
