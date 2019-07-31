using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using System.Collections.Generic;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.AnimatedImageVisual Tests")]
    public class AnimatedImageVisualTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        private static bool _flagComposingPropertyMap;
        internal class MyAnimatedImageVisual : AnimatedImageVisual
        {
            protected override void ComposingPropertyMap()
            {
                _flagComposingPropertyMap = true;
                base.ComposingPropertyMap();
            }
        }

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("AnimatedImageVisualTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a AnimatedImageVisual object.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageVisual.AnimatedImageVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AnimatedImageVisual_INIT()
        {
            /* TEST CODE */
            var animatedImageVisual = new AnimatedImageVisual();
            Assert.IsNotNull(animatedImageVisual, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<AnimatedImageVisual>(animatedImageVisual, "Should be an instance of AnimatedImageVisual type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test URL. Check whether URL is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageVisual.URL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void URL_SET_GET_VALUE()
        {
            /* TEST CODE */
            AnimatedImageVisual map = new AnimatedImageVisual();
            map.URL = image_path;
            Assert.AreEqual(image_path, map.URL, "Retrieved URL should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test BatchSize. Check whether BatchSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageVisual.BatchSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void BatchSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            AnimatedImageVisual map = new AnimatedImageVisual();
            List<string> list = new List<string>();
            list.Add(image_path);
            map.URLS = list;
            map.BatchSize = 1;
            Assert.AreEqual(1, map.BatchSize, "Retrieved BatchSize should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test CacheSize. Check whether CacheSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageVisual.CacheSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void CacheSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            AnimatedImageVisual map = new AnimatedImageVisual();
            List<string> list = new List<string>();
            list.Add(image_path);
            map.URLS = list;
            map.CacheSize = 1;
            Assert.AreEqual(1, map.CacheSize, "Retrieved CacheSize should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test FrameDelay. Check whether FrameDelay is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageVisual.FrameDelay A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void FrameDelay_SET_GET_VALUE()
        {
            /* TEST CODE */
            AnimatedImageVisual map = new AnimatedImageVisual();
            List<string> list = new List<string>();
            list.Add(image_path);
            map.URLS = list;
            map.FrameDelay = 0.1f;
            Assert.AreEqual(0.1f, map.FrameDelay, "Retrieved FrameDelay should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test LoopCount. Check whether LoopCount is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageVisual.LoopCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void LoopCount_SET_GET_VALUE()
        {
            /* TEST CODE */
            AnimatedImageVisual map = new AnimatedImageVisual();
            List<string> list = new List<string>();
            list.Add(image_path);
            map.URLS = list;
            map.LoopCount = 0.1f;
            Assert.AreEqual(0.1f, map.LoopCount, "Retrieved LoopCount should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test URLS. Check whether URLS is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageVisual.URLS A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void URLS_SET_GET_VALUE()
        {
            /* TEST CODE */
            AnimatedImageVisual map = new AnimatedImageVisual();
            List<string> list = new List<string>();
            list.Add(image_path);
            map.URLS = list;
            string url = map.URLS[0] as string;
            Assert.AreEqual(image_path, url, "Retrieved URLS should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Check override method ComposingPropertyMap is invoked when new AnimatedImageVisual instance.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageVisual.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void ComposingPropertyMap_OVERRIDE_METHOD()
        {
            /*PRE CONDITION
             * _flagComposingPropertyMap flag is initialize false value
             * Create a instance MyAnimatedImageVisual
             */
            _flagComposingPropertyMap = false;
            Assert.False(_flagComposingPropertyMap, "_flagComposingPropertyMap should false initial");
            /**TEST CODE**/
            var myAnimatedImageVisual = new MyAnimatedImageVisual()
            {
                URL = image_path,
            };
            Assert.IsInstanceOf<AnimatedImageVisual>(myAnimatedImageVisual, "Should be an instance of AnimatedImageVisual type.");
            PropertyMap propertyMap = myAnimatedImageVisual.OutputVisualMap;
            Assert.True(_flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");
        }
    }
}
