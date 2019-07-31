using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.View.VisibilityChangedEventArgs Tests")]
    public class VisibilityChangedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("VisibilityChangedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a VisibilityChangedEventArgs object. Check whether VisibilityChangedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.VisibilityChangedEventArgs.VisibilityChangedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void VisibilityChangedEventArgs_INIT()
        {
            /* TEST CODE */
            var visibilityChangedEventArgs = new View.VisibilityChangedEventArgs();
            Assert.IsNotNull(visibilityChangedEventArgs, "Can't create success object VisibilityChangedEventArgs");
            Assert.IsInstanceOf<View.VisibilityChangedEventArgs>(visibilityChangedEventArgs, "Should be an instance of VisibilityChangedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test View. Check whether View is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.VisibilityChangedEventArgs.View A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void View_SET_GET_VALUE()
        {
            /* TEST CODE */
            View.VisibilityChangedEventArgs visibilityChangedEventArgs = new View.VisibilityChangedEventArgs();
            View view = new View();
            visibilityChangedEventArgs.View = view;
            Assert.AreEqual(view, visibilityChangedEventArgs.View, "Retrieved View should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Visibility. Check whether Visibility is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.VisibilityChangedEventArgs.Visibility A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Visibility_SET_GET_VALUE()
        {
            /* TEST CODE */
            View.VisibilityChangedEventArgs visibilityChangedEventArgs = new View.VisibilityChangedEventArgs();
            View view = new View();
            view.BackgroundColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            Window.Instance.GetDefaultLayer().Add(view);
            visibilityChangedEventArgs.View = view;
            visibilityChangedEventArgs.Visibility = true;
            Assert.IsTrue(visibilityChangedEventArgs.Visibility, "Retrieved Visibility should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Type. Check whether Type is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.VisibilityChangedEventArgs.Type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Type_SET_GET_VALUE()
        {
            /* TEST CODE */
            View.VisibilityChangedEventArgs visibilityChangedEventArgs = new View.VisibilityChangedEventArgs();
            View view = new View();
            view.BackgroundColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            Window.Instance.GetDefaultLayer().Add(view);
            visibilityChangedEventArgs.View = view;
            visibilityChangedEventArgs.Type = VisibilityChangeType.SELF;
            Assert.AreEqual(VisibilityChangeType.SELF, visibilityChangedEventArgs.Type, "Retrieved Type should be equal to set value");
        }
    }
}
