using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.GradientVisual Tests")]
    public class GradientVisualTests
    {
        private string TAG = "NUI";
        private static bool _flagComposingPropertyMap;
        internal class MyGradientVisual : GradientVisual
        {
            protected override void ComposingPropertyMap()
            {
                _flagComposingPropertyMap = true;
                base.ComposingPropertyMap();
            }
        }

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("GradientVisualTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a GradientVisual object.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.GradientVisual.GradientVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void GradientVisual_INIT()
        {
            /* TEST CODE */
            var gradientVisualMap = new GradientVisual();
            Assert.IsNotNull(gradientVisualMap, "Can't create success object GradientVisual");
            Assert.IsInstanceOf<GradientVisual>(gradientVisualMap, "Should be an instance of GradientVisual type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test StartPosition. Check whether StartPosition is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.GradientVisual.StartPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void StartPosition_SET_GET_VALUE()
        {
            GradientVisual gradientVisualMap = new GradientVisual();
            Vector2 vector = new Vector2(1.0f, 1.0f);
            gradientVisualMap.StartPosition = vector;
            Assert.AreEqual(1.0f, gradientVisualMap.StartPosition.X, "Retrieved StartPosition.X should be equal to set value");
            Assert.AreEqual(1.0f, gradientVisualMap.StartPosition.Y, "Retrieved StartPosition.Y should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test EndPosition. Check whether EndPosition is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.GradientVisual.EndPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void EndPosition_SET_GET_VALUE()
        {
            GradientVisual gradientVisualMap = new GradientVisual();
            Vector2 vector = new Vector2(1.0f, 1.0f);
            gradientVisualMap.EndPosition = vector;
            Assert.AreEqual(1.0f, gradientVisualMap.EndPosition.X, "Retrieved EndPosition.X should be equal to set value");
            Assert.AreEqual(1.0f, gradientVisualMap.EndPosition.Y, "Retrieved EndPosition.Y should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Center. Check whether Center is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.GradientVisual.Center A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Center_SET_GET_VALUE()
        {
            GradientVisual gradientVisualMap = new GradientVisual();
            Vector2 vector = new Vector2(1.0f, 1.0f);
            gradientVisualMap.Center = vector;
            Assert.AreEqual(1.0f, gradientVisualMap.Center.X, "Retrieved Center.X should be equal to set value");
            Assert.AreEqual(1.0f, gradientVisualMap.Center.Y, "Retrieved Center.Y should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Radius. Check whether Radius is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.GradientVisual.Radius A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Radius_SET_GET_VALUE()
        {
            GradientVisual gradientVisualMap = new GradientVisual();
            gradientVisualMap.Radius = 1.0f;
            Assert.AreEqual(1.0f, gradientVisualMap.Radius, "Retrieved Radius should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test StopOffset. Check whether StopOffset is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.GradientVisual.StopOffset A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void StopOffset_SET_GET_VALUE()
        {
            GradientVisual gradientVisualMap = new GradientVisual();
            PropertyArray array = new PropertyArray();
            for (float i = 0; i < 5; i += 1.0f)
            {
                array.Add(new PropertyValue(i));
            }
            gradientVisualMap.StopOffset = array;

            PropertyArray get = gradientVisualMap.StopOffset;
            Assert.IsNotNull(get, "Should not be null");
            Assert.AreEqual(array.Count(), get.Count(), "Should be equals to the set count");
            float set_value = 0.0f;
            float get_value = 0.0f;
            for (uint i = 0; i < array.Count(); i++)
            {
                array[i].Get(out set_value);
                get[i].Get(out get_value);
                Assert.AreEqual(set_value, get_value, "index" + i + " should be equals to set value");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test StopColor. Check whether StopColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.GradientVisual.StopColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void StopColor_SET_GET_VALUE()
        {
            GradientVisual gradientVisualMap = new GradientVisual();
            PropertyArray array = new PropertyArray();
            for (float i = 0; i < 5; i += 1.0f)
            {
                array.Add(new PropertyValue(i));
            }
            gradientVisualMap.StopColor = array;

            PropertyArray get = gradientVisualMap.StopColor;
            Assert.IsNotNull(get, "Should not be null");
            Assert.AreEqual(array.Count(), get.Count(), "Should be equals to the set count");
            float set_value = 0.0f;
            float get_value = 0.0f;
            for (uint i = 0; i < array.Count(); i++)
            {
                array[i].Get(out set_value);
                get[i].Get(out get_value);
                Assert.AreEqual(set_value, get_value, "index" + i + " should be equals to set value");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Units. Check whether Units is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.GradientVisual.Units A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Units_SET_GET_VALUE()
        {
            GradientVisual gradientVisualMap = new GradientVisual();
            gradientVisualMap.Units = GradientVisualUnitsType.ObjectBoundingBox;
            Assert.AreEqual(GradientVisualUnitsType.ObjectBoundingBox, gradientVisualMap.Units, "Retrieved Units should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SpreadMethod. Check whether SpreadMethod is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.GradientVisual.SpreadMethod A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SpreadMethod_SET_GET_VALUE()
        {
            GradientVisual gradientVisualMap = new GradientVisual();
            gradientVisualMap.SpreadMethod = GradientVisualSpreadMethodType.Pad;
            Assert.AreEqual(GradientVisualSpreadMethodType.Pad, gradientVisualMap.SpreadMethod, "Retrieved SpreadMethod should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Check override method ComposingPropertyMap is invoked when new GradientVisual instance.")]
        [Property("SPEC", "Tizen.NUI.GradientVisual.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ComposingPropertyMap_OVERRIDE_METHOD()
        {
            /*PRE CONDITION
             * _flagComposingPropertyMap flag is initialize false value
             * Create a instance MyGradientVisual
             */
            _flagComposingPropertyMap = false;
            Assert.False(_flagComposingPropertyMap, "_flagComposingPropertyMap should false initial");
            /**TEST CODE**/
            var myGradientVisual = new MyGradientVisual()
            {
                Center = new Vector2(1.0f, 1.0f),
                Radius = 2.0f,
            };
            Assert.IsInstanceOf<GradientVisual>(myGradientVisual, "Should be an instance of GradientVisual type.");
            PropertyMap propertyMap = myGradientVisual.OutputVisualMap;
            Assert.True(_flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");
        }
    }
}
