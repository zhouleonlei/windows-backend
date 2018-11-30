using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.VD.NUI.res.CIndicatorWhiteMediumRenderer.xaml", "CIndicatorWhiteMediumRenderer.xaml", typeof(Tizen.VD.NUI.Renderers.CIndicatorWhiteMediumRenderer))]

namespace Tizen.VD.NUI.Renderers
{
    public class CIndicatorWhiteMediumRenderer : Tizen.NUI.Renderers.IndicatorRenderer
    {
        public CIndicatorWhiteMediumRenderer() : base()
        {
            indicatorView = NameScopeExtensions.FindByName<ImageView>(layout, "indicator");
        }

        public override void OnStateChanged(States state)
        {
            indicatorView.State = state;
        }

        private ImageView indicatorView;
    }

}
