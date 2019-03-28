using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    public class HeaderAttributes : ViewAttributes
    {   
        public HeaderAttributes() : base() { }
        public HeaderAttributes(HeaderAttributes attributes) : base(attributes)
        {
            if (attributes.TextAttributes != null)
            {
                TextAttributes = attributes.TextAttributes.Clone() as TextAttributes;
            }
            if (attributes.LineAttributes != null)
            {
                LineAttributes = attributes.LineAttributes.Clone() as ViewAttributes;
            }
        }


        public TextAttributes TextAttributes
        {
            get;
            set;
        }

        public ViewAttributes LineAttributes
        {
            get;
            set;
        }

       
        public override Attributes Clone()
        {
            return new HeaderAttributes(this);
        }
    }
}
