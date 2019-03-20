using Tizen.NUI.Controls;
using Tizen.NUI.Xaml;
[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Button.FoodOvalButtonAttributes.xaml", "FoodOvalButtonAttributes.xaml", typeof(Tizen.FH.NUI.Controls.FoodOvalButtonAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class FoodOvalButtonAttributes : IconButtonAttributes
    {
        protected override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            ButtonAttributes attributes = base.GetAttributes() as ButtonAttributes;
            attributes.BackgroundImageAttributes.ResourceURL.Selected = CommonResource.Instance.GetFHResourcePath() + "3. Button/[Button] App Primary Color/oval_toggle_btn_select_ec7510.png";
            return attributes;
        }
    }
}
