using Tizen.NUI.CommonUI;
using Tizen.NUI.Xaml;
[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Button.KitchenOvalButtonAttributes.xaml", "KitchenOvalButtonAttributes.xaml", typeof(Tizen.FH.NUI.Controls.KitchenOvalButtonAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class KitchenOvalButtonAttributes : IconButtonAttributes
    {
        protected override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            ButtonAttributes attributes = base.GetAttributes() as ButtonAttributes;
            attributes.BackgroundImageAttributes.ResourceURL.Selected = CommonResource.Instance.GetFHResourcePath() + "3. Button/[Button] App Primary Color/oval_toggle_btn_select_9762d9.png";
            return attributes;
        }
    }
}
