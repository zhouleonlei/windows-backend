using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Timer.TickEventArgs Tests")]
    public class TimerTickEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("TickEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a TickEventArgs object. Check whether TickEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Timer.TickEventArgs.TickEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void TickEventArgs_INIT()
        {
            /* TEST CODE */
            var tickEventArgs = new Timer.TickEventArgs();
            Assert.IsNotNull(tickEventArgs, "Can't create success object TickEventArgs");
            Assert.IsInstanceOf<Timer.TickEventArgs>(tickEventArgs, "Should be an instance of TickEventArgs type.");
        }
    }
}
