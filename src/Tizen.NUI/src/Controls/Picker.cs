using System;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using System.Globalization;

namespace Tizen.NUI.Controls
{
    public class Picker : Control
    {
        private ImageView backgroundImage;
        private ImageView shadowImage;
        private ImageView focusImage;
        private ImageView endSelectedImage;

        private View dateView;
        private TextLabel sunText;
        private TextLabel monText;
        private TextLabel tueText;
        private TextLabel wenText;
        private TextLabel thuText;
        private TextLabel friText;
        private TextLabel satText;
        private TextLabel[,] dateTable;

        private ImageView leftArrowImage;
        private ImageView rightArrowImage;
        private TextLabel monthText;
        private DropDown dropDown;

        private DateTime showDate;
        private DateTime curDate;
        private TextLabel preTouch;

        private DataArgs data;
        
        private PickerAttributes pickerAttributes;

        public Picker() : base()
        {
            Initialize();
        }
        public Picker(string style) : base(style)
        {
            Initialize();
        }

        public DateTime CurDate
        {
            get
            {
                return curDate;
            }
            set
            {
                curDate = value;
                showDate = curDate;
            }
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
                
                if (leftArrowImage != null)
                {
                    Remove(leftArrowImage);
                    leftArrowImage.Dispose();
                    leftArrowImage = null;
                }
                if (rightArrowImage != null)
                {
                    Remove(rightArrowImage);
                    rightArrowImage.Dispose();
                    rightArrowImage = null;
                }
                if (dropDown != null)
                {
                    Remove(dropDown);
                    dropDown.Dispose();
                    dropDown = null;
                }
                if (monthText != null)
                {
                    Remove(monthText);
                    monthText.Dispose();
                    monthText = null;
                }
                if (dropDown != null)
                {
                    dropDown.ItemClickEvent -= DropDownItemClickEvent;
                    Remove(dropDown);
                    dropDown.Dispose();
                    dropDown = null;
                }

                if (dateView != null)
                {
                    if (focusImage != null)
                    {
                        dateView.Remove(focusImage);
                        focusImage.Dispose();
                        focusImage = null;
                    }
                    if (endSelectedImage != null)
                    {
                        dateView.Remove(endSelectedImage);
                        endSelectedImage.Dispose();
                        endSelectedImage = null;
                    }
                    if (sunText != null)
                    {
                        dateView.Remove(sunText);
                        sunText.Dispose();
                        sunText = null;
                    }
                    
                    if (monText != null)
                    {
                        dateView.Remove(monText);
                        monText.Dispose();
                        monText = null;
                    }
                    
                    if (tueText != null)
                    {
                        dateView.Remove(tueText);
                        tueText.Dispose();
                        tueText = null;
                    }

                    if (wenText != null)
                    {
                        dateView.Remove(wenText);
                        wenText.Dispose();
                        wenText = null;
                    }

                    if (thuText != null)
                    {
                        dateView.Remove(thuText);
                        thuText.Dispose();
                        thuText = null;
                    }

                    if (friText != null)
                    {
                        dateView.Remove(friText);
                        friText.Dispose();
                        friText = null;
                    }

                    if (satText != null)
                    {
                        dateView.Remove(satText);
                        satText.Dispose();
                        satText = null;
                    }

                    for (int i = 0; i < 6; i++)
                    {
                        for(int j = 0; j < 7; j++)
                        {
                            if (dateTable[i,j] != null)
                            {
                                dateView.Remove(dateTable[i,j]);
                                dateTable[i,j].Dispose();
                                dateTable[i,j] = null;
                            }
                        }
                    }
                        
                    Remove(dateView);
                    dateView.Dispose();
                    dateView = null;
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
            pickerAttributes = attributes as PickerAttributes;
            if (pickerAttributes == null)
            {
                return;
            }

            ApplyAttributes(this, pickerAttributes);            
            ApplyAttributes(shadowImage, pickerAttributes.ShadowImageAttributes);
            ApplyAttributes(backgroundImage, pickerAttributes.BackgroundImageAttributes);          
            ApplyAttributes(dateView, pickerAttributes.DateViewAttributes);
            ApplyAttributes(sunText, pickerAttributes.SunTextAttributes);
            ApplyAttributes(monText, pickerAttributes.MonTextAttributes);
            ApplyAttributes(tueText, pickerAttributes.TueTextAttributes);
            ApplyAttributes(wenText, pickerAttributes.WenTextAttributes);
            ApplyAttributes(thuText, pickerAttributes.ThuTextAttributes);
            ApplyAttributes(friText, pickerAttributes.FriTextAttributes);
            ApplyAttributes(satText, pickerAttributes.SatTextAttributes);
            
            ApplyAttributes(monthText, pickerAttributes.MonthTextAttributes);
            ApplyAttributes(leftArrowImage, pickerAttributes.LeftArrowImageAttributes);
            ApplyAttributes(rightArrowImage, pickerAttributes.RightArrowImageAttributes);

            if (pickerAttributes.DropDownAttrs != null)
            {
                dropDown = new DropDown(pickerAttributes.DropDownAttrs);  
                dropDown.ItemClickEvent += DropDownItemClickEvent;
                Add(dropDown);
            }
            
            if (pickerAttributes.DropDownItemAttrs != null)
            {
                int value = showDate.Year;
                for (int i = 0; i < 50; i++)
                {
                    DropDown.DropDownItemData item = new DropDown.DropDownItemData(pickerAttributes.DropDownItemAttrs);
                    item.Text = (value + i).ToString();
                    dropDown.AddItem(item);
                }
   
            }

            ApplyAttributes(focusImage, pickerAttributes.FocusImageAttributes);
            ApplyAttributes(endSelectedImage, pickerAttributes.EndSelectedImageAttributes);

            for (int i = 0; i < 6; i++)
            { 
                for (int j = 0; j < 7; j++)
                {
                    if (j%2 == 0)
                    {
                        ApplyAttributes(dateTable[i,j], pickerAttributes.DateTextAttributes);
                    }
                    else
                    {
                        ApplyAttributes(dateTable[i,j], pickerAttributes.DateTextAttributes2);
                    }
                }
            }
                        
            int tableX = 0;
            int tableY = sunText.Size2D.Height;
            int tableW = dateTable[0,0].Size2D.Width;
            int tableH = dateTable[0,0].Size2D.Height;
            for (int i = 0; i < 6; i++)
            { 
                tableX = 0;
                for (int j = 0; j < 7; j++)
                {
                    dateTable[i,j].Position2D = new Position2D(tableX, tableY );
                    if (j%2 == 0)
                    {
                        tableW = dateTable[0,0].Size2D.Width; 
                    }
                    else
                    {
                        tableW = dateTable[0,1].Size2D.Width; 
                    }
                    tableX += tableW;
                }
                tableY += tableH;
            }

            UpdateDate();
        }

        private void Initialize()
        {
            pickerAttributes = attributes as PickerAttributes;
            if (pickerAttributes == null)
            {
                throw new Exception("Picker attribute parse error.");
            }

            StateFocusableOnTouchMode = true;
            LeaveRequired = true;

            if (pickerAttributes.ShadowImageAttributes != null)
            {
                shadowImage = new ImageView();
                Add(shadowImage);
            }

            if (pickerAttributes.BackgroundImageAttributes != null)
            {
                backgroundImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
                Add(backgroundImage);
            }

            if (pickerAttributes.LeftArrowImageAttributes != null)
            {
                leftArrowImage = new ImageView()
                {
                  WidthResizePolicy = ResizePolicyType.FillToParent,
                  HeightResizePolicy = ResizePolicyType.FillToParent
                };
                leftArrowImage.TouchEvent += PreMonth_TouchEvent;
                Add(leftArrowImage);
            }

            if (pickerAttributes.RightArrowImageAttributes != null)
            {
                rightArrowImage = new ImageView()
                {
                  WidthResizePolicy = ResizePolicyType.FillToParent,
                  HeightResizePolicy = ResizePolicyType.FillToParent
                };

                rightArrowImage.TouchEvent += NextMonth_TouchEvent;
                Add(rightArrowImage);
            }

            if (pickerAttributes.MonthTextAttributes != null)
            {
                monthText = new TextLabel();
                Add(monthText);
            }

            if (pickerAttributes.DropDownAttrs != null)
            {
                //dropDown = new DropDown();
                //Add(dropDown);
            }

            if (pickerAttributes.DateViewAttributes != null)
            {
                dateView = new View();
                Add(dateView);
                
                if (pickerAttributes.FocusImageAttributes != null)
                {
                    focusImage = new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent
                    };
                    focusImage.Hide();
                    dateView.Add(focusImage);
                }

                if (pickerAttributes.EndSelectedImageAttributes != null)
                {
                    endSelectedImage= new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent
                    };
                    endSelectedImage.Hide();
                    dateView.Add(endSelectedImage);
                }
                
                if (pickerAttributes.SunTextAttributes != null)
                {
                    sunText = new TextLabel();
                    sunText.Focusable = true;
                    sunText.KeyEvent += Date_KeyEvent;
                    dateView.Add(sunText);
                }
                
                if (pickerAttributes.MonTextAttributes != null)
                {
                    monText= new TextLabel();
                    monText.Focusable = true;
                    monText.KeyEvent += Date_KeyEvent;
                    dateView.Add(monText);
                }
                if (pickerAttributes.TueTextAttributes != null)
                {
                    tueText= new TextLabel();
                    tueText.Focusable = true;
                    tueText.KeyEvent += Date_KeyEvent;
                    dateView.Add(tueText);
                }

                if (pickerAttributes.WenTextAttributes != null)
                {
                    wenText= new TextLabel();
                    wenText.Focusable = true;
                    wenText.KeyEvent += Date_KeyEvent;
                    dateView.Add(wenText);
                }

                if (pickerAttributes.ThuTextAttributes != null)
                {
                    thuText= new TextLabel();
                    thuText.Focusable = true;
                    thuText.KeyEvent += Date_KeyEvent;
                    dateView.Add(thuText);
                }

                if (pickerAttributes.FriTextAttributes != null)
                {
                    friText= new TextLabel();
                    friText.Focusable = true;
                    friText.KeyEvent += Date_KeyEvent;
                    dateView.Add(friText);
                }

                if (pickerAttributes.SatTextAttributes != null)
                {
                    satText= new TextLabel();
                    satText.Focusable = true;
                    satText.KeyEvent += Date_KeyEvent;
                    dateView.Add(satText);
                }

                dateTable = new TextLabel[6,7];
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        dateTable[i,j] = new TextLabel();
                        dateTable[i,j].Focusable = true;
                        dateTable[i,j].KeyEvent += Date_KeyEvent;
                        dateTable[i,j].TouchEvent += Date_TouchEvent;
                        dateView.Add(dateTable[i,j]);
                    }
                }
                
