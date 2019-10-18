using Tizen.NUI;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Controls
{
    internal class WhiteEditModeNavigationStyle : StyleBase
    {
        protected internal override Attributes GetAttributes()
        {
            NavigationAttributes attributes = new NavigationAttributes
            {
                ShadowImageAttributes = new ImageAttributes
                {
                    Size = new Size(6, 800),
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
