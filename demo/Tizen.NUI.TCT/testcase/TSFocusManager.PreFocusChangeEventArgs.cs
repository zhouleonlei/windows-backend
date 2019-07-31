using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.FocusManager.PreFocusChangeEventArgs Tests")]
    public class PreFocusChangeEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("PreFocusChangeEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a PreFocusChangeEventArgs object. Check whether PreFocusChangeEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.PreFocusChangeEventArgs.PreFocusChangeEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void PreFocusChangeEventArgs_INIT()
        {
            /* TEST CODE */
            var preFocusChangeEventArgs = new FocusManager.PreFocusChangeEventArgs();
            Assert.IsNotNull(preFocusChangeEventArgs, "Can't create success object PreFocusChangedArgs");
            Assert.IsInstanceOf<FocusManager.PreFocusChangeEventArgs>(preFocusChangeEventArgs, "Should be an instance of PreFocusChangeEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test CurrentView. Check whether CurrentView is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.PreFocusChangeEventArgs.CurrentView A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void CurrentView_SET_GET_VALUE()
        {
            /* TEST CODE */
            FocusManager.PreFocusChangeEventArgs preFocusChangeEventArgs = new FocusManager.PreFocusChangeEventArgs();
            View view = new View();
            preFocusChangeEventArgs.CurrentView = view;
            Assert.AreEqual(view, preFocusChangeEventArgs.CurrentView, "Retrieved CurrentView should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ProposedView. Check whether ProposedView is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.PreFocusChangeEventArgs.ProposedView A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ProposedView_SET_GET_VALUE()
        {
            /* TEST CODE */
            FocusManager.PreFocusChangeEventArgs preFocusChangeEventArgs = new FocusManager.PreFocusChangeEventArgs();
            View view = new View();
            preFocusChangeEventArgs.ProposedView = view;
            Assert.AreEqual(view, preFocusChangeEventArgs.ProposedView, "Retrieved ProposedView should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Direction. Check whether Direction is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.PreFocusChangeEventArgs.Direction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Direction_SET_GET_VALUE()
        {
            /* TEST CODE */
            FocusManager.PreFocusChangeEventArgs preFocusChangeEventArgs = new FocusManager.PreFocusChangeEventArgs();
            View view = new View();
            preFocusChangeEventArgs.Direction = View.FocusDirection.Down;
            Assert.AreEqual(View.FocusDirection.Down, preFocusChangeEventArgs.Direction, "Retrieved Direction should be equal to set value");
        }
    }
}
