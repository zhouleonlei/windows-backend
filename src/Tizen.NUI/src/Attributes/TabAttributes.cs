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

        public static readonly BindableProperty ItemGapProperty = BindableProperty.Create("ItemGap", typeof(int), typeof(TabAttributes), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TabAttributes)bindable;
            if (newValue != null)
            {
                attrs.itemGap = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TabAttributes)bindable;
            return attrs.itemGap;
        });

        public static readonly BindableProperty SpaceProperty = BindableProperty.Create("Space", typeof(Vector4), typeof(TabAttributes), default(Vector4), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var attrs = (TabAttributes)bindable;
            if (newValue != null)
            {
                attrs.space = (Vector4)newValue;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var attrs = (TabAttributes)bindable;
            return (object)attrs.space;
        }));

        private TextAttributes textAttributes;
        private ViewAttributes underLineAttributes;
        private bool isNatureTextWidth = false;
        private int itemGap = 0;
        private Vector4 space = new Vector4(0, 0, 0, 0);

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

            if (attributes.space != null)
            {
                space = new Vector4(attributes.space.X, attributes.space.Y, attributes.space.Z, attributes.space.W);
            }
            itemGap = attributes.itemGap;
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

        public int ItemGap
        {
            get
            {
                return (int)GetValue(ItemGapProperty);
            }
            set
            {
                SetValue(ItemGapProperty, value);
            }
        }

        public Vector4 Space
        {
            get
            {
                return (Vector4)GetValue(SpaceProperty);
            }
            set
            {
                SetValue(SpaceProperty, value);
            }
        }

        public override Attributes Clone()
        {
            return new TabAttributes(this);
        }
    }
}
