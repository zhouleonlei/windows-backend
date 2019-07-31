using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.PanGesture Tests")]
    public class PanGestureTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("PanGestureTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a PanGesture object. Check whether PanGesture is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.PanGesture C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PanGesture_INIT()
        {
            /* TEST CODE */
            var panGesture = new PanGesture();
            Assert.IsNotNull(panGesture, "Can't create success object PanGesture");
            Assert.IsInstanceOf<PanGesture>(panGesture, "Should be an instance of PanGesture type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetDistance. Check whether GetDistance returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.GetDistance M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetDistance_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var panGesture = new PanGesture();
                Assert.IsInstanceOf<PanGesture>(panGesture, "Should be an instance of PanGesture type.");
                float distance = panGesture.GetDistance();
                Assert.AreEqual(0, distance, "Should be the default value");
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
        [Description("Test GetScreenDistance. Check whether GetScreenDistance returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.GetScreenDistance M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetScreenDistance_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var panGesture = new PanGesture();
                Assert.IsInstanceOf<PanGesture>(panGesture, "Should be an instance of PanGesture type.");
                float distance = panGesture.GetScreenDistance();
                Assert.AreEqual(0, distance, "Should be the default value");
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
        [Description("Test GetScreenSpeed. Check whether GetScreenSpeed returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.GetScreenSpeed M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetScreenSpeed_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var panGesture = new PanGesture();
                Assert.IsInstanceOf<PanGesture>(panGesture, "Should be an instance of PanGesture type.");
                float speed = panGesture.GetScreenSpeed();
                Assert.AreEqual(0, speed, "Should be the default value");
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
        [Description("Test GetSpeed. Check whether GetSpeed returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.GetSpeed M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetSpeed_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var panGesture = new PanGesture();
                Assert.IsInstanceOf<PanGesture>(panGesture, "Should be an instance of PanGesture type.");
                float speed = panGesture.GetSpeed();
                Assert.AreEqual(0, speed, "Should be the default value");
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
        [Description("Test Displacement. Check whether Displacement is readable.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.Displacement A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Displacement_GET_VALUE()
        {
            /* TEST CODE */
            try
            {
                var panGesture = new PanGesture();
                Assert.IsInstanceOf<PanGesture>(panGesture, "Should be an instance of PanGesture type.");
                Vector2 vector = panGesture.Displacement;
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
        [Property("SPEC", "Tizen.NUI.PanGesture.NumberOfTouches A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void NumberOfTouches_GET_VALUE()
        {
            /* TEST CODE */
            try
            {
                var panGesture = new PanGesture();
                Assert.IsInstanceOf<PanGesture>(panGesture, "Should be an instance of PanGesture type.");
                uint number = panGesture.NumberOfTouches;
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
        [Description("Test Position. Check whether Position is readable.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.Position A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Position_GET_VALUE()
        {
            /* TEST CODE */
            try
            {
                var panGesture = new PanGesture();
                Assert.IsInstanceOf<PanGesture>(panGesture, "Should be an instance of PanGesture type.");
                Vector2 vector = panGesture.Position;
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
        [Description("Test ScreenDisplacement. Check whether ScreenDisplacement is readable.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.ScreenDisplacement A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void ScreenDisplacement_GET_VALUE()
        {
            /* TEST CODE */
            try
            {
                var panGesture = new PanGesture();
                Assert.IsInstanceOf<PanGesture>(panGesture, "Should be an instance of PanGesture type.");
                Vector2 vector = panGesture.ScreenDisplacement;
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
        [Description("Test ScreenPosition. Check whether ScreenPosition is readable.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.ScreenPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void ScreenPosition_GET_VALUE()
        {
            /* TEST CODE */
            try
            {
                var panGesture = new PanGesture();
                Assert.IsInstanceOf<PanGesture>(panGesture, "Should be an instance of PanGesture type.");
                Vector2 vector = panGesture.ScreenPosition;
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
        [Description("Test ScreenVelocity. Check whether ScreenVelocity is readable.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.ScreenVelocity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void ScreenVelocity_GET_VALUE()
        {
            /* TEST CODE */
            try
            {
                var panGesture = new PanGesture();
                Assert.IsInstanceOf<PanGesture>(panGesture, "Should be an instance of PanGesture type.");
                Vector2 vector = panGesture.ScreenVelocity;
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
        [Description("Test Velocity. Check whether Velocity is readable.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.Velocity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Velocity_GET_VALUE()
        {
            /* TEST CODE */
            try
            {
                var panGesture = new PanGesture();
                Assert.IsInstanceOf<PanGesture>(panGesture, "Should be an instance of PanGesture type.");
                Vector2 vector = panGesture.Velocity;
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
