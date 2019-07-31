using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.ScrollView.Property Tests")]
    public class ScrollViewPropertyTests
    {
        private string TAG = "NUI";
        private static int PROPERTY_START_INDEX = 10000000 + 1000 + 1 + 1000 + 1;

        private static int ANIMATABLE_PROPERTY_START_INDEX = 20000000 + 1000 + 1;

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ScrollViewPropertyTests");
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
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.Property C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Property_INIT()
        {
            /* TEST CODE */
            var property = new ScrollView.Property();
            Assert.IsNotNull(property, "Can't create success object Property");
            Assert.IsInstanceOf<ScrollView.Property>(property, "Should be an instance of Property type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test WRAP_ENABLED. Check whether WRAP_ENABLED returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.WRAP_ENABLED A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void WRAP_ENABLED_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(PROPERTY_START_INDEX, ScrollView.Property.WRAP_ENABLED, "WRAP_ENABLED shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test PANNING_ENABLED. Check whether PANNING_ENABLED returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.PANNING_ENABLED A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PANNING_ENABLED_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(PROPERTY_START_INDEX + 1, ScrollView.Property.PANNING_ENABLED, "PANNING_ENABLED shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test AXIS_AUTO_LOCK_ENABLED. Check whether AXIS_AUTO_LOCK_ENABLED returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.AXIS_AUTO_LOCK_ENABLED A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AXIS_AUTO_LOCK_ENABLED_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(PROPERTY_START_INDEX + 2, ScrollView.Property.AXIS_AUTO_LOCK_ENABLED, "AXIS_AUTO_LOCK_ENABLED shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test WHEEL_SCROLL_DISTANCE_STEP. Check whether WHEEL_SCROLL_DISTANCE_STEP returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.WHEEL_SCROLL_DISTANCE_STEP A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void WHEEL_SCROLL_DISTANCE_STEP_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(PROPERTY_START_INDEX + 3, ScrollView.Property.WHEEL_SCROLL_DISTANCE_STEP, "WHEEL_SCROLL_DISTANCE_STEP shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_MODE. Check whether SCROLL_MODE returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.SCROLL_MODE A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_MODE_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(PROPERTY_START_INDEX + 4, ScrollView.Property.SCROLL_MODE, "SCROLL_MODE shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_POSITION. Check whether SCROLL_POSITION returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.SCROLL_POSITION A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_POSITION_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX, ScrollView.Property.SCROLL_POSITION, "SCROLL_POSITION shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_PRE_POSITION. Check whether SCROLL_PRE_POSITION returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.SCROLL_PRE_POSITION A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_PRE_POSITION_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 1, ScrollView.Property.SCROLL_PRE_POSITION, "SCROLL_PRE_POSITION shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_PRE_POSITION_X. Check whether SCROLL_PRE_POSITION_X returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.SCROLL_PRE_POSITION_X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_PRE_POSITION_X_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 2, ScrollView.Property.SCROLL_PRE_POSITION_X, "SCROLL_PRE_POSITION_X shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_PRE_POSITION_Y. Check whether SCROLL_PRE_POSITION_Y returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.SCROLL_PRE_POSITION_Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_PRE_POSITION_Y_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 3, ScrollView.Property.SCROLL_PRE_POSITION_Y, "SCROLL_PRE_POSITION_Y shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_PRE_POSITION_MAX. Check whether SCROLL_PRE_POSITION_MAX returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.SCROLL_PRE_POSITION_MAX A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_PRE_POSITION_MAX_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 4, ScrollView.Property.SCROLL_PRE_POSITION_MAX, "SCROLL_PRE_POSITION_MAX shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_PRE_POSITION_MAX_X. Check whether SCROLL_PRE_POSITION_MAX_X returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.SCROLL_PRE_POSITION_MAX_X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_PRE_POSITION_MAX_X_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 5, ScrollView.Property.SCROLL_PRE_POSITION_MAX_X, "SCROLL_PRE_POSITION_MAX_X shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_PRE_POSITION_MAX_Y. Check whether SCROLL_PRE_POSITION_MAX_Y returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.SCROLL_PRE_POSITION_MAX_Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_PRE_POSITION_MAX_Y_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 6, ScrollView.Property.SCROLL_PRE_POSITION_MAX_Y, "SCROLL_PRE_POSITION_MAX_Y shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test OVERSHOOT_X. Check whether OVERSHOOT_X returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.OVERSHOOT_X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void OVERSHOOT_X_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 7, ScrollView.Property.OVERSHOOT_X, "OVERSHOOT_X shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test OVERSHOOT_Y. Check whether OVERSHOOT_Y returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.OVERSHOOT_Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void OVERSHOOT_Y_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 8, ScrollView.Property.OVERSHOOT_Y, "OVERSHOOT_Y shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_FINAL. Check whether SCROLL_FINAL returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.SCROLL_FINAL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_FINAL_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 9, ScrollView.Property.SCROLL_FINAL, "SCROLL_FINAL shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_FINAL_X. Check whether SCROLL_FINAL_X returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.SCROLL_FINAL_X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_FINAL_X_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 10, ScrollView.Property.SCROLL_FINAL_X, "SCROLL_FINAL_X shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_FINAL_Y. Check whether SCROLL_FINAL_Y returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.SCROLL_FINAL_Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_FINAL_Y_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 11, ScrollView.Property.SCROLL_FINAL_Y, "SCROLL_FINAL_Y shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test WRAP. Check whether WRAP returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.WRAP A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void WRAP_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 12, ScrollView.Property.WRAP, "WRAP shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test PANNING. Check whether PANNING returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.PANNING A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PANNING_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 13, ScrollView.Property.PANNING, "PANNING shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLLING. Check whether SCROLLING returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.SCROLLING A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLLING_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 14, ScrollView.Property.SCROLLING, "SCROLLING shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_DOMAIN_SIZE. Check whether SCROLL_DOMAIN_SIZE returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.SCROLL_DOMAIN_SIZE A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_DOMAIN_SIZE_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 15, ScrollView.Property.SCROLL_DOMAIN_SIZE, "SCROLL_DOMAIN_SIZE shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_DOMAIN_SIZE_X. Check whether SCROLL_DOMAIN_SIZE_X returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.SCROLL_DOMAIN_SIZE_X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_DOMAIN_SIZE_X_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 16, ScrollView.Property.SCROLL_DOMAIN_SIZE_X, "SCROLL_DOMAIN_SIZE_X shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_DOMAIN_SIZE_Y. Check whether SCROLL_DOMAIN_SIZE_Y returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.SCROLL_DOMAIN_SIZE_Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_DOMAIN_SIZE_Y_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 17, ScrollView.Property.SCROLL_DOMAIN_SIZE_Y, "SCROLL_DOMAIN_SIZE_Y shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_DOMAIN_OFFSET. Check whether SCROLL_DOMAIN_OFFSET returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.SCROLL_DOMAIN_OFFSET A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_DOMAIN_OFFSET_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 18, ScrollView.Property.SCROLL_DOMAIN_OFFSET, "SCROLL_DOMAIN_OFFSET shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_POSITION_DELTA. Check whether SCROLL_POSITION_DELTA returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.SCROLL_POSITION_DELTA A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_POSITION_DELTA_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 19, ScrollView.Property.SCROLL_POSITION_DELTA, "SCROLL_POSITION_DELTA shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test START_PAGE_POSITION. Check whether START_PAGE_POSITION returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Property.START_PAGE_POSITION A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void START_PAGE_POSITION_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 20, ScrollView.Property.START_PAGE_POSITION, "START_PAGE_POSITION shold be equals to the set value");
        }
    }
}
