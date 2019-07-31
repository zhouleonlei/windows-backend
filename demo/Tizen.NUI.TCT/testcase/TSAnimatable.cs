using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.Animatable Tests")]
    public class AnimatableTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("AnimatableTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali Animatable constructor test")]
        [Property("SPEC", "Tizen.NUI.Animatable.Animatable C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Animatable_INIT()
        {
            /* TEST CODE */
            var animatable = new Animatable();
            Assert.IsInstanceOf<Animatable>(animatable, "Should return Animatable instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali animatable GetProperty test, Check GetProperty works or not.")]
        [Property("SPEC", "Tizen.NUI.Animatable.GetProperty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetProperty_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            view.Opacity = 0.0f;

            float temp = 0.0f;
            var animatable = new Animatable();
            animatable.GetProperty(0).Get(out temp);
            Assert.AreEqual(view.Opacity, temp, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali animatable constructor test, Check SetProperty works or not.")]
        [Property("SPEC", "Tizen.NUI.Animatable.SetProperty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SetProperty_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            var animatable = new Animatable();
            animatable.SetProperty(55, new PropertyValue(1.0f));
            Assert.AreEqual(1.0f, view.Opacity, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali animatable GetPropertyIndex test, Check whether the GetPropertyIndex will return the right value or not.")]
        [Property("SPEC", "Tizen.NUI.Animatable.GetPropertyIndex M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetPropertyIndex_GET_VALUE()
        {
            /* TEST CODE */
            var animatable = new View();
            Assert.AreEqual(0, animatable.GetPropertyIndex("parentOrigin"), "Should be Equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali animatable GetPropertyName test, Check whether the GetPropertyName will return the right value or not.")]
        [Property("SPEC", "Tizen.NUI.Animatable.GetPropertyName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetPropertyName_GET_VALUE()
        {
            /* TEST CODE */
            var animatable = new View();
            Assert.AreEqual("parentOrigin", animatable.GetPropertyName(0), "Should be Equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali animatable GetPropertyType test, Check whether the GetPropertyType will return the right value or not.")]
        [Property("SPEC", "Tizen.NUI.Animatable.GetPropertyType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetPropertyType_GET_VALUE()
        {
            /* TEST CODE */
            var animatable = new View();
            Assert.AreEqual(PropertyType.Vector3, animatable.GetPropertyType(0), "Should be Equal!");
        }

        [Test]
        [Category("P1")]
        [Description("dali animatable IsPropertyAnimatable test, Check whether the IsPropertyAnimatable will return the right value or not.")]
        [Property("SPEC", "Tizen.NUI.Animatable.IsPropertyAnimatable M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void IsPropertyAnimatable_GET_VALUE()
        {
            /* TEST CODE */
            var animatable = new View();
            // 10000004 means BACKGROUND property, it should not be animatable.
            Assert.IsFalse(animatable.IsPropertyAnimatable(10000004), "Should be false.");
        }

        [Test]
        [Category("P1")]
        [Description("dali animatable IsPropertyWritable test, Check whether the IsPropertyWritable will return the right value or not.")]
        [Property("SPEC", "Tizen.NUI.Animatable.IsPropertyWritable M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void IsPropertyWritable_GET_VALUE()
        {
            /* TEST CODE */
            var animatable = new View();
            Assert.IsTrue(animatable.IsPropertyWritable(0), "Should be true.");
        }

        [Test]
        [Category("P1")]
        [Description("dali animatable RegisterProperty test, Check whether the RegisterProperty works or not.")]
        [Property("SPEC", "Tizen.NUI.Animatable.RegisterProperty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "string, PropertyValue")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RegisterProperty_GET_VALUE_WITH_NAME_VALUE()
        {
            /* TEST CODE */
            var animatable = new Animatable();
            int index = animatable.RegisterProperty("opacity", new PropertyValue(0.5f));
            Assert.Greater(index, 0, "Should be greater than zero.");
        }

        [Test]
        [Category("P1")]
        [Description("dali animatable RegisterProperty test, Check whether the RegisterProperty works or not.")]
        [Property("SPEC", "Tizen.NUI.Animatable.RegisterProperty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "string, PropertyValue, PropertyAccessMode")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RegisterProperty_GET_VALUE_WITH_NAME_VALUE_TYPE()
        {
            /* TEST CODE */
            var animatable = new Animatable();
            int index = animatable.RegisterProperty("opacity", new PropertyValue(0.5f), PropertyAccessMode.ReadWrite);
            Assert.Greater(index, 0, "Should be greater than zero.");
        }

        [Test]
        [Category("P1")]
        [Description("dali animatable AddPropertyNotification test, Check whether the AddPropertyNotification works or not.")]
        [Property("SPEC", "Tizen.NUI.Animatable.AddPropertyNotification M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AddPropertyNotification_TEST()
        {
            /* TEST CODE */
            var animatable = new View();
            PropertyNotification propertyNotification = animatable.AddPropertyNotification("PositionX", PropertyCondition.GreaterThan(100.0f));
            Assert.IsNotNull(propertyNotification, "Should be not null here!");
            Assert.IsInstanceOf<PropertyNotification>(propertyNotification, "Should be an instance of PropertyNotification");
        }

        [Test]
        [Category("P1")]
        [Description("dali animatable RemovePropertyNotifications test, Check whether the RemovePropertyNotifications works or not.")]
        [Property("SPEC", "Tizen.NUI.Animatable.RemovePropertyNotifications M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RemovePropertyNotifications_TEST()
        {
            /* TEST CODE */
            var animatable = new View();
            PropertyNotification propertyNotification = animatable.AddPropertyNotification("PositionX", PropertyCondition.GreaterThan(100.0f));
            try
            {
                animatable.RemovePropertyNotifications();
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
        [Description("dali animatable RemovePropertyNotification test, Check whether the RemovePropertyNotification works or not.")]
        [Property("SPEC", "Tizen.NUI.Animatable.RemovePropertyNotification M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RemovePropertyNotification_TEST()
        {
            /* TEST CODE */
            var animatable = new View();
            PropertyCondition condition = PropertyCondition.GreaterThan(100.0f);
            PropertyNotification propertyNotification = animatable.AddPropertyNotification("PositionX", condition);
            try
            {
                animatable.RemovePropertyNotification(propertyNotification);
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
        [Description("Test Dispose, try to dispose the Animatable.")]
        [Property("SPEC", "Tizen.NUI.Animatable.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                Animatable animatable = new Animatable();
                animatable.Dispose();
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
