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
    [Description("Tizen.NUI.FocusManager Tests")]
    public class FocusManagerTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("FocusManagerTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }
        private void OnFocusGroupChanged(object obj, EventArgs e)
        { }

        [Test]
        [Category("P1")]
        [Description("Get a FocusManager object. Check whether object is successfully get or not.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.Instance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Instance_GET_VALUE()
        {
            /* TEST CODE */
            FocusManager manager = FocusManager.Instance;

            Assert.IsNotNull(manager, "Can't get object FocusManager successfully");
            Assert.IsInstanceOf<FocusManager>(manager, "Should be an instance of FocusManager type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetCurrentFocusView.Test whether Set CurrentFocusView successfully")]
        [Property("SPEC", "Tizen.NUI.FocusManager.SetCurrentFocusView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SetCurrentFocusView_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                FocusManager manager = FocusManager.Instance;

                View view = new View();
                view.Focusable = true;
                Window.Instance.GetDefaultLayer().Add(view);

                Assert.IsTrue(manager.SetCurrentFocusView(view), "Should be return true if Set CurrentFocusView successfully");
                Assert.IsTrue(view == manager.GetCurrentFocusView(), "The CurrentFocusView should be the view set");
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
        [Description("Test GetCurrentFocusView.Test whether GetCurrentFocusView returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.GetCurrentFocusView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void GetCurrentFocusView_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            FocusManager manager = FocusManager.Instance;

            View view = new View();
            view.Focusable = true;
            Window.Instance.GetDefaultLayer().Add(view);
            manager.SetCurrentFocusView(view);

            Assert.IsTrue(view == manager.GetCurrentFocusView(), "The CurrentFocusView should be the view set");
        }

        [Test]
        [Category("P1")]
        [Description("Test MoveFocus.Test whether move FocusView successfully")]
        [Property("SPEC", "Tizen.NUI.FocusManager.MoveFocus M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void MoveFocus_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                FocusManager manager = FocusManager.Instance;

                View first = new View();
                first.Focusable = true;
                View second = new View();
                second.Focusable = true;
                TableView table = new TableView(1, 2);
                table.AddChild(first, new TableView.CellPosition(0, 0));
                table.AddChild(second, new TableView.CellPosition(0, 1));
                Window.Instance.GetDefaultLayer().Add(table);

                manager.SetCurrentFocusView(first);

                Assert.IsTrue(manager.MoveFocus(View.FocusDirection.Right), "Should be return true if move FocusView successfully");
                Assert.IsTrue(second == manager.GetCurrentFocusView(), "the curent focus view should be second view");

                Assert.IsTrue(manager.MoveFocus(View.FocusDirection.Left), "Should be return true if move FocusView successfully");
                Assert.IsTrue(first == manager.GetCurrentFocusView(), "the curent focus view should be first view");
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
        [Description("Test ClearFocus.Test whether clear FocusView successfully")]
        [Property("SPEC", "Tizen.NUI.FocusManager.ClearFocus M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ClearFocus_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                PushButton button = new PushButton();
                button.LabelText = "Focus";
                FocusManager.Instance.SetCurrentFocusView(button);

                FocusManager.Instance.ClearFocus();

                Assert.IsFalse(button == FocusManager.Instance.GetCurrentFocusView(), "button view should be not foucused");
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
        [Description("Test SetCustomAlgorithm. Try to Set the Custom Algorithm")]
        [Property("SPEC", "Tizen.NUI.FocusManager.SetCustomAlgorithm M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SetCustomAlgorithm_SET_VALUE()
        {
            /* TEST CODE */
            try
            {
                FocusManager manager = FocusManager.Instance;
                manager.SetCustomAlgorithm(new CustomFocusAlgorithm());
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
        [Description("Test SetAsFocusGroup.Check whether SetAsFocusGroup update the state of FocusGroup sucessfully")]
        [Property("SPEC", "Tizen.NUI.FocusManager.SetAsFocusGroup M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SetAsFocusGroup_SET_GET_VALUE_CHECK_STATE()
        {
            /* TEST CODE */
            FocusManager manager = FocusManager.Instance;

            View view = new View();
            view.Focusable = true;
            Window.Instance.GetDefaultLayer().Add(view);

            Assert.IsFalse(manager.IsFocusGroup(view), "The view should not be a FocusGroup at the begging");
            manager.SetAsFocusGroup(view, true);
            Assert.IsTrue(manager.IsFocusGroup(view), "The view should be a FocusGroup when FocusGroup be set true");
            manager.SetAsFocusGroup(view, false);
            Assert.IsFalse(manager.IsFocusGroup(view), "The view should not be a FocusGroup when FocusGroup be set false");
        }

        [Test]
        [Category("P1")]
        [Description("Test IsFocusGroup.Check whether IsFocusGroup returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.IsFocusGroup M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void IsFocusGroup_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            FocusManager manager = FocusManager.Instance;

            View view = new View();
            view.Focusable = true;
            Window.Instance.GetDefaultLayer().Add(view);

            Assert.IsFalse(manager.IsFocusGroup(view), "The view should not be a FocusGroup at the begging");
            manager.SetAsFocusGroup(view, true);
            Assert.IsTrue(manager.IsFocusGroup(view), "The view should be a FocusGroup when FocusGroup be set true");
            manager.SetAsFocusGroup(view, false);
            Assert.IsFalse(manager.IsFocusGroup(view), "The view should not be a FocusGroup when FocusGroup be set false");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetFocusGroup.Check whether GetFocusGroup returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.GetFocusGroup M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void GetFocusGroup_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            FocusManager manager = FocusManager.Instance;

            View parent = new View();
            parent.Focusable = true;
            Window.Instance.GetDefaultLayer().Add(parent);
            manager.SetAsFocusGroup(parent, true);

            View child = new View();
            child.Focusable = true;
            parent.Add(child);
            manager.SetAsFocusGroup(child, true);

            View grandchild = new View();
            grandchild.Focusable = true;
            child.Add(grandchild);
            manager.SetAsFocusGroup(grandchild, true);

            Assert.IsTrue(grandchild == manager.GetFocusGroup(grandchild), "Should be equals to grandchild");
        }

        [Test]
        [Category("P1")]
        [Description("Test MoveFocusBackward.Check whether MoveFocusBackward works.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.MoveFocusBackward M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void MoveFocusBackward_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            FocusManager manager = FocusManager.Instance;
            View first = new View();
            first.Size2D = new Size2D(100, 200);
            first.Position = new Position(100, 100, 0);
            Window.Instance.GetDefaultLayer().Add(first);

            View second = new View();
            second.Size2D = new Size2D(100, 200);
            second.Position = new Position(100, 100, 0);
            Window.Instance.GetDefaultLayer().Add(second);

            manager.SetCurrentFocusView(first);
            manager.SetCurrentFocusView(second);
            try
            {
                manager.MoveFocusBackward();
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
        [Description("Test FocusIndicator. Check whether FocusIndicator is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusIndicator A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void FocusIndicator_SET_GET_VALUE()
        {
            /* TEST CODE */
            FocusManager manager = FocusManager.Instance;
            View view = new View();
            manager.FocusIndicator = view;
            Assert.IsTrue(view == manager.FocusIndicator, "Should be equals to view set");
        }

        [Test]
        [Category("P1")]
        [Description("Test FocusGroupLoop. Check whether FocusGroupLoop is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusGroupLoop A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void FocusGroupLoop_SET_GET_VALUE()
        {
            /* TEST CODE */
            FocusManager manager = FocusManager.Instance;

            View view = new View();
            manager.FocusGroupLoop = true;
            Assert.IsTrue(manager.FocusGroupLoop, "Should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test FocusChanged.Check whether FocusChanged defined in the spec is callable.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void FocusChanged_CHECK_EVENT()
        {
            FocusManager manager = FocusManager.Instance;
            View view1 = new View();
            View view2 = new View();
            view1.Focusable = true;
            view2.Focusable = true;
            Window.Instance.GetDefaultLayer().Add(view1);
            Window.Instance.GetDefaultLayer().Add(view2);
            manager.SetCurrentFocusView(view1);

            bool flag = false;
            manager.FocusChanged += (obj, e) =>
            {
                flag = true;
            };

            manager.SetCurrentFocusView(view2);
            Assert.IsTrue(flag, "FocusChanged is not be called");
        }
    }

    public class CustomFocusAlgorithm : FocusManager.ICustomFocusAlgorithm
    {
        public View GetNextFocusableView(View current, View proposed, View.FocusDirection direction)
        {
            return new View();
        }
    }
}
