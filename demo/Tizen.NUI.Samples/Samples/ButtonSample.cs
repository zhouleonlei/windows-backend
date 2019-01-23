using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.NUI.Samples
{
    public class ButtonSample : IExample
    {
        private static readonly float Height = 150;
        private static readonly float Width = 300;
        private static readonly Size2D Padding = new Size2D(50, 50);
        private View root;
        Button textButton;
        Button iconButton;

        public void Activate()
        {
            Window window = Window.Instance;

            root = new View()
            {
                Size2D = new Size2D(1920, 1080),
            };
            window.Add(root);

            textButton = new Button();
            textButton.BackgroundImageURL = CommonReosurce.GetTVResourcePath() + "component/c_buttonbasic/c_basic_button_white_bg_normal_9patch.png";
            textButton.BackgroundImageBorder = new Rectangle(4, 4, 5, 5);
            textButton.Size2D = new Size2D(300, 80);
            textButton.Position2D = new Position2D(100, 100);
            textButton.Text = "Button";
            root.Add(textButton);

            iconButton = new Button();
            iconButton.BackgroundImageURL = CommonReosurce.GetTVResourcePath() + "component/c_buttonbasic/c_basic_button_white_bg_normal_9patch.png";
            iconButton.BackgroundImageBorder = new Rectangle(4, 4, 5, 5);
            iconButton.Size2D = new Size2D(100, 100);
            iconButton.Position2D = new Position2D(600, 100);
            iconButton.IconURL = CommonReosurce.GetTVResourcePath() + "component/c_radiobutton/c_radiobutton_white_check.png";
            root.Add(iconButton);


        }
        

        public void Deactivate()
        {
            if (root != null)
            {
                Window.Instance.Remove(root);
                root.Dispose();
            }
        }
    }
}
