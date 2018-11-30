using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;
using Tizen.NUI.Binding;
using System.Collections.Generic;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.NUI.res.PaginationRenderer.xaml", "PaginationRenderer.xaml", typeof(Tizen.NUI.Renderers.PaginationRenderer))]

namespace Tizen.NUI.Renderers
{
    public class PaginationRenderer : BaseRenderer
    {
        public PaginationRenderer() : base()
        {
            container = NameScopeExtensions.FindByName<View>(layout, "container");

            //mainLayout = NameScopeExtensions.FindByName<LinearLayout>(layout, "mainLayout");
            //mainLayout = new LinearLayout()
            //{
            //    LinearOrientation = LinearLayout.Orientation.Horizontal,
            //    CellPadding = new LayoutSize(14, 14),
            //    LinearAlignment = LinearLayout.Alignment.CenterHorizontal
            //};
            //container.Layout = mainLayout;
        }
        public override void OnPropertyChanged(string type, View sender)
        {
            Pagination pagination = sender as Pagination;
            switch (type)
            {
                case "PageCount":
                    if (pagination.PageCount > indicatorList.Count)
                    {
                        int addCount = pagination.PageCount - indicatorList.Count;
                        for (int i = 0; i < addCount; i++)
                        {
                            BaseControl indicator = GetIndicatorView();
                            indicatorList.Add(indicator);
                            container.Add(indicator);
                            indicator.Position = new Position(i * 29, 0, 0);
                        }
                    }
                    else if (pagination.PageCount < indicatorList.Count)
                    {
                        int delCount = indicatorList.Count - pagination.PageCount;
                        for (int i = pagination.PageCount; i < indicatorList.Count; i++)
                        {
                            container.Remove(indicatorList[i]);
                        }
                        indicatorList.RemoveRange(pagination.PageCount, delCount);
                    }
                    break;
                case "SelectedPageIndex":
                    if (selectedIndex != -1)
                    {
                        indicatorList[selectedIndex].State = States.Normal;
                    }
                    selectedIndex = pagination.SelectedPageIndex;
                    indicatorList[selectedIndex].State = States.Selected;
                    break;
                default:
                    break;
            }
        }

        public override void OnStateChanged(States state)
        {
            
        }

        protected virtual BaseControl GetIndicatorView()
        {
            return new Indicator();
        }

        private View container;
        //private LinearLayout mainLayout;
        protected List<BaseControl> indicatorList = new List<BaseControl>();
        protected int selectedIndex = -1;
    }
}
