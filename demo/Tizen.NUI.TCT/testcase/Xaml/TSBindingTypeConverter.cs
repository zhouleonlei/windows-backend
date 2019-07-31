using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.BindingTypeConverter Tests")]
    public class BindingTypeConverterTests
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
        [Description("Test ConvertFromInvariantString. Check ConvertFromInvariantString() of BindingTypeConverter.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ConvertFromInvariantString_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Construct. Check BindingTypeConverter construct.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingTypeConverter.BindingTypeConverter C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void BindingTypeConverter_INIT()
        {
            /* TEST CODE */
        }


    }
}
