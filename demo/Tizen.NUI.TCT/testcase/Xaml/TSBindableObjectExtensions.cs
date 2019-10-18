using NUnit.Framework;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.BindableObjectExtensions Tests")]
    public class BindableObjectExtensionsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Setup()
        {
            Tizen.Log.Info(TAG, "BindablePropertyTests-------------- - Setup()");
        }

        [TearDown]
        public void TearDown()
        {
            Tizen.Log.Info(TAG, "BindablePropertyTests-------------- - TearDown()");
        }


        [Test]
        [Category("P1")]
        [Description("Test SetBinding. Check SetBinding() of BindableObjectExtensions.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObjectExtensions.SetBinding M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void SetBinding_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            View view1 = new View();
            view1.IsCreateByXaml = true;

            View view2 = new View();
            view2.IsCreateByXaml = true;

            view1.BindingContext = view2;
            BindableObjectExtensions.SetBinding(view1, View.Size2DProperty, "Size2D");

            view2.Size2D = new Size2D(300, 200);

            Assert.IsTrue(view1.Size2D.Equals(new Size2D(300, 200)));

            view1?.Dispose();
        }
    }
}
