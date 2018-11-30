using System;
using System.Collections.Generic;
using System.Text;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.DA.NUI.res.PaginationWidgetRenderer.xaml", "PaginationWidgetRenderer.xaml", typeof(Tizen.DA.NUI.Renderers.PaginationWidgetRenderer))]

namespace Tizen.DA.NUI.Renderers
{
    public class PaginationWidgetRenderer : PaginationRenderer
    {
        public PaginationWidgetRenderer():base()
        {

        }

        protected override int GetMaxDisplayCount()
        {
            return 5;
        }
    }

}
