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
    [Description("Tizen.NUI.Shader.Hint Tests")]
    public class ShaderHintTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("HintTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Hint.Check whether Hint is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Shader.Hint.Hint C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Youxia Wu, youxia17.wu@samsung.com")]
        public void Hint_INIT()
        {
            Shader.Hint hint = new Shader.Hint();
            Assert.IsNotNull(hint, "Can't create success object Hint");
            Assert.IsInstanceOf<Shader.Hint>(hint, "Should be an instance of Hint type.");
        }
    }
}