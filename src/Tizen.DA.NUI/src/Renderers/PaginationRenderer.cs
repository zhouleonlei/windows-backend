using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.DA.NUI.Controls;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.DA.NUI.res.PaginationRenderer.xaml", "PaginationRenderer.xaml", typeof(Tizen.DA.NUI.Renderers.PaginationRenderer))]

namespace Tizen.DA.NUI.Renderers
{
    public class PaginationRenderer : Tizen.NUI.Renderers.BaseRenderer
    {
        public PaginationRenderer() : base()
        {
            container = NameScopeExtensions.FindByName<View>(layout, "container");
            leftArrow = NameScopeExtensions.FindByName<ImageView>(layout, "leftArrow");
            rightArrow = NameScopeExtensions.FindByName<ImageView>(layout, "rightArrow");
        }

        protected override void Dispose(DisposeTypes type)
        {

        }

        public override void OnPropertyChanged(string type, View sender)
        {
            Pagination pagination = sender as Pagination;
            switch (type)
            {
                case "PageCount":
                    if (pagination.PageCount > indicatorList.Count)
                    {
                        int start = indicatorList.Count;
                        int end = pagination.PageCount < GetMaxDisplayCount() ? pagination.PageCount : GetMaxDisplayCount();
                        for (int i = start; i < end; i++)
                        {
                            Tizen.NUI.Controls.BaseControl indicator = new Indicator();
                            indicatorList.Add(indicator);
                        }
                    }
                    pageCount = pagination.PageCount;

                    Layout(selectedIndex, selectedIndex);

                    break;
                case "SelectedPageIndex":
                    Layout(selectedIndex, pagination.SelectedPageIndex);

                    int prevSelected = selectedIndex % GetMaxDisplayCount();
                    selectedIndex = pagination.SelectedPageIndex;
                    int curSelected = selectedIndex % GetMaxDisplayCount();
                    if (prevSelected != curSelected)
                    {
                        if (prevSelected != -1)
                        {
                            indicatorList[prevSelected].State = States.Normal;
                        }
                        indicatorList[curSelected].State = States.Selected;
                    }
                    break;
                default:
                    break;
            }
        }

        public override void OnStateChanged(States state)
        {

        }

        protected virtual int GetMaxDisplayCount()
        {
            return 10;
        }

        private void Layout(int prevIndex, int curIndex)
        {
            int maxDisCount = GetMaxDisplayCount();
            int partCount = (pageCount + maxDisCount - 1) / maxDisCount;
            int prevPart = prevIndex != -1 ? prevIndex / maxDisCount : -1;
            int curPart = curIndex != -1 ? curIndex / maxDisCount : -1;
            int prevCount = 0;
            if (prevPart >= 0)
            {
                prevCount = prevPart == partCount - 1 ? pageCount % maxDisCount : maxDisCount;
            }
            int currentCount = 0;
            if (curPart >= 0)
            {
                currentCount = curPart == partCount - 1 ? pageCount % maxDisCount : maxDisCount;
            }

            if (prevCount < currentCount)
            {
                for (int i = prevCount; i < currentCount; i++)
                {
                    container.Add(indicatorList[i]);
                    indicatorList[i].Position = new Position(i * 34, 0, 0);
                }
            }
            else
            {
                for (int i = currentCount; i < prevCount; i++)
                {
                    container.Remove(indicatorList[i]);
                }
            }

            if (curPart > 0)
            {
                leftArrow.Show();
            }
            else
            {
                leftArrow.Hide();
            }
            if (curPart < partCount - 1)
            {
                rightArrow.Show();
            }
            else
            {
                rightArrow.Hide();
            }
        }

        private View container;
        //private LinearLayout mainLayout;
        private List<Tizen.NUI.Controls.BaseControl> indicatorList = new List<Tizen.NUI.Controls.BaseControl>();
        protected int pageCount = 0;
        protected int selectedIndex = -1;

        private ImageView leftArrow;
        private ImageView rightArrow;
    }
}
