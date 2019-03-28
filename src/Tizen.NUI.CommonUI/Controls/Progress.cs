using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI.CommonUI
{    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Progress : Control
    {    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ProgressBarAttributes progressBarAttrs = null;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)] protected ImageView trackObj = null;
        protected ImageView progressObj = null;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)] protected ImageView bufferObj = null;
        protected ImageView loadingObj = null;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)] protected bool isEnabled = true;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected uint? minValue = null;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)] protected uint? maxValue = null;
        protected uint? currentValue = null;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)] protected uint? bufferValue = null;
        protected Color trackColor = null;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)] protected Color progressColor = null;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)] protected Color bufferColor = null;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)] protected ProgressStatusType? state = null;
        public uint? BufValue
        {
            get
            {
                return bufferValue;
            }
            set
            {
                bufferValue = value;
                UpdateValue();
            }
        }

        /// <summary>
        /// The constructor of ProgressBar
        /// </summary>
        /// <version> 5.5.0 </version>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Progress() : base()
        {
            progressBarAttrs = attributes as ProgressBarAttributes;
            Initialize();
        }

        /// <summary>
        /// The constructor of the ProgressBar class with specific Attributes.
        /// </summary>
        /// <param name="attrs">The Attributes object to initialize the ProgressBar.</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Progress(string style) : base(style)
        {
            if (attributes != null)
            {
                progressBarAttrs = attributes as ProgressBarAttributes;
            }

            Initialize();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Progress(ProgressBarAttributes attributes) : base()
        {
            this.attributes = progressBarAttrs = attributes.Clone() as ProgressBarAttributes;
            Initialize();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ProgressStatusType
        {    
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Buffering,   //TrackImage
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Determinate, //ProgressImage
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Indeterminate//loading
        }

        /// <summary>
        /// The direction type of the ProgressBar.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum DirectionType
        {
            /// <summary> The progress moving follow horizontal direction. </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)] Horizontal,
            /// <summary> The progress moving follow vertical direction. </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)] Vertical
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual string ProgressImageURLPre
        {
            get
            {
                if (progressBarAttrs.ProgressImageURLPrefix == null)
                {
                    progressBarAttrs.ProgressImageURLPrefix = new StringSelector();
                }
                return progressBarAttrs.ProgressImageURLPrefix.All;
            }
            set
            {
                if (progressBarAttrs.ProgressImageURLPrefix == null)
                {
                    progressBarAttrs.ProgressImageURLPrefix = new StringSelector();
                }
                progressBarAttrs.ProgressImageURLPrefix.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property to get/set Track image object URL of the ProgressBar.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string TrackImageURL
        {
            get
            {
                if (progressBarAttrs.TrackImageAttributes.ResourceURL == null)
                {
                    progressBarAttrs.TrackImageAttributes.ResourceURL = new StringSelector();
                }
                return progressBarAttrs.TrackImageAttributes.ResourceURL.All;
            }
            set
            {
                if (progressBarAttrs.TrackImageAttributes.ResourceURL == null)
                {
                    progressBarAttrs.TrackImageAttributes.ResourceURL = new StringSelector();
                }
                progressBarAttrs.TrackImageAttributes.ResourceURL.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property to get/set Progress object image URL of the ProgressBar.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProgressImageURL
        {
            get
            {
                if (progressBarAttrs.ProgressImageAttributes.ResourceURL == null)
                {
                    progressBarAttrs.ProgressImageAttributes.ResourceURL = new StringSelector();
                }
                return progressBarAttrs.ProgressImageAttributes.ResourceURL.All;
            }
            set
            {
                if (progressBarAttrs.ProgressImageAttributes.ResourceURL == null)
                {
                    progressBarAttrs.ProgressImageAttributes.ResourceURL = new StringSelector();
                }
                progressBarAttrs.ProgressImageAttributes.ResourceURL.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property to get/set Buffer object image URL of the ProgressBar.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BufferImageURL
        {
            get
            {
                if (progressBarAttrs.BufferImageAttributes.ResourceURL == null)
                {
                    progressBarAttrs.BufferImageAttributes.ResourceURL = new StringSelector();
                }
                return progressBarAttrs.BufferImageAttributes.ResourceURL.All;
            }
            set
            {
                if (progressBarAttrs.BufferImageAttributes.ResourceURL == null)
                {
                    progressBarAttrs.BufferImageAttributes.ResourceURL = new StringSelector();
                }
                progressBarAttrs.BufferImageAttributes.ResourceURL.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property to get/set Track object color of the ProgressBar.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// The property to get/set Direction of the ProgressBar.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            ProgressBarAttributes tempAttributes = StyleManager.Instance.GetAttributes(style) as ProgressBarAttributes;
            if (tempAttributes != null)
            {
                attributes = progressBarAttrs = tempAttributes;
                RelayoutRequest();
            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

            float progressRatio = (float)curVal / (float)(maxVal - minVal);
            DirectionType dir = DirectionType.Horizontal;
            //if (progressBarAttrs.Direction != null)
            //{
            //    dir = direction.Value;
            //}
            //else
            //{
            //    if (direction != null)
            //    {
            //        dir = direction.Value;
            //    }
            //}

            if (dir == DirectionType.Horizontal)
            {
                float progressWidth = width * progressRatio;
                progressObj.Size2D = new Size2D((int)progressWidth, (int)height);
            }
            else
            {
                float progressHeight = height * progressRatio;
                progressObj.Size2D = new Size2D((int)width, (int)progressHeight);
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new ProgressBarAttributes
            {
                TrackImageAttributes = new ImageAttributes
                {
                },
                ProgressImageAttributes = new ImageAttributes
                {
                },
                BufferImageAttributes = new ImageAttributes
                {
                },
                LoadingImageAttributes = new ImageAttributes
                {
                }

            };
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

        private void ApplyTrack()
        {
            if (trackObj == null)
            {
                return;
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

        }
    }
}
