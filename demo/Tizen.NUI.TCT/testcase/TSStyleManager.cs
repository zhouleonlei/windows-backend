using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;
using Tizen.NUI.Test;

namespace NUIStyleManager.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.StyleManager Tests")]
    public class StyleManagerTests
    {
        private string TAG = "NUI";
        private string path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Test_Style_Manager.json";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("StyleManagerTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a StyleManager object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.StyleManager.StyleManager C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void StyleManager_INIT()
        {
            /* TEST CODE */
            var styleManager = new StyleManager();
            Assert.IsNotNull(styleManager, "Can't create success object StyleManager");
            Assert.IsInstanceOf<StyleManager>(styleManager, "Should be an instance of StyleManager type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get.Check whether Get returns expected value or not")]
        [Property("SPEC", "Tizen.NUI.StyleManager.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Get_CHECK_VALUE()
        {
            /* TEST CODE */
            StyleManager styleManager = StyleManager.Get();
            Assert.IsNotNull(styleManager, "The value of Get return should not be null");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get.Check whether Instance property return a StyleManager instance successfully.")]
        [Property("SPEC", "Tizen.NUI.StyleManager.Instance A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Instance_READ_ONLY()
        {
            StyleManager instance = StyleManager.Instance;
            Assert.NotNull(instance, "Should not be null to the StyleManager.Instance");
        }

        [Test]
        [Category("P1")]
        [Description("Test StyleManager.Check whether StyleManager can change style successfully")]
        [Property("SPEC", "Tizen.NUI.StyleManager.ApplyTheme M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ApplyTheme_CHECK_VALUE()
        {
            /* TEST CODE */
            StyleManager styleManager = StyleManager.Get();
            TextLabel text = new TextLabel("Hello");
            Window.Instance.GetDefaultLayer().Add(text);
            styleManager.ApplyTheme(path);
            float pointSize = text.PointSize;
            Assert.AreEqual(10.0f, pointSize, "Should be equals to the set value of text.PointSize");
        }

        [Test]
        [Category("P1")]
        [Description("Test ApplyDefaultTheme.Check whether StyleManager can change style to default theme successfully")]
        [Property("SPEC", "Tizen.NUI.StyleManager.ApplyDefaultTheme M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ApplyDefaultTheme_CHECK_VALUE()
        {
            /* TEST CODE */
            StyleManager styleManager = StyleManager.Get();
            TextLabel text = new TextLabel();
            Window.Instance.GetDefaultLayer().Add(text);
            styleManager.ApplyDefaultTheme();
            Color bg = text.TextColor;
            Assert.AreEqual(0.0f, bg.R, "Should be equals to the set value of text.BackGroundColor.R");
            Assert.AreEqual(0.0f, bg.G, "Should be equals to the set value of text.BackGroundColor.G");
            Assert.AreEqual(0.0f, bg.B, "Should be equals to the set value of text.BackGroundColor.B");
            Assert.AreEqual(1.0f, bg.A, "Should be equals to the set value of text.BackGroundColor.A");
        }

        [Test]
        [Category("P1")]
        [Description("Test ApplyStyle.Check whether ApplyStyle can apply style successfully")]
        [Property("SPEC", "Tizen.NUI.StyleManager.ApplyStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ApplyStyle_CHECK_VALUE()
        {
            /* TEST CODE */
            StyleManager styleManager = StyleManager.Get();
            TextLabel text = new TextLabel();
            Window.Instance.GetDefaultLayer().Add(text);
            styleManager.ApplyStyle(text, path, "TextLabel");
            float pointSize = text.PointSize;
            Assert.AreEqual(10.0f, pointSize, "Should be equals to the set value of text.PointSize");
        }

        [Test]
        [Category("P1")]
        [Description("Test AddConstant.Test whether the method can set StyleConstant successfully")]
        [Property("SPEC", "Tizen.NUI.StyleManager.AddConstant M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void AddConstant_CHECK_VALUE()
        {
            /* TEST CODE */
            StyleManager styleManager = StyleManager.Get();
            String key = "key";
            PropertyValue value = new PropertyValue(100);
            styleManager.AddConstant(key, value);
            PropertyValue outvalue = new PropertyValue();
            styleManager.GetConstant(key, outvalue);
            int num1 = 0, num2 = 0;
            value.Get(out num1);
            outvalue.Get(out num2);
            Assert.IsTrue(num1 == num2, "The get value of StyleConstant should be equals to the set");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetConstant.Test whether GetConstant returns the value expected")]
        [Property("SPEC", "Tizen.NUI.StyleManager.GetConstant M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void GetConstant_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            StyleManager styleManager = StyleManager.Get();
            String key = "key";
            PropertyValue value = new PropertyValue(100);
            styleManager.AddConstant(key, value);
            PropertyValue outvalue = new PropertyValue();
            styleManager.GetConstant(key, outvalue);
            int num1 = 0, num2 = 0;
            value.Get(out num1);
            outvalue.Get(out num2);
            Assert.IsTrue(num1 == num2, "The get value of StyleConstant should be equals to the set");
        }

        [Test]
        [Category("P1")]
        [Description("Test StyleChanged.Check whether StyleChanged defined in the spec is callable.")]
        [Property("SPEC", "Tizen.NUI.StyleManager.StyleChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void StyleChanged_CHECK_EVENT()
        {
            TextLabel text = new TextLabel("hello");
            Window.Instance.GetDefaultLayer().Add(text);
            StyleManager styleManager = StyleManager.Get();
            styleManager.StyleChanged += StyleManager_StyleChanged;
            styleManager.ApplyTheme(path);
            Tizen.Log.Info(TAG, "theme path=" + path);
            Assert.IsTrue(flag, "StyleChanged is not be called");
        }
        private bool flag = false;
        private void StyleManager_StyleChanged(object sender, StyleManager.StyleChangedEventArgs e)
        {
            flag = true;
        }
    }
}
