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
    [Description("Tizen.NUI.Window Tests")]
    public class WindowTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("WindowTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        private void OnFocusChanged(object obj, EventArgs e)
        { }

        private void OnKeyEvent(object obj, EventArgs e)
        { }

        private void OnTouchEvent(object obj, EventArgs e)
        { }

        private void OnWheelEvent(object obj, EventArgs e)
        { }

        [Test]
        [Category("P1")]
        [Description("dali window Raise test, try to raise the window")]
        [Property("SPEC", "Tizen.NUI.Window.Raise M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Raise_TEST()
        {
            /* TEST CODE */
            try
            {
                Window window = Window.Instance;
                window.Raise();
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
        [Description("dali window Lower test, try to lower the window")]
        [Property("SPEC", "Tizen.NUI.Window.Lower M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Lower_TEST()
        {
            /* TEST CODE */
            try
            {
                Window window = Window.Instance;
                window.Lower();
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
        [Description("dali window RenderOnce test")]
        [Property("SPEC", "Tizen.NUI.Window.RenderOnce M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@partner.samsung.com")]
        public void RenderOnce_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                Window window = Window.Instance;
                window.RenderOnce();
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
        [Description("dali window Title test")]
        [Property("SPEC", "Tizen.NUI.Window.Title A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@partner.samsung.com")]
        public void Title_SET_GET_VALUE()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            window.Title = "NUIWindow";
            Assert.AreEqual("NUIWindow", window.Title, "Should be equal to the setted value!");
        }

        [Test]
        [Category("P1")]
        [Description("dali window Activate test, try to activate the window")]
        [Property("SPEC", "Tizen.NUI.Window.Activate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Activate_TEST()
        {
            /* TEST CODE */
            try
            {
                Window window = Window.Instance;
                window.Activate();
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
        [Description("dali window Hide test, try to Hide the window")]
        [Property("SPEC", "Tizen.NUI.Window.Hide M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Hide_TEST()
        {
            /* TEST CODE */
            try
            {
                Window window = Window.Instance;
                window.Hide();
                Assert.IsFalse(window.IsVisible(), "Should not be visible now.");
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
        [Description("dali window Show test, try to Show the window")]
        [Property("SPEC", "Tizen.NUI.Window.Show M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Show_TEST()
        {
            /* TEST CODE */
            try
            {
                Window window = Window.Instance;
                window.Show();
                Assert.IsTrue(window.IsVisible(), "Should be visible now.");
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
        [Description("dali window IsVisible test, test the IsVisible with Show/Hide the window")]
        [Property("SPEC", "Tizen.NUI.Window.IsVisible M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void IsVisible_TEST()
        {
            /* TEST CODE */
            try
            {
                Window window = Window.Instance;
                window.Show();
                Assert.IsTrue(window.IsVisible(), "Should be visible now.");
                window.Hide();
                Assert.IsFalse(window.IsVisible(), "Should not be visible now.");
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
        [Description("dali window SetAcceptFocus test, test the SetAcceptFocus with IsFocusAcceptable")]
        [Property("SPEC", "Tizen.NUI.Window.SetAcceptFocus M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SetAcceptFocus_TEST()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            window.SetAcceptFocus(false);
            Assert.IsFalse(window.IsFocusAcceptable(), "Should be false now.");
        }

        [Test]
        [Category("P1")]
        [Description("dali window IsFocusAcceptable test, test the IsFocusAcceptable with SetFocusAcceptable")]
        [Property("SPEC", "Tizen.NUI.Window.IsFocusAcceptable M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void IsFocusAcceptable_TEST()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            window.SetAcceptFocus(true);
            Assert.IsTrue(window.IsFocusAcceptable(), "Should be true now.");
        }

        [Test]
        [Category("P1")]
        [Description("dali window GrabKey test, test the GrabKey")]
        [Property("SPEC", "Tizen.NUI.Window.GrabKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GrabKey_TEST()
        {
            /* TEST CODE */
            try
            {
                Window window = Window.Instance;
                window.GrabKey(196, Window.KeyGrabMode.Shared);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("dali window UngrabKey test, test the UngrabKey")]
        [Property("SPEC", "Tizen.NUI.Window.UngrabKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void UngrabKey_TEST()
        {
            /* TEST CODE */
            try
            {
                Window window = Window.Instance;
                window.UngrabKey(196);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("dali window GrabKeyTopmost test, test the GrabKeyTopmost")]
        [Property("SPEC", "Tizen.NUI.Window.GrabKeyTopmost M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GrabKeyTopmost_TEST()
        {
            /* TEST CODE */
            try
            {
                Window window = Window.Instance;
                window.GrabKeyTopmost(196);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("dali window UngrabKeyTopmost test, test the UngrabKeyTopmost")]
        [Property("SPEC", "Tizen.NUI.Window.UngrabKeyTopmost M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void UngrabKeyTopmost_TEST()
        {
            /* TEST CODE */
            try
            {
                Window window = Window.Instance;
                window.UngrabKeyTopmost(196);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Size. Check whether Size returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Window.Size A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Size_GET_VALUE()
        {
            /* TEST CODE */
            Window stage = Window.Instance;
            Size2D size = stage.Size;
            Assert.IsTrue(size.Width > 0.0f, "The Width of the screen is not correct!");
            Assert.IsTrue(size.Height > 0.0f, "The Height of the screen is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test BackgroundColor. Check whether BackgroundColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Window.BackgroundColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void BackgroundColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            Window stage = Window.Instance;
            stage.BackgroundColor = new Color(0.1f, 0.2f, 0.3f, 1.0f);
            Color color = stage.BackgroundColor;
            Assert.AreEqual(0.1f, color.R, "The R property of BackgroundColor is not correct!");
            Assert.AreEqual(0.2f, color.G, "The G property of BackgroundColor is not correct!");
            Assert.AreEqual(0.3f, color.B, "The B property of BackgroundColor is not correct!");
            Assert.AreEqual(1.0f, color.A, "The A property of BackgroundColor is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Instance. Check whether Instance returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Window.Instance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Instance_GET_VALUE()
        {
            /* TEST CODE */
            Window stage = Window.Instance;
            Assert.IsInstanceOf<Window>(stage, "Should be an Instance of Window!");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetDefaultLayer.")]
        [Property("SPEC", "Tizen.NUI.Window.GetDefaultLayer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetDefaultLayer_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Window stage = Window.Instance;
            Layer layer = stage.GetDefaultLayer();
            Assert.IsTrue((stage.GetLayer(0) == layer), "Should be equal!");
        }


        [Test]
        [Category("P1")]
        [Description("Test SetKeyboardRepeatInfo.")]
        [Property("SPEC", "Tizen.NUI.Window.SetKeyboardRepeatInfo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void SetKeyboardRepeatInfo_CHECK_VALUE()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            bool ret = window.SetKeyboardRepeatInfo(3.0f, 0.05f);
            Assert.IsTrue(ret, "Should be true");
            float outRate, outDelay;
            Tizen.Log.Debug(TAG, "return=" + ret + "  window.GetKeyboardRepeatInfo() =" + window.GetKeyboardRepeatInfo(out outRate, out outDelay));
            Assert.AreEqual(3.0f, outRate, "out rate should be 3.0f but is " + outRate.ToString());
            Assert.AreEqual(0.05f, outDelay, "out delay should be 0.05f but is " + outDelay.ToString());
        }

        [Test]
        [Category("P1")]
        [Description("Test GetKeyboardRepeatInfo.")]
        [Property("SPEC", "Tizen.NUI.Window.GetKeyboardRepeatInfo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void GetKeyboardRepeatInfo_CHECK_VALUE()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            float outRate, outDelay;
            window.SetKeyboardRepeatInfo(3.0f, 0.05f);
            bool ret = window.GetKeyboardRepeatInfo(out outRate, out outDelay);
            Assert.IsTrue(ret, "Should be true");
            Assert.AreEqual(3.0f, outRate, "out rate should be 3.0f but is " + outRate.ToString());
            Assert.AreEqual(0.05f, outDelay, "out delay should be 0.05f but is " + outDelay.ToString());
        }

        [Test]
        [Category("P1")]
        [Description("Test KeepRendering.")]
        [Property("SPEC", "Tizen.NUI.Window.KeepRendering M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void KeepRendering_TEST()
        {
            /* TEST CODE */
            try
            {
                Window stage = Window.Instance;
                stage.KeepRendering(5.0f);
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
        [Description("Test AddLayer.")]
        [Property("SPEC", "Tizen.NUI.Window.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("COVPARAM", "View")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Add_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                Window stage = Window.Instance;
                View view = new View();
                stage.Add(view);
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
        [Description("Test AddLayer.")]
        [Property("SPEC", "Tizen.NUI.Window.AddLayer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AddLayer_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                Window stage = Window.Instance;
                Layer layer = new Layer();
                stage.AddLayer(layer);
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
        [Description("Test Dpi. Check whether Dpi returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Window.Dpi A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dpi_GET_VALUE()
        {
            /* TEST CODE */
            Window stage = Window.Instance;
            Vector2 dpi = stage.Dpi;
            Assert.IsTrue(dpi.X > 0.0f, "The X property of DPI is not correct!");
            Assert.IsTrue(dpi.Y > 0.0f, "The Y property of DPI is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test LayerCount. Check whether LayerCount returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Window.LayerCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void LayerCount_GET_VALUE()
        {
            /* TEST CODE */
            Window stage = Window.Instance;
            Assert.GreaterOrEqual(stage.LayerCount, 1, "The LayoutCount of the stage should be >= 1 here!");
            Layer newLayer = new Layer();
            stage.AddLayer(newLayer);
            Assert.GreaterOrEqual(stage.LayerCount, 2, "The LayoutCount of the stage should be >= 2 here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetSupportedAuxiliaryHintCount. Check whether GetSupportedAuxiliaryHintCount returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Window.GetSupportedAuxiliaryHintCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetSupportedAuxiliaryHintCount_GET_VALUE()
        {
            /* TEST CODE */
            try
            {
                Window window = Window.Instance;
                uint count = window.GetSupportedAuxiliaryHintCount();
                Assert.Greater(count, 0, "Should more than 0");
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
        [Description("Test GetSupportedAuxiliaryHint. Check whether GetSupportedAuxiliaryHint returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Window.GetSupportedAuxiliaryHint M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetSupportedAuxiliaryHint_GET_VALUE()
        {
            /* TEST CODE */
            try
            {
                Window window = Window.Instance;
                uint count = window.GetSupportedAuxiliaryHintCount();
                if (count > 0)
                {
                    string str = window.GetSupportedAuxiliaryHint(0);
                    Assert.AreEqual("wm.policy.win.user.geometry", str, "Should be equal to NUI");
                }
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
        [Description("Test AddAuxiliaryHint. Check whether AddAuxiliaryHint works fine or not.")]
        [Property("SPEC", "Tizen.NUI.Window.AddAuxiliaryHint M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AddAuxiliaryHint_SET_VALUE()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            if (window.GetSupportedAuxiliaryHintCount() > 0)
            {
                uint id = window.AddAuxiliaryHint(window.GetSupportedAuxiliaryHint(0), "hello");
                if (id != 0)
                {
                    String value = window.GetAuxiliaryHintValue(id);
                    Assert.AreEqual("hello", value, "The AddAuxiliaryHint function does not work fine.");
                }
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test GetAuxiliaryHintValue. Check whether GetAuxiliaryHintValue returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Window.GetAuxiliaryHintValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetAuxiliaryHintValue_GET_VALUE()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            if (window.GetSupportedAuxiliaryHintCount() > 0)
            {
                uint id = window.AddAuxiliaryHint(window.GetSupportedAuxiliaryHint(0), "hello");
                if (id != 0)
                {
                    String value = window.GetAuxiliaryHintValue(id);
                    Assert.AreEqual("hello", value, "The GetAuxiliaryHintValue function does not work fine.");
                }
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test SetAuxiliaryHintValue. Check whether SetAuxiliaryHintValue works fine or not.")]
        [Property("SPEC", "Tizen.NUI.Window.SetAuxiliaryHintValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SetAuxiliaryHintValue_SET_VALUE()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            if (window.GetSupportedAuxiliaryHintCount() > 0)
            {
                uint id = window.AddAuxiliaryHint(window.GetSupportedAuxiliaryHint(0), "hello");
                if (id != 0)
                {
                    window.SetAuxiliaryHintValue(id, "Morning");
                    String value = window.GetAuxiliaryHintValue(id);
                    Assert.AreEqual("Morning", value, "The SetAuxiliaryHintValue function does not work fine.");
                }
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test GetAuxiliaryHintId. Check whether GetAuxiliaryHintId works fine or not.")]
        [Property("SPEC", "Tizen.NUI.Window.GetAuxiliaryHintId M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetAuxiliaryHintId_GET_VALUE()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            if (window.GetSupportedAuxiliaryHintCount() > 0)
            {
                uint id = window.AddAuxiliaryHint(window.GetSupportedAuxiliaryHint(0), "hello");
                if (id != 0)
                {
                    Assert.AreEqual(id, window.GetAuxiliaryHintId(window.GetSupportedAuxiliaryHint(0)), "The GetAuxiliaryHintId function does not work fine.");
                }
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test RemoveAuxiliaryHint. Check whether RemoveAuxiliaryHint works fine or not.")]
        [Property("SPEC", "Tizen.NUI.Window.RemoveAuxiliaryHint M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RemoveAuxiliaryHint_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                Window window = Window.Instance;
                if (window.GetSupportedAuxiliaryHintCount() > 0)
                {
                    uint id = window.AddAuxiliaryHint(window.GetSupportedAuxiliaryHint(0), "hello");
                    if (id != 0)
                    {
                        Assert.IsTrue(window.RemoveAuxiliaryHint(id), "Remove Failed");
                    }
                }
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
        [Description("Test SetOpaqueState. Check whether SetOpaqueState works fine or not.")]
        [Property("SPEC", "Tizen.NUI.Window.SetOpaqueState M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SetOpaqueState_SET_VALUE()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            window.SetOpaqueState(false);
            Assert.IsFalse(window.IsOpaqueState(), "SetOpaqueState does not work.");
        }

        [Test]
        [Category("P1")]
        [Description("Test IsOpaqueState. Check whether IsOpaqueState works fine or not.")]
        [Property("SPEC", "Tizen.NUI.Window.IsOpaqueState M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void IsOpaqueState_GET_VALUE()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            window.SetOpaqueState(false);
            Assert.IsFalse(window.IsOpaqueState(), "IsOpaqueState does not work.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Type, Check whether Type works fine or not.")]
        [Property("SPEC", "Tizen.NUI.Window.Type M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Type_SET_GET_VALUE()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            window.Type = WindowType.Normal;
            Assert.AreEqual(WindowType.Normal, window.Type, "Type does not work fine");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetInputRegion, Check whether SetInputRegion works fine or not..")]
        [Property("SPEC", "Tizen.NUI.Window.SetInputRegion M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SetInputRegion_TEST()
        {
            /* TEST CODE */
            try
            {
                Window window = Window.Instance;
                window.SetInputRegion(new Rectangle(0, 0, 1920, 1080));
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
        [Test]
        [Category("P1")]
        [Description("Test SetBrightness. Check whether SetBrightness works fine or not.")]
        [Property("SPEC", "Tizen.NUI.Window.SetBrightness M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SetBrightness_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            window.SetBrightness(20);
            var brightness = window.GetBrightness();
            Tizen.Log.Debug(TAG, "brightness=" + brightness);
            //This is for multi Window feature, currently not supported.
            Assert.IsNotNull(brightness);
        }

        [Test]
        [Category("P1")]
        [Description("Test GetBrightness. Check whether GetBrightness works fine or not.")]
        [Property("SPEC", "Tizen.NUI.Window.GetBrightness M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetBrightness_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            window.SetBrightness(20);
            //This is for multi Window feature, currently not supported.
            Assert.IsNotNull(window.GetBrightness());
        }

        [Test]
        [Category("P1")]
        [Description("Test GetLayer.")]
        [Property("SPEC", "Tizen.NUI.Window.GetLayer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetLayer_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Layer layer = Window.Instance.GetDefaultLayer();
            Assert.IsTrue((Window.Instance.GetLayer(0) == layer), "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetNotificationLevel. Check whether SetNotificationLevel works fine or not.")]
        [Property("SPEC", "Tizen.NUI.Window.SetNotificationLevel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SetNotificationLevel_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            bool ret = window.SetNotificationLevel(NotificationLevel.Top);
            Tizen.Log.Debug(TAG, "return=" + ret + "  window.GetNotificationLevel()=" + window.GetNotificationLevel());
            //This is for multi Window feature, currently not supported.
            Assert.IsNotNull(window.GetNotificationLevel());
        }

        [Test]
        [Category("P1")]
        [Description("Test GetNotificationLevel. Check whether GetNotificationLevel works fine or not.")]
        [Property("SPEC", "Tizen.NUI.Window.GetNotificationLevel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetNotificationLevel_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            Assert.IsNotNull(window, "The instance should be not null");
            window.SetNotificationLevel(NotificationLevel.Top);
            //This is for multi Window feature, currently not supported.
            Assert.IsNotNull(window.GetNotificationLevel());
        }
        [Test]
        [Category("P1")]
        [Description("Test SetScreenOffMode. Check whether SetScreenOffMode works fine or not.")]
        [Property("SPEC", "Tizen.NUI.Window.SetScreenOffMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SetScreenOffMode_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            Assert.IsNotNull(window, "The instance should be not null");
            window.SetScreenOffMode(ScreenOffMode.Timout);
            Assert.AreEqual(ScreenOffMode.Timout, window.GetScreenOffMode(), "SetScreenMode does not work.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetScreenOffMode. Check whether GetScreenOffMode works fine or not.")]
        [Property("SPEC", "Tizen.NUI.Window.GetScreenOffMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetScreenOffMode_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            Assert.IsNotNull(window, "The instance should be not null");
            window.SetScreenOffMode(ScreenOffMode.Timout);
            Assert.AreEqual(ScreenOffMode.Timout, window.GetScreenOffMode(), "GetScreenMode does not work.");
        }

        [Test]
        [Category("P1")]
        [Description("Test RemoveLayer.")]
        [Property("SPEC", "Tizen.NUI.Window.RemoveLayer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RemoveLayer_CHECK_RETURN_VALUE_LAYER()
        {
            /* TEST CODE */
            try
            {
                Window stage = Window.Instance;
                Assert.IsNotNull(stage, "The instance should be not null");
                Layer layer = new Layer();
                stage.AddLayer(layer);
                stage.RemoveLayer(layer);
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
        [Description("Test RemoveLayer. Remove a view from the window")]
        [Property("SPEC", "Tizen.NUI.Window.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "View")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Remove_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                Window window = Window.Instance;
                View view = new View();
                view.Size2D = new Size2D(100, 100);
                view.BackgroundColor = Color.Red;
                window.Add(view);
                window.Remove(view);
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
        [Description("Test WindowPosition. Check whether WindowPosition is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Window.WindowPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void WindowPosition_SET_GET_VALUE()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            window.WindowPosition = new Position2D(100, 100);
            Assert.AreEqual(100, window.WindowPosition.X, "The X of the WindowPosition is not correct!");
            Assert.AreEqual(100, window.WindowPosition.Y, "The Y of the WindowPosition is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test WindowSize. Check whether WindowSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Window.WindowSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void WindowSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            window.WindowSize = new Size2D(100, 100);

            Tizen.Log.Debug(TAG, $"window.WindowSize.Width={window.WindowSize.Width}  window.WindowSize.Height={window.WindowSize.Height}");

            Assert.AreEqual(100, window.WindowSize.Width, "The WindowSize.Width is not correct!");
            Assert.AreEqual(100, window.WindowSize.Height, "The WindowSize.Height is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Resized. Check whe the Resized event triggered when the window Resized")]
        [Property("SPEC", "Tizen.NUI.Window.Resized E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Resized_CHECK_EVENT()
        {
            /* TEST CODE */
            Window window = Window.Instance;

            bool flag = false;
            window.Resized += (obj, e) =>
            {
                flag = true;
            };

            Tizen.Log.Debug(TAG, $"1. window resied event flag={flag}");

            window.WindowSize = new Size2D(100, 100);
            window.WindowSize = new Size2D(500, 500);
            //To make be rendered, call several times.
            window.WindowSize = new Size2D(300, 300);

            Tizen.Log.Debug(TAG, $"2. window resied event flag={flag}");
            Assert.IsTrue(flag, "The Resized Event is not triggered!");
        }

        [Test]
        [Category("P1")]
        [Description("SetClass test, Check whether SetClass function works or not.")]
        [Property("SPEC", "Tizen.NUI.Window.SetClass M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SetClass_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var window = Window.Instance;
            try
            {
                window.SetClass("NUIWindow", "window");
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
        [Description("SetTransparency test, Check whether SetTransparency function works or not.")]
        [Property("SPEC", "Tizen.NUI.Window.SetTransparency M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SetTransparency_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var window = Window.Instance;
            Assert.IsNotNull(window, "The instance should be not null");
            Assert.IsInstanceOf<Window>(window, "Should be an instance of Window type");
            try
            {
                window.SetTransparency(false);
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
        [Description("FeedKey test, Check whether FeedKey function works or not.")]
        [Property("SPEC", "Tizen.NUI.Window.FeedKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void FeedKey_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var window = Window.Instance;
            try
            {
                Key keyEvent = new Key();
                window.FeedKey(keyEvent);
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
        [Description("Window RenderingBehavior test, Check whether RenderingBehavior works or not.")]
        [Property("SPEC", "Tizen.NUI.Window.RenderingBehavior A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "huiyu eun, huiyu.eun@samsung.com")]
        public void RenderingBehavior_SET_GET_VALUE()
        {
            /* TEST CODE */
            var window = Window.Instance;
            try
            {
                window.RenderingBehavior = RenderingBehaviorType.Continuously;
                Assert.AreEqual(window.RenderingBehavior, RenderingBehaviorType.Continuously, "The window.RenderingBehavior is not Continuously!");

                window.RenderingBehavior = RenderingBehaviorType.IfRequired;
                Assert.AreEqual(window.RenderingBehavior, RenderingBehaviorType.IfRequired, "The window.RenderingBehavior is not IfRequired!");
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
        [Description("FeedKeyEvent test, Check whether FeedKeyEvent function works or not.")]
        [Property("SPEC", "Tizen.NUI.Window.FeedKeyEvent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void FeedKeyEvent_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                Key keyEvent = new Key();
                Window.FeedKeyEvent(keyEvent);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
    }
}
