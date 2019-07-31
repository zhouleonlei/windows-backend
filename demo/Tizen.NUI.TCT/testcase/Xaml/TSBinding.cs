using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.Binding Tests")]
    public class BindingTests
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
        [Description("Test Converter. Check whether Converter is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.Binding.Converter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Converter_SET_GET_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test ConverterParameter. Check whether ConverterParameter is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.Binding.ConverterParameter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ConverterParameter_SET_GET_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Path. Check whether Path is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.Binding.Path A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Path_SET_GET_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Source. Check whether Source is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.Binding.Source A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Source_SET_GET_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test UpdateSourceEventName. Check whether UpdateSourceEventName is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.Binding.UpdateSourceEventName A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void UpdateSourceEventName_SET_GET_VALUE()
        {
            /* TEST CODE */
        }


        [Test]
        [Category("P1")]
        [Description("Test Construct. Check Binding construct.")]
        [Property("SPEC", "Tizen.NUI.Binding.Binding.Binding C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Void")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Binding_INIT()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Construct. Check Binding construct.")]
        [Property("SPEC", "Tizen.NUI.Binding.Binding.Binding C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "String, BindingMode, IValueConverter, Object, String, Object")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Binding_INIT_WITH_STRING_BINDINGMODE_IVALUECONVERTER_OBJECT_STRING_OBJECT()
        {
            /* TEST CODE */
        }


    }
}
