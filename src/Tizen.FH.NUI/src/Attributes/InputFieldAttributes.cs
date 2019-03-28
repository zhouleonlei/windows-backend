using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.CommonUI;
using System.ComponentModel;

namespace Tizen.FH.NUI.Controls
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class InputFieldAttributes : Tizen.NUI.CommonUI.InputFieldAttributes
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InputFieldAttributes() : base() { }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InputFieldAttributes(InputFieldAttributes attrs) : base(attrs)
        {
            if (attrs.CancelButtonAttributes != null)
            {
                CancelButtonAttributes = attrs.CancelButtonAttributes.Clone() as ImageAttributes;
            }
            if (attrs.DeleteButtonAttributes != null)
            {
                DeleteButtonAttributes = attrs.DeleteButtonAttributes.Clone() as ImageAttributes;
            }
            if (attrs.AddButtonBgAttributes != null)
            {
                AddButtonBgAttributes = attrs.AddButtonBgAttributes.Clone() as ImageAttributes;
            }
            if (attrs.AddButtonOverlayAttributes != null)
            {
                AddButtonOverlayAttributes = attrs.AddButtonOverlayAttributes.Clone() as ImageAttributes;
            }
            if (attrs.AddButtonFgAttributes != null)
            {
                AddButtonFgAttributes = attrs.AddButtonFgAttributes.Clone() as ImageAttributes;
            }
            if (attrs.SearchButtonAttributes != null)
            {
                SearchButtonAttributes = attrs.SearchButtonAttributes.Clone() as ImageAttributes;
            }
            if (attrs.SpaceBetweenTextFieldAndRightButton != null)
            {
                SpaceBetweenTextFieldAndRightButton = attrs.SpaceBetweenTextFieldAndRightButton;
            }
            if (attrs.SpaceBetweenTextFieldAndLeftButton != null)
            {
                SpaceBetweenTextFieldAndLeftButton = attrs.SpaceBetweenTextFieldAndLeftButton;
            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes CancelButtonAttributes
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes DeleteButtonAttributes
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes AddButtonBgAttributes
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes AddButtonOverlayAttributes
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes AddButtonFgAttributes
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes SearchButtonAttributes
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? SpaceBetweenTextFieldAndRightButton
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? SpaceBetweenTextFieldAndLeftButton
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new InputFieldAttributes(this);
        }
    }
}
