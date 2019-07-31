using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.SWIGTYPE_p_bundle Tests")]
    public class SWIGTYPE_p_bundleTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("SWIGTYPE_p_bundleTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a MySWIGTYPE_p_bundle object. Check whether MySWIGTYPE_p_bundle is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.SWIGTYPE_p_bundle.SWIGTYPE_p_bundle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SWIGTYPE_p_bundle_INIT()
        {
            /* TEST CODE */
            var mySWIGTYPE_P_Bundle = new MySWIGTYPE_p_bundle();
            Assert.IsNotNull(mySWIGTYPE_P_Bundle, "Can't create success object MySWIGTYPE_p_bundle");
            Assert.IsInstanceOf<MySWIGTYPE_p_bundle>(mySWIGTYPE_P_Bundle, "Should be an instance of MySWIGTYPE_p_bundle type.");
        }

    }

    public class MySWIGTYPE_p_bundle : SWIGTYPE_p_bundle
    {

    }
}
