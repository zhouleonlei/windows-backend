using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.PropertyMap Tests")]
    public class PropertyMapTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("PropertyMapTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Test this. Check whether this with string parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.this[string] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "string")]
        public void this_SET_GET_VALUE_WITH_STRING()
        {
            /* TEST CODE */
            PropertyMap propertyMap = new PropertyMap();
            PropertyValue propertyValue = new PropertyValue(14.0f);
            propertyMap.Insert("A", propertyValue);
            PropertyValue newValue = propertyMap["A"];
            float tempvalue1 = 0;
            float tempvalue2 = 0;
            newValue.Get(out tempvalue1);
            propertyValue.Get(out tempvalue2);
            Assert.AreEqual(tempvalue1, tempvalue2, "this function with string parameter does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test this. Check whether this with int parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.this[int] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "int")]
        public void this_SET_GET_VALUE_WITH_INT()
        {
            /* TEST CODE */
            PropertyMap propertyMap = new PropertyMap();
            PropertyValue propertyValue = new PropertyValue(14.0f);
            propertyMap.Insert(8, propertyValue);
            PropertyValue newValue = propertyMap[8];
            float tempValue1 = 0;
            float tempValue2 = 0;
            newValue.Get(out tempValue1);
            propertyValue.Get(out tempValue2);
            Assert.AreEqual(tempValue1, tempValue2, "this function with int parameter does not work");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyMap constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.PropertyMap C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void PropertyMap_INIT_WITH_NULL()
        {
            /* TEST CODE */
            var propertyMmap = new PropertyMap();
            Assert.IsInstanceOf<PropertyMap>(propertyMmap, "Should return PropertyMap instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyKey constructor with PropertyMap parameter test")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.PropertyMap C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "PropertyMap")]
        public void PropertyMap_INIT_WITH_PROPERTYMAP()
        {
            /* TEST CODE */
            var propertyMmap1 = new PropertyMap();
            var propertyMmap2 = new PropertyMap(propertyMmap1);
            Assert.IsInstanceOf<PropertyMap>(propertyMmap2, "Should return PropertyMap instance.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Count. Check whether Count returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Count M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Count_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            PropertyMap propertyMap = new PropertyMap();
            PropertyValue propertyValue1 = new PropertyValue(4.0f);
            propertyMap.Insert(8, propertyValue1);
            PropertyValue propertyValue2 = new PropertyValue(5.0f);
            propertyMap.Insert(18, propertyValue2);
            Assert.AreEqual(2, propertyMap.Count(), "Count function does not work, the count of map is not equal to the insert number");
        }

        [Test]
        [Category("P1")]
        [Description("Test Empty. Check whether Empty returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Empty_CHECK_VALUE()
        {
            /* TEST CODE */
            PropertyMap propertyMap = new PropertyMap();
            Assert.True(propertyMap.Empty(), "the PropertyMap is not empty");
            PropertyValue propertyvalue1 = new PropertyValue(4.0f);
            propertyMap.Insert(8, propertyvalue1);
            PropertyValue propertyvalue2 = new PropertyValue(5.0f);
            propertyMap.Insert(18, propertyvalue2);
            Assert.False(propertyMap.Empty(), "the PropertyMap is empty");
        }

        [Test]
        [Category("P1")]
        [Description("Test Insert. Check whether Insert with string and PropertyValue parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Insert M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "string, PropertyValue")]
        public void Insert_CHECK_VALUE_WITH_STRING_PROPERTYVALUE()
        {
            /* TEST CODE */
            PropertyMap propertyMap = new PropertyMap();
            PropertyValue propertyValue = new PropertyValue(4.0f);
            try
            {
                propertyMap.Insert("hello", propertyValue);
            }
            catch
            {
                Assert.IsFalse(true, "Insert does not work.");
            }
            Assert.AreEqual(1, propertyMap.Count(), "Insert with string and PropertyValue parameter function does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test Insert. Check whether Insert with int and PropertyValue parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Insert M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "int, PropertyValue")]
        public void Insert_CHECK_VALUE_WITH_INT_PROPERTYVALUE()
        {
            /* TEST CODE */
            PropertyMap propertyMap = new PropertyMap();

            PropertyValue propertyValue = new PropertyValue(4.0f);
            try
            {
                propertyMap.Insert(20, propertyValue);
            }
            catch
            {
                Assert.IsFalse(true, "Insert does not work.");
            }
            Assert.AreEqual(1, propertyMap.Count(), "Insert with int and PropertyValue parameter function does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test Add. Check whether Add with string and PropertyValue parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "string, PropertyValue")]
        public void Add_CHECK_VALUE_WITH_STRING_PROPERTYVALUE()
        {
            /* TEST CODE */
            PropertyMap propertyMap = new PropertyMap();
            PropertyValue propertyValue = new PropertyValue(4.0f);
            var proMap = propertyMap.Add("hello", propertyValue);

            Assert.IsInstanceOf<PropertyMap>(proMap, "Should return PropertyMap instance.");
            Assert.AreEqual(1, propertyMap.Count(), "Add with string and PropertyValue parameter function does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test Add. Check whether Add with int and PropertyValue parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "int, PropertyValue")]
        public void Add_CHECK_VALUE_WITH_INT_PROPERTYVALUE()
        {
            /* TEST CODE */
            PropertyMap propertyMap = new PropertyMap();
            PropertyValue propertyValue = new PropertyValue(4.0f);
            var proMap = propertyMap.Add(300, propertyValue);

            Assert.IsInstanceOf<PropertyMap>(proMap, "Should return PropertyMap instance.");
            Assert.AreEqual(1, propertyMap.Count(), "Add with string and PropertyValue parameter function does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test Add. Check whether Add with KeyValue parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        [Property("COVPARAM", "KeyValue")]
        public void Add_CHECK_VALUE_WITH_KEYVALUE()
        {
            /* TEST CODE */
            PropertyMap propertyMap = new PropertyMap();
            KeyValue keyValue1 = new KeyValue();
            keyValue1.KeyInt = 300;
            keyValue1.SingleValue = 4.0f;
            var proMap = propertyMap.Add(keyValue1);

            Assert.IsInstanceOf<PropertyMap>(proMap, "Should return PropertyMap instance.");
            Assert.AreEqual(1, propertyMap.Count(), "Add with string and PropertyValue parameter function does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetValue. Check whether GetValue returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.GetValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void GetValue_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            PropertyMap propertyMap = new PropertyMap();
            PropertyValue propertyValue = new PropertyValue(4.0f);
            propertyMap.Insert("hello", propertyValue);
            var proVal = propertyMap.GetValue(0);
            Assert.IsInstanceOf<PropertyValue>(proVal, "Should return PropertyValue instance.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetKey. Check whether GetKey returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.GetKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void GetKey_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            PropertyMap propertymap = new PropertyMap();
            PropertyValue propertyValue = new PropertyValue(4.0f);
            propertymap.Add("hello", propertyValue);
            PropertyKey key = propertymap.GetKeyAt(0);
        }

        [Test]
        [Category("P1")]
        [Description("Test GetKeyAt. Check whether GetKeyAt returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.GetKeyAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void GetKeyAt_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            PropertyMap propertymap = new PropertyMap();
            PropertyValue propertyValue = new PropertyValue(4.0f);
            propertymap.Insert("hello", propertyValue);
            var propertykey = propertymap.GetKeyAt(0);
        }

        [Test]
        [Category("P1")]
        [Description("Test Find. Check whether Find with int key parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Find M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "int")]
        public void Find_CHECK_RETURN_VALUE_WITH_INT()
        {
            /* TEST CODE */
            PropertyMap propertymap = new PropertyMap();
            PropertyValue propertyValue = new PropertyValue(400.0f);
            propertymap.Add(2, propertyValue);
            PropertyValue value = propertymap.Find(2);
            float tempValue = 0;
            value.Get(out tempValue);
            Assert.AreEqual(400.0f, tempValue, "Find function with int key parameter does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test Find. Check whether Find with int indexKey parameter and stringKey parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Find M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "int, string")]
        public void Find_CHECK_RETURN_VALUE_WITH_INT_STRING()
        {
            /* TEST CODE */
            PropertyMap propertymap = new PropertyMap();
            PropertyValue propertyValue = new PropertyValue("DALI");
            propertymap.Add("A", propertyValue);
            PropertyValue value = propertymap.Find(10, "A");
            string str = "";
            value.Get(out str);
            Assert.AreEqual("DALI", str, "Find function with int indexKey parameter and stringKey parameter does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test Clear. Check whether Clear returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Clear M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Clear_CHECK_VALUE()
        {
            /* TEST CODE */
            PropertyMap propertymap = new PropertyMap();
            PropertyValue propertyValue = new PropertyValue(5);
            propertymap.Add(100, propertyValue);
            try
            {
                propertymap.Clear();
            }
            catch
            {
                Assert.IsFalse(true, "Clear propertyMap failed!");
            }
            Assert.AreEqual(0, propertymap.Count(), "Clear function does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test Merge. Check whether Merge returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Merge M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Merge_CHECK_VALUE()
        {
            /* TEST CODE */
            PropertyMap propertyMap1 = new PropertyMap();
            PropertyValue propertyValue1 = new PropertyValue(5);
            propertyMap1.Add(100, propertyValue1);

            PropertyMap propertyMap2 = new PropertyMap();
            PropertyValue propertyValue2 = new PropertyValue(6);
            propertyMap2.Add("A", propertyValue2);
            try
            {
                propertyMap1.Merge(propertyMap2);
            }
            catch
            {
                Assert.IsFalse(true, "Merge propertyMap failed!");
            }
            
            Assert.AreEqual(2, propertyMap1.Count(), "Clear function does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the PropertyMap.")]
        [Property("SPEC", "Tizen.NUI.PropertyMap.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                PropertyMap propertymap = new PropertyMap();
                propertymap.Dispose();
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
