using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.RelativeVector3 Tests")]
    public class RelativeVector3Tests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("RelativeVector3Tests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali RelativeVector3 constructor test.Check whether RelativeVector3 object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.RelativeVector3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RelativeVector3_INIT()
        {
            /* TEST CODE */
            var vector = new RelativeVector3();
            Assert.IsInstanceOf<RelativeVector3>(vector, "Should return Vector3 instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali RelativeVector3 constructor test.Check whether RelativeVector3 object which initialized with three singles is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.RelativeVector3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single, Single, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RelativeVector3_INIT_WITH_SINGLE_SINGLE_SINGLE()
        {
            /* TEST CODE */
            var vector = new RelativeVector3(0.5f, 0.6f, 0.7f);
            Assert.IsInstanceOf<RelativeVector3>(vector, "Should return Vector3 instance.");
            Assert.AreEqual(0.5f, vector.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(0.6f, vector.Y, "Retrieved vector.Y should be equal to set value");
            Assert.AreEqual(0.7f, vector.Z, "Retrieved vector.Z should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("dali RelativeVector3 constructor test.Check whether RelativeVector3 object which initialized with RelativeVector2 is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.RelativeVector3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "RelativeVector2")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RelativeVector3_INIT_WITH_RELATIVEVECTOR2()
        {
            /* TEST CODE */
            RelativeVector2 vec2 = new RelativeVector2(0.5f, 0.6f);

            var vector = new RelativeVector3(vec2);
            Assert.IsInstanceOf<RelativeVector3>(vector, "Should return Vector3 instance.");
            Assert.AreEqual(0.5f, vector.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(0.6f, vector.Y, "Retrieved vector.Y should be equal to set value");
            Assert.AreEqual(0.0f, vector.Z, "Retrieved vector.Z should be equal to set value");

        }

        [Test]
        [Category("P1")]
        [Description("dali RelativeVector3 constructor test.Check whether RelativeVector2 object which initialized with RelativeVector4 is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.RelativeVector3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "RelativeVector4")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RelativeVector3_INIT_WITH_RELATIVEVECTOR4()
        {
            /* TEST CODE */
            RelativeVector4 vec4 = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            var vector = new RelativeVector3(vec4);
            Assert.IsInstanceOf<RelativeVector3>(vector, "Should return Vector3 instance.");
            Assert.AreEqual(0.5f, vector.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(0.6f, vector.Y, "Retrieved vector.Y should be equal to set value");
            Assert.AreEqual(0.7f, vector.Z, "Retrieved vector.Z should be equal to set value");

        }

        [Test]
        [Category("P1")]
        [Description("Test this[uint index]. Check whether this[uint index] returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void this_GET_VALUE()
        {
            /* TEST CODE */
            RelativeVector3 vector = new RelativeVector3(0.5f, 0.6f, 0.7f);
            Assert.AreEqual(0.5f, vector[0], "The value of index[0] is not correct!");
            Assert.AreEqual(0.6f, vector[1], "The value of index[1] is not correct!");
            Assert.AreEqual(0.7f, vector[2], "The value of index[2] is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test EqualTo. Try to compare two RelativeVector3 instance by EqualTo.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void EqualTo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector3 vector1 = new RelativeVector3(1.0f, 0.5f, 0.4f);
            RelativeVector3 vector2 = new RelativeVector3(1.0f, 0.5f, 0.4f);
            Assert.IsTrue((vector1.EqualTo(vector2)), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test NotEqualTo. Try to compare two RelativeVector3 instance by NotEqualTo.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void NotEqualTo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector3 vector1 = new RelativeVector3(1.0f, 0.5f, 0.4f);
            RelativeVector3 vector2 = new RelativeVector3(1.0f, 0.5f, 0.6f);
            Assert.IsTrue((vector1.NotEqualTo(vector2)), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test X. Check whether X is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void X_GET_VALUE()
        {
            /* TEST CODE */
            RelativeVector3 v0 = new RelativeVector3(0.5f, 0.6f, 0.7f);
            Assert.AreEqual(0.5f, v0.X, "The X value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Y. Check whether Y is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Y_GET_VALUE()
        {
            /* TEST CODE */
            RelativeVector3 v0 = new RelativeVector3(0.5f, 0.6f, 0.7f);
            Assert.AreEqual(0.6f, v0.Y, "The Y value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Z. Check whether Z is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.Z A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Z_GET_VALUE()
        {
            /* TEST CODE */
            RelativeVector3 v0 = new RelativeVector3(0.5f, 0.6f, 0.7f);
            Assert.AreEqual(0.7f, v0.Z, "The Z value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator +.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.Addition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Addition_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector3 vector1 = new RelativeVector3(0.5f, 0.6f, 0.7f);
            RelativeVector3 vector2 = new RelativeVector3(0.4f, 0.3f, 0.2f);
            RelativeVector3 vector = vector1 + vector2;
            Assert.Less(Math.Abs(0.9f - vector.X), 0.0001f, "The X of the vector is not correct here!");
            Assert.Less(Math.Abs(0.9f - vector.Y), 0.0001f, "The Y of the vector is not correct here!");
            Assert.Less(Math.Abs(0.9f - vector.Z), 0.0001f, "The Z of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator -.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.Subtraction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Subtraction_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector3 vector1 = new RelativeVector3(0.5f, 0.6f, 0.7f);
            RelativeVector3 vector2 = new RelativeVector3(0.4f, 0.3f, 0.2f);
            RelativeVector3 vector = vector1 - vector2;
            Assert.Less(Math.Abs(0.1f - vector.X), 0.0001f, "The X of the vector is not correct here!");
            Assert.Less(Math.Abs(0.3f - vector.Y), 0.0001f, "The Y of the vector is not correct here!");
            Assert.Less(Math.Abs(0.5f - vector.Z), 0.0001f, "The Z of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator *.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "RelativeVector3, RelativeVector3")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Multiply_VECTOR3_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector3 vector1 = new RelativeVector3(0.5f, 0.6f, 0.7f);
            RelativeVector3 vector2 = new RelativeVector3(0.4f, 0.3f, 0.2f);
            RelativeVector3 vector = vector1 * vector2;
            Assert.Less(Math.Abs(0.2f - vector.X), 0.0001f, "The X of the vector is not correct here!");
            Assert.Less(Math.Abs(0.18f - vector.Y), 0.0001f, "The Y of the vector is not correct here!");
            Assert.Less(Math.Abs(0.14f - vector.Z), 0.0001f, "The Z of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator *.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "RelativeVector3, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Multiply_FLOAT_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector3 vector1 = new RelativeVector3(0.5f, 0.6f, 0.7f);
            RelativeVector3 vector = vector1 * 0.2f;
            Assert.Less(Math.Abs(0.1f - vector.X), 0.0001f, "The X of the vector is not correct here!");
            Assert.Less(Math.Abs(0.12f - vector.Y), 0.0001f, "The Y of the vector is not correct here!");
            Assert.Less(Math.Abs(0.14f - vector.Z), 0.0001f, "The Z of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator /.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "RelativeVector3, RelativeVector3")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Division_VECTOR3_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector3 vector1 = new RelativeVector3(0.5f, 0.6f, 0.7f);
            RelativeVector3 vector2 = new RelativeVector3(1.0f, 0.6f, 0.7f);
            RelativeVector3 vector = vector1 / vector2;
            Assert.Less(Math.Abs(0.5f - vector.X), 0.0001f, "The X of the vector is not correct here!");
            Assert.Less(Math.Abs(1.0f - vector.Y), 0.0001f, "The Y of the vector is not correct here!");
            Assert.Less(Math.Abs(1.0f - vector.Z), 0.0001f, "The Z of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator /.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "RelativeVector3, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Division_FLOAT_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector3 vector1 = new RelativeVector3(0.5f, 0.6f, 0.7f);
            RelativeVector3 vector = vector1 / 10.0f;
            Assert.Less(Math.Abs(0.05f - vector.X), 0.0001f, "The X of the vector is not correct here!");
            Assert.Less(Math.Abs(0.06f - vector.Y), 0.0001f, "The Y of the vector is not correct here!");
            Assert.Less(Math.Abs(0.07f - vector.Z), 0.0001f, "The Z of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Equals. Check whether Equals returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Equals_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector3 vector1 = new RelativeVector3(0.02f, 0.02f, 0.02f);
            RelativeVector3 vector2 = new RelativeVector3(0.02f, 0.02f, 0.02f);

            bool flag = vector1.Equals(vector2);
            Assert.IsTrue(flag, "Should be true here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test implicit vector3. Try to convert a vector3 instance to a RelativeVector3 instance.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector3")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void implicit_VECTOR3_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector3 vector = new Vector3(0.5f, 0.6f, 0.7f);
            RelativeVector3 relativeVector3 = vector;
            Assert.AreEqual(relativeVector3.X, vector.X, "The value of X is not correct.");
            Assert.AreEqual(relativeVector3.Y, vector.Y, "The value of Y is not correct.");
            Assert.AreEqual(relativeVector3.Z, vector.Z, "The value of Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test implicit RelativeVector3. Try to convert a position instance to a vector3 instance.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "RelativeVector3")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void implicit_POSITION_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector3 relativeVector3 = new RelativeVector3(0.5f, 0.6f, 0.7f);
            Vector3 vector = relativeVector3;
            Assert.AreEqual(relativeVector3.X, vector.X, "The value of X is not correct.");
            Assert.AreEqual(relativeVector3.Y, vector.Y, "The value of Y is not correct.");
            Assert.AreEqual(relativeVector3.Z, vector.Z, "The value of Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the RelativeVector3.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                RelativeVector3 vector1 = new RelativeVector3(0.5f, 0.6f, 0.7f);
                vector1.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test GetHashCode. Check whether GetHashCode returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetHashCode_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var vector1 = new RelativeVector3(0.5f, 0.6f, 0.7f);
            var hash = vector1.GetHashCode();
            Assert.IsNotNull(vector1, "Can't create success object RelativeVector3");
            Assert.IsInstanceOf<RelativeVector3>(vector1, "Should be an instance of RelativeVector3 type.");
            Assert.IsTrue(hash >= Int32.MinValue && hash <= Int32.MaxValue, "The value of hash is out of Integer range");
        }
    }
}
