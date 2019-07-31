using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

using Tizen;
using System.Runtime.InteropServices;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Constants;
using Tizen.Applications;
using System.Globalization;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.NUIApplication Tests")]
    public class NUIApplicationTests
    {

        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("NUIApplicationTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali NUIApplication constructor test. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.NUIApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void NUIApplication_INIT()
        {
            /* TEST CODE */
            var application = new NUIApplication();
            Assert.IsNotNull(application, "NUIApplication Should return Layer instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali NUIApplication constructor test. Check whether object  which set stylesheet is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.NUIApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "string")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void NUIApplication_INIT_WITH_STRING()
        {
            /* TEST CODE */
            var application = new NUIApplication("stylesheet");
            Assert.IsNotNull(application, "NUIApplication Should return NUIApplication instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali NUIApplication constructor test. Check whether object  which set stylesheet and WindowMode is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.NUIApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "string,WindowMode")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void NUIApplication_INIT_WITH_STRING_WINDOWMODE()
        {
            /* TEST CODE */
            var application = new NUIApplication("stylesheet", NUIApplication.WindowMode.Opaque);
            Assert.IsNotNull(application, "NUIApplication Should return NUIApplication instance.");
        }

        [Test]
        [Category("P1")]
        [Description("Test RegisterAssembly. Try to register assembly")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.RegisterAssembly M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Ge Wenfeng, wenfeng.ge@samsung.com")]
        public void RegisterAssembly_CHECK()
        {
            /* TEST CODE */
            try
            {
                NUIApplication.RegisterAssembly(typeof(NUIApplication).Assembly);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test MultilingualResourceManager. Check whether MultiliguaalResourceManager is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.NUIApplication.MultilingualResourceManager A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void MultilingualResourceManager_CHECK()
        {
            /* TEST CODE */
            NUIApplication.MultilingualResourceManager = Properties.Resource.ResourceManager;
            Assert.IsNotNull(NUIApplication.MultilingualResourceManager, "Should be not null!");

            string translatableText = null;
            translatableText = NUIApplication.MultilingualResourceManager?.GetString("COM_SID_PICTURE", new CultureInfo("af-ZA"));
            Assert.AreEqual("Beeld", translatableText, "Picture should be Beeld in Dutch");
        }


#if false // currently ACR is not yet proceed. temporarily blocked.
        //[Test]
        //[Category("P1")]
        //[Description("Test Dispose, try to dispose the NUIApplication.")]
        //[Property("SPEC", "Tizen.NUI.NUIApplication.Dispose M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR MCST")]
        //[Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                NUIApplication application = new NUIApplication();
                application.Dispose();
            }
            catch (Exception e)
            {
                Tizen.Log.Error("Test CellPosition.cs", "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
#endif
    }
}
