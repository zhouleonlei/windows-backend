using NUnit.Framework;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.BindablePropertyConverter Tests")]
    public class BindablePropertyConverterTests
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
        [Description("Test ConvertFromInvariantString. Check ConvertFromInvariantString() of BindablePropertyConverter.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindablePropertyConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ConvertFromInvariantString_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            BindablePropertyConverter bindablePropertyConverter = new BindablePropertyConverter();
            BindableProperty bindableProperty = bindablePropertyConverter.ConvertFromInvariantString("Tizen.NUI.BaseComponents.View.Size2D") as BindableProperty;

            Assert.IsTrue(bindableProperty.GetType() == View.Size2DProperty.GetType());
        }

        [Test]
        [Category("P1")]
        [Description("Test Construct. Check BindablePropertyConverter construct.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindablePropertyConverter.BindablePropertyConverter C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void BindablePropertyConverter_INIT()
        {
            /* TEST CODE */
            BindablePropertyConverter bindablePropertyConverter = new BindablePropertyConverter();
            Assert.IsNotNull(bindablePropertyConverter);
        }
    }
}
