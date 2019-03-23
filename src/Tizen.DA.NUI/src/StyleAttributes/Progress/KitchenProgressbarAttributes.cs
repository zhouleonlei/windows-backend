using Tizen.NUI.Binding;
using Tizen.NUI.Controls;
using Tizen.NUI.Xaml;
using Tizen.NUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Progress.KitchenProgressbarAttributes.xaml", "KitchenProgressbarAttributes.xaml", typeof(Tizen.FH.NUI.Controls.KitchenProgressbarAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class KitchenProgressbarAttributes : AttributesContainer
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
                        All = Utility.Hex2Color(Constants.APP_COLOR_KITCHEN, 1)
                    }
                },
            };
            return attributes;
        }
    }
}
