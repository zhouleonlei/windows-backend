using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.NUI.Samples
{
    public class PopupSample : IExample
    {
        private View root;

        private TextLabel[] createText = new TextLabel[2];

        private Popup popup = null;
        private Popup popup2 = null;
        private TextLabel contentText = null;
        private TextLabel contentText2 = null;
        private int index = 0;
        private int index2 = 0;

        private static string[] buttonStyles = new string[]
        {
            "UtilityPopupButton",
            "FamilyPopupButton",
            "FoodPopupButton",
            "KitchenPopupButton",
        };
        private static Color[] color = new Color[]
        {
            new Color(0.05f, 0.63f, 0.9f, 1),//#ff0ea1e6
            new Color(0.14f, 0.77f, 0.28f, 1),//#ff24c447
            new Color(0.75f, 0.46f, 0.06f, 1),//#ffec7510
            new Color(0.59f, 0.38f, 0.85f, 1),//#ff9762d9
        };
        public void Activate()
        {
            Window window = Window.Instance;

            root = new View()
            {
                Size2D = new Size2D(1920, 1080),
            };
            window.Add(root);

            ///////////////////////////////////////////////Create by Property//////////////////////////////////////////////////////////
            createText[0] = new TextLabel();
            createText[0].Text = "Create Popup just by properties";
            createText[0].Size2D = new Size2D(500, 100);
            createText[0].Position2D = new Position2D(700, 50);
            root.Add(createText[0]);

            popup = new Popup();
            popup.MinimumSize = new Size2D(1032, 184);
            popup.Size2D = new Size2D(1032, 400);
            popup.Position2D = new Position2D(400, 100);

            popup.TitlePointSize = 25;
            popup.TitleTextColor = Color.Black;
            popup.TitleHeight = 68;
            popup.TitleTextHorizontalAlignment = HorizontalAlignment.Begin;
            popup.TitleTextPosition2D = new Position2D(64, 52);
            popup.TitleText = "Popup Title";

            popup.ShadowImageURL = CommonReosurce.GetFHResourcePath() + "11. Popup/popup_background_shadow.png";
            popup.ShadowImageBorder = new Rectangle(0, 0, 105, 105);
            popup.ShadowOffset = new Vector4(24, 24, 24, 24);
            popup.BackgroundImageURL = CommonReosurce.GetFHResourcePath() + "11. Popup/popup_background.png";
            popup.BackgroundImageBorder = new Rectangle(0, 0, 81, 81);

            popup.ButtonBackgroundImageURL = CommonReosurce.GetFHResourcePath() + "3. Button/rectangle_btn_normal.png";
            popup.ButtonBackgroundImageBorder = new Rectangle(5, 5, 5, 5);
            popup.ButtonOverLayBackgroundColorSelector = new ColorSelector
            {
                Normal = new Color(1.0f, 1.0f, 1.0f, 1.0f),
                Pressed = new Color(0.0f, 0.0f, 0.0f, 0.1f),
                Selected = new Color(1.0f, 1.0f, 1.0f, 1.0f),
            };
            popup.ButtonTextColor = color[index];
            popup.ButtonHeight = 132;
            popup.ButtonCount = 2;
            popup.SetButtonText(0, "Yes");
            popup.SetButtonText(1, "Exit");
            popup.PopupButtonClickedEvent += PopupButtonClickedEvent;

            root.Add(popup);

            contentText = new TextLabel();
            contentText.Size2D = new Size2D(800, 100);
            contentText.PointSize = 20;
            contentText.HorizontalAlignment = HorizontalAlignment.Begin;
            contentText.VerticalAlignment = VerticalAlignment.Center;
            contentText.Text = "Popup ButtonStyle is " + buttonStyles[index];          
            popup.ContentView.Add(contentText);

            ///////////////////////////////////////////////Create by Attributes//////////////////////////////////////////////////////////
            createText[1] = new TextLabel();
            createText[1].Text = "Create Popup just by Attributes";
            createText[1].Size2D = new Size2D(500, 100);
            createText[1].Position2D = new Position2D(700, 550);
            root.Add(createText[1]);

            PopupAttributes attrs = new PopupAttributes
            {
                MinimumSize = new Size2DSelector{ All = new Size2D(1032, 184) },
                ShadowOffset = new Vector4(24, 24, 24, 24),
                TitleTextAttributes = new TextAttributes
                {
                    PointSize = new FloatSelector { All = 25 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Size2D = new Size2DSelector { All = new Size2D(0, 68) },
                    PositionUsesPivotPoint = new BoolSelector { All = true },
                    ParentOrigin = new PositionSelector { All = Tizen.NUI.ParentOrigin.TopLeft },
                    PivotPoint = new PositionSelector { All = Tizen.NUI.PivotPoint.TopLeft },
                    HorizontalAlignment = new HorizontalAlignmentSelector { All = HorizontalAlignment.Begin },
                    VerticalAlignment = new VerticalAlignmentSelector { All = VerticalAlignment.Bottom },
                    Position2D = new Position2DSelector { All = new Position2D(64, 52) },
                    Text = new StringSelector { All = "Popup Title" },
                },
                ShadowImageAttributes = new ImageAttributes
                {
                    PositionUsesPivotPoint = new BoolSelector { All = true },
                    ParentOrigin = new PositionSelector { All = Tizen.NUI.ParentOrigin.Center },
                    PivotPoint = new PositionSelector { All = Tizen.NUI.PivotPoint.Center },
                    ResourceURL = new StringSelector { All = CommonReosurce.GetFHResourcePath() + "11. Popup/popup_background_shadow.png" },
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 105, 105) },
                },
                BackgroundImageAttributes = new ImageAttributes
                {
                    PositionUsesPivotPoint = new BoolSelector { All = true },
                    ParentOrigin = new PositionSelector { All = Tizen.NUI.ParentOrigin.Center },
                    PivotPoint = new PositionSelector { All = Tizen.NUI.PivotPoint.Center },
                    WidthResizePolicy = new ResizePolicyTypeSelector { All = ResizePolicyType.FillToParent },
                    HeightResizePolicy = new ResizePolicyTypeSelector { All = ResizePolicyType.FillToParent },
                    ResourceURL = new StringSelector { All = CommonReosurce.GetFHResourcePath() + "11. Popup/popup_background.png" },
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 81, 81) },
                },
                ButtonAttributes = new ButtonAttributes
                {
                    Size2D = new Size2DSelector { All = new Size2D(0, 132) },
                    PositionUsesPivotPoint = new BoolSelector { All = true },
                    ParentOrigin = new PositionSelector { All = Tizen.NUI.ParentOrigin.BottomLeft },
                    PivotPoint = new PositionSelector { All = Tizen.NUI.PivotPoint.BottomLeft },
                    BackgroundImageAttributes = new ImageAttributes
                    {
                        PositionUsesPivotPoint = new BoolSelector { All = true },
                        ParentOrigin = new PositionSelector { All = Tizen.NUI.ParentOrigin.Center },
                        PivotPoint = new PositionSelector { All = Tizen.NUI.PivotPoint.Center },
                        WidthResizePolicy = new ResizePolicyTypeSelector { All = ResizePolicyType.FillToParent },
                        HeightResizePolicy = new ResizePolicyTypeSelector { All = ResizePolicyType.FillToParent },
                        ResourceURL = new StringSelector { All = CommonReosurce.GetFHResourcePath() + "3. Button/rectangle_btn_normal.png" },
                        Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) },
                    },
                    OverlayImageAttributes = new ImageAttributes
                    {
                        PositionUsesPivotPoint = new BoolSelector { All = true },
                        ParentOrigin = new PositionSelector { All = Tizen.NUI.ParentOrigin.Center },
                        PivotPoint = new PositionSelector { All = Tizen.NUI.PivotPoint.Center },
                        WidthResizePolicy = new ResizePolicyTypeSelector { All = ResizePolicyType.FillToParent },
                        HeightResizePolicy = new ResizePolicyTypeSelector { All = ResizePolicyType.FillToParent },
                        BackgroundColor = new ColorSelector
                        {
                            Normal = new Color(1.0f, 1.0f, 1.0f, 1.0f),
                            Pressed = new Color(0.0f, 0.0f, 0.0f, 0.1f),
                            Selected = new Color(1.0f, 1.0f, 1.0f, 1.0f),
                        },
                    },
                    TextAttributes = new TextAttributes
                    {
                        PositionUsesPivotPoint = new BoolSelector { All = true },
                        ParentOrigin = new PositionSelector { All = Tizen.NUI.ParentOrigin.Center },
                        PivotPoint = new PositionSelector { All = Tizen.NUI.PivotPoint.Center },
                        HorizontalAlignment = new HorizontalAlignmentSelector { All = HorizontalAlignment.Center },
                        VerticalAlignment = new VerticalAlignmentSelector { All = VerticalAlignment.Center },
                        TextColor = new ColorSelector { All = color[index2] },
                    },
                },
            };

            popup2 = new Popup(attrs);
            popup2.Size2D = new Size2D(1032, 400);
            popup2.Position2D = new Position2D(400, 600);
            popup2.ButtonCount = 2;
            popup2.SetButtonText(0, "Yes");
            popup2.SetButtonText(1, "Exit");
            popup2.PopupButtonClickedEvent += PopupButtonClickedEvent;

            root.Add(popup2);

            contentText2 = new TextLabel();
            contentText2.Size2D = new Size2D(800, 100);
            contentText2.PointSize = 20;
            contentText2.HorizontalAlignment = HorizontalAlignment.Begin;
            contentText2.VerticalAlignment = VerticalAlignment.Center;
            contentText2.Text = "Popup2 ButtonStyle is " + buttonStyles[index];
            popup2.ContentView.Add(contentText2);
        }

        private void PopupButtonClickedEvent(object sender, Popup.ButtonClickEventArgs e)
        {
            Popup obj = sender as Popup;
            if (obj != null && e.ButtonIndex == 0)
            {
                if(obj == popup)
                {
                    index++;
                    index = index % buttonStyles.Length;
                    obj.ButtonTextColor = color[index];
                    contentText.Text = "Popup ButtonStyle is " + buttonStyles[index];
                }
                else
                {
                    index2++;
                    index2 = index2 % buttonStyles.Length;
                    obj.ButtonTextColor = color[index2];
                    contentText2.Text = "Popup2 ButtonStyle is " + buttonStyles[index2];
                }               
            }
        }

        public void Deactivate()
        {
            if (root != null)
            {
                popup.ContentView.Remove(contentText);
                contentText.Dispose();
                contentText = null;

                root.Remove(popup);
                popup.Dispose();
                popup = null;

                popup2.ContentView.Remove(contentText2);
                contentText2.Dispose();
                contentText2 = null;

                root.Remove(popup2);
                popup2.Dispose();
                popup2 = null;
                
                root.Remove(createText[0]);
                createText[0].Dispose();
                createText[0] = null;
                root.Remove(createText[1]);
                createText[1].Dispose();
                createText[1] = null;

                Window.Instance.Remove(root);
                root.Dispose();
            }
        }
    }
}
