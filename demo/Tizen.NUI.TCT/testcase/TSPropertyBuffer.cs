using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using System.Runtime.InteropServices;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.PropertyBuffer Tests")]

    public class PropertyBufferTests
    {
        private string TAG = "NUI";
        private struct TexturedQuadVertex {public Vector2 position; public Vector2 textureCoordinates; };

        [Test]
        [Category("P1")]
        [Description("Create a PropertyBuffer object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyBuffer.PropertyBuffer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void PropertyBuffer_INIT()
        {
            /* TEST CODE */
            PropertyMap propertyMap = new PropertyMap();
            propertyMap.Add("aIndex", new PropertyValue((int)PropertyType.Float));
            propertyMap.Add("aValue", new PropertyValue((int)PropertyType.Float));
            var sPropertyBuffer = new PropertyBuffer(propertyMap);
            Assert.IsNotNull(sPropertyBuffer, "Can't create success object PropertyBuffer");
            Assert.IsInstanceOf<PropertyBuffer>(sPropertyBuffer, "Should be an instance of PropertyBuffer type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetSize.Test whether GetSize works or not")]
        [Property("SPEC", "Tizen.NUI.PropertyBuffer.GetSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void GetSize_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            PropertyMap bufferFormat = new PropertyMap();
            bufferFormat.Add("aIndex", new PropertyValue((int)PropertyType.Float));
            bufferFormat.Add("aValue", new PropertyValue((int)PropertyType.Float));
            var sPropertyBuffer = new PropertyBuffer(bufferFormat);

            Assert.AreEqual(0, sPropertyBuffer.GetSize(), "Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetData.Test whether SetData works or not")]
        [Property("SPEC", "Tizen.NUI.PropertyBuffer.SetData M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SetData_CHECK()
        {
            /* TEST CODE */
            PropertyMap bufferFormat = new PropertyMap();
            bufferFormat.Add("aIndex", new PropertyValue((int)PropertyType.Float));
            bufferFormat.Add("aValue", new PropertyValue((int)PropertyType.Float));
            var sPropertyBuffer = new PropertyBuffer(bufferFormat);
            try
            {
                global::System.IntPtr data = new global::System.IntPtr();
                sPropertyBuffer.SetData(data, 0);
            }
            catch (Exception e)
            {
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            Assert.AreEqual(0, sPropertyBuffer.GetSize(), "Should be Equal.");
        }
    }
}

