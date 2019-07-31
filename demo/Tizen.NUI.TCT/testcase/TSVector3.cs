using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.Vector3 Tests")]
    public class Vector3Tests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("Vector3Tests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali Vector3 constructor test.Check whether Vector3 object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Vector3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Vector3_INIT()
        {
            /* TEST CODE */
            var vector = new Vector3();
            Assert.IsInstanceOf<Vector3>(vector, "Should return Vector3 instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali Vector3 constructor test.Check whether Vector3 object which initialized with three singles is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Vector3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single, Single, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Vector3_INIT_WITH_SINGLE_SINGLE_SINGLE()
        {
            /* TEST CODE */
            var vector = new Vector3(100.0f, 200.0f, 300.0f);
            Assert.IsInstanceOf<Vector3>(vector, "Should return Vector3 instance.");
            Assert.AreEqual(100.0f, vector.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(200.0f, vector.Y, "Retrieved vector.Y should be equal to set value");
            Assert.AreEqual(300.0f, vector.Z, "Retrieved vector.Z should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("dali Vector3 constructor test.Check whether Vector3 object which initialized with single array is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Vector3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single[]")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Vector3_INIT_WITH_SINGLE_ARRAY()
        {
            /* TEST CODE */
            float[] array = new float[3] { 100.0f, 200.0f, 300.0f };

            var vector = new Vector3(array);
            Assert.IsInstanceOf<Vector3>(vector, "Should return Vector3 instance.");
            Assert.AreEqual(100.0f, vector.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(200.0f, vector.Y, "Retrieved vector.Y should be equal to set value");
            Assert.AreEqual(300.0f, vector.Z, "Retrieved vector.Z should be equal to set value");

        }

        [Test]
        [Category("P1")]
        [Description("dali Vector3 constructor test.Check whether Vector2 object which initialized with Vector2 is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Vector3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Vector2")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Vector3_INIT_WITH_VECTOR2()
        {
            /* TEST CODE */
            Vector2 vec2 = new Vector2(100.0f, 200.0f);

            var vector = new Vector3(vec2);
            Assert.IsInstanceOf<Vector3>(vector, "Should return Vector3 instance.");
            Assert.AreEqual(100.0f, vector.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(200.0f, vector.Y, "Retrieved vector.Y should be equal to set value");
            Assert.AreEqual(0.0f, vector.Z, "Retrieved vector.Z should be equal to set value");

        }

        [Test]
        [Category("P1")]
        [Description("dali Vector3 constructor test.Check whether Vector2 object which initialized with Vector4 is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Vector3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Vector4")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Vector3_INIT_WITH_VECTOR4()
        {
            /* TEST CODE */
            Vector4 vec4 = new Vector4(100.0f, 200.0f, 300.0f, 400.0f);
            var vector = new Vector3(vec4);
            Assert.IsInstanceOf<Vector3>(vector, "Should return Vector3 instance.");
            Assert.AreEqual(100.0f, vector.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(200.0f, vector.Y, "Retrieved vector.Y should be equal to set value");
            Assert.AreEqual(300.0f, vector.Z, "Retrieved vector.Z should be equal to set value");

        }

        [Test]
        [Category("P1")]
        [Description("Test this[uint index]. Check whether this[uint index] returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector3.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void this_GET_VALUE()
        {
            /* TEST CODE */
            Vector3 vector = new Vector3(100.0f, 200.0f, 300.0f);
            Assert.AreEqual(100.0f, vector[0], "The value of index[0] is not correct!");
            Assert.AreEqual(200.0f, vector[1], "The value of index[1] is not correct!");
            Assert.AreEqual(300.0f, vector[2], "The value of index[2] is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test One. Check whether One returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector3.One A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void One_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(1.0f, Vector3.One.X, "The value of Vector3.One.X is not correct!");
            Assert.AreEqual(1.0f, Vector3.One.Y, "The value of Vector3.One.Y is not correct!");
            Assert.AreEqual(1.0f, Vector3.One.Z, "The value of Vector3.One.Z is not correct!");
        }


        [Test]
        [Category("P1")]
        [Description("Test XAxis. Check whether XAxis returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector3.XAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void XAxis_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(1.0f, Vector3.XAxis.X, "The value of Vector3.XAxis.X is not correct!");
            Assert.AreEqual(0.0f, Vector3.XAxis.Y, "The value of Vector3.XAxis.Y is not correct!");
            Assert.AreEqual(0.0f, Vector3.XAxis.Z, "The value of Vector3.XAxis.Z is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test YAxis. Check whether YAxis returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector3.YAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void YAxis_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Vector3.YAxis.X, "The value of Vector3.YAxis.X is not correct!");
            Assert.AreEqual(1.0f, Vector3.YAxis.Y, "The value of Vector3.YAxis.Y is not correct!");
            Assert.AreEqual(0.0f, Vector3.YAxis.Z, "The value of Vector3.YAxis.Z is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test ZAxis. Check whether ZAxis returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector3.ZAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ZAxis_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Vector3.ZAxis.X, "The value of Vector3.ZAxis.X is not correct!");
            Assert.AreEqual(0.0f, Vector3.ZAxis.Y, "The value of Vector3.ZAxis.Y is not correct!");
            Assert.AreEqual(1.0f, Vector3.ZAxis.Z, "The value of Vector3.ZAxis.Z is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test NegativeXAxis. Check whether NegativeXAxis returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector3.NegativeXAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void NegativeXAxis_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(-1.0f, Vector3.NegativeXAxis.X, "The value of Vector3.NegativeXAxis.X is not correct!");
            Assert.AreEqual(0.0f, Vector3.NegativeXAxis.Y, "The value of Vector3.NegativeXAxis.Y is not correct!");
            Assert.AreEqual(0.0f, Vector3.NegativeXAxis.Z, "The value of Vector3.NegativeXAxis.Z is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test NegativeYAxis. Check whether NegativeYAxis returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector3.NegativeYAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void NegativeYAxis_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Vector3.NegativeYAxis.X, "The value of Vector3.NegativeYAxis.X is not correct!");
            Assert.AreEqual(-1.0f, Vector3.NegativeYAxis.Y, "The value of Vector3.NegativeYAxis.Y is not correct!");
            Assert.AreEqual(0.0f, Vector3.NegativeYAxis.Z, "The value of Vector3.NegativeYAxis.Z is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test NegativeZAxis. Check whether NegativeZAxis returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector3.NegativeZAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void NegativeZAxis_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Vector3.NegativeZAxis.X, "The value of Vector3.NegativeZAxis.X is not correct!");
            Assert.AreEqual(0.0f, Vector3.NegativeZAxis.Y, "The value of Vector3.NegativeZAxis.Y is not correct!");
            Assert.AreEqual(-1.0f, Vector3.NegativeZAxis.Z, "The value of Vector3.NegativeZAxis.Z is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Zero. Check whether Zero returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Zero A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Zero_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Vector3.Zero.X, "The value of Vector3.Zero.X is not correct!");
            Assert.AreEqual(0.0f, Vector3.Zero.Y, "The value of Vector3.Zero.Y is not correct!");
            Assert.AreEqual(0.0f, Vector3.Zero.Z, "The value of Vector3.Zero.Z is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Length.Check whether Length returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Length M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Length_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector3 vector = new Vector3(0.0f, 0.0f, 0.0f);
            Assert.AreEqual(0.0f, vector.Length(), "The length of vector is not correct!");
            Vector3 vector3 = new Vector3(1.0f, 2.0f, 3.0f);
            Assert.AreEqual((float)Math.Sqrt(14.0f), vector3.Length(), "The length of vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test LengthSquared.Check whether LengthSquared returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector3.LengthSquared M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void LengthSquared_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector3 vector = new Vector3(0.0f, 0.0f, 0.0f);
            Assert.AreEqual(0.0f, vector.LengthSquared(), "The length of vector is not correct!");
            Vector3 vector3 = new Vector3(1.0f, 2.0f, 3.0f);
            Assert.AreEqual(14.0f, vector3.LengthSquared(), "The length of vector is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Normalize.Check whether Normalize returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Normalize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Normalize_CHECK_STATE()
        {
            /* TEST CODE */
            Vector3 vector3 = new Vector3((float)Math.Cosh(0.0f) * 10.0f, (float)Math.Cosh(1.0f) * 10.0f, (float)Math.Cosh(2.0f) * 10.0f);
            vector3.Normalize();
            Assert.Less(Math.Abs(1.0f - vector3.LengthSquared()), 0.001f, "The value of LengthSquared is wrong");
            Vector3 vector = new Vector3(0.0f, 0.0f, 0.0f);
            vector.Normalize();
            Assert.Less(Math.Abs(0.0f - vector.LengthSquared()), 0.00001f, "Should be return 0.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test Clamp.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Clamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Clamp_CHECK_STATE()
        {
            /* TEST CODE */
            Vector3 min = new Vector3(1.0f, 4.0f, 0.0f);
            Vector3 max = new Vector3(9.0f, 6.0f, 6.0f);
            Vector3 v0 = new Vector3(2.0f, 0.8f, 8.0f);
            v0.Clamp(min, max);
            Assert.AreEqual(2.0f, v0.X, "2.0 > 1.0(min) && 2.0 < 9.0(max), so the value should be 2.0f");
            Assert.AreEqual(4.0f, v0.Y, "0.8 < 4.0(min), so the value should be 4.0f");
            Assert.AreEqual(6.0f, v0.Z, "8.0 > 6.0(max), so the value should be 6.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetVectorXY.Check whether GetVectorXY returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector3.GetVectorXY M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetVectorXY_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector3 v0 = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.AreEqual(10.0f, v0.GetVectorXY().X, "The X value of the vector is not correct!");
            Assert.AreEqual(20.0f, v0.GetVectorXY().Y, "The Y value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetVectorYZ.Check whether GetVectorYZ returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector3.GetVectorYZ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetVectorYZ_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector3 v0 = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.AreEqual(30.0f, v0.GetVectorYZ().Y, "The Y value of the vector is not correct!");
            Assert.AreEqual(20.0f, v0.GetVectorYZ().X, "The X value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Width. Check whether Width is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Width A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Width_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector3 v0 = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.AreEqual(10.0f, v0.Width, "The Width value of the vector is not correct!");
            v0.Width = 100.0f;
            Assert.AreEqual(100.0f, v0.Width, "The Width value of the vector is not correct here.");
        }


        [Test]
        [Category("P1")]
        [Description("Test Height. Check whether Height is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Height A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Height_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector3 v0 = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.AreEqual(20.0f, v0.Height, "The Height value of the vector is not correct!");
            v0.Height = 100.0f;
            Assert.AreEqual(100.0f, v0.Height, "The Height value of the vector is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Depth. Check whether Depth is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Depth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Depth_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector3 v0 = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.AreEqual(30.0f, v0.Depth, "The Depth value of the vector is not correct!");
            v0.Depth = 100.0f;
            Assert.AreEqual(100.0f, v0.Depth, "The Depth value of the vector is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test R. Check whether R is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector3.R A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void R_GET_VALUE()
        {
            /* TEST CODE */
            Vector3 v0 = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.AreEqual(10.0f, v0.R, "The R value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test G. Check whether G is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector3.G A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void G_GET_VALUE()
        {
            /* TEST CODE */
            Vector3 v0 = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.AreEqual(20.0f, v0.G, "The G value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test B. Check whether B is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector3.B A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void B_GET_VALUE()
        {
            /* TEST CODE */
            Vector3 v0 = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.AreEqual(30.0f, v0.B, "The B value of the vector is not correct!");
        }
        [Test]
        [Category("P1")]
        [Description("Test X. Check whether X is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector3.X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void X_GET_VALUE()
        {
            /* TEST CODE */
            Vector3 v0 = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.AreEqual(10.0f, v0.X, "The X value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Y. Check whether Y is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Y_GET_VALUE()
        {
            /* TEST CODE */
            Vector3 v0 = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.AreEqual(20.0f, v0.Y, "The Y value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Z. Check whether Z is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Z A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Z_GET_VALUE()
        {
            /* TEST CODE */
            Vector3 v0 = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.AreEqual(30.0f, v0.Z, "The Z value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator +.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Addition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Addition_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector3 vector1 = new Vector3(10.0f, 20.0f, 30.0f);
            Vector3 vector2 = new Vector3(1.0f, 2.0f, 3.0f);
            Vector3 vector = vector1 + vector2;
            Assert.AreEqual(11.0f, vector.X, "The X value of the vector is not correct!");
            Assert.AreEqual(22.0f, vector.Y, "The Y value of the vector is not correct!");
            Assert.AreEqual(33.0f, vector.Z, "The Z value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator -.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Subtraction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Subtraction_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector3 vector1 = new Vector3(10.0f, 20.0f, 30.0f);
            Vector3 vector2 = new Vector3(1.0f, 2.0f, 3.0f);
            Vector3 vector = vector1 - vector2;
            Assert.AreEqual(9.0f, vector.X, "The X value of the vector is not correct!");
            Assert.AreEqual(18.0f, vector.Y, "The Y value of the vector is not correct!");
            Assert.AreEqual(27.0f, vector.Z, "The Z value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator -.")]
        [Property("SPEC", "Tizen.NUI.Vector3.UnaryNegation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void UnaryNegation_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector3 vector1 = new Vector3(10.0f, 20.0f, 30.0f);
            Vector3 vector = -vector1;
            Assert.AreEqual(-10.0f, vector.X, "The X value of the vector is not correct!");
            Assert.AreEqual(-20.0f, vector.Y, "The Y value of the vector is not correct!");
            Assert.AreEqual(-30.0f, vector.Z, "The Z value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator *.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector3, Vector3")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Multiply_VECTOR3_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector3 vector1 = new Vector3(10.0f, 20.0f, 30.0f);
            Vector3 vector2 = new Vector3(1.0f, 2.0f, 3.0f);
            Vector3 vector = vector1 * vector2;
            Assert.AreEqual(10.0f, vector.X, "The X value of the vector is not correct!");
            Assert.AreEqual(40.0f, vector.Y, "The Y value of the vector is not correct!");
            Assert.AreEqual(90.0f, vector.Z, "The Z value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator *.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector3, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Multiply_FLOAT_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector3 vector1 = new Vector3(10.0f, 20.0f, 30.0f);
            Vector3 vector = vector1 * 10.0f;
            Assert.AreEqual(100.0f, vector.X, "The X value of the vector is not correct!");
            Assert.AreEqual(200.0f, vector.Y, "The Y value of the vector is not correct!");
            Assert.AreEqual(300.0f, vector.Z, "The Z value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator /.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector3, Vector3")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Division_VECTOR3_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector3 vector1 = new Vector3(10.0f, 20.0f, 30.0f);
            Vector3 vector2 = new Vector3(1.0f, 2.0f, 3.0f);
            Vector3 vector = vector1 / vector2;
            Assert.AreEqual(10.0f, vector.X, "The X value of the vector is not correct!");
            Assert.AreEqual(10.0f, vector.Y, "The Y value of the vector is not correct!");
            Assert.AreEqual(10.0f, vector.Z, "The Z value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator /.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector3, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Division_FLOAT_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector3 vector1 = new Vector3(10.0f, 20.0f, 30.0f);
            Vector3 vector = vector1 / 10.0f;
            Assert.AreEqual(1.0f, vector.X, "The X value of the vector is not correct!");
            Assert.AreEqual(2.0f, vector.Y, "The Y value of the vector is not correct!");
            Assert.AreEqual(3.0f, vector.Z, "The Z value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Equals. Check whether Equals returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Equals_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector3 vector1 = new Vector3(1.0f, 1.0f, 1.0f);
            Vector3 vector2 = new Vector3(1.0f, 1.0f, 1.0f);

            bool flag = vector1.Equals(vector2);
            Assert.IsTrue(flag, "Should be true here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Vector3.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                Vector3 vector1 = new Vector3(10.0f, 20.0f, 30.0f);
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
        [Property("SPEC", "Tizen.NUI.Vector3.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetHashCode_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var vector = new Vector3(10.0f, 20.0f, 30.0f);
            var hash = vector.GetHashCode();
            Assert.IsNotNull(vector, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(vector, "Should be an instance of Vector3 type.");
            Assert.IsTrue(hash >= Int32.MinValue && hash <= Int32.MaxValue, "The value of hash is out of Integer range");
        }
    }
}
