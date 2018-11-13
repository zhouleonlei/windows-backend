using System;
using System.IO;
using System.Reflection;

using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;
using Tizen.NUI;
//using System.ComponentModel;

namespace Tizen.NUI.Examples
{

    public class TestTextField : NUIApplication
    {
        protected override void OnCreate() 
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            TextFieldTestPage myPage = new TextFieldTestPage(window);

            Extensions.LoadFromXaml(myPage, typeof(TextFieldTestPage));
            
            Console.WriteLine("==================  Set BindingContext in Application !!!! ==================");
        }

        public static void _Main(string[] args)
        {
            TestTextField p = new TestTextField();
            p.Run(args);
        }
    }
}
