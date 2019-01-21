using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Controls
{
    public class InputField : Control
    {
        private ImageView bgImage = null;
        private TextField textField = null;
        private ImageView cancelBtn = null;
        private ImageView deleteBtn = null;
        private ImageView addBtnBg = null;
        private ImageView addBtnOverlay = null;
        private ImageView addBtnTop = null;
        private InputFieldAttributes inputFieldAttrs = null;

        private string text = null;
        private string hintText = null;
        private bool isFocused = false;
        private bool isPressed = false;
        private bool isEnabled = true;

        private EventHandler<CancelBtnClickArgs> cancelBtnClickHandler;
        private EventHandler<DeleteBtnClickArgs> deleteBtnClickHandler;
        private EventHandler<AddBtnClickArgs> addBtnClickHandler;

        public enum ButtonClickState
        {
            /// <summary> Press down </summary>
            PressDown,
            /// <summary> Bounce up </summary>
            BounceUp
        }

        static InputField()
        {
            RegisterStyle("Default", typeof(InputFieldAttributes));
        }

        public InputField() : this("Default")
        {
            Initialize();
        }

        public InputField(string style) : base(style)
        {
            Initialize();
        }

        public event EventHandler<CancelBtnClickArgs> CancelBtnClickEvent
        {
            add
            {
                cancelBtnClickHandler += value;
            }
            remove
            {
                cancelBtnClickHandler -= value;
            }
        }

        public event EventHandler<DeleteBtnClickArgs> DeleteBtnClickEvent
        {
            add
            {
                deleteBtnClickHandler += value;
            }
            remove
            {
                deleteBtnClickHandler -= value;
            }
        }

        public event EventHandler<AddBtnClickArgs> AddBtnClickEvent
        {
            add
            {
                addBtnClickHandler += value;
            }
            remove
            {
                addBtnClickHandler -= value;
            }
        }

        public class CancelBtnClickArgs : EventArgs
        {
            public ButtonClickState State;
        }

        public class DeleteBtnClickArgs : EventArgs
        {
            public ButtonClickState State;
        }

        public class AddBtnClickArgs : EventArgs
        {
            public ButtonClickState State;
        }

        /// <summary>
        /// The property for the enabled state
        /// </summary>
        public bool StateEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (isEnabled == value)
                {
                    return;
                }
                isEnabled = value;
            }
        }
        /// <summary>
        /// The property for the text content
        /// </summary>
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                if (textField != null)
                {
                    textField.Text = text;
                }
            }
        }

        /// <summary>
        /// The property for the hint text
        /// </summary>
        public string HintText
        {
            get
            {
                return hintText;
            }
            set
            {
                hintText = value;
                if (textField != null)
                {
                    textField.PlaceholderText = hintText;
                }
            }
        }

        //protected override void OnFocusGained(object sender, EventArgs e)
        //{
        //    Console.WriteLine("<<<<<<<<<<<<<<<<, focus gained");
        //    base.OnFocusGained(sender, e);
        //}
        //protected override void OnFocusLost(object sender, EventArgs e)
        //{
        //    Console.WriteLine(">>>>>>>>>>>>>>>>, focus lost");
        //    base.OnFocusLost(sender, e);
        //}

        protected override Attributes GetAttributes()
        {
            return null;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }
            if (type == DisposeTypes.Explicit)
            {
                if (bgImage != null)
                {
                    this.Remove(bgImage);
                    bgImage.Dispose();
                    bgImage = null;
                }
                if (textField != null)
                {
                    textField.TouchEvent -= OnTextFieldTouchEvent;
                    textField.FocusGained -= OnTextFieldFocusGained;
                    textField.FocusLost -= OnTextFieldFocusLost;
                    textField.TextChanged += OnTextFieldTextChanged;
                    this.Remove(textField);
                    textField.Dispose();
                    textField = null;
                }
                if (cancelBtn != null)
                {
                    cancelBtn.TouchEvent -= OnCancelBtnTouchEvent;
                    this.Remove(cancelBtn);
                    cancelBtn.Dispose();
                    cancelBtn = null;
                }
                if (deleteBtn != null)
                {
                    deleteBtn.TouchEvent -= OnDeleteBtnTouchEvent;
                    this.Remove(deleteBtn);
                    deleteBtn.Dispose();
                    deleteBtn = null;
                }
                if (addBtnTop != null)
                {
                    addBtnTop.TouchEvent -= OnAddBtnTouchEvent;
                    if (addBtnOverlay != null)
                    {
                        addBtnOverlay.Remove(addBtnTop);
                    }
                    addBtnTop.Dispose();
                    addBtnTop = null;
                }
                if (addBtnOverlay != null)
                {
                    if (addBtnBg != null)
                    {
                        addBtnBg.Remove(addBtnOverlay);
                    }
                    addBtnOverlay.Dispose();
                    addBtnOverlay = null;
                }
                if (addBtnBg != null)
                {
                    this.Remove(addBtnBg);
                    addBtnBg.Dispose();
                    addBtnBg = null;
                }
            }

            base.Dispose(type);
        }

        protected override void OnUpdate(Attributes attributtes)
        {
            inputFieldAttrs = attributes as InputFieldAttributes;
            if (inputFieldAttrs == null)
            {
                return;
            }
            ApplyAttributes(this, inputFieldAttrs);

            ApplyAttributes(bgImage, inputFieldAttrs.BgImageAttributes);
            ApplyAttributes(textField, inputFieldAttrs.InputBoxAttributes);
            ApplyAttributes(cancelBtn, inputFieldAttrs.CancelButtonAttributes);
            ApplyAttributes(addBtnBg, inputFieldAttrs.AddButtonBgAttributes);
            ApplyAttributes(addBtnOverlay, inputFieldAttrs.AddButtonOverlayAttributes);
            ApplyAttributes(addBtnTop, inputFieldAttrs.AddButtonTopAttributes);
            ApplyAttributes(deleteBtn, inputFieldAttrs.DeleteButtonAttributes);
            RelayoutComponents();
        }

        private void Initialize()
        {
            inputFieldAttrs = attributes as InputFieldAttributes;
            if (inputFieldAttrs == null)
            {
                throw new Exception("Fail to get the inputField attributes.");
            }
            if (inputFieldAttrs.BgImageAttributes != null && bgImage == null)
            {
                bgImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    PositionUsesPivotPoint = true
                };
                this.Add(bgImage);
            }
            if (inputFieldAttrs.InputBoxAttributes != null && textField == null)
            {
                textField = new TextField()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed,
                    ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                    PositionUsesPivotPoint = true
                };
                this.Add(textField);
                textField.TouchEvent += OnTextFieldTouchEvent;
                textField.FocusGained += OnTextFieldFocusGained;
                textField.FocusLost += OnTextFieldFocusLost;
                textField.TextChanged += OnTextFieldTextChanged;
            }
            if (inputFieldAttrs.CancelButtonAttributes != null && cancelBtn == null)
            {
                cancelBtn = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed,
                    ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight,
                    PivotPoint = Tizen.NUI.PivotPoint.CenterRight,
                    PositionUsesPivotPoint = true
                };
                this.Add(cancelBtn);
                cancelBtn.TouchEvent += OnCancelBtnTouchEvent;
            }
            if (inputFieldAttrs.AddButtonBgAttributes != null && addBtnBg == null)
            {
                addBtnBg = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed,
                    ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight,
                    PivotPoint = Tizen.NUI.PivotPoint.CenterRight,
                    PositionUsesPivotPoint = true
                };
                this.Add(addBtnBg);
            }
            if (inputFieldAttrs.AddButtonOverlayAttributes != null && addBtnOverlay == null)
            {
                addBtnOverlay = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                };
                addBtnBg.Add(addBtnOverlay);
            }
            if (inputFieldAttrs.AddButtonTopAttributes != null && addBtnTop == null)
            {
                addBtnTop = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                };
                addBtnOverlay.Add(addBtnTop);
                addBtnTop.TouchEvent += OnAddBtnTouchEvent;
            }
            if (inputFieldAttrs.DeleteButtonAttributes != null && deleteBtn == null)
            {
                deleteBtn = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed,
                    ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight,
                    PivotPoint = Tizen.NUI.PivotPoint.CenterRight,
                    PositionUsesPivotPoint = true
                };
                this.Add(deleteBtn);
                deleteBtn.TouchEvent += OnDeleteBtnTouchEvent;
            }
            isFocused = false;
            isPressed = false;
            isEnabled = true;
        }
        
        private void RelayoutComponents()
        {
            if (cancelBtn != null)
            {
                RelayoutComponentsWithCancelBtn();
            }
            else if (deleteBtn != null && addBtnBg != null && addBtnOverlay != null && addBtnTop != null)
            {
                RelayoutComponentsWithDeleteAndAddBtn();
            }
            else
            {
                RelayoutComponentsDefault();
            }
        }

        private void RelayoutComponentsDefault()
        {// only contains textField
            if (textField == null)
            {
                return;
            }
            int space = Space();
            textField.Size2D = new Size2D(this.Size2D.Width - space * 2, this.Size2D.Height);
            textField.PositionX = space;
        }

        private void RelayoutComponentsWithCancelBtn()
        {// Contains textField and cancelBtn.
            if (textField == null || cancelBtn == null)
            {
                return;
            }
            Size2D size = this.Size2D;
            int space = Space();
            
            int textLength = 0;
            if (textField.Text != null)
            {
                textLength = textField.Text.Length;
            }
            if (!isFocused && textLength == 0)
            {
                textField.Size2D = new Size2D(size.Width - space * 2, size.Height);
                textField.PositionX = space;
                cancelBtn.PositionX = -space;
                cancelBtn.Hide();
            }
            else
            {
                int spaceBetweenTextFieldAndButton = SpaceBetweenTextFieldAndButton();
                int cancelBtnWidth = CancelButtonWidth();

                textField.Size2D = new Size2D(size.Width - space * 2 - spaceBetweenTextFieldAndButton - cancelBtnWidth, size.Height);
                textField.PositionX = space;
                cancelBtn.PositionX = -space;
                cancelBtn.Show();
            }
        }

        private void RelayoutComponentsWithDeleteAndAddBtn()
        {// contains textField, delete button and add button
            if (textField == null || deleteBtn == null || addBtnBg == null || addBtnOverlay == null || addBtnTop == null)
            {
                return;
            }
            Size2D size = this.Size2D;
            int space = Space();
            int spaceBetweenTextFieldAndButton = SpaceBetweenTextFieldAndButton();
            int deleteBtnWidth = DeleteButtonWidth();
            int addBtnWidth = AddButtonWidth();
            textField.Size2D = new Size2D(size.Width - space - spaceBetweenTextFieldAndButton - deleteBtnWidth - addBtnWidth, size.Height);
            textField.PositionX = space;

            addBtnBg.PositionX = 0;
            deleteBtn.PositionX = -addBtnWidth;
        }

        private int Space()
        {
            int space = 0;
            if (inputFieldAttrs != null && inputFieldAttrs.Space != null)
            {
                space = inputFieldAttrs.Space.Value;
            }
            return space;
        }

        private int SpaceBetweenTextFieldAndButton()
        {
            int spaceBetweenTextFieldAndButton = 0;
            if (inputFieldAttrs != null && inputFieldAttrs.SpaceBetweenTextFieldAndButton != null)
            {
                spaceBetweenTextFieldAndButton = inputFieldAttrs.SpaceBetweenTextFieldAndButton.Value;
            }
            return spaceBetweenTextFieldAndButton;
        }

        private int CancelButtonWidth()
        {
            int width = 0;
            if (cancelBtn != null && cancelBtn.Size2D != null)
            {
                width = cancelBtn.Size2D.Width;
            }
            return width;
        }

        private int DeleteButtonWidth()
        {
            int width = 0;
            if (deleteBtn != null && deleteBtn.Size2D != null)
            {
                width = deleteBtn.Size2D.Width;
            }
            return width;
        }

        private int AddButtonWidth()
        {
            int width = 0;
            if (addBtnBg != null && addBtnBg.Size2D != null)
            {
                width = addBtnBg.Size2D.Width;
            }
            return width;
        }

        private bool OnTextFieldTouchEvent(object source, TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {

            }
            Console.WriteLine("-------, state = " + state);
            return false;
        }

        private bool OnCancelBtnTouchEvent(object source, TouchEventArgs e)
        {
            if (cancelBtnClickHandler == null)
            {
                return false;
            }
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                CancelBtnClickArgs args = new CancelBtnClickArgs();
                args.State = ButtonClickState.PressDown;
                cancelBtnClickHandler(this, args);
            }
            else if (state == PointStateType.Up)
            {
                CancelBtnClickArgs args = new CancelBtnClickArgs();
                args.State = ButtonClickState.BounceUp;
                cancelBtnClickHandler(this, args);
            }
            Console.WriteLine("-------, state = " + state);
            return false;
        }

        private bool OnDeleteBtnTouchEvent(object source, TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                if (deleteBtnClickHandler != null)
                {
                    DeleteBtnClickArgs args = new DeleteBtnClickArgs();
                    args.State = ButtonClickState.PressDown;
                    deleteBtnClickHandler(this, args);
                }
                UpdateDeleteBtnState(true);
            }
            else if (state == PointStateType.Up)
            {
                if (deleteBtnClickHandler != null)
                {
                    DeleteBtnClickArgs args = new DeleteBtnClickArgs();
                    args.State = ButtonClickState.BounceUp;
                    deleteBtnClickHandler(this, args);
                }
                UpdateDeleteBtnState(false);
            }
            Console.WriteLine("-------, state = " + state);
            return false;
        }

        private bool OnAddBtnTouchEvent(object source, TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                if (addBtnClickHandler != null)
                {
                    AddBtnClickArgs args = new AddBtnClickArgs();
                    args.State = ButtonClickState.PressDown;
                    addBtnClickHandler(this, args);
                }
                UpdateAddBtnState(true);
            }
            else if (state == PointStateType.Up)
            {
                if (addBtnClickHandler != null)
                {
                    AddBtnClickArgs args = new AddBtnClickArgs();
                    args.State = ButtonClickState.BounceUp;
                    addBtnClickHandler(this, args);
                }
                UpdateAddBtnState(false);
            }
            Console.WriteLine("-------, state = " + state);
            return false;
        }

        private void OnTextFieldFocusGained(object source, EventArgs e)
        {
            // when press on TextField, it will gain focus
            isFocused = true;
            Console.WriteLine("<<<-------, textField focus gained");
            RelayoutComponents();
        }

        private void OnTextFieldFocusLost(object source, EventArgs e)
        {
            isFocused = false;
            Console.WriteLine(">>>-------, textField focus lost");
            RelayoutComponents();
        }

        private void OnTextFieldTextChanged(object sender, TextField.TextChangedEventArgs e)
        {
            int textLength = 0;
            if (textField != null && textField.Text != null)
            {
                textLength = textField.Text.Length;
            }
            Console.WriteLine("++++++++++++++++, text changed, textLength = " + textLength);
            RelayoutComponents();
        }

        private void UpdateDeleteBtnState(bool pressed)
        {
            if (!isEnabled)
            {
                return;
            }
            if (pressed)
            {
                deleteBtn.ResourceUrl = inputFieldAttrs.DeleteButtonAttributes.ResourceURL.Pressed;
            }
            else
            {
                deleteBtn.ResourceUrl = inputFieldAttrs.DeleteButtonAttributes.ResourceURL.Normal;
            }
        }

        private void UpdateAddBtnState(bool pressed)
        {
            if (!isEnabled)
            {
                return;
            }
            if (pressed)
            {
                addBtnBg.ResourceUrl = inputFieldAttrs.AddButtonBgAttributes.ResourceURL.Pressed;
                addBtnOverlay.ResourceUrl = inputFieldAttrs.AddButtonOverlayAttributes.ResourceURL.Pressed;
                addBtnTop.ResourceUrl = inputFieldAttrs.AddButtonTopAttributes.ResourceURL.Pressed;
            }
            else
            {
                addBtnBg.ResourceUrl = inputFieldAttrs.AddButtonBgAttributes.ResourceURL.Normal;
                addBtnOverlay.ResourceUrl = inputFieldAttrs.AddButtonOverlayAttributes.ResourceURL.Normal;
                addBtnTop.ResourceUrl = inputFieldAttrs.AddButtonTopAttributes.ResourceURL.Normal;
            }
        }
        
    }
}
