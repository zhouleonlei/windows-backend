using Tizen.NUI.CommonUI;
using Tizen.NUI;

namespace Tizen.FH.NUI.Controls
{
    internal class BasicShortToasStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            ToastAttributes attributes = new ToastAttributes
            {
                Size2D = new Tizen.NUI.Size2D(512, 132),
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector
                    {
                        All = CommonResource.Instance.GetFHResourcePath() + "12. Toast Popup/toast_background.png",
                    },
                    Border = new RectangleSelector
                    {
                        All = new Tizen.NUI.Rectangle(64, 64, 4, 4)
                    }
                },

                TextAttributes = new TextAttributes
                {
                    PaddingTop = 38,
                    PaddingBottom = 38,
                    PaddingLeft = 96,
                    PaddingRight = 96,
                    PointSize = new FloatSelector { All = 26, },
                    TextColor = new ColorSelector { All = Color.White, }
                }
            };
            return attributes;
        }
    }
}
