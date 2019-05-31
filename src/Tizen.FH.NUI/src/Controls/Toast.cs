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

using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;
using Tizen.NUI;
using System;
using System.ComponentModel;

namespace Tizen.FH.NUI.Controls
{
    /// <summary>
    /// Use a toast to provide simple messages when the user does not need to make an additional action or confirmation.
    /// Unlike other popups, a toast only has the body field as it is just used for providing simple feedback to user actions.
    /// A toast will automatically disappear after a certain time.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Toast : Tizen.NUI.CommonUI.Toast
    {
        private ToastAttributes toastAttributes;
        private Loading loading;
        private TextLabel toastText_2line;
        private TextLabel toastText_3line;
        private ToastLengthType lengthType = ToastLengthType.CUSTOM;
        private ToastLinesType linesType = ToastLinesType.ONE;
        private bool loadingEnable = false;

        /// <summary>
        /// Construct Toast with null.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Toast() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Constructor of the Toast class with special style.
        /// </summary>
        /// <param name="style"> style name </param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Toast(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// The Toast length type
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ToastLengthType
        {
            /// <summary>
            /// The short type
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            SHORT,

            /// <summary>
            /// The long type
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            LONG,

            /// <summary>
            /// The custom type
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            CUSTOM
        };

        /// <summary>
        /// The how many lines type
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ToastLinesType
        {
            /// <summary>
            /// One line
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            ONE,

            /// <summary>
            /// Two lines
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            TWO,

            /// <summary>
            /// Three lines
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            THREE
        };

        /// <summary>
        /// Get or set text length.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ToastLengthType LengthType
        {
            get
            {
                return lengthType;
            }
            set
            {
                if (value != lengthType)
                {
                    if (value == ToastLengthType.LONG)
                    {
                        this.SizeWidth = 1000;
                    }
                    else if (value == ToastLengthType.SHORT)
                    {
                        this.SizeWidth = 512;
                    }

                    lengthType = value;
                }

            }
        }

        /// <summary>
        /// Get or set how many lines.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ToastLinesType LinesType
        {
            get
            {
                return linesType;
            }
            set
            {
                if (value != linesType)
                {
                    if (value == ToastLinesType.ONE)
                    {
                        if (toastText_3line != null)
                        {
                            toastText_3line.Dispose();
                        }
                        if (toastText_2line != null)
                        {
                            toastText_2line.Dispose();
                        }

                        linesType = value;
                    }
                    else if (value == ToastLinesType.TWO)
                    {
                        if (toastText_3line != null)
                        {
                            toastText_3line.Dispose();
                        }
                        if (toastText_2line == null)
                        {
                            toastText_2line = new TextLabel()
                            {
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,

                                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                                PivotPoint = Tizen.NUI.PivotPoint.Center,
                                PositionUsesPivotPoint = true,
                            };
                            this.Add(toastText_2line);
                        }

                        linesType = value;
                    }
                    else if (value == ToastLinesType.THREE)
                    {
                        if (toastText_3line == null)
                        {
                            toastText_3line = new TextLabel()
                            {
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                            };
                        }
                        if (toastText_2line == null)
                        {
                            toastText_2line = new TextLabel()
                            {
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                            };
                        }

                        this.Add(toastText_2line);
                        this.Add(toastText_3line);

                        linesType = value;
                    }

                }

            }
        }

        /// <summary>
        /// Get or set loading enable.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LoadingEnable
        {
            get
            {
                return loadingEnable;
            }
            set
            {
                if (value != loadingEnable)
                {
                    if (value == true)
                    {
                        AddLoading();
                    }
                    else
                    {
                        RemoveLoading();
                    }

                    loadingEnable = value;
                }

            }
        }

        /// <summary>
        /// Get or set text of second line.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Text2Line
        {
            get
            {
                return toastText_2line?.Text;
            }
            set
            {
                if (linesType == ToastLinesType.TWO || linesType == ToastLinesType.THREE)
                    toastText_2line.Text = value;
            }

        }

        /// <summary>
        /// Get or set text of third lie.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Text3Line
        {
            get
            {
                return toastText_3line?.Text;
            }
            set
            {
                if (linesType == ToastLinesType.THREE)
                    toastText_3line.Text = value;
            }

        }

        /// <summary>
        /// Dispose ToastPopup.
        /// </summary>
        /// <param name="type">dispose types.</param>
        /// <since_tizen> 5.5 </since_tizen>
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
                if (loading != null)
                {
                    this.Remove(loading);
                    loading.Dispose();
                    loading = null;
                }

            }

