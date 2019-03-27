
namespace Tizen.NUI.CommonUI
{
    public class SliderAttributes : ViewAttributes
    {
        private Slider.IndicatorType indicatorType = Slider.IndicatorType.None;

        public SliderAttributes() : base() { }

        public SliderAttributes(SliderAttributes attributes) : base(attributes)
        {
            if(attributes == null)
            {
                return;
            }
            if (attributes.BgTrackAttributes != null)
            {
                BgTrackAttributes = attributes.BgTrackAttributes.Clone() as ImageAttributes;
            }
            if (attributes.SlidedTrackAttributes != null)
            {
                SlidedTrackAttributes = attributes.SlidedTrackAttributes.Clone() as ImageAttributes;
            }
            if (attributes.ThumbBgAttributes != null)
            {
                ThumbBgAttributes = attributes.ThumbBgAttributes.Clone() as ImageAttributes;
            }
            if (attributes.ThumbAttributes != null)
            {
                ThumbAttributes = attributes.ThumbAttributes.Clone() as ImageAttributes;
            }
            if (attributes.LowIndicatorImageAttributes != null)
            {
                LowIndicatorImageAttributes = attributes.LowIndicatorImageAttributes.Clone() as ImageAttributes;
            }
            if (attributes.HighIndicatorImageAttributes != null)
            {
                HighIndicatorImageAttributes = attributes.HighIndicatorImageAttributes.Clone() as ImageAttributes;
            }
            if (attributes.LowIndicatorTextAttributes != null)
            {
                LowIndicatorTextAttributes = attributes.LowIndicatorTextAttributes.Clone() as TextAttributes;
            }
            if (attributes.HighIndicatorTextAttributes != null)
            {
                HighIndicatorTextAttributes = attributes.HighIndicatorTextAttributes.Clone() as TextAttributes;
            }
            if (attributes.TrackThickness != null)
            {
                TrackThickness = attributes.TrackThickness;
            }
            if (attributes.SpaceBetweenTrackAndIndicator != null)
            {
                SpaceBetweenTrackAndIndicator = attributes.SpaceBetweenTrackAndIndicator;
            }
            indicatorType = attributes.indicatorType;
        }

        public ImageAttributes BgTrackAttributes
        {
            get;
            set;
        }

        public ImageAttributes SlidedTrackAttributes
        {
            get;
            set;
        }

        public ImageAttributes ThumbAttributes
        {
            get;
            set;
        }

        public ImageAttributes ThumbBgAttributes
        {
            get;
            set;
        }

        public ImageAttributes LowIndicatorImageAttributes
        {
            get;
            set;
        }

        public ImageAttributes HighIndicatorImageAttributes
        {
            get;
            set;
        }

        public TextAttributes LowIndicatorTextAttributes
        {
            get;
            set;
        }

        public TextAttributes HighIndicatorTextAttributes
        {
            get;
            set;
        }

        public uint? TrackThickness
        {
            get;
            set;
        }

        public uint? SpaceBetweenTrackAndIndicator
        {
            get;
            set;
        }

        public Slider.IndicatorType IndicatorType
        {
            get
            {
                return indicatorType;
            }

            set
            {
                indicatorType = value;
            }
        }

        public override Attributes Clone()
        {
            return new SliderAttributes(this);
        }
    }
}
