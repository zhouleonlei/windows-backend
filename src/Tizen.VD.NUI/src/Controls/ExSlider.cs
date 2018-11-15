using Tizen.NUI;
using Tizen.NUI.Controls;
using Tizen.NUI.Renderers;
using Tizen.VD.NUI.Renderers;

namespace Tizen.VD.NUI.Controls
{
    public class ExSlider : NewSlider
    {
        public ExSlider() : base()
        {

        }
        private Size2D minValueTextSize;
        public Size2D MinValueTextSize
        {
            get
            {
                return minValueTextSize;
            }
            set
            {
                minValueTextSize = value;
                renderer.OnPropertyChanged(ExSliderRenderer.MinValueTextSizeChange, this);
            }
        }

        private Size2D maxValueTextSize;
        public Size2D MaxValueTextSize
        {
            get
            {
                return maxValueTextSize;
            }
            set
            {
                maxValueTextSize = value;
                renderer.OnPropertyChanged(ExSliderRenderer.MaxValueTextSizeChange, this);
            }
        }

        private Size2D promptTextSize;
        public Size2D PromptTextSize
        {
            get
            {
                return promptTextSize;
            }
            set
            {
                promptTextSize = value;
                renderer.OnPropertyChanged(ExSliderRenderer.PromptTextSizeChange, this);
            }
        }

        protected override BaseRenderer GetRenderer()
        {
            return new ExSliderRenderer();
        }
    }
}
