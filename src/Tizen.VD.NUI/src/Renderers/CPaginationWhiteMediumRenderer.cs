using Tizen.VD.NUI.Controls;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.VD.NUI.res.CPaginationWhiteMediumRenderer.xaml", "CPaginationWhiteMediumRenderer.xaml", typeof(Tizen.VD.NUI.Renderers.CPaginationWhiteMediumRenderer))]

namespace Tizen.VD.NUI.Renderers
{
    public class CPaginationWhiteMediumRenderer : Tizen.NUI.Renderers.PaginationRenderer
    {
        public CPaginationWhiteMediumRenderer() : base()
        {
        }

        protected override Tizen.NUI.Controls.BaseControl GetIndicatorView()
        {
            return new Indicator("C_Indicator_WhiteMedium");
        }

    }

}
