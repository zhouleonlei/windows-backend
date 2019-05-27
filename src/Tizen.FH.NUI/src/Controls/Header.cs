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
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    /// <summary>
    /// The Header  is a component that contain a lable and a 1 pixel line  under it
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Header : Control
    {
        private HeaderAttributes headerAttribute;
        private TextLabel headerTitle;
        private View headerLine;
        /// <summary>
        /// Initializes a new instance of the Header class.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Header() : base()
        {
            Initialize();
        }
        /// <summary>
        /// Initializes a new instance of the Header class.
        /// </summary>
        /// <param name="style">Create Header by special style defined in UX.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Header(string style) : base(style)
        {
            Initialize();
        }
        /// <summary>
        /// Initializes a new instance of the Header class.
        /// </summary>
        /// <param name="attributes">Create Header by attributes customized by user.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Header(HeaderAttributes attributes) : base()
        {
            this.attributes = headerAttribute = attributes.Clone() as HeaderAttributes;
        }
        /// <summary>
        ///The text showed in the header
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string HeaderText
        {
            get
            {
                return headerAttribute?.TextAttributes?.Text?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateTextAttributes();
                    if (headerAttribute.TextAttributes.Text == null)
                    {
                        headerAttribute.TextAttributes.Text = new StringSelector();
                    }
                    headerAttribute.TextAttributes.Text.All = value;

                    RelayoutRequest();
                }
            }
        }
        /// <summary>
        ///The color of text showed in the header
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color HeaderTextColor
        {
            get
            {
                return headerAttribute?.TextAttributes?.TextColor?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateTextAttributes();
                    if (headerAttribute.TextAttributes.TextColor == null)
                    {
                        headerAttribute.TextAttributes.TextColor = new ColorSelector();
                    }
                    headerAttribute.TextAttributes.TextColor.All = value;
                    RelayoutRequest();
                }
            }
        }
        /// <summary>
        ///The color of one pixel line under the header
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color LinebackgroundColor
        {
            get
            {
                return headerAttribute?.LineAttributes?.BackgroundColor?.All;
            }
            set
            {
                CreateLineAttributes();
                if (headerAttribute.LineAttributes.BackgroundColor == null)
                {
                    headerAttribute.LineAttributes.BackgroundColor = new ColorSelector();
                }
                headerAttribute.LineAttributes.BackgroundColor.All = value;
                RelayoutRequest();
            }
        }
        /// <summary>
        /// Get Header attribues.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new HeaderAttributes();
        }
        /// <summary>
        /// Dispose Header and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
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
                if (headerTitle != null)
                {
                    Remove(headerTitle);
                    headerTitle.Dispose();
                    headerTitle = null;
                }
                if (headerLine != null)
                {
                    Remove(headerLine);
                    headerLine.Dispose();
                    headerLine = null;
                }
            }
            base.Dispose(type);
        }
        /// <summary>
        /// Update Header by attributes.
        /// </summary>
        /// <param name="attributes">Header attributes which record all data information.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate(Attributes attributtes)
        {
            headerAttribute = attributes as HeaderAttributes;
            if (headerAttribute == null)
            {
                return;
            }
            if (headerAttribute.TextAttributes != null)
            {
                if (headerTitle== null)
                {
                    headerTitle= new TextLabel
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                        HorizontalAlignment =   HorizontalAlignment.Center,
                        VerticalAlignment =  VerticalAlignment.Center,
                    };
                    this.Add(headerTitle);
                }
                ApplyAttributes(headerTitle, headerAttribute.TextAttributes);
            }
            if (headerAttribute.LineAttributes != null)
            {
                if (headerLine == null)
                {
                    headerLine = new View
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        Size2D = new Size2D(1080, 1),
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft
                    };
                    this.Add(headerLine);
                }
                ApplyAttributes(headerLine, headerAttribute.LineAttributes);
            }
        }

        private void CreateTextAttributes()
        {
            if (headerAttribute.TextAttributes == null)
            {
                headerAttribute.TextAttributes = new TextAttributes();
            }
        }

        private void CreateLineAttributes()
        {

            if (headerAttribute.LineAttributes == null)
            {
                headerAttribute.LineAttributes = new ViewAttributes();
            }
        }

        private void Initialize()
        {
            headerAttribute = attributes as HeaderAttributes;
            if (headerAttribute == null)
            {
                throw new Exception("Header attribute parse error.");
            }
            ApplyAttributes(this, headerAttribute);
        }
     
    }
}
