using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.TextureSet Tests")]
    public class TextureSetTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("TextureSetTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a TextureSet object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.TextureSet.TextureSet C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Youxia Wu, youxia17.wu@samsung.com")]
        public void TextureSet_INIT()
        {
            /* TEST CODE */
            var textureSet = new TextureSet();
            Assert.IsNotNull(textureSet, "Can't create success object TextureSet");
            Assert.IsInstanceOf<TextureSet>(textureSet, "Should be an instance of TextureSet type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetSampler.Check whether GetSampler function works or not.")]
        [Property("SPEC", "Tizen.NUI.TextureSet.GetSampler M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Youxia Wu, youxia17.wu@samsung.com")]
        public void GetSampler_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            TextureSet textureSet = new TextureSet();
            Sampler sampler0 = new Sampler();
            Sampler sampler1 = new Sampler();
            textureSet.SetSampler(0, sampler0);
            textureSet.SetSampler(1, sampler1);
            Assert.IsTrue(sampler0 == textureSet.GetSampler(0), "Retrieved sampler0 should be equal to set value");
            Assert.IsTrue(sampler1 == textureSet.GetSampler(1), "Retrieved sampler1 should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetSampler.Check whether SetSampler function works or not.")]
        [Property("SPEC", "Tizen.NUI.TextureSet.SetSampler M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Youxia Wu, youxia17.wu@samsung.com")]
        public void SetSampler_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            TextureSet textureSet = new TextureSet();
            Sampler sampler0 = new Sampler();
            Sampler sampler1 = new Sampler();
            textureSet.SetSampler(0, sampler0);
            textureSet.SetSampler(1, sampler1);
            Assert.IsTrue(sampler0 == textureSet.GetSampler(0), "Retrieved sampler0 should be equal to set value");
            Assert.IsTrue(sampler1 == textureSet.GetSampler(1), "Retrieved sampler1 should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetTexture.Check whether GetTexture function works or not.")]
        [Property("SPEC", "Tizen.NUI.TextureSet.GetTexture M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Youxia Wu, youxia17.wu@samsung.com")]
        public void GetTexture_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            TextureSet textureSet = new TextureSet();
            Texture texture = new Texture(TextureType.TEXTURE_2D, PixelFormat.RGBA8888, 64, 64);
            textureSet.SetTexture(0, texture);
            Assert.IsTrue(texture == textureSet.GetTexture(0), "Retrieved texture should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetTexture.Check whether SetTexture function works or not.")]
        [Property("SPEC", "Tizen.NUI.TextureSet.SetTexture M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Youxia Wu, youxia17.wu@samsung.com")]
        public void SetTexture_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            TextureSet textureSet = new TextureSet();
            Texture texture = new Texture(TextureType.TEXTURE_2D, PixelFormat.RGBA8888, 64, 64);
            textureSet.SetTexture(0, texture);
            Assert.IsTrue(texture == textureSet.GetTexture(0), "Retrieved texture should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetTextureCount.Check whether GetTextureCount function works or not.")]
        [Property("SPEC", "Tizen.NUI.TextureSet.GetTextureCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Youxia Wu, youxia17.wu@samsung.com")]
        public void GetTextureCount_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            TextureSet textureSet = new TextureSet();
            Texture texture = new Texture(TextureType.TEXTURE_2D, PixelFormat.RGBA8888, 64, 64);
            textureSet.SetTexture(0, texture);
            textureSet.SetTexture(1, texture);
            textureSet.SetTexture(2, texture);
            Assert.AreEqual(3, textureSet.GetTextureCount(), "Retrieved GetTextureCount should be equal to set value");
        }
    }
}