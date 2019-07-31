using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.Scrollable.UpdatedEventArgs Tests")]
    public class ScrollablUpdatedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("UpdatedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a UpdatedEventArgs object. Check whether UpdatedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.UpdatedEventArgs.UpdatedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Youxia Wu, youxia17.wu@samsung.com")]
        public void UpdatedEventArgs_INIT()
        {
            /* TEST CODE */
            var updatedEventArgs = new Scrollable.UpdatedEventArgs();
            Assert.IsNotNull(updatedEventArgs, "Can't create success object updatedEventArgs");
            Assert.IsInstanceOf<Scrollable.UpdatedEventArgs>(updatedEventArgs, "Should be an instance of UpdatedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Vector2. Check whether Vector2 is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.UpdatedEventArgs.Vector2 A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Youxia Wu, youxia17.wu@samsung.com")]
        public void Vector2_SET_GET_VALUE()
        {
            /* TEST CODE */
            Scrollable.UpdatedEventArgs updatedEventArgs = new Scrollable.UpdatedEventArgs();
            updatedEventArgs.Vector2 = new Vector2(0.3f, 0.4f);
            Assert.AreEqual(0.3f, updatedEventArgs.Vector2.X, "Retrieved Vector2.X should be equal to set value");
            Assert.AreEqual(0.4f, updatedEventArgs.Vector2.Y, "Retrieved Vector2.Y should be equal to set value");
        }
    }
}
