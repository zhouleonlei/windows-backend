using Tizen.NUI.Binding;

namespace Tizen.NUI.Controls
{
    public class Selector<T> : Element
    {
        public static readonly BindableProperty AllProperty = BindableProperty.Create("All", typeof(T), typeof(Selector<T>), default(T), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var selector = (Selector<T>)bindable;
            if (newValue != null)
            {
                selector.all = (T)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var selector = (Selector<T>)bindable;
            return selector.all;
        });

        public static readonly BindableProperty NormalProperty = BindableProperty.Create("Normal", typeof(T), typeof(Selector<T>), default(T), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var selector = (Selector<T>)bindable;
            if (newValue != null)
            {
                selector.normal = (T)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var selector = (Selector<T>)bindable;
            return selector.normal;
        });

        public static readonly BindableProperty FocusedProperty = BindableProperty.Create("Focused", typeof(T), typeof(Selector<T>), default(T), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var selector = (Selector<T>)bindable;
            if (newValue != null)
            {
                selector.focused = (T)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var selector = (Selector<T>)bindable;
            return selector.focused;
        });
        public static readonly BindableProperty PressedProperty = BindableProperty.Create("Pressed", typeof(T), typeof(Selector<T>), default(T), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var selector = (Selector<T>)bindable;
            if (newValue != null)
            {
                selector.pressed = (T)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var selector = (Selector<T>)bindable;
            return selector.pressed;
        });


        public static readonly BindableProperty SelectedProperty = BindableProperty.Create("Selected", typeof(T), typeof(Selector<T>), default(T), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var selector = (Selector<T>)bindable;
            if (newValue != null)
            {
                selector.selected = (T)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var selector = (Selector<T>)bindable;
            return selector.selected;
        });
        public static readonly BindableProperty DisabledProperty = BindableProperty.Create("Disabled", typeof(T), typeof(Selector<T>), default(T), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var selector = (Selector<T>)bindable;
            if (newValue != null)
            {
                selector.disabled = (T)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var selector = (Selector<T>)bindable;
            return selector.disabled;
        });



        public static readonly BindableProperty DisabledFocusedProperty = BindableProperty.Create("DisabledFocused", typeof(T), typeof(Selector<T>), default(T), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var selector = (Selector<T>)bindable;
            if (newValue != null)
            {
                selector.disabledFocused = (T)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var selector = (Selector<T>)bindable;
            return selector.disabledFocused;
        });

        public static readonly BindableProperty DisabledSelectedProperty = BindableProperty.Create("DisabledSelected", typeof(T), typeof(Selector<T>), default(T), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var selector = (Selector<T>)bindable;
            if (newValue != null)
            {
                selector.disabledSelected = (T)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var selector = (Selector<T>)bindable;
            return selector.disabledSelected;
        });

        public static readonly BindableProperty OtherProperty = BindableProperty.Create("Other", typeof(T), typeof(Selector<T>), default(T), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var selector = (Selector<T>)bindable;
            if (newValue != null)
            {
                selector.other = (T)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var selector = (Selector<T>)bindable;
            return selector.other;
        });

        private T all;
        private T normal;
        private T focused;
        private T pressed;
        private T disabled;
        private T selected;
        private T disabledFocused;
        private T disabledSelected;
        private T other;


        public T All
        {
            get
            {
                return (T)GetValue(AllProperty);
            }
            set
            {
                SetValue(AllProperty, value);
            }
        }

        public T Normal
        {
            get
            {
                return (T)GetValue(NormalProperty);
            }
            set
            {
                SetValue(NormalProperty, value);
            }
        }
        public T Pressed
        {
            get
            {
                return (T)GetValue(PressedProperty);
            }
            set
            {
                SetValue(PressedProperty, value);
            }
        }

        public T Focused
        {
            get
            {
                return (T)GetValue(FocusedProperty);
            }
            set
            {
                SetValue(FocusedProperty, value);
            }
        }
        public T Selected
        {
            get
            {
                return (T)GetValue(SelectedProperty);
            }
            set
            {
                SetValue(SelectedProperty, value);
            }
        }
        public T Disabled
        {
            get
            {
                return (T)GetValue(DisabledProperty);
            }
            set
            {
                SetValue(DisabledProperty, value);
            }
        }
        public T DisabledFocused
        {
            get
            {
                return (T)GetValue(DisabledFocusedProperty);
            }
            set
            {
                SetValue(DisabledFocusedProperty, value);
            }
        }

        public T DisabledSelected
        {
            get
            {
                return (T)GetValue(DisabledSelectedProperty);
            }
            set
            {
                SetValue(DisabledSelectedProperty, value);
            }
        }

        public T Other
        {
            get
            {
                return (T)GetValue(OtherProperty);
            }
            set
            {
                SetValue(OtherProperty, value);
            }
        }

