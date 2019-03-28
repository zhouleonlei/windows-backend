using Tizen.NUI;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class FoodPopupStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            PopupAttributes attributes = new PopupAttributes
            {
                MinimumSize = new Size2D(1032, 184),
                ShadowOffset = new Vector4(24, 24, 24, 24),
                TitleTextAttributes = new TextAttributes
                {
                    PointSize = new FloatSelector { All = 25 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Size2D = new Size2D(0, 68),
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Position2D = new Position2D(64, 52),
                },
                ShadowImageAttributes = new ImageAttributes
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "11. Popup/popup_background_shadow.png" },
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 105, 105) },
                },
                BackgroundImageAttributes = new ImageAttributes
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "11. Popup/popup_background.png" },
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 81, 81) },
                },
                ButtonAttributes = new ButtonAttributes
                {
                    Size2D = new Size2D(0, 132),
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
                    BackgroundImageAttributes = new ImageAttributes
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                        PivotPoint = Tizen.NUI.PivotPoint.Center,
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                        ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "3. Button/rectangle_btn_normal.png" },
                        Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) },
                    },
                    OverlayImageAttributes = new ImageAttributes
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                        PivotPoint = Tizen.NUI.PivotPoint.Center,
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                        BackgroundColor = new ColorSelector
                        {
                            Normal = new Color(1.0f, 1.0f, 1.0f, 1.0f),
                            Pressed = new Color(0.0f, 0.0f, 0.0f, 0.1f),
                            Selected = new Color(1.0f, 1.0f, 1.0f, 1.0f),
                        },
                    },
                    TextAttributes = new TextAttributes
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                        PivotPoint = Tizen.NUI.PivotPoint.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        TextColor = new ColorSelector { All = Utility.Hex2Color(Constants.APP_COLOR_FOOD, 1) },
                    },
                },
            };
            return attributes;
        }
    }
}
