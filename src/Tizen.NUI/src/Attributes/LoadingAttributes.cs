using Tizen.NUI.Binding;

namespace Tizen.NUI.Controls
{
    public class LoadingAttributes : ViewAttributes
    {
        public static readonly BindableProperty LoadingImageURLPrefixProperty = BindableProperty.Create("LoadingImageURLPrefix", typeof(StringSelector), typeof(LoadingAttributes), default(StringSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (LoadingAttributes)bindable;
            if (newValue != null)
            {
                attrs.loadingImageURLPrefix = (StringSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (LoadingAttributes)bindable;
            return attrs.loadingImageURLPrefix;
        });

        public static readonly BindableProperty FPSProperty = BindableProperty.Create("FPS", typeof(IntSelector), typeof(LoadingAttributes), default(IntSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (LoadingAttributes)bindable;
            if (newValue != null)
            {
                attrs.fps = (IntSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (LoadingAttributes)bindable;
            return attrs.fps;
        });

        public static readonly BindableProperty LoadingImageAttributesProperty = BindableProperty.Create("LoadingImageAttributes", typeof(ImageAttributes), typeof(LoadingAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (LoadingAttributes)bindable;
            if (newValue != null)
            {
                attrs.loadingImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (LoadingAttributes)bindable;
            return attrs.loadingImageAttrs;
        });

        private StringSelector loadingImageURLPrefix;
        private IntSelector fps;
        private ImageAttributes loadingImageAttrs;

        public LoadingAttributes() : base() { }

        public LoadingAttributes(LoadingAttributes attributes) : base(attributes)
        {

            if (attributes.loadingImageURLPrefix != null)
            {
                loadingImageURLPrefix = attributes.loadingImageURLPrefix.Clone() as StringSelector;
            }
            if (attributes.fps != null)
            {
                fps = attributes.fps.Clone() as IntSelector;
            }
            if (attributes.loadingImageAttrs != null)
            {
                loadingImageAttrs = attributes.loadingImageAttrs.Clone() as ImageAttributes;
            }
        }

        public StringSelector LoadingImageURLPrefix
        {
            get
            {
                return (StringSelector)GetValue(LoadingImageURLPrefixProperty);
            }
            set
            {
                SetValue(LoadingImageURLPrefixProperty, value);
            }
        }

        public IntSelector FPS
        {
            get
            {
                return (IntSelector)GetValue(FPSProperty);
            }
            set
            {
                SetValue(FPSProperty, value);
            }
        }

        public ImageAttributes LoadingImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(LoadingImageAttributesProperty);
            }
            set
            {
                SetValue(LoadingImageAttributesProperty, value);
            }
        }

        public override Attributes Clone()
        {
            return new LoadingAttributes(this);
        }

    }
}
