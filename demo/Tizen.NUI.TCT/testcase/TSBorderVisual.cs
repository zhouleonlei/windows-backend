using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.BorderVisual Tests")]
    public class BorderVisualTests
    {
        private string TAG = "NUI";
        private static bool _flagComposingPropertyMap;
        internal class MyBorderVisual : BorderVisual
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
            Tizen.Log.Info(TAG, " Init() is called!");
            App.MainTitleChangeText("BorderVisualTests");
            App.MainTitleChangeBackgroundColor(null);

        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, " Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a BorderVisual object.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.BorderVisual.BorderVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void BorderVisual_INIT()
        {
            /* TEST CODE */
            var borderVisualMap = new BorderVisual();
            Assert.IsNotNull(borderVisualMap, "Can't create success object BorderVisual");
            Assert.IsInstanceOf<BorderVisual>(borderVisualMap, "Should be an instance of BorderVisual type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Color. Check whether Color is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BorderVisual.Color A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Color_SET_GET_VALUE()
        {
            /* TEST CODE */
            BorderVisual borderVisualMap = new BorderVisual();
            Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            borderVisualMap.Color = color;
            Assert.AreEqual(1.0f, borderVisualMap.Color.R, "Retrieved Color.R should be equal to set value");
            Assert.AreEqual(1.0f, borderVisualMap.Color.G, "Retrieved Color.G should be equal to set value");
            Assert.AreEqual(1.0f, borderVisualMap.Color.B, "Retrieved Color.B should be equal to set value");
            Assert.AreEqual(1.0f, borderVisualMap.Color.A, "Retrieved Color.A should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test BorderSize. Check whether BorderSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BorderVisual.BorderSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void BorderSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            BorderVisual borderVisualMap = new BorderVisual();
            borderVisualMap.BorderSize = 1.0f;
            Assert.AreEqual(1.0f, borderVisualMap.BorderSize, "Retrieved BorderSize should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test AntiAliasing. Check whether AntiAliasing is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BorderVisual.AntiAliasing A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void AntiAliasing_SET_GET_VALUE()
        {
            /* TEST CODE */
            BorderVisual borderVisualMap = new BorderVisual();
            borderVisualMap.AntiAliasing = true;
            Assert.AreEqual(true, borderVisualMap.AntiAliasing, "Retrieved AntiAliasing should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Check override method ComposingPropertyMap is invoked when new BorderVisual instance.")]
        [Property("SPEC", "Tizen.NUI.BorderVisual.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ComposingPropertyMap_OVERRIDE_METHOD()
        {
            /*PRE CONDITION
             * _flagComposingPropertyMap flag is initialize false value
             * Create a instance MyBorderVisual
             */
            _flagComposingPropertyMap = false;
            Assert.False(_flagComposingPropertyMap, "_flagComposingPropertyMap should false initial");
            /**TEST CODE**/
            var myBorderVisual = new MyBorderVisual()
            {
                Color = new Color(1.0f, 0.3f, 0.5f, 1.0f),
                BorderSize = 1.0f,
            };
            Assert.IsInstanceOf<BorderVisual>(myBorderVisual, "Should be an instance of BorderVisual type.");
            PropertyMap propertyMap = myBorderVisual.OutputVisualMap;
            Assert.True(_flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");
        }
    }
}
