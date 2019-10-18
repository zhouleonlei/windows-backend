using Tizen.NUI;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Controls
{
    internal class BlackEditModeFirstNavigationItemStyle : StyleBase
    {
        protected internal override Attributes GetAttributes()
        {
            NavigationItemAttributes attributes = new NavigationItemAttributes
            {
                Space = new Vector4(24, 24, 0, 0),
                TextAttributes = new TextAttributes
                {
                    Size = new Size(130, 76),
                    Text = new StringSelector { All = "1" },
                    TextColor = new ColorSelector { All = new Color(14.0f / 255.0f, 14.0f / 255.0f, 230.0f / 255.0f, 1) },
                    PointSize = new FloatSelector { All = 32 },
                    FontFamily = "SamsungOneUI 300C",
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                },
                SubTextAttributes = new TextAttributes
                {
                    Size = new Size(130, 42),
                    Text = new StringSelector { All = "SELECTED" },
                    TextColor = new ColorSelector { All = new Color(1, 1, 1, 1) },
                    PointSize = new FloatSelector { All = 16 },
                    FontFamily = "SamsungOneUI 600",
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                },
                DividerLineAttributes = new ViewAttributes
                {
                    Size = new Size(178, 2),
                    BackgroundColor = new ColorSelector { All = new Color(1, 1, 1, 0.1f) },
                    Position = new Position(0, 166),
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                },
            };

            return attributes;
        }
    }
}
