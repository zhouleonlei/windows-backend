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
            thumbUpper = NameScopeExtensions.FindByName<ImageView>(layout, "ThumbUpper");
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

        protected override void OnSizeChanged(Size2D newSize)
        {
            backgroundBar.PositionX = space;
            backgroundBar.Size2D = new Size2D(newSize.Width - space * 2, (int)BarHeight);

            CurrentSlidedOffset = UpdateValue();
        }

        protected override void OnValueChanged(float newPercent)
        {
            if ((CurrentPercent - newPercent > 0.0001) || (CurrentPercent - newPercent < -0.0001))
            {
                CurrentPercent = newPercent;
                CurrentSlidedOffset = UpdateValue();
            }
        }

        public override void OnStateChanged(View.States state)
        {
            thumbUpper.State = state;
            base.OnStateChanged(state);
        }

        protected ImageView thumbUpper;
        private int space = 40;
    }
}
