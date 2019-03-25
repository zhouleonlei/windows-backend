using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.CommonUI
{
    public class ViewAttributes : Attributes
    {
        public static readonly BindableProperty Position2DProperty = BindableProperty.Create("Position2D", typeof(Position2D), typeof(ViewAttributes), default(Position2D), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.position2D = (Position2D)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
           var attrs = (ViewAttributes)bindable;
           return attrs.position2D;
        });
        public static readonly BindableProperty Size2DProperty = BindableProperty.Create("Size2D", typeof(Size2D), typeof(ViewAttributes), default(Size2D), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.size2D = (Size2D)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.size2D;
        });
        public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create("BackgroundColor", typeof(ColorSelector), typeof(ViewAttributes), default(ColorSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.backgroundColor = (ColorSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.backgroundColor;
        });
        public static readonly BindableProperty PositionUsesPivotPointProperty = BindableProperty.Create("PositionUsesPivotPoint", typeof(bool?), typeof(ViewAttributes), default(bool?), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.positionUsesPivotPoint = (bool?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.positionUsesPivotPoint;
        });
        public static readonly BindableProperty ParentOriginProperty = BindableProperty.Create("ParentOrigin", typeof(Position), typeof(ViewAttributes), default(Position), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.parentOrigin = (Position)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.parentOrigin;
        });
        public static readonly BindableProperty PivotPointProperty = BindableProperty.Create("PivotPoint", typeof(Position), typeof(ViewAttributes), default(Position), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.pivotPoint = (Position)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.pivotPoint;
        });
        public static readonly BindableProperty WidthResizePolicyProperty = BindableProperty.Create("WidthResizePolicy", typeof(ResizePolicyType), typeof(ViewAttributes), default(ResizePolicyType), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.widthResizePolicy = (ResizePolicyType)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.widthResizePolicy;
        });
        public static readonly BindableProperty HeightResizePolicyProperty = BindableProperty.Create("HeightResizePolicy", typeof(ResizePolicyType), typeof(ViewAttributes), default(ResizePolicyType), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.heightResizePolicy = (ResizePolicyType)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.heightResizePolicy;
        });

        public static readonly BindableProperty MinimumSizeProperty = BindableProperty.Create("MinimumSize", typeof(Size2D), typeof(ViewAttributes), default(Size2D), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.minimumSize = (Size2D)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.minimumSize;
        });
        public static readonly BindableProperty SizeModeFactorProperty = BindableProperty.Create("SizeModeFactor", typeof(Vector3), typeof(ViewAttributes), default(Vector3), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.sizeModeFactor = (Vector3)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.sizeModeFactor;
        });
        public static readonly BindableProperty OpacityProperty = BindableProperty.Create("Opacity", typeof(FloatSelector), typeof(ViewAttributes), default(FloatSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.opacity = (FloatSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.opacity;
        });

        public static readonly BindableProperty PaddingLeftProperty = BindableProperty.Create("PaddingLeft", typeof(int), typeof(ViewAttributes), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.paddingLeft = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.paddingLeft;
        });
        public static readonly BindableProperty PaddingRightProperty = BindableProperty.Create("PaddingRight", typeof(int), typeof(ViewAttributes), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.paddingRight = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.paddingRight;
        });
        public static readonly BindableProperty PaddingTopProperty = BindableProperty.Create("PaddingTop", typeof(int), typeof(ViewAttributes), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.paddingTop = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.paddingTop;
        });
        public static readonly BindableProperty PaddingBottomProperty = BindableProperty.Create("PaddingBottom", typeof(int), typeof(ViewAttributes), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.paddingBottom = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.paddingBottom;
        });

        private Position2D position2D;
        private Size2D size2D;
        private ColorSelector backgroundColor;
        private bool? positionUsesPivotPoint;
        private Position parentOrigin;
        private Position pivotPoint;
        private ResizePolicyType? widthResizePolicy;
        private ResizePolicyType? heightResizePolicy;
        private Size2D minimumSize;
        private Vector3 sizeModeFactor;
        private FloatSelector opacity;

        private int paddingLeft;
        private int paddingRight;
        private int paddingTop;
        private int paddingBottom;

        public ViewAttributes() : base() { }

        public ViewAttributes(ViewAttributes attributes)
        {
            if (attributes.position2D != null)
            {
                position2D = new Position2D(attributes.position2D.X, attributes.position2D.Y);
            }

            if (attributes.size2D != null)
            {
                size2D = new Size2D(attributes.size2D.Width, attributes.size2D.Height);
            }

            if (attributes.backgroundColor != null)
            {
                backgroundColor = attributes.backgroundColor.Clone() as ColorSelector;
            }

            if (attributes.positionUsesPivotPoint != null)
            {
                positionUsesPivotPoint = attributes.positionUsesPivotPoint;
            }

            if (attributes.parentOrigin != null)
            {
                parentOrigin = new Position(attributes.parentOrigin.X, attributes.parentOrigin.Y, attributes.parentOrigin.Z);
            }

            if (attributes.pivotPoint != null)
            {
                pivotPoint = new Position(attributes.pivotPoint.X, attributes.pivotPoint.Y, attributes.pivotPoint.Z);
            }

            if (attributes.widthResizePolicy != null)
            {
                widthResizePolicy = attributes.widthResizePolicy;
            }

            if (attributes.heightResizePolicy != null)
            {
                heightResizePolicy = attributes.heightResizePolicy;
            }

            if (attributes.minimumSize != null)
            {
                minimumSize = new Size2D(attributes.minimumSize.Width, attributes.minimumSize.Height);
            }

            if (attributes.sizeModeFactor != null)
            {
                sizeModeFactor = new Vector3(attributes.sizeModeFactor.X, attributes.sizeModeFactor.Y, attributes.sizeModeFactor.Z);
            }

            if (attributes.opacity != null)
            {
                opacity = attributes.opacity.Clone() as FloatSelector;
            }

            paddingLeft = attributes.paddingLeft;
            paddingRight = attributes.paddingRight;
            paddingTop = attributes.paddingTop;
            paddingBottom = attributes.paddingBottom;
        }

        public Position2D Position2D
        {
            get
            {
                return (Position2D)GetValue(Position2DProperty);
            }
            set
            {
                SetValue(Position2DProperty, value);
            }
        }

        public Size2D Size2D
        {
            get
            {
                return (Size2D)GetValue(Size2DProperty);
            }
            set
            {
                SetValue(Size2DProperty, value);
            }
        }

        public ColorSelector BackgroundColor
        {
            get
            {
                return (ColorSelector)GetValue(BackgroundColorProperty);
            }
            set
            {
                SetValue(BackgroundColorProperty, value);
            }
        }
        public bool? PositionUsesPivotPoint
        {
            get
            {
                return (bool?)GetValue(PositionUsesPivotPointProperty);
            }
            set
            {
                SetValue(PositionUsesPivotPointProperty, value);
            }
        }

        public Position ParentOrigin
        {
            get
            {
                return (Position)GetValue(ParentOriginProperty);
            }
            set
            {
                SetValue(ParentOriginProperty, value);
            }
        }

        public Position PivotPoint
        {
            get
            {
                return (Position)GetValue(PivotPointProperty);
            }
            set
            {
                SetValue(PivotPointProperty, value);
            }
        }

        public ResizePolicyType? WidthResizePolicy
        {
            get
            {
                return (ResizePolicyType?)GetValue(WidthResizePolicyProperty);
            }

            set
            {
                SetValue(WidthResizePolicyProperty, value);
            }
        }

        public ResizePolicyType? HeightResizePolicy
        {
            get
            {
                return (ResizePolicyType?)GetValue(HeightResizePolicyProperty);
            }

            set
            {
                SetValue(HeightResizePolicyProperty, value);
            }
        }

        public Size2D MinimumSize
        {
            get
            {
                return (Size2D)GetValue(MinimumSizeProperty);
            }
            set
            {
                SetValue(MinimumSizeProperty, value);
            }
        }

        public Vector3 SizeModeFactor
        {
            get
            {
                return (Vector3)GetValue(SizeModeFactorProperty);
            }
            set
            {
                SetValue(SizeModeFactorProperty, value);
            }
        }

        public FloatSelector Opacity
        {
            get
            {
                return (FloatSelector)GetValue(OpacityProperty);
            }

            set
            {
                SetValue(OpacityProperty, value);
            }
        }
        public int PaddingLeft
        {
            get
            {
                return (int)GetValue(PaddingLeftProperty);
            }

            set
            {
                SetValue(PaddingLeftProperty, value);
            }
        }

        public int PaddingRight
        {
            get
            {
                return (int)GetValue(PaddingRightProperty);
            }

            set
            {
                SetValue(PaddingRightProperty, value);
            }
        }

        public int PaddingTop
        {
            get
            {
                return (int)GetValue(PaddingTopProperty);
            }

            set
            {
                SetValue(PaddingTopProperty, value);
            }
        }

        public int PaddingBottom
        {
            get
            {
                return (int)GetValue(PaddingBottomProperty);
            }

            set
            {
                SetValue(PaddingBottomProperty, value);
            }
        }

        public override Attributes Clone()
        {
            return new ViewAttributes(this);
        }

    }
}
