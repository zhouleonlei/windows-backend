using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.CommonUI;
using Tizen.NUI.Binding;

namespace Tizen.FH.NUI.Controls
{
    internal class PaginationAttributes : Tizen.NUI.CommonUI.PaginationAttributes
    {
        public static readonly BindableProperty ReturnArrowAttributesProperty = BindableProperty.Create("ReturnArrowAttributes", typeof(ImageAttributes), typeof(PaginationAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PaginationAttributes)bindable;
            if (newValue != null)
            {
                attrs.returnArrowAtts = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PaginationAttributes)bindable;
            return attrs.returnArrowAtts;
        });
        public static readonly BindableProperty NextArrowAttributesProperty = BindableProperty.Create("NextArrowAttributes", typeof(ImageAttributes), typeof(PaginationAttributes), default(ImageAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (PaginationAttributes)bindable;
            if (newValue != null)
            {
                attrs.nextArrowAttrs = (ImageAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (PaginationAttributes)bindable;
            return attrs.nextArrowAttrs;
        });

        private ImageAttributes returnArrowAtts;
        private ImageAttributes nextArrowAttrs;

        public PaginationAttributes() : base() { }
        public PaginationAttributes(PaginationAttributes attributes) : base(attributes)
        {
            if (attributes.returnArrowAtts != null)
            {
                returnArrowAtts = attributes.returnArrowAtts.Clone() as ImageAttributes;
            }
            if (attributes.nextArrowAttrs != null)
            {
                nextArrowAttrs = attributes.nextArrowAttrs.Clone() as ImageAttributes;
            }
        }

        public ImageAttributes ReturnArrowAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(ReturnArrowAttributesProperty);
            }
            set
            {
                SetValue(ReturnArrowAttributesProperty, value);
            }
        }

        public ImageAttributes NextArrowAttributes
        {
            get
            {
                return (ImageAttributes)GetValue(NextArrowAttributesProperty);
            }
            set
            {
                SetValue(NextArrowAttributesProperty, value);
            }
        }

        public override Attributes Clone()
        {
            return new PaginationAttributes(this);
        }
    }
}
