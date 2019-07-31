using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.ImfManager Tests")]
    public class ImfManagerTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";
        private bool _flagOnImfActivedEvent, _flagOnImfEventReceivedEvent, _flagOnLanguageChangedEvent, _flagOnResizedEvent, _flagOnStatusChangedEvent;

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, " Init() is called!");
            App.MainTitleChangeText("ImfManagerTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, " Destroy() is called!");
        }

        private void OnImfActivedEvent(object sender, EventArgs e)
        {
            _flagOnImfActivedEvent = true;
        }

        private ImfManager.ImfCallbackData OnImfEventReceivedEvent(object obj, EventArgs e)
        {
            _flagOnImfEventReceivedEvent = true;
            ImfManager.ImfCallbackData callbackData = new ImfManager.ImfCallbackData(true, 0, "", false);
            return callbackData;
        }

        private void OnLanguageChangedEvent(object obj, EventArgs e)
        {
            _flagOnLanguageChangedEvent = true;
        }

        private void OnResizedEvent(object obj, EventArgs e)
        {
            _flagOnResizedEvent = true;
        }

        private void OnStatusChangedEvent(object obj, EventArgs e)
        {
            _flagOnStatusChangedEvent = true;
        }

        [Test]
        [Category("P1")]
        [Description("Test constructor. Check whether it works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.ImfManager C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void ImfManager_INIT()
        {
            var manager = new ImfManager();
            Assert.NotNull(manager, "Should not be null to the ttsplayer.Get");
            Assert.IsInstanceOf<ImfManager>(manager, "Should be the instance of ImfManger Type");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get.Check whether Get works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.Get M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void Get_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();
            Assert.NotNull(manager, "Should not be null to the ImfManager.Get");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get.Check whether Instance property return a StyleManager instance successfully.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.Instance A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Instance_READ_ONLY()
        {
            ImfManager instance = ImfManager.Instance;
            Assert.NotNull(instance, "Should not be null to the ImfManager.Instance");
        }

        [Test]
        [Category("P1")]
        [Description("Test Activate.Check whether Activate works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.Activate M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void Activate_CHECK_VALUE()
        {
            ImfManager manager = ImfManager.Get();
            try
            {
                manager.Activate();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Deactivate.Check whether Deactivate works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.Deactivate M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void Deactivate_NO_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();
            try
            {
                manager.Deactivate();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test RestoreAfterFocusLost.Check whether RestoreAfterFocusLost works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.RestoreAfterFocusLost M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void RestoreAfterFocusLost_NO_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();
            try
            {
                manager.RestoreAfterFocusLost();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test SetRestoreAfterFocusLost.Check whether SetRestoreAfterFocusLost works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.SetRestoreAfterFocusLost M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void SetRestoreAfterFocusLost_NO_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();
            try
            {
                manager.SetRestoreAfterFocusLost(true);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Reset.Check whether Reset works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.Reset M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void Reset_NO_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();
            try
            {
                manager.Reset();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test NotifyCursorPosition.Check whether NotifyCursorPosition works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.NotifyCursorPosition M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void NotifyCursorPosition_NO_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();
            try
            {
                manager.NotifyCursorPosition();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test SetCursorPosition.Check whether SetCursorPosition works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.SetCursorPosition M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void SetCursorPosition_NO_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();
            try
            {
                manager.SetCursorPosition(100);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test GetCursorPosition.Check whether GetCursorPosition works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.GetCursorPosition M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void GetCursorPosition_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();
            manager.SetCursorPosition(100);
            uint pos = manager.GetCursorPosition();
            Assert.AreEqual(100, pos, "Should be equal to GetCursorPosition");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetSurroundingText.Check whether SetSurroundingText works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.SetSurroundingText M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void SetSurroundingText_NO_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();
            try
            {
                manager.SetSurroundingText("Test");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test GetSurroundingText.Check whether GetSurroundingText works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.GetSurroundingText M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void GetSurroundingText_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();
            manager.SetSurroundingText("Test");
            string text = manager.GetSurroundingText();
            Assert.AreEqual("Test", text, "Should be equal to GetCursorPosition");
        }

        [Test]
        [Category("P1")]
        [Description("Test NotifyTextInputMultiLine.Check whether NotifyTextInputMultiLine works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.NotifyTextInputMultiLine M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void NotifyTextInputMultiLine_NO_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();
            try
            {
                manager.NotifyTextInputMultiLine(true);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test GetTextDirection.Check whether GetTextDirection works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.GetTextDirection M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void GetTextDirection_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();
            if (manager)
            {
                Assert.AreEqual(ImfManager.TextDirection.LeftToRight, manager.GetTextDirection(), "Should be equal");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test GetInputPanelLocale.Check whether GetInputPanelLocale works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.GetInputPanelLocale M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public async Task GetInputPanelLocale_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();

            await Task.Delay(200);
            Tizen.Log.Fatal("NUI", "GetInputPanelLocale_RETURN_VALUE() Add 200ms delay");

            if (manager)
            {
                Assert.AreEqual("", manager.GetInputPanelLocale(), "Should be null");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test GetKeyboardType.Check whether GetKeyboardType works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.GetKeyboardType M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void GetKeyboardType_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();
            if (manager)
            {
                Assert.AreEqual(ImfManager.KeyboardType.SoftwareKeyboard, manager.GetKeyboardType(), "Should be not null");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test GetInputMethodArea.Check whether GetInputMethodArea works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.GetInputMethodArea M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public async Task GetInputMethodArea_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();

            manager.Deactivate();
            manager.HideInputPanel();
            await Task.Delay(200);
            manager.Activate();
            manager.ShowInputPanel();

            Tizen.Log.Debug("NUI", "GetInputMethodArea_RETURN_VALUE Add 200ms delay!");

            if (manager)
            {
                Rectangle rect = manager.GetInputMethodArea();
                Assert.GreaterOrEqual(rect.X, 0, "Should be greater than 0!");
                Assert.GreaterOrEqual(rect.Y, 0, "Should be greater than 0!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test SetReturnKeyState.Check whether SetReturnKeyState works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.SetReturnKeyState M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void SetReturnKeyState_NO_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();
            try
            {
                manager.SetReturnKeyState(true);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test AutoEnableInputPanel.Check whether AutoEnableInputPanel works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.AutoEnableInputPanel M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void AutoEnableInputPanel_NO_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();
            try
            {
                manager.AutoEnableInputPanel(true);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test ShowInputPanel.Check whether ShowInputPanel works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.ShowInputPanel M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void ShowInputPanel_NO_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();
            try
            {
                manager.ShowInputPanel();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test HideInputPanel.Check whether HideInputPanel works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.HideInputPanel M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void HideInputPanel_NO_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();
            try
            {
                manager.HideInputPanel();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test GetInputPanelState.Check whether GetInputPanelState works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.GetInputPanelState M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@partner.samsung.com")]
        public async Task GetInputPanelState_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();
            Assert.IsNotNull(manager, "ImfManager should not be null");
            if (manager.RestoreAfterFocusLost())
                manager.SetRestoreAfterFocusLost(false);

            manager.HideInputPanel();

            await Task.Delay(300);

            Assert.AreEqual(ImfManager.State.Hide, manager.GetInputPanelState(), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetInputPanelUserData.Check whether SetInputPanelUserData works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.SetInputPanelUserData M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@partner.samsung.com")]
        public void SetInputPanelUserData_TEST()
        {
            try
            {
                ImfManager manager = ImfManager.Get();
                manager.SetInputPanelUserData("layouttype = 1 & entrylimit = 255 & action = clearall_for_voice_commit & caller = org.volt.search - all");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test GetInputPanelUserData.Check whether GetInputPanelUserData works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.GetInputPanelUserData M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@partner.samsung.com")]
        public void GetInputPanelUserData_TEST()
        {
            try
            {
                ImfManager manager = ImfManager.Get();
                manager.SetInputPanelUserData("layouttype = 1 & entrylimit = 255 & action = clearall_for_voice_commit & caller = org.volt.search - all");
                string data = "";
                manager.GetInputPanelUserData(out data);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Get.Check whether DestroyContext works or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.DestroyContext M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void DestroyContext_RETURN_VALUE()
        {
            ImfManager manager = ImfManager.Get();
            Assert.IsNotNull(manager, "The object should not be null!");
            try
            {
                manager.DestroyContext();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Check whether Activated event is triggered.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.Activated E")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public async Task Activated_CHECK_EVENT()
        {
            /* TEST CODE */
            var manager = ImfManager.Get();
            Assert.IsInstanceOf<ImfManager>(manager, "Should be an instance of ImfManager type.");
            try
            {
                _flagOnImfActivedEvent = false;
                Assert.False(_flagOnImfActivedEvent, "_flagOnImfActivedEvent should false initial");
                manager.Activated += OnImfActivedEvent;
                manager.Activate();
                await Task.Delay(20);
                Assert.True(_flagOnImfActivedEvent, "Should be true after triger Activated event.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            finally
            {
                manager.Activated -= OnImfActivedEvent;
            }
        }

        [Test]
        [Category("P1")]
        [Description("Check whether EventReceived event is triggered.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.EventReceived E")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public async Task EventReceived_CHECK_EVENT()
        {
            /* TEST CODE */
            var manager = ImfManager.Get();
            Assert.IsInstanceOf<ImfManager>(manager, "Should be an instance of ImfManager type.");
            try
            {
                _flagOnImfEventReceivedEvent = false;
                Assert.False(_flagOnImfEventReceivedEvent, "_flagOnImfEventReceivedEvent should false initial");
                manager.EventReceived += OnImfEventReceivedEvent;
                manager.Deactivate();
                manager.HideInputPanel();
                await Task.Delay(20);
                manager.Activate();
                manager.ShowInputPanel();
                await Task.Delay(20);
                Assert.True(_flagOnImfEventReceivedEvent, "Should be true after triger EventReceived event.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            finally
            {
                manager.EventReceived -= OnImfEventReceivedEvent;
            }
        }

        [Test]
        [Category("P1")]
        [Description("Check whether LanguageChanged event is triggered.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.LanguageChanged E")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public async Task LanguageChanged_CHECK_EVENT()
        {
            /* TEST CODE */
            var manager = ImfManager.Get();
            Assert.IsInstanceOf<ImfManager>(manager, "Should be an instance of ImfManager type.");
            try
            {
                _flagOnLanguageChangedEvent = false;
                Assert.False(_flagOnLanguageChangedEvent, "_flagOnLanguageChangedEvent should false initial");
                manager.LanguageChanged += OnLanguageChangedEvent;
                manager.Deactivate();
                manager.HideInputPanel();
                //await Task.Delay(300);
                manager.Activate();
                manager.ShowInputPanel();
                await Task.Delay(200);
                Tizen.Log.Fatal("NUI", "LanguageChanged_CHECK_EVENT()!!!");
                Assert.True(_flagOnLanguageChangedEvent, "Should be true after triger LanguageChanged event.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            finally
            {
                manager.LanguageChanged -= OnLanguageChangedEvent;
            }
        }

        [Test]
        [Category("P1")]
        [Description("Check whether Resized event is triggered.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.Resized E")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public async Task Resized_CHECK_EVENT()
        {
            /* TEST CODE */
            var manager = ImfManager.Get();
            Assert.IsInstanceOf<ImfManager>(manager, "Should be an instance of ImfManager type.");
            try
            {
                _flagOnResizedEvent = false;
                Assert.False(_flagOnResizedEvent, "_flagOnResizedEvent should false initial");
                manager.Resized += OnResizedEvent;
                manager.Activate();
                manager.ShowInputPanel();
                await Task.Delay(300);
                manager.Deactivate();
                manager.HideInputPanel();
                await Task.Delay(300);

                Assert.True(_flagOnResizedEvent, "Should be true after triger Resized event.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            finally
            {
                manager.Resized -= OnResizedEvent;
            }
        }

        [Test]
        [Category("P1")]
        [Description("Check whether Resized event is triggered.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.StatusChanged E")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public async Task StatusChanged_CHECK_EVENT()
        {
            /* TEST CODE */
            var manager = ImfManager.Get();
            Assert.IsInstanceOf<ImfManager>(manager, "Should be an instance of ImfManager type.");
            try
            {
                _flagOnStatusChangedEvent = false;
                Assert.False(_flagOnStatusChangedEvent, "_flagOnStatusChangedEvent should false initial");
                manager.StatusChanged += OnStatusChangedEvent;
                manager.Activate();
                manager.ShowInputPanel();
                await Task.Delay(70);
                manager.Deactivate();
                manager.HideInputPanel();
                await Task.Delay(70);
                Assert.True(_flagOnStatusChangedEvent, "Should be true after triger StatusChanged event.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            finally
            {
                manager.StatusChanged -= OnStatusChangedEvent;
            }
        }
    }
}
