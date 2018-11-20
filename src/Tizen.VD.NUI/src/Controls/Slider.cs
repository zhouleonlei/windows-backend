using Tizen.NUI;
using Tizen.NUI.Controls;
using Tizen.NUI.Renderers;
using Tizen.VD.NUI.Renderers;

namespace Tizen.VD.NUI.Controls
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

        /// <summary>
        /// The property of the size of the text that indicate the min value.
        /// </summary>
        public Size2D MinValueTextSize
        {
            get
            {
                return minValueTextSize;
            }
            set
            {
                minValueTextSize = value;
                renderer.OnPropertyChanged(Tizen.VD.NUI.Renderers.SliderRenderer.MinValueTextSizeChanged, this);
            }
        }

        /// <summary>
        /// The property of the size of the text that indicate the max value.
        /// </summary>
        public Size2D MaxValueTextSize
        {
            get
            {
                return maxValueTextSize;
            }
            set
            {
                maxValueTextSize = value;
                renderer.OnPropertyChanged(Tizen.VD.NUI.Renderers.SliderRenderer.MaxValueTextSizeChanged, this);
            }
        }

        /// <summary>
        /// The property of the size of the text that indicate the tip string.
        /// </summary>
        public Size2D TipTextSize
        {
            get
            {
                return tipTextSize;
            }
            set
            {
                tipTextSize = value;
                renderer.OnPropertyChanged(Tizen.VD.NUI.Renderers.SliderRenderer.TipTextSizeChanged, this);
            }
        }

        protected override BaseRenderer GetRenderer()
        {
            return new Tizen.VD.NUI.Renderers.SliderRenderer();
        }

        private Size2D minValueTextSize;
        private Size2D maxValueTextSize;
        private Size2D tipTextSize;
    }
}
