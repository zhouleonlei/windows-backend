/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI.CommonUI
{
    /// <summary>
    /// InputField is a editable input compoment
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class InputField : Control
    {
        // the background image
        private ImageView bgImage = null;
        // the textField
        private TextField textField = null;
        // the attributes of the inputField
        private InputFieldAttributes inputFieldAttrs = null;
        // the flag indicate should relayout the textField in base class
        private bool relayoutTextField = true;

        /// <summary>
        /// Initializes a new instance of the InputField class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InputField() : base()
        {
            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InputField(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the InputField class.
        /// </summary>
        /// <param name="style">Create Header by special style defined in UX.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InputField(InputFieldAttributes attributes) : base(attributes)
        {
            Initialize();
        }

        /// <summary>
        /// The property for the enabled state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool StateEnabled
        {
            get
            {
                return Sensitive;
            }
            set
            {
                Sensitive = value;
            }
        }

        /// <summary>
        /// The property for the text content
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Text
        {
            get
            {
                return textField.Text;
            }
            set
            {
                if (textField != null)
                {
                    textField.Text = value;
                }
            }
        }

        /// <summary>
        /// The property for the hint text
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string HintText
        {
            get
            {
                return textField.PlaceholderText;
            }
            set
            {
                if (textField != null)
                {
                    textField.PlaceholderText = value;
                }
            }
        }

        /// <summary>
        /// The property for the color of the input text
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color TextColor
        {
            get
            {
                return textField.TextColor;
            }
            set
            {
                if (textField != null)
                {
                    textField.TextColor = value;
                }
            }
        }

        /// <summary>
        /// Get Input Field attribues.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new InputFieldAttributes();
        }

        /// <summary>
        /// Dispose Input Field and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    textField.FocusGained -= OnTextFieldFocusGained;
                    textField.FocusLost -= OnTextFieldFocusLost;
                    textField.TextChanged -= OnTextFieldTextChanged;
                    textField.KeyEvent -= OnTextFieldKeyEvent;
                    //textField.TouchEvent -= OnTextFieldTouchEvent;
                    this.Remove(textField);
                    textField.Dispose();
                    textField = null;
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Update Input Field by attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            inputFieldAttrs = attributes as InputFieldAttributes;
            if (inputFieldAttrs == null)
            {
                return;
            }
            ApplyAttributes(this, inputFieldAttrs);
            ApplyAttributes(bgImage, inputFieldAttrs.BackgroundImageAttributes);
            ApplyAttributes(textField, inputFieldAttrs.InputBoxAttributes);
            RelayoutComponent();
            OnLayoutDirectionChanged();
        }
        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            InputFieldAttributes tempAttributes = StyleManager.Instance.GetAttributes(style) as InputFieldAttributes;
            if (tempAttributes != null)
            {
                attributes = inputFieldAttrs = tempAttributes;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property for the inputfield space
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected int Space()
        {
            int space = 0;
            if (inputFieldAttrs != null && inputFieldAttrs.Space != null)
            {
                space = inputFieldAttrs.Space.Value;
            }
            return space;
        }

        /// <summary>
        /// Theme change callback when text field focus is gained, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnTextFieldFocusGained(object source, EventArgs e)
        {
        }

        /// <summary>
        /// Theme change callback when text field is lost, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnTextFieldFocusLost(object source, EventArgs e)
        {
        }

        /// <summary>
        /// Theme change callback when text field's text is changed, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnTextFieldTextChanged(object sender, TextField.TextChangedEventArgs e)
        {
        }

        /// <summary>
        /// Theme change callback when text field have a key event, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool OnTextFieldKeyEvent(object source, KeyEventArgs e)
        {
            return false;
        }

        /// <summary>
        /// Theme change callback when text field is touched, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool OnTextFieldTouchEvent(object sender, View.TouchEventArgs e)
        {
            return false;
        }

        /// <summary>
        /// Set the text field 2D size
        /// </summary>
        /// <param name="w">Input Field' width.</param>
        /// <param name="h">Input Field' height.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void SetTextFieldSize2D(int w, int h)
        {
            if (textField != null)
            {
                textField.Size2D = new Size2D(w, h);
            }
        }

        /// <summary>
        /// Set the text field X pose
        /// </summary>
        /// <param name="X">Input Field' X.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void SetTextFieldPosX(int x)
        {
            if (textField != null)
            {
                textField.PositionX = x;
            }
        }

        /// <summary>
        /// Set the text field  text color
        /// </summary>
        /// <param name="color">Input Field' color.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void SetTextFieldTextColor(Color color)
        {
            if (textField != null)
            {
                textField.TextColor = color;
            }
        }

        /// <summary>
        /// Set the text field relayout flag
        /// </summary>
        /// <param name="value">relayout text field' value.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void RelayoutTextField(bool value)
        {
            relayoutTextField = value;
        }

        private void Initialize()
        {
            inputFieldAttrs = attributes as InputFieldAttributes;
            if (inputFieldAttrs == null)
            {
                throw new Exception("Fail to get the base inputField attributes.");
            }
            if (inputFieldAttrs.BackgroundImageAttributes != null && bgImage == null)
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
                textField.FocusGained += OnTextFieldFocusGained;
                textField.FocusLost += OnTextFieldFocusLost;
                textField.TextChanged += OnTextFieldTextChanged;
                textField.KeyEvent += OnTextFieldKeyEvent;
            }
        }
        private void OnLayoutDirectionChanged()
        {
            if (inputFieldAttrs == null) return;
            if (textField != null)
            {
                if (LayoutDirection == ViewLayoutDirectionType.LTR)
                {
                    if(inputFieldAttrs.InputBoxAttributes != null)
                    {
                        inputFieldAttrs.InputBoxAttributes.HorizontalAlignment = HorizontalAlignment.Begin;
                        inputFieldAttrs.InputBoxAttributes.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
                        inputFieldAttrs.InputBoxAttributes.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
                        inputFieldAttrs.InputBoxAttributes.PositionUsesPivotPoint = true;
                    }
                    textField.HorizontalAlignment = HorizontalAlignment.Begin;
                    textField.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
                    textField.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
                    textField.PositionUsesPivotPoint = true;
                }
                else //ViewLayoutDirectionType.RTL
                {
                    if (inputFieldAttrs.InputBoxAttributes != null)
                    {
                        inputFieldAttrs.InputBoxAttributes.HorizontalAlignment = HorizontalAlignment.End;
                        inputFieldAttrs.InputBoxAttributes.ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight;
                        inputFieldAttrs.InputBoxAttributes.PivotPoint = Tizen.NUI.PivotPoint.CenterRight;
                    }
                    textField.HorizontalAlignment = HorizontalAlignment.End;
                    textField.ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight;
                    textField.PivotPoint = Tizen.NUI.PivotPoint.CenterRight;
                    textField.PositionUsesPivotPoint = true;
                }
            }
        }
        private void RelayoutComponent()
        {
            if (!relayoutTextField)
            {
                return;
            }
            int space = Space();
            if (textField != null)
            {
                textField.Size2D = new Size2D(this.Size2D.Width - space * 2, this.Size2D.Height);
                textField.PositionX = space;
            }
        }
    }
}
