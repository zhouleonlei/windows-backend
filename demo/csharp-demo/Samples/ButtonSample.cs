using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.NUI.Examples
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
                    Button button = new Button(applications[j - 1] + styles[i - 1] + "Button");
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
                        button.StateChangedEvent += Button_StateChangedEvent;
                    }
                    else if(i == 4)
                    {

                    }
                    root.Add(button);
                }
            }

            //for (uint i = 0; i < rowNum; i++)
            //{
            //    root.SetFixedHeight(i, Height);
            //    for (uint j = 0; j < colNum; j++)
            //    {
            //        root.SetFixedWidth(j, Width);
            //        root.SetCellAlignment(new TableView.CellPosition(i, j), HorizontalAlignmentType.Center, VerticalAlignmentType.Center);
            //    }
            //}
            //root.SetCellPadding(Padding);

            window.Add(root);

            button1 = new Button("UtilityBasicButton");
            button1.Size2D = new Size2D(300, 100);
            button1.Position2D = new Position2D(1500, 900);
            button1.Text = "test";
            root.Add(button1);

            FocusManager.Instance.SetCurrentFocusView(root);
        }
        Button button1;
        private void Button_StateChangedEvent(object sender, Button.StateChangeEventArgs e)
        {
            Button button = sender as Button;
            if (e.CurrentState == States.Normal)
            {
                button.Text = "Toggle Off";
            }
            else if (e.CurrentState == States.Selected)
            {
                button.Text = "Toggle On";
            }
        }

        public void Deactivate()
        {
            //for (uint i = 0; i < rowNum; i++)
            //{
            //    for (uint j = 0; j < colNum; j++)
            //    {
            //        View child = root.GetChildAt(new TableView.CellPosition(i, j));
            //        if (child != null)
            //        {
            //            root.RemoveChildAt(new TableView.CellPosition(i, j));
            //            child.Dispose();
            //        }
            //    }
            //}

            if (root != null)
            {
                Window.Instance.Remove(root);
                root.Dispose();
            }
        }
    }
}