                data = new DataArgs();
                showDate = DateTime.Now;
                curDate = showDate;                
            }
            
        }

        private bool Date_KeyEvent(object source, View.KeyEventArgs e)
        {
            TextLabel textLabel = source as TextLabel;

            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Return")
                {
                    return true;
                }
            }
            return false;
        }

        private void DropDownItemClickEvent(object sender, DropDown.ItemClickEventArgs e)
        {
            int year = 0;
            if (int.TryParse(e.Text, out year))
            {
                if (year == showDate.Year)
                {
                    return;
                }
                
                int month = showDate.Month;
                if (month == curDate.Month && year == curDate.Year)
                {
                    showDate = new DateTime(curDate.Year, curDate.Month ,curDate.Day);
                }
                else
                {
                    showDate = new DateTime(year, month ,1);
                }
                UpdateDate();
            }
        }
        
        private bool NextMonth_TouchEvent(object source, View.TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                int month = (showDate.Month == 12)? 1 : showDate.Month + 1;
                int year = (showDate.Month == 12)? showDate.Year + 1 : showDate.Year;
                if (month == curDate.Month && year == curDate.Year)
                {
                    showDate = new DateTime(curDate.Year, curDate.Month ,curDate.Day);
                }
                else
                {
                    showDate = new DateTime(year, month ,1);
                }
                UpdateDate();
            }        
            return false;
        }
        
        private bool PreMonth_TouchEvent(object source, View.TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                int month = (showDate.Month == 1)? 12 : showDate.Month - 1;
                int year = (showDate.Month == 1)? showDate.Year - 1 : showDate.Year;
                if (month == curDate.Month && year == curDate.Year)
                {
                    showDate = new DateTime(curDate.Year, curDate.Month ,curDate.Day);
                }
                else
                {
                    showDate = new DateTime(year, month ,1);
                }
                UpdateDate();
            }
            return false;
        }

        private bool Date_TouchEvent(object source, View.TouchEventArgs e)
        {
            TextLabel textLabel = source as TextLabel;

            
            int line = (textLabel.Position2D.Y - dateTable[0, 0].Position2D.Y)/dateTable[0, 0].Size2D.Height;
            int i = 0;
            for (i = 0; i < 7; i++)
            {
                if (dateTable[line, i].Position2D.X == textLabel.Position2D.X)
                {
                     break;
                }
            }

            int index = line * 7 + i;
            if (index < data.prenum || index >= (42 - data.nextnum))
            {
                return false;
            }

            if (preTouch != null)
            {
                int X = preTouch.Position2D.X;
                if (X == 0)
                {
                    preTouch.TextColor = Color.Red;
                }
                else
                {
                    preTouch.TextColor = Color.Black;
                }
            }
            int focusX = textLabel.Position2D.X + (textLabel.Size2D.Width - focusImage.Size2D.Width)/2;
            int focusY = textLabel.Position2D.Y + (textLabel.Size2D.Height - focusImage.Size2D.Height)/2;;
            focusImage.Position2D = new Position2D(focusX, focusY);
            focusImage.Show();
            
            textLabel.TextColor = Color.White;
            preTouch = textLabel;
            return false; ;
        }
        
        private void UpdateDate()
        {
            DateTime dateTime = new DateTime(showDate.Year, showDate.Month, 1);
            int weekStart = Convert.ToInt32(dateTime.DayOfWeek);
            int days = DateTime.DaysInMonth(showDate.Year, showDate.Month); 

            int lines = ((days + weekStart)%7 == 0)? (days + weekStart)/7 : ((days + weekStart)/7 +1);
            dateView.Size2D = new Size2D(dateView.Size2D.Width, dateTable[0,0].Size2D.Height*(lines+1));

            data.curnum = days;
            data.prenum = weekStart;
            data.nextnum = 42-weekStart-days;

            int[] value = new int[42];
            int idx = 0;
            for (int i = 0; i< data.prenum; i++)
            {
                value[idx++] = 0xFF;
            }
            
            int t = 1;
            for(int i = 0; i< data.curnum; i++)
            {
                value[idx++] = t++;
            }
            
            for (int i = 0; i< data.nextnum; i++)
            {
                value[idx++] = 0xFF;
            }

            for (int i = 0; i < 42; i++)
            {
                int x = i/7;
                int y = i%7;
                if (value[i] != 0xFF)
                {
                    dateTable[x,y].Text = value[i].ToString();
                }
                else
                {
                    dateTable[x,y].Text = " ";
                }
            }

            for (int i = data.prenum; i< data.prenum+data.curnum; i++)
            {
                int x = i/7;
                int y = i%7;
                if(y == 0)
                {
                    dateTable[x,y].TextColor = Color.Red;
                }
                else
                {
                    dateTable[x,y].TextColor = Color.Black;
                }
            }

            int focusidx = data.prenum + showDate.Day - 1;
            dateTable[focusidx/7,focusidx%7].TextColor = Color.White;

            int focusX = dateTable[focusidx/7,focusidx%7].Position2D.X + (dateTable[focusidx/7,focusidx%7].Size2D.Width - focusImage.Size2D.Width)/2;
            int focusY = dateTable[focusidx/7,focusidx%7].Position2D.Y + (dateTable[focusidx/7,focusidx%7].Size2D.Height - focusImage.Size2D.Height)/2;
            focusImage.Position2D = new Position2D(focusX, focusY);
            focusImage.Show();

            if (showDate.Month == curDate.Month && showDate.Year == curDate.Year)
            {
                endSelectedImage.Position2D = new Position2D(focusX, focusY);
                endSelectedImage.Show();
                if (showDate.Day == curDate.Day)
                {
                    focusImage.Hide();
                }
            }
            else
            {
                endSelectedImage.Hide();
            }

            preTouch = dateTable[focusidx/7,focusidx%7];

            monthText.Text =  showDate.ToString("MMMM", new CultureInfo("en-us"));
            dropDown.ButtonText = showDate.Year.ToString(); 
        }

        private class DataArgs
        {
            public int prenum;
            public int curnum;
            public int nextnum;
        }
    }
}
