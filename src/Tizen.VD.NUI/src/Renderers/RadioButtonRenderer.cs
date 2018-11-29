using Tizen.NUI.BaseComponents;
using Tizen.NUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.VD.NUI.res.RadioButtonRenderer.xaml", "RadioButtonRenderer.xaml", typeof(Tizen.VD.NUI.Renderers.RadioButtonRenderer))]

namespace Tizen.VD.NUI.Renderers
{
    public class RadioButtonRenderer : Tizen.NUI.Renderers.SelectionRenderer
    {
        public RadioButtonRenderer() : base()
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
