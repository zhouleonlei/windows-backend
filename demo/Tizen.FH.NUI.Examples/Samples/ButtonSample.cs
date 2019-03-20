using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.FH.NUI.Samples
{
    public class ButtonSample : IExample
    {
        private static readonly float Height = 150;
        private static readonly float Width = 300;
        private static readonly Size2D Padding = new Size2D(50, 50);

        private uint colNum;
        private uint rowNum;

        private static string[] styles = new string[]
        {
            "Basic",
            "Service",
            "Toggle",
            "Oval"
        };

        private static string[] applications = new string[]
        {
            "Utility",
            "Family",
            "Food",
            "Kitchen",
        };

        private View root;

        public void Activate()
        {
            Window window = Window.Instance;

            if (styles.Length == 0 || applications.Length == 0)
            {
                return;
            }
            colNum = (uint)applications.Length + 1;
            rowNum = (uint)styles.Length + 1;

            root = new View()
            {
                Size2D = new Size2D(1920, 1080),
            };
            for (int i = 1; i < rowNum; i++)
            {
                TextLabel text = new TextLabel();
                text.Size2D = new Size2D(100, 50);
                text.Position2D = new Position2D(50 , 150 * i);
                text.PointSize = 20;
                text.Focusable = true;
                text.HorizontalAlignment = HorizontalAlignment.Center;
                text.VerticalAlignment = VerticalAlignment.Center;
                text.Text = styles[i - 1];
                root.Add(text);
            }

            for (int i = 1; i < colNum; i++)
            {
                TextLabel text = new TextLabel();
                text.Size2D = new Size2D(100, 50);
                text.Position2D = new Position2D(300 * i, 50);
                text.PointSize = 20;
                text.HorizontalAlignment = HorizontalAlignment.Center;
                text.VerticalAlignment = VerticalAlignment.Center;
                text.Text = applications[i - 1];
                text.Focusable = true;
                root.Add(text);
            }
            for (int i = 1; i < rowNum; i++)
            {
                for (int j = 1; j < colNum; j++)
                {
                    Button button = new Button(styles[i - 1] + "Button");
                    button.Position2D = new Position2D(300 * j, 150 * i);
                    if(i != 4)
                    {
                        button.Size2D = new Size2D(280, 80);
                        button.Text = applications[j - 1] + styles[i - 1] + "Button";
                    }
                    else
                    {
                        button.Size2D = new Size2D(104, 104);
                    }
                    
                    if (i == 3)
                    {
                        button.TextSelector = new StringSelector() { Normal = "Toggle Off", Selected = "Toggle On" };
                    }
                    else if(i == 4)
                    {

                    }
                    root.Add(button);
                }
            }

            window.Add(root);
        }

        public void Deactivate()
        {
            uint count = root.ChildCount;
            List<View> viewlist = new List<View>(root.Children);
            
            for(uint i = 0; i < count; i++)
            {
                root.Remove(viewlist[(int)i]);
                viewlist[(int)i].Dispose();
            }
            viewlist.Clear();
            
            if (root != null)
            {
                Window.Instance.Remove(root);
                root.Dispose();
            }
        }
    }
}
