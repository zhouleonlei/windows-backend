using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Spin Tests")]
    public class SpinTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("SpinTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a Spin object.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Spin.Spin C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Spin_INIT()
        {
            /* TEST CODE */
            var spin = new Spin();
            Assert.IsNotNull(spin, "Can't create success object Spin");
            Assert.IsInstanceOf<Spin>(spin, "Should be an instance of Spin type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Value. Check whether Value is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Spin.Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Value_SET_GET_VALUE()
        {
            /* TEST CODE */
            Spin spin = new Spin();
            spin.MinValue = 1;
            spin.MaxValue = 100;
            spin.Value = 10;
            Assert.AreEqual(10, spin.Value, "Retrieved Value should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test MinValue. Check whether MinValue is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Spin.MinValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void MinValue_SET_GET_VALUE()
        {
            /* TEST CODE */
            Spin spin = new Spin();
            spin.MinValue = 1;
            Assert.AreEqual(1, spin.MinValue, "Retrieved MinValue should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test MaxValue. Check whether MaxValue is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Spin.MaxValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void MaxValue_SET_GET_VALUE()
        {
            /* TEST CODE */
            Spin spin = new Spin();
            spin.MaxValue = 100;
            Assert.AreEqual(100, spin.MaxValue, "Retrieved MaxValue should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Step. Check whether Step is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Spin.Step A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Step_SET_GET_VALUE()
        {
            /* TEST CODE */
            Spin spin = new Spin();
            spin.Step = 1;
            Assert.AreEqual(1, spin.Step, "Retrieved Step should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test WrappingEnabled. Check whether WrappingEnabled is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Spin.WrappingEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void WrappingEnabled_SET_GET_VALUE()
        {
            /* TEST CODE */
            Spin spin = new Spin();
            spin.WrappingEnabled = true;
            Assert.AreEqual(true, spin.WrappingEnabled, "Retrieved WrappingEnabled should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test TextPointSize. Check whether TextPointSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Spin.TextPointSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TextPointSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            Spin spin = new Spin();
            spin.TextPointSize = 1;
            Assert.AreEqual(1, spin.TextPointSize, "Retrieved TextPointSize should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test TextColor. Check whether TextColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Spin.TextColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TextColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            Spin spin = new Spin();
            Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            spin.TextColor = color;
            Assert.AreEqual(1.0f, spin.TextColor.R, "Retrieved TextColor.R should be equal to set value");
            Assert.AreEqual(1.0f, spin.TextColor.G, "Retrieved TextColor.G should be equal to set value");
            Assert.AreEqual(1.0f, spin.TextColor.B, "Retrieved TextColor.B should be equal to set value");
            Assert.AreEqual(1.0f, spin.TextColor.A, "Retrieved TextColor.A should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test MaxTextLength. Check whether MaxTextLength is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Spin.MaxTextLength A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void MaxTextLength_SET_GET_VALUE()
        {
            /* TEST CODE */
            Spin spin = new Spin();
            spin.MaxTextLength = 10;
            Assert.AreEqual(10, spin.MaxTextLength, "Retrieved MaxTextLength should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SpinText. Check whether SpinText is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Spin.SpinText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SpinText_SET_GET_VALUE()
        {
            /* TEST CODE */
            Spin spin = new Spin();
            TextField textField = new TextField();
            spin.SpinText = textField;
            Assert.IsTrue(textField == spin.SpinText, "Retrieved SpinText should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test IndicatorImage. Check whether IndicatorImage is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Spin.IndicatorImage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void IndicatorImage_SET_GET_VALUE()
        {
            /* TEST CODE */
            Spin spin = new Spin();
            spin.IndicatorImage = "IndicatorImage";
            Assert.AreEqual("IndicatorImage", spin.IndicatorImage, "Retrieved IndicatorImage should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test whether OnInitialize chang sone valus execepted")]
        [Property("SPEC", "Tizen.NUI.Spin.OnInitialize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void OnInitialize_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                Spin spin = new Spin();
                spin.OnInitialize();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test whether GetNextFocusableView return the right value or not")]
        [Property("SPEC", "Tizen.NUI.Spin.GetNextFocusableView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void GetNextFocusableView_CHECK_VALUE()
        {
            /* TEST CODE */
            Spin spin = new Spin();
            FocusManager.Instance.SetCurrentFocusView(spin);
            View view = spin.GetNextFocusableView(spin, View.FocusDirection.Up, false);
            Assert.IsNotNull(view, "Should be not null");
        }

        [Test]
        [Category("P1")]
        [Description("Test whether GetNaturalSize return the right value or not")]
        [Property("SPEC", "Tizen.NUI.Spin.GetNaturalSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetNaturalSize_CHECK_VALUE()
        {
            /* TEST CODE */
            Spin spin = new Spin();
            Size2D natureSize = spin.GetNaturalSize();
            Assert.AreEqual(150, natureSize.Width, "Should be 150");
            Assert.AreEqual(150, natureSize.Height, "Should be 150");
        }

        [Test]
        [Category("P1")]
        [Description("Test whether TextFieldKeyInputFocusGained chang some valus execepted")]
        [Property("SPEC", "Tizen.NUI.Spin.TextFieldKeyInputFocusGained M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TextFieldKeyInputFocusGained_CHECK_VALUE()
        {
            try
            {
                Spin spin = new Spin();
                spin.Focusable = true;
                Window.Instance.GetDefaultLayer().Add(spin);
                TextField textField = spin.SpinText;
                textField.FocusGained += spin.TextFieldKeyInputFocusGained;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test whether TextFieldKeyInputFocusLost chang some valus execepted")]
        [Property("SPEC", "Tizen.NUI.Spin.TextFieldKeyInputFocusLost M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TextFieldKeyInputFocusLost_CHECK_VALUE()
        {
            try
            {
                Spin spin = new Spin();
                TextField textField = spin.SpinText;
                textField.FocusLost += spin.TextFieldKeyInputFocusLost;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Spin.")]
        [Property("SPEC", "Tizen.NUI.Spin.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                Spin spin = new Spin();
                spin.Dispose();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
    }
}
