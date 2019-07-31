using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Window.WheelEventArgs Tests")]
    public class WindowWheelEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("WheelEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a WheelEventArgs object. Check whether WheelEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Window.WheelEventArgs.WheelEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void WheelEventArgs_INIT()
        {
            /* TEST CODE */
            var wheelEventArgs = new Window.WheelEventArgs();
            Assert.IsNotNull(wheelEventArgs, "Can't create success object WheelEventArgs");
            Assert.IsInstanceOf<Window.WheelEventArgs>(wheelEventArgs, "Should be an instance of WheelEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Wheel. Check whether Wheel is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Window.WheelEventArgs.Wheel A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Wheel_SET_GET_VALUE()
        {
            /* TEST CODE */
            Window.WheelEventArgs wheelEventArgs = new Window.WheelEventArgs();
            Wheel wheel = new Wheel();
            wheelEventArgs.Wheel = wheel;
            Assert.AreEqual(wheel, wheelEventArgs.Wheel, "Retrieved Wheel should be equal to set value");
        }
    }
}
