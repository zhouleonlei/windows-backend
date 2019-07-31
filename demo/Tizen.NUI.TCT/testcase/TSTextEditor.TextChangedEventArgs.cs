using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.TextEditor.TextChangedEventArgs Tests")]
    public class TextEditorTextChangedEventArgsTests
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
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.TextChangedEventArgs.TextChangedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TextChangedEventArgs_INIT()
        {
            /* TEST CODE */
            var textChangedEventArgs = new TextEditor.TextChangedEventArgs();
            Assert.IsNotNull(textChangedEventArgs, "Can't create success object TextChangedEventArgs");
            Assert.IsInstanceOf<TextEditor.TextChangedEventArgs>(textChangedEventArgs, "Should be an instance of TextChangedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test TextEditor. Check whether TextEditor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.TextChangedEventArgs.TextEditor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TextEditor_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor.TextChangedEventArgs textChangedEventArgs = new TextEditor.TextChangedEventArgs();
            TextEditor textEditor = new TextEditor();
            textChangedEventArgs.TextEditor = textEditor;
            Assert.AreEqual(textEditor, textChangedEventArgs.TextEditor, "Retrieved TextEditor should be equal to set value");
        }
    }
}
