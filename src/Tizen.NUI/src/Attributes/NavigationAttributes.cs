using Tizen.NUI.Binding;

namespace Tizen.NUI.Controls
{
    public class NavigationAttributes : ViewAttributes
    {
        public static readonly BindableProperty ShadowImageAttributesProperty = BindableProperty.Create("ShadowImageAttributes", typeof(ImageAttributes), typeof(NavigationAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (NavigationAttributes)bindable;
            if (newValue != null)
            {
                attrs.shadowImageAttributes = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (NavigationAttributes)bindable;
            return attrs.shadowImageAttributes;
        });

        public static readonly BindableProperty BackgroundImageAttributesProperty = BindableProperty.Create("BackgroundImageAttributes", typeof(ImageAttributes), typeof(NavigationAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (NavigationAttributes)bindable;
            if (newValue != null)
            {
                attrs.backgroundImageAttributes = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (NavigationAttributes)bindable;
            return attrs.backgroundImageAttributes;
        });

        public static readonly BindableProperty DividerLineColorProperty = BindableProperty.Create("DividerLineAttributes", typeof(Color), typeof(NavigationAttributes), default(Color), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var attrs = (NavigationAttributes)bindable;
            if (newValue != null)
            {
                attrs.dividerLineColor = (Color)newValue;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var attrs = (NavigationAttributes)bindable;
            return (object)attrs.dividerLineColor;
        }));

        public static readonly BindableProperty ItemGapProperty = BindableProperty.Create("ItemGap", typeof(int), typeof(NavigationAttributes), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (NavigationAttributes)bindable;
            if (newValue != null)
            {
                attrs.itemGap = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (NavigationAttributes)bindable;
            return attrs.itemGap;
        });

        public static readonly BindableProperty SpaceProperty = BindableProperty.Create("Space", typeof(Vector4), typeof(NavigationAttributes), default(Vector4), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var attrs = (NavigationAttributes)bindable;
            if (newValue != null)
            {
                attrs.space = (Vector4)newValue;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var attrs = (NavigationAttributes)bindable;
            return (object)attrs.space;
        }));


        public static readonly BindableProperty IsFitWithItemsProperty = BindableProperty.Create("IsFitWithItems", typeof(bool), typeof(NavigationAttributes), default(bool), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var attrs = (NavigationAttributes)bindable;
            if (newValue != null)
            {
                attrs.isFitWithItems = (bool)newValue;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var attrs = (NavigationAttributes)bindable;
            return (object)attrs.isFitWithItems;
        }));

        private ImageAttributes shadowImageAttributes;
        private ImageAttributes backgroundImageAttributes;
        private Color dividerLineColor = new Color(0, 0, 0, 0.1f);
        private int itemGap = 0;
        private Vector4 space = new Vector4(0, 0, 0, 0);
        private bool isFitWithItems = false;

        public NavigationAttributes() : base() { }
        public NavigationAttributes(NavigationAttributes attributes) : base(attributes)
        {
            if (attributes.shadowImageAttributes != null)
            {
                shadowImageAttributes = attributes.shadowImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.backgroundImageAttributes != null)
            {
                backgroundImageAttributes = attributes.backgroundImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.dividerLineColor != null)
            {
                dividerLineColor = new Color(attributes.dividerLineColor.R, attributes.dividerLineColor.G, attributes.dividerLineColor.B, attributes.dividerLineColor.A);
            }

            if (attributes.space != null)
            {
                space = new Vector4(attributes.space.X, attributes.space.Y, attributes.space.Z, attributes.space.W);
            }

            itemGap = attributes.itemGap;
            isFitWithItems = attributes.isFitWithItems;
        }

