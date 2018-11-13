using System;
using Tizen.NUI.Xaml;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using Tizen.NUI.BaseComponents;
using System.Reflection;
using System.Linq;
using Tizen.NUI.UIComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;
using Tizen.NUI;

namespace Tizen.NUI.Examples
{
    public class xReferenceMarkupExtensionDemo : NUIApplication
    {
        private ContentPage myPage;
        private Window window;

        protected override void OnCreate() 
        {
            base.OnCreate();

            window = Window.Instance;

            myPage = new xReferenceMarkupExtensionDemoPage(window);
            Extensions.LoadFromXaml(myPage, typeof(xReferenceMarkupExtensionDemoPage));

            PushButton button = NameScopeExtensions.FindByName<PushButton>(myPage, "Up");
            FocusManager.Instance.SetCurrentFocusView(button);

            myPage.SetFocus();


        }

    }
}
