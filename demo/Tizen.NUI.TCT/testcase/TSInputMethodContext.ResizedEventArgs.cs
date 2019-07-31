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
    [Description("Tizen.NUI.InputMethodContext.ResizedEventArgs Tests")]
    public class InputMethodContextResizedEventArgsTests
    {
        private string TAG = "NUI";
        private string _image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("InputMethodContext.ResizedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a event ResizedEventArgs object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.ResizedEventArgs.ResizedEventArgs C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void ResizedEventArgs_INIT()
        {
            var resizedEventArgs = new InputMethodContext.ResizedEventArgs();
            Assert.NotNull(resizedEventArgs, "Should be not null");
            Assert.IsInstanceOf<InputMethodContext.ResizedEventArgs>(resizedEventArgs, "Should be an instance of InputMethodContext.ResizedEventArgs");
        }

        [Test]
        [Category("P1")]
        [Description("Test Resized.Check whether Resized is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.ResizedEventArgs.Resized A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void Resized_SET_GET_VALUE()
        {
            var resizedEventArgs = new InputMethodContext.ResizedEventArgs();
            resizedEventArgs.Resized = 0;
            Assert.AreEqual(0, resizedEventArgs.Resized, "Should be equal!");
            resizedEventArgs.Resized = 9;
            Assert.AreEqual(9, resizedEventArgs.Resized, "Should be equal!");
        }
    }
}