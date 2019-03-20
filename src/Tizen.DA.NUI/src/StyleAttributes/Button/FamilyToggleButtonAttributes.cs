using Tizen.NUI;
using Tizen.NUI.Controls;
using Tizen.NUI.Xaml;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Button.FamilyToggleButtonAttributes.xaml", "FamilyToggleButtonAttributes.xaml", typeof(Tizen.FH.NUI.Controls.FamilyToggleButtonAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class FamilyToggleButtonAttributes : TextButtonAttributes
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
                Normal = CommonResource.Instance.GetFHResourcePath() + "3. Button/[Button] App Primary Color/rectangle_toggle_btn_normal_24c447.png",
                Selected = CommonResource.Instance.GetFHResourcePath() + "3. Button/[Button] App Primary Color/rectangle_point_btn_normal_24c447.png",

            };
            attributes.TextAttributes.TextColor = new ColorSelector
            {
                Normal = new Color(0.141f, 0.769f, 0.278f, 1),
                Selected = new Color(1, 1, 1, 1),
            };
            return attributes;
        }
    }
}
