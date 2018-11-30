using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.VD.NUI.res.CIndicatorWhiteSmallRenderer.xaml", "CIndicatorWhiteSmallRenderer.xaml", typeof(Tizen.VD.NUI.Renderers.CIndicatorWhiteSmallRenderer))]

namespace Tizen.VD.NUI.Renderers
{
    public class CIndicatorWhiteSmallRenderer : Tizen.NUI.Renderers.IndicatorRenderer
    {
        public CIndicatorWhiteSmallRenderer() : base()
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
