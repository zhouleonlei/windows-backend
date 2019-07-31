using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.FocusManager.FocusChangedEventArgs Tests")]
    public class FocusChangedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("FocusChangedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a FocusChangedEventArgs object. Check whether FocusChangedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusChangedEventArgs.FocusChangedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void FocusChangedEventArgs_INIT()
        {
            /* TEST CODE */
            var focusChangedEventArgs = new FocusManager.FocusChangedEventArgs();
            Assert.IsNotNull(focusChangedEventArgs, "Can't create success object FocusChangedEventArgs");
            Assert.IsInstanceOf<FocusManager.FocusChangedEventArgs>(focusChangedEventArgs, "Should be an instance of FocusChangedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test CurrentView. Check whether CurrentView is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusChangedEventArgs.CurrentView A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void CurrentView_SET_GET_VALUE()
        {
            /* TEST CODE */
            FocusManager.FocusChangedEventArgs focusChangedEventArgs = new FocusManager.FocusChangedEventArgs();
            View view = new View();
            focusChangedEventArgs.CurrentView = view;
            Assert.AreEqual(view, focusChangedEventArgs.CurrentView, "Retrieved CurrentView should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test NextView. Check whether NextView is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusChangedEventArgs.NextView A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void NextView_SET_GET_VALUE()
        {
            /* TEST CODE */
            FocusManager.FocusChangedEventArgs focusChangedEventArgs = new FocusManager.FocusChangedEventArgs();
            View view = new View();
            focusChangedEventArgs.NextView = view;
            Assert.AreEqual(view, focusChangedEventArgs.NextView, "Retrieved NextView should be equal to set value");
        }
    }
}
