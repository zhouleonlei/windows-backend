using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;
using Tizen.NUI.UIComponents;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.UIComponents.CheckBoxButton Tests")]
    public class CheckBoxButtonTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, " Init() is called!");
            App.MainTitleChangeText("CheckBoxButtonTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, " Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a checkBoxButton object.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.CheckBoxButton.CheckBoxButton C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void CheckBoxButton_INIT()
        {
            /* TEST CODE */
            var checkBox = new CheckBoxButton();

            Assert.IsNotNull(checkBox, "Can't create success object CheckBoxButton");
            Assert.IsInstanceOf<CheckBoxButton>(checkBox, "Should be an instance of CheckBoxButton type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the CheckBoxButton.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.CheckBoxButton.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                CheckBoxButton CheckBoxButton = new CheckBoxButton();
                CheckBoxButton.Dispose();
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
