using NUnit.Framework;
using Tizen.NUI;
using System;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.Radian Tests")]
    public class RadianTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("RadianTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali Radian constructor test")]
        [Property("SPEC", "Tizen.NUI.Radian.Radian C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Radian_INIT_WITH_NULL()
        {
            /* TEST CODE */
            Radian radian = new Radian();
            Assert.IsInstanceOf<Radian>(radian, "Should return Radian instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali Radian constructor with float parameter test")]
        [Property("SPEC", "Tizen.NUI.Radian.Radian C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Single")]
        public void Radian_INIT_WITH_FLOAT()
        {
            /* TEST CODE */
            var radiannew = new Radian(10.0f);
            Assert.IsInstanceOf<Radian>(radiannew, "Should return Radian instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali Radian constructor with Degree parameter test")]
        [Property("SPEC", "Tizen.NUI.Radian.Radian C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Degree")]
        public void Radian_INIT_WITH_DEGREE()
        {
            /* TEST CODE */
            Degree degree = new Degree();
            var radiannew = new Radian(degree);
            Assert.IsInstanceOf<Radian>(radiannew, "Should return Radian instance.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ConvertToFloat. Check whether ConvertToFloat returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Radian.ConvertToFloat M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void ConvertToFloat_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Radian radiannew = new Radian(10.0f);
            float value = radiannew.ConvertToFloat();
            Assert.AreEqual(10.0f, value, "ConvertToFloat function does not work, return error value");
        }

        [Test]
        [Category("P1")]
        [Description("Test radian. Check whether radian is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Radian.Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Value_SET_GET_VALUE()
        {
            /* TEST CODE */
            Radian radiannew = new Radian(10.0f);
            radiannew.Value = 30.0f;
            Assert.AreEqual(30.0f, radiannew.Value, "radian function does not work, return error value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Radian.")]
        [Property("SPEC", "Tizen.NUI.Radian.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                Radian radiannew = new Radian(10.0f);
                radiannew.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
    }
}