
namespace Tizen.NUI.CommonUI
{
    public class TextAttributes : ViewAttributes
    {
        public TextAttributes() : base() { }
        public TextAttributes(TextAttributes attributes) : base(attributes)
        {
            if(attributes == null)
            {
                return;
            }
            if (attributes.Text != null)
            {
                Text = attributes.Text.Clone() as StringSelector;
            }

            if (attributes.TranslatableText != null)
            {
                TranslatableText = attributes.TranslatableText.Clone() as StringSelector;
            }

            if (attributes.MultiLine != null)
            {
                MultiLine = attributes.MultiLine;
            }

            if (attributes.HorizontalAlignment != null)
            {
                HorizontalAlignment = attributes.HorizontalAlignment;
            }

            if (attributes.VerticalAlignment != null)
            {
                VerticalAlignment = attributes.VerticalAlignment;
            }

            if (attributes.EnableMarkup != null)
            {
                EnableMarkup = attributes.EnableMarkup;
            }

            if (attributes.EnableAutoScroll != null)
            {
                EnableAutoScroll = attributes.EnableAutoScroll;
            }

            if (attributes.AutoScrollSpeed != null)
            {
                AutoScrollSpeed = attributes.AutoScrollSpeed;
            }

            if (attributes.AutoScrollLoopCount != null)
            {
                AutoScrollLoopCount = attributes.AutoScrollLoopCount;
            }

            if (attributes.AutoScrollGap != null)
            {
                AutoScrollGap = attributes.AutoScrollGap;
            }

            if (attributes.AutoScrollLoopDelay != null)
            {
                AutoScrollLoopDelay = attributes.AutoScrollLoopDelay;
            }

            if (attributes.AutoScrollStopMode != null)
            {
                AutoScrollStopMode = attributes.AutoScrollStopMode;
            }

            if (attributes.LineSpacing != null)
            {
                LineSpacing = attributes.LineSpacing;
            }

            if (attributes.TextColor != null)
            {
                TextColor = attributes.TextColor.Clone() as ColorSelector;
            }

            if (attributes.FontFamily != null)
            {
                FontFamily = attributes.FontFamily;
            }

            if (attributes.PointSize != null)
            {
                PointSize = attributes.PointSize.Clone() as FloatSelector;
            }

            if (attributes.ShadowOffset != null)
            {
                ShadowOffset = attributes.ShadowOffset.Clone() as Vector2Selector;
            }

            if (attributes.ShadowColor != null)
            {
                ShadowColor = attributes.ShadowColor.Clone() as ColorSelector;
            }

            if (attributes.OutstrokeColor != null)
            {
                OutstrokeColor = attributes.OutstrokeColor.Clone() as ColorSelector;
            }
            if (attributes.OutstrokeThickness != null)
            {
                OutstrokeThickness = attributes.OutstrokeThickness.Clone() as IntSelector;
            }
        }
        public StringSelector Text
        {
            get;
            set;
        }
        public StringSelector TranslatableText
        {
            get;
            set;
        }
        public bool? MultiLine
        {
            get;
            set;
        }
        public HorizontalAlignment? HorizontalAlignment
        {
            get;
            set;
        }

        public VerticalAlignment? VerticalAlignment
        {
            get;
            set;
        }

        public bool? EnableMarkup
        {
            get;
            set;
        }

        public bool? EnableAutoScroll
        {
            get;
            set;
        }

        public int? AutoScrollSpeed
        {
            get;
            set;
        }

        public int? AutoScrollLoopCount
{
            get;
            set;
        }

        public float? AutoScrollGap
        {
            get;
            set;
        }

        public float? AutoScrollLoopDelay
        {
            get;
            set;
        }

        public AutoScrollStopMode? AutoScrollStopMode
        {
            get;
            set;
        }

        public float? LineSpacing
        {
            get;
            set;
        }

        public ColorSelector TextColor
        {
            get;
            set;
        }

        public string FontFamily
        {
            get;
            set;
        }

        public FloatSelector PointSize
        {
            get;
            set;
        }

        public Vector2Selector ShadowOffset
        {
            get;
            set;
        }

        public ColorSelector ShadowColor
        {
            get;
            set;
        }


        public ColorSelector OutstrokeColor
        {
            get;
            set;
        }

        public IntSelector OutstrokeThickness
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new TextAttributes(this);
        }
    }
}
