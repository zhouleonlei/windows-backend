using Tizen.NUI;
using Tizen.NUI.Controls;
using Tizen.NUI.Xaml;
[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Button.KitchenBasicButtonAttributes.xaml", "KitchenBasicButtonAttributes.xaml", typeof(Tizen.FH.NUI.Controls.KitchenBasicButtonAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class KitchenBasicButtonAttributes : TextButtonAttributes
    {
        protected override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            ButtonAttributes attributes = base.GetAttributes() as ButtonAttributes;
            attributes.TextAttributes.TextColor.Selected = new Color(0.592f, 0.384f, 0.851f, 1);
            return attributes;
        }
    }
}
