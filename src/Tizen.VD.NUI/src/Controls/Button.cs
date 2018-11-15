
using Tizen.VD.NUI.Renderers;

namespace Tizen.VD.NUI.Controls
{
    public class Button : Tizen.NUI.Controls.Button
    {
        //static constructor used to register internal style
        static Button()
        {
            RegisterStyle("C_ButtonBasic_WhiteText", typeof(CButtonBasicWhiteTextRenderer));
            RegisterStyle("C_ButtonBasic_WhiteIcon", typeof(CButtonBasicWhiteIconRenderer));
        }

        public Button() : base() { }
        public Button(string style) : base(style) { }

    }
}
