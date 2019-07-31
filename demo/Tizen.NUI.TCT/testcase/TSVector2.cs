using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.Vector2 Tests")]
    public class Vector2Tests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("Vector2Tests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali Vector2 constructor test.Check whether Vector2 object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Vector2 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Vector2_INIT()
        {
            /* TEST CODE */
            var vector2 = new Vector2();
            Assert.IsInstanceOf<Vector2>(vector2, "Should return Vector2 instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali Vector2 constructor test.Check whether Vector2 object which initialized with two singles is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Vector2 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Vector2_INIT_WITH_SINGLE_SINGLE()
        {
            /* TEST CODE */
            var vector2 = new Vector2(100.0f, 200.0f);
            Assert.IsInstanceOf<Vector2>(vector2, "Should return Vector2 instance.");
            Assert.AreEqual(100.0f, vector2.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(200.0f, vector2.Y, "Retrieved vector.Y should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("dali Vector2 constructor test.Check whether Vector2 object which initialized with single array is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Vector2 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single[]")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Vector2_INIT_WITH_SINLE_ARRAY()
        {
            /* TEST CODE */
            float[] array = new float[2] { 100.0f, 200.0f };
            var vector2 = new Vector2(array);
            Assert.IsInstanceOf<Vector2>(vector2, "Should return Vector2 instance.");
            Assert.AreEqual(100.0f, vector2.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(200.0f, vector2.Y, "Retrieved vector.Y should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("dali Vector2 constructor test.Check whether Vector2 object which initialized with Vector3 is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Vector2 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Vector3")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Vector2_INIT_WITH_VECTOR3()
        {
            /* TEST CODE */
            Vector3 vec3 = new Vector3(100.0f, 200.0f, 300.0f);
            var vector2 = new Vector2(vec3);
            Assert.IsInstanceOf<Vector2>(vector2, "Should return Vector2 instance.");
            Assert.AreEqual(100.0f, vector2.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(200.0f, vector2.Y, "Retrieved vector.Y should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("dali Vector2 constructor test.Check whether Vector2 object which initialized with Vector4 is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Vector2 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Vector4")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Vector2_INIT_WITH_VECTOR4()
        {
            /* TEST CODE */
            Vector4 vec4 = new Vector4(100.0f, 200.0f, 300.0f, 400.0f);
            var vector2 = new Vector2(vec4);
            Assert.IsInstanceOf<Vector2>(vector2, "Should return Vector2 instance.");
            Assert.AreEqual(100.0f, vector2.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(200.0f, vector2.Y, "Retrieved vector.Y should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test this[uint index]. Check whether this[uint index] returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void this_GET_VALUE()
        {
            /* TEST CODE */
            Vector2 vector2 = new Vector2(100.0f, 200.0f);
            Assert.AreEqual(100.0f, vector2[0], "The value of index[0] is not correct!");
            Assert.AreEqual(200.0f, vector2[1], "The value of index[1] is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test One. Check whether One returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.One A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void One_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(1.0f, Vector2.One.X, "The value of Vector2.One.X is not correct!");
            Assert.AreEqual(1.0f, Vector2.One.Y, "The value of Vector2.One.Y is not correct!");
        }


        [Test]
        [Category("P1")]
        [Description("Test XAxis. Check whether XAxis returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.XAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void XAxis_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(1.0f, Vector2.XAxis.X, "The value of Vector2.XAxis.Y is not correct!");
            Assert.AreEqual(0.0f, Vector2.XAxis.Y, "The value of Vector2.XAxis.Y is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test YAxis. Check whether YAxis returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.YAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void YAxis_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Vector2.YAxis.X, "The value of Vector2.YAxis.X is not correct!");
            Assert.AreEqual(1.0f, Vector2.YAxis.Y, "The value of Vector2.YAxis.Y is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test NegativeXAxis. Check whether NegativeXAxis returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.NegativeXAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void NegativeXAxis_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(-1.0f, Vector2.NegativeXAxis.X, "The value of Vector2.NegativeXAxis.X is not correct!");
            Assert.AreEqual(0.0f, Vector2.NegativeXAxis.Y, "The value of Vector2.NegativeXAxis.Y is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test NegativeYAxis. Check whether NegativeYAxis returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.NegativeYAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void NegativeYAxis_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Vector2.NegativeYAxis.X, "The value of Vector2.NegativeYAxis.X is not correct!");
            Assert.AreEqual(-1.0f, Vector2.NegativeYAxis.Y, "The value of Vector2.NegativeYAxis.Y is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Zero. Check whether Zero returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Zero A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Zero_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Vector2.Zero.X, "The value of Vector2.Zero.X is not correct!");
            Assert.AreEqual(0.0f, Vector2.Zero.Y, "The value of Vector2.Zero.Y is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Length.Check whether Length returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Length M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Length_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector2 vector = new Vector2(0.0f, 0.0f);
            Assert.AreEqual(0.0f, vector.Length(), "The length of vector should be zero!");
            Vector2 vector2 = new Vector2(1.0f, 2.0f);
            Assert.AreEqual((float)Math.Sqrt(5.0f), vector2.Length(), "The length of vector2 is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test LengthSquared.Check whether LengthSquared returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.LengthSquared M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void LengthSquared_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector2 vector = new Vector2(0.0f, 0.0f);
            Assert.AreEqual(0.0f, vector.LengthSquared(), "The length of vector is not correct!");
            Vector2 vector2 = new Vector2(1.0f, 2.0f);
            Assert.AreEqual(5.0f, vector2.LengthSquared(), "The length of vector2 is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Normalize.Check whether Normalize change state of vector4 expected")]
        [Property("SPEC", "Tizen.NUI.Vector2.Normalize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Normalize_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                Vector2 vector2 = new Vector2((float)Math.Cosh(0.0f) * 10.0f, (float)Math.Cosh(1.0f) * 10.0f);
                vector2.Normalize();
                Assert.Less(Math.Abs(1.0f - vector2.LengthSquared()), 0.001f, "The value of LengthSquared is wrong");
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
        [Description("Test Clamp.Check whether Clamp change state of vector4 expected")]
        [Property("SPEC", "Tizen.NUI.Vector2.Clamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Clamp_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                Vector2 min = new Vector2(1.0f, 4.0f);
                Vector2 max = new Vector2(9.0f, 6.0f);
                Vector2 v0 = new Vector2(2.0f, 0.8f);
                v0.Clamp(min, max);
                Assert.AreEqual(2.0f, v0.X, "2.0 > 1.0(min) && 2.0 < 9.0(max), so the value should be 2.0f");
                Assert.AreEqual(4.0f, v0.Y, "0.8 < 4.0(min), so the value should be 4.0f");
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
        [Description("Test Width. Check whether Width is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Width A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Width_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector2 v0 = new Vector2(20.0f, 30.0f);
            Assert.AreEqual(20.0f, v0.Width, "The Width of the vector is not correct here!");
            v0.Width = 100.0f;
            Assert.AreEqual(100.0f, v0.Width, "The Width of the vector is not correct.");
        }


        [Test]
        [Category("P1")]
        [Description("Test Height. Check whether Height is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Height A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Height_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector2 v0 = new Vector2(30.0f, 20.0f);
            Assert.AreEqual(20.0f, v0.Height, "The Height of the vector is not correct here!");
            v0.Height = 100.0f;
            Assert.AreEqual(100.0f, v0.Height, "The Height of the vector is not correct.");
        }
        [Test]
        [Category("P1")]
        [Description("Test X. Check whether X is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector2.X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void X_GET_VALUE()
        {
            /* TEST CODE */
            Vector2 v0 = new Vector2(20.0f,30.0f);
            Assert.AreEqual(20.0f, v0.X, "The X of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Y. Check whether Y is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Y_GET_VALUE()
        {
            /* TEST CODE */
            Vector2 v0 = new Vector2(30.0f, 20.0f);
            Assert.AreEqual(20.0f, v0.Y, "The Y of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator +.Check whether Addition(Vector2 + Vector2) returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Addition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Addition_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector2 vector1 = new Vector2(0.0f, 2.0f);
            Vector2 vector2 = new Vector2(1.0f, 2.0f);
            Vector2 vector = vector1 + vector2;
            Assert.AreEqual(1.0f, vector.X, "The X of the vector is not correct here!");
            Assert.AreEqual(4.0f, vector.Y, "The Y of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator -.Check whether Subtraction(Vector2 - Vector2) returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Subtraction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Subtraction_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector2 vector1 = new Vector2(10.0f, 20.0f);
            Vector2 vector2 = new Vector2(1.0f, 2.0f);
            Vector2 vector = vector1 - vector2;
            Assert.AreEqual(9.0f, vector.X, "The X of the vector is not correct here!");
            Assert.AreEqual(18.0f, vector.Y, "The Y of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator -.Check whether UnaryNegation(-Vector2) returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.UnaryNegation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void UnaryNegation_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector2 vector1 = new Vector2(10.0f, 20.0f);
            Vector2 vector = -vector1;
            Assert.AreEqual(-10.0f, vector.X, "The X of the vector is not correct here!");
            Assert.AreEqual(-20.0f, vector.Y, "The Y of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator *.Check whether Multiply(Vector2 * Vector2) returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2, Vector2")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Multiply_CHECK_RETURN_VALUE_WITH_VECTOR2_VECTOR2()
        {
            /* TEST CODE */
            Vector2 vector1 = new Vector2(10.0f, 20.0f);
            Vector2 vector2 = new Vector2(1.0f, 2.0f);
            Vector2 vector = vector1 * vector2;
            Assert.AreEqual(10.0f, vector.X, "The X of the vector is not correct here!");
            Assert.AreEqual(40.0f, vector.Y, "The Y of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator *.Check whether Multiply(Vector2 - Vector2) returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Multiply_CHECK_RETURN_VALUE_WITH_VECTOR2_SINGLE()
        {
            /* TEST CODE */
            Vector2 vector1 = new Vector2(10.0f, 20.0f);
            Vector2 vector = vector1 * 10.0f;
            Assert.AreEqual(100.0f, vector.X, "The X of the vector is not correct here!");
            Assert.AreEqual(200.0f, vector.Y, "The Y of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator /.Check whether Division(Vector2 / Vector2) returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2, Vector2")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Division_CHECK_RETURN_VALUE_WITH_VECTOR2_VECTOR2()
        {
            /* TEST CODE */
            Vector2 vector1 = new Vector2(10.0f, 20.0f);
            Vector2 vector2 = new Vector2(1.0f, 2.0f);
            Vector2 vector = vector1 / vector2;
            Assert.AreEqual(10.0f, vector.X, "The X of the vector is not correct here!");
            Assert.AreEqual(10.0f, vector.Y, "The Y of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator /.Check whether Division(Vector2 - Single) returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Division_CHECK_RETURN_VALUE_WITH_vECTOR2_SINGLE()
        {
            /* TEST CODE */
            Vector2 vector1 = new Vector2(10.0f, 20.0f);
            Vector2 vector = vector1 / 10.0f;
            Assert.AreEqual(1.0f, vector.X, "The X of the vector is not correct here!");
            Assert.AreEqual(2.0f, vector.Y, "The Y of the vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Equals. Check whether Equals returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Equals_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector2 vector1 = new Vector2(1.0f, 1.0f);
            Vector2 vector2 = new Vector2(1.0f, 1.0f);

            bool flag = vector1.Equals(vector2);
            Assert.IsTrue(flag, "Should be true here!");
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
                Vector2 vector1 = new Vector2(10.0f, 20.0f);
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
        [Property("SPEC", "Tizen.NUI.Vector2.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetHashCode_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var vector = new Vector2(10.0f, 20.0f);
            var hash = vector.GetHashCode();
            Assert.IsNotNull(vector, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(vector, "Should be an instance of Vector2 type.");
            Assert.IsTrue(hash >= Int32.MinValue && hash <= Int32.MaxValue, "The value of hash is out of Integer range");
        }
    }
}
