using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;
using System;


namespace Tizen.NUI.Examples
{
    class A
    {
        public virtual void Test()
        {
            Console.WriteLine("A.Test()\n");
        }
    }

    class B: A
    {
        public override void Test()
        {
            Console.WriteLine("B.Test()\n");
        }
    }

    class C: B
    {
        public override void Test()
        {
            base.Test();
            Console.WriteLine("C.Test()\n");
        }
    }
    public class PaginationSample : IExample
    {
        private Pagination pagination;
        private Pagination vdMediumPagination;
        private Pagination vdSmallPagination;

        private Pagination daAppPagination;
        private Pagination daWidgetPagination;

        private readonly int PAGE_COUNT = 5;
        private int currentSelectIndex = 0;
        private readonly int PAGE_COUNT_1 = 14;
        private int currentSelectIndex1 = 0;
        public void Activate()
        {
            Window window = Window.Instance;

            pagination = new Pagination();
            pagination.Name = "SRPagination";
            pagination.Position2D = new Position2D(500, 300);
            pagination.Size2D = new Size2D(1000, 20);
            pagination.BackgroundColor = Color.Cyan;
            pagination.PageCount = PAGE_COUNT;
            pagination.SelectedPageIndex = currentSelectIndex;
            pagination.Focusable = true;
            window.Add(pagination);

            vdMediumPagination = new Tizen.VD.NUI.Controls.Pagination("C_Pagination_WhiteMedium");
            vdMediumPagination.Name = "VDMediumPagination";
            vdMediumPagination.Position2D = new Position2D(500, 350);
            vdMediumPagination.Size2D = new Size2D(1000, 20);
            vdMediumPagination.BackgroundColor = Color.Cyan;
            vdMediumPagination.PageCount = PAGE_COUNT;
            vdMediumPagination.SelectedPageIndex = currentSelectIndex;
            vdMediumPagination.Focusable = true;
            window.Add(vdMediumPagination);

            vdSmallPagination = new Tizen.VD.NUI.Controls.Pagination("C_Pagination_WhiteSmall");
            vdSmallPagination.Name = "VDSmallPagination";
            vdSmallPagination.Position2D = new Position2D(500, 400);
            vdSmallPagination.Size2D = new Size2D(1000, 20);
            vdSmallPagination.BackgroundColor = Color.Cyan;
            vdSmallPagination.PageCount = PAGE_COUNT;
            vdSmallPagination.SelectedPageIndex = currentSelectIndex;
            vdSmallPagination.Focusable = true;
            window.Add(vdSmallPagination);

            daAppPagination = new Tizen.DA.NUI.Controls.Pagination("PaginationApplication");
            daAppPagination.Name = "DAAppPagination";
            daAppPagination.Position2D = new Position2D(500, 450);
            daAppPagination.Size2D = new Size2D(1000, 30);
            daAppPagination.BackgroundColor = Color.Cyan;
            daAppPagination.PageCount = PAGE_COUNT_1;
            daAppPagination.SelectedPageIndex = currentSelectIndex1;
            daAppPagination.Focusable = true;
            window.Add(daAppPagination);

            daWidgetPagination = new Tizen.DA.NUI.Controls.Pagination("PaginationWidget");
            daWidgetPagination.Name = "DAWidgetPagination";
            daWidgetPagination.Position2D = new Position2D(500, 500);
            daWidgetPagination.Size2D = new Size2D(1000, 30);
            daWidgetPagination.BackgroundColor = Color.Cyan;
            daWidgetPagination.PageCount = PAGE_COUNT_1;
            daWidgetPagination.SelectedPageIndex = currentSelectIndex1;
            daWidgetPagination.Focusable = true;
            window.Add(daWidgetPagination);

            window.KeyEvent += Window_KeyEvent;


            A test = new C();
            test.Test();
        }
        public void Deactivate()
        {
            Window window = Window.Instance;
            window.Remove(pagination);
            window.Remove(vdMediumPagination);
            window.Remove(vdSmallPagination);
            window.Remove(daAppPagination);
            window.Remove(daWidgetPagination);
            pagination.Dispose();
            vdMediumPagination.Dispose();
            vdSmallPagination.Dispose();
            daAppPagination.Dispose();
            daWidgetPagination.Dispose();
        }

        private void Window_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Left")
                {
                    if (currentSelectIndex > 0)
                    {
                        currentSelectIndex--;
                        //pagination.SelectedPageIndex = currentSelectIndex;
                        vdMediumPagination.SelectedPageIndex = currentSelectIndex;
                        vdSmallPagination.SelectedPageIndex = currentSelectIndex;
                        daAppPagination.SelectedPageIndex = currentSelectIndex;
                    }
                    if (currentSelectIndex1 > 0)
                    {
                        currentSelectIndex1--;
                        daAppPagination.SelectedPageIndex = currentSelectIndex1;
                        daWidgetPagination.SelectedPageIndex = currentSelectIndex1;
                    }
                }
                else if (e.Key.KeyPressedName == "Right")
                {
                    if (currentSelectIndex < PAGE_COUNT - 1)
                    {
                        currentSelectIndex++;
                        //pagination.SelectedPageIndex = currentSelectIndex;
                        vdMediumPagination.SelectedPageIndex = currentSelectIndex;
                        vdSmallPagination.SelectedPageIndex = currentSelectIndex;
                    }
                    if (currentSelectIndex1 < PAGE_COUNT_1 - 1)
                    {
                        currentSelectIndex1++;
                        daAppPagination.SelectedPageIndex = currentSelectIndex1;
                        daWidgetPagination.SelectedPageIndex = currentSelectIndex1;
                    }
                }
            }
        }
    }
}
