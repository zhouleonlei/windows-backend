using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.Element Tests")]
    public class ElementTests
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
        [Description("Test AutomationId. Check whether AutomationId is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.AutomationId A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void AutomationId_SET_GET_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test ClassId. Check whether ClassId is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.ClassId A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ClassId_SET_GET_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Id. Check whether Id is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.Id A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Id_READ_ONLY()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test ParentView. Check whether ParentView is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.ParentView A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ParentView_READ_ONLY()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test StyleId. Check whether StyleId is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.StyleId A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void StyleId_SET_GET_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test LogicalChildren. Check whether LogicalChildren is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.LogicalChildren A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void LogicalChildren_READ_ONLY()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test RealParent. Check whether RealParent is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.RealParent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void RealParent_READ_ONLY()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Parent. Check whether Parent is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.Parent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Parent_SET_GET_VALUE()
        {
            /* TEST CODE */
        }


        [Test]
        [Category("P1")]
        [Description("Test OnBindingContextChanged. Check OnBindingContextChanged() of Element.")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.OnBindingContextChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void OnBindingContextChanged_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test OnChildAdded. Check OnChildAdded() of Element.")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.OnChildAdded M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void OnChildAdded_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test OnChildRemoved. Check OnChildRemoved() of Element.")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.OnChildRemoved M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void OnChildRemoved_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test OnParentSet. Check OnParentSet() of Element.")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.OnParentSet M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void OnParentSet_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test OnPropertyChanged. Check OnPropertyChanged() of Element.")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.OnPropertyChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void OnPropertyChanged_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Descendants. Check Descendants() of Element.")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.Descendants M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Descendants_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }


    }
}
