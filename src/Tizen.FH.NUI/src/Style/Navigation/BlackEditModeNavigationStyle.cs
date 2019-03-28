using Tizen.NUI;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class BlackEditModeNavigationStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            NavigationAttributes attributes = new NavigationAttributes
            {
                ShadowImageAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(6, 800),
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_editmode_shadow_b.png" },
                },
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_editmode_bg_b.png" },
                },
                BackgroundColor = new ColorSelector { All = new Color(1, 1, 1, 0.9f) },
                IsFitWithItems = false,
            };

            return attributes;
        }
    }
}
