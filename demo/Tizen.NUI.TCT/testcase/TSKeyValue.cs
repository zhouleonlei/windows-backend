using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.KeyValue Tests")]
    public class KeyValueTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("KeyValueTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a KeyValue object. Check whether Key is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.KeyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void KeyValue_INIT()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            Assert.IsInstanceOf<KeyValue>(keyValue, "Should be an instance of KeyValue type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test KeyInt. Check whether KeyInt works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.KeyInt A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void KeyInt_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.KeyInt = 1;

            Assert.AreEqual(1, keyValue.KeyInt, "The value of the KeyInt field should be 1 here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test KeyString. Check whether KeyString works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.KeyString A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void KeyString_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.KeyString = "Test";

            Assert.AreEqual("Test", keyValue.KeyString, "The value of the KeyString field should be 1 here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test TrueValue. Check whether TrueValue works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.TrueValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void TrueValue_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.TrueValue = PropertyValue.CreateFromObject(1);

            PropertyValue propertyValue = keyValue.TrueValue;
            int value = 0;
            propertyValue.Get(out value);

            Assert.AreEqual(1, value, "The value should be 1 here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Key. Check whether Key works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.Key A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Key_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.Key = "Test";

            Assert.AreEqual("Test", keyValue.Key, "The value of the Key property should be Test here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test OriginalKey. Check whether OriginalKey works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.OriginalKey A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void OriginalKey_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.OriginalKey = "Test";

            Assert.AreEqual("Test", keyValue.OriginalKey, "The value of the OriginalKey property should be Test here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Value. Check whether Value works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Value_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.Value = "Test";

            Assert.AreEqual("Test", keyValue.Value, "The value of the Value property should be Test here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test IntergerValue. Check whether IntergerValue works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.IntergerValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void IntergerValue_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.IntergerValue = 1;

            PropertyValue propertyValue = keyValue.TrueValue;
            int value = 0;
            propertyValue.Get(out value);

            Assert.AreEqual(1, value, "The value should be 1 here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test BooleanValue. Check whether BooleanValue works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.BooleanValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void BooleanValue_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.BooleanValue = true;

            PropertyValue propertyValue = keyValue.TrueValue;
            bool value = false;
            propertyValue.Get(out value);

            Assert.IsTrue(value, "The value should be true here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test SingleValue. Check whether SingleValue works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.SingleValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SingleValue_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.SingleValue = 1.0f;

            PropertyValue propertyValue = keyValue.TrueValue;
            float value = 0.0f;
            propertyValue.Get(out value);

            Assert.AreEqual(1.0f, value, "The value should be 1.0f here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test StringValue. Check whether StringValue works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.StringValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void StringValue_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.StringValue = "TEST";

            PropertyValue propertyValue = keyValue.TrueValue;
            string value = "";
            propertyValue.Get(out value);

            Assert.AreEqual("TEST", value, "The value should be TEST here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Vector2Value. Check whether Vector2Value works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.Vector2Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Vector2Value_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.Vector2Value = new Vector2(1.0f, 1.0f);

            PropertyValue propertyValue = keyValue.TrueValue;
            Vector2 value = new Vector2(0.0f, 0.0f);
            propertyValue.Get(value);

            Assert.AreEqual(1.0f, value.X, "The value.X should be equal to the 1.0f");
            Assert.AreEqual(1.0f, value.Y, "The value.Y should be equal to the 1.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test Vector3Value. Check whether Vector3Value works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.Vector3Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Vector3Value_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.Vector3Value = new Vector3(1.0f, 1.0f, 1.0f);

            PropertyValue propertyValue = keyValue.TrueValue;
            Vector3 value = new Vector3(0.0f, 0.0f, 0.0f);
            propertyValue.Get(value);

            Assert.AreEqual(1.0f, value.X, "The value.X should be equal to the 1.0f");
            Assert.AreEqual(1.0f, value.Y, "The value.Y should be equal to the 1.0f");
            Assert.AreEqual(1.0f, value.Z, "The value.Z should be equal to the 1.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test Vector4Value. Check whether Vector4Value works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.Vector4Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Vector4Value_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.Vector4Value = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);

            PropertyValue propertyValue = keyValue.TrueValue;
            Vector4 value = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            propertyValue.Get(value);

            Assert.AreEqual(1.0f, value.X, "The value.X should be equal to the 1.0f");
            Assert.AreEqual(1.0f, value.Y, "The value.Y should be equal to the 1.0f");
            Assert.AreEqual(1.0f, value.Z, "The value.Z should be equal to the 1.0f");
            Assert.AreEqual(1.0f, value.W, "The value.W should be equal to the 1.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test PositionValue. Check whether PositionValue works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.PositionValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PositionValue_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.PositionValue = new Position(1.0f, 1.0f, 0.0f);

            PropertyValue propertyValue = keyValue.TrueValue;
            Position value = new Position(0.0f, 0.0f, 0.0f);
            propertyValue.Get(value);

            Assert.AreEqual(1.0f, value.X, "The value.X should be equal to the 1.0f");
            Assert.AreEqual(1.0f, value.Y, "The value.Y should be equal to the 1.0f");
            Assert.AreEqual(0.0f, value.Z, "The value.Z should be equal to the 0.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test Position2DValue. Check whether Position2DValue works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.Position2DValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Position2DValue_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.Position2DValue = new Position2D(1, 1);

            PropertyValue propertyValue = keyValue.TrueValue;
            Position2D value = new Position2D(0, 0);
            propertyValue.Get(value);

            Assert.AreEqual(1, value.X, "The value.X should be equal to the 1");
            Assert.AreEqual(1, value.Y, "The value.Y should be equal to the 1");
        }

        [Test]
        [Category("P1")]
        [Description("Test SizeValue. Check whether SizeValue works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.SizeValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SizeValue_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.SizeValue = new Size(1.0f, 1.0f, 1.0f);

            PropertyValue propertyValue = keyValue.TrueValue;
            Size value = new Size(0.0f, 0.0f, 0.0f);
            propertyValue.Get(value);

            Assert.AreEqual(1.0f, value.Width, "The value.Width should be equal to the 1.0f");
            Assert.AreEqual(1.0f, value.Height, "The value.Height should be equal to the 1.0f");
            Assert.AreEqual(1.0f, value.Depth, "The value.Depth should be equal to the 1.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test Size2DValue. Check whether Size2DValue works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.Size2DValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Size2DValue_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.Size2DValue = new Size2D(1, 1);

            PropertyValue propertyValue = keyValue.TrueValue;
            Size2D value = new Size2D(0, 0);
            propertyValue.Get(value);

            Assert.AreEqual(1, value.Width, "The value.Width should be equal to the 1");
            Assert.AreEqual(1, value.Height, "The value.Height should be equal to the 1");
        }

        [Test]
        [Category("P1")]
        [Description("Test ColorValue. Check whether ColorValue works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.ColorValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ColorValue_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.ColorValue = Color.Red;

            PropertyValue propertyValue = keyValue.TrueValue;
            Color value = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            propertyValue.Get(value);

            Assert.AreEqual(Color.Red.R, value.R, "The value.R should be equal to the Color.Red.R");
            Assert.AreEqual(Color.Red.G, value.G, "The value.R should be equal to the Color.Red.G");
            Assert.AreEqual(Color.Red.B, value.B, "The value.R should be equal to the Color.Red.B");
            Assert.AreEqual(Color.Red.A, value.A, "The value.R should be equal to the Color.Red.A");
        }

        [Test]
        [Category("P1")]
        [Description("Test RectangleValue. Check whether RectangleValue works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.RectangleValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RectangleValue_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.RectangleValue = new Rectangle(0, 0, 1, 1);

            PropertyValue propertyValue = keyValue.TrueValue;
            Rectangle value = new Rectangle(0, 0, 0, 0);
            propertyValue.Get(value);

            Assert.AreEqual(0, value.X, "The value.X should be equal to the 0");
            Assert.AreEqual(0, value.Y, "The value.Y should be equal to the 0");
            Assert.AreEqual(1, value.Width, "The value.Width should be equal to the 1");
            Assert.AreEqual(1, value.Height, "The value.Height should be equal to the 1");
        }

        [Test]
        [Category("P1")]
        [Description("Test RotationValue. Check whether RotationValue works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.RotationValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RotationValue_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.RotationValue = new Rotation(new Radian(1.5f), Vector3.XAxis);

            PropertyValue propertyValue = keyValue.TrueValue;
            Rotation value = new Rotation();
            propertyValue.Get(value);

            Assert.IsNotNull(value, "Should be not null");
        }

        [Test]
        [Category("P1")]
        [Description("Test RelativeVector2Value. Check whether RelativeVector2Value works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.RelativeVector2Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RelativeVector2Value_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.RelativeVector2Value = new RelativeVector2(1.0f, 1.0f);

            PropertyValue propertyValue = keyValue.TrueValue;
            RelativeVector2 value = new RelativeVector2(0.0f, 0.0f);
            propertyValue.Get(value);

            Assert.AreEqual(1.0f, value.X, "The value.X should be equal to the 1.0f");
            Assert.AreEqual(1.0f, value.Y, "The value.Y should be equal to the 1.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test RelativeVector3Value. Check whether RelativeVector3Value works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.RelativeVector3Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RelativeVector3Value_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.RelativeVector3Value = new RelativeVector3(1.0f, 1.0f, 1.0f);

            PropertyValue propertyValue = keyValue.TrueValue;
            RelativeVector3 value = new RelativeVector3(0.0f, 0.0f, 0.0f);
            propertyValue.Get(value);

            Assert.AreEqual(1.0f, value.X, "The value.X should be equal to the 1.0f");
            Assert.AreEqual(1.0f, value.Y, "The value.Y should be equal to the 1.0f");
            Assert.AreEqual(1.0f, value.Z, "The value.Z should be equal to the 1.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test RelativeVector4Value. Check whether RelativeVector4Value works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.RelativeVector4Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RelativeVector4Value_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.RelativeVector4Value = new RelativeVector4(1.0f, 1.0f, 1.0f, 1.0f);

            PropertyValue propertyValue = keyValue.TrueValue;
            RelativeVector4 value = new RelativeVector4(0.0f, 0.0f, 0.0f, 0.0f);
            propertyValue.Get(value);

            Assert.AreEqual(1.0f, value.X, "The value.X should be equal to the 1.0f");
            Assert.AreEqual(1.0f, value.Y, "The value.Y should be equal to the 1.0f");
            Assert.AreEqual(1.0f, value.Z, "The value.Z should be equal to the 1.0f");
            Assert.AreEqual(1.0f, value.W, "The value.W should be equal to the 1.0f");
        }

        [Test]
        [Category("P1")]
        [Description("Test ExtentsValue. Check whether ExtentsValue works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.ExtentsValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ExtentsValue_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");
            keyValue.ExtentsValue = new Extents(1, 1, 1, 1);

            PropertyValue propertyValue = keyValue.TrueValue;
            Extents value = new Extents(0, 0, 0, 0);
            propertyValue.Get(value);

            Assert.AreEqual(1, value.Start, "The value.Start should be equal to the 1");
            Assert.AreEqual(1, value.End, "The value.End should be equal to the 1");
            Assert.AreEqual(1, value.Top, "The value.Top should be equal to the 1");
            Assert.AreEqual(1, value.Bottom, "The value.Bottom should be equal to the 1");
        }

        [Test]
        [Category("P1")]
        [Description("Test PropertyArrayValue. Check whether PropertyArrayValue works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.PropertyArrayValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PropertyArrayValue_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");

            PropertyArray propertyarray = new PropertyArray();
            KeyValue keyValue1 = new KeyValue();
            keyValue1.SingleValue = 14.0f;
            KeyValue keyValue2 = new KeyValue();
            keyValue2.SingleValue = 15.0f;

            propertyarray.Add(keyValue1);
            propertyarray.Add(keyValue2);
            keyValue.PropertyArrayValue = propertyarray;

            PropertyValue propertyValue = keyValue.TrueValue;
            PropertyArray value = new PropertyArray();
            propertyValue.Get(value);

            Assert.AreEqual(2, value.Size(), "The count is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test PropertyMapValue. Check whether PropertyMapValue works or not.")]
        [Property("SPEC", "Tizen.NUI.KeyValue.PropertyMapValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PropertyMapValue_CHECK_VALUE()
        {
            /* TEST CODE */
            var keyValue = new KeyValue();
            Assert.IsNotNull(keyValue, "Can't create success object KeyValue");

            PropertyMap propertyMap = new PropertyMap();
            PropertyValue propertyValue1 = new PropertyValue(4.0f);
            propertyMap.Insert(8, propertyValue1);
            PropertyValue propertyValue2 = new PropertyValue(5.0f);
            propertyMap.Insert(18, propertyValue2);

            keyValue.PropertyMapValue = propertyMap;

            PropertyValue propertyValue = keyValue.TrueValue;
            PropertyMap value = new PropertyMap();
            propertyValue.Get(value);

            Assert.AreEqual(2, value.Count(), "The count is not correct.");
        }

    }
}
