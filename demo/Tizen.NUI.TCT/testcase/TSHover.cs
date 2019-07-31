using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Hover Tests")]
    public class HoverTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("HoverTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a Hover object. Check whether Hover is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Hover.Hover C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Hover_INIT()
        {
            /* TEST CODE */
            var hover = new Hover();
            Assert.IsNotNull(hover, "Can't create success object Hover");
            Assert.IsInstanceOf<Hover>(hover, "Should be an instance of Hover type.");
        }


        [Test]
        [Category("P1")]
        [Description("Test GetPointCount.Check whether GetPointCount returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.Hover.GetPointCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void GetPointCount_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Hover hover = new Hover();
            Assert.AreEqual(0, hover.GetPointCount(), "Should be equals to the origin value of pointCount");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetDeviceId.Check whether GetDeviceId returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.Hover.GetDeviceId M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void GetDeviceId_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Hover hover = new Hover();
            Assert.AreEqual(-1, hover.GetDeviceId(0), "Should be equals to the origin value of DeviceId");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetState.Check whether GetState returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.Hover.GetState M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void GetState_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Hover hover = new Hover();
            Assert.AreEqual(PointStateType.Finished, hover.GetState(0), "Should be equals to the origin value of state");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetHitView.Check whether GetHitView returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.Hover.GetHitView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void GetHitView_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Hover hover = new Hover();

            Assert.IsInstanceOf<View>(hover.GetHitView(0), "Should be instance of Actor");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetLocalPosition.Check whether GetLocalPosition returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.Hover.GetLocalPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void GetLocalPosition_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Hover hover = new Hover();
            Assert.AreEqual(0.0f, hover.GetLocalPosition(0).X, "Should be equals to the origin value of LocalPosition.X");
            Assert.AreEqual(0.0f, hover.GetLocalPosition(0).Y, "Should be equals to the origin value of LocalPosition.Y");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetScreenPosition.Check whether GetScreenPosition returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.Hover.GetScreenPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void GetScreenPosition_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Hover hover = new Hover();
            Assert.AreEqual(0.0f, hover.GetScreenPosition(0).X, "Should be equals to the origin value of ScreenPosition.X");
            Assert.AreEqual(0.0f, hover.GetScreenPosition(0).Y, "Should be equals to the origin value of ScreenPosition.Y");
        }

        [Test]
        [Category("P1")]
        [Description("Test Time property. Check whether Time returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.Hover.Time A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void Time_Property_GET()
        {
            /* TEST CODE */
            Hover hover = new Hover();
            Assert.AreEqual(0u, hover.Time, "Should be equals to the origin value of Time");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Hover.")]
        [Property("SPEC", "Tizen.NUI.Hover.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                Hover hover = new Hover();
                hover.Dispose();
            }
            catch (Exception e)
            {
                Tizen.Log.Error("Test CellPosition.cs", "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
    }
}
