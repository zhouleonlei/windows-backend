using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.PinchGesture Tests")]
    public class PinchGestureTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("PinchGestureTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a PinchGesture object. Check whether PinchGesture is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.PinchGesture.PinchGesture C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void PanGesture_INIT()
        {
            /* TEST CODE */
            var pinchGesture = new PinchGesture(Gesture.StateType.Started);
            Assert.IsNotNull(pinchGesture, "Can't create success object PinchGesture");
            Assert.IsInstanceOf<PinchGesture>(pinchGesture, "Should be an instance of PinchGesture type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test LocalCenterPoint. Check whether GetDistance returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PinchGesture.LocalCenterPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void LocalCenterPoint_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                var pinchGesture = new PinchGesture(Gesture.StateType.Started);
                Assert.IsInstanceOf<PinchGesture>(pinchGesture, "Should be an instance of PinchGesture type.");
                Assert.GreaterOrEqual(0, pinchGesture.LocalCenterPoint.X, "Should be the default value");
                Assert.GreaterOrEqual(0, pinchGesture.LocalCenterPoint.Y, "Should be the default value");
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
        [Description("Test Scale. Check whether Scale returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PinchGesture.Scale A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Scale_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                var pinchGesture = new PinchGesture(Gesture.StateType.Started);
                Assert.IsInstanceOf<PinchGesture>(pinchGesture, "Should be an instance of PinchGesture type.");
                Assert.GreaterOrEqual(0, pinchGesture.Scale, "Should be the default value");
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
        [Description("Test ScreenCenterPoint. Check whether ScreenCenterPoint returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PinchGesture.ScreenCenterPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void ScreenCenterPoint_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                var pinchGesture = new PinchGesture(Gesture.StateType.Started);
                Assert.IsInstanceOf<PinchGesture>(pinchGesture, "Should be an instance of PinchGesture type.");
                Assert.GreaterOrEqual(0, pinchGesture.ScreenCenterPoint.X, "Should be the default value");
                Assert.GreaterOrEqual(0, pinchGesture.ScreenCenterPoint.Y, "Should be the default value");
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
        [Description("Test Speed. Check whether Speed returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PinchGesture.Speed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Speed_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var pinchGesture = new PinchGesture(Gesture.StateType.Started);
                Assert.IsInstanceOf<PinchGesture>(pinchGesture, "Should be an instance of PinchGesture type.");
                Assert.GreaterOrEqual(0, pinchGesture.Speed, "Should be the default value");
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