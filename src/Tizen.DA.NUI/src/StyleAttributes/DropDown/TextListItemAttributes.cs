using Tizen.NUI.Xaml;
using Tizen.NUI;
using Tizen.NUI.Controls;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.DropDown.TextListItemAttributes.xaml", "TextListItemAttributes.xaml", typeof(Tizen.FH.NUI.Controls.TextListItemAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class TextListItemAttributes : AttributesContainer
    {
        protected override Attributes GetAttributes()
        {
            DropDownItemAttributes attributes = new DropDownItemAttributes
            {
                BackgroundColor = new ColorSelector
                {
                    Pressed = new Color(0, 0, 0, 0.4f),
                    Other = new Color(1, 1, 1, 0),
                },
                TextAttributes = new TextAttributes
                {
                    PointSize = new FloatSelector { All = 18 },
                    FontFamily = "SamsungOne 500",
                    Position2D = new Position2D(28, 0),
                },
                CheckImageAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(40, 40),
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "10. Drop Down/dropdown_checkbox_on.png" },
                },
                CheckImageRightSpace = 16,
            };

            return attributes;
        }
    }
}
