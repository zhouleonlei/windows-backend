using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.PropertyArray Tests")]
    public class PropertyArrayTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("PropertyArrayTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyArray constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.PropertyArray C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void PropertyArray_INIT()
        {
            /* TEST CODE */
            var propertyarray = new PropertyArray();
            Assert.IsInstanceOf<PropertyArray>(propertyarray, "Should return PropertyArray instance.");
        }

        [Test]
        [Category("P1")]
        [Description("Test this[uint index]. Check whether this[uint index] returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void this_SET_GET_VALUE()
        {
            /* TEST CODE */
            PropertyArray propertyarray = new PropertyArray();
            propertyarray.Reserve(3);
            Assert.AreEqual(0, propertyarray.Size(), "the array size is not zero");
            PropertyValue propertyvalue1 = new PropertyValue(1);
            PropertyValue propertyvalue2 = new PropertyValue(2);
            propertyarray.PushBack(propertyvalue1);
            propertyarray.PushBack(propertyvalue2);
            int tempvalue = 0;
            propertyarray[1].Get(out tempvalue);
            Assert.AreEqual(2, tempvalue, "this[uint index] function return error value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Size. Check whether Size returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.Size M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Size_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            PropertyArray propertyarray = new PropertyArray();
            propertyarray.Reserve(3);
            Assert.AreEqual(0, propertyarray.Size(), "the array size is not zero");
            PropertyValue propertyvalue1 = new PropertyValue(1);
            PropertyValue propertyvalue2 = new PropertyValue(2);
            PropertyValue propertyvalue3 = new PropertyValue(3);
            propertyarray.PushBack(propertyvalue1);
            propertyarray.PushBack(propertyvalue2);
            propertyarray.PushBack(propertyvalue3);
            Assert.AreEqual(3, propertyarray.Size(), "the array size got from Size function is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Count. Check whether Count returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.Count M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Count_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            PropertyArray propertyarray = new PropertyArray();
            Assert.AreEqual(0, propertyarray.Count(), "the array count is not zero");
            propertyarray.Reserve(3);
            PropertyValue propertyvalue1 = new PropertyValue(1);
            PropertyValue propertyvalue2 = new PropertyValue(2);
            PropertyValue propertyvalue3 = new PropertyValue(3);
            propertyarray.PushBack(propertyvalue1);
            propertyarray.PushBack(propertyvalue2);
            propertyarray.PushBack(propertyvalue3);
            Assert.AreEqual(3, propertyarray.Count(), "the array count got from Count function is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Empty. Check whether Empty returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", " MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Empty_CHECK_VALUE()
        {
            /* TEST CODE */
            PropertyArray propertyarray = new PropertyArray();
            propertyarray.Reserve(3);
            Assert.True(propertyarray.Empty(), "Empty not work, the array is not empty");
            PropertyValue propertyvalue1 = new PropertyValue(1);
            PropertyValue propertyvalue2 = new PropertyValue(2);
            PropertyValue propertyvalue3 = new PropertyValue(3);
            propertyarray.PushBack(propertyvalue1);
            propertyarray.PushBack(propertyvalue2);
            propertyarray.PushBack(propertyvalue3);
            Assert.False(propertyarray.Empty(), "array now is empty");
        }

        [Test]
        [Category("P1")]
        [Description("Test Clear. Check whether Clear returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.Clear M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Clear_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                PropertyArray propertyarray = new PropertyArray();
                propertyarray.Reserve(3);
                PropertyValue propertyvalue1 = new PropertyValue(1);
                PropertyValue propertyvalue2 = new PropertyValue(2);
                PropertyValue propertyvalue3 = new PropertyValue(3);
                propertyarray.PushBack(propertyvalue1);
                propertyarray.PushBack(propertyvalue2);
                propertyarray.PushBack(propertyvalue3);
                Assert.False(propertyarray.Empty(), "array is empty");
                propertyarray.Clear();
                Assert.True(propertyarray.Empty(), "Clear not work, array now is not empty");
            }
            catch (Exception e)
            {
                Tizen.Log.Error("Test PropertyArray", "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Reserve. Check whether Reserve returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.Reserve M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Reserve_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                PropertyArray propertyarray = new PropertyArray();
                Assert.AreEqual(0, propertyarray.Capacity(), "now array capacity is not zero");
                propertyarray.Reserve(3);
                Assert.AreEqual(3, propertyarray.Capacity(), "Capacity function return false, array Capacity is not equal to Reserve number");
            }
            catch (Exception e)
            {
                Tizen.Log.Error("Test PropertyArray", "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Resize. Check whether Resize returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.Resize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Resize_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                PropertyArray propertyarray = new PropertyArray();
                propertyarray.Resize(5);
                Assert.AreEqual(5, propertyarray.Count(), "Resize function not work, array account is not equal to resize number");
            }
            catch (Exception e)
            {
                Tizen.Log.Error("Test PropertyArray", "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Capacity. Check whether Capacity returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.Capacity M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Capacity_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            PropertyArray propertyarray = new PropertyArray();
            propertyarray.Reserve(6);
            Assert.AreEqual(6, propertyarray.Capacity(), "Capacity function not work, array Capacity is not equal to Reserve number");
        }

        [Test]
        [Category("P1")]
        [Description("Test PushBack. Check whether PushBack returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.PushBack M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void PushBack_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                PropertyArray propertyarray = new PropertyArray();
                PropertyValue propertyvalue = new PropertyValue(4);
                propertyarray.PushBack(propertyvalue);
                Assert.AreEqual(1, propertyarray.Size(), "PushBack function not work, the size of the array is not equal to the pushback number");
                int tempvalue = 0;
                propertyarray[0].Get(out tempvalue);
                Assert.AreEqual(4, tempvalue, "PushBack function not work, the value got from array is not equal to the pushback value");
            }
            catch (Exception e)
            {
                Tizen.Log.Error("Test PropertyArray", "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Add. Check whether Add returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "PropertyValue")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Add_CHECK_VALUE_WITH_PROPERTYVALUE()
        {
            /* TEST CODE */
            PropertyArray propertyarray = new PropertyArray();
            PropertyValue propertyvalue1 = new PropertyValue(14.0f);
            PropertyValue propertyvalue2 = new PropertyValue(15.0f);
            propertyarray.Add(propertyvalue1);
            propertyarray.Add(propertyvalue2);
            Assert.AreEqual(2, propertyarray.Size(), "Add function not work, the size of the array is not equal to the Add number");
            float tempvalue1 = 0.0f;
            float tempvalue2 = 0.0f;
            propertyarray[0].Get(out tempvalue1);
            propertyarray[1].Get(out tempvalue2);
            Assert.AreEqual(14.0f, tempvalue1, "Add function not work, the value got from array is not equal to the Add value");
            Assert.AreEqual(15.0f, tempvalue2, "Add function not work, the value got from array is not equal to the Add value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Add. Check whether Add returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "KeyValue")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Add_CHECK_VALUE_WITH_KEYVALUE()
        {
            /* TEST CODE */
            PropertyArray propertyarray = new PropertyArray();
            KeyValue keyValue1 = new KeyValue();
            keyValue1.SingleValue = 14.0f;
            KeyValue keyValue2 = new KeyValue();
            keyValue2.SingleValue = 15.0f;

            propertyarray.Add(keyValue1);
            propertyarray.Add(keyValue2);
            Assert.AreEqual(2, propertyarray.Size(), "Add function not work, the size of the array is not equal to the Add number");
            float tempvalue1 = 0.0f;
            float tempvalue2 = 0.0f;
            propertyarray[0].Get(out tempvalue1);
            propertyarray[1].Get(out tempvalue2);
            Assert.AreEqual(14.0f, tempvalue1, "Add function not work, the value got from array is not equal to the Add value");
            Assert.AreEqual(15.0f, tempvalue2, "Add function not work, the value got from array is not equal to the Add value");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetElementAt. Check whether GetElementAt returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyArray.GetElementAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void GetElementAt_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            PropertyArray propertyarray = new PropertyArray();
            PropertyValue propertyvalue1 = new PropertyValue(3.0f);
            PropertyValue propertyvalue2 = new PropertyValue(6.0f);
            propertyarray.Add(propertyvalue1);
            propertyarray.Add(propertyvalue2);
            float tempvalue1 = 0.0f;
            float tempvalue2 = 0.0f;
            propertyarray.GetElementAt(0).Get(out tempvalue1);
            propertyarray.GetElementAt(1).Get(out tempvalue2);
            Assert.AreEqual(3.0f, tempvalue1, "GetElementAt function not work, the value got from GetElementAt is not equal to the array value");
            Assert.AreEqual(6.0f, tempvalue2, "GetElementAt function not work, the value got from GetElementAt is not equal to the array value");
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