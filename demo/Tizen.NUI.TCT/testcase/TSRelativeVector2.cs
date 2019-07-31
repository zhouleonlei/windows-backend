using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.RelativeVector2 Tests")]
    public class RelativeVector2Tests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("RelativeVector2Tests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali RelativeVector2 constructor test.Check whether RelativeVector2 object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.RelativeVector2 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RelativeVector2_INIT()
        {
            /* TEST CODE */
            var vector2 = new RelativeVector2();
            Assert.IsInstanceOf<RelativeVector2>(vector2, "Should return RelativeVector2 instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali RelativeVector2 constructor test.Check whether RelativeVector2 object which initialized with two singles is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.RelativeVector2 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RelativeVector2_INIT_WITH_SINGLE_SINGLE()
        {
            /* TEST CODE */
            var vector2 = new RelativeVector2(0.5f, 0.6f);
            Assert.IsInstanceOf<RelativeVector2>(vector2, "Should return Vector2 instance.");
            Assert.AreEqual(0.5f, vector2.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(0.6f, vector2.Y, "Retrieved vector.Y should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("dali RelativeVector2 constructor test.Check whether RelativeVector2 object which initialized with RelativeVector3 is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.RelativeVector2 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "RelativeVector3")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RelativeVector2_INIT_WITH_RELATIVEVECTOR3()
        {
            /* TEST CODE */
            RelativeVector3 vec3 = new RelativeVector3(0.5f, 0.6f, 0.7f);
            var vector2 = new RelativeVector2(vec3);
            Assert.IsInstanceOf<RelativeVector2>(vector2, "Should return RelativeVector2 instance.");
            Assert.AreEqual(0.5f, vector2.X, "Retrieved vector2.X should be equal to set value");
            Assert.AreEqual(0.6f, vector2.Y, "Retrieved vector2.Y should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("dali RelativeVector2 constructor test. Check whether RelativeVector2 object which initialized with RelativeVector4 is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.RelativeVector2 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "RelativeVector4")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RelativeVector2_INIT_WITH_RELATIVEVECTOR4()
        {
            /* TEST CODE */
            RelativeVector4 vec4 = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            var vector2 = new RelativeVector2(vec4);
            Assert.IsInstanceOf<RelativeVector2>(vector2, "Should return RelativeVector2 instance.");
            Assert.AreEqual(0.5f, vector2.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(0.6f, vector2.Y, "Retrieved vector.Y should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test this[uint index]. Check whether this[uint index] returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void this_GET_VALUE()
        {
            /* TEST CODE */
            RelativeVector2 vector2 = new RelativeVector2(1.0f, 0.5f);
            Assert.AreEqual(1.0f, vector2[0], "The value of index[0] is not correct!");
            Assert.AreEqual(0.5f, vector2[1], "The value of index[1] is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test EqualTo. Try to compare two RelativeVector2 instance by EqualTo.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void EqualTo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector2 vector1 = new RelativeVector2(1.0f, 0.5f);
            RelativeVector2 vector2 = new RelativeVector2(1.0f, 0.5f);
            Assert.IsTrue((vector1.EqualTo(vector2)), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test NotEqualTo. Try to compare two RelativeVector2 instance by NotEqualTo.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void NotEqualTo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector2 vector1 = new RelativeVector2(1.0f, 0.5f);
            RelativeVector2 vector2 = new RelativeVector2(1.0f, 0.6f);
            Assert.IsTrue((vector1.NotEqualTo(vector2)), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test X. Check whether X is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void X_GET_VALUE()
        {
            /* TEST CODE */
            RelativeVector2 v0 = new RelativeVector2(1.0f, 0.5f);
            Assert.AreEqual(1.0f, v0.X, "The X of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Y. Check whether Y is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Y_GET_VALUE()
        {
            /* TEST CODE */
            RelativeVector2 v0 = new RelativeVector2(1.0f, 0.5f);
            Assert.AreEqual(0.5f, v0.Y, "The Y of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator +.Check whether Addition(RelativeVector2 + RelativeVector2) returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.Addition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Addition_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector2 vector1 = new RelativeVector2(0.5f, 0.6f);
            RelativeVector2 vector2 = new RelativeVector2(0.4f, 0.2f);
            RelativeVector2 vector = vector1 + vector2;
            Assert.AreEqual(0.9f, vector.X, "The X of the vector is not correct here!");
            Assert.AreEqual(0.8f, vector.Y, "The Y of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator -.Check whether Subtraction(RelativeVector2 - RelativeVector2) returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.Subtraction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Subtraction_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector2 vector1 = new RelativeVector2(1.0f, 0.8f);
            RelativeVector2 vector2 = new RelativeVector2(1.0f, 0.6f);
            RelativeVector2 vector = vector1 - vector2;
            Assert.AreEqual(0.0f, vector.X, "The X of the vector is not correct here!");
            Assert.Less(Math.Abs(0.2f - vector.Y), 0.0001f, "The Y of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator *.Check whether Multiply(RelativeVector2 * RelativeVector2) returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2, Vector2")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Multiply_CHECK_RETURN_VALUE_WITH_VECTOR2_VECTOR2()
        {
            /* TEST CODE */
            RelativeVector2 vector1 = new RelativeVector2(0.5f, 0.4f);
            RelativeVector2 vector2 = new RelativeVector2(1.0f, 0.0f);
            RelativeVector2 vector = vector1 * vector2;
            Assert.AreEqual(0.5f, vector.X, "The X of the vector is not correct here!");
            Assert.AreEqual(0.0f, vector.Y, "The Y of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator *.Check whether Multiply(RelativeVector2 - RelativeVector2) returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Multiply_CHECK_RETURN_VALUE_WITH_VECTOR2_SINGLE()
        {
            /* TEST CODE */
            RelativeVector2 vector1 = new RelativeVector2(0.02f, 0.04f);
            RelativeVector2 vector = vector1 * 10.0f;
            Assert.Less(Math.Abs(0.2f - vector.X), 0.0001f, "The X of the vector is not correct here!");
            Assert.Less(Math.Abs(0.4f - vector.Y), 0.0001f, "The Y of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator /.Check whether Division(RelativeVector2 / RelativeVector2) returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "RelativeVector2, RelativeVector2")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Division_CHECK_RETURN_VALUE_WITH_VECTOR2_VECTOR2()
        {
            /* TEST CODE */
            RelativeVector2 vector1 = new RelativeVector2(0.5f, 0.04f);
            RelativeVector2 vector2 = new RelativeVector2(1.0f, 0.5f);
            RelativeVector2 vector = vector1 / vector2;
            Assert.AreEqual(0.5f, vector.X, "The X of the vector is not correct here!");
            Assert.AreEqual(0.08f, vector.Y, "The Y of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator /.Check whether Division(RelativeVector2 / Single) returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "RelativeVector2, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Division_CHECK_RETURN_VALUE_WITH_vECTOR2_SINGLE()
        {
            /* TEST CODE */
            RelativeVector2 vector1 = new RelativeVector2(0.02f, 0.02f);
            RelativeVector2 vector = vector1 / 0.5f;
            Assert.AreEqual(0.04f, vector.X, "The X of the vector is not correct here!");
            Assert.AreEqual(0.04f, vector.Y, "The Y of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Equals. Check whether Equals returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Equals_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector2 vector1 = new RelativeVector2(0.02f, 0.02f);
            RelativeVector2 vector2 = new RelativeVector2(0.02f, 0.02f);

            bool flag = vector1.Equals(vector2);
            Assert.IsTrue(flag, "Should be true here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test implicit vector2. Try to convert a vector2 instance to a RelativeVector2 instance.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void implicit_VECTOR2_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector2 vector = new Vector2(1.0f, 0.5f);
            RelativeVector2 relativeVector2 = vector;
            Assert.AreEqual(relativeVector2.X, vector.X, "The value of X is not correct.");
            Assert.AreEqual(relativeVector2.Y, vector.Y, "The value of Y is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test implicit RelativeVector2. Try to convert a RelativeVector2 instance to a vector2 instance.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "RelativeVector2")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void implicit_POSITION2D_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            RelativeVector2 relativeVector2 = new RelativeVector2(1.0f, 0.5f);
            Vector2 vector = relativeVector2;
            Assert.AreEqual(relativeVector2.X, vector.X, "The value of X is not correct.");
            Assert.AreEqual(relativeVector2.Y, vector.Y, "The value of Y is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Vector2.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                RelativeVector2 vector1 = new RelativeVector2(1.0f, 0.0f);
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
        [Property("SPEC", "Tizen.NUI.RelativeVector2.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetHashCode_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var vector1 = new RelativeVector2(1.0f, 0.0f);
            var hash = vector1.GetHashCode();
            Assert.IsNotNull(vector1, "Can't create success object RelativeVector2");
            Assert.IsInstanceOf<RelativeVector2>(vector1, "Should be an instance of RelativeVector2 type.");
            Assert.IsTrue(hash >= Int32.MinValue && hash <= Int32.MaxValue, "The value of hash is out of Integer range");
        }
    }
}
