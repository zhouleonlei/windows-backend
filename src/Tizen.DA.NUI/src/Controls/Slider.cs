using System;
using Tizen.NUI;
using Tizen.NUI.Controls;
using Tizen.NUI.Renderers;
using Tizen.DA.NUI.Renderers;

namespace Tizen.DA.NUI.Controls
{
    /// <summary>
    /// The class of the Slider component.
    /// </summary>
    public class Slider : Tizen.NUI.Controls.Slider
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        public Slider() : base()
        {
        }

        protected override void OnFocusGained(object sender, EventArgs e)
        {
            State = States.Focused;
            base.OnFocusGained(sender, e);
        }

        protected override void OnFocusLost(object sender, EventArgs e)
        {
            State = States.Normal;
            base.OnFocusLost(sender, e);
        }

        protected override BaseRenderer GetRenderer()
        {
            return new Tizen.DA.NUI.Renderers.SliderDefaultRenderer();
        }
    }
}
