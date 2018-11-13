using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    public class LongPressGestureTest : NUIApplication
    {
        private string ImagePath = "*DemoRes*/images/picture_mod.png";
        private string ImageLeftPath = "*DemoRes*/images/field_ic_handle_left.png";
        private string ImageRightPath = "*DemoRes*/images/field_ic_handle_right.png";

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
                //SelectionHandleImageLeft = imageLeft,
                //SelectionHandleImageRight = imageRight,
            };
           
            window.Add(view);

            LongPressGestureDetector longPress = new LongPressGestureDetector();
            longPress.Attach(view);
            longPress.Detected += (obj, e) => {
                if (e.LongPressGesture.State == Gesture.StateType.Started)
                {
                    Console.WriteLine($"LongPressGesture started");
                    Console.WriteLine($"==================================================");
                    Console.WriteLine($"LocalPoint.X: {e.LongPressGesture.LocalPoint.X}");
                    Console.WriteLine($"LocalPoint.Y: {e.LongPressGesture.LocalPoint.Y}");
                    Console.WriteLine($"NumberOfTouches: {e.LongPressGesture.NumberOfTouches}");
                    Console.WriteLine($"ScreenPoint.X: {e.LongPressGesture.ScreenPoint.X}");
                    Console.WriteLine($"ScreenPoint.Y: {e.LongPressGesture.ScreenPoint.Y}");
                    Console.WriteLine($"Time: {e.LongPressGesture.Time}");
                }
                if (e.LongPressGesture.State == Gesture.StateType.Continuing)
                {
                    Console.WriteLine($"LongPressGesture continuing");
                }
                if (e.LongPressGesture.State == Gesture.StateType.Finished)
                {
                    Console.WriteLine($"LongPressGesture Finished");
                    Console.WriteLine($"==================================================");
                    Console.WriteLine($"LocalPoint.X: {e.LongPressGesture.LocalPoint.X}");
                    Console.WriteLine($"LocalPoint.Y: {e.LongPressGesture.LocalPoint.Y}");
                    Console.WriteLine($"NumberOfTouches: {e.LongPressGesture.NumberOfTouches}");
                    Console.WriteLine($"ScreenPoint.X: {e.LongPressGesture.ScreenPoint.X}");
                    Console.WriteLine($"ScreenPoint.Y: {e.LongPressGesture.ScreenPoint.Y}");
                    Console.WriteLine($"Time: {e.LongPressGesture.Time}");
                }
                if (e.LongPressGesture.State == Gesture.StateType.Possible)
                {
                    Console.WriteLine($"LongPressGesture Possible");
                }
                if (e.LongPressGesture.State == Gesture.StateType.Clear)
                {
                    Console.WriteLine($"LongPressGesture Clear");
                }
                if (e.LongPressGesture.State == Gesture.StateType.Cancelled)
                {
                    Console.WriteLine($"LongPressGesture cancelled");
                }
            };
            PanGestureDetector pan = new PanGestureDetector();
           

        }

        public static void _Main(string[] args)
        {
            TempTest p = new TempTest();
            p.Run(args);
        }
    }
}
