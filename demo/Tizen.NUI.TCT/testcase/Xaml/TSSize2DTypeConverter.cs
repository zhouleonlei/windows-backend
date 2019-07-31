using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.Size2DTypeConverter Tests")]
    public class Size2DTypeConverterTests
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
        [Description("Test ConvertFromInvariantString. Check ConvertFromInvariantString() of Size2DTypeConverter.")]
        [Property("SPEC", "Tizen.NUI.Binding.Size2DTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ConvertFromInvariantString_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Construct. Check Size2DTypeConverter construct.")]
        [Property("SPEC", "Tizen.NUI.Binding.Size2DTypeConverter.Size2DTypeConverter C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Size2DTypeConverter_INIT()
        {
            /* TEST CODE */
        }


    }
}
