using Tizen.NUI.BaseComponents;


namespace Tizen.NUI.Examples
{
    public class SliderSample : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = Window.Instance;

            Tizen.VD.NUI.Controls.ExSlider slider = new Tizen.VD.NUI.Controls.ExSlider();
            slider.Position2D = new Position2D(300, 100);
            slider.Size2D = new Size2D(1370, 95);

            slider.MinValue = 0;
            slider.MaxValue = 100;
            slider.Value = 30;

            slider.PromptTextSize = new Size2D(60, 60);
            slider.MinValueTextSize = new Size2D(80, 50);
            slider.MaxValueTextSize = new Size2D(80, 50);
            window.Add(slider);

        }
    }
}
