using System;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.FH.NUI.Samples
{
    public class NaviFrameSample : IExample
    {
        private View root;
        private Button NextButton;
        private Button BackButton;
        private NaviFrame  navi;
        private Header h1;
        private Header h2;
        private Header h3;
        private TextLabel c1;
        private TextLabel c2;
        private TextLabel c3;
        int i;
        public void Activate()
        {
            i = 0;
            Window window = Window.Instance;
              root = new View()
              {
                  Position2D = new Position2D(0, 0),
                  Size2D = new Size2D(1080, 900),
              };
              window.Add(root);

            navi = new NaviFrame("DefaultNaviFrame");
            root.Add(navi);
            AddItem();

            BackButton = new Button()
            {
                Size2D = new Size2D(90, 60),
                BackgroundColor = Color.Cyan,
                Text = "Back",
            };
            BackButton.PositionUsesPivotPoint = true;
            BackButton.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
            BackButton.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
            BackButton.ClickEvent += ClickBack;

            root.Add(BackButton);
            BackButton.RaiseToTop();
            NextButton = new Button()
            {
                Text = "Next",
                Size2D = new Size2D(90, 60),
                BackgroundColor = Color.Cyan,
            };
            NextButton.PositionUsesPivotPoint = true;
            NextButton.ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight;
            NextButton.PivotPoint = Tizen.NUI.PivotPoint.CenterRight;
            NextButton.ClickEvent += ClickNext;

            root.Add(NextButton);
            NextButton.RaiseToTop();
        }

        private Header MakeHeader(string txt)
        {
            Header head = new Header("DefaultHeader");
            head.BackgroundColor = new Color(255, 255, 255, 0.7f);
            head.HeaderText = "Title " + txt;
            return head;
        }
        private TextLabel MakeLabel(string txt)
        {
            TextLabel content = new TextLabel()
            {
                Text = txt,
                PointSize = 90,
                BackgroundColor = new Color(255, 255, 255, 0.7f),
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent,
            };

            return content;
        }
        private void AddItem()
        {

            h1 = MakeHeader("header1");
            c1 = MakeLabel("label1");
            h2 = MakeHeader("header2");
            c2 = MakeLabel("label2");
            h3 = MakeHeader("header3");
            c3 = MakeLabel("label3");
            navi.NaviframeItemPush(h1, c1);
            navi.NaviframeItemPush(h2, c2);
            navi.NaviframeItemPush(h3, c3);

        }

        private void ClickBack(object sender, Button.ClickEventArgs e)
        {
            if(navi!=null)
            {
                navi.NaviFrameItemPre();
            }
           
        }
        private void ClickNext(object sender, Button.ClickEventArgs e)
        {
            if (navi != null)
            {
                navi.NaviFrameItemNext();
            }
        }

        public void Deactivate()
        {
            if (root != null)
            {
               
                if (navi != null)
                {
                    root.Remove(navi);
                    navi.Dispose();
                }
                if (BackButton != null)
                {
                    root.Remove(BackButton);
                    BackButton.Dispose();
                }
                if (NextButton != null)
                {
                    root.Remove(NextButton);
                    NextButton.Dispose();
                }
               
                Window.Instance.Remove(root);
                root.Dispose();
            }
            if (h1 != null) h1.Dispose();
            if (h2 != null) h2.Dispose();
            if (h3 != null) h3.Dispose();
            if (c1 != null) c1.Dispose();
            if (c2 != null) c2.Dispose();
            if (c3 != null) c3.Dispose();
        }
    }
}
