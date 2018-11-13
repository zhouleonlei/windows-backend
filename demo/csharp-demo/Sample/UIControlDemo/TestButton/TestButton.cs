using System;
using System.IO;
using System.Reflection;

using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
//using System.ComponentModel;

namespace Tizen.NUI.Examples
{


    public class TestButton : NUIApplication
    {

        protected override void OnCreate() 
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            ButtonTestPage myPage = new ButtonTestPage(window);

            Extensions.LoadFromXaml(myPage, typeof(ButtonTestPage));

            Console.WriteLine("==================  Set BindingContext in Application !!!! ==================");
            myPage.SetFocus();
        }

        public static void _Main(string[] args)
        {
            TestButton p = new TestButton();
            p.Run(args);
        }
    }
}
