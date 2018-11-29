using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    public class ToggleButtonSample : NUIApplication
    {
        Tizen.NUI.Controls.ToggleButton _toggle;
        Tizen.DA.NUI.Controls.ToggleButton _toggle1;

        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            //SR
            _toggle = new Controls.ToggleButton();
            _toggle.Position2D = new Position2D(500, 300);
            _toggle.Size2D = new Size2D(100, 100);
            _toggle.Focusable = true;

            string[] _iconURL = new string[3];
            _iconURL[0] = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/c_toggle/" + "icon-change.png";
            _iconURL[1] = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/c_toggle/" + "icon-delete.png";
            _iconURL[2] = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/c_toggle/" + "icon-edit.png";
            
            _toggle.IconURL = _iconURL;

            string[] _text = new string[3];
            _text[0] = "change";
            _text[1] = "delete";
            _text[2] = "edit";

            _toggle.Text = _text;

            _toggle.CurrentStateIndex = 0;
            _toggle.StateEnable = true;
            

            window.Add(_toggle);

            //DA
            _toggle1 = new DA.NUI.Controls.ToggleButton();
            _toggle1.Position2D = new Position2D(500, 500);
            _toggle1.Size2D = new Size2D(100, 100);
            _toggle1.Focusable = true;

            _toggle1.Text = _text;
            _toggle1.CurrentStateIndex = 0;
            _toggle1.StateEnable = true;

            window.Add(_toggle1);



        }
    }
}
