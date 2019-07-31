using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.ResourceDictionary Tests")]
    public class ResourceDictionaryTests
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
        [Description("Test MergedWith. Check whether MergedWith is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.MergedWith A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void MergedWith_SET_GET_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Source. Check whether Source is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.Source A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Source_SET_GET_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test MergedDictionaries. Check whether MergedDictionaries is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.MergedDictionaries A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void MergedDictionaries_READ_ONLY()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Count. Check whether Count is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.Count A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Count_READ_ONLY()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Item. Check whether Item is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.Item A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Item_SET_GET_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Keys. Check whether Keys is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.Keys A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Keys_READ_ONLY()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Values. Check whether Values is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.Values A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Values_READ_ONLY()
        {
            /* TEST CODE */
        }


        [Test]
        [Category("P1")]
        [Description("Test Construct. Check ResourceDictionary construct.")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.ResourceDictionary C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ResourceDictionary_INIT()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test SetAndLoadSource. Check SetAndLoadSource() of ResourceDictionary.")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.SetAndLoadSource M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void SetAndLoadSource_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Clear. Check Clear() of ResourceDictionary.")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.Clear M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Clear_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Add. Check Add() of ResourceDictionary.")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "String, Object")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Add_CHECK_RETURN_VALUE_WITH_STRING_OBJECT()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test ContainsKey. Check ContainsKey() of ResourceDictionary.")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.ContainsKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ContainsKey_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Remove. Check Remove() of ResourceDictionary.")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Remove_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test GetEnumerator. Check GetEnumerator() of ResourceDictionary.")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.GetEnumerator M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void GetEnumerator_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test TryGetValue. Check TryGetValue() of ResourceDictionary.")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.TryGetValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void TryGetValue_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Add. Check Add() of ResourceDictionary.")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "ResourceDictionary")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Add_CHECK_RETURN_VALUE_WITH_RESOURCEDICTIONARY()
        {
            /* TEST CODE */
        }


    }
}
