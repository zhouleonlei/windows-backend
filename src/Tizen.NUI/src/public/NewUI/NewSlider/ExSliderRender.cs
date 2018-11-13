using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static Tizen.NUI.BaseComponents.View;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.BaseComponents
{
    public class ExSliderRenderer : NewSliderRenderer
    {
        internal const string MinValueTextSizeChange = "MinValueTextSizeChange";
        internal const string MaxValueTextSizeChange = "MaxValueTextSizeChange";
        internal const string PromptTextSizeChange = "PromptTextSizeChange";

        public ExSliderRenderer()
        {
            minValueText = NameScopeExtensions.FindByName<TextLabel>(layout, "minValueText");
            maxValueText = NameScopeExtensions.FindByName<TextLabel>(layout, "maxValueText");
            promptText = NameScopeExtensions.FindByName<TextLabel>(layout, "PromptText");
        }

        public override void OnPropertyChanged(string type, View sender)
        {
            ExSlider realSender = sender as ExSlider;

            switch (type)
            {
                case MinValueTextSizeChange:
                    minValueText.Size2D = realSender.MinValueTextSize;
                    UpdateSliderSize(realSender.Size2D);
                    break;

                case MaxValueTextSizeChange:
                    maxValueText.Size2D = realSender.MaxValueTextSize;
                    UpdateSliderSize(realSender.Size2D);
                    break;

                case PromptTextSizeChange:
                    promptText.Size2D = realSender.PromptTextSize;
                    UpdateSliderSize(realSender.Size2D);
                    break;

                default:
                    base.OnPropertyChanged(type, sender);
                    break;
            }
        }

        private int space = 5;

        private void UpdateSliderSize(Size2D newSize)
        {
            int progressBarWidth = newSize.Width - minValueText.Size2D.Width - maxValueText.Size2D.Width - space * 2;
            int progressBarHeight = newSize.Height - promptText.Size2D.Height - space;

            progressBar.Position2D = new Position2D(minValueText.Size2D.Width + space, progressBar.Position2D.Y);
            progressBar.Size2D = new Size2D(progressBarWidth, progressBarHeight);

            progressValue.Size2D = new Size2D((int)(progressBar.Size2D.Width * valuePercent), progressBarHeight);

            minValueText.Position2D = new Position2D(0, 0);

            maxValueText.Position2D = new Position2D(minValueText.Position2D.X + minValueText.Size2D.Width + space + progressBarWidth + space, 0);

            if (0 < valuePercent)
            {
                promptText.SetVisible(true);
                promptText.Position2D = new Position2D(minValueText.Position2D.X + space + progressBar.Position2D.X + progressValue.Size2D.Width - promptText.Size2D.Width / 2, progressBar.Size2D.Height + space);
            }
            else
            {
                promptText.SetVisible(false);
            }
        }

        protected override void OnSizeChanged(Size2D newSize)
        {
            UpdateSliderSize(newSize);
        }

        protected override void OnValuePercentChanged(float newPercent)
        {
            base.OnValuePercentChanged(newPercent);

            if (0 < valuePercent)
            {
                promptText.SetVisible(true);
                promptText.Position2D = new Position2D(minValueText.Position2D.X + space + progressBar.Position2D.X + progressValue.Size2D.Width - promptText.Size2D.Width / 2, progressBar.Size2D.Height + space);
            }
            else
            {
                promptText.SetVisible(false);
            }
        }

        protected TextLabel minValueText;
        protected TextLabel maxValueText;
        protected TextLabel promptText;
    }
}
