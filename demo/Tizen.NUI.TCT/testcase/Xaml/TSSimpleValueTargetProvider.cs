using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Xaml.SimpleValueTargetProvider Tests")]
    public class SimpleValueTargetProviderTests
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
        [Description("Test Construct. Check SimpleValueTargetProvider construct.")]
        [Property("SPEC", "Tizen.NUI.Xaml.SimpleValueTargetProvider.SimpleValueTargetProvider C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void SimpleValueTargetProvider_INIT()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test FindByName. Check FindByName() of SimpleValueTargetProvider.")]
        [Property("SPEC", "Tizen.NUI.Xaml.SimpleValueTargetProvider.FindByName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void FindByName_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }


    }
}
