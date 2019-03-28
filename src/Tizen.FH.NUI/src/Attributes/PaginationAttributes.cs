using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class PaginationAttributes : Tizen.NUI.CommonUI.PaginationAttributes
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PaginationAttributes() : base() { }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PaginationAttributes(PaginationAttributes attributes) : base(attributes)
        {
            if (attributes.ReturnArrowAttributes != null)
            {
                ReturnArrowAttributes = attributes.ReturnArrowAttributes.Clone() as ImageAttributes;
            }
            if (attributes.NextArrowAttributes != null)
            {
                NextArrowAttributes = attributes.NextArrowAttributes.Clone() as ImageAttributes;
            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes ReturnArrowAttributes
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes NextArrowAttributes
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new PaginationAttributes(this);
        }
    }
}
