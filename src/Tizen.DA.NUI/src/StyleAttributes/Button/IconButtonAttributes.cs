using Tizen.NUI;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class IconButtonAttributes : StyleBase
    {
        public IconButtonAttributes()
        {
   
        }
        protected override Attributes GetAttributes()
        {
            ButtonAttributes attributes = new ButtonAttributes
            {
                IsSelectable = true,
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector
                    {
                        Normal = CommonResource.Instance.GetFHResourcePath() + "3. Button/oval_toggle_btn_normal.png",
                        Selected = CommonResource.Instance.GetFHResourcePath() + "3. Button/oval_toggle_btn_select.png",
                    },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) }
                },

                ShadowImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "3. Button/oval_toggle_btn_shadow.png" },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) }
                },

                OverlayImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector { Pressed = CommonResource.Instance.GetFHResourcePath() + "3. Button/oval_toggle_btn_press_overlay.png", Other = "" },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) },
                },

                IconAttributes = new ImageAttributes
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                }
            };
            return attributes;
        }
    }
}
