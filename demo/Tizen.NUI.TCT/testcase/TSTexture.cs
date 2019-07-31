using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Texture Tests")]
    public class TextureTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("TextureTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a Texture object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Texture.Texture C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Youxia Wu, youxia17.wu@samsung.com")]
        public void Texture_INIT()
        {
            /* TEST CODE */
            Texture texture = new Texture(TextureType.TEXTURE_2D, PixelFormat.RGBA8888, (uint)64, (uint)64);
            Assert.IsNotNull(texture, "Can't create success object Texture");
            Assert.IsInstanceOf<Texture>(texture, "Should be an instance of Texture type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetWidth.Check whether GetWidth function works or not.")]
        [Property("SPEC", "Tizen.NUI.Texture.GetWidth M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Youxia Wu, youxia17.wu@samsung.com")]
        public void GetWidth_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Texture texture = new Texture(TextureType.TEXTURE_2D, PixelFormat.RGBA8888, 64, 64);
            Assert.AreEqual(64, texture.GetWidth(), "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetHeight.Check whether GetHeight function works or not.")]
        [Property("SPEC", "Tizen.NUI.Texture.GetHeight M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Youxia Wu, youxia17.wu@samsung.com")]
        public void GetHeight_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Texture texture = new Texture(TextureType.TEXTURE_2D, PixelFormat.RGBA8888, 64, 64);
            Assert.AreEqual(64, texture.GetHeight(), "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test GenerateMipmaps. Check whether GenerateMipmaps function works or not.")]
        [Property("SPEC", "Tizen.NUI.Texture.GenerateMipmaps M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Youxia Wu, youxia17.wu@samsung.com")]
        public void GenerateMipmaps_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                Texture texture = new Texture(TextureType.TEXTURE_2D, PixelFormat.RGBA8888, 64, 64);
                texture.GenerateMipmaps();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Upload. Check whether GenerateMipmaps function works or not.")]
        [Property("SPEC", "Tizen.NUI.Texture.Upload M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("COVPARAM", "PixelData")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Upload_PixelData_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                uint width = 64;
                uint height = 64;
                Texture texture = new Texture(TextureType.TEXTURE_2D, PixelFormat.RGBA8888, width, height);
                uint bufferSize = width * height * 4;
                byte[] buffer = new byte[bufferSize];
                PixelData pixelData = new PixelData(buffer, bufferSize, width, height, PixelFormat.RGBA8888, PixelData.ReleaseFunction.Free);
                texture.Upload(pixelData);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Upload. Check whether GenerateMipmaps function works or not.")]
        [Property("SPEC", "Tizen.NUI.Texture.Upload M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("COVPARAM", "PixelData, uint, uint, uint, uint, uint, uint")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Upload_Multi_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                uint width = 64;
                uint height = 64;
                Texture texture = new Texture(TextureType.TEXTURE_2D, PixelFormat.RGBA8888, width, height);
                uint bufferSize = width * height * 2;
                byte[] buffer = new byte[bufferSize];
                PixelData pixelData = new PixelData(buffer, bufferSize, width, height, PixelFormat.RGBA8888, PixelData.ReleaseFunction.Free);
                texture.Upload(pixelData, 0u, 0u, width / 2, height / 2, width / 2, height / 2);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
    }
}