using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;
using System;

namespace Tizen.NUI.Examples
{
    public class SliderSample : IExample
    {
        private TextLabel guideText;
        private TextLabel inforText;
        private Slider[] slider_sr;
        private DA.NUI.Controls.Slider[] slider_da;
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 100;
        private const int SR_COUNT = 2;
        private const int DA_COUNT = 16;
        private int index = 0;

        private static readonly string[] styleName = new string[8] {
            "UtilityDefaultSlider",
            "FoodDefaultSlider",
            "FamilyDefaultSlider",
            "KitchenDefaultSlider",
            "UtilityTextSlider",
            "FoodTextSlider",
            "FamilyTextSlider",
            "KitchenTextSlider" };
        
        public void Activate()
        {
            CreateGuideText();
            CreateInforText();
            CreateSR();
            CreateDA();
            Window.Instance.KeyEvent += OnWindowsKeyEvent;
        }

        private void CreateGuideText()
        {
            guideText = new TextLabel();
            guideText.Size2D = new Size2D(1000, 200);
            guideText.Position2D = new Position2D(20, 20);
            guideText.PointSize = 15;
            guideText.TextColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
            guideText.BackgroundColor = new Color(1.0f, 1.0f, 0, 0.8f);
            guideText.MultiLine = true;
            Window.Instance.Add(guideText);
            guideText.Text = 
                "Tips: \n" +
                "Press Up/Down to select item; \n" + 
                "Press Left/Right to change value of the selected item; \n" +
                "User can click on the slider track to change value; \n" +
                "User can drag the slider thumb to change value.";
        }

        private void CreateInforText()
        {
            inforText = new TextLabel();            
            inforText.Size2D = new Size2D(1000, 60);
            inforText.Position2D = new Position2D(20, 220);
            inforText.PointSize = 20;
            inforText.TextColor = NUI.Color.Blue;
            inforText.BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1.0f);
            inforText.HorizontalAlignment = HorizontalAlignment.Begin;
            inforText.VerticalAlignment = VerticalAlignment.Center;
            Window.Instance.Add(inforText);
        }

        private void CreateSR()
        {
            if (slider_sr == null)
            {
                slider_sr = new Slider[SR_COUNT];
            }
            slider_sr[0] = CreateSR("DefaultSlider", 50, 300, 1000, 50, 10, Slider.DirectionType.Horizontal);
            slider_sr[0].ThumbImageURL = "*DemoRes*/images/FH3/9. Controller/controller_btn_slide_handler_normal.png";
            slider_sr[0].LowIndicatorSize = new Size2D(42, 42);
            slider_sr[0].LowIndicatorImageURL = "*DemoRes*/images/FH3/9. Controller/picker_spin_btn_back.png";
            slider_sr[0].HighIndicatorSize = new Size2D(42, 42);
            slider_sr[0].HighIndicatorImageURL = "*DemoRes*/images/FH3/9. Controller/picker_spin_btn_next.png";

            slider_sr[1] = CreateSR("DefaultSlider", 1100, 50, 50, 1000, 10, Slider.DirectionType.Vertical);
            slider_sr[1].ThumbImageURL = "*DemoRes*/images/FH3/9. Controller/controller_btn_slide_handler_normal.png";
            slider_sr[1].LowIndicatorSize = new Size2D(42, 42);
            slider_sr[1].LowIndicatorImageURL = "*DemoRes*/images/FH3/8. SIP/support_ic_down.png";
            slider_sr[1].HighIndicatorSize = new Size2D(42, 42);
            slider_sr[1].HighIndicatorImageURL = "*DemoRes*/images/FH3/8. SIP/support_ic_up.png";

            slider_sr[index].BackgroundColor = new Color(0, 0.8f, 0, 0.3f);
            inforText.Text = "name = " + slider_sr[index].Name + ", currentValue = " + slider_sr[index].CurrentValue;
        }

