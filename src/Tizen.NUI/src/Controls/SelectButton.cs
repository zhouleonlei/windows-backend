using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Controls
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
            Initialize();
        }
        public SelectButton(string style) : base(style)
        {
            Initialize();
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

            ApplyAttributes(checkShadowImage, selectButtonAttributes.CheckShadowImageAttributes);
            ApplyAttributes(checkBackgroundImage, selectButtonAttributes.CheckBackgroundImageAttributes);
            ApplyAttributes(checkImage, selectButtonAttributes.CheckImageAttributes);           
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

        /// <summary>
        /// Overrides this method if want to handle behavior after pressing return key by user.
        /// </summary>
        protected virtual void OnSelected()
        {
        }

        private void Initialize()
        {
            selectButtonAttributes = attributes as SelectButtonAttributes;
            if (selectButtonAttributes == null)
            {
                throw new Exception("SelectButton attribute parse error.");
            }

            selectButtonAttributes.IsSelectable = true;

            if (selectButtonAttributes.CheckShadowImageAttributes != null)
            {
                checkShadowImage = new ImageView();
                checkShadowImage.Name = "CheckShadowImage";
                Add(checkShadowImage);
            }

            if (selectButtonAttributes.CheckBackgroundImageAttributes != null)
            {
                checkBackgroundImage = new ImageView();
                checkBackgroundImage.Name = "CheckBackgroundImage";
                Add(checkBackgroundImage);
            }

            if (selectButtonAttributes.CheckImageAttributes != null)
            {
                checkImage = new ImageView();
                checkImage.Name = "CheckImage";
                Add(checkImage);
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
