using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Controls
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
                attrs.indicatorSpacing = (int?)newValue;
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
        private int? indicatorSpacing;

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

        public int? IndicatorSpacing
        {
            get
            {
                return (int?)GetValue(IndicatorSpacingProperty);
            }
            set
            {
                SetValue(IndicatorSpacingProperty, value);
            }
        }
    }
}
