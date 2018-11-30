using Tizen.VD.NUI.Controls;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.VD.NUI.res.CPaginationWhiteSmallRenderer.xaml", "CPaginationWhiteSmallRenderer.xaml", typeof(Tizen.VD.NUI.Renderers.CPaginationWhiteSmallRenderer))]

namespace Tizen.VD.NUI.Renderers
{
    public class CPaginationWhiteSmallRenderer : Tizen.NUI.Renderers.PaginationRenderer
    {
        public CPaginationWhiteSmallRenderer() : base()
        {
        }

        protected override Tizen.NUI.Controls.BaseControl GetIndicatorView()
        {
            return new Indicator("C_Indicator_WhiteSmall");
        }

    }

}
