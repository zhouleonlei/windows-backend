using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Window.KeyEventArgs Tests")]
    public class WindowKeyEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("KeyEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a KeyEventArgs object. Check whether KeyEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Window.KeyEventArgs.KeyEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void KeyEventArgs_INIT()
        {
            /* TEST CODE */
            var keyEventArgs = new Window.KeyEventArgs();
            Assert.IsNotNull(keyEventArgs, "Can't create success object KeyEventArgs");
            Assert.IsInstanceOf<Window.KeyEventArgs>(keyEventArgs, "Should be an instance of KeyEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Key. Check whether Key is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Window.KeyEventArgs.Key A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Key_SET_GET_VALUE()
        {
            /* TEST CODE */
            Window.KeyEventArgs keyEventArgs = new Window.KeyEventArgs();
            Key key = new Key();
            keyEventArgs.Key = key;
            Assert.AreEqual(key, keyEventArgs.Key, "Retrieved Key should be equal to set value");
        }
    }
}
