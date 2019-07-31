using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.BindableObject Tests")]
    public class BindableObjectTests
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
        [Description("Test BindingContext. Check whether BindingContext is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.BindingContext A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void BindingContext_SET_GET_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test IsCreateByXaml. Check whether IsCreateByXaml is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.IsCreateByXaml A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void IsCreateByXaml_SET_GET_VALUE()
        {
            /* TEST CODE */
        }


        [Test]
        [Category("P1")]
        [Description("Test GetValue. Check GetValue() of BindableObject.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.GetValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void GetValue_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test SetBinding. Check SetBinding() of BindableObject.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.SetBinding M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void SetBinding_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test SetValue. Check SetValue() of BindableObject.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.SetValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "BindableProperty, Object")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void SetValue_CHECK_RETURN_VALUE_WITH_BINDABLEPROPERTY_OBJECT()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test SetValue. Check SetValue() of BindableObject.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.SetValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "BindablePropertyKey, Object")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void SetValue_CHECK_RETURN_VALUE_WITH_BINDABLEPROPERTYKEY_OBJECT()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test SetInheritedBindingContext. Check SetInheritedBindingContext() of BindableObject.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.SetInheritedBindingContext M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void SetInheritedBindingContext_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test ApplyBindings. Check ApplyBindings() of BindableObject.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.ApplyBindings M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ApplyBindings_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test OnBindingContextChanged. Check OnBindingContextChanged() of BindableObject.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.OnBindingContextChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void OnBindingContextChanged_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test OnPropertyChanged. Check OnPropertyChanged() of BindableObject.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.OnPropertyChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void OnPropertyChanged_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test OnPropertyChanging. Check OnPropertyChanging() of BindableObject.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.OnPropertyChanging M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void OnPropertyChanging_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test UnapplyBindings. Check UnapplyBindings() of BindableObject.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.UnapplyBindings M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void UnapplyBindings_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test PropertyChanged. Test whether the PropertyChanged event will be triggered.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.PropertyChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void PropertyChanged_CHECK_EVENT()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test BindingContextChanged. Test whether the BindingContextChanged event will be triggered.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.BindingContextChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void BindingContextChanged_CHECK_EVENT()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test PropertyChanging. Test whether the PropertyChanging event will be triggered.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.PropertyChanging E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void PropertyChanging_CHECK_EVENT()
        {
            /* TEST CODE */
        }


    }
}
