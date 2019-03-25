using Tizen.NUI;
using Tizen.NUI.CommonUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.InputField.FoodStyleBInputFieldAttributes.xaml", "FoodStyleBInputFieldAttributes.xaml", typeof(Tizen.FH.NUI.Controls.FoodStyleBInputFieldAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class FoodStyleBInputFieldAttributes : AttributesContainer
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
                AddButtonBgAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(92, 92),
                    ResourceURL = new StringSelector
                    {
                        Normal = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/[Input Field] App Primary Color/field_btn_add_bg_ec7510.png",
                        Pressed = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/[Input Field] App Primary Color/field_btn_add_bg_ec7510.png",
                        Disabled = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/[Input Field] App Primary Color/field_btn_add_bg_dim_ec7510.png",
                    }
                },
                AddButtonFgAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector
                    {
                        Normal = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/html/input_btn_add_ec7510_normal.png",
                        Pressed = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/html/input_btn_add_ec7510_press.png",
                        Disabled = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/html/input_btn_add_ec7510_dim.png",
                    }
                },
                AddButtonOverlayAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector
                    {
                        Normal = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/field_btn_add_bg_press_overlay.png",
                        Other = "",
                    }
                },

                DeleteButtonAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(92, 92),
                    ResourceURL = new StringSelector
                    {
                        Normal = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/field_btn_ic_delete.png",
                        Pressed = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/field_btn_ic_delete_press.png",
                        Disabled = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/field_btn_ic_delete_dim.png",
                    }
                },
            };

            return attributes;
        }
    }
}
