using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.FlexContainer Tests")]

    public class FlexContainerTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            App.MainTitleChangeText("FlexContainerTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {

        }

        [Test]
        [Category("P1")]
        [Description("Test Construt. Check Flex Container Construct.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.FlexContainer.FlexContainer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]

        public void FlexContainer_INIT()
        {
            var tempContainer = new FlexContainer();
            Assert.IsInstanceOf<FlexContainer>(tempContainer, "Construct Flex Container Fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ContentDirection. Check content direction.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.FlexContainer.FlexDirection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW PRE")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]

        public void FlexDirection_SET_GET_VALUE()
        {
            FlexContainer container = new FlexContainer();
            Window.Instance.GetDefaultLayer().Add(container);

            container.FlexDirection = FlexContainer.FlexDirectionType.Column;
            Assert.AreEqual(container.FlexDirection, FlexContainer.FlexDirectionType.Column, "Check FlexDirectionType.Column Fail");

            container.FlexDirection = FlexContainer.FlexDirectionType.ColumnReverse;
            Assert.AreEqual(container.FlexDirection, FlexContainer.FlexDirectionType.ColumnReverse, "Check FlexDirectionType.ColumnReverse Fail");

            container.FlexDirection = FlexContainer.FlexDirectionType.Row;
            Assert.AreEqual(container.FlexDirection, FlexContainer.FlexDirectionType.Row, "Check FlexDirectionType.Row Fail");

            container.FlexDirection = FlexContainer.FlexDirectionType.RowReverse;
            Assert.AreEqual(container.FlexDirection, FlexContainer.FlexDirectionType.RowReverse, "Check FlexDirectionType.RowReverse Fail");

            Window.Instance.GetDefaultLayer().Remove(container);
        }

        [Test]
        [Category("P1")]
        [Description("Test ContentDirection. Check content direction.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.FlexContainer.ContentDirection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW PRE")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void ContentDirection_SET_GET_VALUE()
        {
            FlexContainer container = new FlexContainer();
            Window.Instance.GetDefaultLayer().Add(container);

            container.ContentDirection = FlexContainer.ContentDirectionType.Inherit;
            Assert.AreEqual(container.ContentDirection, FlexContainer.ContentDirectionType.Inherit, "Check Content Direction Inherit Fail");

            container.ContentDirection = FlexContainer.ContentDirectionType.LTR;
            Assert.AreEqual(container.ContentDirection, FlexContainer.ContentDirectionType.LTR, "Check Content Direction LTR Fail");

            container.ContentDirection = FlexContainer.ContentDirectionType.RTL;
            Assert.AreEqual(container.ContentDirection, FlexContainer.ContentDirectionType.RTL, "Check Content Direction RTL Fail");

            Window.Instance.GetDefaultLayer().Remove(container);
        }

        [Test]
        [Category("P1")]
        [Description("Test FlexWrap. Check Flex Wrap of Child.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.FlexContainer.FlexWrap A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW PRE")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void FlexWrap_SET_GET_VALUE()
        {
            FlexContainer container = new FlexContainer();
            Window.Instance.GetDefaultLayer().Add(container);

            container.FlexWrap = FlexContainer.WrapType.NoWrap;
            Assert.AreEqual(container.FlexWrap, FlexContainer.WrapType.NoWrap, "Check Wrap Fail");
        }

        [Test]
        [Category("P1")]
        [Description("Test JustifyContent. Check Justfy Content.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.FlexContainer.JustifyContent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW PRE")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void JustifyContent_SET_GET_VALUE()
        {
            FlexContainer container = new FlexContainer();
            Window stage = Window.Instance;
            Window.Instance.GetDefaultLayer().Add(container);

            container.JustifyContent = FlexContainer.Justification.JustifyCenter;
            Assert.AreEqual(container.JustifyContent, FlexContainer.Justification.JustifyCenter, "Check Justify center Fail");

            container.JustifyContent = FlexContainer.Justification.JustifyFlexEnd;
            Assert.AreEqual(container.JustifyContent, FlexContainer.Justification.JustifyFlexEnd, "Check Justify End Fail");

            container.JustifyContent = FlexContainer.Justification.JustifyFlexStart;
            Assert.AreEqual(container.JustifyContent, FlexContainer.Justification.JustifyFlexStart, "Check Justify Start Fail");

            container.JustifyContent = FlexContainer.Justification.JustifySpaceAround;
            Assert.AreEqual(container.JustifyContent, FlexContainer.Justification.JustifySpaceAround, "Check Justify Around Fail");

            container.JustifyContent = FlexContainer.Justification.JustifySpaceBetween;
            Assert.AreEqual(container.JustifyContent, FlexContainer.Justification.JustifySpaceBetween, "Check Justify Between Fail");

            Window.Instance.GetDefaultLayer().Remove(container);
        }

        [Test]
        [Category("P1")]
        [Description("Test AlignItems. Check Item Alignment.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.FlexContainer.AlignItems A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW PRE")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void AlignItems_SET_GET_VALUE()
        {
            FlexContainer container = new FlexContainer();
            Window stage = Window.Instance;
            Window.Instance.GetDefaultLayer().Add(container);

            container.AlignItems = FlexContainer.Alignment.AlignFlexStart;
            Assert.AreEqual(container.AlignItems, FlexContainer.Alignment.AlignFlexStart, "Check Items Align Start Fail");

            container.AlignItems = FlexContainer.Alignment.AlignFlexEnd;
            Assert.AreEqual(container.AlignItems, FlexContainer.Alignment.AlignFlexEnd, "Check Items Align End Fail");

            Window.Instance.GetDefaultLayer().Remove(container);
        }

        [Test]
        [Category("P1")]
        [Description("Test AlignContent. Check Content Alignment.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.FlexContainer.AlignContent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW PRE")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void AlignContent_SET_GET_VALUE()
        {
            FlexContainer container = new FlexContainer();
            Window stage = Window.Instance;
            Window.Instance.GetDefaultLayer().Add(container);

            container.AlignContent = FlexContainer.Alignment.AlignStretch;
            Assert.AreEqual(container.AlignContent, FlexContainer.Alignment.AlignStretch, "Check Content Align Stretch Fail");
            Window.Instance.GetDefaultLayer().Remove(container);
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the FlexContainer.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.FlexContainer.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                FlexContainer flexContainer = new FlexContainer();
                flexContainer.Dispose();
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
