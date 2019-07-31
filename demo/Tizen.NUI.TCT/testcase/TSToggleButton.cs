using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.ToggleButton Tests")]
    public class ToggleButtonTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";
        private string image_path1 = Tizen.Applications.Application.Current.DirectoryInfo.Resource +  "picture.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ToggleButtonTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a toggleButtonButton object.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.ToggleButton.ToggleButton C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ToggleButton_INIT()
        {
            /* TEST CODE */
            var toggleButton = new ToggleButton();

            Assert.IsNotNull(toggleButton, "Can't create success object ToggleButton");
            Assert.IsInstanceOf<ToggleButton>(toggleButton, "Should be an instance of ToggleButton type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test StateVisuals.Check whether StateVisuals works or not.")]
        [Property("SPEC", "Tizen.NUI.ToggleButton.StateVisuals A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void StateVisuals_SET_GET_VALUE()
        {
            /* TEST CODE */
            var toggleButton = new ToggleButton();
            PropertyArray array = new PropertyArray();
            array.Add(new PropertyValue(image_path));
            array.Add(new PropertyValue(image_path1));
            toggleButton.StateVisuals = array;

            Window.Instance.GetDefaultLayer().Add(toggleButton);

            PropertyArray array1 = toggleButton.StateVisuals;
            PropertyValue value = array1[0];
            string imagePath;
            value.Get(out imagePath);
            Assert.AreEqual(image_path, imagePath, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test CurrentStateIndex.Check whether CurrentStateIndex works or not.")]
        [Property("SPEC", "Tizen.NUI.ToggleButton.CurrentStateIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void CurrentStateIndex_SET_GET_VALUE()
        {
            /* TEST CODE */
            var toggleButton = new ToggleButton();
            PropertyArray array = new PropertyArray();
            array.Add(new PropertyValue(image_path));
            array.Add(new PropertyValue(image_path1));
            toggleButton.CurrentStateIndex = 0;

            Window.Instance.GetDefaultLayer().Add(toggleButton);
            Assert.AreEqual(0, toggleButton.CurrentStateIndex, "Should be equal!");
        }


        [Test]
        [Category("P1")]
        [Description("Test Tooltips.Check whether Tooltips works or not.")]
        [Property("SPEC", "Tizen.NUI.ToggleButton.Tooltips A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Tooltips_SET_GET_VALUE()
        {
            /* TEST CODE */
            var toggleButton = new ToggleButton();
            PropertyArray imageArray = new PropertyArray();
            imageArray.Add(new PropertyValue(image_path));
            imageArray.Add(new PropertyValue(image_path1));
            toggleButton.StateVisuals = imageArray;

            PropertyArray tipArray = new PropertyArray();
            tipArray.Add(new PropertyValue("ON"));
            tipArray.Add(new PropertyValue("OFF"));
            toggleButton.Tooltips = tipArray;

            Window.Instance.GetDefaultLayer().Add(toggleButton);

            PropertyArray array1 = toggleButton.Tooltips;
            PropertyValue value = array1[0];
            string tip;
            value.Get(out tip);
            Assert.AreEqual("ON", tip, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the ToggleButton.")]
        [Property("SPEC", "Tizen.NUI.ToggleButton.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                ToggleButton ToggleButton = new ToggleButton();
                ToggleButton.Dispose();
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
