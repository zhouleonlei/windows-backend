using Tizen.NUI;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Controls
{
    internal class DefaultNaviFrameStyle : StyleBase
    {
        protected internal override Attributes GetAttributes()
        {
            if(Content != null)
            {
                return (Content as Attributes).Clone();
            }
            NaviFrameAttributes attributes = new NaviFrameAttributes
            {
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                NaviHeaderAttributes = new ViewAttributes
                {
					Position = new Position(0, 0),
					Size = new Size(1080, 128),
                },
                ContentAttributes = new ViewAttributes
                {
                    Position = new Position(0, 128),
                    HeightResizePolicy = ResizePolicyType.FillToParent,
					WidthResizePolicy = ResizePolicyType.FillToParent,
                },
            };
            return attributes;
        }
    }
}
