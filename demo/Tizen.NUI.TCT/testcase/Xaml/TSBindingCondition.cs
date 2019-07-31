using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.BindingCondition Tests")]
    public class BindingConditionTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Setup()
        {
            Tizen.Log.Info(TAG, "BindablePropertyTests-------------- - Setup()");
        }

        [TearDown]
        public void TearDown()
        {
            Tizen.Log.Info(TAG, "BindablePropertyTests-------------- - TearDown()");
        }

        [Test]
        [Category("P1")]
        [Description("Test Binding. Check whether Binding is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingCondition.Binding A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Binding_SET_GET_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Value. Check whether Value is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingCondition.Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Value_SET_GET_VALUE()
        {
            /* TEST CODE */
        }


        [Test]
        [Category("P1")]
        [Description("Test Construct. Check BindingCondition construct.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingCondition.BindingCondition C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void BindingCondition_INIT()
        {
            /* TEST CODE */
        }


    }
}
