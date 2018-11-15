using System.ComponentModel;
using Tizen.NUI.Binding;
using Tizen.NUI.Renderers;

namespace Tizen.NUI.Controls
{
    public class NewSlider : BaseControl
    {
        public NewSlider() : base()
        {
            (renderer as NewSliderRenderer).ValuePercentChangeHandler += (object obj, float percent) =>
            {
                Value = (int)((maxValue - minValue) * percent) + minValue;
            };
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ValueProperty = BindableProperty.Create("Value", typeof(int), typeof(NewSlider), default(int), BindingMode.TwoWay, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var slider = (NewSlider)bindable;
            slider.value = (int)newValue;
            slider.UpdateSliderValuePercent();
        },
        defaultValueCreator: (bindable) =>
        {
            var slider = (NewSlider)bindable;
            return slider.value;
        });
        private int value;
        public int Value
        {
            get
            {
                return (int)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinValueProperty = BindableProperty.Create("MinValue", typeof(int), typeof(NewSlider), default(int), BindingMode.TwoWay, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var slider = (NewSlider)bindable;
            slider.minValue = (int)newValue;
            slider.UpdateSliderValuePercent();
        },
        defaultValueCreator: (bindable) =>
        {
            var slider = (NewSlider)bindable;
            return slider.minValue;
        });
        private int minValue;
        public int MinValue
        {
            get
            {
                return (int)GetValue(MinValueProperty);
            }
            set
            {
                SetValue(MinValueProperty, value);
            }
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxValueProperty = BindableProperty.Create("MaxValue", typeof(int), typeof(NewSlider), default(int), BindingMode.TwoWay, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var slider = (NewSlider)bindable;
            slider.maxValue = (int)newValue;
            slider.UpdateSliderValuePercent();
        },
        defaultValueCreator: (bindable) =>
        {
            var slider = (NewSlider)bindable;
            return slider.maxValue;
        });
        private int maxValue;
        public int MaxValue
        {
            get
            {
                return (int)GetValue(MaxValueProperty);
            }
            set
            {
                SetValue(MaxValueProperty, value);
            }
        }

        private void UpdateSliderValuePercent()
        {
            if (0 < maxValue)
            {
                float percent = (float)value / (maxValue - minValue);
                renderer.OnPropertyChanged(NewSliderRenderer.ValuePercentChange, this);
            }
        }

        public new Size2D Size2D
        {
            get
            {
                return base.Size2D;
            }
            set
            {
                base.Size2D = value;
                renderer.OnPropertyChanged(NewSliderRenderer.SizeChange, this);
            }
        }

        protected override BaseRenderer GetRenderer()
        {
            if (null == renderer)
            {
                renderer = new NewSliderRenderer();
            }

            return renderer;
        }
    }
}
