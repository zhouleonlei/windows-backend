using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.Scrollable.StartedEventArgs Tests")]
    public class ScrollablStartedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("StartedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a StartedEventArgs object. Check whether StartedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.StartedEventArgs.StartedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Youxia Wu, youxia17.wu@samsung.com")]
        public void StartedEventArgs_INIT()
        {
            /* TEST CODE */
            var startedEventArgs = new Scrollable.StartedEventArgs();
            Assert.IsNotNull(startedEventArgs, "Can't create success object StartedEventArgs");
            Assert.IsInstanceOf<Scrollable.StartedEventArgs>(startedEventArgs, "Should be an instance of StartedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Vector2. Check whether Vector2 is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.StartedEventArgs.Vector2 A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Youxia Wu, youxia17.wu@samsung.com")]
        public void Vector2_SET_GET_VALUE()
        {
            /* TEST CODE */
            Scrollable.StartedEventArgs startedEventArgs = new Scrollable.StartedEventArgs();
            startedEventArgs.Vector2 = new Vector2(0.3f, 0.4f);
            Assert.AreEqual(0.3f, startedEventArgs.Vector2.X, "Retrieved Vector2.X should be equal to set value");
            Assert.AreEqual(0.4f, startedEventArgs.Vector2.Y, "Retrieved Vector2.Y should be equal to set value");
        }
    }
}
