using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    public class InputFieldAttributes : Tizen.NUI.CommonUI.InputFieldAttributes
    {      
        public InputFieldAttributes() : base() { }

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
      
        public ImageAttributes CancelButtonAttributes
        {
            get;
            set;
        }

        public ImageAttributes DeleteButtonAttributes
        {
            get;
            set;
        }

        public ImageAttributes AddButtonBgAttributes
        {
            get;
            set;
        }

        public ImageAttributes AddButtonOverlayAttributes
        {
            get;
            set;
        }

        public ImageAttributes AddButtonFgAttributes
        {
            get;
            set;
        }

        public ImageAttributes SearchButtonAttributes
        {
            get;
            set;
        }

        public int? SpaceBetweenTextFieldAndRightButton
        {
            get;
            set;
        }

        public int? SpaceBetweenTextFieldAndLeftButton
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new InputFieldAttributes(this);
        }
    }
}
