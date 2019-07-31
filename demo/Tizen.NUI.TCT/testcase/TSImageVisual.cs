using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.ImageVisual Tests")]
    public class ImageVisualTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";
        private static bool _flagComposingPropertyMap;
        internal class MyImageVisual : ImageVisual
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
            App.MainTitleChangeText("ImageVisualTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a ImageVisual object.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.ImageVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ImageVisual_INIT()
        {
            /* TEST CODE */
            var imageVisualMap = new ImageVisual();
            Assert.IsNotNull(imageVisualMap, "Can't create success object ImageVisual");
            Assert.IsInstanceOf<ImageVisual>(imageVisualMap, "Should be an instance of ColorVisualMap type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test URL. Check whether URL is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.URL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void URL_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageVisual map = new ImageVisual();
            map.URL = "URL";
            Assert.AreEqual("URL", map.URL, "Retrieved URL should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test FittingMode. Check whether FittingMode is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.FittingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void FittingMode_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageVisual map = new ImageVisual();
            map.FittingMode = FittingModeType.FitHeight;
            Assert.AreEqual(FittingModeType.FitHeight, map.FittingMode, "Retrieved FittingMode should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SamplingMode. Check whether SamplingMode is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.SamplingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SamplingMode_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageVisual map = new ImageVisual();
            map.SamplingMode = SamplingModeType.Box;
            Assert.AreEqual(SamplingModeType.Box, map.SamplingMode, "Retrieved SamplingMode should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test DesiredWidth. Check whether DesiredWidth is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.DesiredWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void DesiredWidth_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageVisual map = new ImageVisual();
            map.DesiredWidth = 3;
            Assert.AreEqual(3, map.DesiredWidth, "Retrieved DesiredWidth should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test AlphaMaskURL. Check whether AlphaMaskURL is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.AlphaMaskURL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AlphaMaskURL_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageVisual map = new ImageVisual();
            map.AlphaMaskURL = image_path;
            Assert.AreEqual(image_path, map.AlphaMaskURL, "Retrieved AlphaMaskURL should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test AuxiliaryImageURL. Check whether AuxiliaryImageURL is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.AuxiliaryImageURL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AuxiliaryImageURL_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageVisual map = new ImageVisual();
            map.AuxiliaryImageURL = image_path;
            Assert.AreEqual(image_path, map.AuxiliaryImageURL, "Retrieved AuxiliaryImageURL should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test AuxiliaryImageAlpha. Check whether AuxiliaryImageAlpha is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.AuxiliaryImageAlpha A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AuxiliaryImageAlpha_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageVisual map = new ImageVisual();
            map.AuxiliaryImageAlpha = 0.9f;
            Assert.AreEqual(0.9f, map.AuxiliaryImageAlpha, "Retrieved AuxiliaryImageAlpha should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test DesiredHeight. Check whether DesiredHeight is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.DesiredHeight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void DesiredHeight_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageVisual map = new ImageVisual();
            map.DesiredHeight = 3;
            Assert.AreEqual(3, map.DesiredHeight, "Retrieved DesiredHeight should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SynchronousLoading. Check whether SynchronousLoading is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.SynchronousLoading A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SynchronousLoading_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageVisual map = new ImageVisual();
            map.SynchronousLoading = true;
            Assert.AreEqual(true, map.SynchronousLoading, "Retrieved SynchronousLoading should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test BorderOnly. Check whether BorderOnly is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.BorderOnly A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void BorderOnly_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageVisual map = new ImageVisual();
            map.BorderOnly = true;
            Assert.AreEqual(true, map.BorderOnly, "Retrieved BorderOnly should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test PixelArea. Check whether PixelArea is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.PixelArea A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void PixelArea_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageVisual map = new ImageVisual();
            Vector4 vector = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            map.PixelArea = vector;
            Assert.AreEqual(vector.R, map.PixelArea.R, "Retrieved PixelArea.R should be equal to set value");
            Assert.AreEqual(vector.G, map.PixelArea.G, "Retrieved PixelArea.G should be equal to set value");
            Assert.AreEqual(vector.B, map.PixelArea.B, "Retrieved PixelArea.B should be equal to set value");
            Assert.AreEqual(vector.A, map.PixelArea.A, "Retrieved PixelArea.A should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test WrapModeU. Check whether WrapModeU is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.WrapModeU A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void WrapModeU_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageVisual map = new ImageVisual();
            map.WrapModeU = WrapModeType.ClampToEdge;
            Assert.AreEqual(WrapModeType.ClampToEdge, map.WrapModeU, "Retrieved WrapModeU should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test WrapModeV. Check whether WrapModeV is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.WrapModeV A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void WrapModeV_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageVisual map = new ImageVisual();
            map.WrapModeV = WrapModeType.ClampToEdge;
            Assert.AreEqual(WrapModeType.ClampToEdge, map.WrapModeV, "Retrieved WrapModeV should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test CropToMask. Check whether CropToMask is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.CropToMask A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void CropToMask_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageVisual map = new ImageVisual();
            map.CropToMask = false;
            Assert.AreEqual(false, map.CropToMask, "Retrieved CropToMask should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test MaskContentScale. Check whether MaskContentScale is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.MaskContentScale A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void MaskContentScale_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageVisual map = new ImageVisual();
            map.MaskContentScale = 1.0f;
            Assert.AreEqual(1.0f, map.MaskContentScale, "Retrieved MaskContentScale should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ReleasePolicy. Check whether ReleasePolicy is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.ReleasePolicy A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ReleasePolicy_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageVisual map = new ImageVisual();
            map.ReleasePolicy = ReleasePolicyType.Detached;
            Assert.AreEqual(ReleasePolicyType.Detached, map.ReleasePolicy, "Retrieved ReleasePolicy should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test OrientationCorrection. Check whether OrientationCorrection is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.OrientationCorrection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void OrientationCorrection_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageVisual map = new ImageVisual();
            map.OrientationCorrection = true;
            Assert.IsTrue(map.OrientationCorrection, "Retrieved OrientationCorrection should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test LoadPolicy. Check whether LoadPolicy is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.LoadPolicy A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void LoadPolicy_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageVisual map = new ImageVisual();
            map.LoadPolicy = LoadPolicyType.Immediate;
            Assert.AreEqual(LoadPolicyType.Immediate, map.LoadPolicy, "Retrieved LoadPolicy should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Atlasing. Check whether Atlasing is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.Atlasing A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void Atlasing_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageVisual map = new ImageVisual();
            map.Atlasing = true;
            Assert.AreEqual(true, map.Atlasing, "Retrieved Atlasing should be equal to set value");

            map.Atlasing = false;
            Assert.AreEqual(false, map.Atlasing, "Retrieved Atlasing should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Check override method ComposingPropertyMap is invoked when new ImageVisual instance.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ComposingPropertyMap_OVERRIDE_METHOD()
        {
            /*PRE CONDITION
             * _flagComposingPropertyMap flag is initialize false value
             * Create a instance MyImageVisual
             */
            _flagComposingPropertyMap = false;
            Assert.False(_flagComposingPropertyMap, "_flagComposingPropertyMap should false initial");
            /**TEST CODE**/
            var myImageVisual = new MyImageVisual()
            {
                URL = image_path,
            };
            Assert.IsInstanceOf<ImageVisual>(myImageVisual, "Should be an instance of ImageVisual type.");
            PropertyMap propertyMap = myImageVisual.OutputVisualMap;
            Assert.True(_flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");
        }
    }
}
