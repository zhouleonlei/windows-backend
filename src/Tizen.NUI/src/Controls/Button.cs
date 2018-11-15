using System;
using Tizen.NUI.Renderers;

namespace Tizen.NUI.Controls
{
    public class Button : BaseControl
    {
        public class ClickEventArgs : EventArgs
        {
            
        }

        //static constructor used to register internal style
        static Button()
        {
            RegisterStyle("Text", typeof(TextButtonRenderer));
            RegisterStyle("Icon", typeof(IconButtonRenderer));
        }

        public Button() : base() { }
        public Button(string style) : base(style) { }

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                if(text != value)
                {
                    text = value;
                    renderer.OnPropertyChanged("Text", this);
                }
            }
        }
        public string IconURL
        {
            get
            {
                return iconURL;
            }
            set
            {
                if (iconURL != value)
                {
                    iconURL = value;
                    renderer.OnPropertyChanged("IconURL", this);
                }
            }
        }
        public Size2D IconSize2D
        {
            get
            {
                return iconSize2D;
            }
            set
            {
                if(iconSize2D != value)
                {
                    iconSize2D = value;
                    renderer.OnPropertyChanged("IconSize2D", this);
                }
            }
        }
        public event EventHandler<ClickEventArgs> ClickEvent;

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
                    ClickEventArgs eventArgs = new ClickEventArgs();
                    OnClick(eventArgs);
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
        protected override void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
            ClickEventArgs eventArgs = new ClickEventArgs();
            OnClick(eventArgs);
            base.OnTapGestureDetected(source, e);
        }
        protected override bool OnTouch(object source, TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                State = States.Pressed;
            }
            switch(state)
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
        protected override BaseRenderer GetRenderer()
        {
            return new TextButtonRenderer();
        }
        private void OnClick(ClickEventArgs eventArgs)
        {
            if (ClickEvent != null)
            {
                ClickEvent(this, eventArgs);
            }
        }

        private string text;
        private string iconURL;
        private Size2D iconSize2D = new Size2D(0, 0);

    }
}
