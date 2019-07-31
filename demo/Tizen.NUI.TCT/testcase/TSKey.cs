using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Key Tests")]
    public class KeyTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("KeyTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a Key object. Check whether Key is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Key.Key C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Key_INIT()
        {
            /* TEST CODE */
            var key = new Key();
            Assert.IsNotNull(key, "Can't create success object Key");
            Assert.IsInstanceOf<Key>(key, "Should be an instance of Key type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test IsShiftModifier.Check whether IsShiftModifier returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.Key.IsShiftModifier M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void IsShiftModifier_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Key key = new Key();
            Assert.IsFalse(key.IsShiftModifier(), "Shold be false now!");
        }

        [Test]
        [Category("P1")]
        [Description("Test IsCtrlModifier.Check whether IsCtrlModifier returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.Key.IsCtrlModifier M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void IsCtrlModifier_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Key key = new Key();
            Assert.IsFalse(key.IsCtrlModifier(), "Shold be false now!");
        }

        [Test]
        [Category("P1")]
        [Description("Test IsAltModifier.Check whether IsAltModifier returns the value expected.")]
        [Property("SPEC", "Tizen.NUI.Key.IsAltModifier M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void IsAltModifier_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Key key = new Key();
            Assert.IsFalse(key.IsAltModifier(), "Shold be false now!");
        }

        [Test]
        [Category("P1")]
        [Description("Test DeviceClass. Check whether DeviceClass returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Key.DeviceClass A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void DeviceClass_GET_VALUE()
        {
            /* TEST CODE */
            Key key = new Key();
            Assert.AreEqual(DeviceClassType.None, key.DeviceClass, "DeviceClass shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test DeviceName. Check whether DeviceName returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Key.DeviceName A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void DeviceName_GET_VALUE()
        {
            /* TEST CODE */
            Key key = new Key();
            Assert.AreEqual("", key.DeviceName, "DeviceName shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test DeviceSubClass. Check whether DeviceSubClass returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Key.DeviceSubClass A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void DeviceSubClass_GET_VALUE()
        {
            /* TEST CODE */
            Key key = new Key();
            Assert.AreEqual(DeviceSubClassType.None, key.DeviceSubClass, "DeviceSubClass shold be equals to the default value");
        }

        [Test]
        [Category("P1")]
        [Description("Test KeyCode. Check whether KeyCode is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Key.KeyCode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void KeyCode_SET_GET_VALUE()
        {
            /* TEST CODE */
            Key key = new Key();
            key.KeyCode = 99;
            Assert.AreEqual(99, key.KeyCode, "KeyCode shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test KeyModifier. Check whether KeyModifier returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Key.KeyModifier A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void KeyModifier_GET_VALUE()
        {
            /* TEST CODE */
            Key key = new Key();
            Assert.AreEqual(0, key.KeyModifier, "KeyModifier shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test KeyPressedName. Check whether KeyPressedName returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Key.KeyPressedName A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void KeyPressedName_GET_VALUE()
        {
            /* TEST CODE */
            Key key = new Key();
            Assert.AreEqual("", key.KeyPressedName, "KeyPressedName shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Time.Check whether Time returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Key.Time A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Time_GET_VALUE()
        {
            /* TEST CODE */
            Key key = new Key();
            Assert.AreEqual(0, key.Time, "Time shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test State.Check whether State returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Key.State A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void State_GET_VALUE()
        {
            /* TEST CODE */
            Key key = new Key();
            Assert.AreEqual(Key.StateType.Down, key.State, "State shold be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Key.")]
        [Property("SPEC", "Tizen.NUI.Key.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                Key key = new Key();
                key.Dispose();
            }
            catch (Exception e)
            {
                Tizen.Log.Error("Test CellPosition.cs", "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
    }
}
