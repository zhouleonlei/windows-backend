using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.CommonUI;
using Tizen.NUI.Binding;

namespace Tizen.FH.NUI.Controls
{
    public class ListItemAttributes : Tizen.NUI.CommonUI.ViewAttributes
    {
        // common part
        private TextAttributes mainTextAttrs = null;
        private TextAttributes mainText2Attrs = null;
        private TextAttributes subTextAttrs = null;
        private ImageAttributes dividerViewAttrs = null;
        private ViewAttributes leftItemRootViewAttrs = null;
        private ViewAttributes rightItemRootViewAttrs = null;
        
        private uint? leftSpace = null;
        private uint? rightSpace = null;
        private uint? spaceBetweenLeftItemAndText = null;
        private uint? spaceBetweenRightItemAndText = null;

        // special part
        private ImageAttributes leftIconAttrs = null;
        private ImageAttributes rightIconAttrs = null;
        private TextAttributes rightTextAttrs = null;
        private string checkBoxStyle = null;
        private string switchStyle = null;
        private string dropDownStyle = null;
        private ListItem.StyleTypes styleType = ListItem.StyleTypes.None;

        public ListItemAttributes() : base() { }

        public ListItemAttributes(ListItemAttributes attrs) : base(attrs)
        {
            if (attrs.mainTextAttrs != null)
            {
                mainTextAttrs = attrs.mainTextAttrs.Clone() as TextAttributes;
            }
            if (attrs.subTextAttrs != null)
            {
                subTextAttrs = attrs.subTextAttrs.Clone() as TextAttributes;
            }
            if (attrs.dividerViewAttrs != null)
            {
                dividerViewAttrs = attrs.dividerViewAttrs.Clone() as ImageAttributes;
            }
            if (attrs.leftItemRootViewAttrs != null)
            {
                leftItemRootViewAttrs = attrs.leftItemRootViewAttrs.Clone() as ViewAttributes;
            }
            if (attrs.rightItemRootViewAttrs != null)
            {
                rightItemRootViewAttrs = attrs.rightItemRootViewAttrs.Clone() as ViewAttributes;
            }
            if (attrs.leftIconAttrs != null)
            {
                leftIconAttrs = attrs.leftIconAttrs.Clone() as ImageAttributes;
            }
            if (attrs.rightIconAttrs != null)
            {
                rightIconAttrs = attrs.rightIconAttrs.Clone() as ImageAttributes;
            }
            if (attrs.rightTextAttrs != null)
            {
                rightTextAttrs = attrs.rightTextAttrs.Clone() as TextAttributes;
            }
            if (attrs.leftSpace != null)
            {
                leftSpace = attrs.leftSpace;
            }
            if (attrs.rightSpace != null)
            {
                rightSpace = attrs.rightSpace;
            }
            if (attrs.spaceBetweenLeftItemAndText != null)
            {
                spaceBetweenLeftItemAndText = attrs.spaceBetweenLeftItemAndText;
            }
            if (attrs.spaceBetweenRightItemAndText != null)
            {
                spaceBetweenRightItemAndText = attrs.spaceBetweenRightItemAndText;
            }
            if (attrs.checkBoxStyle != null)
            {
                checkBoxStyle = attrs.checkBoxStyle;
            }
            if (attrs.switchStyle != null)
            {
                switchStyle = attrs.switchStyle;
            }
            if (attrs.switchStyle != null)
            {
                switchStyle = attrs.switchStyle;
            }
            if (attrs.dropDownStyle != null)
            {
                dropDownStyle = attrs.dropDownStyle;
            }
            styleType = attrs.styleType;
        }

