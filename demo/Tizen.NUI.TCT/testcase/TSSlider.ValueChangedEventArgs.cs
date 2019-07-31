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
    [Description("Tizen.NUI.UIComponents.Slider.ValueChangedEventArgs Tests")]
    public class ValueChangedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ValueChangedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Test ValueChangedEventArgs. Check Slider Value Event Arguments.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.ValueChangedEventArgs.ValueChangedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void ValueChangedEventArgs_INIT()
        {
            Slider.ValueChangedEventArgs eventArgs = new Slider.ValueChangedEventArgs();
            Assert.IsInstanceOf<Slider.ValueChangedEventArgs>(eventArgs, "ValueChangeEventsArgs construct fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Update Slider Change in Event Arguments.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.ValueChangedEventArgs.Slider A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void Slider_SET_GET_VALUE()
        {
            Slider.ValueChangedEventArgs eventArgs = new Slider.ValueChangedEventArgs();
            Slider slider = new Slider();
            slider.Name = "test slider";
            eventArgs.Slider = slider;
            Assert.AreEqual("test slider", eventArgs.Slider.Name, "ValueChangedEventArgs Slider Test Error");
        }

        [Test]
        [Category("P1")]
        [Description("Update Slider Value Change in Event Arguments.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.ValueChangedEventArgs.SlideValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void SlideValue_SET_GET_VALUE()
        {
            Slider.ValueChangedEventArgs eventArgs = new Slider.ValueChangedEventArgs();
            eventArgs.SlideValue = 100.0f;
            Assert.AreEqual(100.0f, eventArgs.SlideValue, "ValueChangedEventArgs Slide Value Test Error");
        }
    }
}
