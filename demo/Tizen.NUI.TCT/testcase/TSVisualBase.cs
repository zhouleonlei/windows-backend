using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.VisualBase Tests")]
    public class VisualBaseTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("VisualBaseTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali VisualBase constructor test")]
        [Property("SPEC", "Tizen.NUI.VisualBase.VisualBase C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void VisualBase_INIT()
        {
            /* TEST CODE */
            var visualbase = new VisualBase();
            Assert.IsInstanceOf<VisualBase>(visualbase, "Should return VisualBase instance.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Name. Check whether Name is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualBase.Name A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Name_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualFactory visualfactory = VisualFactory.Instance;
            PropertyMap textMap1 = new PropertyMap();
            textMap1.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
            textMap1.Insert(TextVisualProperty.Text, new PropertyValue("Hello Goodbye"));
            VisualBase textVisual1 = visualfactory.CreateVisual(textMap1);
            textVisual1.Name = "VisualBase1";
            Assert.AreEqual("VisualBase1", textVisual1.Name, "Name function does not work, return incorrect name.");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetTransformAndSize. Check whether SetTransformAndSize returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.VisualBase.SetTransformAndSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void SetTransformAndSize_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                VisualFactory visualfactory = VisualFactory.Instance;
                PropertyMap textMap1 = new PropertyMap();
                textMap1.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
                textMap1.Insert(Visual.Property.Type, new PropertyValue("Hello Goodbye"));
                VisualBase textVisual1 = visualfactory.CreateVisual(textMap1);
                Vector2 vec2 = new Vector2(2.0f, 0.8f);
                textVisual1.SetTransformAndSize(textMap1, vec2);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.IsTrue(e is ArgumentException, "Argument Exception Not Recieved");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test GetHeightForWidth. Check whether GetHeightForWidth returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.VisualBase.GetHeightForWidth M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void GetHeightForWidth_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            VisualFactory visualfactory = VisualFactory.Instance;
            PropertyMap map = new PropertyMap();
            map.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
            map.Insert(Visual.Property.Type, new PropertyValue(""));
            VisualBase visual = visualfactory.CreateVisual(map);
            var height = visual.GetHeightForWidth(0.0f);
            Assert.AreEqual(0.0f, height, "The height got from GetHeightForWidth is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetWidthForHeight. Check whether GetWidthForHeight returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.VisualBase.GetWidthForHeight M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void GetWidthForHeight_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            VisualFactory visualfactory = VisualFactory.Instance;
            PropertyMap map = new PropertyMap();
            map.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
            map.Insert(Visual.Property.Type, new PropertyValue(""));
            VisualBase visual = visualfactory.CreateVisual(map);
            var width = visual.GetWidthForHeight(0.0f);
            Assert.AreEqual(0.0f, width, "The Width got from GetWidthForHeight is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetNaturalSize. Check whether GetNaturalSize returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.VisualBase.GetNaturalSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void GetNaturalSize_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                VisualFactory visualfactory = VisualFactory.Instance;
                PropertyMap textMap1 = new PropertyMap();
                textMap1.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
                VisualBase textVisual1 = visualfactory.CreateVisual(textMap1);
                Size2D size2d = new Size2D(1, 2);
                textVisual1.GetNaturalSize(size2d);
                Assert.AreEqual(0.0f, size2d.Height, "The Height got from GetNaturalSize is not right");
                Assert.AreEqual(0.0f, size2d.Width, "The Width got from GetNaturalSize is not right");
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
        [Description("Test DepthIndex. Check whether DepthIndex is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.VisualBase.DepthIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void DepthIndex_SET_GET_VALUE()
        {
            /* TEST CODE */
            VisualFactory visualfactory = VisualFactory.Instance;
            PropertyMap textMap1 = new PropertyMap();
            textMap1.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
            textMap1.Insert(Visual.Property.Type, new PropertyValue("Hello Goodbye"));
            VisualBase textVisual1 = visualfactory.CreateVisual(textMap1);
            textVisual1.DepthIndex = 1;
            Assert.AreEqual(1, textVisual1.DepthIndex, "The DepthIndex got from DepthIndex is not right");
        }

        [Test]
        [Category("P1")]
        [Description("Test Creation. Check whether Creation returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.VisualBase.Creation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Creation_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                VisualFactory visualfactory = VisualFactory.Instance;
                PropertyMap textMap1 = new PropertyMap();
                textMap1.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
                textMap1.Insert(TextVisualProperty.Text, new PropertyValue("Hello"));
                textMap1.Insert(TextVisualProperty.PointSize, new PropertyValue(10.0f));

                PropertyMap textMap2 = new PropertyMap();
                VisualBase textVisual1 = visualfactory.CreateVisual(textMap1);
                textMap2 = textVisual1.Creation;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.IsTrue(e is ArgumentException, "Argument Exception Not Recieved");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the VisualBase.")]
        [Property("SPEC", "Tizen.NUI.VisualBase.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                VisualBase visualbase = new VisualBase();
                visualbase.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
    }
}