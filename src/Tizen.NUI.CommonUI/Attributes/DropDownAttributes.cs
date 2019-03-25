using Tizen.NUI.Binding;

namespace Tizen.NUI.CommonUI
{
    public class DropDownAttributes : ViewAttributes
    {
        public static readonly BindableProperty ButtonAttributesProperty = BindableProperty.Create("ButtonAttributes", typeof(ButtonAttributes), typeof(DropDownAttributes), default(ButtonAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (DropDownAttributes)bindable;
            if (newValue != null)
            {
                attrs.buttonAttributes = (ButtonAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (DropDownAttributes)bindable;
            return attrs.buttonAttributes;
        });

        public static readonly BindableProperty HeaderTextAttributesProperty = BindableProperty.Create("HeaderTextAttributes", typeof(TextAttributes), typeof(DropDownAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (DropDownAttributes)bindable;
            if (newValue != null)
            {
                attrs.headerTextAttributes = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (DropDownAttributes)bindable;
            return attrs.headerTextAttributes;
        });

        public static readonly BindableProperty SpaceBetweenButtonTextAndIconProperty = BindableProperty.Create("SpaceBetweenButtonTextAndIcon", typeof(int), typeof(DropDownAttributes), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (DropDownAttributes)bindable;
            if (newValue != null)
            {
                attrs.spaceBetweenButtonTextAndIcon = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (DropDownAttributes)bindable;
            return attrs.spaceBetweenButtonTextAndIcon;
        });

        public static readonly BindableProperty ListBackgroundImageAttributesProperty = BindableProperty.Create("ListBackgroundImageAttributes", typeof(ImageAttributes), typeof(DropDownAttributes), default(ImageAttributes), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var attrs = (DropDownAttributes)bindable;
            if (newValue != null)
            {
                attrs.listBackgroundAttributes = (ImageAttributes)newValue;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var attrs = (DropDownAttributes)bindable;
            return (object)attrs.listBackgroundAttributes;
        }));
		
		public static readonly BindableProperty SpaceProperty = BindableProperty.Create("Space", typeof(Vector4), typeof(DropDownAttributes), default(Vector4), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var attrs = (DropDownAttributes)bindable;
            if (newValue != null)
            {
                attrs.space = (Vector4)newValue;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var attrs = (DropDownAttributes)bindable;
            return (object)attrs.space;
        }));

        public static readonly BindableProperty ListRelativeOrientationProperty = BindableProperty.Create("ListRelativeOrientation", typeof(DropDown.ListOrientation), typeof(DropDownAttributes), default(DropDown.ListOrientation), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var attrs = (DropDownAttributes)bindable;
            if (newValue != null)
            {
                attrs.listOrientation = (DropDown.ListOrientation)newValue;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var attrs = (DropDownAttributes)bindable;
            return (object)attrs.listOrientation;
        }));

        public static readonly BindableProperty ListMarginProperty = BindableProperty.Create("ListMargin", typeof(Vector4), typeof(DropDownAttributes), default(Vector4), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var attrs = (DropDownAttributes)bindable;
            if (newValue != null)
            {
                attrs.listMargin = (Vector4)newValue;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var attrs = (DropDownAttributes)bindable;
            return (object)attrs.listMargin;
        }));

