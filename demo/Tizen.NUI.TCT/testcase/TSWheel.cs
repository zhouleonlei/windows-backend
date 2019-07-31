using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Wheel Tests")]
    public class WheelTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("WheelTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a Wheel object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Wheel.Wheel C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Wheel_INIT()
        {
            /* TEST CODE */
            var wheel = new Wheel();
            Assert.IsNotNull(wheel, "Can't create success object Wheel");
            Assert.IsInstanceOf<Wheel>(wheel, "Should be an instance of Touch type.");
        }

        [Test]
        [Category("P1")]
        [Description("Create a Wheel object. Check whether Wheel object which is initialized is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Wheel.Wheel C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "WheelType,int,uint,Vector2,int,uint")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Wheel_INIT_WITH_WHEELTYPE_INT_UINT_VECTOR2_INT_UINT()
        {
            /* TEST CODE */
            var point = new Vector2(1.0f, 1.0f);
            Wheel wheel = new Wheel(Wheel.WheelType.MouseWheel, 1, 0x1, point, 1, 1000u);
            Assert.IsNotNull(wheel, "Can't create success object Wheel");
            Assert.IsInstanceOf<Wheel>(wheel, "Should be an instance of Touch type.");
            Assert.AreEqual(Wheel.WheelType.MouseWheel, wheel.Type, "Type should be equals to the set value");
            Assert.AreEqual(1, wheel.Direction, "Direction should be equals to the set value");
            Assert.AreEqual(0x1, wheel.Modifiers, "Modifiers should be equals to the set value");
            Assert.AreEqual(point.X, wheel.Point.X, "wheel.Point.X should be equals to the set value");
            Assert.AreEqual(point.Y, wheel.Point.Y, "wheel.Point.Y should be equals to the set value");
            Assert.AreEqual(1, wheel.Z, "Z should be equals to the set value");
            Assert.AreEqual(1000u, wheel.TimeStamp, "TimeStamp should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test IsShiftModifier")]
        [Property("SPEC", "Tizen.NUI.Wheel.IsShiftModifier M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void IsShiftModifier_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector2 point = new Vector2(1.0f, 1.0f);
            Wheel wheel = new Wheel(Wheel.WheelType.MouseWheel, 1, 0x1, point, 1, 1000u);
            Assert.IsTrue(wheel.IsShiftModifier(), "Should be equals true");
        }

        [Test]
        [Category("P1")]
        [Description("Test IsCtrlModifier")]
        [Property("SPEC", "Tizen.NUI.Wheel.IsCtrlModifier M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void IsCtrlModifier_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector2 point = new Vector2(1.0f, 1.0f);
            Wheel wheel = new Wheel(Wheel.WheelType.MouseWheel, 1, 0x2, point, 1, 1000u);
            Assert.IsTrue(wheel.IsCtrlModifier(), "Should be equals true");
        }

        [Test]
        [Category("P1")]
        [Description("Test IsAltModifier")]
        [Property("SPEC", "Tizen.NUI.Wheel.IsAltModifier M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void IsAltModifier_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector2 point = new Vector2(1.0f, 1.0f);
            Wheel wheel = new Wheel(Wheel.WheelType.MouseWheel, 1, 0x4, point, 1, 1000u);
            Assert.IsTrue(wheel.IsAltModifier(), "Should be equals true");
        }

        [Test]
        [Category("P1")]
        [Description("Test Direction.Check whether Direction returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Wheel.Direction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Direction_GET_VALUE()
        {
            /* TEST CODE */
            Vector2 point = new Vector2(1.0f, 1.0f);
            Wheel wheel = new Wheel(Wheel.WheelType.MouseWheel, 1, 0x4, point, 1, 1000u);
            Assert.AreEqual(1, wheel.Direction, "Should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Modifiers.Check whether Modifiers returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Wheel.Modifiers A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Modifiers_GET_VALUE()
        {
            /* TEST CODE */
            Vector2 point = new Vector2(1.0f, 1.0f);
            Wheel wheel = new Wheel(Wheel.WheelType.MouseWheel, 1, 0x4, point, 1, 1000u);
            Assert.AreEqual(0x4, wheel.Modifiers, "Should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Point.Check whether Point returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Wheel.Point A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Point_GET_VALUE()
        {
            /* TEST CODE */
            Vector2 point = new Vector2(1.0f, 1.0f);
            Wheel wheel = new Wheel(Wheel.WheelType.MouseWheel, 1, 0x4, point, 1, 1000u);
            Assert.AreEqual(point.X, wheel.Point.X, "wheel.Point.X should be equals to the set value");
            Assert.AreEqual(point.Y, wheel.Point.Y, "wheel.Point.Y should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Z.Check whether Z returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Wheel.Z A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Z_GET_VALUE()
        {
            /* TEST CODE */
            Vector2 point = new Vector2(1.0f, 1.0f);
            Wheel wheel = new Wheel(Wheel.WheelType.MouseWheel, 1, 0x4, point, 1, 1000u);
            Assert.AreEqual(1, wheel.Z, "Should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test TimeStamp.Check whether TimeStamp returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Wheel.TimeStamp A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TimeStamp_GET_VALUE()
        {
            /* TEST CODE */
            Vector2 point = new Vector2(1.0f, 1.0f);
            Wheel wheel = new Wheel(Wheel.WheelType.MouseWheel, 1, 0x4, point, 1, 1000u);
            Assert.AreEqual(1000u, wheel.TimeStamp, "Should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test WheelType.Check whether WheelType returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Wheel.Type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Type_GET_VALUE()
        {
            /* TEST CODE */
            Vector2 point = new Vector2(1.0f, 1.0f);
            Wheel wheel = new Wheel(Wheel.WheelType.MouseWheel, 1, 0x4, point, 1, 1000u);
            Assert.AreEqual(Wheel.WheelType.MouseWheel, wheel.Type, "Should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Wheel.")]
        [Property("SPEC", "Tizen.NUI.Wheel.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                Wheel wheel = new Wheel();
                wheel.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
    }
}
