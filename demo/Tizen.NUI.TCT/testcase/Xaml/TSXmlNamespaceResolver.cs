using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Xaml.XmlNamespaceResolver Tests")]
    public class XmlNamespaceResolverTests
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
        [Description("Test GetNamespacesInScope. Check GetNamespacesInScope() of XmlNamespaceResolver.")]
        [Property("SPEC", "Tizen.NUI.Xaml.XmlNamespaceResolver.GetNamespacesInScope M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void GetNamespacesInScope_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test LookupNamespace. Check LookupNamespace() of XmlNamespaceResolver.")]
        [Property("SPEC", "Tizen.NUI.Xaml.XmlNamespaceResolver.LookupNamespace M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void LookupNamespace_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test LookupPrefix. Check LookupPrefix() of XmlNamespaceResolver.")]
        [Property("SPEC", "Tizen.NUI.Xaml.XmlNamespaceResolver.LookupPrefix M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void LookupPrefix_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Add. Check Add() of XmlNamespaceResolver.")]
        [Property("SPEC", "Tizen.NUI.Xaml.XmlNamespaceResolver.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Add_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Construct. Check XmlNamespaceResolver construct.")]
        [Property("SPEC", "Tizen.NUI.Xaml.XmlNamespaceResolver.XmlNamespaceResolver C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void XmlNamespaceResolver_INIT()
        {
            /* TEST CODE */
        }


    }
}
