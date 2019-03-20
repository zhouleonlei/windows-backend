using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;
using Tizen.FH.NUI.Controls;
using Tizen.NUI;

namespace Tizen.FH.NUI.Samples
{
    public class ProgressSample : IExample
    {
        private TextLabel board1, board2, board3, board, tl, tl2;
        private Button button1, button2, button3, button4, button5;
        int status = 0;
        private ProgressCircle progressCircle1, familyProgressBar2;
        private Progress progressBar1, progressBar2, progressBar3, progressBar4;
        private View root;

        public void Activate()
        {
            Window window = Window.Instance;
            root = new View()
            {
                Size2D = new Size2D(1920, 1080),
            };

            board = new TextLabel();
            board.Size2D = new Size2D(1000, 100);
            board.Position2D = new Position2D(460, 800);
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
            board1.Size2D = new Size2D(200, 60);
            board1.Position2D = new Position2D(50, 200);
            board1.PointSize = 30;
            board1.HorizontalAlignment = HorizontalAlignment.Center;
            board1.VerticalAlignment = VerticalAlignment.Center;
            board1.BackgroundColor = Color.Magenta;
            board1.Text = "DA";
            root.Add(board1);
            board1.Focusable = true;
            board1.FocusGained += Board_FocusGained;
            board1.FocusLost += Board_FocusLost;

            board2 = new TextLabel();
            board2.Size2D = new Size2D(200, 60);
            board2.Position2D = new Position2D(350, 200);
            board2.PointSize = 30;
            board2.HorizontalAlignment = HorizontalAlignment.Center;
            board2.VerticalAlignment = VerticalAlignment.Center;
            board2.BackgroundColor = Color.Magenta;
            board2.Text = "Circle";
            root.Add(board2);
            board2.Focusable = true;
            board2.FocusGained += Board_FocusGained;
            board2.FocusLost += Board_FocusLost;

            button1 = new Button("BasicButton");
            button1.BackgroundColor = Color.Green;
            button1.Position2D = new Position2D(100, 600);
            button1.Size2D = new Size2D(50, 50);
            button1.Text = "+";
            root.Add(button1);
            button1.Focusable = true;
            button1.ClickEvent += bar1Add;

            button2 = new Button("BasicButton");
            button2.BackgroundColor = Color.Green;
            button2.Position2D = new Position2D(200, 600);
            button2.Size2D = new Size2D(50, 50);
            button2.Text = "-";
            root.Add(button2);
            button2.Focusable = true;
            button2.ClickEvent += bar1Minus;

            button3 = new Button("BasicButton");
            button3.BackgroundColor = Color.Green;
            button3.Position2D = new Position2D(450, 600);
            button3.Size2D = new Size2D(50, 50);
            button3.Text = "+";
            root.Add(button3);
            button3.Focusable = true;
            button3.ClickEvent += circle1Add;

            button4 = new Button("BasicButton");
            button4.BackgroundColor = Color.Green;
            button4.Position2D = new Position2D(550, 600);
            button4.Size2D = new Size2D(50, 50);
            button4.Text = "-";
            root.Add(button4);
            button4.Focusable = true;
            button4.ClickEvent += circle1Minus;

            button5 = new Button("BasicButton");
            button5.BackgroundColor = Color.Green;
            button5.Position2D = new Position2D(650, 600);
            button5.Size2D = new Size2D(200, 60);
            button5.Text = "change status";
            root.Add(button5);
            button5.Focusable = true;
            button5.ClickEvent += circleStatusChanged;

            progressCircle1 = new ProgressCircle("VDProgressCircle");
            progressCircle1.Position2D = new Position2D(400, 400);
            progressCircle1.MaxValue = 100;
            progressCircle1.MinValue = 0;
            progressCircle1.CurrentValue = 45;
            progressCircle1.ProgressState = Progress.ProgressStatusType.Determinate;
            progressCircle1.Direction = Progress.DirectionType.Horizontal;
            root.Add(progressCircle1);
            progressCircle1.IsTextEnabled = true;

            progressBar1 = new Progress("UtilityProgressbar");
            progressBar1.Position2D = new Position2D(80, 350);
            progressBar1.Size2D = new Size2D(140, 4);
            progressBar1.MaxValue = 100;
            progressBar1.MinValue = 0;
            progressBar1.CurrentValue = 45;
            progressBar1.Direction = Progress.DirectionType.Horizontal;
            root.Add(progressBar1);

            progressBar2 = new Progress("FoodProgressbar");
            progressBar2.Position2D = new Position2D(80, 420);
            progressBar2.Size2D = new Size2D(140, 4);
            progressBar2.MaxValue = 100;
            progressBar2.MinValue = 0;
            progressBar2.CurrentValue = 15;
            progressBar2.Direction = Progress.DirectionType.Horizontal;
            root.Add(progressBar2);

            progressBar3 = new Progress("FamilyProgressbar");
            progressBar3.Position2D = new Position2D(80, 490);
            progressBar3.Size2D = new Size2D(140, 4);
            progressBar3.MaxValue = 100;
            progressBar3.MinValue = 0;
            progressBar3.CurrentValue = 30;
            progressBar3.Direction = Progress.DirectionType.Horizontal;
            root.Add(progressBar3);

            progressBar4 = new Progress("KitchenProgressbar");
            progressBar4.Position2D = new Position2D(80, 560);
            progressBar4.Size2D = new Size2D(140, 4);
            progressBar4.MaxValue = 100;
            progressBar4.MinValue = 0;
            progressBar4.CurrentValue = 75;
            progressBar4.Direction = Progress.DirectionType.Horizontal;
            root.Add(progressBar4);

            board.UpFocusableView = button1;
            window.Add(root);
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

        private void bar1Add(object sender, global::System.EventArgs e)
        {
            global::System.Console.WriteLine("+++++++++++++");
            board.Text = "+";
            progressBar1.CurrentValue++;
        }
        private void bar1Minus(object sender, global::System.EventArgs e)
        {
            global::System.Console.WriteLine("----------------");
            board.Text = "-";
            progressBar1.CurrentValue--;
        }
        private void circle1Add(object sender, global::System.EventArgs e)
        {
            global::System.Console.WriteLine("+++++++++++++");
            board.Text = "+";
            progressCircle1.CurrentValue++;
        }
        private void circle1Minus(object sender, global::System.EventArgs e)
        {
            global::System.Console.WriteLine("----------------");
            board.Text = "-";
            progressCircle1.CurrentValue--;
        }

        private void circleStatusChanged(object sender, global::System.EventArgs e)
        {
            global::System.Console.WriteLine("----------------");

            status++;
            if (status > 2)
                status = 0;
            if (status == 0)
            {
                button5.Text = "Buffer";
                progressCircle1.ProgressState = Progress.ProgressStatusType.Buffering;
            }
            if (status == 1)
            {
                button5.Text = "Deter";
                progressCircle1.ProgressState = Progress.ProgressStatusType.Determinate;
            }
            if (status == 2)
            {
                button5.Text = "indeter";
                progressCircle1.ProgressState = Progress.ProgressStatusType.Indeterminate;
            }
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
