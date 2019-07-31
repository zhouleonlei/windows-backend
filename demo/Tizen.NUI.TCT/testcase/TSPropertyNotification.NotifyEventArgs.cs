using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.PropertyNotification.NotifyEventArgs Tests")]
    public class PropertyNotificationNotifyEventArgsTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("NotifyEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a NotifyEventArgs object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.NotifyEventArgs.NotifyEventArgs C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void NotifyEventArgs_INIT()
        {
            var notifyEventArgs = new PropertyNotification.NotifyEventArgs();
            Assert.NotNull(notifyEventArgs, "Should be not null");
            Assert.IsInstanceOf<PropertyNotification.NotifyEventArgs>(notifyEventArgs, "Should be an instance of PropertyNotification.PropertyNotificationNotifyEventArgs");
        }

        [Test]
        [Category("P1")]
        [Description("Test PropertyNotification.Check whether PropertyNotification is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.NotifyEventArgs.PropertyNotification A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void PropertyNotification_SET_GET_VALUE()
        {
            PropertyNotification.NotifyEventArgs notifyEventArgs = new PropertyNotification.NotifyEventArgs();
            View view = new View();
            PropertyNotification propertyNotification = view.AddPropertyNotification("PositionX", PropertyCondition.GreaterThan(100.0f));
            notifyEventArgs.PropertyNotification = propertyNotification;
            Assert.AreEqual(13, notifyEventArgs.PropertyNotification.GetTargetProperty(), "Should be equal!");
        }
    }
}