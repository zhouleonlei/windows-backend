using Tizen.NUI.Controls;
using Tizen.NUI.Binding;

namespace Tizen.FH.NUI.Controls
{
    internal class ToastAttributes : Tizen.NUI.Controls.ToastAttributes
    {
        private ImageAttributes iconAttrs;

        public ToastAttributes() : base() { }
        public ToastAttributes(ToastAttributes attributes) : base(attributes)
        {
            if(attributes.IconAttributes != null)
            {
                iconAttrs = attributes.iconAttrs.Clone() as ImageAttributes;
            }
        }

        public static readonly BindableProperty IconAttributesProperty = BindableProperty.Create("IconAttributes", typeof(ImageAttributes), typeof(ToastAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ToastAttributes)bindable;
            if (newValue != null)
            {
                attrs.iconAttrs = (ImageAttributes)newValue;
            }
        },
       defaultValueCreator: (bindable) =>
       {
           var attrs = (ToastAttributes)bindable;
           return attrs.iconAttrs;
       });

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

        public override Attributes Clone()
        {
            return new ToastAttributes(this);
        }
    }
}
