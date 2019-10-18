using Tizen.NUI;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Controls
{
    internal class FoodDefaultSliderStyle : StyleBase
    {
        protected internal override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            SliderAttributes attributes = new SliderAttributes
            {
                TrackThickness = 4,
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
                        All = Utility.Hex2Color(Constants.APP_COLOR_FOOD, 1),
                    }
                },

                ThumbAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector
                    {
                        Normal = CommonResource.Instance.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_slide_handler_normal_ec7510.png",
                        Pressed = CommonResource.Instance.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_slide_handler_press_ec7510.png",
                    }
                },

                ThumbBackgroundAttributes = new ImageAttributes
                {
                    Size = new Size(60, 60),
                    ResourceURL = new StringSelector
                    {
                        Normal = "",
                        Pressed = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_btn_slide_handler_effect.png",
                    }
                }
            };

            return attributes;
        }
    }
}
