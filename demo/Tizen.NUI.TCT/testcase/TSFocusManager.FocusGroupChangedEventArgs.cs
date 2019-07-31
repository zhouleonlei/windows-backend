using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.FocusManager.FocusGroupChangedEventArgs Tests")]
    public class FocusGroupChangedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("FocusGroupChangedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a FocusGroupChangedEventArgs object. Check whether FocusGroupChangedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusGroupChangedEventArgs.FocusGroupChangedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void FocusGroupChangedEventArgs_INIT()
        {
            /* TEST CODE */
            var focusGroupChangedEventArgs = new FocusManager.FocusGroupChangedEventArgs();
            Assert.IsNotNull(focusGroupChangedEventArgs, "Can't create success object FocusGroupChangedEventArgs");
            Assert.IsInstanceOf<FocusManager.FocusGroupChangedEventArgs>(focusGroupChangedEventArgs, "Should be an instance of FocusGroupChangedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test CurrentView. Check whether CurrentView is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusGroupChangedEventArgs.CurrentView A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void CurrentView_SET_GET_VALUE()
        {
            /* TEST CODE */
            FocusManager.FocusGroupChangedEventArgs focusGroupChangedEventArgs = new FocusManager.FocusGroupChangedEventArgs();
            View view = new View();
            focusGroupChangedEventArgs.CurrentView = view;
            Assert.AreEqual(view, focusGroupChangedEventArgs.CurrentView, "Retrieved CurrentView should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ForwardDirection. Check whether ForwardDirection is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusGroupChangedEventArgs.ForwardDirection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ForwardDirection_SET_GET_VALUE()
        {
            /* TEST CODE */
            FocusManager.FocusGroupChangedEventArgs focusGroupChangedEventArgs = new FocusManager.FocusGroupChangedEventArgs();
            focusGroupChangedEventArgs.ForwardDirection = true;
            Assert.AreEqual(true, focusGroupChangedEventArgs.ForwardDirection, "Retrieved ForwardDirection should be equal to set value");
        }
    }
}
