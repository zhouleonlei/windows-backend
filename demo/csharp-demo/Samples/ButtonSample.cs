using Tizen.NUI.BaseComponents;


namespace Tizen.NUI.Examples
{
    public class ButtonSample : NUIApplication
    {
        TextLabel board;
        Tizen.NUI.Controls.Button btn1;
        Tizen.NUI.Controls.Button btn2;
        Tizen.VD.NUI.Controls.Button btn3;
        Tizen.VD.NUI.Controls.Button btn4;
        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = Window.Instance;

            btn1 = new Tizen.NUI.Controls.Button("Text");
            btn1.Name = "SRTextButton";
            btn1.Position2D = new Position2D(500, 300);
            btn1.Size2D = new Size2D(300, 100);
            btn1.Text = "SRTextButton";
            btn1.Focusable = true;
            btn1.ClickEvent += Btn1_ClickEvent;
            window.Add(btn1);

            btn2 = new Tizen.NUI.Controls.Button("Icon");
            btn2.Position2D = new Position2D(1000, 300);
            btn2.Size2D = new Size2D(100, 100);
            btn2.BackgroundColor = Color.Green;
            btn2.IconURL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/" + "star-highlight.png";
            btn2.IconSize2D = new Size2D(40, 40);
            btn2.Focusable = true;
            window.Add(btn2);

            btn3 = new Tizen.VD.NUI.Controls.Button("C_ButtonBasic_WhiteText");
            btn3.Name = "VDTextButton";
            btn3.Position2D = new Position2D(500, 500);
            btn3.Size2D = new Size2D(300, 100);
            btn3.Text = "VDTextButton";
            btn3.Focusable = true;
            btn3.ClickEvent += Btn1_ClickEvent;
            window.Add(btn3);

            btn4 = new Tizen.VD.NUI.Controls.Button("C_ButtonBasic_WhiteIcon");
            btn4.Position2D = new Position2D(1000, 500);
            btn4.Size2D = new Size2D(100, 100);
            btn4.IconURL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/" + "star-highlight.png";
            btn4.IconSize2D = new Size2D(40, 40);
            btn4.Focusable = true;
            window.Add(btn4);

            FocusManager.Instance.SetCurrentFocusView(btn1);

            btn1.RightFocusableView = btn2;
            btn2.LeftFocusableView = btn1;
            btn2.DownFocusableView = btn4;
            btn1.DownFocusableView = btn3;
            btn3.UpFocusableView = btn1;
            btn3.RightFocusableView = btn4;
            btn4.LeftFocusableView = btn3;
            btn4.UpFocusableView = btn2;

            board = new TextLabel();
            board.Size2D = new Size2D(1000, 100);
            board.Position2D = new Position2D(460, 800);
            board.PointSize = 30;
            board.HorizontalAlignment = HorizontalAlignment.Center;
            board.VerticalAlignment = VerticalAlignment.Center;
            board.BackgroundColor = Color.Magenta;
            window.Add(board);

        }

        private void Btn1_ClickEvent(object sender, Tizen.NUI.Controls.Button.ClickEventArgs e)
        {
            View view = sender as View;
            board.Text = view.Name + " Clicked";

        }
    }
}
