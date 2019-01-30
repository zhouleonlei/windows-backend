using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;
using System;
using Tizen.NUI;

namespace Tizen.FH.NUI.Samples
{
    public class InputFieldSample : IExample
    {
        private const int COUNT = 8;
        private Tizen.FH.NUI.Controls.InputField[] inputFieldArr;
        private View rootView;

        public void Activate()
        {
            inputFieldArr = new Tizen.FH.NUI.Controls.InputField[COUNT];
            CreateRootView();
            CreateFamily();
            CreateFood();
            CreateKitchen();
            CreateUtility();
            Window.Instance.KeyEvent += OnWindowsKeyEvent;
        }

        private void CreateRootView()
        {
            rootView = new View();
            rootView.WidthResizePolicy = ResizePolicyType.FillToParent;
            rootView.HeightResizePolicy = ResizePolicyType.FillToParent;
            rootView.BackgroundColor = new Color(78.0f / 255.0f, 216.0f / 255.0f, 231.0f / 255.0f, 1.0f);
            rootView.Focusable = true;
            Window.Instance.Add(rootView);
            rootView.TouchEvent += OnRootViewTouchEvent;
        }

        private void CreateFamily()
        {
            inputFieldArr[0] = new Tizen.FH.NUI.Controls.InputField("FamilyDefaultInputField");
            inputFieldArr[0].Name = "FamilyDefaultInputField";
            inputFieldArr[0].Size2D = new Size2D(1600, 95);
            inputFieldArr[0].PositionY = 100;
            Window.Instance.Add(inputFieldArr[0]);
            inputFieldArr[0].HintText = "FamilyDefaultInputField";
            inputFieldArr[0].CancelButtonClickEvent += OnCancelBtnClickEvent;
            inputFieldArr[0].KeyEvent += OnKeyEvent;

            inputFieldArr[1] = new Tizen.FH.NUI.Controls.InputField("FamilyStyleBInputField");
            inputFieldArr[1].Name = "FamilyStyleBInputField";
            inputFieldArr[1].Size2D = new Size2D(1600, 95);
            inputFieldArr[1].PositionY = 200;
            Window.Instance.Add(inputFieldArr[1]);
            inputFieldArr[1].HintText = "FamilyStyleBInputField";
            inputFieldArr[1].DeleteButtonClickEvent += OnDeleteBtnClickEvent;
            inputFieldArr[1].AddButtonClickEvent += OnAddBtnClickEvent;
        }

        private void CreateFood()
        {
            inputFieldArr[2] = new Tizen.FH.NUI.Controls.InputField("FoodDefaultInputField");
            inputFieldArr[2].Name = "FoodDefaultInputField";
            inputFieldArr[2].Size2D = new Size2D(1600, 95);
            inputFieldArr[2].PositionY = 300;
            Window.Instance.Add(inputFieldArr[2]);
            inputFieldArr[2].HintText = "FoodDefaultInputField";
            inputFieldArr[2].CancelButtonClickEvent += OnCancelBtnClickEvent;
            inputFieldArr[2].KeyEvent += OnKeyEvent;

            inputFieldArr[3] = new Tizen.FH.NUI.Controls.InputField("FoodStyleBInputField");
            inputFieldArr[3].Name = "FoodStyleBInputField";
            inputFieldArr[3].Size2D = new Size2D(1600, 95);
            inputFieldArr[3].PositionY = 400;
            Window.Instance.Add(inputFieldArr[3]);
            inputFieldArr[3].HintText = "FoodStyleBInputField";
            inputFieldArr[3].DeleteButtonClickEvent += OnDeleteBtnClickEvent;
            inputFieldArr[3].AddButtonClickEvent += OnAddBtnClickEvent;
        }

        private void CreateKitchen()
        {
            inputFieldArr[4] = new Tizen.FH.NUI.Controls.InputField("KitchenDefaultInputField");
            inputFieldArr[4].Name = "KitchenDefaultInputField";
            inputFieldArr[4].Size2D = new Size2D(1600, 95);
            inputFieldArr[4].PositionY = 500;
            Window.Instance.Add(inputFieldArr[4]);
            inputFieldArr[4].HintText = "KitchenDefaultInputField";
            inputFieldArr[4].CancelButtonClickEvent += OnCancelBtnClickEvent;
            inputFieldArr[4].KeyEvent += OnKeyEvent;

            inputFieldArr[5] = new Tizen.FH.NUI.Controls.InputField("KitchenStyleBInputField");
            inputFieldArr[5].Name = "KitchenStyleBInputField";
            inputFieldArr[5].Size2D = new Size2D(1600, 95);
            inputFieldArr[5].PositionY = 600;
            Window.Instance.Add(inputFieldArr[5]);
            inputFieldArr[5].HintText = "KitchenStyleBInputField";
            inputFieldArr[5].DeleteButtonClickEvent += OnDeleteBtnClickEvent;
            inputFieldArr[5].AddButtonClickEvent += OnAddBtnClickEvent;
        }

