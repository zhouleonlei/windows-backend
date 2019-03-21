using Tizen.NUI;
using Tizen.NUI.Controls;
using Tizen.NUI.Xaml;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.InputField.DefaultSearchInputFieldAttributes.xaml", "DefaultSearchInputFieldAttributes.xaml", typeof(Tizen.FH.NUI.Controls.DefaultSearchInputFieldAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class DefaultSearchInputFieldAttributes : AttributesContainer
    {
        protected override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            InputFieldAttributes attributes = new InputFieldAttributes
            {
                Space = 24,
                SpaceBetweenTextFieldAndLeftButton = 16,
                SpaceBetweenTextFieldAndRightButton = 56,
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector
                    {
                        All = CommonResource.Instance.GetFHResourcePath() + "1. Action bar/search_bg.png",
                    },
                    Border = new RectangleSelector
                    {
                        All = new Rectangle(45, 45, 0, 0),
                    },
                },
                InputBoxAttributes = new TextFieldAttributes
                {
                    TextColor = new ColorSelector
                    {
                        Normal = new Color(0, 0, 0, 1),
                        Pressed = new Color(0, 0, 0, 1),
                        Disabled = new Color(0, 0, 0, 0.4f)
                    },
                    PlaceholderTextColor = new ColorSelector
                    {
                        All = new Color(0, 0, 0, 0.4f),
                    },
                    PrimaryCursorColor = new ColorSelector
                    {
                        All = Utility.Hex2Color(0x0aaaf5, 1),
                    },
                    SecondaryCursorColor = new ColorSelector
                    {
                        All = Utility.Hex2Color(0x0aaaf5, 1),
                    },
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Center,
                    PointSize = new FloatSelector
                    {
                        All = 38,
                    },
                    FontFamily = "SamsungOne 500",
                    CursorWidth = 2,
                },
                CancelButtonAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(56, 56),
                    ResourceURL = new StringSelector
                    {
                        All = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/field_ic_cancel.png",
                    }
                },
                SearchButtonAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(56, 56),
                    ResourceURL = new StringSelector
                    {
                        All = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/search_ic_search.png",
                    }
                }
            };

            return attributes;
        }
    }
}