        public static readonly BindableProperty MainTextAttributesProperty =
            BindableProperty.Create("MainTextAttributes", typeof(TextAttributes), typeof(ListItemAttributes), default(TextAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (ListItemAttributes)bindable;
                if (newValue != null)
                {
                    attrs.mainTextAttrs = (TextAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (ListItemAttributes)bindable;
                return attrs.mainTextAttrs;
            });

        public static readonly BindableProperty MainText2AttributesProperty =
            BindableProperty.Create("MainText2Attributes", typeof(TextAttributes), typeof(ListItemAttributes), default(TextAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (ListItemAttributes)bindable;
                if (newValue != null)
                {
                    attrs.mainText2Attrs = (TextAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (ListItemAttributes)bindable;
                return attrs.mainText2Attrs;
            });

        public static readonly BindableProperty SubTextAttributesProperty =
            BindableProperty.Create("SubTextAttributes", typeof(TextAttributes), typeof(ListItemAttributes), default(TextAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (ListItemAttributes)bindable;
                if (newValue != null)
                {
                    attrs.subTextAttrs = (TextAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (ListItemAttributes)bindable;
                return attrs.subTextAttrs;
            });

        public static readonly BindableProperty DividerViewAttributesProperty =
            BindableProperty.Create("DividerViewAttributes", typeof(ImageAttributes), typeof(ListItemAttributes), default(ImageAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (ListItemAttributes)bindable;
                if (newValue != null)
                {
                    attrs.dividerViewAttrs= (ImageAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (ListItemAttributes)bindable;
                return attrs.dividerViewAttrs;
            });

        public static readonly BindableProperty LeftItemRootViewAttributesProperty =
            BindableProperty.Create("LeftItemRootViewAttributes", typeof(ViewAttributes), typeof(ListItemAttributes), default(ViewAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (ListItemAttributes)bindable;
                if (newValue != null)
                {
                    attrs.leftItemRootViewAttrs = (ViewAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (ListItemAttributes)bindable;
                return attrs.leftItemRootViewAttrs;
            });

        public static readonly BindableProperty RightItemRootViewAttributesProperty =
            BindableProperty.Create("RightItemRootViewAttributes", typeof(ViewAttributes), typeof(ListItemAttributes), default(ViewAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (ListItemAttributes)bindable;
                if (newValue != null)
                {
                    attrs.rightItemRootViewAttrs = (ViewAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (ListItemAttributes)bindable;
                return attrs.rightItemRootViewAttrs;
            });

        public static readonly BindableProperty LeftIconAttributesProperty =
            BindableProperty.Create("LeftIconAttributes", typeof(ImageAttributes), typeof(ListItemAttributes), default(ImageAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (ListItemAttributes)bindable;
                if (newValue != null)
                {
                    attrs.leftIconAttrs = (ImageAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (ListItemAttributes)bindable;
                return attrs.leftIconAttrs;
            });

        public static readonly BindableProperty RightIconAttributesProperty =
            BindableProperty.Create("RightIconAttributes", typeof(ImageAttributes), typeof(ListItemAttributes), default(ImageAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (ListItemAttributes)bindable;
                if (newValue != null)
                {
                    attrs.rightIconAttrs = (ImageAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (ListItemAttributes)bindable;
                return attrs.rightIconAttrs;
            });

        public static readonly BindableProperty RightTextAttributesProperty =
            BindableProperty.Create("RightTextAttributes", typeof(TextAttributes), typeof(ListItemAttributes), default(TextAttributes),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (ListItemAttributes)bindable;
                if (newValue != null)
                {
                    attrs.rightTextAttrs = (TextAttributes)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (ListItemAttributes)bindable;
                return attrs.rightTextAttrs;
            });

        public static readonly BindableProperty LeftSpaceProperty =
            BindableProperty.Create("LeftSpace", typeof(uint?), typeof(ListItemAttributes), default(uint?),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (ListItemAttributes)bindable;
                if (newValue != null)
                {
                    attrs.leftSpace = (uint?)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (ListItemAttributes)bindable;
                return attrs.leftSpace;
            });

        public static readonly BindableProperty RightSpaceProperty =
            BindableProperty.Create("RightSpace", typeof(uint?), typeof(ListItemAttributes), default(uint?),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (ListItemAttributes)bindable;
                if (newValue != null)
                {
                    attrs.rightSpace = (uint?)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (ListItemAttributes)bindable;
                return attrs.rightSpace;
            });

        public static readonly BindableProperty SpaceBetweenLeftItemAndTextProperty =
            BindableProperty.Create("SpaceBetweenLeftItemAndText", typeof(uint?), typeof(ListItemAttributes), default(uint?),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var attrs = (ListItemAttributes)bindable;
                if (newValue != null)
                {
                    attrs.spaceBetweenLeftItemAndText = (uint?)newValue;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var attrs = (ListItemAttributes)bindable;
                return attrs.spaceBetweenLeftItemAndText;
            });

        public static readonly BindableProperty SpaceBetweenRightItemAndTextProperty =
           BindableProperty.Create("SpaceBetweenRightItemAndText", typeof(uint?), typeof(ListItemAttributes), default(uint?),
           propertyChanged: (bindable, oldValue, newValue) =>
           {
               var attrs = (ListItemAttributes)bindable;
               if (newValue != null)
               {
                   attrs.spaceBetweenRightItemAndText = (uint?)newValue;
               }
           },
           defaultValueCreator: (bindable) =>
           {
               var attrs = (ListItemAttributes)bindable;
               return attrs.spaceBetweenRightItemAndText;
           });

        public static readonly BindableProperty CheckBoxStyleProperty =
           BindableProperty.Create("CheckBoxStyle", typeof(string), typeof(ListItemAttributes), default(string),
           propertyChanged: (bindable, oldValue, newValue) =>
           {
               var attrs = (ListItemAttributes)bindable;
               if (newValue != null)
               {
                   attrs.checkBoxStyle = (string)newValue;
               }
           },
           defaultValueCreator: (bindable) =>
           {
               var attrs = (ListItemAttributes)bindable;
               return attrs.checkBoxStyle;
           });

        public static readonly BindableProperty SwitchStyleProperty =
           BindableProperty.Create("SwitchStyle", typeof(string), typeof(ListItemAttributes), default(string),
           propertyChanged: (bindable, oldValue, newValue) =>
           {
               var attrs = (ListItemAttributes)bindable;
               if (newValue != null)
               {
                   attrs.switchStyle = (string)newValue;
               }
           },
           defaultValueCreator: (bindable) =>
           {
               var attrs = (ListItemAttributes)bindable;
               return attrs.switchStyle;
           });

        public static readonly BindableProperty DropDownStyleProperty =
           BindableProperty.Create("DropDownStyle", typeof(string), typeof(ListItemAttributes), default(string),
           propertyChanged: (bindable, oldValue, newValue) =>
           {
               var attrs = (ListItemAttributes)bindable;
               if (newValue != null)
               {
                   attrs.dropDownStyle = (string)newValue;
               }
           },
           defaultValueCreator: (bindable) =>
           {
               var attrs = (ListItemAttributes)bindable;
               return attrs.dropDownStyle;
           });

        public static readonly BindableProperty StyleTypeProperty =
           BindableProperty.Create("StyleType", typeof(ListItem.StyleTypes), typeof(ListItemAttributes), default(ListItem.StyleTypes),
           propertyChanged: (bindable, oldValue, newValue) =>
           {
               var attrs = (ListItemAttributes)bindable;
               if (newValue != null)
               {
                   attrs.styleType = (ListItem.StyleTypes)newValue;
               }
           },
           defaultValueCreator: (bindable) =>
           {
               var attrs = (ListItemAttributes)bindable;
               return attrs.styleType;
           });

        public TextAttributes MainTextAttributes
        {
            get { return (TextAttributes)GetValue(MainTextAttributesProperty); }
            set { SetValue(MainTextAttributesProperty, value); }
        }

        public TextAttributes MainText2Attributes
        {
            get { return (TextAttributes)GetValue(MainText2AttributesProperty); }
            set { SetValue(MainText2AttributesProperty, value); }
        }

        public TextAttributes SubTextAttributes
        {
            get { return (TextAttributes)GetValue(SubTextAttributesProperty); }
            set { SetValue(SubTextAttributesProperty, value); }
        }

        public ImageAttributes DividerViewAttributes
        {
            get { return (ImageAttributes)GetValue(DividerViewAttributesProperty); }
            set { SetValue(DividerViewAttributesProperty, value); }
        }

        public ViewAttributes LeftItemRootViewAttributes
        {
            get { return (ViewAttributes)GetValue(LeftItemRootViewAttributesProperty); }
            set { SetValue(LeftItemRootViewAttributesProperty, value); }
        }

        public ViewAttributes RightItemRootViewAttributes
        {
            get { return (ViewAttributes)GetValue(RightItemRootViewAttributesProperty); }
            set { SetValue(RightItemRootViewAttributesProperty, value); }
        }

        public ImageAttributes LeftIconAttributes
        {
            get { return (ImageAttributes)GetValue(LeftIconAttributesProperty); }
            set { SetValue(LeftIconAttributesProperty, value); }
        }

        public ImageAttributes RightIconAttributes
        {
            get { return (ImageAttributes)GetValue(RightIconAttributesProperty); }
            set { SetValue(RightIconAttributesProperty, value); }
        }

        public TextAttributes RightTextAttributes
        {
            get { return (TextAttributes)GetValue(RightTextAttributesProperty); }
            set { SetValue(RightTextAttributesProperty, value); }
        }

        public uint? LeftSpace
        {
            get { return (uint?)GetValue(LeftSpaceProperty); }
            set { SetValue(LeftSpaceProperty, value); }
        }

        public uint? RightSpace
        {
            get { return (uint?)GetValue(RightSpaceProperty); }
            set { SetValue(RightSpaceProperty, value); }
        }

        public uint? SpaceBetweenLeftItemAndText
        {
            get { return (uint?)GetValue(SpaceBetweenLeftItemAndTextProperty); }
            set { SetValue(SpaceBetweenLeftItemAndTextProperty, value); }
        }

        public uint? SpaceBetweenRightItemAndText
        {
            get { return (uint?)GetValue(SpaceBetweenRightItemAndTextProperty); }
            set { SetValue(SpaceBetweenRightItemAndTextProperty, value); }
        }

        public string CheckBoxStyle
        {
            get { return (string)GetValue(CheckBoxStyleProperty); }
            set { SetValue(CheckBoxStyleProperty, value); }
        }

        public string SwitchStyle
        {
            get { return (string)GetValue(SwitchStyleProperty); }
            set { SetValue(SwitchStyleProperty, value); }
        }

        public string DropDownStyle
        {
            get { return (string)GetValue(DropDownStyleProperty); }
            set { SetValue(DropDownStyleProperty, value); }
        }

        public ListItem.StyleTypes StyleType
        {
            get { return (ListItem.StyleTypes)GetValue(StyleTypeProperty); }
            set { SetValue(StyleTypeProperty, value); }
        }

        public override Attributes Clone()
        {
            return new ListItemAttributes(this);
        }
    }
}
