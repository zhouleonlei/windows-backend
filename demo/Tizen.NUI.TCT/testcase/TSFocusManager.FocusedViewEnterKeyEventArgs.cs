using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.FocusManager.FocusedViewEnterKeyEventArgs Tests")]
    public class FocusedViewEnterKeyEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("FocusedViewEnterKeyEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a FocusedViewEnterKeyEventArgs object. Check whether FocusedViewEnterKeyEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusedViewEnterKeyEventArgs.FocusedViewEnterKeyEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void FocusedViewEnterKeyEventArgs_INIT()
        {
            /* TEST CODE */
            var focusedViewEnterKeyEventArgs = new FocusManager.FocusedViewEnterKeyEventArgs();
            Assert.IsNotNull(focusedViewEnterKeyEventArgs, "Can't create success object FocusedViewEnterKeyEventArgs");
            Assert.IsInstanceOf<FocusManager.FocusedViewEnterKeyEventArgs>(focusedViewEnterKeyEventArgs, "Should be an instance of FocusedViewEnterKeyEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test View. Check whether View is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusedViewEnterKeyEventArgs.View A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void View_SET_GET_VALUE()
        {
            /* TEST CODE */
            FocusManager.FocusedViewEnterKeyEventArgs focusedViewEnterKeyEventArgs = new FocusManager.FocusedViewEnterKeyEventArgs();
            View view = new View();
            focusedViewEnterKeyEventArgs.View = view;
            Assert.AreEqual(view, focusedViewEnterKeyEventArgs.View, "Retrieved View should be equal to set value");
        }
    }
}
