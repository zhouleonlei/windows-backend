using NUnit.Framework;
using Tizen.NUI.Test;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.BindingBase Tests")]
    public class BindingBaseTests
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
        [Description("Test Mode. Check whether Mode is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingBase.Mode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Mode_SET_GET_VALUE()
        {
            /* TEST CODE */
            Binding.Binding binding = new Binding.Binding();
            binding.Mode = BindingMode.Default;
            Assert.IsTrue(binding.Mode == BindingMode.Default);
        }

        [Test]
        [Category("P1")]
        [Description("Test StringFormat. Check whether StringFormat is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingBase.StringFormat A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void StringFormat_SET_GET_VALUE()
        {
            /* TEST CODE */
            Binding.Binding binding = new Binding.Binding();
            binding.StringFormat = "Format";
            Assert.IsTrue(binding.StringFormat == "Format");
        }

        [Test]
        [Category("P1")]
        [Description("Test TargetNullValue. Check whether TargetNullValue is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingBase.TargetNullValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void TargetNullValue_SET_GET_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test FallbackValue. Check whether FallbackValue is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingBase.FallbackValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void FallbackValue_SET_GET_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test DisableCollectionSynchronization. Check DisableCollectionSynchronization() of BindingBase.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingBase.DisableCollectionSynchronization M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void DisableCollectionSynchronization_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test EnableCollectionSynchronization. Check EnableCollectionSynchronization() of BindingBase.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingBase.EnableCollectionSynchronization M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void EnableCollectionSynchronization_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test ThrowIfApplied. Check ThrowIfApplied() of BindingBase.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingBase.ThrowIfApplied M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ThrowIfApplied_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }
    }
}
