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
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Toast : Tizen.NUI.CommonUI.Toast
    {
        private ToastAttributes toastAttributes;
        private Loading loading;
        private readonly Size2D loadingSize = new Size2D(100, 100);

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
        /// Get or set loading enable.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LoadingEnable
        {
            get
            {
                return toastAttributes.LoadingEnable ?? false;
            }
            set
            {
                toastAttributes.LoadingEnable = value;
                SetLoading();
                RelayoutRequest();
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
                this.LayoutDirectionChanged -= OnLayoutDirectionChanged;
                if (null != loading)
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
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (toastAttributes == null)
            {
                return;
            }

            //LayoutChild();
        }

        /// <summary>
        /// LayoutChild include textLabel and loading.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void LayoutChild()
        {
            base.LayoutChild();
            if (LayoutDirection == ViewLayoutDirectionType.LTR)
            {
                if (null != loading)
                {
                    loading.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
                    loading.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
                    loading.PositionUsesPivotPoint = true;
                    loading.Size2D = loadingSize;
                    loading.Position2D = new Position2D(TextPaddingLeft - loadingSize.Width - 8, 0);
                }
            }
            else
            {
                if (null != loading)
                {
                    loading.ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight;
                    loading.PivotPoint = Tizen.NUI.PivotPoint.CenterRight;
                    loading.PositionUsesPivotPoint = true;
                    loading.Size2D = loadingSize;
                    loading.Position2D = new Position2D(-TextPaddingLeft + loadingSize.Width + 8, 0);
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
            toastAttributes = this.attributes as ToastAttributes;
            if (toastAttributes == null)
            {
                throw new Exception("Toast attribute parse error.");
            }
            ApplyAttributes(this, toastAttributes);

            SetLoading();
            LayoutDirectionChanged += OnLayoutDirectionChanged;
        }

        private void OnLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            RelayoutRequest();
        }

        private void SetLoading()
        {
            if (null != toastAttributes.LoadingEnable)
            {
                if (true == toastAttributes.LoadingEnable)
                {
                    if (null == loading)
                    {
                        loading = new Loading("DefaultLoading");
                        this.Add(loading);
                    }
                    ApplyAttributes(loading, toastAttributes.LoadingAttributes);
                }
                else
                {
                    if (null != loading)
                    {
                        this.Remove(loading);
                        loading.Dispose();
                        loading = null;
                    }
                }
            }
        }
    }
}
