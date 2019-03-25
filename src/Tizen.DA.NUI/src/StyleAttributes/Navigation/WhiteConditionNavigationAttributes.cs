using Tizen.NUI;
using Tizen.NUI.CommonUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Navigation.WhiteConditionNavigationAttributes.xaml", "WhiteConditionNavigationAttributes.xaml", typeof(Tizen.FH.NUI.Controls.WhiteConditionNavigationAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class WhiteConditionNavigationAttributes : AttributesContainer
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
