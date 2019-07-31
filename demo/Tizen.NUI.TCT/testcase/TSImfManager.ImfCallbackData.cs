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
    [Description("Tizen.NUI.ImfManager.ImfCallbackData Tests")]
    public class ImfCallbackDataTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ImfCallbackDataTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a ImfCallbackData object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.ImfCallbackData.ImfCallbackData C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ImfCallbackData_INIT()
        {
            var imfCallbackData = new ImfManager.ImfCallbackData();
            Assert.NotNull(imfCallbackData, "Should be not null");
            Assert.IsInstanceOf<ImfManager.ImfCallbackData>(imfCallbackData, "Should be an instance of ImfManager.ImfCallbackData");
        }

        [Test]
        [Category("P1")]
        [Description("Create a ImfCallbackData object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.ImfCallbackData.ImfCallbackData C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "bool, int, string, bool")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ImfCallbackData_INIT_WITH_BOOL_INT_STRING_BOOL()
        {
            var imfCallbackData = new ImfManager.ImfCallbackData(false, 0, "", false);
            Assert.NotNull(imfCallbackData, "Should be not null");
            Assert.IsInstanceOf<ImfManager.ImfCallbackData>(imfCallbackData, "Should be an instance of ImfManager.ImfCallbackData");
        }

        [Test]
        [Category("P1")]
        [Description("Test CurrentText.Check whether CurrentText is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.ImfCallbackData.CurrentText A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void CurrentText_SET_GET_VALUE()
        {
            ImfManager.ImfCallbackData imfCallbackData = new ImfManager.ImfCallbackData();
            imfCallbackData.CurrentText = "";
            Assert.AreEqual("", imfCallbackData.CurrentText, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test CursorPosition.Check whether CursorPosition is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.ImfCallbackData.CursorPosition A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void CursorPosition_SET_GET_VALUE()
        {
            ImfManager.ImfCallbackData imfCallbackData = new ImfManager.ImfCallbackData();
            imfCallbackData.CursorPosition = 0;
            Assert.AreEqual(0, imfCallbackData.CursorPosition, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Update.Check whether Update is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.ImfCallbackData.Update A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Update_SET_GET_VALUE()
        {
            ImfManager.ImfCallbackData imfCallbackData = new ImfManager.ImfCallbackData();
            imfCallbackData.Update = false;
            Assert.IsFalse(imfCallbackData.Update, "Should be false here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test PreeditResetRequired.Check whether PreeditResetRequired is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.ImfCallbackData.PreeditResetRequired A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PreeditResetRequired_SET_GET_VALUE()
        {
            ImfManager.ImfCallbackData imfCallbackData = new ImfManager.ImfCallbackData();
            imfCallbackData.PreeditResetRequired = false;
            Assert.IsFalse(imfCallbackData.PreeditResetRequired, "Should be false here!");
        }
    }
}