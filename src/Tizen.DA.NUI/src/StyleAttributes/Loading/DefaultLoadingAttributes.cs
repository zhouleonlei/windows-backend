using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.Controls;
using Tizen.NUI.Xaml;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Loading.DefaultLoadingAttributes.xaml", "DefaultLoadingAttributes.xaml", typeof(Tizen.FH.NUI.Controls.DefaultLoadingAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class DefaultLoadingAttributes : AttributesContainer
    {
        protected override Attributes GetAttributes()
        {
            LoadingAttributes attributes = new LoadingAttributes
            {
                LoadingImageURLPrefix = new StringSelector
                {
                    All = "*DemoRes*/images/FH3/9. Controller/Loading Sequence_Native/loading_",
                }
            };
            return attributes;
        }
    }
}
