using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Controls
{
    /// <summary>
    /// The ProgressBar class of tv nui component. It's used to show the ongoing status with a long narrow bar.
    /// </summary>
    /// <code>
    /// ProgressBar progress = new ProgressBar("C_ProgressBar_White");
    /// </code>
    /// <code>
    /// ProgressBar.Attributes attrs = new ProgressBar.Attributes();
    /// attrs.Direction = DirectionType.Horizontal;
    /// attrs.TrackColor = new Color(0.7f, 0.7f, 0.7f, 0.5f);
    /// attrs.ProgressColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    /// attrs.BufferColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);
    /// attrs.DisabledOpacity = 0.2f;
    /// ProgressBar progress = new ProgressBar(attr);
    /// </code>
    public class Progress : Control
    {
        public enum ProgressStatusType
        {
            Buffering,   //TrackImage
            Determinate, //ProgressImage
            Indeterminate//loading
        }

        protected ProgressBarAttributes progressBarAttrs = null;
        protected ImageView trackObj = null;
        protected ImageView progressObj = null;
        protected ImageView bufferObj = null;
        protected ImageView loadingObj = null;
        //private AnimationPlayer aniForLoading = null;
        //private AnimationPlayer aniForOpacity = null;
        protected bool isLoadingEnabled = false;
        protected bool isEnabled = true;

        protected DirectionType? direction = null;
        protected uint? minValue = null;
        protected uint? maxValue = null;//
        protected uint? currentValue = null;//
        protected uint? bufferValue = null;
        protected Color trackColor = null;
        protected Color progressColor = null;
        protected Color bufferColor = null;
        protected string trackURL = null;
        protected string bufferURL = null;
        protected string loadingImageURL = null;
        protected string progressImageURL = null;
        protected string progressImageURLPre = null;
        protected ProgressStatusType? state = null;

        /// <summary>
        /// The Animation attributes.
        /// </summary>
        protected AnimationAttributes animationAttrs = null;
        protected override Attributes GetAttributes()
        {
            return new ProgressBarAttributes
            {
            };
        }
        /// <summary>
        /// The direction type of the ProgressBar.
        /// </summary>
        public enum DirectionType
        {
            /// <summary> The progress moving follow horizontal direction. </summary>
            Horizontal,
            /// <summary> The progress moving follow vertical direction. </summary>
            Vertical
        }

        /// <summary>
        /// The animation attributes class.
        /// </summary>
        /// <code>
        /// ProgressBar.AnimationAttributes attrs = new ProgressBar.AnimationAttributes();
        /// attrs.Part1Duration = 167;
        /// attrs.Part2Duration = 16400;
        /// attrs.OpacityMin = 0;
        /// attrs.OpacityMax = 1.0f;
        /// attrs.OffsetX = 1127.4f;
        /// </code>
        public class AnimationAttributes
        {
            /// <summary>
            /// Construct AnimationAttributes.
            /// </summary>
            public AnimationAttributes() { }

            /// <summary>
            /// Construct with specified attribute.
            /// </summary>
            /// <param name="attrs">The specified AnimationAttributes.</param>
            public AnimationAttributes(AnimationAttributes attrs)
            {
                if (attrs == null)
                {
                    return;
                }

                Part1Duration = attrs.Part1Duration;
                Part2Duration = attrs.Part2Duration;
                OpacityMin = attrs.OpacityMin;
                OpacityMax = attrs.OpacityMax;
                OffsetX = attrs.OffsetX;
            }

            /// <summary> Clone a AnimationAttributes </summary>
            /// <returns>The new AnimationAttributes instance.</returns>
            public virtual AnimationAttributes Clone()
            {
                return new AnimationAttributes(this);
            }

            /// <summary>
            /// The animation part1 duration.
            /// </summary>
            public uint? Part1Duration = null;
            /// <summary>
            /// The animation part2 duration.
            /// </summary>
            public uint? Part2Duration = null;
            /// <summary>
            /// The animation opacity min value.
            /// </summary>
            public float? OpacityMin = null;
            /// <summary>
            /// The animation opacity max value.
            /// </summary>
            public float? OpacityMax = null;
            /// <summary>
            /// The animation x-offset value.
            /// </summary>
            public float? OffsetX = null;
        }

        /// <summary>
        /// The Attributes class of ProgressBar. User can set Direction, ImageURL, Color and the process value attributes to ProgressBar.
        /// </summary>
        /// <code>
        /// ProgressBar.Attributes attrs = new ProgressBar.Attributes();
        /// attrs.Direction = ProgressBar.DirectionType.Horizontal;
        /// attrs.TrackColor = new Color(164.0f / 255.0f, 179.0f / 255.0f, 191.0f / 255.0f, 0.6f);    // Color #a4b3bf (Opacity : 60%)
        /// attrs.ProgressColor = new Color(46.0f / 255.0f, 176.0f / 255.0f, 200.0f / 255.0f, 1.0f);  // Color #2eb0c8 
        /// attrs.BufferColor = new Color(0.0f / 255.0f, 152.0f / 255.0f, 180.0f / 255.0f, 0.3f);     // Color #0098b4 (Opacity : 30%)
        /// attrs.MaxValue = 100;
        /// attrs.MinValue = 0;
        /// attrs.CurValue = 50;
        /// </code>
        //public new class Attributes : Control.Attributes
        //{
        /// <summary>
        /// The default constructor of the ProgressBar Attributes class.
        /// </summary>
        //public Attributes()
        //{
        //}

        /// <summary>
        /// Copy Constructor of the ProgressBar Attributes class.
        /// </summary>
        /// <param name="attrs">Attributes to be copied</param>
        //public Attributes(Attributes attrs) : base(attrs)
        //{
        //    if (attrs == null)
        //    {
        //        return;
        //    }
        //    if (attrs.Direction != null)
        //    {
        //        Direction = attrs.Direction;
        //    }
        //    if (attrs.TrackColor != null)
        //    {
        //        TrackColor = attrs.TrackColor;
        //    }
        //    if (attrs.ProgressColor != null)
        //    {
        //        ProgressColor = attrs.ProgressColor;
        //    }
        //    if (attrs.BufferColor != null)
        //    {
        //        BufferColor = attrs.BufferColor;
        //    }
        //    if (attrs.TrackImageURL != null)
        //    {
        //        TrackImageURL = attrs.TrackImageURL;
        //    }
        //    if (attrs.ProgressImageURL != null)
        //    {
        //        ProgressImageURL = attrs.ProgressImageURL;
        //    }
        //    if (attrs.BufferImageURL != null)
        //    {
        //        BufferImageURL = attrs.BufferImageURL;
        //    }
        //    if (attrs.LoadingImageURL != null)
        //    {
        //        LoadingImageURL = attrs.LoadingImageURL;
        //    }
        //    if (attrs.MaxValue != null)
        //    {
        //        MaxValue = attrs.MaxValue;
        //    }
        //    if (attrs.MinValue != null)
        //    {
        //        MinValue = attrs.MinValue;
        //    }
        //    if (attrs.CurValue != null)
        //    {
        //        CurValue = attrs.CurValue;
        //    }
        //    if (attrs.BufValue != null)
        //    {
        //        BufValue = attrs.BufValue;
        //    }
        //    if (animationAttrs != null)
        //    {
        //        if (animationAttrs == null)
        //        {
        //            animationAttrs = new AnimationAttributes();
        //        }
        //        animationAttrs = animationAttrs.Clone() as AnimationAttributes;
        //    }
        //    if (attrs.DisabledOpacity != null)
        //    {
        //        DisabledOpacity = attrs.DisabledOpacity;
        //    }
        //    style = attrs.style;
        //}

        /// <summary>
        /// The method to clone the ProgressBar Attributes.
        /// </summary>
        /// <returns>The ProgressBar Attributes.</returns>
        //public override Control.Attributes Clone()
        //{
        //    TNLog.I("Clone Attributes;");
        //    return new Attributes(this);
        //}

        /// <summary>
        /// The progress direction.
        /// </summary>
        //public DirectionType? Direction = null;

        /// <summary>
        /// The track object background color.
        /// </summary>
        //public Color TrackColor = null;

        /// <summary>
        /// The progress object background color.
        /// </summary>
        //public Color ProgressColor = null;

        /// <summary>
        /// The buffer object background color.
        /// </summary>
        //public Color BufferColor = null;

        /// <summary>
        /// The track object image URL.
        /// </summary>
        //public string TrackImageURL = null;

        /// <summary>
        /// The progress object image URL.
        /// </summary>
        //public string ProgressImageURL = null;

        /// <summary>
        /// The buffer object image URL.
        /// </summary>
        //public string BufferImageURL = null;

        /// <summary>
        /// The loading object image URL.
        /// </summary>
        //public string LoadingImageURL = null;

        /// <summary>
        /// The progress max value.
        /// </summary>
        //public uint? MaxValue = null;

        /// <summary>
        /// The progress min value.
        /// </summary>
        //public uint? MinValue = null;

        public uint? BufValue
        {
            get
            {
                return bufferValue;
            }
            set
            {
                bufferValue = value;
                //TNLog.D("maxValue = " + maxValue);
                UpdateValue();/////
            }
        }

        /// <summary>
        /// The Disabled state opacity value attributes.
        /// </summary>
        public float? DisabledOpacity = null;

        /// <summary>
        /// The static method to create ProgressBar instance.
        /// </summary>
        /// <returns>The ProgressBar instance.</returns>
        static Progress CreateInstance()
        {
            //TNLog.I("CreateInstance();");
            return new Progress();
        }

        /// <summary>
        /// For register type to View Registry
        /// </summary>

        /// <summary>
        /// The constructor of ProgressBar
        /// </summary>
        /// <version> 5.5.0 </version>
        public Progress() : base()
        {
            progressBarAttrs = attributes as ProgressBarAttributes;
            Initialize();
        }

        /// <summary>
        /// The constructor of the ProgressBar class with specific Attributes.
        /// </summary>
        /// <param name="attrs">The Attributes object to initialize the ProgressBar.</param>
        public Progress(string style) : base(style)
        {
            if (attributes != null)
            {
                progressBarAttrs = attributes as ProgressBarAttributes;
            }
            Console.WriteLine("Progress (SR ) style cons");
            Initialize();
        }

        public Progress(ProgressBarAttributes attributes) : base()
        {
            this.attributes = progressBarAttrs = attributes.Clone() as ProgressBarAttributes;
            Initialize();
        }

        /// <summary>
        /// The constructor of the Progress class with specific style.
        /// </summary>
        /// <param name="style">The string to initialize the ProgressBar.</param>
        //public ProgressBar(string style) : base(style, "ProgressBar")
        //{
        //    //TNLog.I("ProgressBar(style)");
        //    if (progressBarAttrs == null)
        //    {
        //        progressBarAttrs = new Attributes();
        //    }
        //    Initialize();
        //}

        /// <summary>
        /// The property to get/set Direction of the ProgressBar.
        /// </summary>
        public DirectionType Direction
        {
            get
            {
                return direction.Value;
            }
            set
            {
                direction = value;
                //TNLog.I("value = " + direction);
                UpdateValue();
            }
        }

        /// <summary>
        /// The property to get/set Track image object URL of the ProgressBar.
        /// </summary>
        public string TrackImageURL
        {
            get
            {
                if (trackURL != null)
                {
                    return trackURL;
                }
                return trackObj?.ResourceUrl;
            }
            set
            {
                trackURL = value;
                if (trackObj != null)
                {
                    trackObj.ResourceUrl = value;
                }
            }
        }

        /// <summary>
        /// The property to get/set Progress object image URL of the ProgressBar.
        /// </summary>
        public string ProgressImageURL
        {
            get
            {
                return progressImageURL;
            }
            set
            {
                progressImageURL = value;
                if (progressObj != null)
                {
                    progressBarAttrs.ProgressImageAttributes.ResourceURL.All = value;
                }
            }
        }

        public virtual string ProgressImageURLPre
        {
            get
            {
                return progressImageURLPre;
            }
            set
            {
                progressImageURLPre = value;
            }
        }

        /// <summary>
        /// The property to get/set Buffer object image URL of the ProgressBar.
        /// </summary>
        public string BufferImageURL
        {
            get
            {
                return bufferObj?.ResourceUrl;
            }
            set
            {
                bufferURL = value;
                if (bufferObj != null)
                {
                    bufferObj.ResourceUrl = value;
                }
            }
        }

        /// <summary>
        /// The property to get/set Track object color of the ProgressBar.
        /// </summary>
        public Color TrackColor
        {
            get
            {
                return trackColor;
            }
            set
            {
                trackColor = value;
                if (trackObj != null)
                {
                    //TNLog.I("r = " + trackColor.R + ", g = " + trackColor.G + ", b = " + trackColor.B + ", a = " + trackColor.A);
                    trackObj.BackgroundColor = trackColor;
                }
            }
        }

        /// <summary>
        /// The property to get/set Progress object color of the ProgressBar.
        /// </summary>
        public Color ProgressColor
        {
            get
            {
                return progressColor;
            }
            set
            {
                progressColor = value;
                if (progressObj != null)
                {
                    //TNLog.I("r = " + progressColor.R + ", g = " + progressColor.G + ", b = " + progressColor.B + ", a = " + progressColor.A);
                    progressObj.BackgroundColor = progressColor;
                }
            }
        }

        /// <summary>
        /// The property to get/set Buffer object color of the ProgressBar.
        /// </summary>
        public Color BufferColor
        {
            get
            {
                return bufferColor;
            }
            set
            {
                bufferColor = value;
                if (bufferObj != null)
                {
                    bufferObj.BackgroundColor = bufferColor;
                }
            }
        }

        /// <summary>
        /// The property to get/set the max value of the ProgressBar.
        /// </summary>
        public uint? MaxValue
        {
            get
            {
                if (maxValue != null)
                {
                    return maxValue.Value;
                }
                return progressBarAttrs.MaxValue.Value;
            }
            set
            {
                maxValue = value;
                UpdateValue();
            }
        }

        /// <summary>
        /// The property to get/set the min value of the ProgressBar.
        /// </summary>
        public uint MinValue
        {
            get
            {
                if (minValue != null)
                {
                    return minValue.Value;
                }
                return progressBarAttrs.MinValue.Value;
            }
            set
            {
                minValue = value;
                UpdateValue();
            }
        }

        /// <summary>
        /// The property to get/set the current value of the ProgressBar.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throw when Current value is less than Min value, or greater than Max value.</exception>
        /// <example>
        /// <code>
        /// ProgressBar progress;
        /// progress.MaxValue = 100;
        /// progress.MinValue = 0;
        /// try
        /// {
        ///     progress.CurrentValue = 50;
        /// }
        /// catch(ArgumentOutOfRangeException e)
        /// {
        ///     Tizen.Log.Error(LogTag, "Failed to set Current value : " + e.Message);
        /// }
        /// </code>
        /// </example>
        public uint? CurrentValue
        {        
            get
            {
                if (currentValue != null)
                {
                    return currentValue.Value;
                }
                return progressBarAttrs.CurValue.Value;
            }
            set
            {
                if (value < minValue || value > maxValue)
                {
                    //TNLog.E("Current value is less than the Min value, or greater than the Max value. value = " + value + ";");
                    throw new ArgumentOutOfRangeException("Wrong Current value. It shoud be greater than the Min value, and less than the Max value!");
                }
                currentValue = value;
                UpdateValue();
            }
        }

        /// <summary>
        /// The property to get/set the buffer value of the ProgressBar.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throw when Buffer value is less than Min value, or greater than Max value.</exception>
        /// <example>
        /// <code>
        /// ProgressBar progress;
        /// progress.MaxValue = 100;
        /// progress.MinValue = 0;
        /// try
        /// {
        ///     progress.BufferValue = 50;
        /// }
        /// catch(ArgumentOutOfRangeException e)
        /// {
        ///     Tizen.Log.Error(LogTag, "Failed to set Buffer value : " + e.Message);
        /// }
        /// </code>
        /// </example>
        public uint BufferValue
        {
            get
            {
                return bufferValue.Value;
            }
            set
            {
                if (value < minValue || value > maxValue)
                {
                    //TNLog.E("Buffer value is less than the Min value, or greater than the Max value. value = " + value + ";");
                    throw new ArgumentOutOfRangeException("Wrong Buffer value. It shoud be greater than the Min value, and less than the Max value!");
                }
                bufferValue = value;
                UpdateValue();
            }
        }

        public ProgressStatusType? ProgressState
        {
            get
            {
                if (state != null)
                    return state.Value;
                else
                    return null;
            }
            set
            {
                state = value;
                UpdateStates();
            }
        }

        /// <summary>
        /// Dispose ProgressBar.
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
                if (trackObj != null)
                {
                    Remove(trackObj);
                    trackObj.Dispose();
                    trackObj = null;
                }

                if (progressObj != null)
                {
                    Remove(progressObj);
                    progressObj.Dispose();
                    progressObj = null;
                }

                if (bufferObj != null)
                {
                    Remove(bufferObj);
                    bufferObj.Dispose();
                    bufferObj = null;
                }

                if (loadingObj != null)
                {
                    Remove(loadingObj);
                    loadingObj.Dispose();
                    loadingObj = null;
                }

                ///if (aniForLoading != null)
                ///{
                ///    aniForLoading.Stop();
                ///    aniForLoading.Clear();
                ///    aniForLoading.Dispose();
                ///    aniForLoading = null;
                ///}

                ///if (aniForOpacity != null)
                ///{
                ///    aniForOpacity.Stop();
                ///    aniForOpacity.Clear();
                ///    aniForOpacity.Dispose();
                ///    aniForOpacity = null;
                ///}
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
            if (progressBarAttrs == null)
            {
                return;
            }

            ApplyAttributes(this, progressBarAttrs);
            ApplyAttributes(trackObj, progressBarAttrs.TrackImageAttributes);
            ApplyAttributes(progressObj, progressBarAttrs.ProgressImageAttributes);
            ApplyAttributes(loadingObj, progressBarAttrs.LoadingImageAttributes);
            ApplyAttributes(bufferObj, progressBarAttrs.BufferImageAttributes);
        }

        private void Initialize()
        {
            // create necessary components
            InitializeTrack();
            InitializeBuffer();
            InitializeProgress();
            InitializeLoading();
        }

        private void InitializeTrack()
        {
            trackObj = new ImageView
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft
            };
            Add(trackObj);
        }

        private void InitializeProgress()
        {
            //TNLog.I("create progress object");
            progressObj = new ImageView
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft
            };
            Add(progressObj);
        }

        private void InitializeBuffer()
        {

                bufferObj = new ImageView
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft
                };
                Add(bufferObj);
            
        }

        private void InitializeLoading()
        {
            if (loadingObj == null)
            {
                loadingObj = new ImageView
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft
                };
                Add(loadingObj);
            }
        }

        //private void InitializeLoading()
        //{
        //    if (loadingObj == null && (_style == ProgressStyle.WhiteBuffering || _style == ProgressStyle.BlackBuffering))
        //    {
        //        //TNLog.I("create loading object");
        //        ClippingMode = ClippingModeType.ClipToBoundingBox;

        //        loadingObj = new ImageView
        //        {
        //            WidthResizePolicy = ResizePolicyType.Fixed,
        //            HeightResizePolicy = ResizePolicyType.Fixed,
        //            PositionUsesPivotPoint = true,
        //            ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
        //            PivotPoint = Tizen.NUI.PivotPoint.TopLeft
        //        };
        //        Add(loadingObj);
        //    }
        //}

        private void InitializeAnimation()
        {
            //if (progressBarAttrs.style == ProgressStyle.WhiteBuffering || progressBarAttrs.style == ProgressStyle.BlackBuffering)
            //{
            //    if (aniForLoading == null)
            //    {
            //        //TNLog.I("create animation for loading");
            //        aniForLoading = new AnimationPlayer();
            //        aniForLoading.Looping = true;
            //    }
            //    if (aniForOpacity == null)
            //    {
            //        //TNLog.I("create animation for opacity");
            //        aniForOpacity = new AnimationPlayer();
            //    }
            //}
        }

        //protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        //{
        //    ProgressBarAttributes tempAttributes = StyleManager.Instance.GetAttributes(style) as ProgressBarAttributes;
        //    if (tempAttributes != null)
        //    {
        //        attributes = progressBarAttrs = tempAttributes;
        //        RelayoutRequest();
        //    }
        //}

        private void UpdateAnimation()//Attributes attrs)
        {
            if (animationAttrs == null)
            {
                return;
            }
            if (animationAttrs == null)
            {
                //TNLog.I("animationAttrs == null");
                animationAttrs = new AnimationAttributes();
            }
            if (animationAttrs.Part1Duration != null)
            {
                animationAttrs.Part1Duration = animationAttrs.Part1Duration;
            }
            if (animationAttrs.Part2Duration != null)
            {
                animationAttrs.Part2Duration = animationAttrs.Part2Duration;
            }
            if (animationAttrs.OpacityMin != null)
            {
                animationAttrs.OpacityMin = animationAttrs.OpacityMin;
            }
            if (animationAttrs.OpacityMax != null)
            {
                animationAttrs.OpacityMax = animationAttrs.OpacityMax;
            }
            if (animationAttrs.OffsetX != null)
            {
                animationAttrs.OffsetX = animationAttrs.OffsetX;
            }
        }

        //private void ApplyAttributes()
        //{
        //    ApplyTrack();
        //    ApplyProgress();
        //    ApplyBuffer();
        //    ApplyLoadingAnimation();
        //    UpdateStates();
        //    //UpdateEnabled();
        //}

        private void ApplyTrack()
        {
            if (trackObj == null)
            {
                return;
            }
            if (trackURL != null)
            {
                trackObj.ResourceUrl = trackURL;
            }
            else
            {
                if (TrackImageURL != null)
                {
                    trackObj.ResourceUrl = TrackImageURL;
                }
            }

            if (trackColor != null)
            {
                float r = trackColor.R;
                float g = trackColor.G;
                float b = trackColor.B;
                float a = trackColor.A;
                trackObj.BackgroundColor = new Color(r, g, b, a);
            }
            else
            {
                if (TrackColor != null)
                {
                    float r = TrackColor.R;
                    float g = TrackColor.G;
                    float b = TrackColor.B;
                    float a = TrackColor.A;
                    trackObj.BackgroundColor = new Color(r, g, b, a);
                }
            }
        }

        private void ApplyProgress()
        {
            if (progressObj == null)
            {
                return;
            }
            if (progressImageURL != null)
            {
                //progressObj.ResourceUrl = progressURL;
            }
            else
            {
                if (progressImageURL != null)
                {
                    progressObj.ResourceUrl = progressImageURL;
                }
            }

            if (progressColor != null)
            {
                float r = progressColor.R;
                float g = progressColor.G;
                float b = progressColor.B;
                float a = progressColor.A;
                progressObj.BackgroundColor = new Color(r, g, b, a);
            }
            else
            {
                if (ProgressColor != null)
                {
                    float r = ProgressColor.R;
                    float g = ProgressColor.G;
                    float b = ProgressColor.B;
                    float a = ProgressColor.A;
                    progressObj.BackgroundColor = new Color(r, g, b, a);
                }
            }
        }

        private void ApplyBuffer()
        {
            InitializeBuffer();

            if (bufferObj == null)
            {
                return;
            }

            if (bufferURL != null)
            {
                bufferObj.ResourceUrl = bufferURL;
            }
            else
            {
                if (BufferImageURL != null)
                {
                    bufferObj.ResourceUrl = BufferImageURL;
                }
            }

            if (bufferColor != null)
            {
                float r = bufferColor.R;
                float g = bufferColor.G;
                float b = bufferColor.B;
                float a = bufferColor.A;
                bufferObj.BackgroundColor = new Color(r, g, b, a);
            }
            else
            {
                if (BufferColor != null)
                {
                    float r = BufferColor.R;
                    float g = BufferColor.G;
                    float b = BufferColor.B;
                    float a = BufferColor.A;
                    bufferObj.BackgroundColor = new Color(r, g, b, a);
                }
            }
        }

        private void ApplyLoadingAnimation()
        {
            //InitializeLoading();
            InitializeAnimation();
            if (loadingObj == null)// || aniForLoading == null || aniForOpacity == null)
            {
                return;
            }
            if (loadingImageURL != null)
            {
                string url = loadingImageURL;
                loadingObj.ResourceUrl = url;
            }
        }

        protected virtual void UpdateStates()
        {
            Console.WriteLine("before update progress" + progressObj.Size2D.Height.ToString() + progressObj.Size2D.Width.ToString());
            Console.WriteLine("before update load" + loadingObj.Size2D.Height.ToString() + loadingObj.Size2D.Width.ToString());
            Console.WriteLine(bufferObj.ResourceUrl);
            Console.WriteLine("before update buffer" + bufferObj.Size2D.Height.ToString() + bufferObj.Size2D.Width.ToString());

            if (state == ProgressStatusType.Buffering)
            {
                bufferObj.Show();
                loadingObj.Hide();
                progressObj.Hide();
            }
            else if (state == ProgressStatusType.Determinate)
            {
                bufferObj.Hide();
                loadingObj.Hide();
                progressObj.Show();
                UpdateValue();
            }
            else
            {
                bufferObj.Hide();
                loadingObj.Show();
                progressObj.Hide();
            }
            //if (aniForLoading != null)
            //{
            //    aniForLoading.Stop();
            //    aniForLoading.Clear();
            //}
            //if (aniForOpacity != null)
            //{
            //    aniForOpacity.Stop();
            //    aniForOpacity.Clear();
            //}
            //PlayLoadingAnimation();
        }


        private void PlayLoadingAnimation()
        {
            if (loadingObj == null)// || aniForLoading == null || aniForOpacity == null)
            {
                return;
            }
            int rootWidth = Size2D.Width;
            int rootHeight = Size2D.Height;
            //TNLog.I("rootWidth = " + rootWidth + ", rootHeight = " + rootHeight);
            float offsetX = 0;
            uint part1Duration = 0;
            uint part2Duration = 0;
            float opacityMin = 0;
            float opacityMax = 1.0f;
            if (animationAttrs != null)
            {
                if (animationAttrs.OffsetX != null)
                {
                    offsetX = animationAttrs.OffsetX.Value;
                }
                if (animationAttrs.Part1Duration != null)
                {
                    part1Duration = animationAttrs.Part1Duration.Value;
                }
                if (animationAttrs.Part2Duration != null)
                {
                    part2Duration = animationAttrs.Part2Duration.Value;
                }
                if (animationAttrs.OpacityMin != null)
                {
                    opacityMin = animationAttrs.OpacityMin.Value;
                }
                if (animationAttrs.OpacityMax != null)
                {
                    opacityMax = animationAttrs.OpacityMax.Value;
                }
            }
            //TNLog.I("offsetX = " + offsetX);
            loadingObj.Size2D = new Size2D(rootWidth + (int)offsetX, rootHeight);
            loadingObj.Position = new Position(-offsetX, 0, 0);

            int duration = (int)(part1Duration + part2Duration);
            //TNLog.I("Duration = " + duration);
            //aniForLoading.Duration = duration;
            //aniForLoading.AnimateTo(loadingObj, "PositionX", 0, 0, duration, AnimationCurve.Basic);

            loadingObj.Opacity = opacityMin;
            //aniForOpacity.AnimateTo(loadingObj, "Opacity", opacityMax, 0, (int)part1Duration, AnimationCurve.Basic);

            //aniForLoading.Play();
            //aniForOpacity.Play();
        }

        protected virtual void UpdateValue()
        {
            if (trackObj == null || progressObj == null ||
                (progressBarAttrs.MaxValue == null && maxValue == null) ||
                (progressBarAttrs.MinValue == null && minValue == null) ||
                (progressBarAttrs.CurValue == null && currentValue == null))
            {
                return;
            }

            int minVal = 0;
            if (minValue != null)
            {
                minVal = (int)minValue;
            }
            else
            {
                if (progressBarAttrs.MinValue != null)
                {
                    minVal = (int)progressBarAttrs.MinValue;
                }

            }
            int maxVal = 0;
            if (maxValue != null)
            {
                maxVal = (int)maxValue;
            }
            else
            {
                if (progressBarAttrs.MaxValue != null)
                {
                    maxVal = (int)progressBarAttrs.MaxValue;
                }
            }
            int curVal = 0;
            if (currentValue != null)
            {
                curVal = (int)currentValue;
            }
            else
            {
                if (progressBarAttrs.CurValue != null)
                {
                    curVal = (int)progressBarAttrs.CurValue;
                }
            }

            //TNLog.I("minValue = " + minVal + ", maxValue = " + maxVal + ", curValue = " + curVal);

            if (minVal >= maxVal || curVal < minVal || curVal > maxVal)
            {
                if (minVal >= maxVal)
                {
                    //TNLog.E("Min value >= Max value;");
                }
                if (curVal < minVal || curVal > maxVal)
                {
                    //TNLog.E("Current value < Min value || Current value > Max value;");
                }
                return;
            }

            float width = SizeWidth;
            float height = SizeHeight;
            //TNLog.I("width = " + width + ", height = " + height);
            float progressRatio = (float)curVal / (float)(maxVal - minVal);
            DirectionType dir = DirectionType.Horizontal;
            if (direction != null)
            {
                dir = direction.Value;
            }
            else
            {
                if (direction != null)
                {
                    dir = direction.Value;
                }
            }
            //TNLog.I("Direction = " + dir);
            if (dir == DirectionType.Horizontal)
            {
                float progressWidth = width * progressRatio;
                progressObj.Size2D = new Size2D((int)progressWidth, (int)height);
                //TNLog.I("progressWidth = " + progressWidth);
            }
            else
            {
                float progressHeight = height * progressRatio;
                progressObj.Size2D = new Size2D((int)width, (int)progressHeight);
                //TNLog.I("progressHeight = " + progressHeight);
            }

            if (bufferObj != null && (BufValue != null || bufferValue != null))
            {
                int bufVal = 0;
                if (bufferValue != null)
                {
                    bufVal = (int)bufferValue;
                }
                else
                {
                    if (BufValue != null)
                    {
                        bufVal = (int)BufValue;
                    }
                }
                if (bufVal < minVal || bufVal > maxVal)
                {
                    //TNLog.E("Buffer value < Min value || Buffer value > Max value;");
                    return;
                }
                //TNLog.I("Buffer value = " + bufVal);

                float bufferRatio = (float)bufVal / (float)(maxVal - minVal);
                if (dir == DirectionType.Horizontal)
                {
                    float bufferWidth = width * bufferRatio;
                    bufferObj.Size2D = new Size2D((int)bufferWidth, (int)height);
                    //TNLog.I("bufferWidth = " + bufferWidth + ";");
                }
                else
                {
                    float bufferHeight = height * bufferRatio;
                    bufferObj.Size2D = new Size2D((int)width, (int)bufferHeight);
                    //TNLog.I("bufferHeight = " + bufferHeight + ";");
                }
            }
        }

    }
}
