namespace Tizen.NUI.CommonUI
{
    public class TabAttributes : ViewAttributes
    {      
        public TabAttributes() : base()
        {
            Space = new Vector4(0, 0, 0, 0);
            IsNatureTextWidth = false;
            ItemGap = 0;
        }
        public TabAttributes(TabAttributes attributes) : base(attributes)
        {
            if (attributes.UnderLineAttributes != null)
            {
                UnderLineAttributes = attributes.UnderLineAttributes.Clone() as ViewAttributes;
            }

            if (attributes.TextAttributes != null)
            {
                TextAttributes = attributes.TextAttributes.Clone() as TextAttributes;
            }

            if (attributes.Space != null)
            {
                Space = new Vector4(attributes.Space.X, attributes.Space.Y, attributes.Space.Z, attributes.Space.W);
            }
            else
            {
                Space = new Vector4(0, 0, 0, 0);
            }
            ItemGap = attributes.ItemGap;
            IsNatureTextWidth = attributes.IsNatureTextWidth;
        }

        public ViewAttributes UnderLineAttributes
        {
            get;
            set;
        }

        public TextAttributes TextAttributes
        {
            get;
            set;
        }

        public bool IsNatureTextWidth
        {
            get;
            set;
        }

        public int ItemGap
        {
            get;
            set;
        }

        public Vector4 Space
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new TabAttributes(this);
        }
    }
}
