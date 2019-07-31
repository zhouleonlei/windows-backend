using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;
using System.Threading.Tasks;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.BaseHandle Tests")]
    public class BaseHandleTests
    {
        private string TAG = "NUI";
        private bool _flag = false;

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("BaseHandleTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        private void baseHandleEventCallback(object sender, EventArgs e)
        {
            _flag = true;
        }

        [Test]
        [Category("P1")]
        [Description("dali BaseHandle constructor test")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.BaseHandle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void BaseHandle_INIT()
        {
            /* TEST CODE */
            var baseHandle = new BaseHandle();
            Assert.IsInstanceOf<BaseHandle>(baseHandle, "Should return BaseHandle instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali BaseHandle constructor test")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.BaseHandle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "BaseHandle")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void BaseHandle_INIT_WITH_BASEHANDLE()
        {
            /* TEST CODE */
            var baseHandle1 = new View();
            var baseHandle = new BaseHandle(baseHandle1);
            Assert.IsInstanceOf<BaseHandle>(baseHandle, "Should return BaseHandle instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali baseHandle DoAction test, Check DoAction works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.DoAction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void DoAction_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            view.Size2D = new Size2D(100, 100);
            view.Position = new Position(100, 100, 0);
            view.BackgroundColor = Color.Red;
            Window.Instance.GetDefaultLayer().Add(view);

            PropertyMap map = new PropertyMap();
            Assert.IsTrue(view.DoAction("hide", map), "Should be true!");
        }

        [Test]
        [Category("P1")]
        [Description("dali baseHandle EqualTo test, Check EqualTo works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void EqualTo_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            View view1 = new View();
            view1 = view;
            Assert.IsTrue(view.EqualTo(view1), "Should be true!");
        }

        [Test]
        [Category("P1")]
        [Description("dali baseHandle NotEqualTo test, Check NotEqualTo works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void NotEqualTo_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            View view1 = new View();
            Assert.IsTrue(view.NotEqualTo(view1), "Should be true!");
        }

        [Test]
        [Category("P1")]
        [Description("dali baseHandle IsEqual test, Check IsEqual works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.IsEqual M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void IsEqual_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            View view1 = new View();
            view1 = view;
            Assert.IsTrue(view.IsEqual(view1), "Should be true!");
        }

        [Test]
        [Category("P1")]
        [Description("dali baseHandle GetTypeName test, Check GetTypeName works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.GetTypeName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetTypeName_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            PushButton button = new PushButton();
            Assert.AreEqual("PushButton", button.GetTypeName(), "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali baseHandle HasBody test, Check whether the HasBody will return the right value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.HasBody M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void HasBody_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            view.Size2D = new Size2D(100, 100);
            view.Position = new Position(100, 100, 0);
            view.BackgroundColor = Color.Red;
            Window.Instance.GetDefaultLayer().Add(view);
            Assert.IsTrue(view.HasBody(), "Should be true!");
        }

        [Test]
        [Category("P1")]
        [Description("dali baseHandle BitwiseAnd test, Check whether the BitwiseAnd will return the right value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.BitwiseAnd M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void BitwiseAnd_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            view.Size2D = new Size2D(100, 100);
            view.Position = new Position(100, 100, 0);
            view.BackgroundColor = Color.Red;
            Window.Instance.GetDefaultLayer().Add(view);

            BaseHandle view1 = view & view;
            Assert.IsTrue(view1.HasBody(), "Should be true!");
        }

        [Test]
        [Category("P1")]
        [Description("dali baseHandle BitwiseOr test, Check whether the BitwiseOr will return the right value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.BitwiseOr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void BitwiseOr_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            view.Size2D = new Size2D(100, 100);
            view.Position = new Position(100, 100, 0);
            view.BackgroundColor = Color.Red;
            Window.Instance.GetDefaultLayer().Add(view);

            BaseHandle view1 = view | view;
            Assert.IsTrue(view1.HasBody(), "Should be true!");
        }

        [Test]
        [Category("P1")]
        [Description("dali baseHandle LogicalNot test, Check whether the LogicalNot will return the right value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.LogicalNot M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void LogicalNot_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            view.Size2D = new Size2D(200, 200);
            view.BackgroundColor = Color.Red;
            Window.Instance.GetDefaultLayer().Add(view);
            Assert.IsFalse(!view, "view should be true!");
        }

        [Test]
        [Category("P1")]
        [Description("dali baseHandle Reset test, Check whether the Reset works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.Reset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Reset_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            view.Size2D = new Size2D(100, 100);
            view.Position = new Position(100, 100, 0);
            view.BackgroundColor = Color.Red;
            Window.Instance.GetDefaultLayer().Add(view);
            Window.Instance.GetDefaultLayer().Remove(view);
            view.Reset();
            Assert.IsTrue((view == null), "Should be true!");
        }

        [Test]
        [Category("P1")]
        [Description("dali baseHandle Explicit test, Check whether the Explicit will return the right value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.Explicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Explicit_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            view.Size2D = new Size2D(100, 100);
            view.Position = new Position(100, 100, 0);
            view.BackgroundColor = Color.Red;
            Window.Instance.GetDefaultLayer().Add(view);
            bool flag = false;
            if (view)
            {
                flag = true;
            }
            Assert.IsTrue(flag, "Should be true!");
        }


        [Test]
        [Category("P1")]
        [Description("dali baseHandle Equality test, Check whether Equality works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.== M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "BaseHandle,BaseHandle")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Equality_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            view.Size2D = new Size2D(100, 100);
            view.Position = new Position(100, 100, 0);
            view.BackgroundColor = Color.Red;
            Window.Instance.GetDefaultLayer().Add(view);

            View view1 = new View();
            view1 = view;
            Assert.IsTrue((view1 == view), "Should be true!");
        }

        [Test]
        [Category("P1")]
        [Description("dali baseHandle Inequality test, Check whether the Inequality will return the right value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.!= M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "BaseHandle,BaseHandle")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Inequality_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            view.Size2D = new Size2D(100, 100);
            view.Position = new Position(100, 100, 0);
            view.BackgroundColor = Color.Red;
            Window.Instance.GetDefaultLayer().Add(view);
            View view1 = new View();
            view1 = new View();
            Assert.IsTrue((view1 != view), "Should be true!");
        }

        [Test]
        [Category("P1")]
        [Description("dali baseHandle true test, Check whether the true will return the right value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.True M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void True_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            view.Size2D = new Size2D(100, 100);
            view.Position = new Position(100, 100, 0);
            view.BackgroundColor = Color.Red;
            Window.Instance.GetDefaultLayer().Add(view);
            bool flag = false;
            if (view)
            {
                flag = true;
            }
            Assert.IsTrue(flag, "Should be true!");
        }

        [Test]
        [Category("P1")]
        [Description("dali baseHandle false test, Check whether the false will return the right value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.False M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void False_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            view.Size2D = new Size2D(100, 100);
            view.Position = new Position(100, 100, 0);
            view.BackgroundColor = Color.Red;
            Window.Instance.GetDefaultLayer().Add(view);
            bool flag = true;
            if (!view)
            {
                flag = false;
            }
            Assert.IsTrue(flag, "Should be true!");
        }

        [Test]
        [Category("P1")]
        [Description("PropertySet test, Check whether PropertySet event will be triggered.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.PropertySet E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public async Task PropertySet_EVENT()
        {
            /* TEST CODE */
            View view = new View();
            view.Size2D = new Size2D(100, 100);
            view.Position = new Position(100, 100, 0);
            view.BackgroundColor = Color.Red;
            _flag = false;
            view.PropertySet += baseHandleEventCallback;
            Window.Instance.GetDefaultLayer().Add(view);
            view.StyleName = "fake";
            await Task.Delay(20);
            Assert.IsTrue(_flag, "Should be true!");
            Window.Instance.GetDefaultLayer().Remove(view);
            view.PropertySet -= baseHandleEventCallback;
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the BaseHandle.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                BaseHandle baseHandle = new BaseHandle();
                baseHandle.Dispose();
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
        [Description("Test GetTypeInfo. Check whether GetTypeInfo returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.GetTypeInfo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetTypeInfo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                PushButton view = new PushButton();
                var typeInfo = TypeRegistry.Get().GetTypeInfo("PushButton");
                Assert.IsInstanceOf<TypeInfo>(typeInfo, "Should be an instance of TypeInfo type.");
                Assert.True(view.GetTypeInfo(typeInfo), "Should be true");
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
        [Description("Test Equals. Check whether Equals returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Equals_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                BaseHandle baseHandle = new View();
                View view = baseHandle as View;
                View view2 = new View();
                Assert.True(baseHandle.Equals(view), "Should be true");
                Assert.False(baseHandle.Equals(view2), "Should be false");
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
        [Description("Test GetHashCode. Check whether GetHashCode returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetHashCode_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                BaseHandle baseHandle = new View();
                Assert.GreaterOrEqual(baseHandle.GetHashCode(), 0, "Should be true");
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
