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
    [Description("Tizen.NUI.ImfManager.LanguageChangedEventArgs Tests")]
    public class LanguageChangedEventArgsTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("LanguageChangedEventArgsTests");
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
        [Property("SPEC", "Tizen.NUI.ImfManager.LanguageChangedEventArgs.LanguageChangedEventArgs C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void LanguageChangedEventArgs_INIT()
        {
            var languageChangedEventArgs = new ImfManager.LanguageChangedEventArgs();
            Assert.NotNull(languageChangedEventArgs, "Should be not null");
            Assert.IsInstanceOf<ImfManager.LanguageChangedEventArgs>(languageChangedEventArgs, "Should be an instance of ImfManager.LanguageChangedEventArgs");
        }

        [Test]
        [Category("P1")]
        [Description("Test LanguageChanged.Check whether LanguageChanged is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.LanguageChangedEventArgs.LanguageChanged A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void LanguageChanged_SET_GET_VALUE()
        {
            var languageChangedEventArgs = new ImfManager.LanguageChangedEventArgs();
            languageChangedEventArgs.LanguageChanged = 0;
            Assert.AreEqual(0, languageChangedEventArgs.LanguageChanged, "Should be equal!");
        }
    }
}