using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.DA.NUI.res.IndicatorRenderer.xaml", "IndicatorRenderer.xaml", typeof(Tizen.DA.NUI.Renderers.IndicatorRenderer))]

namespace Tizen.DA.NUI.Renderers
{
    public class IndicatorRenderer: Tizen.NUI.Renderers.IndicatorRenderer
    {
        public IndicatorRenderer() : base()
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
