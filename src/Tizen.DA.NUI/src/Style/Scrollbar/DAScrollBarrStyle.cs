using Tizen.NUI.CommonUI;
using Tizen.NUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Scrollbar.DAScrollBarStyle.xaml", "DAScrollBarStyle.xaml", typeof(Tizen.FH.NUI.Controls.DAScrollBarStyle))]
namespace Tizen.FH.NUI.Controls
{
    internal class DAScrollBarStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            ScrollBarAttributes attributes = new ScrollBarAttributes
            {
                TrackImageAttributes = new ImageAttributes
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(0.43f, 0.43f, 0.43f, 0.6f),
                    }
                },
                ThumbImageAttributes = new ImageAttributes
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(0.0f, 0.0f, 0.0f, 0.2f)
                    }
                },
            };
            return attributes;
        }
    }
}
