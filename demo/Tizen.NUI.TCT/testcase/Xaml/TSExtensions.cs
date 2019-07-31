using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Xaml.Extensions Tests")]
    public class ExtensionsTests
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
        [Description("Test LoadFromXaml. Check LoadFromXaml() of Extensions.")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXaml<TXaml> M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "TXaml, Type")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void LoadFromXamlTXaml_CHECK_RETURN_VALUE_WITH_TXAML_TYPE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test LoadFromXaml. Check LoadFromXaml() of Extensions.")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXaml<TXaml> M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "TXaml, String")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void LoadFromXamlTXaml_CHECK_RETURN_VALUE_WITH_TXAML_STRING()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test LoadObject. Check LoadObject() of Extensions.")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadObject<T> M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void LoadObjectT_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test LoadFromXamlFile. Check LoadFromXamlFile() of Extensions.")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXamlFile<TXaml> M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void LoadFromXamlFileTXaml_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }


    }
}
