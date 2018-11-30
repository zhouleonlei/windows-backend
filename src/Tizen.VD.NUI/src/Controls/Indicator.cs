
using Tizen.VD.NUI.Renderers;

namespace Tizen.VD.NUI.Controls
{
    public class Indicator : Tizen.NUI.Controls.Indicator
    {
        //static constructor used to register internal style
        static Indicator()
        {
            RegisterStyle("C_Indicator_WhiteMedium", typeof(CIndicatorWhiteMediumRenderer));
            RegisterStyle("C_Indicator_WhiteSmall", typeof(CIndicatorWhiteSmallRenderer));
        }

        public Indicator() : base() { }
        public Indicator(string style) : base(style) { }

    }
}
