using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.NUIEventType Tests")]
    public class NUIEventTypeTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("NUIEventTypeTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a NUIEventType object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.NUIEventType.NUIEventType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void NUIEventType_INIT()
        {
            /* TEST CODE */
            var nuiEventType = new NUIEventType("TimeTick");

            Assert.IsNotNull(nuiEventType, "Can't create success object NUIEventType");
            Assert.IsInstanceOf<NUIEventType>(nuiEventType, "Should be an instance of NUIEventType type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test TimeTick, Check whether TimeTick property is readable.")]
        [Property("SPEC", "Tizen.NUI.NUIEventType.TimeTick A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void TimeTick_GET_VALUE()
        {
            /* TEST CODE */
            var nuiEventType = NUIEventType.TimeTick;
            Assert.IsInstanceOf<NUIEventType>(nuiEventType, "Should be an instance of NUIEventType type.");
            Assert.AreEqual(NUIEventType.TimeTick, nuiEventType, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test AmbientTick, Check whether AmbientTick property is readable.")]
        [Property("SPEC", "Tizen.NUI.NUIEventType.AmbientTick A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void AmbientTick_GET_VALUE()
        {
            /* TEST CODE */
            var nuiEventType = NUIEventType.AmbientTick;
            Assert.IsInstanceOf<NUIEventType>(nuiEventType, "Should be an instance of NUIEventType type.");
            Assert.AreEqual(NUIEventType.AmbientTick, nuiEventType, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test AmbientChanged, Check whether AmbientChanged property is readable.")]
        [Property("SPEC", "Tizen.NUI.NUIEventType.AmbientChanged A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void AmbientChanged_GET_VALUE()
        {
            /* TEST CODE */
            var nuiEventType = NUIEventType.AmbientChanged;
            Assert.IsInstanceOf<NUIEventType>(nuiEventType, "Should be an instance of NUIEventType type.");
            Assert.AreEqual(NUIEventType.AmbientChanged, nuiEventType, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test implicit string. Try to convert a string to a NUIEventType instance.")]
        [Property("SPEC", "Tizen.NUI.NUIEventType.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "string")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void implicit_STRING_RETURN_VALUE()
        {
            /* TEST CODE */
            NUIEventType nuiEventType = "TimeTick";
            Assert.IsInstanceOf<NUIEventType>(nuiEventType, "Should be an instance of NUIEventType type.");
        }
    }
}
