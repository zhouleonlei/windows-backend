using System;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Controls
{   
    public class Popup : Control
    {
        private ImageView backgroundImage;
        private ImageView shadowImage;
        private View contentView;
        private TextLabel titleText;
        private List<Button> buttonList;
        private List<string> buttonTextList = new List<string>();

        private PopupAttributes popupAttributes;
        private int buttonCount = 0;
        private string buttonPreStyle = "";
        private string buttonStyle = "";

        public Popup() : base()
        {
            popupAttributes = attributes as PopupAttributes;
            if (popupAttributes == null)
            {
                throw new Exception("Popup attribute parse error.");
            }
            Initialize();
        }
        public Popup(string style) : base(style)
        {
            popupAttributes = attributes as PopupAttributes;
            if (popupAttributes == null)
            {
                throw new Exception("Popup attribute parse error.");
            }
            Initialize();
        }
        public Popup(PopupAttributes attributes) : base()
        {
            this.attributes = popupAttributes = attributes.Clone() as PopupAttributes;
            Initialize();
        }
        public event EventHandler<ButtonClickEventArgs> PopupButtonClickedEvent;

        public string TitleText
        {
            get
            {
                return popupAttributes?.TitleTextAttributes?.Text?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateTitleTextAttributes();
                    if (popupAttributes.TitleTextAttributes.Text == null)
                    {
                        popupAttributes.TitleTextAttributes.Text = new StringSelector();
                    }
                    popupAttributes.TitleTextAttributes.Text.All = value;

                    RelayoutRequest();
                }
            }
        }

        public string ButtonStyle
        {
            get
            {
                return buttonStyle;
            }
            set
            {
                if (buttonStyle != value)
                {
                    buttonStyle = value;
                    RelayoutRequest();
                }
            }
        }

        public int ButtonCount
        {
            get
            {
                return buttonCount;
            }
            set
            {
                if (buttonCount != value)
                {
                    buttonCount = value;
                    RelayoutRequest();
                }
            }
        }

        public View ContentView
        {
            get
            {
                return contentView;
            }
        }

        public string ShadowImageURL
        {
            get
            {
                return popupAttributes?.ShadowImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateShadowAttributes();
                    if (popupAttributes.ShadowImageAttributes.ResourceURL == null)
                    {
                        popupAttributes.ShadowImageAttributes.ResourceURL = new StringSelector();
                    }
                    popupAttributes.ShadowImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        public Rectangle ShadowImageBorder
        {
            get
            {
                return popupAttributes?.ShadowImageAttributes?.Border?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateShadowAttributes();
                    if (popupAttributes.ShadowImageAttributes.Border == null)
                    {
                        popupAttributes.ShadowImageAttributes.Border = new RectangleSelector();
                    }
                    popupAttributes.ShadowImageAttributes.Border.All = value;
                    RelayoutRequest();
                }
            }
        }

        public string BackgroundImageURL
        {
            get
            {
                return popupAttributes?.BackgroundImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateBackgroundAttributes();
                    if (popupAttributes.BackgroundImageAttributes.ResourceURL == null)
                    {
                        popupAttributes.BackgroundImageAttributes.ResourceURL = new StringSelector();
                    }
                    popupAttributes.BackgroundImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        public Rectangle BackgroundImageBorder
        {
            get
            {
                return popupAttributes?.BackgroundImageAttributes?.Border?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateBackgroundAttributes();
                    if (popupAttributes.BackgroundImageAttributes.Border == null)
                    {
                        popupAttributes.BackgroundImageAttributes.Border = new RectangleSelector();
                    }
                    popupAttributes.BackgroundImageAttributes.Border.All = value;
                    RelayoutRequest();
                }
            }
        }

        public float TitlePointSize
        {
            get
            {
                return popupAttributes?.TitleTextAttributes?.PointSize?.All ?? 0;
            }
            set
            {
                CreateTitleTextAttributes();
                if (popupAttributes.TitleTextAttributes.PointSize == null)
                {
                    popupAttributes.TitleTextAttributes.PointSize = new FloatSelector();
                }
                popupAttributes.TitleTextAttributes.PointSize.All = value;
                RelayoutRequest();
            }
        }

        public string TitleFontFamily
        {
            get
            {
                return popupAttributes?.TitleTextAttributes?.FontFamily;
            }
            set
            {
                CreateTitleTextAttributes();
                popupAttributes.TitleTextAttributes.FontFamily = value;
                RelayoutRequest();
            }
        }

        public Color TitleTextColor
        {
            get
            {
                return popupAttributes?.TitleTextAttributes?.TextColor?.All;
            }
            set
            {
                CreateTitleTextAttributes();
                if (popupAttributes.TitleTextAttributes.TextColor == null)
                {
                    popupAttributes.TitleTextAttributes.TextColor = new ColorSelector();
                }
                popupAttributes.TitleTextAttributes.TextColor.All = value;
                RelayoutRequest();
            }
        }

        public HorizontalAlignment TitleTextHorizontalAlignment
        {
            get
            {
                return popupAttributes?.TitleTextAttributes?.HorizontalAlignment ?? HorizontalAlignment.Center;
            }
            set
            {
                CreateTitleTextAttributes();
                popupAttributes.TitleTextAttributes.HorizontalAlignment = value;
                RelayoutRequest();
            }
        }

        public Position2D TitleTextPosition2D
        {
            get
            {
                return popupAttributes?.TitleTextAttributes?.Position2D ?? new Position2D(0, 0);
            }
            set
            {
                CreateTitleTextAttributes();
                popupAttributes.TitleTextAttributes.Position2D = value;
                RelayoutRequest();
            }
        }

        public int TitleHeight
        {
            get
            {
                return popupAttributes?.TitleTextAttributes?.Size2D?.Height ?? 0;
            }
            set
            {
                CreateTitleTextAttributes();
                popupAttributes.TitleTextAttributes.Size2D.Height = value;
                RelayoutRequest();
            }
        }

        public Vector4 ShadowOffset
        {
            get
            {
                return popupAttributes?.ShadowOffset;
            }
            set
            {
                if (value != null)
                {
                    if (popupAttributes.ShadowOffset == null)
                    {
                        popupAttributes.ShadowOffset = new Vector4(0, 0, 0, 0);
                    }
                    popupAttributes.ShadowOffset = value;
                    RelayoutRequest();
                }
            }
        }

        public int ButtonHeight
        {
            get
            {
                return popupAttributes?.ButtonAttributes?.Size2D?.Height ?? 0;
            }
            set
            {
                CreateButtonAttributes();
                popupAttributes.ButtonAttributes.Size2D.Height = value;
                RelayoutRequest();
            }
        }

        public float ButtonPointSize
        {
            get
            {
                return popupAttributes?.ButtonAttributes?.TextAttributes?.PointSize?.All ?? 0;
            }
            set
            {
                CreateButtonAttributes();
                if (popupAttributes.ButtonAttributes.TextAttributes.PointSize == null)
                {
                    popupAttributes.ButtonAttributes.TextAttributes.PointSize = new FloatSelector();
                }
                popupAttributes.ButtonAttributes.TextAttributes.PointSize.All = value;
                RelayoutRequest();
            }
        }

        public string ButtonFontFamily
        {
            get
            {
                return popupAttributes?.ButtonAttributes?.TextAttributes?.FontFamily;
            }
            set
            {
                CreateButtonAttributes();
                popupAttributes.ButtonAttributes.TextAttributes.FontFamily = value;
                RelayoutRequest();
            }
        }

        public Color ButtonTextColor
        {
            get
            {
                return popupAttributes?.ButtonAttributes?.TextAttributes?.TextColor?.All;
            }
            set
            {
                CreateButtonAttributes();
                if (popupAttributes.ButtonAttributes.TextAttributes.TextColor == null)
                {
                    popupAttributes.ButtonAttributes.TextAttributes.TextColor = new ColorSelector();
                }
                popupAttributes.ButtonAttributes.TextAttributes.TextColor.All = value;
                RelayoutRequest();
            }
        }

        public ColorSelector ButtonOverLayBackgroundColorSelector
        {
            get
            {
                return popupAttributes?.ButtonAttributes?.OverlayImageAttributes?.BackgroundColor;
            }
            set
            {
                if (value != null)
                {
                    CreateButtonAttributes();
                    popupAttributes.ButtonAttributes.OverlayImageAttributes.BackgroundColor = value.Clone() as ColorSelector;
                    RelayoutRequest();
                }
            }
        }

        public HorizontalAlignment ButtonTextAlignment
        {
            get
            {
                return popupAttributes?.ButtonAttributes?.TextAttributes?.HorizontalAlignment ?? HorizontalAlignment.Center;
            }
            set
            {
                CreateButtonAttributes();
                popupAttributes.ButtonAttributes.TextAttributes.HorizontalAlignment = value;
                RelayoutRequest();
            }
        }

        public string ButtonBackgroundImageURL
        {
            get
            {
                return popupAttributes?.ButtonAttributes?.BackgroundImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateButtonAttributes();
                    if (popupAttributes.ButtonAttributes.BackgroundImageAttributes.ResourceURL == null)
                    {
                        popupAttributes.ButtonAttributes.BackgroundImageAttributes.ResourceURL = new StringSelector();
                    }
                    popupAttributes.ButtonAttributes.BackgroundImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        public Rectangle ButtonBackgroundImageBorder
        {
            get
            {
                return popupAttributes?.ButtonAttributes?.BackgroundImageAttributes?.Border?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateButtonAttributes();
                    if (popupAttributes.ButtonAttributes.BackgroundImageAttributes.Border == null)
                    {
                        popupAttributes.ButtonAttributes.BackgroundImageAttributes.Border = new RectangleSelector();
                    }
                    popupAttributes.ButtonAttributes.BackgroundImageAttributes.Border.All = value;
                    RelayoutRequest();
                }
            }
        }

        public void SetButtonText(int index, string text)
        {
            if(index < 0 && index >= buttonCount)
            {
                return;
            }
            if(buttonTextList.Count < index + 1)
            {
                for (int i = buttonTextList.Count; i < index + 1; i++)
                {
                    buttonTextList.Add("");
                }
            }
            buttonTextList[index] = text;
            RelayoutRequest();
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (titleText != null)
                {
                    Remove(titleText);
                    titleText.Dispose();
                    titleText = null;
                }
                if (backgroundImage != null)
                {
                    Remove(backgroundImage);
                    backgroundImage.Dispose();
                    backgroundImage = null;
                }
                if (shadowImage != null)
                {
                    Remove(shadowImage);
                    shadowImage.Dispose();
                    shadowImage = null;
                }
                if (contentView != null)
                {
                    Remove(contentView);
                    contentView.Dispose();
                    contentView = null;
                }
                if (buttonList != null)
                {
                    foreach(Button btn in buttonList)
                    {
                        Remove(btn);
                        btn.Dispose();
                    }
                }
            }

            base.Dispose(type);
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
            return new PopupAttributes();
        }

        protected override void OnUpdate(Attributes attributtes)
        {
            popupAttributes = attributes as PopupAttributes;
            if (popupAttributes == null)
            {
                return;
            }

            ApplyAttributes(this, popupAttributes);

            if (popupAttributes.ShadowImageAttributes != null)
            {
                if (shadowImage == null)
                {
                    shadowImage = new ImageView();
                    Add(shadowImage);
                }
                ApplyAttributes(shadowImage, popupAttributes.ShadowImageAttributes);
            }

            if (popupAttributes.BackgroundImageAttributes != null)
            {
                if (backgroundImage == null)
                {
                    backgroundImage = new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent
                    };
                    Add(backgroundImage);
                }
                ApplyAttributes(backgroundImage, popupAttributes.BackgroundImageAttributes);
            }

            if (popupAttributes.TitleTextAttributes != null)
            {
                if (titleText == null)
                {
                    titleText = new TextLabel();
                    Add(titleText);
                }
                ApplyAttributes(titleText, popupAttributes.TitleTextAttributes);
            }

            contentView.RaiseToTop();

            int w = 0;
            int h = 0;
            if (shadowImage != null)
            {
                w = Size2D.Width;
                h = Size2D.Height;
                if (popupAttributes.ShadowOffset != null)
                {
                    w = (int)(Size2D.Width + popupAttributes.ShadowOffset.W + popupAttributes.ShadowOffset.X);
                    h = (int)(Size2D.Height + popupAttributes.ShadowOffset.Y + popupAttributes.ShadowOffset.Z);
                }
                
                shadowImage.Size2D = new Size2D(w, h);
            }
            if (titleText != null)
            {
                w = (int)(Size2D.Width - titleText.PositionX * 2);
                h = titleText.Size2D.Height;
                titleText.Size2D = new Size2D(w, h);
            }

            UpdateButton(buttonCount);

            int titleX = 0;
            int titleY = 0;
            int titleH = 0;
            int buttonH = 0;
            if (popupAttributes.TitleTextAttributes != null)
            {
                if (popupAttributes.TitleTextAttributes.Position2D != null)
                {
                    titleX = popupAttributes.TitleTextAttributes.Position2D.X;
                    titleY = popupAttributes.TitleTextAttributes.Position2D.Y;
                }
                if (popupAttributes.TitleTextAttributes.Size2D != null)
                {
                    titleH = popupAttributes.TitleTextAttributes.Size2D.Height;
                }
            }
            if (popupAttributes.ButtonAttributes != null && popupAttributes.ButtonAttributes.Size2D != null)
            {
                buttonH = popupAttributes.ButtonAttributes.Size2D.Height;
            }
            contentView.Size2D = new Size2D(Size2D.Width - titleX * 2, Size2D.Height - titleY - titleH - buttonH);
            contentView.Position2D = new Position2D(titleX, titleY + titleH);
        }

        protected virtual void LayoutChild()
        {
            if (popupAttributes == null)
            {
                return;
            }

            if(titleText != null)
            {
                if(titleText.HorizontalAlignment == HorizontalAlignment.Begin)
                {
                    if (popupAttributes.TitleTextAttributes != null)
                    {
                        popupAttributes.TitleTextAttributes.HorizontalAlignment = HorizontalAlignment.End;
                    }
                    titleText.HorizontalAlignment = HorizontalAlignment.End;
                }
                else if(titleText.HorizontalAlignment == HorizontalAlignment.End)
                {
                    if (popupAttributes.TitleTextAttributes != null)
                    {
                        popupAttributes.TitleTextAttributes.HorizontalAlignment = HorizontalAlignment.Begin;
                    }
                    titleText.HorizontalAlignment = HorizontalAlignment.Begin;
                }
            }

            if(buttonList.Count > 0)
            {
                int pos = 0;
                if (LayoutDirection == ViewLayoutDirectionType.RTL)
                {                   
                    for (int i = buttonList.Count - 1; i >= 0; i--)
                    {
                        buttonList[i].PositionX = pos;
                        pos += buttonList[i].Size2D.Width;
                    }
                }
                else
                {
                    for (int i = 0; i < buttonList.Count; i++)
                    {
                        buttonList[i].PositionX = pos;
                        pos += buttonList[i].Size2D.Width;
                    }
                }
            }
        }

        private void Initialize()
        {
            StateFocusableOnTouchMode = true;
            LeaveRequired = true;

            contentView = new View()
            {
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                PositionUsesPivotPoint = true
            };
            Add(contentView);
            contentView.RaiseToTop();

            LayoutDirectionChanged += OnLayoutDirectionChanged;
        }

        private void OnLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            LayoutChild();
        }

        private void CreateShadowAttributes()
        {
            if (popupAttributes.ShadowImageAttributes == null)
            {
                popupAttributes.ShadowImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                };
            }
        }

        private void CreateBackgroundAttributes()
        {
            if (popupAttributes.BackgroundImageAttributes == null)
            {
                popupAttributes.BackgroundImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center, 
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
            }
        }

        private void CreateTitleTextAttributes()
        {
            if (popupAttributes.TitleTextAttributes == null)
            {
                popupAttributes.TitleTextAttributes = new TextAttributes()
                {
                    Size2D =  new Size2D(0, 0),
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Bottom
                };
            }
        }

        private void CreateButtonAttributes()
        {
            if (popupAttributes.ButtonAttributes == null)
            {
                popupAttributes.ButtonAttributes = new ButtonAttributes()
                {
                    Size2D =  new Size2D(0, 0),
                    PositionUsesPivotPoint = true,
                    ParentOrigin =  Tizen.NUI.ParentOrigin.BottomLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
                    TextAttributes = new TextAttributes
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                        PivotPoint = Tizen.NUI.PivotPoint.Center,
                        HorizontalAlignment =  HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    },
                    BackgroundImageAttributes = new ImageAttributes
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin =  Tizen.NUI.ParentOrigin.Center,
                        PivotPoint = Tizen.NUI.PivotPoint.Center,
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                        Border = new RectangleSelector { All = new Rectangle(0, 0, 0, 0) },
                    },
                    OverlayImageAttributes = new ImageAttributes
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                        PivotPoint = Tizen.NUI.PivotPoint.Center,
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                        Border = new RectangleSelector { All = new Rectangle(0, 0, 0, 0) },
                    },
                };
            }
        }

        private void UpdateButton(int count)
        {
            if(buttonCount == count)
            {
                if (buttonList != null && buttonStyle != "" && buttonStyle == buttonPreStyle)
                {
                    return;
                }
                if (buttonList != null && buttonStyle == "")
                {
                    for (int i = 0; i < count; i++)
                    {
                        buttonList[i].TextColor = popupAttributes.ButtonAttributes.TextAttributes.TextColor.All;
                    }
                    return;
                }
            }
           
            if (buttonList != null)
            {
                foreach (Button btn in buttonList)
                {
                    btn.ClickEvent -= ButtonClickEvent;
                    this.Remove(btn);
                    btn.Dispose();
                }
                buttonList.Clear();
                buttonList = null;
            }
            if(count <= 0)
            {
                return;
            }
            int buttonWidth = Size2D.Width / count;
            int buttonHeight = popupAttributes.ButtonAttributes.Size2D.Height;
            int pos = 0;
            buttonList = new List<Button>();
            for (int i = 0; i < count; i++)
            {
                Button btn = null;
                if (buttonStyle != "")
                {
                    btn = new Button(buttonStyle);
                    btn.Size2D = new Size2D(buttonWidth, buttonHeight);
                    btn.ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft;
                    btn.PivotPoint = Tizen.NUI.PivotPoint.BottomLeft;
                    btn.PositionUsesPivotPoint = true;
                }
                else
                {
                    popupAttributes.ButtonAttributes.Size2D.Width = buttonWidth;
                    btn = new Button(popupAttributes.ButtonAttributes);
                }
                btn.Position2D = new Position2D(pos, 0);

                if (i >= buttonTextList.Count)
                {
                    buttonTextList.Add("");
                }
                btn.Text = buttonTextList[i];
                btn.ClickEvent += ButtonClickEvent;
                pos += buttonWidth;
                this.Add(btn);
                buttonList.Add(btn);
            }
            buttonPreStyle = buttonStyle;
        }

        private void ButtonClickEvent(object sender, Button.ClickEventArgs e)
        {
            if (PopupButtonClickedEvent != null && buttonList != null)
            {
                Button button = sender as Button;
                for (int i = 0; i < buttonList.Count; i++)
                {
                    if(button == buttonList[i])
                    {
                        ButtonClickEventArgs args = new ButtonClickEventArgs();
                        args.ButtonIndex = i;
                        PopupButtonClickedEvent(this, args);
                    }
                }
            }
        }

        public class ButtonClickEventArgs : EventArgs
        {
            /// <summary> Button index which is clicked in Popup </summary>
            public int ButtonIndex;
        }
    }
}
