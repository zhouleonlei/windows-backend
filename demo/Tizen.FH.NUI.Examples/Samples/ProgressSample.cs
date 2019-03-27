using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;
using Tizen.FH.NUI.Controls;
using Tizen.NUI;

namespace Tizen.FH.NUI.Samples
{
    public class ProgressSample : IExample
    {
        private TextLabel board1, board2, board3, board, tl, tl2;
        private Button button1, button2, button3, button4, button5;
        int status = 0;
        private Progress progressBar1, progressBar2, progressBar3, progressBar4;
        private SampleLayout root;

        public void Activate()
        {
            Window window = Window.Instance;
            root = new SampleLayout();
            root.HeaderText = "Progress";

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

            button1 = new Button("BasicButton");
            button1.BackgroundColor = Color.Green;
            button1.Position2D = new Position2D(300, 200);
            button1.Size2D = new Size2D(80, 80);
            button1.Text = "+";
            root.Add(button1);
            button1.Focusable = true;
            button1.ClickEvent += bar1Add;

            button2 = new Button("BasicButton");
            button2.BackgroundColor = Color.Green;
            button2.Position2D = new Position2D(700, 200);
            button2.Size2D = new Size2D(80, 80);
            button2.Text = "-";
            root.Add(button2);
            button2.Focusable = true;
            button2.ClickEvent += bar1Minus;
         
            progressBar1 = new Progress("Progressbar");
            progressBar1.Position2D = new Position2D(300, 100);
            progressBar1.Size2D = new Size2D(500, 4);
            progressBar1.MaxValue = 100;
            progressBar1.MinValue = 0;
            progressBar1.CurrentValue = 45;
            root.Add(progressBar1);

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
