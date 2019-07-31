using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.LongPressGesture Tests")]
    public class LongPressGestureTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("LongPressGestureTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a LongPressGesture object. Check whether LongPressGesture is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.LongPressGesture.LongPressGesture C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void LongPressGesture_INIT()
        {
            /* TEST CODE */
            var longPressGesture = new LongPressGesture(Gesture.StateType.Cancelled);
            Assert.IsNotNull(longPressGesture, "Can't create success object PanGesture");
            Assert.IsInstanceOf<LongPressGesture>(longPressGesture, "Should be an instance of LongPressGesture type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test LocalPoint. Check whether LocalPoint is readable.")]
        [Property("SPEC", "Tizen.NUI.LongPressGesture.LocalPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void LocalPoint_GET_VALUE()
        {
            /* TEST CODE */
            try
            {
                var longPressGesture = new LongPressGesture(Gesture.StateType.Cancelled);
                Assert.IsInstanceOf<LongPressGesture>(longPressGesture, "Should be an instance of LongPressGesture type");
                Vector2 vector = longPressGesture.LocalPoint;
                Assert.AreEqual(0, vector.X, "Should be the default value");
                Assert.AreEqual(0, vector.Y, "Should be the default value");
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
        [Description("Test NumberOfTouches. Check whether NumberOfTouches is readable.")]
        [Property("SPEC", "Tizen.NUI.LongPressGesture.NumberOfTouches A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void NumberOfTouches_GET_VALUE()
        {
            /* TEST CODE */
            try
            {
                var longPressGesture = new LongPressGesture(Gesture.StateType.Cancelled);
                Assert.IsInstanceOf<LongPressGesture>(longPressGesture, "Should be an instance of LongPressGesture type");
                uint number = longPressGesture.NumberOfTouches;
                Assert.AreEqual(1, number, "Should be the default value");
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
        [Description("Test ScreenPoint. Check whether ScreenPoint is readable.")]
        [Property("SPEC", "Tizen.NUI.LongPressGesture.ScreenPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void ScreenPoint_GET_VALUE()
        {
            /* TEST CODE */
            try
            {
                var longPressGesture = new LongPressGesture(Gesture.StateType.Cancelled);
                Assert.IsInstanceOf<LongPressGesture>(longPressGesture, "Should be an instance of LongPressGesture type");
                Vector2 vector = longPressGesture.ScreenPoint;
                Assert.AreEqual(0, vector.X, "Should be the default value");
                Assert.AreEqual(0, vector.Y, "Should be the default value");
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
