using Tizen.NUI;
using Tizen.NUI.CommonUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.RadioButton.KitchenRadioButtonAttributes.xaml", "KitchenRadioButtonAttributes.xaml", typeof(Tizen.FH.NUI.Controls.KitchenRadioButtonAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class KitchenRadioButtonAttributes : AttributesContainer
    {
        protected override Attributes GetAttributes()
        {
            SelectButtonAttributes attributes = new SelectButtonAttributes
            {
                CheckImageAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(48, 48),
                    Position2D = new Position2D(0, 0),
                    ResourceURL = new StringSelector
                    {
                        Normal = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_btn_radio_off.png",
                        Selected = CommonResource.Instance.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_radio_on_9762d9.png",
                        Disabled = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_btn_radio_off.png",
                        DisabledSelected = CommonResource.Instance.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_radio_on_9762d9.png",
                    },
                    Opacity = new FloatSelector
                    {
                        Normal = 1.0f,
                        Selected = 1.0f,
                        Disabled = 0.4f,
                        DisabledSelected = 0.4f
                    },
                },
            };

            return attributes;
        }
    }
}
