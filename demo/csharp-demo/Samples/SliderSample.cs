using Tizen.NUI.BaseComponents;
using System;


namespace Tizen.NUI.Examples
{
    public class SliderSample : IExample
    {
        public void Activate()
        {
            Window.Instance.BackgroundColor = Color.White;

            CreateNUI();
            CreateDADefault();
            CreateDA1Text();
            CreateDA2Text();
            CreateIndicator();

            objIndex = 1;
            Window.Instance.KeyEvent += OnKeyEvent;
            FocusManager.Instance.SetCurrentFocusView(sliderBase);
            indicator.Text = "base, CurrentValue = " + sliderBase.CurrentValue.ToString();
        }
        public void Deactivate()
        {
            Window.Instance.KeyEvent -= OnKeyEvent;
            Window window = Window.Instance;
            window.Remove(sliderBase);
            window.Remove(sliderDA_Default);
            window.Remove(sliderDA_1SubText);
            window.Remove(sliderDA_2SubText);
            window.Remove(title1);
            window.Remove(title2);
            window.Remove(title3);
            window.Remove(title4);
            window.Remove(indicator);
            sliderBase.Dispose();
            sliderDA_Default.Dispose();
            sliderDA_1SubText.Dispose();
            sliderDA_2SubText.Dispose();
            title1.Dispose();
            title2.Dispose();
            title3.Dispose();
            title4.Dispose();
            indicator.Dispose();
        }

        private void CreateNUI()
        {
            title1 = new TextLabel();
            title1.Size2D = new Size2D(150, 60);
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
            sliderBase.Size2D = new Size2D(1370, 60);
            sliderBase.BackgroundColor = new Color(1.0f, 1.0f, 0, 0.2f);
            sliderBase.MinValue = 0;
            sliderBase.MaxValue = 100;
            sliderBase.CurrentValue = 25;
            sliderBase.ThumbImageURL = "*DemoRes*/images/FH3/9. Controller/controller_btn_slide_handler_normal.png";
            Window.Instance.Add(sliderBase);
            sliderBase.GestureEvent += OnGestureEventNUI;
            sliderBase.FocusGained += OnFocusGained;
            sliderBase.FocusLost += OnFocusLost;
        }

        private void CreateDADefault()
        {
            title2 = new TextLabel();
            title2.Size2D = new Size2D(150, 60);
            title2.Position2D = new Position2D(50, 200);
            title2.BackgroundColor = Color.Blue;
            title2.TextColor = Color.Yellow;
            title2.PointSize = 15;
            title2.HorizontalAlignment = HorizontalAlignment.Center;
            title2.VerticalAlignment = VerticalAlignment.Center;
            title2.Text = "DA Default";
            Window.Instance.Add(title2);

            sliderDA_Default = new DA.NUI.Controls.Slider("Default");
            sliderDA_Default.Position2D = new Position2D(250, 200);
            sliderDA_Default.Size2D = new Size2D(1370, 60);
            sliderDA_Default.BackgroundColor = new Color(255, 255, 0, 0.2f);
            sliderDA_Default.MinValue = 0;
            sliderDA_Default.MaxValue = 100;
            sliderDA_Default.CurrentValue = 50;
            Window.Instance.Add(sliderDA_Default);
            sliderDA_Default.GestureEvent += OnGestureEventDA;
        }

        private void CreateDA1Text()
        {
            title3 = new TextLabel();
            title3.Size2D = new Size2D(150, 60);
            title3.Position2D = new Position2D(50, 300);
            title3.BackgroundColor = Color.Blue;
            title3.TextColor = Color.Yellow;
            title3.PointSize = 15;
            title3.HorizontalAlignment = HorizontalAlignment.Center;
            title3.VerticalAlignment = VerticalAlignment.Center;
            title3.Text = "DA 1Text";
            Window.Instance.Add(title3);

            sliderDA_1SubText = new DA.NUI.Controls.Slider("1Text");
            sliderDA_1SubText.Position2D = new Position2D(250, 300);
            sliderDA_1SubText.Size2D = new Size2D(1370, 60);
            sliderDA_1SubText.BackgroundColor = new Color(255, 255, 0, 0.2f);
            sliderDA_1SubText.MinValue = 0;
            sliderDA_1SubText.MaxValue = 100;
            sliderDA_1SubText.CurrentValue = 75;
            sliderDA_1SubText.SubText = "subText";
            Window.Instance.Add(sliderDA_1SubText);
        }

        private void CreateDA2Text()
        {
            title4 = new TextLabel();
            title4.Size2D = new Size2D(150, 60);
            title4.Position2D = new Position2D(50, 450);
            title4.BackgroundColor = Color.Blue;
            title4.TextColor = Color.Yellow;
            title4.PointSize = 15;
            title4.HorizontalAlignment = HorizontalAlignment.Center;
            title4.VerticalAlignment = VerticalAlignment.Center;
            title4.Text = "DA 2Text";
            Window.Instance.Add(title4);

            sliderDA_2SubText = new DA.NUI.Controls.Slider("2Text");
            sliderDA_2SubText.Position2D = new Position2D(250, 450);
            sliderDA_2SubText.Size2D = new Size2D(1370, 60);
            sliderDA_2SubText.BackgroundColor = new Color(255, 255, 0, 0.2f);
            sliderDA_2SubText.MinValue = 0;
            sliderDA_2SubText.MaxValue = 100;
            sliderDA_2SubText.CurrentValue = 75;
            sliderDA_2SubText.LeftSubText = "left subText";
            sliderDA_2SubText.RightSubText = "right subText";
            Window.Instance.Add(sliderDA_2SubText);
        }

