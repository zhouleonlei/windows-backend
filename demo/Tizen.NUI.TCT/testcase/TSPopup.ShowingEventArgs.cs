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
    [Description("Tizen.NUI.UIComponents.Popup.ShowingEventArgs Tests")]
    public class PopupShowingEventArgsTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ShowingEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali Popup.ShowingEventArgs constructor test")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.ShowingEventArgs.ShowingEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ShowingEventArgs_INIT()
        {
            /* TEST CODE */
            var showingEventArgs = new Popup.ShowingEventArgs();
            Assert.IsInstanceOf<Popup.ShowingEventArgs>(showingEventArgs, "Should return Popup.ShowingEventArgs instance.");
        }
    }
}