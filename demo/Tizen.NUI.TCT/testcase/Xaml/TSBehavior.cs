using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Test;
using Tizen.NUI.UIComponents;

namespace Tizen.NUI.Tests
{
    public class TestBehavior : Behavior<TextLabel>
    {
        protected override void OnAttachedTo(TextLabel bindable)
        {
            isAttached = true;
        }

        protected override void OnDetachingFrom(TextLabel bindable)
        {
            isAttached = false;
        }

        public Type CustomAssociatedType
        {
            get
            {
                return AssociatedType;
            }
        }

        public bool isAttached = false;
    }

    [TestFixture]
    [Description("Tizen.NUI.Binding.Behavior Tests")]
    public class BehaviorTests
    {
        private string TAG = "NUI";

        static TestBehavior instance;
        static TextLabel text;

        [SetUp]
        public void Setup()
        {
            Tizen.Log.Info(TAG, "BindablePropertyTests-------------- - Setup()");
            instance = new TestBehavior();
            text = new TextLabel();
        }

        [TearDown]
        public void TearDown()
        {
            Tizen.Log.Info(TAG, "BindablePropertyTests-------------- - TearDown()");
            instance = null;
            text?.Dispose();
            text = null;
        }

        [Test]
        [Category("P1")]
        [Description("Test AssociatedType. Check whether AssociatedType is readable.")]
        [Property("SPEC", "Tizen.NUI.Binding.Behavior.AssociatedType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void AssociatedType_READ_ONLY()
        {
            /* TEST CODE */
            Assert.IsTrue(instance.CustomAssociatedType == typeof(TextLabel), "AssociatedType shall be TextLabel");
        }

        [Test]
        [Category("P1")]
        [Description("Test OnAttachedTo. Check OnAttachedTo() of Behavior.")]
        [Property("SPEC", "Tizen.NUI.Binding.Behavior.OnAttachedTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void OnAttachedTo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            text.Behaviors.Add(instance);
            Assert.IsTrue(instance.isAttached, "isAttached shall be true");
        }

        [Test]
        [Category("P1")]
        [Description("Test OnDetachingFrom. Check OnDetachingFrom() of Behavior.")]
        [Property("SPEC", "Tizen.NUI.Binding.Behavior.OnDetachingFrom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void OnDetachingFrom_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            text.Behaviors.Remove(instance);
            Assert.IsTrue(!instance.isAttached, "isAttached shall be false");
        }
    }
}
