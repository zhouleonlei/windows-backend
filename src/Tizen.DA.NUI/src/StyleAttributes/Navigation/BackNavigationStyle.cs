using Tizen.NUI.CommonUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Navigation.BackNavigationStyle.xaml", "BackNavigationStyle.xaml", typeof(Tizen.FH.NUI.Controls.BackNavigationStyle))]
namespace Tizen.FH.NUI.Controls
{
    internal class BackNavigationStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            NavigationAttributes attributes = new NavigationAttributes
            {
                IsFitWithItems = true,
            };

            return attributes;
        }
    }
}
