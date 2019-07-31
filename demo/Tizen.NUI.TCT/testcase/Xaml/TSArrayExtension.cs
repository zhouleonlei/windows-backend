using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Xaml.ArrayExtension Tests")]
    public class ArrayExtensionTests
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
        [Description("Test Items. Check whether Items is readable.")]
        [Property("SPEC", "Tizen.NUI.Xaml.ArrayExtension.Items A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Items_READ_ONLY()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Type. Check whether Type is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Xaml.ArrayExtension.Type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Type_SET_GET_VALUE()
        {
            /* TEST CODE */
        }


        [Test]
        [Category("P1")]
        [Description("Test Construct. Check ArrayExtension construct.")]
        [Property("SPEC", "Tizen.NUI.Xaml.ArrayExtension.ArrayExtension C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ArrayExtension_INIT()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test ProvideValue. Check ProvideValue() of ArrayExtension.")]
        [Property("SPEC", "Tizen.NUI.Xaml.ArrayExtension.ProvideValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ProvideValue_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }


    }
}
