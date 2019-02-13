using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Controls
{
    public class ViewAttributes : Attributes
    {
        public static readonly BindableProperty Position2DProperty = BindableProperty.Create("Position2D", typeof(Position2DSelector), typeof(ViewAttributes), default(Position2DSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.position2D = (Position2DSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
           var attrs = (ViewAttributes)bindable;
           return attrs.position2D;
        });
        public static readonly BindableProperty Size2DProperty = BindableProperty.Create("Size2D", typeof(Size2DSelector), typeof(ViewAttributes), default(Size2DSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.size2D = (Size2DSelector)newValue;
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
        public static readonly BindableProperty PositionUsesPivotPointProperty = BindableProperty.Create("PositionUsesPivotPoint", typeof(BoolSelector), typeof(ViewAttributes), default(BoolSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.positionUsesPivotPoint = (BoolSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.positionUsesPivotPoint;
        });
        public static readonly BindableProperty ParentOriginProperty = BindableProperty.Create("ParentOrigin", typeof(PositionSelector), typeof(ViewAttributes), default(PositionSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.parentOrigin = (PositionSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.parentOrigin;
        });
        public static readonly BindableProperty PivotPointProperty = BindableProperty.Create("PivotPoint", typeof(PositionSelector), typeof(ViewAttributes), default(PositionSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.pivotPoint = (PositionSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.pivotPoint;
        });
        public static readonly BindableProperty WidthResizePolicyProperty = BindableProperty.Create("WidthResizePolicy", typeof(ResizePolicyTypeSelector), typeof(ViewAttributes), default(ResizePolicyTypeSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.widthResizePolicy = (ResizePolicyTypeSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.widthResizePolicy;
        });
        public static readonly BindableProperty HeightResizePolicyProperty = BindableProperty.Create("HeightResizePolicy", typeof(ResizePolicyTypeSelector), typeof(ViewAttributes), default(ResizePolicyTypeSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.heightResizePolicy = (ResizePolicyTypeSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.heightResizePolicy;
        });

        public static readonly BindableProperty MinimumSizeProperty = BindableProperty.Create("MinimumSize", typeof(Size2DSelector), typeof(ViewAttributes), default(Size2DSelector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.minimumSize = (Size2DSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.minimumSize;
        });
        public static readonly BindableProperty SizeModeFactorProperty = BindableProperty.Create("SizeModeFactor", typeof(Vector3Selector), typeof(ViewAttributes), default(Vector3Selector), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.sizeModeFactor = (Vector3Selector)newValue;
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

        public static readonly BindableProperty PaddingLeftProperty = BindableProperty.Create("PaddingLeft", typeof(IntSelector), typeof(ViewAttributes), default(Selector<int?>), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.paddingLeft = (IntSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.paddingLeft;
        });
        public static readonly BindableProperty PaddingRightProperty = BindableProperty.Create("PaddingRight", typeof(IntSelector), typeof(ViewAttributes), default(Selector<int?>), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.paddingRight = (IntSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.paddingRight;
        });
        public static readonly BindableProperty PaddingTopProperty = BindableProperty.Create("PaddingTop", typeof(IntSelector), typeof(ViewAttributes), default(Selector<int?>), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.paddingTop = (IntSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.paddingTop;
        });
        public static readonly BindableProperty PaddingBottomProperty = BindableProperty.Create("PaddingBottom", typeof(IntSelector), typeof(ViewAttributes), default(Selector<int?>), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.paddingBottom = (IntSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.paddingBottom;
        });
        public static readonly BindableProperty MarginLeftProperty = BindableProperty.Create("MarginLeft", typeof(IntSelector), typeof(ViewAttributes), default(Selector<int?>), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.marginLeft = (IntSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.marginLeft;
        });
        public static readonly BindableProperty MarginRightProperty = BindableProperty.Create("MarginRight", typeof(IntSelector), typeof(ViewAttributes), default(Selector<int?>), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.marginRight = (IntSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.marginRight;
        });
        public static readonly BindableProperty MarginTopProperty = BindableProperty.Create("MarginTop", typeof(IntSelector), typeof(ViewAttributes), default(Selector<int?>), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.marginTop = (IntSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.marginTop;
        });
        public static readonly BindableProperty MarginBottomProperty = BindableProperty.Create("MarginBottom", typeof(IntSelector), typeof(ViewAttributes), default(Selector<int?>), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (ViewAttributes)bindable;
            if (newValue != null)
            {
                attrs.marginBottom = (IntSelector)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (ViewAttributes)bindable;
            return attrs.marginBottom;
        });

        private Position2DSelector position2D;
        private Size2DSelector size2D;
        private ColorSelector backgroundColor;
        private BoolSelector positionUsesPivotPoint;
        private PositionSelector parentOrigin;
        private PositionSelector pivotPoint;
        private ResizePolicyTypeSelector widthResizePolicy;
        private ResizePolicyTypeSelector heightResizePolicy;
        private Size2DSelector minimumSize;
        private Vector3Selector sizeModeFactor;
        private FloatSelector opacity;

        private IntSelector paddingLeft;
        private IntSelector paddingRight;
        private IntSelector paddingTop;
        private IntSelector paddingBottom;
        private IntSelector marginLeft;
        private IntSelector marginRight;
        private IntSelector marginTop;
        private IntSelector marginBottom;

        public ViewAttributes() : base() { }

        public ViewAttributes(ViewAttributes attributes)
        {
            if (attributes.position2D != null)
            {
                position2D = attributes.position2D.Clone() as Position2DSelector;
            }

            if (attributes.size2D != null)
            {
                size2D = attributes.size2D.Clone() as Size2DSelector;
            }

            if (attributes.backgroundColor != null)
            {
                backgroundColor = attributes.backgroundColor.Clone() as ColorSelector;
            }

            if (attributes.positionUsesPivotPoint != null)
            {
                positionUsesPivotPoint = attributes.positionUsesPivotPoint.Clone() as BoolSelector;
            }

            if (attributes.parentOrigin != null)
            {
                parentOrigin = attributes.parentOrigin.Clone() as PositionSelector;
            }

            if (attributes.pivotPoint != null)
            {
                pivotPoint = attributes.pivotPoint.Clone() as PositionSelector;
            }

            if (attributes.widthResizePolicy != null)
            {
                widthResizePolicy = attributes.widthResizePolicy.Clone() as ResizePolicyTypeSelector;
            }

            if (attributes.heightResizePolicy != null)
            {
                heightResizePolicy = attributes.heightResizePolicy.Clone() as ResizePolicyTypeSelector;
            }

            if (attributes.minimumSize != null)
            {
                minimumSize = attributes.minimumSize.Clone() as Size2DSelector;
            }

            if (attributes.sizeModeFactor != null)
            {
                sizeModeFactor = attributes.sizeModeFactor.Clone() as Vector3Selector;
            }

            if (attributes.opacity != null)
            {
                opacity = attributes.opacity.Clone() as FloatSelector;
            }

            if (attributes.paddingLeft != null)
            {
                paddingLeft = attributes.paddingLeft.Clone() as IntSelector;
            }

            if (attributes.paddingRight != null)
            {
                paddingRight = attributes.paddingRight.Clone() as IntSelector;
            }

            if (attributes.paddingTop != null)
            {
                paddingTop = attributes.paddingTop.Clone() as IntSelector;
            }

            if (attributes.paddingBottom != null)
            {
                paddingBottom = attributes.paddingBottom.Clone() as IntSelector;
            }

            if (attributes.marginLeft != null)
            {
                marginLeft = attributes.marginLeft.Clone() as IntSelector;
            }

            if (attributes.marginRight != null)
            {
                marginRight = attributes.marginRight.Clone() as IntSelector;
            }

            if (attributes.marginTop != null)
            {
                marginTop = attributes.marginTop.Clone() as IntSelector;
            }

            if (attributes.marginBottom != null)
            {
                marginBottom = attributes.marginBottom.Clone() as IntSelector;
            }
        }

        public Position2DSelector Position2D
        {
            get
            {
                return (Position2DSelector)GetValue(Position2DProperty);
            }
            set
            {
                SetValue(Position2DProperty, value);
            }
        }

        public Size2DSelector Size2D
        {
            get
            {
                return (Size2DSelector)GetValue(Size2DProperty);
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
        public BoolSelector PositionUsesPivotPoint
        {
            get
            {
                return (BoolSelector)GetValue(PositionUsesPivotPointProperty);
            }
            set
            {
                SetValue(PositionUsesPivotPointProperty, value);
            }
        }

        public PositionSelector ParentOrigin
        {
            get
            {
                return (PositionSelector)GetValue(ParentOriginProperty);
            }
            set
            {
                SetValue(ParentOriginProperty, value);
            }
        }

        public PositionSelector PivotPoint
        {
            get
            {
                return (PositionSelector)GetValue(PivotPointProperty);
            }
            set
            {
                SetValue(PivotPointProperty, value);
            }
        }

        public ResizePolicyTypeSelector WidthResizePolicy
        {
            get
            {
                return (ResizePolicyTypeSelector)GetValue(WidthResizePolicyProperty);
            }

            set
            {
                SetValue(WidthResizePolicyProperty, value);
            }
        }

        public ResizePolicyTypeSelector HeightResizePolicy
        {
            get
            {
                return (ResizePolicyTypeSelector)GetValue(HeightResizePolicyProperty);
            }

            set
            {
                SetValue(HeightResizePolicyProperty, value);
            }
        }

        public Size2DSelector MinimumSize
        {
            get
            {
                return (Size2DSelector)GetValue(MinimumSizeProperty);
            }
            set
            {
                SetValue(MinimumSizeProperty, value);
            }
        }

        public Vector3Selector SizeModeFactor
        {
            get
            {
                return (Vector3Selector)GetValue(SizeModeFactorProperty);
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
        public IntSelector PaddingLeft
        {
            get
            {
                return (IntSelector)GetValue(PaddingLeftProperty);
            }

            set
            {
                SetValue(PaddingLeftProperty, value);
            }
        }

        public IntSelector PaddingRight
        {
            get
            {
                return (IntSelector)GetValue(PaddingRightProperty);
            }

            set
            {
                SetValue(PaddingRightProperty, value);
            }
        }

        public IntSelector PaddingTop
        {
            get
            {
                return (IntSelector)GetValue(PaddingTopProperty);
            }

            set
            {
                SetValue(PaddingTopProperty, value);
            }
        }

        public IntSelector PaddingBottom
        {
            get
            {
                return (IntSelector)GetValue(PaddingBottomProperty);
            }

            set
            {
                SetValue(PaddingBottomProperty, value);
            }
        }

        public IntSelector MarginLeft
        {
            get
            {
                return (IntSelector)GetValue(MarginLeftProperty);
            }

            set
            {
                SetValue(MarginLeftProperty, value);
            }
        }

        public IntSelector MarginRight
        {
            get
            {
                return (IntSelector)GetValue(MarginRightProperty);
            }

            set
            {
                SetValue(MarginRightProperty, value);
            }
        }

        public IntSelector MarginTop
        {
            get
            {
                return (IntSelector)GetValue(MarginTopProperty);
            }

            set
            {
                SetValue(MarginTopProperty, value);
            }
        }

        public IntSelector MarginBottom
        {
            get
            {
                return (IntSelector)GetValue(MarginBottomProperty);
            }

            set
            {
                SetValue(MarginBottomProperty, value);
            }
        }

        public override Attributes Clone()
        {
            return new ViewAttributes(this);
        }

    }
}
