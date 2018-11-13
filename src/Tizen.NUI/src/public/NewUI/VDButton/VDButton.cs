using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.BaseComponents
{
    public class VDButton : NewButton
    {
        //static constructor used to register internal style
        static VDButton()
        {
            RegisterStyle("C_ButtonBasic_WhiteText", typeof(CButtonBasicWhiteTextRenderer));
            RegisterStyle("C_ButtonBasic_WhiteIcon", typeof(CButtonBasicWhiteIconRenderer));
        }

        public VDButton() : base() { }
        public VDButton(string style) : base(style) { }

    }
}
