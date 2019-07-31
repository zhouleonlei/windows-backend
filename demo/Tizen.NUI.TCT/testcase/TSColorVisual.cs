using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.ColorVisual Tests")]
    public class ColorVisualTests
    {
        private string TAG = "NUI";
        private static bool _flagComposingPropertyMap;
        internal class MyColorVisual : ColorVisual
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
            App.MainTitleChangeText("ColorVisualTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, " Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a ColorVisual object.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.ColorVisual.ColorVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ColorVisual_INIT()
        {
            /* TEST CODE */
            var colorVisualMap = new ColorVisual();
            Assert.IsNotNull(colorVisualMap, "Can't create success object ColorVisual");
            Assert.IsInstanceOf<ColorVisual>(colorVisualMap, "Should be an instance of ColorVisual type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Color. Check whether Color is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ColorVisual.Color A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Color_SET_GET_VALUE()
        {
            /* TEST CODE */
            ColorVisual colorVisualMap = new ColorVisual();
            Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            colorVisualMap.Color = color;
            Assert.AreEqual(1.0f, colorVisualMap.Color.R, "Retrieved Color.R should be equal to set value");
            Assert.AreEqual(1.0f, colorVisualMap.Color.G, "Retrieved Color.G should be equal to set value");
            Assert.AreEqual(1.0f, colorVisualMap.Color.B, "Retrieved Color.B should be equal to set value");
            Assert.AreEqual(1.0f, colorVisualMap.Color.A, "Retrieved Color.A should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test RenderIfTransparent. Check whether RenderIfTransparent is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ColorVisual.RenderIfTransparent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void RenderIfTransparent_SET_GET_VALUE()
        {
            /* TEST CODE */
            ColorVisual colorVisualMap = new ColorVisual();
            colorVisualMap.RenderIfTransparent = true;
            Assert.AreEqual(true, colorVisualMap.RenderIfTransparent, "Retrieved RenderIfTransparent should be equal to set value");

            colorVisualMap.RenderIfTransparent = false;
            Assert.AreEqual(false, colorVisualMap.RenderIfTransparent, "Retrieved RenderIfTransparent should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Check override method ComposingPropertyMap is invoked when new ColorVisual instance.")]
        [Property("SPEC", "Tizen.NUI.ColorVisual.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ComposingPropertyMap_OVERRIDE_METHOD()
        {
            /*PRE CONDITION
             * _flagComposingPropertyMap flag is initialize false value
             * Create a instance MyColorVisual
             */
            _flagComposingPropertyMap = false;
            Assert.False(_flagComposingPropertyMap, "_flagComposingPropertyMap should false initial");
            /**TEST CODE**/
            var myColorVisual = new MyColorVisual()
            {
                Color = new Color(1.0f, 0.3f, 0.5f, 1.0f),
            };
            Assert.IsInstanceOf<ColorVisual>(myColorVisual, "Should be an instance of ColorVisual type.");
            PropertyMap propertyMap = myColorVisual.OutputVisualMap;
            Assert.True(_flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");
        }
    }
}
