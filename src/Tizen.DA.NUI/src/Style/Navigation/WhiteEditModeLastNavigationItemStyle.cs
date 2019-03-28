using Tizen.NUI;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class WhiteEditModeLastNavigationItemStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            NavigationItemAttributes attributes = new NavigationItemAttributes
            {
                Space = new Vector4(24, 24, 58, 0),
                TextAttributes = new TextAttributes
                {
                    Size2D = new Size2D(130, 52),
                    TextColor = new ColorSelector { All = new Color(0, 0, 0, 0.85f) },
                    PointSize = new FloatSelector { All = 8 },
                    FontFamily = "SamsungOneUI 500C",
                    Text = new StringSelector { All = "Cancel" },
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                },
                IconAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(56, 56),
                    ResourceURL = new StringSelector
                    {
                        Pressed = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_cancel_press.png",
                        Disabled = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_cancel_dim.png",
                        DisabledFocused = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_cancel_dim.png",
                        DisabledSelected = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_cancel_dim.png",
                        Other = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_cancel.png"
                    },
                },
                DividerLineAttributes = new ViewAttributes
                {
                    Size2D = new Size2D(178, 2),
                    BackgroundColor = new ColorSelector { All = new Color(0, 0, 0, 0.1f) },
                    Position2D = new Position2D(0, 16),
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                },
            };

            return attributes;
        }
    }
}
