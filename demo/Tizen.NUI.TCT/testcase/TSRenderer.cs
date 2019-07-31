using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Renderer Tests")]

    public class RendererTests
    {
        private string TAG = "NUI";
        private string VertexShader = " attribute mediump vec2 aPosition;\n" +
            " uniform   mediump mat4 uMvpMatrix;\n" +
            " \n" +
            " void main()\n" +
            " {\n" +
            "   mediump vec4 vertexPosition = vec4(aPosition, 0.0, 1.0);\n" +
            "   gl_Position = uMvpMatrix * vertexPosition;\n" +
            " }\n";
        private string FragmentShader = " uniform mediump vec4 uColor;\n" +
                                        "  \n" +
                                        "  void main()\n" +
                                        "  {\n" +
                                        " gl_FragColor = uColor;\n" +
                                        " }\n";


        [Test]
        [Category("P1")]
        [Description("Create a Renderer object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Renderer.Renderer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void Renderer_INIT()
        {
            /* TEST CODE */
            Geometry sGeometry = new Geometry();
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            Assert.IsNotNull(sShader, "Can't create success object sRenderer");
            Assert.IsInstanceOf<Renderer>(sRenderer, "Should be an instance of sRenderer type.");
        }


        [Test]
        [Category("P1")]
        [Description("Test SetGeometry.Test whether SetGeometry works or not")]
        [Property("SPEC", "Tizen.NUI.Renderer.SetGeometry M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void SetGeometry_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            Geometry sGeometry1 = new Geometry();
            sGeometry1.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry1, sShader);
            Geometry sGeometry2 = new Geometry();
            sGeometry2.SetType(Geometry.Type.LINE_LOOP);
            sRenderer.SetGeometry(sGeometry2);
            Assert.AreEqual(sRenderer.GetGeometry().GetType(), Geometry.Type.LINE_LOOP, "Should be Equal.");
        }


        [Test]
        [Category("P1")]
        [Description("Test GetGeometry.Test whether GetGeometry works or not")]
        [Property("SPEC", "Tizen.NUI.Renderer.GetGeometry M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void GetGeometry_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            Assert.AreEqual(sRenderer.GetGeometry().GetType(), Geometry.Type.POINTS, "Should be Equal.");
        }


        [Test]
        [Category("P1")]
        [Description("Test Renderer.Test whether Renderer works or not")]
        [Property("SPEC", "Tizen.NUI.Renderer.SetIndexRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void SetIndexRange_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            try
            {
                sRenderer.SetIndexRange(0, 0);
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
        [Description("Test SetTextures.Test whether SetTextures works or not")]
        [Property("SPEC", "Tizen.NUI.Renderer.SetTextures M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void SetTextures_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            TextureSet textureSet = new TextureSet();
            Texture texture = new Texture(TextureType.TEXTURE_2D, PixelFormat.A8, 10, 10);
            textureSet.SetTexture(0, texture);
            sRenderer.SetTextures(textureSet);
            Assert.AreEqual(sRenderer.GetTextures().GetTexture(0).GetWidth(), 10, "Should be Equal.");
            Assert.AreEqual(sRenderer.GetTextures().GetTexture(0).GetHeight(), 10, "Should be Equal.");
        }


        [Test]
        [Category("P1")]
        [Description("Test GetTextures.Test whether GetTextures works or not")]
        [Property("SPEC", "Tizen.NUI.Renderer.GetTextures M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void GetTextures_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);

            TextureSet textureSet = new TextureSet();
            Texture texture = new Texture(TextureType.TEXTURE_2D, PixelFormat.A8, 10, 10);
            textureSet.SetTexture(0, texture);
            sRenderer.SetTextures(textureSet);
            Assert.AreEqual(sRenderer.GetTextures().GetTexture(0).GetWidth(), 10, "Should be Equal.");
            Assert.AreEqual(sRenderer.GetTextures().GetTexture(0).GetHeight(), 10, "Should be Equal.");
        }


        [Test]
        [Category("P1")]
        [Description("Test SetShader.Test whether SetShader works or not")]
        [Property("SPEC", "Tizen.NUI.Renderer.SetShader M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void SetShader_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);

            PropertyMap propertyMap = new PropertyMap();
            PropertyValue propertyValueVertex = new PropertyValue(VertexShader);
            PropertyValue propertyValueFragment = new PropertyValue(FragmentShader);

            propertyMap.Insert("vertex", propertyValueVertex);
            propertyMap.Insert("fragment", propertyValueFragment);
            Shader sShader1 = new Shader(VertexShader, FragmentShader);
            sShader1.Program = propertyMap;

            sRenderer.SetShader(sShader1);
            PropertyKey key = sRenderer.GetShader().Program.GetKeyAt(0);
            Assert.AreEqual("vertex", key.StringKey, "Should be Equal.");
        }


        [Test]
        [Category("P1")]
        [Description("Test GetShader.Test whether GetShader works or not")]
        [Property("SPEC", "Tizen.NUI.Renderer.GetShader M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void GetShader_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);

            PropertyMap propertyMap = new PropertyMap();
            PropertyValue propertyValueVertex = new PropertyValue(VertexShader);
            PropertyValue propertyValueFragment = new PropertyValue(FragmentShader);
            propertyMap.Insert("vertex", propertyValueVertex);
            propertyMap.Insert("fragment", propertyValueFragment);
            Shader sShader1 = new Shader(VertexShader, FragmentShader);
            sShader1.Program = propertyMap;

            sRenderer.SetShader(sShader1);
            PropertyKey key = sRenderer.GetShader().Program.GetKeyAt(0);
            Assert.AreEqual("vertex", key.StringKey, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test DepthIndex Check whether DepthIndex is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.DepthIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void DepthIndex_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.DepthIndex = 1;
            Assert.AreEqual(sRenderer.DepthIndex, 1, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test FaceCullingMode Check whether FaceCullingMode is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.FaceCullingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void FaceCullingMode_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.FaceCullingMode = 1;
            Assert.AreEqual(sRenderer.FaceCullingMode, 1, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test BlendMode Check whether BlendMode is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.BlendMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void BlendMode_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.BlendMode = 1;
            Assert.AreEqual(sRenderer.BlendMode, 1, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test BlendEquationRgb Check whether BlendEquationRgb is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.BlendEquationRgb A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void BlendEquationRgb_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.BlendEquationRgb = 32774;
            Assert.AreEqual(sRenderer.BlendEquationRgb, 32774, "Should be Equal.");
        }


        [Test]
        [Category("P1")]
        [Description("Test BlendEquationAlpha Check whether BlendEquationAlpha is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.BlendEquationAlpha A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void BlendEquationAlpha_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.BlendEquationAlpha = 32774;
            Assert.AreEqual(sRenderer.BlendEquationAlpha, 32774, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test BlendFactorSrcRgb Check whether BlendFactorSrcRgb is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.BlendFactorSrcRgb A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void BlendFactorSrcRgb_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.BlendFactorSrcRgb = 1;
            Assert.AreEqual(sRenderer.BlendFactorSrcRgb, 1, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test BlendFactorDestRgb Check whether BlendFactorDestRgb is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.BlendFactorDestRgb A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void BlendFactorDestRgb_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.BlendFactorDestRgb = 1;
            Assert.AreEqual(sRenderer.BlendFactorDestRgb, 1, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test BlendFactorSrcAlpha Check whether BlendFactorSrcAlpha is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.BlendFactorSrcAlpha A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void BlendFactorSrcAlpha_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.BlendFactorSrcAlpha = 1;
            Assert.AreEqual(sRenderer.BlendFactorSrcAlpha, 1, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test BlendFactorDestAlpha Check whether BlendFactorDestAlpha is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.BlendFactorDestAlpha A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void BlendFactorDestAlpha_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.BlendFactorDestAlpha = 1;
            Assert.AreEqual(sRenderer.BlendFactorDestAlpha, 1, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test BlendColor Check whether BlendColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.BlendColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void BlendColor_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);

            float[] array = new float[4] { 0.5f, 0.5f, 0.5f, 1.0f };
            var color = new Color(array);
            sRenderer.BlendColor = color;
            Assert.IsInstanceOf<Color>(color, "Should return Color instance.");
            Assert.AreEqual(0.5f, sRenderer.BlendColor.R, "The R property of Black is not correct here.");
            Assert.AreEqual(0.5f, sRenderer.BlendColor.G, "The G property of Black is not correct here.");
            Assert.AreEqual(0.5f, sRenderer.BlendColor.B, "The B property of Black is not correct here.");
            Assert.AreEqual(1.0f, sRenderer.BlendColor.A, "The A property of Black is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test BlendPreMultipliedAlpha Check whether BlendPreMultipliedAlpha is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.BlendPreMultipliedAlpha A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void BlendPreMultipliedAlpha_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.BlendPreMultipliedAlpha = true;
            Assert.IsTrue(sRenderer.BlendPreMultipliedAlpha, "Should be True.");
        }

        [Test]
        [Category("P1")]
        [Description("Test IndexRangeFirst Check whether IndexRangeFirst is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.IndexRangeFirst A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void IndexRangeFirst_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.IndexRangeFirst = 1;
            Assert.AreEqual(sRenderer.IndexRangeFirst, 1, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test IndexRangeCount Check whether IndexRangeCount is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.IndexRangeCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void IndexRangeCount_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.IndexRangeCount = 1;
            Assert.AreEqual(sRenderer.IndexRangeCount, 1, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test DepthWriteMode Check whether DepthWriteMode is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.DepthWriteMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void DepthWriteMode_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.DepthWriteMode = 1;
            Assert.AreEqual(sRenderer.DepthWriteMode, 1, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test DepthFunction Check whether DepthFunction is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.DepthFunction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void DepthFunction_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.DepthFunction = 1;
            Assert.AreEqual(sRenderer.DepthFunction, 1, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test DepthTestMode Check whether DepthTestMode is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.DepthTestMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void DepthTestMode_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.DepthTestMode = 1;
            Assert.AreEqual(sRenderer.DepthTestMode, 1, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test RenderMode Check whether RenderMode is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.RenderMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void RenderMode_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.RenderMode = 1;
            Assert.AreEqual(sRenderer.RenderMode, 1, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test StencilFunction Check whether StencilFunction is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.StencilFunction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void StencilFunction_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.StencilFunction = 1;
            Assert.AreEqual(sRenderer.StencilFunction, 1, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test StencilFunctionMask Check whether StencilFunctionMask is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.StencilFunctionMask A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void StencilFunctionMask_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.StencilFunctionMask = 1;
            Assert.AreEqual(sRenderer.StencilFunctionMask, 1, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test StencilFunctionReference Check whether StencilFunctionReference is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.StencilFunctionReference A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void StencilFunctionReference_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.StencilFunctionReference = 1;
            Assert.AreEqual(sRenderer.StencilFunctionReference, 1, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test StencilMask Check whether StencilMask is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.StencilMask A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void StencilMask_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.StencilMask = 1;
            Assert.AreEqual(sRenderer.StencilMask, 1, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test StencilOperationOnFail Check whether StencilOperationOnFail is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.StencilOperationOnFail A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void StencilOperationOnFail_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.StencilOperationOnFail = 1;
            Assert.AreEqual(sRenderer.StencilOperationOnFail, 1, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test StencilOperationOnZFail Check whether StencilOperationOnZFail is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.StencilOperationOnZFail A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void StencilOperationOnZFail_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.StencilOperationOnZFail = 1;
            Assert.AreEqual(sRenderer.StencilOperationOnZFail, 1, "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test StencilOperationOnZPass Check whether StencilOperationOnZPass is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Renderer.StencilOperationOnZPass A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void StencilOperationOnZPass_SET_GET_VALUE()
        {
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Shader sShader = new Shader(VertexShader, FragmentShader);
            var sRenderer = new Renderer(sGeometry, sShader);
            sRenderer.StencilOperationOnZPass = 1;
            Assert.AreEqual(sRenderer.StencilOperationOnZPass, 1, "Should be Equal.");
        }
    }
}


