using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.TriggerAction Tests")]
    public class TriggerActionTests
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
        [Description("Test AssociatedType. Check whether AssociatedType is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.TriggerAction.AssociatedType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void AssociatedType_READ_ONLY()
        {
            /* TEST CODE */
        }


        [Test]
        [Category("P1")]
        [Description("Test Invoke. Check Invoke() of TriggerAction.")]
        [Property("SPEC", "Tizen.NUI.Binding.TriggerAction.Invoke M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Invoke_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }


    }
}
