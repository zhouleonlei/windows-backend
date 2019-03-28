namespace Tizen.NUI.CommonUI
{
    public class PaginationAttributes : ViewAttributes
    {
        public PaginationAttributes() : base() { }
        public PaginationAttributes(PaginationAttributes attributes) : base(attributes)
        {
            if (attributes.IndicatorSize != null)
            {
                IndicatorSize = new Size2D(attributes.IndicatorSize.Width, attributes.IndicatorSize.Height);
            }
            if (attributes.IndicatorBackgroundURL != null)
            {
                IndicatorBackgroundURL = attributes.IndicatorBackgroundURL.Clone() as string;
            }
            if (attributes.IndicatorSelectURL != null)
            {
                IndicatorSelectURL = attributes.IndicatorSelectURL.Clone() as string;
            }
            IndicatorSpacing = attributes.IndicatorSpacing;
        }

        public Size2D IndicatorSize
        {
            get;
            set;
        }

        public string IndicatorBackgroundURL
        {
            get;
            set;
        }

        public string IndicatorSelectURL
        {
            get;
            set;
        }

        public int IndicatorSpacing
        {
            get;
            set;
        }


        public override Attributes Clone()
        {
            return new PaginationAttributes(this);
        }

    }
}
