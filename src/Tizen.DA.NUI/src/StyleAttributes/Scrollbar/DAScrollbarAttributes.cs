using Tizen.NUI.CommonUI;
using Tizen.NUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Scrollbar.DAScrollBarAttributes.xaml", "DAScrollBarAttributes.xaml", typeof(Tizen.FH.NUI.Controls.DAScrollBarAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class DAScrollBarAttributes : StyleBase
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
