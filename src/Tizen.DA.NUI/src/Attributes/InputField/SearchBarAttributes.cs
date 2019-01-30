using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.Controls;
using Tizen.NUI.Binding;

namespace Tizen.FH.NUI.Controls
{
    public class SearchBarAttributes : Tizen.NUI.Controls.ViewAttributes
    {
        private InputFieldAttributes searchBoxAttributes = null;
        private ViewAttributes resultListAttributes = null;
        private int? space = null;

        public SearchBarAttributes() : base() { }

        public SearchBarAttributes(SearchBarAttributes attrs) : base(attrs)
        {
            if (attrs.searchBoxAttributes != null)
            {
                searchBoxAttributes = attrs.searchBoxAttributes.Clone() as InputFieldAttributes;
            }
            if (attrs.resultListAttributes != null)
            {
                resultListAttributes = attrs.resultListAttributes.Clone() as ViewAttributes;
            }
            if (attrs.space != null)
            {
                space = attrs.space;
            }
        }

        public static readonly BindableProperty SearchBoxAttributesProperty =
            BindableProperty.Create("SearchBoxAttributes", typeof(InputFieldAttributes), typeof(SearchBarAttributes), default(InputFieldAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (SearchBarAttributes)bindable;
                if (newValue != null)
                {
                    attrs.searchBoxAttributes = (InputFieldAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (SearchBarAttributes)bindable;
                return attrs.searchBoxAttributes;
            });

        public static readonly BindableProperty ResultListAttributesProperty =
            BindableProperty.Create("ResultListAttributes", typeof(ViewAttributes), typeof(SearchBarAttributes), default(ViewAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (SearchBarAttributes)bindable;
                if (newValue != null)
                {
                    attrs.resultListAttributes = (ViewAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (SearchBarAttributes)bindable;
                return attrs.resultListAttributes;
            });

        public static readonly BindableProperty SpaceProperty =
            BindableProperty.Create("Space", typeof(int?), typeof(SearchBarAttributes), default(int?),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (SearchBarAttributes)bindable;
                if (newValue != null)
                {
                    attrs.space = (int?)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (SearchBarAttributes)bindable;
                return attrs.space;
            });

        public InputFieldAttributes SearchBoxAttributes
        {
            get { return (InputFieldAttributes)GetValue(SearchBoxAttributesProperty); }
            set { SetValue(SearchBoxAttributesProperty, value); }
        }

        public ViewAttributes ResultListAttributes
        {
            get { return (ViewAttributes)GetValue(ResultListAttributesProperty); }
            set { SetValue(ResultListAttributesProperty, value); }
        }

        public int? Space
        {
            get { return (int?)GetValue(SpaceProperty); }
            set { SetValue(SpaceProperty, value); }
        }

        public override Attributes Clone()
        {
            return new SearchBarAttributes(this);
        }
    }
}
