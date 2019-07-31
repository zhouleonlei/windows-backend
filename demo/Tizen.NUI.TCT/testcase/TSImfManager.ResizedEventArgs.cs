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
    [Description("Tizen.NUI.ImfManager.ResizedEventArgs Tests")]
    public class ResizedEventArgsTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ResizedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a eventReceivedEventArgs object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.ResizedEventArgs.ResizedEventArgs C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ResizedEventArgs_INIT()
        {
            var resizedEventArgs = new ImfManager.ResizedEventArgs();
            Assert.NotNull(resizedEventArgs, "Should be not null");
            Assert.IsInstanceOf<ImfManager.ResizedEventArgs>(resizedEventArgs, "Should be an instance of ImfManager.ResizedEventArgs");
        }

        [Test]
        [Category("P1")]
        [Description("Test Resized.Check whether Resized is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.ResizedEventArgs.Resized A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Resized_SET_GET_VALUE()
        {
            var resizedEventArgs = new ImfManager.ResizedEventArgs();
            resizedEventArgs.Resized = 0;
            Assert.AreEqual(0, resizedEventArgs.Resized, "Should be equal!");
        }
    }
}