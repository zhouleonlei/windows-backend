using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.StyleManager.StyleChangedEventArgs Tests")]
    public class StyleChangedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("StyleChangedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a StyleChangedEventArgs object. Check whether StyleChangedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.StyleManager.StyleChangedEventArgs.StyleChangedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void StyleChangedEventArgs_INIT()
        {
            /* TEST CODE */
            var styleChangedEventArgs = new StyleManager.StyleChangedEventArgs();
            Assert.IsNotNull(styleChangedEventArgs, "Can't create success object StyleChangedEventArgs");
            Assert.IsInstanceOf<StyleManager.StyleChangedEventArgs>(styleChangedEventArgs, "Should be an instance of StyleChangedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test StyleManager. Check whether StyleManager is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.StyleManager.StyleChangedEventArgs.StyleManager A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void StyleManager_SET_GET_VALUE()
        {
            /* TEST CODE */
            StyleManager.StyleChangedEventArgs styleChangedEventArgs = new StyleManager.StyleChangedEventArgs();
            StyleManager styleManager = new StyleManager();
            styleChangedEventArgs.StyleManager = styleManager;
            Assert.AreEqual(styleManager, styleChangedEventArgs.StyleManager, "Retrieved StyleManager should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test StyleChange. Check whether StyleChange is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.StyleManager.StyleChangedEventArgs.StyleChange A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void StyleChange_SET_GET_VALUE()
        {
            /* TEST CODE */
            StyleManager.StyleChangedEventArgs styleChangedEventArgs = new StyleManager.StyleChangedEventArgs();
            styleChangedEventArgs.StyleChange = StyleChangeType.DefaultFontChange;
            Assert.AreEqual(StyleChangeType.DefaultFontChange, styleChangedEventArgs.StyleChange, "Retrieved StyleChange should be equal to set value");
        }
    }
}
