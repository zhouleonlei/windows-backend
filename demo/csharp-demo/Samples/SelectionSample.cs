using Tizen.NUI.BaseComponents;


namespace Tizen.NUI.Examples
{
    public class SelectionSample : NUIApplication
    {
        TextLabel board;
        Tizen.NUI.Controls.Selection selection1;
        Tizen.NUI.Controls.Selection selection2;
        Tizen.VD.NUI.Controls.Selection selection3;
        Tizen.VD.NUI.Controls.Selection selection4;
        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = Window.Instance;

            selection1 = new Tizen.NUI.Controls.Selection("Selection");
            selection1.Name = "Selection1";
            selection1.Position2D = new Position2D(500, 300);
            selection1.Size2D = new Size2D(300, 100);
            selection1.CheckBoxSize2D = new Size2D(38, 38);
            selection1.Text = "Selection1";
            selection1.Focusable = true;
            selection1.SelectEvent += selection1_ClickEvent;
            window.Add(selection1);

            selection2 = new Tizen.NUI.Controls.Selection("Selection");
            selection2.Name = "Selection2";
            selection2.Position2D = new Position2D(1000, 300);
            selection2.Size2D = new Size2D(100, 100);
            selection2.CheckBoxSize2D = new Size2D(38, 38);
            selection2.Focusable = true;
            selection2.SelectEvent += selection1_ClickEvent;
            window.Add(selection2);

            selection3 = new Tizen.VD.NUI.Controls.Selection("C_Selection");
            selection3.Name = "VDSelection1";
            selection3.Position2D = new Position2D(500, 500);
            selection3.Size2D = new Size2D(300, 100);
            selection3.CheckBoxSize2D = new Size2D(38, 38);
            selection3.Text = "VDSelection1";
            selection3.Focusable = true;
            selection3.SelectEvent += selection1_ClickEvent;
            window.Add(selection3);

            selection4 = new Tizen.VD.NUI.Controls.Selection("C_Selection");
            selection4.Name = "VDSelection2";
            selection4.Position2D = new Position2D(1000, 500);
            selection4.Size2D = new Size2D(100, 100);
            selection4.CheckBoxSize2D = new Size2D(38, 38);
            selection4.Focusable = true;
            selection4.SelectEvent += selection1_ClickEvent;
            window.Add(selection4);

            FocusManager.Instance.SetCurrentFocusView(selection1);

            selection1.RightFocusableView = selection2;
            selection2.LeftFocusableView = selection1;
            selection2.DownFocusableView = selection4;
            selection1.DownFocusableView = selection3;
            selection3.UpFocusableView = selection1;
            selection3.RightFocusableView = selection4;
            selection4.LeftFocusableView = selection3;
            selection4.UpFocusableView = selection2;

            board = new TextLabel();
            board.Size2D = new Size2D(1000, 100);
            board.Position2D = new Position2D(460, 800);
            board.PointSize = 30;
            board.HorizontalAlignment = HorizontalAlignment.Center;
            board.VerticalAlignment = VerticalAlignment.Center;
            board.BackgroundColor = Color.Magenta;
            window.Add(board);

        }

        private void selection1_ClickEvent(object sender, Tizen.NUI.Controls.Selection.SelectEventArgs e)
        {
            View view = sender as View;
            board.Text = view.Name + " Clicked, checkState = " + e.CheckState;
        }
    }
}
