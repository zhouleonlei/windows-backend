using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Xaml.XmlLineInfoProvider Tests")]
    public class XmlLineInfoProviderTests
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
        [Description("Test XmlLineInfo. Check whether XmlLineInfo is readable.")]
        [Property("SPEC", "Tizen.NUI.Xaml.XmlLineInfoProvider.XmlLineInfo A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void XmlLineInfo_READ_ONLY()
        {
            /* TEST CODE */
        }


        [Test]
        [Category("P1")]
        [Description("Test Construct. Check XmlLineInfoProvider construct.")]
        [Property("SPEC", "Tizen.NUI.Xaml.XmlLineInfoProvider.XmlLineInfoProvider C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void XmlLineInfoProvider_INIT()
        {
            /* TEST CODE */
        }


    }
}
