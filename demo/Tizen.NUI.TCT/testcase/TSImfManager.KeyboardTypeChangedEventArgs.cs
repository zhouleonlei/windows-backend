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
    [Description("Tizen.NUI.ImfManager.KeyboardTypeChangedEventArgs Tests")]
    public class ImfManagerKeyboardTypeChangedEventArgsTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("KeyboardTypeChangedEventArgsTests");
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
        [Property("SPEC", "Tizen.NUI.ImfManager.KeyboardTypeChangedEventArgs.KeyboardTypeChangedEventArgs C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void KeyboardTypeChangedEventArgs_INIT()
        {
            var keyboardTypeChangedEventArgs = new ImfManager.KeyboardTypeChangedEventArgs();
            Assert.NotNull(keyboardTypeChangedEventArgs, "Should be not null");
            Assert.IsInstanceOf<ImfManager.KeyboardTypeChangedEventArgs>(keyboardTypeChangedEventArgs, "Should be an instance of ImfManager.ImfManagerKeyboardTypeChangedEventArgs");
        }

        [Test]
        [Category("P1")]
        [Description("Test KeyboardType.Check whether KeyboardType is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.KeyboardTypeChangedEventArgs.KeyboardType A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void KeyboardType_SET_GET_VALUE()
        {
            ImfManager.KeyboardTypeChangedEventArgs keyboardTypeChangedEventArgs = new ImfManager.KeyboardTypeChangedEventArgs();
            keyboardTypeChangedEventArgs.KeyboardType = ImfManager.KeyboardType.SoftwareKeyboard;
            Assert.AreEqual(ImfManager.KeyboardType.SoftwareKeyboard, keyboardTypeChangedEventArgs.KeyboardType, "Should be equal!");
        }
    }
}