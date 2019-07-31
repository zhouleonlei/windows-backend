using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.View.LayoutDirectionChangedEventArgs Tests")]
    public class ViewLayoutDirectionChangedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("LayoutDirectionChangedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a LayoutDirectionChangedEventArgs object. Check whether LayoutDirectionChangedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.LayoutDirectionChangedEventArgs.LayoutDirectionChangedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void LayoutDirectionChangedEventArgs_INIT()
        {
            /* TEST CODE */
            var layoutDirectionChangedEventArgs = new View.LayoutDirectionChangedEventArgs();
            Assert.IsNotNull(layoutDirectionChangedEventArgs, "Can't create success object LayoutDirectionChangedEventArgs");
            Assert.IsInstanceOf<View.LayoutDirectionChangedEventArgs>(layoutDirectionChangedEventArgs, "Should be an instance of LayoutDirectionChangedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Type. Check whether Type is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.LayoutDirectionChangedEventArgs.Type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Type_SET_GET_VALUE()
        {
            /* TEST CODE */
            View.LayoutDirectionChangedEventArgs layoutDirectionChangedEventArgs = new View.LayoutDirectionChangedEventArgs();
            layoutDirectionChangedEventArgs.Type = ViewLayoutDirectionType.LTR;
            Assert.AreEqual(ViewLayoutDirectionType.LTR, layoutDirectionChangedEventArgs.Type, "Retrieved Type should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test View. Check whether View is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.LayoutDirectionChangedEventArgs.View A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void View_SET_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            View.LayoutDirectionChangedEventArgs layoutDirectionChangedEventArgs = new View.LayoutDirectionChangedEventArgs();
            layoutDirectionChangedEventArgs.View = view;
            View view2 = layoutDirectionChangedEventArgs.View;
            Assert.IsTrue((view == view2), "Retrieved View should be equal to set value");
        }
    }
}
