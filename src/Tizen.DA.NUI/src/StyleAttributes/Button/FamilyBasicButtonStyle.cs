using Tizen.NUI;
using Tizen.NUI.CommonUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Button.FamilyBasicButtonAttributes.xaml", "FamilyBasicButtonAttributes.xaml", typeof(Tizen.FH.NUI.Controls.FamilyBasicButtonStyle))]
namespace Tizen.FH.NUI.Controls
{
    internal class FamilyBasicButtonStyle : TextButtonStyle
    {
        protected override Attributes GetAttributes()
        {
            if(Content != null)
            {
                return (Content as Attributes).Clone();
            }
            ButtonAttributes attributes = base.GetAttributes() as ButtonAttributes;
            attributes.TextAttributes.TextColor.Selected = Utility.Hex2Color(Constants.APP_COLOR_FAMILY, 1); 
            return attributes;
        }
    }
}
