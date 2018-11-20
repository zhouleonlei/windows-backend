using Tizen.NUI.BaseComponents;


namespace Tizen.NUI.Examples
{
    public class SliderSample : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Window.Instance.BackgroundColor = Color.White;

            CreateNUI();

            //title2 = new TextLabel();
            //title2.Size2D = new Size2D(150, 50);
            //title2.Position2D = new Position2D(50, 300);
            //title2.BackgroundColor = Color.Yellow;
            //title2.PointSize = 15;
            //title2.HorizontalAlignment = HorizontalAlignment.Center;
            //title2.VerticalAlignment = VerticalAlignment.Center;
            //title2.Text = "SliderDefault";
            //window.Add(title2);

            //sliderDA = new DA.NUI.Controls.Slider();
            //sliderDA.Position2D = new Position2D(250, 300);
            //sliderDA.Size2D = new Size2D(1370, 50);
            //sliderDA.BackgroundColor = new Color(255, 255, 0, 0.5f);
            //sliderDA.MinValue = 0;
            //sliderDA.MaxValue = 100;
            //sliderDA.CurrentValue = 50;

            //window.Add(sliderDA);

            CreateIndicator();
            Window.Instance.KeyEvent += OnKeyEvent;
        }

        private void CreateNUI()
        {
            title1 = new TextLabel();
            title1.Size2D = new Size2D(150, 50);
            title1.Position2D = new Position2D(50, 100);
            title1.PointSize = 15;
            title1.BackgroundColor = Color.Blue;
            title1.TextColor = Color.Yellow;
            title1.HorizontalAlignment = HorizontalAlignment.Center;
            title1.VerticalAlignment = VerticalAlignment.Center;
            title1.Text = "NUI";
            Window.Instance.Add(title1);

            slider = new Tizen.NUI.Controls.Slider();
            slider.Position2D = new Position2D(250, 100);
            slider.Size2D = new Size2D(1370, 50);
            slider.BackgroundColor = new Color(1.0f, 1.0f, 0, 0.5f);
            slider.MinValue = 0;
            slider.MaxValue = 100;
            slider.CurrentValue = 30;
            slider.ThumbImageURL = "*DemoRes*/images/FH3/9. Controller/controller_btn_slide_handler_normal.png";
            Window.Instance.Add(slider);
            slider.GestureEvent += OnGestureEventNUI;
        }

        private void CreateIndicator()
        {
            indicator = new TextLabel();
            indicator.Size2D = new Size2D(300, 50);
            indicator.Position2D = new Position2D(50, 30);
            indicator.PointSize = 15;
            indicator.BackgroundColor = new Color(238.0f / 255.0f, 183.0f / 255.0f, 79.0f / 255.0f, 255.0f / 255.0f);
            indicator.HorizontalAlignment = HorizontalAlignment.Begin;
            indicator.VerticalAlignment = VerticalAlignment.Center;
            indicator.Text = "CurrentValue = " + slider.CurrentValue.ToString();
            Window.Instance.Add(indicator);
        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Up")
                {
                    FocusManager.Instance.SetCurrentFocusView(slider);
                }
                else if (e.Key.KeyPressedName == "Down")
                {
                    //FocusManager.Instance.SetCurrentFocusView(sliderDA);
                }
                else if (e.Key.KeyPressedName == "Left")
                {
                    if (slider.CurrentValue > slider.MinValue)
                    {
                        slider.CurrentValue--;
                    }
                    else
                    {
                        slider.CurrentValue = slider.MaxValue;
                    }
                    indicator.Text = "CurrentValue = " + slider.CurrentValue.ToString();
                }
                else if (e.Key.KeyPressedName == "Right")
                {
                    if (slider.CurrentValue < slider.MaxValue)
                    {
                        slider.CurrentValue++;
                    }
                    else
                    {
                        slider.CurrentValue = slider.MinValue;
                    }
                    indicator.Text = "CurrentValue = " + slider.CurrentValue.ToString();
                }
                else if (e.Key.KeyPressedName == "1")
                {
                    if (slider.ThumbSize.Width == 60)
                    {
                        slider.ThumbSize = new Size2D(100, 100);
                    }
                    else if (slider.ThumbSize.Width == 100)
                    {
                        slider.ThumbSize = new Size2D(40, 40);
                    }
                    else if (slider.ThumbSize.Width == 40)
                    {
                        slider.ThumbSize = new Size2D(60, 60);
                    }
                }
                else if (e.Key.KeyPressedName == "2")
                {
                    if (slider.BarHeight == 4)
                    {
                        slider.BarHeight = 10;
                    }
                    else if (slider.BarHeight == 10)
                    {
                        slider.BarHeight = 30;
                    }
                    else if (slider.BarHeight == 30)
                    {
                        slider.BarHeight = 4;
                    }
                }
            }
        }

        private void OnGestureEventNUI(object sender, Tizen.NUI.Controls.Slider.GestureEventArgs e)
        {
            indicator.Text = "CurrentValue = " + e.CurrentValue.ToString();
        }

        Tizen.NUI.Controls.Slider slider = null;
        //Tizen.DA.NUI.Controls.Slider sliderDA = null;
        TextLabel title1 = null;
        //TextLabel title2 = null;
        TextLabel indicator = null;
    }
}
