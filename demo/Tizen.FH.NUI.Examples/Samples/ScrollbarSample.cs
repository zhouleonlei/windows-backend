using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Samples
{
    public class ScrollbarSample : IExample
    {
        private TextLabel board1, board2, board;
        private Button button1, button2, button3, button4;
        private ScrollBar scrollBar1, scrollBar2;
        private ScrollBar daScrollBar1, daScrollBar2;
        private SampleLayout root;

        public void Activate()
        {
            Window window = Window.Instance;

            root = new SampleLayout(false);
            root.HeaderText = "Scrollbar";

            CreateBoardAndButtons();

            daScrollBar1 = new ScrollBar("DAScrollbar");
            daScrollBar1.Position2D = new Position2D(100, 200);
            daScrollBar1.Size2D = new Size2D(300, 4);
            daScrollBar1.MaxValue = (uint)daScrollBar1.SizeWidth / 10;
            daScrollBar1.MinValue = 0;
            daScrollBar1.ThumbSize = new Size2D(30, 4);
            daScrollBar1.CurrentValue = 0;
            daScrollBar1.Direction = ScrollBar.DirectionType.Horizontal;
            root.Add(daScrollBar1);

            daScrollBar2 = new ScrollBar("DAScrollbar");
            daScrollBar2.Position2D = new Position2D(500, 100);
            daScrollBar2.Size2D = new Size2D(4, 300);
            daScrollBar2.MaxValue = (uint)daScrollBar1.SizeWidth / 10;
            daScrollBar2.MinValue = 0;
            daScrollBar2.ThumbSize = new Size2D(4, 30);
            daScrollBar2.CurrentValue = 0;
            daScrollBar2.Direction = ScrollBar.DirectionType.Vertical;
            root.Add(daScrollBar2);

            scrollBar1 = new ScrollBar();
            scrollBar1.Position2D = new Position2D(100, 300);
            scrollBar1.Size2D = new Size2D(300, 4);
            scrollBar1.TrackColor = Color.Green;
            scrollBar1.MaxValue = (uint)scrollBar1.SizeWidth / 10;
            scrollBar1.MinValue = 0;
            scrollBar1.ThumbSize = new Size2D(30, 4);
            scrollBar1.CurrentValue = 0;
            scrollBar1.ThumbColor = Color.Black;
            root.Add(scrollBar1);

            ScrollBarAttributes attr = new ScrollBarAttributes
            {
                TrackImageAttributes = new ImageAttributes
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(0.43f, 0.43f, 0.43f, 0.1f),
                    }
                },
                ThumbImageAttributes = new ImageAttributes
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(0.0f, 0.0f, 0.0f, 0.2f),
                    }
                },

            };

            scrollBar2 = new ScrollBar(attr);
            scrollBar2.Position2D = new Position2D(100, 400);
            scrollBar2.Size2D = new Size2D(300, 4);
            scrollBar2.MaxValue = (uint)scrollBar2.SizeWidth / 10;
            scrollBar2.MinValue = 0;
            scrollBar2.ThumbSize = new Size2D(30, 4);
            scrollBar2.CurrentValue = 0;

            root.Add(scrollBar2);

            board.UpFocusableView = button1;

            window.Add(root);

            FocusManager.Instance.SetCurrentFocusView(button1);
        }

        private void CreateBoardAndButtons()
        {
            board = new TextLabel();
            board.Size2D = new Size2D(1000, 100);
            board.Position2D = new Position2D(100, 600);
            board.PointSize = 30;
            board.HorizontalAlignment = HorizontalAlignment.Center;
            board.VerticalAlignment = VerticalAlignment.Center;
            board.BackgroundColor = Color.Magenta;
            board.Text = "Hello World!";
            root.Add(board);
            board.Focusable = true;
            board.FocusGained += Board_FocusGained;
            board.FocusLost += Board_FocusLost;

            board1 = new TextLabel();
            board1.Size2D = new Size2D(200, 70);
            board1.Position2D = new Position2D(100, 0);
            board1.PointSize = 30;
            board1.HorizontalAlignment = HorizontalAlignment.Center;
            board1.VerticalAlignment = VerticalAlignment.Center;
            board1.BackgroundColor = Color.Magenta;
            board1.Text = "Honrizal";
            root.Add(board1);
            board1.Focusable = true;
            board1.FocusGained += Board_FocusGained;
            board1.FocusLost += Board_FocusLost;

            board2 = new TextLabel();
            board2.Size2D = new Size2D(200, 70);
            board2.Position2D = new Position2D(450, 0);
            board2.PointSize = 30;
            board2.HorizontalAlignment = HorizontalAlignment.Center;
            board2.VerticalAlignment = VerticalAlignment.Center;
            board2.BackgroundColor = Color.Magenta;
            board2.Text = "vertical";
            root.Add(board2);
            board2.Focusable = true;
            board2.FocusGained += Board_FocusGained;
            board2.FocusLost += Board_FocusLost;

            button1 = new Button();
            button1.BackgroundColor = Color.Green;
            button1.Position2D = new Position2D(100, 500);
            button1.Size2D = new Size2D(80, 80);
            button1.Text = "+";
            root.Add(button1);
            button1.Focusable = true;
            button1.ClickEvent += Scroll1Add;

            button2 = new Button();
            button2.BackgroundColor = Color.Green;
            button2.Position2D = new Position2D(200, 500);
            button2.Size2D = new Size2D(80, 80);
            button2.Text = "-";
            root.Add(button2);
            button2.Focusable = true;
            button2.ClickEvent += Scroll1Minus;

            button3 = new Button();
            button3.BackgroundColor = Color.Green;
            button3.Position2D = new Position2D(450, 500);
            button3.Size2D = new Size2D(80, 80);
            button3.Text = "+";
            root.Add(button3);
            button3.Focusable = true;
            button3.ClickEvent += Scroll2Add;

            button4 = new Button();
            button4.BackgroundColor = Color.Green;
            button4.Position2D = new Position2D(550, 500);
            button4.Size2D = new Size2D(80, 80);
            button4.Text = "-";
            root.Add(button4);
            button4.Focusable = true;
            button4.ClickEvent += Scroll2Minus;
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
            if (root != null)
            {
                Window.Instance.Remove(root);
                root.Dispose();
            }
        }
    }
}
