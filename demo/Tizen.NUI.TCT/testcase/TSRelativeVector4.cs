using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.RelativeVector4 Tests")]
    public class RelativeVector4Tests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("RelativeVector4Tests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali RelativeVector4 constructor test.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.RelativeVector4 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RelativeVector4_INIT()
        {
            /* TEST CODE */
            var vector = new RelativeVector4();
            Assert.IsInstanceOf<RelativeVector4>(vector, "Should return Vector4 instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali RelativeVector4 constructor test.Check whether object which initialized with four singles is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.RelativeVector4 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single,Single,Single,Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RelativeVector4_INIT_WITH_SINGLE_SINGLE_SINGLE_SINGLE()
        {
            /* TEST CODE */
            var vector = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            Assert.IsInstanceOf<RelativeVector4>(vector, "Should return Vector4 instance.");
            Assert.AreEqual(0.5f, vector.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(0.6f, vector.Y, "Retrieved vector.Y should be equal to set value");
            Assert.AreEqual(0.7f, vector.Z, "Retrieved vector.Z should be equal to set value");
            Assert.AreEqual(0.8f, vector.W, "Retrieved vector.W should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("dali RelativeVector4 constructor test.Check whether object which initialized with RelativeVector2 is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.RelativeVector4 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "RelativeVector2")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RelativeVector4_INIT_WITH_RELATIVEVECTOR2()
        {
            /* TEST CODE */
            var vec2 = new RelativeVector2(0.5f, 0.6f);
            RelativeVector4 vector = new RelativeVector4(vec2);
            Assert.IsInstanceOf<RelativeVector4>(vector, "Should return Vector4 instance.");
            Assert.AreEqual(0.5f, vector.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(0.6f, vector.Y, "Retrieved vector.Y should be equal to set value");
            Assert.AreEqual(0.0f, vector.Z, "Retrieved vector.Z should be equal to set value");
            Assert.AreEqual(0.0f, vector.W, "Retrieved vector.W should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("dali RelativeVector4 constructor test.Check whether object which initialized with RelativeVector3 is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.RelativeVector4 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "RelativeVector3")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RelativeVector4_INIT_WITH_RELATIVEVECTOR3()
        {
            /* TEST CODE */
            var vec3 = new RelativeVector3(0.5f, 0.6f, 0.7f);
            RelativeVector4 vector = new RelativeVector4(vec3);
            Assert.IsInstanceOf<RelativeVector4>(vector, "Should return Vector4 instance.");
            Assert.AreEqual(0.5f, vector.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(0.6f, vector.Y, "Retrieved vector.Y should be equal to set value");
            Assert.AreEqual(0.7f, vector.Z, "Retrieved vector.Z should be equal to set value");
            Assert.AreEqual(0.0f, vector.W, "Retrieved vector.W should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test this[uint index]. Check whether this[uint index] returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void this_GET_VALUE()
        {
            /* TEST CODE */
            RelativeVector4 vector = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            Assert.AreEqual(0.5f, vector[0], "this[0] should return 100.0f");
            Assert.AreEqual(0.6f, vector[1], "this[1] should return 200.0f");
            Assert.AreEqual(0.7f, vector[2], "this[2] should return 300.0f");
            Assert.AreEqual(0.8f, vector[3], "this[3] should return 400.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test EqualTo. Try to compare two RelativeVector4 instance by EqualTo.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void EqualTo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector4 vector1 = new RelativeVector4(1.0f, 0.5f, 0.4f, 0.3f);
            RelativeVector4 vector2 = new RelativeVector4(1.0f, 0.5f, 0.4f, 0.3f);
            Assert.IsTrue((vector1.EqualTo(vector2)), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test NotEqualTo. Try to compare two RelativeVector4 instance by NotEqualTo.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void NotEqualTo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector4 vector1 = new RelativeVector4(1.0f, 0.5f, 0.4f, 0.3f);
            RelativeVector4 vector2 = new RelativeVector4(1.0f, 0.5f, 0.6f, 0.7f);
            Assert.IsTrue((vector1.NotEqualTo(vector2)), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test X. Check whether X is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void X_SET_GET_VALUE()
        {
            /* TEST CODE */
            RelativeVector4 v0 = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            v0.X = 0.6f;
            Assert.AreEqual(0.6f, v0.X, "v0.X should be 20.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test Y. Check whether Y is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Y_SET_GET_VALUE()
        {
            /* TEST CODE */
            RelativeVector4 v0 = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            v0.Y = 1.0f;
            Assert.AreEqual(1.0f, v0.Y, "v0.Y should be 20.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test Z. Check whether Z is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.Z A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Z_SET_GET_VALUE()
        {
            /* TEST CODE */
            RelativeVector4 v0 = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            v0.Z = 1.0f;
            Assert.AreEqual(1.0f, v0.Z, "v0.Z should be 1.0f");
        }


        [Test]
        [Category("P1")]
        [Description("Test W. Check whether W is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.W A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void W_SET_GET_VALUE()
        {
            /* TEST CODE */
            RelativeVector4 v0 = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            v0.W = 1.0f;
            Assert.AreEqual(1.0f, v0.W, "v0.W should be 1.0f");
        }


        [Test]
        [Category("P1")]
        [Description("Test Addition.Check whether Addition whose parameter is RelativeVector4 and RelativeVector4 returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.Addition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Addition_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector4 vector1 = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            RelativeVector4 vector2 = new RelativeVector4(0.4f, 0.3f, 0.2f, 0.1f);
            RelativeVector4 vector = vector1 + vector2;
            Assert.Less(Math.Abs(0.9f - vector.X), 0.0001f, "The X of the vector is not correct here!");
            Assert.Less(Math.Abs(0.9f - vector.Y), 0.0001f, "The Y of the vector is not correct here!");
            Assert.Less(Math.Abs(0.9f - vector.Z), 0.0001f, "The Z of the vector is not correct here!");
            Assert.Less(Math.Abs(0.9f - vector.W), 0.0001f, "The W of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Subtraction.Check whether Subtraction whose parameter is RelativeVector4 and RelativeVector4 returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.Subtraction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Subtraction_SET_GET_VALUE_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector4 vector1 = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            RelativeVector4 vector2 = new RelativeVector4(0.4f, 0.3f, 0.2f, 0.1f);
            RelativeVector4 vector = vector1 - vector2;

            Assert.Less(Math.Abs(0.1f - vector.X), 0.0001f, "The X of the vector is not correct here!");
            Assert.Less(Math.Abs(0.3f - vector.Y), 0.0001f, "The Y of the vector is not correct here!");
            Assert.Less(Math.Abs(0.5f - vector.Z), 0.0001f, "The Z of the vector is not correct here!");
            Assert.Less(Math.Abs(0.7f - vector.W), 0.0001f, "The W of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Multiply.Check whether Multiply whose parameter is RelativeVector4 and RelativeVector4 returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "RelativeVector4,RelativeVector4")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Multiply_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector4 vector1 = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            RelativeVector4 vector2 = new RelativeVector4(0.4f, 0.3f, 0.2f, 0.1f);
            RelativeVector4 vector = vector1 * vector2;
            Assert.Less(Math.Abs(0.2f - vector.X), 0.0001f, "The X of the vector is not correct here!");
            Assert.Less(Math.Abs(0.18f - vector.Y), 0.0001f, "The Y of the vector is not correct here!");
            Assert.Less(Math.Abs(0.14f - vector.Z), 0.0001f, "The Z of the vector is not correct here!");
            Assert.Less(Math.Abs(0.08f - vector.W), 0.0001f, "The W of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Multiply.Check whether Multiply whose parameter is Vector4 and Single returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "RelativeVector4,Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Multiply_CHECK_RETURN_VALUE_WITH_VECTOR4_SINGLE()
        {
            /* TEST CODE */
            RelativeVector4 vector1 = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            RelativeVector4 vector = vector1 * 0.5f;

            Assert.Less(Math.Abs(0.25f - vector.X), 0.0001f, "The X of the vector is not correct here!");
            Assert.Less(Math.Abs(0.3f - vector.Y), 0.0001f, "The Y of the vector is not correct here!");
            Assert.Less(Math.Abs(0.35f - vector.Z), 0.0001f, "The Z of the vector is not correct here!");
            Assert.Less(Math.Abs(0.4f - vector.W), 0.0001f, "The W of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Division.Check whether Division whose parameter is Vector4 and Vector4 returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector4,Vector4")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Division_CHECK_RETURN_VALUE_WITH_VECTOR4_VECTOR4()
        {
            /* TEST CODE */
            RelativeVector4 vector1 = new RelativeVector4(0.05f, 0.06f, 0.07f, 0.08f);
            RelativeVector4 vector2 = new RelativeVector4(0.2f, 0.2f, 0.2f, 0.1f);
            RelativeVector4 vector = vector1 / vector2;

            Assert.Less(Math.Abs(0.25f - vector.X), 0.0001f, "The X of the vector is not correct here!");
            Assert.Less(Math.Abs(0.3f - vector.Y), 0.0001f, "The Y of the vector is not correct here!");
            Assert.Less(Math.Abs(0.35f - vector.Z), 0.0001f, "The Z of the vector is not correct here!");
            Assert.Less(Math.Abs(0.8f - vector.W), 0.0001f, "The W of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Division.Check whether Division whose parameter is Vector4 and Single returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector4,Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Division_CHECK_RETURN_VALUE_WITH_VECTOR4_SINGLE()
        {
            /* TEST CODE */
            RelativeVector4 vector1 = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            RelativeVector4 vector = vector1 / 2.0f;

            Assert.Less(Math.Abs(0.25f - vector.X), 0.0001f, "The X of the vector is not correct here!");
            Assert.Less(Math.Abs(0.3f - vector.Y), 0.0001f, "The Y of the vector is not correct here!");
            Assert.Less(Math.Abs(0.35f - vector.Z), 0.0001f, "The Z of the vector is not correct here!");
            Assert.Less(Math.Abs(0.4f - vector.W), 0.0001f, "The W of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Equals. Check whether Equals returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Equals_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector4 vector1 = new RelativeVector4(0.02f, 0.02f, 0.02f, 0.02f);
            RelativeVector4 vector2 = new RelativeVector4(0.02f, 0.02f, 0.02f, 0.02f);

            bool flag = vector1.Equals(vector2);
            Assert.IsTrue(flag, "Should be true here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test implicit vector4. Try to convert a Vector4 instance to a RelativeVector4 instance.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector4")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void implicit_VECTOR4_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector4 vector = new Vector4(0.5f, 0.6f, 0.7f, 0.8f);
            RelativeVector4 relativeVector4 = vector;
            Assert.AreEqual(relativeVector4.X, vector.X, "The value of X is not correct.");
            Assert.AreEqual(relativeVector4.Y, vector.Y, "The value of Y is not correct.");
            Assert.AreEqual(relativeVector4.Z, vector.Z, "The value of Z is not correct.");
            Assert.AreEqual(relativeVector4.W, vector.W, "The value of W is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test implicit RelativeVector4. Try to convert a position instance to a vector4 instance.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "RelativeVector4")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void implicit_RelativeVector4_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector4 relativeVector4 = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            Vector4 vector = relativeVector4;
            Assert.AreEqual(relativeVector4.X, vector.X, "The value of X is not correct.");
            Assert.AreEqual(relativeVector4.Y, vector.Y, "The value of Y is not correct.");
            Assert.AreEqual(relativeVector4.Z, vector.Z, "The value of Z is not correct.");
            Assert.AreEqual(relativeVector4.W, vector.W, "The value of W is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Vector4.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                RelativeVector4 vector1 = new RelativeVector4(10.0f, 20.0f, 30.0f, 40.0f);
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
        [Property("SPEC", "Tizen.NUI.RelativeVector4.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetHashCode_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var vector1 = new RelativeVector4(10.0f, 20.0f, 30.0f, 40.0f);
            var hash = vector1.GetHashCode();
            Assert.IsNotNull(vector1, "Can't create success object RelativeVector4");
            Assert.IsInstanceOf<RelativeVector4>(vector1, "Should be an instance of RelativeVector4 type.");
            Assert.IsTrue(hash >= Int32.MinValue && hash <= Int32.MaxValue, "The value of hash is out of Integer range");
        }
    }
}
