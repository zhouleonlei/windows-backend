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
    public class BindingConverterDemo : NUIApplication
    {
        protected override void OnCreate() 
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            BindingConverterDemoPage myPage = new BindingConverterDemoPage(window);
            Extensions.LoadFromXaml(myPage, typeof(BindingConverterDemoPage));
            Console.WriteLine("==================  Set BindingContext in Application !!!! ==================");

            PushButton button = NameScopeExtensions.FindByName<PushButton>(myPage, "Button");
            Console.WriteLine("button.Focusable:{0}", button.Focusable);

            myPage.SetFocus();
        }
    }
}
