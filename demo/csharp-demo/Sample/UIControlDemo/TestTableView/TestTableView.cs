using System;
using System.IO;
using System.Reflection;

using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;
using Tizen.NUI;
//using System.ComponentModel;



namespace Tizen.NUI.Examples
{
    
    public class TestTableView : NUIApplication
    {
        protected override void OnCreate() 
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            TableTestPage myPage = new TableTestPage(window);

            Extensions.LoadFromXaml(myPage, typeof(TableTestPage));
            
            Console.WriteLine("==================  Set BindingContext in Application !!!! ==================");

        }

        public static void _Main(string[] args)
        {
            TestTableView p = new TestTableView();
            p.Run(args);
        }
    }
}
