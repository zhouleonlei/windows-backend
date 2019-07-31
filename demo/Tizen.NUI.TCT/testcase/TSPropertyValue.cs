using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.PropertyValue Tests")]
    public class PropertyValueTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("PropertyValueTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Test CreateFromObject. Check whether CreateFromObject with string key parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.CreateFromObject M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void CreateFromObject_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Object obj = new Position(10.0f, 20.0f, 30.0f);
            var value = PropertyValue.CreateFromObject(obj);
            Assert.IsInstanceOf<PropertyValue>(value, "Should return PropertyValue instance.");
            Vector3 tempvector = new Vector3(0.0f, 0.0f, 0.0f);
            value.Get(tempvector);
            Assert.AreEqual(10.0f, tempvector.X, "CreateFromObject function does not work");
            Assert.AreEqual(20.0f, tempvector.Y, "CreateFromObject function does not work");
            Assert.AreEqual(30.0f, tempvector.Z, "CreateFromObject function does not work");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyValue constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "")]
        public void PropertyValue_INIT_WITH_NULL()
        {
            /* TEST CODE */
            var propertyvalue = new PropertyValue();
            Assert.IsInstanceOf<PropertyValue>(propertyvalue, "Should return PropertyValue instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyValue with bool parameter constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "bool")]
        public void PropertyValue_INIT_WITH_BOOL()
        {
            /* TEST CODE */
            var propertyvalue = new PropertyValue(true);
            Assert.IsInstanceOf<PropertyValue>(propertyvalue, "Should return PropertyValue instance.");
            bool tempvalue = false;
            propertyvalue.Get(out tempvalue);
            Assert.AreEqual(true, tempvalue, "the constructor bool parameter is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyValue with int parameter constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "int")]
        public void PropertyValue_INIT_WITH_INT()
        {
            /* TEST CODE */
            var propertyvalue = new PropertyValue(5);
            Assert.IsInstanceOf<PropertyValue>(propertyvalue, "Should return PropertyValue instance.");
            int tempvalue = 0;
            propertyvalue.Get(out tempvalue);
            Assert.AreEqual(5, tempvalue, "the constructor int parameter is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyValue with float parameter constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "single")]
        public void PropertyValue_INIT_WITH_FLOAT()
        {
            /* TEST CODE */
            var propertyvalue = new PropertyValue(6.0f);
            Assert.IsInstanceOf<PropertyValue>(propertyvalue, "Should return PropertyValue instance.");
            float tempvalue = 0.0f;
            propertyvalue.Get(out tempvalue);
            Assert.AreEqual(6.0f, tempvalue, "the constructor float parameter is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyValue with Vector2 parameter constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Vector2")]
        public void PropertyValue_INIT_WITH_VECTOR2()
        {
            /* TEST CODE */
            var propertyvalue = new PropertyValue(new Vector2(1.0f, 2.0f));
            Assert.IsInstanceOf<PropertyValue>(propertyvalue, "Should return PropertyValue instance.");
            Vector2 tempvalue = new Vector2(0.0f, 0.0f);
            propertyvalue.Get(tempvalue);
            Assert.AreEqual(1.0f, tempvalue.X, "the constructor Vector2 parameter is not correct");
            Assert.AreEqual(2.0f, tempvalue.Y, "the constructor Vector2 parameter is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyValue with Size2D parameter constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Size2D")]
        public void PropertyValue_INIT_WITH_SIZE2D()
        {
            /* TEST CODE */
            var propertyvalue = new PropertyValue(new Size2D(1, 2));
            Assert.IsInstanceOf<PropertyValue>(propertyvalue, "Should return PropertyValue instance.");
            Size2D tempvalue = new Size2D(0, 0);
            propertyvalue.Get(tempvalue);
            Assert.AreEqual(1, tempvalue.Width, "the constructor Size2D parameter is not correct");
            Assert.AreEqual(2, tempvalue.Height, "the constructor Size2D parameter is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyValue with Vector3 parameter constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Vector3")]
        public void PropertyValue_INIT_WITH_VECTOR3()
        {
            /* TEST CODE */
            var propertyvalue = new PropertyValue(new Vector3(1.0f, 2.0f, 3.0f));
            Assert.IsInstanceOf<PropertyValue>(propertyvalue, "Should return PropertyValue instance.");
            Vector3 tempvalue = new Vector3(0.0f, 0.0f, 0.0f);
            propertyvalue.Get(tempvalue);
            Assert.AreEqual(1.0f, tempvalue.X, "the constructor Vector3 parameter is not correct");
            Assert.AreEqual(2.0f, tempvalue.Y, "the constructor Vector3 parameter is not correct");
            Assert.AreEqual(3.0f, tempvalue.Z, "the constructor Vector3 parameter is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyValue with Position2D parameter constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Position2D")]
        public void PropertyValue_INIT_WITH_POSITION2D()
        {
            /* TEST CODE */
            var propertyvalue = new PropertyValue(new Position2D(1,2));
            Assert.IsInstanceOf<PropertyValue>(propertyvalue, "Should return PropertyValue instance.");
            Position2D tempvalue = new Position2D(0, 0);
            propertyvalue.Get(tempvalue);
            Assert.AreEqual(1, tempvalue.X, "the constructor Position2D parameter is not correct");
            Assert.AreEqual(2, tempvalue.Y, "the constructor Position2D parameter is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyValue with Position parameter constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Position")]
        public void PropertyValue_INIT_WITH_POSITION()
        {
            /* TEST CODE */
            var propertyvalue = new PropertyValue(new Position(1.0f, 2.0f, 3.0f));
            Assert.IsInstanceOf<PropertyValue>(propertyvalue, "Should return PropertyValue instance.");
            Position tempvalue = new Position(0.0f, 0.0f, 0.0f);
            propertyvalue.Get(tempvalue);
            Assert.AreEqual(1.0f, tempvalue.X, "the constructor Position parameter is not correct");
            Assert.AreEqual(2.0f, tempvalue.Y, "the constructor Position parameter is not correct");
            Assert.AreEqual(3.0f, tempvalue.Z, "the constructor Position parameter is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyValue with Vector4 parameter constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Vector4")]
        public void PropertyValue_INIT_WITH_VECTOR4()
        {
            /* TEST CODE */
            var propertyvalue = new PropertyValue(new Vector4(1.0f, 2.0f, 3.0f, 4.0f));
            Assert.IsInstanceOf<PropertyValue>(propertyvalue, "Should return PropertyValue instance.");
            Vector4 tempvalue = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            propertyvalue.Get(tempvalue);
            Assert.AreEqual(1.0f, tempvalue.X, "the constructor Vector4 parameter is not correct");
            Assert.AreEqual(2.0f, tempvalue.Y, "the constructor Vector4 parameter is not correct");
            Assert.AreEqual(3.0f, tempvalue.Z, "the constructor Vector4 parameter is not correct");
            Assert.AreEqual(4.0f, tempvalue.W, "the constructor Vector4 parameter is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyValue with Extents parameter constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        [Property("COVPARAM", "Extents")]
        public void PropertyValue_INIT_WITH_Extents()
        {
            /* TEST CODE */
            var propertyvalue = new PropertyValue(new Extents(1, 2, 3, 4));
            Assert.IsInstanceOf<PropertyValue>(propertyvalue, "Should return PropertyValue instance.");
            Extents tempvalue = new Extents(0, 0, 0, 0);
            propertyvalue.Get(tempvalue);
            Assert.AreEqual(1, tempvalue.Start, "the constructor Extents parameter is not correct");
            Assert.AreEqual(2, tempvalue.End, "the constructor Extents parameter is not correct");
            Assert.AreEqual(3, tempvalue.Top, "the constructor Extents parameter is not correct");
            Assert.AreEqual(4, tempvalue.Bottom, "the constructor Extents parameter is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyValue with Color parameter constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Color")]
        public void PropertyValue_INIT_WITH_COLOR()
        {
            /* TEST CODE */
            var propertyvalue = new PropertyValue(new Color(1.0f, 1.0f, 1.0f, 0.5f));
            Assert.IsInstanceOf<PropertyValue>(propertyvalue, "Should return PropertyValue instance.");
            Color tempvalue = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            propertyvalue.Get(tempvalue);
            Assert.AreEqual(1.0f, tempvalue.R, "the constructor Color parameter is not correct");
            Assert.AreEqual(1.0f, tempvalue.G, "the constructor Color parameter is not correct");
            Assert.AreEqual(1.0f, tempvalue.B, "the constructor Color parameter is not correct");
            Assert.AreEqual(0.5f, tempvalue.A, "the constructor Color parameter is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyValue with Rectangle parameter constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Rectangle")]
        public void PropertyValue_INIT_WITH_RECTANGLE()
        {
            /* TEST CODE */
            var propertyvalue = new PropertyValue(new Rectangle(1, 2, 100, 200));
            Assert.IsInstanceOf<PropertyValue>(propertyvalue, "Should return PropertyValue instance.");
            Rectangle tempvalue = new Rectangle(0, 0, 0, 0);
            propertyvalue.Get(tempvalue);
            Assert.AreEqual(1, tempvalue.X, "the constructor Rectangle parameter is not correct");
            Assert.AreEqual(2, tempvalue.Y, "the constructor Rectangle parameter is not correct");
            Assert.AreEqual(100, tempvalue.Width, "the constructor Rectangle parameter is not correct");
            Assert.AreEqual(200, tempvalue.Height, "the constructor Rectangle parameter is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyValue with Rotation parameter constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Rotation")]
        public void PropertyValue_INIT_WITH_ROTATION()
        {
            /* TEST CODE */
            Rotation rotation = new Rotation();
            var propertyvalue = new PropertyValue(rotation);
            Assert.IsInstanceOf<PropertyValue>(propertyvalue, "Should return PropertyValue instance.");
            Assert.IsInstanceOf<Rotation>(rotation, "the constructor Rotation parameter is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyValue with string parameter constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "string")]
        public void PropertyValue_INIT_WITH_STRING()
        {
            /* TEST CODE */
            var propertyvalue = new PropertyValue("DALI");
            Assert.IsInstanceOf<PropertyValue>(propertyvalue, "Should return PropertyValue instance.");
            String tempvalue = "HELLO";
            propertyvalue.Get(out tempvalue);
            Assert.AreEqual("DALI", tempvalue, "the constructor string parameter is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyValue with PropertyArray parameter constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "PropertyArray")]
        public void PropertyValue_INIT_WITH_PROPERTYARRAY()
        {
            /* TEST CODE */
            PropertyArray propertyarray = new PropertyArray();
            PropertyValue propertyvalue1 = new PropertyValue(14.0f);
            PropertyValue propertyvalue2 = new PropertyValue(15.0f);
            propertyarray.Add(propertyvalue1);
            propertyarray.Add(propertyvalue2);
            var propertyvalue = new PropertyValue(propertyarray);
            Assert.IsInstanceOf<PropertyValue>(propertyvalue, "Should return PropertyValue instance.");
            PropertyArray propertyarraytemp = new PropertyArray();
            propertyvalue.Get(propertyarraytemp);
            float tempvalue1 = 0.0f;
            float tempvalue2 = 0.0f;
            propertyarraytemp[0].Get(out tempvalue1);
            propertyarraytemp[1].Get(out tempvalue2);
            Assert.AreEqual(14.0f, tempvalue1, "the constructor PropertyArray parameter is not correct");
            Assert.AreEqual(15.0f, tempvalue2, "the constructor PropertyArray parameter is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyValue with PropertyMap parameter constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "PropertyMap")]
        public void PropertyValue_INIT_WITH_PROPERTYMAP()
        {
            /* TEST CODE */
            PropertyMap propertymap = new PropertyMap();
            PropertyValue propertyvalue1 = new PropertyValue(400.0f);
            propertymap.Add("hello", propertyvalue1);
            PropertyValue propertyvalue2 = new PropertyValue(500.0f);
            propertymap.Add("world", propertyvalue2);
            var propertyvalue = new PropertyValue(propertymap);
            Assert.IsInstanceOf<PropertyValue>(propertyvalue, "Should return PropertyValue instance.");
            PropertyMap propertymaptemp = new PropertyMap();
            propertyvalue.Get(propertymaptemp);
            PropertyValue propertyvaluenew1 = propertymaptemp.GetValue(0);
            float tempvaluenew1 = 0.0f;
            propertyvaluenew1.Get(out tempvaluenew1);
            Assert.AreEqual(400.0f, tempvaluenew1, "the constructor PropertyMap parameter is not correct");
            PropertyValue propertyvaluenew2 = propertymaptemp.GetValue(1);
            float tempvaluenew2 = 0.0f;
            propertyvaluenew2.Get(out tempvaluenew2);
            Assert.AreEqual(500.0f, tempvaluenew2, "the constructor PropertyMap parameter is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyValue with PropertyType parameter constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "PropertyType")]
        public void PropertyValue_INIT_WITH_PROPERTYTYPE()
        {
            /* TEST CODE */
            var propertyvalue = new PropertyValue(PropertyType.Float);
            Assert.IsInstanceOf<PropertyValue>(propertyvalue, "Should return PropertyValue instance.");
            PropertyType type = PropertyType.Vector2;
            type = propertyvalue.GetType();
            Assert.AreEqual(PropertyType.Float, type, "the constructor PropertyType parameter is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("dali PropertyValue with PropertyValue parameter constructor test")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "PropertyValue")]
        public void PropertyValue_INIT_WITH_PROPERTYVALUE()
        {
            /* TEST CODE */
            int value = 5;
            PropertyValue propertyvalue1 = new PropertyValue(value);
            var propertyvalue2 = new PropertyValue(propertyvalue1);
            Assert.IsInstanceOf<PropertyValue>(propertyvalue2, "Should return PropertyValue instance.");
            int tempvalue = 0;
            propertyvalue2.Get(out tempvalue);
            Assert.AreEqual(5, tempvalue, "the constructor PropertyValue parameter is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetType. Check whether GetType returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.GetType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void GetType_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            PropertyValue propertyvalue1 = new PropertyValue(2);
            PropertyValue propertyvalue2 = propertyvalue1;
            PropertyType propertytype = propertyvalue2.GetType();
            Assert.AreEqual(PropertyType.Integer, propertytype, "GetType function does not work, the tyep from GetType function is wrong");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get. Check whether Get with bool parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "bool")]
        public void Get_CHECK_RETURN_VALUE_WITH_BOOL()
        {
            /* TEST CODE */
            PropertyValue propertyvalue = new PropertyValue(false);
            bool tempvalue = true;
            propertyvalue.Get(out tempvalue);
            Assert.AreEqual(false, tempvalue, "Get function with bool parameter does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get. Check whether Get with float parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "single")]
        public void Get_CHECK_RETURN_VALUE_WITH_FLOAT()
        {
            /* TEST CODE */
            PropertyValue propertyvalue = new PropertyValue(12.0f);
            float tempvalue = 0.0f;
            propertyvalue.Get(out tempvalue);
            Assert.AreEqual(12.0f, tempvalue, "Get function with float parameter does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get. Check whether Get with int parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "int")]
        public void Get_CHECK_RETURN_VALUE_WITH_INT()
        {
            /* TEST CODE */
            PropertyValue propertyvalue = new PropertyValue(20);
            int tempvalue = 0;
            propertyvalue.Get(out tempvalue);
            Assert.AreEqual(20, tempvalue, "Get function with int parameter does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get. Check whether Get with Rectangle parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Rectangle")]
        public void Get_CHECK_RETURN_VALUE_WITH_RECTANGLE()
        {
            /* TEST CODE */
            Rectangle rect1 = new Rectangle(1, 2, 3, 4);
            PropertyValue propertyvalue = new PropertyValue(rect1);
            Rectangle rect2 = new Rectangle(4, 3, 2, 1);
            propertyvalue.Get(rect2);
            Assert.AreEqual(1, rect2.X, "Get function with Rectangle parameter does not work, Rectangle.X is not right.");
            Assert.AreEqual(2, rect2.Y, "Get function with Rectangle parameter does not work, Rectangle.Y is not right.");
            Assert.AreEqual(3, rect2.Width, "Get function with Rectangle parameter does not work, Rectangle.width is not right.");
            Assert.AreEqual(4, rect2.Height, "Get function with Rectangle parameter does not work, Rectangle.H is not right.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get. Check whether Get with Vector2 parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Vector2")]
        public void Get_CHECK_RETURN_VALUE_WITH_VECTOR2()
        {
            /* TEST CODE */
            Vector2 vec1 = new Vector2(1, 2);
            PropertyValue propertyvalue = new PropertyValue(vec1);
            Vector2 vec2 = new Vector2(3, 4);
            propertyvalue.Get(vec2);
            Assert.AreEqual(vec1.X, vec2.X, "Get function with Vector2 parameter does not work, Vector2.X is not right");
            Assert.AreEqual(vec1.Y, vec2.Y, "Get function with Vector2 parameter does not work, Vector2.Y is not right");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get. Check whether Get with Size2D parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Size2D")]
        public void Get_CHECK_RETURN_VALUE_WITH_SIZE2D()
        {
            /* TEST CODE */
            Size2D size2d1 = new Size2D(1, 2);
            PropertyValue propertyvalue = new PropertyValue(size2d1);
            Size2D size2d2 = new Size2D(3, 4);
            propertyvalue.Get(size2d2);
            Assert.AreEqual(1, size2d2.Width, "Get function with Size2D parameter does not work, Size2D.Width is not right");
            Assert.AreEqual(2, size2d2.Height, "Get function with Size2D parameter does not work, Size2D.Height is not right");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get. Check whether Get with Vector3 parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Vector3")]
        public void Get_CHECK_RETURN_VALUE_WITH_VECTOR3()
        {
            /* TEST CODE */
            Vector3 vector31 = new Vector3(1, 2, 3);
            PropertyValue propertyvalue = new PropertyValue(vector31);
            Vector3 vector32 = new Vector3(3, 2, 1);
            propertyvalue.Get(vector32);
            Assert.AreEqual(1, vector32.X, "Get function with Vector3 parameter does not work, Vector.X is not right");
            Assert.AreEqual(2, vector32.Y, "Get function with Vector3 parameter does not work, Vector.Y is not right");
            Assert.AreEqual(3, vector32.Z, "Get function with Vector3 parameter does not work, Vector.Z is not right");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get. Check whether Get with Position parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Position")]
        public void Get_CHECK_RETURN_VALUE_WITH_POSITION()
        {
            /* TEST CODE */
            Position position1 = new Position(1, 2, 3);
            PropertyValue propertyvalue = new PropertyValue(position1);
            Position position2 = new Position(4, 5, 6);
            propertyvalue.Get(position2);
            Assert.AreEqual(1, position2.X, "Get function with Position parameter does not work, Position.X is not right.");
            Assert.AreEqual(2, position2.Y, "Get function with Position parameter does not work, Position.Y is not right.");
            Assert.AreEqual(3, position2.Z, "Get function with Position parameter does not work, Position.Z is not right.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get. Check whether Get with Position2D parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Position2D")]
        public void Get_CHECK_RETURN_VALUE_WITH_POSITION2D()
        {
            /* TEST CODE */
            Position2D position1 = new Position2D(1, 2);
            PropertyValue propertyvalue = new PropertyValue(position1);
            Position2D position2 = new Position2D(4, 5);
            propertyvalue.Get(position2);
            Assert.AreEqual(1, position2.X, "Get function with Position2D parameter does not work, Position.X is not right.");
            Assert.AreEqual(2, position2.Y, "Get function with Position2D parameter does not work, Position.Y is not right.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get. Check whether Get with Vector4 parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Vector4")]
        public void Get_CHECK_RETURN_VALUE_WITH_VECTOR4()
        {
            /* TEST CODE */
            Vector4 vector1 = new Vector4(10, 20, 30, 40);
            PropertyValue propertyvalue = new PropertyValue(vector1);
            Vector4 vector2 = new Vector4(100, 200, 300, 400);
            propertyvalue.Get(vector2);
            Assert.AreEqual(10, vector2.X, "Get function with Vector4 parameter does not work, Vector.X is not right.");
            Assert.AreEqual(20, vector2.Y, "Get function with Vector4 parameter does not work, Vector.Y is not right.");
            Assert.AreEqual(30, vector2.Z, "Get function with Vector4 parameter does not work, Vector.Z is not right.");
            Assert.AreEqual(40, vector2.W, "Get function with Vector4 parameter does not work, Vector.W is not right.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get. Check whether Get with Extents parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        [Property("COVPARAM", "Extents")]
        public void Get_CHECK_RETURN_VALUE_WITH_Extents()
        {
            /* TEST CODE */
            var propertyvalue = new PropertyValue(new Extents(1, 2, 3, 4));
            Assert.IsInstanceOf<PropertyValue>(propertyvalue, "Should return PropertyValue instance.");
            Extents tempvalue = new Extents(0, 0, 0, 0);
            propertyvalue.Get(tempvalue);
            Assert.AreEqual(1, tempvalue.Start, "the constructor Extents parameter is not correct");
            Assert.AreEqual(2, tempvalue.End, "the constructor Extents parameter is not correct");
            Assert.AreEqual(3, tempvalue.Top, "the constructor Extents parameter is not correct");
            Assert.AreEqual(4, tempvalue.Bottom, "the constructor Extents parameter is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get. Check whether Get with Color parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Color")]
        public void Get_CHECK_RETURN_VALUE_WITH_COLOR()
        {
            /* TEST CODE */
            Color color1 = new Color(1.0f, 0.5f, 1.0f, 0.5f);
            PropertyValue propertyvalue = new PropertyValue(color1);
            Color color2 = new Color(0, 0, 0, 0);
            propertyvalue.Get(color2);
            Assert.AreEqual(1.0f, color2.R, "Get function with Color parameter does not work, color.R is not right.");
            Assert.AreEqual(0.5f, color2.G, "Get function with Color parameter does not work, color.G is not right.");
            Assert.AreEqual(1.0f, color2.B, "Get function with Color parameter does not work, color.B is not right.");
            Assert.AreEqual(0.5f, color2.A, "Get function with Color parameter does not work, color.A is not right.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get. Check whether Get with Rotation parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Rotation")]
        public void Get_CHECK_RETURN_VALUE_WITH_ROTATION()
        {
            /* TEST CODE */
            Rotation rotation = new Rotation(new Radian(6.0f), new Vector3(1.0f, 2.0f, 3.0f));
            PropertyValue propertyvalue = new PropertyValue(rotation);
            Rotation rotationnew = new Rotation();
            Assert.IsTrue(propertyvalue.Get(rotationnew), "Get function with rotation parameter does not work");
            Vector3 axisvalue = new Vector3(0, 0, 0);
            Radian angletemp = new Radian(20.0f);
            rotationnew.GetAxisAngle(axisvalue, angletemp);
            Assert.AreEqual(0.27f, float.Parse(axisvalue.X.ToString("F2")), "Get function with rotation parameter does not work, Vector3.X value is incorrect");
            Assert.AreEqual(0.53f, float.Parse(axisvalue.Y.ToString("F2")), "Get function with rotation parameter does not work, Vector3.Y value is incorrect");
            Assert.AreEqual(0.80f, float.Parse(axisvalue.Z.ToString("F2")), "Get function with rotation parameter does not work, Vector3.Z value is incorrect");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get. Check whether Get with string parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "string")]
        public void Get_CHECK_RETURN_VALUE_WITH_STRING()
        {
            /* TEST CODE */
            PropertyValue propertyvalue = new PropertyValue("DALI");
            String strvalue = "HELLO";
            propertyvalue.Get(out strvalue);
            Assert.AreEqual("DALI", strvalue, "Get function with string parameter does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get. Check whether Get with PropertyArray parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "PropertyArray")]
        public void Get_CHECK_RETURN_VALUE_WITH_PROPERTYARRAY()
        {
            /* TEST CODE */
            PropertyArray propertyarray = new PropertyArray();
            PropertyValue propertyvalue1 = new PropertyValue(3.0f);
            PropertyValue propertyvalue2 = new PropertyValue(6.0f);
            propertyarray.Add(propertyvalue1);
            propertyarray.Add(propertyvalue2);
            PropertyValue propertyvalue = new PropertyValue(propertyarray);
            PropertyArray propertyarraynew = new PropertyArray();
            PropertyValue propertyvaluenew1 = new PropertyValue(100.0f);
            PropertyValue propertyvaluenew2 = new PropertyValue(200.0f);
            propertyarraynew.Add(propertyvaluenew1);
            propertyarraynew.Add(propertyvaluenew2);
            float tempvalue1 = 0.0f;
            propertyarraynew[0].Get(out tempvalue1);
            float tempvalue2 = 0.0f;
            propertyarraynew[1].Get(out tempvalue2);
            Assert.AreEqual(100.0f, tempvalue1, "propertyarray value is not right");
            Assert.AreEqual(200.0f, tempvalue2, "propertyarray value is not right");
            propertyvalue.Get(propertyarraynew);
            float tempvalue11 = 0.0f;
            propertyarraynew[0].Get(out tempvalue11);
            float tempvalue22 = 0.0f;
            propertyarraynew[1].Get(out tempvalue22);
            Assert.AreEqual(3.0f, tempvalue11, "Get function with PropertyArray parameter does not work");
            Assert.AreEqual(6.0f, tempvalue22, "Get function with PropertyArray parameter does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get. Check whether Get with PropertyMap parameter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        [Property("COVPARAM", "Tizen.NUI.PropertyMap")]
        public void Get_CHECK_RETURN_VALUE_WITH_PROPERTYMAP()
        {
            /* TEST CODE */
            PropertyMap propertymap = new PropertyMap();
            PropertyValue propertyvalue1 = new PropertyValue(400.0f);
            propertymap.Add(2, propertyvalue1);
            PropertyValue propertyvalue = new PropertyValue(propertymap);
            PropertyMap propertymapnew = new PropertyMap();
            propertyvalue.Get(propertymapnew);
            PropertyValue propertyvalue3 = propertymapnew[2];
            float tempvalue = 0.0f;
            propertyvalue3.Get(out tempvalue);
            Assert.AreEqual(400.0f, tempvalue, "Get function with PropertyMap parameter does not work");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the PropertyValue.")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                PropertyValue propertyvalue = new PropertyValue(400.0f);
                propertyvalue.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
    }
}