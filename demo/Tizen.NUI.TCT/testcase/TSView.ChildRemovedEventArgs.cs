using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.View.ChildRemovedEventArgs Tests")]
    public class ChildRemovedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ChildRemovedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a ChildRemovedEventArgs object. Check whether ChildRemovedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ChildRemovedEventArgs.ChildRemovedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void ChildRemovedEventArgs_INIT()
        {
            /* TEST CODE */
            var childRemovedEventArgs = new View.ChildRemovedEventArgs();
            Assert.IsNotNull(childRemovedEventArgs, "Can't create success object ChildRemovedEventArgs");
            Assert.IsInstanceOf<View.ChildRemovedEventArgs>(childRemovedEventArgs, "Should be an instance of ChildRemovedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Removed. Check whether Removed is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ChildRemovedEventArgs.Removed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void Removed_SET_GET_VALUE()
        {
            /* TEST CODE */
            View.ChildRemovedEventArgs childRemovedEventArgs = new View.ChildRemovedEventArgs();
            View view = new View();
            childRemovedEventArgs.Removed = view;
            Assert.AreEqual(view, childRemovedEventArgs.Removed, "Removed View should be equal to set value");
        }

    }
}