        public static readonly BindableProperty ListSize2DProperty = BindableProperty.Create("ListSize2D", typeof(Size2D), typeof(DropDownAttributes), default(Size2D), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var attrs = (DropDownAttributes)bindable;
            if (newValue != null)
            {
                attrs.listSize2D = (Size2D)newValue;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var attrs = (DropDownAttributes)bindable;
            return (object)attrs.listSize2D;
        }));

        public static readonly BindableProperty FocusedItemIndexProperty = BindableProperty.Create("FocusedItemIndex", typeof(int), typeof(DropDownAttributes), default(int), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var attrs = (DropDownAttributes)bindable;
            if (newValue != null)
            {
                attrs.focusItemIndex = (int)newValue;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var attrs = (DropDownAttributes)bindable;
            return (object)attrs.focusItemIndex;
        }));

        public static readonly BindableProperty ListPaddingProperty = BindableProperty.Create("ListPadding", typeof(Extents), typeof(DropDownAttributes), default(Extents), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var attrs = (DropDownAttributes)bindable;
            if (newValue != null)
            {
                attrs.listPadding = (Extents)newValue;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var attrs = (DropDownAttributes)bindable;
            return (object)attrs.listPadding;
        }));

        private ButtonAttributes buttonAttributes = null;
        private TextAttributes headerTextAttributes = null;
        private ImageAttributes listBackgroundAttributes = null;
        private int spaceBetweenButtonTextAndIcon = 0;
        private Vector4 space = new Vector4(0, 0, 0, 0);
        private DropDown.ListOrientation listOrientation = DropDown.ListOrientation.Left;
        private Vector4 listMargin = new Vector4(0, 0, 0, 0);
        private int focusItemIndex = 0;
        private Size2D listSize2D = null;
        private Extents listPadding = null;

        public DropDownAttributes() : base() { }
        public DropDownAttributes(DropDownAttributes attributes) : base(attributes)
        {
            if (attributes.buttonAttributes != null)
            {
                buttonAttributes = attributes.buttonAttributes.Clone() as ButtonAttributes;
            }

            if (attributes.headerTextAttributes != null)
            {
                headerTextAttributes = attributes.headerTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.listBackgroundAttributes != null)
            {
                listBackgroundAttributes = attributes.listBackgroundAttributes.Clone() as ImageAttributes;
            }

            if (attributes.space != null)
            {
                space = new Vector4(attributes.space.X, attributes.space.Y, attributes.space.Z, attributes.space.W);
            }

            if (attributes.listMargin != null)
            {
                listMargin = new Vector4(attributes.listMargin.X, attributes.listMargin.Y, attributes.listMargin.Z, attributes.listMargin.W);
            }

            if (attributes.listSize2D != null)
            {
                listSize2D = new Size2D(attributes.listSize2D.Width, attributes.listSize2D.Height);
            }

            if (attributes.listPadding != null)
            {
                listPadding = attributes.listPadding;
            }

            spaceBetweenButtonTextAndIcon = attributes.spaceBetweenButtonTextAndIcon;
            listOrientation = attributes.listOrientation;
            focusItemIndex = attributes.focusItemIndex;
        }

        public ButtonAttributes ButtonAttributes
        {
            get
            {
                return (ButtonAttributes)GetValue(ButtonAttributesProperty);
            }
            set
            {
                SetValue(ButtonAttributesProperty, value);
            }
        }

        public TextAttributes HeaderTextAttributes
        {
            get
            {
                return (TextAttributes)GetValue(HeaderTextAttributesProperty);
            }
            set
            {
                SetValue(HeaderTextAttributesProperty, value);
            }
        }

        public int SpaceBetweenButtonTextAndIcon
        {
            get
            {
                return (int)GetValue(SpaceBetweenButtonTextAndIconProperty);
            }
            set
            {
                SetValue(SpaceBetweenButtonTextAndIconProperty, value);
            }
        }

        public ImageAttributes ListBackgroundImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(ListBackgroundImageAttributesProperty);
            }
            set
            {
                SetValue(ListBackgroundImageAttributesProperty, value);
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

        public DropDown.ListOrientation ListRelativeOrientation
        {
            get
            {
                return (DropDown.ListOrientation)GetValue(ListRelativeOrientationProperty);
            }
            set
            {
                SetValue(ListRelativeOrientationProperty, value);
            }
        }

        public Vector4 ListMargin
        {
            get
            {
                return (Vector4)GetValue(ListMarginProperty);
            }
            set
            {
                SetValue(ListMarginProperty, value);
            }
        }

        public int FocusedItemIndex
        {
            get
            {
                return (int)GetValue(FocusedItemIndexProperty);
            }
            set
            {
                SetValue(FocusedItemIndexProperty, value);
            }
        }

        public Size2D ListSize2D
        {
            get
            {
                return (Size2D)GetValue(ListSize2DProperty);
            }
            set
            {
                SetValue(ListSize2DProperty, value);
            }
        }

        public Extents ListPadding
        {
            get
            {
                return (Extents)GetValue(ListPaddingProperty);
            }
            set
            {
                SetValue(ListPaddingProperty, value);
            }
        }

        public override Attributes Clone()
        {
            return new DropDownAttributes(this);
        }
    }

    public class DropDownItemAttributes : ViewAttributes
    {
        public static readonly BindableProperty TextAttributesProperty = BindableProperty.Create("TextAttributes", typeof(TextAttributes), typeof(DropDownItemAttributes), default(TextAttributes), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var attrs = (DropDownItemAttributes)bindable;
            if (newValue != null)
            {
                attrs.textAttributes = (TextAttributes)newValue;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var attrs = (DropDownItemAttributes)bindable;
            return (object)attrs.textAttributes;
        }));

        public static readonly BindableProperty IconAttributesProperty = BindableProperty.Create("IconAttributes", typeof(ImageAttributes), typeof(DropDownItemAttributes), default(ImageAttributes), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var attrs = (DropDownItemAttributes)bindable;
            if (newValue != null)
            {
                attrs.iconAttributes = (ImageAttributes)newValue;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var attrs = (DropDownItemAttributes)bindable;
            return (object)attrs.iconAttributes;
        }));

        public static readonly BindableProperty CheckImageAttributesProperty = BindableProperty.Create("CheckImageAttributes", typeof(ImageAttributes), typeof(DropDownItemAttributes), default(ImageAttributes), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var attrs = (DropDownItemAttributes)bindable;
            if (newValue != null)
            {
                attrs.checkImageAttributes = (ImageAttributes)newValue;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var attrs = (DropDownItemAttributes)bindable;
            return (object)attrs.checkImageAttributes;
        }));

        public static readonly BindableProperty CheckImageRightSpaceProperty = BindableProperty.Create("CheckImageRightSpace", typeof(int), typeof(DropDownItemAttributes), default(int), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var attrs = (DropDownItemAttributes)bindable;
            if (newValue != null)
            {
                attrs.checkImageRightSpace = (int)newValue;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var attrs = (DropDownItemAttributes)bindable;
            return (object)attrs.checkImageRightSpace;
        }));

        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create("IsSelected", typeof(bool), typeof(DropDownItemAttributes), default(bool), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var attrs = (DropDownItemAttributes)bindable;
            if (newValue != null)
            {
                attrs.isSelected = (bool)newValue;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var attrs = (DropDownItemAttributes)bindable;
            return (object)attrs.isSelected;
        }));

        private TextAttributes textAttributes = null;
        private ImageAttributes iconAttributes = null;
        private ImageAttributes checkImageAttributes = null;
        private int checkImageRightSpace = 0;
        private bool isSelected = false;

        public DropDownItemAttributes() : base() { }
        public DropDownItemAttributes(DropDownItemAttributes attributes) : base(attributes)
        {
            if (attributes.textAttributes != null)
            {
                textAttributes = attributes.textAttributes.Clone() as TextAttributes;
            }

            if (attributes.iconAttributes != null)
            {
                iconAttributes = attributes.iconAttributes.Clone() as ImageAttributes;
            }

            if (attributes.checkImageAttributes != null)
            {
                checkImageAttributes = attributes.checkImageAttributes.Clone() as ImageAttributes;
            }

            checkImageRightSpace = attributes.checkImageRightSpace;
            isSelected = attributes.isSelected;
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

        public int CheckImageRightSpace
        {
            get
            {
                return (int)GetValue(CheckImageRightSpaceProperty);
            }
            set
            {
                SetValue(CheckImageRightSpaceProperty, value);
            }
        }

        public bool IsSelected
        {
            get
            {
                return (bool)GetValue(IsSelectedProperty);
            }
            set
            {
                SetValue(IsSelectedProperty, value);
            }
        }

        public override Attributes Clone()
        {
            return new DropDownItemAttributes(this);
        }
    }
}
