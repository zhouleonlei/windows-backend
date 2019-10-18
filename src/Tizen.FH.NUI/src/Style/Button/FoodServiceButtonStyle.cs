using Tizen.NUI;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Controls
{
    internal class FoodServiceButtonStyle : TextButtonStyle
    {
        protected internal override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            ButtonAttributes attributes = base.GetAttributes() as ButtonAttributes;
            attributes.IsSelectable = false;
            attributes.BackgroundImageAttributes.ResourceURL.All = CommonResource.Instance.GetFHResourcePath() + "3. Button/[Button] App Primary Color/rectangle_point_btn_normal_ec7510.png";
            attributes.TextAttributes.TextColor = new ColorSelector
            {
                Normal = new Color(1, 1, 1, 1),
                Pressed = new Color(1, 1, 1, 0.7f),
                Disabled = new Color(1, 1, 1, 0.4f),
            };
            return attributes;
        }
    }
}
