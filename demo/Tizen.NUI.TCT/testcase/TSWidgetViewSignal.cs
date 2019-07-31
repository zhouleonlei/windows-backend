using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.WidgetViewSignal Tests")]
    public class WidgetViewSignalTests
    {
        private string TAG = "NUI";
        public delegate void SignalCallback();

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("WidgetViewSignalTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetViewSignal constructor test.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewSignal.WidgetViewSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void WidgetViewSignal_INIT()
        {
            /* TEST CODE */
            var widgetViewSignal = new WidgetViewSignal();
            Assert.IsNotNull(widgetViewSignal, "Should be not null!");
            Assert.IsInstanceOf<WidgetViewSignal>(widgetViewSignal, "Should be an Instance of WidgetViewSignal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the WidgetViewSignal.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewSignal.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                WidgetViewSignal widgetViewSignal = new WidgetViewSignal();
                widgetViewSignal.Dispose();
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
        [Description("Test swigCMemOwn. Check whether swigCMemOwn is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewSignal.swigCMemOwn A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void swigCMemOwn_SET_GET_VALUE()
        {
            /* TEST CODE */
            MyWidgetViewSignal widgetViewSignal = new MyWidgetViewSignal();
            widgetViewSignal.SwigCMemOwn = false;

            Assert.IsFalse(widgetViewSignal.SwigCMemOwn, "The SwigCMemOwn property of MyWidgetViewSignal is not correct here.");

            widgetViewSignal.SwigCMemOwn = true;

            Assert.IsTrue(widgetViewSignal.SwigCMemOwn, "The SwigCMemOwn property of MyWidgetViewSignal is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Empty, try to check whether the Empty method return the correct value.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Empty_TEST()
        {
            /* TEST CODE */
            try
            {
                WidgetViewSignal widgetViewSignal = new WidgetViewSignal();
                Assert.IsTrue(widgetViewSignal.Empty(), "Should be true here!");
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
        [Description("Test GetConnectionCount, try to check whether the GetConnectionCount method return the correct value.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetConnectionCount_TEST()
        {
            /* TEST CODE */
            try
            {
                WidgetViewSignal widgetViewSignal = new WidgetViewSignal();
                Assert.AreEqual(0, widgetViewSignal.GetConnectionCount(), "Should be zero here!");
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
        [Description("Test Connect, try to check whether the Connect method works or not.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Connect_TEST()
        {
            /* TEST CODE */
            try
            {
                WidgetViewSignal widgetViewSignal = new WidgetViewSignal();
                SignalCallback signalCallback = new SignalCallback(MyDelegate);
                widgetViewSignal.Connect(signalCallback);
                Assert.AreEqual(1, widgetViewSignal.GetConnectionCount(), "Should be one here!");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P2")]
        [Description("Check exception when the args of the Disconnect method is null.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Connect_CHECK_NULL()
        {
            /* TEST CODE */
            try
            {
                WidgetViewSignal widgetViewSignal = new WidgetViewSignal();
                widgetViewSignal.Connect(null);
                Assert.Fail("Should throw the ArgumentNullException!");
            }
            catch (ArgumentNullException e)
            {
                Assert.True(true);
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Disconnect, try to check whether the Disconnect method works or not.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewSignal.Disconnect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Disconnect_TEST()
        {
            /* TEST CODE */
            try
            {
                WidgetViewSignal widgetViewSignal = new WidgetViewSignal();
                SignalCallback signalCallback = new SignalCallback(MyDelegate);
                widgetViewSignal.Connect(signalCallback);
                Assert.AreEqual(1, widgetViewSignal.GetConnectionCount(), "Should be one here!");
                widgetViewSignal.Disconnect(signalCallback);
                Assert.AreEqual(0, widgetViewSignal.GetConnectionCount(), "Should be zero here!");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P2")]
        [Description("Check exception when the args of the Disconnect method is null.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewSignal.Disconnect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Disconnect_CHECK_NULL()
        {
            /* TEST CODE */
            try
            {
                WidgetViewSignal widgetViewSignal = new WidgetViewSignal();
                widgetViewSignal.Disconnect(null);
                Assert.Fail("Should throw the ArgumentNullException!");
            }
            catch (ArgumentNullException e)
            {
                Assert.True(true);
            }
        }

        [Test]
        [Category("P2")]
        [Description("Check exception when the args of the Emit method is null.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Emit_CHECK_NULL()
        {
            /* TEST CODE */
            try
            {
                WidgetViewSignal widgetViewSignal = new WidgetViewSignal();
                widgetViewSignal.Emit(null);
                Assert.Fail("Should throw the ArgumentNullException!");
            }
            catch (ArgumentNullException e)
            {
                Assert.True(true);
            }
        }

        public static void MyDelegate()
        {
            Log.Fatal("TCT", "[TestCase][AddIdle][NUIApplication] Pass");
        }
    }

    public class MyWidgetViewSignal : WidgetViewSignal
    {

        public bool SwigCMemOwn
        {
            get
            {
                return swigCMemOwn;
            }
            set
            {
                swigCMemOwn = value;
            }
        }
    }
}
