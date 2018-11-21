using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;
using Tizen.DA.NUI.Controls;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.DA.NUI.res.SliderDefaultRenderer.xaml", "SliderDefaultRenderer.xaml", typeof(Tizen.DA.NUI.Renderers.SliderDefaultRenderer))]

namespace Tizen.DA.NUI.Renderers
{
    public class SliderDefaultRenderer : Tizen.NUI.Renderers.SliderRenderer
    {
        public SliderDefaultRenderer()
        {
        }

        public override void OnPropertyChanged(string type, View sender)
        {
            Slider realSender = sender as Slider;

            switch (type)
            {
                default:
                    base.OnPropertyChanged(type, sender);
                    break;
            }
        }

        private void UpdateSliderSize(Size2D newSize)
        {
            int bgBarWidth = newSize.Width - space * 2;

            backgroundBar.Position2D = new Position2D(space, (newSize.Height - barHeight) / 2);
            backgroundBar.Size2D = new Size2D(bgBarWidth, barHeight);

            sliderBar.Size2D = new Size2D((int)(bgBarWidth * CurrentPercent), barHeight);
        }

        protected override void OnSizeChanged(Size2D newSize)
        {
            UpdateSliderSize(newSize);
        }

        protected override void OnValueChanged(float newPercent)
        {
            base.OnValueChanged(newPercent);
        }

        private int barHeight = 4;
        private int space = 40;
    }
}
