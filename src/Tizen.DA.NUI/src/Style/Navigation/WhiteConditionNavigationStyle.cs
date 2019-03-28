using Tizen.NUI;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class WhiteConditionNavigationStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            NavigationAttributes attributes = new NavigationAttributes
            {
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/sidenavi_bg.png" },
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 103, 103) },
                },
                Space = new Vector4(8, 0, 40, 40),
                ItemGap = 2,
                DividerLineColor = new Color(0, 0, 0, 0.1f),
                IsFitWithItems = true,
            };

            return attributes;
        }
    }
}