            base.Dispose(type);
        }

        /// <summary>
        /// Relayout control's elements
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            DownSpace = UpSpace;
            if (loadingEnable)
            {
                ApplyAttributes(loading, toastAttributes.LoadingAttributes);
            }
            if (linesType == ToastLinesType.THREE)
            {
                DownSpace = 168;
            }
            if (linesType == ToastLinesType.TWO)
            {
                DownSpace = 98;
            }
            base.OnUpdate();
        }

        /// <summary>
        /// Get Toast attribues.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new ToastAttributes
            {
                TextAttributes = new TextAttributes
                {

                },

                BackgroundImageAttributes = new ImageAttributes
                {

                },
                LoadingAttributes = new LoadingAttributes
                {
                }
            };
        }

        /// <summary>
        /// LayoutChild include textLabel and loading.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void LayoutChild()
        {
            if (toastAttributes.TextAttributes.Size2D == null)
            {
                toastAttributes.TextAttributes.Size2D = new Size2D();
            }
            if (toastAttributes.TextAttributes.Position2D == null)
            {
                toastAttributes.TextAttributes.Position2D = new Position2D();
            }
            toastAttributes.TextAttributes.Size2D.Height = this.Size2D.Height - UpSpace - DownSpace;
            toastAttributes.TextAttributes.Position2D.Y = UpSpace;

            if (loadingEnable)
            {
                toastAttributes.TextAttributes.Size2D.Width = this.Size2D.Width - 2 * LeftSpace - 108;
                if (LayoutDirection == ViewLayoutDirectionType.LTR)
                {
                    loading.Position2D.X = LeftSpace;
                    toastAttributes.TextAttributes.Position2D.X = LeftSpace + 108;
                    toastAttributes.TextAttributes.HorizontalAlignment = HorizontalAlignment.Begin;

                }
                else
                {
                    loading.Position2D.X = this.Size2D.Width - LeftSpace - loading.Size2D.Width;
                    toastAttributes.TextAttributes.Position2D.X = LeftSpace;
                    toastAttributes.TextAttributes.HorizontalAlignment = HorizontalAlignment.End;
                }
            }
            else
            {
                toastAttributes.TextAttributes.Size2D.Width = this.Size2D.Width - 2 * LeftSpace;

                toastAttributes.TextAttributes.Position2D.X = LeftSpace;

            }

            if (toastText_2line != null)
            {
                toastText_2line.Size2D = toastAttributes.TextAttributes.Size2D;
                toastText_2line.Position2D.X = toastAttributes.TextAttributes.Position2D.X;
                toastText_2line.Position2D.Y = toastAttributes.TextAttributes.Position2D.Y + 60;//TODO
            }
            if (toastText_3line != null)
            {
                toastText_3line.Size2D = toastAttributes.TextAttributes.Size2D;
                toastText_3line.Position2D.X = toastAttributes.TextAttributes.Position2D.X;
                toastText_3line.Position2D.Y = toastAttributes.TextAttributes.Position2D.Y + 120;//TODO
            }

        }

        private void Initialize()
        {
            toastAttributes = this.attributes as ToastAttributes;
            if(toastAttributes == null)
            {
                throw new Exception("Toast attribute parse error.");
            }
            ApplyAttributes(this, toastAttributes);
            LayoutDirectionChanged += OnLayoutDirectionChanged;
        }

        private void OnLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            RelayoutRequest();
        }

        private void AddLoading()
        {
            loading = new Loading("DefaultLoading");
            this.Add(loading);
            loading.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
            loading.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
            loading.Size2D = new Size2D(100, 100);
            loading.PositionUsesPivotPoint = true;
            loading.Position2D.Y = 0;
            loadingEnable = true;
            RelayoutRequest();
        }

        private void RemoveLoading()
        {
            if (loading != null)
            {
                this.Remove(loading);
                loading.Dispose();
            }

            loadingEnable = false;
            RelayoutRequest();
        }

    }
}
