using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.Vector4 Tests")]
    public class Vector4Tests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("Vector4Tests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali Vector4 constructor test.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Vector4 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Vector4_INIT()
        {
            /* TEST CODE */
            var vector = new Vector4();
            Assert.IsInstanceOf<Vector4>(vector, "Should return Vector4 instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali Vector4 constructor test.Check whether object which initialized with four singles is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Vector4 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single,Single,Single,Single")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Vector4_INIT_WITH_SINGLE_SINGLE_SINGLE_SINGLE()
        {
            /* TEST CODE */
            var vector = new Vector4(100.0f, 200.0f, 300.0f, 400.0f);
            Assert.IsInstanceOf<Vector4>(vector, "Should return Vector4 instance.");
            Assert.AreEqual(100.0f, vector.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(200.0f, vector.Y, "Retrieved vector.Y should be equal to set value");
            Assert.AreEqual(300.0f, vector.Z, "Retrieved vector.Z should be equal to set value");
            Assert.AreEqual(400.0f, vector.W, "Retrieved vector.W should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("dali Vector4 constructor test.Check whether object which initialized with single[] is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Vector4 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single[]")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Vector4_INIT_WITH_SINGLEARRAY()
        {
            /* TEST CODE */
            float[] array = new float[4] { 100.0f, 200.0f, 300.0f, 400.0f };
            var vector = new Vector4(array);
            Assert.IsInstanceOf<Vector4>(vector, "Should return Vector4 instance.");
            Assert.AreEqual(100.0f, vector.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(200.0f, vector.Y, "Retrieved vector.Y should be equal to set value");
            Assert.AreEqual(300.0f, vector.Z, "Retrieved vector.Z should be equal to set value");
            Assert.AreEqual(400.0f, vector.W, "Retrieved vector.W should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("dali Vector4 constructor test.Check whether object which initialized with Vector2 is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Vector4 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Vector2")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Vector4_INIT_WITH_VECTOR2()
        {
            /* TEST CODE */
            var vec2 = new Vector2(100.0f, 200.0f);
            Vector4 vector = new Vector4(vec2);
            Assert.IsInstanceOf<Vector4>(vector, "Should return Vector4 instance.");
            Assert.AreEqual(100.0f, vector.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(200.0f, vector.Y, "Retrieved vector.Y should be equal to set value");
            Assert.AreEqual(0.0f, vector.Z, "Retrieved vector.Z should be equal to set value");
            Assert.AreEqual(0.0f, vector.W, "Retrieved vector.W should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("dali Vector4 constructor test.Check whether object which initialized with Vector3 is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Vector4 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Vector3")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Vector4_INIT_WITH_VECTOR3()
        {
            /* TEST CODE */
            var vec3 = new Vector3(100.0f, 200.0f, 300.0f);
            Vector4 vector = new Vector4(vec3);
            Assert.IsInstanceOf<Vector4>(vector, "Should return Vector4 instance.");
            Assert.AreEqual(100.0f, vector.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(200.0f, vector.Y, "Retrieved vector.Y should be equal to set value");
            Assert.AreEqual(300.0f, vector.Z, "Retrieved vector.Z should be equal to set value");
            Assert.AreEqual(0.0f, vector.W, "Retrieved vector.W should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test this[uint index]. Check whether this[uint index] returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void this_GET_VALUE()
        {
            /* TEST CODE */
            Vector4 vector = new Vector4(100.0f, 200.0f, 300.0f, 400.0f);
            Assert.AreEqual(100.0f, vector[0], "this[0] should return 100.0f");
            Assert.AreEqual(200.0f, vector[1], "this[1] should return 200.0f");
            Assert.AreEqual(300.0f, vector[2], "this[2] should return 300.0f");
            Assert.AreEqual(400.0f, vector[3], "this[3] should return 400.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test One.Check whether One returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.One A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void One_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(1.0f, Vector4.One.X, "Vector4.One.X should return 1.0f");
            Assert.AreEqual(1.0f, Vector4.One.Y, "Vector4.One.Y should return 1.0f");
            Assert.AreEqual(1.0f, Vector4.One.Z, "Vector4.One.Z should return 1.0f");
            Assert.AreEqual(1.0f, Vector4.One.W, "Vector4.One.W should return 1.0f");
        }


        [Test]
        [Category("P1")]
        [Description("Test XAxis.Check whether XAxis returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.XAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void XAxis_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(1.0f, Vector4.XAxis.X, "Vector4.XAxis.X should return 1.0f");
            Assert.AreEqual(0.0f, Vector4.XAxis.Y, "Vector4.XAxis.Y should return 0.0f");
            Assert.AreEqual(0.0f, Vector4.XAxis.Z, "Vector4.XAxis.Z should return 0.0f");
            Assert.AreEqual(0.0f, Vector4.XAxis.W, "Vector4.XAxis.W should return 0.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test YAxis.Check whether YAxis returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.YAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void YAxis_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Vector4.YAxis.X, "Vector4.YAxis.X should return 0.0f");
            Assert.AreEqual(1.0f, Vector4.YAxis.Y, "Vector4.YAxis.Y should return 1.0f");
            Assert.AreEqual(0.0f, Vector4.YAxis.Z, "Vector4.YAxis.Z should return 0.0f");
            Assert.AreEqual(0.0f, Vector4.YAxis.W, "Vector4.YAxis.W should return 0.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test ZAxis.Check whether ZAxis returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.ZAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ZAxis_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Vector4.ZAxis.X, "Vector4.ZAxis.X should return 0.0f");
            Assert.AreEqual(0.0f, Vector4.ZAxis.Y, "Vector4.ZAxis.Y should return 0.0f");
            Assert.AreEqual(1.0f, Vector4.ZAxis.Z, "Vector4.ZAxis.Z should return 1.0f");
            Assert.AreEqual(0.0f, Vector4.ZAxis.W, "Vector4.ZAxis.W should return 0.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test Zero.Check whether Zero returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Zero A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Zero_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Vector4.Zero.X, "Vector4.Zero.X should return 0.0f");
            Assert.AreEqual(0.0f, Vector4.Zero.Y, "Vector4.Zero.Y should return 0.0f");
            Assert.AreEqual(0.0f, Vector4.Zero.Z, "Vector4.Zero.Z should return 0.0f");
            Assert.AreEqual(0.0f, Vector4.Zero.W, "Vector4.Zero.W should return 0.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test Length.Check whether Length returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Length M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Length_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector4 vector = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Assert.AreEqual(0.0f, vector.Length(), "Length == sqrt(0.0*0.0 + 0.0*0.0 + 0.0*0.0)");
            Vector4 vector4 = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Assert.AreEqual((float)Math.Sqrt(14.0f), vector4.Length(), "Length == sqrt(1.0*1.0 + 2.0*2.0 + 3.0*3.0)");
        }

        [Test]
        [Category("P1")]
        [Description("Test LengthSquared.Check whether LengthSquared returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.LengthSquared M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void LengthSquared_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector4 vector = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Assert.AreEqual(0.0f, vector.LengthSquared(), "LengthSquared == (0.0*0.0 + 0.0*0.0 + 0.0*0.0)");
            Vector4 vector4 = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Assert.AreEqual(14.0f, vector4.LengthSquared(), "LengthSquared == (1.0*1.0 + 2.0*2.0 + 3.0*3.0)");
        }

        [Test]
        [Category("P1")]
        [Description("Test Normalize.Check whether Normalize change state of vector4 expected")]
        [Property("SPEC", "Tizen.NUI.Vector4.Normalize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Normalize_CHECK_VALUE()
        {
            /* TEST CODE */
            Vector4 vector4 = new Vector4(1.0f, 1.0f, 2.0f, 0.0f);
            vector4.Normalize();
            Assert.Less(Math.Abs(1.0f - vector4.LengthSquared()), 0.001f, "The value of LengthSquared is wrong");
            Vector4 vector = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            vector.Normalize();
            Assert.Less(Math.Abs(0.0f - vector.LengthSquared()), 0.00001f, "Should be return 0.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test Clamp.Check whether Clamp change state of vector4 expected")]
        [Property("SPEC", "Tizen.NUI.Vector4.Clamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Clamp_CHECK_VALUE()
        {
            /* TEST CODE */
            Vector4 min = new Vector4(1.0f, 4.0f, 1.5f, 0.0f);
            Vector4 max = new Vector4(9.0f, 6.0f, 8.0f, 6.0f);
            Vector4 v0 = new Vector4(2.0f, 0.8f, 0.0f, 8.0f);
            v0.Clamp(min, max);
            Assert.AreEqual(2.0f, v0.X, "2.0 > 1.0(min) && 2.0 < 9.0(max), so the value should be 2.0f");
            Assert.AreEqual(4.0f, v0.Y, "0.8 < 4.0(min), so the value should be 4.0f");
            Assert.AreEqual(1.5f, v0.Z, "0.0 < 1.5(min), so the value should be 1.5ff");
            Assert.AreEqual(6.0f, v0.W, "8.0 > 6.0(max), so the value should be 6.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test X. Check whether X is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector4.X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void X_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector4 v0 = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            v0.X = 20.0f;
            Assert.AreEqual(20.0f, v0.X, "v0.X should be 20.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test R. Check whether R is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector4.R A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void R_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector4 v0 = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            v0.R = 1.0f;
            Assert.AreEqual(1.0f, v0.R, "v0.R should be 20.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test S. Check whether S is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector4.S A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void S_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector4 v0 = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            v0.S = 1.0f;
            Assert.AreEqual(1.0f, v0.S, "v0.S should be 20.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test Y. Check whether Y is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Y_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector4 v0 = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            v0.Y = 1.0f;
            Assert.AreEqual(1.0f, v0.Y, "v0.Y should be 20.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test G. Check whether G is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector4.G A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void G_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector4 v0 = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            v0.G = 1.0f;
            Assert.AreEqual(1.0f, v0.G, "v0.G should be 20.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test T. Check whether T is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector4.T A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void T_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector4 v0 = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            v0.T = 1.0f;
            Assert.AreEqual(1.0f, v0.T, "v0.T should be 1.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test Z. Check whether Z is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Z A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Z_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector4 v0 = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            v0.Z = 1.0f;
            Assert.AreEqual(1.0f, v0.Z, "v0.Z should be 1.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test B. Check whether B is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector4.B A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void B_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector4 v0 = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            v0.B = 1.0f;
            Assert.AreEqual(1.0f, v0.B, "v0.B should be 1.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test P. Check whether P is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector4.P A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void P_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector4 v0 = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            v0.P = 1.0f;
            Assert.AreEqual(1.0f, v0.P, "v0.P should be 1.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test W. Check whether W is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector4.W A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void W_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector4 v0 = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            v0.W = 1.0f;
            Assert.AreEqual(1.0f, v0.W, "v0.W should be 1.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test A. Check whether A is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector4.A A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void A_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector4 v0 = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            v0.A = 1.0f;
            Assert.AreEqual(1.0f, v0.A, "v0.A should be 1.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test Q. Check whether Q is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Q A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Q_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector4 v0 = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            v0.Q = 1.0f;
            Assert.AreEqual(1.0f, v0.Q, "v0.Q should be 1.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test Addition.Check whether Addition whose parameter is Vector4 and Vector4 returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Addition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Addition_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector4 vector1 = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Vector4 vector2 = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4 vector = vector1 + vector2;
            Assert.AreEqual(11.0f, vector.X, "vector.X == 10.0f + 1.0f");
            Assert.AreEqual(22.0f, vector.Y, "vector.Y == 20.0f + 2.0f");
            Assert.AreEqual(33.0f, vector.Z, "vector.Z == 30.0f + 3.0f");
            Assert.AreEqual(44.0f, vector.W, "vector.W == 40.0f + 4.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test Subtraction.Check whether Subtraction whose parameter is Vector4 and Vector4 returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Subtraction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Subtraction_SET_GET_VALUE_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector4 vector1 = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Vector4 vector2 = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4 vector = vector1 - vector2;
            Assert.AreEqual(9.0f, vector.X, "vector.X == 10.0f - 1.0f");
            Assert.AreEqual(18.0f, vector.Y, "vector.Y == 20.0f - 2.0f");
            Assert.AreEqual(27.0f, vector.Z, "vector.Z == 30.0f - 3.0f");
            Assert.AreEqual(36.0f, vector.W, "vector.W == 40.0f - 4.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test UnaryNegation.Check whether UnaryNegation whose parameter is Vector4 returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.UnaryNegation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void UnaryNegation_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector4 vector1 = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Vector4 vector = -vector1;
            Assert.AreEqual(-10.0f, vector.X, "vector.X == -10.0f");
            Assert.AreEqual(-20.0f, vector.Y, "vector.Y == -20.0f");
            Assert.AreEqual(-30.0f, vector.Z, "vector.Z == -30.0f");
            Assert.AreEqual(-40.0f, vector.W, "vector.W == -40.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test Multiply.Check whether Multiply whose parameter is Vector4 and Vector4 returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector4,Vector4")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Multiply_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector4 vector1 = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Vector4 vector2 = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4 vector = vector1 * vector2;
            Assert.AreEqual(10.0f, vector.X, "vector.X == 10.0f * 1.0f");
            Assert.AreEqual(40.0f, vector.Y, "vector.Y == 20.0f * 2.0f");
            Assert.AreEqual(90.0f, vector.Z, "vector.Z == 30.0f * 3.0f");
            Assert.AreEqual(160.0f, vector.W, "vector.W == 40.0f * 4.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test Multiply.Check whether Multiply whose parameter is Vector4 and Single returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector4,Single")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Multiply_CHECK_RETURN_VALUE_WITH_VECTOR4_SINGLE()
        {
            /* TEST CODE */
            Vector4 vector1 = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Vector4 vector = vector1 * 10.0f;
            Assert.AreEqual(100.0f, vector.X, "vector.X == 10.0f * 10.0f");
            Assert.AreEqual(200.0f, vector.Y, "vector.Y == 20.0f * 10.0f");
            Assert.AreEqual(300.0f, vector.Z, "vector.Z == 30.0f * 10.0f");
            Assert.AreEqual(400.0f, vector.W, "vector.W == 40.0f * 10.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test Division.Check whether Division whose parameter is Vector4 and Vector4 returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector4,Vector4")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Division_CHECK_RETURN_VALUE_WITH_VECTOR4_VECTOR4()
        {
            /* TEST CODE */
            Vector4 vector1 = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Vector4 vector2 = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4 vector = vector1 / vector2;
            Assert.AreEqual(10.0f, vector.X, "vector.X == 10.0f");
            Assert.AreEqual(10.0f, vector.Y, "vector.Y == 10.0f");
            Assert.AreEqual(10.0f, vector.Z, "vector.Z == 10.0f");
            Assert.AreEqual(10.0f, vector.W, "vector.W == 10.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test Division.Check whether Division whose parameter is Vector4 and Single returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector4,Single")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Division_CHECK_RETURN_VALUE_WITH_VECTOR4_SINGLE()
        {
            /* TEST CODE */
            Vector4 vector1 = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Vector4 vector = vector1 / 10.0f;
            Assert.AreEqual(1.0f, vector.X, "vector.X == 10.0f / 10.0f");
            Assert.AreEqual(2.0f, vector.Y, "vector.X == 20.0f / 10.0f");
            Assert.AreEqual(3.0f, vector.Z, "vector.X == 30.0f / 10.0f");
            Assert.AreEqual(4.0f, vector.W, "vector.X == 40.0f / 10.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test Equals. Check whether Equals returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Equals_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector4 vector1 = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            Vector4 vector2 = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);

            bool flag = vector1.Equals(vector2);
            Assert.IsTrue(flag, "Should be true here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Vector4.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                Vector4 vector1 = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
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
        [Property("SPEC", "Tizen.NUI.Vector4.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetHashCode_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var vector = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            var hash = vector.GetHashCode();
            Assert.IsNotNull(vector, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(vector, "Should be an instance of Vector4 type.");
            Assert.IsTrue(hash >= Int32.MinValue && hash <= Int32.MaxValue, "The value of hash is out of Integer range");
        }
    }
}
