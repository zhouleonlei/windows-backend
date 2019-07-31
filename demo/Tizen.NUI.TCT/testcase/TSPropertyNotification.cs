using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI;
using System.Threading.Tasks;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.PropertyNotification Tests")]
    public class PropertyNotificationTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("PropertyNotificationTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a PropertyNotification object. Check whether PropertyNotification is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.PropertyNotification C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PropertyNotification_INIT()
        {
            /* TEST CODE */
            var propertyNotification = new Tizen.NUI.PropertyNotification();
            Assert.IsNotNull(propertyNotification, "Can't create success object PropertyNotification");
            Assert.IsInstanceOf<PropertyNotification>(propertyNotification, "Should be an instance of PropertyNotification type.");
        }

        [Test]
        [Category("P1")]
        [Description("Create a PropertyNotification object. Check whether PropertyNotification is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.PropertyNotification C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "PropertyNotification")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PropertyNotification_INIT_WITH_PROPERTYNOTIFICATION()
        {
            /* TEST CODE */
            View view = new View();
            PropertyNotification propertyNotification = view.AddPropertyNotification("PositionX", PropertyCondition.GreaterThan(100.0f));
            var notification = new Tizen.NUI.PropertyNotification(propertyNotification);
            Assert.IsNotNull(notification, "Can't create success object PropertyNotification");
            Assert.IsInstanceOf<PropertyNotification>(notification, "Should be an instance of PropertyNotification type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetTarget. Check whether GetTarget works or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.GetTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetTarget_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            PropertyNotification propertyNotification = view.AddPropertyNotification("PositionX", PropertyCondition.GreaterThan(100.0f));
            Animatable animatable = propertyNotification.GetTarget();
            Assert.IsNotNull(animatable, "Should be not null!");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetCondition. Check whether GetCondition works or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.GetCondition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetCondition_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            PropertyCondition condition = PropertyCondition.GreaterThan(100.0f);
            PropertyNotification propertyNotification = view.AddPropertyNotification("PositionX", condition);
            PropertyCondition propertyCondition = propertyNotification.GetCondition();
            bool flag = false;
            if(propertyCondition == condition)
            {
                flag = true;
            }
            Assert.IsTrue(flag, "The flag should be true here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetTargetProperty. Check whether GetTargetProperty works or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.GetTargetProperty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetTargetProperty_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            PropertyNotification propertyNotification = view.AddPropertyNotification("PositionX", PropertyCondition.GreaterThan(100.0f));
            Assert.AreEqual(13, propertyNotification.GetTargetProperty(), "Should be equal here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetNotifyMode. Check whether SetNotifyMode works or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.SetNotifyMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SetNotifyMode_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            PropertyNotification propertyNotification = view.AddPropertyNotification("PositionX", PropertyCondition.GreaterThan(100.0f));
            propertyNotification.SetNotifyMode(PropertyNotification.NotifyMode.NotifyOnChanged);
            PropertyNotification.NotifyMode notifyMode = propertyNotification.GetNotifyMode();
            Assert.AreEqual(PropertyNotification.NotifyMode.NotifyOnChanged, notifyMode, "Should be equal here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetNotifyMode. Check whether GetNotifyMode works or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.GetNotifyMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetNotifyMode_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            PropertyNotification propertyNotification = view.AddPropertyNotification("PositionX", PropertyCondition.GreaterThan(100.0f));
            propertyNotification.SetNotifyMode(PropertyNotification.NotifyMode.NotifyOnChanged);
            PropertyNotification.NotifyMode notifyMode = propertyNotification.GetNotifyMode();
            Assert.AreEqual(PropertyNotification.NotifyMode.NotifyOnChanged, notifyMode, "Should be equal here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetNotifyResult. Check whether GetNotifyResult works or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.GetNotifyResult M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetNotifyResult_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            PropertyNotification propertyNotification = view.AddPropertyNotification("PositionX", PropertyCondition.GreaterThan(100.0f));
            propertyNotification.SetNotifyMode(PropertyNotification.NotifyMode.NotifyOnChanged);
            propertyNotification.Notified += (obj, e) =>
            {
                Tizen.Log.Fatal("TCT", "Notified!");
            };
            view.Position = new Position(0.0f, 0.0f, 0.0f);
            Assert.AreEqual(false, propertyNotification.GetNotifyResult(), "Should be equal here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Notified. Check whether Notified works or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.Notified E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Notified_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            View view = new View();
            Window.Instance.Add(view);
            PropertyNotification propertyNotification = view.AddPropertyNotification("positionX", PropertyCondition.GreaterThan(100.0f));
            propertyNotification.SetNotifyMode(PropertyNotification.NotifyMode.NotifyOnChanged);
            bool flag = false;
            propertyNotification.Notified += (obj, e) =>
            {
                flag = true;
            };

            view.Position = new Position(300.0f, 0.0f, 0.0f);
            await Task.Delay(200);
            Assert.AreEqual(true, flag, "Should be equal here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the PropertyNotification.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            try
            {
                PropertyNotification propertyNotification = new PropertyNotification();
                propertyNotification.Dispose();
            }
            catch (Exception e)
            {
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test DownCast. Get the PropertyNotification instance from a handle instance")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void DownCast_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            BaseHandle handle = new PropertyNotification();
            PropertyNotification propertyNotification = PropertyNotification.DownCast(handle);
            Assert.IsInstanceOf<PropertyNotification>(propertyNotification, "Should return a instance of PropertyNotification");
        }

        [Test]
        [Category("P1")]
        [Description("Test NotifySignal. Check whether NotifySignal works or not")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.NotifySignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task NotifySignal_CHECK()
        {
            /* TEST CODE */
            View view = new View();
            Window.Instance.Add(view);
            PropertyNotification propertyNotification = view.AddPropertyNotification("positionX", PropertyCondition.GreaterThan(100.0f));
            propertyNotification.SetNotifyMode(PropertyNotification.NotifyMode.NotifyOnChanged);
            bool flag = false;
            propertyNotification.Notified += (obj, e) =>
            {
                flag = true;
            };

            view.Position = new Position(300.0f, 0.0f, 0.0f);
            await Task.Delay(200);
            PropertyNotifySignal propertyNotifySignal = propertyNotification.NotifySignal();

            Assert.IsNotNull(propertyNotifySignal, "Should be not null");
            Assert.IsInstanceOf<PropertyNotifySignal>(propertyNotifySignal, "Should be an instance of propertyNotifySignal");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetPropertyNotificationFromPtr Check whether GetPropertyNotificationFromPtr works or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.GetPropertyNotificationFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetPropertyNotificationFromPtr_CHECK()
        {
            /* TEST CODE */
            try
            {
                Assert.IsTrue(true, "Cann't be tested, this API will move into internal after the ACR");
            }
            catch (Exception e)
            {
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Assign. Check whether Assign works or not")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Assign_CHECK()
        {
            /* TEST CODE */
            try
            {
                View view = new View();
                Window.Instance.Add(view);
                PropertyNotification propertyNotification1 = view.AddPropertyNotification("positionX", PropertyCondition.GreaterThan(100.0f));
                PropertyNotification propertyNotification2 = view.AddPropertyNotification("positionY", PropertyCondition.GreaterThan(100.0f));
                propertyNotification2.Assign(propertyNotification1);
            }
            catch (Exception e)
            {
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P2")]
        [Description("Check exception when the args of the Assign method is null.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Assign_CHECK_NULL()
        {
            /* TEST CODE */
            try
            {
                View view = new View();
                Window.Instance.Add(view);
                PropertyNotification propertyNotification1 = view.AddPropertyNotification("positionX", PropertyCondition.GreaterThan(100.0f));
                propertyNotification1.Assign(null);
                Assert.Fail("Should throw the ArgumentNullException!");
            }
            catch (ArgumentNullException e)
            {
                Assert.True(true);
            }
        }
    }
}