        private void CreateUtility()
        {
            inputFieldArr[6] = new Tizen.FH.NUI.Controls.InputField("UtilityDefaultInputField");
            inputFieldArr[6].Name = "UtilityDefaultInputField";
            inputFieldArr[6].Size2D = new Size2D(1600, 95);
            inputFieldArr[6].PositionY = 700;
            Window.Instance.Add(inputFieldArr[6]);
            inputFieldArr[6].HintText = "UtilityDefaultInputField";
            inputFieldArr[6].CancelButtonClickEvent += OnCancelBtnClickEvent;
            inputFieldArr[6].KeyEvent += OnKeyEvent;

            inputFieldArr[7] = new Tizen.FH.NUI.Controls.InputField("UtilityStyleBInputField");
            inputFieldArr[7].Name = "UtilityStyleBInputField";
            inputFieldArr[7].Size2D = new Size2D(1600, 95);
            inputFieldArr[7].PositionY = 800;
            Window.Instance.Add(inputFieldArr[7]);
            inputFieldArr[7].HintText = "UtilityStyleBInputField";
            inputFieldArr[7].DeleteButtonClickEvent += OnDeleteBtnClickEvent;
            inputFieldArr[7].AddButtonClickEvent += OnAddBtnClickEvent;
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

        private bool OnRootViewTouchEvent(object sender, View.TouchEventArgs e)
        {
            FocusManager.Instance.SetCurrentFocusView(rootView);
            return false;
        }

        private void OnKeyEvent(object sender, View.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Return")
                {
                    Tizen.FH.NUI.Controls.InputField inputField = sender as Tizen.FH.NUI.Controls.InputField;
                    if (inputField != null)
                    {
                        if (inputField.Text.Length >= 10)
                        {
                            inputField.TextColor = Color.Red;
                        }
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
                        inputFieldArr[i].CancelButtonClickEvent -= OnCancelBtnClickEvent;
                        inputFieldArr[i].KeyEvent -= OnKeyEvent;
                    }
                    else
                    {
                        inputFieldArr[i].DeleteButtonClickEvent -= OnDeleteBtnClickEvent;
                        inputFieldArr[i].AddButtonClickEvent -= OnAddBtnClickEvent;
                    }
                    rootView.Remove(inputFieldArr[i]);
                    inputFieldArr[i].Dispose();
                    inputFieldArr[i] = null;
                }
            }
            inputFieldArr = null;

            if (rootView != null)
            {
                rootView.TouchEvent -= OnRootViewTouchEvent;
                Window.Instance.Remove(rootView);
                rootView.Dispose();
                rootView = null;
            }
        }

        private void OnCancelBtnClickEvent(object sender, FH.NUI.Controls.InputField.ButtonClickArgs args)
        {
            if (sender is Tizen.FH.NUI.Controls.InputField)
            {
                Tizen.FH.NUI.Controls.InputField inputfield = sender as Tizen.FH.NUI.Controls.InputField;
                Console.WriteLine("-------, name: " + inputfield.Name + ", args.State = " + args.State);
                inputfield.TextColor = Color.Black;
                inputfield.Text = "Click on the cancel button";
            }
        }

        private void OnDeleteBtnClickEvent(object sender, FH.NUI.Controls.InputField.ButtonClickArgs args)
        {
            if (sender is Tizen.FH.NUI.Controls.InputField)
            {
                Tizen.FH.NUI.Controls.InputField inputfield = sender as Tizen.FH.NUI.Controls.InputField;
                Console.WriteLine("-------, name: " + inputfield.Name + ", args.State = " + args.State);
                inputfield.Text = "Click on the delete button";
            }
        }

        private void OnAddBtnClickEvent(object sender, FH.NUI.Controls.InputField.ButtonClickArgs args)
        {
            if (sender is Tizen.FH.NUI.Controls.InputField)
            {
                Tizen.FH.NUI.Controls.InputField inputfield = sender as Tizen.FH.NUI.Controls.InputField;
                Console.WriteLine("-------, name: " + inputfield.Name + ", args.State = " + args.State);
                inputfield.Text = "Click on the add button";
            }
        }
    }
}
