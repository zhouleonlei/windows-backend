using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Controls
{
    public class InputField : Control
    {
        // the background image object
        private ImageView bgImage = null;
        // the input box object
        private TextField textField = null;
        private ImageView cancelView = null;
        // the InputField attributes
        private InputFieldAttributes inputFieldAttrs = null;

        private string text = null;
        private string hintText = null;
        private bool isPressed = false;

        private EventHandler<CancelBtnClickArgs> cancelBtnClickHandler;

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

        public class CancelBtnClickArgs : EventArgs
        {
            public ButtonClickState State;
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
                if (cancelView != null)
                {
                    cancelView.TouchEvent -= OnCancelBtnTouchEvent;
                    this.Remove(cancelView);
                    cancelView.Dispose();
                    cancelView = null;
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

            ApplyAttributes(bgImage, inputFieldAttrs.BgImageViewAttributes);
            ApplyAttributes(textField, inputFieldAttrs.TextFieldViewAttributes);
            ApplyAttributes(cancelView, inputFieldAttrs.CancelBtnAttributes);
            RelayoutComponents();
        }

        private void Initialize()
        {
            inputFieldAttrs = attributes as InputFieldAttributes;
            if (inputFieldAttrs == null)
            {
                throw new Exception("Fail to get the inputField attributes.");
            }

            if (inputFieldAttrs.BgImageViewAttributes != null && bgImage == null)
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
            if (inputFieldAttrs.TextFieldViewAttributes != null && textField == null)
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
            if (inputFieldAttrs.CancelBtnAttributes != null && cancelView == null)
            {
                cancelView = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed,
                    ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight,
                    PivotPoint = Tizen.NUI.PivotPoint.CenterRight,
                    PositionUsesPivotPoint = true
                };
                this.Add(cancelView);
                cancelView.TouchEvent += OnCancelBtnTouchEvent;
            }
            isPressed = false;
        }
        
        private void RelayoutComponents()
        {
            Size2D curSize = this.Size2D;
            int space = Space();
            
            int textLength = 0;
            if (textField != null && textField.Text != null)
            {
                textLength = textField.Text.Length;
            }

            if (!isPressed && textLength == 0)
            {
                if (textField != null)
                {
                    textField.Size2D = new Size2D(curSize.Width - space * 2, curSize.Height);
                    textField.PositionX = space;
                }
                if (cancelView != null)
                {
                    cancelView.PositionX = -space;
                    cancelView.Hide();
                }
            }
            else
            {
                int spaceBetweenTextFieldAndButton = SpaceBetweenTextFieldAndButton();
                int cancelBtnWidth = CancelButtonWidth();
                if (textField != null)
                {
                    textField.Size2D = new Size2D(curSize.Width - space * 2 - spaceBetweenTextFieldAndButton - cancelBtnWidth, curSize.Height);
                    textField.PositionX = space;
                }
                if (cancelView != null)
                {
                    cancelView.PositionX = -space;
                    cancelView.Show();
                }
            }
            
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
            if (cancelView != null && cancelView.Size2D != null)
            {
                width = cancelView.Size2D.Width;
            }
            return width;
        }

        private bool OnTextFieldTouchEvent(object source, TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            //if (state == PointStateType.Down)
            //{
                
            //}
            //Console.WriteLine("-------, state = " + state);
            return false;
        }

        private bool OnCancelBtnTouchEvent(object source, TouchEventArgs e)
        {
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

        private void OnTextFieldFocusGained(object source, EventArgs e)
        {
            isPressed = true;
            Console.WriteLine("<<<-------, textField focus gained");
            RelayoutComponents();
        }

        private void OnTextFieldFocusLost(object source, EventArgs e)
        {
            isPressed = false;
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
    }
}
