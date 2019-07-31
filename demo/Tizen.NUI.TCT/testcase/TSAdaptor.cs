using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.Adaptor Tests")]
    public class AdaptorTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("AdaptorTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Instance. Check whether Instance returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Adaptor.Instance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Instance_GET_VALUE()
        {
            /* TEST CODE */
            Adaptor adaptor = Adaptor.Instance;
            Assert.IsInstanceOf<Adaptor>(adaptor, "Should be an Instance of Adaptor!");
        }

        [Test]
        [Category("P1")]
        [Description("Test FeedKeyEvent.")]
        [Property("SPEC", "Tizen.NUI.Adaptor.FeedKeyEvent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void FeedKeyEvent_TEST()
        {
            /* TEST CODE */
            try
            {
                Key key = new Key()
                {
                    KeyPressedName = "Up",
                    State = Key.StateType.Down,
                };
                Adaptor adaptor = Adaptor.Instance;
                adaptor.FeedKeyEvent(key);
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
        [Description("Test FeedWheelEvent.")]
        [Property("SPEC", "Tizen.NUI.Adaptor.FeedWheelEvent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void FeedWheelEvent_TEST()
        {
            /* TEST CODE */
            try
            {
                Vector2 point = new Vector2(1.0f, 1.0f);
                Wheel wheel = new Wheel(Wheel.WheelType.MouseWheel, 1, 0x2, point, 1, 1000u);
                Adaptor adaptor = Adaptor.Instance;
                adaptor.FeedWheelEvent(wheel);
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
