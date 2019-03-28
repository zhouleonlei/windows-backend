using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.CommonUI;
using System.ComponentModel;

namespace Tizen.FH.NUI.Controls
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ListItemAttributes : Tizen.NUI.CommonUI.ViewAttributes
    {         
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ListItemAttributes() : base() { }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes MainTextAttributes
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes MainText2Attributes
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes SubTextAttributes
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes DividerViewAttributes
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewAttributes LeftItemRootViewAttributes
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewAttributes RightItemRootViewAttributes
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes LeftIconAttributes
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes RightIconAttributes
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes RightTextAttributes
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint? LeftSpace
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint? RightSpace
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint? SpaceBetweenLeftItemAndText
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint? SpaceBetweenRightItemAndText
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CheckBoxStyle
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SwitchStyle
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DropDownStyle
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ListItem.StyleTypes StyleType
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new ListItemAttributes(this);
        }
    }
}
