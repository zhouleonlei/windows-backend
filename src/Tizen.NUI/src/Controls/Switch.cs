using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Controls
{
    public class Switch : Button
    {
        private ImageView switchBackgroundImage;
        private ImageView switchHandlerImage;

        private SwitchAttributes switchAttributes;
        //static constructor used to register internal style
        static Switch()
        {
            RegisterStyle("Switch", typeof(SwitchAttributes));
        }

        public Switch() : this("Switch") { }
        public Switch(string style) : base(style)
        {
            Initialize();
        }

        public event EventHandler<SelectEventArgs> SelectedEvent;

        public new bool IsSelected
        {
            get
            {
                return base.IsSelected;
            }
            set
            {
                base.IsSelected = value;
            }
        }

        protected override void OnUpdate(Attributes attributtes)
        {
            switchAttributes = attributes as SwitchAttributes;
            if (switchAttributes == null)
            {
                return;
            }
            base.OnUpdate(attributtes);

            ApplyAttributes(switchBackgroundImage, switchAttributes.SwitchBackgroundImageAttributes);
            ApplyAttributes(switchHandlerImage, switchAttributes.SwitchHandlerImageAttributes);           
        }

        protected override bool OnKey(object source, KeyEventArgs e)
        {
            if (IsEnabled == false)
            {
                return false;
            }
            bool ret = base.OnKey(source, e);
            if (e.Key.State == Key.StateType.Up)
            {
                if (e.Key.KeyPressedName == "Return")
                {
                    OnSelect();
                }
            }

            return ret;
        }

        protected override bool OnTouch(object source, TouchEventArgs e)
        {
            if(IsEnabled == false)
            {
                return false;
            }
            PointStateType state = e.Touch.GetState(0);
            bool ret = base.OnTouch(source, e);
            switch (state)
            {
                case PointStateType.Up:
                    OnSelect();
                    break;
                default:
                    break;
            }
            return ret;
        }

        protected override Attributes GetAttributes()
        {
            return null;
        }

        /// <summary>
        /// Overrides this method if want to handle behavior after pressing return key by user.
        /// </summary>
        protected virtual void OnSelected()
        {
        }

        private void Initialize()
        {
            switchAttributes = attributes as SwitchAttributes;
            if (switchAttributes == null)
            {
                throw new Exception("Switch attribute parse error.");
            }

            switchAttributes.IsSelectable = true;

            if (switchAttributes.SwitchBackgroundImageAttributes != null)
            {
                switchBackgroundImage = new ImageView();
                switchBackgroundImage.Name = "SwitchBackgroundImage";
                Add(switchBackgroundImage);
            }

            if (switchAttributes.SwitchHandlerImageAttributes != null)
            {
                switchHandlerImage = new ImageView();
                switchHandlerImage.Name = "SwitchHandlerImage";
                Add(switchHandlerImage);
            }
        }

        private void OnSelect()
        {    
            OnSelected();

            if (SelectedEvent != null)
            {
                SelectEventArgs eventArgs = new SelectEventArgs();
                eventArgs.IsSelected = IsSelected;
                SelectedEvent(this, eventArgs);
            }
        }

        public class SelectEventArgs : EventArgs
        {
            public bool IsSelected;
        }
    }
}
