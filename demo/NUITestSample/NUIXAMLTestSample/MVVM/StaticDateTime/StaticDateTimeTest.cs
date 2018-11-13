using System;
using System.IO;
using System.Reflection;

using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI.Examples
{
    public class StaticDateTimeTest : NUIApplication
    {
        protected override void OnCreate() 
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.Green;

            StaticDateTimePage myPage = new StaticDateTimePage(window);
            Extensions.LoadFromXaml(myPage, typeof(StaticDateTimePage));
            Console.WriteLine("==================  Set BindingContext in Application !!!! ==================");
            myPage.SetFocus();
        }

        public static void _Main(string[] args)
        {
            StaticDateTimeTest p = new StaticDateTimeTest();
            p.Run(args);
        }
    }
}
