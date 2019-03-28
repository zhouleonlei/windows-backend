using Tizen.NUI.CommonUI;
using Tizen.NUI;

namespace Tizen.FH.NUI.Controls
{
    internal class DATimePickerAMPMStyle : StyleBase
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
                HourSpinAttributes = new SpinAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size2D = new Size2D(200, 428),
                    Position2D = new Position2D(108, 32)
                },
                MinuteSpinAttributes = new SpinAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size2D = new Size2D(200, 428),
                    Position2D = new Position2D(416, 32)
                },
                AMPMSpinAttributes = new SpinAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size2D = new Size2D(200, 428),
                    Position2D = new Position2D(724, 32)
                },
                ColonImageAttributes = new ImageAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size2D = new Size2D(12, 152),
                    Position2D = new Position2D(0, 208),
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 1, 1) },
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/picker_time_colon.png" }
                }
            };
            return attributes;
        }
    }
}
