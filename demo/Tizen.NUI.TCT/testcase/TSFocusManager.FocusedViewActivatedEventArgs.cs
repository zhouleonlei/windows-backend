using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.FocusManager.FocusedViewActivatedEventArgs Tests")]
    public class FocusedViewActivatedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("FocusedViewActivatedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a FocusedViewActivatedEventArgs object. Check whether FocusedViewActivatedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusedViewActivatedEventArgs.FocusedViewActivatedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void FocusedViewActivatedEventArgs_INIT()
        {
            /* TEST CODE */
            var focusedViewActivatedEventArgs = new FocusManager.FocusedViewActivatedEventArgs();
            Assert.IsNotNull(focusedViewActivatedEventArgs, "Can't create success object FocusedViewActivatedEventArgs");
            Assert.IsInstanceOf<FocusManager.FocusedViewActivatedEventArgs>(focusedViewActivatedEventArgs, "Should be an instance of FocusedViewActivatedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test View. Check whether View is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusedViewActivatedEventArgs.View A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Feng Jin, youxia.wu@partner.samsung.com")]
        public void View_SET_GET_VALUE()
        {
            /* TEST CODE */
            FocusManager.FocusedViewActivatedEventArgs focusedViewActivatedEventArgs = new FocusManager.FocusedViewActivatedEventArgs();
            View view = new View();
            focusedViewActivatedEventArgs.View = view;
            Assert.AreEqual(view, focusedViewActivatedEventArgs.View, "Retrieved View should be equal to set value");
        }
    }
}
