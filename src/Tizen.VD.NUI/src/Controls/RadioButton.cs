
using Tizen.VD.NUI.Renderers;

namespace Tizen.VD.NUI.Controls
{
    public class RadioButton : Tizen.NUI.Controls.RadioButton
    {
        //static constructor used to register internal style
        static RadioButton()
        {
            RegisterStyle("C_RadioButton_White", typeof(RadioButtonRenderer));
        }

        public RadioButton() : base() { }
        public RadioButton(string style) : base(style) { }

    }
}