        private void CreateIndicator()
        {
            indicator = new TextLabel();
            indicator.Size2D = new Size2D(350, 60);
            indicator.Position2D = new Position2D(50, 30);
            indicator.PointSize = 15;
            indicator.BackgroundColor = new Color(238.0f / 255.0f, 183.0f / 255.0f, 79.0f / 255.0f, 255.0f / 255.0f);
            indicator.HorizontalAlignment = HorizontalAlignment.Begin;
            indicator.VerticalAlignment = VerticalAlignment.Center;
            Window.Instance.Add(indicator);
        }

        private NUI.Controls.Slider SliderInstance(int idx)
        {
            if (idx == 1)
            {
                return sliderBase;
            }
            else if (idx == 2)
            {
                return sliderDA_Default;
            }
            else if (idx == 3)
            {
                return sliderDA_1SubText;
            }
            else if (idx == COUNT)
            {
                return sliderDA_2SubText;
            }
            return null;
        }

        private string SliderName(int idx)
        {
            if (idx == 1)
            {
                return "NUI";
            }
            else if (idx == 2)
            {
                return "DA Default";
            }
            else if (idx == 3)
            {
                return "DA 1Text";
            }
            else if (idx == COUNT)
            {
                return "DA 2Text";
            }
            return string.Empty;
        }

        private void SetFocusToSlider(int idx)
        {
            FocusManager.Instance.SetCurrentFocusView(SliderInstance(idx));
            indicator.Text = SliderName(idx) + ", CurrentValue = " + SliderInstance(idx).CurrentValue.ToString();
        }

        private void ChangeCurValue(int idx, string keyNameStr)
        {
            if (keyNameStr == "Left")
            {
                if (SliderInstance(idx).CurrentValue > SliderInstance(idx).MinValue)
                {
                    SliderInstance(idx).CurrentValue--;
                }
                else
                {
                    SliderInstance(idx).CurrentValue = SliderInstance(idx).MaxValue;
                }
            }
            else if (keyNameStr == "Right")
            {
                if (SliderInstance(idx).CurrentValue < SliderInstance(idx).MaxValue)
                {
                    SliderInstance(idx).CurrentValue++;
                }
                else
                {
                    SliderInstance(idx).CurrentValue = SliderInstance(idx).MinValue;
                }
            }
            indicator.Text = SliderName(idx) + ", CurrentValue = " + SliderInstance(idx).CurrentValue.ToString();
        }

        private void ChangeThumbSize(int idx)
        {
            if (SliderInstance(idx).ThumbSize.Width == 60)
            {
                SliderInstance(idx).ThumbSize = new Size2D(80, 80);
            }
            else if (SliderInstance(idx).ThumbSize.Width == 80)
            {
                SliderInstance(idx).ThumbSize = new Size2D(40, 40);
            }
            else if (SliderInstance(idx).ThumbSize.Width == 40)
            {
                SliderInstance(idx).ThumbSize = new Size2D(60, 60);
            }
        }

        private void ChangeBarHeight(int idx)
        {
            if (SliderInstance(idx).BarHeight == 4)
            {
                SliderInstance(idx).BarHeight = 10;
            }
            else if (SliderInstance(idx).BarHeight == 10)
            {
                SliderInstance(idx).BarHeight = 4;
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
                else if (e.Key.KeyPressedName == "3")
                {
                    if (objIndex == 3)
                    {
                        if (sliderDA_1SubText.SubText.Length < 10)
                        {
                            sliderDA_1SubText.SubText = "subText1234564780";
                        }
                        else
                        {
                            sliderDA_1SubText.SubText = "subText";
                        }
                    }
                }
                else if (e.Key.KeyPressedName == "4")
                {
                    if (objIndex == 4)
                    {
                        if (sliderDA_2SubText.LeftSubText.Length < 15)
                        {
                            sliderDA_2SubText.LeftSubText = "left subText12345";
                            sliderDA_2SubText.RightSubText = "left subText12345";
                        }
                        else
                        {
                            sliderDA_2SubText.LeftSubText = "left subText";
                            sliderDA_2SubText.RightSubText = "right subText";
                        }
                    }
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
        Tizen.DA.NUI.Controls.Slider sliderDA_Default = null;
        Tizen.DA.NUI.Controls.Slider sliderDA_1SubText = null;
        Tizen.DA.NUI.Controls.Slider sliderDA_2SubText = null;
        TextLabel title1 = null;
        TextLabel title2 = null;
        TextLabel title3 = null;
        TextLabel title4 = null;
        TextLabel indicator = null;
        private int objIndex;
        private const int COUNT = 4;
    }
}
