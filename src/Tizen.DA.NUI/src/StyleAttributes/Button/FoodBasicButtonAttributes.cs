using Tizen.NUI;
using Tizen.NUI.Controls;
using Tizen.NUI.Xaml;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Button.FoodBasicButtonAttributes.xaml", "FoodBasicButtonAttributes.xaml", typeof(Tizen.FH.NUI.Controls.FoodBasicButtonAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class FoodBasicButtonAttributes : TextButtonAttributes
    {
        protected override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            ButtonAttributes attributes = base.GetAttributes() as ButtonAttributes;
            attributes.TextAttributes.TextColor.Selected = Utility.Hex2Color(Constants.APP_COLOR_FOOD, 1);
            return attributes;
        }
    }
}
