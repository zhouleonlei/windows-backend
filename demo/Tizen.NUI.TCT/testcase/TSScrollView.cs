using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;
using System.Threading.Tasks;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.ScrollView Tests")]
    public class ScrollViewTests
    {
        private string TAG = "NUI";
        private bool _flagSnapStarted;

        private void OnSnapStarted(object sender, EventArgs e)
        {
            _flagSnapStarted = true;
        }

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ScrollViewTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali ScrollView constructor test")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ScrollView_INIT()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            Assert.IsInstanceOf<ScrollView>(scrollView, "Should return ScrollView instance.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetScrollSnapAlphaFunction whether GetScrollSnapAlphaFunction returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetScrollSnapAlphaFunction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void GetScrollSnapAlphaFunction_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.SetScrollSnapAlphaFunction(new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseIn));

            AlphaFunction.BuiltinFunctions function = scrollView.GetScrollSnapAlphaFunction().GetBuiltinFunction();

            Assert.AreEqual(function, AlphaFunction.BuiltinFunctions.EaseIn, "Should be equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetScrollSnapAlphaFunction whether SetScrollSnapAlphaFunction returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetScrollSnapAlphaFunction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetScrollSnapAlphaFunction_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.SetScrollSnapAlphaFunction(new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseIn));

            AlphaFunction.BuiltinFunctions function = scrollView.GetScrollSnapAlphaFunction().GetBuiltinFunction();

            Assert.AreEqual(function, AlphaFunction.BuiltinFunctions.EaseIn, "Should be equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetScrollFlickAlphaFunction whether GetScrollFlickAlphaFunction returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetScrollFlickAlphaFunction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void GetScrollFlickAlphaFunction_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.SetScrollFlickAlphaFunction(new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseIn));

            AlphaFunction.BuiltinFunctions function = scrollView.GetScrollFlickAlphaFunction().GetBuiltinFunction();

            Assert.AreEqual(function, AlphaFunction.BuiltinFunctions.EaseIn, "Should be equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetScrollFlickAlphaFunction whether SetScrollFlickAlphaFunction returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetScrollFlickAlphaFunction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetScrollFlickAlphaFunction_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.SetScrollFlickAlphaFunction(new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseIn));

            AlphaFunction.BuiltinFunctions function = scrollView.GetScrollFlickAlphaFunction().GetBuiltinFunction();

            Assert.AreEqual(function, AlphaFunction.BuiltinFunctions.EaseIn, "Should be equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetScrollSnapDuration whether GetScrollSnapDuration returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetScrollSnapDuration M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void GetScrollSnapDuration_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.SetScrollSnapDuration(1.0f);

            float duration = scrollView.GetScrollSnapDuration();

            Assert.AreEqual(1.0f, duration, "Should be equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetScrollSnapDuration whether SetScrollSnapDuration returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetScrollSnapDuration M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetScrollSnapDuration_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.SetScrollSnapDuration(1.0f);

            float duration = scrollView.GetScrollSnapDuration();

            Assert.AreEqual(1.0f, duration, "Should be equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetScrollFlickDuration whether GetScrollFlickDuration returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetScrollFlickDuration M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void GetScrollFlickDuration_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.SetScrollFlickDuration(2.0f);
            float duration = scrollView.GetScrollFlickDuration();
            Assert.AreEqual(2.0f, duration, "Should be equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetScrollFlickDuration whether SetScrollFlickDuration returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetScrollFlickDuration M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetScrollFlickDuration_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.SetScrollFlickDuration(2.0f);
            float duration = scrollView.GetScrollFlickDuration();
            Assert.AreEqual(2.0f, duration, "Should be equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetScrollSensitive whether SetScrollSensitive works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetScrollSensitive M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetScrollSensitive_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                scrollView.SetScrollSensitive(true);
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
        [Description("Test SetMaxOvershoot whether SetMaxOvershoot works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetMaxOvershoot M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetMaxOvershoot_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                scrollView.SetMaxOvershoot(50.0f, 50.0f);
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
        [Description("Test SetSnapOvershootAlphaFunction whether SetSnapOvershootAlphaFunction works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetSnapOvershootAlphaFunction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetSnapOvershootAlphaFunction_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                scrollView.SetSnapOvershootAlphaFunction(new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseIn));
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
        [Description("Test SetSnapOvershootDuration whether SetSnapOvershootDuration works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetSnapOvershootDuration M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetSnapOvershootDuration_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                scrollView.SetSnapOvershootDuration(5.0f);
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
        [Description("Test SetViewAutoSnap whether SetViewAutoSnap works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetViewAutoSnap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetViewAutoSnap_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                scrollView.SetViewAutoSnap(true);
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
        [Description("Test SetWrapMode whether SetWrapMode works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetWrapMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetWrapMode_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                scrollView.SetWrapMode(true);
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
        [Description("Test GetScrollUpdateDistance whether GetScrollUpdateDistance returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetScrollUpdateDistance M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void GetScrollUpdateDistance_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.SetScrollUpdateDistance(10);

            int distance = scrollView.GetScrollUpdateDistance();
            Assert.AreEqual(10, distance, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetScrollUpdateDistance whether SetScrollUpdateDistance works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetScrollUpdateDistance M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetScrollUpdateDistance_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                scrollView.SetScrollUpdateDistance(10);
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
        [Description("Test GetAxisAutoLock whether GetAxisAutoLock returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetAxisAutoLock M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void GetAxisAutoLock_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.SetAxisAutoLock(true);

            bool isAutoLock = scrollView.GetAxisAutoLock();
            Assert.AreEqual(true, isAutoLock, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetAxisAutoLock whether SetAxisAutoLock works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetAxisAutoLock M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetAxisAutoLock_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                scrollView.SetAxisAutoLock(true);
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
        [Description("Test GetAxisAutoLockGradient whether GetAxisAutoLockGradient returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetAxisAutoLockGradient M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void GetAxisAutoLockGradient_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.SetAxisAutoLockGradient(1.0f);

            float gradient = scrollView.GetAxisAutoLockGradient();
            Assert.AreEqual(1.0f, gradient, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetAxisAutoLockGradient whether SetAxisAutoLockGradient works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetAxisAutoLockGradient M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetAxisAutoLockGradient_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                scrollView.SetAxisAutoLockGradient(1.0f);
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
        [Description("Test GetFrictionCoefficient whether GetFrictionCoefficient returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetFrictionCoefficient M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void GetFrictionCoefficient_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.SetFrictionCoefficient(1.0f);

            float coefficient = scrollView.GetFrictionCoefficient();
            Assert.AreEqual(1.0f, coefficient, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetFrictionCoefficient whether SetFrictionCoefficient works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetFrictionCoefficient M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetFrictionCoefficient_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                scrollView.SetFrictionCoefficient(1.0f);
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
        [Description("Test GetFlickSpeedCoefficient whether GetFlickSpeedCoefficient returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetFlickSpeedCoefficient M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void GetFlickSpeedCoefficient_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.SetFlickSpeedCoefficient(0.7f);
            float coefficient = scrollView.GetFlickSpeedCoefficient();
            Assert.Less(Math.Abs(0.7 - coefficient), 0.001f, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetFlickSpeedCoefficient whether SetFlickSpeedCoefficient works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetFlickSpeedCoefficient M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetFlickSpeedCoefficient_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                scrollView.SetFlickSpeedCoefficient(0.7f);
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
        [Description("Test GetMinimumDistanceForFlick whether GetMinimumDistanceForFlick returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetMinimumDistanceForFlick M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void GetMinimumDistanceForFlick_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.SetMinimumDistanceForFlick(new Vector2(30.0f, 15.0f));

            Vector2 distance = scrollView.GetMinimumDistanceForFlick();
            Assert.AreEqual(30.0f, distance.X, "Should be equal!");
            Assert.AreEqual(15.0f, distance.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetMinimumDistanceForFlick whether SetMinimumDistanceForFlick works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetMinimumDistanceForFlick M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetMinimumDistanceForFlick_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                scrollView.SetMinimumDistanceForFlick(new Vector2(30.0f, 15.0f));
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
        [Description("Test GetMinimumSpeedForFlick whether GetMinimumSpeedForFlick returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetMinimumSpeedForFlick M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void GetMinimumSpeedForFlick_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.SetMinimumDistanceForFlick(new Vector2(30.0f, 15.0f));

            Vector2 distance = scrollView.GetMinimumDistanceForFlick();
            Assert.AreEqual(30.0f, distance.X, "Should be equal!");
            Assert.AreEqual(15.0f, distance.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetMinimumSpeedForFlick whether SetMinimumSpeedForFlick works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetMinimumSpeedForFlick M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetMinimumSpeedForFlick_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                scrollView.SetFlickSpeedCoefficient(500);
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
        [Description("Test GetMaxFlickSpeed whether GetMaxFlickSpeed returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetMaxFlickSpeed M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void GetMaxFlickSpeed_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.SetMaxFlickSpeed(500);

            float speed = scrollView.GetMaxFlickSpeed();
            Assert.AreEqual(500, speed, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetMaxFlickSpeed whether SetMaxFlickSpeed works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetMaxFlickSpeed M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetMaxFlickSpeed_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                scrollView.SetMaxFlickSpeed(0.5f);
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
        [Description("Test GetWheelScrollDistanceStep whether GetWheelScrollDistanceStep returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetWheelScrollDistanceStep M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void GetWheelScrollDistanceStep_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.SetWheelScrollDistanceStep(new Vector2(30.0f, 15.0f));

            Vector2 step = scrollView.GetWheelScrollDistanceStep();
            Assert.AreEqual(30.0f, step.X, "Should be equal!");
            Assert.AreEqual(15.0f, step.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetWheelScrollDistanceStep whether SetWheelScrollDistanceStep works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetWheelScrollDistanceStep M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetWheelScrollDistanceStep_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                scrollView.SetWheelScrollDistanceStep(new Vector2(30.0f, 15.0f));
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
        [Description("Test GetCurrentScrollPosition whether GetCurrentScrollPosition returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetCurrentScrollPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void GetCurrentScrollPosition_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            Vector2 position = scrollView.GetCurrentScrollPosition();
            Assert.AreEqual(0.0f, position.X, "Should be equal!");
            Assert.AreEqual(0.0f, position.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetCurrentPage whether GetCurrentPage returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.GetCurrentPage M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void GetCurrentPage_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();

            uint page = scrollView.GetCurrentPage();
            Assert.AreEqual(0, page, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScrollTo whether ScrollTo returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ScrollTo_CHECK_RETURN_VALUE_WITH_VECTOR2()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            Window.Instance.Add(scrollView);

            Vector2 target = new Vector2(0, 0);
            scrollView.ScrollTo(target);
            Vector2 position = scrollView.GetCurrentScrollPosition();
            Assert.AreEqual(0, position.X, "Should be equal!");
            Assert.AreEqual(0, position.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScrollTo whether ScrollTo returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2, Single")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ScrollTo_CHECK_RETURN_VALUE_WITH_VECTOR2_Single()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            Window.Instance.Add(scrollView);

            Vector2 target = new Vector2(0, 0);

            scrollView.ScrollTo(target, 0.0f);
            Vector2 position = scrollView.GetCurrentScrollPosition();
            Assert.AreEqual(0, position.X, "Should be equal!");
            Assert.AreEqual(0, position.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScrollTo whether ScrollTo returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2, Single, AlphaFunction")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ScrollTo_CHECK_RETURN_VALUE_WITH_VECTOR2_Single_ALPHAFUNCTION()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            Window.Instance.Add(scrollView);

            Vector2 target = new Vector2(0, 0);

            scrollView.ScrollTo(target, 0.5f, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            Vector2 position = scrollView.GetCurrentScrollPosition();
            Assert.AreEqual(0, position.X, "Should be equal!");
            Assert.AreEqual(0, position.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScrollTo whether ScrollTo returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2, Single, DirectionBias, DirectionBias")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ScrollTo_CHECK_RETURN_VALUE_WITH_VECTOR2_Single_DIRECTIONBIAS_DIRECTIONBIAS()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            Window.Instance.Add(scrollView);

            Vector2 target = new Vector2(0, 0);

            scrollView.ScrollTo(target, 0.25f, DirectionBias.DirectionBiasLeft, DirectionBias.DirectionBiasLeft);
            Vector2 position = scrollView.GetCurrentScrollPosition();
            Assert.AreEqual(0, position.X, "Should be equal!");
            Assert.AreEqual(0, position.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScrollTo whether ScrollTo returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2, Single, AlphaFunction, DirectionBias, DirectionBias")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ScrollTo_CHECK_RETURN_VALUE_WITH_VECTOR2_Single_ALPHAFUNCTION_DIRECTIONBIAS_DIRECTIONBIAS()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            Window.Instance.Add(scrollView);

            Vector2 target = new Vector2(0, 0);

            scrollView.ScrollTo(target, 0.25f, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear), DirectionBias.DirectionBiasLeft, DirectionBias.DirectionBiasLeft);
            Vector2 position = scrollView.GetCurrentScrollPosition();
            Assert.AreEqual(0, position.X, "Should be equal!");
            Assert.AreEqual(0, position.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScrollTo whether ScrollTo returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "uint")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ScrollTo_CHECK_RETURN_VALUE_WITH_UINT()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            Window.Instance.Add(scrollView);

            scrollView.ScrollTo(0);
            Vector2 position = scrollView.GetCurrentScrollPosition();
            Assert.AreEqual(0.0f, position.X, "Should be equal!");
            Assert.AreEqual(0.0f, position.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScrollTo whether ScrollTo returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "uint, Single")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ScrollTo_CHECK_RETURN_VALUE_WITH_UINT_Single()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            Window.Instance.Add(scrollView);

            scrollView.ScrollTo(0, 0.0f);
            Vector2 position = scrollView.GetCurrentScrollPosition();
            Assert.AreEqual(0, position.X, "Should be equal!");
            Assert.AreEqual(0.0f, position.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScrollTo whether ScrollTo returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "uint, Single, DirectionBias")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ScrollTo_CHECK_RETURN_VALUE_WITH_UINT_Single_DIRECTIONBIAS()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            Window.Instance.Add(scrollView);

            scrollView.ScrollTo(0, 0.0f, DirectionBias.DirectionBiasLeft);
            Vector2 position = scrollView.GetCurrentScrollPosition();
            Assert.AreEqual(0.0f, position.X, "Should be equal!");
            Assert.AreEqual(0.0f, position.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScrollTo whether ScrollTo returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "View")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ScrollTo_CHECK_RETURN_VALUE_WITH_VIEW()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            Window.Instance.Add(scrollView);

            View view = new View();
            view.Position = new Position(0.0f, 0.0f, 0.0f);
            scrollView.Add(view);


            scrollView.ScrollTo(view);
            Vector2 position = scrollView.GetCurrentScrollPosition();
            Assert.AreEqual(0.0f, position.X, "Should be equal!");
            Assert.AreEqual(0.0f, position.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScrollTo whether ScrollTo returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "View, Single")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ScrollTo_CHECK_RETURN_VALUE_WITH_VIEW_Single()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            Window.Instance.Add(scrollView);

            View view = new View();
            view.Position = new Position(0.0f, 0.0f, 0.0f);
            scrollView.Add(view);


            scrollView.ScrollTo(view, 0.0f);
            Vector2 position = scrollView.GetCurrentScrollPosition();
            Assert.AreEqual(0.0f, position.X, "Should be equal!");
            Assert.AreEqual(0.0f, position.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScrollToSnapPoint whether ScrollToSnapPoint returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollToSnapPoint M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ScrollToSnapPoint_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            Window.Instance.Add(scrollView);
            Assert.True(scrollView.ScrollToSnapPoint(), "Should be false!");
        }

        [Test]
        [Category("P1")]
        [Description("Test RemoveAllEffects whether RemoveAllEffects works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.RemoveAllEffects M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void RemoveAllEffects_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                Window.Instance.Add(scrollView);
                scrollView.RemoveAllEffects();
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
        [Description("Test BindView whether BindView returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.BindView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void BindView_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                Window.Instance.Add(scrollView);

                View view = new View();
                view.Position = new Position(100.0f, 100.0f, 0.0f);
                scrollView.Add(view);

                scrollView.BindView(view);
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
        [Description("Test UnbindView whether UnbindView works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.UnbindView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void UnbindView_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                Window.Instance.Add(scrollView);

                View view = new View();
                view.Position = new Position(100.0f, 100.0f, 0.0f);
                scrollView.Add(view);

                scrollView.BindView(view);
                scrollView.UnbindView(view);
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
        [Description("Test SetScrollingDirection whether SetScrollingDirection works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetScrollingDirection M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Radian, Radian")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetScrollingDirection_CHECK_RETURN_VALUE_WITH_RADIAN_RADIAN()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                Window.Instance.Add(scrollView);

                scrollView.SetScrollingDirection(new Radian(3.0f), new Radian(3.0f));
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
        [Description("Test SetScrollingDirection whether SetScrollingDirection works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SetScrollingDirection M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Radian")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SetScrollingDirection_CHECK_RETURN_VALUE_WITH_RADIAN()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                Window.Instance.Add(scrollView);

                scrollView.SetScrollingDirection(new Radian(3.0f));
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
        [Description("Test RemoveScrollingDirection whether RemoveScrollingDirection works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.RemoveScrollingDirection M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void RemoveScrollingDirection_CHECK_RETURN_VALUE_WITH_RADIAN()
        {
            /* TEST CODE */
            try
            {
                var scrollView = new ScrollView();
                Window.Instance.Add(scrollView);
                Radian radian = new Radian(3.0f);

                scrollView.SetScrollingDirection(radian);
                scrollView.RemoveScrollingDirection(radian);
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
        [Description("dali scrollView WrapEnabled test, Check whether WrapEnabled is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.WrapEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void WrapEnabled_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.WrapEnabled = false;
            Assert.AreEqual(false, scrollView.WrapEnabled, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollView PanningEnabled test, Check whether PanningEnabled is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.PanningEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PanningEnabled_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.PanningEnabled = false;
            Assert.AreEqual(false, scrollView.PanningEnabled, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollView AxisAutoLockEnabled test, Check whether AxisAutoLockEnabled is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.AxisAutoLockEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AxisAutoLockEnabled_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.AxisAutoLockEnabled = true;
            Assert.IsTrue(scrollView.AxisAutoLockEnabled, "Should be true!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollView WheelScrollDistanceStep test, Check whether WheelScrollDistanceStep is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.WheelScrollDistanceStep A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void WheelScrollDistanceStep_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            Vector2 step = new Vector2(100.0f, 50.0f);
            scrollView.WheelScrollDistanceStep = step;

            Vector2 value = scrollView.WheelScrollDistanceStep;
            Assert.AreEqual(100.0f, value.X, "Should be equal!");
            Assert.AreEqual(50.0f, value.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollView ScrollPosition test, Check whether ScrollPosition is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ScrollPosition_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.ScrollPosition = new Vector2(320.0f, 550.0f);

            Vector2 value = scrollView.ScrollPosition;
            Assert.AreEqual(320.0f, value.X, "Should be equal!");
            Assert.AreEqual(550.0f, value.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollView ScrollPrePosition test, Check whether ScrollPrePosition is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollPrePosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ScrollPrePosition_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.ScrollPrePosition = new Vector2(300.0f, 500.0f);

            Vector2 value = scrollView.ScrollPrePosition;
            Assert.AreEqual(300.0f, value.X, "Should be equal!");
            Assert.AreEqual(500.0f, value.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollView ScrollPrePositionMax test, Check whether ScrollPrePositionMax is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollPrePositionMax A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ScrollPrePositionMax_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.ScrollPrePositionMax = new Vector2(300.0f, 500.0f);

            Vector2 value = scrollView.ScrollPrePositionMax;
            Assert.AreEqual(300.0f, value.X, "Should be equal!");
            Assert.AreEqual(500.0f, value.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollView OvershootX test, Check whether OvershootX is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.OvershootX A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void OvershootX_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.OvershootX = 0.8f;
            Assert.AreEqual(0.8f, scrollView.OvershootX, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollView OvershootY test, Check whether OvershootY is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.OvershootY A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void OvershootY_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.OvershootY = 0.8f;
            Assert.AreEqual(0.8f, scrollView.OvershootY, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollView ScrollFinal test, Check whether ScrollFinal is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollFinal A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ScrollFinal_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.ScrollFinal = new Vector2(500.0f, 200.0f);
            Assert.AreEqual(500.0f, scrollView.ScrollFinal.Width, "Should be equal!");
            Assert.AreEqual(200.0f, scrollView.ScrollFinal.Height, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollView Wrap test, Check whether Wrap is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Wrap A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void Wrap_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.Wrap = false;
            Assert.AreEqual(false, scrollView.Wrap, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollView Panning test, Check whether Panning is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Panning A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Panning_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.Panning = false;
            Assert.AreEqual(false, scrollView.Panning, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollView Scrolling test, Check whether Scrolling is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Scrolling A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Scrolling_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.Scrolling = false;

            Assert.AreEqual(false, scrollView.Scrolling, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollView ScrollDomainSize test, Check whether ScrollDomainSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollDomainSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ScrollDomainSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.ScrollDomainSize = new Vector2(500.0f, 200.0f);
            Assert.AreEqual(500.0f, scrollView.ScrollDomainSize.Width, "Should be equal!");
            Assert.AreEqual(200.0f, scrollView.ScrollDomainSize.Height, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollView ScrollDomainOffset test, Check whether ScrollDomainOffset is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollDomainOffset A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ScrollDomainOffset_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.ScrollDomainOffset = new Vector2(500.0f, 200.0f);
            Assert.AreEqual(500.0f, scrollView.ScrollDomainOffset.Width, "Should be equal!");
            Assert.AreEqual(200.0f, scrollView.ScrollDomainOffset.Height, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollView ScrollPositionDelta test, Check whether ScrollPositionDelta is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollPositionDelta A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ScrollPositionDelta_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();

            scrollView.ScrollPositionDelta = new Vector2(10.0f, 30.0f);
            Vector2 position = scrollView.ScrollPositionDelta;

            Assert.AreEqual(10, position.X, "Should be equal!");
            Assert.AreEqual(30, position.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollView StartPagePosition test, Check whether StartPagePosition is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.StartPagePosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void StartPagePosition_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            scrollView.StartPagePosition = new Vector3(0, 0, 0);
            Vector3 position = scrollView.StartPagePosition;

            Assert.AreEqual(0, position.X, "Should be equal!");
            Assert.AreEqual(0, position.Y, "Should be equal!");
            Assert.AreEqual(0, position.Z, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollView ScrollMode test, Check whether ScrollMode is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ScrollMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ScrollMode_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollView = new ScrollView();
            PropertyMap map = new PropertyMap();
            map.Add((int)ScrollModeType.XAxisScrollEnabled, new PropertyValue(true));
            scrollView.ScrollMode = map;

            Assert.AreEqual(false, scrollView.Scrolling, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the ScrollBar.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void Dispose_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                ScrollView scrollView = new ScrollView();
                scrollView.Dispose();
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
        [Description("Test ApplyEffect whether works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.ApplyEffect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ApplyEffect_CHECK()
        {
            var scrollView = new ScrollView();
            Assert.IsInstanceOf<ScrollView>(scrollView, "Should be an instance of ScrollView type.");
            Window.Instance.Add(scrollView);
            /* TEST CODE */
            try
            {
                Path path = new Path();
                ScrollViewEffect scrollViewEffect = new ScrollViewPagePathEffect(path, new Vector3(-1.0f, 0, 0), ScrollView.Property.SCROLL_FINAL_X, new Vector3(100.0f, 100.0f, 0.0f), 2);
                scrollView.ApplyEffect(scrollViewEffect);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            finally
            {
                Window.Instance.Remove(scrollView);
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test RemoveEffect whether works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.RemoveEffect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void RemoveEffect_CHECK()
        {
            var scrollView = new ScrollView();
            Assert.IsInstanceOf<ScrollView>(scrollView, "Should be an instance of ScrollView type.");
            Window.Instance.Add(scrollView);
            /* TEST CODE */
            try
            {
                Path path = new Path();
                ScrollViewEffect scrollViewEffect = new ScrollViewPagePathEffect(path, new Vector3(-1.0f, 0, 0), ScrollView.Property.SCROLL_FINAL_X, new Vector3(100.0f, 100.0f, 0.0f), 2);
                scrollView.ApplyEffect(scrollViewEffect);
                scrollView.RemoveEffect(scrollViewEffect);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            finally
            {
                Window.Instance.Remove(scrollView);
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test SnapStarted. Test whether the SnapStarted event will be triggered.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SnapStarted E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public async Task SnapStarted_CHECK_EVENT()
        {
            /*TEST CODE*/
            var scrollView = new ScrollView();
            Assert.IsInstanceOf<ScrollView>(scrollView, "Should be an instance of ScrollView type.");
            scrollView.Size2D = new Size2D(400, 400);
            Window.Instance.Add(scrollView);
            try
            {
                _flagSnapStarted = false;
                Assert.False(_flagSnapStarted, "_flagSnapStarted should false initial");
                scrollView.SnapStarted += OnSnapStarted;
                scrollView.ScrollTo(new Vector2(300, 100), 0.0f);
                await Task.Delay(100);
                Assert.True(_flagSnapStarted, "_flagSnapStarted should be true.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            finally
            {
                scrollView.SnapStarted -= OnSnapStarted;
                Window.Instance.Remove(scrollView);
            }
        }
    }
}
