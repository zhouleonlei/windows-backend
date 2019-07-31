using NUnit.Framework;
using Tizen.NUI;
using System;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.Rotation Tests")]
    public class RotationTests
    {
        private string TAG = "NUI";

        private Vector3 MyCross(Vector3 vector1, Vector3 vector2)
        {
            return new Vector3((vector1.Y * vector2.Z) - (vector1.Z * vector2.Y),
                  (vector1.Z * vector2.X) - (vector1.X * vector2.Z),
                  (vector1.X * vector2.Y) - (vector1.Y * vector2.X));
        }

        private float MyDot(Vector3 vector1, Vector3 vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z; ;
        }

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("Tests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Addition. Check whether Addition returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Addition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Addition_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rotation rotation1 = new Rotation(new Radian(new Degree(180.0f)), new Vector3(1.0f, 0.0f, 0.0f));
            Rotation rotation2 = new Rotation(new Radian(new Degree(180.0f)), new Vector3(1.0f, 0.0f, 0.0f));
            Rotation rotation3 = rotation1 + rotation2;
            Radian radianvalue = new Radian(0.0f);
            Vector3 axisvalue = new Vector3();
            rotation3.GetAxisAngle(axisvalue, radianvalue);
            Assert.AreEqual(2.0f, axisvalue.X, "Addition function does not work, Vector3.X value is not correct");
            Assert.AreEqual(0.0f, axisvalue.Y, "Addition function does not work, Vector3.Y value is not correct");
            Assert.AreEqual(0.0f, axisvalue.Z, "Addition function does not work, Vector3.Z value is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Subtraction. Check whether Subtraction with two Rotation parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Subtraction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Rotation, Rotation")]
        public void Subtraction_CHECK_RETURN_VALUE_WITH_ROTATION_ROTATION()
        {
            /* TEST CODE */
            Rotation rotation1 = new Rotation(new Radian(new Degree(180.0f)), new Vector3(0.0f, 1.0f, 0.0f));
            Rotation rotation2 = new Rotation(new Radian(new Degree(180.0f)), new Vector3(0.0f, 1.0f, 0.0f));
            Rotation rotation3 = rotation1 - rotation2;
            Radian radianvalue = new Radian(0.0f);
            Vector3 axisvalue = new Vector3();
            rotation3.GetAxisAngle(axisvalue, radianvalue);
            Assert.AreEqual(0.0f, axisvalue.X, "Subtraction function does not work, Vector3.X value is not correct");
            Assert.AreEqual(0.0f, axisvalue.Y, "Subtraction function does not work, Vector3.Y value is not correct");
            Assert.AreEqual(0.0f, axisvalue.Z, "Subtraction function does not work, Vector3.Z value is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test UnaryNegation. Check whether UnaryNegation with Rotation parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.UnaryNegation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Rotation")]
        public void UnaryNegation_CHECK_RETURN_VALUE_WITH_ROTATION()
        {
            /* TEST CODE */
            Rotation rotation1 = new Rotation(new Radian(new Degree(180.0f)), new Vector3(0.0f, 1.0f, 0.0f));
            Rotation rotation2 = new Rotation(new Radian(new Degree(180.0f)), new Vector3(0.0f, 1.0f, 0.0f));
            rotation2 = -rotation1;
            Radian radianvalue = new Radian(0.0f);
            Vector3 axisvalue = new Vector3();
            rotation2.GetAxisAngle(axisvalue, radianvalue);
            Assert.AreEqual(0.0f, axisvalue.X, "UnaryNegation function does not work, Vector3.X value is not correct");
            Assert.AreEqual(-1.0f, axisvalue.Y, "UnaryNegation function does not work, Vector3.Y value is not correct");
            Assert.AreEqual(0.0f, axisvalue.Z, "UnaryNegation function does not work, Vector3.Z value is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Multiply. Check whether Multiply with two Rotation parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Rotation, Rotation")]
        public void Multiply_CHECK_RETURN_VALUE_WITH_ROTATION_ROTATION()
        {
            /* TEST CODE */
            float s1 = 0.0f;
            float s2 = 0.0f;
            Vector3 vector1 = new Vector3(0.0f, 0.0f, 0.0f);
            Vector3 vector2 = new Vector3(0.0f, 0.0f, 0.0f);
            Radian radian1 = new Radian(0.0f);
            Radian radian2 = new Radian(0.0f);

            Rotation q1 = new Rotation(new Radian(s1), vector1);
            Rotation q2 = new Rotation(new Radian(s2), vector2);

            Vector3 vector3 = MyCross(vector1, vector2) + vector2 * s1 + vector1 * s2;
            Rotation r1 = new Rotation(new Radian(s1 * s2 - MyDot(vector1, vector2)), vector3);

            Radian radianvaluetemp1 = new Radian(0.0f);
            Vector3 axisvaluetemp1 = new Vector3();
            r1.GetAxisAngle(axisvaluetemp1, radianvaluetemp1);

            Rotation rotationtemp = q1 * q2;

            Radian radianvaluetemp2 = new Radian(0.0f);
            Vector3 axisvaluetemp2 = new Vector3();
            rotationtemp.GetAxisAngle(axisvaluetemp2, radianvaluetemp2);

            Assert.AreEqual(float.Parse(axisvaluetemp2.X.ToString("F2")), float.Parse(axisvaluetemp1.X.ToString("F2")), "Vector3 got from Multiply is not correct, X value is not correct");
            Assert.AreEqual(float.Parse(axisvaluetemp2.Y.ToString("F2")), float.Parse(axisvaluetemp1.Y.ToString("F2")), "Vector3 got from Multiply is not correct, Y value is not correct");
            Assert.AreEqual(float.Parse(axisvaluetemp2.Z.ToString("F2")), float.Parse(axisvaluetemp1.Z.ToString("F2")), "Vector3 got from Multiply is not correct, Z value is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Multiply. Check whether Multiply with Rotation and Vector3 parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Rotation, Vector3")]
        public void Multiply_CHECK_RETURN_VALUE_WITH_ROTATION_VECTOR3()
        {
            /* TEST CODE */
            Vector3 v = new Vector3(0.0f, 0.0f, 0.0f );
            Rotation q = new Rotation(new Radian(0.0f), Vector3.Zero );
            Rotation qI = q;
            qI.Invert();
            Rotation qv = new Rotation(new Radian(0.0f), v );
            Rotation r1 = (q * qv) * qI;

            Vector3 r2 = q * v;

            Radian radianvaluetemp = new Radian(0.0f);
            Vector3 axisvaluetemp = new Vector3();
            r1.GetAxisAngle(axisvaluetemp, radianvaluetemp);

            Assert.AreEqual(r2.X, float.Parse(axisvaluetemp.X.ToString("F2")), "Vector3 got from Multiply is not correct, X value is not correct");
            Assert.AreEqual(r2.Y, float.Parse(axisvaluetemp.Y.ToString("F2")), "Vector3 got from Multiply is not correct, Y value is not correct");
            Assert.AreEqual(r2.Z, float.Parse(axisvaluetemp.Z.ToString("F2")), "Vector3 got from Multiply is not correct, Z value is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Multiply. Check whether Multiply with Rotation and float parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Rotation, Single")]
        public void Multiply_CHECK_RETURN_VALUE_WITH_ROTATION_FLOAT()
        {
            /* TEST CODE */
            Rotation rotation1 = new Rotation(new Radian(new Degree(180)), new Vector3(1.0f, 0.0f, 0.0f));
            Radian radianvalue1 = new Radian(0.0f);
            Vector3 axisvalue1 = new Vector3();
            rotation1.GetAxisAngle(axisvalue1, radianvalue1);
            Rotation rotation2 = rotation1 * 2.0f;
            Radian radianvalue2 = new Radian(0.0f);
            Vector3 axisvalue2 = new Vector3();
            rotation2.GetAxisAngle(axisvalue2, radianvalue2);
            Assert.AreEqual(2.0f, float.Parse(axisvalue2.X.ToString("F2")), "Vector3 got from Multiply is not correct, X value is not correct");
            Assert.AreEqual(0.0f, float.Parse(axisvalue2.Y.ToString("F2")), "Vector3 got from Multiply is not correct, Y value is not correct");
            Assert.AreEqual(0.0f, float.Parse(axisvalue2.Z.ToString("F2")), "Vector3 got from Multiply is not correct, Z value is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Division. Check whether Division with two Rotation parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Rotation, Rotation")]
        public void Division_CHECK_RETURN_VALUE_WITH_ROTATION_ROTATION()
        {
            /* TEST CODE */
            Rotation q1 = new Rotation(new Radian(2.35551f), new Vector3(0.0f, 0.0f, 1.00027f));
            Rotation q2 = new Rotation(new Radian(3.14159f), new Vector3(0.609f, 0.0f, 0.793f));

            Rotation r1 = q2;
            r1.Conjugate();
            r1 *= 1.0f / q2.LengthSquared();
            Rotation r2 = q1 * r1;
            Rotation r3 = q1 / q2;

            Radian radianvalue1 = new Radian(0.0f);
            Vector3 axisvalue1 = new Vector3();
            r3.GetAxisAngle(axisvalue1, radianvalue1);

            Radian radianvalue2 = new Radian(0.0f);
            Vector3 axisvalue2 = new Vector3();
            r3.GetAxisAngle(axisvalue2, radianvalue2);

            Assert.AreEqual(float.Parse(axisvalue1.X.ToString("F2")), float.Parse(axisvalue2.X.ToString("F2")), "Division function does not work, Vector3.X value is not correct");
            Assert.AreEqual(float.Parse(axisvalue1.Y.ToString("F2")), float.Parse(axisvalue2.Y.ToString("F2")), "Division function does not work, Vector3.Y value is not correct");
            Assert.AreEqual(float.Parse(axisvalue1.Z.ToString("F2")), float.Parse(axisvalue2.Z.ToString("F2")), "Division function does not work, Vector3.Z value is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Division. Check whether Division with Rotation and float parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Rotation, Single")]
        public void Division_CHECK_RETURN_VALUE_WITH_ROTATION_FLOAT()
        {
            /* TEST CODE */
            Rotation rotation1 = new Rotation(new Radian(new Degree(180.0f)), new Vector3(0.0f, 1.0f, 0.0f));
            Rotation rotation2 = rotation1 / 2.0f;
            Radian radianvalue = new Radian(0.0f);
            Vector3 axisvalue = new Vector3();
            rotation2.GetAxisAngle(axisvalue, radianvalue);
            Assert.AreEqual(0.0f, axisvalue.X, "Division function does not work, Vector3.X value is not correct");
            Assert.AreEqual(0.5f, axisvalue.Y, "Division function does not work, Vector3.Y value is not correct");
            Assert.AreEqual(0.0f, axisvalue.Z, "Division function does not work, Vector3.Z value is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("dali Rotation constructor test")]
        [Property("SPEC", "Tizen.NUI.Rotation.Rotation C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Rotation_INIT_WITH_NULL()
        {
            /* TEST CODE */
            var rotation = new Rotation();
            Assert.IsInstanceOf<Rotation>(rotation, "Should return Rotation instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali Rotation constructor with Radian and Vector3 parameter test")]
        [Property("SPEC", "Tizen.NUI.Rotation.Rotation C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Radian, Vector3")]
        public void Rotation_INIT_WITH_RADIAN_VECTOR3()
        {
            /* TEST CODE */
            var rotation = new Rotation(new Radian(6.0f), new Vector3(1.0f, 2.0f, 3.0f));
            Assert.IsInstanceOf<Rotation>(rotation, "Should return Rotation instance.");
            Radian radianvalue = new Radian(0.0f);
            Vector3 axisvalue = new Vector3();
            rotation.GetAxisAngle(axisvalue, radianvalue);
            Assert.AreEqual(0.27f, float.Parse(axisvalue.X.ToString("F2")), "Vector3 parameter got from constructor is not correct, X value is not correct");
            Assert.AreEqual(0.53f, float.Parse(axisvalue.Y.ToString("F2")), "Vector3 parameter got from constructor is not correct, Y value is not correct");
            Assert.AreEqual(0.80f, float.Parse(axisvalue.Z.ToString("F2")), "Vector3 parameter got from constructor is not correct, Z value is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test IDENTITY. Check whether IDENTITY returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.IDENTITY A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void IDENTITY_GET_VALUE()
        {
            /* TEST CODE */
            Rotation rotation1 = new Rotation(new Radian(0.0f), new Vector3(1.0f, 1.0f, 1.0f));
            Radian radianvalue1 = new Radian(0.0f);
            Vector3 axisvalue1 = new Vector3();
            rotation1.GetAxisAngle(axisvalue1, radianvalue1);
            Rotation rotation2 = Rotation.IDENTITY;
            Radian radianvalue2 = new Radian(0.0f);
            Vector3 axisvalue2 = new Vector3();
            rotation2.GetAxisAngle(axisvalue2, radianvalue2);
            Assert.AreEqual(float.Parse(axisvalue2.X.ToString("F2")), float.Parse(axisvalue1.X.ToString("F2")), "Vector3 got from IDENTITY is not correct, X value is not correct");
            Assert.AreEqual(float.Parse(axisvalue2.X.ToString("F2")), float.Parse(axisvalue1.Y.ToString("F2")), "Vector3 got from IDENTITY is not correct, Y value is not correct");
            Assert.AreEqual(float.Parse(axisvalue2.X.ToString("F2")), float.Parse(axisvalue1.Z.ToString("F2")), "Vector3 got from IDENTITY is not correct, Z value is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test IsIdentity. Check whether IsIdentity returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.IsIdentity M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void IsIdentity_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rotation rotation1 = Rotation.IDENTITY;
            Assert.IsTrue(rotation1.IsIdentity(), "IsIdentity should return true!");

            Rotation rotation2 = new Rotation(new Radian(90.0f), new Vector3(0.1f, 0.0f, 0.0f));
            Assert.IsFalse(rotation2.IsIdentity(), "IsIdentity should return false!");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetAxisAngle. Check whether GetAxisAngle returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.GetAxisAngle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void GetAxisAngle_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rotation rotation = new Rotation(new Radian(6.0f), new Vector3(1.0f, 2.0f, 3.0f));
            Radian radianvalue = new Radian(0.0f);
            Vector3 axisvalue = new Vector3();
            rotation.GetAxisAngle(axisvalue, radianvalue);
            Assert.AreEqual(0.27f, float.Parse(axisvalue.X.ToString("F2")), "Vector3 got from GetAxisAngle is not correct, X value is not correct");
            Assert.AreEqual(0.53f, float.Parse(axisvalue.Y.ToString("F2")), "Vector3 got from GetAxisAngle is not correct, Y value is not correct");
            Assert.AreEqual(0.80f, float.Parse(axisvalue.Z.ToString("F2")), "Vector3 got from GetAxisAngle is not correct, Z value is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Length. Check whether Length returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Length M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Length_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rotation rotation = new Rotation(new Radian(new Degree(90)), new Vector3(1.0f, 2.0f, 3.0f));
            double a = Math.Sqrt(0.707f * 0.707f + 0.189f * 0.189f + 0.378f * 0.378f + 0.567f * 0.567f);
            float b = rotation.Length();
            Assert.AreEqual(float.Parse(a.ToString("F2")), float.Parse(b.ToString("F2")), "Length function return incorrect value");
        }

        [Test]
        [Category("P1")]
        [Description("Test LengthSquared. Check whether LengthSquared returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.LengthSquared M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void LengthSquared_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rotation rotation = new Rotation(new Radian(new Degree(90)), new Vector3(1.0f, 2.0f, 3.0f));
            double a = 0.707f * 0.707f + 0.189f * 0.189f + 0.378f * 0.378f + 0.567f * 0.567f;
            float b = rotation.LengthSquared();
            Assert.AreEqual(float.Parse(a.ToString("F2")), float.Parse(b.ToString("F2")), "LengthSquared function return incorrect value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Normalize. Check whether Normalize returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Normalize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Normalize_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rotation rotation = new Rotation(new Radian(6.0f), new Vector3(1.0f, 2.0f, 3.0f));
            rotation.Normalize();
            Radian radianvalue = new Radian(0.0f);
            Vector3 axisvalue = new Vector3();
            rotation.GetAxisAngle(axisvalue, radianvalue);
            Assert.AreEqual(0.27f, float.Parse(axisvalue.X.ToString("F2")), "Vector3 got from Normalize is not correct, X value is not correct");
            Assert.AreEqual(0.53f, float.Parse(axisvalue.Y.ToString("F2")), "Vector3 got from Normalize is not correct, Y value is not correct");
            Assert.AreEqual(0.80f, float.Parse(axisvalue.Z.ToString("F2")), "Vector3 got from Normalize is not correct, Z value is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Normalized. Check whether Normalized returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Normalized M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Normalized_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rotation rotation = new Rotation(new Radian(6.0f), new Vector3(1.0f, 2.0f, 3.0f));
            Radian radianvalue = new Radian(0.0f);
            Vector3 axisvalue = new Vector3();
            rotation.GetAxisAngle(axisvalue, radianvalue);
            Assert.AreEqual(0.27f, float.Parse(axisvalue.X.ToString("F2")), "X value is not correct");
            Assert.AreEqual(0.53f, float.Parse(axisvalue.Y.ToString("F2")), "Y value is not correct");
            Assert.AreEqual(0.80f, float.Parse(axisvalue.Z.ToString("F2")), "Z value is not correct");
            Rotation rotationnew2 = rotation * 5.0f;
            Rotation rotationnew3 = rotationnew2.Normalized();
            Radian radianvalue3 = new Radian(0.0f);
            Vector3 axisvalue3 = new Vector3();
            rotationnew3.GetAxisAngle(axisvalue3, radianvalue3);
            Assert.AreEqual(0.27f, float.Parse(axisvalue3.X.ToString("F2")), "X value got from Normalized is not correct");
            Assert.AreEqual(0.53f, float.Parse(axisvalue3.Y.ToString("F2")), "Y value got from Normalized is not correct");
            Assert.AreEqual(0.80f, float.Parse(axisvalue3.Z.ToString("F2")), "Z value got from Normalized is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Conjugate. Check whether Conjugate returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Conjugate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Conjugate_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rotation rotation = new Rotation(new Radian(6.0f), new Vector3(1.0f, 2.0f, 3.0f));
            Radian radianvalue = new Radian(0.0f);
            Vector3 axisvalue = new Vector3();
            rotation.GetAxisAngle(axisvalue, radianvalue);
            Assert.AreEqual(0.27f, float.Parse(axisvalue.X.ToString("F2")), "X value is not correct");
            Assert.AreEqual(0.53f, float.Parse(axisvalue.Y.ToString("F2")), "Y value is not correct");
            Assert.AreEqual(0.80f, float.Parse(axisvalue.Z.ToString("F2")), "Z value is not correct");
            rotation.Conjugate();
            Radian radianvaluenew = new Radian(0.0f);
            Vector3 axisvaluenew = new Vector3();
            rotation.GetAxisAngle(axisvaluenew, radianvaluenew);
            Assert.AreEqual(-0.27f, float.Parse(axisvaluenew.X.ToString("F2")), "X value got from Conjugate is not correct");
            Assert.AreEqual(-0.53f, float.Parse(axisvaluenew.Y.ToString("F2")), "Y value got from Conjugate is not correct");
            Assert.AreEqual(-0.80f, float.Parse(axisvaluenew.Z.ToString("F2")), "Z value got from Conjugate is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Invert. Check whether Invert returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Invert M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Invert_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rotation rotation = new Rotation(new Radian(0.0f), new Vector3(0.0f, 0.0f, 0.0f)); //radian: 2.355f z: -1.0f
            Rotation rotation2 = rotation;

            rotation2.Conjugate();
            rotation2 *= 1.0f / rotation.LengthSquared();

            Rotation rotation3 = rotation;
            rotation3.Invert();

            Radian radianvalue = new Radian(0.0f);
            Vector3 axisvalue = new Vector3();
            rotation2.GetAxisAngle(axisvalue, radianvalue);

            Radian radianvaluenew1 = new Radian(0.0f);
            Vector3 axisvaluenew1 = new Vector3();
            rotation3.GetAxisAngle(axisvaluenew1, radianvaluenew1);

            Assert.AreEqual(float.Parse(axisvaluenew1.X.ToString("F2")), float.Parse(axisvalue.X.ToString("F2")), "Invert function does not work, X value is not correct");
            Assert.AreEqual(float.Parse(axisvaluenew1.Y.ToString("F2")), float.Parse(axisvalue.Y.ToString("F2")), "Invert function does not work, Y value is not correct");
            Assert.AreEqual(float.Parse(axisvaluenew1.Z.ToString("F2")), float.Parse(axisvalue.Z.ToString("F2")), "Invert function does not work, Z value is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Log. Check whether Log returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Log M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Log_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rotation rotation1 = new Rotation(new Radian(2.29f), new Vector3(0.0f, 0.0f, 0.0f));
            Rotation rotation2 = rotation1;
            rotation2.Normalize();
            Rotation rotationnew = rotation2.Log();
            Rotation rotationnew2 = rotationnew.Exp();
            Radian radianvalue2 = new Radian(0.0f);
            Vector3 axisvalue2 = new Vector3();
            rotation2.GetAxisAngle(axisvalue2, radianvalue2);
            Radian radianvaluenew2 = new Radian(0.0f);
            Vector3 axisvaluenew2 = new Vector3();
            rotationnew2.GetAxisAngle(axisvaluenew2, radianvaluenew2);
            Assert.AreEqual(float.Parse(axisvalue2.X.ToString("F2")), float.Parse(axisvaluenew2.X.ToString("F2")), "Log function does not wrok, X value is not correct");
            Assert.AreEqual(float.Parse(axisvalue2.Y.ToString("F2")), float.Parse(axisvaluenew2.Y.ToString("F2")), "Log function does not wrok, Y value is not correct");
            Assert.AreEqual(float.Parse(axisvalue2.Z.ToString("F2")), float.Parse(axisvaluenew2.Z.ToString("F2")), "Log function does not wrok, Z value is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Exp. Check whether Exp returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Exp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Exp_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rotation rotation1 = new Rotation(new Radian(2.29f), new Vector3(0.0f, 0.0f, 0.0f));
            Rotation rotation2 = rotation1;
            rotation2.Normalize();
            Rotation rotationnew = rotation2.Log();
            Rotation rotationnew2 = rotationnew.Exp();
            Radian radianvalue2 = new Radian(0.0f);
            Vector3 axisvalue2 = new Vector3();
            rotation2.GetAxisAngle(axisvalue2, radianvalue2);
            Radian radianvaluenew2 = new Radian(0.0f);
            Vector3 axisvaluenew2 = new Vector3();
            rotationnew2.GetAxisAngle(axisvaluenew2, radianvaluenew2);
            Assert.AreEqual(float.Parse(axisvalue2.X.ToString("F2")), float.Parse(axisvaluenew2.X.ToString("F2")), "Exp function does not wrok, X value is not correct");
            Assert.AreEqual(float.Parse(axisvalue2.Y.ToString("F2")), float.Parse(axisvaluenew2.Y.ToString("F2")), "Exp function does not wrok, Y value is not correct");
            Assert.AreEqual(float.Parse(axisvalue2.Z.ToString("F2")), float.Parse(axisvaluenew2.Z.ToString("F2")), "Exp function does not wrok, Z value is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dot. Check whether Dot returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Dot M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Dot_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector3 vector1 = new Vector3(0.072f, 0.713f, 0.695f);
            Vector3 vector2 = new Vector3(0.853f, 0.479f, -0.200f);
            Radian radian1 = new Radian(1.339f);
            Radian radian2 = new Radian(1.599f);
            Rotation rotation1 = new Rotation(radian1, vector1);
            Rotation rotation2 = new Rotation(radian2, vector2);

            float s1 = 0.784f; Vector3 v1 = new Vector3(0.045f, 0.443f, 0.432f );
            float s2 = 0.697f; Vector3 v2 = new Vector3(0.612f, 0.344f, -0.144f );

            float r1 = s1 * s2 + MyDot(v1, v2);
            float s3 = Rotation.Dot(rotation1, rotation2);

            Assert.AreEqual(float.Parse(s3.ToString("F2")), float.Parse(r1.ToString("F2")), "Dot function does not wrok");
        }

        [Test]
        [Category("P1")]
        [Description("Test Lerp. Check whether Lerp returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Lerp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Lerp_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rotation rotation1 = new Rotation(new Radian(new Degree(-80.0f)), new Vector3(0.0f, 0.0f, 1.0f));
            Rotation rotation2 = new Rotation(new Radian(new Degree(80.0f)), new Vector3(0.0f, 0.0f, 1.0f));
            Radian radianvalue2 = new Radian(0.0f);
            Vector3 axisvalue2 = new Vector3();
            rotation2.GetAxisAngle(axisvalue2, radianvalue2);
            Rotation rotationnew = Rotation.Lerp(rotation1, rotation2, 1.0f);
            Radian radianvaluenew = new Radian(0.0f);
            Vector3 axisvaluenew = new Vector3();
            rotationnew.GetAxisAngle(axisvaluenew, radianvaluenew);
            Assert.AreEqual(float.Parse(axisvalue2.X.ToString("F2")), float.Parse(axisvaluenew.X.ToString("F2")), "Lerp function does not wrok, X value is not correct");
            Assert.AreEqual(float.Parse(axisvalue2.Y.ToString("F2")), float.Parse(axisvaluenew.Y.ToString("F2")), "Lerp function does not wrok, Y value is not correct");
            Assert.AreEqual(float.Parse(axisvalue2.Z.ToString("F2")), float.Parse(axisvaluenew.Z.ToString("F2")), "Lerp function does not wrok, Z value is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Slerp. Check whether Slerp returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Slerp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Slerp_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rotation rotation1 = new Rotation(new Radian(new Degree(120.0f)), new Vector3(0.0f, 0.0f, 1.0f));
            Rotation rotation2 = new Rotation(new Radian(new Degree(130.0f)), new Vector3(0.0f, 0.0f, 1.0f));
            Radian radianvalue2 = new Radian(0.0f);
            Vector3 axisvalue2 = new Vector3();
            rotation2.GetAxisAngle(axisvalue2, radianvalue2);
            Rotation rotationnew = Rotation.Slerp(rotation1, rotation2, 1.0f);
            Radian radianvaluenew = new Radian(0.0f);
            Vector3 axisvaluenew = new Vector3();
            rotationnew.GetAxisAngle(axisvaluenew, radianvaluenew);
            Assert.AreEqual(float.Parse(axisvalue2.X.ToString("F2")), float.Parse(axisvaluenew.X.ToString("F2")), "Slerp function does not wrok, X value is not correct");
            Assert.AreEqual(float.Parse(axisvalue2.Y.ToString("F2")), float.Parse(axisvaluenew.Y.ToString("F2")), "Slerp function does not wrok, Y value is not correct");
            Assert.AreEqual(float.Parse(axisvalue2.Z.ToString("F2")), float.Parse(axisvaluenew.Z.ToString("F2")), "Slerp function does not wrok, Z value is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test SlerpNoInvert. Check whether SlerpNoInvert returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.SlerpNoInvert M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void SlerpNoInvert_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rotation rotation1 = new Rotation(new Radian(new Degree(120.0f)), new Vector3(0.0f, 0.0f, 1.0f));
            Radian radianvalue1 = new Radian(0.0f);
            Vector3 axisvalue1 = new Vector3();
            rotation1.GetAxisAngle(axisvalue1, radianvalue1);
            Rotation rotation2 = new Rotation(new Radian(new Degree(130.0f)), new Vector3(0.0f, 0.0f, 1.0f));
            Radian radianvalue2 = new Radian(0.0f);
            Vector3 axisvalue2 = new Vector3();
            rotation2.GetAxisAngle(axisvalue2, radianvalue2);
            Rotation rotationnew = Rotation.SlerpNoInvert(rotation1, rotation2, 0.0f);
            Radian radianvaluenew = new Radian(0.0f);
            Vector3 axisvaluenew = new Vector3();
            rotationnew.GetAxisAngle(axisvaluenew, radianvaluenew);
            Assert.AreEqual(axisvalue1.X, axisvaluenew.X, "SlerpNoInvert function does not wrok, X value is not correct");
            Assert.AreEqual(axisvalue1.Y, axisvaluenew.Y, "SlerpNoInvert function does not wrok, Y value is not correct");
            Assert.AreEqual(axisvalue1.Z, axisvaluenew.Z, "SlerpNoInvert function does not wrok, Z value is not correct");
            rotationnew = Rotation.SlerpNoInvert(rotation1, rotation2, 1.0f);
            rotationnew.GetAxisAngle(axisvaluenew, radianvaluenew);
            Assert.AreEqual(axisvalue2.X, axisvaluenew.X, "SlerpNoInvert function does not wrok, X value is not correct");
            Assert.AreEqual(axisvalue2.Y, axisvaluenew.Y, "SlerpNoInvert function does not wrok, Y value is not correct");
            Assert.AreEqual(axisvalue2.Z, axisvaluenew.Z, "SlerpNoInvert function does not wrok, Z value is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Squad. Check whether Squad returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Squad M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Squad_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rotation rotation1 = new Rotation(new Radian(new Degree(45.0f)), new Vector3(0.0f, 0.0f, 1.0f));
            Rotation rotation1out = new Rotation(new Radian(new Degree(40.0f)), new Vector3(0.0f, 1.0f, 2.0f));
            Rotation rotation2in = new Rotation(new Radian(new Degree(35.0f)), new Vector3(0.0f, 2.0f, 3.0f));
            Rotation rotation2 = new Rotation(new Radian(new Degree(30.0f)), new Vector3(0.0f, 1.0f, 3.0f));
            Rotation rotationnew = Rotation.Squad(rotation1, rotation2, rotation1out, rotation2in, 0.0f);
            Radian radianvalue1 = new Radian(0.0f);
            Vector3 axisvalue1 = new Vector3();
            rotation1.GetAxisAngle(axisvalue1, radianvalue1);
            Radian radianvalue2 = new Radian(0.0f);
            Vector3 axisvalue2 = new Vector3();
            rotation2.GetAxisAngle(axisvalue2, radianvalue2);
            Radian radianvaluenew = new Radian(0.0f);
            Vector3 axisvaluenew = new Vector3();
            rotationnew.GetAxisAngle(axisvaluenew, radianvaluenew);
            Assert.AreEqual(axisvaluenew.X, axisvalue1.X, "Squad function does not wrok, X value is not correct");
            Assert.AreEqual(axisvaluenew.Y, axisvalue1.Y, "Squad function does not wrok, Y value is not correct");
            Assert.AreEqual(axisvaluenew.Z, axisvalue1.Z, "Squad function does not wrok, Z value is not correct");
            rotationnew = Rotation.Squad(rotation1, rotation2, rotation1out, rotation2in, 1.0f);
            rotationnew.GetAxisAngle(axisvaluenew, radianvaluenew);
            Assert.AreEqual(axisvaluenew.X, axisvalue2.X, "Squad function does not wrok, X value is not correct");
            Assert.AreEqual(axisvaluenew.Y, axisvalue2.Y, "Squad function does not wrok, Y value is not correct");
            Assert.AreEqual(axisvaluenew.Z, axisvalue2.Z, "Squad function does not wrok, Z value is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test AngleBetween. Check whether AngleBetween returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rotation.AngleBetween M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void AngleBetween_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Radian radian1 = new Radian(new Degree(80.0f));
            Radian radian2 = new Radian(new Degree(90.0f));
            Rotation rotation1 = new Rotation(radian1, Vector3.YAxis);
            Rotation rotation2 = new Rotation(radian2, Vector3.YAxis);
            float value1 = Rotation.AngleBetween(rotation1, rotation2);
            float value2 = (90.0f - 80.0f) * 3.14f / 180.0f;
            Assert.AreEqual(float.Parse(value1.ToString("F2")), float.Parse(value2.ToString("F2")), "AngleBetween function does not work.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Rotation.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                Radian radian1 = new Radian(new Degree(80.0f));
                Rotation rotation1 = new Rotation(radian1, Vector3.YAxis);
                rotation1.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
    }
}
