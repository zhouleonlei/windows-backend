using Tizen.NUI.Xaml;
using Tizen.NUI;
using Tizen.NUI.Controls;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Switch.ListIndexSwitchAttributes.xaml", "ListIndexSwitchAttributes.xaml", typeof(Tizen.FH.NUI.Controls.ListIndexSwitchAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class ListIndexSwitchAttributes : AttributesContainer
    {
        protected override Attributes GetAttributes()
        {
            SwitchAttributes attributes = new SwitchAttributes
            {
                IsSelectable = true,
                SwitchBackgroundImageAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(72, 48),
                    ResourceURL = new StringSelector
                    {
                        Normal = CommonResource.Instance.GetFHResourcePath() + "6. List/list_index_swich_bg_off.png",
                        Selected = CommonResource.Instance.GetFHResourcePath() + "6. List/list_index_swich_bg_on.png",
                        Disabled = CommonResource.Instance.GetFHResourcePath() + "6. List/list_index_swich_bg_off_dim.png",
                        DisabledSelected = CommonResource.Instance.GetFHResourcePath() + "6. List/list_index_swich_bg_on_dim.png",
                    },
                },
                SwitchHandlerImageAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(48, 48),
                    ResourceURL = new StringSelector
                    {
                        Normal = CommonResource.Instance.GetFHResourcePath() + "6. List/list_index_controller_swich.png",
                        Selected = CommonResource.Instance.GetFHResourcePath() + "6. List/list_index_controller_swich.png",
                        Disabled = CommonResource.Instance.GetFHResourcePath() + "6. List/list_index_controller_swich_dim.png",
                        DisabledSelected = CommonResource.Instance.GetFHResourcePath() + "6. List/list_index_controller_swich_dim.png",
                    },
                },
            };

            return attributes;
        }
    }
}
