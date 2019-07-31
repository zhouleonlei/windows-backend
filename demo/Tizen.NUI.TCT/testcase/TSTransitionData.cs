using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.TransitionData Tests")]
    public class TransitionDataTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("TransitionDataTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali TransitionData constructor test, Create a TransitionData instance with another PropertyMap instance.")]
        [Property("SPEC", "Tizen.NUI.TransitionData.TransitionData C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "PropertyMap")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void TransitionData_INIT_WITH_PROPERTYMAP()
        {
            /* TEST CODE */
            PropertyMap animator = new PropertyMap();
            animator.Add("alphaFunction", new PropertyValue("LINEAR"));

            PropertyMap timePeriod = new PropertyMap();
            timePeriod.Add("duration", new PropertyValue(0.8f));
            timePeriod.Add("delay", new PropertyValue(0.0f));
            animator.Add("timePeriod", new PropertyValue(timePeriod));

            PropertyMap _transition = new PropertyMap();
            _transition.Add("target", new PropertyValue("testVisual"));
            _transition.Add("property", new PropertyValue("pixelArea"));
            _transition.Add("targetValue", new PropertyValue(new Vector4(0, 0, 0, 1)));
            _transition.Add("targetValue", new PropertyValue(new Vector4(0, 0, 1, 1)));
            _transition.Add("animator", new PropertyValue(animator));

            var transitionData = new TransitionData(_transition);
            Assert.IsInstanceOf<TransitionData>(transitionData, "Should return TransitionData instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali TransitionData constructor test, Create a TransitionData instance with another PropertyArray instance.")]
        [Property("SPEC", "Tizen.NUI.TransitionData.TransitionData C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "PropertyArray")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void TransitionData_INIT_WITH_PROPERTYARRAY()
        {
            /* TEST CODE */
            PropertyMap animator = new PropertyMap();
            animator.Add("alphaFunction", new PropertyValue("LINEAR"));

            PropertyMap timePeriod = new PropertyMap();
            timePeriod.Add("duration", new PropertyValue(0.8f));
            timePeriod.Add("delay", new PropertyValue(0.0f));
            animator.Add("timePeriod", new PropertyValue(timePeriod));

            PropertyMap _transition = new PropertyMap();
            _transition.Add("target", new PropertyValue("testVisual"));
            _transition.Add("property", new PropertyValue("pixelArea"));
            _transition.Add("targetValue", new PropertyValue(new Vector4(0, 0, 0, 1)));
            _transition.Add("targetValue", new PropertyValue(new Vector4(0, 0, 1, 1)));
            _transition.Add("animator", new PropertyValue(animator));

            PropertyArray array = new PropertyArray();
            array.Add(new PropertyValue(_transition));

            var transitionData = new TransitionData(array);
            Assert.IsInstanceOf<TransitionData>(transitionData, "Should return TransitionData instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali TransitionData constructor test, Create a TransitionData instance with another TransitionData instance.")]
        [Property("SPEC", "Tizen.NUI.TransitionData.TransitionData C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "TransitionData")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void TransitionData_INIT_WITH_TransitionData()
        {
            /* TEST CODE */
            PropertyMap animator = new PropertyMap();
            animator.Add("alphaFunction", new PropertyValue("LINEAR"));

            PropertyMap timePeriod = new PropertyMap();
            timePeriod.Add("duration", new PropertyValue(0.8f));
            timePeriod.Add("delay", new PropertyValue(0.0f));
            animator.Add("timePeriod", new PropertyValue(timePeriod));

            PropertyMap _transition = new PropertyMap();
            _transition.Add("target", new PropertyValue("testVisual"));
            _transition.Add("property", new PropertyValue("pixelArea"));
            _transition.Add("targetValue", new PropertyValue(new Vector4(0, 0, 0, 1)));
            _transition.Add("targetValue", new PropertyValue(new Vector4(0, 0, 1, 1)));
            _transition.Add("animator", new PropertyValue(animator));

            var transitionData1 = new TransitionData(_transition);
            var transitionData = new TransitionData(transitionData1);
            Assert.IsInstanceOf<TransitionData>(transitionData, "Should return TransitionData instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali Count test, Check whether Count function return the correct Value or not.")]
        [Property("SPEC", "Tizen.NUI.TransitionData.Count M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Count_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            PropertyMap animator = new PropertyMap();
            animator.Add("alphaFunction", new PropertyValue("LINEAR"));

            PropertyMap timePeriod = new PropertyMap();
            timePeriod.Add("duration", new PropertyValue(0.8f));
            timePeriod.Add("delay", new PropertyValue(0.0f));
            animator.Add("timePeriod", new PropertyValue(timePeriod));

            PropertyMap _transition = new PropertyMap();
            _transition.Add("target", new PropertyValue("testVisual"));
            _transition.Add("property", new PropertyValue("pixelArea"));
            _transition.Add("targetValue", new PropertyValue(new Vector4(0, 0, 0, 1)));
            _transition.Add("targetValue", new PropertyValue(new Vector4(0, 0, 1, 1)));
            _transition.Add("animator", new PropertyValue(animator));

            PropertyArray array = new PropertyArray();
            array.Add(new PropertyValue(_transition));

            var transitionData = new TransitionData(array);
            Assert.AreEqual(1, transitionData.Count(), "Should be Equal");
        }

        [Test]
        [Category("P1")]
        [Description("dali GetAnimatorAt test, Check whether GetAnimatorAt function return the correct Value or not.")]
        [Property("SPEC", "Tizen.NUI.TransitionData.GetAnimatorAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetAnimatorAt_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            PropertyMap animator = new PropertyMap();
            animator.Add("alphaFunction", new PropertyValue("LINEAR"));

            PropertyMap timePeriod = new PropertyMap();
            timePeriod.Add("duration", new PropertyValue(0.8f));
            timePeriod.Add("delay", new PropertyValue(0.0f));
            animator.Add("timePeriod", new PropertyValue(timePeriod));

            PropertyMap _transition = new PropertyMap();
            _transition.Add("target", new PropertyValue("testVisual"));
            _transition.Add("property", new PropertyValue("pixelArea"));
            _transition.Add("targetValue", new PropertyValue(new Vector4(0, 0, 0, 1)));
            _transition.Add("targetValue", new PropertyValue(new Vector4(0, 0, 1, 1)));
            _transition.Add("animator", new PropertyValue(animator));

            PropertyArray array = new PropertyArray();
            array.Add(new PropertyValue(_transition));

            var transitionData = new TransitionData(array);
            PropertyMap map = transitionData.GetAnimatorAt(0);
            PropertyValue value = map.Find(0, "target");
            string target;
            value.Get(out target);
            Assert.AreEqual("testVisual", target, "Should be Equal");
        }
    }
}
