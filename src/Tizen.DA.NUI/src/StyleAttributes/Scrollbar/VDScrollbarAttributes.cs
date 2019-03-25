using Tizen.NUI.CommonUI;
using Tizen.NUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Scrollbar.VDScrollBarAttributes.xaml", "VDScrollBarAttributes.xaml", typeof(Tizen.FH.NUI.Controls.VDScrollBarAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class VDScrollBarAttributes : AttributesContainer
    {
        protected override Attributes GetAttributes()
        {
            ScrollBarAttributes attributes = new ScrollBarAttributes
            {
                TrackImageAttributes = new ImageAttributes
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(96.0f / 255.0f, 105.0f / 255.0f, 110.0f / 255.0f, 0.6f),//Color #60696e (Opacity : 60%)
                    }
                },
                ThumbImageAttributes = new ImageAttributes
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(13.0f / 255.0f, 13.0f / 255.0f, 13.0f / 255.0f, 1.0f)    //Color #0d0d0d
                    }
                },
            };
            return attributes;
        }
    }
}
