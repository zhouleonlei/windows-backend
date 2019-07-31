using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.VisualMap Tests")]
    public class VisualMapTests
    {
        private string TAG = "NUI";
        private static bool _flagComposingPropertyMap;
        internal class MyVisualMap : VisualMap
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
            App.MainTitleChangeText("VisualMapTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a VisualMap object.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.VisualMap C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void VisualMap_INIT()
        {
            /* TEST CODE */
            var visualMap = new VisualMap();
            Assert.IsNotNull(visualMap, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(visualMap, "Should be an instance of VisualMap type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test VisualSize. Check whether VisualSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.Size A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Size_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualMap visualMap = new VisualMap();
            Vector2 vector2 = new Vector2(1.0f, 1.0f);
            visualMap.Size = vector2;
            Assert.AreEqual(1.0f, visualMap.Size.Width, "Retrieved VisualSize.Width should be equal to set value");
            Assert.AreEqual(1.0f, visualMap.Size.Height, "Retrieved VisualSize.Height should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test MixColor. Check whether MixColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.MixColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void MixColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualMap visualMap = new VisualMap();
            visualMap.MixColor = new Color(0.5f, 1.0f, 0.6f, 1.0f);
            Assert.AreEqual(0.5f, visualMap.MixColor.R, "Retrieved VisualSize.MixColor.R should be equal to set value");
            Assert.AreEqual(1.0f, visualMap.MixColor.G, "Retrieved VisualSize.MixColor.G should be equal to set value");
            Assert.AreEqual(0.6f, visualMap.MixColor.B, "Retrieved VisualSize.MixColor.B should be equal to set value");
            Assert.AreEqual(1.0f, visualMap.MixColor.A, "Retrieved VisualSize.MixColor.A should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Opacity. Check whether Opacity is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.Opacity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Opacity_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualMap visualMap = new VisualMap();
            visualMap.Opacity = 0.5f;
            Assert.AreEqual(0.5f, visualMap.Opacity, "Retrieved VisualSize.Opacity should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test PremultipliedAlpha. Check whether PremultipliedAlpha is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.PremultipliedAlpha A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PremultipliedAlpha_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualMap visualMap = new VisualMap();
            visualMap.PremultipliedAlpha = true;
            Assert.IsTrue(visualMap.PremultipliedAlpha, "Retrieved VisualSize.PremultipliedAlpha should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test RelativePosition. Check whether RelativePosition is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.RelativePosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RelativePosition_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualMap visualMap = new VisualMap();
            visualMap.RelativePosition = new RelativeVector2(0.5f, 0.5f);
            Assert.AreEqual(0.5f, visualMap.RelativePosition.X, "Retrieved VisualSize.RelativePosition.X should be equal to set value");
            Assert.AreEqual(0.5f, visualMap.RelativePosition.Y, "Retrieved VisualSize.RelativePosition.Y should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test RelativeSize. Check whether RelativeSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.RelativeSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RelativeSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualMap visualMap = new VisualMap();
            visualMap.RelativeSize = new RelativeVector2(0.5f, 0.5f);
            Assert.AreEqual(0.5f, visualMap.RelativeSize.X, "Retrieved VisualSize.RelativeSize.X should be equal to set value");
            Assert.AreEqual(0.5f, visualMap.RelativeSize.Y, "Retrieved VisualSize.RelativeSize.Y should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Shader. Check whether Shader is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.Shader A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Shader_SET_GET_VALUE()
        {
            /* TEST CODE */
            PropertyMap map = new PropertyMap();
            map.Insert(Visual.ShaderProperty.FragmentShader, new PropertyValue("Foobar"));
            VisualMap visualMap = new VisualMap();
            visualMap.Shader = map;

            string str = "";
            (visualMap.Shader.Find(Visual.ShaderProperty.FragmentShader)).Get(out str);
            Assert.AreEqual("Foobar", str, "Retrieved PremultipliedAlpha should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Offset. Check whether Offset is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.Position A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Position_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualMap visualMap = new VisualMap();
            Vector2 vector2 = new Vector2(1.0f, 1.0f);
            visualMap.Position = vector2;
            Assert.AreEqual(1.0f, visualMap.Position.X, "Retrieved Offset.X should be equal to set value");
            Assert.AreEqual(1.0f, visualMap.Position.Y, "Retrieved Offset.Y should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test PositionPolicy. Check whether PositionPolicy is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.PositionPolicy A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PositionPolicy_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualMap visualMap = new VisualMap();
            visualMap.PositionPolicy = VisualTransformPolicyType.Absolute;

            Assert.AreEqual(VisualTransformPolicyType.Absolute, visualMap.PositionPolicy, "Retrieved PositionPolicy should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test PositionPolicyX. Check whether PositionPolicyX is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.PositionPolicyX A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PositionPolicyX_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualMap visualMap = new VisualMap();
            visualMap.PositionPolicyX = VisualTransformPolicyType.Absolute;

            Assert.AreEqual(VisualTransformPolicyType.Absolute, visualMap.PositionPolicyX, "Retrieved PositionPolicyX should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test PositionPolicyY. Check whether PositionPolicyY is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.PositionPolicyY A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PositionPolicyY_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualMap visualMap = new VisualMap();
            visualMap.PositionPolicyY = VisualTransformPolicyType.Absolute;

            Assert.AreEqual(VisualTransformPolicyType.Absolute, visualMap.PositionPolicyY, "Retrieved PositionPolicyY should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SizePolicy. Check whether SizePolicy is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.SizePolicy A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SizePolicy_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualMap visualMap = new VisualMap();
            visualMap.SizePolicy = VisualTransformPolicyType.Absolute;

            Assert.AreEqual(VisualTransformPolicyType.Absolute, visualMap.SizePolicy, "Retrieved SizePolicy should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SizePolicyWidth. Check whether SizePolicyWidth is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.SizePolicyWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SizePolicyWidth_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualMap visualMap = new VisualMap();
            visualMap.SizePolicyWidth = VisualTransformPolicyType.Absolute;

            Assert.AreEqual(VisualTransformPolicyType.Absolute, visualMap.SizePolicyWidth, "Retrieved SizePolicyWidth should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SizePolicyHeight. Check whether SizePolicyHeight is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.SizePolicyHeight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SizePolicyHeight_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualMap visualMap = new VisualMap();
            visualMap.SizePolicyHeight = VisualTransformPolicyType.Absolute;

            Assert.AreEqual(VisualTransformPolicyType.Absolute, visualMap.SizePolicyHeight, "Retrieved SizePolicyHeight should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Origin. Check whether Origin is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.Origin A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Origin_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualMap visualMap = new VisualMap();
            visualMap.Origin = Visual.AlignType.Center;
            Assert.AreEqual(Visual.AlignType.Center, visualMap.Origin, "Retrieved Origin should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test AnchorPoint. Check whether AnchorPoint is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.AnchorPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void AnchorPoint_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualMap visualMap = new VisualMap();
            visualMap.AnchorPoint = Visual.AlignType.Center;
            Assert.AreEqual(Visual.AlignType.Center, visualMap.AnchorPoint, "Retrieved PivotPoint should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test DepthIndex. Check whether DepthIndex is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.DepthIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void DepthIndex_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualMap visualMap = new VisualMap();
            visualMap.DepthIndex = 1;
            Assert.AreEqual(1, visualMap.DepthIndex, "Retrieved DepthIndex should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test OutputTransformMap. Check whether OutputTransformMap is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.OutputTransformMap A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void OutputTransformMap_GET_VALUE()
        {
            /* TEST CODE */
            VisualMap visualMap = new VisualMap();
            Vector2 vector2 = new Vector2(1.0f, 1.0f);
            visualMap.Size = vector2;
            visualMap.Position = vector2;
            visualMap.PositionPolicy = VisualTransformPolicyType.Absolute;
            visualMap.SizePolicy = VisualTransformPolicyType.Absolute;
            visualMap.Origin = Visual.AlignType.Center;
            visualMap.AnchorPoint = Visual.AlignType.Center;

            PropertyMap map = new PropertyMap();
            map = visualMap.OutputTransformMap;
            map.Find((int)VisualTransformPropertyType.Size).Get(vector2);
            Assert.AreEqual(1.0f, vector2.X, "Retrieved VisualSize.X should be equal to set value");
            Assert.AreEqual(1.0f, vector2.Y, "Retrieved VisualSize.Y should be equal to set value");
            map.Find((int)VisualTransformPropertyType.Offset).Get(vector2);
            Assert.AreEqual(1.0f, vector2.X, "Retrieved Offset.X should be equal to set value");
            Assert.AreEqual(1.0f, vector2.Y, "Retrieved Offset.Y should be equal to set value");
            map.Find((int)VisualTransformPropertyType.OffsetPolicy).Get(vector2);
            Assert.AreEqual(1.0f, vector2.X, "Retrieved OffsetPolicy.X should be equal to set value");
            Assert.AreEqual(1.0f, vector2.Y, "Retrieved OffsetPolicy.Y should be equal to set value");
            map.Find((int)VisualTransformPropertyType.SizePolicy).Get(vector2);
            Assert.AreEqual(1.0f, vector2.X, "Retrieved SizePolicy.X should be equal to set value");
            Assert.AreEqual(1.0f, vector2.Y, "Retrieved SizePolicy.Y should be equal to set value");

            int type = 0;
            map.Find((int)VisualTransformPropertyType.Origin).Get(out type);
            Assert.AreEqual((int)Visual.AlignType.Center, type, "Retrieved Origin should be equal to set value");
            map.Find((int)VisualTransformPropertyType.AnchorPoint).Get(out type);
            Assert.AreEqual((int)Visual.AlignType.Center, type, "Retrieved AnchorPoint should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test OutputVisualMap. Check whether OutputVisualMap is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.OutputVisualMap A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void OutputVisualMap_GET_VALUE()
        {
            VisualMap visualMap = new VisualMap();
            PropertyMap map = visualMap.OutputVisualMap;
            Assert.IsNotNull(map, "Should not be null");
        }

        [Test]
        [Category("P1")]
        [Description("Test VisualFittingMode. Check whether VisualFittingMode is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.VisualFittingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void VisualFittingMode_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualMap visualMap = new VisualMap();
            visualMap.VisualFittingMode = VisualFittingModeType.Fill;
            Assert.AreEqual(VisualFittingModeType.Fill, visualMap.VisualFittingMode, "Retrieved VisualFittingMode should be equal to set value");

            visualMap.VisualFittingMode = VisualFittingModeType.FitKeepAspectRatio;
            Assert.AreEqual(VisualFittingModeType.FitKeepAspectRatio, visualMap.VisualFittingMode, "Retrieved VisualFittingMode should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Check override method ComposingPropertyMap is invoked when new VisualMap instance.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ComposingPropertyMap_OVERRIDE_METHOD()
        {
            /*PRE CONDITION
             * _flagComposingPropertyMap flag is initialize false value
             * Create a instance VisualMap
             */
            _flagComposingPropertyMap = false;
            Assert.False(_flagComposingPropertyMap, "_flagComposingPropertyMap should false initial");
            /**TEST CODE**/
            var myVisualMap = new MyVisualMap();
            Assert.IsInstanceOf<VisualMap>(myVisualMap, "Should be an instance of VisualMap type.");
            //In OutputVisualMap will call ComposingPropertyMap to set _flagComposingPropertyMap
            PropertyMap propertyMap = myVisualMap.OutputVisualMap;
            Assert.AreEqual(0, propertyMap.Count(), "Retrieved PropertyMap count should be 0");
            Assert.True(_flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");
        }
    }
}
