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
    [Description("Tizen.NUI.InputMethodContext.StatusChangedEventArgs Tests")]
    public class InputMethodContextStatusChangedEventArgsTests
    {
        private string TAG = "NUI";
        private string _image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("StatusChangedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a StatusChangedEventArgs object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.StatusChangedEventArgs.StatusChangedEventArgs C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void StatusChangedEventArgs_INIT()
        {
            var statusChangedEventArgs = new InputMethodContext.StatusChangedEventArgs();
            Assert.NotNull(statusChangedEventArgs, "Should be not null");
            Assert.IsInstanceOf<InputMethodContext.StatusChangedEventArgs>(statusChangedEventArgs, "Should be an instance of InputMethodContext.StatusChangedEventArgs");
        }

        [Test]
        [Category("P1")]
        [Description("Test InputMethodContext.Check whether StatusChanged is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.StatusChangedEventArgs.StatusChanged A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void StatusChanged_SET_GET_VALUE()
        {
            InputMethodContext.StatusChangedEventArgs statusChangedEventArgs = new InputMethodContext.StatusChangedEventArgs();
            statusChangedEventArgs.StatusChanged = false;
            Assert.IsFalse(statusChangedEventArgs.StatusChanged, "Should be false");
            statusChangedEventArgs.StatusChanged = true;
            Assert.IsTrue(statusChangedEventArgs.StatusChanged, "Should be true");
        }
    }
}