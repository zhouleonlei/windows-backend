using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.FH.NUI.Samples
{
    public class TabSample : IExample
    {
        private Tab tab = null;
        private Button button = null;
        private int index = 0;

        private static string[] mode = new string[]
        {
            "Utility Tab",
            "Family Tab",
            "Food Tab",
            "Kitchen Tab",
        };
        private static Color[] color = new Color[]
        {
            new Color(0.05f, 0.63f, 0.9f, 1),//#ff0ea1e6 Utility
            new Color(0.14f, 0.77f, 0.28f, 1),//#ff24c447 Family
            new Color(0.75f, 0.46f, 0.06f, 1),//#ffec7510 Food
            new Color(0.59f, 0.38f, 0.85f, 1),//#ff9762d9 Kitchen
        };

        public void Activate()
        {
            Window window = Window.Instance;

            tab = new Tab("DATab");
            tab.IsNatureTextWidth = false;
            tab.Size2D = new Size2D(1000, 108);
            tab.Position2D = new Position2D(200, 300);
            window.Add(tab);

            for (int i = 0; i < 3; i++)
            {
                Tab.TabItem item = new Tab.TabItem();
                item.Text = "Tab " + i;
                tab.AddItem(item);
            }

            button = new Button("UtilityServiceButton");
            button.Size2D = new Size2D(280, 80);
            button.Position2D = new Position2D(500, 700);
            button.Text = mode[index];
            button.ClickEvent += ButtonClickEvent;
            window.Add(button);
        }

        public void Deactivate()
        {           
            if(tab != null)
            {
                Window.Instance.Remove(tab);
                tab.Dispose();
                tab = null;
            }

            if (button != null)
            {
                Window.Instance.Remove(button);
                button.Dispose();
                button = null;
            }
        }

        private void ButtonClickEvent(object sender, Button.ClickEventArgs e)
        {
            index = (index + 1) % 4;
            button.Text = mode[index];
            tab.UnderLineBackgroundColor = color[index];
            tab.TextColorSelector = new ColorSelector
            {
                Normal = Color.Black,
                Selected = color[index],
            };
        }
    }
}
