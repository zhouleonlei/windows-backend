using Tizen.NUI.BaseComponents;


namespace Tizen.NUI.Examples
{
    public class CheckBoxSample : NUIApplication
    {
        TextLabel board;
        Tizen.NUI.Controls.CheckBoxGroup group;
        Tizen.NUI.Controls.CheckBox checkBox1;
        Tizen.NUI.Controls.CheckBox checkBox2;

        Tizen.VD.NUI.Controls.CheckBoxGroup vdGroup;
        Tizen.VD.NUI.Controls.CheckBox vdCheckBox1;
        Tizen.VD.NUI.Controls.CheckBox vdCheckBox2;

        Tizen.DA.NUI.Controls.CheckBoxGroup daGroup;
        Tizen.DA.NUI.Controls.CheckBox daCheckBox1;
        Tizen.DA.NUI.Controls.CheckBox daCheckBox2;
        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            group = new Controls.CheckBoxGroup();
            checkBox1 = new Tizen.NUI.Controls.CheckBox("CheckBox");
            checkBox1.Name = "checkBox1";
            checkBox1.Position2D = new Position2D(100, 300);
            checkBox1.Size2D = new Size2D(300, 100);
            checkBox1.SelectBoxSize2D = new Size2D(38, 38);
            checkBox1.Text = "checkBox1";
            checkBox1.Focusable = true;
            checkBox1.SelectEvent += checkBox1_ClickEvent;
            group.Add(checkBox1);
            window.Add(checkBox1);

            checkBox2 = new Tizen.NUI.Controls.CheckBox("CheckBox");
            checkBox2.Name = "checkBox2";
            checkBox2.Position2D = new Position2D(100, 500);
            checkBox2.Size2D = new Size2D(100, 100);
            checkBox2.SelectBoxSize2D = new Size2D(38, 38);
            checkBox2.Focusable = true;
            checkBox2.SelectEvent += checkBox1_ClickEvent;
            group.Add(checkBox2);
            window.Add(checkBox2);

            vdGroup = new Tizen.VD.NUI.Controls.CheckBoxGroup();
            vdCheckBox1 = new Tizen.VD.NUI.Controls.CheckBox("C_CheckBox_White");
            vdCheckBox1.Name = "VDcheckBox1";
            vdCheckBox1.Position2D = new Position2D(500, 300);
            vdCheckBox1.Size2D = new Size2D(300, 100);
            vdCheckBox1.SelectBoxSize2D = new Size2D(38, 38);
            vdCheckBox1.Text = "VDcheckBox1";
            vdCheckBox1.Focusable = true;
            vdCheckBox1.SelectEvent += checkBox1_ClickEvent;
            vdGroup.Add(vdCheckBox1);
            window.Add(vdCheckBox1);

            vdCheckBox2 = new Tizen.VD.NUI.Controls.CheckBox("C_CheckBox_White");
            vdCheckBox2.Name = "VDcheckBox2";
            vdCheckBox2.Position2D = new Position2D(500, 500);
            vdCheckBox2.Size2D = new Size2D(100, 100);
            vdCheckBox2.SelectBoxSize2D = new Size2D(38, 38);
            vdCheckBox2.Focusable = true;
            vdCheckBox2.SelectEvent += checkBox1_ClickEvent;
            vdGroup.Add(vdCheckBox2);
            window.Add(vdCheckBox2);

            daGroup = new Tizen.DA.NUI.Controls.CheckBoxGroup();
            daCheckBox1 = new Tizen.DA.NUI.Controls.CheckBox("C_CheckBox");
            daCheckBox1.Name = "DACheckBox1";
            daCheckBox1.Position2D = new Position2D(800, 300);
            daCheckBox1.Size2D = new Size2D(300, 100);
            daCheckBox1.SelectBoxSize2D = new Size2D(48, 48);
            daCheckBox1.Text = "DACheckBox1";
            daCheckBox1.Focusable = true;
            daCheckBox1.SelectEvent += checkBox1_ClickEvent;
            daGroup.Add(daCheckBox1);
            window.Add(daCheckBox1);

            daCheckBox2 = new Tizen.DA.NUI.Controls.CheckBox("C_CheckBox");
            daCheckBox2.Name = "DACheckBox2";
            daCheckBox2.Position2D = new Position2D(800, 500);
            daCheckBox2.Size2D = new Size2D(100, 100);
            daCheckBox2.SelectBoxSize2D = new Size2D(48, 48);
            daCheckBox2.Focusable = true;
            daCheckBox2.SelectEvent += checkBox1_ClickEvent;
            daGroup.Add(daCheckBox2);
            window.Add(daCheckBox2);

            FocusManager.Instance.SetCurrentFocusView(checkBox1);

            checkBox1.RightFocusableView = vdCheckBox1;
            checkBox2.RightFocusableView = vdCheckBox2;
            checkBox2.UpFocusableView = checkBox1;
            checkBox1.DownFocusableView = checkBox2;
            vdCheckBox1.DownFocusableView = vdCheckBox2;
            vdCheckBox1.LeftFocusableView = checkBox1;
            vdCheckBox2.LeftFocusableView = checkBox2;
            vdCheckBox2.UpFocusableView = vdCheckBox1;
            vdCheckBox1.RightFocusableView = daCheckBox1;
            vdCheckBox2.RightFocusableView = daCheckBox2;
            daCheckBox1.DownFocusableView = daCheckBox2;
            daCheckBox1.LeftFocusableView = vdCheckBox1;
            daCheckBox2.LeftFocusableView = vdCheckBox2;
            daCheckBox2.UpFocusableView = daCheckBox1;

            board = new TextLabel();
            board.Size2D = new Size2D(1000, 100);
            board.Position2D = new Position2D(460, 800);
            board.PointSize = 30;
            board.HorizontalAlignment = HorizontalAlignment.Center;
            board.VerticalAlignment = VerticalAlignment.Center;
            board.BackgroundColor = Color.Magenta;
            window.Add(board);

        }

        private void checkBox1_ClickEvent(object sender, Tizen.NUI.Controls.CheckBox.SelectEventArgs e)
        {
            View view = sender as View;
            board.Text = view.Name + " Clicked, checkState = " + e.CheckState;
        }
    }
}
