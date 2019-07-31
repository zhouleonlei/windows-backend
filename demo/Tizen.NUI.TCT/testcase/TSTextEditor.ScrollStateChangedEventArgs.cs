using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.TextEditor.ScrollStateChangedEventArgs Tests")]
    public class TextEditorScrollStateChangedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ScrollStateChangedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a ScrollStateChangedEventArgs object. Check whether ScrollStateChangedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.ScrollStateChangedEventArgs.ScrollStateChangedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ScrollStateChangedEventArgs_INIT()
        {
            /* TEST CODE */
            var scrollStateChangedEventArgs = new TextEditor.ScrollStateChangedEventArgs();
            Assert.IsNotNull(scrollStateChangedEventArgs, "Can't create success object ScrollStateChangedEventArgs");
            Assert.IsInstanceOf<TextEditor.ScrollStateChangedEventArgs>(scrollStateChangedEventArgs, "Should be an instance of ScrollStateChangedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test TextEditor. Check whether TextEditor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.ScrollStateChangedEventArgs.TextEditor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void TextEditor_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor.ScrollStateChangedEventArgs scrollStateChangedEventArgs = new TextEditor.ScrollStateChangedEventArgs();
            TextEditor textEditor = new TextEditor();
            scrollStateChangedEventArgs.TextEditor = textEditor;
            Assert.AreEqual(textEditor, scrollStateChangedEventArgs.TextEditor, "Retrieved TextEditor should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScrollState. Check whether ScrollState is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.ScrollStateChangedEventArgs.ScrollState A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ScrollState_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor.ScrollStateChangedEventArgs scrollStateChangedEventArgs = new TextEditor.ScrollStateChangedEventArgs();
            scrollStateChangedEventArgs.ScrollState = ScrollState.Finished;
            Assert.AreEqual(ScrollState.Finished, scrollStateChangedEventArgs.ScrollState, "Retrieved ScrollState should be equal to set value");
        }
    }
}
