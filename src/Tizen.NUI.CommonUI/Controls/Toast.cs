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
    /// Use a toast to provide simple messages when the user does not need to make an additional action or confirmation.
    /// Unlike other popups, a toast only has the body field as it is just used for providing simple feedback to user actions.
    /// A toast will automatically disappear after a certain time.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Toast : Control
    {
        protected TextLabel[] textLabels = null;
        private ToastAttributes toastAttributes = null;
        private string[] textArray = null;
        private NPatchVisual toastBackground = null;
        private Timer timer = null;

        private readonly int maxTextAreaWidth = 808;
        private readonly uint textLineHeight = 56;
        private readonly uint textLineSpace = 4;
        private readonly float textPointSize = 38;
        private readonly int textPaddingLeft = 96;
        private readonly int textPaddingRight = 96;
        private readonly int textPaddingTop = 38;
        private readonly int textPaddingBottom = 38;
        private readonly uint duration = 3000;

        /// <summary>
        /// Construct Toast with null.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Toast() : base()
        {
            Initialize();
        }

        /// <summary>
        /// The constructor of the Toast class with specific Attributes.
        /// </summary>
        /// <param name="attributes">Construct Attributes</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Toast(ToastAttributes attributes) : base(attributes)
        {
            Initialize();
        }

        /// <summary>
        /// Constructor of the Toast class with special style.
        /// </summary>
        /// <param name="style"> style name </param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Toast(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Text string of ToastPopup
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string[] TextArray
        {
            get
            {
                return textArray;
            }
            set
            {
                if (value != null)
                {
                    textArray = value;
                    SetToastText();
                    //CreateTextAttributes();
                    //if (toastAttributes.TextAttributes.Text == null)
                    //{
                    //    toastAttributes.TextAttributes.Text = new StringSelector();
                    //}
                    //toastAttributes.TextAttributes.Text.All = value;

                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Text point size in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float PointSize
        {
            get
            {
                return toastAttributes.TextAttributes?.PointSize?.All ?? textPointSize;
            }
            set
            {
                CreateTextAttributes();
                if (toastAttributes.TextAttributes.PointSize == null)
                {
                    toastAttributes.TextAttributes.PointSize = new FloatSelector();
                }
                toastAttributes.TextAttributes.PointSize.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Text font family in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FontFamily
        {
            get
            {
                return toastAttributes.TextAttributes?.FontFamily;
            }
            set
            {
                CreateTextAttributes();
                toastAttributes.TextAttributes.FontFamily = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Text color in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color TextColor
        {
            get
            {
                return toastAttributes.TextAttributes?.TextColor?.All;
            }
            set
            {
                CreateTextAttributes();
                if (toastAttributes.TextAttributes.TextColor == null)
                {
                    toastAttributes.TextAttributes.TextColor = new ColorSelector();
                }
                toastAttributes.TextAttributes.TextColor.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Text horizontal alignment in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalAlignment TextAlignment
        {
            get
            {
                return toastAttributes.TextAttributes?.HorizontalAlignment ?? HorizontalAlignment.Center;
            }
            set
            {
                CreateTextAttributes();
                toastAttributes.TextAttributes.HorizontalAlignment = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Get or set BackgroundImage resource URL
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BackgroundImageURL
        {
            get
            {
                return toastAttributes.BackgroundImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateBackgroundAttributes();
                    if (toastAttributes.BackgroundImageAttributes?.ResourceURL == null)
                    {
                        toastAttributes.BackgroundImageAttributes.ResourceURL = new StringSelector();
                    }

                    toastAttributes.BackgroundImageAttributes.ResourceURL.All = value;
                    SetToastBackground();
                }
            }
        }

        /// <summary>
        /// Background image's border in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle BackgroundImageBorder
        {
            get
            {
                return toastAttributes.BackgroundImageAttributes?.Border?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateBackgroundAttributes();
                    if (toastAttributes.BackgroundImageAttributes.Border == null)
                    {
                        toastAttributes.BackgroundImageAttributes.Border = new RectangleSelector();
                    }
                    toastAttributes.BackgroundImageAttributes.Border.All = value;
                    SetToastBackground();
                }
            }
        }

        /// <summary>
        /// Get or set text left padding in Toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TextPaddingLeft
        {
            get
            {
                return toastAttributes.TextAttributes?.PaddingLeft ?? textPaddingLeft;
            }
            set
            {
                CreateTextAttributes();
                toastAttributes.TextAttributes.PaddingLeft = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Get or set text right padding in Toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TextPaddingRight
        {
            get
            {
                return toastAttributes.TextAttributes?.PaddingRight ?? textPaddingRight;
            }
            set
            {
                CreateTextAttributes();
                toastAttributes.TextAttributes.PaddingRight = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Get or set text top padding in Toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TextPaddingTop
        {
            get
            {
                return toastAttributes.TextAttributes?.PaddingTop ?? textPaddingTop;
            }
            set
            {
                CreateTextAttributes();
                toastAttributes.TextAttributes.PaddingTop = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Get or set text bottom padding in Toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TextPaddingBottom
        {
            get
            {
                return toastAttributes.TextAttributes?.PaddingBottom ?? textPaddingBottom;
            }
            set
            {
                CreateTextAttributes();
                toastAttributes.TextAttributes.PaddingBottom = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Get or set text line height in Toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint TextLineHeight
        {
            get
            {
                return toastAttributes.TextLineHeight ?? textLineHeight;
            }
            set
            {
                toastAttributes.TextLineHeight = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Get or set text line space in Toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint TextLineSpace
        {
            get
            {
                return toastAttributes.TextLineSpace ?? textLineSpace;
            }
            set
            {
                toastAttributes.TextLineSpace = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Get or set text bottom padding in Toast.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Duration
        {
            get
            {
                return toastAttributes.Duration ?? duration;
            }
            set
            {
                toastAttributes.Duration = value;
                timer.Interval = value;
            }
        }

        /// <summary>
        /// Dispose ToastPopup.
        /// </summary>
        /// <param name="type">dispose types.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                this.VisibilityChanged -= OnVisibilityChanged;
                if (null != timer)
                {
                    timer.Tick -= OnTick;
                    timer.Dispose();
                    timer = null;
                }
                if (null != textLabels)
                {
                    for (int i=0; i<textLabels.Length; i++)
                    {
                        Utility.Dispose(textLabels[i]);
                    }
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Relayout control's elements
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            if (toastAttributes == null)
            {
                return;
            }
            if (null != toastAttributes.TextAttributes)
            {
                for (int i = 0; i < textLabels.Length; i++)
                {
                    ApplyAttributes(textLabels[i], toastAttributes.TextAttributes);
                }
            }
            LayoutChild();
        }

        /// <summary>
        /// LayoutChild include textLabel.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void LayoutChild()
        {
            int _textPaddingLeft = toastAttributes.TextAttributes?.PaddingLeft ?? textPaddingLeft;
            int _textPaddingRight = toastAttributes.TextAttributes?.PaddingRight ?? _textPaddingLeft;
            int _textPaddingTop = toastAttributes.TextAttributes?.PaddingTop ?? textPaddingTop;
            int _textPaddingBottom = toastAttributes.TextAttributes?.PaddingBottom ?? _textPaddingTop;

            int _textAreaWidth = this.Size2D.Width - _textPaddingLeft - _textPaddingRight;
            int _textAreaHeight = this.Size2D.Height - _textPaddingTop - _textPaddingBottom;
            int _textLineSpace = (int)(toastAttributes.TextLineSpace ?? textLineSpace);
            int _textLineHeight = (int)(toastAttributes.TextLineHeight ?? textLineHeight);
            int _positionY = 0;

            _textAreaWidth = _textAreaWidth > maxTextAreaWidth ? maxTextAreaWidth : _textAreaWidth;
            if (LayoutDirection == ViewLayoutDirectionType.LTR)
            {
                for (int i = 0; i < textLabels?.Length; i++)
                {
                    textLabels[i].Position2D = new Position2D(_textPaddingLeft, _textPaddingTop + _positionY);
                    textLabels[i].Size2D = new Size2D(_textAreaWidth, _textLineHeight);
                    _positionY += _textLineHeight + _textLineSpace;
                }
            }
            else
            {
                for (int i = 0; i < textLabels?.Length; i++)
                {
                    textLabels[i].ParentOrigin = Tizen.NUI.ParentOrigin.TopRight;
                    textLabels[i].PivotPoint = Tizen.NUI.PivotPoint.TopRight;
                    textLabels[i].PositionUsesPivotPoint = true;
                    textLabels[i].Position2D = new Position2D(-_textPaddingLeft, _textPaddingTop + _positionY);
                    textLabels[i].Size2D = new Size2D(_textAreaWidth, _textLineHeight);
                    _positionY += _textLineHeight + _textLineSpace;
                }
            }
        }

        /// <summary>
        /// Get Toast attribues.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new ToastAttributes();
        }

        private void Initialize()
        {
            toastAttributes = attributes as ToastAttributes;
            if (toastAttributes == null)
            {
                throw new Exception("Toast attribute parse error.");
            }
            ApplyAttributes(this, toastAttributes);

            toastBackground = new NPatchVisual();
            SetToastBackground();

            this.VisibilityChanged += OnVisibilityChanged;
            timer = new Timer(toastAttributes.Duration ?? duration);
            timer.Tick += OnTick;
            timer.Start();
        }

        private bool OnTick(object sender, EventArgs e)
        {
            Hide();
            return false;
        }

        private void OnVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.Visibility == true)
            {
                timer.Start();
            }
        }

        private void SetToastText()
        {
            for (int i = 0; i < textLabels?.Length; i++)
            {
                if (null != textLabels[i])
                {
                    this.Remove(textLabels[i]);
                    textLabels[i].Dispose();
                    textLabels[i] = null;
                }
            }

            textLabels = new TextLabel[textArray.Length];
            for (int i = 0; i < textArray.Length; i++)
            {
                textLabels[i] = new TextLabel();
                textLabels[i].Text = textArray[i];
                textLabels[i].BackgroundColor = Color.Blue;
                this.Add(textLabels[i]);
            }
        }

        private void SetToastBackground()
        {
            if (null != toastAttributes?.BackgroundImageAttributes?.ResourceURL)
            {
                toastBackground.URL = toastAttributes.BackgroundImageAttributes.ResourceURL.All;
            }
            if (null != toastAttributes?.BackgroundImageAttributes?.Border)
            {
                toastBackground.Border = toastAttributes.BackgroundImageAttributes.Border.All;
            }
            this.Background = toastBackground.OutputVisualMap;
        }

        private void CreateBackgroundAttributes()
        {
            if (toastAttributes.BackgroundImageAttributes == null)
            {
                toastAttributes.BackgroundImageAttributes = new ImageAttributes();
            }
        }

        private void CreateTextAttributes()
        {
            if (toastAttributes.TextAttributes == null)
            {
                toastAttributes.TextAttributes = new TextAttributes();
            }
        }
    }
}
