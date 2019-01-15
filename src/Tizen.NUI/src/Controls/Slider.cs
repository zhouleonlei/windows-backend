using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Controls
{
    public class Slider : Control
    {
        private ImageView bgTrack = null;
        private ImageView slidedTrack = null;
        private ImageView thumb = null;
        private ImageView thumbBg = null;
        private ImageView lowIndicatorImage = null;
        private ImageView highIndicatorImage = null;
        private TextLabel lowIndicatorText = null;
        private TextLabel highIndicatorText = null;

        private SliderAttributes sliderAttrs = null;

        private DirectionType direction = DirectionType.Horizontal;
        private int? minValue = null;
        private int? maxValue = null;
        private int? curValue = null;
        private Size2D thumbSize = null;
        private string thumbImageURL = string.Empty;
        private uint? trackThickness = null;
        private uint? spaceBetweenTrackAndIndicator = null;
        private Color bgTrackColor = null;
        private Color slidedTrackColor = null;
        private string lowIndicatorImageURL = null;
        private string highIndicatorImageURL = null;
        private string lowIndicatorTextStr = null;
        private string highIndicatorTextStr = null;
        private Size2D lowIndicatorSize = null;
        private Size2D highIndicatorSize = null;

        private PanGestureDetector panGestureDetector = null;
        private float currentSlidedOffset;
        private EventHandler<ValueChangedArgs> valueChangedHandler;
        private EventHandler<StateChangedArgs> stateChangedHandler;

        bool isFocused = false;
        bool isPressed = false;

        static Slider()
        {
            RegisterStyle("DefaultSlider", typeof(SliderAttributes));
        }

        public Slider() : this("DefaultSlider")
        {
            Initialize();
        }

        public Slider(string style) : base(style)
        {
            Initialize();
        }

        public event EventHandler<ValueChangedArgs> ValueChangedEvent
        {
            add
            {
                valueChangedHandler += value;
            }
            remove
            {
                valueChangedHandler -= value;
            }
        }

        public event EventHandler<StateChangedArgs> StateChangedEvent
        {
            add
            {
                stateChangedHandler += value;
            }
            remove
            {
                stateChangedHandler -= value;
            }
        }

        public enum DirectionType
        {
            Horizontal,
            Vertical
        }

        public enum IndicatorType
        {
            /// <summary> Only contains slider bar.</summary>
            None,
            /// <summary> Contains slider bar, IndicatorImage.</summary>
            Image,
            /// <summary> Contains slider bar, IndicatorText.</summary>
            Text
        }

        public DirectionType Direction
        {
            get
            {
                return direction;
            }
            set
            {
                if (direction == value)
                {
                    return;
                }
                direction = value;
                RelayoutBaseComponent(false);
                UpdateBgTrackSize();
                UpdateBgTrackPosition();
                UpdateValue();
            }
        }

        public int MinValue
        {
            get
            {
                return minValue.Value;
            }
            set
            {
                minValue = value;
                UpdateValue();
            }
        }

        public int MaxValue
        {
            get
            {
                return maxValue.Value;
            }
            set
            {
                maxValue = value;
                UpdateValue();
            }
        }

        public int CurrentValue
        {
            get
            {
                return curValue.Value;
            }
            set
            {
                curValue = value;
                UpdateValue();
            }
        }

        public Size2D ThumbSize
        {
            get
            {
                return thumbSize;
            }
            set
            {
                thumbSize = value;
                if (thumbBg != null && thumbSize != null)
                {
                    thumbBg.Size2D = thumbSize;
                }
            }
        }

        public string ThumbImageURL
        {
            get { return thumbImageURL; }
            set
            {
                thumbImageURL = value;
                if (thumb != null && thumbImageURL != null)
                {
                    thumb.ResourceUrl = thumbImageURL;
                }
            }
        }

        public Color BgTrackColor
        {
            get
            {
                return bgTrackColor;
            }
            set
            {
                bgTrackColor = value;
                if (bgTrack != null && bgTrackColor != null)
                {
                    bgTrack.BackgroundColor = bgTrackColor;
                }
            }
        }

        public Color SlidedTrackColor
        {
            get
            {
                return slidedTrackColor;
            }
            set
            {
                slidedTrackColor = value;
                if (slidedTrack != null && slidedTrackColor != null)
                {
                    slidedTrack.BackgroundColor = slidedTrackColor;
                }
            }
        }

        public uint TrackThickness
        {
            get
            {
                return trackThickness.Value;
            }
            set
            {
                trackThickness = value;
                if (bgTrack != null)
                {
                    if (direction == DirectionType.Horizontal)
                    {
                        bgTrack.SizeHeight = (float)trackThickness.Value;
                    }
                    else if (direction == DirectionType.Vertical)
                    {
                        bgTrack.SizeWidth = (float)trackThickness.Value;
                    }
                }
                if (slidedTrack != null)
                {
                    if (direction == DirectionType.Horizontal)
                    {
                        slidedTrack.SizeHeight = (float)trackThickness.Value;
                    }
                    else if (direction == DirectionType.Vertical)
                    {
                        slidedTrack.SizeWidth = (float)trackThickness.Value;
                    }
                }
            }
        }

        public string LowIndicatorImageURL
        {
            get
            {
                return lowIndicatorImageURL;
            }
            set
            {
                lowIndicatorImageURL = value;
                if (lowIndicatorImage != null && lowIndicatorImageURL != null)
                {
                    lowIndicatorImage.ResourceUrl = lowIndicatorImageURL;
                }
            }
        }

        public string HighIndicatorImageURL
        {
            get
            {
                return highIndicatorImageURL;
            }
            set
            {
                highIndicatorImageURL = value;
                if (highIndicatorImage != null && highIndicatorImageURL != null)
                {
                    highIndicatorImage.ResourceUrl = highIndicatorImageURL;
                }
            }
        }

        public string LowIndicatorTextStr
        {
            get
            {
                return lowIndicatorTextStr;
            }
            set
            {
                lowIndicatorTextStr = value;
                if (lowIndicatorText != null && lowIndicatorTextStr != null)
                {
                    lowIndicatorText.Text = lowIndicatorTextStr;
                }
            }
        }

        public string HighIndicatorTextStr
        {
            get
            {
                return highIndicatorTextStr;
            }
            set
            {
                highIndicatorTextStr = value;
                if (highIndicatorText != null && highIndicatorTextStr != null)
                {
                    highIndicatorText.Text = highIndicatorTextStr;
                }
            }
        }

        public Size2D LowIndicatorSize
        {
            get
            {
                return lowIndicatorSize;
            }
            set
            {
                lowIndicatorSize = value;
                UpdateLowIndicatorSize();
                UpdateBgTrackSize();
                UpdateBgTrackPosition();
                UpdateValue();
            }
        }

        public Size2D HighIndicatorSize
        {
            get
            {
                return highIndicatorSize;
            }
            set
            {
                highIndicatorSize = value;
                UpdateHighIndicatorSize();
                UpdateBgTrackSize();
                UpdateBgTrackPosition();
                UpdateValue();
            }
        }

        public uint SpaceBetweenTrackAndIndicator
        {
            get
            {
                return spaceBetweenTrackAndIndicator.Value;
            }
            set
            {
                spaceBetweenTrackAndIndicator = value;
                UpdateComponentByIndicatorTypeChanged();
                UpdateBgTrackSize();
                UpdateBgTrackPosition();
                UpdateValue();
            }
        }

        protected override void OnFocusGained(object sender, EventArgs e)
        {
            //State = States.Focused;
            UpdateState(true, isPressed);
            base.OnFocusGained(sender, e);
        }
        protected override void OnFocusLost(object sender, EventArgs e)
        {
            //State = States.Normal;
            UpdateState(false, isPressed);
            base.OnFocusLost(sender, e);
        }

        protected override Attributes GetAttributes()
        {
            return null;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (panGestureDetector != null)
                {
                    if (thumb != null)
                    {
                        panGestureDetector.Detach(thumb);
                    }
                    panGestureDetector.Detected -= OnPanGestureDetected;
                    panGestureDetector.Dispose();
                    panGestureDetector = null;
                }
                
                if (thumb != null && thumbBg != null)
                {
                    thumb.TouchEvent -= OnTouchEventForThumb;
                    thumbBg.Remove(thumb);
                    thumb.Dispose();
                    thumb = null;
                }
                if (thumbBg != null && slidedTrack != null)
                {
                    slidedTrack.Remove(thumbBg);
                    thumbBg.Dispose();
                    thumbBg = null;
                }
                if (slidedTrack != null && bgTrack != null)
                {
                    bgTrack.Remove(slidedTrack);
                    slidedTrack.Dispose();
                    slidedTrack = null;
                }
                if (bgTrack != null)
                {
                    bgTrack.TouchEvent -= OnTouchEventForBgTrack;
                    this.Remove(bgTrack);
                    bgTrack.Dispose();
                    bgTrack = null;
                }
                if (lowIndicatorImage != null)
                {
                    this.Remove(lowIndicatorImage);
                    lowIndicatorImage.Dispose();
                    lowIndicatorImage = null;
                }
                if (highIndicatorImage != null)
                {
                    this.Remove(highIndicatorImage);
                    highIndicatorImage.Dispose();
                    highIndicatorImage = null;
                }
                if (lowIndicatorText != null)
                {
                    this.Remove(lowIndicatorText);
                    lowIndicatorText.Dispose();
                    lowIndicatorText = null;
                }
                if (highIndicatorText != null)
                {
                    this.Remove(highIndicatorText);
                    highIndicatorText.Dispose();
                    highIndicatorText = null;
                }
            }

            base.Dispose(type);
        }

        protected override void OnUpdate(Attributes attributtes)
        {
            sliderAttrs = attributes as SliderAttributes;
            if (sliderAttrs == null)
            {
                return;
            }
            ApplyAttributes(this, sliderAttrs);

            ApplyAttributes(bgTrack, sliderAttrs.BgTrackAttributes);
            ApplyAttributes(slidedTrack, sliderAttrs.SlidedTrackAttributes);
            ApplyAttributes(thumbBg, sliderAttrs.ThumbBgAttributes);
            ApplyAttributes(thumb, sliderAttrs.ThumbAttributes);
            ApplyAttributes(lowIndicatorImage, sliderAttrs.LowIndicatorImageAttributes);
            ApplyAttributes(highIndicatorImage, sliderAttrs.HighIndicatorImageAttributes);
            ApplyAttributes(lowIndicatorText, sliderAttrs.LowIndicatorTextAttributes);
            ApplyAttributes(highIndicatorText, sliderAttrs.HighIndicatorTextAttributes);

            UpdateComponentByIndicatorTypeChanged();
            UpdateBgTrackSize();
            UpdateBgTrackPosition();
            UpdateLowIndicatorSize();
            UpdateHighIndicatorSize();
            UpdateValue();
        }

        private void Initialize()
        {
            sliderAttrs = attributes as SliderAttributes;
            if (sliderAttrs == null)
            {
                throw new Exception("Fail to parse the slider attributes.");
            }

            if (sliderAttrs.BgTrackAttributes != null && bgTrack == null)
            {
                bgTrack = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed
                };
                this.Add(bgTrack);
                bgTrack.TouchEvent += OnTouchEventForBgTrack;
            }
            if (sliderAttrs.SlidedTrackAttributes != null && slidedTrack == null)
            {
                slidedTrack = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed
                };
                if (bgTrack != null)
                {
                    bgTrack.Add(slidedTrack);
                }
            }
            if (sliderAttrs.ThumbBgAttributes != null && thumbBg == null)
            {
                thumbBg = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed
                };
                if (slidedTrack != null)
                {
                    slidedTrack.Add(thumbBg);
                }
                //thumb.TouchEvent += OnTouchEventForThumb;
            }
            if (sliderAttrs.ThumbAttributes != null && thumb == null)
            {
                thumb = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    ParentOrigin = NUI.ParentOrigin.Center,
                    PivotPoint = NUI.PivotPoint.Center,
                    PositionUsesPivotPoint = true
                };
                if (thumbBg != null)
                {
                    thumbBg.Add(thumb);
                }
                thumb.TouchEvent += OnTouchEventForThumb;
            }
            if (sliderAttrs.LowIndicatorImageAttributes != null && lowIndicatorImage == null)
            {
                lowIndicatorImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed
                };
                this.Add(lowIndicatorImage);
            }
            if (sliderAttrs.HighIndicatorImageAttributes != null && highIndicatorImage == null)
            {
                highIndicatorImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed
                };
                this.Add(highIndicatorImage);
            }
            if (sliderAttrs.LowIndicatorTextAttributes != null && lowIndicatorText == null)
            {
                lowIndicatorText = new TextLabel()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed
                };
                this.Add(lowIndicatorText);
            }
            if (sliderAttrs.HighIndicatorTextAttributes != null && highIndicatorText == null)
            {
                highIndicatorText = new TextLabel()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed
                };
                this.Add(highIndicatorText);
            }
            panGestureDetector = new PanGestureDetector();
            panGestureDetector.Attach(thumb);
            panGestureDetector.Detected += OnPanGestureDetected;
            RelayoutBaseComponent();

            currentSlidedOffset = 0;
            isFocused = false;
            isPressed = false;
        }

        private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            //Console.WriteLine("-------, e.PanGesture.State = " + e.PanGesture.State);
            if (e.PanGesture.State == Gesture.StateType.Started)
            {
                if (direction == DirectionType.Horizontal)
                {
                    currentSlidedOffset = slidedTrack.SizeWidth;
                }
                else if (direction == DirectionType.Vertical)
                {
                    currentSlidedOffset = slidedTrack.SizeHeight;
                }
                //State = States.Pressed;
                UpdateState(isFocused, true);
            }

            if (e.PanGesture.State == Gesture.StateType.Continuing || e.PanGesture.State == Gesture.StateType.Started)
            {
                if (direction == DirectionType.Horizontal)
                {
                    CalculateCurrentValueByGesture(e.PanGesture.Displacement.X);
                }
                else if (direction == DirectionType.Vertical)
                {
                    CalculateCurrentValueByGesture(-e.PanGesture.Displacement.Y);
                }
                UpdateValue();
            }

            if (e.PanGesture.State == Gesture.StateType.Finished)
            {
                //Console.WriteLine("-------, State == Gesture.StateType.Finished");
                //State = States.Pressed;
                UpdateState(isFocused, false);
            }
        }

        public class ValueChangedArgs : EventArgs
        {
            public int CurrentValue;
        }

        public class StateChangedArgs : EventArgs
        {
            public States CurrentState;
        }

        // Only relayout basic component: track and thumb
        private void RelayoutBaseComponent(bool isInitial = true)
        {
            if (direction == DirectionType.Horizontal)
            {
                if (slidedTrack != null)
                {
                    slidedTrack.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                    slidedTrack.PivotPoint = NUI.PivotPoint.CenterLeft;
                    slidedTrack.PositionUsesPivotPoint = true;
                }
                if (thumbBg != null)
                {
                    thumbBg.ParentOrigin = NUI.ParentOrigin.CenterRight;
                    thumbBg.PivotPoint = NUI.PivotPoint.Center;
                    thumbBg.PositionUsesPivotPoint = true;
                }
                if (lowIndicatorImage != null)
                {
                    lowIndicatorImage.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                    lowIndicatorImage.PivotPoint = NUI.PivotPoint.CenterLeft;
                    lowIndicatorImage.PositionUsesPivotPoint = true;
                }
                if (highIndicatorImage != null)
                {
                    highIndicatorImage.ParentOrigin = NUI.ParentOrigin.CenterRight;
                    highIndicatorImage.PivotPoint = NUI.PivotPoint.CenterRight;
                    highIndicatorImage.PositionUsesPivotPoint = true;
                }
                if (lowIndicatorText != null)
                {
                    lowIndicatorText.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                    lowIndicatorText.PivotPoint = NUI.PivotPoint.CenterLeft;
                    lowIndicatorText.PositionUsesPivotPoint = true;
                }
                if (highIndicatorText != null)
                {
                    highIndicatorText.ParentOrigin = NUI.ParentOrigin.CenterRight;
                    highIndicatorText.PivotPoint = NUI.PivotPoint.CenterRight;
                    highIndicatorText.PositionUsesPivotPoint = true;
                }
                if (panGestureDetector != null)
                {
                    if (!isInitial)
                    {
                        panGestureDetector.RemoveDirection(PanGestureDetector.DirectionVertical);
                    }
                    panGestureDetector.AddDirection(PanGestureDetector.DirectionHorizontal);
                }
            }
            else if (direction == DirectionType.Vertical)
            {
                if (slidedTrack != null)
                {
                    slidedTrack.ParentOrigin = NUI.ParentOrigin.BottomCenter;
                    slidedTrack.PivotPoint = NUI.PivotPoint.BottomCenter;
                    slidedTrack.PositionUsesPivotPoint = true;
                }
                if (thumbBg != null)
                {
                    thumbBg.ParentOrigin = NUI.ParentOrigin.TopCenter;
                    thumbBg.PivotPoint = NUI.PivotPoint.Center;
                    thumbBg.PositionUsesPivotPoint = true;
                }
                if (lowIndicatorImage != null)
                {
                    lowIndicatorImage.ParentOrigin = NUI.ParentOrigin.BottomCenter;
                    lowIndicatorImage.PivotPoint = NUI.PivotPoint.BottomCenter;
                    lowIndicatorImage.PositionUsesPivotPoint = true;
                }
                if (highIndicatorImage != null)
                {
                    highIndicatorImage.ParentOrigin = NUI.ParentOrigin.TopCenter;
                    highIndicatorImage.PivotPoint = NUI.PivotPoint.TopCenter;
                    highIndicatorImage.PositionUsesPivotPoint = true;
                }
                if (lowIndicatorText != null)
                {
                    lowIndicatorText.ParentOrigin = NUI.ParentOrigin.BottomCenter;
                    lowIndicatorText.PivotPoint = NUI.PivotPoint.BottomCenter;
                    lowIndicatorText.PositionUsesPivotPoint = true;
                }
                if (highIndicatorText != null)
                {
                    highIndicatorText.ParentOrigin = NUI.ParentOrigin.TopCenter;
                    highIndicatorText.PivotPoint = NUI.PivotPoint.TopCenter;
                    highIndicatorText.PositionUsesPivotPoint = true;
                }
                if (panGestureDetector != null)
                {
                    if (!isInitial)
                    {
                        panGestureDetector.RemoveDirection(PanGestureDetector.DirectionHorizontal);
                    }
                    panGestureDetector.AddDirection(PanGestureDetector.DirectionVertical);
                }
            }
        }

        private int BgTrackLength()
        {
            int bgTrackLength = 0;
            int curSpace = (int)CurrentSpaceBetweenTrackAndIndicator();
            Size2D lowIndicatorImageSize = LowIndicatorImageSize();
            Size2D highIndicatorImageSize = HighIndicatorImageSize();
            Size2D lowIndicatorTextSize = LowIndicatorTextSize();
            Size2D highIndicatorTextSize = HighIndicatorTextSize();
            IndicatorType type = CurrentIndicatorType();

            if (type == IndicatorType.None)
            {
                if (direction == DirectionType.Horizontal)
                {
                    bgTrackLength = this.Size2D.Width;
                }
                else if (direction == DirectionType.Vertical)
                {
                    bgTrackLength = this.Size2D.Height;
                }
            }
            else if (type == IndicatorType.Image)
            {// <lowIndicatorImage> <spaceBetweenTrackAndIndicator> <bgTrack> <spaceBetweenTrackAndIndicator> <highIndicatorImage>
                if (direction == DirectionType.Horizontal)
                {
                    int lowIndicatorSpace = lowIndicatorImageSize.Width == 0 ? (0) : (curSpace + lowIndicatorImageSize.Width);
                    int highIndicatorSpace = highIndicatorImageSize.Width == 0 ? (0) : (curSpace + highIndicatorImageSize.Width);
                    bgTrackLength = this.Size2D.Width - lowIndicatorSpace - highIndicatorSpace;
                }
                else if (direction == DirectionType.Vertical)
                {
                    int lowIndicatorSpace = lowIndicatorImageSize.Height == 0 ? (0) : (curSpace + lowIndicatorImageSize.Height);
                    int highIndicatorSpace = highIndicatorImageSize.Height == 0 ? (0) : (curSpace + highIndicatorImageSize.Height);
                    bgTrackLength = this.Size2D.Height - lowIndicatorSpace - highIndicatorSpace;
                }
            }
            else if (type == IndicatorType.Text)
            {// <lowIndicatorText> <spaceBetweenTrackAndIndicator> <bgTrack> <spaceBetweenTrackAndIndicator> <highIndicatorText>
                if (direction == DirectionType.Horizontal)
                {
                    int lowIndicatorSpace = lowIndicatorTextSize.Width == 0 ? (0) : (curSpace + lowIndicatorTextSize.Width);
                    int highIndicatorSpace = highIndicatorTextSize.Width == 0 ? (0) : (curSpace + highIndicatorTextSize.Width);
                    bgTrackLength = this.Size2D.Width - lowIndicatorSpace - highIndicatorSpace;
                }
                else if (direction == DirectionType.Vertical)
                {
                    int lowIndicatorSpace = lowIndicatorTextSize.Height == 0 ? (0) : (curSpace + lowIndicatorTextSize.Height);
                    int highIndicatorSpace = highIndicatorTextSize.Height == 0 ? (0) : (curSpace + highIndicatorTextSize.Height);
                    bgTrackLength = this.Size2D.Height - lowIndicatorSpace - highIndicatorSpace;
                }
            }
            return bgTrackLength;
        }

        private void UpdateLowIndicatorSize()
        {
            if (lowIndicatorSize != null)
            {
                if (lowIndicatorImage != null)
                {
                    lowIndicatorImage.Size2D = lowIndicatorSize;
                }
                if (lowIndicatorText != null)
                {
                    lowIndicatorText.Size2D = lowIndicatorSize;
                }
            }
            else
            {
                if (lowIndicatorImage != null && sliderAttrs != null && sliderAttrs.LowIndicatorImageAttributes != null && sliderAttrs.LowIndicatorImageAttributes.Size2D != null)
                {
                    lowIndicatorImage.Size2D = sliderAttrs.LowIndicatorImageAttributes.Size2D;
                }
                if (lowIndicatorText != null && sliderAttrs != null && sliderAttrs.LowIndicatorTextAttributes != null && sliderAttrs.LowIndicatorTextAttributes.Size2D != null)
                {
                    lowIndicatorText.Size2D = sliderAttrs.LowIndicatorTextAttributes.Size2D;
                }
            }
        }

        private void UpdateHighIndicatorSize()
        {
            if (highIndicatorSize != null)
            {
                if (highIndicatorImage != null)
                {
                    highIndicatorImage.Size2D = highIndicatorSize;
                }
                if (highIndicatorText != null)
                {
                    highIndicatorText.Size2D = highIndicatorSize;
                }
            }
            else
            {
                if (highIndicatorImage != null && sliderAttrs != null && sliderAttrs.HighIndicatorImageAttributes != null && sliderAttrs.HighIndicatorImageAttributes.Size2D != null)
                {
                    highIndicatorImage.Size2D = sliderAttrs.HighIndicatorImageAttributes.Size2D;
                }
                if (highIndicatorText != null && sliderAttrs != null && sliderAttrs.HighIndicatorTextAttributes != null && sliderAttrs.HighIndicatorTextAttributes.Size2D != null)
                {
                    highIndicatorText.Size2D = sliderAttrs.HighIndicatorTextAttributes.Size2D;
                }
            }
        }

        private void UpdateBgTrackSize()
        {
            int curTrackThickness = (int)CurrentTrackThickness();
            int bgTrackLength = BgTrackLength();
            if (direction == DirectionType.Horizontal)
            {
                bgTrack.Size2D = new Size2D(bgTrackLength, curTrackThickness);
            }
            else if (direction == DirectionType.Vertical)
            {
                bgTrack.Size2D = new Size2D(curTrackThickness, bgTrackLength);
            }
        }

        private void UpdateBgTrackPosition()
        {
            int curSpace = (int)CurrentSpaceBetweenTrackAndIndicator();
            Size2D lowIndicatorImageSize = LowIndicatorImageSize();
            Size2D highIndicatorImageSize = HighIndicatorImageSize();
            Size2D lowIndicatorTextSize = LowIndicatorTextSize();
            Size2D highIndicatorTextSize = HighIndicatorTextSize();
            IndicatorType type = CurrentIndicatorType();

            if (type == IndicatorType.Image)
            {
                if (direction == DirectionType.Horizontal)
                {
                    int lowIndicatorSpace = lowIndicatorImageSize.Width == 0 ? (0) : (curSpace + lowIndicatorImageSize.Width);
                    int highIndicatorSpace = highIndicatorImageSize.Width == 0 ? (0) : (curSpace + highIndicatorImageSize.Width);
                    bgTrack.PositionX = lowIndicatorSpace - (lowIndicatorSpace + highIndicatorSpace) / 2;
                }
                else if (direction == DirectionType.Vertical)
                {
                    int lowIndicatorSpace = lowIndicatorImageSize.Height == 0 ? (0) : (curSpace + lowIndicatorImageSize.Height);
                    int highIndicatorSpace = highIndicatorImageSize.Height == 0 ? (0) : (curSpace + highIndicatorImageSize.Height);
                    bgTrack.PositionY = lowIndicatorSpace - (lowIndicatorSpace + highIndicatorSpace) / 2;
                }
            }
            else if (type == IndicatorType.Text)
            {
                if (direction == DirectionType.Horizontal)
                {
                    int lowIndicatorSpace = lowIndicatorTextSize.Width == 0 ? (0) : (curSpace + lowIndicatorTextSize.Width);
                    int highIndicatorSpace = highIndicatorTextSize.Width == 0 ? (0) : (curSpace + highIndicatorTextSize.Width);
                    bgTrack.PositionX = lowIndicatorSpace - (lowIndicatorSpace + highIndicatorSpace) / 2;
                }
                else if (direction == DirectionType.Vertical)
                {
                    int lowIndicatorSpace = lowIndicatorTextSize.Height == 0 ? (0) : (curSpace + lowIndicatorTextSize.Height);
                    int highIndicatorSpace = highIndicatorTextSize.Height == 0 ? (0) : (curSpace + highIndicatorTextSize.Height);
                    bgTrack.PositionY = -(lowIndicatorSpace - (lowIndicatorSpace + highIndicatorSpace) / 2);
                }
            }
        }

        private void UpdateValue()
        {
            if (curValue == null || minValue == null || maxValue == null)
            {
                return;
            }
            if (curValue < minValue || curValue > maxValue || minValue >= maxValue)
            {
                return;
            }
            
            float ratio = 0;
            if (curValue == minValue)
            {
                ratio = 0;
            }
            else if (curValue == maxValue)
            {
                ratio = 1.0f;
            }
            else
            {
                ratio = (float)(curValue - minValue) / (float)(maxValue - minValue);
            }
            uint curTrackThickness = CurrentTrackThickness();
            float slidedTrackLength = (float)BgTrackLength() * ratio;
            if (direction == DirectionType.Horizontal)
            {
                slidedTrack.Size2D = new Size2D((int)slidedTrackLength, (int)curTrackThickness);
            }
            else if (direction == DirectionType.Vertical)
            {
                slidedTrack.Size2D = new Size2D((int)curTrackThickness, (int)slidedTrackLength);
            }
        }

        private uint CurrentTrackThickness()
        {
            uint curTrackThickness = 0;
            if (trackThickness != null)
            {
                curTrackThickness = trackThickness.Value;
            }
            else
            {
                if (sliderAttrs != null && sliderAttrs.TrackThickness != null)
                {
                    curTrackThickness = sliderAttrs.TrackThickness.Value;
                }
            }
            return curTrackThickness;
        }

        private uint CurrentSpaceBetweenTrackAndIndicator()
        {
            uint curSpace = 0;
            if (spaceBetweenTrackAndIndicator != null)
            {
                curSpace = spaceBetweenTrackAndIndicator.Value;
            }
            else
            {
                if (sliderAttrs != null && sliderAttrs.SpaceBetweenTrackAndIndicator != null)
                {
                    curSpace = sliderAttrs.SpaceBetweenTrackAndIndicator.Value;
                }
            }
            return curSpace;
        }

        private IndicatorType CurrentIndicatorType()
        {
            IndicatorType type = IndicatorType.None;
            if (sliderAttrs != null)
            {
                type = sliderAttrs.IndicatorType;
            }
            return type;
        }

        private Size2D LowIndicatorImageSize()
        {
            Size2D size = new Size2D(0, 0);
            if (lowIndicatorSize != null)
            {
                size = lowIndicatorSize;
            }
            else
            {
                if (sliderAttrs != null && sliderAttrs.LowIndicatorImageAttributes != null && sliderAttrs.LowIndicatorImageAttributes.Size2D != null)
                {
                    size = sliderAttrs.LowIndicatorImageAttributes.Size2D;
                }
            }
            return size;
        }

        private Size2D HighIndicatorImageSize()
        {
            Size2D size = new Size2D(0, 0);
            if (highIndicatorSize != null)
            {
                size = highIndicatorSize;
            }
            else
            {
                if (sliderAttrs != null && sliderAttrs.HighIndicatorImageAttributes != null && sliderAttrs.HighIndicatorImageAttributes.Size2D != null)
                {
                    size = sliderAttrs.HighIndicatorImageAttributes.Size2D;
                }
            }
            return size;
        }

        private Size2D LowIndicatorTextSize()
        {
            Size2D size = new Size2D(0, 0);
            if (lowIndicatorSize != null)
            {
                size = lowIndicatorSize;
            }
            else
            {
                if (sliderAttrs != null && sliderAttrs.LowIndicatorTextAttributes != null && sliderAttrs.LowIndicatorTextAttributes.Size2D != null)
                {
                    size = sliderAttrs.LowIndicatorTextAttributes.Size2D;
                }
            }
            return size;
        }

        private Size2D HighIndicatorTextSize()
        {
            Size2D size = new Size2D(0, 0);
            if (highIndicatorSize != null)
            {
                size = highIndicatorSize;
            }
            else
            {
                if (sliderAttrs != null && sliderAttrs.HighIndicatorTextAttributes != null && sliderAttrs.HighIndicatorTextAttributes.Size2D != null)
                {
                    size = sliderAttrs.HighIndicatorTextAttributes.Size2D;
                }
            }
            return size;
        }

        private void CalculateCurrentValueByGesture(float offset)
        {
            currentSlidedOffset += offset;
            //Console.WriteLine("offset = " + offset + ", currentSlidedOffset = " + currentSlidedOffset);

            if (currentSlidedOffset <= 0)
            {
                curValue = minValue;
            }
            else if (currentSlidedOffset >= BgTrackLength())
            {
                curValue = maxValue;
            }
            else
            {
                int bgTrackLength = BgTrackLength();
                if (bgTrackLength != 0)
                {
                    curValue = (int)((currentSlidedOffset / (float)bgTrackLength) * (float)(maxValue - minValue) + 0.5f) + minValue;
                }
            }
            if (valueChangedHandler != null)
            {
                ValueChangedArgs args = new ValueChangedArgs();
                args.CurrentValue = curValue.Value;
                valueChangedHandler(this, args);
            }
            //Console.WriteLine("offset = " + offset + ",   currentSlidedOffset = " + currentSlidedOffset + ",   curValue = " + curValue);
        }

        private bool OnTouchEventForBgTrack(object source, TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                Vector2 pos = e.Touch.GetLocalPosition(0);
                CalculateCurrentValueByTouch(pos);
                UpdateValue();
            }
            return false;
        }

        private bool OnTouchEventForThumb(object source, TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                UpdateState(isFocused, true);
            }
            else if (state == PointStateType.Up)
            {
                UpdateState(isFocused, false);
            }
            return true;
        }

        private void CalculateCurrentValueByTouch(Vector2 pos)
        {
            int bgTrackLength = BgTrackLength();
            if (direction == DirectionType.Horizontal)
            {
                currentSlidedOffset = pos.X;
            }
            else if (direction == DirectionType.Vertical)
            {
                currentSlidedOffset = bgTrackLength - pos.Y;
            }
            //Console.WriteLine("currentSlidedOffset = " + currentSlidedOffset);
            if (bgTrackLength != 0)
            {
                curValue = (int)((currentSlidedOffset / (float)bgTrackLength) * (float)(maxValue - minValue) + 0.5f) + minValue;
                if (valueChangedHandler != null)
                {
                    ValueChangedArgs args = new ValueChangedArgs();
                    args.CurrentValue = curValue.Value;
                    valueChangedHandler(this, args);
                }
            }
        }

        private void UpdateState(bool isFocusedNew, bool isPressedNew)
        {
            if (isFocused == isFocusedNew && isPressed == isPressedNew)
            {
                return;
            }
            //Console.WriteLine("-------, isFocused = " + isFocused + ", isPressed = " + isPressed);
            if (thumb == null || sliderAttrs == null)
            {
                return;
            }
            isFocused = isFocusedNew;
            isPressed = isPressedNew;

            if (!isFocused && !isPressed)
            {
                State = States.Normal;
                ApplyAttributes(thumbBg, sliderAttrs.ThumbBgAttributes);
                ApplyAttributes(thumb, sliderAttrs.ThumbAttributes);
                if (stateChangedHandler != null)
                {
                    StateChangedArgs args = new StateChangedArgs();
                    args.CurrentState = States.Normal;
                    stateChangedHandler(this, args);
                }
            }
            else if (isPressed)
            {
                State = States.Pressed;
                ApplyAttributes(thumbBg, sliderAttrs.ThumbBgAttributes);
                ApplyAttributes(thumb, sliderAttrs.ThumbAttributes);

                if (stateChangedHandler != null)
                {
                    StateChangedArgs args = new StateChangedArgs();
                    args.CurrentState = States.Pressed;
                    stateChangedHandler(this, args);
                }
            }
            else if (!isPressed && isFocused)
            {
                State = States.Focused;
                ApplyAttributes(thumbBg, sliderAttrs.ThumbBgAttributes);
                ApplyAttributes(thumb, sliderAttrs.ThumbAttributes);

                if (stateChangedHandler != null)
                {
                    StateChangedArgs args = new StateChangedArgs();
                    args.CurrentState = States.Focused;
                    stateChangedHandler(this, args);
                }
            }
        }

        private void UpdateComponentByIndicatorTypeChanged()
        {
            IndicatorType type = CurrentIndicatorType();
            if (type == IndicatorType.None)
            {
                if (lowIndicatorImage != null)
                {
                    lowIndicatorImage.Hide();
                }
                if (highIndicatorImage != null)
                {
                    highIndicatorImage.Hide();
                }
                if (lowIndicatorText != null)
                {
                    lowIndicatorText.Hide();
                }
                if (highIndicatorText != null)
                {
                    highIndicatorText.Hide();
                }
            }
            else if (type == IndicatorType.Image)
            {
                if (lowIndicatorImage != null)
                {
                    lowIndicatorImage.Show();
                }
                if (highIndicatorImage != null)
                {
                    highIndicatorImage.Show();
                }
                if (lowIndicatorText != null)
                {
                    lowIndicatorText.Hide();
                }
                if (highIndicatorText != null)
                {
                    highIndicatorText.Hide();
                }
            }
            else if (type == IndicatorType.Text)
            {
                if (lowIndicatorText != null)
                {
                    lowIndicatorText.Show();
                }
                if (highIndicatorText != null)
                {
                    highIndicatorText.Show();
                }
                if (lowIndicatorImage != null)
                {
                    lowIndicatorImage.Hide();
                }
                if (highIndicatorImage != null)
                {
                    highIndicatorImage.Hide();
                }
            }
        }
    }
}
