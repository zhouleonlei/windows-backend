using System;
using System.IO;
using System.Reflection;

using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;
using Tizen.NUI;
//using System.ComponentModel;



namespace Tizen.NUI.Examples
{
    public class TestFlexContainer : NUIApplication
    {
        protected override void OnCreate() 
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            FlexContainerPage myPage = new FlexContainerPage(window);

            Extensions.LoadFromXaml(myPage, typeof(FlexContainerPage));
            
            Console.WriteLine("==================  Set BindingContext in Application !!!! ==================");
        }

        public static void _Main(string[] args)
        {
            TestFlexContainer p = new TestFlexContainer();
            p.Run(args);
        }
    }
}
