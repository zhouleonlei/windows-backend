using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.PropertyKey Tests")]
    public class PropertyKeyTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("PropertyKeyTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyKey constructor with string key parameter test")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.PropertyKey C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "string")]
        public void PropertyKey_INIT_WITH_STRING()
        {
            /* TEST CODE */
            String value = "dali";
            var propertykey = new PropertyKey(value);
            Assert.IsInstanceOf<PropertyKey>(propertykey, "Should return PropertyKey instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyKey constructor with int key parameter test")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.PropertyKey C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "int")]
        public void PropertyKey_INIT_WITH_INT()
        {
            /* TEST CODE */
            int value = 7;
            var propertykey = new PropertyKey(value);
            Assert.IsInstanceOf<PropertyKey>(propertykey, "Should return PropertyKey instance.");
        }

        [Test]
        [Category("P1")]
        [Description("Test type. Check whether type is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.Type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW PRE")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Type_SET_GET_VALUE()
        {
            /* TEST CODE */
            string tempstring = "hello world";
            PropertyKey propertykey = new PropertyKey(tempstring);
            Assert.AreEqual(PropertyKey.KeyType.String, propertykey.Type, "type function does not work");
            propertykey.Type = PropertyKey.KeyType.Index;
            Assert.AreEqual(PropertyKey.KeyType.Index, propertykey.Type, "type function does not work, the type got from type function is not equal to the setting type");
        }

        [Test]
        [Category("P1")]
        [Description("Test type. Check whether type is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.Type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Type_SET_GET_VALUE_WITH_INT()
        {
            /* TEST CODE */
            int tempInt = 1;
            PropertyKey propertykey = new PropertyKey(tempInt);
            Assert.AreEqual(PropertyKey.KeyType.Index, propertykey.Type, "type function does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test indexKey. Check whether indexKey is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.IndexKey A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void IndexKey_SET_GET_VALUE()
        {
            /* TEST CODE */
            PropertyKey PropertyKey = new PropertyKey(30);
            Assert.AreEqual(30, PropertyKey.IndexKey, "indexKey function does not work");
            PropertyKey.IndexKey = 20;
            Assert.AreEqual(20, PropertyKey.IndexKey, "indexKey function does not work, the indexKey got from type function is not equal to the setting indexKey");
        }

        [Test]
        [Category("P1")]
        [Description("Test stringKey. Check whether stringKey is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.StringKey A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void StringKey_SET_GET_VALUE()
        {
            /* TEST CODE */
            PropertyKey PropertyKey = new PropertyKey("aKey");
            Assert.AreEqual("aKey", PropertyKey.StringKey, "stringKey function does not work");
            PropertyKey.StringKey = "bKey";
            Assert.AreEqual("bKey", PropertyKey.StringKey, "stringKey function does not work, the stringKey got from type function is not equal to the setting stringKey");
        }

        [Test]
        [Category("P1")]
        [Description("Test EqualTo. Check whether EqualTo with string parameters returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "string")]
        public void EqualTo_CHECK_RETURN_VALUE_WITH_STRING()
        {
            /* TEST CODE */
            PropertyKey propertykey = new PropertyKey("hello world");
            var result = propertykey.EqualTo("hello world");
            Assert.IsNotNull(result, "The result should not be null");
            Assert.IsTrue(result, "EqualTo with string parameters funtion does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test EqualTo. Check whether EqualTo with int parameters returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "int")]
        public void EqualTo_CHECK_RETURN_VALUE_WITH_INT()
        {
            /* TEST CODE */
            PropertyKey propertykey = new PropertyKey(20);
            var result = propertykey.EqualTo(20);
            Assert.IsNotNull(result, "The result should not be null");
            Assert.IsTrue(result, "EqualTo with int parameters funtion does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test EqualTo. Check whether EqualTo with PropertyKey parameters returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "PropertyKey")]
        public void EqualTo_CHECK_RETURN_VALUE_WITH_PROPERTYKEY()
        {
            /* TEST CODE */
            PropertyKey propertykey1 = new PropertyKey(20);
            PropertyKey propertykey2 = propertykey1;
            var result = propertykey1.EqualTo(propertykey2);
            Assert.IsNotNull(result, "The result should not be null");
            Assert.IsTrue(result, "EqualTo with PropertyKey parameters funtion does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test NotEqualTo. Check whether NotEqualTo with string parameters returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "string")]
        public void NotEqualTo_CHECK_RETURN_VALUE_WITH_STRING()
        {
            /* TEST CODE */
            PropertyKey propertykey1 = new PropertyKey("DALI");
            var result = propertykey1.NotEqualTo("HELLO");
            Assert.IsNotNull(result, "The result should not be null");
            Assert.IsTrue(result, "EqualTo with string parameters funtion does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test NotEqualTo. Check whether NotEqualTo with int parameters returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "int")]
        public void NotEqualTo_CHECK_RETURN_VALUE_WITH_INT()
        {
            /* TEST CODE */
            PropertyKey propertykey1 = new PropertyKey(20);

            var result = propertykey1.NotEqualTo(30);
            Assert.IsNotNull(result, "The result should not be null");
            Assert.IsTrue(result, "NotEqualTo with int parameters funtion does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test NotEqualTo. Check whether NotEqualTo with PropertyKey parameters returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyKey.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "PropertyKey")]
        public void NotEqualTo_CHECK_RETURN_VALUE_WITH_PROPERTYKEY()
        {
            /* TEST CODE */
            PropertyKey propertykey1 = new PropertyKey(20);
            PropertyKey propertykey2 = new PropertyKey(30);
            var result = propertykey1.NotEqualTo(propertykey2);
            Assert.IsNotNull(result, "The result should not be null");
            Assert.IsTrue(result, "NotEqualTo with PropertyKey parameters funtion does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the PropertyArray.")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                PropertyArray propertyarray = new PropertyArray();
                propertyarray.Dispose();
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