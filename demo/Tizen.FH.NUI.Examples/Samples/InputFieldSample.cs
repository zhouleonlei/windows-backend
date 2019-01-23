using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;
using System;
using Tizen.NUI;

namespace Tizen.FH.NUI.Samples
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
            inputFieldArr[0].Name = "FamilyTextFieldInputField";
            inputFieldArr[0].Size2D = new Size2D(1600, 95);
            inputFieldArr[0].PositionY = 100;
            Window.Instance.Add(inputFieldArr[0]);
            inputFieldArr[0].HintText = "FamilyTextFieldInputField";
            inputFieldArr[0].CancelBtnClickEvent += OnCancelBtnClickEvent;

            inputFieldArr[1] = new InputField("FamilyStyleBFieldInputField");
            inputFieldArr[1].Name = "FamilyStyleBFieldInputField";
            inputFieldArr[1].Size2D = new Size2D(1600, 95);
            inputFieldArr[1].PositionY = 200;
            Window.Instance.Add(inputFieldArr[1]);
            inputFieldArr[1].HintText = "FamilyStyleBFieldInputField";
            inputFieldArr[1].DeleteBtnClickEvent += OnDeleteBtnClickEvent;
            inputFieldArr[1].AddBtnClickEvent += OnAddBtnClickEvent;
        }

        private void CreateFood()
        {
            inputFieldArr[2] = new InputField("FoodTextFieldInputField");
            inputFieldArr[2].Name = "FoodTextFieldInputField";
            inputFieldArr[2].Size2D = new Size2D(1600, 95);
            inputFieldArr[2].PositionY = 300;
            Window.Instance.Add(inputFieldArr[2]);
            inputFieldArr[2].HintText = "FoodTextFieldInputField";
            inputFieldArr[2].CancelBtnClickEvent += OnCancelBtnClickEvent;

            inputFieldArr[3] = new InputField("FoodStyleBFieldInputField");
            inputFieldArr[3].Name = "FoodStyleBFieldInputField";
            inputFieldArr[3].Size2D = new Size2D(1600, 95);
            inputFieldArr[3].PositionY = 400;
            Window.Instance.Add(inputFieldArr[3]);
            inputFieldArr[3].HintText = "FoodStyleBFieldInputField";
            inputFieldArr[3].DeleteBtnClickEvent += OnDeleteBtnClickEvent;
            inputFieldArr[3].AddBtnClickEvent += OnAddBtnClickEvent;
        }

        private void CreateKitchen()
        {
            inputFieldArr[4] = new InputField("KitchenTextFieldInputField");
            inputFieldArr[4].Name = "KitchenTextFieldInputField";
            inputFieldArr[4].Size2D = new Size2D(1600, 95);
            inputFieldArr[4].PositionY = 500;
            Window.Instance.Add(inputFieldArr[4]);
            inputFieldArr[4].HintText = "KitchenTextFieldInputField";
            inputFieldArr[4].CancelBtnClickEvent += OnCancelBtnClickEvent;

            inputFieldArr[5] = new InputField("KitchenStyleBFieldInputField");
            inputFieldArr[5].Name = "KitchenStyleBFieldInputField";
            inputFieldArr[5].Size2D = new Size2D(1600, 95);
            inputFieldArr[5].PositionY = 600;
            Window.Instance.Add(inputFieldArr[5]);
            inputFieldArr[5].HintText = "KitchenStyleBFieldInputField";
            inputFieldArr[5].DeleteBtnClickEvent += OnDeleteBtnClickEvent;
            inputFieldArr[5].AddBtnClickEvent += OnAddBtnClickEvent;
        }

        private void CreateUtility()
        {
            inputFieldArr[6] = new InputField("UtilityTextFieldInputField");
            inputFieldArr[6].Name = "UtilityTextFieldInputField";
            inputFieldArr[6].Size2D = new Size2D(1600, 95);
            inputFieldArr[6].PositionY = 700;
            Window.Instance.Add(inputFieldArr[6]);
            inputFieldArr[6].HintText = "UtilityTextFieldInputField";
            inputFieldArr[6].CancelBtnClickEvent += OnCancelBtnClickEvent;

            inputFieldArr[7] = new InputField("UtilityStyleBFieldInputField");
            inputFieldArr[7].Name = "UtilityStyleBFieldInputField";
            inputFieldArr[7].Size2D = new Size2D(1600, 95);
            inputFieldArr[7].PositionY = 800;
            Window.Instance.Add(inputFieldArr[7]);
            inputFieldArr[7].HintText = "UtilityStyleBFieldInputField";
            inputFieldArr[7].DeleteBtnClickEvent += OnDeleteBtnClickEvent;
            inputFieldArr[7].AddBtnClickEvent += OnAddBtnClickEvent;
        }

        private void OnWindowsKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Left")
                {
                    //inputField1.Text = "test";
                    for (int i = 0; i < COUNT; ++i)
                    {
                        inputFieldArr[i].StateEnabled = false;
                    }
                }
                else if (e.Key.KeyPressedName == "Right")
                {
                    //inputField1.Text = "";
                    for (int i = 0; i < COUNT; ++i)
                    {
                        inputFieldArr[i].StateEnabled = true;
                    }
                }
                else if (e.Key.KeyPressedName == "Up")
                {
                    for (int i = 0; i < COUNT; ++i)
                    {
                        inputFieldArr[i].Text = "abcdef";
                    }
                }
                else if (e.Key.KeyPressedName == "Down")
                {
                    for (int i = 0; i < COUNT; ++i)
                    {
                        inputFieldArr[i].Text = "";
                    }
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
                    if (i % 2 == 0)
                    {
                        inputFieldArr[i].CancelBtnClickEvent -= OnCancelBtnClickEvent;
                    }
                    else
                    {
                        inputFieldArr[i].DeleteBtnClickEvent -= OnDeleteBtnClickEvent;
                        inputFieldArr[i].AddBtnClickEvent -= OnAddBtnClickEvent;
                    }
                    window.Remove(inputFieldArr[i]);
                    inputFieldArr[i].Dispose();
                    inputFieldArr[i] = null;
                }
            }
            inputFieldArr = null;
        }

        private void OnCancelBtnClickEvent(object sender, InputField.CancelBtnClickArgs args)
        {
            if (sender is InputField)
            {
                InputField inputfield = sender as InputField;
                Console.WriteLine("-------, name: " + inputfield.Name + ", args.State = " + args.State);
            }
        }

        private void OnDeleteBtnClickEvent(object sender, InputField.DeleteBtnClickArgs args)
        {
            if (sender is InputField)
            {
                InputField inputfield = sender as InputField;
                Console.WriteLine("-------, name: " + inputfield.Name + ", args.State = " + args.State);
            }
        }

        private void OnAddBtnClickEvent(object sender, InputField.AddBtnClickArgs args)
        {
            if (sender is InputField)
            {
                InputField inputfield = sender as InputField;
                Console.WriteLine("-------, name: " + inputfield.Name + ", args.State = " + args.State);
            }
        }
    }
}
