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
    [Description("Tizen.NUI.BaseComponents.VideoView.FinishedEventArgs Tests")]
    public class FinishedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("FinishedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a FinishedEventArgs object. Check whether FinishedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VideoView.FinishedEventArgs.FinishedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void FinishedEventArgs_INIT()
        {
            /* TEST CODE */
            var finishedEventArgs = new VideoView.FinishedEventArgs();
            Assert.IsNotNull(finishedEventArgs, "Can't create success object FinishedEventArgs");
            Assert.IsInstanceOf<VideoView.FinishedEventArgs>(finishedEventArgs, "Should be an instance of FinishedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test VideoView. Check whether VideoView is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VideoView.FinishedEventArgs.VideoView A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void VideoView_SET_GET_VALUE()
        {
            /* TEST CODE */
            VideoView.FinishedEventArgs finishedEventArgs = new VideoView.FinishedEventArgs();
            VideoView videoView = new VideoView();
            finishedEventArgs.VideoView = videoView;
            Assert.AreEqual(videoView, finishedEventArgs.VideoView, "Retrieved VideoView should be equal to set value");
            videoView.Dispose();
        }
    }
}
