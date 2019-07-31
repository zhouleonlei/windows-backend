using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.PaddingType Tests")]
    public class PaddingTypeTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("PaddingTypeTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a paddingType object.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.PaddingType.PaddingType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PaddingType_INIT()
        {
            /* TEST CODE */
            var paddingType = new PaddingType();

            Assert.IsNotNull(paddingType, "Can't create success object PaddingType");
            Assert.IsInstanceOf<PaddingType>(paddingType, "Should be an instance of PaddingType type.");
        }

        [Test]
        [Category("P1")]
        [Description("Create a paddingType object.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.PaddingType.PaddingType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single, Single, Single, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PaddingType_INIT_WITH_VALUE()
        {
            /* TEST CODE */
            var paddingType = new PaddingType(0.0f, 0.0f, 0.0f, 0.0f);
            Assert.IsNotNull(paddingType, "Can't create success object PaddingType");
            Assert.IsInstanceOf<PaddingType>(paddingType, "Should be an instance of PaddingType type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Left, Check whether Left property is writable and readable.")]
        [Property("SPEC", "Tizen.NUI.PaddingType.Start A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Start_SET_GET_VALUE()
        {
            /* TEST CODE */
            var paddingType = new PaddingType();
            paddingType.Start = 20.0f;
            Assert.AreEqual(20.0f, paddingType.Start, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Right, Check whether Right property is writable and readable.")]
        [Property("SPEC", "Tizen.NUI.PaddingType.End A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void End_SET_GET_VALUE()
        {
            /* TEST CODE */
            var paddingType = new PaddingType();
            paddingType.End = 20.0f;
            Assert.AreEqual(20.0f, paddingType.End, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Bottom, Check whether Bottom property is writable and readable.")]
        [Property("SPEC", "Tizen.NUI.PaddingType.Bottom A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Bottom_SET_GET_VALUE()
        {
            /* TEST CODE */
            var paddingType = new PaddingType();
            paddingType.Bottom = 20.0f;
            Assert.AreEqual(20.0f, paddingType.Bottom, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Top, Check whether Top property is writable and readable.")]
        [Property("SPEC", "Tizen.NUI.PaddingType.Top A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Top_SET_GET_VALUE()
        {
            /* TEST CODE */
            var paddingType = new PaddingType();
            paddingType.Top = 20.0f;
            Assert.AreEqual(20.0f, paddingType.Top, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Equality, Check Equality operator by comparing two PaddingType instance.")]
        [Property("SPEC", "Tizen.NUI.PaddingType.== A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "PaddingType, PaddingType")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Equality_CHECK_VALUE()
        {
            /* TEST CODE */
            var paddingType1 = new PaddingType(0.0f, 0.0f, 20.0f, 30.0f);
            var paddingType2 = new PaddingType(0.0f, 0.0f, 20.0f, 30.0f);
            bool flag = false;
            if(paddingType1 == paddingType2)
            {
                flag = true;
            }
            Assert.IsTrue(flag, "Should be true!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Inequality, Check Inequality operator by comparing two PaddingType instance.")]
        [Property("SPEC", "Tizen.NUI.PaddingType.!= A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "PaddingType, PaddingType")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Inequality_CHECK_VALUE()
        {
            /* TEST CODE */
            var paddingType1 = new PaddingType(0.0f, 0.0f, 20.0f, 30.0f);
            var paddingType2 = new PaddingType(0.0f, 0.0f, 30.0f, 20.0f);
            bool flag = false;
            if (paddingType1 != paddingType2)
            {
                flag = true;
            }
            Assert.IsTrue(flag, "Should be true!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Set, Check whether Set function operater works or not.")]
        [Property("SPEC", "Tizen.NUI.PaddingType.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Set_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            try
            {
                var paddingType = new PaddingType();
                paddingType.Set(0.0f, 0.0f, 20.0f, 30.0f);
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
        [Description("Test Dispose, try to dispose the PaddingType.")]
        [Property("SPEC", "Tizen.NUI.PaddingType.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            try
            {
                PaddingType PaddingType = new PaddingType();
                PaddingType.Dispose();
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
        [Description("Test Equals. Check whether Equals returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PaddingType.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Equals_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var paddingType1 = new PaddingType(0.0f, 0.0f, 20.0f, 30.0f);
            var paddingType2 = new PaddingType(0.0f, 0.0f, 20.0f, 30.0f);
            var paddingType3 = new PaddingType(10.0f, 0.0f, 20.0f, 30.0f);
            bool flagTrue = paddingType1.Equals(paddingType2);
            bool flagFalse = paddingType1.Equals(paddingType3);
            Assert.IsTrue(flagTrue, "Should be true!");
            Assert.IsFalse(flagFalse, "Should be false!");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetHashCode. Check whether GetHashCode returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PaddingType.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetHashCode_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var paddingType = new PaddingType();
            Assert.IsNotNull(paddingType, "Can't create success object PaddingType");
            Assert.IsInstanceOf<PaddingType>(paddingType, "Should be an instance of PaddingType type.");
            Assert.GreaterOrEqual(paddingType.GetHashCode(), 0, "Should be true");
        }
    }
}
