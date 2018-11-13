using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;
using Tizen.NUI.Xaml;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Examples
{
    public class CommandUTTest : NUIApplication
    {
        private string InputString = "Hello";

        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            //ImageView view = new ImageView("xxxx.png")
            //{
            //    Size2D = new Size2D(100, 100),
            //    Position2D = new Position2D(100, 100),
            //};
            //if (view == null)
            //{
            //    Console.WriteLine($"view is null");
            //}
            //else
            //{
            //    Console.WriteLine($"view isn't null");
            //}
            //window.Add(view);
            var mCommand01 = new Command<String>((s) => { });
            var mCommand02 = new Command(() => { });
            var pushButton = new PushButton();

            Console.WriteLine($"Test Command ...");
            pushButton.Command = mCommand01;
            Console.WriteLine($"Command: {pushButton.Command}");
            if (pushButton.Command == mCommand01)
            {
                Console.WriteLine($"pushButton.Command == mCommand0");
            }

            Console.WriteLine($"Test CommandParameter ...");
            pushButton.CommandParameter = "mLabel";
            Console.WriteLine($"CommandParameter: {pushButton.CommandParameter as string}");
            if ((string)pushButton.CommandParameter == "mLabel")
            {
                Console.WriteLine($"pushButton.CommandParameter == mLabel");
            }
            Console.WriteLine($"Test Done...");
        }

        public static void _Main(string[] args)
        {
            TempTest p = new TempTest();
            p.Run(args);
        }
    }
}
