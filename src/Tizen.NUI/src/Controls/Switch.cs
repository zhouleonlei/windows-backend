using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Controls
{
    public class Switch : Button
    {
        private ImageView switchBackgroundImage;
        private ImageView switchHandlerImage;

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
                return switchAttributes?.SwitchHandlerImageAttributes?.ParentOrigin?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateSwitchHandlerImageAttributes();
                    if (switchAttributes.SwitchHandlerImageAttributes.ParentOrigin == null)
                    {
                        switchAttributes.SwitchHandlerImageAttributes.ParentOrigin = new PositionSelector();
                    }
                    switchAttributes.SwitchHandlerImageAttributes.ParentOrigin.All = value;
                    RelayoutRequest();
                }
            }
        }

        public PositionSelector SwitchHandlerParentOriginSelector
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
                    switchAttributes.SwitchHandlerImageAttributes.ParentOrigin = value.Clone() as PositionSelector;
                    RelayoutRequest();
                }
            }
        }

        public Position SwitchHandlerPivotPoint
        {
            get
            {
                return switchAttributes?.SwitchHandlerImageAttributes?.PivotPoint?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateSwitchHandlerImageAttributes();
                    if (switchAttributes.SwitchHandlerImageAttributes.PivotPoint == null)
                    {
                        switchAttributes.SwitchHandlerImageAttributes.PivotPoint = new PositionSelector();
                    }
                    switchAttributes.SwitchHandlerImageAttributes.PivotPoint.All = value;
                    RelayoutRequest();
                }
            }
        }

        public PositionSelector SwitchHandlerPivotPointSelector
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
                    switchAttributes.SwitchHandlerImageAttributes.PivotPoint = value.Clone() as PositionSelector;
                    RelayoutRequest();
                }
            }
        }

        public Size2D SwitchBackgroundImageSize2D
        {
            get
            {
                return switchAttributes?.SwitchBackgroundImageAttributes?.Size2D?.All ?? new Size2D(0, 0);
            }
            set
            {
                CreateSwitchBackgroundImageAttributes();
                if (switchAttributes.SwitchBackgroundImageAttributes.Size2D == null)
                {
                    switchAttributes.SwitchBackgroundImageAttributes.Size2D = new Size2DSelector();
                }
                switchAttributes.SwitchBackgroundImageAttributes.Size2D.All = value;
                RelayoutRequest();
            }
        }

        public Size2D SwitchHandlerImageSize2D
        {
            get
            {
                return switchAttributes?.SwitchHandlerImageAttributes?.Size2D?.All ?? new Size2D(0, 0);
            }
            set
            {
                CreateSwitchHandlerImageAttributes();
                if (switchAttributes.SwitchHandlerImageAttributes.Size2D == null)
                {
                    switchAttributes.SwitchHandlerImageAttributes.Size2D = new Size2DSelector();
                }
                switchAttributes.SwitchHandlerImageAttributes.Size2D.All = value;
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
                    switchBackgroundImage = new ImageView();
                    switchBackgroundImage.Name = "SwitchBackgroundImage";
                    Add(switchBackgroundImage);
                }
                ApplyAttributes(switchBackgroundImage, switchAttributes.SwitchBackgroundImageAttributes);

                if (switchAttributes.SwitchHandlerImageAttributes != null)
                {
                    if (switchHandlerImage == null)
                    {
                        switchHandlerImage = new ImageView();
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

        }

        private void CreateSwitchBackgroundImageAttributes()
        {
            if (switchAttributes.SwitchBackgroundImageAttributes == null)
            {
                switchAttributes.SwitchBackgroundImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = new BoolSelector { All = true },
                    ParentOrigin = new PositionSelector { All = Tizen.NUI.ParentOrigin.TopLeft },
                    PivotPoint = new PositionSelector { All = Tizen.NUI.PivotPoint.TopLeft },
                };
            }
        }

        private void CreateSwitchHandlerImageAttributes()
        {
            if (switchAttributes.SwitchHandlerImageAttributes == null)
            {
                switchAttributes.SwitchHandlerImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = new BoolSelector { All = true },
                };
            }
        }

        private void OnSelect()
        {
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
