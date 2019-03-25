using Tizen.NUI.Binding;

namespace Tizen.NUI.CommonUI
{
    public class ImageAttributes : ViewAttributes
    {
        public static readonly BindableProperty ResourceURLProperty = BindableProperty.Create("ResourceURL", typeof(StringSelector), typeof(ImageAttributes), default(StringSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ImageAttributes)bindable;
            if (newValue != null)
            {
                attrs.resourceURL = (StringSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ImageAttributes)bindable;
            return attrs.resourceURL;
        });

        public static readonly BindableProperty BorderProperty = BindableProperty.Create("Border", typeof(RectangleSelector), typeof(ImageAttributes), default(RectangleSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ImageAttributes)bindable;
            if (newValue != null)
            {
                attrs.border = (RectangleSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ImageAttributes)bindable;
            return attrs.border;
        });

        private StringSelector resourceURL;
        private RectangleSelector border;

        public ImageAttributes() : base() { }
        public ImageAttributes(ImageAttributes attributes) : base(attributes)
        {
            if (attributes.resourceURL != null)
            {
                resourceURL = attributes.resourceURL.Clone() as StringSelector;
            }

            if (attributes.border != null)
            {
                border = attributes.border.Clone() as RectangleSelector;
            }
        }

        public StringSelector ResourceURL
        {
            get
            {
                return (StringSelector)GetValue(ResourceURLProperty);
            }
            set
            {
                SetValue(ResourceURLProperty, value);
            }
        }

        public RectangleSelector Border
        {
            get
            {
                return (RectangleSelector)GetValue(BorderProperty);
            }
            set
            {
                SetValue(BorderProperty, value);
            }
        }

        public override Attributes Clone()
        {
            return new ImageAttributes(this); ;
        }

    }
}
