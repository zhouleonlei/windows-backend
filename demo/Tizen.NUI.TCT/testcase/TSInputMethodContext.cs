using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.InputMethodContext Tests")]
    public class InputMethodContextTests
    {
        private string TAG = "NUI";
        private TextEditor _editor;
        private int _temp;

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("InputMethodContextTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        public void OnInputMethodContextEvent(object sender, EventArgs e)
        {
            _temp = 10;
        }

        public void OnInputMethodContextEvent1(object sender, EventArgs e)
        {
            Tizen.Log.Fatal("NUI", $"TP#3 LanguageChanged_EVENT() OnInputMethodContextEvent1() TimeStamp={DateTime.Now.ToString("hh:mm:ss.fff")}");
            _temp = 10;
        }

        public InputMethodContext.CallbackData OnEventReceived(object sender, InputMethodContext.EventReceivedEventArgs e)
        {
            _temp = 10;
            InputMethodContext.CallbackData callbackData = new InputMethodContext.CallbackData(true, 0, e.EventData.PredictiveString, false);
            Tizen.Log.Fatal("NUI", "Inputmethod Manager return callbackData!!!");
            return callbackData;
        }

        [Test]
        [Category("P1")]
        [Description("Test Get. Check whether DestroyContext works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.DestroyContext M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void DestroyContext_NO_RETURN_VALUE()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            Assert.IsNotNull(inputMethodContext, "The object should not be null!");
            try
            {
                inputMethodContext.DestroyContext();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test constructor. Check whether it works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.InputMethodContext C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void InputMethodContext_INIT()
        {
            var inputMethodContext = new InputMethodContext();
            Assert.NotNull(inputMethodContext, "Should not be null");
            Assert.IsInstanceOf<InputMethodContext>(inputMethodContext, "Should be the instance of InputMethodContext Type");
            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test Activate. Check whether Activate works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.Activate M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void Activate_NO_RETURN_VALUE()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            try
            {
                inputMethodContext.Activate();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test Deactivate. Check whether Deactivate works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.Deactivate M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void Deactivate_NO_RETURN_VALUE()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            try
            {
                inputMethodContext.Deactivate();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test RestoreAfterFocusLost. Check whether RestoreAfterFocusLost works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.RestoreAfterFocusLost M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void RestoreAfterFocusLost_RETURN_VALUE()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            try
            {
                inputMethodContext.SetRestoreAfterFocusLost(true);
                Assert.IsTrue(inputMethodContext.RestoreAfterFocusLost(), "Should be true");
                inputMethodContext.SetRestoreAfterFocusLost(false);
                Assert.IsFalse(inputMethodContext.RestoreAfterFocusLost(), "Should be false");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test SetRestoreAfterFocusLost. Check whether SetRestoreAfterFocusLost works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.SetRestoreAfterFocusLost M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void SetRestoreAfterFocusLost_NO_RETURN_VALUE()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            try
            {
                inputMethodContext.SetRestoreAfterFocusLost(true);
                Assert.IsTrue(inputMethodContext.RestoreAfterFocusLost(), "Should be true");
                inputMethodContext.SetRestoreAfterFocusLost(false);
                Assert.IsFalse(inputMethodContext.RestoreAfterFocusLost(), "Should be false");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test Reset. Check whether Reset works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.Reset M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void Reset_NO_RETURN_VALUE()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            try
            {
                inputMethodContext.Reset();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test NotifyCursorPosition. Check whether NotifyCursorPosition works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.NotifyCursorPosition M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void NotifyCursorPosition_NO_RETURN_VALUE()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            try
            {
                inputMethodContext.NotifyCursorPosition();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test SetCursorPosition. Check whether SetCursorPosition works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.SetCursorPosition M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void SetCursorPosition_NO_RETURN_VALUE()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            uint cursorPosition = 0;
            try
            {
                inputMethodContext.SetCursorPosition(100);
                cursorPosition = inputMethodContext.GetCursorPosition();
                Assert.AreEqual(100, cursorPosition, "Should be equal to SetCursorPosition");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test GetCursorPosition. Check whether GetCursorPosition works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.GetCursorPosition M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void GetCursorPosition_RETURN_VALUE()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            inputMethodContext.SetCursorPosition(100);
            uint pos = inputMethodContext.GetCursorPosition();
            Assert.AreEqual(100, pos, "Should be equal to GetCursorPosition");
            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test SetSurroundingText. Check whether SetSurroundingText works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.SetSurroundingText M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void SetSurroundingText_NO_RETURN_VALUE()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            try
            {
                string example = "Test";
                inputMethodContext.SetSurroundingText(example);
                Assert.AreEqual(example, inputMethodContext.GetSurroundingText(), "Should be equal to SetSurroundingText");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test GetSurroundingText. Check whether GetSurroundingText works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.GetSurroundingText M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void GetSurroundingText_RETURN_VALUE()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            inputMethodContext.SetSurroundingText("Test");
            string text = inputMethodContext.GetSurroundingText();
            Assert.AreEqual("Test", text, "Should be equal to GetSurroundingText");
            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test NotifyTextInputMultiLine. Check whether NotifyTextInputMultiLine works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.NotifyTextInputMultiLine M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void NotifyTextInputMultiLine_NO_RETURN_VALUE()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            try
            {
                inputMethodContext.NotifyTextInputMultiLine(true);
                inputMethodContext.NotifyTextInputMultiLine(false);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test GetTextDirection. Check whether GetTextDirection works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.GetTextDirection M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void GetTextDirection_RETURN_VALUE()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            if (inputMethodContext)
            {
                Assert.AreEqual(InputMethodContext.TextDirection.LeftToRight, inputMethodContext.GetTextDirection(), "Should be equal");
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test TextPrediction. Check whether TextPrediction is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.TextPrediction A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void TextPrediction_SET_GET_VALUE()
        {
            /* TEST CODE */
            InputMethodContext inputMethodContext = new InputMethodContext();
            inputMethodContext.TextPrediction = true;
            Assert.AreEqual(true, inputMethodContext.TextPrediction, "Should be true but error");
            inputMethodContext.TextPrediction = false;
            Assert.AreEqual(false, inputMethodContext.TextPrediction, "should be false but error");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetInputMethodArea. Check whether GetInputMethodArea works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.GetInputMethodArea M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public async Task GetInputMethodArea_RETURN_VALUE()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            inputMethodContext.Activate();
            inputMethodContext.ShowInputPanel();

            await Task.Delay(300);
            Tizen.Log.Debug("NUI", "GetInputMethodArea_RETURN_VALUE! Add 300ms delay!");

            if (inputMethodContext)
            {
                Rectangle rect = inputMethodContext.GetInputMethodArea();
                Assert.GreaterOrEqual(rect.X, 0, "Should be greater than 0!");
                Assert.GreaterOrEqual(rect.Y, 0, "Should be greater than 0!");
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test SetInputPanelUserData. Check whether SetInputPanelUserData works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.SetInputPanelUserData M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void SetInputPanelUserData_TEST()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            try
            {
                inputMethodContext.SetInputPanelUserData("layouttype = 1 & entrylimit = 255 & action = clearall_for_voice_commit & caller = org.volt.search - all");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test GetInputPanelUserData. Check whether GetInputPanelUserData works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.GetInputPanelUserData M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void GetInputPanelUserData_TEST()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            try
            {
                inputMethodContext.SetInputPanelUserData("layouttype = 1 & entrylimit = 255 & action = clearall_for_voice_commit & caller = org.volt.search - all");
                string data = "";
                inputMethodContext.GetInputPanelUserData(out data);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test GetInputPanelState. Check whether GetInputPanelState works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.GetInputPanelState M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public async Task GetInputPanelState_RETURN_VALUE()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            Assert.IsNotNull(inputMethodContext, "InputMethodContext should not be null");
            if (inputMethodContext.RestoreAfterFocusLost())
            {
                inputMethodContext.SetRestoreAfterFocusLost(false);
            }

            inputMethodContext.HideInputPanel();
            await Task.Delay(300);
            Assert.AreEqual(InputMethodContext.State.Hide, inputMethodContext.GetInputPanelState(), "Should be equal");
            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test SetReturnKeyState. Check whether SetReturnKeyState works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.SetReturnKeyState M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void SetReturnKeyState_NO_RETURN_VALUE()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            try
            {
                inputMethodContext.SetReturnKeyState(true);
                inputMethodContext.SetReturnKeyState(false);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test AutoEnableInputPanel. Check whether AutoEnableInputPanel works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.AutoEnableInputPanel M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void AutoEnableInputPanel_NO_RETURN_VALUE()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            try
            {
                inputMethodContext.AutoEnableInputPanel(true);
                inputMethodContext.AutoEnableInputPanel(false);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test ShowInputPanel. Check whether ShowInputPanel works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.ShowInputPanel M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void ShowInputPanel_NO_RETURN_VALUE()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            try
            {
                inputMethodContext.Activate();
                inputMethodContext.ShowInputPanel();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test HideInputPanel. Check whether HideInputPanel works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.HideInputPanel M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void HideInputPanel_NO_RETURN_VALUE()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            try
            {
                inputMethodContext.Deactivate();
                inputMethodContext.HideInputPanel();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test GetKeyboardType. Check whether GetKeyboardType works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.GetKeyboardType M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void GetKeyboardType_RETURN_VALUE()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            if (inputMethodContext)
            {
                Assert.AreEqual(InputMethodContext.KeyboardType.SoftwareKeyboard, inputMethodContext.GetKeyboardType(), "Should be not null");
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test GetInputPanelLocale. Check whether GetInputPanelLocale works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.GetInputPanelLocale M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public async Task GetInputPanelLocale_RETURN_VALUE()
        {
            _editor = new TextEditor()
            {
                Size2D = new Size2D(500, 300),
                Position2D = new Position2D(10, 550),
                BackgroundColor = Color.Magenta,
                Focusable = true,
            };

            InputMethodContext inputMethodContext = _editor.GetInputMethodContext();
            Assert.IsNotNull(inputMethodContext, "InputMethodContext should not be null after using GetInputMethodContext");

            inputMethodContext.Activate();
            inputMethodContext.ShowInputPanel();
            await Task.Delay(500);
            if (inputMethodContext)
            {
                Assert.IsTrue(inputMethodContext.GetInputPanelLocale().Contains("en_US"), "Default value is not en_US");
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Check whether Activated event is triggered.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.Activated E")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public async Task Activated_EVENT()
        {
            InputMethodContext inputMethodContext = new InputMethodContext();
            if (inputMethodContext)
            {
                _temp = 0;
                inputMethodContext.Activated += OnInputMethodContextEvent;
                inputMethodContext.Activate();
                await Task.Delay(20);
                Assert.AreEqual(10, _temp, "Should be 10");
                inputMethodContext.Activated -= OnInputMethodContextEvent;
            }

            inputMethodContext.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Check whether EventReceived event is triggered.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.EventReceived E")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public async Task EventReceived_EVENT()
        {
            _editor = new TextEditor()
            {
                Size2D = new Size2D(500, 300),
                Position2D = new Position2D(10, 550),
                BackgroundColor = Color.Magenta,
                Focusable = true,
            };
            Window.Instance.GetDefaultLayer().Add(_editor);
            InputMethodContext inputMethodContext = _editor.GetInputMethodContext();
            if (inputMethodContext)
            {
                _temp = 0;
                inputMethodContext.EventReceived += OnEventReceived;
                inputMethodContext.Deactivate();
                inputMethodContext.HideInputPanel();
                await Task.Delay(20);
                inputMethodContext.Activate();
                inputMethodContext.ShowInputPanel();
                await Task.Delay(20);
                Assert.AreEqual(10, _temp, "Should be 10");
                inputMethodContext.EventReceived -= OnEventReceived;
            }

            Window.Instance.GetDefaultLayer().Remove(_editor);
        }

        [Test]
        [Category("P1")]
        [Description("Check whether StatusChanged event is triggered.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.StatusChanged E")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public async Task StatusChanged_EVENT()
        {
            _editor = new TextEditor()
            {
                Size2D = new Size2D(500, 300),
                Position2D = new Position2D(10, 550),
                BackgroundColor = Color.Magenta,
                Focusable = true,
            };
            Window.Instance.GetDefaultLayer().Add(_editor);
            InputMethodContext inputMethodContext = _editor.GetInputMethodContext();
            if (inputMethodContext)
            {
                _temp = 0;
                inputMethodContext.StatusChanged += OnInputMethodContextEvent;

                inputMethodContext.Deactivate();
                inputMethodContext.HideInputPanel();
                await Task.Delay(200);
                inputMethodContext.Activate();
                inputMethodContext.ShowInputPanel();
                await Task.Delay(200);

                Tizen.Log.Debug("NUI", "StatusChanged_EVENT Add 200ms delay");

                Assert.AreEqual(10, _temp, "Should be 10");
                inputMethodContext.StatusChanged -= OnInputMethodContextEvent;
            }

            Window.Instance.GetDefaultLayer().Remove(_editor);
        }

        [Test]
        [Category("P1")]
        [Description("Check whether Resized event is triggered.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.Resized E")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public async Task Resized_EVENT()
        {
            _editor = new TextEditor()
            {
                Size2D = new Size2D(500, 300),
                Position2D = new Position2D(10, 550),
                BackgroundColor = Color.Magenta,
                Focusable = true,
            };
            Window.Instance.GetDefaultLayer().Add(_editor);
            InputMethodContext inputMethodContext = _editor.GetInputMethodContext();
            if (inputMethodContext)
            {
                _temp = 0;
                inputMethodContext.Resized += OnInputMethodContextEvent;
                inputMethodContext.Activate();
                inputMethodContext.ShowInputPanel();
                await Task.Delay(200);
                inputMethodContext.Deactivate();
                inputMethodContext.HideInputPanel();
                await Task.Delay(200);

                Assert.AreEqual(10, _temp, "Should be 10");
                inputMethodContext.Resized -= OnInputMethodContextEvent;
            }

            Window.Instance.GetDefaultLayer().Remove(_editor);
        }

        [Test]
        [Category("P1")]
        [Description("Check whether LanguageChanged event is triggered.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.LanguageChanged E")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public async Task LanguageChanged_EVENT()
        {
            _editor = new TextEditor()
            {
                Size2D = new Size2D(500, 300),
                Position2D = new Position2D(10, 550),
                BackgroundColor = Color.Magenta,
                Focusable = true,
            };
            Window.Instance.GetDefaultLayer().Add(_editor);
            InputMethodContext inputMethodContext = _editor.GetInputMethodContext();
            if (inputMethodContext)
            {
                _temp = 0;
                inputMethodContext.LanguageChanged += OnInputMethodContextEvent1;
                inputMethodContext.Deactivate();
                inputMethodContext.HideInputPanel();
                await Task.Delay(200);
                Tizen.Log.Debug("NUI", $"TP#1 LanguageChanged_EVENT() HideInputPanel() TimeStamp={DateTime.Now.ToString("hh:mm:ss.fff")}");
                inputMethodContext.Activate();
                inputMethodContext.ShowInputPanel();
                await Task.Delay(200);
                Tizen.Log.Debug("NUI", $"TP#2 LanguageChanged_EVENT() ShowInputPanel() TimeStamp={DateTime.Now.ToString("hh:mm:ss.fff")}");

                Assert.AreEqual(10, _temp, "Should be 10");
                inputMethodContext.LanguageChanged -= OnInputMethodContextEvent1;
            }

            Window.Instance.GetDefaultLayer().Remove(_editor);
        }

    }
}
