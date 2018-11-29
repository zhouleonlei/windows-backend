using System;
using Tizen.NUI;
using Tizen.NUI.Controls;
using Tizen.NUI.Renderers;
using Tizen.DA.NUI.Renderers;

namespace Tizen.DA.NUI.Controls
{
    public class ToggleButton : Tizen.NUI.Controls.ToggleButton
    {

        //static constructor used to register internal style
        static ToggleButton()
        {
            RegisterStyle("C_ToggleButton", typeof(CToggleButtonRenderer));
        }

        public ToggleButton() : base() { }
        public ToggleButton(string style) : base(style) { }

        protected override BaseRenderer GetRenderer()
        {
            return new CToggleButtonRenderer();
        }
    }
}
