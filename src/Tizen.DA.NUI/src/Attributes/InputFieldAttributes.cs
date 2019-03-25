using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.CommonUI;
using Tizen.NUI.Binding;

namespace Tizen.FH.NUI.Controls
{
    public class InputFieldAttributes : Tizen.NUI.CommonUI.InputFieldAttributes
    {
        private ImageAttributes cancelButtonAttrs = null;
        private ImageAttributes deleteButtonAttrs = null;
        private ImageAttributes addButtonBgAttrs = null;
        private ImageAttributes addButtonOverlayAttrs = null;
        private ImageAttributes addButtonFgAttrs = null;
        private ImageAttributes searchButtonAttrs = null;
        private int? spaceBetweenTextFieldAndRightButton = null;
        private int? spaceBetweenTextFieldAndLeftButton = null;

        public InputFieldAttributes() : base() { }

        public InputFieldAttributes(InputFieldAttributes attrs) : base(attrs)
        {
            if (attrs.cancelButtonAttrs != null)
            {
                cancelButtonAttrs = attrs.cancelButtonAttrs.Clone() as ImageAttributes;
            }
            if (attrs.deleteButtonAttrs != null)
            {
                deleteButtonAttrs = attrs.deleteButtonAttrs.Clone() as ImageAttributes;
            }
            if (attrs.addButtonBgAttrs != null)
            {
                addButtonBgAttrs = attrs.addButtonBgAttrs.Clone() as ImageAttributes;
            }
            if (attrs.addButtonOverlayAttrs != null)
            {
                addButtonOverlayAttrs = attrs.addButtonOverlayAttrs.Clone() as ImageAttributes;
            }
            if (attrs.addButtonFgAttrs != null)
            {
                addButtonFgAttrs = attrs.addButtonFgAttrs.Clone() as ImageAttributes;
            }
            if (attrs.searchButtonAttrs != null)
            {
                searchButtonAttrs = attrs.searchButtonAttrs.Clone() as ImageAttributes;
            }
            if (attrs.spaceBetweenTextFieldAndRightButton != null)
            {
                spaceBetweenTextFieldAndRightButton = attrs.spaceBetweenTextFieldAndRightButton;
            }
            if (attrs.spaceBetweenTextFieldAndLeftButton != null)
            {
                spaceBetweenTextFieldAndLeftButton = attrs.spaceBetweenTextFieldAndLeftButton;
            }
        }

