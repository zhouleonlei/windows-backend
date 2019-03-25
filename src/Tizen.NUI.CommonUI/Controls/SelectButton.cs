using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.CommonUI
{
    public class SelectButton : Button
    {
        protected SelectGroup itemGroup = null;

        private ImageView checkShadowImage;
        private ImageView checkBackgroundImage;
        private ImageView checkImage;

        private SelectButtonAttributes selectButtonAttributes;

        public SelectButton() : base()
        {
            selectButtonAttributes = attributes as SelectButtonAttributes;
            if (selectButtonAttributes == null)
            {
                throw new Exception("SelectButton attribute parse error.");
            }
            InitializeAttributes();
        }
        public SelectButton(string style) : base(style)
        {
            selectButtonAttributes = attributes as SelectButtonAttributes;
            if (selectButtonAttributes == null)
            {
                throw new Exception("SelectButton attribute parse error.");
            }
            InitializeAttributes();
        }

        public SelectButton(SelectButtonAttributes attributes) : base()
        {
            this.attributes = selectButtonAttributes = attributes.Clone() as SelectButtonAttributes;
            InitializeAttributes();
        }

        public event EventHandler<SelectEventArgs> SelectedEvent;

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

        public string CheckImageURL
        {
            get
            {
                return selectButtonAttributes?.CheckImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckImageAttributes();
                    if (selectButtonAttributes.CheckImageAttributes.ResourceURL == null)
                    {
                        selectButtonAttributes.CheckImageAttributes.ResourceURL = new StringSelector();
                    }
                    selectButtonAttributes.CheckImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        public StringSelector CheckImageURLSelector
        {
            get
            {
                return selectButtonAttributes?.CheckImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckImageAttributes();
                    selectButtonAttributes.CheckImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        public float CheckImageOpacity
        {
            get
            {
                return selectButtonAttributes?.CheckImageAttributes?.Opacity?.All ?? 0;
            }
            set
            {
                CreateCheckImageAttributes();
                if (selectButtonAttributes.CheckImageAttributes.Opacity == null)
                {
                    selectButtonAttributes.CheckImageAttributes.Opacity = new FloatSelector();
                }
                selectButtonAttributes.CheckImageAttributes.Opacity.All = value;
                RelayoutRequest();
            }
        }

        public FloatSelector CheckImageOpacitySelector
        {
            get
            {
                return selectButtonAttributes?.CheckImageAttributes?.Opacity;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckImageAttributes();
                    selectButtonAttributes.CheckImageAttributes.Opacity = value.Clone() as FloatSelector;
                    RelayoutRequest();
                }
            }
        }

        public Size2D CheckImageSize2D
        {
            get
            {
                return selectButtonAttributes?.CheckImageAttributes?.Size2D ?? new Size2D(0, 0);
            }
            set
            {
                CreateCheckImageAttributes();
                selectButtonAttributes.CheckImageAttributes.Size2D = value;
                RelayoutRequest();
            }
        }

        public Position2D CheckImagePosition2D
        {
            get
            {
                return selectButtonAttributes?.CheckImageAttributes?.Position2D ?? new Position2D(0, 0);
            }
            set
            {
                CreateCheckImageAttributes();
                selectButtonAttributes.CheckImageAttributes.Position2D = value;
                RelayoutRequest();
            }
        }

        public string CheckBackgroundImageURL
        {
            get
            {
                return selectButtonAttributes?.CheckBackgroundImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckBackgroundImageAttributes();
                    if (selectButtonAttributes.CheckBackgroundImageAttributes.ResourceURL == null)
                    {
                        selectButtonAttributes.CheckBackgroundImageAttributes.ResourceURL = new StringSelector();
                    }
                    selectButtonAttributes.CheckBackgroundImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        public StringSelector CheckBackgroundImageURLSelector
        {
            get
            {
                return selectButtonAttributes?.CheckBackgroundImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckBackgroundImageAttributes();
                    selectButtonAttributes.CheckBackgroundImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        public float CheckBackgroundImageOpacity
        {
            get
            {
                return selectButtonAttributes?.CheckBackgroundImageAttributes?.Opacity?.All ?? 0;
            }
            set
            {
                CreateCheckBackgroundImageAttributes();
                if (selectButtonAttributes.CheckBackgroundImageAttributes.Opacity == null)
                {
                    selectButtonAttributes.CheckBackgroundImageAttributes.Opacity = new FloatSelector();
                }
                selectButtonAttributes.CheckBackgroundImageAttributes.Opacity.All = value;
                RelayoutRequest();
            }
        }

        public FloatSelector CheckBackgroundImageOpacitySelector
        {
            get
            {
                return selectButtonAttributes?.CheckBackgroundImageAttributes?.Opacity;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckBackgroundImageAttributes();
                    selectButtonAttributes.CheckBackgroundImageAttributes.Opacity = value.Clone() as FloatSelector;
                    RelayoutRequest();
                }
            }
        }

        public Size2D CheckBackgroundImageSize2D
        {
            get
            {
                return selectButtonAttributes?.CheckBackgroundImageAttributes?.Size2D ?? new Size2D(0, 0);
            }
            set
            {
                CreateCheckBackgroundImageAttributes();
                selectButtonAttributes.CheckBackgroundImageAttributes.Size2D = value;
                RelayoutRequest();
            }
        }

        public Position2D CheckBackgroundImagePosition2D
        {
            get
            {
                return selectButtonAttributes?.CheckBackgroundImageAttributes?.Position2D ?? new Position2D(0, 0);
            }
            set
            {
                CreateCheckBackgroundImageAttributes();
                selectButtonAttributes.CheckBackgroundImageAttributes.Position2D = value;
                RelayoutRequest();
            }
        }

        public string CheckShadowImageURL
        {
            get
            {
                return selectButtonAttributes?.CheckShadowImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckShadowImageAttributes();
                    if (selectButtonAttributes.CheckShadowImageAttributes.ResourceURL == null)
                    {
                        selectButtonAttributes.CheckShadowImageAttributes.ResourceURL = new StringSelector();
                    }
                    selectButtonAttributes.CheckShadowImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        public StringSelector CheckShadowImageURLSelector
        {
            get
            {
                return selectButtonAttributes?.CheckShadowImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckShadowImageAttributes();
                    selectButtonAttributes.CheckShadowImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        public float CheckShadowImageOpacity
        {
            get
            {
                return selectButtonAttributes?.CheckShadowImageAttributes?.Opacity?.All ?? 0;
            }
            set
            {
                CreateCheckShadowImageAttributes();
                if (selectButtonAttributes.CheckShadowImageAttributes.Opacity == null)
                {
                    selectButtonAttributes.CheckShadowImageAttributes.Opacity = new FloatSelector();
                }
                selectButtonAttributes.CheckShadowImageAttributes.Opacity.All = value;
                RelayoutRequest();
            }
        }

        public FloatSelector CheckShadowImageOpacitySelector
        {
            get
            {
                return selectButtonAttributes?.CheckShadowImageAttributes?.Opacity;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckShadowImageAttributes();
                    selectButtonAttributes.CheckShadowImageAttributes.Opacity = value.Clone() as FloatSelector;
                    RelayoutRequest();
                }
            }
        }

        public Size2D CheckShadowImageSize2D
        {
            get
            {
                return selectButtonAttributes?.CheckShadowImageAttributes?.Size2D ?? new Size2D(0, 0);
            }
            set
            {
                CreateCheckShadowImageAttributes();
                selectButtonAttributes.CheckShadowImageAttributes.Size2D = value;
                RelayoutRequest();
            }
        }

        public Position2D CheckShadowImagePosition2D
        {
            get
            {
                return selectButtonAttributes?.CheckShadowImageAttributes?.Position2D ?? new Position2D(0, 0);
            }
            set
            {
                selectButtonAttributes.CheckShadowImageAttributes.Position2D = value;
                RelayoutRequest();
            }
        }

        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            SelectButtonAttributes tempAttributes = StyleManager.Instance.GetAttributes(style) as SelectButtonAttributes;
            if (tempAttributes != null)
            {
                attributes = selectButtonAttributes = tempAttributes;
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
                if (checkShadowImage != null)
                {
                    Remove(checkShadowImage);
                    checkShadowImage.Dispose();
                    checkShadowImage = null;
                }
                if (checkBackgroundImage != null)
                {
                    Remove(checkBackgroundImage);
                    checkBackgroundImage.Dispose();
                    checkBackgroundImage = null;
                }
                if (checkImage != null)
                {
                    Remove(checkImage);
                    checkImage.Dispose();
                    checkImage = null;
                }
            }

            base.Dispose(type);
        }

        protected override void OnUpdate(Attributes attributtes)
        {
            selectButtonAttributes = attributes as SelectButtonAttributes;
            if (selectButtonAttributes == null)
            {
                return;
            }
            base.OnUpdate(attributtes);

            if (selectButtonAttributes.CheckShadowImageAttributes != null)
            {
                if (checkShadowImage == null)
                {
                    checkShadowImage = new ImageView();
                    checkShadowImage.Name = "CheckShadowImage";
                    Add(checkShadowImage);
                }
                ApplyAttributes(checkShadowImage, selectButtonAttributes.CheckShadowImageAttributes);
            }
            else
            {
                if (checkShadowImage != null)
                {
                    Remove(checkShadowImage);
                    checkShadowImage.Dispose();
                    checkShadowImage = null;
                }
            }

            if (selectButtonAttributes.CheckBackgroundImageAttributes != null)
            {
                if (checkBackgroundImage == null)
                {
                    checkBackgroundImage = new ImageView();
                    checkBackgroundImage.Name = "CheckBackgroundImage";
                    Add(checkBackgroundImage);
                }
                ApplyAttributes(checkBackgroundImage, selectButtonAttributes.CheckBackgroundImageAttributes);
            }
            else
            {
                if (checkBackgroundImage != null)
                {
                    Remove(checkBackgroundImage);
                    checkBackgroundImage.Dispose();
                    checkBackgroundImage = null;
                }
            }

            if (selectButtonAttributes.CheckImageAttributes != null)
            {
                if (checkImage == null)
                {
                    checkImage = new ImageView();
                    checkImage.Name = "CheckImage";
                    Add(checkImage);
                }
                ApplyAttributes(checkImage, selectButtonAttributes.CheckImageAttributes);
                checkImage.RaiseToTop();
            }
            else
            {
                if (checkImage != null)
                {
                    Remove(checkImage);
                    checkImage.Dispose();
                    checkImage = null;
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
            if (IsEnabled == false)
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
            return new SelectButtonAttributes();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior after pressing return key by user.
        /// </summary>
        protected virtual void OnSelected()
        {
        }

        private void InitializeAttributes()
        {
            selectButtonAttributes.IsSelectable = true;           
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

        private void CreateCheckImageAttributes()
        {
            if (selectButtonAttributes.CheckImageAttributes == null)
            {
                selectButtonAttributes.CheckImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint =  Tizen.NUI.PivotPoint.TopLeft,
                };
            }
        }

        private void CreateCheckBackgroundImageAttributes()
        {
            if (selectButtonAttributes.CheckBackgroundImageAttributes == null)
            {
                selectButtonAttributes.CheckBackgroundImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                };
            }
        }

        private void CreateCheckShadowImageAttributes()
        {
            if (selectButtonAttributes.CheckShadowImageAttributes == null)
            {
                selectButtonAttributes.CheckShadowImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint =  Tizen.NUI.PivotPoint.TopLeft,
                };
            }
        }

        public class SelectEventArgs : EventArgs
        {
            public bool IsSelected;
        }
    }
}
