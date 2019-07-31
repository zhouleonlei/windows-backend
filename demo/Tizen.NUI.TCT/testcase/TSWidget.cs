using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Widget Tests")]
    public class WidgetTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("WidgetTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a Widget object.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Widget.Widget C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Widget_INIT()
        {
            /* TEST CODE */
            //var Widget = new Widget("org.tizen.example.NUISamples.Tizen", "", 450, 700, -1);
            var Widget = new Widget();

            Assert.IsNotNull(Widget, "Can't create success object Widget");
            Assert.IsInstanceOf<Widget>(Widget, "Should be an instance of Widget type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetContentInfo, try to set content info for Widget.")]
        [Property("SPEC", "Tizen.NUI.Widget.SetContentInfo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@partner.samsung.com")]
        public void SetContentInfo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                Widget widget = new Widget();
                widget.SetContentInfo("Widget");
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
        [Description("Test Dispose, try to dispose the Widget.")]
        [Property("SPEC", "Tizen.NUI.Widget.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                //Widget Widget = new Widget("org.tizen.example.NUISamples.Tizen", "", 1920, 800, 1.0f);
                Widget Widget = new Widget();
                Widget.Dispose();
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
