using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    public class TouchEventTest : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            TextField label = new TextField();
            label.Size2D = new Size2D(500, 80);
            label.ParentOrigin = ParentOrigin.TopLeft;
            label.PivotPoint = PivotPoint.TopLeft;
            label.Position2D = new Position2D(100, 100);
            label.BackgroundColor = Color.Cyan;
            label.PositionUsesPivotPoint = true;
            window.Add(label);
            label.FocusGained += (obj, e) =>
            {
                Console.WriteLine("FocusGained");
            };
            label.FocusLost += (obj, e) =>
            {
                Console.WriteLine("FocusLost");
            };
            label.KeyEvent += (obj, e) =>
            {
                Console.WriteLine("KeyEvent");
                return false;
            };
            InputMethodContext imf = label.GetInputMethodContext();
            imf.Deactivate();
            label.TouchEvent += (obj, e) =>
            {
                Console.WriteLine("TouchEvent");
                Console.WriteLine($"TouchEvent: DeviceId {e.Touch.GetDeviceId(0)}");
                Console.WriteLine($"TouchEvent: GetTime {e.Touch.GetTime()}");
                Console.WriteLine($"TouchEvent: GetPointCount {e.Touch.GetPointCount()}");
                Console.WriteLine($"TouchEvent: GetState {e.Touch.GetState(0)}");
                Console.WriteLine($"TouchEvent: GetLocalPosition {e.Touch.GetLocalPosition(0).Width}");
                Console.WriteLine($"TouchEvent: GetScreenPosition {e.Touch.GetScreenPosition(0).Width}");
                Console.WriteLine($"TouchEvent: GetRadius {e.Touch.GetRadius(0)}");
                Console.WriteLine($"TouchEvent: GetEllipseRadius {e.Touch.GetEllipseRadius(0).Width}");
                Console.WriteLine($"TouchEvent: GetPressure {e.Touch.GetPressure(0)}");

                //Console.WriteLine($"TouchEvent: GetMouseButton {e.Touch.GetMouseButton(0)}");
                Console.WriteLine($"TouchEvent: =========================================");
                return false;
            };

            TextField label2 = new TextField();
            label2.Size2D = new Size2D(500, 80);
            label2.ParentOrigin = ParentOrigin.TopLeft;
            label2.PivotPoint = PivotPoint.TopLeft;
            label2.Position2D = new Position2D(100, 400);
            label2.BackgroundColor = Color.Cyan;
            label2.PositionUsesPivotPoint = true;
            window.Add(label2);

            label2.FocusGained += (obj, e) =>
            {
                Console.WriteLine("Label 2 FocusGained");
            };
            label2.FocusLost += (obj, e) =>
            {
                Console.WriteLine("Label 2 FocusLost");
            };
            label2.KeyEvent += (obj, e) =>
            {
                Console.WriteLine("Label 2 KeyEvent");
                return false;
            };
            label2.TouchEvent += (obj, e) =>
            {
                Console.WriteLine("Label 2 TouchEvent");
                return false;
            };

            TextLabel label3 = new TextLabel();
            label3.Size2D = new Size2D(500, 400);
            label3.ParentOrigin = ParentOrigin.TopLeft;
            label3.PivotPoint = PivotPoint.TopLeft;
            label3.Position2D = new Position2D(100, 600);
            label3.BackgroundColor = Color.Cyan;
            label3.PositionUsesPivotPoint = true;
            label3.Text = "Label3";
            label3.MultiLine = true;
            label3.Focusable = true;
            window.Add(label3);

            label3.FocusGained += (obj, e) =>
            {
                label3.Text += " Focused";
                Console.WriteLine("Label 3 FocusGained");
            };
            label3.FocusLost += (obj, e) =>
            {
                label3.Text += " Lost";
                Console.WriteLine("Label 3 FocusLost");
            };
            label3.KeyEvent += (obj, e) =>
            {

                Console.WriteLine("Label 3 KeyEvent");
                return false;
            };
            label3.TouchEvent += (obj, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Up)
                {
                    label3.Text += " Touched";
                }
                Console.WriteLine("Label 3 TouchEvent");
                return false;
            };
            
        }

        public static void _Main(string[] args)
        {
            TempTest p = new TempTest();
            p.Run(args);
        }
    }
}
