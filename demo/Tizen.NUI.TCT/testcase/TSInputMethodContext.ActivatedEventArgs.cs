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
    [Description("Tizen.NUI.InputMethodContext.ActivatedEventArgs Tests")]
    public class InputMethodContextActivatedEventArgsTests
    {
        private string TAG = "NUI";
        private string _image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("InputMethodContext.ActivatedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a ActivatedEventArgs object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.ActivatedEventArgs.ActivatedEventArgs C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void ActivatedEventArgs_INIT()
        {
            var activatedEventArgs = new InputMethodContext.ActivatedEventArgs();
            Assert.NotNull(activatedEventArgs, "Should be not null");
            Assert.IsInstanceOf<InputMethodContext.ActivatedEventArgs>(activatedEventArgs, "Should be an instance of InputMethodContext.ActivatedEventArgs");
        }

        [Test]
        [Category("P1")]
        [Description("Test InputMethodContext. Check whether InputMethodContext is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.ActivatedEventArgs.InputMethodContext A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void InputMethodContext_SET_GET_VALUE()
        {
            InputMethodContext.ActivatedEventArgs activatedEventArgs = new InputMethodContext.ActivatedEventArgs();
            activatedEventArgs.InputMethodContext = new InputMethodContext();
            InputMethodContext inputMethodContext = activatedEventArgs.InputMethodContext;
            Assert.NotNull(inputMethodContext, "Should be not null");
            Assert.IsInstanceOf<InputMethodContext>(inputMethodContext, "Should be an instance of InputMethodContext");
        }
    }
}