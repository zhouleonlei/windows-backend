using NUnit.Framework;
using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.BindableProperty Tests")]
    public class BindablePropertyTests
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
        [Description("Test DeclaringType. Check whether DeclaringType is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableProperty.DeclaringType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void DeclaringType_READ_ONLY()
        {
            /* TEST CODE */
            BindableProperty bindableProperty = BindableProperty.Create("Tizen", typeof(string), typeof(string), "TizenNew", BindingMode.Default, null, null,
                null, null, null);
            Assert.IsInstanceOf<Type>(bindableProperty.DeclaringType, "Should be instance of Type.");
            Assert.AreEqual(bindableProperty.DeclaringType, typeof(string), "Not returning expected type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test DefaultBindingMode. Check whether DefaultBindingMode is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableProperty.DefaultBindingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void DefaultBindingMode_READ_ONLY()
        {
            /* TEST CODE */
            BindableProperty bindableProperty = BindableProperty.Create("Tizen", typeof(string), typeof(string), "TizenNew", BindingMode.TwoWay, null, null,
                null, null, null);
            Assert.IsInstanceOf<BindingMode>(bindableProperty.DefaultBindingMode, "Should be instance of BindingMode.");
            Assert.AreEqual(bindableProperty.DefaultBindingMode, BindingMode.TwoWay, "Not returning expected Value.");
        }

        [Test]
        [Category("P1")]
        [Description("Test DefaultValue. Check whether DefaultValue is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableProperty.DefaultValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void DefaultValue_READ_ONLY()
        {
            /* TEST CODE */
            BindableProperty bindableProperty = BindableProperty.Create("Tizen", typeof(string), typeof(string), "TizenNew", BindingMode.TwoWay, null, null,
                null, null, null);
            Assert.IsInstanceOf<Object>(bindableProperty.DefaultValue, "Should be instance of Object.");
            Assert.AreEqual(bindableProperty.DefaultValue, "TizenNew", "Not returning expected Value.");
        }

        [Test]
        [Category("P1")]
        [Description("Test IsReadOnly. Check whether IsReadOnly is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableProperty.IsReadOnly A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void IsReadOnly_READ_ONLY()
        {
            /* TEST CODE */
            BindableProperty bindableProperty = BindableProperty.Create("Tizen", typeof(string), typeof(string), "TizenNew", BindingMode.TwoWay, null, null,
                null, null, null);
            Assert.IsInstanceOf<Boolean>(bindableProperty.IsReadOnly, "Should be instance of Boolean.");
            Assert.IsFalse(bindableProperty.IsReadOnly, "BindableProperty should not be readonly.");
        }

        [Test]
        [Category("P1")]
        [Description("Test PropertyName. Check whether PropertyName is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableProperty.PropertyName A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void PropertyName_READ_ONLY()
        {
            /* TEST CODE */
            BindableProperty bindableProperty = BindableProperty.Create("Tizen", typeof(string), typeof(string), "TizenNew", BindingMode.TwoWay, null, null,
                 null, null, null);
            Assert.IsInstanceOf<String>(bindableProperty.PropertyName, "Should be instance of String.");
            Assert.AreEqual(bindableProperty.PropertyName, "Tizen", "Not returning proper value.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ReturnType. Check whether ReturnType is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableProperty.ReturnType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ReturnType_READ_ONLY()
        {
            /* TEST CODE */
            BindableProperty bindableProperty = BindableProperty.Create("Tizen", typeof(string), typeof(string), "TizenNew", BindingMode.TwoWay, null, null,
                 null, null, null);
            Assert.IsInstanceOf<Type>(bindableProperty.ReturnType, "Should be instance of Type.");
            Assert.AreEqual(bindableProperty.ReturnType, typeof(string), "Not returning proper Value.");
        }


        [Test]
        [Category("P1")]
        [Description("Test Create. Check Create() of BindableProperty.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableProperty.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Create_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var bindableProperty = BindableProperty.Create("Tizen", typeof(string), typeof(string), "TizenNew", BindingMode.TwoWay, null, null,
                 null, null, null);
            Assert.IsNotNull(bindableProperty, "Instance is null");
            Assert.IsInstanceOf<BindableProperty>(bindableProperty, "Should be instance of BindableProperty.");
        }

        [Test]
        [Category("P1")]
        [Description("Test CreateAttached. Check CreateAttached() of BindableProperty.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableProperty.CreateAttached M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void CreateAttached_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var bindableProperty = BindableProperty.CreateAttached("Tizen", typeof(string), typeof(string), "TizenNew");
            Assert.IsNotNull(bindableProperty, "BindableProperty instance is null");
            Assert.IsInstanceOf<BindableProperty>(bindableProperty, "Should be instance of BindableProperty.");
        }

        [Test]
        [Category("P1")]
        [Description("Test CreateAttachedReadOnly. Check CreateAttachedReadOnly() of BindableProperty.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableProperty.CreateAttachedReadOnly M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void CreateAttachedReadOnly_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var bindablePropertyKey = BindableProperty.CreateAttachedReadOnly("Tizen", typeof(string), typeof(string), "TizenNew", BindingMode.TwoWay);
            Assert.IsNotNull(bindablePropertyKey, "BindableProperty instance is null");
            Assert.IsInstanceOf<BindablePropertyKey>(bindablePropertyKey, "Should be instance of BindableProperty.");
        }

        [Test]
        [Category("P1")]
        [Description("Test CreateReadOnly. Check CreateReadOnly() of BindableProperty.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableProperty.CreateReadOnly M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void CreateReadOnly_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var bindableProperty = BindableProperty.CreateReadOnly("Tizen", typeof(string), typeof(string), "TizenNew", BindingMode.TwoWay);
            Assert.IsNotNull(bindableProperty, "BindableProperty instance is null");
            Assert.IsInstanceOf<BindablePropertyKey>(bindableProperty, "Should be instance of BindableProperty.");
        }
    }
}
