using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.NUI.Examples
{
    public class ScrollbarSample : IExample
    {
        private TextLabel board1, board2, board3, board, tl, tl2;
        private Button button1, button2, button3, button4;

        private ScrollBar familyScrollBar1, familyScrollBar2;


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

            familyScrollBar1 = new ScrollBar("FamilyBasicScrollbar");
            familyScrollBar1.Position2D = new Position2D(100, 500);
            familyScrollBar1.Size2D = new Size2D(300, 8);
            familyScrollBar1.MaxValue = (uint)familyScrollBar1.SizeWidth / 10;
            familyScrollBar1.MinValue = 0;
            familyScrollBar1.CurrentValue = 0;
            familyScrollBar1.ThumbSize = new Size(30.0f, 8.0f, 0.0f);
            familyScrollBar1.Direction = ScrollBar.DirectionType.Horizontal;

            window.Add(familyScrollBar1);

            familyScrollBar2 = new ScrollBar("FamilyBasicScrollbar");
            familyScrollBar2.Position2D = new Position2D(450, 300);
            familyScrollBar2.Size2D = new Size2D(8, 300);
            familyScrollBar2.MaxValue = (uint)familyScrollBar2.SizeHeight / 10;
            familyScrollBar2.MinValue = 0;
            familyScrollBar2.CurrentValue = 0;
            familyScrollBar2.ThumbSize = new Size(8.0f, 30.0f, 0.0f);
            familyScrollBar2.Direction = ScrollBar.DirectionType.Vertical;

            window.Add(familyScrollBar2);

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
            familyScrollBar1.CurrentValue++;
        }
        private void Scroll1Minus(object sender, global::System.EventArgs e)
        {
            familyScrollBar1.CurrentValue--;
        }
        private void Scroll2Add(object sender, global::System.EventArgs e)
        {
            familyScrollBar2.CurrentValue++;
        }
        private void Scroll2Minus(object sender, global::System.EventArgs e)
        {
            familyScrollBar2.CurrentValue--;
        }

        public void Deactivate()
        {
            Window window = Window.Instance;
        }
    }
}
