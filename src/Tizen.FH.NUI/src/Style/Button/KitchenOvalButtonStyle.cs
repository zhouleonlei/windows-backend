using Tizen.NUI.Components;
namespace Tizen.FH.NUI.Controls
{
    internal class KitchenOvalButtonStyle : IconButtonStyle
    {
        protected internal override Attributes GetAttributes()
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
