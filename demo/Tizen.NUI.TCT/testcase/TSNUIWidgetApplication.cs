using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;

namespace Tizen.NUI.Tests
{
    public class MyWidget : Widget
    {
        protected override void OnCreate(string contentInfo, Window window)
        {
            window.BackgroundColor = Color.White;
            TextLabel textLabel = new TextLabel("Widget Works");

            window.GetDefaultLayer().Add(textLabel);
            base.OnCreate(contentInfo, window);
        }
    }

    [TestFixture]
    [Description("Tizen.NUI.NUIWidgetApplication Tests")]
    public class NUIWidgetApplicationTests
    {
        private string TAG = "Tizen.NUI.NUIWidgetApplicationTests";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "#################### Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "#################### Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetApplication constructor test.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetApplication.NUIWidgetApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "System.type")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void NUIWidgetApplication_INIT()
        {
            /* TEST CODE */
            var widgetApplication = new NUIWidgetApplication(typeof(MyWidget));
            Assert.IsNotNull(widgetApplication, "NUIWidgetApplication can't create successfully.");
            Assert.IsInstanceOf<NUIWidgetApplication>(widgetApplication, "Should be an instance of NUIWidgetApplication type.");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetApplication constructor test. Check whether object  which set stylesheet is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetApplication.NUIWidgetApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "System.type, string")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@partner.samsung.com")]
        public void NUIWidgetApplication_INIT_WITH_STRING()
        {
            /* TEST CODE */
            var widgetApplication = new NUIWidgetApplication(typeof(MyWidget), "stylesheet");
            Assert.IsNotNull(widgetApplication, "NUIWidgetApplication can't create successfully.");
            Assert.IsInstanceOf<NUIWidgetApplication>(widgetApplication, "Should be an instance of NUIWidgetApplication type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Widget.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetApplication.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@partner.samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                NUIWidgetApplication widgetApplication = new NUIWidgetApplication(typeof(MyWidget));
                Assert.IsNotNull(widgetApplication, "NUIWidgetApplication can't create successfully.");
                widgetApplication.Dispose();
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
