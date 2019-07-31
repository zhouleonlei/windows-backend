using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.UIComponents.ScrollBar.ScrollIntervalEventArgs Tests")]
    public class ScrollIntervalEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ScrollIntervalEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a ScrollIntervalEventArgs object. Check whether ScrollIntervalEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ScrollBar.ScrollIntervalEventArgs.ScrollIntervalEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ScrollIntervalEventArgs_INIT()
        {
            /* TEST CODE */
            var scrollIntervalEventArgs = new ScrollBar.ScrollIntervalEventArgs();
            Assert.IsNotNull(scrollIntervalEventArgs, "Can't create success object ScrollIntervalEventArgs");
            Assert.IsInstanceOf<ScrollBar.ScrollIntervalEventArgs>(scrollIntervalEventArgs, "Should be an instance of ScrollIntervalEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test CurrentScrollPosition. Check whether CurrentScrollPosition is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ScrollBar.ScrollIntervalEventArgs.CurrentScrollPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void CurrentScrollPosition_SET_GET_VALUE()
        {
            /* TEST CODE */
            ScrollBar.ScrollIntervalEventArgs scrollIntervalEventArgs = new ScrollBar.ScrollIntervalEventArgs();
            scrollIntervalEventArgs.CurrentScrollPosition = 1.0f;
            Assert.AreEqual(1.0f, scrollIntervalEventArgs.CurrentScrollPosition, "Retrieved CurrentScrollPosition should be equal to set value");
        }
    }
}
