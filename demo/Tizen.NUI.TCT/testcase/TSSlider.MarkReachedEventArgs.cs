using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using System.Threading;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.UIComponents.Slider.ValueChangedEventArgs Tests")]
    public class MarkReachedEventArgsTests
    {
        [SetUp]
        public void Init()
        {

        }

        [TearDown]
        public void Destroy()
        {

        }

        [Test]
        [Category("P1")]
        [Description("Test MarkReachedEventArgs. Check Mark Reached Event Arguments .")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.MarkReachedEventArgs.MarkReachedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void MarkReachedEventArgs_INIT()
        {
            var eventArgs = new Slider.MarkReachedEventArgs();
            Assert.IsInstanceOf<Slider.MarkReachedEventArgs>(eventArgs, "MarkReachedEventArgs construct fail.");

        }

        [Test]
        [Category("P1")]
        [Description("Update Slider in Mark Reached Event Arguments.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.MarkReachedEventArgs.Slider A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void Slider_SET_GET_VALUE()
        {
            Slider.MarkReachedEventArgs eventArgs = new Slider.MarkReachedEventArgs();
            Slider slider = new Slider();
            slider.Name = "test slider";
            eventArgs.Slider = slider;
            Assert.AreEqual("test slider", eventArgs.Slider.Name, "MarkReachedEventArgs Slider Test Error");
        }

        [Test]
        [Category("P1")]
        [Description("Update Slide Value in Mark Reached Event Arguments.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.MarkReachedEventArgs.SlideValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void SlideValue_SET_GET_VALUE()
        {
            Slider.MarkReachedEventArgs eventArgs = new Slider.MarkReachedEventArgs();
            eventArgs.SlideValue = 2;
            Assert.AreEqual(2, eventArgs.SlideValue, "MarkReachedEventArgs Slide Value Test Error");
        }

    }



}

