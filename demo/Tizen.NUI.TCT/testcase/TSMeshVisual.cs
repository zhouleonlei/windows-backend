using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.MeshVisual Tests")]
    public class MeshVisualTests
    {
        private string TAG = "NUI";
        private static bool _flagComposingPropertyMap;
        internal class MyMeshVisual : MeshVisual
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
            App.MainTitleChangeText("MeshVisualTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a MeshVisual object.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.MeshVisual.MeshVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void MeshVisual_INIT()
        {
            /* TEST CODE */
            var meshVisualMap = new MeshVisual();
            Assert.IsNotNull(meshVisualMap, "Can't create success object MeshVisual");
            Assert.IsInstanceOf<MeshVisual>(meshVisualMap, "Should be an instance of MeshVisual type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ObjectURL. Check whether ObjectURL is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.MeshVisual.ObjectURL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ObjectURL_SET_GET_VALUE()
        {
            MeshVisual meshVisualMap = new MeshVisual();
            string url = "ObjectURL";
            meshVisualMap.ObjectURL = url;
            Assert.AreEqual(url, meshVisualMap.ObjectURL, "Retrieved ObjectURL should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test MaterialtURL. Check whether MaterialtURL is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.MeshVisual.MaterialtURL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void MaterialtURL_SET_GET_VALUE()
        {
            MeshVisual meshVisualMap = new MeshVisual();
            string url = "MaterialtURL";
            meshVisualMap.MaterialtURL = url;
            Assert.AreEqual(url, meshVisualMap.MaterialtURL, "Retrieved MaterialtURL should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test TexturesPath. Check whether TexturesPath is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.MeshVisual.TexturesPath A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TexturesPath_SET_GET_VALUE()
        {
            MeshVisual meshVisualMap = new MeshVisual();
            string url = "MaterialtURL";
            meshVisualMap.TexturesPath = url;
            Assert.AreEqual(url, meshVisualMap.TexturesPath, "Retrieved TexturesPath should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ShadingMode. Check whether ShadingMode is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.MeshVisual.ShadingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ShadingMode_SET_GET_VALUE()
        {
            MeshVisual meshVisualMap = new MeshVisual();
            meshVisualMap.ShadingMode = MeshVisualShadingModeValue.TexturedWithDetailedSpecularLighting;
            Assert.AreEqual(MeshVisualShadingModeValue.TexturedWithDetailedSpecularLighting, meshVisualMap.ShadingMode, "Retrieved ShadingMode should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test UseMipmapping. Check whether UseMipmapping is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.MeshVisual.UseMipmapping A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void UseMipmapping_SET_GET_VALUE()
        {
            MeshVisual meshVisualMap = new MeshVisual();
            meshVisualMap.UseMipmapping = true;
            Assert.AreEqual(true, meshVisualMap.UseMipmapping, "Retrieved UseMipmapping should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test UseSoftNormals. Check whether UseSoftNormals is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.MeshVisual.UseSoftNormals A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void UseSoftNormals_SET_GET_VALUE()
        {
            MeshVisual meshVisualMap = new MeshVisual();
            meshVisualMap.UseSoftNormals = true;
            Assert.AreEqual(true, meshVisualMap.UseSoftNormals, "Retrieved UseSoftNormals should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test LightPosition. Check whether LightPosition is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.MeshVisual.LightPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void LightPosition_SET_GET_VALUE()
        {
            MeshVisual meshVisualMap = new MeshVisual();
            Vector3 vector3 = new Vector3(1.0f, 1.0f, 1.0f);
            meshVisualMap.LightPosition = vector3;
            Assert.AreEqual(1.0f, meshVisualMap.LightPosition.X, "Retrieved LightPosition.X should be equal to set value");
            Assert.AreEqual(1.0f, meshVisualMap.LightPosition.Y, "Retrieved LightPosition.Y should be equal to set value");
            Assert.AreEqual(1.0f, meshVisualMap.LightPosition.Z, "Retrieved LightPosition.Z should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Check override method ComposingPropertyMap is invoked when new MeshVisual instance.")]
        [Property("SPEC", "Tizen.NUI.MeshVisual.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ComposingPropertyMap_OVERRIDE_METHOD()
        {
            /*PRE CONDITION
             * _flagComposingPropertyMap flag is initialize false value
             * Create a instance MyMeshVisual
             */
            _flagComposingPropertyMap = false;
            Assert.False(_flagComposingPropertyMap, "_flagComposingPropertyMap should false initial");
            /**TEST CODE**/
            var myMeshVisual = new MyMeshVisual()
            {
                LightPosition = new Vector3(1.0f, 1.0f, 1.0f),
            };
            Assert.IsInstanceOf<MeshVisual>(myMeshVisual, "Should be an instance of MeshVisual type.");
            PropertyMap propertyMap = myMeshVisual.OutputVisualMap;
            Assert.True(_flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");
        }
    }
}
