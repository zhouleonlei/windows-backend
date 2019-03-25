using Tizen.NUI;
using Tizen.NUI.Controls;
using Tizen.NUI.Xaml;

namespace Tizen.FH.NUI.Controls
{
    internal class DefaultNaviFrameAttributes : AttributesContainer
    {
        protected override Attributes GetAttributes()
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
					Position2D = new Position2D(0, 0),
					Size2D = new Size2D(1080, 128),
                },
                ContentAttributes = new ViewAttributes
                {
                    Position2D = new Position2D(0, 128),
                    HeightResizePolicy = ResizePolicyType.FillToParent,
					WidthResizePolicy = ResizePolicyType.FillToParent,
                },
            };
            return attributes;
        }
    }
}
