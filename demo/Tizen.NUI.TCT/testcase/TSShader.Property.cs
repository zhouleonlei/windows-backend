using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Shader.Property Tests")]
    public class ShaderPropertyTests
    {
        private string TAG = "NUI";
        private static int DEFAULT_OBJECT_PROPERTY_START_INDEX = 0;

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ShaderPropertyTests");
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
        [Property("SPEC", "Tizen.NUI.Shader.Property.Property C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Property_INIT()
        {
            /* TEST CODE */
            var property = new Shader.Property();
            Assert.IsNotNull(property, "Can't create success object Property");
            Assert.IsInstanceOf<Shader.Property>(property, "Should be an instance of Property type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test PROGRAM. Check whether PROGRAM returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Shader.Property.PROGRAM A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PROGRAM_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(DEFAULT_OBJECT_PROPERTY_START_INDEX, Shader.Property.PROGRAM, "PROGRAM shold be equals to the set value");
        }
    }
}
