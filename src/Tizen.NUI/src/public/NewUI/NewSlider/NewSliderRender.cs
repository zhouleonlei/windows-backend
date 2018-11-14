using System;
using static Tizen.NUI.BaseComponents.View;
using Tizen.NUI.Binding;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.NUI.res.NewSliderRenderer.xaml", "NewSliderRenderer.xaml", typeof(Tizen.NUI.BaseComponents.NewSliderRenderer))]

namespace Tizen.NUI.BaseComponents
{
    public class NewSliderRenderer : BaseRenderer
    {
        internal const string SizeChange = "SizeChange";
        internal const string ValuePercentChange = "ValuePercent";

        public NewSliderRenderer()
        {
            progressBar = NameScopeExtensions.FindByName<View>(layout, "ProgressBar");
            progressValue = NameScopeExtensions.FindByName<View>(layout, "ProgressValue");

            progressBar.TouchEvent += (object sender, TouchEventArgs e) =>
            {
                Vector2 localPosition = e.Touch.GetLocalPosition(e.Touch.GetPointCount() - 1);
                float percent = ((float)localPosition.X / (float)progressBar.Size2D.Width);

                ValuePercentChangeHandler?.Invoke(this, percent);
                return true;
            };
        }

        public override void OnPropertyChanged(string type, View sender)
        {
            NewSlider realSender = sender as NewSlider;

            switch (type)
            {
                case SizeChange:
                    {
                        OnSizeChanged(realSender.Size2D);
                    }
                    break;

                case ValuePercentChange:
                    {
                        float percent = (float)(realSender.Value) / (realSender.MaxValue - realSender.MinValue);
                        OnValuePercentChanged(percent);
                    }
                    break;
            }
        }

        public override void OnStateChanged(States state)
        {
            ;
        }

        protected virtual void OnSizeChanged(Size2D newSize)
        {
            progressBar.Size2D = newSize;
            progressValue.Size2D = new Size2D((int)(progressBar.Size2D.Width * _valuePercent), (int)(progressBar.Size2D.Height * _valuePercent));
        }

        protected virtual void OnValuePercentChanged(float newPercent)
        {
            if (valuePercent != newPercent)
            {
                valuePercent = newPercent;
            }
        }

        public EventHandler<float> ValuePercentChangeHandler;

        private float _valuePercent = 0;
        protected float valuePercent
        {
            get
            {
                return _valuePercent;
            }
            set
            {
                _valuePercent = value;
                progressValue.Size2D = new Size2D((int)(progressBar.Size2D.Width * _valuePercent), progressBar.Size2D.Height);
            }
        }

        protected View progressBar;

        protected View progressValue;
    }
}
