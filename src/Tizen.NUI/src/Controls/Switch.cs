using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Renderers;

namespace Tizen.NUI.Controls
{
    public class Switch : BaseControl
    {
        public enum OnOffStates
        {
            OffState,
            OnState
        }

        public class SwitchEventArgs : EventArgs
        {
            public OnOffStates OnOffState;
        }

        static Switch()
        {
            RegisterStyle("Switch", typeof(SwitchRenderer));
        }

        public Switch() : base() { }
        public Switch(string style) : base(style) { }

        public string[] OnImageArray
        {
            get
            {
                return onImageArray;
            }
            set
            {
                onImageArray = value;
                renderer.OnPropertyChanged("OnImageArray", this);
            }
        }

        public string[] OffImageArray
        {
            get
            {
                return offImageArray;
            }
            set
            {
                offImageArray = value;
                renderer.OnPropertyChanged("OffImageArray", this);
            }
        }

        public OnOffStates CurrentState
        {
            get
            {
                return currentState;
            }
            set
            {
                currentState = value;
                renderer.OnPropertyChanged("CurrentState", this);
            }
        }

        public Size2D SwitchSize2D
        {
            get
            {
                return switchSize2D;
            }
            set
            {
                if (switchSize2D != value)
                {
                    switchSize2D = value;
                    renderer.OnPropertyChanged("SwitchSize2D", this);
                }
            }
        }

        public bool IsEnable
        {
            get
            {
                return isEnable;
            }
            set
            {
                isEnable = value;
                if (isEnable)
                {
                    renderer.OnStateChanged(States.Normal);
                }
                else
                {
                    renderer.OnStateChanged(States.Disabled);
                }

            }
        }

        public event EventHandler<EventArgs> StateChangeEvent;

        protected override BaseRenderer GetRenderer()
        {
            return new SwitchRenderer();
        }

        protected override void OnRelayout(object sender, EventArgs e)
        {
            renderer.OnPropertyChanged("Size", this);
            base.OnRelayout(sender, e);
        }

        protected override bool OnKey(object source, KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Return")
                {
                    State = States.Pressed;
                    SwitchEventArgs switchEventArgs = new SwitchEventArgs();
                    OnClick(switchEventArgs);
                }
            }
            else
            {
                if (e.Key.KeyPressedName == "Return")
                {
                    State = States.Focused;
                }
            }

            return base.OnKey(source, e);
        }

        protected override void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
            TapGesture tapGesture = e.TapGesture;

            if (tapGesture.NumberOfTaps == 1)
            {
                SwitchEventArgs switchEventArgs = new SwitchEventArgs();
                if (isEnable)
                {
                    OnClick(switchEventArgs);
                }

            }
        }

        protected override void OnFocusGained(object sender, EventArgs e)
        {
            State = States.Focused;
            base.OnFocusGained(sender, e);
        }

        protected override void OnFocusLost(object sender, EventArgs e)
        {
            State = States.Normal;
            base.OnFocusLost(sender, e);
        }

        protected override bool OnTouch(object source, TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                State = States.Pressed;
            }

            switch (state)
            {
                case PointStateType.Down:
                    State = States.Pressed;
                    break;
                case PointStateType.Interrupted:
                case PointStateType.Up:
                    State = States.Normal;
                    break;
                default:
                    break;
            }

            return base.OnTouch(source, e);
        }

        private void OnClick(SwitchEventArgs switchEventArgs)
        {
            CurrentState = currentState == OnOffStates.OnState ? OnOffStates.OffState : OnOffStates.OnState;

            if (StateChangeEvent != null)
            {
                StateChangeEvent(this, switchEventArgs);
                renderer.OnPropertyChanged("CurrentState", this);
            }
        }

        private Size2D switchSize2D = new Size2D(0, 0);
        private string[] onImageArray = null;
        private string[] offImageArray = null;
        private OnOffStates currentState;
        private bool isEnable = true;


    }
}

