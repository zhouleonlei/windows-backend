using Tizen.NUI;
using Tizen.NUI.Controls;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Button.FamilyBasicButtonAttributes.xaml", "FamilyBasicButtonAttributes.xaml", typeof(Tizen.FH.NUI.Controls.FamilyBasicButtonAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class FamilyBasicButtonAttributes : TextButtonAttributes
    {
        protected override Attributes GetAttributes()
        {
            if(Content != null)
            {
                return (Content as Attributes).Clone();
            }
            ButtonAttributes attributes = base.GetAttributes() as ButtonAttributes;
            attributes.TextAttributes.TextColor.Selected = new Color(0.141f, 0.769f, 0.278f, 1); 
            return attributes;
        }
    }
}
