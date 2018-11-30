
using Tizen.VD.NUI.Renderers;

namespace Tizen.VD.NUI.Controls
{
    public class Pagination : Tizen.NUI.Controls.Pagination
    {
        //static constructor used to register internal style
        static Pagination()
        {
            RegisterStyle("C_Pagination_WhiteMedium", typeof(CPaginationWhiteMediumRenderer));
            RegisterStyle("C_Pagination_WhiteSmall", typeof(CPaginationWhiteSmallRenderer));
        }

        public Pagination() : base() { }
        public Pagination(string style) : base(style) { }

    }
}
