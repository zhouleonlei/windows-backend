
using Tizen.NUI.CommonUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Button.FamilyOvalButtonAttributes.xaml", "FamilyOvalButtonAttributes.xaml", typeof(Tizen.FH.NUI.Controls.FamilyOvalButtonAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class FamilyOvalButtonAttributes : IconButtonAttributes
    {
        protected override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            ButtonAttributes attributes = base.GetAttributes() as ButtonAttributes;
            attributes.BackgroundImageAttributes.ResourceURL.Selected = CommonResource.Instance.GetFHResourcePath() + "3. Button/[Button] App Primary Color/oval_toggle_btn_select_24c447.png";
            return attributes;

        }
    }
}
