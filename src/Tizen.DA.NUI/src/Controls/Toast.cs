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
                        this.SizeHeight = 132;
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
                                Position2D = "96,98",
                                Size2D = new Size2D(808, 56),

                                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                                PivotPoint = Tizen.NUI.PivotPoint.Center,
                                PositionUsesPivotPoint = true,
                            };
                            this.Add(toastText_2line);

                        }

                        this.SizeHeight = 192;
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
                                Position2D = "96,158",
                                Size2D = new Size2D(808, 56),
                                BackgroundColor=Color.Red,
                                PointSize = 20,
                                TextColor = Color.Black,

                            };
                        }
                        if (toastText_2line == null)
                        {
                            toastText_2line = new TextLabel()
                            {
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                Position2D = "96,98",
                                Size2D = new Size2D(808, 56),
                                //BackgroundColor = Color.Blue,
                                PointSize = 20,
                                BackgroundColor = Color.Red,
                                TextColor = Color.Black,
                            };

                        }

                        this.SizeHeight = 272;
                        this.Add(toastText_2line);
                        this.Add(toastText_3line);


                        linesType = value;
                        Console.WriteLine("3line set done");
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
            //Console.WriteLine("FH NULL CONTR START");
            this.attributes = toastAttributes = new ToastAttributes
            {
                TextAttributes = new TextAttributes
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Position2D = "96,38",
                    BackgroundColor= new ColorSelector
                    {
                        All = Color.Blue
                    }
                },

                BackgroundImageAttributes = new ImageAttributes
                {
                    Border = new RectangleSelector()
                    {
                        All = new Rectangle(64, 64, 4, 4),
                    }
                },
            };

            Initialize();
            //ApplyAttributes(this, toastAttributes);
            Console.WriteLine("FH NULL CONTR DONE");
        }

        public Toast(string style) : base(style)
        {
            Console.WriteLine("Toast ( FH) style contr");
            toastAttributes = attributes as ToastAttributes;
            if (toastAttributes == null)
            {
                throw new Exception("Toast attribute parse error.");
            }

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
            Console.WriteLine("OnUpdate (FH ) Toast ");
            toastAttributes = attributes as ToastAttributes;
            if (toastAttributes == null)
            {
                Console.WriteLine("FH OnUpdate ==null return");
                return;
            }

            if (loadingEnable)
            {
                ApplyAttributes(loading, toastAttributes.LoadingAttributes);
            }

            base.OnUpdate(attributes);

        }

        private void AddLoading()
        {
            loading= new Loading("DefaultLoading");
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
    }
}
