using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;
using System;

namespace Tizen.NUI.Examples
{
    public class InputFieldSample : IExample
    {
        private InputField inputField1, inputField2;

        
        public void Activate()
        {
            CreateDA();
            Window.Instance.KeyEvent += OnWindowsKeyEvent;
        }

        private void CreateDA()
        {
            inputField1 = new InputField("UtilityTextInputField");
            inputField1.ParentOrigin = Tizen.NUI.ParentOrigin.Center;
            inputField1.PivotPoint = Tizen.NUI.PivotPoint.Center;
            inputField1.PositionUsesPivotPoint = true;
            inputField1.Size2D = new Size2D(1600, 100);
            inputField1.PositionY = -400;
            Window.Instance.Add(inputField1);
            inputField1.HintText = "Guide text";
            inputField1.CancelBtnClickEvent += OnCancelBtnClickEvent1;

            inputField2 = new InputField("UtilityTextInputField");
            inputField2.ParentOrigin = Tizen.NUI.ParentOrigin.Center;
            inputField2.PivotPoint = Tizen.NUI.PivotPoint.Center;
            inputField2.PositionUsesPivotPoint = true;
            inputField2.Size2D = new Size2D(1600, 100);
            inputField2.PositionY = -200;
            Window.Instance.Add(inputField2);
            inputField2.HintText = "Guide text";
        }

        private void OnWindowsKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Left")
                {
                    inputField1.Text = "test";
                }
                else if (e.Key.KeyPressedName == "Right")
                {
                    inputField1.Text = "";
                }
            }
        }

        public void Deactivate()
        {
            Window window = Window.Instance;
            window.KeyEvent -= OnWindowsKeyEvent;

            if (inputField1 != null)
            {
                inputField1.CancelBtnClickEvent -= OnCancelBtnClickEvent1;
                window.Remove(inputField1);
                inputField1.Dispose();
                inputField1 = null;
            }
            if (inputField2 != null)
            {
                window.Remove(inputField2);
                inputField2.Dispose();
                inputField2 = null;
            }
        }

        private void OnCancelBtnClickEvent1(object sender, NUI.Controls.InputField.CancelBtnClickArgs args)
        {
            if (sender is Tizen.NUI.Controls.InputField)
            {
                Console.WriteLine("-------, args.State = " + args.State);
            }
        }
    }
}
