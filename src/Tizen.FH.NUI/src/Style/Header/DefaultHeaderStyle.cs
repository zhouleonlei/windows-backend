using Tizen.NUI;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Controls
{
    internal class DefaultHeaderStyle : StyleBase
    {
        protected internal override Attributes GetAttributes()
        {
            if(Content != null)
            {
                return (Content as Attributes).Clone();
            }
            HeaderAttributes attributes = new HeaderAttributes
            {
                Size = new Size(1080, 128),
                BackgroundColor = new ColorSelector
                {
                    All = Utility.Hex2Color(0xffffff, 1)
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
                        All = Utility.Hex2Color(0x000000, 1)
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
                    Size = new Size(1080, 1),
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(0, 0, 0, 0.2f),
                    },
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    PositionUsesPivotPoint = true,
                    ParentOrigin = ParentOrigin.BottomLeft,
                    PivotPoint = PivotPoint.TopLeft,
                    Position = new Position(0, 0),
                },
            };
            return attributes;
        }
    }
}
