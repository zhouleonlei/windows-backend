using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.Runtime.InteropServices;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("NUI VisualView Tests")]
    class VisualViewTests
    {
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        private string TAG = "NUI";
        internal static bool _flagOnRelayout = false;

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("VisualViewTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Construct. Check visual view  construct.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VisualView.VisualView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void VisualView_INIT()
        {
            VisualView view = new VisualView();
            Assert.IsInstanceOf<VisualView>(view, "Costruct Test Fail");
        }

        [Test]
        [Category("P1")]
        [Description("Test NumberOfVisuals. Check visual view visual number.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VisualView.NumberOfVisuals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void NumberOfVisuals_CHECK_RETURN_VALUE()
        {
            VisualView visualView01 = new VisualView();
            TextVisual textVisualMap01 = new TextVisual();
            textVisualMap01.Text = "Hello";
            textVisualMap01.PointSize = 20.0f;
            visualView01.AddVisual("textVisual01", textVisualMap01);

            int nuberOfVisual = visualView01.NumberOfVisuals;
            Tizen.Log.Debug(TAG, $"nuberOfVisual={nuberOfVisual}");

            Assert.AreEqual(1, nuberOfVisual, "Visual Count Check Fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test AnimateVisualAdd. Check whether AnimateVisualAdd works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VisualView.AnimateVisualAdd M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AnimateVisualAdd_CHECK_RETURN_VALUE()
        {
            VisualView _contentView = new VisualView();
            _contentView.WidthResizePolicy = ResizePolicyType.SizeRelativeToParent;
            _contentView.HeightResizePolicy = ResizePolicyType.SizeRelativeToParent;
            _contentView.BackgroundImage = image_path;

            ImageVisual _icon = new ImageVisual();
            _icon.URL = image_path;
            _icon.DepthIndex = 1;
            _icon.Size = new Size2D(50, 50);
            _icon.SizePolicy = VisualTransformPolicyType.Absolute;
            _icon.Position = new Position2D(5, 5);
            _icon.PositionPolicy = VisualTransformPolicyType.Absolute;
            _icon.Origin = Visual.AlignType.TopBegin;
            _icon.AnchorPoint = Visual.AlignType.TopBegin;
            _icon.MixColor = new Color(0, 1, 0, 0.5f);
            _icon.Opacity = 0.5f;
            _contentView.AddVisual("icon_visual1", _icon);

            Window.Instance.GetDefaultLayer().Add(_contentView);
            _contentView.AnimateVisualAdd(_icon, "Size", new Size2D(150, 150), 0, 1000, AlphaFunction.BuiltinFunctions.Linear);
            Animation animation = _contentView.AnimateVisualAddFinish();
            Assert.IsNotNull(animation, "Should be not null!");
        }

        [Test]
        [Category("P1")]
        [Description("Test AddViual. Check add visual.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VisualView.AddVisual M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void AddVisual_CHECK_RETURN_VALUE()
        {
            VisualView visualView = new VisualView();
            ImageVisual imageVisualMap1 = new ImageVisual();
            imageVisualMap1.URL = image_path;
            imageVisualMap1.Size = new Vector2(300.0f, 300.0f);
            imageVisualMap1.Position = new Vector2(50.0f, 50.0f);
            imageVisualMap1.PositionPolicy = VisualTransformPolicyType.Absolute;
            imageVisualMap1.SizePolicy = VisualTransformPolicyType.Absolute;
            imageVisualMap1.Origin = Visual.AlignType.TopBegin;
            imageVisualMap1.AnchorPoint = Visual.AlignType.TopBegin;
            visualView.AddVisual("imageVisual1", imageVisualMap1);
            Assert.AreEqual(1, visualView.NumberOfVisuals, "Visual Add Fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test RemoveVisual. Check visual count after remove visual.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VisualView.RemoveVisual M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void RemoveVisual_CHECK_RETURN_VALUE()
        {
            VisualView visualView = new VisualView();
            TextVisual textVisualMap1 = new TextVisual();
            textVisualMap1.Text = "Hello";
            textVisualMap1.PointSize = 20.0f;
            visualView.AddVisual("textVisual1", textVisualMap1);

            TextVisual textVisualMap2 = new TextVisual();
            textVisualMap2.Text = "world";
            textVisualMap2.PointSize = 20.0f;
            visualView.AddVisual("textVisual2", textVisualMap2);

            visualView.RemoveVisual("textVisual1");
            Assert.AreEqual(1, visualView.NumberOfVisuals, "Visual Count Check Fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test RemoveAll. Check visual count after remove all.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VisualView.RemoveAll M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void RemoveAll_CHECK_RETURN_VALUE()
        {
            VisualView visualView = new VisualView();
            TextVisual textVisualMap1 = new TextVisual();
            textVisualMap1.Text = "Hello";
            textVisualMap1.PointSize = 20.0f;
            visualView.AddVisual("textVisual1", textVisualMap1);

            TextVisual textVisualMap2 = new TextVisual();
            textVisualMap2.Text = "world";
            textVisualMap2.PointSize = 20.0f;
            visualView.AddVisual("textVisual2", textVisualMap2);

            visualView.RemoveAll();
            Assert.AreEqual(0, visualView.NumberOfVisuals, "Visual Count Check Fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test AnimateVisual. Check AnimateVisual is work or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VisualView.AnimateVisual M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AnimateVisual_CHECK_RERTURN_VALUE()
        {
            VisualView visualView = new VisualView();
            Window.Instance.GetDefaultLayer().Add(visualView);

            ImageVisual _icon = new ImageVisual();
            _icon.URL = image_path;
            _icon.DepthIndex = 1;
            _icon.Size = new Size2D(50, 50);
            _icon.SizePolicy = VisualTransformPolicyType.Absolute;
            _icon.Position = new Position2D(5, 5);
            _icon.PositionPolicy = VisualTransformPolicyType.Absolute;
            _icon.Origin = Visual.AlignType.TopBegin;
            _icon.AnchorPoint = Visual.AlignType.TopBegin;
            _icon.MixColor = new Color(0, 1, 0, 0.5f);
            _icon.Opacity = 0.5f;
            visualView.AddVisual("icon_visual1", _icon);

            Animation animation = visualView.AnimateVisual(_icon, "opacity", 1.0f, 0, 1000, AlphaFunction.BuiltinFunctions.Linear);
            Assert.IsNotNull(animation, "AnimateVisual method does not work.");
        }

        [Test]
        [Category("P1")]
        [Description("Test AnimateVisualAddFinish. Check whether AnimateVisualAddFinish works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VisualView.AnimateVisualAddFinish M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AnimateVisualAddFinish_TEST()
        {
            VisualView _contentView = new VisualView();
            _contentView.WidthResizePolicy = ResizePolicyType.SizeRelativeToParent;
            _contentView.HeightResizePolicy = ResizePolicyType.SizeRelativeToParent;
            _contentView.BackgroundImage = image_path;

            ImageVisual _icon = new ImageVisual();
            _icon.URL = image_path;
            _icon.DepthIndex = 1;
            _icon.Size = new Size2D(50, 50);
            _icon.SizePolicy = VisualTransformPolicyType.Absolute;
            _icon.Position = new Position2D(5, 5);
            _icon.PositionPolicy = VisualTransformPolicyType.Absolute;
            _icon.Origin = Visual.AlignType.TopBegin;
            _icon.AnchorPoint = Visual.AlignType.TopBegin;
            _icon.MixColor = new Color(0, 1, 0, 0.5f);
            _icon.Opacity = 0.5f;
            _contentView.AddVisual("icon_visual1", _icon);

            Window.Instance.GetDefaultLayer().Add(_contentView);
            _contentView.AnimateVisualAdd(_icon, "Size", new Size2D(150, 150), 0, 1000, AlphaFunction.BuiltinFunctions.Linear);
            Animation animation = _contentView.AnimateVisualAddFinish();
            Assert.IsNotNull(animation, "Should be not null!");
        }


        [Test]
        [Category("P1")]
        [Description("Test OnInitialize. Check visual count after remove all.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VisualView.OnInitialize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void OnInitialize_CHECK_RERTURN_VALUE()
        {
            VisualView visualView = new VisualView();
            Assert.AreEqual(0, visualView.NumberOfVisuals, "Visual Count Check Fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the VisualView.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VisualView.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                VisualView visualView = new VisualView();
                visualView.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test OnRelayout. Check visual count after remove all.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VisualView.OnRelayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public async Task OnRelayout_CHECK_RERTURN_VALUE()
        {
            var myVisualView = new MyVisualView()
            {
                Size2D = new Size2D(300, 200),
                BackgroundColor = Color.Cyan,
                ParentOrigin = ParentOrigin.CenterRight,
                PivotPoint = PivotPoint.CenterRight,
                PositionUsesPivotPoint = true,
            };

            try
            {
                Assert.IsNotNull(myVisualView, "Can't create VisualView instance success");
                Assert.IsInstanceOf<VisualView>(myVisualView, "Should return VisualView instance.");
                Window.Instance.Add(myVisualView);
                TextVisual textVisualMap1 = new TextVisual()
                {
                    Text = "Text Visual",
                    PointSize = 20.0f,
                    Size = new Size2D(250, 150),
                    SizePolicy = VisualTransformPolicyType.Absolute,
                    Origin = Visual.AlignType.Center,
                    AnchorPoint = Visual.AlignType.Center,
                    PositionPolicy = VisualTransformPolicyType.Absolute,
                };
                myVisualView.AddVisual("textVisual", textVisualMap1);
                await Task.Delay(200);
                Assert.IsTrue(_flagOnRelayout, "Should be true.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            finally
            {
                Window.Instance.Remove(myVisualView);
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test VisualAnimate. Check visual count after remove all.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.VisualView.VisualAnimate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void VisualAnimate_CHECK_RERTURN_VALUE()
        {
            var visualView = new VisualView()
            {
                Size2D = new Size2D(500, 400),
            };

            try
            {
                Assert.IsNotNull(visualView, "Can't create VisualView instance success");
                Assert.IsInstanceOf<VisualView>(visualView, "Should return VisualView instance.");
                Window.Instance.Add(visualView);

                ColorVisual colorVisualMap1 = new ColorVisual()
                {
                    Color = Color.Green,
                    Size = new Size2D(300, 200),
                    SizePolicy = VisualTransformPolicyType.Absolute,
                    Origin = Visual.AlignType.Center,
                    AnchorPoint = Visual.AlignType.Center,
                    PositionPolicy = VisualTransformPolicyType.Absolute,
                };
                visualView.AddVisual("colorVisual", colorVisualMap1);

                VisualAnimator visualAnimator = new VisualAnimator()
                {
                    AlphaFunction = AlphaFunction.BuiltinFunctions.Default,
                    StartTime = 0,
                    EndTime = 100,
                    Target = "colorVisual",
                    PropertyIndex = "Opacity",
                    DestinationValue = 0.5f,
                };

                Animation visualAnimation = visualView.VisualAnimate(visualAnimator);
                Assert.IsNotNull(visualAnimation, "Can't return Animation instance success");
                Assert.IsInstanceOf<Animation>(visualAnimation, "Should return Animation instance.");
                visualAnimation.Play();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            finally
            {
                Window.Instance.Remove(visualView);
            }
        }

        internal class MyVisualView : VisualView
        {
            public MyVisualView() : base()
            { }

            public override void OnInitialize()
            {
                base.OnInitialize();
            }

            public override void OnRelayout(Vector2 size, RelayoutContainer container)
            {
                _flagOnRelayout = true;
                base.OnRelayout(size, container);
            }
        }
    }
}
