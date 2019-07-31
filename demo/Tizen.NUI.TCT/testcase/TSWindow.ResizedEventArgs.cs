using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Window.ResizedEventArgs Tests")]
    public class WindowResizedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ResizedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a ResizedEventArgs object. Check whether ResizedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Window.ResizedEventArgs.ResizedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ResizedEventArgs_INIT()
        {
            /* TEST CODE */
            var resizedEventArgs = new Window.ResizedEventArgs();
            Assert.IsNotNull(resizedEventArgs, "Can't create success object ResizedEventArgs");
            Assert.IsInstanceOf<Window.ResizedEventArgs>(resizedEventArgs, "Should be an instance of ResizedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test WindowSize. Check whether WindowSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Window.ResizedEventArgs.WindowSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void WindowSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            Window.ResizedEventArgs resizedEventArgs = new Window.ResizedEventArgs();
            resizedEventArgs.WindowSize = new Size2D(100, 100);
            Assert.AreEqual(100, resizedEventArgs.WindowSize.Width, "The resizedEventArgs.WindowSize.Width is not correct!");
            Assert.AreEqual(100, resizedEventArgs.WindowSize.Height, "The resizedEventArgs.WindowSize.Height is not correct!");
        }
    }
}
