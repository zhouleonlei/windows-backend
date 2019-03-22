using Tizen.NUI;
using Tizen.NUI.Controls;
using Tizen.NUI.Xaml;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Slider.KitchenTextSliderAttributes.xaml", "KitchenTextSliderAttributes.xaml", typeof(Tizen.FH.NUI.Controls.KitchenTextSliderAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class KitchenTextSliderAttributes : AttributesContainer
    {
        protected override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            SliderAttributes attributes = new SliderAttributes
            {
                TrackThickness = 4,
                SpaceBetweenTrackAndIndicator = 48,
                IndicatorType = Slider.IndicatorType.Text,
                BackgroundTrackAttributes = new ImageAttributes
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(0, 0, 0, 0.1f),
                    }
                },

                SlidedTrackAttributes = new ImageAttributes
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = Utility.Hex2Color(Constants.APP_COLOR_KITCHEN, 1),
                    }
                },

                ThumbAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector
                    {
                        Normal = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_btn_slide_handler_normal.png",
                        Pressed = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_btn_slide_handler_press.png",
                    }
                },

                ThumbBackgroundAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(60, 60),
                    ResourceURL = new StringSelector
                    {
                        Normal = "",
                        Pressed = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_btn_slide_handler_effect.png",
                    }
                },

                LowIndicatorTextAttributes = new TextAttributes
                {
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = "SamsungOne 400",
                    TextColor = new ColorSelector
                    {
                        All = new Color(0, 0, 0, 0.75f),
                    }
                }
            };

            return attributes;
        }
    }
}
