using System;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Controls
{
    public class TimePicker : Control
    {
        private ImageView backgroundImage;
        private ImageView shadowImage;
        private ImageView colonImage;
        private ImageView colonImage2;
        
        private FHSpin hourSpin;
        private FHSpin minuteSpin;
        private FHSpin secondSpin;
        private FHSpin AMPMSpin;

        private View weekView;
        private TextLabel titleText;
        private ImageView[] weekSelectImage;
        private TextLabel[] weekText;
        private TextLabel weekTitleText;
        private bool[] selected;

        DateTime curTime;
       
        private TimePickerAttributes timePickerAttributes;

        public DateTime CurTime
        {
            get
            {
                return curTime;
            }
            set
            {
                curTime = value;
            }
        }

        public TimePicker() : base()
        {
            Initialize();
        }
        public TimePicker(string style) : base(style)
        {
            Initialize();
        }
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (backgroundImage != null)
                {
                    Remove(backgroundImage);
                    backgroundImage.Dispose();
                    backgroundImage = null;
                }
                if (shadowImage != null)
                {
                    Remove(shadowImage);
                    shadowImage.Dispose();
                    shadowImage = null;
                }
                if (colonImage != null)
                {
                    Remove(colonImage);
                    colonImage.Dispose();
                    colonImage = null;
                }
                if (colonImage2 != null)
                {
                    Remove(colonImage2);
                    colonImage2.Dispose();
                    colonImage2 = null;
                }
                if (hourSpin != null)
                {
                    Remove(hourSpin);
                    hourSpin.Dispose();
                    hourSpin = null;
                }
                if (minuteSpin != null)
                {
                    Remove(minuteSpin);
                    minuteSpin.Dispose();
                    minuteSpin = null;
                }
                if (secondSpin != null)
                {
                    Remove(secondSpin);
                    secondSpin.Dispose();
                    secondSpin = null;
                }
                if (AMPMSpin != null)
                {
                    Remove(AMPMSpin);
                    AMPMSpin.Dispose();
                    AMPMSpin = null;
                }

                if (titleText != null)
                {
                    Remove(titleText);
                    titleText.Dispose();
                    titleText = null;
                }
                
                if (weekView != null)
                {
                    if (weekTitleText != null)
                    {
                        weekView.Remove(weekTitleText);
                        weekTitleText.Dispose();
                        weekTitleText = null;
                    }
                    if (weekSelectImage != null)
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            weekView.Remove(weekSelectImage[i]);
                            weekSelectImage[i].Dispose();
                            weekSelectImage[i] = null;
                        }
                    }
                    if (weekText!= null)
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            weekText[i].TouchEvent -= OnRepeatTextTouchEvent;
                            weekView.Remove(weekText[i]);
                            weekText[i].Dispose();
                            weekText[i] = null;
                        }
                    }
                    Remove(weekView);
                    weekView.Dispose();
                    weekView = null;
                }
            }

            base.Dispose(type);
        }
        
        protected override bool OnKey(object source, KeyEventArgs e)
        {
            return base.OnKey(source, e);
        }   
        protected override void OnFocusGained(object sender, EventArgs e)
        {
            base.OnFocusGained(sender, e);

        }
        protected override void OnFocusLost(object sender, EventArgs e)
        {
            base.OnFocusLost(sender, e);
        }

        protected override Attributes GetAttributes()
        {
            return null;
        }

        protected override void OnUpdate(Attributes attributtes)
        {
            timePickerAttributes = attributes as TimePickerAttributes;
            if (timePickerAttributes == null)
            {
                return;
            }

            ApplyAttributes(this, timePickerAttributes);            
            ApplyAttributes(shadowImage, timePickerAttributes.ShadowImageAttributes);
            ApplyAttributes(backgroundImage, timePickerAttributes.BackgroundImageAttributes);          
            ApplyAttributes(hourSpin, timePickerAttributes.HourSpinAttributes);
            ApplyAttributes(minuteSpin, timePickerAttributes.MinuteSpinAttributes);
            ApplyAttributes(secondSpin, timePickerAttributes.SecondSpinAttributes);
            ApplyAttributes(colonImage, timePickerAttributes.ColonImageAttributes);
            ApplyAttributes(colonImage2, timePickerAttributes.ColonImageAttributes);
            ApplyAttributes(AMPMSpin, timePickerAttributes.AMPMSpinAttributes);
            ApplyAttributes(titleText, timePickerAttributes.TitleTextAttributes);

            if (weekView != null)
            {
                ApplyAttributes(weekView, timePickerAttributes.WeekViewAttributes);
                for (int i = 0; i < 7; i++)
                {
                    ApplyAttributes(weekSelectImage[i], timePickerAttributes.WeekSelectImageAttributes);
                    ApplyAttributes(weekText[i], timePickerAttributes.WeekTextAttributes);
                }
                ApplyAttributes(weekTitleText, timePickerAttributes.WeekTitleTextAttributes);
            }
            int w = 0;
            int h = 0;
            if (shadowImage != null)
            {
                w = (int)(Size2D.Width + timePickerAttributes.ShadowOffset.W + timePickerAttributes.ShadowOffset.X);
                h = (int)(Size2D.Height + timePickerAttributes.ShadowOffset.Y + timePickerAttributes.ShadowOffset.Z);
                shadowImage.Size2D = new Size2D(w, h);
            }

            int x = 0;
            int y = 0;
            if (secondSpin != null)
            {
                x = minuteSpin.Position2D.X + minuteSpin.Size2D.Width + (minuteSpin.Position2D.X - hourSpin.Position2D.X - hourSpin.Size2D.Width - colonImage.Size2D.Width)/2;
                colonImage2.Position2D = new Position2D(x, colonImage2.Position2D.Y);
            }

            x = hourSpin.Position2D.X + hourSpin.Size2D.Width + (minuteSpin.Position2D.X - hourSpin.Position2D.X - hourSpin.Size2D.Width - colonImage.Size2D.Width)/2;
            colonImage.Position2D = new Position2D(x, colonImage.Position2D.Y);

            if (weekView != null)
            {
                if ((weekText != null) && (weekSelectImage != null))
                {
                    for (int i = 0; i < 7; i++)
                    {
                        weekText[i].Position2D = new Position2D(i * weekText[i].Size2D.Width, weekText[i].Position2D.Y);
                        weekSelectImage[i].Position2D = new Position2D(i * weekText[i].Size2D.Width + (weekText[i].Size2D.Width -weekSelectImage[i].Size2D.Width)/2, weekSelectImage[i].Position2D.Y);
                    }
                    weekText[0].Text = "Sun";
                    weekText[0].TextColor = Color.Red;
                    weekText[1].Text = "Mon";
                    weekText[2].Text = "Tue";
                    weekText[3].Text = "Wen";
                    weekText[4].Text = "Thu";
                    weekText[5].Text = "Fri";
                    weekText[6].Text = "Sat";
                }
                
            }
            if (AMPMSpin != null)
            {
                hourSpin.Max = 11;
                hourSpin.Min = 0;

                AMPMSpin.Max = 1;
                AMPMSpin.Min = 0;
            }
            else
            {
                hourSpin.Max = 23;
                hourSpin.Min = 0;
            }
            if (minuteSpin !=null)
            {
                minuteSpin.Max = 59;
                minuteSpin.Min = 0;
            }
            if (secondSpin !=null)
            {
                secondSpin.Max = 59;
                secondSpin.Min = 0;
            }
        }

        private void Initialize()
        {
            timePickerAttributes = attributes as TimePickerAttributes;
            if (timePickerAttributes == null)
            {
                throw new Exception("Picker attribute parse error.");
            }

            StateFocusableOnTouchMode = true;
            LeaveRequired = true;
            curTime = DateTime.Now;

            if (timePickerAttributes.ShadowImageAttributes != null)
            {
                shadowImage = new ImageView();
                Add(shadowImage);
            }

            if (timePickerAttributes.BackgroundImageAttributes != null)
            {
                backgroundImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
                Add(backgroundImage);
            }

            if (timePickerAttributes.ColonImageAttributes != null)
            {
                colonImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
                Add(colonImage);
            }

            if (timePickerAttributes.HourSpinAttributes != null)
            {
                hourSpin = new FHSpin("DASpin");
                hourSpin.NameText = "Hours";
                if (timePickerAttributes.AMPMSpinAttributes != null)
                {
                    hourSpin.CurValue = curTime.Hour%12;
                    Add(hourSpin);
                }
                else
                {
                    hourSpin.CurValue = curTime.Hour%24;
                    Add(hourSpin);
                }
            }

            if (timePickerAttributes.MinuteSpinAttributes != null)
            {
                minuteSpin = new FHSpin("DASpin");
                minuteSpin.NameText = "Minutes";
                minuteSpin.CurValue = curTime.Minute;
                Add(minuteSpin);
            }

            if (timePickerAttributes.SecondSpinAttributes != null)
            {
                secondSpin = new FHSpin("DASpin");
                secondSpin.NameText = "Seconds";
                secondSpin.CurValue = curTime.Second;
                Add(secondSpin);

                if (timePickerAttributes.ColonImageAttributes != null)
                {
                    colonImage2 = new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent
                    };
                    Add(colonImage2);
                }
            }

            if (timePickerAttributes.AMPMSpinAttributes != null)
            {
                AMPMSpin = new FHSpin("DAStrSpin");
                AMPMSpin.CurValue = curTime.Hour/12;
                Add(AMPMSpin);
            }

            if (timePickerAttributes.TitleTextAttributes != null)
            {
                titleText= new TextLabel();
                Add(titleText);
            }
            
            if (timePickerAttributes.WeekViewAttributes != null)
            {
                weekView = new View();
                Add(weekView);

                if (timePickerAttributes.WeekSelectImageAttributes != null)
                {
                    weekSelectImage = new ImageView[7];
                    selected = new bool[7];        
                    for (int i = 0; i < 7; i++)
                    {
                        weekSelectImage[i] = new ImageView()
                        {
                            WidthResizePolicy = ResizePolicyType.FillToParent,
                            HeightResizePolicy = ResizePolicyType.FillToParent
                        };
                        weekSelectImage[i].Hide();
                        weekView.Add(weekSelectImage[i]);

                        selected[i] = false;
                    }                
                }

                if (timePickerAttributes.WeekTextAttributes != null)
                {
                    weekText = new TextLabel[7];
                    for (int i = 0; i < 7; i++)
                    {
                        weekText[i] = new TextLabel();

                        weekText[i].TouchEvent += OnRepeatTextTouchEvent;
                        weekView.Add(weekText[i]);
                    }
                }

                if (timePickerAttributes.WeekTitleTextAttributes != null)
                {
                    weekTitleText = new TextLabel();
                    weekView.Add(weekTitleText);
                }
            }
        }

        private bool OnRepeatTextTouchEvent(object source, View.TouchEventArgs e)
        {
            TextLabel textLabel = source as TextLabel;
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                int i = 0;
                for (i = 0; i < 7; i++)
                {
                    if (weekText[i] == textLabel)
                    {
                        break;
                    }
                }
                if (selected[i] == false)
                {
                    selected[i] = true;
                    weekSelectImage[i].Show();
                }
                else
                {
                    selected[i] = false;
                    weekSelectImage[i].Hide();
                }
            }
            
            return false;
        }
    }    
}

