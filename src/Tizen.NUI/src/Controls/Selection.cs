using System;
using Tizen.NUI.Renderers;

namespace Tizen.NUI.Controls
{
    public class Selection : BaseControl
    {
        public class SelectEventArgs : EventArgs
        {
            public bool CheckState
            {
                get;set;
            }
        }

        //static constructor used to register internal style
        static Selection()
        {
            RegisterStyle("Selection", typeof(SelectionRenderer));
        }

        public Selection() : base() { }
        public Selection(string style) : base(style) { }

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
        public string CheckImageURL
        {
            get
            {
                return checkImageURL;
            }
            set
            {
                if (checkImageURL != value)
                {
                    checkImageURL = value;
                    renderer.OnPropertyChanged("CheckImageURL", this);
                }
            }
        }
        public string BackgroundImageURL
        {
            get
            {
                return backgroundImageURL;
            }
            set
            {
                if (backgroundImageURL != value)
                {
                    backgroundImageURL = value;
                    renderer.OnPropertyChanged("BackgroundImageURL", this);
                }
            }
        }
        public Size2D CheckBoxSize2D
        {
            get
            {
                return checkBoxSize2D;
            }
            set
            {
                if(checkBoxSize2D != value)
                {
                    checkBoxSize2D = value;
                    renderer.OnPropertyChanged("CheckBoxSize2D", this);
                }
            }
        }
        public bool CheckState
        {
            get
            {
                return checkState;
            }
            set
            {
                if (checkState != value)
                {
                    checkState = value;
                    renderer.OnPropertyChanged("CheckState", this);
                }
            }
        }
        public event EventHandler<SelectEventArgs> SelectEvent;

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
                    SelectEventArgs eventArgs = new SelectEventArgs();
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
            SelectEventArgs eventArgs = new SelectEventArgs();
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
            return new SelectionRenderer();
        }
        private void OnClick(SelectEventArgs eventArgs)
        {
            CheckState = !CheckState;
            eventArgs.CheckState = CheckState;
            if (SelectEvent != null)
            {
                SelectEvent(this, eventArgs);
            }
        }

        private string text;
        private string backgroundImageURL;
        private string checkImageURL;
        private Size2D checkBoxSize2D = new Size2D(0, 0);
        private bool checkState = false;
    }
}
