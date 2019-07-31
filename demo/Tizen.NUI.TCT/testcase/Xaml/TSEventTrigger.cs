using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.EventTrigger Tests")]
    public class EventTriggerTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Setup()
        {
            Tizen.Log.Info(TAG, "BindablePropertyTests-------------- - Setup()");
        }

        [TearDown]
        public void TearDown()
        {
            Tizen.Log.Info(TAG, "BindablePropertyTests-------------- - TearDown()");
        }

        [Test]
        [Category("P1")]
        [Description("Test Actions. Check whether Actions is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.EventTrigger.Actions A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Actions_READ_ONLY()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Event. Check whether Event is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.EventTrigger.Event A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Event_SET_GET_VALUE()
        {
            /* TEST CODE */
        }


        [Test]
        [Category("P1")]
        [Description("Test Construct. Check EventTrigger construct.")]
        [Property("SPEC", "Tizen.NUI.Binding.EventTrigger.EventTrigger C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void EventTrigger_INIT()
        {
            /* TEST CODE */
        }


    }
}
