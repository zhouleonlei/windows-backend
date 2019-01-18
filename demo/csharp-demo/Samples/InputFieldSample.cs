using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;
using System;

namespace Tizen.NUI.Examples
{
    public class InputFieldSample : IExample
    {
        private InputField inputField;

        
        public void Activate()
        {
            CreateDA();
            Window.Instance.KeyEvent += OnWindowsKeyEvent;
        }

        private void CreateDA()
        {
            inputField = new InputField("UtilityTextInputField");
            inputField.ParentOrigin = Tizen.NUI.ParentOrigin.Center;
            inputField.PivotPoint = Tizen.NUI.PivotPoint.Center;
            inputField.PositionUsesPivotPoint = true;
            inputField.Size2D = new Size2D(1600, 80);
            inputField.PositionY = -400;
            Window.Instance.Add(inputField);
            inputField.HintText = "Guide text";
        }

        private void OnWindowsKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Left")
                {
                    
                }
                
            }
        }

        public void Deactivate()
        {
            Window window = Window.Instance;
            window.KeyEvent -= OnWindowsKeyEvent;

            if (inputField != null)
            {
                window.Remove(inputField);
                inputField.Dispose();
                inputField = null;
            }
        }
    }
}
