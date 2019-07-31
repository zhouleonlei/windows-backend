using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.ToggleButton.Property Tests")]
    public class ToggleButtonPropertyTests
    {
        private string TAG = "NUI";
        private static int PROPERTY_START_INDEX = 10000000 + 1000 + 1 + 1000 + 1;

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ToggleButtonPropertyTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a Property object. Check whether Property is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.ToggleButton.Property.Property C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Property_INIT()
        {
            /* TEST CODE */
            var property = new ToggleButton.Property();
            Assert.IsNotNull(property, "Can't create success object Property");
            Assert.IsInstanceOf<ToggleButton.Property>(property, "Should be an instance of Property type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test STATE_VISUALS. Check whether STATE_VISUALS returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ToggleButton.Property.STATE_VISUALS A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void STATE_VISUALS_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(PROPERTY_START_INDEX, ToggleButton.Property.STATE_VISUALS, "STATE_VISUALS shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test TOOLTIPS. Check whether TOOLTIPS returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ToggleButton.Property.TOOLTIPS A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void TOOLTIPS_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(PROPERTY_START_INDEX + 1, ToggleButton.Property.TOOLTIPS, "TOOLTIPS shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test CURRENT_STATE_INDEX. Check whether CURRENT_STATE_INDEX returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ToggleButton.Property.CURRENT_STATE_INDEX A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void CURRENT_STATE_INDEX_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(PROPERTY_START_INDEX + 2, ToggleButton.Property.CURRENT_STATE_INDEX, "CURRENT_STATE_INDEX shold be equals to the set value");
        }
    }
}
