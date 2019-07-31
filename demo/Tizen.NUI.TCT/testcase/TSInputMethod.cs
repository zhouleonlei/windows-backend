using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.InputMethod Tests")]
    public class TSTInputMethodTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("InputMethodTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Test constructor.Check whether it works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethod.InputMethod C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void InputMethod_INIT()
        {
            var method = new InputMethod();
            Assert.NotNull(method, "Should be not null");
            Assert.IsInstanceOf<InputMethod>(method, "Should be the instance of InputMethod");
        }

        [Test]
        [Category("P1")]
        [Description("Test PanelLayout.Check whether PanelLayout works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethod.PanelLayout A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void PanelLayout_SET_GET_VALUE()
        {
            InputMethod method = new InputMethod();
            method.PanelLayout = InputMethod.PanelLayoutType.Normal;
            Assert.AreEqual(InputMethod.PanelLayoutType.Normal, method.PanelLayout, "Should be equals to the method.PanelLayout set");
        }

        [Test]
        [Category("P1")]
        [Description("Test ActionButton.Check whether ActionButton works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethod.ActionButton A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void ActionButton_SET_GET_VALUE()
        {
            InputMethod method = new InputMethod();
            method.ActionButton = InputMethod.ActionButtonTitleType.Go;
            Assert.AreEqual(InputMethod.ActionButtonTitleType.Go, method.ActionButton, "Should be equals to the method.ActionButton set");
        }

        [Test]
        [Category("P1")]
        [Description("Test AutoCapital.Check whether AutoCapital works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethod.AutoCapital A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void AutoCapital_SET_GET_VALUE()
        {
            InputMethod method = new InputMethod();
            method.AutoCapital = InputMethod.AutoCapitalType.Word;
            Assert.AreEqual(InputMethod.AutoCapitalType.Word, method.AutoCapital, "Should be equals to the method.AutoCapital set");
        }

        [Test]
        [Category("P1")]
        [Description("Test Variation.Check whether Variation works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethod.Variation A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void Variation_SET_GET_VALUE()
        {
            InputMethod method = new InputMethod();
            method.Variation = 1;
            Assert.AreEqual(1, method.Variation, "Should be equals to the method.Variation set");
        }

        [Test]
        [Category("P1")]
        [Description("Test NormalVariation.Check whether NormalVariation works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethod.NormalVariation A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void NormalVariation_SET_GET_VALUE()
        {
            InputMethod method = new InputMethod();
            method.NormalVariation = InputMethod.NormalLayoutType.WithFilename;
            Assert.AreEqual(InputMethod.NormalLayoutType.WithFilename, method.NormalVariation, "Should be equals to the method.NormalVariation set");
        }

        [Test]
        [Category("P1")]
        [Description("Test NumberOnlyVariation.Check whether NumberOnlyVariation works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethod.NumberOnlyVariation A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void NumberOnlyVariation_SET_GET_VALUE()
        {
            InputMethod method = new InputMethod();
            method.NumberOnlyVariation = InputMethod.NumberOnlyLayoutType.WithSigned;
            Assert.AreEqual(InputMethod.NumberOnlyLayoutType.WithSigned, method.NumberOnlyVariation, "Should be equals to the method.NumberOnlyVariation set");
        }

        [Test]
        [Category("P1")]
        [Description("Test PasswordVariation.Check whether PasswordVariation works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethod.PasswordVariation A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void PasswordVariation_SET_GET_VALUE()
        {
            InputMethod method = new InputMethod();
            method.PasswordVariation = InputMethod.PasswordLayoutType.WithNumberOnly;
            Assert.AreEqual(InputMethod.PasswordLayoutType.WithNumberOnly, method.PasswordVariation, "Should be equals to the method.PasswordVariation set");
        }

        [Test]
        [Category("P1")]
        [Description("Test OutputMap.Check whether OutputMap works or not.")]
        [Property("SPEC", "Tizen.NUI.InputMethod.OutputMap A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void OutputMap_GET_VALUE()
        {
            InputMethod method = new InputMethod();
            method.PanelLayout = InputMethod.PanelLayoutType.Normal;
            method.ActionButton = InputMethod.ActionButtonTitleType.Default;
            method.AutoCapital = InputMethod.AutoCapitalType.Word;
            method.Variation = 1;

            PropertyMap map = method.OutputMap;
            Assert.IsNotNull(map, "The outputMap should be not null");
        }
    }
}