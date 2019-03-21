using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.FH.NUI.Samples
{
    public class TabSample : IExample
    {
        private SampleLayout root;
        private Tab tab = null;
        private Button button = null;
        private int index = 0;

        private static string[] mode = new string[]
        {
            "LargeTab",
            "Small Tab",
        };

        public void Activate()
        {
            root = new SampleLayout();
            root.HeaderText = "Tab";

            tab = new Tab("DATab");
            tab.IsNatureTextWidth = false;
            tab.Size2D = new Size2D(1080, 108);
            tab.Position2D = new Position2D(0, 300);
            tab.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            root.Add(tab);

            for (int i = 0; i < 3; i++)
            {
                Tab.TabItem item = new Tab.TabItem();
                item.Text = "Tab " + i;
                if(i == 1)
                {
                    item.Text = "Long long Tab " + i;
                }
                tab.AddItem(item);
            }

            button = new Button("ServiceButton");
            button.Size2D = new Size2D(280, 80);
            button.Position2D = new Position2D(400, 700);
            button.Text = mode[index];
            button.ClickEvent += ButtonClickEvent;
            root.Add(button);
        }

        public void Deactivate()
        {
            if (root != null)
            {
                if (tab != null)
                {
                    root.Remove(tab);
                    tab.Dispose();
                    tab = null;
                }

                if (button != null)
                {
                    root.Remove(button);
                    button.Dispose();
                    button = null;
                }

                root.Dispose();
            }
        }

        private void ButtonClickEvent(object sender, Button.ClickEventArgs e)
        {
            index = (index + 1) % 2;
            button.Text = mode[index];
            if(index == 0)
            {
                tab.IsNatureTextWidth = false;
            }
            else if (index == 1)
            {
                tab.IsNatureTextWidth = true;
            }
        }
    }
}
