using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.ImageView.ResourceReadyEventArgs Tests")]
    public class ImageViewResourceReadyEventArgsTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ResourceReadyEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali ImageView.ResourceReadyEventArgs constructor test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.ResourceReadyEventArgs.ResourceReadyEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ResourceReadyEventArgs_INIT()
        {
            /* TEST CODE */
            var resourceReadyEventArgs = new ImageView.ResourceReadyEventArgs();
            Assert.IsInstanceOf<ImageView.ResourceReadyEventArgs>(resourceReadyEventArgs, "Should return ImageView.ResourceReadyEventArgs instance.");
        }

        [Test]
        [Category("P1")]
        [Description("Test View. Check whether View is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.ResourceReadyEventArgs.View A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void View_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageView.ResourceReadyEventArgs resourceReadyEventArgs = new ImageView.ResourceReadyEventArgs();
            ImageView imageView = new ImageView();
            resourceReadyEventArgs.View = imageView;
            Assert.AreEqual(imageView, resourceReadyEventArgs.View, "Retrieved View should be equal to set value");
        }
    }
}