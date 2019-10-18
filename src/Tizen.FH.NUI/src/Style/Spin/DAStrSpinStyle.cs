using Tizen.NUI.Components;
using Tizen.NUI;

namespace Tizen.FH.NUI.Controls
{
    internal class DAStrSpinStyle : StyleBase
    {
        protected internal override Attributes GetAttributes()
        {
            SpinAttributes attributes = new SpinAttributes
            {
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                PositionUsesPivotPoint = true,
                ItemHeight = 116,
                TextSize = 50,
                CenterTextSize = 55,
                BackgroundImageAttributes = new ImageAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    PositionUsesPivotPoint = true,
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 81, 81) },
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "11. Popup/popup_background.png" }
                },
                ItemTextAttributes = new TextAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 50 },
                    TextColor = new ColorSelector { All = Color.Black},
                    Size = new Size(200, 116),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                NameTextAttributes = new TextAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 20 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Size = new Size(200, 56),
                    Position = new Position(0, 0),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                MaskTopImageAttributes = new ImageAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 1, 1) },
                    Size = new Size(200, 64),
                    Position = new Position(0, 76),
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/picker_mask_top.png" }
                },
                MaskBottomImageAttributes = new ImageAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 1, 1) },
                    Size = new Size(200, 64),
                    Position = new Position(0, 364),
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/picker_mask_bottom.png" }
                },
                NameViewAttributes = new ViewAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size = new Size(200, 56),
                    Position = new Position(0, 0)
                },
                ClipViewAttributes = new ViewAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size = new Size(200, 352),
                    Position = new Position(0, 76)
                },
                AniViewAttributes = new ViewAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size = new Size(200, 352),
                    Position = new Position(0, 0)
                },
                DividerRecAttributes = new ViewAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    BackgroundColor = new ColorSelector { All = Color.Black },
                    Opacity= new FloatSelector { All = 0.4f },
                    Size = new Size(200, 2),
                    Position = new Position(0, 176)
                },
                DividerRec2Attributes = new ViewAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    BackgroundColor = new ColorSelector { All = Color.Black },
                    Opacity = new FloatSelector { All = 0.4f },
                    Size = new Size(200, 2),
                    Position = new Position(0, 328)
                },
                TextFieldAttributes = new TextFieldAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 55 },
                    Size = new Size(200, 116),
                    Position = new Position(0, 116),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                }
            };
            return attributes;
        }
    }
}
