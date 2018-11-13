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
    public class TestStaticResource : NUIApplication
    {
        private ContentPage myPage;
        private Window window;

        protected override void OnCreate() 
        {
            base.OnCreate();

            window = Window.Instance;

            myPage = new TestStaticResourcePage(window);
            Extensions.LoadFromXaml(myPage, typeof(TestStaticResourcePage));
            myPage.SetFocus();

            window.KeyEvent += Window_KeyEvent;
        }

        int positionX = 200;
        int positionY = 200;

        private void Window_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            bool changePosition = false;

            if (e.Key.State == Key.StateType.Up)
            {
                if (e.Key.KeyPressedName == "Up")
                {
                    positionY -= 50;
                    if (positionY < 0)
                    {
                        positionY = 0;
                    }

                    changePosition = true;
                }
                else if (e.Key.KeyPressedName == "Down")
                {
                    positionY += 50;
                    if (positionY > 1000)
                    {
                        positionY = 1000;
                    }

                    changePosition = true;
                }
                else if (e.Key.KeyPressedName == "Left")
                {
                    positionX -= 50;
                    if (positionX < 0)
                    {
                        positionX = 0;
                    }

                    changePosition = true;
                }
                else if (e.Key.KeyPressedName == "Right")
                {
                    positionX += 50;
                    if (positionX > 1200)
                    {
                        positionX = 1200;
                    }

                    changePosition = true;
                }
            }

            if (true == changePosition)
            {
                Tizen.NUI.Binding.ResourceDictionary dict = Tizen.NUI.GetResourcesProvider.Get().Resources;
                int hashCode = dict.GetHashCode();
                Tizen.NUI.GetResourcesProvider.Get().Resources["positionKey"] = positionX.ToString() + "," + positionY.ToString();
            }
        }
    }
}
