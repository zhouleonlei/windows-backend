using Tizen.NUI.CommonUI;
using Tizen.NUI;

namespace Tizen.FH.NUI.Controls
{
    internal class KitchenTimePickerRepeatStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            TimePickerAttributes attributes = new TimePickerAttributes
            {
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                PositionUsesPivotPoint = true,
                ShadowOffset = new Vector4(1, 1, 1, 1),
                BackgroundImageAttributes = new ImageAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    PositionUsesPivotPoint = true,
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 81, 81) },
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "0. BG/background_default_overlay.png" }
                },
                TitleTextAttributes = new TextAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 20 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Text = new StringSelector {All = "Start Time"},
                    Size2D = new Size2D(1000, 52),
                    Position2D = new Position2D(64, 32),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Begin,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                HourSpinAttributes = new SpinAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size2D = new Size2D(200, 428),
                    Position2D = new Position2D(108, 116)
                },
                MinuteSpinAttributes = new SpinAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size2D = new Size2D(200, 428),
                    Position2D = new Position2D(416, 116)
                },
                AMPMSpinAttributes = new SpinAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size2D = new Size2D(200, 428),
                    Position2D = new Position2D(724, 116)
                },
                ColonImageAttributes = new ImageAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size2D = new Size2D(12, 152),
                    Position2D = new Position2D(0, 292),
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 1, 1) },
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/picker_time_colon.png" }
                },
                WeekViewAttributes = new ViewAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size2D = new Size2D(904, 236),
                    Position2D = new Position2D(64, 576)
                },
                WeekTitleTextAttributes = new TextAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 20 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Text = new StringSelector {All = "Repeat the Day"},
                    Size2D = new Size2D(904, 52),
                    Position2D = new Position2D(0, 0),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Begin,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                WeekSelectImageAttributes = new ImageAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 1, 1) },
                    Size2D = new Size2D(80, 80),
                    Position2D = new Position2D(0, 88),
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/picker_date_select_9762d9.png" }
                },
                WeekTextAttributes = new TextAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 15 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Text = new StringSelector {All = "Repeat the Day"},
                    Size2D = new Size2D(129, 88),
                    Position2D = new Position2D(0, 84),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                }
            };
            return attributes;
        }
    }
}
