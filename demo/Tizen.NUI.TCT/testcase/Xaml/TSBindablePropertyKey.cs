using NUnit.Framework;
using Tizen.NUI.Binding;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.BindablePropertyKey Tests")]
    public class BindablePropertyKeyTests
    {
        private class TestBindablePropertyKey
        {
            public static readonly BindablePropertyKey BehaviorsPropertyKey = BindableProperty.CreateReadOnly("TestProperty", typeof(int), typeof(TestBindablePropertyKey), default(int));

            private int TestProperty
            {
                get
                {
                    return 100;
                }
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
        [Description("Test BindableProperty. Check whether BindableProperty is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindablePropertyKey.BindableProperty A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void BindableProperty_READ_ONLY()
        {
            /* TEST CODE */
            BindableProperty bindableProperty = TestBindablePropertyKey.BehaviorsPropertyKey.BindableProperty;
            Assert.IsTrue(bindableProperty.PropertyName == "TestProperty");
        }
    }
}
