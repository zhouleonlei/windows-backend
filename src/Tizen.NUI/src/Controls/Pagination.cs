using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Renderers;

namespace Tizen.NUI.Controls
{
    public class Pagination : BaseControl
    {
        //static constructor used to register internal style
        static Pagination()
        {
        }

        public Pagination() : base() { }
        public Pagination(string style) : base(style) { }

        public int PageCount
        {
            get
            {
                return pageCount;
            }
            set
            {
                if (value == pageCount)
                {
                    return;
                }

                pageCount = value;
                renderer.OnPropertyChanged("PageCount", this);
            }
        }

        public int SelectedPageIndex
        {
            get
            {
                return selectedPageIndex;
            }
            set
            {
                if (value == selectedPageIndex)
                {
                    return;
                }

                selectedPageIndex = value;
                renderer.OnPropertyChanged("SelectedPageIndex", this);
            }
        }

        protected override BaseRenderer GetRenderer()
        {
            return new PaginationRenderer();
        }

        private int pageCount = 0;
        private int selectedPageIndex = -1;
    }
}
