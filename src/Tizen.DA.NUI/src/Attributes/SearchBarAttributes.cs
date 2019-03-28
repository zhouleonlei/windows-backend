using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    public class SearchBarAttributes : Tizen.NUI.CommonUI.ViewAttributes
    {
        public SearchBarAttributes() : base() { }

        public SearchBarAttributes(SearchBarAttributes attrs) : base(attrs)
        {
            if (attrs.SearchBoxAttributes != null)
            {
                SearchBoxAttributes = attrs.SearchBoxAttributes.Clone() as InputFieldAttributes;
            }
            if (attrs.ResultListAttributes != null)
            {
                ResultListAttributes = attrs.ResultListAttributes.Clone() as ViewAttributes;
            }
            if (attrs.Space != null)
            {
                Space = attrs.Space;
            }
        }

        public InputFieldAttributes SearchBoxAttributes
        {
            get;
            set;
        }

        public ViewAttributes ResultListAttributes
        {
            get;
            set;
        }

        public int? Space
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new SearchBarAttributes(this);
        }
    }
}
