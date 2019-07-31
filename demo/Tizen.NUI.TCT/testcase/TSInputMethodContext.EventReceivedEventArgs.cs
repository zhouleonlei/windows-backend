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
    [Description("Tizen.NUI.InputMethodContext.EventReceivedEventArgs Tests")]
    public class InputMethodContextEventReceivedEventArgsTests
    {
        private string TAG = "NUI";
        private string _image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

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
        [Property("SPEC", "Tizen.NUI.InputMethodContext.EventReceivedEventArgs.EventReceivedEventArgs C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void EventReceivedEventArgs_INIT()
        {
            var eventReceivedEventArgs = new InputMethodContext.EventReceivedEventArgs();
            Assert.NotNull(eventReceivedEventArgs, "Should be not null");
            Assert.IsInstanceOf<InputMethodContext.EventReceivedEventArgs>(eventReceivedEventArgs, "Should be an instance of InputMethodContext.EventReceivedEventArgs");
        }

        [Test]
        [Category("P1")]
        [Description("Test EventData. Check whether EventData is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.EventReceivedEventArgs.EventData A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void EventData_SET_GET_VALUE()
        {
            InputMethodContext.EventReceivedEventArgs eventReceivedEventArgs = new InputMethodContext.EventReceivedEventArgs();
            eventReceivedEventArgs.EventData = new InputMethodContext.EventData();
            InputMethodContext.EventData eventData = eventReceivedEventArgs.EventData; ;
            Assert.NotNull(eventData, "Should be not null");
            Assert.IsInstanceOf<InputMethodContext.EventData>(eventData, "Should be an instance of InputMethodContext.EventData");
        }

        [Test]
        [Category("P1")]
        [Description("Test InputMethodContext.Check whether InputMethodContext is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.InputMethodContext.EventReceivedEventArgs.InputMethodContext A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void InputMethodContext_SET_GET_VALUE()
        {
            InputMethodContext.EventReceivedEventArgs eventReceivedEventArgs = new InputMethodContext.EventReceivedEventArgs();
            eventReceivedEventArgs.InputMethodContext = new InputMethodContext();
            InputMethodContext manager = eventReceivedEventArgs.InputMethodContext;
            Assert.NotNull(manager, "Should be not null");
            Assert.IsInstanceOf<InputMethodContext>(manager, "Should be an instance of InputMethodContext");
        }
    }
}