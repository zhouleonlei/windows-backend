using Tizen.NUI.Binding;

namespace Tizen.NUI.Controls
{
    public class FontAttributes : Attributes
    {
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(SelectorColor), typeof(FontAttributes), default(SelectorColor), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (FontAttributes)bindable;
            if (newValue != null)
            {
                attrs.textColor = (SelectorColor)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (FontAttributes)bindable;
            return attrs.textColor;
        });

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create("FontFamily", typeof(SelectorString), typeof(FontAttributes), default(SelectorString), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (FontAttributes)bindable;
            if (newValue != null)
            {
                attrs.fontFamily = (SelectorString)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (FontAttributes)bindable;
            return attrs.fontFamily;
        });

        public static readonly BindableProperty PointSizeProperty = BindableProperty.Create("PointSize", typeof(SelectorFloat), typeof(FontAttributes), default(SelectorFloat), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (FontAttributes)bindable;
            if (newValue != null)
            {
                attrs.pointSize = (SelectorFloat)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (FontAttributes)bindable;
            return attrs.pointSize;
        });

        public static readonly BindableProperty ShadowOffsetProperty = BindableProperty.Create("ShadowOffset", typeof(SelectorVector2), typeof(FontAttributes), default(SelectorVector2), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (FontAttributes)bindable;
            if (newValue != null)
            {
                attrs.shadowOffset = (SelectorVector2)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (FontAttributes)bindable;
            return attrs.shadowOffset;
        });

        public static readonly BindableProperty ShadowColorProperty = BindableProperty.Create("ShadowColor", typeof(SelectorColor), typeof(FontAttributes), default(SelectorColor), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (FontAttributes)bindable;
            if (newValue != null)
            {
                attrs.shadowColor = (SelectorColor)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (FontAttributes)bindable;
            return attrs.shadowColor;
        });

        public static readonly BindableProperty OutstrokeColorProperty = BindableProperty.Create("OutstrokeColor", typeof(SelectorColor), typeof(FontAttributes), default(SelectorColor), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (FontAttributes)bindable;
            if (newValue != null)
            {
                attrs.outstrokeColor = (SelectorColor)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (FontAttributes)bindable;
            return attrs.outstrokeColor;
        });

        public static readonly BindableProperty OutstrokeThicknessProperty = BindableProperty.Create("OutstrokeThickness", typeof(SelectorInt), typeof(FontAttributes), default(SelectorInt), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (FontAttributes)bindable;
            if (newValue != null)
            {
                attrs.outstrokeThickness = (SelectorInt)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (FontAttributes)bindable;
            return attrs.outstrokeThickness;
        });

        private SelectorColor textColor;
        private SelectorString fontFamily;
        private SelectorFloat pointSize;
        private SelectorVector2 shadowOffset;
        private SelectorColor shadowColor;
        private SelectorColor outstrokeColor;
        private SelectorInt outstrokeThickness;

        public SelectorColor TextColor
        {
            get
            {
                return (SelectorColor)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        public SelectorString FontFamily
        {
            get
            {
                return (SelectorString)GetValue(FontFamilyProperty);
            }
            set
            {
                SetValue(FontFamilyProperty, value);
            }
        }

        public SelectorFloat PointSize
        {
            get
            {
                return (SelectorFloat)GetValue(PointSizeProperty);
            }
            set
            {
                SetValue(PointSizeProperty, value);
            }
        }

        public SelectorVector2 ShadowOffset
        {
            get
            {
                return (SelectorVector2)GetValue(ShadowOffsetProperty);
            }
            set
            {
                SetValue(ShadowOffsetProperty, value);
            }
        }

        public SelectorColor ShadowColor
        {
            get
            {
                return (SelectorColor)GetValue(ShadowColorProperty);
            }
            set
            {
                SetValue(ShadowColorProperty, value);
            }
        }


        public SelectorColor OutstrokeColor
        {
            get
            {
                return (SelectorColor)GetValue(OutstrokeColorProperty);
            }
            set
            {
                SetValue(OutstrokeColorProperty, value);
            }
        }

        public SelectorInt OutstrokeThickness
        {
            get
            {
                return (SelectorInt)GetValue(OutstrokeThicknessProperty);
            }
            set
            {
                SetValue(OutstrokeThicknessProperty, value);
            }
        }

    }
}
