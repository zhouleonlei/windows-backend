using NUnit.Framework;
using System;
using System.Runtime.CompilerServices;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
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
            View view = new View();
            view.IsCreateByXaml = true;

            view.BindingContext = 1;

            int value = (int)view.BindingContext;
            Assert.IsTrue(value == 1);

            view?.Dispose();
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
            View view = new View();
            view.IsCreateByXaml = true;

            Position2D forSet = new Position2D(200, 100);
            view.Position2D = forSet;
            Position2D position = (Position2D)view.GetValue(View.Position2DProperty);

            Assert.IsTrue(position.Equals(forSet));

            view?.Dispose();
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
            View view1 = new View();
            view1.IsCreateByXaml = true;

            View view2 = new View();
            view2.IsCreateByXaml = true;

            Binding.Binding binding = new Binding.Binding("Size2D", Binding.BindingMode.TwoWay, source:view2);
            view1.SetBinding(View.Size2DProperty, binding);

            view2.Size2D = new Size2D(300, 200);
            Assert.IsTrue(view1.Size2D.Equals(view2.Size2D));

            view1.Size2D = new Size2D(200, 300);
            Assert.IsTrue(view1.Size2D.Equals(view2.Size2D));

            view1?.Dispose();
            view2?.Dispose();
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
            View view = new View();
            view.IsCreateByXaml = true;

            Position2D forSet = new Position2D(100, 200);
            view.SetValue(View.Position2DProperty, forSet);
            Assert.IsTrue(view.Position2D.Equals(forSet));

            view?.Dispose();
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
            View view = new View();
            view.IsCreateByXaml = true;

            int ret = -1;
            var bindablePropertyKey = BindableProperty.CreateAttachedReadOnly("TestProperty", typeof(int), typeof(int), 0, BindingMode.TwoWay, propertyChanged: (bindable, oldValue, newValue) =>
            {
                ret = (int)newValue;
            });

            view.SetValue(bindablePropertyKey, 100);
            Assert.IsTrue(100 == ret);

            view?.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test SetInheritedBindingContext. Check SetInheritedBindingContext() of BindableObject.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.SetInheritedBindingContext M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void SetInheritedBindingContext_CHECK()
        {
            /* TEST CODE */
            View view1 = new View();
            view1.IsCreateByXaml = true;

            View view2 = new View();
            view2.IsCreateByXaml = true;

            view1.BindingContext = view2;

            View child1 = new View();
            BindableObject.SetInheritedBindingContext(child1, view1.BindingContext);
            Assert.IsTrue(child1.BindingContext.GetHashCode() == view2.GetHashCode());

            View child2 = new View();
            view1.Add(child2);
            Assert.IsTrue(child2.BindingContext.GetHashCode() == view2.GetHashCode());

            child1?.Dispose();
            child2?.Dispose();

            view1?.Dispose();
            view2?.Dispose();
        }

        private class TestView : View
        {
            public void TestApplyBindings()
            {
                base.ApplyBindings();
            }

            public void TestUnapplyBindings()
            {
                base.UnapplyBindings();
            }

            protected override void OnBindingContextChanged()
            {
                base.OnBindingContextChanged();
                isBindingContextChanged = true;
            }

            protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                base.OnPropertyChanged(propertyName);
                changedPropertyName = propertyName;
            }

            protected override void OnPropertyChanging([CallerMemberName] string propertyName = null)
            {
                changingPropertyName = propertyName;
            }

            public bool isBindingContextChanged = false;
            public string changedPropertyName;
            public string changingPropertyName;
        }

        [Test]
        [Category("P1")]
        [Description("Test ApplyBindings. Check ApplyBindings() of BindableObject.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.ApplyBindings M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ApplyBindings_CHECK()
        {
            /* TEST CODE */
            TestView testView = new TestView();
            testView.IsCreateByXaml = true;

            View view1 = new View();
            view1.IsCreateByXaml = true;

            testView.BindingContext = view1;

            Binding.Binding binding = new Binding.Binding("Size2D", Binding.BindingMode.TwoWay);
            testView.SetBinding(View.Size2DProperty, binding);
            testView.TestApplyBindings();

            testView.Size2D = new Size2D(300, 200);
            Assert.IsTrue(view1.Size2D.Equals(testView.Size2D));

            view1.Size2D = new Size2D(200, 300);
            Assert.IsTrue(view1.Size2D.Equals(testView.Size2D));

            testView?.Dispose();
            view1?.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test OnBindingContextChanged. Check OnBindingContextChanged() of BindableObject.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.OnBindingContextChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void OnBindingContextChanged_CHECK()
        {
            /* TEST CODE */
            TestView testView = new TestView();
            testView.IsCreateByXaml = true;

            View view1 = new View();
            view1.IsCreateByXaml = true;

            testView.BindingContext = view1;
            Assert.IsTrue(testView.isBindingContextChanged);

            testView?.Dispose();
            view1?.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test OnPropertyChanged. Check OnPropertyChanged() of BindableObject.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.OnPropertyChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void OnPropertyChanged_CHECK()
        {
            /* TEST CODE */
            TestView testView = new TestView();
            testView.IsCreateByXaml = true;

            testView.Size2D = new Size2D(200, 200);

            Assert.IsTrue(testView.changedPropertyName == "Size2D");
            testView?.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test OnPropertyChanging. Check OnPropertyChanging() of BindableObject.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.OnPropertyChanging M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void OnPropertyChanging_CHECK()
        {
            /* TEST CODE */
            TestView testView = new TestView();
            testView.IsCreateByXaml = true;

            testView.Size2D = new Size2D(200, 200);

            Assert.IsTrue(testView.changingPropertyName == "Size2D");
            testView?.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test UnapplyBindings. Check UnapplyBindings() of BindableObject.")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObject.UnapplyBindings M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void UnapplyBindings_CHECK()
        {
            /* TEST CODE */
            TestView testView = new TestView();
            testView.IsCreateByXaml = true;

            View view1 = new View();
            view1.IsCreateByXaml = true;

            testView.BindingContext = view1;

            Binding.Binding binding = new Binding.Binding("Size2D", Binding.BindingMode.TwoWay);
            testView.SetBinding(View.Size2DProperty, binding);
            testView.TestApplyBindings();

            testView.Size2D = new Size2D(300, 200);
            Assert.IsTrue(view1.Size2D.Equals(testView.Size2D));

            view1.Size2D = new Size2D(200, 300);
            Assert.IsTrue(view1.Size2D.Equals(testView.Size2D));

            testView.TestUnapplyBindings();
            testView.Size2D = new Size2D(600, 400);
            Assert.IsTrue(view1.Size2D.Equals(new Size2D(200, 300)));

            testView?.Dispose();
            view1?.Dispose();
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
            View view = new View();
            view.IsCreateByXaml = true;

            string propertyName = "";

            view.PropertyChanged += (object sender, global::System.ComponentModel.PropertyChangedEventArgs e) =>
            {
                propertyName = e.PropertyName;
            };

            view.Size2D = new Size2D(300, 200);
            Assert.IsTrue(propertyName == "Size2D");

            view?.Dispose();
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
            View view = new View();
            view.IsCreateByXaml = true;

            bool isBindingContextChanged = false;

            view.BindingContextChanged += (object sender, EventArgs e) =>
            {
                isBindingContextChanged = true;
            };

            View bindingContext = new View();
            view.BindingContext = bindingContext;

            Assert.IsTrue(isBindingContextChanged);

            view?.Dispose();
            bindingContext?.Dispose();
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
            View view = new View();
            view.IsCreateByXaml = true;

            string propertyName = "";

            view.PropertyChanging += (object sender, global::System.ComponentModel.PropertyChangingEventArgs e) =>
            {
                propertyName = e.PropertyName;
            };

            view.Size2D = new Size2D(300, 200);
            Assert.IsTrue(propertyName == "Size2D");

            view?.Dispose();
        }
    }
}
