using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.PropertyCondition Tests")]
    public class PropertyConditionTests
    {
        private string TAG = "NUI";
        private PropertyCondition propertyCondition;

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("PropertyConditionTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a PropertyCondition object. Check whether PropertyCondition is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyCondition.PropertyCondition C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PropertyCondition_INIT()
        {
            /* TEST CODE */
            propertyCondition = new Tizen.NUI.PropertyCondition();
            Assert.IsNotNull(propertyCondition, "Can't create success object PropertyCondition");
            Assert.IsInstanceOf<PropertyCondition>(propertyCondition, "Should be an instance of PropertyCondition type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetArgumentCount. Check whether GetArgumentCount works or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyCondition.GetArgumentCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetArgumentCount_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            var cnt = propertyCondition.GetArgumentCount();
            propertyCondition = PropertyCondition.GreaterThan(50.0f);
            Assert.AreEqual(cnt + 1, propertyCondition.GetArgumentCount(), $"Should be equal to {cnt + 1} here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetArgument. Check whether GetArgument works or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyCondition.GetArgument M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetArgument_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            var propertyCondition = PropertyCondition.GreaterThan(50);
            Assert.AreEqual(50, propertyCondition.GetArgument(0), "Should be equal to 1 here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test LessThan. Check whether LessThan works or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyCondition.LessThan M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void LessThan_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            var propertyCondition2 = PropertyCondition.LessThan(50);
            Assert.AreEqual(1, propertyCondition2.GetArgumentCount(), "Should be equal to 1 here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test GreaterThan. Check whether GreaterThan works or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyCondition.GreaterThan M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GreaterThan_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            var propertyCondition = PropertyCondition.GreaterThan(50);
            Assert.AreEqual(1, propertyCondition.GetArgumentCount(), "Should be equal to 1 here!");
        }


        [Test]
        [Category("P1")]
        [Description("Test Inside. Check whether Inside works or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyCondition.Inside M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Inside_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            var cnt = propertyCondition.GetArgumentCount();
            Tizen.Log.Debug(TAG, "before propertyCondition.GetArgumentCount()=" + propertyCondition.GetArgumentCount());
            propertyCondition = PropertyCondition.Inside(50.0f, 100.0f);
            Tizen.Log.Debug(TAG, "after propertyCondition.GetArgumentCount()=" + propertyCondition.GetArgumentCount());
            Assert.AreEqual(cnt + 1, propertyCondition.GetArgumentCount(), $"Should be equal to {cnt + 1} here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Outside. Check whether Outside works or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyCondition.Outside M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Outside_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            var cnt = propertyCondition.GetArgumentCount();
            Tizen.Log.Debug(TAG, "before propertyCondition.GetArgumentCount()=" + propertyCondition.GetArgumentCount());
            propertyCondition = PropertyCondition.Outside(50.0f, 100.0f);
            Tizen.Log.Debug(TAG, "after propertyCondition.GetArgumentCount()=" + propertyCondition.GetArgumentCount());
            Assert.AreEqual(cnt, propertyCondition.GetArgumentCount(), $"Should be equal to {cnt} here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Step. Check whether Step works or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyCondition.Step M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Step_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            var cnt = propertyCondition.GetArgumentCount();
            propertyCondition = PropertyCondition.Step(100.0f);
            Assert.AreEqual(cnt + 1, propertyCondition.GetArgumentCount(), $"Should be equal to {cnt + 1} here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Step. Check whether Step works or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyCondition.Step M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Single, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Step_CHECK_RETURN_TYPE_WITH_TWO_STRING()
        {
            /* TEST CODE */
            var cnt = propertyCondition.GetArgumentCount();
            Tizen.Log.Debug(TAG, "before propertyCondition.GetArgumentCount()=" + propertyCondition.GetArgumentCount());
            propertyCondition = PropertyCondition.Step(50.0f, 100.0f);
            Tizen.Log.Debug(TAG, "after propertyCondition.GetArgumentCount()=" + propertyCondition.GetArgumentCount());
            Assert.AreEqual(cnt, propertyCondition.GetArgumentCount(), $"Should be equal to {cnt} here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the PropertyCondition.")]
        [Property("SPEC", "Tizen.NUI.PropertyCondition.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            try
            {
                PropertyCondition propertyCondition = new PropertyCondition();
                propertyCondition.Dispose();
            }
            catch (Exception e)
            {
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
    }
}
