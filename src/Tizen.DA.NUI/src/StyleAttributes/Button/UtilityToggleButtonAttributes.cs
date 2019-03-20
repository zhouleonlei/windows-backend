using Tizen.NUI;
using Tizen.NUI.Controls;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Button.UtilityToggleButtonAttributes.xaml", "UtilityToggleButtonAttributes.xaml", typeof(Tizen.FH.NUI.Controls.UtilityToggleButtonAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class UtilityToggleButtonAttributes : TextButtonAttributes
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
                Normal = CommonResource.Instance.GetFHResourcePath() + "3. Button/rectangle_toggle_btn_normal.png",
                Selected = CommonResource.Instance.GetFHResourcePath() + "3. Button/rectangle_point_btn_normal.png",

            };
            attributes.TextAttributes.TextColor = new ColorSelector
            {
                Normal = new Color(0.058f, 0.631f, 0.92f, 1),
                Selected = new Color(1, 1, 1, 1),
            };
            return attributes;
        }
    }
}
