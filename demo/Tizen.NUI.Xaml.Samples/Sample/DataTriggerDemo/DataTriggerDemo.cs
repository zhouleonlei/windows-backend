using Tizen.NUI.Xaml;

namespace Tizen.NUI.Examples
{
    public class DataTriggerDemo : Tizen.NUI.Binding.Application
    {
        private ContentPage myPage;
        private Window window;

        protected override void OnCreate() 
        {
            base.OnCreate();

            window = Window.Instance;
            window.BackgroundColor = Color.White;

            myPage = new DataTriggerDemoPage(window);
            myPage.SetFocus();
        }
    }
}
