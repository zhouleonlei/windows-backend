using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Window.WindowFocusChangedEventArgs Tests")]
    public class WindowWindowFocusChangedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("WindowFocusChangedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a WindowFocusChangedEventArgs object. Check whether WindowFocusChangedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Window.WindowFocusChangedEventArgs.WindowFocusChangedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void WindowFocusChangedEventArgs_INIT()
        {
            /* TEST CODE */
            var focusChangedEventArgs = new Window.WindowFocusChangedEventArgs();
            Assert.IsNotNull(focusChangedEventArgs, "Can't create success object FocusChangedEventArgs");
            Assert.IsInstanceOf<Window.WindowFocusChangedEventArgs>(focusChangedEventArgs, "Should be an instance of WindowFocusChangedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Key. Check whether Key is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Window.WindowFocusChangedEventArgs.FocusGained A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void FocusGained_SET_GET_VALUE()
        {
            /* TEST CODE */
            var focusChangedEventArgs = new Window.WindowFocusChangedEventArgs();
            focusChangedEventArgs.FocusGained = true;
            Assert.IsTrue(focusChangedEventArgs.FocusGained, "FocusGained should be equal to set value");

            focusChangedEventArgs.FocusGained = false;
            Assert.IsFalse(focusChangedEventArgs.FocusGained, "FocusGained should be equal to set value");
        }
    }
}
