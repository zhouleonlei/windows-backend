using Tizen.NUI.Xaml;
using Tizen.NUI.Xaml.Forms.BaseComponents;

namespace Tizen.NUI.Examples
{
    public class TestStaticDynamicResource : NUIApplication
    {
        private View myPage;
        private Window window;

        protected override void OnCreate() 
        {
            window = Window.Instance;
            myPage = new TestStaticDynamicResourcePage();
            window.Add(myPage.ViewInstance);
        }
    }
}
