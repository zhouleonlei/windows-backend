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
        private TextLabel guideText;
        private View rootView;
        private int posX, posY;

        public void Activate()
        {
            posX = 50;
            posY = 250;
            inputFieldArr = new Tizen.FH.NUI.Controls.InputField[COUNT];
            CreateRootView();
            CreateFamily();
            CreateFood();
            CreateKitchen();
            CreateUtility();
            CreateGuideText();
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
            inputFieldArr[0].Position2D = new Position2D(posX, posY);
            Window.Instance.Add(inputFieldArr[0]);
            inputFieldArr[0].HintText = "FamilyDefaultInputField";
            inputFieldArr[0].CancelButtonClickEvent += OnCancelBtnClickEvent;
            inputFieldArr[0].KeyEvent += OnKeyEvent;

            posY += 100;
            inputFieldArr[1] = new Tizen.FH.NUI.Controls.InputField("FamilyStyleBInputField");
            inputFieldArr[1].Name = "FamilyStyleBInputField";
            inputFieldArr[1].Size2D = new Size2D(1600, 95);
            inputFieldArr[1].Position2D = new Position2D(posX, posY);
            Window.Instance.Add(inputFieldArr[1]);
            inputFieldArr[1].HintText = "FamilyStyleBInputField";
            inputFieldArr[1].DeleteButtonClickEvent += OnDeleteBtnClickEvent;
            inputFieldArr[1].AddButtonClickEvent += OnAddBtnClickEvent;
            inputFieldArr[1].KeyEvent += OnKeyEvent;
        }

        private void CreateFood()
        {
            posY += 100;
            inputFieldArr[2] = new Tizen.FH.NUI.Controls.InputField("FoodDefaultInputField");
            inputFieldArr[2].Name = "FoodDefaultInputField";
            inputFieldArr[2].Size2D = new Size2D(1600, 95);
            inputFieldArr[2].Position2D = new Position2D(posX, posY);
            Window.Instance.Add(inputFieldArr[2]);
            inputFieldArr[2].HintText = "FoodDefaultInputField";
            inputFieldArr[2].CancelButtonClickEvent += OnCancelBtnClickEvent;
            inputFieldArr[2].KeyEvent += OnKeyEvent;

            posY += 100;
            inputFieldArr[3] = new Tizen.FH.NUI.Controls.InputField("FoodStyleBInputField");
            inputFieldArr[3].Name = "FoodStyleBInputField";
            inputFieldArr[3].Size2D = new Size2D(1600, 95);
            inputFieldArr[3].Position2D = new Position2D(posX, posY);
            Window.Instance.Add(inputFieldArr[3]);
            inputFieldArr[3].HintText = "FoodStyleBInputField";
            inputFieldArr[3].DeleteButtonClickEvent += OnDeleteBtnClickEvent;
            inputFieldArr[3].AddButtonClickEvent += OnAddBtnClickEvent;
            inputFieldArr[3].KeyEvent += OnKeyEvent;
        }

        private void CreateKitchen()
        {
            posY += 100;
            inputFieldArr[4] = new Tizen.FH.NUI.Controls.InputField("KitchenDefaultInputField");
            inputFieldArr[4].Name = "KitchenDefaultInputField";
            inputFieldArr[4].Size2D = new Size2D(1600, 95);
            inputFieldArr[4].Position2D = new Position2D(posX, posY);
            Window.Instance.Add(inputFieldArr[4]);
            inputFieldArr[4].HintText = "KitchenDefaultInputField";
            inputFieldArr[4].CancelButtonClickEvent += OnCancelBtnClickEvent;
            inputFieldArr[4].KeyEvent += OnKeyEvent;

            posY += 100;
            inputFieldArr[5] = new Tizen.FH.NUI.Controls.InputField("KitchenStyleBInputField");
            inputFieldArr[5].Name = "KitchenStyleBInputField";
            inputFieldArr[5].Size2D = new Size2D(1600, 95);
            inputFieldArr[5].Position2D = new Position2D(posX, posY);
            Window.Instance.Add(inputFieldArr[5]);
            inputFieldArr[5].HintText = "KitchenStyleBInputField";
            inputFieldArr[5].DeleteButtonClickEvent += OnDeleteBtnClickEvent;
            inputFieldArr[5].AddButtonClickEvent += OnAddBtnClickEvent;
            inputFieldArr[5].KeyEvent += OnKeyEvent;
        }

        private void CreateUtility()
        {
            posY += 100;
            inputFieldArr[6] = new Tizen.FH.NUI.Controls.InputField("UtilityDefaultInputField");
            inputFieldArr[6].Name = "UtilityDefaultInputField";
            inputFieldArr[6].Size2D = new Size2D(1600, 95);
            inputFieldArr[6].Position2D = new Position2D(posX, posY);
            Window.Instance.Add(inputFieldArr[6]);
            inputFieldArr[6].HintText = "UtilityDefaultInputField";
            inputFieldArr[6].CancelButtonClickEvent += OnCancelBtnClickEvent;
            inputFieldArr[6].KeyEvent += OnKeyEvent;

            posY += 100;
            inputFieldArr[7] = new Tizen.FH.NUI.Controls.InputField("UtilityStyleBInputField");
            inputFieldArr[7].Name = "UtilityStyleBInputField";
            inputFieldArr[7].Size2D = new Size2D(1600, 95);
            inputFieldArr[7].Position2D = new Position2D(posX, posY);
            Window.Instance.Add(inputFieldArr[7]);
            inputFieldArr[7].HintText = "UtilityStyleBInputField";
            inputFieldArr[7].DeleteButtonClickEvent += OnDeleteBtnClickEvent;
            inputFieldArr[7].AddButtonClickEvent += OnAddBtnClickEvent;
            inputFieldArr[7].KeyEvent += OnKeyEvent;
        }

        private void CreateGuideText()
        {
            guideText = new TextLabel();
            guideText.Size2D = new Size2D(1600, 200);
            guideText.Position2D = new Position2D(30, 30);
            guideText.TextColor = Color.Blue;
            guideText.BackgroundColor = Color.White;
            guideText.PointSize = 15;
            guideText.MultiLine = true;
            rootView.Add(guideText);
            guideText.Text =
                "Tips: \n" +
                "User can input text after press on the InputBox; \n" +
                "User can press Cancel, Add and Delete button, do what they want in these button click callbacks; \n" +
                "User can do what they want in the key event; \n " +
                "In this sample, text color will change when inputted text's length change between 5~10, 10~15.  \n" +
                "User can exit the sample by press \"Esc\" key after touch on any area except the InputField.";
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
                Tizen.FH.NUI.Controls.InputField inputField = sender as Tizen.FH.NUI.Controls.InputField;
                if (inputField != null)
                {
                    if (inputField.Text.Length > 5 && inputField.Text.Length <= 10)
                    {
                        inputField.TextColor = Color.Yellow;
                    }
                    else if (inputField.Text.Length > 10 && inputField.Text.Length <= 15)
                    {
                        inputField.TextColor = Color.Red;
                    }
                    else
                    {
                        inputField.TextColor = Color.Black;
                    }
                }
                //if (e.Key.KeyPressedName == "Return")
                //{
                //    Tizen.FH.NUI.Controls.InputField inputField = sender as Tizen.FH.NUI.Controls.InputField;
                //    if (inputField != null)
                //    {
                //        if (inputField.Text.Length >= 10)
                //        {
                //            inputField.TextColor = Color.Red;
                //        }
                //    }
                //}
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
                    }
                    else
                    {
                        inputFieldArr[i].DeleteButtonClickEvent -= OnDeleteBtnClickEvent;
                        inputFieldArr[i].AddButtonClickEvent -= OnAddBtnClickEvent;
                    }
                    inputFieldArr[i].KeyEvent -= OnKeyEvent;
                    rootView.Remove(inputFieldArr[i]);
                    inputFieldArr[i].Dispose();
                    inputFieldArr[i] = null;
                }
            }
            inputFieldArr = null;

            if (guideText != null)
            {
                rootView.Remove(guideText);
                guideText.Dispose();
                guideText = null;
            }

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
