using Tizen.NUI.CommonUI;
using Tizen.NUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Progress.FamilyProgressbarStyle.xaml", "FamilyProgressbarStyle.xaml", typeof(Tizen.FH.NUI.Controls.FamilyProgressbarStyle))]
namespace Tizen.FH.NUI.Controls
{
    internal class FamilyProgressbarStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            ProgressBarAttributes attributes = new ProgressBarAttributes
            {
                TrackImageAttributes = new ImageAttributes
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(0.0f, 0.0f, 0.0f, 0.1f),
                    }
                },
                ProgressImageAttributes = new ImageAttributes
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = Utility.Hex2Color(Constants.APP_COLOR_FAMILY, 1)
                    }
                },
            };
            return attributes;
        }
    }
}
