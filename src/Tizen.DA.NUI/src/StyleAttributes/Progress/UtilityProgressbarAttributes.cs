using Tizen.NUI.Binding;
using Tizen.NUI.Controls;
using Tizen.NUI.Xaml;
using Tizen.NUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Progress.UtilityProgressbarAttributes.xaml", "UtilityProgressbarAttributes.xaml", typeof(Tizen.FH.NUI.Controls.UtilityProgressbarAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class UtilityProgressbarAttributes : AttributesContainer
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
                        All = Utility.Hex2Color(Constants.APP_COLOR_UTILITY, 1)
                    }
                },
            };
            return attributes;
        }
    }
}
