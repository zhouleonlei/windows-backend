using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.NameScopeExtensions Tests")]
    public class NameScopeExtensionsTests
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
        [Description("Test FindByName. Check FindByName() of NameScopeExtensions.")]
        [Property("SPEC", "Tizen.NUI.Binding.NameScopeExtensions.FindByName<T> M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void FindByNameT_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test FindByNameInCurrentNameScope. Check FindByNameInCurrentNameScope() of NameScopeExtensions.")]
        [Property("SPEC", "Tizen.NUI.Binding.NameScopeExtensions.FindByNameInCurrentNameScope<T> M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void FindByNameInCurrentNameScopeT_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }


    }
}
