using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    public class SwitchSample : IExample
    {
        Tizen.NUI.Controls.Switch _switch;
        Tizen.VD.NUI.Controls.Switch _switch1;

        public void Activate()
        {
            Window window = Window.Instance;

            _switch = new Controls.Switch();
            _switch.Position2D = new Position2D(500, 300);
            _switch.Size2D = new Size2D(300, 100);
            _switch.Focusable = true;

            string[] _onImageArray = new string[1];
            string[] _offImageArray = new string[1];
            _onImageArray[0] = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/c_switch/check/" + "c_switch_check_00.png";
            _offImageArray[0] = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/c_switch/check/" + "c_switch_check_25.png";
            _switch.OnImageArray = _onImageArray;
            _switch.OffImageArray = _offImageArray;
            _switch.CurrentState = Controls.Switch.OnOffStates.OnState;
            _switch.IsEnable = true;
            window.Add(_switch);

            _switch1 = new Tizen.VD.NUI.Controls.Switch();
            _switch1.Position2D = new Position2D(500, 500);
            _switch1.Size2D = new Size2D(300, 100);
            _switch1.Focusable = true;

            _switch1.OnImageArray = _onImageArray;
            _switch1.OffImageArray = _offImageArray;
            _switch1.CurrentState = Controls.Switch.OnOffStates.OnState;
            _switch1.IsEnable = false;

            window.Add(_switch1);


        }
        public void Deactivate()
        {
            Window window = Window.Instance;
            window.Remove(_switch);
            window.Remove(_switch1);
            _switch1.Dispose();
            _switch1.Dispose();
        }
    }
}
