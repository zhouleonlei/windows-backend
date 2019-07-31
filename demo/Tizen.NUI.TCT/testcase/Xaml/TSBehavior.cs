using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.Behavior Tests")]
    public class BehaviorTests
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
        [Property("SPEC", "Tizen.NUI.Binding.Behavior.AssociatedType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void AssociatedType_READ_ONLY()
        {
            /* TEST CODE */
        }


        [Test]
        [Category("P1")]
        [Description("Test OnAttachedTo. Check OnAttachedTo() of Behavior.")]
        [Property("SPEC", "Tizen.NUI.Binding.Behavior.OnAttachedTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void OnAttachedTo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test OnDetachingFrom. Check OnDetachingFrom() of Behavior.")]
        [Property("SPEC", "Tizen.NUI.Binding.Behavior.OnDetachingFrom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void OnDetachingFrom_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }


    }
}
