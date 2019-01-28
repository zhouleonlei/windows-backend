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

        public Button() : base()
        {
            Initialize();
        }
        public Button(string style) : base(style)
        {
            Initialize();
        }

        public Button(ButtonAttributes attributes) : base()
        {
            this.attributes = buttonAttributes = attributes.Clone() as ButtonAttributes;
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

        public bool IsSelectable
        {
            get
            {
                return buttonAttributes?.IsSelectable ?? false;
            }
            set
            {
                buttonAttributes.IsSelectable = value;
            }
        }

        public new Color BackgroundColor
        {
            get
            {
                return buttonAttributes?.BackgroundColor.All;
            }
            set
            {
                if (value != null)
                {
                    if (buttonAttributes.BackgroundColor == null)
                    {
                        buttonAttributes.BackgroundColor = new ColorSelector();
                    }
                    buttonAttributes.BackgroundColor.All = value;
                    RelayoutRequest();
                }
            }
        }

        public string BackgroundImageURL
        {
            get
            {
                return buttonAttributes?.BackgroundImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateBackgroundAttributes();
                    if (buttonAttributes.BackgroundImageAttributes.ResourceURL == null)
                    {
                        buttonAttributes.BackgroundImageAttributes.ResourceURL = new StringSelector();
                    }
                    buttonAttributes.BackgroundImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        public Rectangle BackgroundImageBorder
        {
            get
            {
                return buttonAttributes?.BackgroundImageAttributes?.Border?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateBackgroundAttributes();
                    if (buttonAttributes.BackgroundImageAttributes.Border == null)
                    {
                        buttonAttributes.BackgroundImageAttributes.Border = new RectangleSelector();
                    }
                    buttonAttributes.BackgroundImageAttributes.Border.All = value;
                    RelayoutRequest();
                }
            }
        }
        public string ShadowImageURL
        {
            get
            {
                return buttonAttributes?.ShadowImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateShadowAttributes();
                    if (buttonAttributes.ShadowImageAttributes.ResourceURL == null)
                    {
                        buttonAttributes.ShadowImageAttributes.ResourceURL = new StringSelector();
                    }
                    buttonAttributes.ShadowImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }
        public Rectangle ShadowImageBorder
        {
            get
            {
                return buttonAttributes?.ShadowImageAttributes?.Border?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateShadowAttributes();
                    if (buttonAttributes.ShadowImageAttributes.Border == null)
                    {
                        buttonAttributes.ShadowImageAttributes.Border = new RectangleSelector();
                    }
                    buttonAttributes.ShadowImageAttributes.Border.All = value;
                    RelayoutRequest();
                }
            }
        }

        public string OverlayImageURL
        {
            get
            {
                return buttonAttributes?.OverlayImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateOverlayAttributes();
                    if (buttonAttributes.OverlayImageAttributes.ResourceURL == null)
                    {
                        buttonAttributes.OverlayImageAttributes.ResourceURL = new StringSelector();
                    }
                    buttonAttributes.OverlayImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        public Rectangle OverlayImageBorder
        {
            get
            {
                return buttonAttributes?.OverlayImageAttributes?.Border?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateOverlayAttributes();
                    if (buttonAttributes.OverlayImageAttributes.Border == null)
                    {
                        buttonAttributes.OverlayImageAttributes.Border = new RectangleSelector();
                    }
                    buttonAttributes.OverlayImageAttributes.Border.All = value;
                    RelayoutRequest();
                }
            }
        }

        public float OverlayImageOpacity
        {
            get
            {
                return buttonAttributes?.OverlayImageAttributes?.Opacity?.All ?? 0.0f;
            }
            set
            {
                CreateOverlayAttributes();
                if (buttonAttributes.OverlayImageAttributes.Opacity == null)
                {
                    buttonAttributes.OverlayImageAttributes.Opacity = new FloatSelector();
                }
                buttonAttributes.OverlayImageAttributes.Opacity.All = value;
                RelayoutRequest();
            }
        }

        public string Text
        {
            get
            {
                return buttonAttributes?.TextAttributes?.Text?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateTextAttributes();
                    if(buttonAttributes.TextAttributes.Text == null)
                    {
                        buttonAttributes.TextAttributes.Text = new StringSelector();
                    }
                    buttonAttributes.TextAttributes.Text.All = value;

                    RelayoutRequest();
                }
            }
        }

        public string TranslatableText
        {
            get
            {
                return buttonAttributes?.TextAttributes?.TranslatableText?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateTextAttributes();
                    if (buttonAttributes.TextAttributes.TranslatableText == null)
                    {
                        buttonAttributes.TextAttributes.TranslatableText = new StringSelector();
                    }
                    buttonAttributes.TextAttributes.TranslatableText.All = value;

                    RelayoutRequest();
                }
            }
        }

        public float PointSize
        {
            get
            {
                return buttonAttributes?.TextAttributes?.PointSize?.All ?? 0;
            }
            set
            {
                CreateTextAttributes();
                if (buttonAttributes.TextAttributes.PointSize == null)
                {
                    buttonAttributes.TextAttributes.PointSize = new FloatSelector();
                }
                buttonAttributes.TextAttributes.PointSize.All = value;
                RelayoutRequest();
            }
        }

        public string FontFamily
        {
            get
            {
                return buttonAttributes?.TextAttributes?.FontFamily?.All;
            }
            set
            {
                CreateTextAttributes();
                if (buttonAttributes.TextAttributes.FontFamily == null)
                {
                    buttonAttributes.TextAttributes.FontFamily = new StringSelector();
                }
                buttonAttributes.TextAttributes.FontFamily.All = value;
                RelayoutRequest();
            }
        }

        public Color TextColor
        {
            get
            {
                return buttonAttributes?.TextAttributes?.TextColor?.All;
            }
            set
            {
                CreateTextAttributes();
                if (buttonAttributes.TextAttributes.TextColor == null)
                {
                    buttonAttributes.TextAttributes.TextColor = new ColorSelector();
                }
                buttonAttributes.TextAttributes.TextColor.All = value;
                RelayoutRequest();
            }
        }

        public HorizontalAlignment TextAlignment
        {
            get
            {
                return buttonAttributes?.TextAttributes?.HorizontalAlignment?.All ?? HorizontalAlignment.Center;
            }
            set
            {
                CreateTextAttributes();
                if (buttonAttributes.TextAttributes.HorizontalAlignment == null)
                {
                    buttonAttributes.TextAttributes.HorizontalAlignment = new HorizontalAlignmentSelector();
                }
                buttonAttributes.TextAttributes.HorizontalAlignment.All = value;
                RelayoutRequest();
            }
        }

        public string IconURL
        {
            get
            {
                return buttonAttributes?.IconAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateIconAttributes();
                    if (buttonAttributes.IconAttributes.ResourceURL == null)
                    {
                        buttonAttributes.IconAttributes.ResourceURL = new StringSelector();
                    }
                    buttonAttributes.IconAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        public StringSelector TextSelector
        {
            get
            {
                return buttonAttributes?.TextAttributes?.Text;
            }
            set
            {
                if (value != null)
                {
                    CreateTextAttributes();
                    buttonAttributes.TextAttributes.Text = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }
        public StringSelector TranslatableTextSelector
        {
            get
            {
                return buttonAttributes?.TextAttributes?.TranslatableText;
            }
            set
            {
                if (value != null)
                {
                    CreateTextAttributes();
                    buttonAttributes.TextAttributes.TranslatableText = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        public ColorSelector TextColorSelector
        {
            get
            {
                return buttonAttributes?.TextAttributes?.TextColor;
            }
            set
            {
                if(value != null)
                {
                    CreateTextAttributes();
                    buttonAttributes.TextAttributes.TextColor = value.Clone() as ColorSelector;
                    RelayoutRequest();
                }
            }
        }

        public FloatSelector FontSizeSelector
        {
            get
            {
                return buttonAttributes?.TextAttributes?.PointSize;
            }
            set
            {
                if (value != null)
                {
                    CreateTextAttributes();
                    buttonAttributes.TextAttributes.PointSize = value.Clone() as FloatSelector;
                    RelayoutRequest();
                }
            }
        }

        public StringSelector FontFamilySelector
        {
            get
            {
                return buttonAttributes?.TextAttributes?.FontFamily;
            }
            set
            {
                if (value != null)
                {
                    CreateTextAttributes();
                    buttonAttributes.TextAttributes.FontFamily = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        public HorizontalAlignmentSelector TextAlignmentSelector
        {
            get
            {
                return buttonAttributes?.TextAttributes?.HorizontalAlignment;
            }
            set
            {
                CreateTextAttributes();
                buttonAttributes.TextAttributes.HorizontalAlignment = value;
                RelayoutRequest();
            }
        }

        public StringSelector IconURLSelector
        {
            get
            {
                return buttonAttributes?.IconAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateTextAttributes();
                    buttonAttributes.IconAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        public StringSelector BackgroundImageURLSelector
        {
            get
            {
                return buttonAttributes?.BackgroundImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateBackgroundAttributes();
                    buttonAttributes.BackgroundImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }
        public RectangleSelector BackgroundImageBorderSelector
        {
            get
            {
                return buttonAttributes?.BackgroundImageAttributes?.Border;
            }
            set
            {
                if (value != null)
                {
                    CreateBackgroundAttributes();
                    buttonAttributes.BackgroundImageAttributes.Border = value.Clone() as RectangleSelector;
                    RelayoutRequest();
                }
            }
        }

        public StringSelector ShadowImageURLSelector
        {
            get
            {
                return buttonAttributes?.ShadowImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateShadowAttributes();
                    buttonAttributes.ShadowImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }
        public RectangleSelector ShadowImageBorderSelector
        {
            get
            {
                return buttonAttributes?.ShadowImageAttributes?.Border;
            }
            set
            {
                if (value != null)
                {
                    CreateShadowAttributes();
                    buttonAttributes.ShadowImageAttributes.Border = value.Clone() as RectangleSelector;
                    RelayoutRequest();
                }
            }
        }

        public StringSelector OverlayImageURLSelector
        {
            get
            {
                return buttonAttributes?.OverlayImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateOverlayAttributes();
                    buttonAttributes.OverlayImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }
        public RectangleSelector OverlayImageBorderSelector
        {
            get
            {
                return buttonAttributes?.OverlayImageAttributes?.Border;
            }
            set
            {
                if (value != null)
                {
                    CreateOverlayAttributes();
                    buttonAttributes.OverlayImageAttributes.Border = value.Clone() as RectangleSelector;
                    RelayoutRequest();
                }
            }
        }

        public FloatSelector OverlayImageOpacitySelector
        {
            get
            {
                return buttonAttributes?.OverlayImageAttributes?.Opacity;
            }
            set
            {
                if (value != null)
                {
                    CreateOverlayAttributes();
                    buttonAttributes.OverlayImageAttributes.Opacity = value.Clone() as FloatSelector;
                    RelayoutRequest();
                }
            }
        }

        public ColorSelector BackgroundColorSelector
        {
            get
            {
                return buttonAttributes?.BackgroundColor;
            }
            set
            {
                if (value != null)
                {
                    buttonAttributes.BackgroundColor = value.Clone() as ColorSelector;
                    RelayoutRequest();
                }
            }
        }
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
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
                    if (buttonAttributes.IsSelectable != null && buttonAttributes.IsSelectable == true)
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
                    if (buttonAttributes.IsSelectable != null && buttonAttributes.IsSelectable == true)
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
            return new ButtonAttributes();
        }

        protected override void OnUpdate(Attributes attributtes)
        {
            buttonAttributes = attributes as ButtonAttributes;
            if (buttonAttributes == null)
            {
                return;
            }

            ApplyAttributes(this, buttonAttributes);

            if (buttonAttributes.ShadowImageAttributes != null)
            {
                if(shadowImage == null)
                {
                    shadowImage = new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent
                    };
                    this.Add(shadowImage);
                }
                /////////////// Shadow  ///////////////////////
                ApplyAttributes(shadowImage, buttonAttributes.ShadowImageAttributes);
            }

            if (buttonAttributes.BackgroundImageAttributes != null)
            {
                if(backgroundImage == null)
                {
                    backgroundImage = new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent
                    };
                    this.Add(backgroundImage);
                }
                /////////////// Background ////////////////////
                ApplyAttributes(backgroundImage, buttonAttributes.BackgroundImageAttributes);
            }

            if (buttonAttributes.OverlayImageAttributes != null)
            {
                if(overlayImage == null)
                {
                    overlayImage = new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent
                    };
                    this.Add(overlayImage);
                }
                /////////////// Overlay ///////////////////////
                ApplyAttributes(overlayImage, buttonAttributes.OverlayImageAttributes);
            }

            if (buttonAttributes.TextAttributes != null)
            {
                if(buttonText == null)
                {
                    buttonText = new TextLabel();
                    this.Add(buttonText);
                }
                /////////////// Text //////////////////////////
                ApplyAttributes(buttonText, buttonAttributes.TextAttributes);
            }

            if (buttonAttributes.IconAttributes != null)
            {
                if(buttonIcon == null)
                {
                    buttonIcon = new ImageView();
                    this.Add(buttonIcon);
                }
                /////////////// Icon //////////////////////////
                ApplyAttributes(buttonIcon, buttonAttributes.IconAttributes);
            }

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
            if(sourceState != targetState)
            {
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
        }

        private void Initialize()
        {
            buttonAttributes = attributes as ButtonAttributes;
            if (buttonAttributes == null)
            {
                throw new Exception("Button attribute parse error.");
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

        private void CreateBackgroundAttributes()
        {
            if (buttonAttributes.BackgroundImageAttributes == null)
            {
                buttonAttributes.BackgroundImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = new BoolSelector { All = true },
                    ParentOrigin = new PositionSelector { All = Tizen.NUI.ParentOrigin.Center },
                    PivotPoint = new PositionSelector { All = Tizen.NUI.PivotPoint.Center },
                    WidthResizePolicy = new ResizePolicyTypeSelector { All = ResizePolicyType.FillToParent },
                    HeightResizePolicy = new ResizePolicyTypeSelector { All = ResizePolicyType.FillToParent}
                };
            }
        }

        private void CreateShadowAttributes()
        {
            if (buttonAttributes.ShadowImageAttributes == null)
            {
                buttonAttributes.ShadowImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = new BoolSelector { All = true },
                    ParentOrigin = new PositionSelector { All = Tizen.NUI.ParentOrigin.Center },
                    PivotPoint = new PositionSelector { All = Tizen.NUI.PivotPoint.Center },
                    WidthResizePolicy = new ResizePolicyTypeSelector { All = ResizePolicyType.FillToParent },
                    HeightResizePolicy = new ResizePolicyTypeSelector { All = ResizePolicyType.FillToParent }
                };
            }
        }

        private void CreateOverlayAttributes()
        {
            if (buttonAttributes.OverlayImageAttributes == null)
            {
                buttonAttributes.OverlayImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = new BoolSelector { All = true },
                    ParentOrigin = new PositionSelector { All = Tizen.NUI.ParentOrigin.Center },
                    PivotPoint = new PositionSelector { All = Tizen.NUI.PivotPoint.Center },
                    WidthResizePolicy = new ResizePolicyTypeSelector { All = ResizePolicyType.FillToParent },
                    HeightResizePolicy = new ResizePolicyTypeSelector { All = ResizePolicyType.FillToParent }
                };
            }
        }

        private void CreateTextAttributes()
        {
            if (buttonAttributes.TextAttributes == null)
            {
                buttonAttributes.TextAttributes = new TextAttributes()
                {
                    PositionUsesPivotPoint = new BoolSelector { All = true },
                    ParentOrigin = new PositionSelector { All = Tizen.NUI.ParentOrigin.Center },
                    PivotPoint = new PositionSelector { All = Tizen.NUI.PivotPoint.Center },
                    HorizontalAlignment = new HorizontalAlignmentSelector { All = HorizontalAlignment.Center},
                    VerticalAlignment = new VerticalAlignmentSelector { All = VerticalAlignment.Center}
                };
            }
        }

        private void CreateIconAttributes()
        {
            if (buttonAttributes.IconAttributes == null)
            {
                buttonAttributes.IconAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = new BoolSelector { All = true },
                    ParentOrigin = new PositionSelector { All = Tizen.NUI.ParentOrigin.Center },
                    PivotPoint = new PositionSelector { All = Tizen.NUI.PivotPoint.Center },
                    WidthResizePolicy = new ResizePolicyTypeSelector { All = ResizePolicyType.UseNaturalSize },
                    HeightResizePolicy = new ResizePolicyTypeSelector { All = ResizePolicyType.UseNaturalSize },
                };
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
