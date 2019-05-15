
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;
using Tizen.NUI.Xaml.Forms.BaseComponents;
using Tizen.NUI.Xaml.UIComponents;

namespace Tizen.NUI.Examples
{
    public class TriggerWithDataBindingDemo : Tizen.NUI.Binding.Application
    {
        private ContentPage myPage;
        private Window window;

        protected override void OnCreate() 
        {
            base.OnCreate();

            window = Window.Instance;
            window.BackgroundColor = Color.White;

            myPage = new TriggerWithDataBindingDemoPage(window);

            myPage.SetFocus();
        }
    }
}
