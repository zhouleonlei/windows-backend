using Tizen.NUI.CommonUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Loading.DefaultLoadingStyle.xaml", "DefaultLoadingStyle.xaml", typeof(Tizen.FH.NUI.Controls.DefaultLoadingStyle))]
namespace Tizen.FH.NUI.Controls
{
    internal class DefaultLoadingStyle : StyleBase
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
