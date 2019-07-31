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
    [Description("Tizen.NUI.BaseComponents.Scrollable Tests")]
    public class ScrollableTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ScrollableTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }


        private bool _flagScrollStarted, _flagScrollCompleted;
        private void OnScrollStarted(object obj, EventArgs e)
        {
            _flagScrollStarted = true;
        }

        private void OnScrollCompleted(object obj, EventArgs e)
        {
            _flagScrollCompleted = true;
        }

        private void OnScrollUpdated(object obj, EventArgs e)
        { }

        [Test]
        [Category("P1")]
        [Description("dali Scrollable constructor test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.Scrollable C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Scrollable_INIT()
        {
            /* TEST CODE */
            var scrollable = new ScrollView();
            Assert.NotNull(scrollable, "Should be not null.");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollable CanScrollHorizontal test, Check whether CanScrollHorizontal is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.CanScrollHorizontal A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void CanScrollHorizontal_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollable = new ScrollView();
            scrollable.CanScrollHorizontal = true;
            Assert.IsTrue(scrollable.CanScrollHorizontal, "Should be true!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollable CanScrollVertical test, Check whether CanScrollVertical is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.CanScrollVertical A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void CanScrollVertical_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollable = new ScrollView();
            scrollable.CanScrollVertical = true;
            Assert.IsTrue(scrollable.CanScrollVertical, "Should be true!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollable OvershootAnimationSpeed test, Check whether OvershootAnimationSpeed is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.OvershootAnimationSpeed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void OvershootAnimationSpeed_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollable = new ScrollView();
            scrollable.OvershootAnimationSpeed = 55.0f;
            Assert.AreEqual(55.0f, scrollable.OvershootAnimationSpeed, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollable OvershootEffectColor test, Check whether OvershootEffectColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.OvershootEffectColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void OvershootEffectColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollable = new ScrollView();
            scrollable.OvershootEffectColor = new Color(1.0f, 0.0f, 1.0f, 1.0f);
            Assert.AreEqual(1.0f, scrollable.OvershootEffectColor.R, "Should be equal!");
            Assert.AreEqual(0.0f, scrollable.OvershootEffectColor.G, "Should be equal!");
            Assert.AreEqual(1.0f, scrollable.OvershootEffectColor.B, "Should be equal!");
            Assert.AreEqual(1.0f, scrollable.OvershootEffectColor.A, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollable OvershootEnabled test, Check whether OvershootEnabled is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.OvershootEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void OvershootEnabled_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollable = new ScrollView();
            scrollable.OvershootEnabled = false;
            Assert.IsFalse(scrollable.OvershootEnabled, "Should be false!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollable OvershootSize test, Check whether OvershootSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.OvershootSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void OvershootSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollable = new ScrollView();
            scrollable.OvershootSize = new Size2D(100, 100);

            Assert.AreEqual(100, scrollable.OvershootSize.Width, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollable ScrollPositionMax test, Check whether ScrollPositionMax is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.ScrollPositionMax A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ScrollPositionMax_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollable = new ScrollView();
            scrollable.ScrollPositionMax = new Vector2(100, 100);
            Assert.AreEqual(100, scrollable.ScrollPositionMax.X, "Should be equal!");
            Assert.AreEqual(100, scrollable.ScrollPositionMax.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollable ScrollPositionMin test, Check whether ScrollPositionMin is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.ScrollPositionMin A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ScrollPositionMin_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollable = new ScrollView();
            scrollable.ScrollPositionMin = new Vector2(0, 0);
            Assert.AreEqual(0, scrollable.ScrollPositionMin.X, "Should be equal!");
            Assert.AreEqual(0, scrollable.ScrollPositionMin.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollable ScrollRelativePosition test, Check whether ScrollRelativePosition is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.ScrollRelativePosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ScrollRelativePosition_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollable = new ScrollView();
            scrollable.ScrollRelativePosition = new Vector2(2, 4);
            Assert.AreEqual(2, scrollable.ScrollRelativePosition.X, "Should be equal!");
            Assert.AreEqual(4, scrollable.ScrollRelativePosition.Y, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali scrollable ScrollToAlphaFunction test, Check whether ScrollToAlphaFunction is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.ScrollToAlphaFunction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ScrollToAlphaFunction_SET_GET_VALUE()
        {
            /* TEST CODE */
            var scrollable = new ScrollView();
            scrollable.ScrollToAlphaFunction = 0;
            Assert.AreEqual(0, scrollable.ScrollToAlphaFunction, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Scroll ScrollStarted. Check whether the ScrollStarted event triggered when the scroll start")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.ScrollStarted E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Junqing Ma, junqing.ma@samsung.com")]
        public void ScrollStarted_CHECK_EVENT()
        {
            /* TEST CODE */
            var scrollable = new ScrollView();
            Assert.IsInstanceOf<ScrollView>(scrollable, "Should be a intance of ScrollView type");
            _flagScrollStarted = false;
            Assert.False(_flagScrollStarted, "_flagScrollStarted should false initial");
            scrollable.ScrollStarted += OnScrollStarted;

            scrollable.ScrollDomainSize = new Vector2(1000.0f, 1000.0f);
            scrollable.ScrollTo(new Vector2(100.0f, 100.0f), 1.0f);

            Assert.IsTrue(_flagScrollStarted, "The ScrollStarted Event is not triggered!");
            scrollable.ScrollStarted -= OnScrollStarted;
        }

        [Test]
        [Category("P1")]
        [Description("Test Scroll ScrollCompleted. Check whether the ScrollCompleted event triggered when the scroll complete")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.ScrollCompleted E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Junqing Ma, junqing.ma@samsung.com")]
        public async Task ScrollCompleted_CHECK_EVENT()
        {
            /* TEST CODE */
            var scrollable = new ScrollView();
            Assert.IsInstanceOf<ScrollView>(scrollable, "Should be a intance of ScrollView type");
            Assert.IsNotNull(scrollable, "Shouldn't be null");
            _flagScrollCompleted = false;
            Assert.False(_flagScrollCompleted, "_flagScrollCompleted should false initial");
            scrollable.ScrollCompleted += OnScrollCompleted;

            scrollable.ScrollDomainSize = new Vector2(1000.0f, 1000.0f);
            scrollable.ScrollTo(new Vector2(100.0f, 100.0f), 0.05f);
            await Task.Delay(100);

            Assert.IsTrue(_flagScrollCompleted, "The ScrollCompleted Event is not triggered!");
            scrollable.ScrollCompleted -= OnScrollCompleted;
        }

        [Test]
        [Category("P1")]
        [Description("Test Scroll ScrollUpdated. Check whether the ScrollUpdated event triggered when the scroll complete")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Scrollable.ScrollUpdated E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ScrollUpdated_CHECK_EVENT()
        {
            /* TEST CODE */
            var scrollable = new ScrollView();
            Assert.IsInstanceOf<ScrollView>(scrollable, "Should be a intance of ScrollView type");
            try
            {
                scrollable.ScrollUpdated += OnScrollUpdated;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            finally
            {
                scrollable.ScrollUpdated -= OnScrollUpdated;
            }
        }
    }
}
