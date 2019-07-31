using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Xaml.XamlServiceProvider Tests")]
    public class XamlServiceProviderTests
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
        [Description("Test Construct. Check XamlServiceProvider construct.")]
        [Property("SPEC", "Tizen.NUI.Xaml.XamlServiceProvider.XamlServiceProvider C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void XamlServiceProvider_INIT()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test GetService. Check GetService() of XamlServiceProvider.")]
        [Property("SPEC", "Tizen.NUI.Xaml.XamlServiceProvider.GetService M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void GetService_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Add. Check Add() of XamlServiceProvider.")]
        [Property("SPEC", "Tizen.NUI.Xaml.XamlServiceProvider.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Add_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }


    }
}
