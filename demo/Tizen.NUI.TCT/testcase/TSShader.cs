using NUnit.Framework;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Shader Tests")]

    public class ShaderTests
    {
        private string TAG = "NUI-TCT";
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
        [Description("Create a Shader object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Shader.Shader C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "string,string,Shader.Hint.Value")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void Shader_Hint_INIT()
        {
            /* TEST CODE */
            var sShader = new Shader(VertexShader, FragmentShader, Shader.Hint.Value.OUTPUT_IS_TRANSPARENT);
            Assert.IsNotNull(sShader, "Can't create success object Shader");
            Assert.IsInstanceOf<Shader>(sShader, "Should be an instance of Shader type.");
        }

        [Test]
        [Category("P1")]
        [Description("Create a Shader object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Shader.Shader C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "string,string")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void Shader_INIT()
        {
            /* TEST CODE */
            var sShader = new Shader(VertexShader, FragmentShader);
            Assert.IsNotNull(sShader, "Can't create success object Shader");
            Assert.IsInstanceOf<Shader>(sShader, "Should be an instance of Shader type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Program Check whether Program is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Shader.Program A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void Program_SET_GET_VALUE()
        {
            var sShader = new Shader(VertexShader, FragmentShader);

            PropertyMap propertyMap = new PropertyMap();
            PropertyValue propertyValueVertex = new PropertyValue(VertexShader);
            PropertyValue propertyValueFragment = new PropertyValue(FragmentShader);

            propertyMap.Insert("vertex", propertyValueVertex);
            propertyMap.Insert("fragment", propertyValueFragment);


            sShader.Program = propertyMap;

            PropertyKey key = sShader.Program.GetKeyAt(0);
            Assert.AreEqual("vertex", key.StringKey, "Should be Equal.");
        }
    }
}



