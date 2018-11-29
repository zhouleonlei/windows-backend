
using Tizen.VD.NUI.Renderers;

namespace Tizen.VD.NUI.Controls
{
    public class CheckBox : Tizen.NUI.Controls.CheckBox
    {
        //static constructor used to register internal style
        static CheckBox()
        {
            RegisterStyle("C_CheckBox_White", typeof(CheckBoxRenderer));
        }

        public CheckBox() : base() { }
        public CheckBox(string style) : base(style) { }

    }
}
