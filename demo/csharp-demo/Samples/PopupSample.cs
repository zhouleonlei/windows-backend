using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.NUI.Examples
{
    public class PopupSample : IExample
    {
        private static readonly float Height = 150;
        private static readonly float Width = 300;
        private static readonly Size2D Padding = new Size2D(50, 50);

        private uint colNum;
        private uint rowNum;

        private static string[] styles = new string[]
        {
            "",
        };

        private static string[] applications = new string[]
        {
            "",
        };

        private static string[] buttonStyles = new string[]
        {
            "UtilityPopupButton",
            "FamilyPopupButton",
            "FoodPopupButton",
            "KitchenPopupButton",
        };

        private TableView root;
        private TextLabel contentText = null;
        private int index = 0;
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
                text.Size2D = new Size2D(300, 50);
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

            for (uint j = 1; j < colNum; j++)
            {
                for (uint i = 1; i < rowNum; i++)
                {
                    Popup popup = new Popup("DAPopup");
                    popup.ButtonStyle = buttonStyles[index];
                    popup.Size2D = new Size2D(1032, 500);
                    popup.TitleText = "Popup Title";
                    popup.ButtonCount = 2;
                    popup.SetButtonText(0, "Yes");
                    popup.SetButtonText(1, "Exit");
                    popup.PopupButtonClickedEvent += PopupButtonClickedEvent;

                    if (contentText == null)
                    {
                        contentText = new TextLabel();
                        contentText.Size2D = new Size2D(800, 200);
                        contentText.PointSize = 20;
                        contentText.HorizontalAlignment = HorizontalAlignment.Begin;
                        contentText.VerticalAlignment = VerticalAlignment.Center;
                        contentText.Text = "Popup ButtonStyle is " + popup.ButtonStyle;
                    }
                    popup.ContentView.Add(contentText);

                    root.AddChild(popup, new TableView.CellPosition(i, j));                   
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

            window.Add(root);

            FocusManager.Instance.SetCurrentFocusView(root);
        }

        private void PopupButtonClickedEvent(object sender, Popup.ButtonClickEventArgs e)
        {
            Popup child = root.GetChildAt(new TableView.CellPosition(1, 1)) as Popup;
            if(child != null && e.ButtonIndex == 0)
            {
                index++;
                index = index % buttonStyles.Length;
                child.ButtonStyle = buttonStyles[index];
                contentText.Text = "Popup ButtonStyle is " + child.ButtonStyle;
            }           
        }

        public void Deactivate()
        {
            for (uint i = 0; i < rowNum; i++)
            {
                for (uint j = 0; j < colNum; j++)
                {
                    Popup child = root.GetChildAt(new TableView.CellPosition(i, j)) as Popup;
                    if (child != null)
                    {
                        child.ContentView.Remove(contentText);
                        root.RemoveChildAt(new TableView.CellPosition(i, j));
                        child.Dispose();
                    }
                }
            }

            if(contentText != null)
            {
                contentText.Dispose();
                contentText = null;
            }

            if (root != null)
            {
                Window.Instance.Remove(root);
                root.Dispose();
            }
        }
    }
}
