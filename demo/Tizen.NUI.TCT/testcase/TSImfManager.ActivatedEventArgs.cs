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
    [Description("Tizen.NUI.ImfManager.ActivatedEventArgs Tests")]
    public class ImfManagerActivatedEventArgsTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ActivatedEventArgsTests");
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
        [Property("SPEC", "Tizen.NUI.ImfManager.ActivatedEventArgs.ActivatedEventArgs C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void ActivatedEventArgs_INIT()
        {
            var activatedEventArgs = new ImfManager.ActivatedEventArgs();
            Assert.NotNull(activatedEventArgs, "Should be not null");
            Assert.IsInstanceOf<ImfManager.ActivatedEventArgs>(activatedEventArgs, "Should be an instance of ImfManager.ActivatedEventArgs");
        }

        [Test]
        [Category("P1")]
        [Description("Test ImfManager.Check whether ImfManager is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.ActivatedEventArgs.ImfManager A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void ImfManager_SET_GET_VALUE()
        {
            ImfManager.ActivatedEventArgs activatedEventArgs = new ImfManager.ActivatedEventArgs();
            activatedEventArgs.ImfManager = ImfManager.Get();
            ImfManager manager = activatedEventArgs.ImfManager;
            Assert.NotNull(manager, "Should be not null");
            Assert.IsInstanceOf<ImfManager>(manager, "Should be an instance of ImfManager");
        }
    }
}