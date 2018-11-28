using Tizen.NUI.BaseComponents;
using Tizen.NUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.VD.NUI.res.CheckBoxRenderer.xaml", "CheckBoxRenderer.xaml", typeof(Tizen.VD.NUI.Renderers.CheckBoxRenderer))]

namespace Tizen.VD.NUI.Renderers
{
    public class CheckBoxRenderer : Tizen.NUI.Renderers.SelectionRenderer
    {
        public CheckBoxRenderer() : base()
        {
        }

        public override void OnPropertyChanged(string type, View sender)
        {
            base.OnPropertyChanged(type, sender);
        }

        public override void OnStateChanged(States state)
        {
            base.OnStateChanged(state);
        }
    }

}
