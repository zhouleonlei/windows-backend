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

        protected override BaseRenderer GetRenderer()
        {
            return new Tizen.DA.NUI.Renderers.SliderDefaultRenderer();
        }
    }
}
