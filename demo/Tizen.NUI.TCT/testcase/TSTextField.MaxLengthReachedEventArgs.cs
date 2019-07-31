using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.TextField.MaxLengthReachedEventArgs Tests")]
    public class TextFieldMaxLengthReachedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("MaxLengthReachedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a MaxLengthReachedEventArgs object. Check whether MaxLengthReachedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.MaxLengthReachedEventArgs.MaxLengthReachedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void MaxLengthReachedEventArgs_INIT()
        {
            /* TEST CODE */
            var maxLengthReachedEventArgs = new TextField.MaxLengthReachedEventArgs();
            Assert.IsNotNull(maxLengthReachedEventArgs, "Can't create success object MaxLengthReachedEventArgs");
            Assert.IsInstanceOf<TextField.MaxLengthReachedEventArgs>(maxLengthReachedEventArgs, "Should be an instance of MaxLengthReachedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test TextField. Check whether TextField is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.MaxLengthReachedEventArgs.TextField A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TextField_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField.MaxLengthReachedEventArgs maxLengthReachedEventArgs = new TextField.MaxLengthReachedEventArgs();
            TextField textField = new TextField();
            maxLengthReachedEventArgs.TextField = textField;
            Assert.AreEqual(textField, maxLengthReachedEventArgs.TextField, "Retrieved TextField should be equal to set value");
        }
    }
}