        private Tizen.NUI.Controls.Slider CreateSR(string style, int posX, int posY, int w, int h, int curValue, Slider.DirectionType dir)
        {
            Tizen.NUI.Controls.Slider source = new Slider(style);
            source.Name = style;
            source.Direction = dir;
            Window.Instance.Add(source);
            source.Focusable = true;
            source.MinValue = MIN_VALUE;
            source.MaxValue = MAX_VALUE;
            source.StateChangedEvent += OnStateChanged;
            source.ValueChangedEvent += OnValueChanged;

            source.Position2D = new Position2D(posX, posY);
            source.Size2D = new Size2D(w, h);
            source.CurrentValue = curValue;
            return source;
        }

        private void CreateDA()
        {
            if (slider_da == null)
            {
                slider_da = new DA.NUI.Controls.Slider[DA_COUNT];
            }

            //
            slider_da[0] = CreateDA(styleName[0], 50, 350, 1000, 50, 20, Slider.DirectionType.Horizontal);
            slider_da[1] = CreateDA(styleName[0], 1150, 50, 50, 1000, 20, Slider.DirectionType.Vertical);

            //
            slider_da[2] = CreateDA(styleName[1], 50, 400, 1000, 50, 30, Slider.DirectionType.Horizontal);
            slider_da[3] = CreateDA(styleName[1], 1200, 50, 50, 1000, 30, Slider.DirectionType.Vertical);

            //
            slider_da[4] = CreateDA(styleName[2], 50, 450, 1000, 50, 40, Slider.DirectionType.Horizontal);
            slider_da[5] = CreateDA(styleName[2], 1250, 50, 50, 1000, 40, Slider.DirectionType.Vertical);

            //
            slider_da[6] = CreateDA(styleName[3], 50, 500, 1000, 50, 50, Slider.DirectionType.Horizontal);
            slider_da[7] = CreateDA(styleName[3], 1300, 50, 50, 1000, 50, Slider.DirectionType.Vertical);

            //
            slider_da[8] = CreateDA(styleName[4], 50, 550, 1000, 50, 60, Slider.DirectionType.Horizontal);
            slider_da[8].LowIndicatorTextStr = "SubText";
            slider_da[8].LowIndicatorSize = new Size2D(100, 40);
          
            slider_da[9] = CreateDA(styleName[4], 1400, 50, 50, 1000, 60, Slider.DirectionType.Vertical);
            slider_da[9].LowIndicatorTextStr = "SubText";
            slider_da[9].LowIndicatorSize = new Size2D(100, 40);

            //
            slider_da[10] = CreateDA(styleName[5], 50, 600, 1000, 50, 70, Slider.DirectionType.Horizontal);
            slider_da[10].LowIndicatorTextStr = "SubText";
            slider_da[10].LowIndicatorSize = new Size2D(100, 40);

            slider_da[11] = CreateDA(styleName[5], 1500, 50, 50, 1000, 70, Slider.DirectionType.Vertical);
            slider_da[11].LowIndicatorTextStr = "SubText";
            slider_da[11].LowIndicatorSize = new Size2D(100, 40);

            //
            slider_da[12] = CreateDA(styleName[6], 50, 650, 1000, 50, 80, Slider.DirectionType.Horizontal);
            slider_da[12].LowIndicatorTextStr = "SubText";
            slider_da[12].LowIndicatorSize = new Size2D(100, 40);

            slider_da[13] = CreateDA(styleName[6], 1600, 50, 50, 1000, 80, Slider.DirectionType.Vertical);
            slider_da[13].LowIndicatorTextStr = "SubText";
            slider_da[13].LowIndicatorSize = new Size2D(100, 40);

            //
            slider_da[14] = CreateDA(styleName[7], 50, 700, 1000, 50, 90, Slider.DirectionType.Horizontal);
            slider_da[14].LowIndicatorTextStr = "SubText";
            slider_da[14].LowIndicatorSize = new Size2D(100, 40);

            slider_da[15] = CreateDA(styleName[7], 1700, 50, 50, 1000, 90, Slider.DirectionType.Vertical);
            slider_da[15].LowIndicatorTextStr = "SubText";
            slider_da[15].LowIndicatorSize = new Size2D(100, 40);
        }

