
using Tizen.VD.NUI.Renderers;

namespace Tizen.VD.NUI.Controls
{
    public class Selection : Tizen.NUI.Controls.Selection
    {
        //static constructor used to register internal style
        static Selection()
        {
            RegisterStyle("C_Selection", typeof(CSelectionRenderer));
        }

        public Selection() : base() { }
        public Selection(string style) : base(style) { }

    }
}
