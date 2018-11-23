using System.ComponentModel;
using Tizen.NUI.Renderers;
using System;

namespace Tizen.NUI.Controls
{
    /// <summary>
    /// The class of the Slider component.
    /// </summary>
    public class Slider : BaseControl
    {
        /// <summary>
        /// The class of gesture event args.
        /// </summary>
        public class GestureEventArgs : EventArgs
        {
            // The changed current value caused by gesture event.
            public int CurrentValue;
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        public Slider() : base()
        {
            Initialize();
        }

        public Slider(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// The property of the current value.
        /// </summary>
        public int CurrentValue
        {
            get
            {
                return curValue;
            }
            set
            {
                if (curValue != value)
                {
                    curValue = value;
                    UpdateValue();
                }
            }
        }
        
        /// <summary>
        /// The property of the minimum value.
        /// </summary>
        public int MinValue
        {
            get
            {
                return minValue;
            }
            set
            {
                if (minValue != value)
                {
                    minValue = value;
                    UpdateValue();
                }
            }
        }

        /// <summary>
        /// The property of the maximum value.
        /// </summary>
        public int MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                if (maxValue != value)
                {
                    maxValue = value;
                    UpdateValue();
                }
            }
        }

        /// <summary>
        /// The property of the height of the bar.
        /// </summary>
        public uint BarHeight
        {
            get
            {
                return barHeight;
            }
            set
            {
                if (barHeight != value)
                {
                    barHeight = value;
                    UpdateBarHeight();
                }
            }
        }

        /// <summary>
        /// The property of the size of the thumb.
        /// </summary>
        public Size2D ThumbSize
        {
            get
            {
                return thumbSize;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                thumbSize = new Size2D(value.Width, value.Height);
                UpdateThumbSize();
            }
        }

        /// <summary>
        /// The property of the string url of the thumb.
        /// </summary>
        public string ThumbImageURL
        {
            get
            {
                return thumbImageURL;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                thumbImageURL = value;
                UpdateThumbImageURL();
            }
        }

        public Color BgBarColor
        {
            get
            {
                return bgBarColor;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                bgBarColor = new Color(value.R, value.G, value.B, value.A);
                UpdateBgBarColor();
            }
        }

        public Color SliderBarColor
        {
            get
            {
                return sliderBarColor;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                sliderBarColor = new Color(value.R, value.G, value.B, value.A);
                UpdateSliderBarColor();
            }
        }

        protected override void OnRelayout(object sender, EventArgs e)
        {
            renderer.OnPropertyChanged(SliderRenderer.SizeChanged, this);
            base.OnRelayout(sender, e);
        }

        private void Initialize()
        {
            Focusable = true;
            // The value change caused by touch&panGesture event.
            (renderer as SliderRenderer).ValueChangeHandler += (object obj, float percent) =>
            {
                curValue = (int)((maxValue - minValue) * percent + 0.5f) + minValue;
                GestureEventArgs args = new GestureEventArgs();
                args.CurrentValue = curValue;
                OnGestureEvent(args);
            };
        }

        private void UpdateValue()
        {
            renderer.OnPropertyChanged(SliderRenderer.ValueChanged, this);
        }

        private void UpdateBarHeight()
        {
            renderer.OnPropertyChanged(SliderRenderer.BarHeightChanged, this);
        }

        private void UpdateThumbSize()
        {
            renderer.OnPropertyChanged(SliderRenderer.ThumbSizeChanged, this);
        }

        private void UpdateThumbImageURL()
        {
            renderer.OnPropertyChanged(SliderRenderer.ThumbImageURLChanged, this);
        }

        private void UpdateBgBarColor()
        {
            renderer.OnPropertyChanged(SliderRenderer.BgBarColorChanged, this);
        }

        private void UpdateSliderBarColor()
        {
            renderer.OnPropertyChanged(SliderRenderer.SliderBarColorChanged, this);
        }

        private void OnGestureEvent(GestureEventArgs args)
        {
            if (GestureEvent != null)
            {
                GestureEvent(this, args);
            }
        }

        protected override BaseRenderer GetRenderer()
        {
            if (renderer == null)
            {
                renderer = new SliderRenderer();
            }
            return renderer;
        }

        // The gesture event that user can register.
        public event EventHandler<GestureEventArgs> GestureEvent;
        private int curValue, minValue, maxValue;

        private uint barHeight = 4;
        private Size2D thumbSize = new Size2D(60, 60);
        private Color bgBarColor = new Color(164.0f / 255.0f, 179.0f / 255.0f, 191.0f / 255.0f, 0.6f); //Color #a4b3bf (Opacity : 60%)
        private Color sliderBarColor = new Color(46.0f / 255.0f, 176.0f / 255.0f, 200.0f / 255.0f, 1.0f); //Color #2eb0c8
        private string thumbImageURL = string.Empty;
    }
}