        public ImageAttributes ShadowImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(ShadowImageAttributesProperty);
            }
            set
            {
                SetValue(ShadowImageAttributesProperty, value);
            }
        }

        public ImageAttributes BackgroundImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(BackgroundImageAttributesProperty);
            }
            set
            {
                SetValue(BackgroundImageAttributesProperty, value);
            }
        }

        public Color DividerLineColor
        {
            get
            {
                return (Color)GetValue(DividerLineColorProperty);
            }
            set
            {
                SetValue(DividerLineColorProperty, value);
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

        public bool IsFitWithItems
        {
            get
            {
                return (bool)GetValue(IsFitWithItemsProperty);
            }
            set
            {
                SetValue(IsFitWithItemsProperty, value);
            }
        }

        public override Attributes Clone()
        {
            return new NavigationAttributes(this);
        }
    }

    public class NavigationItemAttributes : ButtonAttributes
    {
        public static readonly BindableProperty SubTextAttributesProperty = BindableProperty.Create("SubTextAttributes", typeof(TextAttributes), typeof(NavigationItemAttributes), default(TextAttributes), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var attrs = (NavigationItemAttributes)bindable;
            if (newValue != null)
            {
                attrs.subTextAttributes = (TextAttributes)newValue;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var attrs = (NavigationItemAttributes)bindable;
            return (object)attrs.subTextAttributes;
        }));

        public static readonly BindableProperty DividerLineAttributesProperty = BindableProperty.Create("DividerLineAttributes", typeof(ViewAttributes), typeof(NavigationItemAttributes), default(ViewAttributes), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var attrs = (NavigationItemAttributes)bindable;
            if (newValue != null)
            {
                attrs.dividerAttributes = (ViewAttributes)newValue;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var attrs = (NavigationItemAttributes)bindable;
            return (object)attrs.dividerAttributes;
        }));

        public static readonly BindableProperty SpaceProperty = BindableProperty.Create("Space", typeof(Vector4), typeof(NavigationItemAttributes), default(Vector4), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var attrs = (NavigationItemAttributes)bindable;
            if (newValue != null)
            {
                attrs.space = (Vector4)newValue;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var attrs = (NavigationItemAttributes)bindable;
            return (object)attrs.space;
        }));

        public static readonly BindableProperty EnableIconCenterProperty = BindableProperty.Create("EnableIconCenter", typeof(bool), typeof(NavigationItemAttributes), default(bool), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var attrs = (NavigationItemAttributes)bindable;
            if (newValue != null)
            {
                attrs.enableIconCenter = (bool)newValue;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var attrs = (NavigationItemAttributes)bindable;
            return (object)attrs.enableIconCenter;
        }));

        private TextAttributes subTextAttributes;
        private ViewAttributes dividerAttributes;
        private Vector4 space = new Vector4(0, 0, 0, 0);
        private bool enableIconCenter = false;

        public NavigationItemAttributes() : base() { }
        public NavigationItemAttributes(NavigationItemAttributes attributes) : base(attributes)
        {
            if (attributes.subTextAttributes != null)
            {
                subTextAttributes = attributes.subTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.dividerAttributes != null)
            {
                dividerAttributes = attributes.dividerAttributes.Clone() as ViewAttributes;
            }

            if (attributes.space != null)
            {
                space = new Vector4(attributes.space.X, attributes.space.Y, attributes.space.Z, attributes.space.W);
            }

            enableIconCenter = attributes.enableIconCenter;
        }

        public TextAttributes SubTextAttributes
        {
            get
            {
                return (TextAttributes)GetValue(SubTextAttributesProperty);
            }
            set
            {
                SetValue(SubTextAttributesProperty, value);
            }
        }

        public ViewAttributes DividerLineAttributes
        {
            get
            {
                return (ViewAttributes)GetValue(DividerLineAttributesProperty);
            }
            set
            {
                SetValue(DividerLineAttributesProperty, value);
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

        public bool EnableIconCenter
        {
            get
            {
                return (bool)GetValue(EnableIconCenterProperty);
            }
            set
            {
                SetValue(EnableIconCenterProperty, value);
            }
        }

        public override Attributes Clone()
        {
            return new NavigationItemAttributes(this);
        }
    }
}
