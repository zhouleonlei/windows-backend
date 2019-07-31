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
    [Description("Tizen.NUI.ImfManager.ImfEventData Tests")]
    public class ImfEventDataTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ImfEventDataTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a ImfEventData object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.ImfEventData.ImfEventData C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ImfEventData_INIT()
        {
            var imfEventData = new ImfManager.ImfEventData();
            Assert.NotNull(imfEventData, "Should be not null");
            Assert.IsInstanceOf<ImfManager.ImfEventData>(imfEventData, "Should be an instance of ImfManager.ImfEventData");
        }

        [Test]
        [Category("P1")]
        [Description("Create a ImfEventData object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.ImfEventData.ImfEventData C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "ImfManager.ImfEvent, string, int, int")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ImfEventData_INIT_WITH_IMFEVENT_STRING_INT_INT()
        {
            var imfEventData = new ImfManager.ImfEventData(ImfManager.ImfEvent.DeleteSurrounding, "", 0, 0);
            Assert.NotNull(imfEventData, "Should be not null");
            Assert.IsInstanceOf<ImfManager.ImfEventData>(imfEventData, "Should be an instance of ImfManager.ImfEventData");
        }

        [Test]
        [Category("P1")]
        [Description("Test CursorOffset.Check whether CursorOffset is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.ImfEventData.CursorOffset A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void CursorOffset_SET_GET_VALUE()
        {
            ImfManager.ImfEventData imfEventData = new ImfManager.ImfEventData();
            imfEventData.CursorOffset = 0;
            Assert.AreEqual(0, imfEventData.CursorOffset, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test EventName.Check whether EventName is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.ImfEventData.EventName A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void EventName_SET_GET_VALUE()
        {
            ImfManager.ImfEventData imfEventData = new ImfManager.ImfEventData();
            imfEventData.EventName = ImfManager.ImfEvent.DeleteSurrounding;
            Assert.AreEqual(ImfManager.ImfEvent.DeleteSurrounding, imfEventData.EventName, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test NumberOfChars.Check whether NumberOfChars is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.ImfEventData.NumberOfChars A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void NumberOfChars_SET_GET_VALUE()
        {
            ImfManager.ImfEventData ImfEventData = new ImfManager.ImfEventData();
            ImfEventData.NumberOfChars = 5;
            Assert.AreEqual(5, ImfEventData.NumberOfChars, "Should be equal here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test PredictiveString.Check whether PredictiveString is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.ImfEventData.PredictiveString A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PredictiveString_SET_GET_VALUE()
        {
            ImfManager.ImfEventData ImfEventData = new ImfManager.ImfEventData();
            ImfEventData.PredictiveString = "string";
            Assert.AreEqual("string", ImfEventData.PredictiveString, "Should be equal here!");
        }
    }
}