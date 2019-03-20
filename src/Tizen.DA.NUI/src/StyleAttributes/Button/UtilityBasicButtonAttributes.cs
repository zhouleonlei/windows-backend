using Tizen.NUI.Controls;
using Tizen.NUI.Xaml;
[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Button.UtilityBasicButtonAttributes.xaml", "UtilityBasicButtonAttributes.xaml", typeof(Tizen.FH.NUI.Controls.UtilityBasicButtonAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class UtilityBasicButtonAttributes : TextButtonAttributes
    {
        protected override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            return base.GetAttributes();
        }
    }
}
