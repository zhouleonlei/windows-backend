using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using System.Runtime.InteropServices;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.KeyboardTypeSignalType Tests")]
    public class KeyboardTypeSignalTypeTests
    {
        private string TAG = "NUI";

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void SignalCallback(int signal);

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("KeyboardTypeSignalTypeTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("KeyboardTypeSignalType constructor test.")]
        [Property("SPEC", "Tizen.NUI.KeyboardTypeSignalType.KeyboardTypeSignalType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void KeyboardTypeSignalType_INIT()
        {
            /* TEST CODE */
            var keyboardTypeSignalType = new KeyboardTypeSignalType();
            Assert.IsNotNull(keyboardTypeSignalType, "Should be not null!");
            Assert.IsInstanceOf<KeyboardTypeSignalType>(keyboardTypeSignalType, "Should be an Instance of KeyboardTypeSignalType!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the KeyboardTypeSignalType.")]
        [Property("SPEC", "Tizen.NUI.KeyboardTypeSignalType.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                KeyboardTypeSignalType keyboardTypeSignalType = new KeyboardTypeSignalType();
                keyboardTypeSignalType.Dispose();
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
        [Description("Test Dispose, try to dispose the KeyboardTypeSignalType.")]
        [Property("SPEC", "Tizen.NUI.KeyboardTypeSignalType.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("COVPARAM", "DisposeTypes")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST_WITH_DISPOSETYPE()
        {
            /* TEST CODE */
            try
            {
                MyKeyboardTypeSignalType keyboardTypeSignalType = new MyKeyboardTypeSignalType();
                keyboardTypeSignalType.Dispose();
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
        [Property("SPEC", "Tizen.NUI.KeyboardTypeSignalType.swigCMemOwn A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void swigCMemOwn_SET_GET_VALUE()
        {
            /* TEST CODE */
            MyKeyboardTypeSignalType keyboardTypeSignalType = new MyKeyboardTypeSignalType();
            keyboardTypeSignalType.SwigCMemOwn = false;

            Assert.IsFalse(keyboardTypeSignalType.SwigCMemOwn, "The SwigCMemOwn property of MyKeyboardTypeSignalType is not correct here.");

            keyboardTypeSignalType.SwigCMemOwn = true;

            Assert.IsTrue(keyboardTypeSignalType.SwigCMemOwn, "The SwigCMemOwn property of MyKeyboardTypeSignalType is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test disposed. Check whether disposed is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.KeyboardTypeSignalType.disposed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void disposed_SET_GET_VALUE()
        {
            /* TEST CODE */
            MyKeyboardTypeSignalType keyboardTypeSignalType = new MyKeyboardTypeSignalType();
            keyboardTypeSignalType.Disposed = false;

            Assert.IsFalse(keyboardTypeSignalType.Disposed, "The Disposed property of MyKeyboardTypeSignalType is not correct here.");

            keyboardTypeSignalType.Disposed = true;

            Assert.IsTrue(keyboardTypeSignalType.Disposed, "The Disposed property of MyKeyboardTypeSignalType is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Empty, try to check whether the Empty method return the correct value.")]
        [Property("SPEC", "Tizen.NUI.KeyboardTypeSignalType.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Empty_TEST()
        {
            /* TEST CODE */
            try
            {
                KeyboardTypeSignalType keyboardTypeSignalType = new KeyboardTypeSignalType();
                Assert.IsTrue(keyboardTypeSignalType.Empty(), "Should be true here!");
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
        [Property("SPEC", "Tizen.NUI.KeyboardTypeSignalType.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetConnectionCount_TEST()
        {
            /* TEST CODE */
            try
            {
                KeyboardTypeSignalType keyboardTypeSignalType = new KeyboardTypeSignalType();
                Assert.AreEqual(0, keyboardTypeSignalType.GetConnectionCount(), "Should be zero here!");
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
        [Property("SPEC", "Tizen.NUI.KeyboardTypeSignalType.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Connect_TEST()
        {
            /* TEST CODE */
            try
            {
                KeyboardTypeSignalType keyboardTypeSignalType = new KeyboardTypeSignalType();
                SignalCallback signalCallback = new SignalCallback(MyDelegate);
                keyboardTypeSignalType.Connect(signalCallback);
                Assert.AreEqual(1, keyboardTypeSignalType.GetConnectionCount(), "Should be one here!");
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
        [Property("SPEC", "Tizen.NUI.KeyboardTypeSignalType.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Connect_CHECK_NULL()
        {
            /* TEST CODE */
            try
            {
                KeyboardTypeSignalType keyboardTypeSignalType = new KeyboardTypeSignalType();
                keyboardTypeSignalType.Connect(null);
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
        [Property("SPEC", "Tizen.NUI.KeyboardTypeSignalType.Disconnect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Disconnect_TEST()
        {
            /* TEST CODE */
            try
            {
                KeyboardTypeSignalType keyboardTypeSignalType = new KeyboardTypeSignalType();
                SignalCallback signalCallback = new SignalCallback(MyDelegate);
                keyboardTypeSignalType.Connect(signalCallback);
                Assert.AreEqual(1, keyboardTypeSignalType.GetConnectionCount(), "Should be one here!");
                keyboardTypeSignalType.Disconnect(signalCallback);
                Assert.AreEqual(0, keyboardTypeSignalType.GetConnectionCount(), "Should be zero here!");
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
        [Property("SPEC", "Tizen.NUI.KeyboardTypeSignalType.Disconnect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Disconnect_CHECK_NULL()
        {
            /* TEST CODE */
            try
            {
                KeyboardTypeSignalType keyboardTypeSignalType = new KeyboardTypeSignalType();
                keyboardTypeSignalType.Disconnect(null);
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
        [Property("SPEC", "Tizen.NUI.KeyboardTypeSignalType.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Emit_TEST()
        {
            /* TEST CODE */
            try
            {
                KeyboardTypeSignalType keyboardTypeSignalType = new KeyboardTypeSignalType();
                SignalCallback signalCallback = new SignalCallback(MyDelegate);
                keyboardTypeSignalType.Connect(signalCallback);
                keyboardTypeSignalType.Emit(InputMethodContext.KeyboardType.HardwareKeyboard);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }


        public static void MyDelegate(int signal)
        {
            Log.Fatal("TCT", "[TestCase][AddIdle][NUIApplication] Pass");
        }
    }

    public class MyKeyboardTypeSignalType : KeyboardTypeSignalType
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
