using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;
using Tizen.NUI;
using System;

namespace Tizen.FH.NUI.Controls
{
    public class Toast : Tizen.NUI.Controls.Toast
    {
        public enum ToastLengthType
        {
            SHORT,
            LONG,
            CUSTOM
        };
        public enum ToastLinesType
        {
            ONE,
            TWO,
            THREE
        };
        private Loading loading;
        private ToastAttributes toastAttributes;
        private TextLabel toastText_2line;
        private TextLabel toastText_3line;
        private ToastLengthType lengthType = ToastLengthType.CUSTOM;
        private ToastLinesType linesType = ToastLinesType.ONE;
        private bool loadingEnable = false;
        public ToastLengthType LengthType
        {
            get
            {
                return lengthType;
            }
            set
            {
                if (value != lengthType)
                {
                    if (value == ToastLengthType.LONG)
                    {
                        this.SizeWidth = 1000;
                    }
                    else if (value == ToastLengthType.SHORT)
                    {
                        this.SizeWidth = 512;
                    }

                    lengthType = value;
                }

            }
        }

        public ToastLinesType LinesType
        {
            get
            {
                return linesType;
            }
            set
            {
                if (value != linesType)
                {
                    if (value == ToastLinesType.ONE)
                    {
                        if (toastText_3line != null)
                        {
                            toastText_3line.Dispose();
                        }
                        if (toastText_2line != null)
                        {
                            toastText_2line.Dispose();
                        }

                        linesType = value;
                    }
                    else if (value == ToastLinesType.TWO)
                    {
                        if (toastText_3line != null)
                        {
                            toastText_3line.Dispose();
                        }
                        if (toastText_2line == null)
                        {
                            toastText_2line = new TextLabel()
                            {
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,

                                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                                PivotPoint = Tizen.NUI.PivotPoint.Center,
                                PositionUsesPivotPoint = true,
                            };
                            this.Add(toastText_2line);
                        }

                        linesType = value;
                    }
                    else if (value == ToastLinesType.THREE)
                    {
                        if (toastText_3line == null)
                        {
                            toastText_3line = new TextLabel()
                            {
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                            };
                        }
                        if (toastText_2line == null)
                        {
                            toastText_2line = new TextLabel()
                            {
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                            };
                        }

                        this.Add(toastText_2line);
                        this.Add(toastText_3line);

                        linesType = value;
                        Console.WriteLine("3line set done");//gwfdebug
                    }

                }

            }
        }

        public bool LoadingEnable
        {
            get
            {
                return loadingEnable;
            }
            set
            {
                if (value != loadingEnable)
                {
                    if (value == true)
                    {
                        AddLoading();
                    }
                    else
                    {
                        RemoveLoading();
                    }

                    loadingEnable = value;
                }

            }
        }

        public string Text2Line
        {
            get
            {
                return toastText_2line?.Text;
            }
            set
            {
                if (linesType == ToastLinesType.TWO || linesType == ToastLinesType.THREE)
                    toastText_2line.Text = value;
            }

        }

        public string Text3Line
        {
            get
            {
                return toastText_3line?.Text;
            }
            set
            {
                if (linesType == ToastLinesType.THREE)
                    toastText_3line.Text = value;
            }

        }

        public Toast() : base()
        {
            //Console.WriteLine("FH NULL CONTR START");//gwfdebug
            SetAttribute();

            Initialize();
            base.SetAttribute();
            Console.WriteLine("FH NULL CONTR DONE");//gwfdebug
        }

        public Toast(string style) : base(style)
        {
            SetAttribute();
            if (toastAttributes == null)
            {
                throw new Exception("Toast attribute parse error.");
            }
            base.SetAttribute();
            ApplyAttributes(this, toastAttributes);
        }

        private void Initialize()
        {
            //TextSize2D = new Size2D();
            // TextPosition2D = new Position2D(96, 38);
            //toastAttributes = attributes as ToastAttributes;
           // toastAttributes.TextAttributes.Position2D = new Position2D(96, 38);
           // toastAttributes.TextAttributes.PositionUsesPivotPoint = true;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (loading != null)
                {
                    this.Remove(loading);
                    loading.Dispose();
                    loading = null;
                }

            }

            base.Dispose(type);
        }

        protected override void OnUpdate(Attributes attributes)
        {
            Console.WriteLine("OnUpdate (FH ) Toast ");//gwfdebug
            if (toastAttributes == null)
            {
                return;
            }
            DownSpace = UpSpace;
            if (loadingEnable)
            {
                ApplyAttributes(loading, toastAttributes.LoadingAttributes);
            }
            if (linesType == ToastLinesType.THREE)
            {
                DownSpace = 168;
            }
            if (linesType == ToastLinesType.TWO)
            {
                DownSpace = 98;
            }
            base.OnUpdate(attributes);
            UpdateTexts();
        }

        private void AddLoading()
        {
            loading = new Loading("DefaultLoading");
            this.Add(loading);
            loading.Position2D.X = 96;
            loading.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
            loading.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
            loading.Size2D = new Size2D(100, 100);

            loading.PositionUsesPivotPoint = true;

            toastAttributes.TextAttributes.Position2D.X = 204;
            toastAttributes.TextAttributes.HorizontalAlignment = HorizontalAlignment.Begin;
            OnUpdate(toastAttributes);
        }

        private void RemoveLoading()
        {
            if (loading != null)
            {
                this.Remove(loading);
                loading.Dispose();
            }

            toastAttributes.TextAttributes.Position2D.X = 86;
            toastAttributes.TextAttributes.HorizontalAlignment = HorizontalAlignment.Center;
            OnUpdate(toastAttributes);
        }

        private void UpdateTexts()
        {
            if (toastText_2line != null)
            {
                toastText_2line.Size2D = toastAttributes.TextAttributes.Size2D;
                toastText_2line.Position2D.X = toastAttributes.TextAttributes.Position2D.X;
                toastText_2line.Position2D.Y = toastAttributes.TextAttributes.Position2D.Y + 60;//TODO
            }
            if (toastText_3line != null)
            {
                toastText_3line.Size2D = toastAttributes.TextAttributes.Size2D;
                toastText_3line.Position2D.X = toastAttributes.TextAttributes.Position2D.X;
                toastText_3line.Position2D.Y = toastAttributes.TextAttributes.Position2D.Y + 120;//TODO
            }
            
        }

        protected override Attributes GetAttributes()
        {
            return new ToastAttributes
            {
                TextAttributes = new TextAttributes
                {

                },

                BackgroundImageAttributes = new ImageAttributes
                {

                },
                LoadingAttributes = new LoadingAttributes
                {
                }
            };
        }

        protected void SetAttribute()
        {
            toastAttributes = this.attributes as ToastAttributes;
        }
    }
}
