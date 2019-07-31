using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.KeyFrames Tests")]
    public class KeyFramesTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("KeyFramesTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali keyFrames constructor test")]
        [Property("SPEC", "Tizen.NUI.KeyFrames.KeyFrames C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void KeyFrames_INIT()
        {
            /* TEST CODE */
            var keyFrames = new KeyFrames();
            Assert.IsInstanceOf<KeyFrames>(keyFrames, "Should return KeyFrames instance.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Add. Add some point to keyFrame.")]
        [Property("SPEC", "Tizen.NUI.KeyFrames.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Single, object")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Add_SET_VALUE_WITH_FLOAT_OBJECT()
        {
            /* TEST CODE */
            try
            {
                View actor = new View();
                actor.Position = new Position(10.0f, 10.0f, 10.0f);
                Window.Instance.GetDefaultLayer().Add(actor);
                KeyFrames keyFrames = new KeyFrames();
                keyFrames.Add(0.0f, new Position(0.1f, 0.2f, 0.3f));
                keyFrames.Add(0.5f, new Position(0.9f, 0.8f, 0.7f));
                keyFrames.Add(1.0f, new Position(1.0f, 1.0f, 1.0f));
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
        [Description("Test Add. Add some point to keyFrame, and specify the alphaFunction.")]
        [Property("SPEC", "Tizen.NUI.KeyFrames.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Single, object, AlphaFunction")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Add_SET_VALUE_WITH_FLOAT_OBJECT_ALPHAFUNCTION()
        {
            /* TEST CODE */
            try
            {
                View actor = new View();
                Window.Instance.GetDefaultLayer().Add(actor);
                actor.Position = new Position(1.0f, 1.0f, 1.0f);
                KeyFrames keyFrames = new KeyFrames();
                keyFrames.Add(0.0f, new Position(0.1f, 0.2f, 0.3f), new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
                keyFrames.Add(0.5f, new Position(0.9f, 0.8f, 0.7f), new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
                keyFrames.Add(1.0f, new Position(1.0f, 1.0f, 1.0f), new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
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
        [Description("Test Add. Add some propertyValue to keyFrame")]
        [Property("SPEC", "Tizen.NUI.KeyFrames.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Single, PropertyValue")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Add_SET_VALUE_WITH_FLOAT_PROPERTYVALUE_ALPHAFUNCTION()
        {
            /* TEST CODE */
            try
            {
                View actor = new View();
                Window.Instance.GetDefaultLayer().Add(actor);
                actor.Position = new Position(1.0f, 1.0f, 1.0f);
                KeyFrames keyFrames = new KeyFrames();
                PropertyValue value1 = new PropertyValue(new Position(0.1f, 0.2f, 0.3f));
                PropertyValue value2 = new PropertyValue(new Position(0.9f, 0.8f, 0.7f));
                PropertyValue value3 = new PropertyValue(new Position(1.0f, 1.0f, 1.0f));
                keyFrames.Add(0.0f, value1);
                keyFrames.Add(0.5f, value2);
                keyFrames.Add(1.0f, value3);
                Assert.IsInstanceOf<KeyFrames>(keyFrames, "Should return KeyFrames instance.");
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
        [Description("Test Add. Add some propertyValue to keyFrame, and specify the alphaFunction.")]
        [Property("SPEC", "Tizen.NUI.KeyFrames.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Single, PropertyValue, AlphaFunction")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Add_FSET_VALUE_WITH_FLOAT_PROPERTYVALUE_ALPHAFUNCTION()
        {
            /* TEST CODE */
            try
            {
                View actor = new View();
                Window.Instance.GetDefaultLayer().Add(actor);
                actor.Position = new Position(1.0f, 1.0f, 1.0f);
                KeyFrames keyFrames = new KeyFrames();
                PropertyValue value1 = new PropertyValue(new Position(0.1f, 0.2f, 0.3f));
                PropertyValue value2 = new PropertyValue(new Position(0.9f, 0.8f, 0.7f));
                PropertyValue value3 = new PropertyValue(new Position(1.0f, 1.0f, 1.0f));
                keyFrames.Add(0.0f, value1, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
                keyFrames.Add(0.5f, value2, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
                keyFrames.Add(1.0f, value3, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
                Assert.IsInstanceOf<KeyFrames>(keyFrames, "Should return KeyFrames instance.");
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
        [Description("Test GetType. Check whether it return the right value.")]
        [Property("SPEC", "Tizen.NUI.KeyFrames.GetType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetType_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            KeyFrames keyFrames = new KeyFrames();
            Assert.AreEqual(PropertyType.None, keyFrames.GetType());
            keyFrames.Add(0.0f, new Vector3(0.1f, 0.2f, 0.3f));
            keyFrames.Add(0.5f, new Vector3(0.9f, 0.8f, 0.7f));
            keyFrames.Add(1.0f, new Vector3(1.0f, 1.0f, 1.0f));
            Assert.AreEqual(PropertyType.Vector3, keyFrames.GetType(), "The type of keyFrames is not correct here");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the KeyFrames.")]
        [Property("SPEC", "Tizen.NUI.KeyFrames.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            try
            {
                KeyFrames keyFrames = new KeyFrames();
                keyFrames.Dispose();
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
