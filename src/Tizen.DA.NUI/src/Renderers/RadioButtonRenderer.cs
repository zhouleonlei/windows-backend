using Tizen.NUI.BaseComponents;
using Tizen.NUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.DA.NUI.res.RadioButtonRenderer.xaml", "RadioButtonRenderer.xaml", typeof(Tizen.DA.NUI.Renderers.RadioButtonRenderer))]

namespace Tizen.DA.NUI.Renderers
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
