using Tizen.NUI;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class TransparencyHeaderAttributes : AttributesContainer
    {
        protected override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            HeaderAttributes attributes = new HeaderAttributes
            {
                Size2D = new Size2D(1080, 128),
                BackgroundColor = new ColorSelector
                {
                    All = new Color(1, 1, 1, 0)
                },
                TextAttributes = new TextAttributes
                {
                    FontFamily = "SamsungOne 500",
                    PointSize = new FloatSelector
                    {
                        All = 50,
                    },
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextColor = new ColorSelector
                    {
                        All = new Color(1, 1, 1, 1)
                    },
                    PositionUsesPivotPoint = true,
                    ParentOrigin = ParentOrigin.Center,
                    PivotPoint = PivotPoint.Center,
                    WidthResizePolicy = ResizePolicyType.SizeFixedOffsetFromParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    SizeModeFactor = new Vector3(-112, 0, 0),
                },
                LineAttributes = new ViewAttributes
                {
                    Size2D = new Size2D(1080, 1),
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(1, 1, 1, 0.2f),
                    },
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    PositionUsesPivotPoint = true,
                    ParentOrigin = ParentOrigin.BottomLeft,
                    PivotPoint = PivotPoint.TopLeft,
                    Position2D = new Position2D(0, 0),
                },
            };
            return attributes;
        }
    }
}

