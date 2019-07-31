using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using System.Runtime.InteropServices;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.Size2D Tests")]
    public class Size2DTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("Size2DTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali size2D constructor test")]
        [Property("SPEC", "Tizen.NUI.Size2D.Size2D C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Size2D_INIT()
        {
            /* TEST CODE */
            var size = new Size2D();
            Assert.IsInstanceOf<Size2D>(size, "Should return Size2D instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali size2D constructor, with two int value")]
        [Property("SPEC", "Tizen.NUI.Size2D.Size2D C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "int, int")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Size2D_INIT_WITH_INT_INT()
        {
            /* TEST CODE */
            var size = new Size2D(100, 100);
            Assert.IsInstanceOf<Size2D>(size, "Should return Size2D instance.");
            Assert.AreEqual(100, size.Height, "The Height property of position is not correct here.");
            Assert.AreEqual(100, size.Width, "The Width property of position is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Width. Check whether Width is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Size2D.Width A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Width_SET_GET_VALUE()
        {
            /* TEST CODE */
            Size2D size = new Size2D(100, 100);
            Assert.AreEqual(100, size.Width, "The Width should be 100.0f here!");

            size.Width = 200;
            Assert.AreEqual(200, size.Width, "The Width should be 200.0f here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Height. Check whether Height is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Size2D.Height A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Height_SET_GET_VALUE()
        {
            /* TEST CODE */
            Size2D size = new Size2D(100, 100);
            Assert.AreEqual(100.0f, size.Height, "The Height should be 100.0f here!");

            size.Height = 200;
            Assert.AreEqual(200, size.Height, "The Height should be 200.0f here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test EqualTo. Try to compare two Size2D instance by EqualTo.")]
        [Property("SPEC", "Tizen.NUI.Size2D.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void EqualTo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size2D size1 = new Size2D(1, 2);
            Size2D size2 = new Size2D(1, 2);
            Assert.IsTrue((size1.EqualTo(size2)), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test NotEqualTo. Try to compare two Size2D instance by NotEqualTo.")]
        [Property("SPEC", "Tizen.NUI.Size2D.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void NotEqualTo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size2D size1 = new Size2D(10, 20);
            Size2D size2 = new Size2D(1, 2);
            Assert.IsTrue((size1.NotEqualTo(size2)), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator +.")]
        [Property("SPEC", "Tizen.NUI.Size2D.Addition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Addition_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size2D size1 = new Size2D(2, 3);
            Size2D size2 = new Size2D(4, 6);
            Size2D size = size1 + size2;
            Assert.AreEqual(6, size.Width, "The Width value of the size is not correct!");
            Assert.AreEqual(9, size.Height, "The Height value of the size is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator -.")]
        [Property("SPEC", "Tizen.NUI.Size2D.Subtraction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Subtraction_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size2D size1 = new Size2D(2, 3);
            Size2D size2 = new Size2D(4, 6);
            Size2D size = size2 - size1;
            Assert.AreEqual(2, size.Width, "The Width value of the size is not correct!");
            Assert.AreEqual(3, size.Height, "The Height value of the size is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator -.")]
        [Property("SPEC", "Tizen.NUI.Size2D.UnaryNegation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void UnaryNegation_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size2D size1 = new Size2D(2, 3);
            Size2D size = -size1;
            Assert.AreEqual(-2, size.Width, "The Width value of the size is not correct!");
            Assert.AreEqual(-3, size.Height, "The Height value of the size is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator *.")]
        [Property("SPEC", "Tizen.NUI.Size2D.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Size2D, Size2D")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Multiply_SIZE2D_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size2D size1 = new Size2D(2, 3);
            Size2D size2 = new Size2D(4, 6);
            Size2D size = size2 * size1;
            Assert.AreEqual(8, size.Width, "The Width value of the size is not correct!");
            Assert.AreEqual(18, size.Height, "The Height value of the size is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator *.")]
        [Property("SPEC", "Tizen.NUI.Size2D.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Size2D, int")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Multiply_INT_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size2D size1 = new Size2D(2, 3);
            Size2D size = size1 * 2;
            Assert.AreEqual(4, size.Width, "The Width value of the size is not correct!");
            Assert.AreEqual(6, size.Height, "The Height value of the size is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator /.")]
        [Property("SPEC", "Tizen.NUI.Size2D.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Size2D, Size2D")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Division_SIZE2D_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size2D size1 = new Size2D(2, 3);
            Size2D size2 = new Size2D(4, 6);
            Size2D size = size2 / size1;
            Assert.AreEqual(2, size.Width, "The Width value of the size is not correct!");
            Assert.AreEqual(2, size.Height, "The Height value of the size is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator /.")]
        [Property("SPEC", "Tizen.NUI.Size2D.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Size2D, int")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Division_INT_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size2D size2 = new Size2D(4, 6);
            Size2D size = size2 / 2;
            Assert.AreEqual(2, size.Width, "The Width value of the size is not correct!");
            Assert.AreEqual(3, size.Height, "The Height value of the size is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test this[uint index]. Check whether this[uint index] returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Size2D.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void this_GET_VALUE()
        {
            /* TEST CODE */
            Size2D size = new Size2D(100, 300);
            Assert.AreEqual(100, size[0], "The value of index[0] is not correct!");
            Assert.AreEqual(300, size[1], "The value of index[1] is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Equals. Check whether Equals returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Size2D.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Equals_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size2D size1 = new Size2D(1, 1);
            Size2D size2 = new Size2D(1, 1);

            bool flag = size1.Equals(size2);
            Assert.IsTrue(flag, "Should be true here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test implicit vector2. Try to convert a vector2 instance to a size2D instance.")]
        [Property("SPEC", "Tizen.NUI.Size2D.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void implicit_VECTOR2_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector2 vector = new Vector2(10, 20);
            Size2D size = vector;
            Assert.AreEqual(vector.X, size.Width, "The value of Width is not correct.");
            Assert.AreEqual(vector.Y, size.Height, "The value of Height is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test implicit size. Try to convert a size2D instance to a vector2 instance.")]
        [Property("SPEC", "Tizen.NUI.Size2D.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Size2D")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void implicit_SIZE2D_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size2D size = new Size2D(10, 20);
            Vector2 vector = size;
            Assert.AreEqual(size.Width, vector.X, "The value of X is not correct.");
            Assert.AreEqual(size.Height, vector.Y, "The value of Y is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Size2D.")]
        [Property("SPEC", "Tizen.NUI.Size2D.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                Size2D size = new Size2D();
                size.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test GetHashCode. Check whether GetHashCode returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Size2D.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetHashCode_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var size = new Size2D(10, 20);
            var hash = size.GetHashCode();
            Assert.IsNotNull(size, "Can't create success object Size2D");
            Assert.IsInstanceOf<Size2D>(size, "Should be an instance of Size2D type.");
            Assert.IsTrue(hash >= Int32.MinValue && hash <= Int32.MaxValue, "The value of hash is out of Integer range");
        }
    }
}