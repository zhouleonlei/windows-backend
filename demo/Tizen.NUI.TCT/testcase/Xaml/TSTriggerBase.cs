using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.TriggerBase Tests")]
    public class TriggerBaseTests
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
        [Description("Test EnterActions. Check whether EnterActions is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.TriggerBase.EnterActions A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void EnterActions_READ_ONLY()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test ExitActions. Check whether ExitActions is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.TriggerBase.ExitActions A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ExitActions_READ_ONLY()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test IsSealed. Check whether IsSealed is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.TriggerBase.IsSealed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void IsSealed_READ_ONLY()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test TargetType. Check whether TargetType is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.TriggerBase.TargetType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void TargetType_READ_ONLY()
        {
            /* TEST CODE */
        }



    }
}
