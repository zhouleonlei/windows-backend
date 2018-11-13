using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Examples
{
    class EventHandlerDemo : NUIApplication
    {
        private Window window;
        private ContentPage myPage;

        protected override void OnCreate()
        {
            base.OnCreate();

            window = Window.Instance;

            window.BackgroundColor = Color.White;

            myPage = new EventHandlerDemoPage(window);

            Extensions.LoadFromXaml(myPage, typeof(EventHandlerDemoPage));

            View button = myPage.Root.FindChildByName("PushButton");
            FocusManager.Instance.SetCurrentFocusView(button);

            myPage.SetFocus();
        }
    }
}
