using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.FH.NUI.Samples
{
    public class DropDownSample : IExample
    {
        private DropDown dropDown = null;
        private Button button = null;
        private int index = 0;

        private static string[] mode = new string[]
        {
            "Utility DropDown",
            "Family DropDown",
            "Food DropDown",
            "Kitchen DropDown",
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

            dropDown = new DropDown("HeaderSpinner");
            dropDown.Size2D = new Size2D(1000, 108);
            dropDown.Position2D = new Position2D(200, 300);
            window.Add(dropDown);

            for (int i = 0; i < 3; i++)
            {
                DropDown.DropDownItemData itemData = new DropDown.DropDownItemData();
                itemData.Text = "DropDown " + i;
                dropDown.AddItem(itemData);
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
            if(dropDown != null)
            {
                Window.Instance.Remove(dropDown);
                dropDown.Dispose();
                dropDown = null;
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

        }
    }
}
