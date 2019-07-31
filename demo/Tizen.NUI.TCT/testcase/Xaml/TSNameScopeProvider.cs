using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Xaml.NameScopeProvider Tests")]
    public class NameScopeProviderTests
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
        [Description("Test NameScope. Check whether NameScope is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Xaml.NameScopeProvider.NameScope A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void NameScope_SET_GET_VALUE()
        {
            /* TEST CODE */
        }


        [Test]
        [Category("P1")]
        [Description("Test Construct. Check NameScopeProvider construct.")]
        [Property("SPEC", "Tizen.NUI.Xaml.NameScopeProvider.NameScopeProvider C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void NameScopeProvider_INIT()
        {
            /* TEST CODE */
        }


    }
}
