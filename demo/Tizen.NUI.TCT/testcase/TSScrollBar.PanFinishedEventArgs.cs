using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.UIComponents.ScrollBar.PanFinishedEventArgs Tests")]
    public class PanFinishedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("PanFinishedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a PanFinishedEventArgs object. Check whether PanFinishedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ScrollBar.PanFinishedEventArgs.PanFinishedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void PanFinishedEventArgs_INIT()
        {
            /* TEST CODE */
            var panFinishedEventArgs = new ScrollBar.PanFinishedEventArgs();
            Assert.IsNotNull(panFinishedEventArgs, "Can't create success object PanFinishedEventArgs");
            Assert.IsInstanceOf<ScrollBar.PanFinishedEventArgs>(panFinishedEventArgs, "Should be an instance of PanFinishedEventArgs type.");
        }
    }
}
