using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;
using Tizen.NUI.Binding;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.NUI.res.IndicatorRenderer.xaml", "IndicatorRenderer.xaml", typeof(Tizen.NUI.Renderers.IndicatorRenderer))]

namespace Tizen.NUI.Renderers
{
    public class IndicatorRenderer : BaseRenderer
    {
        public IndicatorRenderer() : base()
        {
            //indicatorVisual = NameScopeExtensions.FindByName<PrimitiveVisual>(layout, "indicator");
        }

        public override void OnPropertyChanged(string type, View sender)
        {
            Pagination pagination = sender as Pagination;
            switch (type)
            {
                default:
                    break;
            }
        }
        public override void OnStateChanged(States state)
        {
            //indicatorVisual.State = state;
        }

        //PrimitiveVisual indicatorVisual;
    }
}