        public T GetValue(States state)
        {
            if(all != null)
            {
                return all;
            }
            switch(state)
            {
                case States.Normal:
                    return normal;
                case States.Focused:
                    return focused;
                case States.Pressed:
                    return pressed;
                case States.Disabled:
                    return disabled;
                case States.Selected:
                    return selected;
                case States.DisabledFocused:
                    return disabledFocused;
                case States.DisabledSelected:
                    return disabledSelected;
                default:
                    return other;
            }

        }

        public void Clone(Selector<T> selector)
        {
            all = selector.all;
            normal = selector.normal;
            focused = selector.focused;
            pressed = selector.pressed;
            disabled = selector.disabled;
            selected = selector.selected;
            disabledSelected = selector.disabledSelected;
            disabledFocused = selector.disabledFocused;
            other = selector.other;
        }

    }

    [TypeConverter(typeof(IntSelectorConverter))]
    public class IntSelector : Selector<int?>
    {
        public IntSelector Clone()
        {
            IntSelector selector = new IntSelector();
            selector.Clone(this);
            return selector;
        }
    }


    [TypeConverter(typeof(FloatSelectorConverter))]
    public class FloatSelector : Selector<float?>
    {
        public FloatSelector Clone()
        {
            FloatSelector selector = new FloatSelector();
            selector.Clone(this);
            return selector;
        }
    }

    [TypeConverter(typeof(BoolSelectorConverter))]
    public class BoolSelector : Selector<bool?>
    {
        public BoolSelector Clone()
        {
            BoolSelector selector = new BoolSelector();
            selector.Clone(this);
            return selector;
        }
    }

    [TypeConverter(typeof(StringSelectorConverter))]
    public class StringSelector : Selector<string>
    {
        public StringSelector Clone()
        {
            StringSelector selector = new StringSelector();
            selector.Clone(this);
            return selector; 
        }
    }

    [TypeConverter(typeof(ColorSelectorConverter))]
    public class ColorSelector : Selector<Color>
    {
        public ColorSelector Clone()
        {
            ColorSelector selector = new ColorSelector();
            selector.Clone(this);
            return selector;
        }
    }

    [TypeConverter(typeof(Size2DSelectorConverter))]
    public class Size2DSelector : Selector<Size2D>
    {
        public Size2DSelector Clone()
        {
            Size2DSelector selector = new Size2DSelector();
            selector.Clone(this);
            return selector;
        }
    }

    [TypeConverter(typeof(Position2DSelectorConverter))]
    public class Position2DSelector : Selector<Position2D>
    {
        public Position2DSelector Clone()
        {
            Position2DSelector selector = new Position2DSelector();
            selector.Clone(this);
            return selector;
        }
    }

    [TypeConverter(typeof(PositionSelectorConverter))]
    public class PositionSelector : Selector<Position>
    {
        public PositionSelector Clone()
        {
            PositionSelector selector = new PositionSelector();
            selector.Clone(this);
            return selector;
        }
    }

    [TypeConverter(typeof(Vector2SelectorConverter))]
    public class Vector2Selector : Selector<Vector2>
    {
        public Vector2Selector Clone()
        {
            Vector2Selector selector = new Vector2Selector();
            selector.Clone(this);
            return selector;
        }
    }

    [TypeConverter(typeof(Vector3SelectorConverter))]
    public class Vector3Selector : Selector<Vector3>
    {
        public Vector3Selector Clone()
        {
            Vector3Selector selector = new Vector3Selector();
            selector.Clone(this);
            return selector;
        }
    }

    [TypeConverter(typeof(RectangleSelectorConverter))]
    public class RectangleSelector : Selector<Rectangle>
    {
        public RectangleSelector Clone()
        {
            RectangleSelector selector = new RectangleSelector();
            selector.Clone(this);
            return selector;
        }
    }

    [TypeConverter(typeof(HorizontalAlignmentSelectorConverter))]
    public class HorizontalAlignmentSelector : Selector<HorizontalAlignment?>
    {
        public HorizontalAlignmentSelector Clone()
        {
            HorizontalAlignmentSelector selector = new HorizontalAlignmentSelector();
            selector.Clone(this);
            return selector;
        }
    }

    [TypeConverter(typeof(VerticalAlignmentSelectorConverter))]
    public class VerticalAlignmentSelector : Selector<VerticalAlignment?>
    {
        public VerticalAlignmentSelector Clone()
        {
            VerticalAlignmentSelector selector = new VerticalAlignmentSelector();
            selector.Clone(this);
            return selector;
        }
    }

    [TypeConverter(typeof(AutoScrollStopModeSelectorConverter))]
    public class AutoScrollStopModeSelector : Selector<AutoScrollStopMode?>
    {
        public AutoScrollStopModeSelector Clone()
        {
            AutoScrollStopModeSelector selector = new AutoScrollStopModeSelector();
            selector.Clone(this);
            return selector;
        }
    }

    [TypeConverter(typeof(ResizePolicyTypeSelectorConverter))]
    public class ResizePolicyTypeSelector : Selector<ResizePolicyType?>
    {
        public ResizePolicyTypeSelector Clone()
        {
            ResizePolicyTypeSelector selector = new ResizePolicyTypeSelector();
            selector.Clone(this);
            return selector;
        }
    }

}
