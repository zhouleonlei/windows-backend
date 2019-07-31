using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.CustomViewRegistry Tests")]
    public class CustomViewRegistryTests
    {
        private static string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, " Init() is called!");
            App.MainTitleChangeText("CustomViewRegistryTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, " Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Instance property test.Check whether Instance is readable.")]
        [Property("SPEC", "Tizen.NUI.CustomViewRegistry.Instance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Instance_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            try
            {
                var myView = new MyView();
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
        [Description("Register function test.Check whether Register function works or not.")]
        [Property("SPEC", "Tizen.NUI.CustomViewRegistry.Register M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Register_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            try
            {
                var myView = new MyView();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
    }

    public class MyView : CustomView
    {
        View view;
        static CustomView CreateInstance()
        {
            return new MyView();
        }
        static MyView()
        {
            CustomViewRegistry.Instance.Register(CreateInstance, typeof(MyView));
        }

        public MyView() : base(typeof(MyView).FullName, CustomViewBehaviour.ViewBehaviourDefault)
        {
            OnInitialize();
        }

        public void OnInitialize()
        {
            view = new BaseComponents.View();
            view.Size2D = new Size2D(200, 200);
            view.BackgroundColor = Color.Red;
            this.Add(view);
        }
    }
}
