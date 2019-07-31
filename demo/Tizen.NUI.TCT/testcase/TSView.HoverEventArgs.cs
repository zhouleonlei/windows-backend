using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.View.HoverEventArgs Tests")]
    public class HoverEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("HoverEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a HoverEventArgs object. Check whether HoverEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.HoverEventArgs.HoverEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void HoverEventArgs_INIT()
        {
            /* TEST CODE */
            var hoverEventArgs = new View.HoverEventArgs();
            Assert.IsNotNull(hoverEventArgs, "Can't create success object HoverEventArgs");
            Assert.IsInstanceOf<View.HoverEventArgs>(hoverEventArgs, "Should be an instance of HoverEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Hover. Check whether Hover is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.HoverEventArgs.Hover A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Hover_SET_GET_VALUE()
        {
            /* TEST CODE */
            View.HoverEventArgs hoverEventArgs = new View.HoverEventArgs();
            Hover hover = new Hover();
            hoverEventArgs.Hover = hover;
            Assert.AreEqual(hover, hoverEventArgs.Hover, "Retrieved Hover should be equal to set value");
        }
    }
}
