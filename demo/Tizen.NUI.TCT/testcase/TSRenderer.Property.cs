using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Renderer.Property Tests")]
    public class RendererPropertyTests
    {
        private string TAG = "NUI";
        private static int DEFAULT_RENDERER_PROPERTY_START_INDEX = 9000000;

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ScrollablePropertyTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a Property object. Check whether Property is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.Property C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Property_INIT()
        {
            /* TEST CODE */
            var property = new Renderer.Property();
            Assert.IsNotNull(property, "Can't create success object Property");
            Assert.IsInstanceOf<Renderer.Property>(property, "Should be an instance of Property type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test DEPTH_INDEX. Check whether DEPTH_INDEX returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.DEPTH_INDEX A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void DEPTH_INDEX_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX, Renderer.Property.DEPTH_INDEX, "DEPTH_INDEX shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test FACE_CULLING_MODE. Check whether FACE_CULLING_MODE returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.FACE_CULLING_MODE A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void FACE_CULLING_MODE_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 1, Renderer.Property.FACE_CULLING_MODE, "FACE_CULLING_MODE shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test BLEND_MODE. Check whether BLEND_MODE returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.BLEND_MODE A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void BLEND_MODE_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 2, Renderer.Property.BLEND_MODE, "BLEND_MODE shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test BLEND_EQUATION_RGB. Check whether BLEND_EQUATION_RGB returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.BLEND_EQUATION_RGB A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void BLEND_EQUATION_RGB_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 3, Renderer.Property.BLEND_EQUATION_RGB, "BLEND_EQUATION_RGB shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test BLEND_EQUATION_ALPHA. Check whether BLEND_EQUATION_ALPHA returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.BLEND_EQUATION_ALPHA A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void BLEND_EQUATION_ALPHA_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 4, Renderer.Property.BLEND_EQUATION_ALPHA, "BLEND_EQUATION_ALPHA shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test BLEND_FACTOR_SRC_RGB. Check whether BLEND_FACTOR_SRC_RGB returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.BLEND_FACTOR_SRC_RGB A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void BLEND_FACTOR_SRC_RGB_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 5, Renderer.Property.BLEND_FACTOR_SRC_RGB, "BLEND_FACTOR_SRC_RGB shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test BLEND_FACTOR_DEST_RGB. Check whether BLEND_FACTOR_DEST_RGB returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.BLEND_FACTOR_DEST_RGB A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void BLEND_FACTOR_DEST_RGB_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 6, Renderer.Property.BLEND_FACTOR_DEST_RGB, "BLEND_FACTOR_DEST_RGB shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test BLEND_FACTOR_SRC_ALPHA. Check whether BLEND_FACTOR_SRC_ALPHA returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.BLEND_FACTOR_SRC_ALPHA A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void BLEND_FACTOR_SRC_ALPHA_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 7, Renderer.Property.BLEND_FACTOR_SRC_ALPHA, "BLEND_FACTOR_SRC_ALPHA shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test BLEND_FACTOR_DEST_ALPHA. Check whether BLEND_FACTOR_DEST_ALPHA returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.BLEND_FACTOR_DEST_ALPHA A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void BLEND_FACTOR_DEST_ALPHA_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 8, Renderer.Property.BLEND_FACTOR_DEST_ALPHA, "BLEND_FACTOR_DEST_ALPHA shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test BLEND_COLOR. Check whether BLEND_COLOR returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.BLEND_COLOR A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void BLEND_COLOR_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 9, Renderer.Property.BLEND_COLOR, "BLEND_COLOR shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test BLEND_PRE_MULTIPLIED_ALPHA. Check whether BLEND_PRE_MULTIPLIED_ALPHA returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.BLEND_PRE_MULTIPLIED_ALPHA A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void BLEND_PRE_MULTIPLIED_ALPHA_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 10, Renderer.Property.BLEND_PRE_MULTIPLIED_ALPHA, "BLEND_PRE_MULTIPLIED_ALPHA shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test INDEX_RANGE_FIRST. Check whether INDEX_RANGE_FIRST returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.INDEX_RANGE_FIRST A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void INDEX_RANGE_FIRST_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 11, Renderer.Property.INDEX_RANGE_FIRST, "INDEX_RANGE_FIRST shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test INDEX_RANGE_COUNT. Check whether INDEX_RANGE_COUNT returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.INDEX_RANGE_COUNT A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void INDEX_RANGE_COUNT_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 12, Renderer.Property.INDEX_RANGE_COUNT, "INDEX_RANGE_COUNT shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test DEPTH_WRITE_MODE. Check whether DEPTH_WRITE_MODE returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.DEPTH_WRITE_MODE A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void DEPTH_WRITE_MODE_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 13, Renderer.Property.DEPTH_WRITE_MODE, "DEPTH_WRITE_MODE shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test DEPTH_FUNCTION. Check whether DEPTH_FUNCTION returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.DEPTH_FUNCTION A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void DEPTH_FUNCTION_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 14, Renderer.Property.DEPTH_FUNCTION, "DEPTH_FUNCTION shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test DEPTH_TEST_MODE. Check whether DEPTH_TEST_MODE returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.DEPTH_TEST_MODE A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void DEPTH_TEST_MODE_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 15, Renderer.Property.DEPTH_TEST_MODE, "DEPTH_TEST_MODE shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test RENDER_MODE. Check whether RENDER_MODE returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.RENDER_MODE A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RENDER_MODE_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 16, Renderer.Property.RENDER_MODE, "RENDER_MODE shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test STENCIL_FUNCTION. Check whether STENCIL_FUNCTION returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.STENCIL_FUNCTION A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void STENCIL_FUNCTION_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 17, Renderer.Property.STENCIL_FUNCTION, "STENCIL_FUNCTION shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test STENCIL_FUNCTION_MASK. Check whether STENCIL_FUNCTION_MASK returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.STENCIL_FUNCTION_MASK A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void STENCIL_FUNCTION_MASK_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 18, Renderer.Property.STENCIL_FUNCTION_MASK, "STENCIL_FUNCTION_MASK shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test STENCIL_FUNCTION_REFERENCE. Check whether STENCIL_FUNCTION_REFERENCE returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.STENCIL_FUNCTION_REFERENCE A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void STENCIL_FUNCTION_REFERENCE_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 19, Renderer.Property.STENCIL_FUNCTION_REFERENCE, "STENCIL_FUNCTION_REFERENCE shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test STENCIL_MASK. Check whether STENCIL_MASK returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.STENCIL_MASK A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void STENCIL_MASK_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 20, Renderer.Property.STENCIL_MASK, "STENCIL_MASK shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test STENCIL_OPERATION_ON_FAIL. Check whether STENCIL_OPERATION_ON_FAIL returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.STENCIL_OPERATION_ON_FAIL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void STENCIL_OPERATION_ON_FAIL_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 21, Renderer.Property.STENCIL_OPERATION_ON_FAIL, "STENCIL_OPERATION_ON_FAIL shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test STENCIL_OPERATION_ON_Z_FAIL. Check whether STENCIL_OPERATION_ON_Z_FAIL returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.STENCIL_OPERATION_ON_Z_FAIL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void STENCIL_OPERATION_ON_Z_FAIL_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 22, Renderer.Property.STENCIL_OPERATION_ON_Z_FAIL, "STENCIL_OPERATION_ON_Z_FAIL shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test STENCIL_OPERATION_ON_Z_PASS. Check whether STENCIL_OPERATION_ON_Z_PASS returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Property.STENCIL_OPERATION_ON_Z_PASS A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void STENCIL_OPERATION_ON_Z_PASS_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_RENDERER_PROPERTY_START_INDEX + 23, Renderer.Property.STENCIL_OPERATION_ON_Z_PASS, "STENCIL_OPERATION_ON_Z_PASS shold be equals to the set value");
        }
    }
}
