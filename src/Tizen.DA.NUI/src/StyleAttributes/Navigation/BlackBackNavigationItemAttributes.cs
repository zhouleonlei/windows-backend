using Tizen.NUI;
using Tizen.NUI.CommonUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Navigation.BlackBackNavigationItemAttributes.xaml", "BlackBackNavigationItemAttributes.xaml", typeof(Tizen.FH.NUI.Controls.BlackBackNavigationItemAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class BlackBackNavigationItemAttributes : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            NavigationItemAttributes attributes = new NavigationItemAttributes
            {
                Size2D = new Size2D(120, 140),
                IconAttributes = new ImageAttributes()
                {
                    Size2D = new Size2D(56, 56),
                    ResourceURL = new StringSelector
                    {
                        Pressed = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_back_b_press.png",
                        Other = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_back_b.png"
                    },
                },
                BackgroundImageAttributes = new ImageAttributes()
                {
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_back_bg_b.png" },
                },
                EnableIconCenter = true
            };

            return attributes;
        }
    }
}
