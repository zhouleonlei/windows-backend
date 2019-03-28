using Tizen.NUI;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class UtilityServiceButtonStyle : TextButtonStyle
    {
        protected override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            ButtonAttributes attributes = base.GetAttributes() as ButtonAttributes;
            attributes.IsSelectable = false;
            attributes.BackgroundImageAttributes.ResourceURL.All = CommonResource.Instance.GetFHResourcePath() + "3. Button/rectangle_point_btn_normal.png";
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
