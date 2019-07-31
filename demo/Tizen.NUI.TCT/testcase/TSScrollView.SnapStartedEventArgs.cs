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
    [Description("Tizen.NUI.ScrollView.SnapStartedEventArgs Tests")]
    public class SnapStartedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("SnapStartedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a SnapStartedEventArgs object. Check whether SnapStartedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SnapStartedEventArgs.SnapStartedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SnapStartedEventArgs_INIT()
        {
            /* TEST CODE */
            var snapStartedEventArgs = new ScrollView.SnapStartedEventArgs();
            Assert.IsNotNull(snapStartedEventArgs, "Can't create success object SnapStartedEventArgs");
            Assert.IsInstanceOf<ScrollView.SnapStartedEventArgs>(snapStartedEventArgs, "Should be an instance of SnapStartedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test SnapEventInfo Check whether SnapEventInfo is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ScrollView.SnapStartedEventArgs.SnapEventInfo A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void SnapEventInfo_SET_GET_VALUE()
        {
            /* TEST CODE */
            ScrollView.SnapStartedEventArgs snapStartedEventArgs = new ScrollView.SnapStartedEventArgs();
            ScrollView.SnapEvent snapEvent = new ScrollView.SnapEvent();
            snapStartedEventArgs.SnapEventInfo = snapEvent;
            Assert.AreEqual(snapEvent, snapStartedEventArgs.SnapEventInfo, "Retrieved SnapEventInfo should be equal to set value");
        }
    }
}
