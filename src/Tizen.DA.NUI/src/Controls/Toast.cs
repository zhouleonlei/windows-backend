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
            LayoutDirectionChanged += OnLayoutDirectionChanged;
        }

        private void OnLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            RelayoutRequest();
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
        }

        private void AddLoading()
        {
            loading = new Loading("DefaultLoading");
            this.Add(loading);
            loading.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
            loading.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
            loading.Size2D = new Size2D(100, 100);
            loading.PositionUsesPivotPoint = true;
            loading.Position2D.Y = 0;
            loadingEnable = true;
            RelayoutRequest();
        }

        private void RemoveLoading()
        {
            if (loading != null)
            {
                this.Remove(loading);
                loading.Dispose();
            }

            loadingEnable = false;
            RelayoutRequest();
        }

        protected override void LayoutChild()
        {
            if (toastAttributes.TextAttributes.Size2D == null)
            {
                toastAttributes.TextAttributes.Size2D = new Size2D();
            }
            if (toastAttributes.TextAttributes.Position2D == null)
            {
                toastAttributes.TextAttributes.Position2D = new Position2D();
            }
            toastAttributes.TextAttributes.Size2D.Height = this.Size2D.Height - UpSpace - DownSpace;
            toastAttributes.TextAttributes.Position2D.Y = UpSpace;

            if (loadingEnable)
            {
                toastAttributes.TextAttributes.Size2D.Width = this.Size2D.Width - 2 * LeftSpace - 108;
                if (LayoutDirection == ViewLayoutDirectionType.LTR)
                {
                    loading.Position2D.X = LeftSpace;
                    toastAttributes.TextAttributes.Position2D.X = LeftSpace + 108;
                    toastAttributes.TextAttributes.HorizontalAlignment = HorizontalAlignment.Begin;

                }
                else
                {
                    loading.Position2D.X = this.Size2D.Width - LeftSpace - loading.Size2D.Width;
                    toastAttributes.TextAttributes.Position2D.X = LeftSpace;
                    toastAttributes.TextAttributes.HorizontalAlignment = HorizontalAlignment.End;
                }
                Console.WriteLine("loading.Position2D.X" + loading.Position2D.X + " leftSapce:" + LeftSpace.ToString() + "  downSpace= " + DownSpace.ToString());//gwfdebug
            }
            else
            {
                toastAttributes.TextAttributes.Size2D.Width = this.Size2D.Width - 2 * LeftSpace;

                toastAttributes.TextAttributes.Position2D.X = LeftSpace;

            }
            //Console.WriteLine("this.height"+this.Size2D.Height+" Upspace"+UpSpace.ToString()+"downSpace= "+downSpace.ToString());gwfdebug

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
