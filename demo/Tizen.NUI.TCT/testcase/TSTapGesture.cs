using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.TapGesture Tests")]
    public class TapGestureTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("TapGestureTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a TapGesture object. Check whether TapGesture is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.TapGesture.TapGesture C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void TapGesture_INIT()
        {
            /* TEST CODE */
            var tapGesture = new TapGesture();
            Assert.IsNotNull(tapGesture, "Can't create success object TapGesture");
            Assert.IsInstanceOf<TapGesture>(tapGesture, "Should be an instance of TapGesture type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test LocalPoint. Check whether LocalPoint is readable.")]
        [Property("SPEC", "Tizen.NUI.TapGesture.LocalPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void LocalPoint_GET_VALUE()
        {
            /* TEST CODE */
            try
            {
                var tapGesture = new TapGesture();
                Assert.IsInstanceOf<TapGesture>(tapGesture, "Should be an instance of TapGesture type.");
                Vector2 vector = tapGesture.LocalPoint;
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
        [Description("Test NumberOfTaps. Check whether NumberOfTaps is readable.")]
        [Property("SPEC", "Tizen.NUI.TapGesture.NumberOfTaps A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void NumberOfTaps_GET_VALUE()
        {
            /* TEST CODE */
            try
            {
                var tapGesture = new TapGesture();
                Assert.IsInstanceOf<TapGesture>(tapGesture, "Should be an instance of TapGesture type.");
                uint number = tapGesture.NumberOfTaps;
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
        [Description("Test NumberOfTouches. Check whether NumberOfTouches is readable.")]
        [Property("SPEC", "Tizen.NUI.TapGesture.NumberOfTouches A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void NumberOfTouches_GET_VALUE()
        {
            /* TEST CODE */
            try
            {
                var tapGesture = new TapGesture();
                Assert.IsInstanceOf<TapGesture>(tapGesture, "Should be an instance of TapGesture type.");
                uint number = tapGesture.NumberOfTouches;
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
        [Property("SPEC", "Tizen.NUI.TapGesture.ScreenPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void ScreenPoint_GET_VALUE()
        {
            /* TEST CODE */
            try
            {
                var tapGesture = new TapGesture();
                Assert.IsInstanceOf<TapGesture>(tapGesture, "Should be an instance of TapGesture type.");
                Vector2 vector = tapGesture.ScreenPoint;
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
