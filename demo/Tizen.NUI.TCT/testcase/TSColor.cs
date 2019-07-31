using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using System.Runtime.InteropServices;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.Color Tests")]
    public class ColorTests
    {
        private string TAG = "Test for Color.cs";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, " Init() is called!");
            App.MainTitleChangeText("ColorTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, " Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali color constructor test")]
        [Property("SPEC", "Tizen.NUI.Color.Color C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Color_INIT()
        {
            /* TEST CODE */
            var color = new Color();
            Assert.IsInstanceOf<Color>(color, "Should return Color instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali color constructor with four float parameter test")]
        [Property("SPEC", "Tizen.NUI.Color.Color C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single, Single, Single, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Color_INIT_WITH_FLOAT_FLOAT_FLOAT_FLOAT()
        {
            /* TEST CODE */
            var color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
            Assert.IsInstanceOf<Color>(color, "Should return Color instance.");
            Assert.AreEqual(0.5f, color.R, "The R property of Black is not correct here.");
            Assert.AreEqual(0.5f, color.G, "The G property of Black is not correct here.");
            Assert.AreEqual(0.5f, color.B, "The B property of Black is not correct here.");
            Assert.AreEqual(1.0f, color.A, "The A property of Black is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("dali color constructor test.Check whether color object which initialized with float array is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Color.Color C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single[]")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Color_INIT_WITH_SINGLE_ARRAY()
        {
            /* TEST CODE */
            float[] array = new float[4] { 0.5f, 0.5f, 0.5f, 1.0f };
            var color = new Color(array);
            Assert.IsInstanceOf<Color>(color, "Should return Color instance.");
            Assert.AreEqual(0.5f, color.R, "The R property of Black is not correct here.");
            Assert.AreEqual(0.5f, color.G, "The G property of Black is not correct here.");
            Assert.AreEqual(0.5f, color.B, "The B property of Black is not correct here.");
            Assert.AreEqual(1.0f, color.A, "The A property of Black is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test R. Check whether R is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Color.R A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void R_SET_GET_VALUE()
        {
            /* TEST CODE */
            Color color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
            Assert.AreEqual(0.5f, color.R, "The R property of color is not correct.");

            color.R = 0.4f;
            Assert.AreEqual(0.4f, color.R, "The R property of color is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test G. Check whether G is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Color.G A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void G_SET_GET_VALUE()
        {
            /* TEST CODE */
            Color color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
            Assert.AreEqual(0.5f, color.G, "The G property of color is not correct.");

            color.G = 0.4f;
            Assert.AreEqual(0.4f, color.G, "The G property of color is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test B. Check whether B is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Color.B A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void B_SET_GET_VALUE()
        {
            /* TEST CODE */
            Color color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
            Assert.AreEqual(0.5f, color.B, "The B property of color is not correct.");

            color.B = 0.4f;
            Assert.AreEqual(0.4f, color.B, "The B property of color is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test A. Check whether A is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Color.A A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void A_SET_GET_VALUE()
        {
            /* TEST CODE */
            Color color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
            Assert.AreEqual(1.0f, color.A, "The A property of color is not correct.");

            color.A = 0.4f;
            Assert.AreEqual(0.4f, color.A, "The A property of color is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Black. Check whether Black returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Color.Black A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Black_GET_VALUE()
        {
            /* TEST CODE */
            Color color = Color.Black;
            Assert.AreEqual(0.0f, color.R, "The R property of Black is not correct here.");
            Assert.AreEqual(0.0f, color.G, "The G property of Black is not correct here.");
            Assert.AreEqual(0.0f, color.B, "The B property of Black is not correct here.");
            Assert.AreEqual(1.0f, color.A, "The A property of Black is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test White. Check whether returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Color.White A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void White_GET_VALUE()
        {
            /* TEST CODE */
            Color color = Color.White;
            Assert.AreEqual(1.0f, color.R, "The R property of White is not correct here.");
            Assert.AreEqual(1.0f, color.G, "The G property of White is not correct here.");
            Assert.AreEqual(1.0f, color.B, "The B property of White is not correct here.");
            Assert.AreEqual(1.0f, color.A, "The A property of White is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Red. Check whether Red returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Color.Red A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Red_GET_VALUE()
        {
            /* TEST CODE */
            Color color = Color.Red;
            Assert.AreEqual(1.0f, color.R, "The R property of Red is not correct here.");
            Assert.AreEqual(0.0f, color.G, "The G property of Red is not correct here.");
            Assert.AreEqual(0.0f, color.B, "The B property of Red is not correct here.");
            Assert.AreEqual(1.0f, color.A, "The A property of Red is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Green. Check whether Green returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Color.Green A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Green_GET_VALUE()
        {
            /* TEST CODE */
            Color color = Color.Green;
            Assert.AreEqual(0.0f, color.R, "The R property of Green is not correct here.");
            Assert.AreEqual(1.0f, color.G, "The G property of Green is not correct here.");
            Assert.AreEqual(0.0f, color.B, "The B property of Green is not correct here.");
            Assert.AreEqual(1.0f, color.A, "The A property of Green is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Blue. Check whether Blue returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Color.Blue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Blue_GET_VALUE()
        {
            /* TEST CODE */
            Color color = Color.Blue;
            Assert.AreEqual(0.0f, color.R, "The R property of Blue is not correct here.");
            Assert.AreEqual(0.0f, color.G, "The G property of Blue is not correct here.");
            Assert.AreEqual(1.0f, color.B, "The B property of Blue is not correct here.");
            Assert.AreEqual(1.0f, color.A, "The A property of Blue is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Yellow. Check whether Yellow returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Color.Yellow A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Yellow_GET_VALUE()
        {
            /* TEST CODE */
            Color color = Color.Yellow;
            Assert.AreEqual(1.0f, color.R, "The R property of Yellow is not correct here.");
            Assert.AreEqual(1.0f, color.G, "The G property of Yellow is not correct here.");
            Assert.AreEqual(0.0f, color.B, "The B property of Yellow is not correct here.");
            Assert.AreEqual(1.0f, color.A, "The A property of Yellow is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Magenta. Check whether Magenta returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Color.Magenta A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Magenta_GET_VALUE()
        {
            /* TEST CODE */
            Color color = Color.Magenta;
            Assert.AreEqual(1.0f, color.R, "The R property of Magenta is not correct here.");
            Assert.AreEqual(0.0f, color.G, "The G property of Magenta is not correct here.");
            Assert.AreEqual(1.0f, color.B, "The B property of Magenta is not correct here.");
            Assert.AreEqual(1.0f, color.A, "The A property of Magenta is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Cyan. Check whether Cyan returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Color.Cyan A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Cyan_GET_VALUE()
        {
            /* TEST CODE */
            Color color = Color.Cyan;
            Assert.AreEqual(0.0f, color.R, "The R property of Cyan is not correct here.");
            Assert.AreEqual(1.0f, color.G, "The G property of Cyan is not correct here.");
            Assert.AreEqual(1.0f, color.B, "The B property of Cyan is not correct here.");
            Assert.AreEqual(1.0f, color.A, "The A property of Cyan is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Transparent. Check whether Transparent returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Color.Transparent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Transparent_GET_VALUE()
        {
            /* TEST CODE */
            Color color = Color.Transparent;
            Assert.AreEqual(0.0f, color.R, "The R property of Transparent is not correct here.");
            Assert.AreEqual(0.0f, color.G, "The G property of Transparent is not correct here.");
            Assert.AreEqual(0.0f, color.B, "The B property of Transparent is not correct here.");
            Assert.AreEqual(0.0f, color.A, "The A property of Transparent is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test this[uint index]. Check whether this[uint index] returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Color.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void this_GET_VALUE()
        {
            /* TEST CODE */
            Color color = new Color(0.1f, 0.2f, 0.3f, 0.4f);
            Assert.AreEqual(0.1f, color[0], "The value of index[0] is not correct!");
            Assert.AreEqual(0.2f, color[1], "The value of index[1] is not correct!");
            Assert.AreEqual(0.3f, color[2], "The value of index[2] is not correct!");
            Assert.AreEqual(0.4f, color[3], "The value of index[3] is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator +.")]
        [Property("SPEC", "Tizen.NUI.Color.Addition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Addition_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Color color1 = new Color(0.1f, 0.2f, 0.3f, 0.4f);
            Color color2 = new Color(0.4f, 0.3f, 0.5f, 0.6f);
            Color color = color1 + color2;
            Assert.AreEqual(0.5f, color.R, "The R value of the color is not correct!");
            Assert.AreEqual(0.5f, color.G, "The G value of the color is not correct!");
            Assert.AreEqual(0.8f, color.B, "The B value of the color is not correct!");
            Assert.AreEqual(1.0f, color.A, "The A value of the color is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator -.")]
        [Property("SPEC", "Tizen.NUI.Color.Subtraction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Subtraction_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Color color1 = new Color(0.1f, 0.2f, 0.3f, 0.4f);
            Color color2 = new Color(0.4f, 0.3f, 0.5f, 0.6f);
            Color color = color2 - color1;
            Assert.Less(Math.Abs(0.3f - color.R), 0.001f, "The R value of the color is not correct!");
            Assert.Less(Math.Abs(0.1f - color.G), 0.001f, "The G value of the color is not correct!");
            Assert.Less(Math.Abs(0.2f - color.B), 0.001f, "The B value of the color is not correct!");
            Assert.Less(Math.Abs(0.2f - color.A), 0.001f, "The A value of the color is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator -.")]
        [Property("SPEC", "Tizen.NUI.Color.UnaryNegation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void UnaryNegation_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Color color1 = new Color(0.1f, 0.2f, 0.3f, 0.4f);
            Color color = -color1;
            Assert.AreEqual(0.0f, color.R, "The R value of the color is not correct!");
            Assert.AreEqual(0.0f, color.G, "The G value of the color is not correct!");
            Assert.AreEqual(0.0f, color.B, "The B value of the color is not correct!");
            Assert.AreEqual(0.0f, color.A, "The A value of the color is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator *.")]
        [Property("SPEC", "Tizen.NUI.Color.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Color, Color")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Multiply_VECTOR3_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Color color1 = new Color(0.1f, 0.2f, 0.3f, 0.1f);
            Color color2 = new Color(0.4f, 0.3f, 0.2f, 0.6f);
            Color color = color2 * color1;
            Assert.AreEqual(0.04f, color.R, 0.00001, "The R value of the color is not correct!");
            Assert.AreEqual(0.06f, color.G, 0.00001, "The G value of the color is not correct!");
            Assert.AreEqual(0.06f, color.B, 0.00001, "The B value of the color is not correct!");
            Assert.AreEqual(0.06f, color.A, 0.00001, "The A value of the color is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator *.")]
        [Property("SPEC", "Tizen.NUI.Color.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Color, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Multiply_FLOAT_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Color color1 = new Color(0.1f, 0.2f, 0.3f, 0.1f);
            float number = 2.0f;
            Color color = color1 * number;
            Assert.Less(Math.Abs(0.2f - color.R), 0.001f, "The R value of the color is not correct!");
            Assert.Less(Math.Abs(0.4f - color.G), 0.001f, "The G value of the color is not correct!");
            Assert.Less(Math.Abs(0.6f - color.B), 0.001f, "The B value of the color is not correct!");
            Assert.Less(Math.Abs(0.2f - color.A), 0.001f, "The A value of the color is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator /.")]
        [Property("SPEC", "Tizen.NUI.Color.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Color, Color")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Division_VECTOR3_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Color color1 = new Color(0.2f, 0.2f, 0.3f, 0.1f);
            Color color2 = new Color(0.04f, 0.06f, 0.06f, 0.06f);
            Color color = color2 / color1;
            Assert.Less(Math.Abs(0.2f - color.R), 0.001f, "The R value of the color is not correct!");
            Assert.Less(Math.Abs(0.3f - color.G), 0.001f, "The G value of the color is not correct!");
            Assert.Less(Math.Abs(0.2f - color.B), 0.001f, "The B value of the color is not correct!");
            Assert.Less(Math.Abs(0.6f - color.A), 0.001f, "The A value of the color is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator /.")]
        [Property("SPEC", "Tizen.NUI.Color.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Color, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Division_FLOAT_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Color color1 = new Color(0.2f, 0.2f, 0.4f, 0.6f);
            float number = 2.0f;
            Color color = color1 / number;
            Assert.Less(Math.Abs(0.1f - color.R), 0.001f, "The R value of the color is not correct!");
            Assert.Less(Math.Abs(0.1f - color.G), 0.001f, "The G value of the color is not correct!");
            Assert.Less(Math.Abs(0.2f - color.B), 0.001f, "The B value of the color is not correct!");
            Assert.Less(Math.Abs(0.3f - color.A), 0.001f, "The A value of the color is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test EqualTo. Try to compare two color instance by EqualTo.")]
        [Property("SPEC", "Tizen.NUI.Color.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void EqualTo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Color color1 = new Color(0.1f, 0.2f, 0.3f, 0.4f);
            Color color2 = new Color(0.1f, 0.2f, 0.3f, 0.4f);
            Assert.IsTrue((color1.EqualTo(color2)), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test NotEqualTo. Try to compare two color instance by NotEqualTo.")]
        [Property("SPEC", "Tizen.NUI.Color.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void NotEqualTo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Color color1 = new Color(0.1f, 0.2f, 0.3f, 0.4f);
            Color color2 = new Color(0.4f, 0.3f, 0.2f, 0.1f);
            Assert.IsTrue((color1.NotEqualTo(color2)), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test implicit vector4. Try to convert a vector4 instance to a color instance.")]
        [Property("SPEC", "Tizen.NUI.Color.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector4")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void implicit_VECTOR4_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector4 vector = new Vector4(0.1f, 0.2f, 0.3f, 0.4f);
            Color color = vector;
            Assert.AreEqual(color.R, vector.R, "The value of R is not correct.");
            Assert.AreEqual(color.G, vector.G, "The value of G is not correct.");
            Assert.AreEqual(color.B, vector.B, "The value of B is not correct.");
            Assert.AreEqual(color.A, vector.A, "The value of A is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test implicit color. Try to convert a color instance to a vector4 instance.")]
        [Property("SPEC", "Tizen.NUI.Color.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Color")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void implicit_COLOR_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Color color = new Color(0.1f, 0.2f, 0.3f, 0.4f);
            Vector4 vector = color;
            Assert.AreEqual(color.R, vector.R, "The value of R is not correct.");
            Assert.AreEqual(color.G, vector.G, "The value of G is not correct.");
            Assert.AreEqual(color.B, vector.B, "The value of B is not correct.");
            Assert.AreEqual(color.A, vector.A, "The value of A is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Color.")]
        [Property("SPEC", "Tizen.NUI.Color.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                Color color = new Color();
                color.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
    }
}
