using Tizen.NUI.CommonUI;
using Tizen.NUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Progress.VDProgressCircleStyle.xaml", "VDProgressCircleStyle.xaml", typeof(Tizen.FH.NUI.Controls.VDProgressCircleStyle))]
namespace Tizen.FH.NUI.Controls
{
    internal class VDProgressCircleStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            ProgressBarAttributes attributes = new ProgressBarAttributes
            {
                Size2D = new Size2D(90, 90),
                ProgressImageURLPrefix = new StringSelector
                {
                    All = "*DemoRes*/images/VD/component/c_progresscircle/circle_progress_m/circle_progress_whitem_",
                },
                TrackImageAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(90, 90),
                    ResourceURL = new StringSelector
                    {
                        All = "*DemoRes*/images/VD/component/c_progresscircle/circle_progress_m/circle_progress_whitem_00.png"
                    }
                },
                ProgressImageAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(90, 90),
                    ResourceURL = new StringSelector
                    {
                        All = "*DemoRes*/images/VD/component/c_progresscircle/circle_progress_m/circle_progress_whitem_00.png"
                    }
                },
                LoadingImageAttributes=new ImageAttributes
                {
                    Size2D = new Size2D(90, 90),
                    ResourceURL = new StringSelector
                    {
                        All = "*DemoRes*/images/VD/component/c_progresscircle/circle_progress_m/circle_progress_whitem_50.png"
                    }
                },
                BufferImageAttributes=new ImageAttributes
                {
                    Size2D = new Size2D(90, 90),
                    ResourceURL = new StringSelector
                    {
                        All = "*DemoRes*/images/VD/component/c_progresscircle/circle_progress_m/circle_progress_whitem_75.png"
                    }
                }
            };
            return attributes;
        }
    }
}
