using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.BaseHandle.FocusRequestArgs Tests")]
    public class FocusRequestArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("FocusRequestArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a FocusRequestArgs object. Check whether FocusRequestArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.FocusRequestArgs.FocusRequestArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void FocusRequestArgs_INIT()
        {
            /* TEST CODE */
            var focusRequestArgs = new BaseHandle.FocusRequestArgs();
            Assert.IsNotNull(focusRequestArgs, "Can't create success object FocusRequestArgs");
            Assert.IsInstanceOf<BaseHandle.FocusRequestArgs>(focusRequestArgs, "Should be an instance of FocusRequestArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Focus. Check whether Focus is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.FocusRequestArgs.Focus A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void Focus_SET_GET_VALUE()
        {
            /* TEST CODE */
            BaseHandle.FocusRequestArgs focusRequestArgs = new BaseHandle.FocusRequestArgs();
            focusRequestArgs.Focus = true;
            Assert.AreEqual(true, focusRequestArgs.Focus, "Retrieved Focus should be equal to set value");

            focusRequestArgs.Focus = false;
            Assert.AreEqual(false, focusRequestArgs.Focus, "Retrieved Focus should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Result. Check whether Result is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.FocusRequestArgs.Result A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void Result_SET_GET_VALUE()
        {
            /* TEST CODE */
            BaseHandle.FocusRequestArgs focusRequestArgs = new BaseHandle.FocusRequestArgs();
            focusRequestArgs.Result = true;
            Assert.AreEqual(true, focusRequestArgs.Result, "Retrieved Result should be equal to set value");

            focusRequestArgs.Result = false;
            Assert.AreEqual(false, focusRequestArgs.Result, "Retrieved Result should be equal to set value");
        }
    }
}
