using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.FH.NUI.Samples
{
    public class SampleLayout : View
    {
        private Header LayoutHeader;

        private Button UtilityButton;
        private Button FoodButton;
        private Button FamilyButton;
        private Button KitchenButton;


        public SampleLayout()
        {
            Size2D = new Size2D(Window.Instance.Size.Width, Window.Instance.Size.Height);
            Window.Instance.Add(this);
            LayoutHeader = new Header("DefaultHeader");
            base.Add(LayoutHeader);

            ButtonAttributes buttonAttributes = new ButtonAttributes
            {
                IsSelectable = true,
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector { All = CommonReosurce.GetFHResourcePath() + "3. Button/rectangle_btn_normal.png" },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) }
                },

                ShadowImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector { All = CommonReosurce.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png" },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) }
                },

                OverlayImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector { Pressed = CommonReosurce.GetFHResourcePath() + "3. Button/rectangle_btn_press_overlay.png", Other = "" },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) },
                },

                TextAttributes = new TextAttributes
                {
                    PointSize = new FloatSelector { All = 20 },
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,

                    TextColor = new ColorSelector
                    {
                        Normal = new Color(0, 0, 0, 1),
                        Pressed = new Color(0, 0, 0, 0.7f),
                        Selected = new Color(0.141f, 0.769f, 0.278f, 1),
                        Disabled = new Color(0, 0, 0, 0.4f),
                    },
                }
            };

            UtilityButton = new Button(buttonAttributes);
            UtilityButton.Size2D = new Size2D(200, 100);
            UtilityButton.Position2D = new Position2D(100, 300);
            UtilityButton.PointSize = 30;
            UtilityButton.Text = "Utility";
            base.Add(UtilityButton);

        }

        public string HeaderText
        {
            get
            {
                return LayoutHeader.HeaderText;
            }

            set
            {
                LayoutHeader.HeaderText = value;
            }
        }
    }
}
