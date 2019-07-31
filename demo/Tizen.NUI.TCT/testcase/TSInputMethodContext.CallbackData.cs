using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.InputMethodContext.CallbackData Tests")]
    public class InputMethodContextCallbackDataTests
    {
        private string TAG = "NUI";
        private string _image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("InputMethodContext.CallbackDataTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a CallbackData object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.CallbackData.CallbackData C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void CallbackData_INIT()
        {
            var callbackData = new InputMethodContext.CallbackData();
            Assert.NotNull(callbackData, "Should be not null");
            Assert.IsInstanceOf<InputMethodContext.CallbackData>(callbackData, "Should be an instance of InputMethodContext.CallbackData");
        }

        [Test]
        [Category("P1")]
        [Description("Create a CallbackData object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.CallbackData.CallbackData C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "bool, int, string, bool")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void CallbackData_INIT_WITH_BOOL_INT_STRING_BOOL()
        {
            var callbackData = new InputMethodContext.CallbackData(false, 0, "", false);
            Assert.NotNull(callbackData, "Should be not null");
            Assert.IsInstanceOf<InputMethodContext.CallbackData>(callbackData, "Should be an instance of InputMethodContext.CallbackData");
        }

        [Test]
        [Category("P2")]
        [Description("Create a CallbackData object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.CallbackData.CallbackData C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTN")]
        [Property("COVPARAM", "bool, int, string, bool")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void CallbackData_INIT_WITH_BOOL_INT_STRING_BOOL_NEGATIVE()
        {
            Assert.Throws<ArgumentNullException>(() => new InputMethodContext.CallbackData(false, 0, null, false));
        }

        [Test]
        [Category("P1")]
        [Description("Test CurrentText. Check whether CurrentText is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.CallbackData.CurrentText A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void CurrentText_SET_GET_VALUE()
        {
            InputMethodContext.CallbackData callbackData = new InputMethodContext.CallbackData();
            string example = "Test current text";
            callbackData.CurrentText = example;
            Assert.AreEqual(example, callbackData.CurrentText, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test CursorPosition. Check whether CursorPosition is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.CallbackData.CursorPosition A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void CursorPosition_SET_GET_VALUE()
        {
            InputMethodContext.CallbackData callbackData = new InputMethodContext.CallbackData();
            callbackData.CursorPosition = 0;
            Assert.AreEqual(0, callbackData.CursorPosition, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Update. Check whether Update is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.CallbackData.Update A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void Update_SET_GET_VALUE()
        {
            InputMethodContext.CallbackData callbackData = new InputMethodContext.CallbackData();
            callbackData.Update = false;
            Assert.IsFalse(callbackData.Update, "Should be false here!");
            callbackData.Update = true;
            Assert.IsTrue(callbackData.Update, "Should be true here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test PreeditResetRequired. Check whether PreeditResetRequired is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.CallbackData.PreeditResetRequired A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void PreeditResetRequired_SET_GET_VALUE()
        {
            InputMethodContext.CallbackData callbackData = new InputMethodContext.CallbackData();
            callbackData.PreeditResetRequired = false;
            Assert.IsFalse(callbackData.PreeditResetRequired, "Should be false here!");
            callbackData.PreeditResetRequired = true;
            Assert.IsTrue(callbackData.PreeditResetRequired, "Should be true here!");
        }
    }
}