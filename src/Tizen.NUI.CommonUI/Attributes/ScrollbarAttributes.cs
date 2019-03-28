namespace Tizen.NUI.CommonUI
{
    public class ScrollBarAttributes : ViewAttributes
    {      
        public ScrollBarAttributes() : base()
        {
            Direction = ScrollBar.DirectionType.Horizontal;
        }

        public ScrollBarAttributes(ScrollBarAttributes attributes) : base(attributes)
        {
            if (attributes.TrackImageAttributes != null)
            {
                TrackImageAttributes = attributes.TrackImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.ThumbImageAttributes != null)
            {
                ThumbImageAttributes = attributes.ThumbImageAttributes.Clone() as ImageAttributes;
            }

            Direction = attributes.Direction;
            MaxValue = attributes.MaxValue;
            MinValue = attributes.MinValue;
            CurValue = attributes.CurValue;
            Duration = attributes.Duration;
        }

        public ImageAttributes TrackImageAttributes
        {
            get;
            set;
        }

        public ImageAttributes ThumbImageAttributes
        {
            get;
            set;
        }

        public ScrollBar.DirectionType? Direction
        {
            get;
            set;
        }

        public uint MaxValue
        {
            get;
            set;
        }

        public uint MinValue
        {
            get;
            set;
        }
        // can't change the pos of thumb
        public uint CurValue
        {
            get;
            set;
        }

        public uint Duration
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new ScrollBarAttributes(this);
        }

    }
}
