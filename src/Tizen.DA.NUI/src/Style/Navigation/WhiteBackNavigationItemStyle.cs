using Tizen.NUI;
using Tizen.NUI.CommonUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Navigation.WhiteBackNavigationItemStyle.xaml", "WhiteBackNavigationItemStyle.xaml", typeof(Tizen.FH.NUI.Controls.WhiteBackNavigationItemStyle))]
namespace Tizen.FH.NUI.Controls
{
    internal class WhiteBackNavigationItemStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            NavigationItemAttributes attributes = new NavigationItemAttributes
            {
                Size2D = new Size2D(120, 140),
                IconAttributes = new ImageAttributes()
                {
                    Size2D = new Size2D(56, 56),
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_back.png" },
                },
                BackgroundImageAttributes = new ImageAttributes()
                {
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/sidenavi_back_bg.png" },
                },
                OverlayImageAttributes = new ImageAttributes()
                {
                    ResourceURL = new StringSelector
                    {
                        Pressed = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/sidenavi_back_bg_press_overlay.png",
                        Other = "",
                    },
                },
                EnableIconCenter = true
            };

            return attributes;
        }
    }
}
