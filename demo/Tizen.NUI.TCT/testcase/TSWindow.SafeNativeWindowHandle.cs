using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Window.SafeNativeWindowHandle Tests")]
    public class WindowSafeNativeWindowHandleTests
    {
        private string TAG = "NUI-TCT";
        internal class MySafeNativeWindowHandle : Window.SafeNativeWindowHandle
        {
            public bool MyReleaseHandle()
            {
                return base.ReleaseHandle();
            }
        }

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a SafeNativeWindowHandle object. Check whether SafeNativeWindowHandle is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Window.SafeNativeWindowHandle.SafeNativeWindowHandle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SafeNativeWindowHandle_INIT()
        {
            /* TEST CODE */
            var safeNativeWindowHandle = new Window.SafeNativeWindowHandle();
            Assert.IsNotNull(safeNativeWindowHandle, "Can't create success object SafeNativeWindowHandle");
            Assert.IsInstanceOf<Window.SafeNativeWindowHandle>(safeNativeWindowHandle, "Should be an instance of SafeNativeWindowHandle type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Key. Check whether IsInvalid is readable.")]
        [Property("SPEC", "Tizen.NUI.Window.SafeNativeWindowHandle.IsInvalid A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void IsInvalid_READ_ONLY()
        {
            /* TEST CODE */
            Window.SafeNativeWindowHandle safeNativeWindowHandle = new Window.SafeNativeWindowHandle();
            Assert.IsFalse(safeNativeWindowHandle.IsInvalid, "safeNativeWindowHandle should be valid here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test ReleaseHandle. Check whether ReleaseHandle returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Window.SafeNativeWindowHandle.ReleaseHandle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void ReleaseHandle_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var mySafeHandle = new MySafeNativeWindowHandle();
            Assert.IsInstanceOf<Window.SafeNativeWindowHandle>(mySafeHandle, "Should be an instance of SafeNativeWindowHandle type.");
            bool ret = mySafeHandle.MyReleaseHandle();
            Assert.AreEqual(true, ret, "The return value should be true here.");
        }
    }
}
