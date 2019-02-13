using Tizen.NUI.Binding;

namespace Tizen.NUI.Controls
{
    public class TabAttributes : ViewAttributes
    {
        public static readonly BindableProperty UnderLineAttributesProperty = BindableProperty.Create("UnderLineAttributes", typeof(ViewAttributes), typeof(TabAttributes), default(ViewAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TabAttributes)bindable;
            if (newValue != null)
            {
                attrs.underLineAttributes = (ViewAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TabAttributes)bindable;
            return attrs.underLineAttributes;
        });

        public static readonly BindableProperty TextAttributesProperty = BindableProperty.Create("TextAttributes", typeof(TextAttributes), typeof(TabAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TabAttributes)bindable;
            if (newValue != null)
            {
                attrs.textAttributes = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TabAttributes)bindable;
            return attrs.textAttributes;
        });

        public static readonly BindableProperty IsNatureTextWidthProperty = BindableProperty.Create("IsNatureTextWidth", typeof(bool), typeof(TabAttributes), default(bool), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TabAttributes)bindable;
            if (newValue != null)
            {
                attrs.isNatureTextWidth = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TabAttributes)bindable;
            return attrs.isNatureTextWidth;
        });

        private TextAttributes textAttributes;
        private ViewAttributes underLineAttributes;
        private bool isNatureTextWidth = false;

        public TabAttributes() : base() { }
        public TabAttributes(TabAttributes attributes) : base(attributes)
        {
            if (attributes.underLineAttributes != null)
            {
                underLineAttributes = attributes.underLineAttributes.Clone() as ViewAttributes;
            }

            if (attributes.textAttributes != null)
            {
                textAttributes = attributes.textAttributes.Clone() as TextAttributes;
            }

            isNatureTextWidth = attributes.isNatureTextWidth;
        }

        public ViewAttributes UnderLineAttributes
        {
            get
            {
                return (ViewAttributes)GetValue(UnderLineAttributesProperty);
            }
            set
            {
                SetValue(UnderLineAttributesProperty, value);
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

        public bool IsNatureTextWidth
        {
            get
            {
                return (bool)GetValue(IsNatureTextWidthProperty);
            }
            set
            {
                SetValue(IsNatureTextWidthProperty, value);
            }
        }

        public override Attributes Clone()
        {
            return new TabAttributes(this);
        }
    }
}
