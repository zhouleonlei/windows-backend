using Tizen.NUI;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class UtilitySwitchStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            SwitchAttributes attributes = new SwitchAttributes
            {
                IsSelectable = true,
                SwitchBackgroundImageAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(96, 60),
                    ResourceURL = new StringSelector
                    {
                        Normal = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_switch_bg_off.png",
                        Selected = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_switch_bg_on.png",
                        Disabled = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_switch_bg_off_dim.png",
                        DisabledSelected = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_switch_bg_on_dim.png",
                    },
                },
                SwitchHandlerImageAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(60, 60),
                    ResourceURL = new StringSelector
                    {
                        Normal = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_switch_handler.png",
                        Selected = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_switch_handler.png",
                        Disabled = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_switch_handler_dim.png",
                        DisabledSelected = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_switch_handler_dim.png",
                    },
                },
            };

            return attributes;
        }          
    }
}
