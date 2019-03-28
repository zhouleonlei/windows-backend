namespace Tizen.NUI.CommonUI
{
    public class TimePickerAttributes : ViewAttributes
    {
        public TimePickerAttributes() : base() { }
        public TimePickerAttributes(TimePickerAttributes attributes) : base(attributes)
        {
            if (attributes.ShadowImageAttributes != null)
            {
                ShadowImageAttributes = attributes.ShadowImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.BackgroundImageAttributes != null)
            {
                BackgroundImageAttributes = attributes.BackgroundImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.TitleTextAttributes != null)
            {
                TitleTextAttributes = attributes.TitleTextAttributes.Clone() as TextAttributes;
            }
            
            ShadowOffset = new Vector4(attributes.ShadowOffset.W, attributes.ShadowOffset.X, attributes.ShadowOffset.Y, attributes.ShadowOffset.Z);

            if (attributes.HourSpinAttributes != null)
            {
                HourSpinAttributes = attributes.HourSpinAttributes.Clone() as SpinAttributes;
            }

            if (attributes.MinuteSpinAttributes != null)
            {
                MinuteSpinAttributes = attributes.MinuteSpinAttributes.Clone() as SpinAttributes;
            }

            if (attributes.SecondSpinAttributes != null)
            {
                SecondSpinAttributes = attributes.SecondSpinAttributes.Clone() as SpinAttributes;
            }

            if (attributes.AMPMSpinAttributes != null)
            {
                AMPMSpinAttributes = attributes.AMPMSpinAttributes.Clone() as SpinAttributes;
            }

            if (attributes.ColonImageAttributes != null)
            {
                ColonImageAttributes = attributes.ColonImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.WeekViewAttributes != null)
            {
                WeekViewAttributes = attributes.WeekViewAttributes.Clone() as ViewAttributes;
            }

            if (attributes.WeekTitleTextAttributes != null)
            {
                WeekTitleTextAttributes = attributes.WeekTitleTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.WeekSelectImageAttributes != null)
            {
                WeekSelectImageAttributes = attributes.WeekSelectImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.WeekTextAttributes != null)
            {
                WeekTextAttributes = attributes.WeekTextAttributes.Clone() as TextAttributes;
            }
        }

        public ImageAttributes ShadowImageAttributes
        {
            get;
            set;
        }

        public ImageAttributes BackgroundImageAttributes
        {
            get;
            set;
        }

        public TextAttributes TitleTextAttributes
        {
            get;
            set;
        }
        
        public Vector4 ShadowOffset
        {
            get;
            set;
        }

        public SpinAttributes HourSpinAttributes
        {
            get;
            set;
        }

        public SpinAttributes MinuteSpinAttributes
        {
            get;
            set;
        }

        public SpinAttributes SecondSpinAttributes
        {
            get;
            set;
        }

        public SpinAttributes AMPMSpinAttributes
        {
            get;
            set;
        }

        public ImageAttributes ColonImageAttributes
        {
            get;
            set;
        }
        
        public ViewAttributes WeekViewAttributes
        {
            get;
            set;
        }

        public TextAttributes WeekTitleTextAttributes
        {
            get;
            set;
        }

        public ImageAttributes WeekSelectImageAttributes
        {
            get;
            set;
        }

        public TextAttributes WeekTextAttributes
        {
            get;
            set;
        }
        public override Attributes Clone()
        {
            return new TimePickerAttributes(this);
        }
    }
}
