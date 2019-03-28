using Tizen.NUI;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class WhiteEditModeNavigationStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            NavigationAttributes attributes = new NavigationAttributes
            {
                ShadowImageAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(6, 800),
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/sidenavi_editmode_shadow.png" },
                },
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/sidenavi_editmode_bg.png" },
                },
                BackgroundColor = new ColorSelector { All = new Color(1, 1, 1, 0.9f) },
                IsFitWithItems = false,
            };

            return attributes;
        }
    }
}
