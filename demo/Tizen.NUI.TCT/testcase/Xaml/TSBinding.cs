using NUnit.Framework;
using Tizen.NUI.Test;
using Tizen.NUI.Binding;
using System;
using System.Globalization;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.Binding Tests")]
    public class BindingTests
    {
        private class FloatToRotationConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return new Rotation(new Radian(new Degree((float)value)), Vector3.ZAxis);
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                //return (bool)value ? 1 : 0;
                return null;
            }
        }

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
            Binding.Binding binding = new Binding.Binding();
            binding.Converter = new FloatToRotationConverter();

            Assert.IsTrue(binding.Converter.GetType() == typeof(FloatToRotationConverter));
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
            Binding.Binding binding = new Binding.Binding();
            binding.ConverterParameter = 123;

            Assert.IsTrue(123 == (int)binding.ConverterParameter);
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
            Binding.Binding binding = new Binding.Binding();
            binding.Path = "Size2D";

            Assert.IsTrue("Size2D" == binding.Path);
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
            View view = new View();
            Binding.Binding binding = new Binding.Binding();
            binding.Source = view;

            Assert.IsTrue(binding.Source.GetHashCode() == view.GetHashCode());

            view?.Dispose();
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
            Binding.Binding binding = new Binding.Binding();
            binding.UpdateSourceEventName = "UpdateSourceEvent";

            Assert.IsTrue("UpdateSourceEvent" == binding.UpdateSourceEventName);
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
            Binding.Binding binding = new Binding.Binding();
            Assert.IsNotNull(binding);
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
            Binding.Binding binding = new Binding.Binding("Size2D");
            Assert.IsNotNull(binding);
        }
    }
}
