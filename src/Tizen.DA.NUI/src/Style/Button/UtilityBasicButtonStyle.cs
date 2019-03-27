using Tizen.NUI.CommonUI;
using Tizen.NUI.Xaml;
[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Button.UtilityBasicButtonStyle.xaml", "UtilityBasicButtonStyle.xaml", typeof(Tizen.FH.NUI.Controls.UtilityBasicButtonStyle))]
namespace Tizen.FH.NUI.Controls
{
    internal class UtilityBasicButtonStyle : TextButtonStyle
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
