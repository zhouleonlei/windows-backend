using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Xaml.XmlLineInfo Tests")]
    public class XmlLineInfoTests
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
        [Description("Test LineNumber. Check whether LineNumber is readable.")]
        [Property("SPEC", "Tizen.NUI.Xaml.XmlLineInfo.LineNumber A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void LineNumber_READ_ONLY()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test LinePosition. Check whether LinePosition is readable.")]
        [Property("SPEC", "Tizen.NUI.Xaml.XmlLineInfo.LinePosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void LinePosition_READ_ONLY()
        {
            /* TEST CODE */
        }


        [Test]
        [Category("P1")]
        [Description("Test Construct. Check XmlLineInfo construct.")]
        [Property("SPEC", "Tizen.NUI.Xaml.XmlLineInfo.XmlLineInfo C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Void")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void XmlLineInfo_INIT()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Construct. Check XmlLineInfo construct.")]
        [Property("SPEC", "Tizen.NUI.Xaml.XmlLineInfo.XmlLineInfo C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Int32, Int32")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void XmlLineInfo_INIT_WITH_INT32_INT32()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test HasLineInfo. Check HasLineInfo() of XmlLineInfo.")]
        [Property("SPEC", "Tizen.NUI.Xaml.XmlLineInfo.HasLineInfo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void HasLineInfo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }


    }
}
