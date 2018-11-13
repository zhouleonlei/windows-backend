using Tizen.NUI.Xaml;

namespace Tizen.NUI.BaseComponents
{
    public abstract class BaseRenderer : BaseHandle
    {
        public BaseRenderer()
        {
            layout = Extensions.LoadObject<XamlLayout>(GetLayoutPath());
        }

        internal View Root
        {
            set
            {
                layout.RelateView = value;
            }
        }

        public abstract void OnPropertyChanged(string type, View sender);
        public abstract void OnStateChanged(View.States state);

        //need to change to abstract method to request child class override it
        protected virtual string GetLayoutPath()
        {
            string resourceName = GetType().Name;
            resourceName = resourceName + "/" + resourceName + ".xaml";
            return Tizen.Applications.Application.Current.DirectoryInfo.Resource + "layout/" + resourceName;
        }

        protected XamlLayout layout;
    }
}
