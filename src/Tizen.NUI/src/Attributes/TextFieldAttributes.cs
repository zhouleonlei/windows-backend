using Tizen.NUI.Binding;

namespace Tizen.NUI.Controls
{
    public class TextFieldAttributes : ViewAttributes
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(StringSelector), typeof(TextFieldAttributes), default(StringSelector), 
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.text = (StringSelector)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                return attrs.text;
            });

        public static readonly BindableProperty PlaceholderTextProperty = BindableProperty.Create("PlaceholderText", typeof(StringSelector), typeof(TextFieldAttributes), default(StringSelector),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.placeholderText = (StringSelector)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                return attrs.placeholderText;
            });

        public static readonly BindableProperty TranslatablePlaceholderTextProperty = BindableProperty.Create("TranslatablePlaceholderText", typeof(StringSelector), typeof(TextFieldAttributes), default(StringSelector),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.translatablePlaceholderText = (StringSelector)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                return attrs.translatablePlaceholderText;
            });

        public static readonly BindableProperty HorizontalAlignmentProperty = BindableProperty.Create("HorizontalAlignment", typeof(HorizontalAlignmentSelector), typeof(TextFieldAttributes), default(HorizontalAlignmentSelector), 
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.horizontalAlignment = (HorizontalAlignmentSelector)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                return attrs.horizontalAlignment;
            });

        public static readonly BindableProperty VerticalAlignmentProperty = BindableProperty.Create("VerticalAlignment", typeof(VerticalAlignmentSelector), typeof(TextFieldAttributes), default(VerticalAlignmentSelector), 
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.verticalAlignment = (VerticalAlignmentSelector)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                return attrs.verticalAlignment;
            });

        public static readonly BindableProperty EnableMarkupProperty = BindableProperty.Create("EnableMarkup", typeof(BoolSelector), typeof(TextFieldAttributes), default(BoolSelector), 
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.enableMarkup = (BoolSelector)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                return attrs.enableMarkup;
            });

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(ColorSelector), typeof(TextFieldAttributes), default(ColorSelector), 
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.textColor = (ColorSelector)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                return attrs.textColor;
            });

        public static readonly BindableProperty PlaceholderTextColorProperty = BindableProperty.Create("PlaceholderTextColor", typeof(ColorSelector), typeof(TextFieldAttributes), default(ColorSelector), 
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.placeholderTextColor = (ColorSelector)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                return attrs.placeholderTextColor;
            });

        public static readonly BindableProperty PrimaryCursorColorProperty = BindableProperty.Create("PrimaryCursorColor", typeof(ColorSelector), typeof(TextFieldAttributes), default(ColorSelector),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.primaryCursorColor = (ColorSelector)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                return attrs.primaryCursorColor;
            });

        public static readonly BindableProperty SecondaryCursorColorProperty = BindableProperty.Create("SecondaryCursorColor", typeof(ColorSelector), typeof(TextFieldAttributes), default(ColorSelector),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.secondaryCursorColor = (ColorSelector)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                return attrs.secondaryCursorColor;
            });

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create("FontFamily", typeof(StringSelector), typeof(TextFieldAttributes), default(StringSelector), 
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.fontFamily = (StringSelector)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                return attrs.fontFamily;
            });

        public static readonly BindableProperty PointSizeProperty = BindableProperty.Create("PointSize", typeof(FloatSelector), typeof(TextFieldAttributes), default(FloatSelector), 
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.pointSize = (FloatSelector)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                return attrs.pointSize;
            });

        public static readonly BindableProperty EnableCursorBlinkProperty = BindableProperty.Create("EnableCursorBlink", typeof(BoolSelector), typeof(TextFieldAttributes), default(BoolSelector),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.enableCursorBlink = (BoolSelector)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                return attrs.enableCursorBlink;
            });

        public static readonly BindableProperty EnableSelectionProperty = BindableProperty.Create("EnableSelection", typeof(BoolSelector), typeof(TextFieldAttributes), default(BoolSelector),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.enableSelection = (BoolSelector)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                return attrs.enableSelection;
            });

        public static readonly BindableProperty CursorWidthProperty = BindableProperty.Create("CursorWidth", typeof(IntSelector), typeof(TextFieldAttributes), default(IntSelector),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.cursorWidth = (IntSelector)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                return attrs.cursorWidth;
            });

        public static readonly BindableProperty EnableEllipsisProperty = BindableProperty.Create("EnableEllipsis", typeof(BoolSelector), typeof(TextFieldAttributes), default(BoolSelector),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.enableEllipsis = (BoolSelector)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (TextFieldAttributes)bindable;
                return attrs.enableEllipsis;
            });

        private StringSelector text;
        private StringSelector placeholderText;
        private StringSelector translatablePlaceholderText;
        private HorizontalAlignmentSelector horizontalAlignment;
        private VerticalAlignmentSelector verticalAlignment;
        private BoolSelector enableMarkup;
        private ColorSelector textColor;
        private ColorSelector placeholderTextColor;
        private ColorSelector primaryCursorColor;
        private ColorSelector secondaryCursorColor;
        private StringSelector fontFamily;
        private FloatSelector pointSize;
        private BoolSelector enableCursorBlink;
        private BoolSelector enableSelection;
        private IntSelector cursorWidth;
        private BoolSelector enableEllipsis;

        public TextFieldAttributes() : base() { }
        public TextFieldAttributes(TextFieldAttributes attributes) : base(attributes)
        {
            if (attributes.text != null)
            {
                text = attributes.text.Clone() as StringSelector;
            }
            if (attributes.placeholderText != null)
            {
                placeholderText = attributes.placeholderText.Clone() as StringSelector;
            }
            if (attributes.translatablePlaceholderText != null)
            {
                translatablePlaceholderText = attributes.translatablePlaceholderText.Clone() as StringSelector;
            }
            if (attributes.horizontalAlignment != null)
            {
                horizontalAlignment = attributes.horizontalAlignment.Clone() as HorizontalAlignmentSelector;
            }
            if (attributes.verticalAlignment != null)
            {
                verticalAlignment = attributes.verticalAlignment.Clone() as VerticalAlignmentSelector;
            }
            if (attributes.enableMarkup != null)
            {
                enableMarkup = attributes.enableMarkup.Clone() as BoolSelector;
            }
            if (attributes.textColor != null)
            {
                textColor = attributes.textColor.Clone() as ColorSelector;
            }
            if (attributes.placeholderTextColor != null)
            {
                placeholderTextColor = attributes.placeholderTextColor.Clone() as ColorSelector;
            }
            if (attributes.primaryCursorColor != null)
            {
                primaryCursorColor = attributes.primaryCursorColor.Clone() as ColorSelector;
            }
            if (attributes.secondaryCursorColor != null)
            {
                secondaryCursorColor = attributes.secondaryCursorColor.Clone() as ColorSelector;
            }
            if (attributes.fontFamily != null)
            {
                fontFamily = attributes.fontFamily.Clone() as StringSelector;
            }
            if (attributes.pointSize != null)
            {
                pointSize = attributes.pointSize.Clone() as FloatSelector;
            }
            if (attributes.enableCursorBlink != null)
            {
                enableCursorBlink = attributes.enableCursorBlink.Clone() as BoolSelector;
            }
            if (attributes.enableSelection != null)
            {
                enableSelection = attributes.enableSelection.Clone() as BoolSelector;
            }
            if (attributes.cursorWidth != null)
            {
                cursorWidth = attributes.cursorWidth.Clone() as IntSelector;
            }
            if (attributes.enableEllipsis != null)
            {
                enableEllipsis = attributes.enableEllipsis.Clone() as BoolSelector;
            }
        }
        public StringSelector Text
        {
            get
            {
                return (StringSelector)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public StringSelector PlaceholderText
        {
            get
            {
                return (StringSelector)GetValue(PlaceholderTextProperty);
            }
            set
            {
                SetValue(PlaceholderTextProperty, value);
            }
        }

        public StringSelector TranslatablePlaceholderText
        {
            get
            {
                return (StringSelector)GetValue(TranslatablePlaceholderTextProperty);
            }
            set
            {
                SetValue(TranslatablePlaceholderTextProperty, value);
            }
        }

        public HorizontalAlignmentSelector HorizontalAlignment
        {
            get
            {
                return (HorizontalAlignmentSelector)GetValue(HorizontalAlignmentProperty);
            }
            set
            {
                SetValue(HorizontalAlignmentProperty, value);
            }
        }

        public VerticalAlignmentSelector VerticalAlignment
        {
            get
            {
                return (VerticalAlignmentSelector)GetValue(VerticalAlignmentProperty);
            }
            set
            {
                SetValue(VerticalAlignmentProperty, value);
            }
        }

        public BoolSelector EnableMarkup
        {
            get
            {
                return (BoolSelector)GetValue(EnableMarkupProperty);
            }
            set
            {
                SetValue(EnableMarkupProperty, value);
            }
        }

        public ColorSelector TextColor
        {
            get
            {
                return (ColorSelector)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        public ColorSelector PlaceholderTextColor
        {
            get
            {
                return (ColorSelector)GetValue(PlaceholderTextColorProperty);
            }
            set
            {
                SetValue(PlaceholderTextColorProperty, value);
            }
        }

        public ColorSelector PrimaryCursorColor
        {
            get
            {
                return (ColorSelector)GetValue(PrimaryCursorColorProperty);
            }
            set
            {
                SetValue(PrimaryCursorColorProperty, value);
            }
        }

        public ColorSelector SecondaryCursorColor
        {
            get
            {
                return (ColorSelector)GetValue(SecondaryCursorColorProperty);
            }
            set
            {
                SetValue(SecondaryCursorColorProperty, value);
            }
        }

        public StringSelector FontFamily
        {
            get
            {
                return (StringSelector)GetValue(FontFamilyProperty);
            }
            set
            {
                SetValue(FontFamilyProperty, value);
            }
        }

        public FloatSelector PointSize
        {
            get
            {
                return (FloatSelector)GetValue(PointSizeProperty);
            }
            set
            {
                SetValue(PointSizeProperty, value);
            }
        }

        public BoolSelector EnableCursorBlink
        {
            get
            {
                return (BoolSelector)GetValue(EnableCursorBlinkProperty);
            }
            set
            {
                SetValue(EnableCursorBlinkProperty, value);
            }
        }

        public BoolSelector EnableSelection
        {
            get
            {
                return (BoolSelector)GetValue(EnableSelectionProperty);
            }
            set
            {
                SetValue(EnableSelectionProperty, value);
            }
        }

        public IntSelector CursorWidth
        {
            get
            {
                return (IntSelector)GetValue(CursorWidthProperty);
            }
            set
            {
                SetValue(CursorWidthProperty, value);
            }
        }

        public BoolSelector EnableEllipsis
        {
            get
            {
                return (BoolSelector)GetValue(EnableEllipsisProperty);
            }
            set
            {
                SetValue(EnableEllipsisProperty, value);
            }
        }

        public override Attributes Clone()
        {
            return new TextFieldAttributes(this);
        }
    }
}
