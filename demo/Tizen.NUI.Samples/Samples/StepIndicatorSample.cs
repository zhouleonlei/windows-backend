using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.NUI.Samples
{
    public class StepIndicatorSample : IExample
    {
        private TextLabel board1, board2, board;
        private Button button1, button2, button3, button4;
        private StepIndicator stepIndicator1_1, stepIndicator1_2, stepIndicator2_1, stepIndicator2_2;  //1-null para 2-attributes; X_1-color; X_2 image track
        private View root;

        public void Activate()
        {
            Window window = Window.Instance;

            root = new View()
            {
                Size2D = new Size2D(1920, 1080),
            };

            CreateBoardAndButtons();

            stepIndicator1_1 = new StepIndicator();
            stepIndicator1_1.Position2D = new Position2D(100, 350);
            stepIndicator1_1.Size2D = new Size2D(500, 100);//
            //"F:\0213\CommonUI\demo\csharp - demo\res\images\VD\component\c_stepindicator";
            //stepIndicator1_1.LoadingImageURLPrefix = CommonReosurce.GetFHResourcePath() + "9. Controller/Loading Sequence_Native/loading_";
            stepIndicator1_1.Steps = 3;
            stepIndicator1_1.StepSize = new Size(120.0f, 101.0f, 0.0f);
            stepIndicator1_1.LeftArrowSize = new Size(42, 42, 0.0f);
            stepIndicator1_1.RightArrowSize = new Size(42, 42, 0.0f);
            stepIndicator1_1.LeftArrowURL = CommonReosurce.GetTVResourcePath() + "component/c_slider/c_slider_white_arrow_left.png";
            stepIndicator1_1.RightArrowURL = CommonReosurce.GetTVResourcePath() + "component/c_slider/c_slider_white_arrow_right.png";
            global::System.Console.WriteLine("!!! set checkURL");
            stepIndicator1_1.CheckImageURL = CommonReosurce.GetTVResourcePath() + "component/c_stepindicator/c_stepindicator_check.png";
            //stepIndicator1_1.le

            root.Add(stepIndicator1_1);

            StepIndicatorAttributes attr = new StepIndicatorAttributes
            {


            };

            stepIndicator2_1 = new StepIndicator(attr);
            stepIndicator2_1.Position2D = new Position2D(500, 350);
            stepIndicator2_1.Size2D = new Size2D(100, 100);
            root.Add(stepIndicator2_1);

            board.UpFocusableView = button1;

            window.Add(root);

            FocusManager.Instance.SetCurrentFocusView(button1);
        }

        void CreateBoardAndButtons()
        {
            board = new TextLabel();
            board.Size2D = new Size2D(1000, 100);
            board.Position2D = new Position2D(430, 900);
            board.PointSize = 30;
            board.HorizontalAlignment = HorizontalAlignment.Center;
            board.VerticalAlignment = VerticalAlignment.Center;
            board.BackgroundColor = Color.Magenta;
            board.Text = "log pad";
            root.Add(board);
            board.Focusable = true;
            board.FocusGained += Board_FocusGained;
            board.FocusLost += Board_FocusLost;

            board1 = new TextLabel();
            board1.Size2D = new Size2D(300, 70);
            board1.Position2D = new Position2D(50, 200);
            board1.PointSize = 20;
            board1.HorizontalAlignment = HorizontalAlignment.Center;
            board1.VerticalAlignment = VerticalAlignment.Center;
            board1.BackgroundColor = Color.Magenta;
            board1.Text = "NULL parameter construction";
            root.Add(board1);
            board1.Focusable = true;
            board1.FocusGained += Board_FocusGained;
            board1.FocusLost += Board_FocusLost;

            board2 = new TextLabel();
            board2.Size2D = new Size2D(300, 70);
            board2.Position2D = new Position2D(600, 200);
            board2.PointSize = 20;
            board2.HorizontalAlignment = HorizontalAlignment.Center;
            board2.VerticalAlignment = VerticalAlignment.Center;
            board2.BackgroundColor = Color.Magenta;
            board2.Text = "Attribute construction";
            root.Add(board2);
            board2.Focusable = true;
            board2.FocusGained += Board_FocusGained;
            board2.FocusLost += Board_FocusLost;

            button1 = new Button();
            button1.BackgroundColor = Color.Green;
            button1.Position2D = new Position2D(80, 600);
            button1.Size2D = new Size2D(100, 50);
            button1.Text = "FPS++";
            root.Add(button1);
            button1.Focusable = true;
            button1.ClickEvent += loading1FPSAdd;

            button2 = new Button();
            button2.BackgroundColor = Color.Green;
            button2.Position2D = new Position2D(200, 600);
            button2.Size2D = new Size2D(100, 50);
            button2.Text = "FPS--";
            root.Add(button2);
            button2.Focusable = true;
            button2.ClickEvent += loading1FPSMinus;

            button3 = new Button();
            button3.BackgroundColor = Color.Green;
            button3.Position2D = new Position2D(450, 600);
            button3.Size2D = new Size2D(80, 50);
            button3.Text = "+";
            root.Add(button3);
            button3.Focusable = true;
            //button3.ClickEvent += Scroll2Add;

            button4 = new Button();
            button4.BackgroundColor = Color.Green;
            button4.Position2D = new Position2D(550, 600);
            button4.Size2D = new Size2D(80, 50);
            button4.Text = "-";
            root.Add(button4);
            button4.Focusable = true;
            // button4.ClickEvent += Scroll2Minus;
        }

        private void Board_FocusLost(object sender, global::System.EventArgs e)
        {
            board.BackgroundColor = Color.Magenta;
        }

        private void Board_FocusGained(object sender, global::System.EventArgs e)
        {
            board.BackgroundColor = Color.Cyan;
        }

        private void loading1FPSAdd(object sender, global::System.EventArgs e)
        {
            // board.Text = "loading1_1 FPS: "+loading1_1.FPS.ToString();
            // loading1_1.FPS += 1;
        }
        private void loading1FPSMinus(object sender, global::System.EventArgs e)
        {
            // board.Text = "loading1_1 FPS: " + loading1_1.FPS.ToString();
            // loading1_1.FPS -= 1;
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
