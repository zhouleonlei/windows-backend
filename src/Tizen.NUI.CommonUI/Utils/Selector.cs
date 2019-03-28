namespace Tizen.NUI.CommonUI
{
    public class Selector<T>
    {
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
            get;
            set;
        }

        public T Normal
        {
            get;
            set;
        }
        public T Pressed
        {
            get;
            set;
        }

        public T Focused
        {
            get;
            set;
        }
        public T Selected
        {
            get;
            set;
        }
        public T Disabled
        {
            get;
            set;
        }
        public T DisabledFocused
        {
            get;
            set;
        }

        public T DisabledSelected
        {
            get;
            set;
        }

        public T Other
        {
            get;
            set;
        }

        public T GetValue(ControlStates state)
        {
            if(All != null)
            {
                return All;
            }
            switch(state)
            {
                case ControlStates.Normal:
                    return Normal != null? Normal : Other;
                case ControlStates.Focused:
                    return Focused != null? Focused : Other;
                case ControlStates.Pressed:
                    return Pressed != null? Pressed : Other;
                case ControlStates.Disabled:
                    return Disabled != null? Disabled : Other;
                case ControlStates.Selected:
                    return Selected != null? Selected : Other;
                case ControlStates.DisabledFocused:
                    return DisabledFocused != null? DisabledFocused : Other;
                case ControlStates.DisabledSelected:
                    return DisabledSelected != null? DisabledSelected : Other;
                default:
                    return Other;
            }
        }

        public void Clone(Selector<T> selector)
        {
            All = selector.All;
            Normal = selector.Normal;
            Focused = selector.Focused;
            Pressed = selector.Pressed;
            Disabled = selector.Disabled;
            Selected = selector.Selected;
            DisabledSelected = selector.DisabledSelected;
            DisabledFocused = selector.DisabledFocused;
            Other = selector.Other;
        }

    }

    public class IntSelector : Selector<int?>
    {
        public IntSelector Clone()
        {
            IntSelector selector = new IntSelector();
            selector.Clone(this);
            return selector;
        }
    }


    public class FloatSelector : Selector<float?>
    {
        public FloatSelector Clone()
        {
            FloatSelector selector = new FloatSelector();
            selector.Clone(this);
            return selector;
        }
    }

    public class BoolSelector : Selector<bool?>
    {
        public BoolSelector Clone()
        {
            BoolSelector selector = new BoolSelector();
            selector.Clone(this);
            return selector;
        }
    }

    public class StringSelector : Selector<string>
    {
        public StringSelector Clone()
        {
            StringSelector selector = new StringSelector();
            selector.Clone(this);
            return selector; 
        }
    }

    public class ColorSelector : Selector<Color>
    {
        public ColorSelector Clone()
        {
            ColorSelector selector = new ColorSelector();
            selector.Clone(this);
            return selector;
        }
    }

    public class Size2DSelector : Selector<Size2D>
    {
        public Size2DSelector Clone()
        {
            Size2DSelector selector = new Size2DSelector();
            selector.Clone(this);
            return selector;
        }
    }

    public class Position2DSelector : Selector<Position2D>
    {
        public Position2DSelector Clone()
        {
            Position2DSelector selector = new Position2DSelector();
            selector.Clone(this);
            return selector;
        }
    }

    public class PositionSelector : Selector<Position>
    {
        public PositionSelector Clone()
        {
            PositionSelector selector = new PositionSelector();
            selector.Clone(this);
            return selector;
        }
    }

    public class Vector2Selector : Selector<Vector2>
    {
        public Vector2Selector Clone()
        {
            Vector2Selector selector = new Vector2Selector();
            selector.Clone(this);
            return selector;
        }
    }

    public class Vector3Selector : Selector<Vector3>
    {
        public Vector3Selector Clone()
        {
            Vector3Selector selector = new Vector3Selector();
            selector.Clone(this);
            return selector;
        }
    }

    public class RectangleSelector : Selector<Rectangle>
    {
        public RectangleSelector Clone()
        {
            RectangleSelector selector = new RectangleSelector();
            selector.Clone(this);
            return selector;
        }
    }

    public class HorizontalAlignmentSelector : Selector<HorizontalAlignment?>
    {
        public HorizontalAlignmentSelector Clone()
        {
            HorizontalAlignmentSelector selector = new HorizontalAlignmentSelector();
            selector.Clone(this);
            return selector;
        }
    }

    public class VerticalAlignmentSelector : Selector<VerticalAlignment?>
    {
        public VerticalAlignmentSelector Clone()
        {
            VerticalAlignmentSelector selector = new VerticalAlignmentSelector();
            selector.Clone(this);
            return selector;
        }
    }

    public class AutoScrollStopModeSelector : Selector<AutoScrollStopMode?>
    {
        public AutoScrollStopModeSelector Clone()
        {
            AutoScrollStopModeSelector selector = new AutoScrollStopModeSelector();
            selector.Clone(this);
            return selector;
        }
    }

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
