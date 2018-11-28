using Tizen.DA.NUI.Renderers;

namespace Tizen.DA.NUI.Controls
{
    public class RadioButton : Tizen.NUI.Controls.RadioButton
    {
        //static constructor used to register internal style
        static RadioButton()
        {
            RegisterStyle("C_RadioButton", typeof(RadioButtonRenderer));
        }

        public RadioButton() : base() { }
        public RadioButton(string style) : base(style) { }

    }
}
