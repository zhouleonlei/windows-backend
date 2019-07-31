using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using System.Threading;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.VideoView Tests")]
    public class VideoViewTests
    {
        private string TAG = "NUI";
        private string _videoPath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "demoVideo.mp4";
        private bool _flagOnFinished;
        private VideoView _videoView;

        private void OnFinished(object obj, VideoView.FinishedEventArgs args)
        {
            _flagOnFinished = true;
        }

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("VideoViewTests");
            App.MainTitleChangeBackgroundColor(null);
            _videoView = new VideoView();
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
            _videoView.Dispose();
            _videoView = null;
        }

        [Test]
        [Category("P1")]
        [Description("dali VideoView constructor test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VideoView.VideoView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "")]
        public void VideoView_INIT_WITH_NULL()
        {
            /* TEST CODE */
            Assert.IsNotNull(_videoView, "_videoView is null.");
            Assert.IsInstanceOf<VideoView>(_videoView, "Should return VideoView instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali VideoView constructor with url parameter test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VideoView.VideoView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "string")]
        public void VideoView_INIT_WITH_URL()
        {
            /* TEST CODE */
            var videoView = new VideoView("DALI");
            Assert.IsNotNull(videoView, "videoView is null.");
            Assert.IsInstanceOf<VideoView>(videoView, "Should return VideoView instance.");
            videoView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test ResourceUrl, Check whether Resource property is readable and Writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VideoView.ResourceUrl A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ResourceUrl_SET_GET_VALUE()
        {
            /* TEST CODE */
            _videoView.ResourceUrl = _videoPath;
            Assert.AreEqual(_videoPath, _videoView.ResourceUrl, "videoview.ResourceUrl should equal to the setted value.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Play. Check whether Play returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VideoView.Play M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Play_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                _videoView.Play();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.IsTrue(e is ArgumentException, "Argument Exception Not Recieved");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Pause. Check whether Pause returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VideoView.Pause M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Pause_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                _videoView.Pause();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.IsTrue(e is ArgumentException, "Argument Exception Not Recieved");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Stop. Check whether Stop returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VideoView.Stop M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Stop_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                _videoView.Stop();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.IsTrue(e is ArgumentException, "Argument Exception Not Recieved");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Forward. Check whether Forward returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VideoView.Forward M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Forward_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                _videoView.Forward(1000);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.IsTrue(e is ArgumentException, "Argument Exception Not Recieved");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Backward. Check whether Backward returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VideoView.Backward M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Backward_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                _videoView.Backward(1000);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.IsTrue(e is ArgumentException, "Argument Exception Not Recieved");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Video. Check whether Video is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VideoView.Video A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Video_SET_GET_VALUE()
        {
            /* TEST CODE */
            PropertyMap propertyMap = new PropertyMap();
            propertyMap.Insert(Tizen.NUI.Visual.Property.Type, new PropertyValue((int)Tizen.NUI.Visual.Type.Text));
            propertyMap.Insert(Tizen.NUI.TextVisualProperty.Text, new PropertyValue("Hello Goodbye"));
            _videoView.Video = propertyMap;
            PropertyValue propertyvalue3 = _videoView.Video.GetValue(1);
            string tempvalue = "";
            propertyvalue3.Get(out tempvalue);
            Assert.AreEqual("Hello Goodbye", tempvalue, "Video function does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test Looping. Check whether Looping is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VideoView.Looping A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Looping_SET_GET_VALUE()
        {
            /* TEST CODE */
            Window.Instance.GetDefaultLayer().Add(_videoView);

            _videoView.Looping = true;
            Assert.AreEqual(true, _videoView.Looping, "Looping function does not work");

            _videoView.Looping = false;
            Assert.AreEqual(false, _videoView.Looping, "Looping function does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test Underlay. Check whether Underlay is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VideoView.Underlay A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Underlay_SET_GET_VALUE()
        {
            /* TEST CODE */
           // Window.Instance.GetDefaultLayer().Add(_videoView);

           // bool isSupportRawVideo = false;
           // if (Tizen.System.Information.TryGetValue<bool>("tizen.org/feature/multimedia.raw_video", out isSupportRawVideo))
           // {
           //     if (isSupportRawVideo)
           //     {
           //         _videoView.Underlay = false;
           //         Assert.AreEqual(false, _videoView.Underlay, "Underlay function does not work");
           //     }
           //     else
           //     {
           //         _videoView.Underlay = true;
           //         Assert.AreEqual(true, _videoView.Underlay, "Underlay function does not work");
           //     }
           // }
           //else
           //{
           //    Tizen.Log.Error(TAG, "Error checking if raw_video is supported(systeminfo)");
           //}
        }

        [Test]
        [Category("P1")]
        [Description("Test Volume. Check whether Muted is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VideoView.Muted A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Muted_SET_GET_VALUE()
        {
            /* TEST CODE */
            Window.Instance.GetDefaultLayer().Add(_videoView);

            _videoView.Muted = true;
            Assert.AreEqual(true, _videoView.Muted, "Muted function does not work");

            _videoView.Muted = false;
            Assert.AreEqual(false, _videoView.Muted, "Muted function does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test Volume. Check whether Volume is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VideoView.Volume A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Volume_SET_GET_VALUE()
        {
            /* TEST CODE */
            PropertyMap propertyMap = new PropertyMap();
            propertyMap.Add("volumeLeft", new PropertyValue(0.0f));
            propertyMap.Add("volumeRight", new PropertyValue(5.0f));

            _videoView.Volume = propertyMap;
            float left = 0.0f;
            float right = 0.0f;
            _videoView.Volume.Find(0, "volumeLeft").Get(out left);
            _videoView.Volume.Find(1, "volumeRight").Get(out right);
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the VideoView.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VideoView.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                VideoView videoView = new VideoView();
                videoView.Dispose();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Finished. Check whether the Finished event triggered when the scroll complete")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VideoView.Finished E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public async Task Finished_CHECK_EVENT()
        {
            /* TEST CODE */
            _videoView.ResourceUrl = _videoPath;
            Assert.IsInstanceOf<VideoView>(_videoView, "Should be an instance of VideoView type.");
            try
            {
                _flagOnFinished = false;
                Assert.False(_flagOnFinished, "_flagOnFinished should false initial");
                _videoView.Finished += OnFinished;
                _videoView.Play();
                await Task.Delay(1000);
                Assert.True(_flagOnFinished, "_flagOnFinished should be true after Finished triggered");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            finally
            {
                _videoView.Finished -= OnFinished;
            }
        }
    }
}
