using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Geometry Tests")]

    public class GeometryTests
    {
        private string TAG = "NUI";

        [Test]
        [Category("P1")]
        [Description("Create a Geometry object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Geometry.Geometry C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void Geometry_INIT()
        {
            /* TEST CODE */
            var sGeometry = new Geometry();
            Assert.IsNotNull(sGeometry, "Can't create success object Geometry");
            Assert.IsInstanceOf<Geometry>(sGeometry, "Should be an instance of Geometry type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test AddVertexBuffer.Test whether AddVertexBuffer returns the value expected")]
        [Property("SPEC", "Tizen.NUI.Geometry.AddVertexBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void AddVertexBuffer_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            PropertyMap propertyMap = new PropertyMap();
            propertyMap.Add("aIndex", new PropertyValue((int)PropertyType.Float));
            propertyMap.Add("aValue", new PropertyValue((int)PropertyType.Float));
            PropertyBuffer propertyBuffer = new PropertyBuffer(propertyMap);

            var sGeometry = new Geometry();
            uint iBRet = sGeometry.GetNumberOfVertexBuffers();
            sGeometry.AddVertexBuffer(propertyBuffer);
            uint iFRet = sGeometry.GetNumberOfVertexBuffers();
            Assert.AreEqual(iFRet-iBRet, 1 ,"Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetNumberOfVertexBuffers.Test whether GetNumberOfVertexBuffers returns the value expected")]
        [Property("SPEC", "Tizen.NUI.Geometry.GetNumberOfVertexBuffers M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void GetNumberOfVertexBuffers_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            PropertyMap propertyMap = new PropertyMap();
            propertyMap.Add("aIndex", new PropertyValue((int)PropertyType.Float));
            propertyMap.Add("aValue", new PropertyValue((int)PropertyType.Float));
            PropertyBuffer propertyBuffer1 = new PropertyBuffer(propertyMap);
            PropertyBuffer propertyBuffer2 = new PropertyBuffer(propertyMap);
            var sGeometry = new Geometry();
            sGeometry.AddVertexBuffer(propertyBuffer1);
            sGeometry.AddVertexBuffer(propertyBuffer2);
            uint iRet = sGeometry.GetNumberOfVertexBuffers();
            Assert.AreEqual(iRet, 2 ,"Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test RemoveVertexBuffer.Test whether RemoveVertexBuffer works or not")]
        [Property("SPEC", "Tizen.NUI.Geometry.RemoveVertexBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void RemoveVertexBuffer_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            PropertyMap propertyMap = new PropertyMap();
            propertyMap.Add("aIndex", new PropertyValue((int)PropertyType.Float));
            propertyMap.Add("aValue", new PropertyValue((int)PropertyType.Float));
            PropertyBuffer propertyBuffer1 = new PropertyBuffer(propertyMap);
            PropertyBuffer propertyBuffer2 = new PropertyBuffer(propertyMap);
            var sGeometry = new Geometry();
            sGeometry.AddVertexBuffer(propertyBuffer1);
            sGeometry.AddVertexBuffer(propertyBuffer2);
            try
            {
                sGeometry.RemoveVertexBuffer(0);
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
        [Description("Test SetIndexBuffer.Test whether SetIndexBuffer works or not")]
        [Property("SPEC", "Tizen.NUI.Geometry.SetIndexBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void SetIndexBuffer_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            PropertyMap propertyMap = new PropertyMap();
            propertyMap.Add("aIndex", new PropertyValue((int)PropertyType.Float));
            propertyMap.Add("aValue", new PropertyValue((int)PropertyType.Float));
            PropertyBuffer propertyBuffer1 = new PropertyBuffer(propertyMap);
            PropertyBuffer propertyBuffer2 = new PropertyBuffer(propertyMap);
            var sGeometry = new Geometry();
            sGeometry.AddVertexBuffer(propertyBuffer1);
            sGeometry.AddVertexBuffer(propertyBuffer2);
            ushort[] array = new ushort[] { 0, 0};
            try
            {
                sGeometry.SetIndexBuffer(array, 2);
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
        [Description("Test SetType.Test whether SetType works or not")]
        [Property("SPEC", "Tizen.NUI.Geometry.SetType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void SetType_SET_VALUE()
        {
            /* TEST CODE */
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Assert.AreEqual(sGeometry.GetType(),Geometry.Type.POINTS ,"Should be Equal.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetType.Test whether GetType works or not")]
        [Property("SPEC", "Tizen.NUI.Geometry.GetType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void GetType_GET_VALUE()
        {
            /* TEST CODE */
            Geometry sGeometry = new Geometry();
            sGeometry.SetType(Geometry.Type.POINTS);
            Assert.AreEqual(sGeometry.GetType(),Geometry.Type.POINTS ,"Should be Equal.");
        }

    }
}

