using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.SizeTypeConverter Tests")]
    public class SizeTypeConverterTests
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
        [Description("Test ConvertFromInvariantString. Check ConvertFromInvariantString() of SizeTypeConverter.")]
        [Property("SPEC", "Tizen.NUI.Binding.SizeTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ConvertFromInvariantString_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Construct. Check SizeTypeConverter construct.")]
        [Property("SPEC", "Tizen.NUI.Binding.SizeTypeConverter.SizeTypeConverter C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void SizeTypeConverter_INIT()
        {
            /* TEST CODE */
        }


    }
}
