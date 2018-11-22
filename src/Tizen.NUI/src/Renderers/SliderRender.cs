using System;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.NUI.res.SliderRenderer.xaml", "SliderRenderer.xaml", typeof(Tizen.NUI.Renderers.SliderRenderer))]

namespace Tizen.NUI.Renderers
{
    /// <summary>
    /// The class of the slider renderer.
    /// </summary>
    public class SliderRenderer : BaseRenderer
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        public SliderRenderer()
        {
            backgroundBar = NameScopeExtensions.FindByName<View>(layout, "BackgroundBar");
            sliderBar = NameScopeExtensions.FindByName<View>(layout, "SliderBar");
            thumb = NameScopeExtensions.FindByName<ImageView>(layout, "Thumb");

            // register touch event callback
            backgroundBar.TouchEvent += (object sender, View.TouchEventArgs e) =>
            {
                Vector2 touchPosition = e.Touch.GetLocalPosition(e.Touch.GetPointCount() - 1);
                if (backgroundBar.Size2D.Width != 0)
                {
                    currentPercent = ((float)touchPosition.X / (float)backgroundBar.Size2D.Width);
                }
                UpdateValue();
                ValueChangeHandler?.Invoke(this, currentPercent);
                return true;
            };

            // register panGesture event callback
            currentSlidedOffset = 0;
            panGestureDetector = new PanGestureDetector();
            panGestureDetector.Attach(thumb);
            panGestureDetector.AddDirection(PanGestureDetector.DirectionHorizontal);
            panGestureDetector.Detected += (object source, PanGestureDetector.DetectedEventArgs e) =>
            {
                if (e.PanGesture.State == Gesture.StateType.Started)
                {
                    //Console.WriteLine("currentSlidedOffset = " + currentSlidedOffset);
                    currentSlidedOffset = sliderBar.SizeWidth;
                }

                if (e.PanGesture.State == Gesture.StateType.Continuing || e.PanGesture.State == Gesture.StateType.Started)
                {
                    //Console.WriteLine("x = " + e.PanGesture.Displacement.X);
                    CalculateCurrentValue(e.PanGesture.Displacement.X);
                    UpdateValue();
                    ValueChangeHandler?.Invoke(this, currentPercent);
                }
            };
        }

        public override void OnPropertyChanged(string type, View sender)
        {
            Slider obj = sender as Slider;

            switch (type)
            {
                case SizeChanged:
                    {
                        OnSizeChanged(obj.Size2D);
                    }
                    break;
                case ValueChanged:
                    {
                        if (obj.MaxValue <= obj.MinValue || obj.CurrentValue < obj.MinValue || obj.CurrentValue > obj.MaxValue)
                        {
                            return;
                        }
                        float newPercent = (float)(obj.CurrentValue) / (obj.MaxValue - obj.MinValue);
                        OnValueChanged(newPercent);
                    }
                    break;
                case BarHeightChanged:
                    {
                        OnBarHeightChanged(obj.BarHeight);
                    }
                    break;
                case ThumbSizeChanged:
                    {
                        OnThumbSizeChanged(obj.ThumbSize);
                    }
                    break;
                case ThumbImageURLChanged:
                    {
                        OnThumbImageURLChanged(obj.ThumbImageURL);
                    }
                    break;
                case BgBarColorChanged:
                    {
                        OnBgBarColorChanged(obj.BgBarColor);
                    }
                    break;
                case SliderBarColorChanged:
                    {
                        OnSliderBarColorChanged(obj.SliderBarColor);
                    }
                    break;
            }
        }

        protected virtual void OnSizeChanged(Size2D newSize)
        {
            backgroundBar.Size2D = new Size2D(newSize.Width, (int)barHeight);
            currentSlidedOffset = UpdateValue();
        }

        protected virtual void OnValueChanged(float newPercent)
        {
            if ((currentPercent - newPercent > 0.0001) || (currentPercent - newPercent < -0.0001))
            {
                currentPercent = newPercent;
                currentSlidedOffset = UpdateValue();
            }
        }

        protected virtual void OnBarHeightChanged(uint newBarHeight)
        {
            barHeight = newBarHeight;
            if (backgroundBar != null)
            {
                backgroundBar.SizeHeight = barHeight;
            }
        }

        protected virtual void OnThumbSizeChanged(Size2D newSize)
        {
            if (thumb != null && newSize != null)
            {
                thumb.Size2D = new Size2D(newSize.Width, newSize.Height);
            }
        }

        protected virtual void OnThumbImageURLChanged(string stringURL)
        {
            if (thumb != null && stringURL != null)
            {
                thumb.ResourceUrl = stringURL;
            }
        }

        protected virtual void OnBgBarColorChanged(Color newColor)
        {
            if (backgroundBar != null && newColor != null)
            {
                backgroundBar.BackgroundColor = new Color(newColor.R, newColor.G, newColor.B, newColor.A);
            }
        }

        protected virtual void OnSliderBarColorChanged(Color newColor)
        {
            if (sliderBar != null && newColor != null)
            {
                sliderBar.BackgroundColor = new Color(newColor.R, newColor.G, newColor.B, newColor.A);
            }
        }

        protected float UpdateValue()
        {
            float offset = (int)(backgroundBar.Size2D.Width * currentPercent);
            //sliderBar.Size2D = new Size2D((int)offset, (int)barHeight);
            //thumb.Position2D = new Position2D((int)offset, 0);
            sliderBar.SizeWidth = (int)offset;
            thumb.PositionX = (int)offset;
            return offset;
        }

        public override void OnStateChanged(View.States state)
        {
           // throw new NotImplementedException();
        }

        // The property is for derived class to get the percent value.
        protected float CurrentPercent
        {
            get
            {
                return currentPercent;
            }
            set
            {
                currentPercent = value;
            }
        }

        // The property is for derived class to get the barHeight.
        protected uint BarHeight
        {
            get
            {
                return barHeight;
            }
        }

        protected float CurrentSlidedOffset
        {
            get
            {
                return currentSlidedOffset;
            }
            set
            {
                currentSlidedOffset = value;
            }
        }

        private void CalculateCurrentValue(float offset)
        {
            currentSlidedOffset += offset;

            Console.WriteLine("offset = " + offset + ", currentSlidedOffset = " + currentSlidedOffset);
            if (currentSlidedOffset <= 0)
            {
                currentPercent = 0;
            }
            else if (currentSlidedOffset >= backgroundBar.Size2D.Width)
            {
                currentPercent = 1;
            }
            else
            {
                if (backgroundBar.Size2D.Width != 0)
                {
                    currentPercent = (currentSlidedOffset / (float)backgroundBar.Size2D.Width);
                }
            }
        }

        public EventHandler<float> ValueChangeHandler;
        
        // The background bar
        protected View backgroundBar = null;
        // The slider bar
        protected View sliderBar = null;
        // The thumb view
        protected ImageView thumb = null;

        internal const string SizeChanged = "SizeChanged";
        internal const string ValueChanged = "ValueChanged";
        internal const string BarHeightChanged = "BarHeightChanged";
        internal const string ThumbSizeChanged = "ThumbSizeChanged";
        internal const string ThumbImageURLChanged = "ThumbImageURLChanged";
        internal const string BgBarColorChanged = "BgBarColorChanged";
        internal const string SliderBarColorChanged = "SliderBarColorChanged";

        private PanGestureDetector panGestureDetector;
        private float currentPercent = 0;
        private uint barHeight = 4;
        private float currentSlidedOffset = 0;
    }
}
