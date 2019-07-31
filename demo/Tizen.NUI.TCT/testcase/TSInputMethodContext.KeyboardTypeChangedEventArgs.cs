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
    [Description("Tizen.NUI.InputMethodContext.KeyboardTypeChangedEventArgs Tests")]
    public class InputMethodContextKeyboardTypeChangedEventArgsTests
    {
        private string TAG = "NUI";
        private string _image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("InputMethodContext.KeyboardTypeChangedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a KeyboardTypeChangedEventArgs object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.KeyboardTypeChangedEventArgs.KeyboardTypeChangedEventArgs C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void KeyboardTypeChangedEventArgs_INIT()
        {
            var keyboardTypeChangedEventArgs = new InputMethodContext.KeyboardTypeChangedEventArgs();
            Assert.NotNull(keyboardTypeChangedEventArgs, "Should be not null");
            Assert.IsInstanceOf<InputMethodContext.KeyboardTypeChangedEventArgs>(keyboardTypeChangedEventArgs, "Should be an instance of InputMethodContext.KeyboardTypeChangedEventArgs");
        }

        [Test]
        [Category("P1")]
        [Description("Test KeyboardType.Check whether KeyboardType is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.KeyboardTypeChangedEventArgs.KeyboardType A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void KeyboardType_SET_GET_VALUE()
        {
            InputMethodContext.KeyboardTypeChangedEventArgs keyboardTypeChangedEventArgs = new InputMethodContext.KeyboardTypeChangedEventArgs();
            keyboardTypeChangedEventArgs.KeyboardType = InputMethodContext.KeyboardType.SoftwareKeyboard;
            Assert.AreEqual(InputMethodContext.KeyboardType.SoftwareKeyboard, keyboardTypeChangedEventArgs.KeyboardType, "Should be equal!");
        }
    }
}