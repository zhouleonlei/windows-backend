using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using System.Threading;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.UIComponents.Slider.SlidingFinishedEventArgs Tests")]
    public class SlidingFinishedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("SlidingFinishedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Test SlidingFinishedEventArgs. Check Slider Finished Event Arguments.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.SlidingFinishedEventArgs.SlidingFinishedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void SlidingFinishedEventArgs_INIT()
        {
            var eventArgs = new Slider.SlidingFinishedEventArgs();
            Assert.IsInstanceOf<Slider.SlidingFinishedEventArgs>(eventArgs, "SlidingFinishedEventArgs construct fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Update Slider Change in Sliding Finished Event Arguments.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.SlidingFinishedEventArgs.Slider A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void Slider_SET_GET_VALUE()
        {
            Slider.SlidingFinishedEventArgs eventArgs = new Slider.SlidingFinishedEventArgs();
            Slider slider = new Slider();
            slider.Name = "test slider";
            eventArgs.Slider = slider;
            Assert.AreEqual("test slider", eventArgs.Slider.Name, "SlidingFinishedEventArgs Slider Test Error");
        }

        [Test]
        [Category("P1")]
        [Description("Update Slider Value Change in Sliding Finished  Event Arguments.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.SlidingFinishedEventArgs.SlideValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void SlideValue_SET_GET_VALUE()
        {
            Slider.SlidingFinishedEventArgs eventArgs = new Slider.SlidingFinishedEventArgs();
            eventArgs.SlideValue = 100.0f;
            Assert.AreEqual(100.0f, eventArgs.SlideValue, "SlidingFinishedEventArgs Slide Value Test Error");
        }
    }
}

