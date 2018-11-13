using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    public class TextFieldTest : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            TextField field = new TextField()
            {
                Size2D = new Size2D(500, 56),
                Position2D = new Position2D(100, 100),
                BackgroundColor = Color.Green,
                PointSize = 28,
                Focusable = true,
            };
            //Console.WriteLine($"\n TextField 11 reference count: {field.GetObjectPtr().ReferenceCount()}");
            window.Add(field);

            //InputMethodContext imf = field.GetInputMethodContext();
            //Console.WriteLine($"\n InputMethodContext 11 reference count: {imf.GetObjectPtr().ReferenceCount()}");

            //Console.WriteLine($"\n TextField 22 reference count: {field.GetObjectPtr().ReferenceCount()}");
            window.KeyEvent += (obj, e) =>
            {
                if (e.Key.State == Key.StateType.Down)
                {
                    if (e.Key.KeyPressedName == "1")
                    {
                        window.Remove(field);
                        //Console.WriteLine($"\n TextField 33 reference count: {field.GetObjectPtr().ReferenceCount()}");
                        //Console.WriteLine($"\n InputMethodContext 11 reference count: {imf.GetObjectPtr().ReferenceCount()}");
                        field.Dispose();
                        //Console.WriteLine($"\n TextField 44 reference count: {field.GetObjectPtr().ReferenceCount()}");
                        field = null;
                    }
                }
            };
        }
    }
}
