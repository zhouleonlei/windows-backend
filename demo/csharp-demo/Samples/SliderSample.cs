using Tizen.NUI.BaseComponents;
using System;


namespace Tizen.NUI.Examples
{
    public class SliderSample : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Window.Instance.BackgroundColor = Color.White;

            CreateNUI();
            CreateDA();
            CreateIndicator();

            objIndex = 1;
            Window.Instance.KeyEvent += OnKeyEvent;
            FocusManager.Instance.SetCurrentFocusView(sliderBase);
            indicator.Text = "base, CurrentValue = " + sliderBase.CurrentValue.ToString();
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

            sliderBase = new Tizen.NUI.Controls.Slider();
            sliderBase.Position2D = new Position2D(250, 100);
            sliderBase.Size2D = new Size2D(1370, 50);
            sliderBase.BackgroundColor = new Color(1.0f, 1.0f, 0, 0.2f);
            sliderBase.MinValue = 0;
            sliderBase.MaxValue = 100;
            sliderBase.CurrentValue = 30;
            sliderBase.ThumbImageURL = "*DemoRes*/images/FH3/9. Controller/controller_btn_slide_handler_normal.png";
            Window.Instance.Add(sliderBase);
            sliderBase.GestureEvent += OnGestureEventNUI;
            sliderBase.FocusGained += OnFocusGained;
            sliderBase.FocusLost += OnFocusLost;
        }

        private void CreateDA()
        {
            title2 = new TextLabel();
            title2.Size2D = new Size2D(150, 50);
            title2.Position2D = new Position2D(50, 300);
            title2.BackgroundColor = Color.Blue;
            title2.TextColor = Color.Yellow;
            title2.PointSize = 15;
            title2.HorizontalAlignment = HorizontalAlignment.Center;
            title2.VerticalAlignment = VerticalAlignment.Center;
            title2.Text = "DA Default";
            Window.Instance.Add(title2);

            sliderDA = new DA.NUI.Controls.Slider();
            sliderDA.Position2D = new Position2D(250, 300);
            sliderDA.Size2D = new Size2D(1370, 50);
            sliderDA.BackgroundColor = new Color(255, 255, 0, 0.2f);
            sliderDA.MinValue = 0;
            sliderDA.MaxValue = 100;
            sliderDA.CurrentValue = 50;
            Window.Instance.Add(sliderDA);
            sliderDA.GestureEvent += OnGestureEventDA;
        }

        private void CreateIndicator()
        {
            indicator = new TextLabel();
            indicator.Size2D = new Size2D(350, 50);
            indicator.Position2D = new Position2D(50, 30);
            indicator.PointSize = 15;
            indicator.BackgroundColor = new Color(238.0f / 255.0f, 183.0f / 255.0f, 79.0f / 255.0f, 255.0f / 255.0f);
            indicator.HorizontalAlignment = HorizontalAlignment.Begin;
            indicator.VerticalAlignment = VerticalAlignment.Center;
            Window.Instance.Add(indicator);
        }

        private void SetFocusToSlider(int idx)
        {
            if (idx == 1)
            {
                FocusManager.Instance.SetCurrentFocusView(sliderBase);
                indicator.Text = "NUI, CurrentValue = " + sliderBase.CurrentValue.ToString();
            }
            else if (idx == COUNT)
            {
                FocusManager.Instance.SetCurrentFocusView(sliderDA);
                indicator.Text = "DA Default, CurrentValue = " + sliderDA.CurrentValue.ToString();
            }
        }

        private void ChangeCurValue(int idx, string keyNameStr)
        {
            if (idx == 1)
            {
                if (keyNameStr == "Left")
                {
                    if (sliderBase.CurrentValue > sliderBase.MinValue)
                    {
                        sliderBase.CurrentValue--;
                    }
                    else
                    {
                        sliderBase.CurrentValue = sliderBase.MaxValue;
                    }
                }
                else if (keyNameStr == "Right")
                {
                    if (sliderBase.CurrentValue < sliderBase.MaxValue)
                    {
                        sliderBase.CurrentValue++;
                    }
                    else
                    {
                        sliderBase.CurrentValue = sliderBase.MinValue;
                    }
                }
                indicator.Text = "NUI, CurrentValue = " + sliderBase.CurrentValue.ToString();
            }
            else if (idx == COUNT)
            {
                if (keyNameStr == "Left")
                {
                    if (sliderDA.CurrentValue > sliderDA.MinValue)
                    {
                        sliderDA.CurrentValue--;
                    }
                    else
                    {
                        sliderDA.CurrentValue = sliderDA.MaxValue;
                    }
                }
                else if (keyNameStr == "Right")
                {
                    if (sliderDA.CurrentValue < sliderDA.MaxValue)
                    {
                        sliderDA.CurrentValue++;
                    }
                    else
                    {
                        sliderDA.CurrentValue = sliderDA.MinValue;
                    }
                }
                indicator.Text = "DA Default, CurrentValue = " + sliderDA.CurrentValue.ToString();
            }
        }

        private void ChangeThumbSize(int idx)
        {
            if (idx == 1)
            {
                if (sliderBase.ThumbSize.Width == 60)
                {
                    sliderBase.ThumbSize = new Size2D(100, 100);
                }
                else if (sliderBase.ThumbSize.Width == 100)
                {
                    sliderBase.ThumbSize = new Size2D(40, 40);
                }
                else if (sliderBase.ThumbSize.Width == 40)
                {
                    sliderBase.ThumbSize = new Size2D(60, 60);
                }
            }
            else if (idx == COUNT)
            {
                if (sliderDA.ThumbSize.Width == 60)
                {
                    sliderDA.ThumbSize = new Size2D(100, 100);
                }
                else if (sliderDA.ThumbSize.Width == 100)
                {
                    sliderDA.ThumbSize = new Size2D(40, 40);
                }
                else if (sliderDA.ThumbSize.Width == 40)
                {
                    sliderDA.ThumbSize = new Size2D(60, 60);
                }
            }
        }

        private void ChangeBarHeight(int idx)
        {
            if (idx == 1)
            {
                if (sliderBase.BarHeight == 4)
                {
                    sliderBase.BarHeight = 10;
                }
                else if (sliderBase.BarHeight == 10)
                {
                    sliderBase.BarHeight = 30;
                }
                else if (sliderBase.BarHeight == 30)
                {
                    sliderBase.BarHeight = 4;
                }
            }
            else if (idx == COUNT)
            {
                if (sliderDA.BarHeight == 4)
                {
                    sliderDA.BarHeight = 10;
                }
                else if (sliderDA.BarHeight == 10)
                {
                    sliderDA.BarHeight = 30;
                }
                else if (sliderDA.BarHeight == 30)
                {
                    sliderDA.BarHeight = 4;
                }
            }
        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Up")
                {
                    if (objIndex > 1)
                    {
                        objIndex--;
                    }
                    else
                    {
                        objIndex = COUNT;
                    }
                    SetFocusToSlider(objIndex);
                }
                else if (e.Key.KeyPressedName == "Down")
                {
                    if (objIndex < COUNT)
                    {
                        objIndex++;
                    }
                    else
                    {
                        objIndex = 1;
                    }
                    SetFocusToSlider(objIndex);
                }
                else if (e.Key.KeyPressedName == "Left")
                {
                    ChangeCurValue(objIndex, "Left");
                }
                else if (e.Key.KeyPressedName == "Right")
                {
                    ChangeCurValue(objIndex, "Right");
                }
                else if (e.Key.KeyPressedName == "1")
                {
                    ChangeThumbSize(objIndex);
                }
                else if (e.Key.KeyPressedName == "2")
                {
                    ChangeBarHeight(objIndex);
                }
            }
        }

        private void OnGestureEventNUI(object sender, Tizen.NUI.Controls.Slider.GestureEventArgs e)
        {
            objIndex = 1;
            indicator.Text = "NUI, CurrentValue = " + e.CurrentValue.ToString();
        }

        private void OnGestureEventDA(object sender, Tizen.NUI.Controls.Slider.GestureEventArgs e)
        {
            objIndex = COUNT;
            indicator.Text = "DA Default, CurrentValue = " + e.CurrentValue.ToString();
        }

        private void OnFocusGained(object source, EventArgs e)
        {
            sliderBase.ThumbImageURL = "*DemoRes*/images/FH3/9. Controller/controller_btn_slide_handler_press.png";
        }

        private void OnFocusLost(object source, EventArgs e)
        {
            sliderBase.ThumbImageURL = "*DemoRes*/images/FH3/9. Controller/controller_btn_slide_handler_normal.png";
        }

        Tizen.NUI.Controls.Slider sliderBase = null;
        Tizen.DA.NUI.Controls.Slider sliderDA = null;
        TextLabel title1 = null;
        TextLabel title2 = null;
        TextLabel indicator = null;
        private int objIndex;
        private const int COUNT = 2;
    }
}
