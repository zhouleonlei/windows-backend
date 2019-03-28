using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class PaginationAttributes : Tizen.NUI.CommonUI.PaginationAttributes
    {      
        public PaginationAttributes() : base() { }
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

        public ImageAttributes ReturnArrowAttributes
        {
            get;
            set;
        }

        public ImageAttributes NextArrowAttributes
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new PaginationAttributes(this);
        }
    }
}
