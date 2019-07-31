using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using System.Threading.Tasks;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.UIComponents.Popup.ShownEventArgs Tests")]
    public class PopupShownEventArgsTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ShownEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali Popup.ShownEventArgs constructor test")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.ShownEventArgs.ShownEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ShownEventArgs_INIT()
        {
            /* TEST CODE */
            var shownEventArgs = new Popup.ShownEventArgs();
            Assert.IsInstanceOf<Popup.ShownEventArgs>(shownEventArgs, "Should return Popup.ShownEventArgs instance.");
        }
    }
}