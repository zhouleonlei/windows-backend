using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Window.TouchEventArgs Tests")]
    public class WindowTouchEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("TouchEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a TouchEventArgs object. Check whether TouchEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Window.TouchEventArgs.TouchEventArgs A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TouchEventArgs_INIT()
        {
            /* TEST CODE */
            var touchEventArgs = new Window.TouchEventArgs();
            Assert.IsNotNull(touchEventArgs, "Can't create success object TouchEventArgs");
            Assert.IsInstanceOf<Window.TouchEventArgs>(touchEventArgs, "Should be an instance of TouchEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Touch. Check whether Touch is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Window.TouchEventArgs.Touch A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Touch_SET_GET_VALUE()
        {
            /* TEST CODE */
            Window.TouchEventArgs touchEventArgs = new Window.TouchEventArgs();
            Touch touch = new Touch();
            touchEventArgs.Touch = touch;
            Assert.AreEqual(touch, touchEventArgs.Touch, "Retrieved Touch should be equal to set value");
        }
    }
}