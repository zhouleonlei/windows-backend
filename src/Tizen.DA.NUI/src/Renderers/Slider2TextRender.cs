using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;
using Tizen.DA.NUI.Controls;
using System;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.DA.NUI.res.Slider2TextRenderer.xaml", "Slider2TextRenderer.xaml", typeof(Tizen.DA.NUI.Renderers.Slider2TextRenderer))]

namespace Tizen.DA.NUI.Renderers
{
    public class Slider2TextRenderer : Tizen.NUI.Renderers.SliderRenderer
    {
        public Slider2TextRenderer()
        {
            thumbUpper = NameScopeExtensions.FindByName<ImageView>(layout, "ThumbUpper");
            leftSubText = NameScopeExtensions.FindByName<TextLabel>(layout, "LeftSubText");
            rightSubText = NameScopeExtensions.FindByName<TextLabel>(layout, "RightSubText");
            leftSubText.Relayout += (object sender, EventArgs a) =>
            {
                int leftSubTextWidth = (sender as TextLabel).Size2D.Width;
                Console.WriteLine("leftSubTextWidth = " + leftSubTextWidth);
                RelayoutComponent();
            };
            rightSubText.Relayout += (object sender, EventArgs a) =>
            {
                int rightSubTextWidth = (sender as TextLabel).Size2D.Width;
                Console.WriteLine("rightSubTextWidth = " + rightSubTextWidth);
                RelayoutComponent();
            };
        }

        public override void OnPropertyChanged(string type, View sender)
        {
            Slider realSender = sender as Slider;

            switch (type)
            {
                case LeftSubTextChanged:
                    leftSubText.Text = realSender.LeftSubText;
                    break;
                case RightSubTextChanged:
                    rightSubText.Text = realSender.RightSubText;
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

            leftSubText.Position2D = new Position2D(borderForText, barAreaHeight / 2);
            rightSubText.Position2D = new Position2D(borderForText, barAreaHeight / 2);

            backgroundBar.PositionX = borderForBar;
            backgroundBar.Size2D = new Size2D(curSize.Width - borderForBar * 2, (int)BarHeight);

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
            leftSubText.Position2D = new Position2D(borderForText, -barAreaHeight / 2);
            rightSubText.Position2D = new Position2D(-borderForText, -barAreaHeight / 2);
        }

        protected ImageView thumbUpper;
        protected TextLabel leftSubText;
        protected TextLabel rightSubText;
        private int barAreaHeight = 60;
        private int borderForBar = 64;
        private int borderForText = 56;
        private Size2D curSize = new Size2D(0, 0);

        internal const string LeftSubTextChanged = "LeftSubTextChanged";
        internal const string RightSubTextChanged = "RightSubTextChanged";
    }
}
