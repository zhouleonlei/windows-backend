using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Sampler Tests")]

    public class SamplerTests
    {
        private string TAG = "NUI";

        [Test]
        [Category("P1")]
        [Description("Create a Sampler object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Sampler.Sampler C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void Sampler_INIT()
        {
            /* TEST CODE */
            var sSampler = new Sampler();
            Assert.IsNotNull(sSampler, "Can't create success object Sampler");
            Assert.IsInstanceOf<Sampler>(sSampler, "Should be an instance of Sampler type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetFilterMode.Test whether SetFilterMode works or not")]
        [Property("SPEC", "Tizen.NUI.Sampler.SetFilterMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void SetFilterMode_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            var sSampler = new Sampler();
            try
            {
                sSampler.SetFilterMode(FilterModeType.NEAREST, FilterModeType.NEAREST_MIPMAP_LINEAR);
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
        [Description("Test SetWrapMode.Test whether SetWrapMode works or not")]
        [Property("SPEC", "Tizen.NUI.Sampler.SetWrapMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "WrapModeType, WrapModeType")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void SetWrapMode_CHECK_RETURN_TYPE_WITH_TWO_PARA()
        {
            /* TEST CODE */
            var sSampler = new Sampler();
            try
            {
                sSampler.SetWrapMode(WrapModeType.Default, WrapModeType.ClampToEdge);
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
        [Description("Test SetWrapMode.Test whether SetWrapMode works or not")]
        [Property("SPEC", "Tizen.NUI.Sampler.SetWrapMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "WrapModeType, WrapModeType, WrapModeType")]
        [Property("AUTHOR", "Chen Zhihao, zhihao.chen@samsung.com")]
        public void SetWrapMode_CHECK_RETURN_TYPE_WITH_THREE_PARA()
        {
            /* TEST CODE */
            var sSampler = new Sampler();
            try
            {
                sSampler.SetWrapMode(WrapModeType.Default, WrapModeType.ClampToEdge, WrapModeType.Repeat);
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


