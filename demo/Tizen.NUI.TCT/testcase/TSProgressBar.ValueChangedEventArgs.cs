using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using System.Threading.Tasks;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.UIComponents.ProgressBar.ValueChangedEventArgs Tests")]
    public class ProgressBarValueChangedEventArgsTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

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
        [Description("dali ProgressBar.ValueChangedEventArgs constructor test")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ProgressBar.ValueChangedEventArgs.ValueChangedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ValueChangedEventArgs_INIT()
        {
            /* TEST CODE */
            var valueChangedEventArgs = new ProgressBar.ValueChangedEventArgs();
            Assert.IsInstanceOf<ProgressBar.ValueChangedEventArgs>(valueChangedEventArgs, "Should return ProgressBar.ValueChangedEventArgs instance.");
        }

        [Test]
        [Category("P1")]
        [Description("Test View. Check whether View is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ProgressBar.ValueChangedEventArgs.ProgressBar A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ProgressBar_SET_GET_VALUE()
        {
            /* TEST CODE */
            ProgressBar.ValueChangedEventArgs valueChangedEventArgs = new ProgressBar.ValueChangedEventArgs();
            ProgressBar progressBar = new ProgressBar();
            valueChangedEventArgs.ProgressBar = progressBar;
            Assert.AreEqual(progressBar, valueChangedEventArgs.ProgressBar, "Retrieved ProgressBar should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ProgressValue. Check whether ProgressValue is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ProgressBar.ValueChangedEventArgs.ProgressValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ProgressValue_SET_GET_VALUE()
        {
            /* TEST CODE */
            ProgressBar.ValueChangedEventArgs valueChangedEventArgs = new ProgressBar.ValueChangedEventArgs();
            ProgressBar progressBar = new ProgressBar();
            valueChangedEventArgs.ProgressBar = progressBar;
            valueChangedEventArgs.ProgressBar.ProgressValue = 0.5f;
            Assert.AreEqual(0.5f, valueChangedEventArgs.ProgressBar.ProgressValue, "Retrieved ProgressValue should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SecondaryProgressValue. Check whether SecondaryProgressValue is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ProgressBar.ValueChangedEventArgs.SecondaryProgressValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SecondaryProgressValue_SET_GET_VALUE()
        {
            /* TEST CODE */
            ProgressBar.ValueChangedEventArgs valueChangedEventArgs = new ProgressBar.ValueChangedEventArgs();
            ProgressBar progressBar = new ProgressBar();
            valueChangedEventArgs.ProgressBar = progressBar;
            valueChangedEventArgs.ProgressBar.SecondaryProgressValue = 0.5f;
            Assert.AreEqual(0.5f, valueChangedEventArgs.ProgressBar.SecondaryProgressValue, "Retrieved SecondaryProgressValue should be equal to set value");
        }
    }
}