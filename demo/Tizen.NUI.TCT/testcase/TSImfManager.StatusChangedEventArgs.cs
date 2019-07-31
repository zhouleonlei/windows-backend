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
    [Description("Tizen.NUI.ImfManager.StatusChangedEventArgs Tests")]
    public class ImfManagerStatusChangedEventArgsTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

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
        [Property("SPEC", "Tizen.NUI.ImfManager.StatusChangedEventArgs.StatusChangedEventArgs C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void StatusChangedEventArgs_INIT()
        {
            var statusChangedEventArgs = new ImfManager.StatusChangedEventArgs();
            Assert.NotNull(statusChangedEventArgs, "Should be not null");
            Assert.IsInstanceOf<ImfManager.StatusChangedEventArgs>(statusChangedEventArgs, "Should be an instance of ImfManager.ImfManagerStatusChangedEventArgs");
        }

        [Test]
        [Category("P1")]
        [Description("Test ImfManager.Check whether StatusChanged is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.StatusChangedEventArgs.StatusChanged A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void StatusChanged_SET_GET_VALUE()
        {
            ImfManager.StatusChangedEventArgs statusChangedEventArgs = new ImfManager.StatusChangedEventArgs();
            statusChangedEventArgs.StatusChanged = false;
            Assert.IsFalse(statusChangedEventArgs.StatusChanged, "Should be false");
        }
    }
}