using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.ScrollViewEffect Tests")]
    public class ScrollViewEffectTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("Tests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a scrollViewEffectButton object.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollViewEffect.ScrollViewEffect C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ScrollViewEffect_INIT()
        {
            /* TEST CODE */
            var scrollViewEffect = new ScrollViewEffect();

            Assert.IsNotNull(scrollViewEffect, "Can't create success object ScrollViewEffect");
            Assert.IsInstanceOf<ScrollViewEffect>(scrollViewEffect, "Should be an instance of ScrollViewEffect type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the ScrollViewEffect.")]
        [Property("SPEC", "Tizen.NUI.ScrollViewEffect.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            try
            {
                ScrollViewEffect ScrollViewEffect = new ScrollViewEffect();
                ScrollViewEffect.Dispose();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
    }
}
