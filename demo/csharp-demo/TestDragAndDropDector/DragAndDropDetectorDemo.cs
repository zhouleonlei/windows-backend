using System;
using System.Globalization;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{

    public class DragAndDropDetectorDemo : NUIApplication
    {
        protected override void OnCreate() 
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.Green;

            Console.WriteLine("DragAndDropDetectorDemo");

            View view1 = new View();
            view1.Name = "View1";
            view1.BackgroundColor = Color.Red;
            view1.Size2D = new Size2D(200, 200);
            view1.Position2D = new Position2D(200, 100);
            window.Add(view1);

            View view2 = new View();
            view2.Name = "View2";
            view2.BackgroundColor = Color.Blue;
            view2.Size2D = new Size2D(400, 400);
            view2.Position2D = new Position2D(200, 400);
            window.Add(view2);

            PanGestureDetector panGestureDetector = new PanGestureDetector();
            panGestureDetector.Attach(view1);

            panGestureDetector.Detected += (obj, e) =>
            {
                PanGesture panGesture = e.PanGesture;
                View view = e.View;
                Vector2 vector = panGesture.Displacement;
                Console.WriteLine("panGesture.Displacement.X: {0}, .Y: {1}", vector.X, vector.Y);
                view.PositionX += vector.X;
                view.PositionY += vector.Y;


            };

            DragAndDropDetector dragAndDropDetector = window.GetDragAndDropDetector();
            if(dragAndDropDetector != null)
            {
                Console.WriteLine("dragAndDropDetector.Content: {0}", dragAndDropDetector.GetContent());
                Vector2 vector2 = dragAndDropDetector.GetCurrentScreenPosition();
                Console.WriteLine("dragAndDropDetector.GetCurrentScreenPosition.X: {0}, .Y: {1}", vector2.X, vector2.Y);
            }
            else
            {
                Console.WriteLine("dragAndDropDetector is Null.");
            }

            dragAndDropDetector.Entered += (obj, e) =>
            {
                Console.WriteLine("Entered detected.");
                Console.WriteLine("Entered dragAndDropDetector.Content: {0}", dragAndDropDetector.GetContent());
                Vector2 vector2 = dragAndDropDetector.GetCurrentScreenPosition();
                Console.WriteLine("Entered dragAndDropDetector.GetCurrentScreenPosition.X: {0}, .Y: {1}", vector2.X, vector2.Y);
            };

            dragAndDropDetector.Moved += (obj, e) =>
            {
                Console.WriteLine("Moved detected.");
                Console.WriteLine("Moved dragAndDropDetector.Content: {0}", dragAndDropDetector.GetContent());
                Vector2 vector2 = dragAndDropDetector.GetCurrentScreenPosition();
                Console.WriteLine("Moved dragAndDropDetector.GetCurrentScreenPosition.X: {0}, .Y: {1}", vector2.X, vector2.Y);
            };

            dragAndDropDetector.Exited += (obj, e) =>
            {
                Console.WriteLine("Exited detected.");
                Console.WriteLine("Exited dragAndDropDetector.Content: {0}", dragAndDropDetector.GetContent());
                Vector2 vector2 = dragAndDropDetector.GetCurrentScreenPosition();
                Console.WriteLine("Exited dragAndDropDetector.GetCurrentScreenPosition.X: {0}, .Y: {1}", vector2.X, vector2.Y);
            };

            dragAndDropDetector.Dropped += (obj, e) =>
            {
                Console.WriteLine("Dropped detected.");
                Console.WriteLine("Dropped dragAndDropDetector.Content: {0}", dragAndDropDetector.GetContent());
                Vector2 vector2 = dragAndDropDetector.GetCurrentScreenPosition();
                Console.WriteLine("Dropped dragAndDropDetector.GetCurrentScreenPosition.X: {0}, .Y: {1}", vector2.X, vector2.Y);
            };


        }

        public static void _Main(string[] args)
        {
            ViewToViewTest p = new ViewToViewTest();
            p.Run(args);
        }
    }
}
