using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.Runtime.InteropServices;
using Tizen.NUI.Test;
using System.Threading.Tasks;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.CustomView Tests")]
    public class CustomViewTests
    {
        private static string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, " Init() is called!");
            App.MainTitleChangeText("CustomViewTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, " Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali CustomView constructor test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.CustomView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void CustomView_INIT()
        {
            /* TEST CODE */
            var customView = new CustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
            Assert.IsInstanceOf<CustomView>(customView, "Should return CustomView instance.");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetBackground. Try to set the background of the view.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.SetBackground M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SetBackground_SET_VALUE()
        {
            /* TEST CODE */
            try
            {
                CustomView customView = new CustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
                PropertyMap map = new PropertyMap();
                map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Color));
                map.Add("Color", new PropertyValue(new Color(0.0f, 0.0f, 0.0f, 1.0f)));
                customView.SetBackground(map);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test FocusNavigationSupport. Check whether FocusNavigationSupport is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.FocusNavigationSupport A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void FocusNavigationSupport_SET_GET_VALUE()
        {
            /* TEST CODE */
            CustomView customView = new CustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
            customView.FocusNavigationSupport = true;
            Assert.IsTrue(customView.FocusNavigationSupport, "The FocusNavigationSupport of customView should be true");
            customView.FocusNavigationSupport = false;
            Assert.IsFalse(customView.FocusNavigationSupport, "The FocusNavigationSupport of customView should be false");
        }

        [Test]
        [Category("P1")]
        [Description("Test FocusGroup. Check whether FocusGroup is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.FocusGroup A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void FocusGroup_SET_GET_VALUE()
        {
            /* TEST CODE */
            CustomView customView = new CustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
            customView.FocusGroup = true;
            Assert.IsTrue(customView.FocusGroup, "The FocusGroup of customView should be true");
            customView.FocusGroup = false;
            Assert.IsFalse(customView.FocusGroup, "The FocusGroup of customView should be true");
        }

        [Test]
        [Category("P1")]
        [Description("Test CalculateChildSize. Check whether it return the right value")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.CalculateChildSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void CalculateChildSize_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            View child = new View();
            child.HeightResizePolicy = ResizePolicyType.FillToParent;
            CustomView customView = new CustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
            customView.Size = new Size(100.0f, 100.0f, 100.0f);
            float height = customView.CalculateChildSize(child, DimensionType.Height);
            Assert.AreEqual(100.0f, height, "The height of customView is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to Allows customeView to enable the gesture detectors.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.EnableGestureDetection M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void EnableGestureDetection_TEST()
        {
            /* TEST CODE */
            try
            {
                CustomView customView = new CustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
                customView.EnableGestureDetection(Gesture.GestureType.LongPress);
            }
            catch (Exception e)
            {
                Tizen.Log.Error("Test CellPosition.cs", "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test GetHeightForWidth. Check whether it return the right value")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.GetHeightForWidth M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void GetHeightForWidth_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            CustomView customView = new CustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
            float height = customView.GetHeightForWidth(1.0f);
            Assert.AreEqual(1.0f, height, "The height of customView is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetWidthForHeight. Check whether it return the right value")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.GetWidthForHeight M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void GetWidthForHeight_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            CustomView customView = new CustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
            float width = customView.GetWidthForHeight(1.0f);
            Assert.AreEqual(1.0f, width, "The width of customView is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetNaturalSize. Check whether it return the right value")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.GetNaturalSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetNaturalSize_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Spin customView = new Spin();
            Size2D size = customView.GetNaturalSize();
            Assert.AreEqual(150, size.Width, "The width of customView is not correct here.");
            Assert.AreEqual(150, size.Height, "The height of customView is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test RelayoutDependentOnChildren. Check whether it return the right value")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.RelayoutDependentOnChildren M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void RelayoutDependentOnChildren_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            CustomView customView = new CustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
            bool ret = customView.RelayoutDependentOnChildren();
            Assert.AreEqual(true, ret, "The return value should be true here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test RelayoutDependentOnChildren. Check whether it return the right value")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.RelayoutDependentOnChildren M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Tizen.NUI.DimensionType")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RelayoutDependentOnChildren_WITH_DIMENSIONTYPE_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            CustomView customView = new CustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
            bool ret = customView.RelayoutDependentOnChildren(DimensionType.AllDimensions);
            Assert.AreEqual(true, ret, "The return value should be true here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test CalculateChildSizeBase, try to calculate the size for a child using the base view object")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.CalculateChildSizeBase M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Junqing Ma, junqing.ma@samsung.com")]
        public void CalculateChildSizeBase_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            View child = new View();
            child.Size2D = new Size2D(150, 150);

            MyCustomView custom = new MyCustomView();
            custom.Size2D = new Size2D(0, 0);

            float v = custom.CalculateChildSize(child, DimensionType.AllDimensions);
            Assert.AreEqual(0.0f, v, "The child size of CustomView is not correct here.");

        }

        [Test]
        [Category("P1")]
        [Description("Test CreateTransition, try to create transition effect on the control")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.CreateTransition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Junqing Ma, junqing.ma@samsung.com")]
        public void CreateTransition_TEST()
        {
            /* TEST CODE */
            MyCustomView view = new MyCustomView();

            PropertyMap animator = new PropertyMap();
            animator.Add("alphaFunction", new PropertyValue("LINEAR"));

            PropertyMap timePeriod = new PropertyMap();
            timePeriod.Add("duration", new PropertyValue(0.8f));
            timePeriod.Add("delay", new PropertyValue(0.0f));
            animator.Add("timePeriod", new PropertyValue(timePeriod));

            PropertyMap _transition = new PropertyMap();
            _transition.Add("target", new PropertyValue("testVisual"));
            _transition.Add("property", new PropertyValue("pixelArea"));
            _transition.Add("targetValue", new PropertyValue(new Vector4(0, 0, 0, 1)));
            _transition.Add("targetValue", new PropertyValue(new Vector4(0, 0, 1, 1)));
            _transition.Add("animator", new PropertyValue(animator));

            var transitionData = new TransitionData(_transition);
            Assert.IsNotNull(transitionData, "The transitionData shouldn't be null");
            Animation animation = view._CreateTransition(transitionData);
            Assert.IsInstanceOf<Animation>(animation, "Should return Animation instance.");
        }

        [Test]
        [Category("P1")]
        [Description("Test EmitFocusSignal, try to emits the KeyInputFocusGained signal if true")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.EmitFocusSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Junqing Ma, junqing.ma@samsung.com")]
        public void EmitFocusSignal_TEST()
        {
            /* TEST CODE */
            try
            {
                MyCustomView view = new MyCustomView();
                view._EmitFocusSignal(false);
            }
            catch(Exception e)
            {
                Tizen.Log.Error("Test CustomView.cs", "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test EnableVisual, try to sets the given visual to be displayed or not when parent staged")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.EnableVisual M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Junqing Ma, junqing.ma@samsung.com")]
        public void EnableVisual_TEST()
        {
            /* TEST CODE */
            try
            {
                MyCustomView view = new MyCustomView();
                view._EnableVisual(0, true);
            }
            catch (Exception e)
            {
                Tizen.Log.Error("Test CustomView.cs", "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test GetHeightForWidthBase, Check whether it return the right value")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.GetHeightForWidthBase M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Junqing Ma, junqing.ma@samsung.com")]
        public void GetHeightForWidthBase_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
            float height = view._GetHeightForWidth(1.0f);
            Assert.AreEqual(1.0f, height, "The height of customView is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetVisual, Check whether it return the right value")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.GetVisual M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Junqing Ma, junqing.ma@samsung.com")]
        public void GetVisual_CHECK_RETURN_VALUE()
        {
            MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
            VisualFactory visualfactory = VisualFactory.Instance;
            PropertyMap map = new PropertyMap();
            map.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
            map.Insert(Visual.Property.Type, new PropertyValue(""));
            VisualBase visual = visualfactory.CreateVisual(map);
            visual.Name = "test visual";

            view._EnableVisual(0, true);
            view._RegisterVisual(0, visual);
            VisualBase ret = view._GetVisual(0);
            Assert.AreEqual("test visual", ret.Name, "The visual get from CustomView is not correct here");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetWidthForHeightBase, Check whether it return the right value")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.GetWidthForHeightBase M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Junqing Ma, junqing.ma@samsung.com")]
        public void GetWidthForHeightBase_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
            float width = view._GetWidthForHeight(1.0f);
            Assert.AreEqual(1.0f, width, "The width of customView is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test IsVisualEnabled, Check whether it return the right value")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.IsVisualEnabled M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Junqing Ma, junqing.ma@samsung.com")]
        public void IsVisualEnabled_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);

            VisualFactory visualfactory = VisualFactory.Instance;
            PropertyMap map = new PropertyMap();
            map.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
            map.Insert(Visual.Property.Type, new PropertyValue(""));
            VisualBase visual = visualfactory.CreateVisual(map);
            visual.Name = "test visual";

            view._EnableVisual(0, true);
            view._RegisterVisual(0, visual);

            bool ret = view._IsVisualEnabled(0);

            Assert.AreEqual(true, ret, "The return value of CustomView is not correct here");
        }



        [Test]
        [Category("P1")]
        [Description("Test UnregisterVisual, try to unregister visual")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.UnregisterVisual M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Junqing Ma, junqing.ma@samsung.com")]
        public void UnregisterVisual_TEST()
        {
            /* TEST CODE */
            MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);

            VisualFactory visualfactory = VisualFactory.Instance;
            PropertyMap map = new PropertyMap();
            map.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
            map.Insert(Visual.Property.Type, new PropertyValue(""));
            VisualBase visual = visualfactory.CreateVisual(map);
            visual.Name = "test visual";

            view._EnableVisual(0, true);
            view._EnableVisual(1, true);

            try
            {
                view._RegisterVisual(0, visual);
                view._RegisterVisual(1, visual, true);
            }
            catch (Exception e)
            {
                Tizen.Log.Error("Test CustomView.cs", "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            try
            {
                view._UnregisterVisual(0);
                view._UnregisterVisual(1);
            }
            catch (Exception e)
            {
                Tizen.Log.Error("Test CustomView.cs", "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }


        [Test]
        [Category("P1")]
        [Description("Test RelayoutDependentOnChildrenBase. Check whether it return the right value")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.RelayoutDependentOnChildrenBase M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Junqing Ma, junqing.ma@samsung.com")]
        public void RelayoutDependentOnChildrenBase_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
            bool ret = view._RelayoutDependentOnChildren();
            Assert.AreEqual(true, ret, "The return value should be true here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test RelayoutDependentOnChildrenBase. Check whether it return the right value")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.RelayoutDependentOnChildrenBase M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Tizen.NUI.DimensionType")]
        [Property("AUTHOR", "Junqing Ma, junqing.ma@samsung.com")]
        public void RelayoutDependentOnChildrenBase_WITH_DIMENSIONTYPE_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
            bool ret = view._RelayoutDependentOnChildren(DimensionType.AllDimensions);
            Assert.AreEqual(true, ret, "The return value should be true here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test RelayoutRequest, try to request a relayout")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.RelayoutRequest M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Junqing Ma, junqing.ma@samsung.com")]
        public void RelayoutRequest_TEST()
        {
            /* TEST CODE */
            try
            {
                MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
                view._RelayoutRequest();
            }
            catch(Exception e)
            {
                Tizen.Log.Error("Test CustomView.cs", "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test RegisterVisual, try to register a visual")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.RegisterVisual M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "int, Tizen.NUI.VisualBase")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void RegisterVisual_TEST_PARAM2()
        {
            /* TEST CODE */
            try
            {
                MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
                int visualIndex = view.RegisterProperty("visualName", new PropertyValue("visualName"), PropertyAccessMode.ReadWrite);
                ColorVisual colorVisual = new ColorVisual();
                colorVisual.Color = new Color(1.0f, 0.3f, 0.5f, 1.0f);
                VisualBase visual = VisualFactory.Instance.CreateVisual(colorVisual.OutputVisualMap);
                view._RegisterVisual(visualIndex, visual);
            }
            catch (Exception e)
            {
                Tizen.Log.Error("Test CustomView.cs", "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test RegisterVisual, try to register a visual")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.RegisterVisual M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "int, Tizen.NUI.VisualBase, bool")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void RegisterVisual_TEST_PARAM3()
        {
            /* TEST CODE */
            try
            {
                MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
                int visualIndex = view.RegisterProperty("visualName", new PropertyValue("visualName"), PropertyAccessMode.ReadWrite);
                ColorVisual colorVisual = new ColorVisual();
                colorVisual.Color = new Color(1.0f, 0.3f, 0.5f, 1.0f);
                VisualBase visual = VisualFactory.Instance.CreateVisual(colorVisual.OutputVisualMap);
                view._RegisterVisual(visualIndex, visual, false);
            }
            catch (Exception e)
            {
                Tizen.Log.Error("Test CustomView.cs", "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test whether GetNextFocusableView return the right value or not")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.GetNextFocusableView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void GetNextFocusableView_CHECK_RETURN_VALUE()
        {
            CustomView customView = new CustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
            FocusManager.Instance.SetCurrentFocusView(customView);
            View view = customView.GetNextFocusableView(customView, View.FocusDirection.Up, false);
            Assert.IsNotNull(view, "Should be not null");
        }

        [Test]
        [Category("P1")]
        [Description("Test OnCalculateRelayoutSize. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnCalculateRelayoutSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnCalculateRelayoutSize_CHECK_VALUE()
        {
            MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault);
            view.OnCalculateRelayoutSize(DimensionType.AllDimensions);
            Assert.AreEqual(true, view.calculateRelayoutSizeFlag, "OnCalculateRelayoutSize return Check Fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test OnChildAdd. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnChildAdd M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnChildAdd_CHECK()
        {
            MyCustomView myCustomView = new MyCustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault);
            View view = new View();
            myCustomView.Children.Add(view);
            Assert.AreEqual(true, myCustomView.childAddFlag, "OnChildAdd return Check Fail.");
            myCustomView.Children.Remove(view);
        }

        [Test]
        [Category("P1")]
        [Description("Test OnChildRemove. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnChildRemove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnChildRemove_CHECK()
        {
            MyCustomView myCustomView = new MyCustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault);
            View view = new View();
            myCustomView.Children.Add(view);
            myCustomView.Remove(view);
            Assert.AreEqual(true, myCustomView.childRemoveFlag, "OnChildRemove Check Fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test OnFocusChangeCommitted. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnFocusChangeCommitted M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnFocusChangeCommitted_CHECK_VALUE()
        {
            MyCustomView myCustomView = new MyCustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
            View view = new View();
            view.Focusable = true;
            myCustomView.OnFocusChangeCommitted(view);
            Assert.AreEqual(true, myCustomView.focusChangeCommittedFlag, "OnFocusChangeCommitted Check Fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test OnFocusGained. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnFocusGained M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnFocusGained_CHECK_VALUE()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault);
            view.Focusable = true;
            window.Add(view);
            FocusManager.Instance.SetCurrentFocusView(view);
            Assert.AreEqual(true, view.focusGainedFlag, "OnFocusGained Check Fail.");
            window.Remove(view);
        }

        [Test]
        [Category("P1")]
        [Description("Test OnFocusLost. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnFocusLost M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnFocusLost_CHECK_VALUE()
        {
            /* TEST CODE */
            Window window = Window.Instance;
            MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault);
            MyCustomView view2 = new MyCustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault);
            view.Focusable = true;
            view2.Focusable = true;
            window.Add(view);
            window.Add(view2);
            FocusManager.Instance.SetCurrentFocusView(view);
            FocusManager.Instance.SetCurrentFocusView(view2);
            Assert.AreEqual(true, view.focusLostFlag, "OnFocusLost Check Fail.");
            window.Remove(view);
            window.Remove(view2);
        }

        [Test]
        [Category("P1")]
        [Description("Test OnHover. Check return the right value or not")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnHover M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnHover_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                CustomView View = new CustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
                bool flag = true;
                flag = View.OnHover(new Hover());
                Assert.AreEqual(false, flag, "OnHover return check fail.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

        }

        [Test]
        [Category("P1")]
        [Description("Test OnInitialize. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnInitialize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnInitialize_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                CustomView view = new CustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
                view.OnInitialize();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test OnKey. Check return the right value or not")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnKey_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                CustomView View = new CustomView("CustomView", CustomViewBehaviour.DisableSizeNegotiation);
                bool flag = true;
                flag = View.OnKey(new Key());
                Assert.AreEqual(false, flag, "OnKey return check fail.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test OnKeyboardEnter. Check return the right value or not")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnKeyboardEnter M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnKeyboardEnter_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                CustomView View = new CustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault);
                bool flag = true;
                flag = View.OnKeyboardEnter();
                Assert.AreEqual(false, flag, "OnKeyboardEnter return Check Fail.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test OnLayoutNegotiated. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnLayoutNegotiated M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnLayoutNegotiated_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault);
                view.OnLayoutNegotiated(0.5f, DimensionType.Height);
                Assert.AreEqual(true, view.layoutNegotiatedFlag, "OnLayoutNegotiated trigger Check Fail.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

        }

        [Test]
        [Category("P1")]
        [Description("Test OnPan. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnPan M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnPan_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                MyCustomView View = new MyCustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault);
                PanGesture pan = new PanGesture();
                View.OnPan(pan);
                Assert.AreEqual(true, View.panFlag, "OnPan trigger Check Fail.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test OnPropertySet. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnPropertySet M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnPropertySet_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault);
                view.Size2D = new Size2D(100, 100);
                view.Position = new Position(100, 100, 0);
                view.BackgroundColor = Color.Red;
                Window.Instance.GetDefaultLayer().Add(view);
                view.StyleName = "fake";
                Window.Instance.GetDefaultLayer().Remove(view);
                Assert.AreEqual(true, view.propertySetFlag, "OnPropertySet trigger Check Fail.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test OnRelayout. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnRelayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public async Task OnRelayout_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault);
                Window window = Window.Instance;
                window.Add(view);
                await Task.Delay(500);
                Assert.AreEqual(true, view.relayoutFlag, "OnRelayout trigger Check Fail.");
                window.Remove(view);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test OnSetResizePolicy. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnSetResizePolicy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnSetResizePolicy_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault);
                view.OnSetResizePolicy(ResizePolicyType.Fixed, DimensionType.Height);
                Assert.AreEqual(true, view.setResizePolicyFlag, "OnSetResizePolicy trigger Check Fail.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test OnSizeAnimation. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnSizeAnimation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnSizeAnimation_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault);
                Vector3 v3 = new Vector3(20, 30, 40);
                Animation animation = new Animation();
                view.OnSizeAnimation(animation, v3);
                Assert.AreEqual(true, view.sizeAnimationFlag, "OnSizeAnimation trigger Check Fail.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test OnSizeSet. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnSizeSet M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnSizeSet_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault);
                Vector3 v3 = new Vector3(20, 30, 40);
                view.OnSizeSet(v3);
                Assert.AreEqual(true, view.sizeSetFlag, "OnSizeSet trigger Check Fail.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test OnStageConnection. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnStageConnection M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnStageConnection_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault);
                view.OnStageConnection(1);
                Assert.AreEqual(true, view.stageConnectionFlag, "OnStageConnection trigger Check Fail.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test OnStageDisconnection. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnStageDisconnection M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnStageDisconnection_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault);
                view.OnStageDisconnection();
                Assert.AreEqual(true, view.stageDisconnectionFlag, "OnStageDisconnection trigger Check Fail.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test OnStyleChange. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnStyleChange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnStyleChange_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault);
                StyleManager manager = new StyleManager();
                view.OnStyleChange(manager, StyleChangeType.DefaultFontChange);
                Assert.AreEqual(true, view.styleChangeFlag, "OnStyleChange trigger Check Fail.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test OnTap. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnTap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnTap_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                MyCustomView view = new MyCustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault);
                TapGesture tap = new TapGesture();
                view.OnTap(tap);
                Assert.AreEqual(true, view.tapFlag, "OnTap trigger Check Fail.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test OnTouch. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnTouch M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnTouch_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                CustomView view = new CustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault);
                Touch touch = new Touch();
                bool flag = true;
                flag = view.OnTouch(touch);
                Assert.AreEqual(false, flag, "OnTouch trigger Check Fail.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test OnWheel. Check it has been triggered")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.CustomView.OnWheel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void OnWheel_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                CustomView view = new CustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault);
                Wheel wheel = new Wheel();
                bool flag = true;
                flag = view.OnWheel(wheel);
                Assert.AreEqual(false, flag, "OnWheel trigger Check Fail.");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

    }

    public class MyCustomView : CustomView
    {
        View view;
        public bool calculateRelayoutSizeFlag = false;
        public bool childAddFlag = false;
        public bool childRemoveFlag = false;
        public bool focusChangeCommittedFlag = false;
        public bool focusGainedFlag = false;
        public bool focusLostFlag = false;
        public bool hoverFlag = false;
        public bool initializeFlag = false;
        public bool keyFlag = false;
        public bool keyboardEnterFlag = false;
        public bool layoutNegotiatedFlag = false;
        public bool panFlag = false;
        public bool propertySetFlag = false;
        public bool relayoutFlag = false;
        public bool setResizePolicyFlag = false;
        public bool sizeAnimationFlag = false;
        public bool sizeSetFlag = false;
        public bool stageConnectionFlag = false;
        public bool stageDisconnectionFlag = false;
        public bool styleChangeFlag = false;
        public bool tapFlag = false;
        public bool touchFlag = false;
        public bool wheelFlag = false;

        static CustomView CreateInstance()
        {
            return new MyCustomView();
        }
        static MyCustomView()
        {
            CustomViewRegistry.Instance.Register(CreateInstance, typeof(MyCustomView));
        }

        public MyCustomView() : base(typeof(MyCustomView).FullName, CustomViewBehaviour.ViewBehaviourDefault)
        {
        }

        public MyCustomView(string typeName, CustomViewBehaviour behaviour) : base(typeName, behaviour)
        {
        }

        public override void OnCalculateRelayoutSize(DimensionType dimension)
        {
            calculateRelayoutSizeFlag = true;
        }

        public override void OnChildAdd(View view)
        {
            childAddFlag = true;
        }

        public override void OnChildRemove(View view)
        {
            childRemoveFlag = true;
        }

        public override void OnFocusChangeCommitted(View commitedFocusableView)
        {
            focusChangeCommittedFlag = true;
        }

        public override void OnFocusGained()
        {
            focusGainedFlag = true;
        }

        public override void OnFocusLost()
        {
            focusLostFlag = true;
        }

        public override void OnInitialize()
        {
            view = new BaseComponents.View();
            view.Size2D = new Size2D(200, 200);
            view.BackgroundColor = Color.Red;
            this.Add(view);
        }

        public override void OnLayoutNegotiated(float size, DimensionType dimension)
        {
            layoutNegotiatedFlag = true;
        }

        public override void OnPan(PanGesture pan)
        {
            panFlag = true;
        }

        public override void OnPropertySet(int index, Tizen.NUI.PropertyValue propertyValue)
        {
            propertySetFlag = true;
        }

        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            relayoutFlag = true;
        }

        public override void OnSetResizePolicy(ResizePolicyType policy, DimensionType dimension)
        {
            setResizePolicyFlag = true;
        }

        public override void OnSizeAnimation(Animation animation, Vector3 targetSize)
        {
            sizeAnimationFlag = true;
        }

        public override void OnSizeSet(Vector3 targetSize)
        {
            sizeSetFlag = true;
        }

        public override void OnStageConnection(int depth)
        {
            stageConnectionFlag = true;
        }

        public override void OnStageDisconnection()
        {
            stageDisconnectionFlag = true;
        }

        public override void OnStyleChange(StyleManager styleManager, StyleChangeType change)
        {
            styleChangeFlag = true;
        }

        public override void OnTap(TapGesture tap)
        {
            tapFlag = true;
        }

        public override Size2D GetNaturalSize()
        {
            return new Size2D(200, 200);
        }

        public override float CalculateChildSize(View child, DimensionType dimension)
        {
            return base.CalculateChildSizeBase(child, dimension);
        }

        public Animation _CreateTransition(TransitionData transitionData)
        {
            return base.CreateTransition(transitionData);
        }

        public void _EmitFocusSignal(bool focusGained)
        {
            base.EmitFocusSignal(focusGained);
        }

        public void _EnableVisual(int index, bool enable)
        {
            base.EnableVisual(index, enable);
        }

        public float _GetHeightForWidth(float width)
        {
            return base.GetHeightForWidthBase(width);
        }

        public VisualBase _GetVisual(int index)
        {
            return base.GetVisual(index);
        }

        public float _GetWidthForHeight(float height)
        {
            return base.GetWidthForHeightBase(height);
        }

        public bool _IsVisualEnabled(int index)
        {
            return base.IsVisualEnabled(index);
        }

        public void _RegisterVisual(int index, VisualBase visual)
        {
            base.RegisterVisual(index, visual);
        }

        public void _RegisterVisual(int index, VisualBase visual, bool enabled)
        {
            base.RegisterVisual(index, visual, enabled);
        }

        public bool _RelayoutDependentOnChildren(DimensionType dimension)
        {
            return base.RelayoutDependentOnChildrenBase(dimension);
        }

        public bool _RelayoutDependentOnChildren()
        {
            return base.RelayoutDependentOnChildrenBase();
        }

        public void _RelayoutRequest()
        {
            base.RelayoutRequest();
        }

        public void _UnregisterVisual(int index)
        {
            base.UnregisterVisual(index);
        }

    }
}
