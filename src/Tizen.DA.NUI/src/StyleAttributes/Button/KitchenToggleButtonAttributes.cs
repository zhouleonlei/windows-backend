using Tizen.NUI;
using Tizen.NUI.Controls;
using Tizen.NUI.Xaml;
[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Button.KitchenToggleButtonAttributes.xaml", "KitchenToggleButtonAttributes.xaml", typeof(Tizen.FH.NUI.Controls.KitchenToggleButtonAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class KitchenToggleButtonAttributes : TextButtonAttributes
    {
        protected override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            ButtonAttributes attributes = base.GetAttributes() as ButtonAttributes;
            attributes.BackgroundImageAttributes.ResourceURL = new StringSelector
            {
                Normal = CommonResource.Instance.GetFHResourcePath() + "3. Button/[Button] App Primary Color/rectangle_toggle_btn_normal_9762d9.png",
                Selected = CommonResource.Instance.GetFHResourcePath() + "3. Button/[Button] App Primary Color/rectangle_point_btn_normal_9762d9.png",

            };
            attributes.TextAttributes.TextColor = new ColorSelector
            {
                Normal = new Color(0.592f, 0.384f, 0.851f, 1),
                Selected = new Color(1, 1, 1, 1),
            };
            return attributes;
        }
    }
}
