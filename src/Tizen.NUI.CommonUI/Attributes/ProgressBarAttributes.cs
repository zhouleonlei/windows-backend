﻿using Tizen.NUI.Binding;

namespace Tizen.NUI.CommonUI
{
    public class ProgressBarAttributes : ViewAttributes
    {
        public static readonly BindableProperty TrackImageAttributesProperty = BindableProperty.Create("TrackImageAttributes", typeof(ImageAttributes), typeof(ProgressBarAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            if (newValue != null)
            {
                attrs.trackImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            return attrs.trackImageAttrs;
        });

        public static readonly BindableProperty ProgressImageAttributesProperty = BindableProperty.Create("ProgressImageAttributes", typeof(ImageAttributes), typeof(ProgressBarAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            if (newValue != null)
            {
                attrs.progressImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            return attrs.progressImageAttrs;
        });

        public static readonly BindableProperty ProgressImageURLPrefixProperty = BindableProperty.Create("ProgressImageURLPrefix", typeof(StringSelector), typeof(ProgressBarAttributes), default(StringSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            if (newValue != null)
            {
                attrs.progressImageURLPrefix = (StringSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            return attrs.progressImageURLPrefix;
        });

        public static readonly BindableProperty BufferImageAttributesProperty = BindableProperty.Create("BufferImageAttributes", typeof(ImageAttributes), typeof(ProgressBarAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            if (newValue != null)
            {
                attrs.bufferImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            return attrs.bufferImageAttrs;
        });

        public static readonly BindableProperty LoadingImageAttributesProperty = BindableProperty.Create("LoadingImageAttributes", typeof(ImageAttributes), typeof(ProgressBarAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            if (newValue != null)
            {
                attrs.loadingImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            return attrs.loadingImageAttrs;
        });

        public static readonly BindableProperty DirectionProperty = BindableProperty.Create("Direction", typeof(Tizen.NUI.CommonUI.Progress.DirectionType), typeof(ProgressBarAttributes), default(Progress.DirectionType), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            if (newValue != null)
            {
                attrs.direction = (Progress.DirectionType)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            return attrs.direction;
        });

        public static readonly BindableProperty ThumbSizeProperty = BindableProperty.Create("ThumbSize", typeof(Size), typeof(ProgressBarAttributes), default(Size), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            if (newValue != null)
            {
                attrs.thumbSize = (Size)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            return attrs.thumbSize;
        });

        public static readonly BindableProperty MaxValueProperty = BindableProperty.Create("MaxValue", typeof(uint), typeof(ProgressBarAttributes), default(uint), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            if (newValue != null)
            {
                attrs.maxValue = (uint?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            return attrs.maxValue;
        });

        public static readonly BindableProperty MinValueProperty = BindableProperty.Create("MinValue", typeof(uint), typeof(ProgressBarAttributes), default(uint), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            if (newValue != null)
            {
                attrs.minValue = (uint?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            return attrs.minValue;
        });

        public static readonly BindableProperty CurValueProperty = BindableProperty.Create("CurValue", typeof(uint), typeof(ProgressBarAttributes), default(uint), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            if (newValue != null)
            {
                attrs.curValue = (uint?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            return attrs.curValue;
        });

        public static readonly BindableProperty DurationProperty = BindableProperty.Create("Duration", typeof(uint), typeof(ProgressBarAttributes), default(uint), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            if (newValue != null)
            {
                attrs.duration = (uint?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ProgressBarAttributes)bindable;
            return attrs.duration;
        });

        private Progress.DirectionType direction;
        private StringSelector progressImageURLPrefix;
        private Size thumbSize;
        private uint? maxValue;
        private uint? minValue;
        private uint? curValue;
        private uint? duration;
        private ImageAttributes trackImageAttrs;
        private ImageAttributes progressImageAttrs;
        private ImageAttributes bufferImageAttrs;
        private ImageAttributes loadingImageAttrs;
        
        public ProgressBarAttributes() : base() { }

        public ProgressBarAttributes(ProgressBarAttributes attributes) : base(attributes)
        {
            direction = attributes.direction;
            thumbSize = attributes.thumbSize;
            maxValue = attributes.maxValue;
            minValue = attributes.minValue;
            curValue = attributes.curValue;
            duration = attributes.duration;

            if (attributes.progressImageURLPrefix != null)
            {
                progressImageURLPrefix = attributes.progressImageURLPrefix.Clone() as StringSelector;
            }

            if (attributes.trackImageAttrs != null)
            {
                trackImageAttrs = attributes.trackImageAttrs.Clone() as ImageAttributes;
            }

            if (attributes.progressImageAttrs != null)
            {
                progressImageAttrs = attributes.progressImageAttrs.Clone() as ImageAttributes;
            }

            if (attributes.bufferImageAttrs != null)
            {
                bufferImageAttrs = attributes.bufferImageAttrs.Clone() as ImageAttributes;
            }

            if (attributes.loadingImageAttrs != null)
            {
                loadingImageAttrs = attributes.loadingImageAttrs.Clone() as ImageAttributes;
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

        public ImageAttributes ProgressImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(ProgressImageAttributesProperty);
            }
            set
            {
                SetValue(ProgressImageAttributesProperty, value);
            }
        }

        public ImageAttributes BufferImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(BufferImageAttributesProperty);
            }
            set
            {
                SetValue(BufferImageAttributesProperty, value);
            }
        }

        public ImageAttributes LoadingImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(LoadingImageAttributesProperty);
            }
            set
            {
                SetValue(LoadingImageAttributesProperty, value);
            }
        }

        public StringSelector ProgressImageURLPrefix
        {
            get
            {
                return (StringSelector)GetValue(ProgressImageURLPrefixProperty);
            }
            set
            {
                SetValue(ProgressImageURLPrefixProperty, value);
            }
        }

        public Progress.DirectionType Direction
        {
            get
            {
                return (Progress.DirectionType)GetValue(DurationProperty);
            }
            set
            {
                SetValue(DurationProperty, value);
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

        public uint? MaxValue
        {
            get
            {
                return (uint?)GetValue(MaxValueProperty);
            }
            set
            {
                SetValue(MaxValueProperty, value);
            }
        }

        public uint? MinValue
        {
            get
            {
                return (uint?)GetValue(MinValueProperty);
            }
            set
            {
                SetValue(MinValueProperty, value);
            }
        }

        public uint? CurValue
        {
            get
            {
                return (uint?)GetValue(CurValueProperty);
            }
            set
            {
                SetValue(CurValueProperty, value);
            }
        }

        public uint? Duration
        {
            get
            {
                return (uint?)GetValue(DurationProperty);
            }
            set
            {
                SetValue(DurationProperty, value);
            }
        }

        public override Attributes Clone()
        {
            return new ProgressBarAttributes(this);
        }

    }
}
