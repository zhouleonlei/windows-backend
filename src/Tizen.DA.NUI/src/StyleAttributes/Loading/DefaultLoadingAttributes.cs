using Tizen.NUI.CommonUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Loading.DefaultLoadingAttributes.xaml", "DefaultLoadingAttributes.xaml", typeof(Tizen.FH.NUI.Controls.DefaultLoadingAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class DefaultLoadingAttributes : AttributesContainer
    {
        protected override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            LoadingAttributes attributes = new LoadingAttributes
            {
                LoadingImageURLPrefix = new StringSelector
                {
                    All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/Loading Sequence_Native/loading_",
                }
            };
            return attributes;
        }
    }
}
