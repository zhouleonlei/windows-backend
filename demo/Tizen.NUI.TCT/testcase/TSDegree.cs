using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using System.Runtime.InteropServices;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.Degree Tests")]
    public class DegreeTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("DegreeTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali Degree constructor test")]
        [Property("SPEC", "Tizen.NUI.Degree.Degree C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Degree_INIT_WITH_NULL()
        {
            /* TEST CODE */
            var degree = new Degree();
            Assert.IsInstanceOf<Degree>(degree, "Should return Degree instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali Degree constructor with float parameter test")]
        [Property("SPEC", "Tizen.NUI.Degree.Degree C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Single")]
        public void Degree_INIT_WITH_FLOAT()
        {
            /* TEST CODE */
            var degreenew = new Degree(10.0f);
            Assert.IsInstanceOf<Degree>(degreenew, "Should return Degree instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali Degree constructor with Radian parameter test")]
        [Property("SPEC", "Tizen.NUI.Degree.Degree C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Radian")]
        public void Degree_INIT_WITH_RADIAN()
        {
            /* TEST CODE */
            Radian radian = new Radian(1.0f);
            Assert.IsInstanceOf<Radian>(radian, "Should return Radian instance.");
            var degree = new Degree(radian);
            Assert.IsInstanceOf<Degree>(degree, "Should return Degree instance.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Value. Check whether Value is readable and writable")]
        [Property("SPEC", "Tizen.NUI.Degree.Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Value_SET_GET_VALUE()
        {
            /* TEST CODE */
            Degree degree = new Degree(1.0f);
            Assert.AreEqual(1.0f, degree.Value, "Should be equal to 1.0f.");
            degree.Value = 2.0f;
            Assert.AreEqual(2.0f, degree.Value, "Should be equal to 2.0f.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Degree.")]
        [Property("SPEC", "Tizen.NUI.Degree.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                Degree degreenew = new Degree(10.0f);
                degreenew.Dispose();
            }
            catch (Exception e)
            {
                Tizen.Log.Error("Test CellPosition.cs", "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
    }
}