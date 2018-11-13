using System;
using System.IO;
using System.Reflection;

using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;
using Tizen.NUI;
//using System.ComponentModel;

namespace Tizen.NUI.Examples
{

    public class TestTextLabel : NUIApplication
    {
        protected override void OnCreate() 
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            TextLabelTestPage myPage = new TextLabelTestPage(window);

            // MyPage myPage = new MyPage(win);
            Extensions.LoadFromXaml(myPage, typeof(TextLabelTestPage));
            
            Console.WriteLine("==================  Set BindingContext in Application !!!! ==================");

        }

        public static void _Main(string[] args)
        {
            TestTextLabel p = new TestTextLabel();
            p.Run(args);
        }
    }
}
