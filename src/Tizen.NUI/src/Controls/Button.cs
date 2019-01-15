using System;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Controls
{
    public class Button : Control
    {
        private ImageView backgroundImage;
        private ImageView shadowImage;
        private ImageView overlayImage;

        private TextLabel buttonText;
        private ImageView buttonIcon;

        private ButtonAttributes buttonAttributes;
        private EventHandler<StateChangeEventArgs> stateChangeHander;
        private Dictionary<KeyValuePair<States, States>, Action> stateActionTable;

        private bool isSelected = false;
        private bool isEnabled = true;
        private bool isPressed = false;

        //static constructor used to register internal style
        static Button()
        {
            RegisterStyle("Text", typeof(ButtonAttributes));
        }

        public Button() : this("Text") { }
        public Button(string style) : base(style)
        {
            Initialize();
        }

        public event EventHandler<ClickEventArgs> ClickEvent;
        public event EventHandler<StateChangeEventArgs> StateChangedEvent
        {
            add
            {
                stateChangeHander += value;
            }
            remove
            {
                stateChangeHander -= value;
            }
        }

        public string Text
        {
            get
            {
                return buttonText?.Text;
            }
            set
            {
                if(buttonText != null)
                {
                    buttonText.Text = value;
                }
            }
        }

        public string IconURL
        {
            get
            {
                return buttonIcon?.ResourceUrl;
            }
            set
            {
                if (buttonIcon != null)
                {
                    buttonIcon.ResourceUrl = value;
                }
            }
        }

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            internal set
            {
                isSelected = value;
                UpdateState();
            }
        }

        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
                UpdateState();
            }
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (buttonIcon != null)
                {
                    this.Remove(buttonIcon);
                    buttonIcon.Dispose();
                    buttonIcon = null;
                }
                if (buttonText != null)
                {
                    this.Remove(buttonText);
                    buttonText.Dispose();
                    buttonText = null;
                }
                if (overlayImage != null)
                {
                    this.Remove(overlayImage);
                    overlayImage.Dispose();
                    overlayImage = null;
                }
                if (backgroundImage != null)
                {
                    this.Remove(backgroundImage);
                    backgroundImage.Dispose();
                    backgroundImage = null;
                }
                if (shadowImage != null)
                {
                    this.Remove(shadowImage);
                    shadowImage.Dispose();
                    shadowImage = null;
                }
            }

            base.Dispose(type);
        }
     
        protected override bool OnKey(object source, KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Return")
                {
                    isPressed = true;
                    UpdateState();
                    if(isEnabled)
                    {
                        ClickEventArgs eventArgs = new ClickEventArgs();
                        OnClick(eventArgs);
                    }
                }
            }
            else
            {
                if (e.Key.KeyPressedName == "Return")
                {
                    isPressed = false;
                    if (buttonAttributes.IsSelectable.Value)
                    {
                        isSelected = !isSelected;
                    }
                    UpdateState();
                }
            }
            return base.OnKey(source, e);
        }
        protected override void OnFocusGained(object sender, EventArgs e)
        {
            base.OnFocusGained(sender, e);
            UpdateState();
        }
        protected override void OnFocusLost(object sender, EventArgs e)
        {
            base.OnFocusLost(sender, e);
            UpdateState();
        }
        protected override void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
            if (isEnabled)
            {
                ClickEventArgs eventArgs = new ClickEventArgs();
                OnClick(eventArgs);
                base.OnTapGestureDetected(source, e);
            }
        }
        protected override bool OnTouch(object source, TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
      
            switch(state)
            {
                case PointStateType.Down:
                    isPressed = true;
                    UpdateState();
                    return true;
                case PointStateType.Interrupted:
                    isPressed = false;
                    UpdateState();
                    return true;
                case PointStateType.Up:
                    isPressed = false;
                    if (buttonAttributes.IsSelectable.Value)
                    {
                        isSelected = !isSelected;
                    }
                    UpdateState();
                    return true;
                default:
                    break;
            }
            return base.OnTouch(source, e);
        }
        protected override Attributes GetAttributes()
        {
            return null;
        }

        protected override void OnRelayout(object sender, EventArgs e)
        {
            UpdateState();
        }

        protected override void OnUpdate(Attributes attributtes)
        {
            buttonAttributes = attributes as ButtonAttributes;
            if (buttonAttributes == null)
            {
                return;
            }

            ApplyAttributes(this, buttonAttributes);

            /////////////// Background ////////////////////
            ApplyAttributes(backgroundImage, buttonAttributes.BackgroundImageAttributes);


            /////////////// Shadow  ///////////////////////
            ApplyAttributes(shadowImage, buttonAttributes.ShadowImageAttributes);

            /////////////// Overlay ///////////////////////
            ApplyAttributes(overlayImage, buttonAttributes.OverlayImageAttributes);

            /////////////// Text //////////////////////////
            ApplyAttributes(buttonText, buttonAttributes.TextAttributes);

            /////////////// Icon //////////////////////////
            ApplyAttributes(buttonIcon, buttonAttributes.IconAttributes);
        }

        protected void UpdateState()
        {
            States sourceState = State;
            States targetState;

            if(isEnabled)
            {
                targetState = isPressed ? States.Pressed : (IsFocused ? (IsSelected ? States.SelectedFocused : States.Focused) : (IsSelected ? States.Selected : States.Normal));
            }
            else
            {
                targetState = IsSelected ? States.DisabledSelected : (IsFocused ? States.DisabledFocused : States.Disabled);
            }
            
            State = targetState;

            OnUpdate(attributes);

            StateChangeEventArgs e = new StateChangeEventArgs
            {
                PreviousState = sourceState,
                CurrentState = targetState
            };
            stateChangeHander?.Invoke(this, e);

            PlayMotion(sourceState, targetState);
        }

        private void Initialize()
        {
            buttonAttributes = attributes as ButtonAttributes;
            if (buttonAttributes == null)
            {
                throw new Exception("Button attribute parse error.");
            }

            StateFocusableOnTouchMode = true;
            LeaveRequired = true;
            //default settings
            if (buttonAttributes.ShadowImageAttributes != null)
            {
                shadowImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
                this.Add(shadowImage);
            }

            if (buttonAttributes.BackgroundImageAttributes != null)
            {
                backgroundImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
                this.Add(backgroundImage);
            }

            if (buttonAttributes.OverlayImageAttributes != null)
            {
                overlayImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
                this.Add(overlayImage);
            }

            if (buttonAttributes.TextAttributes != null)
            {
                buttonText = new TextLabel();
                this.Add(buttonText);
            }

            if (buttonAttributes.IconAttributes != null)
            {
                buttonIcon = new ImageView();
                this.Add(buttonIcon);
            }

        }

        private void PlayMotion(States sourceState, States targetState)
        {
            KeyValuePair<States, States> command = new KeyValuePair<States, States>(sourceState, targetState);
            if (stateActionTable != null && stateActionTable.ContainsKey(command))
            {
                stateActionTable[command].Invoke();
            }
        }

        private void OnClick(ClickEventArgs eventArgs)
        {
            if (ClickEvent != null)
            {
                ClickEvent(this, eventArgs);
            }
        }

        public class ClickEventArgs : EventArgs
        {

        }

        public class StateChangeEventArgs : EventArgs
        {
            /// <summary> previous state of Button </summary>
            public States PreviousState;
            /// <summary> current state of Button </summary>
            public States CurrentState;
        }

    }
}
