using System;
using Tizen.NUI.Xaml;
using Tizen.NUI.Binding;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;
using System.Reflection;
using System.Linq;

namespace Tizen.NUI.Examples
{
    public class TriggerWithDataBindingDemo : NUIApplication
    {
        private ContentPage myPage;
        private Window window;

        protected override void OnCreate() 
        {
            base.OnCreate();

            window = Window.Instance;
            window.BackgroundColor = Color.White;

            myPage = new TriggerWithDataBindingDemoPage(window);
            Extensions.LoadFromXaml(myPage, typeof(TriggerWithDataBindingDemoPage));

            PushButton button = NameScopeExtensions.FindByName<PushButton>(myPage, "Click");
            FocusManager.Instance.SetCurrentFocusView(button);

            TextLabel label = NameScopeExtensions.FindByName<TextLabel>(myPage, "label");

            bool flag = true;
            button.Clicked += (obj, e) =>
            {
                if (true == flag)
                {
                    label.Text = "*DemoRes*/images/AmbientScreenUXControl/Cut/bixby_detail.png";
                }
                else
                {
                    label.Text = "*DemoRes*/images/AmbientScreenUXControl/Cut/bixby_sendtophone.png";
                }

                flag = !flag;
                return true;
            };

            myPage.SetFocus();


        }

    }
}
