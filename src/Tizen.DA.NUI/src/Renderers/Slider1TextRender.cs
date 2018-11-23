using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;
using Tizen.DA.NUI.Controls;
using System;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.DA.NUI.res.Slider1TextRenderer.xaml", "Slider1TextRenderer.xaml", typeof(Tizen.DA.NUI.Renderers.Slider1TextRenderer))]

namespace Tizen.DA.NUI.Renderers
{
    public class Slider1TextRenderer : Tizen.NUI.Renderers.SliderRenderer
    {
        public Slider1TextRenderer()
        {
            thumbUpper = NameScopeExtensions.FindByName<ImageView>(layout, "ThumbUpper");
            subText = NameScopeExtensions.FindByName<TextLabel>(layout, "SubText");
            subText.Relayout += (object sender, EventArgs a) =>
            {
                int subTextWidth = (sender as TextLabel).Size2D.Width;
                Console.WriteLine("subTextWidth = " + subTextWidth);
                RelayoutComponent();
            };
        }

        public override void OnPropertyChanged(string type, View sender)
        {
            Slider realSender = sender as Slider;

            switch (type)
            {
                case SubTextChanged:
                    subText.Text = realSender.SubText;
                    break;
                default:
                    base.OnPropertyChanged(type, sender);
                    break;
            }
        }

        protected override void OnSizeChanged(Size2D newSize)
        {
            if (curSize.Width == newSize.Width && curSize.Height == newSize.Height)
            {
                return;
            }
            curSize = new Size2D(newSize.Width, newSize.Height);

            subText.PositionX = leftBorder;
            backgroundBar.PositionX = leftBorder + subText.SizeWidth + spaceBetweenTextAndBar;
            backgroundBar.Size2D = new Size2D(curSize.Width - leftBorder - (int)subText.SizeWidth - spaceBetweenTextAndBar - rightBorder, (int)BarHeight);

            CurrentSlidedOffset = UpdateValue();
        }

        protected override void OnValueChanged(float newPercent)
        {
            if ((CurrentPercent - newPercent > 0.0001) || (CurrentPercent - newPercent < -0.0001))
            {
                CurrentPercent = newPercent;
                CurrentSlidedOffset = UpdateValue();
            }
        }

        public override void OnStateChanged(View.States state)
        {
            thumbUpper.State = state;
            base.OnStateChanged(state);
        }

        private void RelayoutComponent()
        {
            backgroundBar.SizeWidth = curSize.Width - leftBorder - subText.SizeWidth - spaceBetweenTextAndBar - rightBorder;
            backgroundBar.PositionX = leftBorder + subText.SizeWidth + spaceBetweenTextAndBar;
            CurrentSlidedOffset = UpdateValue();
        }

        protected ImageView thumbUpper;
        protected TextLabel subText;
        private int leftBorder = 56;
        private int rightBorder = 64;
        private int spaceBetweenTextAndBar = 48;
        private Size2D curSize = new Size2D(0, 0);

        internal const string SubTextChanged = "SubTextChanged";
    }
}
