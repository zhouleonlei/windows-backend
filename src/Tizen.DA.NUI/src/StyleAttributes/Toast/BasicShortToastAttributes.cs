using Tizen.NUI.Binding;
using Tizen.NUI.Controls;
using Tizen.NUI.Xaml;
using Tizen.NUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Toast.BasicShortToastAttributes.xaml", "BasicShortToastAttributes.xaml", typeof(Tizen.FH.NUI.Controls.BasicShortToastAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class BasicShortToastAttributes : AttributesContainer
    {
        protected override Attributes GetAttributes()
        {
            ScrollBarAttributes attributes = new ScrollBarAttributes
            {
                TrackImageAttributes = new ImageAttributes
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(96.0f / 255.0f, 105.0f / 255.0f, 110.0f / 255.0f, 0.6f),
                    }
                },
                ThumbImageAttributes = new ImageAttributes
                {

                },
            };
            return attributes;
        }
    }
}
