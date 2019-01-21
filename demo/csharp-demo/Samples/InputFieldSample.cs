using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;
using System;

namespace Tizen.NUI.Examples
{
    public class InputFieldSample : IExample
    {
        private const int COUNT = 8;
        private InputField[] inputFieldArr;
        
        public void Activate()
        {
            inputFieldArr = new InputField[COUNT];
            CreateFamily();
            CreateFood();
            CreateKitchen();
            CreateUtility();
            Window.Instance.KeyEvent += OnWindowsKeyEvent;
        }

        private void CreateFamily()
        {
            inputFieldArr[0] = new InputField("FamilyTextFieldInputField");
            inputFieldArr[0].Size2D = new Size2D(1600, 95);
            inputFieldArr[0].PositionY = 100;
            Window.Instance.Add(inputFieldArr[0]);
            inputFieldArr[0].HintText = "FamilyTextFieldInputField";
            inputFieldArr[0].CancelBtnClickEvent += OnCancelBtnClickEvent1;

            inputFieldArr[1] = new InputField("FamilyStyleBFieldInputField");
            inputFieldArr[1].Size2D = new Size2D(1600, 95);
            inputFieldArr[1].PositionY = 200;
            Window.Instance.Add(inputFieldArr[1]);
            inputFieldArr[1].HintText = "FamilyStyleBFieldInputField";
        }

        private void CreateFood()
        {
            inputFieldArr[2] = new InputField("FoodTextFieldInputField");
            inputFieldArr[2].Size2D = new Size2D(1600, 95);
            inputFieldArr[2].PositionY = 300;
            Window.Instance.Add(inputFieldArr[2]);
            inputFieldArr[2].HintText = "FoodTextFieldInputField";
            //inputFieldArr[2].CancelBtnClickEvent += OnCancelBtnClickEvent1;

            inputFieldArr[3] = new InputField("FoodStyleBFieldInputField");
            inputFieldArr[3].Size2D = new Size2D(1600, 95);
            inputFieldArr[3].PositionY = 400;
            Window.Instance.Add(inputFieldArr[3]);
            inputFieldArr[3].HintText = "FoodStyleBFieldInputField";
        }

        private void CreateKitchen()
        {
            inputFieldArr[4] = new InputField("KitchenTextFieldInputField");
            inputFieldArr[4].Size2D = new Size2D(1600, 95);
            inputFieldArr[4].PositionY = 500;
            Window.Instance.Add(inputFieldArr[4]);
            inputFieldArr[4].HintText = "KitchenTextFieldInputField";
            //inputFieldArr[4].CancelBtnClickEvent += OnCancelBtnClickEvent1;

            inputFieldArr[5] = new InputField("KitchenStyleBFieldInputField");
            inputFieldArr[5].Size2D = new Size2D(1600, 95);
            inputFieldArr[5].PositionY = 600;
            Window.Instance.Add(inputFieldArr[5]);
            inputFieldArr[5].HintText = "KitchenStyleBFieldInputField";
        }

        private void CreateUtility()
        {
            inputFieldArr[6] = new InputField("UtilityTextFieldInputField");
            inputFieldArr[6].Size2D = new Size2D(1600, 95);
            inputFieldArr[6].PositionY = 700;
            Window.Instance.Add(inputFieldArr[6]);
            inputFieldArr[6].HintText = "UtilityTextFieldInputField";
            //inputFieldArr[6].CancelBtnClickEvent += OnCancelBtnClickEvent1;

            inputFieldArr[7] = new InputField("UtilityStyleBFieldInputField");
            inputFieldArr[7].Size2D = new Size2D(1600, 95);
            inputFieldArr[7].PositionY = 800;
            Window.Instance.Add(inputFieldArr[7]);
            inputFieldArr[7].HintText = "UtilityStyleBFieldInputField";
        }

        private void OnWindowsKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Left")
                {
                    //inputField1.Text = "test";
                }
                else if (e.Key.KeyPressedName == "Right")
                {
                    //inputField1.Text = "";
                }
            }
        }

        public void Deactivate()
        {
            Window window = Window.Instance;
            window.KeyEvent -= OnWindowsKeyEvent;
            
            for (int i = 0; i < COUNT; ++i)
            {
                if (inputFieldArr[i] != null)
                {
                    if (i == 0)
                    {
                        inputFieldArr[i].CancelBtnClickEvent -= OnCancelBtnClickEvent1;
                    }
                    window.Remove(inputFieldArr[i]);
                    inputFieldArr[i].Dispose();
                    inputFieldArr[i] = null;
                }
            }
            inputFieldArr = null;
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
