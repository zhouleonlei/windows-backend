using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using System.Runtime.InteropServices;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.Size Tests")]
    public class SizeTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("SizeTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali size constructor test")]
        [Property("SPEC", "Tizen.NUI.Size.Size C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Size_INIT()
        {
            /* TEST CODE */
            var size = new Size();
            Assert.IsInstanceOf<Size>(size, "Should return Size instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali size constructor, with three float value parameters test")]
        [Property("SPEC", "Tizen.NUI.Size.Size C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single, Single, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Size_INIT_WITH_FLOAT_FLOAT_FLOAT()
        {
            /* TEST CODE */
            var size = new Size(100.0f, 100.0f, 100.0f);
            Assert.IsInstanceOf<Size>(size, "Should return Size instance.");
            Assert.AreEqual(100.0f, size.Width, "The Width property of position is not correct here.");
            Assert.AreEqual(100.0f, size.Height, "The Height property of position is not correct here.");
            Assert.AreEqual(100.0f, size.Depth, "The Depth property of position is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("dali size constructor, with a Size2D instance.")]
        [Property("SPEC", "Tizen.NUI.Size.Size C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Size2D")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Size_INIT_WITH_Size2D()
        {
            /* TEST CODE */
            Size2D size2D = new Size2D(100, 100);
            var size = new Size(size2D);
            Assert.IsInstanceOf<Size>(size, "Should return Size instance.");
            Assert.AreEqual(100.0f, size.Width, "The Width property of position is not correct here.");
            Assert.AreEqual(100.0f, size.Height, "The Height property of position is not correct here.");
            Assert.AreEqual(0.0f, size.Depth, "The Depth property of position is not correct here.");
        }


        [Test]
        [Category("P1")]
        [Description("Test Width. Check whether Width is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Size.Width A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Width_SET_GET_VALUE()
        {
            /* TEST CODE */
            Size size = new Size(100.0f, 100.0f, 100.0f);
            Assert.AreEqual(100.0f, size.Width, "The Width should be 100.0f here!");

            size.Width = 200.0f;
            Assert.AreEqual(200.0f, size.Width, "The Width should be 100.0f here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Height. Check whether Height is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Size.Height A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Height_SET_GET_VALUE()
        {
            /* TEST CODE */
            Size size = new Size(100.0f, 100.0f, 100.0f);
            Assert.AreEqual(100.0f, size.Height, "The Height should be 100.0f here!");

            size.Height = 200.0f;
            Assert.AreEqual(200.0f, size.Height, "The Height should be 200.0f here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Depth. Check whether Depth is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Size.Depth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Depth_SET_GET_VALUE()
        {
            /* TEST CODE */
            Size size = new Size(100.0f, 100.0f, 100.0f);
            Assert.AreEqual(100.0f, size.Depth, "The Depth should be 100.0f here!");

            size.Depth = 200.0f;
            Assert.AreEqual(200.0f, size.Depth, "The Depth should be 200.0f here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test EqualTo. Try to compare two Size instance by EqualTo.")]
        [Property("SPEC", "Tizen.NUI.Size.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void EqualTo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size size1 = new Size(1.0f, 2.0f, 3.0f);
            Size size2 = new Size(1.0f, 2.0f, 3.0f);
            Assert.IsTrue((size1.EqualTo(size2)), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test Equals. Try to compare two Size instance by Equals.")]
        [Property("SPEC", "Tizen.NUI.Size.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void Equals_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size size1 = new Size(1.0f, 2.0f, 3.0f);
            Size size2 = new Size(1.0f, 2.0f, 3.0f);
            Size size3 = new Size(2.0f, 2.0f, 3.0f);
            Assert.IsTrue((size1.Equals(size2)), "Should be equal");
            Assert.IsFalse((size1.Equals(size3)), "Should not be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test NotEqualTo. Try to compare two Size instance by NotEqualTo.")]
        [Property("SPEC", "Tizen.NUI.Size.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void NotEqualTo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size size1 = new Size(10.0f, 20.0f, 30.0f);
            Size size2 = new Size(1.0f, 2.0f, 3.0f);
            Assert.IsTrue((size1.NotEqualTo(size2)), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test this[uint index]. Check whether this[uint index] returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Size.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void this_GET_VALUE()
        {
            /* TEST CODE */
            Size size = new Size(20.0f, 30.0f, 50.0f);
            Assert.AreEqual(20.0f, size[0], "The value of index[0] is not correct!");
            Assert.AreEqual(30.0f, size[1], "The value of index[1] is not correct!");
            Assert.AreEqual(50.0f, size[2], "The value of index[2] is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Zero. Check whether Zero returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Size.Zero A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Zero_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Size.Zero.Width, "The value of Size.Zero.Width is not correct!");
            Assert.AreEqual(0.0f, Size.Zero.Height, "The value of Size.Zero.Height is not correct!");
            Assert.AreEqual(0.0f, Size.Zero.Depth, "The value of Size.Zero.Depth is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator +.")]
        [Property("SPEC", "Tizen.NUI.Size.Addition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Addition_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size size1 = new Size(20.0f, 30.0f, 50.0f);
            Size size2 = new Size(40.0f, 60.0f, 30.0f);
            Size size = size1 + size2;
            Assert.AreEqual(60.0f, size.Width, "The Width value of the size is not correct!");
            Assert.AreEqual(90.0f, size.Height, "The Height value of the size is not correct!");
            Assert.AreEqual(80.0f, size.Depth, "The Depth value of the size is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator -.")]
        [Property("SPEC", "Tizen.NUI.Size.Subtraction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Subtraction_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size size1 = new Size(20.0f, 30.0f, 50.0f);
            Size size2 = new Size(40.0f, 60.0f, 60.0f);
            Size size = size2 - size1;
            Assert.AreEqual(20.0f, size.Width, "The Width value of the size is not correct!");
            Assert.AreEqual(30.0f, size.Height, "The Height value of the size is not correct!");
            Assert.AreEqual(10.0f, size.Depth, "The Depth value of the size is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator -.")]
        [Property("SPEC", "Tizen.NUI.Size.UnaryNegation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void UnaryNegation_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size size1 = new Size(20.0f, 30.0f, 50.0f);
            Size size = -size1;
            Assert.AreEqual(-20.0f, size.Width, "The Width value of the size is not correct!");
            Assert.AreEqual(-30.0f, size.Height, "The Height value of the size is not correct!");
            Assert.AreEqual(-50.0f, size.Depth, "The Depth value of the size is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator *. Test multiply an another Size instance.")]
        [Property("SPEC", "Tizen.NUI.Size.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Size, Size")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Multiply_Size_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size size1 = new Size(20.0f, 30.0f, 50.0f);
            Size size2 = new Size(40.0f, 60.0f, 60.0f);
            Size size = size2 * size1;
            Assert.AreEqual(800.0f, size.Width, "The Width value of the size is not correct!");
            Assert.AreEqual(1800.0f, size.Height, "The Height value of the size is not correct!");
            Assert.AreEqual(3000.0f, size.Depth, "The Depth value of the size is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator *.")]
        [Property("SPEC", "Tizen.NUI.Size.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Size, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Multiply_FLOAT_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size size1 = new Size(20.0f, 30.0f, 50.0f);
            Size size = size1 * 10.0f;
            Assert.AreEqual(200.0f, size.Width, "The Width value of the size is not correct!");
            Assert.AreEqual(300.0f, size.Height, "The Height value of the size is not correct!");
            Assert.AreEqual(500.0f, size.Depth, "The Depth value of the size is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator /. Test divide another size instance.")]
        [Property("SPEC", "Tizen.NUI.Size.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Size, Size")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Division_SIZE_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size size1 = new Size(20.0f, 30.0f, 20.0f);
            Size size2 = new Size(40.0f, 60.0f, 60.0f);
            Size size = size2 / size1;
            Assert.AreEqual(2.0f, size.Width, "The Width value of the size is not correct!");
            Assert.AreEqual(2.0f, size.Height, "The Height value of the size is not correct!");
            Assert.AreEqual(3.0f, size.Depth, "The Depth value of the size is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator /.")]
        [Property("SPEC", "Tizen.NUI.Size.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Size, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Division_FLOAT_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size size1 = new Size(20.0f, 30.0f, 20.0f);
            Size size = size1 / 10.0f;
            Assert.AreEqual(2.0f, size.Width, "The Width value of the size is not correct!");
            Assert.AreEqual(3.0f, size.Height, "The Height value of the size is not correct!");
            Assert.AreEqual(2.0f, size.Depth, "The Depth value of the size is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test implicit vector3. Try to convert a vector3 instance to a size instance.")]
        [Property("SPEC", "Tizen.NUI.Size.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector3")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void implicit_VECTOR3_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector3 vector = new Vector3(10.0f, 20.0f, 30.0f);
            Size size = vector;
            Assert.AreEqual(vector.X, size.Width, "The value of Width is not correct.");
            Assert.AreEqual(vector.Y, size.Height, "The value of Height is not correct.");
            Assert.AreEqual(vector.Z, size.Depth, "The value of Depth is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test implicit size. Try to convert a size instance to a vector3 instance.")]
        [Property("SPEC", "Tizen.NUI.Size.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Size")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void implicit_SIZE_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Size size = new Size(10.0f, 20.0f, 30.0f);
            Vector3 vector = size;
            Assert.AreEqual(size.Width, vector.X, "The value of X is not correct.");
            Assert.AreEqual(size.Height, vector.Y, "The value of Y is not correct.");
            Assert.AreEqual(size.Depth, vector.Z, "The value of Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Size.")]
        [Property("SPEC", "Tizen.NUI.Size.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                Size size = new Size();
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
        [Property("SPEC", "Tizen.NUI.Size.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetHashCode_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var size = new Size(10.0f, 20.0f, 30.0f);
            var hash = size.GetHashCode();
            Assert.IsNotNull(size, "Can't create success object Size");
            Assert.IsInstanceOf<Size>(size, "Should be an instance of Size type.");
            Assert.IsTrue(hash >= Int32.MinValue && hash <= Int32.MaxValue, "The value of hash is out of Integer range");
        }
    }
}

