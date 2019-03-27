using Tizen.NUI.CommonUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Navigation.BackNavigationAttributes.xaml", "BackNavigationAttributes.xaml", typeof(Tizen.FH.NUI.Controls.BackNavigationAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class BackNavigationAttributes : StyleBase
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
