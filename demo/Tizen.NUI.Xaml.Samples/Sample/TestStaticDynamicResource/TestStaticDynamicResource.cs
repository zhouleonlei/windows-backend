using Tizen.NUI.Xaml;

namespace Tizen.NUI.Examples
{
    public class TestStaticDynamicResource : Tizen.NUI.Binding.Application
    {
        private ContentPage myPage;
        private Window window;

        protected override void OnCreate() 
        {
            window = Window.Instance;

            myPage = new TestStaticDynamicResourcePage(window);
            myPage.SetFocus();
        }
    }
}
