using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Window.FocusChangedEventArgs Tests")]
    public class WindowFocusChangedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("FocusChangedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a FocusChangedEventArgs object. Check whether FocusChangedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Window.FocusChangedEventArgs.FocusChangedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void FocusChangedEventArgs_INIT()
        {
            /* TEST CODE */
            var focusChangedEventArgs = new Window.FocusChangedEventArgs();
            Assert.IsNotNull(focusChangedEventArgs, "Can't create success object FocusChangedEventArgs");
            Assert.IsInstanceOf<Window.FocusChangedEventArgs>(focusChangedEventArgs, "Should be an instance of FocusChangedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Key. Check whether Key is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Window.FocusChangedEventArgs.FocusGained A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void FocusGained_SET_GET_VALUE()
        {
            /* TEST CODE */
            Window.FocusChangedEventArgs focusChangedEventArgs = new Window.FocusChangedEventArgs();
            focusChangedEventArgs.FocusGained = true;
            Assert.IsTrue(focusChangedEventArgs.FocusGained, "FocusGained should be equal to set value");
        }
    }
}
