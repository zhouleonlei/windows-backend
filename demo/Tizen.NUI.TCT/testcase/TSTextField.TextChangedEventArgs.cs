using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.TextField.TextChangedEventArgs Tests")]
    public class TextFieldTextChangedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("TextChangedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a TextChangedEventArgs object. Check whether TextChangedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.TextChangedEventArgs.TextChangedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TextChangedEventArgs_INIT()
        {
            /* TEST CODE */
            var textChangedEventArgs = new TextField.TextChangedEventArgs();
            Assert.IsNotNull(textChangedEventArgs, "Can't create success object TextChangedEventArgs");
            Assert.IsInstanceOf<TextField.TextChangedEventArgs>(textChangedEventArgs, "Should be an instance of TextChangedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test TextField. Check whether TextField is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.TextChangedEventArgs.TextField A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TextField_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField.TextChangedEventArgs textChangedEventArgs = new TextField.TextChangedEventArgs();
            TextField textField = new TextField();
            textChangedEventArgs.TextField = textField;
            Assert.AreEqual(textField, textChangedEventArgs.TextField, "Retrieved TextField should be equal to set value");
        }
    }
}
