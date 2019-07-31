using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.PrimitiveVisual Tests")]
    public class PrimitiveVisualTests
    {
        private string TAG = "NUI";
        private static bool _flagComposingPropertyMap;
        internal class MyPrimitiveVisual : PrimitiveVisual
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
            App.MainTitleChangeText("PrimitiveVisualTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a PrimitiveVisual object.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.PrimitiveVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void PrimitiveVisual_INIT()
        {
            /* TEST CODE */
            var primitiveVisualMap = new PrimitiveVisual();
            Assert.IsNotNull(primitiveVisualMap, "Can't create success object PrimitiveVisualMap");
            Assert.IsInstanceOf<PrimitiveVisual>(primitiveVisualMap, "Should be an instance of PrimitiveVisualMap type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Shape. Check whether Shape is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.Shape A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Shape_SET_GET_VALUE()
        {
            PrimitiveVisual primitiveVisualMap = new PrimitiveVisual();
            primitiveVisualMap.Shape = PrimitiveVisualShapeType.BevelledCube;
            Assert.AreEqual(PrimitiveVisualShapeType.BevelledCube, primitiveVisualMap.Shape, "Retrieved Shape should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test MixColor. Check whether MixColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.MixColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void MixColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            PrimitiveVisual primitiveVisualMap = new PrimitiveVisual();
            Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            primitiveVisualMap.MixColor = color;
            Assert.AreEqual(1.0f, primitiveVisualMap.MixColor.R, "Retrieved MixColor.R should be equal to set value");
            Assert.AreEqual(1.0f, primitiveVisualMap.MixColor.G, "Retrieved MixColor.G should be equal to set value");
            Assert.AreEqual(1.0f, primitiveVisualMap.MixColor.B, "Retrieved MixColor.B should be equal to set value");
            Assert.AreEqual(1.0f, primitiveVisualMap.MixColor.A, "Retrieved MixColor.A should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Slices. Check whether Slices is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.Slices A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Slices_SET_GET_VALUE()
        {
            /* TEST CODE */
            PrimitiveVisual primitiveVisualMap = new PrimitiveVisual();
            primitiveVisualMap.Slices = 3;
            Assert.AreEqual(3, primitiveVisualMap.Slices, "Retrieved Slices should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Stacks. Check whether Stacks is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.Stacks A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Stacks_SET_GET_VALUE()
        {
            /* TEST CODE */
            PrimitiveVisual primitiveVisualMap = new PrimitiveVisual();
            primitiveVisualMap.Stacks = 3;
            Assert.AreEqual(3, primitiveVisualMap.Stacks, "Retrieved Stacks should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScaleTopRadius. Check whether ScaleTopRadius is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.ScaleTopRadius A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ScaleTopRadius_SET_GET_VALUE()
        {
            /* TEST CODE */
            PrimitiveVisual primitiveVisualMap = new PrimitiveVisual();
            primitiveVisualMap.ScaleTopRadius = 1.0f;
            Assert.AreEqual(1.0f, primitiveVisualMap.ScaleTopRadius, "Retrieved ScaleTopRadius should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScaleBottomRadius. Check whether ScaleBottomRadius is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.ScaleBottomRadius A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ScaleBottomRadius_SET_GET_VALUE()
        {
            /* TEST CODE */
            PrimitiveVisual primitiveVisualMap = new PrimitiveVisual();
            primitiveVisualMap.ScaleBottomRadius = 1.0f;
            Assert.AreEqual(1.0f, primitiveVisualMap.ScaleBottomRadius, "Retrieved ScaleBottomRadius should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScaleHeight. Check whether ScaleHeight is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.ScaleHeight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ScaleHeight_SET_GET_VALUE()
        {
            /* TEST CODE */
            PrimitiveVisual primitiveVisualMap = new PrimitiveVisual();
            primitiveVisualMap.ScaleHeight = 1.0f;
            Assert.AreEqual(1.0f, primitiveVisualMap.ScaleHeight, "Retrieved ScaleHeight should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScaleRadius. Check whether ScaleRadius is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.ScaleRadius A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ScaleRadius_SET_GET_VALUE()
        {
            /* TEST CODE */
            PrimitiveVisual primitiveVisualMap = new PrimitiveVisual();
            primitiveVisualMap.ScaleRadius = 1.0f;
            Assert.AreEqual(1.0f, primitiveVisualMap.ScaleRadius, "Retrieved ScaleRadius should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScaleDimensions. Check whether ScaleDimensions is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.ScaleDimensions A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ScaleDimensions_SET_GET_VALUE()
        {
            PrimitiveVisual primitiveVisualMap = new PrimitiveVisual();
            Vector3 vector3 = new Vector3(1.0f, 1.0f, 1.0f);
            primitiveVisualMap.ScaleDimensions = vector3;
            Assert.AreEqual(1.0f, primitiveVisualMap.ScaleDimensions.X, "Retrieved ScaleDimensions.X should be equal to set value");
            Assert.AreEqual(1.0f, primitiveVisualMap.ScaleDimensions.Y, "Retrieved ScaleDimensions.Y should be equal to set value");
            Assert.AreEqual(1.0f, primitiveVisualMap.ScaleDimensions.Z, "Retrieved ScaleDimensions.Z should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test BevelPercentage. Check whether BevelPercentage is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.BevelPercentage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void BevelPercentage_SET_GET_VALUE()
        {
            /* TEST CODE */
            PrimitiveVisual primitiveVisualMap = new PrimitiveVisual();
            primitiveVisualMap.BevelPercentage = 1.0f;
            Assert.AreEqual(1.0f, primitiveVisualMap.BevelPercentage, "Retrieved BevelPercentage should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test BevelSmoothness. Check whether BevelSmoothness is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.BevelSmoothness A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void BevelSmoothness_SET_GET_VALUE()
        {
            /* TEST CODE */
            PrimitiveVisual primitiveVisualMap = new PrimitiveVisual();
            primitiveVisualMap.BevelSmoothness = 1.0f;
            Assert.AreEqual(1.0f, primitiveVisualMap.BevelSmoothness, "Retrieved BevelSmoothness should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test LightPosition. Check whether LightPosition is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.LightPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void LightPosition_SET_GET_VALUE()
        {
            PrimitiveVisual primitiveVisualMap = new PrimitiveVisual();
            Vector3 vector3 = new Vector3(1.0f, 1.0f, 1.0f);
            primitiveVisualMap.LightPosition = vector3;
            Assert.AreEqual(1.0f, primitiveVisualMap.LightPosition.X, "Retrieved LightPosition.X should be equal to set value");
            Assert.AreEqual(1.0f, primitiveVisualMap.LightPosition.Y, "Retrieved LightPosition.Y should be equal to set value");
            Assert.AreEqual(1.0f, primitiveVisualMap.LightPosition.Z, "Retrieved LightPosition.Z should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Check override method ComposingPropertyMap is invoked when new PrimitiveVisual instance.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void ComposingPropertyMap_OVERRIDE_METHOD()
        {
            /*PRE CONDITION
             * _flagComposingPropertyMap flag is initialize false value
             * Create a instance MySVGVisual
             */
            _flagComposingPropertyMap = false;
            Assert.False(_flagComposingPropertyMap, "_flagComposingPropertyMap should false initial");
            /**TEST CODE**/
            var myPrimitiveVisual = new MyPrimitiveVisual()
            {
                LightPosition = new Vector3(1.0f, 1.0f, 1.0f),
            };
            Assert.IsInstanceOf<PrimitiveVisual>(myPrimitiveVisual, "Should be an instance of PrimitiveVisual type.");
            PropertyMap propertyMap = myPrimitiveVisual.OutputVisualMap;
            Assert.True(_flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");
        }
    }
}
