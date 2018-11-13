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
    class TestMultiResolutionSample : NUIApplication
    {
        private Window window;
        private ContentPage myPage;

        protected override void OnCreate()
        {
            base.OnCreate();

            window = Window.Instance;

            //window.BackgroundColor = new Color(0.75f, 0.75f, 0.75f, 0.8f);

            myPage = new TestMultiResolution(window);

            Extensions.LoadFromXaml(myPage, typeof(TestMultiResolution));

            myPage.SetFocus();
        }
    }
}
