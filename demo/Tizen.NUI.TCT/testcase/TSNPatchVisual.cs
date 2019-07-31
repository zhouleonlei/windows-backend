using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.NPatchVisual Tests")]
    public class NPatchVisualTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";
        private static bool _flagComposingPropertyMap;
        internal class MyNPatchVisual : NPatchVisual
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
            App.MainTitleChangeText("NPatchVisualTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a NPatchVisual object.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.NPatchVisual.NPatchVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void NPatchVisual_INIT()
        {
            /* TEST CODE */
            var nPatchVisualMap = new NPatchVisual();
            Assert.IsNotNull(nPatchVisualMap, "Can't create success object NPatchVisual");
            Assert.IsInstanceOf<NPatchVisual>(nPatchVisualMap, "Should be an instance of NPatchVisual type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test URL. Check whether URL is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.NPatchVisual.URL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void URL_SET_GET_VALUE()
        {
            /* TEST CODE */
            NPatchVisual map = new NPatchVisual();
            map.URL = image_path;
            Assert.AreEqual(image_path, map.URL, "Retrieved URL should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test BorderOnly. Check whether BorderOnly is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.NPatchVisual.BorderOnly A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void BorderOnly_SET_GET_VALUE()
        {
            /* TEST CODE */
            NPatchVisual map = new NPatchVisual();
            map.BorderOnly = true;
            Assert.AreEqual(true, map.BorderOnly, "Retrieved BorderOnly should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Border. Check whether Border is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.NPatchVisual.Border A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Border_SET_GET_VALUE()
        {
            /* TEST CODE */
            NPatchVisual map = new NPatchVisual();
            map.Border = new Rectangle(0, 0, 10, 10);
            Assert.AreEqual(0, map.Border.X, "Retrieved BorderOnly should be equal to set value");
            Assert.AreEqual(0, map.Border.Y, "Retrieved BorderOnly should be equal to set value");
            Assert.AreEqual(10, map.Border.Width, "Retrieved BorderOnly should be equal to set value");
            Assert.AreEqual(10, map.Border.Height, "Retrieved BorderOnly should be equal to set value");

        }

        [Test]
        [Category("P1")]
        [Description("Check override method ComposingPropertyMap is invoked when new NPatchVisual instance.")]
        [Property("SPEC", "Tizen.NUI.NPatchVisual.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ComposingPropertyMap_OVERRIDE_METHOD()
        {
            /*PRE CONDITION
             * _flagComposingPropertyMap flag is initialize false value
             * Create a instance MyNPatchVisual
             */
            _flagComposingPropertyMap = false;
            Assert.False(_flagComposingPropertyMap, "_flagComposingPropertyMap should false initial");
            /**TEST CODE**/
            var myNPatchVisual = new MyNPatchVisual()
            {
                URL = image_path,
                BorderOnly = true,
            };
            Assert.IsInstanceOf<NPatchVisual>(myNPatchVisual, "Should be an instance of NPatchVisual type.");
            PropertyMap propertyMap = myNPatchVisual.OutputVisualMap;
            Assert.True(_flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");
        }
    }
}
