using Tizen.NUI.Binding;

namespace Tizen.NUI.CommonUI
{
    public class TextAttributes : ViewAttributes
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(StringSelector), typeof(TextAttributes), default(StringSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.text = (StringSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.text;
        });

        public static readonly BindableProperty TranslatableTextProperty = BindableProperty.Create("TranslatableText", typeof(StringSelector), typeof(TextAttributes), default(StringSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.translatableText = (StringSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.translatableText;
        });

        public static readonly BindableProperty MultiLineProperty = BindableProperty.Create("MultiLine", typeof(bool?), typeof(TextAttributes), default(bool?), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.multiLine = (bool?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.multiLine;
        });

        public static readonly BindableProperty HorizontalAlignmentProperty = BindableProperty.Create("HorizontalAlignment", typeof(HorizontalAlignment?), typeof(TextAttributes), default(HorizontalAlignment?), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.horizontalAlignment = (HorizontalAlignment?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.horizontalAlignment;
        });

        public static readonly BindableProperty VerticalAlignmentProperty = BindableProperty.Create("VerticalAlignment", typeof(VerticalAlignment?), typeof(TextAttributes), default(VerticalAlignment?), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.verticalAlignment = (VerticalAlignment?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.verticalAlignment;
        });

        public static readonly BindableProperty EnableMarkupProperty = BindableProperty.Create("EnableMarkup", typeof(bool?), typeof(TextAttributes), default(bool?), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.enableMarkup = (bool?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.enableMarkup;
        });

        public static readonly BindableProperty EnableAutoScrollProperty = BindableProperty.Create("EnableAutoScroll", typeof(bool?), typeof(TextAttributes), default(bool?), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.enableAutoScroll = (bool?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.enableAutoScroll;
        });

        public static readonly BindableProperty AutoScrollSpeedProperty = BindableProperty.Create("AutoScrollSpeed", typeof(int?), typeof(TextAttributes), default(int?), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.autoScrollSpeed = (int?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.autoScrollSpeed;
        });

        public static readonly BindableProperty AutoScrollLoopCountProperty = BindableProperty.Create("AutoScrollLoopCount", typeof(int?), typeof(TextAttributes), default(int?), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.autoScrollLoopCount = (int?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.autoScrollLoopCount;
        });

        public static readonly BindableProperty AutoScrollGapProperty = BindableProperty.Create("AutoScrollGap", typeof(float?), typeof(TextAttributes), default(float?), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.autoScrollGap = (float?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.autoScrollGap;
        });

        public static readonly BindableProperty AutoScrollLoopDelayProperty = BindableProperty.Create("AutoScrollLoopDelay", typeof(float?), typeof(TextAttributes), default(float?), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.autoScrollLoopDelay = (float?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.autoScrollLoopDelay;
        });

        public static readonly BindableProperty AutoScrollStopModeProperty = BindableProperty.Create("AutoScrollStopMode", typeof(AutoScrollStopMode?), typeof(TextAttributes), default(AutoScrollStopMode?), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.autoScrollStopMode = (AutoScrollStopMode?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.autoScrollStopMode;
        });

        public static readonly BindableProperty LineSpacingProperty = BindableProperty.Create("LineSpacing", typeof(float?), typeof(TextAttributes), default(float?), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.lineSpacing = (float?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.lineSpacing;
        });


        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(ColorSelector), typeof(TextAttributes), default(ColorSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.textColor = (ColorSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.textColor;
        });

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create("FontFamily", typeof(string), typeof(TextAttributes), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.fontFamily = (string)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.fontFamily;
        });

