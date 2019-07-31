using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;
using System.Collections.Generic;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.Container Tests")]
    public class ContainerTests
    {

        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ContainerTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Test ChildCount. Check whether ChildCount returns the correct value")]
        [Property("SPEC", "Tizen.NUI.Container.ChildCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ChildCount_GET_VALUE()
        {
            /* TEST CODE */
            View parentContainer = new View();
            View childView = new View();
            Assert.AreEqual(0, parentContainer.ChildCount, "The child count of parentContainer should be zero");
            parentContainer.Add(childView);
            Assert.AreEqual(1, parentContainer.ChildCount, "The child count of parentContainer should be 1");
        }

        [Test]
        [Category("P1")]
        [Description("Test ChildCount. Check whether ChildCount returns the correct value")]
        [Property("SPEC", "Tizen.NUI.Container.ChildCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ChildCount_GET_VALUE_WITH_LAYER()
        {
            /* TEST CODE */
            Layer parentContainer = new Layer();
            View childView = new View();
            Assert.AreEqual(0, parentContainer.ChildCount, "The child count of parentContainer should be zero");
            parentContainer.Add(childView);
            Assert.AreEqual(1, parentContainer.ChildCount, "The child count of parentContainer should be 1");
        }

        [Test]
        [Category("P1")]
        [Description("Test Parent, Check whether it works or not.")]
        [Property("SPEC", "Tizen.NUI.Container.Parent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Parent_GET_VALUE()
        {
            /* TEST CODE */
            View parentContainer = new View();
            View childView = new View();
            parentContainer.Add(childView);
            View parent = childView.Parent;
            Assert.IsNotNull(parent, "Should be not null!");
            Assert.AreEqual(parent, parentContainer, "parent should be equal to parentContainer!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Parent, Check whether it works or not.")]
        [Property("SPEC", "Tizen.NUI.Container.Parent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Parent_GET_VALUE_WITH_LAYER()
        {
            /* TEST CODE */
            Layer parentContainer = new Layer();
            View childView = new View();
            parentContainer.Add(childView);
            Container parent = childView.GetParent();
            Assert.IsNotNull(parent, "Should be not null!");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetParent. Check whether GetParent return the correct value.")]
        [Property("SPEC", "Tizen.NUI.Container.GetParent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetParent_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            View Parent = new View();
            View Child = new View();
            Parent.Add(Child);
            Assert.IsNotNull(Child.GetParent(), "The child view's parent should be not null.");
            Assert.AreEqual(Parent, Child.GetParent(), "The child's parent should be equal to parent view");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetChildCount. Check whether GetChildCount return the right value.")]
        [Property("SPEC", "Tizen.NUI.Container.GetChildCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetChildCount_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            View Parent = new View();
            View Child = new View();
            Parent.Add(Child);
            Assert.AreEqual(1, Parent.GetChildCount(), "The Parent view's child count should be equal to 1.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Remove. Try to remove a child from parent")]
        [Property("SPEC", "Tizen.NUI.Container.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Remove_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View parentContainer = new View();
            View childView = new View();
            try
            {
                parentContainer.Add(childView);
                parentContainer.Remove(childView);
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
        [Description("Test Remove. Try to remove a child from parent")]
        [Property("SPEC", "Tizen.NUI.Container.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Remove_CHECK_RETURN_TYPE_WITH_LAYER()
        {
            /* TEST CODE */
            Layer parentContainer = new Layer();
            View childView = new View();
            try
            {
                parentContainer.Add(childView);
                parentContainer.Remove(childView);
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
        [Description("Test GetChildAt. Try to get the child at the specific index.")]
        [Property("SPEC", "Tizen.NUI.Container.GetChildAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetChildAt_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View parentContainer = new View();
            View childView = new View();
            parentContainer.Add(childView);
            View view = parentContainer.GetChildAt(0);
            Assert.IsTrue((view == childView), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test Children. Check whether Children is readable.")]
        [Property("SPEC", "Tizen.NUI.Container.Children A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Children_GET_VALUE()
        {
            /* TEST CODE */
            View parentContainer = new View();
            View childView = new View();
            parentContainer.Add(childView);
            List<View> children = parentContainer.Children;
            Assert.AreEqual(1, children.Count, "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test Add. Try to add a child to parent")]
        [Property("SPEC", "Tizen.NUI.Container.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Add_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View parentContainer = new View();
            View childView = new View();
            try
            {
                parentContainer.Add(childView);

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
        [Description("Test Add. Try to add a child to parent")]
        [Property("SPEC", "Tizen.NUI.Container.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Add_CHECK_RETURN_TYPE_WITH_LAYER()
        {
            /* TEST CODE */
            Layer parentContainer = new Layer();
            View childView = new View();
            try
            {
                parentContainer.Add(childView);

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
