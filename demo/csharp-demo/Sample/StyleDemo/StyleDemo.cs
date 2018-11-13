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
    public class StyleDemo : NUIApplication
    {
        private ContentPage myPage;
        private Window window;

        protected override void OnCreate() 
        {
            base.OnCreate();

            window = Window.Instance;
            window.BackgroundColor = Color.White;

            myPage = new StyleDemoPage(window);
            Extensions.LoadFromXaml(myPage, typeof(StyleDemoPage));

            PushButton button = NameScopeExtensions.FindByName<PushButton>(myPage, "Click");
            FocusManager.Instance.SetCurrentFocusView(button);

            ImageView image = NameScopeExtensions.FindByName<ImageView>(myPage, "ImageView");

            bool flag = true;
            button.Clicked += (obj, e) =>
            {
                if (true == flag)
                {
                    image.ResourceUrl = "*DemoRes*/images/AmbientScreenUXControl/Cut/bixby_detail.png";
                }
                else
                {
                    image.ResourceUrl = "*DemoRes*/images/AmbientScreenUXControl/Cut/bixby_sendtophone.png";
                }

                //if (true == flag)
                //{
                //    image.PositionX = 200;
                //}
                //else
                //{
                //    image.PositionX = 500;
                //}

                flag = !flag;
                return true;
            };

            myPage.SetFocus();


        }

    }
}
