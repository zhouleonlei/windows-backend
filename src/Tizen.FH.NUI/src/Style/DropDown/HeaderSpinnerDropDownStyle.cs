using Tizen.NUI;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class HeaderSpinnerDropDownStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            DropDownAttributes attributes = new DropDownAttributes
            {
                HeaderTextAttributes = new TextAttributes
                {
                    PointSize = new FloatSelector { All = 28 },
                    TextColor = new ColorSelector { All = new Color(0, 0, 0, 1) },
                    FontFamily = "SamsungOneUI 500C",
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                },

                ButtonAttributes = new ButtonAttributes
                {
                    TextAttributes = new TextAttributes
                    {
                        PointSize = new FloatSelector { All = 20 },
                        TextColor = new ColorSelector { All = new Color(0, 0, 0, 1) },
                        FontFamily = "SamsungOneUI 500",
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                        WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                        Position2D = new Position2D(0, 0),
                        HorizontalAlignment = HorizontalAlignment.Begin,
                        VerticalAlignment = VerticalAlignment.Center,
                    },
                    IconAttributes = new ImageAttributes
                    {
                        Size2D = new Size2D(48, 48),
                        ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "6. List/list_ic_dropdown.png" },
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight,
                        PivotPoint = Tizen.NUI.PivotPoint.CenterRight,
                    },
                },
                ListBackgroundImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "10. Drop Down/dropdown_bg.png" },
                    Border = new RectangleSelector { All = new Rectangle(51, 51, 51, 51) },
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    WidthResizePolicy = ResizePolicyType.FitToChildren,
                    HeightResizePolicy = ResizePolicyType.FitToChildren,
                },
                Space = new Vector4(56, 0, 0, 0),
                SpaceBetweenButtonTextAndIcon = 8,
                ListMargin = new Vector4(20, 0, 20, 0),
                BackgroundColor = new ColorSelector { All = new Color(1, 1, 1, 1) },
                ListPadding = new Extents(4, 4, 4, 4),
            };
            return attributes;
        }
    }
}
