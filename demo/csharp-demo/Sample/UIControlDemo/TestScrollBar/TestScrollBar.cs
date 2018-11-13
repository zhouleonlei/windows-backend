using System;
using System.IO;
using System.Reflection;

using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;
using Tizen.NUI;
//using System.ComponentModel;

namespace Tizen.NUI.Examples
{

    public class TestScrollBar : NUIApplication
    {
        protected override void OnCreate() 
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            ScrollBarTestPage myPage = new ScrollBarTestPage(window);

            Extensions.LoadFromXaml(myPage, typeof(ScrollBarTestPage));
            
            Console.WriteLine("==================  Set BindingContext in Application !!!! ==================");

        }

        public static void _Main(string[] args)
        {
            TestScrollBar p = new TestScrollBar();
            p.Run(args);
        }
    }
}
