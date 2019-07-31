using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.TypeConverter Tests")]
    public class TypeConverterTests
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
        [Description("Test CanConvertFrom. Check CanConvertFrom() of TypeConverter.")]
        [Property("SPEC", "Tizen.NUI.Binding.TypeConverter.CanConvertFrom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void CanConvertFrom_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test ConvertFromInvariantString. Check ConvertFromInvariantString() of TypeConverter.")]
        [Property("SPEC", "Tizen.NUI.Binding.TypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ConvertFromInvariantString_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }


    }
}
