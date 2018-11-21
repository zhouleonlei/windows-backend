using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;
using Tizen.VD.NUI.Controls;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.VD.NUI.res.SliderRenderer.xaml", "SliderRenderer.xaml", typeof(Tizen.VD.NUI.Renderers.SliderRenderer))]

namespace Tizen.VD.NUI.Renderers
{
    public class SliderRenderer : Tizen.NUI.Renderers.SliderRenderer
    {
        internal const string MinValueTextSizeChanged = "MinValueTextSizeChanged";
        internal const string MaxValueTextSizeChanged = "MaxValueTextSizeChanged";
        internal const string TipTextSizeChanged = "TipTextSizeChanged";

        public SliderRenderer()
        {
            minValueText = NameScopeExtensions.FindByName<TextLabel>(layout, "minValueText");
            maxValueText = NameScopeExtensions.FindByName<TextLabel>(layout, "maxValueText");
            tipText = NameScopeExtensions.FindByName<TextLabel>(layout, "tipText");
        }

        public override void OnPropertyChanged(string type, View sender)
        {
            Slider realSender = sender as Slider;

            switch (type)
            {
                case MinValueTextSizeChanged:
                    minValueText.Size2D = realSender.MinValueTextSize;
                    UpdateSliderSize(realSender.Size2D);
                    break;

                case MaxValueTextSizeChanged:
                    maxValueText.Size2D = realSender.MaxValueTextSize;
                    UpdateSliderSize(realSender.Size2D);
                    break;

                case TipTextSizeChanged:
                    tipText.Size2D = realSender.TipTextSize;
                    UpdateSliderSize(realSender.Size2D);
                    break;

                default:
                    base.OnPropertyChanged(type, sender);
                    break;
            }
        }

        private void UpdateSliderSize(Size2D newSize)
        {
            int bgBarWidth = newSize.Width - minValueText.Size2D.Width - maxValueText.Size2D.Width - space * 2;
            int bgBarHeight = newSize.Height - tipText.Size2D.Height - space;

            backgroundBar.Position2D = new Position2D(minValueText.Size2D.Width + space, backgroundBar.Position2D.Y);
            backgroundBar.Size2D = new Size2D(bgBarWidth, bgBarHeight);

            sliderBar.Size2D = new Size2D((int)(bgBarWidth * CurrentPercent), bgBarHeight);

            minValueText.Position2D = new Position2D(0, 0);
            maxValueText.Position2D = new Position2D(minValueText.Position2D.X + minValueText.Size2D.Width + space + bgBarWidth + space, 0);

            if (CurrentPercent > 0)
            {
                tipText.Show();
                tipText.Position2D = new Position2D(minValueText.Position2D.X + space + backgroundBar.Position2D.X + bgBarWidth - tipText.Size2D.Width / 2, bgBarHeight + space);
            }
            else
            {
                tipText.Hide();
            }
        }

        protected override void OnSizeChanged(Size2D newSize)
        {
            UpdateSliderSize(newSize);
        }

        protected override void OnValueChanged(float newPercent)
        {
            base.OnValueChanged(newPercent);

            if (CurrentPercent > 0)
            {
                tipText.Show();
                tipText.Position2D = new Position2D(minValueText.Position2D.X + space + backgroundBar.Position2D.X + backgroundBar.Size2D.Width - tipText.Size2D.Width / 2, backgroundBar.Size2D.Height + space);
            }
            else
            {
                tipText.Hide();
            }
        }

        protected TextLabel minValueText, maxValueText, tipText;
        private int space = 5;
    }
}