        private Tizen.DA.NUI.Controls.Slider CreateDA(string style, int posX, int posY, int w, int h, int curValue, Slider.DirectionType dir)
        {
            Tizen.DA.NUI.Controls.Slider source = new DA.NUI.Controls.Slider(style);
            source.Name = style;
            source.Direction = dir;
            Window.Instance.Add(source);
            source.Focusable = true;
            source.MinValue = MIN_VALUE;
            source.MaxValue = MAX_VALUE;
            source.StateChangedEvent += OnStateChanged;
            source.ValueChangedEvent += OnValueChanged;

            source.Position2D = new Position2D(posX, posY);
            source.Size2D = new Size2D(w, h);
            source.CurrentValue = curValue;
            return source;
        }

        private void OnWindowsKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Left")
                {
                    if (index < SR_COUNT)
                    {
                        if (slider_sr[index].CurrentValue > slider_sr[index].MinValue)
                        {
                            slider_sr[index].CurrentValue--;
                        }
                        else
                        {
                            slider_sr[index].CurrentValue = slider_sr[index].MaxValue;
                        }
                        inforText.Text = "name = " + slider_sr[index].Name + ", currentValue = " + slider_sr[index].CurrentValue;
                    }
                    else
                    {
                        if (slider_da[index - SR_COUNT].CurrentValue > slider_da[index - SR_COUNT].MinValue)
                        {
                            slider_da[index - SR_COUNT].CurrentValue--;
                        }
                        else
                        {
                            slider_da[index - SR_COUNT].CurrentValue = slider_da[index - SR_COUNT].MaxValue;
                        }
                        inforText.Text = "name = " + slider_da[index - SR_COUNT].Name + ", currentValue = " + slider_da[index - SR_COUNT].CurrentValue;
                    }
                }
                else if (e.Key.KeyPressedName == "Right")
                {
                    if (index < SR_COUNT)
                    {
                        if (slider_sr[index].CurrentValue < slider_sr[index].MaxValue)
                        {
                            slider_sr[index].CurrentValue++;
                        }
                        else
                        {
                            slider_sr[index].CurrentValue = slider_sr[index].MinValue;
                        }
                        inforText.Text = "name = " + slider_sr[index].Name + ", currentValue = " + slider_sr[index].CurrentValue;
                    }
                    else
                    {
                        if (slider_da[index - SR_COUNT].CurrentValue < slider_da[index - SR_COUNT].MaxValue)
                        {
                            slider_da[index - SR_COUNT].CurrentValue++;
                        }
                        else
                        {
                            slider_da[index - SR_COUNT].CurrentValue = slider_da[index - SR_COUNT].MinValue;
                        }
                        inforText.Text = "name = " + slider_da[index - SR_COUNT].Name + ", currentValue = " + slider_da[index - SR_COUNT].CurrentValue;
                    }
                }
                else if (e.Key.KeyPressedName == "Up")
                {
                    if (index < SR_COUNT)
                    {
                        slider_sr[index].BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0);
                    }
                    else
                    {
                        slider_da[index - SR_COUNT].BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0);
                    }

                    if (index > 0)
                    {
                        index--;
                    }
                    else
                    {
                        index = SR_COUNT +  DA_COUNT - 1;
                    }

                    if (index < SR_COUNT)
                    {
                        slider_sr[index].BackgroundColor = new Color(0, 0.8f, 0, 0.3f);
                        inforText.Text = "name = " + slider_sr[index].Name + ", currentValue = " + slider_sr[index].CurrentValue;
                    }
                    else
                    {
                        slider_da[index - SR_COUNT].BackgroundColor = new Color(0, 0.8f, 0, 0.3f);
                        inforText.Text = "name = " + slider_da[index - SR_COUNT].Name + ", currentValue = " + slider_da[index - SR_COUNT].CurrentValue;
                    }
                }
                else if (e.Key.KeyPressedName == "Down")
                {
                    if (index < SR_COUNT)
                    {
                        slider_sr[index].BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0);
                    }
                    else
                    {
                        slider_da[index - SR_COUNT].BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0);
                    }

                    if (index < SR_COUNT + DA_COUNT - 1)
                    {
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }

                    if (index < SR_COUNT)
                    {
                        slider_sr[index].BackgroundColor = new Color(0, 0.8f, 0, 0.3f);
                        inforText.Text = "name = " + slider_sr[index].Name + ", currentValue = " + slider_sr[index].CurrentValue;
                    }
                    else
                    {
                        slider_da[index - SR_COUNT].BackgroundColor = new Color(0, 0.8f, 0, 0.3f);
                        inforText.Text = "name = " + slider_da[index - SR_COUNT].Name + ", currentValue = " + slider_da[index - SR_COUNT].CurrentValue;
                    }
                }
                
            }
        }

        public void Deactivate()
        {
            Window window = Window.Instance;
            window.KeyEvent -= OnWindowsKeyEvent;

            if (guideText != null)
            {
                window.Remove(guideText);
                guideText.Dispose();
                guideText = null;
            }

            if (inforText != null)
            {
                window.Remove(inforText);
                inforText.Dispose();
                inforText = null;
            }

            DestroySR();
            DestroyDA();
        }

        private void DestroySR()
        {
            if (slider_sr != null)
            {
                for (int i = 0; i < SR_COUNT; ++i)
                {
                    if (slider_sr[i] != null)
                    {
                        slider_sr[i].StateChangedEvent -= OnStateChanged;
                        slider_sr[i].ValueChangedEvent -= OnValueChanged;
                        Window.Instance.Remove(slider_sr[i]);
                        slider_sr[i].Dispose();
                        slider_sr[i] = null;
                    }
                }
                slider_sr = null;
            }
        }

        private void DestroyDA()
        {
            if (slider_da != null)
            {
                for (int i = 0; i < DA_COUNT; ++i)
                {
                    if (slider_da[i] != null)
                    {
                        slider_da[i].StateChangedEvent -= OnStateChanged;
                        slider_da[i].ValueChangedEvent -= OnValueChanged;
                        Window.Instance.Remove(slider_da[i]);
                        slider_da[i].Dispose();
                        slider_da[i] = null;
                    }
                }
                slider_da = null;
            }
        }

        private void OnValueChanged(object sender, NUI.Controls.Slider.ValueChangedArgs args)
        {
            Console.WriteLine("args.CurrentValue = " + args.CurrentValue);
            if (sender is Tizen.NUI.Controls.Slider)
            {
                Tizen.NUI.Controls.Slider slider = sender as Tizen.NUI.Controls.Slider;
                if (slider != null)
                {
                    inforText.Text = "name = " + slider.Name + ", currentValue = " + args.CurrentValue;
                }
            }
            else if (sender is Tizen.DA.NUI.Controls.Slider)
            {
                Tizen.DA.NUI.Controls.Slider slider = sender as Tizen.DA.NUI.Controls.Slider;
                if (slider != null)
                {
                    inforText.Text = "name = " + slider.Name + ", currentValue = " + args.CurrentValue;
                }
            }
        }

        private void OnStateChanged(object sender, NUI.Controls.Slider.StateChangedArgs args)
        {
            Console.WriteLine("args.CurrentState = " + args.CurrentState);
            if (sender is Tizen.NUI.Controls.Slider)
            {
                Tizen.NUI.Controls.Slider slider = sender as Tizen.NUI.Controls.Slider;
                if (slider != null)
                {
                    //if (args.CurrentState == States.Normal)
                    //{
                    //    slider_sr[0].ThumbImageURL = "*DemoRes*/images/FH3/9. Controller/controller_btn_slide_handler_normal.png";
                    //}
                    //else if (args.CurrentState == States.Focused || args.CurrentState == States.Pressed)
                    //{
                    //    slider_sr[0].ThumbImageURL = "*DemoRes*/images/FH3/9. Controller/controller_btn_slide_handler_press.png";
                    //}
                }
            }
        }
    }
}
