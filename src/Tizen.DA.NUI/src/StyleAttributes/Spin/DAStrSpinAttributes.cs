using Tizen.NUI.CommonUI;
using Tizen.NUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Spin.StrSpinAttributes.xaml", "StrSpinAttributes.xaml", typeof(Tizen.FH.NUI.Controls.DAStrSpinAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class DAStrSpinAttributes : AttributesContainer
    {
        protected override Attributes GetAttributes()
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
                TextAttrs = new TextAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 50 },
                    TextColor = new ColorSelector { All = Color.Black},
                    Size2D = new Size2D(200, 116),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                NameTextAttrs = new TextAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 20 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Size2D = new Size2D(200, 56),
                    Position2D = new Position2D(0, 0),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                MaskTopImageAttributes = new ImageAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 1, 1) },
                    Size2D = new Size2D(200, 64),
                    Position2D = new Position2D(0, 76),
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/picker_mask_top.png" }
                },
                MaskBottomImageAttributes = new ImageAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 1, 1) },
                    Size2D = new Size2D(200, 64),
                    Position2D = new Position2D(0, 364),
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/picker_mask_bottom.png" }
                },
                NameViewAttributes = new ViewAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size2D = new Size2D(200, 56),
                    Position2D = new Position2D(0, 0)
                },
                ClipViewAttributes = new ViewAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size2D = new Size2D(200, 352),
                    Position2D = new Position2D(0, 76)
                },
                AniViewAttributes = new ViewAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size2D = new Size2D(200, 352),
                    Position2D = new Position2D(0, 0)
                },
                DividerRecAttrs = new ViewAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    BackgroundColor = new ColorSelector { All = Color.Black },
                    Opacity= new FloatSelector { All = 0.4f },
                    Size2D = new Size2D(200, 2),
                    Position2D = new Position2D(0, 176)
                },
                DividerRec2Attrs = new ViewAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    BackgroundColor = new ColorSelector { All = Color.Black },
                    Opacity = new FloatSelector { All = 0.4f },
                    Size2D = new Size2D(200, 2),
                    Position2D = new Position2D(0, 328)
                },
                TextFieldAttrs = new TextFieldAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 55 },
                    Size2D = new Size2D(200, 116),
                    Position2D = new Position2D(0, 116),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                }
            };
            return attributes;
        }
    }
}
