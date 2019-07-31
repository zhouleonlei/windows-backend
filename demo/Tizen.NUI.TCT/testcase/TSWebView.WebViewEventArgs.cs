using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.WebView.WebViewEventArgs Tests")]
    public class WebViewEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("WebViewEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
            Tizen.NUI.EnvironmentVariable.SetEnvironmentVariable("DALI_WEB_ENGINE_NAME", "lwe");
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a WebViewPageLoadEventArgs object. Check whether WebViewPageLoadEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.WebViewPageLoadEventArgs.WebViewPageLoadEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void WebViewPageLoadEventArgs_INIT()
        {
            /* TEST CODE */
            var webViewPageLoadEventArgs = new WebViewPageLoadEventArgs();
            Assert.IsNotNull(webViewPageLoadEventArgs, "Can't create success object WebViewPageLoadEventArgs");
            Assert.IsInstanceOf<WebViewPageLoadEventArgs>(webViewPageLoadEventArgs, "Should be an instance of WebViewPageLoadEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test WebView. Check whether WebView is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.WebViewPageLoadEventArgs.WebView A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void WebView_SET_GET_VALUE()
        {
            /* TEST CODE */
            var webViewEventArgs = new WebViewPageLoadEventArgs();
            WebView webView = new WebView();
            webViewEventArgs.WebView = webView;
            Assert.AreEqual(webView, webViewEventArgs.WebView, "Retrieved WebView should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test PageUrl. Check whether PageUrl is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.WebViewPageLoadEventArgs.PageUrl A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void PageUrl_SET_GET_VALUE()
        {
            /* TEST CODE */
            var webViewEventArgs = new WebViewPageLoadEventArgs();
            string webUrl = "www.samsung.com";
            webViewEventArgs.PageUrl = webUrl;
            Assert.AreEqual(webUrl, webViewEventArgs.PageUrl, "Retrieved PageUrl should be equal to set value");
        }
    }
}
