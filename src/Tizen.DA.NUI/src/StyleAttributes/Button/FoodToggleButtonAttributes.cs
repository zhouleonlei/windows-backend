using Tizen.NUI;
using Tizen.NUI.Controls;
using Tizen.NUI.Xaml;
[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Button.FoodToggleButtonAttributes.xaml", "FoodToggleButtonAttributes.xaml", typeof(Tizen.FH.NUI.Controls.FoodToggleButtonAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class FoodToggleButtonAttributes : TextButtonAttributes
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
                Normal = CommonResource.Instance.GetFHResourcePath() + "3. Button/[Button] App Primary Color/rectangle_toggle_btn_normal_ec7510.png",
                Selected = CommonResource.Instance.GetFHResourcePath() + "3. Button/[Button] App Primary Color/rectangle_point_btn_normal_ec7510.png",

            };
            attributes.TextAttributes.TextColor = new ColorSelector
            {
                Normal = new Color(0.925f, 0.489f, 0.063f, 1),
                Selected = new Color(1, 1, 1, 1),
            };
            return attributes;
        }
    }
}
