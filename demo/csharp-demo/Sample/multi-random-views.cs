using System;
using System.Collections.Generic;
using System.Text;
using Tizen.Common;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    class MultiRandomViews : NUIApplication
    {
        private Random myRandom;
        public MultiRandomViews() : base()
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        private void Initialize()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;
            myRandom = new Random();
            TextLabel label = new TextLabel();
            label.ParentOrigin = ParentOrigin.BottomLeft;
            label.PivotPoint = PivotPoint.BottomLeft;
            label.PositionUsesPivotPoint = true;
            label.Text = "Seconds: ";
            window.Add(label);
            DateTime tm1 = DateTime.Now;

            for (int i = 0; i < 1000; i++)
            {
                View view = new View();
                float intensity = myRandom.Next(0, 255) / 255.0f;
                view.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                view.Position2D = new Position2D(myRandom.Next(0, 1820), myRandom.Next(0, 980));
                view.Size2D = new Size2D(100, 100);
                window.Add(view);
            }

            DateTime tm2 = DateTime.Now;
            TimeSpan ts = tm2.Subtract(tm1).Duration();

            label.RaiseToTop();
            label.Text = "Seconds: " + ts.TotalSeconds.ToString();
        }
    }
}
