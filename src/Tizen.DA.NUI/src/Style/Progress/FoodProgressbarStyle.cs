using Tizen.NUI;
using Tizen.NUI.CommonUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Progress.FoodProgressbarStyle.xaml", "FoodProgressbarStyle.xaml", typeof(Tizen.FH.NUI.Controls.FoodProgressbarStyle))]
namespace Tizen.FH.NUI.Controls
{
    internal class FoodProgressbarStyle : StyleBase
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
