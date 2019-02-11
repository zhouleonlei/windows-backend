using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Controls
{
    public class ScrollBar : Control
    {
        protected override Attributes GetAttributes()
        {
            return null;
        }

        public enum DirectionType
        {
            Horizontal,
            Vertical
        }

        ///// <summary>
        ///// The Attributes class of ScrollBar. User can set Direction, ImageURL, Color and value, duration attributes to ScrollBar.
        ///// </summary>
        ///// <code>
        ///// ScrollBar.Attributes attrs = new ScrollBar.Attributes();
        ///// attrs.Direction = ScrollBar.DirectionType.Horizontal;
        ///// attr.ThumbColor = new Color(13.0f / 255.0f, 13.0f / 255.0f, 13.0f / 255.0f, 1.0f);    //Color #0d0d0d
        ///// attr.TrackColor = new Color(96.0f / 255.0f, 105.0f / 255.0f, 110.0f / 255.0f, 0.6f);  //Color #60696e (Opacity : 60%)
        ///// </code>


        //    }



        /// <summary>
        /// The PanGesture event args.
        /// </summary>
        /// <code>
        /// scrollBar.PanGestureEvent += OnPanGestureEvent;
        /// private void OnPanGestureEvent(object sender, ScrollBar.PanGestureEventArgs args)
        /// {
        ///      Log.Info("TV.NUI.Example", "args.currentValue = " + args.currentValue);
        /// }
        /// </code>
        /// <version> 5.5.0 </version>
        public class PanGestureEventArgs : EventArgs
        {
            public int currentValue;
        }

        /// <summary>
        /// The PanGesture event handler.
        /// </summary>
        /// <version> 5.5.0 </version>
        public event EventHandler<PanGestureEventArgs> PanGestureEvent
        {
            add
            {
                panGestureEventHandler += value;
            }
            remove
            {
                panGestureEventHandler -= value;
            }
        }

        //static ScrollBar CreateInstance()
        //{
        //    ////TNLog.D("CreateInstance();");
        //    return new ScrollBar();
        //}

        /// <summary>
        /// For register type to View Registry
        /// </summary>
        public ScrollBar() : base()
        {
            Initialize();
        }

        public ScrollBar(string style) : base(style)
        {
            scrollBarAttrs = attributes as ScrollBarAttributes;
            if (scrollBarAttrs == null)
            {
                throw new Exception("ScrollBar attribute parse error.");
            }
            Initialize();
        }

        public ScrollBar(ScrollBarAttributes attributes) : base()
        {
            this.attributes = scrollBarAttrs = attributes.Clone() as ScrollBarAttributes;
        }

        ///// <summary>
        ///// The constructor of the ScrollBar with specific Attributes.
        ///// </summary>
        ///// <param name="attrs">The Attributes object to initialize the ScrollBar.</param>
        //public ScrollBar(Attributes attrs = null) : base(attrs, "ScrollBar")
        //{
        //    //TNLog.D("ScrollBar(Attributes);");
        //    if (scrollBarAttrs == null)
        //    {
        //        scrollBarAttrs = new Attributes();
        //    }
        //    Initialize();
        //}

        ///// <summary>
        ///// The constructor of the ScrollBar with specific style.
        ///// </summary>
        ///// <param name="style">The string to initialize the ScrollBar.</param>
        //public ScrollBar(string style) : base(style, "ScrollBar")
        //{
        //    //TNLog.D("ScrollBar(style);");
        //    if (scrollBarAttrs == null)
        //    {
        //        scrollBarAttrs = new Attributes();
        //    }
        //    Initialize();
        //}

        /// <summary>
        /// The property to get/set the direction of the ScrollBar.
        /// </summary>
        public DirectionType Direction
        {
            get
            {
                return scrollBarAttrs.Direction.Value;
            }
            set
            {
                scrollBarAttrs.Direction = value;
                //TNLog.D("Direction value = " + scrollBarAttrs.Direction + ";");
                UpdateValue();
            }
        }

        /// <summary>
        /// The property to get/set the size of the thumb object.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throw when ThumbSize is null.</exception>
        /// <example>
        /// <code>
        /// ScrollBar scroll;
        /// try
        /// {
        ///     scroll.ThumbSize = new Size(500, 10, 0);
        /// }
        /// catch(InvalidOperationException e)
        /// {
        ///     Tizen.Log.Error(LogTag, "Failed to set ThumbSize value : " + e.Message);
        /// }
        /// </code>
        /// </example>
        public Size ThumbSize
        {
            get
            {
                return scrollBarAttrs.ThumbSize;
            }
            set
            {
                if (value == null)
                {
                    throw new InvalidOperationException("Wrong size value of the thumb object. It shoud be a not-null value!");
                }
                if (thumbObj != null)
                {
                    //TNLog.D("ThumbSize, value.Width = " + value.Width + ", value.Height = " + value.Height + ";");
                    if (scrollBarAttrs.ThumbSize == null)
                    {
                        scrollBarAttrs.ThumbSize = new Size(value.Width, value.Height, 0);
                    }
                    else
                    {
                        scrollBarAttrs.ThumbSize.Width = value.Width;
                        scrollBarAttrs.ThumbSize.Height = value.Height;
                    }
                    thumbObj.Size2D = new Size2D((int)value.Width, (int)value.Height);
                    UpdateValue();
                }
            }
        }

        public string TrackImageURL
        {
            get
            {
                return scrollBarAttrs.TrackImageAttributes.ResourceURL.All;
            }
            set
            {
                if (trackObj != null)
                {
                    if (scrollBarAttrs.TrackImageAttributes.ResourceURL == null)
                    {
                        scrollBarAttrs.TrackImageAttributes.ResourceURL = new StringSelector();
                    }
                    scrollBarAttrs.TrackImageAttributes.ResourceURL.All = value;
                }
            }
        }

        //    public string ThumbImageURL = null;

        /// <summary>
        /// The property to get/set the color of the track object.
        /// </summary>
        public Color TrackColor
        {
            get
            {
                //if (trackColor != null)
                //{
                //    return trackColor;
                //}
                //return scrollBarAttrs.TrackColor;
                return trackObj?.BackgroundColor;
            }
            set
            {
                //TNLog.D("trackColor, r = " + value.R + ", g = " + value.G + ", b = " + value.B + ", a = " + value.A + ";");
                // trackColor = new Color(value.R, value.G, value.B, value.A);
                if (trackObj != null)
                {
                    trackObj.BackgroundColor = value;
                }
            }
        }

        /// <summary>
        /// The property to get/set the color of the thumb object.
        /// </summary>
        public Color ThumbColor
        {
            get
            {
                return thumbObj?.BackgroundColor;
            }
            set
            {
                //TNLog.D("thumbColor, r = " + value.R + ", g = " + value.G + ", b = " + value.B + ", a = " + value.A + ";");
                if (thumbObj != null)
                {
                    thumbObj.BackgroundColor = value;
                }
            }
        }

        /// <summary>
        /// The property to get/set the max value of the ScrollBar.
        /// </summary>
        public uint? MaxValue
        {
            get
            {
                return scrollBarAttrs.MaxValue.Value;
            }
            set
            {
                scrollBarAttrs.MaxValue = value;
                //TNLog.D("maxValue = " + maxValue);
                UpdateValue();/////
            }
        }

        /// <summary>
        /// The property to get/set the min value of the ScrollBar.
        /// </summary>
        public uint MinValue
        {
            get
            {
                return scrollBarAttrs.MinValue.Value;
            }
            set
            {
                scrollBarAttrs.MinValue = value;
                //TNLog.D("minValue = " + minValue);
                UpdateValue();
            }
        }

        /// <summary>
        /// The property to get/set the current value of the ScrollBar.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throw when Current value is less than Min value, or greater than Max value.</exception>
        /// <example>
        /// <code>
        /// ScrollBar scroll;
        /// scroll.MaxValue = 100;
        /// scroll.MinValue = 0;
        /// try
        /// {
        ///     scroll.CurrentValue = 50;
        /// }
        /// catch(ArgumentOutOfRangeException e)
        /// {
        ///     Tizen.Log.Error(LogTag, "Failed to set Current value : " + e.Message);
        /// }
        /// </code>
        /// </example>
        public uint CurrentValue
        {
            get
            {
                return scrollBarAttrs.CurValue.Value;
            }
            set
            {
                if (value < scrollBarAttrs.MinValue || value > scrollBarAttrs.MaxValue)
                {
                    //TNLog.E("Current value is less than the Min value, or greater than the Max value. value = " + value + ";");
                    throw new ArgumentOutOfRangeException("Wrong Current value. It shoud be greater than the Min value, and less than the Max value!");
                }
                scrollBarAttrs.CurValue = value;
                //TNLog.D("curValue = " + curValue);
                UpdateValue();
            }
        }

        /// <summary>
        /// Property to set/get animation duration.
        /// </summary>
        public uint Duration
        {
            get
            {
                return scrollBarAttrs.Duration.Value;
            }
            set
            {
                //TNLog.D("Duration value = " + value + ";");
                scrollBarAttrs.Duration = value;
                //if (scrollAniPlayer != null)
                //{
                //    scrollAniPlayer.Duration = (int)value;
                //}
            }
        }

        /// <summary>
        /// Method to set current value. The thumb object would move to the corresponding position with animation or not.
        /// </summary>
        /// <param name="currentValue">The special current value.</param>
        /// <param name="enableAni">Enable move with animation or not, the default value is true.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throw when current size is less than the min value, or greater than the max value.</exception>
        /// <example>
        /// <code>
        /// ScrollBar scroll;
        /// scroll.MinValue = 0;
        /// scroll.MaxValue = 100;
        /// try
        /// {
        ///     scroll.SetCurrentValue(50);
        /// }
        /// catch(ArgumentOutOfRangeException e)
        /// {
        ///     Tizen.Log.Error(LogTag, "Failed to set current value : " + e.Message);
        /// }
        /// </code>
        /// </example>
        public void SetCurrentValue(uint currentValue, bool enableAni = true)
        {
            if (currentValue < scrollBarAttrs.MinValue || currentValue > scrollBarAttrs.MaxValue)
            {
                //TNLog.E("Current value is less than the Min value, or greater than the Max value. currentValue = " + currentValue + ";");
                throw new ArgumentOutOfRangeException("Wrong Current value. It shoud be greater than the Min value, and less than the Max value!");
            }
            //TNLog.D("currentValue = " + currentValue + ";");
            scrollBarAttrs.CurValue = currentValue;

            if (!enableAni)
            {
                UpdateValue();
            }
            else
            {
                UpdateValue(true);
            }
        }

        /// <summary>
        /// Dispose ScrollBar.
        /// </summary>
        /// <param name="type">The DisposeTypes value.</param>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
                if (thumbObj != null)
                {
                    panGestureDetector.Detach(thumbObj);
                }
                panGestureDetector.Detected -= OnPanGestureDetected;
                panGestureDetector.Dispose();

                if (trackObj != null)
                {
                    trackObj.TouchEvent -= OnTouchEvent;
                    Remove(trackObj);
                    trackObj.Dispose();
                    trackObj = null;
                }

                if (thumbObj != null)
                {
                    Remove(thumbObj);
                    thumbObj.Dispose();
                    thumbObj = null;
                }

                //if (scrollAniPlayer != null)
                //{
                //    scrollAniPlayer.Stop();
                //    scrollAniPlayer.Clear();
                //    scrollAniPlayer.Dispose();
                //    scrollAniPlayer = null;
                //}

                // UIDirectionChangedEvent -= OnUIDirectionChangedEvent;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            //Unreference this from if a static instance refer to this. 

            //You must call base.Dispose(type) just before exit.
            base.Dispose(type);
        }

        /// <summary>
        /// The method to update Attributes.
        /// </summary>
        /// <param name="attrs">The specified attributes object.</param>
        protected override void OnUpdate(Attributes attrs)
        {
            scrollBarAttrs = attrs as ScrollBarAttributes;
            if (scrollBarAttrs == null)
            {
                return;
            }

            ApplyAttributes(this, scrollBarAttrs);
            ApplyAttributes(trackObj, scrollBarAttrs.TrackImageAttributes);
            ApplyAttributes(thumbObj, scrollBarAttrs.ThumbImageAttributes);
        }

        private void Initialize()
        {
            this.Focusable = false;
            //TNLog.I("create component");
            trackObj = new ImageView
            {
                Focusable = false,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft

            };
            trackObj.TouchEvent += OnTouchEvent;
            thumbObj = new ImageView
            {
                Focusable = false,
                WidthResizePolicy = ResizePolicyType.Fixed,
                HeightResizePolicy = ResizePolicyType.Fixed,
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft
            };

            Add(trackObj);
            Add(thumbObj);

            //scrollAniPlayer = new AnimationPlayer();

            //UIDirectionChangedEvent += OnUIDirectionChangedEvent;
            //uiDirection = SystemProperty.Instance.UIDirection;

            InitializePanGestureDetector();
        }

        //private void UpdateAttribute(Attributes attrs)
        //{
        //    //TNLog.D("UpdateAttribute(attrs);");
        //    if (attrs.Direction != null)
        //    {
        //        scrollBarAttrs.Direction = attrs.Direction;
        //    }
        //    if (attrs.TrackImageURL != null)
        //    {
        //        scrollBarAttrs.TrackImageURL = attrs.TrackImageURL;
        //    }
        //    if (attrs.TrackColor != null)
        //    {
        //        scrollBarAttrs.TrackColor = attrs.TrackColor;
        //    }
        //    if (attrs.ThumbImageURL != null)
        //    {
        //        scrollBarAttrs.ThumbImageURL = attrs.ThumbImageURL;
        //    }
        //    if (attrs.ThumbColor != null)
        //    {
        //        scrollBarAttrs.ThumbColor = attrs.ThumbColor;
        //    }
        //    if (attrs.ThumbSize != null)
        //    {
        //        scrollBarAttrs.ThumbSize = attrs.ThumbSize;
        //    }
        //    if (attrs.MaxValue != null)
        //    {
        //        scrollBarAttrs.MaxValue = attrs.MaxValue;
        //    }
        //    if (attrs.MinValue != null)
        //    {
        //        scrollBarAttrs.MinValue = attrs.MinValue;
        //    }
        //    if (attrs.CurValue != null)
        //    {
        //        scrollBarAttrs.CurValue = attrs.CurValue;
        //    }
        //    if (attrs.Duration != null)
        //    {
        //        scrollBarAttrs.Duration = attrs.Duration;
        //    }
        //}

        //private void ApplyAttributes()
        //{
        //    //TNLog.D("ApplyAttributes();");
        //    if (scrollBarAttrs.TrackImageURL != null)
        //    {
        //        trackObj.SetImage(scrollBarAttrs.TrackImageURL);
        //    }

        //    if (trackColor != null)
        //    {
        //        float r = trackColor.R;
        //        float g = trackColor.G;
        //        float b = trackColor.B;
        //        float a = trackColor.A;
        //        trackObj.BackgroundColor = new Color(r, g, b, a);
        //    }
        //    else
        //    {
        //        if (scrollBarAttrs.TrackColor != null)
        //        {
        //            float r = scrollBarAttrs.TrackColor.R;
        //            float g = scrollBarAttrs.TrackColor.G;
        //            float b = scrollBarAttrs.TrackColor.B;
        //            float a = scrollBarAttrs.TrackColor.A;
        //            trackObj.BackgroundColor = new Color(r, g, b, a);
        //        }
        //    }

        //    if (scrollBarAttrs.ThumbImageURL != null)
        //    {
        //        thumbObj.SetImage(scrollBarAttrs.ThumbImageURL);
        //    }
        //    if (thumbColor != null)
        //    {
        //        float r = thumbColor.R;
        //        float g = thumbColor.G;
        //        float b = thumbColor.B;
        //        float a = thumbColor.A;
        //        thumbObj.BackgroundColor = new Color(r, g, b, a);
        //    }
        //    else
        //    {
        //        if (scrollBarAttrs.ThumbColor != null)
        //        {
        //            float r = scrollBarAttrs.ThumbColor.R;
        //            float g = scrollBarAttrs.ThumbColor.G;
        //            float b = scrollBarAttrs.ThumbColor.B;
        //            float a = scrollBarAttrs.ThumbColor.A;
        //            thumbObj.BackgroundColor = new Color(r, g, b, a);
        //        }
        //    }

        //    if (scrollBarAttrs.ThumbSize != null)
        //    {
        //        float w = scrollBarAttrs.ThumbSize.Width;
        //        float h = scrollBarAttrs.ThumbSize.Height;
        //        thumbObj.Size2D = new Size2D((int)w, (int)h);
        //    }
        //    if (scrollBarAttrs.Duration != null)
        //    {
        //        scrollAniPlayer.Duration = (int)scrollBarAttrs.Duration.Value;
        //    }
        //    ApplyPanGestureDetectorDirection();
        //}

        private void UpdateValue(bool enableAni = false)
        {
            if (trackObj == null || thumbObj == null || scrollBarAttrs.Direction == null || scrollBarAttrs.MaxValue == null || scrollBarAttrs.MinValue == null || scrollBarAttrs.CurValue == null)
            {
                if (trackObj == null)
                {
                    Console.WriteLine("01  ");
                }
                if (thumbObj == null)
                {
                    Console.WriteLine("02  ");
                }
                if (scrollBarAttrs.Direction == null)
                {
                    Console.WriteLine("03  ");
                }
                if (scrollBarAttrs.MaxValue == null)
                {
                    Console.WriteLine("04 ");
                }
                if (scrollBarAttrs.MinValue == null)
                {
                    Console.WriteLine("05 ");
                }
                if (scrollBarAttrs.CurValue == null)
                {
                    Console.WriteLine("06 ");
                }
                //TNLog.E("Null value, return;");
                Console.WriteLine("  11111111111");
                return;
            }
            //TNLog.D("minValue = " + minValue + ", maxValue = " + maxValue + ", curValue = " + curValue);
            if (scrollBarAttrs.MinValue >= scrollBarAttrs.MaxValue || scrollBarAttrs.CurValue < scrollBarAttrs.MinValue || scrollBarAttrs.CurValue > scrollBarAttrs.MaxValue)
            {
                if (scrollBarAttrs.MinValue >= scrollBarAttrs.MaxValue)
                {
                    //TNLog.E("Min value >= Max value;");
                    Console.WriteLine("222222222222");
                }
                if (scrollBarAttrs.CurValue < scrollBarAttrs.MinValue || scrollBarAttrs.CurValue > scrollBarAttrs.MaxValue)
                {
                    //TNLog.E("Current value < Min value || Current value > Max value;");
                    Console.WriteLine("333333333333333");
                }
                return;
            }
            Console.WriteLine("444444444444444");
            float width = (float)Size2D.Width;
            float height = (float)Size2D.Height;
            float thumbW = scrollBarAttrs.ThumbSize.Width;
            float thumbH = scrollBarAttrs.ThumbSize.Height;
            float ratio = (float)(scrollBarAttrs.CurValue - scrollBarAttrs.MinValue) / (float)(scrollBarAttrs.MaxValue - scrollBarAttrs.MinValue);
            //TNLog.I("width = " + width + ", height = " + height + ", ratio = " + ratio);
            if (scrollBarAttrs.Direction == DirectionType.Horizontal)
            {
                //if (uiDirection == UIDirection.RTL)
                //{
                //    ratio = 1.0f - ratio;
                //    //TNLog.I("RTL, ratio = " + ratio);
                //}
                Console.WriteLine("555555555555555555");
                float posX = ratio * (width - thumbW);
                float posY = (height - thumbH) / 2.0f;
                //TNLog.I("posX = " + posX + ", posY = " + posY + ";");
                thumbObjPosX = posX;
                //if (scrollAniPlayer != null)
                //{
                //    scrollAniPlayer.Stop();
                //    scrollAniPlayer.Clear();
                //}

                if (!enableAni)
                {
                    thumbObj.Position = new Position(posX, posY, 0);
                }
                else
                {
                    //if (scrollAniPlayer != null)
                    //{
                    //    scrollAniPlayer.AnimateTo(thumbObj, "PositionX", posX, AnimationCurve.Basic);
                    //    scrollAniPlayer.Play();
                    //}
                }
            }
            else
            {
                float posX = (width - thumbW) / 2.0f;
                float posY = ratio * (height - thumbH);
                //TNLog.I("posX = " + posX + ", posY = " + posY + ";");
                thumbObjPosY = posY;
                //if (scrollAniPlayer != null)
                //{
                //    scrollAniPlayer.Stop();
                //    scrollAniPlayer.Clear();
                //}

                if (!enableAni)
                {
                    thumbObj.Position = new Position(posX, posY, 0);
                }
                else
                {
                    //if (scrollAniPlayer != null)
                    //{
                    //    scrollAniPlayer.AnimateTo(thumbObj, "PositionY", posY, AnimationCurve.Basic);
                    //    scrollAniPlayer.Play();
                    //}
                }
            }
        }

        private void RelayoutComponents()
        {
            if (scrollBarAttrs.Direction == DirectionType.Horizontal)
            {
                UpdateValue();
            }
        }

        //private void OnUIDirectionChangedEvent(object sender, DirectionChangedEventArgs e)
        //{
        //    if (uiDirection == e.ParentUIDirection)
        //    {
        //        return;
        //    }
        //    uiDirection = e.ParentUIDirection;
        //    //TNLog.I("UIDirection callback, uiDirection = " + uiDirection);
        //    RelayoutComponents();
        //}



        private void InitializePanGestureDetector()
        {
            panGestureDetector = new PanGestureDetector();
            //panGestureDetector.AddDirection(PanGestureDetector.DirectionHorizontal);
            panGestureDetector.Attach(thumbObj);
            panGestureDetector.Detected += OnPanGestureDetected;
            thumbObjPosX = 0;
            thumbObjPosY = 0;
        }

        private void ApplyPanGestureDetectorDirection()
        {
            DirectionType dir = CurrentDirection();
            if (dir == DirectionType.Horizontal)
            {
                panGestureDetector.AddDirection(PanGestureDetector.DirectionHorizontal);
            }
            else
            {
                panGestureDetector.AddDirection(PanGestureDetector.DirectionVertical);
            }
        }

        private DirectionType CurrentDirection()
        {
            DirectionType dir = DirectionType.Horizontal;
            if (scrollBarAttrs != null)
            {
                if (scrollBarAttrs.Direction != null)
                {
                    dir = scrollBarAttrs.Direction.Value;
                }
            }
            return dir;
        }

        private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            DirectionType dir = CurrentDirection();
            if (e.PanGesture.State == Gesture.StateType.Continuing)
            {
                PanGestureEventArgs eventArgs = null;
                eventArgs = new PanGestureEventArgs();
                if (dir == DirectionType.Horizontal)
                {
                    eventArgs.currentValue = CalculateCurrentValue(e.PanGesture.Displacement.X, dir);
                }
                else
                {
                    eventArgs.currentValue = CalculateCurrentValue(e.PanGesture.Displacement.Y, dir);
                }
                OnPanGestureEvent(this, eventArgs);
            }
            if (e.PanGesture.State == Gesture.StateType.Started)
            {
                PanGestureEventArgs eventArgs = null;
                eventArgs = new PanGestureEventArgs();
                if (dir == DirectionType.Horizontal)
                {
                    thumbObjPosX = thumbObj.PositionX;
                    eventArgs.currentValue = CalculateCurrentValue(e.PanGesture.Displacement.X, dir);
                }
                else
                {
                    thumbObjPosY = thumbObj.PositionY;
                    eventArgs.currentValue = CalculateCurrentValue(e.PanGesture.Displacement.Y, dir);
                }
                OnPanGestureEvent(this, eventArgs);
            }
        }

        private int CalculateCurrentValue(float offset, DirectionType dir)
        {
            if (dir == DirectionType.Horizontal)
            {
                thumbObjPosX += offset;
                if (thumbObjPosX < 0)
                {
                    thumbObj.PositionX = 0;
                    scrollBarAttrs.CurValue = scrollBarAttrs.MinValue;
                }
                else if (thumbObjPosX > Size2D.Width - thumbObj.Size2D.Width)
                {
                    thumbObj.PositionX = Size2D.Width - thumbObj.Size2D.Width;
                    scrollBarAttrs.CurValue = scrollBarAttrs.MaxValue;
                }
                else
                {
                    thumbObj.PositionX = thumbObjPosX;
                    scrollBarAttrs.CurValue = (uint)((thumbObjPosX / (float)(Size2D.Width - thumbObj.Size2D.Width)) * (float)(scrollBarAttrs.MaxValue - scrollBarAttrs.MinValue) + 0.5f);
                }
            }
            else
            {
                //TNLog.I("thumbObjPosY = " + thumbObjPosY + ", offset = " + offset);
                thumbObjPosY += offset;
                if (thumbObjPosY < 0)
                {
                    thumbObj.PositionY = 0;
                    scrollBarAttrs.CurValue = scrollBarAttrs.MinValue;
                }
                else if (thumbObjPosY > Size2D.Height - thumbObj.Size2D.Height)
                {
                    thumbObj.PositionY = Size2D.Height - thumbObj.Size2D.Height;
                    scrollBarAttrs.CurValue = scrollBarAttrs.MaxValue;
                }
                else
                {
                    thumbObj.PositionY = thumbObjPosY;
                    scrollBarAttrs.CurValue = (uint)((thumbObjPosY / (float)(Size2D.Height - thumbObj.Size2D.Height)) * (float)(scrollBarAttrs.MaxValue - scrollBarAttrs.MinValue) + 0.5f);
                }
            }
            ////TNLog.I("***offsetX = " + offsetX + ", curValue = " + curValue + ", thumbObjPositionX = " + thumbObjPositionX);
            return (int)scrollBarAttrs.CurValue;
        }

        private void OnPanGestureEvent(object sender, PanGestureEventArgs e)
        {
            //TNLog.I("on pan gesture move event");
            panGestureEventHandler?.Invoke(sender, e);
        }

        private bool OnTouchEvent(object source, TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                Vector2 pos = e.Touch.GetLocalPosition(0);
                ChangeValueByTouch(pos);
            }
            return false;
        }

        private void ChangeValueByTouch(Vector2 pos)
        {
            if (thumbObj == null)
            {
                return;
            }
            Size2D thumbSize = thumbObj.Size2D;
            Size2D trackSize = trackObj.Size2D;
            DirectionType direction = CurrentDirection();
            //TNLog.I("pos.X = " + pos.X + ", pos.Y = " + pos.Y + ", direction = " + direction);

            if (direction == DirectionType.Horizontal)
            {
                if (pos.X > trackSize.Width - thumbSize.Width)
                {
                    thumbObjPosX = trackSize.Width - thumbSize.Width;
                }
                else
                {
                    thumbObjPosX = pos.X;
                }

                thumbObj.PositionX = thumbObjPosX;
                scrollBarAttrs.CurValue = (uint)((thumbObjPosX) / (float)(trackSize.Width - thumbSize.Width) * (float)(scrollBarAttrs.MaxValue - scrollBarAttrs.MinValue) + 0.5f);
            }
            else
            {
                if (pos.Y > trackSize.Height - thumbSize.Height)
                {
                    thumbObjPosY = trackSize.Height - thumbSize.Height;
                }
                else
                {
                    thumbObjPosY = pos.Y;
                }

                thumbObj.PositionY = thumbObjPosY;
                scrollBarAttrs.CurValue = (uint)((thumbObjPosY) / (float)(trackSize.Height - thumbSize.Height) * (float)(scrollBarAttrs.MaxValue - scrollBarAttrs.MinValue) + 0.5f);
            }
        }

        private ScrollBarAttributes scrollBarAttrs;

        ViewLayoutDirectionType uiDirection = ViewLayoutDirectionType.LTR;

        private ImageView trackObj;// = null;
        private ImageView thumbObj;// = null;

        //private AnimationPlayer scrollAniPlayer;
        //private UIDirection uiDirection = UIDirection.LTR;
        //private Color trackColor = null;
        //private Color thumbColor = null;
        //private uint? curValue = null;
        //private uint? minValue = null;
        //private uint? maxValue = null;

        private PanGestureDetector panGestureDetector;
        private EventHandler<PanGestureEventArgs> panGestureEventHandler;


        private float thumbObjPosX;  //move to attribute?
        private float thumbObjPosY;


    }
}
