using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Controls
{
    public class StepIndicatorAttributes : ViewAttributes
    {
        private TextAttributes normalStepTextAtr;
        private TextAttributes focusStepTextAttr;
        private TextAttributes leftTextAttr;
        private TextAttributes rightTextAttr;
        private ImageAttributes leftArrowIconAttr;
        private ImageAttributes rightArrowIconAttr;
        private StringSelector checkImageURL;
        private string[] checkImageArray;
        private Size stepSize;

        public StepIndicatorAttributes() : base()
        {
            NormalStepTextAtr = new TextAttributes()
            {
                Size2D = new Size2D(70, 50)
                
            };
            FocusStepTextAttr = new TextAttributes
            {
                Size2D = new Size2D(70, 50)
                
            };
            LeftTextAttr = new TextAttributes
            {
                Size2D =  new Size2D(120, 48)
                
            };
            RightTextAttr = new TextAttributes
            {
                Size2D = new Size2D(120, 48)
                
            };
            CheckImageURL = new StringSelector
            {
            };

        }

        public StepIndicatorAttributes(StepIndicatorAttributes attrs) : base(attrs)
        {

        }

        public static readonly BindableProperty NormalStepTextAtrProperty = BindableProperty.Create("NormalStepTextAtr", typeof(TextAttributes), typeof(StepIndicatorAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (StepIndicatorAttributes)bindable;
            if (newValue != null)
            {
                attrs.normalStepTextAtr = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (StepIndicatorAttributes)bindable;
            return attrs.normalStepTextAtr;
        });

        public static readonly BindableProperty FocusStepTextAttrProperty = BindableProperty.Create("FocusStepTextAttr", typeof(TextAttributes), typeof(StepIndicatorAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (StepIndicatorAttributes)bindable;
            if (newValue != null)
            {
                attrs.focusStepTextAttr = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (StepIndicatorAttributes)bindable;
            return attrs.focusStepTextAttr;
        });

        public static readonly BindableProperty leftTextAttrProperty = BindableProperty.Create("LeftTextAttr", typeof(TextAttributes), typeof(StepIndicatorAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (StepIndicatorAttributes)bindable;
            if (newValue != null)
            {
                attrs.leftTextAttr = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (StepIndicatorAttributes)bindable;
            return attrs.leftTextAttr;
        });

        public static readonly BindableProperty RightTextAttrProperty = BindableProperty.Create("RightTextAttr", typeof(TextAttributes), typeof(StepIndicatorAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (StepIndicatorAttributes)bindable;
            if (newValue != null)
            {
                attrs.rightTextAttr = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (StepIndicatorAttributes)bindable;
            return attrs.rightTextAttr;
        });

        public static readonly BindableProperty LeftArrowIconAttrProperty = BindableProperty.Create("LeftArrowIconAttr", typeof(ImageAttributes), typeof(StepIndicatorAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (StepIndicatorAttributes)bindable;
            if (newValue != null)
            {
                attrs.leftArrowIconAttr = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (StepIndicatorAttributes)bindable;
            return attrs.leftArrowIconAttr;
        });

        public static readonly BindableProperty RightArrowIconAttrProperty = BindableProperty.Create("RightArrowIconAttr", typeof(ImageAttributes), typeof(StepIndicatorAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (StepIndicatorAttributes)bindable;
            if (newValue != null)
            {
                attrs.rightArrowIconAttr = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (StepIndicatorAttributes)bindable;
            return attrs.rightArrowIconAttr;
        });

        public static readonly BindableProperty CheckImageURLProperty = BindableProperty.Create("CheckImageURLAttr", typeof(StringSelector), typeof(StepIndicatorAttributes), default(StringSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (StepIndicatorAttributes)bindable;
            if (newValue != null)
            {
                attrs.checkImageURL = (StringSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (StepIndicatorAttributes)bindable;
            return attrs.checkImageURL;
        });

        // 

        public TextAttributes NormalStepTextAtr
        {
            get
            {
                return (TextAttributes)GetValue(NormalStepTextAtrProperty);
            }
            set
            {
                SetValue(NormalStepTextAtrProperty, value);
            }
        }

        public TextAttributes FocusStepTextAttr
        {
            get
            {
                return (TextAttributes)GetValue(FocusStepTextAttrProperty);
            }
            set
            {
                SetValue(FocusStepTextAttrProperty, value);
            }
        }

        public TextAttributes LeftTextAttr
        {
            get
            {
                return (TextAttributes)GetValue(leftTextAttrProperty);
            }
            set
            {
                SetValue(leftTextAttrProperty, value);
            }
        }

        public TextAttributes RightTextAttr
        {
            get
            {
                return (TextAttributes)GetValue(RightArrowIconAttrProperty);
            }
            set
            {
                SetValue(RightArrowIconAttrProperty, value);
            }
        }

        public ImageAttributes LeftArrowIconAttr
        {
            get
            {
                return (ImageAttributes)GetValue(LeftArrowIconAttrProperty);
            }
            set
            {
                SetValue(LeftArrowIconAttrProperty, value);
            }
        }

        public ImageAttributes RightArrowIconAttr
        {
            get
            {
                return (ImageAttributes)GetValue(RightArrowIconAttrProperty);
            }
            set
            {
                SetValue(RightArrowIconAttrProperty, value);
            }
        }


        //public string[] CheckImageArray
        //{
        //    get
        //    {
        //        return (ImageAttributes)GetValue(TrackImageAttributesProperty);
        //    }
        //    set
        //    {
        //        SetValue(TrackImageAttributesProperty, value);
        //    }
        //}

        public StringSelector CheckImageURL
        {
            get
            {
                return (StringSelector)GetValue(CheckImageURLProperty);
            }
            set
            {
                SetValue(CheckImageURLProperty, value);
            }
        }

        public Size StepSize
        {
            get
            {

                return stepSize;
                //return (ImageAttributes)GetValue(TrackImageAttributesProperty);
            }
            set
            {
                //SetValue(TrackImageAttributesProperty, value);
                stepSize = value;
            }
        }

        public override Attributes Clone()
        {
            return new StepIndicatorAttributes(this);
        }

    }
}
