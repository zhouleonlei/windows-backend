using Tizen.NUI;
using Tizen.NUI.CommonUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Progress.FoodProgressbarAttributes.xaml", "FoodProgressbarAttributes.xaml", typeof(Tizen.FH.NUI.Controls.FoodProgressbarAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class FoodProgressbarAttributes : AttributesContainer
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
                        All = Utility.Hex2Color(Constants.APP_COLOR_FOOD, 1)
                    }
                },
            };
            return attributes;
        }
    }
}
