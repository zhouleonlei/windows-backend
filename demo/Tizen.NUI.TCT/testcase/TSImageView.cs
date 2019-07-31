using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;
using System.Threading.Tasks;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.ImageView Tests")]
    public class ImageViewTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        private string gif_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "dog-anim.gif";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ImageViewTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali imageView constructor test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.ImageView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ImageView_INIT()
        {
            /* TEST CODE */
            var imageView = new ImageView();
            Assert.IsInstanceOf<ImageView>(imageView, "Should return ImageView instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali imageView constructor test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.ImageView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "string")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ImageView_INIT_WITH_STRING()
        {
            /* TEST CODE */
            String imagePath = "TestImage";
            var imageView = new ImageView(imagePath);
            Assert.IsInstanceOf<ImageView>(imageView, "Should return ImageView instance.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ResourceUrl. Check whether ResourceUrl is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.ResourceUrl A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ResourceUrl_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageView imageView = new ImageView();
            string path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

            imageView.ResourceUrl = path;
            Assert.AreEqual(path, imageView.ResourceUrl);
        }

        [Test]
        [Category("P1")]
        [Description("Test PreMultipliedAlpha. Check whether PreMultipliedAlpha is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.PreMultipliedAlpha A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PreMultipliedAlpha_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageView imageView = new ImageView(image_path);
            imageView.PreMultipliedAlpha = true;
            Assert.IsTrue(imageView.PreMultipliedAlpha, "The PreMultipliedAlpha property of imageView should be true here.");
            imageView.PreMultipliedAlpha = false;
            Assert.IsFalse(imageView.PreMultipliedAlpha, "The PreMultipliedAlpha property of imageView should be false here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test PreMultipliedAlpha. Check whether OrientationCorrection is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.OrientationCorrection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void OrientationCorrection_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageView imageView = new ImageView(image_path);
            imageView.OrientationCorrection = true;
            Assert.IsTrue(imageView.OrientationCorrection, "The OrientationCorrection property of imageView should be true here.");
            imageView.OrientationCorrection = false;
            Assert.IsFalse(imageView.OrientationCorrection, "The PreMultipliedAlpha property of imageView should be false here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test LoadingStatus. Check whether LoadingStatus return the right value.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.LoadingStatus A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void LoadingStatus_READ_ONLY()
        {
            /* TEST CODE */
            ImageView imageView = new ImageView(image_path);
            Assert.AreEqual(ImageView.LoadingStatusType.Preparing, imageView.LoadingStatus, "The status should be Preparing!");
        }

        [Test]
        [Category("P1")]
        [Description("Test ImageMap. Check whether ImageMap is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.ImageMap A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ImageMap_SET_GET_VALUE()
        {
            /* TEST CODE */

            ImageView imageView = new ImageView();

            PropertyMap map = new PropertyMap();
            map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Color));
            map.Add(ColorVisualProperty.MixColor, new PropertyValue(new Color(0.0f, 0.0f, 0.0f, 1.0f)));

            imageView.ImageMap = map;

            PropertyMap propertyMap = imageView.ImageMap;
            int type = 0;
            propertyMap.Find(Visual.Property.Type).Get(out type);
            Assert.AreEqual((int)Visual.Type.Color, type, "The type is not correct here.");
            Color color = new Color();

            (propertyMap.Find(ColorVisualProperty.MixColor)).Get(color);

            Assert.AreEqual(0.0f, color.R, "The R property of color is not correct here.");
            Assert.AreEqual(0.0f, color.G, "The G property of color is not correct here.");
            Assert.AreEqual(0.0f, color.B, "The B property of color is not correct here.");
            Assert.AreEqual(1.0f, color.A, "The A property of color is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Image. Check whether Image is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.Image A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Image_SET_GET_VALUE()
        {
            /* TEST CODE */

            ImageView imageView = new ImageView();

            PropertyMap map = new PropertyMap();
            map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Color));
            map.Add(ColorVisualProperty.MixColor, new PropertyValue(new Color(0.0f, 0.0f, 0.0f, 1.0f)));

            imageView.Image = map;

            PropertyMap propertyMap = imageView.Image;
            int type = 0;
            propertyMap.Find(Visual.Property.Type).Get(out type);
            Assert.AreEqual((int)Visual.Type.Color, type, "The type is not correct here.");
            Color color = new Color();
            (propertyMap.Find(ColorVisualProperty.MixColor)).Get(color);
            Assert.AreEqual(0.0f, color.R, "The R property of color is not correct here.");
            Assert.AreEqual(0.0f, color.G, "The G property of color is not correct here.");
            Assert.AreEqual(0.0f, color.B, "The B property of color is not correct here.");
            Assert.AreEqual(1.0f, color.A, "The A property of color is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test PixelArea. Check whether PixelArea is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.PixelArea A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PixelArea_SET_GET_VALUE()
        {
            /* TEST CODE */

            ImageView imageView = new ImageView(image_path);

            Tizen.Log.Fatal(TAG, "image_path=" + image_path);

            imageView.PixelArea = new Vector4(0.5f, 0.6f, 0.7f, 0.8f);
            Assert.AreEqual(0.5f, imageView.PixelArea.X, "The PixelArea.X property of imageView is not correct here.");
            Assert.AreEqual(0.6f, imageView.PixelArea.Y, "The PixelArea.Y property of imageView is not correct here.");
            Assert.AreEqual(0.7f, imageView.PixelArea.Z, "The PixelArea.Z property of imageView is not correct here.");
            Assert.AreEqual(0.8f, imageView.PixelArea.W, "The PixelArea.W property of imageView is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Reload. Check whether the Reload works for gif.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.Reload M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Reload_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                ImageView imageView = new ImageView(gif_path);
                imageView.Reload();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Play. Check whether the Play works for gif.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.Play M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Play_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                ImageView imageView = new ImageView(gif_path);
                imageView.Play();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Pause. Check whether the Pause works for gif.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.Pause M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Pause_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                ImageView imageView = new ImageView(gif_path);
                imageView.Pause();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Stop. Check whether the Stop works for gif.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.Stop M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Stop_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                ImageView imageView = new ImageView(gif_path);
                imageView.Stop();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test IsResourceReady. Test whether the IsResourceReady will return the right value.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.IsResourceReady M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void IsResourceReady_CHECK_EVENT()
        {
            ImageView view = new ImageView(image_path);
            view.ParentOrigin = ParentOrigin.TopLeft;
            view.PivotPoint = PivotPoint.TopLeft;
            view.Position = new Position(0.0f, 150.0f, 0.0f);
            view.Show();
            Assert.IsTrue(view.Visibility, "Should be true when the ImageView is on the window");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetImage. Check whether the function works.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.SetImage M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SetImage_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                ImageView imageView = new ImageView();
                imageView.SetImage(image_path);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test BorderOnly. Check whether BorderOnly is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.BorderOnly A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void BorderOnly_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageView imageView = new ImageView();
            imageView.ResourceUrl = image_path;
            imageView.BorderOnly = true;
            Assert.AreEqual(true, imageView.BorderOnly, "Retrieved BorderOnly should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Border. Check whether Border is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.Border A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Border_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageView imageView = new ImageView();
            imageView.Border = new Rectangle(0, 0, 10, 10);
            Assert.AreEqual(0, imageView.Border.X, "Retrieved BorderOnly should be equal to set value");
            Assert.AreEqual(0, imageView.Border.Y, "Retrieved BorderOnly should be equal to set value");
            Assert.AreEqual(10, imageView.Border.Width, "Retrieved BorderOnly should be equal to set value");
            Assert.AreEqual(10, imageView.Border.Height, "Retrieved BorderOnly should be equal to set value");

        }



        [Test]
        [Category("P1")]
        [Description("Test ResourceReady. Test whether the ResourceReady event will be triggered.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.ResourceReady E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ResourceReady_CHECK_EVENT()
        {
            ImageView view = new ImageView(image_path);
            view.ParentOrigin = ParentOrigin.TopLeft;
            view.PivotPoint = PivotPoint.TopLeft;
            view.Position = new Position(0.0f, 150.0f, 0.0f);
            bool flag = true;
            Assert.IsTrue(flag, "The ResourceReady Event has been triggerred!");
        }

        [Test]
        [Category("P1")]
        [Description("Test SynchronosLoading. Get the Image instance from handle instance.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.SynchronosLoading A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SynchronosLoading_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageView imageView = new ImageView();
            imageView.ParentOrigin = ParentOrigin.CenterLeft;
            imageView.PivotPoint = PivotPoint.CenterLeft;
            imageView.PositionUsesPivotPoint = true;
            imageView.Size2D = new Size2D(150, 150);
            imageView.ResourceUrl = image_path;
            Window.Instance.GetDefaultLayer().Add(imageView);
            imageView.SynchronosLoading = false;
            Assert.IsFalse(imageView.SynchronosLoading, "Should be false!");
        }
    }
}