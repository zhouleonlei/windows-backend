using System;
using Tizen.NUI.Xaml;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;
using System.Reflection;
using System.Linq;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Examples
{
    public class MultiTriggerDemo : NUIApplication
    {
        private ContentPage myPage;
        private Window window;

        protected override void OnCreate() 
        {
            base.OnCreate();

            window = Window.Instance;
            window.BackgroundColor = Color.White;

            myPage = new MultiTriggerDemoPage(window);
            Extensions.LoadFromXaml(myPage, typeof(MultiTriggerDemoPage));

            PushButton button = NameScopeExtensions.FindByName<PushButton>(myPage, "Click");
            FocusManager.Instance.SetCurrentFocusView(button);

            ImageView image = NameScopeExtensions.FindByName<ImageView>(myPage, "ImageView");

            bool flag = true;
            button.Clicked += (obj, e) =>
            {
                image.PositionX = 200;
                image.PositionY = 200;
                return true;
            };

            myPage.SetFocus();
        }
    }
}
