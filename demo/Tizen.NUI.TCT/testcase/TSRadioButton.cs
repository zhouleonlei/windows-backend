using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.UIComponents.RadioButton Tests")]
    public class RadioButtonTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "#################### Init() is called!");
            App.MainTitleChangeText("RadioButtonTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "#################### Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a RadioButton object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.RadioButton.RadioButton C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void RadioButton_INIT()
        {
            /* TEST CODE */
            var radioButton = new RadioButton();
            Assert.IsTrue(radioButton != null, "Can't create success object RadioButton");
            Assert.IsInstanceOf<RadioButton>(radioButton, "Should be an instance of RadioButton type.");
        }

        [Test]
        [Category("P1")]
        [Description("Create a RadioButton object. Check whether RadioButtonButton object which set LabelText is successfully created or not")]
        [Property("SPEC", "Tizen.NUI.UIComponents.RadioButton.RadioButton C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "string")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void RadioButton_INIT_WITH_STRING()
        {
            /* TEST CODE */
            var radioButton = new RadioButton("test");
            Assert.IsNotNull(radioButton, "Can't create success object RadioButton");
            Assert.IsInstanceOf<RadioButton>(radioButton, "Should be an instance of RadioButton type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the RadioButton.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.RadioButton.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            try
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Dispose();
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
