using Tizen.NUI.BaseComponents;


namespace Tizen.NUI.Examples
{
    public class RadioButtonSample : NUIApplication
    {
        TextLabel board;
        Tizen.NUI.Controls.RadioButtonGroup group;
        Tizen.NUI.Controls.RadioButton radioButton1;
        Tizen.NUI.Controls.RadioButton radioButton2;

        Tizen.VD.NUI.Controls.RadioButtonGroup vdGroup;
        Tizen.VD.NUI.Controls.RadioButton vdRadioButton1;
        Tizen.VD.NUI.Controls.RadioButton vdRadioButton2;

        Tizen.DA.NUI.Controls.RadioButtonGroup daGroup;
        Tizen.DA.NUI.Controls.RadioButton daRadioButton1;
        Tizen.DA.NUI.Controls.RadioButton daRadioButton2;
        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            group = new Controls.RadioButtonGroup();
            radioButton1 = new Tizen.NUI.Controls.RadioButton("RadioButton");
            radioButton1.Name = "radioButton1";
            radioButton1.Position2D = new Position2D(100, 300);
            radioButton1.Size2D = new Size2D(300, 100);
            radioButton1.SelectBoxSize2D = new Size2D(38, 38);
            radioButton1.Text = "radioButton1";
            radioButton1.Focusable = true;
            radioButton1.SelectEvent += radioButton1_ClickEvent;
            group.Add(radioButton1);
            window.Add(radioButton1);

            radioButton2 = new Tizen.NUI.Controls.RadioButton("RadioButton");
            radioButton2.Name = "radioButton2";
            radioButton2.Position2D = new Position2D(100, 500);
            radioButton2.Size2D = new Size2D(100, 100);
            radioButton2.SelectBoxSize2D = new Size2D(38, 38);
            radioButton2.Focusable = true;
            radioButton2.SelectEvent += radioButton1_ClickEvent;
            group.Add(radioButton2);
            window.Add(radioButton2);

            vdGroup = new Tizen.VD.NUI.Controls.RadioButtonGroup();
            vdRadioButton1 = new Tizen.VD.NUI.Controls.RadioButton("C_RadioButton_White");
            vdRadioButton1.Name = "VDRadioButton1";
            vdRadioButton1.Position2D = new Position2D(500, 300);
            vdRadioButton1.Size2D = new Size2D(300, 100);
            vdRadioButton1.SelectBoxSize2D = new Size2D(38, 38);
            vdRadioButton1.Text = "VDRadioButton1";
            vdRadioButton1.Focusable = true;
            vdRadioButton1.SelectEvent += radioButton1_ClickEvent;
            vdGroup.Add(vdRadioButton1);
            window.Add(vdRadioButton1);

            vdRadioButton2 = new Tizen.VD.NUI.Controls.RadioButton("C_RadioButton_White");
            vdRadioButton2.Name = "VDRadioButton2";
            vdRadioButton2.Position2D = new Position2D(500, 500);
            vdRadioButton2.Size2D = new Size2D(100, 100);
            vdRadioButton2.SelectBoxSize2D = new Size2D(38, 38);
            vdRadioButton2.Focusable = true;
            vdRadioButton2.SelectEvent += radioButton1_ClickEvent;
            vdGroup.Add(vdRadioButton2);
            window.Add(vdRadioButton2);

            daGroup = new Tizen.DA.NUI.Controls.RadioButtonGroup();
            daRadioButton1 = new Tizen.DA.NUI.Controls.RadioButton("C_RadioButton");
            daRadioButton1.Name = "DARadioButton1";
            daRadioButton1.Position2D = new Position2D(800, 300);
            daRadioButton1.Size2D = new Size2D(300, 100);
            daRadioButton1.SelectBoxSize2D = new Size2D(48, 48);
            daRadioButton1.Text = "DARadioButton1";
            daRadioButton1.Focusable = true;
            daRadioButton1.SelectEvent += radioButton1_ClickEvent;
            daGroup.Add(daRadioButton1);
            window.Add(daRadioButton1);

            daRadioButton2 = new Tizen.DA.NUI.Controls.RadioButton("C_RadioButton");
            daRadioButton2.Name = "DARadioButton2";
            daRadioButton2.Position2D = new Position2D(800, 500);
            daRadioButton2.Size2D = new Size2D(100, 100);
            daRadioButton2.SelectBoxSize2D = new Size2D(48, 48);
            daRadioButton2.Focusable = true;
            daRadioButton2.SelectEvent += radioButton1_ClickEvent;
            daGroup.Add(daRadioButton2);
            window.Add(daRadioButton2);

            FocusManager.Instance.SetCurrentFocusView(radioButton1);

            radioButton1.RightFocusableView = vdRadioButton1;
            radioButton2.RightFocusableView = vdRadioButton2;
            radioButton2.UpFocusableView = radioButton1;
            radioButton1.DownFocusableView = radioButton2;
            vdRadioButton1.DownFocusableView = vdRadioButton2;
            vdRadioButton1.LeftFocusableView = radioButton1;
            vdRadioButton2.LeftFocusableView = radioButton2;
            vdRadioButton2.UpFocusableView = vdRadioButton1;
            vdRadioButton1.RightFocusableView = daRadioButton1;
            vdRadioButton2.RightFocusableView = daRadioButton2;
            daRadioButton1.DownFocusableView = daRadioButton2;
            daRadioButton1.LeftFocusableView = vdRadioButton1;
            daRadioButton2.LeftFocusableView = vdRadioButton2;
            daRadioButton2.UpFocusableView = daRadioButton1;

            board = new TextLabel();
            board.Size2D = new Size2D(1000, 100);
            board.Position2D = new Position2D(460, 800);
            board.PointSize = 30;
            board.HorizontalAlignment = HorizontalAlignment.Center;
            board.VerticalAlignment = VerticalAlignment.Center;
            board.BackgroundColor = Color.Magenta;
            window.Add(board);

        }

        private void radioButton1_ClickEvent(object sender, Tizen.NUI.Controls.RadioButton.SelectEventArgs e)
        {
            View view = sender as View;
            board.Text = view.Name + " Clicked, checkState = " + e.CheckState;
        }
    }
}
