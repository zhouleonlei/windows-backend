using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.Controls;
using Tizen.NUI.Binding;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.DA.NUI.res.PaginationAttributes.xaml", "PaginationAttributes.xaml", typeof(Tizen.DA.NUI.Controls.PaginationAttributes))]
namespace Tizen.DA.NUI.Controls
{
    internal class PaginationAttributes : Tizen.NUI.Controls.PaginationAttributes
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
    }
}
