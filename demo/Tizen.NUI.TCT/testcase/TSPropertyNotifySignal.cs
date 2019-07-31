using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.PropertyNotifySignal Tests")]
    public class PropertyNotifySignalTests
    {
        private string TAG = "NUI";
        public delegate void SignalCallback();

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("PropertyNotifySignalTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyNotifySignal constructor test.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotifySignal.PropertyNotifySignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PropertyNotifySignal_INIT()
        {
            /* TEST CODE */
            var propertyNotifySignal = new PropertyNotifySignal();
            Assert.IsNotNull(propertyNotifySignal, "Should be not null!");
            Assert.IsInstanceOf<PropertyNotifySignal>(propertyNotifySignal, "Should be an Instance of PropertyNotifySignal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the PropertyNotifySignal.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotifySignal.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                PropertyNotifySignal propertyNotifySignal = new PropertyNotifySignal();
                propertyNotifySignal.Dispose();
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
        [Description("Test Dispose, try to dispose the PropertyNotifySignal.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotifySignal.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("COVPARAM", "DisposeTypes")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST_WITH_DISPOSETYPE()
        {
            /* TEST CODE */
            try
            {
                MyPropertyNotifySignal propertyNotifySignal = new MyPropertyNotifySignal();
                propertyNotifySignal.Dispose();
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
        [Property("SPEC", "Tizen.NUI.PropertyNotifySignal.swigCMemOwn A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void swigCMemOwn_SET_GET_VALUE()
        {
            /* TEST CODE */
            MyPropertyNotifySignal propertyNotifySignal = new MyPropertyNotifySignal();
            propertyNotifySignal.SwigCMemOwn = false;

            Assert.IsFalse(propertyNotifySignal.SwigCMemOwn, "The SwigCMemOwn property of MyPropertyNotifySignal is not correct here.");

            propertyNotifySignal.SwigCMemOwn = true;

            Assert.IsTrue(propertyNotifySignal.SwigCMemOwn, "The SwigCMemOwn property of MyPropertyNotifySignal is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test disposed. Check whether disposed is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotifySignal.disposed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void disposed_SET_GET_VALUE()
        {
            /* TEST CODE */
            MyPropertyNotifySignal propertyNotifySignal = new MyPropertyNotifySignal();
            propertyNotifySignal.Disposed = false;

            Assert.IsFalse(propertyNotifySignal.Disposed, "The Disposed property of MyPropertyNotifySignal is not correct here.");

            propertyNotifySignal.Disposed = true;

            Assert.IsTrue(propertyNotifySignal.Disposed, "The Disposed property of MyPropertyNotifySignal is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Empty, try to check whether the Empty method return the correct value.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotifySignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Empty_TEST()
        {
            /* TEST CODE */
            try
            {
                PropertyNotifySignal propertyNotifySignal = new PropertyNotifySignal();
                Assert.IsTrue(propertyNotifySignal.Empty(), "Should be true here!");
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
        [Property("SPEC", "Tizen.NUI.PropertyNotifySignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetConnectionCount_TEST()
        {
            /* TEST CODE */
            try
            {
                PropertyNotifySignal propertyNotifySignal = new PropertyNotifySignal();
                Assert.AreEqual(0, propertyNotifySignal.GetConnectionCount(), "Should be zero here!");
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
        [Property("SPEC", "Tizen.NUI.PropertyNotifySignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Connect_TEST()
        {
            /* TEST CODE */
            try
            {
                PropertyNotifySignal propertyNotifySignal = new PropertyNotifySignal();
                SignalCallback signalCallback = new SignalCallback(MyDelegate);
                propertyNotifySignal.Connect(signalCallback);
                Assert.AreEqual(1, propertyNotifySignal.GetConnectionCount(), "Should be one here!");
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
        [Description("Check exception when the args of the Connect method is null.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotifySignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Connect_CHECK_NULL()
        {
            /* TEST CODE */
            try
            {
                PropertyNotifySignal propertyNotifySignal = new PropertyNotifySignal();
                propertyNotifySignal.Connect(null);
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
        [Property("SPEC", "Tizen.NUI.PropertyNotifySignal.Disconnect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Disconnect_TEST()
        {
            /* TEST CODE */
            try
            {
                PropertyNotifySignal propertyNotifySignal = new PropertyNotifySignal();
                SignalCallback signalCallback = new SignalCallback(MyDelegate);
                propertyNotifySignal.Connect(signalCallback);
                Assert.AreEqual(1, propertyNotifySignal.GetConnectionCount(), "Should be one here!");
                propertyNotifySignal.Disconnect(signalCallback);
                Assert.AreEqual(0, propertyNotifySignal.GetConnectionCount(), "Should be zero here!");
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
        [Property("SPEC", "Tizen.NUI.PropertyNotifySignal.Disconnect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Disconnect_CHECK_NULL()
        {
            /* TEST CODE */
            try
            {
                PropertyNotifySignal propertyNotifySignal = new PropertyNotifySignal();
                propertyNotifySignal.Disconnect(null);
                Assert.Fail("Should throw the ArgumentNullException!");
            }
            catch (ArgumentNullException e)
            {
                Assert.True(true);
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Emit, try to check whether the Emit method works or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotifySignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Emit_TEST()
        {
            /* TEST CODE */
            try
            {
                PropertyNotifySignal propertyNotifySignal = new PropertyNotifySignal();
                View view = new View();
                view.Size2D = new Size2D(200, 200);
                view.BackgroundColor = Color.Red;
                Window.Instance.Add(view);
                PropertyNotification propertyNotification = view.AddPropertyNotification("PositionX", PropertyCondition.GreaterThan(100.0f));
                propertyNotifySignal.Emit(propertyNotification);
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
        [Description("Check exception when the args of the Emit method is null.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotifySignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Emit_CHECK_NULL()
        {
            /* TEST CODE */
            try
            {
                PropertyNotifySignal propertyNotifySignal = new PropertyNotifySignal();
                propertyNotifySignal.Emit(null);
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

    public class MyPropertyNotifySignal : PropertyNotifySignal
    {
        public new void Dispose()
        {
            Dispose(DisposeTypes.Implicit);
        }

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

        public bool Disposed
        {
            get
            {
                return disposed;
            }
            set
            {
                disposed = value;
            }
        }
    }
}
