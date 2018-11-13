using Tizen.NUI;
using Tizen.NUI.Xaml;
using Tizen.Applications;
namespace Tizen.TV.NUI.Example
{
    public class XamlSamplesPage : ContentPage
    {
        public XamlSamplesPage(Window win):base(win)
        {
        }

        protected override void Dispose(DisposeTypes type)
        {
            if(disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {

            }
            base.Dispose(type);
        }

        public new void SetFocus()
        {
            base.SetFocus();
        }
    }
    
    public class SampleMain : NUIApplication
    {
        private Window window;
        private ContentPage myPage;
      
        protected override void OnCreate()
        {
            base.OnCreate();

            Window.Instance.BackgroundColor = Color.White;

            window = Window.Instance;

            myPage = new ContentPage(window);

            Extensions.LoadFromXaml(myPage, typeof(XamlSamplesPage));

            Tizen.Log.Info("NUIJINWOO", "Res Path:"+ Application.Current.DirectoryInfo.Resource);

            myPage.SetFocus();
        }

        //static void Main(string[] args)
        //{
        //    var app = new SampleMain();
        //    app.Run(args);
        //}
    }
}

