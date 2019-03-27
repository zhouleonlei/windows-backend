using Tizen.NUI;
using Tizen.NUI.CommonUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.SearchBar.DefaultSearchBarStyle.xaml", "DefaultSearchBarStyle.xaml", typeof(Tizen.FH.NUI.Controls.DefaultSearchBarStyle))]
namespace Tizen.FH.NUI.Controls
{
    internal class DefaultSearchBarStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            SearchBarAttributes attributes = new SearchBarAttributes
            {
                Space = 56,
                SearchBoxAttributes = new InputFieldAttributes(),
                ResultListAttributes = new ViewAttributes
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(0.8f, 0.8f, 0.8f, 0.8f),
                    }
                },
            };

            return attributes;
        }
    }
}
