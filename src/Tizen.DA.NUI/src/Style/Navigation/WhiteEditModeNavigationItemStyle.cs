using Tizen.NUI;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class WhiteEditModeNavigationItemStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            NavigationItemAttributes attributes = new NavigationItemAttributes
            {
                TextAttributes = new TextAttributes
                {
                    Size2D = new Size2D(130, 52),
                    TextColor = new ColorSelector
                    {
                        Pressed = new Color(0, 0, 0, 1),
                        Disabled = new Color(0, 0, 0, 0.4f),
                        Other = new Color(0, 0, 0, 1),
                    },
                    PointSize = new FloatSelector { All = 8 },
                    FontFamily = "SamsungOneUI 500C",
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                },
                IconAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(56, 56),
                },
                Space = new Vector4(24, 24, 24, 24),
            };

            return attributes;
        }
    }
}
