using Tizen.NUI.CommonUI;
using Tizen.NUI;

namespace Tizen.NUI.Samples
{
    public class PaginationSample : IExample
    {
        private Pagination pagination1;

        private readonly int PAGE_COUNT = 5;

        public void Activate()
        {
            Window window = Window.Instance;

            pagination1 = new Pagination();
            pagination1.Name = "Pagination1";
            pagination1.Position2D = new Position2D(500, 450);
            pagination1.Size2D = new Size2D(400, 30);
            pagination1.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.6f);
            pagination1.IndicatorSize = new Size2D(26, 26);
            pagination1.IndicatorBackgroundURL = CommonReosurce.GetFHResourcePath() + "9. Controller/pagination_ic_nor.png";
            pagination1.IndicatorSelectURL = CommonReosurce.GetFHResourcePath() + "9. Controller/pagination_ic_sel.png";
            pagination1.IndicatorSpacing = 8;
            pagination1.IndicatorCount = PAGE_COUNT;
            pagination1.SelectedIndex = 0;
            pagination1.Focusable = true;
            window.Add(pagination1);

            window.KeyEvent += Window_KeyEvent;

        }

        private void Window_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Left")
                {
                    if (pagination1.SelectedIndex > 0)
                    {
                        pagination1.SelectedIndex = pagination1.SelectedIndex - 1;
                    }
                }
                else if (e.Key.KeyPressedName == "Right")
                {
                    if (pagination1.SelectedIndex < pagination1.IndicatorCount - 1)
                    {
                        pagination1.SelectedIndex = pagination1.SelectedIndex + 1;
                    }
                }
            }
        }

        public void Deactivate()
        {
            Window window = Window.Instance;
            window.Remove(pagination1);

            pagination1.Dispose();
        }
    }
}
