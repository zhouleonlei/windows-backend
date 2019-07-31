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
    [Description("Tizen.NUI.InputMethodContext.EventData Tests")]
    public class InputMethodContextEventDataTests
    {
        private string TAG = "NUI";
        private string _image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("InputMethodContext.EventDataTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a EventData object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.EventData.EventData C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void EventData_INIT()
        {
            var eventData = new InputMethodContext.EventData();
            Assert.NotNull(eventData, "Should be not null");
            Assert.IsInstanceOf<InputMethodContext.EventData>(eventData, "Should be an instance of InputMethodContext.EventData");
        }

        [Test]
        [Category("P1")]
        [Description("Create a EventData object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.EventData.EventData C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "InputMethodContext.EventType, string, int, int")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void EventData_INIT_WITH_EVENTTYPE_STRING_INT_INT()
        {
            var eventData = new InputMethodContext.EventData(InputMethodContext.EventType.DeleteSurrounding, "", 0, 0);
            Assert.NotNull(eventData, "Should be not null");
            Assert.IsInstanceOf<InputMethodContext.EventData>(eventData, "Should be an instance of InputMethodContext.EventData");
        }

        [Test]
        [Category("P2")]
        [Description("Create a EventData object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.EventData.EventData C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTN")]
        [Property("COVPARAM", "InputMethodContext.EventType, string, int, int")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void EventData_INIT_WITH_EVENTTYPE_STRING_INT_INT_NEGATIVE()
        {
            Assert.Throws<ArgumentNullException>(() => new InputMethodContext.EventData(InputMethodContext.EventType.DeleteSurrounding, null, 0, 0));
        }

        [Test]
        [Category("P1")]
        [Description("Test CursorOffset. Check whether CursorOffset is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.EventData.CursorOffset A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void CursorOffset_SET_GET_VALUE()
        {
            InputMethodContext.EventData eventData = new InputMethodContext.EventData();
            eventData.CursorOffset = 0;
            Assert.AreEqual(0, eventData.CursorOffset, "Should be equal!");
            eventData.CursorOffset = 9;
            Assert.AreEqual(9, eventData.CursorOffset, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test EventName. Check whether EventName is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.EventData.EventName A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void EventName_SET_GET_VALUE()
        {
            InputMethodContext.EventData eventData = new InputMethodContext.EventData();
            eventData.EventName = InputMethodContext.EventType.DeleteSurrounding;
            Assert.AreEqual(InputMethodContext.EventType.DeleteSurrounding, eventData.EventName, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test NumberOfChars. Check whether NumberOfChars is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.EventData.NumberOfChars A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void NumberOfChars_SET_GET_VALUE()
        {
            InputMethodContext.EventData eventData = new InputMethodContext.EventData();
            eventData.NumberOfChars = 5;
            Assert.AreEqual(5, eventData.NumberOfChars, "Should be equal here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test PredictiveString. Check whether PredictiveString is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.EventData.PredictiveString A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void PredictiveString_SET_GET_VALUE()
        {
            InputMethodContext.EventData eventData = new InputMethodContext.EventData();
            eventData.PredictiveString = "string";
            Assert.AreEqual("string", eventData.PredictiveString, "Should be equal here!");
        }
    }
}