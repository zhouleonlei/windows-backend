using Tizen.NUI.Binding;

namespace Tizen.NUI.CommonUI
{
    public class TextFieldAttributes : ViewAttributes
    {
        public TextFieldAttributes() : base() { }
        public TextFieldAttributes(TextFieldAttributes attributes) : base(attributes)
        {
            if(attributes == null)
            {
                return;
            }
            if (attributes.Text != null)
            {
                Text = attributes.Text.Clone() as StringSelector;
            }
            if (attributes.PlaceholderText != null)
            {
                PlaceholderText = attributes.PlaceholderText.Clone() as StringSelector;
            }
            if (attributes.TranslatablePlaceholderText != null)
            {
                TranslatablePlaceholderText = attributes.TranslatablePlaceholderText.Clone() as StringSelector;
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
            if (attributes.TextColor != null)
            {
                TextColor = attributes.TextColor.Clone() as ColorSelector;
            }
            if (attributes.PlaceholderTextColor != null)
            {
                PlaceholderTextColor = attributes.PlaceholderTextColor.Clone() as ColorSelector;
            }
            if (attributes.PrimaryCursorColor != null)
            {
                PrimaryCursorColor = attributes.PrimaryCursorColor.Clone() as ColorSelector;
            }
            if (attributes.SecondaryCursorColor != null)
            {
                SecondaryCursorColor = attributes.SecondaryCursorColor.Clone() as ColorSelector;
            }
            if (attributes.FontFamily != null)
            {
                FontFamily = attributes.FontFamily;
            }
            if (attributes.PointSize != null)
            {
                PointSize = attributes.PointSize.Clone() as FloatSelector;
            }
            if (attributes.EnableCursorBlink != null)
            {
                EnableCursorBlink = attributes.EnableCursorBlink;
            }
            if (attributes.EnableSelection != null)
            {
                EnableSelection = attributes.EnableSelection;
            }
            if (attributes.CursorWidth != null)
            {
                CursorWidth = attributes.CursorWidth;
            }
            if (attributes.EnableEllipsis != null)
            {
                EnableEllipsis = attributes.EnableEllipsis;
            }
        }
        public StringSelector Text
        {
            get;
            set;
        }

        public StringSelector PlaceholderText
        {
            get;
            set;
        }

        public StringSelector TranslatablePlaceholderText
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

        public ColorSelector TextColor
        {
            get;
            set;
        }

        public ColorSelector PlaceholderTextColor
        {
            get;
            set;
        }

        public ColorSelector PrimaryCursorColor
        {
            get;
            set;
        }

        public ColorSelector SecondaryCursorColor
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

        public bool? EnableCursorBlink
        {
            get;
            set;
        }

        public bool? EnableSelection
        {
            get;
            set;
        }

        public int? CursorWidth
        {
            get;
            set;
        }

        public bool? EnableEllipsis
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new TextFieldAttributes(this);
        }
    }
}
