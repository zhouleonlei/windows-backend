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
    public class ViewToViewTest : NUIApplication
    {
        protected override void OnCreate() 
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.Green;

            float?[] aray = new float?[]{};
            Console.WriteLine(aray.GetType());

            ViewToViewPage myPage = new ViewToViewPage(window);
            Extensions.LoadFromXaml(myPage, typeof(ViewToViewPage));
            Console.WriteLine("==================  Set BindingContext in Application !!!! ==================");
            myPage.SetFocus();
        }

        public static void _Main(string[] args)
        {
            ViewToViewTest p = new ViewToViewTest();
            p.Run(args);
        }
    }
}
