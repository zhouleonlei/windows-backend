using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.Scrollable.Property Tests")]
    public class ScrollablePropertyTests
    {
        private string TAG = "NUI";
        //private static int CONTROL_PROPERTY_START_INDEX = 10000000;
        //private static int CONTROL_PROPERTY_END_INDEX = CONTROL_PROPERTY_START_INDEX + 1000;
        //private static int PROPERTY_START_INDEX = CONTROL_PROPERTY_END_INDEX + 1;
        private static int PROPERTY_START_INDEX = 10000000 + 1000 + 1;


        private static int ANIMATABLE_PROPERTY_START_INDEX = 20000000;

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ScrollablePropertyTests");
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
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.Property.Property C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Property_INIT()
        {
            /* TEST CODE */
            var property = new Scrollable.Property();
            Assert.IsNotNull(property, "Can't create success object Property");
            Assert.IsInstanceOf<Scrollable.Property>(property, "Should be an instance of Property type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test OVERSHOOT_EFFECT_COLOR. Check whether OVERSHOOT_EFFECT_COLOR returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.Property.OVERSHOOT_EFFECT_COLOR A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void OVERSHOOT_EFFECT_COLOR_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(PROPERTY_START_INDEX, Scrollable.Property.OVERSHOOT_EFFECT_COLOR, "OVERSHOOT_EFFECT_COLOR shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test OVERSHOOT_ANIMATION_SPEED. Check whether OVERSHOOT_ANIMATION_SPEED returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.Property.OVERSHOOT_ANIMATION_SPEED A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void OVERSHOOT_ANIMATION_SPEED_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(PROPERTY_START_INDEX + 1, Scrollable.Property.OVERSHOOT_ANIMATION_SPEED, "OVERSHOOT_ANIMATION_SPEED shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test OVERSHOOT_ENABLED. Check whether OVERSHOOT_ENABLED returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.Property.OVERSHOOT_ENABLED A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void OVERSHOOT_ENABLED_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(PROPERTY_START_INDEX + 2, Scrollable.Property.OVERSHOOT_ENABLED, "OVERSHOOT_ENABLED shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test OVERSHOOT_SIZE. Check whether OVERSHOOT_SIZE returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.Property.OVERSHOOT_SIZE A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void OVERSHOOT_SIZE_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(PROPERTY_START_INDEX + 3, Scrollable.Property.OVERSHOOT_SIZE, "OVERSHOOT_SIZE shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_TO_ALPHA_FUNCTION. Check whether SCROLL_TO_ALPHA_FUNCTION returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.Property.SCROLL_TO_ALPHA_FUNCTION A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_TO_ALPHA_FUNCTION_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(PROPERTY_START_INDEX + 4, Scrollable.Property.SCROLL_TO_ALPHA_FUNCTION, "SCROLL_TO_ALPHA_FUNCTION shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_RELATIVE_POSITION. Check whether SCROLL_RELATIVE_POSITION returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.Property.SCROLL_RELATIVE_POSITION A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_RELATIVE_POSITION_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX, Scrollable.Property.SCROLL_RELATIVE_POSITION, "SCROLL_RELATIVE_POSITION shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_POSITION_MIN. Check whether SCROLL_POSITION_MIN returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.Property.SCROLL_POSITION_MIN A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_POSITION_MIN_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 1, Scrollable.Property.SCROLL_POSITION_MIN, "SCROLL_POSITION_MIN shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_POSITION_MIN_X. Check whether SCROLL_POSITION_MIN_X returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.Property.SCROLL_POSITION_MIN_X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_POSITION_MIN_X_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 2, Scrollable.Property.SCROLL_POSITION_MIN_X, "SCROLL_POSITION_MIN_X shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_POSITION_MIN_Y. Check whether SCROLL_POSITION_MIN_Y returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.Property.SCROLL_POSITION_MIN_Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_POSITION_MIN_Y_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 3, Scrollable.Property.SCROLL_POSITION_MIN_Y, "SCROLL_POSITION_MIN_Y shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_POSITION_MAX. Check whether SCROLL_POSITION_MAX returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.Property.SCROLL_POSITION_MAX A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_POSITION_MAX_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 4, Scrollable.Property.SCROLL_POSITION_MAX, "SCROLL_POSITION_MAX shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_POSITION_MAX_X. Check whether SCROLL_POSITION_MAX_X returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.Property.SCROLL_POSITION_MAX_X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_POSITION_MAX_X_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 5, Scrollable.Property.SCROLL_POSITION_MAX_X, "SCROLL_POSITION_MAX_X shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SCROLL_POSITION_MAX_Y. Check whether SCROLL_POSITION_MAX_Y returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.Property.SCROLL_POSITION_MAX_Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SCROLL_POSITION_MAX_Y_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 6, Scrollable.Property.SCROLL_POSITION_MAX_Y, "SCROLL_POSITION_MAX_Y shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test CAN_SCROLL_VERTICAL. Check whether CAN_SCROLL_VERTICAL returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.Property.CAN_SCROLL_VERTICAL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void CAN_SCROLL_VERTICAL_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 7, Scrollable.Property.CAN_SCROLL_VERTICAL, "CAN_SCROLL_VERTICAL shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test CAN_SCROLL_HORIZONTAL. Check whether CAN_SCROLL_HORIZONTAL returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.Property.CAN_SCROLL_HORIZONTAL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void CAN_SCROLL_HORIZONTAL_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(ANIMATABLE_PROPERTY_START_INDEX + 8, Scrollable.Property.CAN_SCROLL_HORIZONTAL, "CAN_SCROLL_HORIZONTAL shold be equals to the set value");
        }
    }
}
