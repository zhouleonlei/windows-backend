using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;
using Tizen.NUI.Test;
using System.Threading.Tasks;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.UIComponents.ScrollBar Tests")]
    public class ScrollBarTests
    {
        private string TAG = "NUI";
        private bool _flagScrollInterval;

        private void OnScrollInterval(object sender, EventArgs e)
        {
            _flagScrollInterval = true;
        }

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ScrollBarTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a ScrollBar object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ScrollBar.ScrollBar C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ScrollBar_INIT()
        {
            /* TEST CODE */
            var scrollBar = new ScrollBar();
            Assert.IsNotNull(scrollBar, "Can't create success object ScrollBar");
            Assert.IsInstanceOf<ScrollBar>(scrollBar, "Should be an instance of ScrollBar type.");
        }

        [Test]
        [Category("P1")]
        [Description("Create a ScrollBar object. Check whether ScrollBar object which set direction is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ScrollBar.ScrollBar C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Direction")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ScrollBar_INIT_WITH_DIRECTION()
        {
            /* TEST CODE */
            var scrollBar = new ScrollBar(ScrollBar.Direction.Horizontal);
            Assert.IsNotNull(scrollBar, "Can't create success object ScrollBar");
            Assert.IsInstanceOf<ScrollBar>(scrollBar, "Should be an instance of ScrollBar type.");
            Assert.AreEqual(ScrollBar.Direction.Horizontal, scrollBar.ScrollDirection, "Should be equals to the set value of ScrollDirection.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScrollDirection.Check whether ScrollDirection is readable ahd writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ScrollBar.ScrollDirection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ScrollDirection_SET_GET_VALUE()
        {
            /* TEST CODE */
            ScrollBar scrollBar = new ScrollBar();
            scrollBar.ScrollDirection = ScrollBar.Direction.Vertical;
            Assert.AreEqual(ScrollBar.Direction.Vertical, scrollBar.ScrollDirection, "Should be equals to the set value of ScrollDirection.");
        }

        [Test]
        [Category("P1")]
        [Description("Test IndicatorHeightPolicy.Check whether IndicatorHeightPolicy is readable ahd writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ScrollBar.IndicatorHeightPolicy A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void IndicatorHeightPolicy_SET_GET_VALUE()
        {
            /* TEST CODE */
            ScrollBar scrollBar = new ScrollBar();
            scrollBar.IndicatorHeightPolicy = ScrollBar.IndicatorHeightPolicyType.Fixed;
            Assert.AreEqual(ScrollBar.IndicatorHeightPolicyType.Fixed, scrollBar.IndicatorHeightPolicy, "Should be equals to the set value of IndicatorHeightPolicy");
        }

        [Test]
        [Category("P1")]
        [Description("Test IndicatorFixedHeight.Check whether IndicatorFixedHeight is readable ahd writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ScrollBar.IndicatorFixedHeight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void IndicatorFixedHeight_SET_GET_VALUE()
        {
            /* TEST CODE */
            ScrollBar scrollBar = new ScrollBar();
            scrollBar.IndicatorFixedHeight = 1.0f;
            Assert.AreEqual(1.0f, scrollBar.IndicatorFixedHeight, "Should be equals to the set value of IndicatorFixedHeight");
        }

        [Test]
        [Category("P1")]
        [Description("Test IndicatorShowDuration.Check whether IndicatorShowDuration is readable ahd writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ScrollBar.IndicatorShowDuration A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void IndicatorShowDuration_SET_GET_VALUE()
        {
            /* TEST CODE */
            ScrollBar scrollBar = new ScrollBar();
            scrollBar.IndicatorShowDuration = 1.0f;
            Assert.AreEqual(1.0f, scrollBar.IndicatorShowDuration, "Should be equals to the set value of IndicatorShowDuration");
        }

        [Test]
        [Category("P1")]
        [Description("Test IndicatorHideDuration.Check whether IndicatorHideDuration is readable ahd writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ScrollBar.IndicatorHideDuration A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void IndicatorHideDuration_SET_GET_VALUE()
        {
            /* TEST CODE */
            ScrollBar scrollBar = new ScrollBar();
            scrollBar.IndicatorHideDuration = 1.0f;
            Assert.AreEqual(1.0f, scrollBar.IndicatorHideDuration, "Should be equals to the set value of IndicatorHideDuration");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScrollPositionIntervals.Check whether ScrollPositionIntervals is readable ahd writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ScrollBar.ScrollPositionIntervals A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ScrollPositionIntervals_SET_GET_VALUE()
        {
            /* TEST CODE */
            ScrollBar scrollBar = new ScrollBar(ScrollBar.Direction.Vertical);
            Window.Instance.GetDefaultLayer().Add(scrollBar);
            PropertyArray array = new PropertyArray();
            for (uint i = 0; i < 10; i++)
            {
                array.Add(new PropertyValue(-80.0f * i));
            }
            scrollBar.ScrollPositionIntervals = array;
        }

        [Test]
        [Category("P1")]
        [Description("Test IndicatorMinimumHeight.Check whether IndicatorMinimumHeight is readable ahd writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ScrollBar.IndicatorMinimumHeight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void IndicatorMinimumHeight_SET_GET_VALUE()
        {
            /* TEST CODE */
            ScrollBar scrollBar = new ScrollBar();
            scrollBar.IndicatorMinimumHeight = 1.0f;
            Assert.AreEqual(1.0f, scrollBar.IndicatorMinimumHeight, "Should be equals to the set value of IndicatorMinimumHeight");
        }

        [Test]
        [Category("P1")]
        [Description("Test IndicatorStartPadding.Check whether IndicatorStartPadding is readable ahd writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ScrollBar.IndicatorStartPadding A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void IndicatorStartPadding_SET_GET_VALUE()
        {
            /* TEST CODE */
            ScrollBar scrollBar = new ScrollBar();
            scrollBar.IndicatorStartPadding = 1.0f;
            Assert.AreEqual(1.0f, scrollBar.IndicatorStartPadding, "Should be equals to the set value of IndicatorStartPadding");
        }

        [Test]
        [Category("P1")]
        [Description("Test IndicatorEndPadding.Check whether IndicatorEndPadding is readable ahd writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ScrollBar.IndicatorEndPadding A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void IndicatorEndPadding_SET_GET_VALUE()
        {
            /* TEST CODE */
            ScrollBar scrollBar = new ScrollBar();
            scrollBar.IndicatorEndPadding = 1.0f;
            Assert.AreEqual(1.0f, scrollBar.IndicatorEndPadding, "Should be equals to the set value of IndicatorEndPadding");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the ScrollBar.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ScrollBar.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            try
            {
                ScrollBar scrollBar = new ScrollBar();
                scrollBar.Dispose();
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
        [Description("Test ScrollInterval. Test whether the ScrollInterval event will be triggered.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ScrollBar.ScrollInterval E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public async Task ScrollInterval_CHECK_EVENT()
        {
            /*TEST CODE*/
            var scrollBar = new ScrollBar();
            Assert.IsInstanceOf<ScrollBar>(scrollBar, "Should be an instance of ScrollBar type.");
            Window.Instance.Add(scrollBar);
            View sourceView = new View();
            Assert.IsInstanceOf<View>(sourceView, "Should be an instance of View type.");
            Window.Instance.Add(sourceView);
            try
            {
                _flagScrollInterval = false;
                Assert.False(_flagScrollInterval, "_flagScrollInterval should false initial");
                scrollBar.ScrollInterval += OnScrollInterval;
                int propertyScrollPosition = sourceView.RegisterProperty("sourcePosition", new PropertyValue(0.0f));
                int propertyMinScrollPosition = sourceView.RegisterProperty("sourcePositionMin", new PropertyValue(0.0f));
                int propertyMaxScrollPosition = sourceView.RegisterProperty("sourcePositionMax", new PropertyValue(800.0f));
                int propertyScrollContentSize = sourceView.RegisterProperty("sourceContentSize", new PropertyValue(2000.0f));
                scrollBar.SetScrollPropertySource(sourceView, propertyScrollPosition, propertyMinScrollPosition, propertyMaxScrollPosition, propertyScrollContentSize);
                PropertyArray positionIntervals = new PropertyArray();
                for (int i = 0; i != 10; ++i)
                {
                    positionIntervals.PushBack(new PropertyValue(-80.0f * i)); // should get notified for each 80 pixels
                }
                scrollBar.ScrollPositionIntervals = (positionIntervals);
                Animation animation = new Animation(100);
                animation.AnimateTo(sourceView, "sourcePosition", -170.0f);
                animation.Play();

                await Task.Delay(110);
                Assert.True(_flagScrollInterval, "_flagScrollInterval should be true.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            finally
            {
                scrollBar.ScrollInterval -= OnScrollInterval;
                Window.Instance.Remove(scrollBar);
                Window.Instance.Remove(sourceView);
            }
        }
    }
}
