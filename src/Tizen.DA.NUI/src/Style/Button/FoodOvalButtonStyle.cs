using Tizen.NUI.CommonUI;
namespace Tizen.FH.NUI.Controls
{
    internal class FoodOvalButtonStyle : IconButtonStyle
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
