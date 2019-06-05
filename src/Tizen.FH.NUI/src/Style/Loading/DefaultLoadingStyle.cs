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
            string[] imageArray = new string[36];
            for (int i = 0; i < 36; i++)
            {
                if (i < 10)
                {
                    imageArray[i] = CommonResource.Instance.GetFHResourcePath() + "9. Controller/Loading Sequence_Native/loading_0" + i + ".png";
                }
                else
                {
                    imageArray[i] = CommonResource.Instance.GetFHResourcePath() + "9. Controller/Loading Sequence_Native/loading_" + i + ".png";
                }
            }

            LoadingAttributes attributes = new LoadingAttributes { ImageArray = imageArray };
            return attributes;
        }
    }
}
