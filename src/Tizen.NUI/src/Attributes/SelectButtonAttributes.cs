using Tizen.NUI.Binding;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.NUI.res.SelectButtonDefaultAttributes.xaml", "SelectButtonDefaultAttributes.xaml", typeof(Tizen.NUI.Controls.SelectButtonAttributes))]
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

        public static new readonly BindableProperty StateProperty = BindableProperty.Create("State", typeof(States), typeof(SelectButtonAttributes), States.Normal, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SelectButtonAttributes)bindable;
            if (newValue != null)
            {
                attrs.state = (States)newValue;
                if (attrs.checkShadowImageAttrs != null)
                {
                    attrs.checkShadowImageAttrs.State = attrs.state;
                }
                if (attrs.checkBackgroundImageAttrs != null)
                {
                    attrs.checkBackgroundImageAttrs.State = attrs.state;
                }
                if (attrs.checkImageAttrs != null)
                {
                    attrs.checkImageAttrs.State = attrs.state;
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SelectButtonAttributes)bindable;
            return attrs.state;
        });

        private ImageAttributes checkImageAttrs;
        private ImageAttributes checkBackgroundImageAttrs;
        private ImageAttributes checkShadowImageAttrs;

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

        public override States State
        {
            get
            {
                return (States)GetValue(StateProperty);
            }
            set
            {             
                SetValue(StateProperty, value);
                base.State = value;
            }
        }
    }
}
