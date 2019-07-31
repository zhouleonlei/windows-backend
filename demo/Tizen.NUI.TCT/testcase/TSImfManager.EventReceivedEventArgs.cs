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
    [Description("Tizen.NUI.ImfManager.EventReceivedEventArgs Tests")]
    public class ImfManagerEventReceivedEventArgsTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("EventReceivedEventArgsTests");
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
        [Property("SPEC", "Tizen.NUI.ImfManager.EventReceivedEventArgs.EventReceivedEventArgs C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void EventReceivedEventArgs_INIT()
        {
            var eventReceivedEventArgs = new ImfManager.EventReceivedEventArgs();
            Assert.NotNull(eventReceivedEventArgs, "Should be not null");
            Assert.IsInstanceOf<ImfManager.EventReceivedEventArgs>(eventReceivedEventArgs, "Should be an instance of ImfManager.EventReceivedEventArgs");
        }

        [Test]
        [Category("P1")]
        [Description("Test ImfManager.Check whether ImfManager is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.EventReceivedEventArgs.ImfEventData A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void ImfEventData_SET_GET_VALUE()
        {
            ImfManager.EventReceivedEventArgs eventReceivedEventArgs = new ImfManager.EventReceivedEventArgs();
            eventReceivedEventArgs.ImfEventData = new ImfManager.ImfEventData();
            ImfManager.ImfEventData imfEventData = eventReceivedEventArgs.ImfEventData;;
            Assert.NotNull(imfEventData, "Should be not null");
            Assert.IsInstanceOf<ImfManager.ImfEventData>(imfEventData, "Should be an instance of ImfManager.ImfEventData");
        }

        [Test]
        [Category("P1")]
        [Description("Test ImfManager.Check whether ImfManager is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImfManager.EventReceivedEventArgs.ImfManager A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void ImfManager_SET_GET_VALUE()
        {
            ImfManager.EventReceivedEventArgs eventReceivedEventArgs = new ImfManager.EventReceivedEventArgs();
            eventReceivedEventArgs.ImfManager = ImfManager.Get();
            ImfManager manager = eventReceivedEventArgs.ImfManager;
            Assert.NotNull(manager, "Should be not null");
            Assert.IsInstanceOf<ImfManager>(manager, "Should be an instance of ImfManager");
        }
    }
}