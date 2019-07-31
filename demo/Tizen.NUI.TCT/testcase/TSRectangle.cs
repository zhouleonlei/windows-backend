using NUnit.Framework;
using Tizen.NUI;
using System;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.Rectangle Tests")]
    public class RectangleTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("RectangleTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator ==. Check whether operator == returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.operator == M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void OperatorEquals_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rectangle rectangle1 = new Rectangle(5, 6, 100, 200);
            Rectangle rectangle2 = new Rectangle(5, 6, 100, 200);
            bool value1 = (rectangle1 == rectangle2);
            Assert.IsTrue(value1, "this two Rectangle is not equal");
            Rectangle rectangle3 = new Rectangle(5, 6, 200, 200);
            bool value2 = (rectangle1 == rectangle3);
            Assert.IsFalse(value2, "this two Rectangle is equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator !=. Check whether operator != returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.operator != M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void OperatorNotEquals_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rectangle rectangle1 = new Rectangle(5, 6, 100, 200);
            Rectangle rectangle2 = new Rectangle(5, 6, 100, 200);
            bool value1 = (rectangle1 != rectangle2);
            Assert.IsFalse(value1, "this two Rectangle is not equal");
            Rectangle rectangle3 = new Rectangle(5, 6, 200, 200);
            bool value2 = (rectangle1 != rectangle3);
            Assert.IsTrue(value2, "this two Rectangle is equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test X. Check whether X is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void X_SET_GET_VALUE()
        {
            /* TEST CODE */
            Rectangle rectangle = new Rectangle(5, 6, 100, 200);
            Assert.AreEqual(5, rectangle.X, "The X value of the Rectangle is not correct!");
            rectangle.X = 10;
            Assert.AreEqual(10, rectangle.X, "The X value of the Rectangle is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Y. Check whether Y is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Y_SET_GET_VALUE()
        {
            /* TEST CODE */
            Rectangle rectangle = new Rectangle(5, 6, 100, 200);
            Assert.AreEqual(6, rectangle.Y, "The Y value of the Rectangle is not correct!");
            rectangle.Y = 10;
            Assert.AreEqual(10, rectangle.Y, "The Y value of the Rectangle is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Width. Check whether Width is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Width A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Width_SET_GET_VALUE()
        {
            /* TEST CODE */
            Rectangle rectangle = new Rectangle(5, 6, 100, 200);
            Assert.AreEqual(100, rectangle.Width, "The Width value of the Rectangle is not correct!");
            rectangle.Width = 150;
            Assert.AreEqual(150, rectangle.Width, "The Width value of the Rectangle is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Height. Check whether Height is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Height A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Height_SET_GET_VALUE()
        {
            /* TEST CODE */
            Rectangle rectangle = new Rectangle(5, 6, 100, 200);
            Assert.AreEqual(200, rectangle.Height, "The Height value of the Rectangle is not correct!");
            rectangle.Height = 250;
            Assert.AreEqual(250, rectangle.Height, "The Height value of the Rectangle is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("dali Rectangle constructor test")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Rectangle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Rectangle_INIT_WITH_NULL()
        {
            /* TEST CODE */
            Rectangle rectangle = new Rectangle();
            Assert.IsInstanceOf<Rectangle>(rectangle, "Should return Rectangle instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali Rectangle constructor with four int parameter test")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Rectangle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "int, int, int, int")]
        public void Rectangle_INIT_WITH_INT_INT_INT_INT()
        {
            /* TEST CODE */
            var rectangle = new Rectangle(2, 3, 100, 200);
            Assert.IsInstanceOf<Rectangle>(rectangle, "Should return Rectangle instance.");
            Assert.AreEqual(2, rectangle.X, "The X value of the Rectangle is not correct!");
            Assert.AreEqual(3, rectangle.Y, "The Y value of the Rectangle is not correct!");
            Assert.AreEqual(100, rectangle.Width, "The Width value of the Rectangle is not correct!");
            Assert.AreEqual(200, rectangle.Height, "The Height value of the Rectangle is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Set. Check whether Set returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Set_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rectangle rectangle = new Rectangle(2, 3, 100, 200);
            Assert.AreEqual(2, rectangle.X, "The X value of the Rectangle is not correct!");
            Assert.AreEqual(3, rectangle.Y, "The Y value of the Rectangle is not correct!");
            Assert.AreEqual(100, rectangle.Width, "The Width value of the Rectangle is not correct!");
            Assert.AreEqual(200, rectangle.Height, "The Height value of the Rectangle is not correct!");
            rectangle.Set(5, 6, 300, 400);
            Assert.AreEqual(5, rectangle.X, "Set function does not work, The X value of the Rectangle is not correct!");
            Assert.AreEqual(6, rectangle.Y, "Set function does not work, The Y value of the Rectangle is not correct!");
            Assert.AreEqual(300, rectangle.Width, "Set function does not work, The Width value of the Rectangle is not correct!");
            Assert.AreEqual(400, rectangle.Height, "Set function does not work, The Height value of the Rectangle is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test IsEmpty. Check whether IsEmpty returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.IsEmpty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void IsEmpty_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rectangle rectangle1 = new Rectangle();
            Assert.AreEqual(true, rectangle1.IsEmpty(), "Rectangle is not empty");
            Rectangle rectangle2 = new Rectangle(2, 3, 100, 200);
            Assert.AreEqual(false, rectangle2.IsEmpty(), "Rectangle is empty");
            Rectangle rectangle3 = new Rectangle(2, 3, 100, 0);
            Assert.AreEqual(true, rectangle3.IsEmpty(), "Rectangle is not empty");
        }

        [Test]
        [Category("P1")]
        [Description("Test Left. Check whether Left returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Left M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Left_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rectangle rectangle = new Rectangle(2, 3, 100, 200);
            Assert.AreEqual(2, rectangle.Left(), "The Left value of the Rectangle is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Right. Check whether Right returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Right M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Right_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rectangle rectangle = new Rectangle(2, 3, 100, 200);
            Assert.AreEqual(102, rectangle.Right(), "The Right value of the Rectangle is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Top. Check whether Top returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Top M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Top_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rectangle rectangle = new Rectangle(2, 3, 100, 200);
            Assert.AreEqual(3, rectangle.Top(), "The Top value of the Rectangle is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Bottom. Check whether Bottom returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Bottom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Bottom_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rectangle rectangle = new Rectangle(2, 3, 100, 200);
            Assert.AreEqual(203, rectangle.Bottom(), "The Bottom value of the Rectangle is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Area. Check whether Area returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Area M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Area_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rectangle rectangle = new Rectangle(2, 3, 100, 200);
            Assert.AreEqual(20000, rectangle.Area(), "The Area value of the Rectangle is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Intersects. Check whether Intersects returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Intersects M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Intersects_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rectangle rectangle1 = new Rectangle(10, 20, 200, 200);
            Rectangle rectangle2 = new Rectangle(10, 120, 200, 200);
            Rectangle rectangle3 = new Rectangle(10, -80, 200, 200);
            Rectangle rectangle4 = new Rectangle(110, 20, 200, 200);
            Rectangle rectangle5 = new Rectangle(-90, 20, 200, 200);
            Rectangle rectangle6 = new Rectangle(1000, 1200, 10, 10);
            Assert.IsTrue(rectangle1.Intersects(rectangle2), "rectangle1 does not Intersect rectangle2.");
            Assert.IsTrue(rectangle1.Intersects(rectangle3), "rectangle1 does not Intersect rectangle3.");
            Assert.IsTrue(rectangle1.Intersects(rectangle4), "rectangle1 does not Intersect rectangle4.");
            Assert.IsTrue(rectangle1.Intersects(rectangle5), "rectangle1 does not Intersect rectangle5.");
            Assert.IsFalse(rectangle1.Intersects(rectangle6), "rectangle1 Intersect rectangle6.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Contains. Check whether Contains returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Contains M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Contains_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Rectangle rectangle1 = new Rectangle(10, 20, 200, 200);
            Rectangle rectangle2 = new Rectangle(10, 120, 200, 200);
            Rectangle rectangle3 = new Rectangle(10, -80, 200, 200);
            Rectangle rectangle4 = new Rectangle(110, 20, 200, 200);
            Rectangle rectangle5 = new Rectangle(-90, 20, 200, 200);
            Rectangle rectangle6 = new Rectangle(1000, 1200, 10, 10);
            Rectangle rectangle7 = new Rectangle(50, 70, 50, 50);
            Rectangle rectangle8 = new Rectangle(10, 20, 100, 100);
            Rectangle rectangle9 = new Rectangle(110, 20, 100, 100);
            Rectangle rectangle10 = new Rectangle(110, 120, 100, 100);
            Rectangle rectangle11 = new Rectangle(10, 120, 100, 100);
            Assert.IsTrue(rectangle1.Contains(rectangle1), "rectangle1 does not Contains rectangle1.");
            Assert.IsFalse(rectangle1.Contains(rectangle2), "rectangle1 Contains rectangle2.");
            Assert.IsFalse(rectangle1.Contains(rectangle3), "rectangle1 Contains rectangle3.");
            Assert.IsFalse(rectangle1.Contains(rectangle4), "rectangle1 Contains rectangle4.");
            Assert.IsFalse(rectangle1.Contains(rectangle5), "rectangle1 Contains rectangle5.");
            Assert.IsFalse(rectangle1.Contains(rectangle6), "rectangle1 Contains rectangle6.");
            Assert.IsTrue(rectangle1.Contains(rectangle7), "rectangle1 does not Contains rectangle7.");
            Assert.IsTrue(rectangle1.Contains(rectangle8), "rectangle1 does not Contains rectangle8.");
            Assert.IsTrue(rectangle1.Contains(rectangle9), "rectangle1 does not Contains rectangle9.");
            Assert.IsTrue(rectangle1.Contains(rectangle10), "rectangle1 does not Contains rectangle10.");
            Assert.IsTrue(rectangle1.Contains(rectangle11), "rectangle1 does not Contains rectangle11.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Equals. Check whether Equals returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Equals_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            /* TEST CODE */
            Rectangle rectangle1 = new Rectangle(5, 6, 100, 200);
            Rectangle rectangle2 = new Rectangle(5, 6, 100, 200);
            Rectangle rectangle3 = new Rectangle(50, 60, 100, 200);

            bool flagTrue = rectangle1.Equals(rectangle2);
            bool flagFalse = rectangle1.Equals(rectangle3);
            Assert.IsTrue(flagTrue, "Should be true!");
            Assert.IsFalse(flagFalse, "Should be false!");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetHashCode. Check whether GetHashCode returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetHashCode_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var rectangle = new Rectangle(5, 6, 100, 200);
            Assert.IsNotNull(rectangle, "Can't create success object Rectangle");
            Assert.IsInstanceOf<Rectangle>(rectangle, "Should be an instance of Rectangle type.");
            Assert.GreaterOrEqual(rectangle.GetHashCode(), 0, "Should be true");
        }
    }
}