        public static readonly BindableProperty CancelButtonAttributesProperty =
            BindableProperty.Create("CancelButtonAttributes", typeof(ImageAttributes), typeof(InputFieldAttributes), default(ImageAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.cancelButtonAttrs = (ImageAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                return attrs.cancelButtonAttrs;
            });

        public static readonly BindableProperty DeleteButtonAttributesProperty =
            BindableProperty.Create("DeleteButtonAttributes", typeof(ImageAttributes), typeof(InputFieldAttributes), default(ImageAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.deleteButtonAttrs = (ImageAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                return attrs.deleteButtonAttrs;
            });

        public static readonly BindableProperty AddButtonBgAttributesProperty =
           BindableProperty.Create("AddButtonBgAttributes", typeof(ImageAttributes), typeof(InputFieldAttributes), default(ImageAttributes),
           propertyChanged: (bindable, oldValue, newValue) =>
           {
               var attrs = (InputFieldAttributes)bindable;
               if (newValue != null)
               {
                   attrs.addButtonBgAttrs = (ImageAttributes)newValue;
               }
           },
           defaultValueCreator: (bindable) =>
           {
               var attrs = (InputFieldAttributes)bindable;
               return attrs.addButtonBgAttrs;
           });

        public static readonly BindableProperty AddButtonOverlayAttributesProperty =
           BindableProperty.Create("AddButtonOverlayAttributes", typeof(ImageAttributes), typeof(InputFieldAttributes), default(ImageAttributes),
           propertyChanged: (bindable, oldValue, newValue) =>
           {
               var attrs = (InputFieldAttributes)bindable;
               if (newValue != null)
               {
                   attrs.addButtonOverlayAttrs = (ImageAttributes)newValue;
               }
           },
           defaultValueCreator: (bindable) =>
           {
               var attrs = (InputFieldAttributes)bindable;
               return attrs.addButtonOverlayAttrs;
           });

        public static readonly BindableProperty AddButtonFgAttributesProperty =
           BindableProperty.Create("AddButtonFgAttributes", typeof(ImageAttributes), typeof(InputFieldAttributes), default(ImageAttributes),
           propertyChanged: (bindable, oldValue, newValue) =>
           {
               var attrs = (InputFieldAttributes)bindable;
               if (newValue != null)
               {
                   attrs.addButtonFgAttrs = (ImageAttributes)newValue;
               }
           },
           defaultValueCreator: (bindable) =>
           {
               var attrs = (InputFieldAttributes)bindable;
               return attrs.addButtonFgAttrs;
           });

        public static readonly BindableProperty SearchButtonAttributesProperty =
           BindableProperty.Create("SearchButtonAttributes", typeof(ImageAttributes), typeof(InputFieldAttributes), default(ImageAttributes),
           propertyChanged: (bindable, oldValue, newValue) =>
           {
               var attrs = (InputFieldAttributes)bindable;
               if (newValue != null)
               {
                   attrs.searchButtonAttrs = (ImageAttributes)newValue;
               }
           },
           defaultValueCreator: (bindable) =>
           {
               var attrs = (InputFieldAttributes)bindable;
               return attrs.searchButtonAttrs;
           });

        public static readonly BindableProperty SpaceBetweenTextFieldAndRightButtonProperty =
            BindableProperty.Create("SpaceBetweenTextFieldAndRightButton", typeof(int?), typeof(InputFieldAttributes), default(int?),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.spaceBetweenTextFieldAndRightButton = (int?)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                return attrs.spaceBetweenTextFieldAndRightButton;
            });

        public static readonly BindableProperty SpaceBetweenTextFieldAndLeftButtonProperty =
            BindableProperty.Create("SpaceBetweenTextFieldAndLeftButton", typeof(int?), typeof(InputFieldAttributes), default(int?),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                if (newValue != null)
                {
                    attrs.spaceBetweenTextFieldAndLeftButton = (int?)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (InputFieldAttributes)bindable;
                return attrs.spaceBetweenTextFieldAndLeftButton;
            });

        public ImageAttributes CancelButtonAttributes
        {
            get { return (ImageAttributes)GetValue(CancelButtonAttributesProperty); }
            set { SetValue(CancelButtonAttributesProperty, value); }
        }

        public ImageAttributes DeleteButtonAttributes
        {
            get { return (ImageAttributes)GetValue(DeleteButtonAttributesProperty); }
            set { SetValue(DeleteButtonAttributesProperty, value); }
        }

        public ImageAttributes AddButtonBgAttributes
        {
            get { return (ImageAttributes)GetValue(AddButtonBgAttributesProperty); }
            set { SetValue(AddButtonBgAttributesProperty, value); }
        }

        public ImageAttributes AddButtonOverlayAttributes
        {
            get { return (ImageAttributes)GetValue(AddButtonOverlayAttributesProperty); }
            set { SetValue(AddButtonOverlayAttributesProperty, value); }
        }

        public ImageAttributes AddButtonFgAttributes
        {
            get { return (ImageAttributes)GetValue(AddButtonFgAttributesProperty); }
            set { SetValue(AddButtonFgAttributesProperty, value); }
        }

        public ImageAttributes SearchButtonAttributes
        {
            get { return (ImageAttributes)GetValue(SearchButtonAttributesProperty); }
            set { SetValue(SearchButtonAttributesProperty, value); }
        }

        public int? SpaceBetweenTextFieldAndRightButton
        {
            get { return (int?)GetValue(SpaceBetweenTextFieldAndRightButtonProperty); }
            set { SetValue(SpaceBetweenTextFieldAndRightButtonProperty, value); }
        }

        public int? SpaceBetweenTextFieldAndLeftButton
        {
            get { return (int?)GetValue(SpaceBetweenTextFieldAndLeftButtonProperty); }
            set { SetValue(SpaceBetweenTextFieldAndLeftButtonProperty, value); }
        }

        public override Attributes Clone()
        {
            return new InputFieldAttributes(this);
        }
    }
}
