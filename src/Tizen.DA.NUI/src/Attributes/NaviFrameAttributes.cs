
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    public class NaviFrameAttributes : ViewAttributes
    {
        public NaviFrameAttributes() : base() { }
        public NaviFrameAttributes(NaviFrameAttributes attributes) : base(attributes)
        {
            if (attributes.NaviHeaderAttributes != null)
            {
                NaviHeaderAttributes = attributes.NaviHeaderAttributes.Clone() as ViewAttributes;
            }
            if (attributes.ContentAttributes != null)
            {
                ContentAttributes = attributes.ContentAttributes.Clone() as ViewAttributes;
            }

        }

        public ViewAttributes NaviHeaderAttributes
        {
            get;
            set;
        }

        public ViewAttributes ContentAttributes
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new NaviFrameAttributes(this);
        }
    }
}
