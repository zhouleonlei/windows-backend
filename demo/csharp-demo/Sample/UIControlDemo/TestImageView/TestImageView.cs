using System;
using System.IO;
using System.Reflection;

using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;
using Tizen.NUI;
//using System.ComponentModel;

namespace Tizen.NUI.Examples
{

    public class TestImageView : NUIApplication
    {
        protected override void OnCreate() 
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            ImageTestPage myPage = new ImageTestPage(window);

            Extensions.LoadFromXaml(myPage, typeof(ImageTestPage));

            Console.WriteLine("==================  Set BindingContext in Application !!!! ==================");
        }

        public static void _Main(string[] args)
        {
            TestImageView p = new TestImageView();
            p.Run(args);
        }
    }
}
