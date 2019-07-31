using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.VisualAnimator Tests")]
    public class VisualAnimatorTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";
        private static bool _flagComposingPropertyMap;
        internal class MyVisualAnimator : VisualAnimator
        {
            protected override void ComposingPropertyMap()
            {
                _flagComposingPropertyMap = true;
            }
        }

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("VisualAnimatorTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a VisualAnimator object.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.VisualAnimator.VisualAnimator C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void VisualAnimator_INIT()
        {
            /* TEST CODE */
            var animatorVisual = new VisualAnimator();
            Assert.IsNotNull(animatorVisual, "Can't create success object VisualAnimator");
            Assert.IsInstanceOf<VisualAnimator>(animatorVisual, "Should be an instance of VisualAnimator type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test AlphaFunction. Check whether AlphaFunction is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualAnimator.AlphaFunction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AlphaFunction_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualAnimator map = new VisualAnimator();
            map.AlphaFunction = AlphaFunction.BuiltinFunctions.EaseIn;
            Assert.AreEqual(AlphaFunction.BuiltinFunctions.EaseIn, map.AlphaFunction, "Retrieved AlphaFunction should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test StartTime. Check whether StartTime is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualAnimator.StartTime A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void StartTime_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualAnimator map = new VisualAnimator();
            map.StartTime = 10;
            Assert.AreEqual(10, map.StartTime, "Retrieved StartTime should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test EndTime. Check whether EndTime is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualAnimator.EndTime A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void EndTime_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualAnimator map = new VisualAnimator();
            map.EndTime = 1000;
            Assert.AreEqual(1000, map.EndTime, "Retrieved EndTime should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Target. Check whether Target is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualAnimator.Target A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Target_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualAnimator map = new VisualAnimator();
            map.Target = "IconVisual";
            Assert.AreEqual("IconVisual", map.Target, "Retrieved Target should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test PropertyIndex. Check whether PropertyIndex is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualAnimator.PropertyIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PropertyIndex_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualAnimator map = new VisualAnimator();
            map.PropertyIndex = "MixColor";
            Assert.AreEqual("MixColor", map.PropertyIndex, "Retrieved PropertyIndex should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test DestinationValue. Check whether DestinationValue is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualAnimator.DestinationValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void DestinationValue_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualAnimator map = new VisualAnimator();
            object color = new Color(1.0f, 0.0f, 1.0f, 1.0f);
            map.DestinationValue = color;
            Assert.IsTrue(color.Equals(map.DestinationValue), "Retrieved DestinationValue should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Check override method ComposingPropertyMap is invoked when new VisualAnimator instance.")]
        [Property("SPEC", "Tizen.NUI.VisualAnimator.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ComposingPropertyMap_OVERRIDE_METHOD()
        {
            /*PRE CONDITION
             * _flagComposingPropertyMap flag is initialize false value
             * Create a instance VisualAnimator
             */
            _flagComposingPropertyMap = false;
            Assert.False(_flagComposingPropertyMap, "_flagComposingPropertyMap should false initial");
            /**TEST CODE**/
            var myVisualAnimator = new MyVisualAnimator()
            {
                StartTime = 10,
                EndTime = 200,
            };
            Assert.IsInstanceOf<VisualAnimator>(myVisualAnimator, "Should be an instance of VisualAnimator type.");
            PropertyMap propertyMap = myVisualAnimator.OutputVisualMap;
            Assert.True(_flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");
        }
    }
}
