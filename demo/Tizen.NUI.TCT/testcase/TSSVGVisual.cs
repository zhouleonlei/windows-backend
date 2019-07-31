using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.SVGVisual Tests")]
    public class SVGVisualTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        private static bool _flagComposingPropertyMap;
        internal class MySVGVisual : SVGVisual
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
            App.MainTitleChangeText("SVGVisualTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a SVGVisual object.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.SVGVisual.SVGVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SVGVisual_INIT()
        {
            /* TEST CODE */
            var svgVisual = new SVGVisual();
            Assert.IsNotNull(svgVisual, "Can't create success object SVGVisual");
            Assert.IsInstanceOf<SVGVisual>(svgVisual, "Should be an instance of SVGVisual type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test URL. Check whether URL is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.SVGVisual.URL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void URL_SET_GET_VALUE()
        {
            /* TEST CODE */
            SVGVisual map = new SVGVisual();
            map.URL = image_path;
            Assert.AreEqual(image_path, map.URL, "Retrieved URL should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Check override method ComposingPropertyMap is invoked when new SVGVisual instance.")]
        [Property("SPEC", "Tizen.NUI.SVGVisual.ComposingPropertyMap M")]
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
            var mySVGVisual = new MySVGVisual()
            {
                URL = image_path,
            };
            Assert.IsInstanceOf<SVGVisual>(mySVGVisual, "Should be an instance of SVGVisual type.");
            PropertyMap propertyMap = mySVGVisual.OutputVisualMap;
            Assert.True(_flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");
        }
    }
}
