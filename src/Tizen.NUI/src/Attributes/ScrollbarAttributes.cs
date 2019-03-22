using Tizen.NUI.Binding;

namespace Tizen.NUI.Controls
{
    public class ScrollBarAttributes : ViewAttributes
    {
        public static readonly BindableProperty TrackImageAttributesProperty = BindableProperty.Create("TrackImageAttributes", typeof(ImageAttributes), typeof(ScrollBarAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ScrollBarAttributes)bindable;
            if (newValue != null)
            {
                attrs.trackImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ScrollBarAttributes)bindable;
            return attrs.trackImageAttrs;
        });
        public static readonly BindableProperty ThumbImageAttributesProperty = BindableProperty.Create("ThumbImageAttributes", typeof(ImageAttributes), typeof(ScrollBarAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ScrollBarAttributes)bindable;
            if (newValue != null)
            {
                attrs.thumbImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ScrollBarAttributes)bindable;
            return attrs.thumbImageAttrs;
        });
        public static readonly BindableProperty DirectionProperty = BindableProperty.Create("Direction", typeof(ScrollBar.DirectionType), typeof(ScrollBarAttributes), default(ScrollBar.DirectionType), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ScrollBarAttributes)bindable;
            if (newValue != null)
            {
                attrs.direction = (ScrollBar.DirectionType)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ScrollBarAttributes)bindable;
            return attrs.direction;
        });

        public static readonly BindableProperty ThumbSizeProperty = BindableProperty.Create("ThumbSize", typeof(Size), typeof(ScrollBarAttributes), default(Size), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ScrollBarAttributes)bindable;
            if (newValue != null)
            {
                attrs.thumbSize = (Size)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ScrollBarAttributes)bindable;
            return attrs.thumbSize;
        });

        public static readonly BindableProperty MaxValueProperty = BindableProperty.Create("MaxValue", typeof(uint), typeof(ScrollBarAttributes), default(uint), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ScrollBarAttributes)bindable;
            if (newValue != null)
            {
                attrs.maxValue = (uint)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ScrollBarAttributes)bindable;
            return attrs.maxValue;
        });

        public static readonly BindableProperty MinValueProperty = BindableProperty.Create("MinValue", typeof(uint), typeof(ScrollBarAttributes), default(uint), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ScrollBarAttributes)bindable;
            if (newValue != null)
            {
                attrs.minValue = (uint)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ScrollBarAttributes)bindable;
            return attrs.minValue;
        });

        public static readonly BindableProperty CurValueProperty = BindableProperty.Create("CurValue", typeof(uint), typeof(ScrollBarAttributes), default(uint), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ScrollBarAttributes)bindable;
            if (newValue != null)
            {
                attrs.curValue = (uint)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ScrollBarAttributes)bindable;
            return attrs.curValue;
        });

        public static readonly BindableProperty DurationProperty = BindableProperty.Create("Duration", typeof(uint), typeof(ScrollBarAttributes), default(uint), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ScrollBarAttributes)bindable;
            if (newValue != null)
            {
                attrs.duration = (uint?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ScrollBarAttributes)bindable;
            return attrs.duration;
        });

        private ScrollBar.DirectionType? direction= ScrollBar.DirectionType.Horizontal;
        private Size thumbSize;
        private uint maxValue;
        private uint minValue;
        private uint curValue;
        private uint? duration;
        private ImageAttributes trackImageAttrs;
        private ImageAttributes thumbImageAttrs;

        public ScrollBarAttributes() : base()
        {
        
        }

        public ScrollBarAttributes(ScrollBarAttributes attributes) : base(attributes)
        {
            if (attributes.trackImageAttrs != null)
            {
                trackImageAttrs = attributes.trackImageAttrs.Clone() as ImageAttributes;
            }

            if (attributes.thumbImageAttrs != null)
            {
                thumbImageAttrs = attributes.thumbImageAttrs.Clone() as ImageAttributes;
            }
        }

        public ImageAttributes TrackImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(TrackImageAttributesProperty);
            }
            set
            {
                SetValue(TrackImageAttributesProperty, value);
            }
        }

        public ImageAttributes ThumbImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(ThumbImageAttributesProperty);
            }
            set
            {
                SetValue(ThumbImageAttributesProperty, value);
            }
        }

        public ScrollBar.DirectionType? Direction
        {
            get
            {
                return (ScrollBar.DirectionType?)GetValue(DirectionProperty);
            }
            set
            {
                SetValue(DirectionProperty, value);
            }
        }

        public Size ThumbSize
        {
            get
            {
                return (Size)GetValue(ThumbSizeProperty);
            }
            set
            {
                SetValue(ThumbSizeProperty, value);
            }
        }

        public uint MaxValue
        {
            get
            {
                return (uint)GetValue(MaxValueProperty);
            }
            set
            {
                SetValue(MaxValueProperty, value);
            }
        }

        public uint MinValue
        {
            get
            {
                return (uint)GetValue(MinValueProperty);
            }
            set
            {
                SetValue(MinValueProperty, value);
            }
        }

        // can't change the pos of thumb
        public uint CurValue
        {
            get
            {
                return (uint)GetValue(CurValueProperty);
            }
            set
            {
                SetValue(CurValueProperty, value);
            }
        }

        public uint Duration
        {
            get
            {
                return (uint)GetValue(DurationProperty);
            }
            set
            {
                SetValue(DurationProperty, value);
            }
        }

        public override Attributes Clone()
        {
            return new ScrollBarAttributes(this);
        }

    }
}
