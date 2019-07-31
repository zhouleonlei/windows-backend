using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.FlexContainer.ChildProperty Tests")]
    public class FlexContainerChildPropertyTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("FlexContainerChildPropertyTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a ChildProperty object. Check whether ChildProperty is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.FlexContainer.ChildProperty.ChildProperty C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ChildProperty_INIT()
        {
            /* TEST CODE */
            var childProperty = new FlexContainer.ChildProperty();
            Assert.IsNotNull(childProperty, "Can't create success object ChildProperty");
            Assert.IsInstanceOf<FlexContainer.ChildProperty>(childProperty, "Should be an instance of ChildProperty type.");
        }
    }
}
