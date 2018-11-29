using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Renderers;

namespace Tizen.NUI.Controls
{
    public class ToggleButton : BaseControl
    {
        public class ClickEventArgs : EventArgs
        {

        }

        static ToggleButton()
        {
            RegisterStyle("ToggleButton", typeof(ToggleButtonRenderer));
        }

        public ToggleButton() : base() { }
        public ToggleButton(string style) : base(style) { }

        public string[] IconURL
        {
            get
            {
                return iconURL;
            }
            set
            {
                iconURL = value;
                renderer.OnPropertyChanged("IconURL", this);
            }
        }

        public string[] Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                renderer.OnPropertyChanged("Text", this);
            }
        }

        public int CurrentStateIndex
        {
            get
            {
                return currentStateIndex;
            }
            set
            {
                currentStateIndex = value;
                renderer.OnPropertyChanged("CurrentStateIndex", this);
            }
        }

        public bool StateEnable
        {
            get
            {
                return isEnable;
            }
            set
            {
                if(value == true)
                {
                    isEnable = true;
                    
                }
            }
        }

        public event EventHandler<ClickEventArgs> ClickEvent;
        protected override BaseRenderer GetRenderer()
        {
            return new ToggleButtonRenderer();
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
                    ClickEventArgs clickEventArgs = new ClickEventArgs();
                    OnClick(clickEventArgs);
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
                ClickEventArgs clickEventArgs = new ClickEventArgs();
                if (isEnable)
                {
                    OnClick(clickEventArgs);
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

        private void OnClick(ClickEventArgs clickEventArgs)
        {
            CurrentStateIndex = (CurrentStateIndex + 1) % Text.Length;

            if (ClickEvent != null)
            {
                ClickEvent(this, clickEventArgs);
            }
            renderer.OnPropertyChanged("CurrentStateIndex", this);
        }

        private string[] iconURL;
        private string[] text;
        private int currentStateIndex;
        private bool isEnable;


    }
}
