using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.CommonUI
{
    public class Switch : Button
    {
        private const int aniTime = 100; // will be defined in const file later
        private ImageView switchBackgroundImage;
        private ImageView switchHandlerImage;
        private Animation handlerAni = null;
        private SwitchAttributes switchAttributes;

        public Switch() : base()
        {
            Initialize();
        }
        public Switch(string style) : base(style)
        {
            Initialize();
        }
        public Switch(SwitchAttributes attrs) : base(attrs)
        {
            Initialize();
        }

        public event EventHandler<SelectEventArgs> SelectedEvent;

        public string SwitchBackgroundImageURL
        {
            get
            {
                return switchAttributes?.SwitchBackgroundImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateSwitchBackgroundImageAttributes();
                    if (switchAttributes.SwitchBackgroundImageAttributes.ResourceURL == null)
                    {
                        switchAttributes.SwitchBackgroundImageAttributes.ResourceURL = new StringSelector();
                    }
                    switchAttributes.SwitchBackgroundImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        public StringSelector SwitchBackgroundImageURLSelector
        {
            get
            {
                return switchAttributes?.SwitchBackgroundImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateSwitchBackgroundImageAttributes();
                    switchAttributes.SwitchBackgroundImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        public string SwitchHandlerImageURL
        {
            get
            {
                return switchAttributes?.SwitchHandlerImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateSwitchHandlerImageAttributes();
                    if (switchAttributes.SwitchHandlerImageAttributes.ResourceURL == null)
                    {
                        switchAttributes.SwitchHandlerImageAttributes.ResourceURL = new StringSelector();
                    }
                    switchAttributes.SwitchHandlerImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        public StringSelector SwitchHandlerImageURLSelector
        {
            get
            {
                return switchAttributes?.SwitchHandlerImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateSwitchHandlerImageAttributes();
                    switchAttributes.SwitchHandlerImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        public Position SwitchHandlerParentOrigin
        {
            get
            {
                return switchAttributes?.SwitchHandlerImageAttributes?.ParentOrigin;
            }
            set
            {
                if (value != null)
                {
                    CreateSwitchHandlerImageAttributes();
                    switchAttributes.SwitchHandlerImageAttributes.ParentOrigin = value;
                    RelayoutRequest();
                }
            }
        }

        public Position SwitchHandlerPivotPoint
        {
            get
            {
                return switchAttributes?.SwitchHandlerImageAttributes?.PivotPoint;
            }
            set
            {
                if (value != null)
                {
                    CreateSwitchHandlerImageAttributes();
                    switchAttributes.SwitchHandlerImageAttributes.PivotPoint = value;
                    RelayoutRequest();
                }
            }
        }

        public Size2D SwitchBackgroundImageSize2D
        {
            get
            {
                return switchAttributes?.SwitchBackgroundImageAttributes?.Size2D ?? new Size2D(0, 0);
            }
            set
            {
                CreateSwitchBackgroundImageAttributes();
                switchAttributes.SwitchBackgroundImageAttributes.Size2D = value;
                RelayoutRequest();
            }
        }

        public Size2D SwitchHandlerImageSize2D
        {
            get
            {
                return switchAttributes?.SwitchHandlerImageAttributes?.Size2D ?? new Size2D(0, 0);
            }
            set
            {
                CreateSwitchHandlerImageAttributes();
                switchAttributes.SwitchHandlerImageAttributes.Size2D = value;
                RelayoutRequest();
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
                if (handlerAni != null)
                {
                    if (handlerAni.State == Animation.States.Playing)
                    {
                        handlerAni.Stop();
                    }
                    handlerAni.Dispose();
                    handlerAni = null;
                }

                if (switchHandlerImage != null)
                {
                    switchBackgroundImage.Remove(switchHandlerImage);
                    switchHandlerImage.Dispose();
                    switchHandlerImage = null;
                }
                if (switchBackgroundImage != null)
                {
                    Remove(switchBackgroundImage);
                    switchBackgroundImage.Dispose();
                    switchBackgroundImage = null;
                }
            }

            base.Dispose(type);
        }

        protected override void OnUpdate(Attributes attributtes)
        {
            switchAttributes = attributes as SwitchAttributes;
            if (switchAttributes == null)
            {
                return;
            }
            base.OnUpdate(attributtes);

            if (switchAttributes.SwitchBackgroundImageAttributes != null)
            {
                if (switchBackgroundImage == null)
                {
                    switchBackgroundImage = new ImageView()
                    {
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                        PositionUsesPivotPoint = true,
                    };
                    switchBackgroundImage.Name = "SwitchBackgroundImage";
                    Add(switchBackgroundImage);
                }
                ApplyAttributes(switchBackgroundImage, switchAttributes.SwitchBackgroundImageAttributes);

                if (switchAttributes.SwitchHandlerImageAttributes != null)
                {
                    if (switchHandlerImage == null)
                    {
                        switchHandlerImage = new ImageView()
                        {
                            ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                            PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                            PositionUsesPivotPoint = true,
                        };
                        switchHandlerImage.Name = "SwitchHandlerImage";
                        switchBackgroundImage.Add(switchHandlerImage);
                    }
                    ApplyAttributes(switchHandlerImage, switchAttributes.SwitchHandlerImageAttributes);
                }
            }                          
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
            return new SwitchAttributes();
        }

        private void Initialize()
        {
            switchAttributes = attributes as SwitchAttributes;
            if (switchAttributes == null)
            {
                throw new Exception("Switch attribute parse error.");
            }

            switchAttributes.IsSelectable = true;
            CreateHandlerAnimation();
        }

        private void CreateSwitchBackgroundImageAttributes()
        {
            if (switchAttributes.SwitchBackgroundImageAttributes == null)
            {
                switchAttributes.SwitchBackgroundImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                };
            }
        }

        private void CreateSwitchHandlerImageAttributes()
        {
            if (switchAttributes.SwitchHandlerImageAttributes == null)
            {
                switchAttributes.SwitchHandlerImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                };
            }
        }

        private void CreateHandlerAnimation()
        {
            if (handlerAni == null)
            {
                handlerAni = new Animation(aniTime);
            }
        }

        private void OnSelect()
        {
            if (handlerAni.State == Animation.States.Playing)
            {
                handlerAni.Stop();
            }
            handlerAni.Clear();
            if (switchHandlerImage != null)
            {
                handlerAni.AnimateTo(switchHandlerImage, "PositionX", Size2D.Width - switchHandlerImage.Size2D.Width - switchHandlerImage.Position2D.X);
            }
            if (switchBackgroundImage != null)
            {
                switchBackgroundImage.Opacity = 0.5f; ///////need defined by UX
                handlerAni.AnimateTo(switchBackgroundImage, "Opacity", 1);
            }
            handlerAni.Play();

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
