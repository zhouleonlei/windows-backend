using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Renderers
{
    public abstract class BaseRenderer : BaseHandle
    {
        public BaseRenderer()
        {
            layout = Extensions.LoadObject<XamlLayout>(GetType());
        }

        internal View Root
        {
            set
            {
                layout.RelateView = value;
            }
        }

        public abstract void OnPropertyChanged(string type, View sender);
        public abstract void OnStateChanged(States state);
        protected XamlLayout layout;
    }
}
