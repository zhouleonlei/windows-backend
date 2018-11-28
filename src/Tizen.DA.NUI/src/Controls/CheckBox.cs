using Tizen.DA.NUI.Renderers;

namespace Tizen.DA.NUI.Controls
{
    public class CheckBox : Tizen.NUI.Controls.CheckBox
    {
        //static constructor used to register internal style
        static CheckBox()
        {
            RegisterStyle("C_CheckBox", typeof(CheckBoxRenderer));
        }

        public CheckBox() : base() { }
        public CheckBox(string style) : base(style) { }

    }
}
