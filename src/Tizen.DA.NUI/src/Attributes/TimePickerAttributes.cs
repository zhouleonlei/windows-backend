using Tizen.NUI.Binding;

namespace Tizen.NUI.CommonUI
{
    public class TimePickerAttributes : ViewAttributes
    {
        public static readonly BindableProperty ShadowImageAttributesProperty = BindableProperty.Create("ShadowImageAttributes", typeof(ImageAttributes), typeof(TimePickerAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.shadowImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            return attrs.shadowImageAttrs;
        });

        public static readonly BindableProperty BackgroundImageAttributesProperty = BindableProperty.Create("BackgroundImageAttributes", typeof(ImageAttributes), typeof(TimePickerAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.backgroundImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            return attrs.backgroundImageAttrs;
        });

        public static readonly BindableProperty TitleTextAttributesProperty = BindableProperty.Create("TitleTextAttributes", typeof(TextAttributes), typeof(TimePickerAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.titleTextAttributes = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            return attrs.titleTextAttributes;
        });

        public static readonly BindableProperty ShadowOffsetProperty = BindableProperty.Create("ShadowOffset", typeof(Vector4), typeof(TimePickerAttributes), default(Vector4), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.shadowOffset = (Vector4)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            return attrs.shadowOffset;
        });

