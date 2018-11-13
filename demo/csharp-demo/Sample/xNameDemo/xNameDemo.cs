using System;
using Tizen.NUI.Xaml;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using Tizen.NUI.BaseComponents;
using System.Reflection;
using System.Linq;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Examples
{
    public class xNameDemo : NUIApplication
    {
        private ContentPage myPage;
        private Window window;

        protected override void OnCreate() 
        {
            base.OnCreate();

            window = Window.Instance;

            myPage = new xNameDemoPage(window);
            Extensions.LoadFromXaml(myPage, typeof(xNameDemoPage));

            ImageView title = myPage.Root.FindChildByName("title") as ImageView;

            ImageView imageOne = NameScopeExtensions.FindByName<Tizen.NUI.BaseComponents.ImageView>(myPage, "ImageOne");

            if(title == imageOne)
            {
                Console.WriteLine("Same ImageView!");
            }
            myPage.SetFocus();


        }

    }
}
