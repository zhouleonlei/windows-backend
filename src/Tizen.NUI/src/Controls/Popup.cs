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

        private PopupAttributes popupAttributes;
        private int buttonCount = 0;
        private string buttonStyle = null;


        //static constructor used to register internal style
        static Popup()
        {
            RegisterStyle("Popup", typeof(PopupAttributes));
        }

        public Popup() : this("Text") { }
        public Popup(string style) : base(style)
        {
            Initialize();
        }

        public event EventHandler<ButtonClickEventArgs> PopupButtonClickedEvent;

        public string TitleText
        {
            get
            {
                return titleText?.Text;
            }
            set
            {
                if (titleText != null)
                {
                    titleText.Text = value;
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
                    UpdateButton(value, buttonStyle);
                    buttonCount = value;
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

        public void SetButtonText(int index, string text)
        {
            if(index < 0 && index >= buttonCount)
            {
                return;
            }
            buttonList[index].Text = text;
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
                    this.Remove(titleText);
                    titleText.Dispose();
                    titleText = null;
                }
                if (backgroundImage != null)
                {
                    this.Remove(backgroundImage);
                    backgroundImage.Dispose();
                    backgroundImage = null;
                }
                if (shadowImage != null)
                {
                    this.Remove(shadowImage);
                    shadowImage.Dispose();
                    shadowImage = null;
                }
                if(buttonList != null)
                {
                    foreach(Button btn in buttonList)
                    {
                        this.Remove(btn);
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
            return null;
        }

        protected override void OnUpdate(Attributes attributtes)
        {
            popupAttributes = attributes as PopupAttributes;
            if (popupAttributes == null)
            {
                return;
            }

            ApplyAttributes(this, popupAttributes);            
            ApplyAttributes(shadowImage, popupAttributes.ShadowImageAttributes);
            ApplyAttributes(backgroundImage, popupAttributes.BackgroundImageAttributes);          
            ApplyAttributes(titleText, popupAttributes.TitleTextAttributes);

            int w = 0;
            int h = 0;
            if (shadowImage != null)
            {
                w = (int)(Size2D.Width + popupAttributes.ShadowOffset.W + popupAttributes.ShadowOffset.X);
                h = (int)(Size2D.Height + popupAttributes.ShadowOffset.Y + popupAttributes.ShadowOffset.Z);
                shadowImage.Size2D = new Size2D(w, h);
            }
            if (titleText != null)
            {
                w = (int)(Size2D.Width - titleText.PositionX * 2);
                h = titleText.Size2D.Height;
                titleText.Size2D = new Size2D(w, h);
            }

            UpdateButton(buttonCount, popupAttributes.ButtonStyle);
            buttonStyle = popupAttributes.ButtonStyle;

            w = Size2D.Width - titleText.Position2D.X * 2;
            h = Size2D.Height - titleText.Position2D.Y - titleText.Size2D.Height - popupAttributes.ButtonHeight;
            int x = titleText.Position2D.X;
            int y = titleText.Position2D.Y + titleText.Size2D.Height;
            contentView.Size2D = new Size2D(w, h);
            contentView.Position2D = new Position2D(x, y);
        }

        private void Initialize()
        {
            popupAttributes = attributes as PopupAttributes;
            if (popupAttributes == null)
            {
                throw new Exception("Popup attribute parse error.");
            }

            StateFocusableOnTouchMode = true;
            LeaveRequired = true;
            //default settings
            buttonStyle = popupAttributes.ButtonStyle;

            if (popupAttributes.ShadowImageAttributes != null)
            {
                shadowImage = new ImageView();
                Add(shadowImage);
            }

            if (popupAttributes.BackgroundImageAttributes != null)
            {
                backgroundImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
                Add(backgroundImage);
            }

            if (popupAttributes.TitleTextAttributes != null)
            {
                titleText = new TextLabel();
                Add(titleText);
            }

            contentView = new View()
            {
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                PositionUsesPivotPoint = true
            };
            Add(contentView);
        }

        private void UpdateButton(int count, string style)
        {
            if(buttonCount == count && style == buttonStyle)
            {
                return;
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
            int buttonHeight = popupAttributes.ButtonHeight;
            int pos = 0;
            buttonList = new List<Button>();
            for (int i = 0; i < count; i++)
            {
                Button btn = new Button(style);
                btn.Size2D = new Size2D(buttonWidth, buttonHeight);
                btn.ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft;
                btn.PivotPoint = Tizen.NUI.PivotPoint.BottomLeft;
                btn.PositionUsesPivotPoint = true;
                btn.Position2D = new Position2D(pos, 0);
                btn.ClickEvent += ButtonClickEvent;
                pos += buttonWidth;
                this.Add(btn);
                buttonList.Add(btn);
            }
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
