using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.ColorTypeConverter Tests")]
    public class ColorTypeConverterTests
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
        [Description("Test ConvertFromInvariantString. Check ConvertFromInvariantString() of ColorTypeConverter.")]
        [Property("SPEC", "Tizen.NUI.Binding.ColorTypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ConvertFromInvariantString_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test FromRgba. Check FromRgba() of ColorTypeConverter.")]
        [Property("SPEC", "Tizen.NUI.Binding.ColorTypeConverter.FromRgba M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void FromRgba_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test FromRgb. Check FromRgb() of ColorTypeConverter.")]
        [Property("SPEC", "Tizen.NUI.Binding.ColorTypeConverter.FromRgb M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void FromRgb_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Construct. Check ColorTypeConverter construct.")]
        [Property("SPEC", "Tizen.NUI.Binding.ColorTypeConverter.ColorTypeConverter C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ColorTypeConverter_INIT()
        {
            /* TEST CODE */
        }


    }
}
