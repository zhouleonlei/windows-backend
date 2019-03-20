using Tizen.NUI.Binding;

namespace Tizen.NUI.Controls
{
    public class SpinAttributes : ViewAttributes
    {
        public static readonly BindableProperty BackgroundImageAttributesProperty = BindableProperty.Create("BackgroundImageAttributes", typeof(ImageAttributes), typeof(SpinAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SpinAttributes)bindable;
            if (newValue != null)
            {
                attrs.backgroundImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SpinAttributes)bindable;
            return attrs.backgroundImageAttrs;
        });

		public static readonly BindableProperty TextAttrsProperty = BindableProperty.Create("TextAttrs", typeof(TextAttributes), typeof(SpinAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SpinAttributes)bindable;
            if (newValue != null)
            {
                attrs.textAttrs = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SpinAttributes)bindable;
            return attrs.textAttrs;
        });

		public static readonly BindableProperty NameTextAttrsProperty = BindableProperty.Create("NameTextAttrs", typeof(TextAttributes), typeof(SpinAttributes), default(TextAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SpinAttributes)bindable;
            if (newValue != null)
            {
                attrs.nameTextAttrs = (TextAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SpinAttributes)bindable;
            return attrs.nameTextAttrs;
        });

		public static readonly BindableProperty MaskTopImageAttributesProperty = BindableProperty.Create("MaskTopImageAttributes", typeof(ImageAttributes), typeof(SpinAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SpinAttributes)bindable;
            if (newValue != null)
            {
                attrs.maskTopImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SpinAttributes)bindable;
            return attrs.maskTopImageAttrs;
        });

		public static readonly BindableProperty MaskBottomImageAttributesProperty = BindableProperty.Create("MaskBottomImageAttributes", typeof(ImageAttributes), typeof(SpinAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SpinAttributes)bindable;
            if (newValue != null)
            {
                attrs.maskBottomImageAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SpinAttributes)bindable;
            return attrs.maskBottomImageAttrs;
        });

		public static readonly BindableProperty AniViewAttributesProperty = BindableProperty.Create("AniViewAttributes", typeof(ViewAttributes), typeof(SpinAttributes), default(ViewAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SpinAttributes)bindable;
            if (newValue != null)
            {
                attrs.aniViewAttrs = (ViewAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SpinAttributes)bindable;
            return attrs.aniViewAttrs;
        });

		public static readonly BindableProperty ClipViewAttributesProperty = BindableProperty.Create("ClipViewAttributes", typeof(ViewAttributes), typeof(SpinAttributes), default(ViewAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SpinAttributes)bindable;
            if (newValue != null)
            {
                attrs.clipViewAttrs = (ViewAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SpinAttributes)bindable;
            return attrs.clipViewAttrs;
        });
		public static readonly BindableProperty NameViewAttributesProperty = BindableProperty.Create("NameViewAttributes", typeof(ViewAttributes), typeof(SpinAttributes), default(ViewAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SpinAttributes)bindable;
            if (newValue != null)
            {
                attrs.nameViewAttrs = (ViewAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SpinAttributes)bindable;
            return attrs.nameViewAttrs;
        });

		public static readonly BindableProperty DividerRecAttrsProperty = BindableProperty.Create("DividerRecAttrs", typeof(ViewAttributes), typeof(SpinAttributes), default(ViewAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SpinAttributes)bindable;
            if (newValue != null)
            {
                attrs.dividerRecAttrs = (ViewAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SpinAttributes)bindable;
            return attrs.dividerRecAttrs;
        });

		public static readonly BindableProperty DividerRec2AttrsProperty = BindableProperty.Create("DividerRec2Attrs", typeof(ViewAttributes), typeof(SpinAttributes), default(ViewAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SpinAttributes)bindable;
            if (newValue != null)
            {
                attrs.dividerRec2Attrs = (ViewAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SpinAttributes)bindable;
            return attrs.dividerRec2Attrs;
        });

		public static readonly BindableProperty TextFieldAttrsProperty = BindableProperty.Create("TextFieldAttrs", typeof(TextFieldAttributes), typeof(SpinAttributes), default(ViewAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SpinAttributes)bindable;
            if (newValue != null)
            {
                attrs.textFieldAttrs = (TextFieldAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SpinAttributes)bindable;
            return attrs.textFieldAttrs;
        });

		public static readonly BindableProperty MinProperty = BindableProperty.Create("Min", typeof(int), typeof(SpinAttributes), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SpinAttributes)bindable;
            if (newValue != null)
            {
                attrs.min = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SpinAttributes)bindable;
            return attrs.min;
        });

		public static readonly BindableProperty MaxProperty = BindableProperty.Create("Max", typeof(int), typeof(SpinAttributes), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SpinAttributes)bindable;
            if (newValue != null)
            {
                attrs.max = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SpinAttributes)bindable;
            return attrs.max;
        });

		public static readonly BindableProperty CurProperty = BindableProperty.Create("Cur", typeof(int), typeof(SpinAttributes), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SpinAttributes)bindable;
            if (newValue != null)
            {
                attrs.cur = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SpinAttributes)bindable;
            return attrs.cur;
        });

		public static readonly BindableProperty ItemHeightProperty = BindableProperty.Create("ItemHeight", typeof(int), typeof(SpinAttributes), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SpinAttributes)bindable;
            if (newValue != null)
            {
                attrs.itemHeight = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SpinAttributes)bindable;
            return attrs.itemHeight;
        });

		public static readonly BindableProperty TextSizeProperty = BindableProperty.Create("TextSize", typeof(int), typeof(SpinAttributes), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SpinAttributes)bindable;
            if (newValue != null)
            {
                attrs.textSize = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SpinAttributes)bindable;
            return attrs.textSize;
        });
		
		public static readonly BindableProperty CenterTextSizeProperty = BindableProperty.Create("CenterTextSize", typeof(int), typeof(SpinAttributes), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (SpinAttributes)bindable;
            if (newValue != null)
            {
                attrs.centerTextSize = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (SpinAttributes)bindable;
            return attrs.centerTextSize;
        });

        private ImageAttributes backgroundImageAttrs;
		private ViewAttributes nameViewAttrs;
		private ViewAttributes clipViewAttrs;
		private ViewAttributes aniViewAttrs;
		private TextAttributes textAttrs;
		private TextAttributes nameTextAttrs;
		private ImageAttributes maskTopImageAttrs;
		private ImageAttributes maskBottomImageAttrs;
		private ViewAttributes dividerRecAttrs;
		private ViewAttributes dividerRec2Attrs;
		private TextFieldAttributes textFieldAttrs;

		private int min;
		private int max;
		private int cur;
		private int itemHeight;
		private int textSize;
		private int centerTextSize;
		
        public SpinAttributes() : base() { }
        public SpinAttributes(SpinAttributes attributes) : base(attributes)
        {
            if (attributes.backgroundImageAttrs != null)
            {
                backgroundImageAttrs = attributes.backgroundImageAttrs.Clone() as ImageAttributes;
            }

			if (attributes.textAttrs != null)
			{
				textAttrs = attributes.textAttrs.Clone() as TextAttributes;
			}

			if (attributes.nameTextAttrs != null)
			{
				nameTextAttrs = attributes.nameTextAttrs.Clone() as TextAttributes;
			}

			if (attributes.maskTopImageAttrs != null)
			{
				maskTopImageAttrs = attributes.maskTopImageAttrs.Clone() as ImageAttributes;
			}

			if (attributes.maskBottomImageAttrs != null)
			{
				maskBottomImageAttrs = attributes.maskBottomImageAttrs.Clone() as ImageAttributes;
			}

			if (attributes.aniViewAttrs != null)
			{
				aniViewAttrs = attributes.aniViewAttrs.Clone() as ViewAttributes;
			}
			
			if (attributes.clipViewAttrs != null)
			{
				clipViewAttrs = attributes.clipViewAttrs.Clone() as ViewAttributes;
			}

			if (attributes.nameViewAttrs != null)
			{
				nameViewAttrs = attributes.nameViewAttrs.Clone() as ViewAttributes;
			}

			if (attributes.dividerRecAttrs != null)
			{
				dividerRecAttrs = attributes.dividerRecAttrs.Clone() as ViewAttributes;
			}

			if (attributes.dividerRec2Attrs != null)
			{
				dividerRec2Attrs = attributes.dividerRec2Attrs.Clone() as ViewAttributes;
			}

			if (attributes.textFieldAttrs != null)
			{
				textFieldAttrs = attributes.textFieldAttrs.Clone() as TextFieldAttributes;
			}

			min = attributes.min;
			max = attributes.max;
			cur = attributes.cur;
			itemHeight = attributes.itemHeight;
			textSize = attributes.textSize;
			centerTextSize = attributes.centerTextSize;
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

		public TextAttributes TextAttrs
        {
            get
            {
                return (TextAttributes)GetValue(TextAttrsProperty);
            }
            set
            {
                SetValue(TextAttrsProperty, value);
            }
        }

		public TextAttributes NameTextAttrs
        {
            get
            {
                return (TextAttributes)GetValue(NameTextAttrsProperty);
            }
            set
            {
                SetValue(NameTextAttrsProperty, value);
            }
        }

		public ImageAttributes MaskTopImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(MaskTopImageAttributesProperty);
            }
            set
            {
                SetValue(MaskTopImageAttributesProperty, value);
            }
        }

		public ImageAttributes MaskBottomImageAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(MaskBottomImageAttributesProperty);
            }
            set
            {
                SetValue(MaskBottomImageAttributesProperty, value);
            }
        }

		public ViewAttributes AniViewAttributes
        {
            get
            {
                return (ViewAttributes)GetValue(AniViewAttributesProperty);
            }
            set
            {
                SetValue(AniViewAttributesProperty, value);
            }
        }

		public ViewAttributes ClipViewAttributes
        {
            get
            {
                return (ViewAttributes)GetValue(ClipViewAttributesProperty);
            }
            set
            {
                SetValue(ClipViewAttributesProperty, value);
            }
        }

		public ViewAttributes NameViewAttributes
        {
            get
            {
                return (ViewAttributes)GetValue(NameViewAttributesProperty);
            }
            set
            {
                SetValue(NameViewAttributesProperty, value);
            }
        }

		public ViewAttributes DividerRecAttrs
        {
            get
            {
                return (ViewAttributes)GetValue(DividerRecAttrsProperty);
            }
            set
            {
                SetValue(DividerRecAttrsProperty, value);
            }
        }

		public ViewAttributes DividerRec2Attrs
        {
            get
            {
                return (ViewAttributes)GetValue(DividerRec2AttrsProperty);
            }
            set
            {
                SetValue(DividerRec2AttrsProperty, value);
            }
        }

		public ViewAttributes TextFieldAttrs
        {
            get
            {
                return (TextFieldAttributes)GetValue(TextFieldAttrsProperty);
            }
            set
            {
                SetValue(TextFieldAttrsProperty, value);
            }
        }

		public int Min
        {
            get
            {
                return (int)GetValue(MinProperty);
            }
            set
            {
                SetValue(MinProperty, value);
            }
        }

		public int Max
        {
            get
            {
                return (int)GetValue(MaxProperty);
            }
            set
            {
                SetValue(MaxProperty, value);
            }
        }

		public int Cur
        {
            get
            {
                return (int)GetValue(CurProperty);
            }
            set
            {
                SetValue(CurProperty, value);
            }
        }

		public int ItemHeight
        {
            get
            {
                return (int)GetValue(ItemHeightProperty);
            }
            set
            {
                SetValue(ItemHeightProperty, value);
            }
        }

		public int TextSize
        {
            get
            {
                return (int)GetValue(TextSizeProperty);
            }
            set
            {
                SetValue(TextSizeProperty, value);
            }
        }

		public int CenterTextSize
        {
            get
            {
                return (int)GetValue(CenterTextSizeProperty);
            }
            set
            {
                SetValue(CenterTextSizeProperty, value);
            }
        }
        public override Attributes Clone()
        {
            return new SpinAttributes(this);
        }
    }
}
