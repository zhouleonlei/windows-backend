using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.NUI.Examples
{
    public class ScrollbarSample : IExample
    {
        private TextLabel board1, board2, board3, board, tl, tl2;
        private Button button1, button2, button3, button4;

        private ScrollBar daScrollBar1, daScrollBar2;
        private ScrollBar vdScrollBar1, vdScrollBar2;


        public void Activate()
        {
            Window window = Window.Instance;

            board = new TextLabel();
            board.Size2D = new Size2D(1000, 100);
            board.Position2D = new Position2D(460, 900);
            board.PointSize = 30;
            board.HorizontalAlignment = HorizontalAlignment.Center;
            board.VerticalAlignment = VerticalAlignment.Center;
            board.BackgroundColor = Color.Magenta;
            board.Text = "Hello World!";
            window.Add(board);
            board.Focusable = true;
            board.FocusGained += Board_FocusGained;
            board.FocusLost += Board_FocusLost;

            board1 = new TextLabel();
            board1.Size2D = new Size2D(200, 70);
            board1.Position2D = new Position2D(100, 200);
            board1.PointSize = 30;
            board1.HorizontalAlignment = HorizontalAlignment.Center;
            board1.VerticalAlignment = VerticalAlignment.Center;
            board1.BackgroundColor = Color.Magenta;
            board1.Text = "Honrizal";
            window.Add(board1);
            board1.Focusable = true;
            board1.FocusGained += Board_FocusGained;
            board1.FocusLost += Board_FocusLost;

            board2 = new TextLabel();
            board2.Size2D = new Size2D(200, 70);
            board2.Position2D = new Position2D(400, 200);
            board2.PointSize = 30;
            board2.HorizontalAlignment = HorizontalAlignment.Center;
            board2.VerticalAlignment = VerticalAlignment.Center;
            board2.BackgroundColor = Color.Magenta;
            board2.Text = "vertical";
            window.Add(board2);
            board2.Focusable = true;
            board2.FocusGained += Board_FocusGained;
            board2.FocusLost += Board_FocusLost;

            board3 = new TextLabel();
            board3.Size2D = new Size2D(200, 70);
            board3.Position2D = new Position2D(700, 200);
            board3.PointSize = 30;
            board3.HorizontalAlignment = HorizontalAlignment.Center;
            board3.VerticalAlignment = VerticalAlignment.Center;
            board3.BackgroundColor = Color.Magenta;
            board3.Text = "VD";
            window.Add(board3);
            board3.Focusable = true;
            board3.FocusGained += Board_FocusGained;
            board3.FocusLost += Board_FocusLost;

            button1 = new Button("FamilyBasicButton");
            button1.BackgroundColor = Color.Green;
            button1.Position2D = new Position2D(100, 700);
            button1.Size2D = new Size2D(80, 50);
            button1.Text = "+";
            window.Add(button1);
            button1.Focusable = true;
            button1.ClickEvent += Scroll1Add;

            button2 = new Button("FamilyBasicButton");
            button2.BackgroundColor = Color.Green;
            button2.Position2D = new Position2D(200, 700);
            button2.Size2D = new Size2D(80, 50);
            button2.Text = "-";
            window.Add(button2);
            button2.Focusable = true;
            button2.ClickEvent += Scroll1Minus;

            button3 = new Button("FamilyBasicButton");
            button3.BackgroundColor = Color.Green;
            button3.Position2D = new Position2D(450, 700);
            button3.Size2D = new Size2D(80, 50);
            button3.Text = "+";
            window.Add(button3);
            button3.Focusable = true;
            button3.ClickEvent += Scroll2Add;

            button4 = new Button("FamilyBasicButton");
            button4.BackgroundColor = Color.Green;
            button4.Position2D = new Position2D(550, 700);
            button4.Size2D = new Size2D(80, 50);
            button4.Text = "-";
            window.Add(button4);
            button4.Focusable = true;
            button4.ClickEvent += Scroll2Minus;

            daScrollBar1 = new ScrollBar("DAScrollbar");
            daScrollBar1.Position2D = new Position2D(100, 500);
            daScrollBar1.Size2D = new Size2D(300, 4);
            daScrollBar1.MaxValue = (uint)daScrollBar1.SizeWidth / 10;
            daScrollBar1.MinValue = 0;
            daScrollBar1.CurrentValue = 0;
            daScrollBar1.ThumbSize = new Size(30.0f, 4.0f, 0.0f);
            daScrollBar1.Direction = ScrollBar.DirectionType.Horizontal;
            window.Add(daScrollBar1);
            daScrollBar1.TrackImageURL = "*DemoRes*/images/VD/component/c_progressbar/c_progressbar_white_buffering.png";

            daScrollBar2 = new ScrollBar("DAScrollbar");
            daScrollBar2.Position2D = new Position2D(450, 300);
            daScrollBar2.Size2D = new Size2D(4, 300);
            daScrollBar2.MaxValue = (uint)daScrollBar2.SizeHeight / 10;
            daScrollBar2.MinValue = 0;
            daScrollBar2.CurrentValue = 0;
            daScrollBar2.ThumbSize = new Size(4.0f, 30.0f, 0.0f);
            daScrollBar2.Direction = ScrollBar.DirectionType.Vertical;
            window.Add(daScrollBar2);
            daScrollBar2.PanGestureEvent += ScrollPan;

            vdScrollBar1 = new ScrollBar("VDScrollbar");
            vdScrollBar1.Position2D = new Position2D(800, 500);
            vdScrollBar1.Size2D = new Size2D(300, 3);
            vdScrollBar1.MaxValue = (uint)vdScrollBar1.SizeWidth / 10;
            vdScrollBar1.MinValue = 0;
            vdScrollBar1.CurrentValue = 0;
            vdScrollBar1.ThumbSize = new Size(30.0f, 3.0f, 0.0f);
            vdScrollBar1.Direction = ScrollBar.DirectionType.Horizontal;
            window.Add(vdScrollBar1);
            


            vdScrollBar2 = new ScrollBar("VDScrollbar");
            vdScrollBar2.Position2D = new Position2D(1150, 300);
            vdScrollBar2.Size2D = new Size2D(3, 300);
            vdScrollBar2.MaxValue = (uint)vdScrollBar2.SizeHeight / 10;
            vdScrollBar2.MinValue = 0;
            vdScrollBar2.CurrentValue = 0;
            vdScrollBar2.ThumbSize = new Size(3.0f, 30.0f, 0.0f);
            vdScrollBar2.Direction = ScrollBar.DirectionType.Vertical;
            window.Add(vdScrollBar2);

            board.UpFocusableView = button1;

            FocusManager.Instance.SetCurrentFocusView(button1);
        }

        private void Board_FocusLost(object sender, global::System.EventArgs e)
        {
            board.BackgroundColor = Color.Magenta;
        }

        private void Board_FocusGained(object sender, global::System.EventArgs e)
        {
            board.BackgroundColor = Color.Cyan;
        }

        private void Scroll1Add(object sender, global::System.EventArgs e)
        {
            daScrollBar1.CurrentValue++;
        }
        private void Scroll1Minus(object sender, global::System.EventArgs e)
        {
            daScrollBar1.CurrentValue--;
        }
        private void Scroll2Add(object sender, global::System.EventArgs e)
        {
            daScrollBar2.CurrentValue++;
        }
        private void Scroll2Minus(object sender, global::System.EventArgs e)
        {
            daScrollBar2.CurrentValue--;
        }

        private void ScrollPan(object sender, global::System.EventArgs e)
        {
            board.Text=board.Text+" 1";
            if (board.Text.Length > 20)
                board.Text = "";
        }

        public void Deactivate()
        {
            Window window = Window.Instance;
        }
    }
}
