using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.View.ChildAddedEventArgs Tests")]
    public class ChildAddedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ChildAddedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a ChildAddedEventArgs object. Check whether ChildAddedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ChildAddedEventArgs.ChildAddedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void ChildAddedEventArgs_INIT()
        {
            /* TEST CODE */
            var childAddedEventArgs = new View.ChildAddedEventArgs();
            Assert.IsNotNull(childAddedEventArgs, "Can't create success object ChildAddedEventArgs");
            Assert.IsInstanceOf<View.ChildAddedEventArgs>(childAddedEventArgs, "Should be an instance of ChildAddedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Added. Check whether Added is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ChildAddedEventArgs.Added A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void Added_SET_GET_VALUE()
        {
            /* TEST CODE */
            View.ChildAddedEventArgs childAddedEventArgs = new View.ChildAddedEventArgs();
            View view = new View();
            childAddedEventArgs.Added = view;
            Assert.AreEqual(view, childAddedEventArgs.Added, "Added View should be equal to set value");
        }

    }
}