        public static readonly BindableProperty HourSpinAttributesProperty = BindableProperty.Create("HourSpinAttributes", typeof(SpinAttributes), typeof(TimePickerAttributes), default(SpinAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.hourSpinAttributes = (SpinAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            return attrs.hourSpinAttributes;
        });

        public static readonly BindableProperty MinuteSpinAttributesProperty = BindableProperty.Create("MinuteSpinAttributes", typeof(SpinAttributes), typeof(TimePickerAttributes), default(SpinAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.minuteSpinAttributes = (SpinAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            return attrs.minuteSpinAttributes;
        });

        public static readonly BindableProperty SecondSpinAttributesProperty = BindableProperty.Create("SecondSpinAttributes", typeof(SpinAttributes), typeof(TimePickerAttributes), default(SpinAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.secondSpinAttributes = (SpinAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            return attrs.secondSpinAttributes;
        });

        public static readonly BindableProperty AMPMSpinAttributesProperty = BindableProperty.Create("AMPMSpinAttributes", typeof(SpinAttributes), typeof(TimePickerAttributes), default(SpinAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.aMPMSpinAttributes = (SpinAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            return attrs.aMPMSpinAttributes;
        });

        public static readonly BindableProperty ColonImageAttributesProperty = BindableProperty.Create("ColonImageAttributes", typeof(ImageAttributes), typeof(TimePickerAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.colonImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            return attrs.colonImageAttrs;
        });

        public static readonly BindableProperty WeekViewAttributesProperty = BindableProperty.Create("WeekViewAttributes", typeof(ViewAttributes), typeof(TimePickerAttributes), default(ViewAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.weekViewAttributes = (ViewAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            return attrs.weekViewAttributes;
        });

        public static readonly BindableProperty WeekSelectImageAttributesProperty  = BindableProperty.Create("WeekSelectImageAttributes", typeof(ImageAttributes), typeof(TimePickerAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.weekSelectImageAttributes = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            return attrs.weekSelectImageAttributes;
        });

        public static readonly BindableProperty WeekTextAttributesProperty = BindableProperty.Create("WeekTextAttributes", typeof(TextAttributes), typeof(TimePickerAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.weekTextAttributes = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            return attrs.weekTextAttributes;
        });

        public static readonly BindableProperty WeekTitleTextAttributesProperty = BindableProperty.Create("WeekTTitleTextAttributes", typeof(TextAttributes), typeof(TimePickerAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            if (newValue != null)
            {
                attrs.weekTitleTextAttributes = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TimePickerAttributes)bindable;
            return attrs.weekTitleTextAttributes;
        });
        
        private ImageAttributes shadowImageAttrs;
        private ImageAttributes backgroundImageAttrs;
        private TextAttributes titleTextAttributes;
        private Vector4 shadowOffset;
        private SpinAttributes hourSpinAttributes;
        private SpinAttributes minuteSpinAttributes;
        private SpinAttributes secondSpinAttributes;
        private SpinAttributes aMPMSpinAttributes;
        private ImageAttributes colonImageAttrs;

        private ViewAttributes weekViewAttributes;
        private TextAttributes weekTitleTextAttributes;
        private ImageAttributes weekSelectImageAttributes;
        private TextAttributes weekTextAttributes;

        public TimePickerAttributes() : base() { }
        public TimePickerAttributes(TimePickerAttributes attributes) : base(attributes)
        {
            if (attributes.shadowImageAttrs != null)
            {
                shadowImageAttrs = attributes.shadowImageAttrs.Clone() as ImageAttributes;
            }

            if (attributes.backgroundImageAttrs != null)
            {
                backgroundImageAttrs = attributes.backgroundImageAttrs.Clone() as ImageAttributes;
            }

            if (attributes.titleTextAttributes != null)
            {
                titleTextAttributes = attributes.titleTextAttributes.Clone() as TextAttributes;
            }
            
            shadowOffset = new Vector4(attributes.shadowOffset.W, attributes.shadowOffset.X, attributes.shadowOffset.Y, attributes.shadowOffset.Z);

            if (attributes.hourSpinAttributes != null)
            {
                hourSpinAttributes = attributes.hourSpinAttributes.Clone() as SpinAttributes;
            }

            if (attributes.minuteSpinAttributes != null)
            {
                minuteSpinAttributes = attributes.minuteSpinAttributes.Clone() as SpinAttributes;
            }

            if (attributes.secondSpinAttributes != null)
            {
                secondSpinAttributes = attributes.secondSpinAttributes.Clone() as SpinAttributes;
            }

            if (attributes.aMPMSpinAttributes != null)
            {
                aMPMSpinAttributes = attributes.aMPMSpinAttributes.Clone() as SpinAttributes;
            }

            if (attributes.colonImageAttrs != null)
            {
                colonImageAttrs = attributes.colonImageAttrs.Clone() as ImageAttributes;
            }

            if (attributes.weekViewAttributes != null)
            {
                weekViewAttributes = attributes.weekViewAttributes.Clone() as ViewAttributes;
            }

            if (attributes.weekTitleTextAttributes != null)
            {
                weekTitleTextAttributes = attributes.weekTitleTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.weekSelectImageAttributes != null)
            {
                weekSelectImageAttributes = attributes.weekSelectImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.weekTextAttributes != null)
            {
                weekTextAttributes = attributes.weekTextAttributes.Clone() as TextAttributes;
            }
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

        public TextAttributes TitleTextAttributes
        {
            get
            {
                return (TextAttributes)GetValue(TitleTextAttributesProperty);
            }
            set
            {
                SetValue(TitleTextAttributesProperty, value);
            }
        }
        
        public Vector4 ShadowOffset
        {
            get
            {
                return (Vector4)GetValue(ShadowOffsetProperty);
            }
            set
            {
                SetValue(ShadowOffsetProperty, value);
            }
        }

        public SpinAttributes HourSpinAttributes
        {
            get
            {
                return (SpinAttributes)GetValue(HourSpinAttributesProperty);
            }
            set
            {
                SetValue(HourSpinAttributesProperty, value);
            }
        }

        public SpinAttributes MinuteSpinAttributes
        {
            get
            {
                return (SpinAttributes)GetValue(MinuteSpinAttributesProperty);
            }
            set
            {
                SetValue(MinuteSpinAttributesProperty, value);
            }
        }

        public SpinAttributes SecondSpinAttributes
        {
            get
            {
                return (SpinAttributes)GetValue(SecondSpinAttributesProperty);
            }
            set
            {
                SetValue(SecondSpinAttributesProperty, value);
            }
        }

        public SpinAttributes AMPMSpinAttributes
        {
            get
            {
                return (SpinAttributes)GetValue(AMPMSpinAttributesProperty);
            }
            set
            {
                SetValue(AMPMSpinAttributesProperty, value);
            }
        }

        public ImageAttributes ColonImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(ColonImageAttributesProperty);
            }
            set
            {
                SetValue(ColonImageAttributesProperty, value);
            }
        }
        
        public ViewAttributes WeekViewAttributes
        {
            get
            {
                return (ViewAttributes)GetValue(WeekViewAttributesProperty);
            }
            set
            {
                SetValue(WeekViewAttributesProperty, value);
            }
        }

        public TextAttributes WeekTitleTextAttributes
        {
            get
            {
                return (TextAttributes)GetValue(WeekTitleTextAttributesProperty);
            }
            set
            {
                SetValue(WeekTitleTextAttributesProperty, value);
            }
        }

        public ImageAttributes WeekSelectImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(WeekSelectImageAttributesProperty);
            }
            set
            {
                SetValue(WeekSelectImageAttributesProperty, value);
            }
        }

        public TextAttributes WeekTextAttributes
        {
            get
            {
                return (TextAttributes)GetValue(WeekTextAttributesProperty);
            }
            set
            {
                SetValue(WeekTextAttributesProperty, value);
            }
        }
        public override Attributes Clone()
        {
            return new TimePickerAttributes(this);
        }
    }
}
