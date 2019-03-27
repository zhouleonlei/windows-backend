using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;

namespace Tizen.NUI.Samples
{
    public class ToastSample : IExample
    {
        private TextLabel board1, board2, board;
        private Button button1, button2, button3, button4;
        private Toast toast1_1, toast1_2, toast2_1, toast2_2;  //1-null para 2-attributes; X_1-color; X_2 image track
        private View root;

        public void Activate()
        {
            Window window = Window.Instance;

            root = new View()
            {
                Size2D = new Size2D(1920, 1080),
            };

            CreateBoardAndButtons();

            toast1_1 = new Toast();
            toast1_1.Position2D = new Position2D(50, 350);
            toast1_1.Size2D = new Size2D(512, 132);
            toast1_1.BackgroundBorder = new Rectangle(64, 64, 4, 4);
            
            root.Add(toast1_1);
            toast1_1.Text = "null parameter construction";
            toast1_1.BackgroundImageURL = CommonResource.GetFHResourcePath() + "12. Toast Popup/toast_background.png";
            toast1_1.UpSpace = 38;
            toast1_1.LeftSpace = 96;

            ToastAttributes attr = new ToastAttributes
            {
                TextAttributes = new TextAttributes
                {
                    //    Position2D = "0,0"
                    //Size2D = "352,56"
                    //ParentOrigin = "Center"
                    //PivotPoint = "Center"
                    //PositionUsesPivotPoint = "True"

                    ParentOrigin = ParentOrigin.Center,
                    PivotPoint = PivotPoint.Center,
                    PositionUsesPivotPoint = true,
                    Text = new StringSelector
                    {
                        All = "attibute parameter construction",
                    }
                },
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceURL=new StringSelector
                    {
                        All = CommonResource.GetFHResourcePath() + "12. Toast Popup/toast_background.png",
                    },
                    Border = new RectangleSelector()
                    {
                        All = new Rectangle(64, 64, 4, 4),
                    }
                }

            };

            toast2_1 = new Toast(attr);
            toast2_1.Position2D = new Position2D(650, 350);
            toast2_1.Size2D = new Size2D(512, 110);
            root.Add(toast2_1);

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
            board2.Position2D = new Position2D(650, 200);
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
            button1.Size2D = new Size2D(200, 50);
            button1.Text = "toast1_1 Show";
            root.Add(button1);
            button1.Focusable = true;
            button1.ClickEvent += toast1_1Show;

            button2 = new Button();
            button2.BackgroundColor = Color.Green;
            button2.Position2D = new Position2D(700, 600);
            button2.Size2D = new Size2D(100, 50);
            button2.Text = "toast2_1 Show";
            root.Add(button2);
            button2.Focusable = true;
            button2.ClickEvent += toast2_1Show;

            //button3 = new Button();
            //button3.BackgroundColor = Color.Green;
            //button3.Position2D = new Position2D(450, 600);
            //button3.Size2D = new Size2D(80, 50);
            //button3.Text = "+";
            //root.Add(button3);
            //button3.Focusable = true;
            //button3.ClickEvent += Scroll2Add;

            //button4 = new Button();
            //button4.BackgroundColor = Color.Green;
            //button4.Position2D = new Position2D(550, 600);
            //button4.Size2D = new Size2D(80, 50);
            //button4.Text = "-";
            //root.Add(button4);
            //button4.Focusable = true;
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

        private void toast1_1Show(object sender, global::System.EventArgs e)
        {
            board.Text = "toast1_1 show: ";
            toast1_1.Show(3000, false);
        }

        private void toast2_1Show(object sender, global::System.EventArgs e)
        {
            board.Text = "toast2_1 show: ";
            toast2_1.Show(3000, false);
        }

        private void toast1FPSMinus(object sender, global::System.EventArgs e)
        {
            //board.Text = "toast1_1 FPS: " + toast1_1.FPS.ToString();
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
