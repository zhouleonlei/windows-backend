using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    public class ListItemAttributes : Tizen.NUI.CommonUI.ViewAttributes
    {     
        public ListItemAttributes() : base() { }

        public ListItemAttributes(ListItemAttributes attrs) : base(attrs)
        {
            if (attrs.MainTextAttributes != null)
            {
                MainTextAttributes = attrs.MainTextAttributes.Clone() as TextAttributes;
            }
            if (attrs.SubTextAttributes != null)
            {
                SubTextAttributes = attrs.SubTextAttributes.Clone() as TextAttributes;
            }
            if (attrs.DividerViewAttributes != null)
            {
                DividerViewAttributes = attrs.DividerViewAttributes.Clone() as ImageAttributes;
            }
            if (attrs.LeftItemRootViewAttributes != null)
            {
                LeftItemRootViewAttributes = attrs.LeftItemRootViewAttributes.Clone() as ViewAttributes;
            }
            if (attrs.RightItemRootViewAttributes != null)
            {
                RightItemRootViewAttributes = attrs.RightItemRootViewAttributes.Clone() as ViewAttributes;
            }
            if (attrs.LeftIconAttributes != null)
            {
                LeftIconAttributes = attrs.LeftIconAttributes.Clone() as ImageAttributes;
            }
            if (attrs.RightIconAttributes != null)
            {
                RightIconAttributes = attrs.RightIconAttributes.Clone() as ImageAttributes;
            }
            if (attrs.RightTextAttributes != null)
            {
                RightTextAttributes = attrs.RightTextAttributes.Clone() as TextAttributes;
            }
            if (attrs.LeftSpace != null)
            {
                LeftSpace = attrs.LeftSpace;
            }
            if (attrs.RightSpace != null)
            {
                RightSpace = attrs.RightSpace;
            }
            if (attrs.SpaceBetweenLeftItemAndText != null)
            {
                SpaceBetweenLeftItemAndText = attrs.SpaceBetweenLeftItemAndText;
            }
            if (attrs.SpaceBetweenRightItemAndText != null)
            {
                SpaceBetweenRightItemAndText = attrs.SpaceBetweenRightItemAndText;
            }
            if (attrs.CheckBoxStyle != null)
            {
                CheckBoxStyle = attrs.CheckBoxStyle;
            }
            if (attrs.SwitchStyle != null)
            {
                SwitchStyle = attrs.SwitchStyle;
            }
            if (attrs.DropDownStyle != null)
            {
                DropDownStyle = attrs.DropDownStyle;
            }
            StyleType = attrs.StyleType;
        }

        public TextAttributes MainTextAttributes
        {
            get;
            set;
        }

        public TextAttributes MainText2Attributes
        {
            get;
            set;
        }

        public TextAttributes SubTextAttributes
        {
            get;
            set;
        }

        public ImageAttributes DividerViewAttributes
        {
            get;
            set;
        }

        public ViewAttributes LeftItemRootViewAttributes
        {
            get;
            set;
        }

        public ViewAttributes RightItemRootViewAttributes
        {
            get;
            set;
        }

        public ImageAttributes LeftIconAttributes
        {
            get;
            set;
        }

        public ImageAttributes RightIconAttributes
        {
            get;
            set;
        }

        public TextAttributes RightTextAttributes
        {
            get;
            set;
        }

        public uint? LeftSpace
        {
            get;
            set;
        }

        public uint? RightSpace
        {
            get;
            set;
        }

        public uint? SpaceBetweenLeftItemAndText
        {
            get;
            set;
        }

        public uint? SpaceBetweenRightItemAndText
        {
            get;
            set;
        }

        public string CheckBoxStyle
        {
            get;
            set;
        }

        public string SwitchStyle
        {
            get;
            set;
        }

        public string DropDownStyle
        {
            get;
            set;
        }

        public ListItem.StyleTypes StyleType
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new ListItemAttributes(this);
        }
    }
}
