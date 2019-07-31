using NUnit.Framework;
using Tizen.NUI;
using System;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.VisualFactory Tests")]
    public class VisualFactoryTests
    {
        private string TAG = "NUI";
        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("VisualFactoryTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Test CreateVisual. Check whether CreateVisual returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.VisualFactory.CreateVisual M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void CreateVisual_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            VisualFactory visualfactory = VisualFactory.Instance;
            PropertyMap textMap1 = new PropertyMap();
            textMap1.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
            textMap1.Insert(TextVisualProperty.Text, new PropertyValue("Hello Goodbye"));
            var textVisual1 = visualfactory.CreateVisual(textMap1);
            Assert.IsInstanceOf<VisualBase>(textVisual1, "CreateVisual Should return VisualBase instance.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Instance. Check whether Instance returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.VisualFactory.Instance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Zaijuan Sui, z6177.sui@samsung.com")]
        public void Instance_GET_VALUE()
        {
            /* TEST CODE */
            VisualFactory visualfactory = VisualFactory.Instance;
            Assert.IsInstanceOf<VisualFactory>(visualfactory, "Should return VisualFactory instance.");
        }

    }
}