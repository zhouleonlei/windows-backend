using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using System.Runtime.InteropServices;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.Position2D Tests")]
    public class Position2DTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("Position2DTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali Position2D constructor test")]
        [Property("SPEC", "Tizen.NUI.Position2D.Position2D C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Position2D_INIT()
        {
            /* TEST CODE */
            var position = new Position2D();
            Assert.IsInstanceOf<Position2D>(position, "Should return Position2D instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali Position2D constructor test, with two int value")]
        [Property("SPEC", "Tizen.NUI.Position2D.Position2D C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "int, int")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Position2D_INIT_WITH_INT_INT()
        {
            /* TEST CODE */
            var position = new Position2D(2, 3);
            Assert.IsInstanceOf<Position2D>(position, "Should return Position2D instance.");
            Assert.AreEqual(2, position.X, "The X property of position is not correct here.");
            Assert.AreEqual(3, position.Y, "The Y property of position is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("dali Position2D constructor test, with a Position instance.")]
        [Property("SPEC", "Tizen.NUI.Position2D.Position2D C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Position")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Position2D_INIT_WITH_Position()
        {
            /* TEST CODE */
            Position position = new Position(5.0f, 5.0f, 0.5f);
            var position2D = new Position2D(position);
            Assert.IsInstanceOf<Position2D>(position2D, "Should return Position2D instance.");
            Assert.AreEqual(5, position.X, "The X property of position is not correct here.");
            Assert.AreEqual(5, position.Y, "The Y property of position is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test X. Check whether X is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Position2D.X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void X_SET_GET_VALUE()
        {
            /* TEST CODE */
            Position2D position = new Position2D(2, 3);

            Assert.AreEqual(2, position.X, "The X property of position is not correct here.");

            position.X = 3;
            Assert.AreEqual(3, position.X, "The X property of position is not correct.");
        }
        [Test]
        [Category("P1")]
        [Description("Test Y. Check whether Y is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Position2D.Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Y_SET_GET_VALUE()
        {
            /* TEST CODE */
            Position2D position = new Position2D(2, 3);

            Assert.AreEqual(3, position.Y, "The Y property of position is not correct here.");

            position.Y = 2;
            Assert.AreEqual(2, position.Y, "The Y property of position is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test EqualTo. Try to compare two Position2D instance by EqualTo.")]
        [Property("SPEC", "Tizen.NUI.Position2D.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void EqualTo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position2D position1 = new Position2D(1, 2);
            Position2D position2 = new Position2D(1, 2);
            Assert.IsTrue((position1.EqualTo(position2)), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test NotEqualTo. Try to compare two Position2D instance by NotEqualTo.")]
        [Property("SPEC", "Tizen.NUI.Position2D.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void NotEqualTo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position2D position1 = new Position2D(10, 20);
            Position2D position2 = new Position2D(1, 2);
            Assert.IsTrue((position1.NotEqualTo(position2)), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator +.")]
        [Property("SPEC", "Tizen.NUI.Position2D.Addition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Addition_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position2D position1 = new Position2D(2, 3);
            Position2D position2 = new Position2D(4, 6);
            Position2D position = position1 + position2;
            Assert.AreEqual(6, position.X, "The X value of the position is not correct!");
            Assert.AreEqual(9, position.Y, "The Y value of the position is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test ConvertFromString, Check whether ConvertFromString returns expected value or not")]
        [Property("SPEC", "Tizen.NUI.Position2D.ConvertFromString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void ConvertFromString_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position2D position1 = new Position2D(2, 3);
            var position2 = Position2D.ConvertFromString("2,3");
            Assert.AreEqual(position1, position2, "The value of the position2 is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator -.")]
        [Property("SPEC", "Tizen.NUI.Position2D.Subtraction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Subtraction_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position2D position1 = new Position2D(2, 3);
            Position2D position2 = new Position2D(4, 6);
            Position2D position = position2 - position1;
            Assert.AreEqual(2, position.X, "The X value of the position is not correct!");
            Assert.AreEqual(3, position.Y, "The Y value of the position is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator -.")]
        [Property("SPEC", "Tizen.NUI.Position2D.UnaryNegation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void UnaryNegation_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position2D position1 = new Position2D(2, 3);
            Position2D position = -position1;
            Assert.AreEqual(-2, position.X, "The X value of the position is not correct!");
            Assert.AreEqual(-3, position.Y, "The Y value of the position is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator *.")]
        [Property("SPEC", "Tizen.NUI.Position2D.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Position2D, Position2D")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Multiply_POSITION2D_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position2D position1 = new Position2D(2, 3);
            Position2D position2 = new Position2D(4, 6);
            Position2D position = position2 * position1;
            Assert.AreEqual(8, position.X, "The X value of the position is not correct!");
            Assert.AreEqual(18, position.Y, "The Y value of the position is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator *.")]
        [Property("SPEC", "Tizen.NUI.Position2D.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Position2D, int")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Multiply_INT_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position2D position1 = new Position2D(2, 3);
            Position2D position = position1 * 10;
            Assert.AreEqual(20, position.X, "The X value of the position is not correct!");
            Assert.AreEqual(30, position.Y, "The Y value of the position is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator /.")]
        [Property("SPEC", "Tizen.NUI.Position2D.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Position2D, Position2D")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Division_POSITION2D_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position2D position1 = new Position2D(2, 3);
            Position2D position2 = new Position2D(4, 6);
            Position2D position = position2 / position1;
            Assert.AreEqual(2, position.X, "The X value of the position is not correct!");
            Assert.AreEqual(2, position.Y, "The Y value of the position is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator /.")]
        [Property("SPEC", "Tizen.NUI.Position2D.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Position2D, int")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Division_INT_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position2D position1 = new Position2D(20, 30);
            Position2D position = position1 / 10;
            Assert.AreEqual(2, position.X, "The X value of the position is not correct!");
            Assert.AreEqual(3, position.Y, "The Y value of the position is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test this[uint index]. Check whether this[uint index] returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position2D.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void this_GET_VALUE()
        {
            /* TEST CODE */
            Position2D position = new Position2D(100, 300);
            Assert.AreEqual(100, position[0], "The value of index[0] is not correct!");
            Assert.AreEqual(300, position[1], "The value of index[1] is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Equals. Check whether Equals returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position2D.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Equals_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position2D position1 = new Position2D(1, 1);
            Position2D position2 = new Position2D(1, 1);

            bool flag = position1.Equals(position2);
            Assert.IsTrue(flag, "Should be true here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test implicit vector2. Try to convert a vector2 instance to a position2D instance.")]
        [Property("SPEC", "Tizen.NUI.Position2D.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void implicit_VECTOR2_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector2 vector = new Vector2(10, 20);
            Position2D position2D = vector;
            Assert.AreEqual(position2D.X, vector.X, "The value of X is not correct.");
            Assert.AreEqual(position2D.Y, vector.Y, "The value of Y is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test implicit position2D. Try to convert a position2D instance to a vector2 instance.")]
        [Property("SPEC", "Tizen.NUI.Position2D.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Position2D")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void implicit_POSITION2D_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position2D position = new Position2D(10, 20);
            Vector2 vector = position;
            Assert.AreEqual(position.X, vector.X, "The value of X is not correct.");
            Assert.AreEqual(position.Y, vector.Y, "The value of Y is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test implicit string, Try to convert a string instance to a position2D instance.")]
        [Property("SPEC", "Tizen.NUI.Position2D.Implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "string")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void Implicit_STRING_RETURN_VALUE()
        {
            /* TEST CODE */
            string position = "10, 20";
            Position2D position2D = position;
            Assert.AreEqual(position2D.X, 10, "The value of X is not correct.");
            Assert.AreEqual(position2D.Y, 20, "The value of Y is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Position2D.")]
        [Property("SPEC", "Tizen.NUI.Position2D.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                Position2D position = new Position2D();
                position.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test GetHashCode. Check whether GetHashCode returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position2D.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetHashCode_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var position = new Position2D(10, 20);
            var hash = position.GetHashCode();
            Assert.IsNotNull(position, "Can't create success object Position2D");
            Assert.IsInstanceOf<Position2D>(position, "Should be an instance of Position2D type.");
            Assert.IsTrue(hash >= Int32.MinValue && hash <= Int32.MaxValue, "The value of hash is out of Integer range");
        }
    }
}
