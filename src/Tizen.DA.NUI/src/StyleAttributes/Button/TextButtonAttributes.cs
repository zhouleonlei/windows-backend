using Tizen.NUI;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class TextButtonAttributes : StyleBase
    {
        public TextButtonAttributes()
        {

        }
        protected override Attributes GetAttributes()
        {
            ButtonAttributes attributes = new ButtonAttributes
            {
                IsSelectable = true,
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "3. Button/rectangle_btn_normal.png" },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) }
                },

                ShadowImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png" },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) }
                },

                OverlayImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector { Pressed = CommonResource.Instance.GetFHResourcePath() + "3. Button/rectangle_btn_press_overlay.png", Other = "" },
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
                        Selected = Utility.Hex2Color(Constants.APP_COLOR_UTILITY, 1),
                        Disabled = new Color(0, 0, 0, 0.4f),
                    },
                }
            };
            return attributes;
        }
    }
}

