using Tizen.NUI;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Controls
{
    internal class TextListItemStyle : StyleBase
    {
        protected internal override Attributes GetAttributes()
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
                    Position = new Position(28, 0),
                },
                CheckImageAttributes = new ImageAttributes
                {
                    Size = new Size(40, 40),
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "10. Drop Down/dropdown_checkbox_on.png" },
                },
                CheckImageRightSpace = 16,
            };

            return attributes;
        }
    }
}
