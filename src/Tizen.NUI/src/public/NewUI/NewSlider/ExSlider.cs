using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static Tizen.NUI.BaseComponents.View;

using Tizen.NUI.Xaml;

namespace Tizen.NUI.BaseComponents
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
