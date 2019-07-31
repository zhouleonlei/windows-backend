using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.FontClient Tests")]
    public class FontClientTests
    {
        private string TAG = "NUI-TCT";
        private string ttf_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "TizenSansRegular.ttf";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Instance Test. Check whether Instance property will return a not null instance of FontClient.")]
        [Property("SPEC", "Tizen.NUI.FontClient.Instance C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Instance_INIT()
        {
            /* TEST CODE */
            var instance = FontClient.Instance;
            Assert.IsNotNull(instance, "Return a null object of FontClient");
        }

        [Test]
        [Category("P1")]
        [Description("AddCustomFontDirectory Test. Check whether AddCustomFontDirectory method works or not.")]
        [Property("SPEC", "Tizen.NUI.FontClient.AddCustomFontDirectory M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AddCustomFontDirectory_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var instance = FontClient.Instance;
            Assert.IsNotNull(instance, "Return a null object of FontClient");
            bool flag = instance.AddCustomFontDirectory(ttf_path);
            Assert.IsTrue(flag, "The fonts can not be added");
        }

        [Test]
        [Category("P1")]
        [Description("FindDefaultFont Test. Check whether FindDefaultFont method works or not.")]
        [Property("SPEC", "Tizen.NUI.FontClient.FindDefaultFont M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "uint, uint, bool")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void FindDefaultFont_CHECK_RETURN_VALUE_WITH_UINT_UINT_BOOL()
        {
            /* TEST CODE */
            var instance = FontClient.Instance;
            Assert.IsNotNull(instance, "Return a null object of FontClient");
            uint charcode = 0x0041;
            uint font = instance.FindDefaultFont(charcode, 768, false);
            Assert.Greater(font, 0, "font should be greater than zero.");
        }

        [Test]
        [Category("P1")]
        [Description("FindDefaultFont Test. Check whether FindDefaultFont method works or not.")]
        [Property("SPEC", "Tizen.NUI.FontClient.FindDefaultFont M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "uint, uint")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void FindDefaultFont_CHECK_RETURN_VALUE_WITH_UINT_UINT()
        {
            /* TEST CODE */
            var instance = FontClient.Instance;
            Assert.IsNotNull(instance, "Return a null object of FontClient");
            uint charcode = 0x0041;
            uint font = instance.FindDefaultFont(charcode, 768);
            Assert.Greater(font, 0, "font should be greater than zero.");
        }

        [Test]
        [Category("P1")]
        [Description("FindDefaultFont Test. Check whether FindDefaultFont method works or not.")]
        [Property("SPEC", "Tizen.NUI.FontClient.FindDefaultFont M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "uint")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void FindDefaultFont_CHECK_RETURN_VALUE_WITH_UINT()
        {
            /* TEST CODE */
            var instance = FontClient.Instance;
            Assert.IsNotNull(instance, "Return a null object of FontClient");
            uint charcode = 0x0041;
            uint font = instance.FindDefaultFont(charcode);
            Assert.Greater(font, 0, "font should be greater than zero.");
        }

        [Test]
        [Category("P1")]
        [Description("GetFontId Test. Check whether GetFontId method works or not.")]
        [Property("SPEC", "Tizen.NUI.FontClient.GetFontId M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "string, uint, uint")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetFontId_CHECK_RETURN_VALUE_WITH_STRING_UINT_UINT()
        {
            /* TEST CODE */
            var instance = FontClient.Instance;
            Assert.IsNotNull(instance, "Return a null object of FontClient");
            uint charcode = 0x0041;
            uint id = instance.GetFontId(ttf_path, 768, 0);
            Assert.AreEqual(0, id, "Id should equal 0!");
        }

        [Test]
        [Category("P1")]
        [Description("GetFontId Test. Check whether GetFontId method works or not.")]
        [Property("SPEC", "Tizen.NUI.FontClient.GetFontId M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "string, uint")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetFontId_CHECK_RETURN_VALUE_WITH_STRING_UINT()
        {
            /* TEST CODE */
            var instance = FontClient.Instance;
            Assert.IsNotNull(instance, "Return a null object of FontClient");
            uint charcode = 0x0041;
            uint id = instance.GetFontId(ttf_path, 768);
            Assert.AreEqual(0, id, "Id should equal 0!");
        }

        [Test]
        [Category("P1")]
        [Description("GetFontId Test. Check whether GetFontId method works or not.")]
        [Property("SPEC", "Tizen.NUI.FontClient.GetFontId M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "string")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetFontId_CHECK_RETURN_VALUE_WITH_STRING()
        {
            /* TEST CODE */
            var instance = FontClient.Instance;
            Assert.IsNotNull(instance, "Return a null object of FontClient");
            uint charcode = 0x0041;
            uint id = instance.GetFontId(ttf_path);
            Assert.AreEqual(0, id, "Id should equal 0!");
        }

        [Test]
        [Category("P1")]
        [Description("GetPointSize Test. Check whether GetPointSize method works or not.")]
        [Property("SPEC", "Tizen.NUI.FontClient.GetPointSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetPointSize_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var instance = FontClient.Instance;
            Assert.IsNotNull(instance, "Return a null object of FontClient");
            uint id = instance.GetPointSize(0);
            Assert.AreEqual(768, id, "Id should equal 768!");
        }

        [Test]
        [Category("P1")]
        [Description("IsCharacterSupportedByFont Test. Check whether IsCharacterSupportedByFont method works or not.")]
        [Property("SPEC", "Tizen.NUI.FontClient.IsCharacterSupportedByFont M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void IsCharacterSupportedByFont_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var instance = FontClient.Instance;
            Assert.IsNotNull(instance, "Return a null object of FontClient");
            bool flag = instance.IsCharacterSupportedByFont(0, 0);
            Assert.IsFalse(flag, "flag should be false!");
        }

        [Test]
        [Category("P1")]
        [Description("IsScalable Test. Check whether IsScalable method works or not.")]
        [Property("SPEC", "Tizen.NUI.FontClient.IsScalable M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "string")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void IsScalable_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var instance = FontClient.Instance;
            Assert.IsNotNull(instance, "Return a null object of FontClient");
            bool flag = instance.IsScalable(ttf_path);
            Assert.IsFalse(flag, "flag should be false!");
        }

        [Test]
        [Category("P1")]
        [Description("ResetSystemDefaults Test. Check whether ResetSystemDefaults method works or not.")]
        [Property("SPEC", "Tizen.NUI.FontClient.ResetSystemDefaults M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "string")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ResetSystemDefaults_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                var instance = FontClient.Instance;
                Assert.IsNotNull(instance, "Return a null object of FontClient");
                instance.ResetSystemDefaults();
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
