using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.Test;
namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.TypeInfo Tests")]
    public class TypeInfoTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("TypeInfoTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a TypeInfo object. Check whether TypeInfo is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.TypeInfo.TypeInfo C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void TypeInfo_INIT()
        {
            /* TEST CODE */
            var typeInfo = new TypeInfo();
            Assert.IsNotNull(typeInfo, "Can't create success object TypeInfo");
            Assert.IsInstanceOf<TypeInfo>(typeInfo, "Should be an instance of TypeInfo type.");
        }

        [Test]
        [Category("P1")]
        [Description("Create a TypeInfo object. Check whether TypeInfo is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.TypeInfo.TypeInfo C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Tizen.NUI.TypeInfo")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void TypeInfo_INIT_WITH_TYPEINFO()
        {
            /* TEST CODE */
            var typeInfo = TypeRegistry.Get().GetTypeInfo("PushButton");
            Assert.IsInstanceOf<TypeInfo>(typeInfo, "Should be an instance of TypeInfo type.");
            var typeInfo2 = new TypeInfo(typeInfo);
            Assert.IsInstanceOf<TypeInfo>(typeInfo2, "Should be an instance of TypeInfo type.");
            Assert.IsNotNull(typeInfo2, "Can't create success object TypeInfo");
        }

        [Test]
        [Category("P1")]
        [Description("Test CreateInstance. Check whether CreateInstance returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.TypeInfo.CreateInstance M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void CreateInstance_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var typeInfo = TypeRegistry.Get().GetTypeInfo("PushButton");
            Assert.IsInstanceOf<TypeInfo>(typeInfo, "Should be an instance of TypeInfo type.");
            BaseHandle baseHandle = typeInfo.CreateInstance();
            Assert.IsNotNull(baseHandle, "Can't create success object TypeInfo");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetBaseName. Check whether GetBaseName returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.TypeInfo.GetBaseName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetBaseName_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var typeInfo = TypeRegistry.Get().GetTypeInfo("PushButton");
                Assert.IsInstanceOf<TypeInfo>(typeInfo, "Should be an instance of TypeInfo type.");
                Assert.AreEqual("Button", typeInfo.GetBaseName(), "Should be equal");
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
        [Description("Test GetName. Check whether GetName returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.TypeInfo.GetName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetName_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var typeInfo = TypeRegistry.Get().GetTypeInfo("PushButton");
                Assert.IsInstanceOf<TypeInfo>(typeInfo, "Should be an instance of TypeInfo type.");
                Assert.AreEqual("PushButton", typeInfo.GetName(), "Should be equal");
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
        [Description("Test GetPropertyCount. Check whether GetPropertyCount returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.TypeInfo.GetPropertyCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetPropertyCount_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var typeInfo = TypeRegistry.Get().GetTypeInfo("PushButton");
                Assert.IsInstanceOf<TypeInfo>(typeInfo, "Should be an instance of TypeInfo type.");
                Assert.Greater(typeInfo.GetPropertyCount(), 0, "The property count should greater than 0");
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
        [Description("Test GetPropertyName. Check whether GetPropertyName returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.TypeInfo.GetPropertyName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetPropertyName_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var typeInfo = TypeRegistry.Get().GetTypeInfo("PushButton");
                Assert.IsInstanceOf<TypeInfo>(typeInfo, "Should be an instance of TypeInfo type.");
                PushButton view = new PushButton();
                int propertyIndex = view.GetPropertyIndex("label");
                Assert.AreEqual("label", typeInfo.GetPropertyName(propertyIndex), "Should be equal");
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