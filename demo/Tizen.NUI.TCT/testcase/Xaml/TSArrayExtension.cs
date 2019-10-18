using NUnit.Framework;
using System;
using System.Collections;
using Tizen.NUI.Test;
using Tizen.NUI.Xaml;

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
            ArrayExtension arrayExtension = new ArrayExtension();
            Assert.IsNotNull(arrayExtension);
            Assert.IsInstanceOf<IList>(arrayExtension.Items, "Should be instance of IList");
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
            ArrayExtension arrayExtension = new ArrayExtension();
            Assert.IsNotNull(arrayExtension);

            arrayExtension.Type = typeof(string);
            Assert.IsInstanceOf<Type>(arrayExtension.Type, "Should be instance of Type");
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
            ArrayExtension arrayExtension = new ArrayExtension();
            Assert.IsNotNull(arrayExtension);
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
            ArrayExtension arrayExtension = new ArrayExtension();
            Assert.IsNotNull(arrayExtension);

            arrayExtension.Type = typeof(string);

            XamlServiceProvider xamlServiceProvider = new XamlServiceProvider();
            Assert.IsNotNull(xamlServiceProvider);

            Array array = arrayExtension.ProvideValue(xamlServiceProvider);
            Assert.IsNotNull(array);
            Assert.IsInstanceOf<Array>(array, "Should be instance of Array");
        }
    }
}
