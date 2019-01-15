using Tizen.NUI.Binding;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.NUI.res.SwitchDefaultAttributes.xaml", "SwitchDefaultAttributes.xaml", typeof(Tizen.NUI.Controls.SwitchAttributes))]
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

        public static new readonly BindableProperty StateProperty = BindableProperty.Create("State", typeof(States), typeof(SelectButtonAttributes), States.Normal, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SwitchAttributes)bindable;
            if (newValue != null)
            {
                attrs.state = (States)newValue;
                if (attrs.switchHandlerImageAttrs != null)
                {
                    attrs.switchHandlerImageAttrs.State = attrs.state;
                }
                if (attrs.switchBackgroundImageAttrs != null)
                {
                    attrs.switchBackgroundImageAttrs.State = attrs.state;
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SwitchAttributes)bindable;
            return attrs.state;
        });

        private ImageAttributes switchHandlerImageAttrs;
        private ImageAttributes switchBackgroundImageAttrs;

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
