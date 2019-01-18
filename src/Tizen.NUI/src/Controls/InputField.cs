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

        protected override void OnFocusGained(object sender, EventArgs e)
        {
            base.OnFocusGained(sender, e);
        }
        protected override void OnFocusLost(object sender, EventArgs e)
        {
            base.OnFocusLost(sender, e);
        }

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
                    this.Remove(textField);
                    textField.Dispose();
                    textField = null;
                }
                if (cancelView != null)
                {
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
            }
        }
        
        private void RelayoutComponents()
        {
            Size2D curSize = this.Size2D;
            int space = Space();
            if (textField != null)
            {
                textField.Size2D = new Size2D(curSize.Width - space * 2, curSize.Height);
                textField.PositionX = space;
            }
            if (cancelView != null)
            {
                cancelView.PositionX = -space;
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
    }
}
