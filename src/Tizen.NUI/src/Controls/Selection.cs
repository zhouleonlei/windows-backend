using System;
using Tizen.NUI.Renderers;

namespace Tizen.NUI.Controls
{
    /// <summary>
    /// Selection is the abstract class that represent the base control which can be selected or unselected.
    /// This control is base of checkbox and radio button.
    /// </summary>
    /// <code>
    /// Refer to CheckBox and RadioButton
    /// </code>
    public class Selection : BaseControl
    {
        /// <summary>
        /// 
        /// </summary>
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
            //RegisterStyle("Selection", typeof(SelectionRenderer));
        }

        /// <summary>
        /// 
        /// </summary>
        public Selection() : base() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="style"></param>
        public Selection(string style) : base(style) { }
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        public Size2D SelectBoxSize2D
        {
            get
            {
                return selectBoxSize2D;
            }
            set
            {
                if(selectBoxSize2D != value)
                {
                    selectBoxSize2D = value;
                    renderer.OnPropertyChanged("CheckBoxSize2D", this);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// Index of selection in selection group. If selection is not in the group, return -1;
        /// </summary>
        public int Index
        {
            get
            {
                if (itemGroup != null)
                {
                    return itemGroup.GetIndex(this);
                }

                return -1;
            }
        }
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// Overrides this method if want to handle behavior after pressing return key by user.
        /// </summary>
        protected virtual void OnSelected()
        {
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
            OnSelected();
            if (SelectEvent != null)
            {
                eventArgs.CheckState = checkState;
                SelectEvent(this, eventArgs);
            }
        }

        private string text;
        private string backgroundImageURL;
        private string checkImageURL;
        private Size2D selectBoxSize2D = new Size2D(0, 0);
        private bool checkState = false;

        protected SelectionGroup itemGroup = null;
    }
}
