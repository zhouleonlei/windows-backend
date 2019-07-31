using NUnit.Framework;
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
        }


    }
}
