using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Xaml.TemplateBindingExtension Tests")]
    public class TemplateBindingExtensionTests
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
        [Description("Test Path. Check whether Path is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Xaml.TemplateBindingExtension.Path A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Path_SET_GET_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Mode. Check whether Mode is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Xaml.TemplateBindingExtension.Mode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Mode_SET_GET_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Converter. Check whether Converter is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Xaml.TemplateBindingExtension.Converter A")]
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
        [Property("SPEC", "Tizen.NUI.Xaml.TemplateBindingExtension.ConverterParameter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ConverterParameter_SET_GET_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test StringFormat. Check whether StringFormat is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Xaml.TemplateBindingExtension.StringFormat A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void StringFormat_SET_GET_VALUE()
        {
            /* TEST CODE */
        }



    }
}
