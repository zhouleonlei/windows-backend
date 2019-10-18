using Tizen.NUI;
using Tizen.NUI.Components;
namespace Tizen.FH.NUI.Controls
{
    internal class FoodToggleButtonStyle : TextButtonStyle
    {
        protected internal override Attributes GetAttributes()
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
                Normal = Utility.Hex2Color(Constants.APP_COLOR_FOOD, 1),
                Selected = new Color(1, 1, 1, 1),
            };
            return attributes;
        }
    }
}
