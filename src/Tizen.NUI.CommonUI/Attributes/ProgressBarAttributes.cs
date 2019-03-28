using Tizen.NUI.Binding;

namespace Tizen.NUI.CommonUI
{
    public class ProgressBarAttributes : ViewAttributes
    {
        public ProgressBarAttributes() : base() { }

        public ProgressBarAttributes(ProgressBarAttributes attributes) : base(attributes)
        {
            ThumbSize = attributes.ThumbSize;
            MaxValue = attributes.MaxValue;
            MinValue = attributes.MinValue;
            CurValue = attributes.CurValue;
            Duration = attributes.Duration;

            if (attributes.ProgressImageURLPrefix != null)
            {
                ProgressImageURLPrefix = attributes.ProgressImageURLPrefix.Clone() as StringSelector;
            }

            if (attributes.TrackImageAttributes != null)
            {
                TrackImageAttributes = attributes.TrackImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.ProgressImageAttributes != null)
            {
                ProgressImageAttributes = attributes.ProgressImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.BufferImageAttributes != null)
            {
                BufferImageAttributes = attributes.BufferImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.LoadingImageAttributes != null)
            {
                LoadingImageAttributes = attributes.LoadingImageAttributes.Clone() as ImageAttributes;
            }
        }

        public ImageAttributes TrackImageAttributes
        {
            get;
            set;
        }

        public ImageAttributes ProgressImageAttributes
        {
            get;
            set;
        }

        public ImageAttributes BufferImageAttributes
        {
            get;
            set;
        }

        public ImageAttributes LoadingImageAttributes
        {
            get;
            set;
        }

        public StringSelector ProgressImageURLPrefix
        {
            get;
            set;
        }

        public Progress.DirectionType Direction
        {
            get;
            set;
        }

        public Size ThumbSize
        {
            get;
            set;
        }

        public uint? MaxValue
        {
            get;
            set;
        }

        public uint? MinValue
        {
            get;
            set;
        }

        public uint? CurValue
        {
            get;
            set;
        }

        public uint? Duration
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new ProgressBarAttributes(this);
        }

    }
}
