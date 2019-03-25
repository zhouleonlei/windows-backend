using Tizen.NUI.CommonUI;
using Tizen.NUI.Binding;

namespace Tizen.FH.NUI.Controls
{
    internal class ToastAttributes : Tizen.NUI.CommonUI.ToastAttributes
    {
        private LoadingAttributes loadingAttrs;

        public ToastAttributes() : base() { }
        public ToastAttributes(ToastAttributes attributes) : base(attributes)
        {
            if(attributes.LoadingAttributes != null)
            {
                loadingAttrs = attributes.loadingAttrs.Clone() as LoadingAttributes;
            }
        }

        public static readonly BindableProperty LoadingAttributesProperty = BindableProperty.Create("LoadingAttributes", typeof(LoadingAttributes), typeof(ToastAttributes), default(LoadingAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ToastAttributes)bindable;
            if (newValue != null)
            {
                attrs.loadingAttrs = (LoadingAttributes)newValue;
            }
        },
       defaultValueCreator: (bindable) =>
       {
           var attrs = (ToastAttributes)bindable;
           return attrs.loadingAttrs;
       });

        public LoadingAttributes LoadingAttributes
        {
            get
            {
                return (LoadingAttributes)GetValue(LoadingAttributesProperty);
            }
            set
            {
                SetValue(LoadingAttributesProperty, value);
            }
        }

        public override Attributes Clone()
        {
            return new ToastAttributes(this);
        }
    }
}
