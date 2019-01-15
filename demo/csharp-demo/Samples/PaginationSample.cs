using Tizen.NUI.BaseComponents;
using Tizen.DA.NUI.Controls;

namespace Tizen.NUI.Examples
{
    public class PaginationSample : IExample
    {
        private Pagination DAPagination1;
        private Pagination DAPagination2;

        private readonly int PAGE_COUNT = 14;

        public void Activate()
        {
            Window window = Window.Instance;

            DAPagination1 = new Pagination("BasicPagination");
            DAPagination1.Name = "DAAppPagination1";
            DAPagination1.Position2D = new Position2D(500, 450);
            DAPagination1.Size2D = new Size2D(400, 30);
            DAPagination1.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.6f);
            DAPagination1.IndicatorCount = PAGE_COUNT;
            DAPagination1.SelectedIndex = 0;
            DAPagination1.Focusable = true;
            window.Add(DAPagination1);

            DAPagination2 = new Pagination("BasicPagination");
            DAPagination2.Name = "DAAppPagination2";
            DAPagination2.Position2D = new Position2D(500, 500);
            DAPagination2.Size2D = new Size2D(230, 30);
            DAPagination2.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.6f);
            DAPagination2.IndicatorCount = PAGE_COUNT;
            DAPagination2.SelectedIndex = 1;
            DAPagination2.Focusable = true;
            window.Add(DAPagination2);

            window.KeyEvent += Window_KeyEvent;

        }

        private void Window_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Left")
                {
                    if (DAPagination1.SelectedIndex > 0)
                    {
                        DAPagination1.SelectedIndex = DAPagination1.SelectedIndex - 1;
                    }
                    if (DAPagination2.SelectedIndex > 0)
                    {
                        DAPagination2.SelectedIndex = DAPagination2.SelectedIndex - 1;
                    }
                }
                else if (e.Key.KeyPressedName == "Right")
                {
                    if (DAPagination1.SelectedIndex < DAPagination1.IndicatorCount - 1)
                    {
                        DAPagination1.SelectedIndex = DAPagination1.SelectedIndex + 1;
                    }
                    if (DAPagination2.SelectedIndex < DAPagination2.IndicatorCount - 1)
                    {
                        DAPagination2.SelectedIndex = DAPagination2.SelectedIndex + 1;
                    }
                }
            }
        }

        public void Deactivate()
        {
            Window window = Window.Instance;
            window.Remove(DAPagination1);
            window.Remove(DAPagination2);

            DAPagination1.Dispose();
            DAPagination2.Dispose();
        }
    }
}