        public static readonly BindableProperty PointSizeProperty = BindableProperty.Create("PointSize", typeof(FloatSelector), typeof(TextAttributes), default(FloatSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.pointSize = (FloatSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.pointSize;
        });

        public static readonly BindableProperty ShadowOffsetProperty = BindableProperty.Create("ShadowOffset", typeof(Vector2Selector), typeof(TextAttributes), default(Vector2Selector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.shadowOffset = (Vector2Selector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.shadowOffset;
        });

        public static readonly BindableProperty ShadowColorProperty = BindableProperty.Create("ShadowColor", typeof(ColorSelector), typeof(TextAttributes), default(ColorSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.shadowColor = (ColorSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.shadowColor;
        });

        public static readonly BindableProperty OutstrokeColorProperty = BindableProperty.Create("OutstrokeColor", typeof(ColorSelector), typeof(TextAttributes), default(ColorSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.outstrokeColor = (ColorSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.outstrokeColor;
        });

        public static readonly BindableProperty OutstrokeThicknessProperty = BindableProperty.Create("OutstrokeThickness", typeof(IntSelector), typeof(TextAttributes), default(IntSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.outstrokeThickness = (IntSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.outstrokeThickness;
        });

        private StringSelector text;
        private StringSelector translatableText;
        private bool? multiLine;
        private HorizontalAlignment? horizontalAlignment;
        private VerticalAlignment? verticalAlignment;
        private bool? enableMarkup;
        private bool? enableAutoScroll;
        private int? autoScrollSpeed;
        private int? autoScrollLoopCount;
        private float? autoScrollGap;
        private float? autoScrollLoopDelay;
        private AutoScrollStopMode? autoScrollStopMode;
        private float? lineSpacing;

        private ColorSelector textColor;
        private string fontFamily;
        private FloatSelector pointSize;
        private Vector2Selector shadowOffset;
        private ColorSelector shadowColor;
        private ColorSelector outstrokeColor;
        private IntSelector outstrokeThickness;

        public TextAttributes() : base() { }
        public TextAttributes(TextAttributes attributes) : base(attributes)
        {
            if (attributes.text != null)
            {
                text = attributes.text.Clone() as StringSelector;
            }

            if (attributes.translatableText != null)
            {
                translatableText = attributes.translatableText.Clone() as StringSelector;
            }

            if (attributes.multiLine != null)
            {
                multiLine = attributes.multiLine;
            }

            if (attributes.horizontalAlignment != null)
            {
                horizontalAlignment = attributes.horizontalAlignment;
            }

            if (attributes.verticalAlignment != null)
            {
                verticalAlignment = attributes.verticalAlignment;
            }

            if (attributes.enableMarkup != null)
            {
                enableMarkup = attributes.enableMarkup;
            }

            if (attributes.enableAutoScroll != null)
            {
                enableAutoScroll = attributes.enableAutoScroll;
            }

            if (attributes.autoScrollSpeed != null)
            {
                autoScrollSpeed = attributes.autoScrollSpeed;
            }

            if (attributes.autoScrollLoopCount != null)
            {
                autoScrollLoopCount = attributes.autoScrollLoopCount;
            }

            if (attributes.autoScrollGap != null)
            {
                autoScrollGap = attributes.autoScrollGap;
            }

            if (attributes.autoScrollLoopDelay != null)
            {
                autoScrollLoopDelay = attributes.autoScrollLoopDelay;
            }

            if (attributes.autoScrollStopMode != null)
            {
                autoScrollStopMode = attributes.autoScrollStopMode;
            }

            if (attributes.lineSpacing != null)
            {
                lineSpacing = attributes.lineSpacing;
            }

            if (attributes.textColor != null)
            {
                textColor = attributes.textColor.Clone() as ColorSelector;
            }

            if (attributes.fontFamily != null)
            {
                fontFamily = attributes.fontFamily;
            }

            if (attributes.pointSize != null)
            {
                pointSize = attributes.pointSize.Clone() as FloatSelector;
            }

            if (attributes.shadowOffset != null)
            {
                shadowOffset = attributes.shadowOffset.Clone() as Vector2Selector;
            }

            if (attributes.shadowColor != null)
            {
                shadowColor = attributes.shadowColor.Clone() as ColorSelector;
            }

            if (attributes.outstrokeColor != null)
            {
                outstrokeColor = attributes.outstrokeColor.Clone() as ColorSelector;
            }
            if (attributes.outstrokeThickness != null)
            {
                outstrokeThickness = attributes.outstrokeThickness.Clone() as IntSelector;
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
        public StringSelector TranslatableText
        {
            get
            {
                return (StringSelector)GetValue(TranslatableTextProperty);
            }
            set
            {
                SetValue(TranslatableTextProperty, value);
            }
        }
        public bool? MultiLine
        {
            get
            {
                return (bool?)GetValue(MultiLineProperty);
            }
            set
            {
                SetValue(MultiLineProperty, value);
            }
        }
        public HorizontalAlignment? HorizontalAlignment
        {
            get
            {
                return (HorizontalAlignment?)GetValue(HorizontalAlignmentProperty);
            }
            set
            {
                SetValue(HorizontalAlignmentProperty, value);
            }
        }

        public VerticalAlignment? VerticalAlignment
        {
            get
            {
                return (VerticalAlignment?)GetValue(VerticalAlignmentProperty);
            }
            set
            {
                SetValue(VerticalAlignmentProperty, value);
            }
        }

        public bool? EnableMarkup
        {
            get
            {
                return (bool?)GetValue(EnableMarkupProperty);
            }
            set
            {
                SetValue(EnableMarkupProperty, value);
            }
        }

        public bool? EnableAutoScroll
        {
            get
            {
                return (bool?)GetValue(EnableAutoScrollProperty);
            }
            set
            {
                SetValue(EnableAutoScrollProperty, value);
            }
        }

        public int? AutoScrollSpeed
        {
            get
            {
                return (int?)GetValue(AutoScrollSpeedProperty);
            }
            set
            {
                SetValue(AutoScrollSpeedProperty, value);
            }
        }

        public int? AutoScrollLoopCount
{
            get
            {
                return (int?)GetValue(AutoScrollLoopCountProperty);
            }
            set
            {
                SetValue(AutoScrollLoopCountProperty, value);
            }
        }

        public float? AutoScrollGap
        {
            get
            {
                return (float?)GetValue(AutoScrollGapProperty);
            }
            set
            {
                SetValue(AutoScrollGapProperty, value);
            }
        }

        public float? AutoScrollLoopDelay
        {
            get
            {
                return (float?)GetValue(AutoScrollLoopDelayProperty);
            }
            set
            {
                SetValue(AutoScrollLoopDelayProperty, value);
            }
        }

        public AutoScrollStopMode? AutoScrollStopMode
        {
            get
            {
                return (AutoScrollStopMode?)GetValue(AutoScrollStopModeProperty);
            }
            set
            {
                SetValue(AutoScrollStopModeProperty, value);
            }
        }

        public float? LineSpacing
        {
            get
            {
                return (float?)GetValue(LineSpacingProperty);
            }
            set
            {
                SetValue(LineSpacingProperty, value);
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

        public string FontFamily
        {
            get
            {
                return (string)GetValue(FontFamilyProperty);
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

        public Vector2Selector ShadowOffset
        {
            get
            {
                return (Vector2Selector)GetValue(ShadowOffsetProperty);
            }
            set
            {
                SetValue(ShadowOffsetProperty, value);
            }
        }

        public ColorSelector ShadowColor
        {
            get
            {
                return (ColorSelector)GetValue(ShadowColorProperty);
            }
            set
            {
                SetValue(ShadowColorProperty, value);
            }
        }


        public ColorSelector OutstrokeColor
        {
            get
            {
                return (ColorSelector)GetValue(OutstrokeColorProperty);
            }
            set
            {
                SetValue(OutstrokeColorProperty, value);
            }
        }

        public IntSelector OutstrokeThickness
        {
            get
            {
                return (IntSelector)GetValue(OutstrokeThicknessProperty);
            }
            set
            {
                SetValue(OutstrokeThicknessProperty, value);
            }
        }

        public override Attributes Clone()
        {
            return new TextAttributes(this);
        }
    }
}
