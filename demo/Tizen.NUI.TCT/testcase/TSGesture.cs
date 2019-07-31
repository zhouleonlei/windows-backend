using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Gesture Tests")]
    public class GestureTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("GestureTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a Gesture object. Check whether Gesture is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Gesture.Gesture C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Gesture")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Gesture_INIT()
        {
            /* TEST CODE */
            var longPressGesture = new LongPressGesture(Gesture.StateType.Cancelled);
            Assert.IsNotNull(longPressGesture, "Can't create success object LongPressGesture");
            var gesture = new Gesture(longPressGesture);
            Assert.IsNotNull(gesture, "Can't create success object Gesture");
            Assert.IsInstanceOf<Gesture>(gesture, "Should be an instance of Gesture type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Type. Check whether Type is readable.")]
        [Property("SPEC", "Tizen.NUI.Gesture.Type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Type_GET_VALUE()
        {
            /* TEST CODE */
            try
            {
                var longPressGesture = new LongPressGesture(Gesture.StateType.Cancelled);
                Assert.IsNotNull(longPressGesture, "Can't create success object LongPressGesture");
                var gesture = new Gesture(longPressGesture);
                Assert.IsNotNull(gesture, "Can't create success object Gesture");
                Assert.IsInstanceOf<Gesture>(gesture, "Should be an instance of Gesture type.");
                Gesture.GestureType type = gesture.Type;
                Assert.AreEqual(Gesture.GestureType.LongPress, type, "Should be same value");
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
        [Description("Test State. Check whether State is readable.")]
        [Property("SPEC", "Tizen.NUI.Gesture.State A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void State_GET_VALUE()
        {
            /* TEST CODE */
            try
            {
                var longPressGesture = new LongPressGesture(Gesture.StateType.Cancelled);
                Assert.IsNotNull(longPressGesture, "Can't create success object LongPressGesture");
                var gesture = new Gesture(longPressGesture);
                Assert.IsNotNull(gesture, "Can't create success object Gesture");
                Assert.IsInstanceOf<Gesture>(gesture, "Should be an instance of Gesture type.");
                Gesture.StateType state = gesture.State;
                Assert.AreEqual(Gesture.StateType.Cancelled, state, "Should be same value");
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
        [Description("Test Time. Check whether Time is readable.")]
        [Property("SPEC", "Tizen.NUI.Gesture.Time A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Time_GET_VALUE()
        {
            /* TEST CODE */
            try
            {
                var longPressGesture = new LongPressGesture(Gesture.StateType.Cancelled);
                Assert.IsNotNull(longPressGesture, "Can't create success object LongPressGesture");
                var gesture = new Gesture(longPressGesture);
                Assert.IsNotNull(gesture, "Can't create success object Gesture");
                Assert.IsInstanceOf<Gesture>(gesture, "Should be an instance of Gesture type.");
                uint time = gesture.Time;
                Assert.GreaterOrEqual(time, 0, "Should be greater or equal 0");
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
