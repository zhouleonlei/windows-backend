using Tizen.NUI.Binding;

namespace Tizen.NUI.Controls
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

        public static readonly BindableProperty MultiLineProperty = BindableProperty.Create("MultiLine", typeof(BoolSelector), typeof(TextAttributes), default(BoolSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.multiLine = (BoolSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.multiLine;
        });

        public static readonly BindableProperty HorizontalAlignmentProperty = BindableProperty.Create("HorizontalAlignment", typeof(HorizontalAlignmentSelector), typeof(TextAttributes), default(HorizontalAlignmentSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.horizontalAlignment = (HorizontalAlignmentSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.horizontalAlignment;
        });

        public static readonly BindableProperty VerticalAlignmentProperty = BindableProperty.Create("VerticalAlignment", typeof(VerticalAlignmentSelector), typeof(TextAttributes), default(VerticalAlignmentSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.verticalAlignment = (VerticalAlignmentSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.verticalAlignment;
        });

        public static readonly BindableProperty EnableMarkupProperty = BindableProperty.Create("EnableMarkup", typeof(BoolSelector), typeof(TextAttributes), default(BoolSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.enableMarkup = (BoolSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.enableMarkup;
        });

        public static readonly BindableProperty EnableAutoScrollProperty = BindableProperty.Create("EnableAutoScroll", typeof(BoolSelector), typeof(TextAttributes), default(BoolSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.enableAutoScroll = (BoolSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.enableAutoScroll;
        });

        public static readonly BindableProperty AutoScrollSpeedProperty = BindableProperty.Create("AutoScrollSpeed", typeof(IntSelector), typeof(TextAttributes), default(IntSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.autoScrollSpeed = (IntSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.autoScrollSpeed;
        });

        public static readonly BindableProperty AutoScrollLoopCountProperty = BindableProperty.Create("AutoScrollLoopCount", typeof(IntSelector), typeof(TextAttributes), default(IntSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.autoScrollLoopCount = (IntSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.autoScrollLoopCount;
        });

        public static readonly BindableProperty AutoScrollGapProperty = BindableProperty.Create("AutoScrollGap", typeof(FloatSelector), typeof(TextAttributes), default(FloatSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.autoScrollGap = (FloatSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.autoScrollGap;
        });

        public static readonly BindableProperty AutoScrollLoopDelayProperty = BindableProperty.Create("AutoScrollLoopDelay", typeof(FloatSelector), typeof(TextAttributes), default(FloatSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.autoScrollLoopDelay = (FloatSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.autoScrollLoopDelay;
        });

        public static readonly BindableProperty AutoScrollStopModeProperty = BindableProperty.Create("AutoScrollStopMode", typeof(AutoScrollStopModeSelector), typeof(TextAttributes), default(AutoScrollStopModeSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.autoScrollStopMode = (AutoScrollStopModeSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (TextAttributes)bindable;
            return attrs.autoScrollStopMode;
        });

        public static readonly BindableProperty LineSpacingProperty = BindableProperty.Create("LineSpacing", typeof(FloatSelector), typeof(TextAttributes), default(FloatSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.lineSpacing = (FloatSelector)newValue;
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

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create("FontFamily", typeof(StringSelector), typeof(TextAttributes), default(StringSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (TextAttributes)bindable;
            if (newValue != null)
            {
                attrs.fontFamily = (StringSelector)newValue;
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
        private BoolSelector multiLine;
        private HorizontalAlignmentSelector horizontalAlignment;
        private VerticalAlignmentSelector verticalAlignment;
        private BoolSelector enableMarkup;
        private BoolSelector enableAutoScroll;
        private IntSelector autoScrollSpeed;
        private IntSelector autoScrollLoopCount;
        private FloatSelector autoScrollGap;
        private FloatSelector autoScrollLoopDelay;
        private AutoScrollStopModeSelector autoScrollStopMode;
        private FloatSelector lineSpacing;

        private ColorSelector textColor;
        private StringSelector fontFamily;
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
                multiLine = attributes.multiLine.Clone() as BoolSelector;
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

            if (attributes.enableAutoScroll != null)
            {
                enableAutoScroll = attributes.enableAutoScroll.Clone() as BoolSelector;
            }

            if (attributes.autoScrollSpeed != null)
            {
                autoScrollSpeed = attributes.autoScrollSpeed.Clone() as IntSelector;
            }

            if (attributes.autoScrollLoopCount != null)
            {
                autoScrollLoopCount = attributes.autoScrollLoopCount.Clone() as IntSelector;
            }

            if (attributes.autoScrollGap != null)
            {
                autoScrollGap = attributes.autoScrollGap.Clone() as FloatSelector;
            }

            if (attributes.autoScrollLoopDelay != null)
            {
                autoScrollLoopDelay = attributes.autoScrollLoopDelay.Clone() as FloatSelector;
            }

            if (attributes.autoScrollStopMode != null)
            {
                autoScrollStopMode = attributes.autoScrollStopMode.Clone() as AutoScrollStopModeSelector;
            }

            if (attributes.lineSpacing != null)
            {
                lineSpacing = attributes.lineSpacing.Clone() as FloatSelector;
            }

            if (attributes.textColor != null)
            {
                textColor = attributes.textColor.Clone() as ColorSelector;
            }

            if (attributes.fontFamily != null)
            {
                fontFamily = attributes.fontFamily.Clone() as StringSelector;
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
        public BoolSelector MultiLine
        {
            get
            {
                return (BoolSelector)GetValue(MultiLineProperty);
            }
            set
            {
                SetValue(MultiLineProperty, value);
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

        public BoolSelector EnableAutoScroll
        {
            get
            {
                return (BoolSelector)GetValue(EnableAutoScrollProperty);
            }
            set
            {
                SetValue(EnableAutoScrollProperty, value);
            }
        }

        public IntSelector AutoScrollSpeed
        {
            get
            {
                return (IntSelector)GetValue(AutoScrollSpeedProperty);
            }
            set
            {
                SetValue(AutoScrollSpeedProperty, value);
            }
        }

        public IntSelector AutoScrollLoopCount
{
            get
            {
                return (IntSelector)GetValue(AutoScrollLoopCountProperty);
            }
            set
            {
                SetValue(AutoScrollLoopCountProperty, value);
            }
        }

        public FloatSelector AutoScrollGap
        {
            get
            {
                return (FloatSelector)GetValue(AutoScrollGapProperty);
            }
            set
            {
                SetValue(AutoScrollGapProperty, value);
            }
        }

        public FloatSelector AutoScrollLoopDelay
        {
            get
            {
                return (FloatSelector)GetValue(AutoScrollLoopDelayProperty);
            }
            set
            {
                SetValue(AutoScrollLoopDelayProperty, value);
            }
        }

        public AutoScrollStopModeSelector AutoScrollStopMode
        {
            get
            {
                return (AutoScrollStopModeSelector)GetValue(AutoScrollStopModeProperty);
            }
            set
            {
                SetValue(AutoScrollStopModeProperty, value);
            }
        }

        public FloatSelector LineSpacing
        {
            get
            {
                return (FloatSelector)GetValue(LineSpacingProperty);
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
