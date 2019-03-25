using Tizen.NUI;
using Tizen.NUI.CommonUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.DropDown.IconListItemAttributes.xaml", "IconListItemAttributes.xaml", typeof(Tizen.FH.NUI.Controls.IconListItemAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class IconListItemAttributes : AttributesContainer
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
                IconAttributes = new ImageAttributes
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    Size2D = new Size2D(28, 28),
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
