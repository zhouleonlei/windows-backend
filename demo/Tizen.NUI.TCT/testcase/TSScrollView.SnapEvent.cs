using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.ScrollView.SnapEvent Tests")]
    public class SnapEventTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("SnapEventTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a SnapEvent object. Check whether SnapEvent is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SnapEvent.SnapEvent C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SnapEvent_INIT()
        {
            /* TEST CODE */
            var snapEvent = new ScrollView.SnapEvent();
            Assert.IsNotNull(snapEvent, "Can't create success object SnapEvent");
            Assert.IsInstanceOf<ScrollView.SnapEvent>(snapEvent, "Should be an instance of SnapEvent type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test position Check whether position is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SnapEvent.position A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void position_SET_GET_VALUE()
        {
            /* TEST CODE */
            ScrollView.SnapEvent snapEvent = new ScrollView.SnapEvent();
            snapEvent.position = new Vector2(10.0f, 20.0f);

            Vector2 value = snapEvent.position;
            Assert.AreEqual(10.0f, value.X, "Retrieved position should be equal to set value");
            Assert.AreEqual(20.0f, value.Y, "Retrieved position should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetSnapEventFromPtr Check whether GetSnapEventFromPtr works or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SnapEvent.GetSnapEventFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetSnapEventFromPtr_CHECK()
        {
            /* TEST CODE */
            global::System.IntPtr snapEvent = new global::System.IntPtr();
            var tmp = ScrollView.SnapEvent.GetSnapEventFromPtr(snapEvent);
            Assert.IsInstanceOf<ScrollView.SnapEvent>(tmp);
        }

        [Test]
        [Category("P1")]
        [Description("Test duration Check whether duration is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SnapEvent.duration A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void duration_SET_GET_VALUE()
        {
            /* TEST CODE */
            ScrollView.SnapEvent snapEvent = new ScrollView.SnapEvent();
            snapEvent.duration = 4.0f;

            Assert.AreEqual(4.0f, snapEvent.duration, "Retrieved duration should be equal to set value");
        }


        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the SnapEvent.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SnapEvent.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void Dispose_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            try
            {
                ScrollView.SnapEvent snapEvent = new ScrollView.SnapEvent();
                snapEvent.Dispose();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
    }
}
