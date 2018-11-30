using Tizen.DA.NUI.Renderers;

namespace Tizen.DA.NUI.Controls
{
    public class Pagination : Tizen.NUI.Controls.Pagination
    {
        //static constructor used to register internal style
        static Pagination()
        {
            RegisterStyle("PaginationApplication", typeof(PaginationRenderer));
            RegisterStyle("PaginationWidget", typeof(PaginationWidgetRenderer));
        }

        public Pagination() : base() { }
        public Pagination(string style) : base(style) { }
    }
}
