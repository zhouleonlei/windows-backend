using Tizen.NUI.Binding;

namespace Tizen.NUI.CommonUI
{
    public class PaginationAttributes : ViewAttributes
    {
        public static readonly BindableProperty IndicatorSizeProperty = BindableProperty.Create("IndicatorSize", typeof(Size2D), typeof(PaginationAttributes), default(Size2D), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PaginationAttributes)bindable;
            if (newValue != null)
            {
                attrs.indicatorSize = (Size2D)newValue;
            }
        },
       defaultValueCreator: (bindable) =>
       {
           var attrs = (PaginationAttributes)bindable;
           return attrs.indicatorSize;
       });
        public static readonly BindableProperty IndicatorBackgroundURLProperty = BindableProperty.Create("IndicatorBackgroundURL", typeof(string), typeof(PaginationAttributes), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PaginationAttributes)bindable;
            if (newValue != null)
            {
                attrs.indicatorBackgroundURL = (string)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PaginationAttributes)bindable;
            return attrs.indicatorBackgroundURL;
        });
        public static readonly BindableProperty IndicatorSelectURLProperty = BindableProperty.Create("IndicatorSelectURL", typeof(string), typeof(PaginationAttributes), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PaginationAttributes)bindable;
            if (newValue != null)
            {
                attrs.indicatorSelectURL = (string)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PaginationAttributes)bindable;
            return attrs.indicatorSelectURL;
        });
        public static readonly BindableProperty IndicatorSpacingProperty = BindableProperty.Create("IndicatorSpacing", typeof(int), typeof(PaginationAttributes), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PaginationAttributes)bindable;
            if (newValue != null)
            {
                attrs.indicatorSpacing = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PaginationAttributes)bindable;
            return attrs.indicatorSpacing;
        });

        private Size2D indicatorSize;
        private string indicatorBackgroundURL;
        private string indicatorSelectURL;
        private int indicatorSpacing;

        public PaginationAttributes() : base() { }
        public PaginationAttributes(PaginationAttributes attributes) : base(attributes)
        {
            if (attributes.indicatorSize != null)
            {
                indicatorSize = new Size2D(attributes.indicatorSize.Width, attributes.indicatorSize.Height);
            }
            if (attributes.indicatorBackgroundURL != null)
            {
                indicatorBackgroundURL = attributes.indicatorBackgroundURL.Clone() as string;
            }
            if (attributes.indicatorSelectURL != null)
            {
                indicatorSelectURL = attributes.indicatorSelectURL.Clone() as string;
            }
            indicatorSpacing = attributes.indicatorSpacing;
        }

        public Size2D IndicatorSize
        {
            get
            {
                return (Size2D)GetValue(IndicatorSizeProperty);
            }
            set
            {
                SetValue(IndicatorSizeProperty, value);
            }
        }

        public string IndicatorBackgroundURL
        {
            get
            {
                return (string)GetValue(IndicatorBackgroundURLProperty);
            }
            set
            {
                SetValue(IndicatorBackgroundURLProperty, value);
            }
        }

        public string IndicatorSelectURL
        {
            get
            {
                return (string)GetValue(IndicatorSelectURLProperty);
            }
            set
            {
                SetValue(IndicatorSelectURLProperty, value);
            }
        }

        public int IndicatorSpacing
        {
            get
            {
                return (int)GetValue(IndicatorSpacingProperty);
            }
            set
            {
                SetValue(IndicatorSpacingProperty, value);
            }
        }


        public override Attributes Clone()
        {
            return new PaginationAttributes(this);
        }

    }
}
