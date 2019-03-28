using Tizen.NUI.CommonUI;

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
