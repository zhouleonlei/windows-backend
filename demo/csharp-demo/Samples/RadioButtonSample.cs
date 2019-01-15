using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.NUI.Examples
{
    public class RadioButtonSample : IExample
    {
        private static readonly float Height = 150;
        private static readonly float Width = 300;
        private static readonly Size2D Padding = new Size2D(50, 50);

        private uint colNum;
        private uint rowNum;

        private Tizen.NUI.Controls.RadioButtonGroup[] group;

        private static string[] styles = new string[]
        {
            "",
            "",
            "",
            "",
        };

        private static string[] applications = new string[]
        {
            "Utility",
            "Family",
            "Food",
            "Kitchen",
        };

        private TableView root;

        public void Activate()
        {
            Window window = Window.Instance;

            if (styles.Length == 0 || applications.Length == 0)
            {
                return;
            }
            colNum = (uint)applications.Length + 1;
            rowNum = (uint)styles.Length + 1;

            root = new TableView(rowNum, colNum)
            {
                Size2D = new Size2D(1920, 1080),
            };
            for (uint i = 1; i < rowNum; i++)
            {
                TextLabel text = new TextLabel();
                text.Size2D = new Size2D(200, 50);
                text.PointSize = 20;
                text.Focusable = true;
                text.HorizontalAlignment = HorizontalAlignment.Center;
                text.VerticalAlignment = VerticalAlignment.Center;
                text.Text = styles[i - 1];
                root.AddChild(text, new TableView.CellPosition(i, 0));
            }

            for (uint i = 1; i < colNum; i++)
            {
                TextLabel text = new TextLabel();
                text.Size2D = new Size2D(100, 50);
                text.PointSize = 20;
                text.HorizontalAlignment = HorizontalAlignment.Center;
                text.VerticalAlignment = VerticalAlignment.Center;
                text.Text = applications[i - 1];
                text.Focusable = true;
                root.AddChild(text, new TableView.CellPosition(0, i));
            }

            group = new Controls.RadioButtonGroup[4];
            for (uint j = 1; j < colNum; j++)
            {
                group[j - 1] = new RadioButtonGroup();
                for (uint i = 1; i < rowNum; i++)
                {
                    RadioButton radioButton = new RadioButton(applications[j - 1] + styles[i - 1] + "RadioButton");
                    radioButton.Size2D = new Size2D(204, 104);
                    radioButton.Focusable = true;
                    radioButton.Text = radioButton.IsSelected.ToString();                   
                    group[j - 1].Add(radioButton); 
                    radioButton.SelectedEvent += RadioButtonSelectedEvent;
                    root.AddChild(radioButton, new TableView.CellPosition(i, j));
                }
            }

            for (uint i = 0; i < rowNum; i++)
            {
                root.SetFixedHeight(i, Height);
                for (uint j = 0; j < colNum; j++)
                {
                    root.SetFixedWidth(j, Width);
                    root.SetCellAlignment(new TableView.CellPosition(i, j), HorizontalAlignmentType.Center, VerticalAlignmentType.Center);
                }
            }

            //RadioButton child0 = root.GetChildAt(new TableView.CellPosition(1, 1)) as RadioButton;
            //RadioButton child1 = root.GetChildAt(new TableView.CellPosition(2, 1)) as RadioButton;
            //RadioButton child2 = root.GetChildAt(new TableView.CellPosition(3, 1)) as RadioButton;
            //RadioButton child3 = root.GetChildAt(new TableView.CellPosition(4, 1)) as RadioButton;
            //child0.DownFocusableView = child1;
            //child1.DownFocusableView = child2;
            //child2.DownFocusableView = child3;
            //child3.DownFocusableView = child0;
            //child0.UpFocusableView = child3;
            //child1.UpFocusableView = child0;
            //child2.UpFocusableView = child1;
            //child3.UpFocusableView = child2;
            window.Add(root);

            //FocusManager.Instance.SetCurrentFocusView(child0);
            //FocusManager.Instance.SetCurrentFocusView(root);
        }

        private void RadioButtonSelectedEvent(object sender, SelectButton.SelectEventArgs e)
        {
            RadioButton obj = sender as RadioButton;
            obj.Text = "State is " + e.IsSelected;
            for (uint i = 0; i < rowNum; i++)
            {
                for (uint j = 0; j < colNum; j++)
                {
                    RadioButton child = root.GetChildAt(new TableView.CellPosition(i, j)) as RadioButton;
                    if (child != null)
                    {
                        child.Text = "State is " + child.State;
                    }
                }
            }
        }

        public void Deactivate()
        {
            for (uint i = 0; i < rowNum; i++)
            {
                for (uint j = 0; j < colNum; j++)
                {
                    View child = root.GetChildAt(new TableView.CellPosition(i, j));
                    if (child != null)
                    {
                        root.RemoveChildAt(new TableView.CellPosition(i, j));
                        child.Dispose();
                    }
                }
            }

            if (root != null)
            {
                Window.Instance.Remove(root);
                root.Dispose();
            }
        }
    }
}
