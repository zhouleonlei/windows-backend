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
    public class BindingModeDemo : NUIApplication
    {
        protected override void OnCreate() 
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            BindingModeDemoPage myPage = new BindingModeDemoPage(window);
            Extensions.LoadFromXaml(myPage, typeof(BindingModeDemoPage));
            Console.WriteLine("==================  Set BindingContext in Application !!!! ==================");

            myPage.SetFocus();
        }
    }
}
