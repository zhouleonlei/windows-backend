using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    public class PanGestureTest : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            View view = new View()
            {
                Size2D = new Size2D(500, 400),
                Position2D = new Position2D(100, 100),
                BackgroundColor = Color.Green,
            };

            window.Add(view);

            PanGestureDetector pan = new PanGestureDetector();
            pan.Attach(view);
            pan.Detected += (obj, e) => {
                if (e.PanGesture.State == Gesture.StateType.Started)
                {
                    Console.WriteLine($"PanGesture started");
                    Console.WriteLine($"==================================================");
                    Console.WriteLine($"LocalPoint.X: {e.PanGesture.Position.X}");
                    Console.WriteLine($"LocalPoint.Y: {e.PanGesture.Position.Y}");
                    Console.WriteLine($"NumberOfTouches: {e.PanGesture.NumberOfTouches}");
                    Console.WriteLine($"ScreenPoint.X: {e.PanGesture.ScreenPosition.X}");
                    Console.WriteLine($"ScreenPoint.Y: {e.PanGesture.ScreenPosition.Y}");
                    Console.WriteLine($"Time: {e.PanGesture.Time}");
                    Console.WriteLine($"Velocity.X: {e.PanGesture.Velocity.X}");
                    Console.WriteLine($"Velocity.Y: {e.PanGesture.Velocity.Y}");
                    Console.WriteLine($"ScreenVelocity.X: {e.PanGesture.ScreenVelocity.X}");
                    Console.WriteLine($"ScreenVelocity.Y: {e.PanGesture.ScreenVelocity.Y}");
                    Console.WriteLine($"ScreenDisplacement.X: {e.PanGesture.ScreenDisplacement.X}");
                    Console.WriteLine($"ScreenDisplacement.Y: {e.PanGesture.ScreenDisplacement.Y}");
                }
                if (e.PanGesture.State == Gesture.StateType.Continuing)
                {
                    Console.WriteLine($"PanGesture continuing");
                }
                if (e.PanGesture.State == Gesture.StateType.Finished)
                {
                    Console.WriteLine($"PanGesture Finished");
                    Console.WriteLine($"==================================================");
                    Console.WriteLine($"LocalPoint.X: {e.PanGesture.Position.X}");
                    Console.WriteLine($"LocalPoint.Y: {e.PanGesture.Position.Y}");
                    Console.WriteLine($"NumberOfTouches: {e.PanGesture.NumberOfTouches}");
                    Console.WriteLine($"ScreenPoint.X: {e.PanGesture.ScreenPosition.X}");
                    Console.WriteLine($"ScreenPoint.Y: {e.PanGesture.ScreenPosition.Y}");
                    Console.WriteLine($"Time: {e.PanGesture.Time}");
                    Console.WriteLine($"Velocity.X: {e.PanGesture.Velocity.X}");
                    Console.WriteLine($"Velocity.Y: {e.PanGesture.Velocity.Y}");
                    Console.WriteLine($"ScreenVelocity.X: {e.PanGesture.ScreenVelocity.X}");
                    Console.WriteLine($"ScreenVelocity.Y: {e.PanGesture.ScreenVelocity.Y}");
                    Console.WriteLine($"ScreenDisplacement.X: {e.PanGesture.ScreenDisplacement.X}");
                    Console.WriteLine($"ScreenDisplacement.Y: {e.PanGesture.ScreenDisplacement.Y}");
                }
                if (e.PanGesture.State == Gesture.StateType.Possible)
                {
                    Console.WriteLine($"PanGesture Possible");
                }
                if (e.PanGesture.State == Gesture.StateType.Clear)
                {
                    Console.WriteLine($"PanGesture Clear");
                }
                if (e.PanGesture.State == Gesture.StateType.Cancelled)
                {
                    Console.WriteLine($"PanGesture cancelled");
                }
            };


        }

        public static void _Main(string[] args)
        {
            TempTest p = new TempTest();
            p.Run(args);
        }
    }
}
