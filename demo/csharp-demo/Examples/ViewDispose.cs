using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    public class ViewDisposeTest : NUIApplication
    {

        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            View parent = new View()
            {
                Size2D = new Size2D(500, 300),
                Position2D = new Position2D(100, 100),
                BackgroundColor = Color.Green,
                Name = "parent",
            };
            window.Add(parent);

            window.KeyEvent += (obj, e) => {
                if (e.Key.State == Key.StateType.Down)
                {
                    if (e.Key.KeyPressedName == "1")
                    {
                        window.Remove(parent);
                        parent.Dispose();
                        parent = null;
                    }
                }
            };
        }
    }
}
