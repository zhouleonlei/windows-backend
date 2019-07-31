using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.Scrollable.CompletedEventArgs Tests")]
    public class ScrollableCompletedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("CompletedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a CompletedEventArgs object. Check whether CompletedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.CompletedEventArgs.CompletedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Youxia Wu, youxia17.wu@samsung.com")]
        public void CompletedEventArgs_INIT()
        {
            /* TEST CODE */
            var completedEventArgs = new Scrollable.CompletedEventArgs();
            Assert.IsNotNull(completedEventArgs, "Can't create success object CompletedEventArgs");
            Assert.IsInstanceOf<Scrollable.CompletedEventArgs>(completedEventArgs, "Should be an instance of CompletedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Vector2. Check whether Vector2 is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.CompletedEventArgs.Vector2 A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Youxia Wu, youxia17.wu@samsung.com")]
        public void Vector2_SET_GET_VALUE()
        {
            /* TEST CODE */
            Scrollable.CompletedEventArgs completedEventArgs = new Scrollable.CompletedEventArgs();
            completedEventArgs.Vector2 = new Vector2(0.3f, 0.4f);
            Assert.AreEqual(0.3f, completedEventArgs.Vector2.X, "Retrieved Vector2.X should be equal to set value");
            Assert.AreEqual(0.4f, completedEventArgs.Vector2.Y, "Retrieved Vector2.Y should be equal to set value");
        }
    }
}
