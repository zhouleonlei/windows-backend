using System;
using Tizen.NUI.Xaml;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using Tizen.NUI.BaseComponents;
using System.Reflection;
using System.Linq;

namespace Tizen.NUI.Examples
{
    public class xStaticMarkupExtensionDemo : NUIApplication
    {
        private ContentPage myPage;
        private Window window;

        protected override void OnCreate() 
        {
            base.OnCreate();

            window = Window.Instance;

            myPage = new xStaticMarkupExtensionDemoPage(window);
            Extensions.LoadFromXaml(myPage, typeof(xStaticMarkupExtensionDemoPage));
            myPage.SetFocus();


        }

    }
}
