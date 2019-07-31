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
    [Description("Tizen.NUI.InputMethodContext.LanguageChangedEventArgs Tests")]
    public class InputMethodContextLanguageChangedEventArgsTests
    {
        private string TAG = "NUI";
        private string _image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("InputMethodContext.LanguageChangedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a LanguageChangedEventArgs object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.LanguageChangedEventArgs.LanguageChangedEventArgs C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void LanguageChangedEventArgs_INIT()
        {
            var languageChangedEventArgs = new InputMethodContext.LanguageChangedEventArgs();
            Assert.NotNull(languageChangedEventArgs, "Should be not null");
            Assert.IsInstanceOf<InputMethodContext.LanguageChangedEventArgs>(languageChangedEventArgs, "Should be an instance of InputMethodContext.LanguageChangedEventArgs");
        }

        [Test]
        [Category("P1")]
        [Description("Test LanguageChanged.Check whether LanguageChanged is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.LanguageChangedEventArgs.LanguageChanged A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void LanguageChanged_SET_GET_VALUE()
        {
            var languageChangedEventArgs = new InputMethodContext.LanguageChangedEventArgs();
            languageChangedEventArgs.LanguageChanged = 0;
            Assert.AreEqual(0, languageChangedEventArgs.LanguageChanged, "Should be equal!");
            languageChangedEventArgs.LanguageChanged = 9;
            Assert.AreEqual(9, languageChangedEventArgs.LanguageChanged, "Should be equal!");
        }
    }
}