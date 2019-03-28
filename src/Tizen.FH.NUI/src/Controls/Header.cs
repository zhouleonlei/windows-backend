using System;
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Header : Control
    {
        private HeaderAttributes headerAttribute;
        private TextLabel headerTitle;
        private View headerLine;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Header() : base()
        {
            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Header(string style) : base(style)
        {
            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Header(HeaderAttributes attributes) : base()
        {
            this.attributes = headerAttribute = attributes.Clone() as HeaderAttributes;
        }
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new HeaderAttributes();
        }
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
                if (headerAttribute.TextAttributes != null)
                {
                    if (headerTitle== null)
                    {
                        headerTitle= new TextLabel();
                        this.Add(headerTitle);
                    }
                    ApplyAttributes(headerTitle, headerAttribute.TextAttributes);
                }
                if (headerAttribute.LineAttributes != null)
                {
                    if (headerLine== null)
                    {
                        headerLine = new View();
                        this.Add(headerLine);
                    }
                    ApplyAttributes(headerLine, headerAttribute.LineAttributes);
                }
            }
            base.Dispose(type);
        }
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
