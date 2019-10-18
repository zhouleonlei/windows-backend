using Tizen.NUI;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Controls
{
    internal class UtilityRadioButtonStyle : StyleBase
    {
        protected internal override Attributes GetAttributes()
        {
            SelectButtonAttributes attributes = new SelectButtonAttributes
            {
                CheckImageAttributes = new ImageAttributes
                {
                    Size = new Size(48, 48),
                    Position = new Position(0, 0),
                    ResourceURL = new StringSelector
                    {
                        Normal = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_btn_radio_off.png",
                        Selected = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_btn_radio_on.png",
                        Disabled = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_btn_radio_off.png",
                        DisabledSelected = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_btn_radio_on.png",
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
