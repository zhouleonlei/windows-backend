using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.XamlPropertyCondition Tests")]
    public class XamlPropertyConditionTests
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
        [Description("Test Property. Check whether Property is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlPropertyCondition.Property A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Property_SET_GET_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Value. Check whether Value is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlPropertyCondition.Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Value_SET_GET_VALUE()
        {
            /* TEST CODE */
        }


        [Test]
        [Category("P1")]
        [Description("Test Construct. Check XamlPropertyCondition construct.")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlPropertyCondition.XamlPropertyCondition C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void XamlPropertyCondition_INIT()
        {
            /* TEST CODE */
        }


    }
}
