using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.FH.NUI.Samples
{
    public class TabSample : IExample
    {
        private SampleLayout root;
        private Tab tab = null;
        private Button[] button = new Button[2];
        private int num = 2;

        private static string[] mode = new string[]
        {
            "LargeTab",
            "Small Tab",
        };

        public void Activate()
        {
            root = new SampleLayout();
            root.HeaderText = "Tab";

            tab = new Tab("Tab");
            tab.IsNatureTextWidth = false;
            tab.Size2D = new Size2D(1080, 108);
            tab.Position2D = new Position2D(0, 300);
            tab.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            root.Add(tab);

            for (int i = 0; i < 3; i++)
            {
                Tab.TabItemData item = new Tab.TabItemData();
                item.Text = "Tab " + i;
                if(i == 1)
                {
                    item.Text = "Long long Tab " + i;
                }
                tab.AddItem(item);
            }

            for (int i = 0; i < num; i++)
            {
                button[i] = new Button("ServiceButton");
                button[i].Size2D = new Size2D(240, 80);
                button[i].Position2D = new Position2D(280 + i * 260, 700);
                button[i].Text = mode[i];
                button[i].ClickEvent += ButtonClickEvent;
                root.Add(button[i]);
            }
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

                for (int i = 0; i < num; i++)
                {
                    if (button[i] != null)
                    {
                        root.Remove(button[i]);
                        button[i].Dispose();
                        button[i] = null;
                    }
                }

                root.Dispose();
            }
        }

        private void ButtonClickEvent(object sender, Button.ClickEventArgs e)
        {
            Button btn = sender as Button;
            if(button[0] == btn)
            {
                tab.IsNatureTextWidth = false;
            }
            else if (button[1] == btn)
            {
                tab.IsNatureTextWidth = true;
            }

            //tab.DeleteItem(0);

            //Tab.TabItemData item = new Tab.TabItemData();
            //item.Text = "insert Tab ";
            //tab.InsertItem(item, 1);
        }
    }
}
