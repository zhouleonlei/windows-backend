using Tizen.NUI.Binding;

namespace Tizen.NUI.CommonUI
{
    public class PickerAttributes : ViewAttributes
    {
        public static readonly BindableProperty ShadowImageAttributesProperty = BindableProperty.Create("ShadowImageAttributes", typeof(ImageAttributes), typeof(PickerAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.shadowImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PickerAttributes)bindable;
            return attrs.shadowImageAttrs;
        });

        public static readonly BindableProperty BackgroundImageAttributesProperty = BindableProperty.Create("BackgroundImageAttributes", typeof(ImageAttributes), typeof(PickerAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.backgroundImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PickerAttributes)bindable;
            return attrs.backgroundImageAttrs;
        });

        public static readonly BindableProperty FocusImageAttributesProperty = BindableProperty.Create("FocusImageAttributes", typeof(ImageAttributes), typeof(PickerAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.focusImageAttributes = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PickerAttributes)bindable;
            return attrs.focusImageAttributes;
        });

        public static readonly BindableProperty EndSelectedImageAttributesProperty = BindableProperty.Create("EndSelectedImageAttributes", typeof(ImageAttributes), typeof(PickerAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.endSelectedImageAttributes = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PickerAttributes)bindable;
            return attrs.endSelectedImageAttributes;
        });

        public static readonly BindableProperty DateViewAttributesProperty = BindableProperty.Create("DateViewAttributes", typeof(ViewAttributes), typeof(PickerAttributes), default(ViewAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.dateViewAttributes = (ViewAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PickerAttributes)bindable;
            return attrs.dateViewAttributes;
        });
        public static readonly BindableProperty MonTextAttributesProperty = BindableProperty.Create("MonTextAttributes", typeof(TextAttributes), typeof(PickerAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.monTextAttributes = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PickerAttributes)bindable;
            return attrs.monTextAttributes;
        });

        public static readonly BindableProperty TueTextAttributesProperty = BindableProperty.Create("TueTextAttributes", typeof(TextAttributes), typeof(PickerAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.tueTextAttributes = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PickerAttributes)bindable;
            return attrs.tueTextAttributes;
        });

        public static readonly BindableProperty SunTextAttributesProperty = BindableProperty.Create("SunTextAttributes", typeof(TextAttributes), typeof(PickerAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.sunTextAttributes = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PickerAttributes)bindable;
            return attrs.sunTextAttributes;
        });

        public static readonly BindableProperty WenTextAttributesProperty = BindableProperty.Create("WenTextAttributes", typeof(TextAttributes), typeof(PickerAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.wenTextAttributes = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PickerAttributes)bindable;
            return attrs.wenTextAttributes;
        });

        public static readonly BindableProperty ThuTextAttributesProperty = BindableProperty.Create("ThuTextAttributes", typeof(TextAttributes), typeof(PickerAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.thuTextAttributes = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PickerAttributes)bindable;
            return attrs.thuTextAttributes;
        });

        public static readonly BindableProperty FriTextAttributesProperty = BindableProperty.Create("FriTextAttributes", typeof(TextAttributes), typeof(PickerAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.friTextAttributes = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PickerAttributes)bindable;
            return attrs.friTextAttributes;
        });

        public static readonly BindableProperty SatTextAttributesProperty = BindableProperty.Create("SatTextAttributes", typeof(TextAttributes), typeof(PickerAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.satTextAttributes = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PickerAttributes)bindable;
            return attrs.satTextAttributes;
        });

        public static readonly BindableProperty DateTextAttributesProperty = BindableProperty.Create("DateTextAttributes", typeof(TextAttributes), typeof(PickerAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.dateTextAttributes = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PickerAttributes)bindable;
            return attrs.dateTextAttributes;
        });

        public static readonly BindableProperty DateText2AttributesProperty = BindableProperty.Create("DateText2Attributes", typeof(TextAttributes), typeof(PickerAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.dateText2Attributes = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PickerAttributes)bindable;
            return attrs.dateText2Attributes;
        });

        public static readonly BindableProperty LeftArrowImageAttributesProperty = BindableProperty.Create("LeftArrowImageAttributes", typeof(ImageAttributes), typeof(PickerAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.leftArrowImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PickerAttributes)bindable;
            return attrs.leftArrowImageAttrs;
        });

        public static readonly BindableProperty RightArrowImageAttributesProperty = BindableProperty.Create("RightArrowImageAttributes", typeof(ImageAttributes), typeof(PickerAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.rightArrowImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PickerAttributes)bindable;
            return attrs.rightArrowImageAttrs;
        });

        public static readonly BindableProperty MonthTextAttributesProperty = BindableProperty.Create("MonthTextAttributes", typeof(TextAttributes), typeof(PickerAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.monthTextAttributes = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PickerAttributes)bindable;
            return attrs.monthTextAttributes;
        });

        public static readonly BindableProperty YearDropDownAttributesProperty = BindableProperty.Create("YearDropDownAttributes", typeof(DropDownAttributes), typeof(PickerAttributes), default(DropDownAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.dropDownAttrs = (DropDownAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PickerAttributes)bindable;
            return attrs.dropDownAttrs;
        });

        public static readonly BindableProperty YearDropDownItemAttributesProperty = BindableProperty.Create("YearDropDownItemAttributes", typeof(DropDownItemAttributes), typeof(PickerAttributes), default(DropDownAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.dropDownItemAttrs = (DropDownItemAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PickerAttributes)bindable;
            return attrs.dropDownItemAttrs;
        });

        public static readonly BindableProperty YearRangeProperty = BindableProperty.Create("YearRange", typeof(Vector2), typeof(PickerAttributes), default(DropDownAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.yearRange = (Vector2)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PickerAttributes)bindable;
            return attrs.yearRange;
        });

        private ImageAttributes shadowImageAttrs;
        private ImageAttributes backgroundImageAttrs;
        private ImageAttributes focusImageAttributes;
        private ImageAttributes endSelectedImageAttributes;
        private ViewAttributes dateViewAttributes;
        private TextAttributes sunTextAttributes;
        private TextAttributes monTextAttributes;
        private TextAttributes tueTextAttributes;
        private TextAttributes wenTextAttributes;
        private TextAttributes thuTextAttributes;
        private TextAttributes friTextAttributes;
        private TextAttributes satTextAttributes;
        private TextAttributes dateTextAttributes;
        private TextAttributes dateText2Attributes;

        private ImageAttributes leftArrowImageAttrs;
        private ImageAttributes rightArrowImageAttrs;
        private TextAttributes monthTextAttributes;

        private DropDownAttributes dropDownAttrs;
        private DropDownItemAttributes dropDownItemAttrs;
        private Vector2 yearRange;

        public PickerAttributes() : base() { }
        public PickerAttributes(PickerAttributes attributes) : base(attributes)
        {
            if (attributes.shadowImageAttrs != null)
            {
                shadowImageAttrs = attributes.shadowImageAttrs.Clone() as ImageAttributes;
            }

            if (attributes.backgroundImageAttrs != null)
            {
                backgroundImageAttrs = attributes.backgroundImageAttrs.Clone() as ImageAttributes;
            }

            if (attributes.focusImageAttributes != null)
            {
                focusImageAttributes = attributes.focusImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.endSelectedImageAttributes != null)
            {
                endSelectedImageAttributes = attributes.endSelectedImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.sunTextAttributes != null)
            {
                sunTextAttributes = attributes.sunTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.dateViewAttributes != null)
            {
                dateViewAttributes = attributes.dateViewAttributes.Clone() as ViewAttributes;
            }

            if (attributes.monTextAttributes != null)
            {
                monTextAttributes = attributes.monTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.tueTextAttributes != null)
            {
                tueTextAttributes = attributes.tueTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.wenTextAttributes != null)
            {
                wenTextAttributes = attributes.wenTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.thuTextAttributes != null)
            {
                thuTextAttributes = attributes.thuTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.friTextAttributes != null)
            {
                friTextAttributes = attributes.friTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.satTextAttributes != null)
            {
                satTextAttributes = attributes.satTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.dateTextAttributes != null)
            {
                dateTextAttributes = attributes.dateTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.dateText2Attributes != null)
            {
                dateText2Attributes = attributes.dateText2Attributes.Clone() as TextAttributes;
            }

            if (attributes.leftArrowImageAttrs != null)
            {
                leftArrowImageAttrs = attributes.leftArrowImageAttrs.Clone() as ImageAttributes;
            }

            if (attributes.rightArrowImageAttrs != null)
            {
                rightArrowImageAttrs = attributes.rightArrowImageAttrs.Clone() as ImageAttributes;
            }

            if (attributes.monthTextAttributes != null)
            {
                monthTextAttributes = attributes.monthTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.dropDownAttrs != null)
            {
                dropDownAttrs = attributes.dropDownAttrs.Clone() as DropDownAttributes;
            }

            if (attributes.dropDownItemAttrs != null)
            {
                dropDownItemAttrs = attributes.dropDownItemAttrs.Clone() as DropDownItemAttributes;
            }

            yearRange = new Vector2(attributes.yearRange.X, attributes.yearRange.Y);

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

        public ImageAttributes FocusImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(FocusImageAttributesProperty);
            }
            set
            {
                SetValue(FocusImageAttributesProperty, value);
            }
        }

        public ImageAttributes EndSelectedImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(EndSelectedImageAttributesProperty);
            }
            set
            {
                SetValue(EndSelectedImageAttributesProperty, value);
            }
        }
        
        public ViewAttributes DateViewAttributes
        {
            get
            {
                return (ViewAttributes)GetValue(DateViewAttributesProperty);
            }
            set
            {
                SetValue(DateViewAttributesProperty, value);
            }
        }

        public TextAttributes SunTextAttributes
        {
            get
            {
                return (TextAttributes)GetValue(SunTextAttributesProperty);
            }
            set
            {
                SetValue(SunTextAttributesProperty, value);
            }
        }

        public TextAttributes MonTextAttributes
        {
            get
            {
                return (TextAttributes)GetValue(MonTextAttributesProperty);
            }
            set
            {
                SetValue(MonTextAttributesProperty, value);
            }
        }

        public TextAttributes TueTextAttributes
        {
            get
            {
                return (TextAttributes)GetValue(TueTextAttributesProperty);
            }
            set
            {
                SetValue(TueTextAttributesProperty, value);
            }
        }

        public TextAttributes WenTextAttributes
        {
            get
            {
                return (TextAttributes)GetValue(WenTextAttributesProperty);
            }
            set
            {
                SetValue(WenTextAttributesProperty, value);
            }
        }

        public TextAttributes ThuTextAttributes
        {
            get
            {
                return (TextAttributes)GetValue(ThuTextAttributesProperty);
            }
            set
            {
                SetValue(ThuTextAttributesProperty, value);
            }
        }

        public TextAttributes FriTextAttributes
        {
            get
            {
                return (TextAttributes)GetValue(FriTextAttributesProperty);
            }
            set
            {
                SetValue(FriTextAttributesProperty, value);
            }
        }

        public TextAttributes SatTextAttributes
        {
            get
            {
                return (TextAttributes)GetValue(SatTextAttributesProperty);
            }
            set
            {
                SetValue(SatTextAttributesProperty, value);
            }
        }

        public TextAttributes DateTextAttributes
        {
            get
            {
                return (TextAttributes)GetValue(DateTextAttributesProperty);
            }
            set
            {
                SetValue(DateTextAttributesProperty, value);
            }
        }

        public TextAttributes DateText2Attributes
        {
            get
            {
                return (TextAttributes)GetValue(DateText2AttributesProperty);
            }
            set
            {
                SetValue(DateText2AttributesProperty, value);
            }
        }

        public ImageAttributes LeftArrowImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(LeftArrowImageAttributesProperty);
            }
            set
            {
                SetValue(LeftArrowImageAttributesProperty, value);
            }
        }

        public ImageAttributes RightArrowImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(RightArrowImageAttributesProperty);
            }
            set
            {
                SetValue(RightArrowImageAttributesProperty, value);
            }
        }

        public TextAttributes MonthTextAttributes
        {
            get
            {
                return (TextAttributes)GetValue(MonthTextAttributesProperty);
            }
            set
            {
                SetValue(MonthTextAttributesProperty, value);
            }
        }

        public DropDownAttributes YearDropDownAttributes
        {
            get
            {
                return (DropDownAttributes)GetValue(YearDropDownAttributesProperty);
            }
            set
            {
                SetValue(YearDropDownAttributesProperty, value);
            }
        }

        public DropDownItemAttributes YearDropDownItemAttributes
        {
            get
            {
                return (DropDownItemAttributes)GetValue(YearDropDownItemAttributesProperty);
            }
            set
            {
                SetValue(YearDropDownItemAttributesProperty, value);
            }
        }

        public Vector2 YearRange
        {
            get
            {
                return (Vector2)GetValue(YearRangeProperty);
            }
            set
            {
                SetValue(YearRangeProperty, value);
            }
        }
        public override Attributes Clone()
        {
            return new PickerAttributes(this);
        }
    }
}
