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
    [Description("Tizen.NUI.Layer Tests")]
    public class LayerTests
    {

        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("LayerTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali layer constructor test")]
        [Property("SPEC", "Tizen.NUI.Layer.Layer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Layer_INIT()
        {
            /* TEST CODE */
            var layer = new Layer();
            Assert.IsInstanceOf<Layer>(layer, "Should return Layer instance.");
        }

        [Test]
        [Category("P1")]
        [Description("test add, add a view to layer")]
        [Property("SPEC", "Tizen.NUI.Layer.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Add_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                View view = new View();
                Layer layer = new Layer();
                layer.Add(view);
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
        [Description("Test GetParent. Check whether GetParent return the correct value.")]
        [Property("SPEC", "Tizen.NUI.Layer.GetParent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetParent_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Layer child = new Layer();
            Window.Instance.AddLayer(child);
            Layer defaultLayer = Window.Instance.GetDefaultLayer();
            Assert.IsNull(child.GetParent(), "The child layer's parent should be null.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ChildCount. Check whether ChildCount can return the correct value of child number.")]
        [Property("SPEC", "Tizen.NUI.Layer.ChildCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ChildCount_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            view.Size2D = new Size2D(100, 100);
            view.BackgroundColor = Color.Red;

            Layer layer = new NUI.Layer();
            layer.Add(view);
            Window.Instance.AddLayer(layer);
            Assert.AreEqual(1, layer.ChildCount, "Should be equal!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Name. Check whether Name is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Layer.Name A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Name_SET_GET_VALUE()
        {
            /* TEST CODE */
            Layer layer = new Layer();
            layer.Name = "Layer";
            Assert.AreEqual("Layer", layer.Name, "The layer's Name is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Opacity. Check whether Opacity is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Layer.Opacity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Opacity_SET_GET_VALUE()
        {
            /* TEST CODE */
            Layer layer = new Layer();

            layer.Opacity = 0.5f;
            await Task.Delay(20);
            Assert.AreEqual(0.5f, layer.Opacity, "The Opacity of layer should be true now");
        }

        [Test]
        [Category("P1")]
        [Description("Test Visibility. Check whether Visibility return the right value.")]
        [Property("SPEC", "Tizen.NUI.Layer.Visibility A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Visibility_GET_VALUE()
        {
            /* TEST CODE */
            Layer layer = new Layer();
            layer.Visibility = true;
            await Task.Delay(200);
            Assert.IsTrue(layer.Visibility, "The value of layer.Visibility is not correct here");
        }

        [Test]
        [Category("P1")]
        [Description("Test Viewport. Check whether Viewport return the right value.")]
        [Property("SPEC", "Tizen.NUI.Layer.Viewport A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Viewport_GET_VALUE()
        {
            /* TEST CODE */
            Layer layer = new Layer();
            layer.Viewport = new Rectangle(0, 0, 1, 1);
            Rectangle rectangle = layer.Viewport;
            Assert.AreEqual(0, rectangle.X, "The value of X is not correct here");
            Assert.AreEqual(0, rectangle.Y, "The value of Y is not correct here");
            Assert.AreEqual(1, rectangle.Width, "The value of Width is not correct here");
            Assert.AreEqual(1, rectangle.Height, "The value of Height is not correct here");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetChildCount. Check whether GetChildCount is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Layer.GetChildCount C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetChildCount_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Layer Parent = new Layer();
            View Child = new View();
            Parent.Add(Child);
            Assert.AreEqual(1, Parent.GetChildCount(), "The Parent layer's child count should be equal to 1.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Parent. Check whether Parent is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Layer.Parent C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Parent_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Layer child = new Layer();
            Window.Instance.AddLayer(child);
            Layer defaultLayer = Window.Instance.GetDefaultLayer();
            Assert.IsNull(child.Parent, "The child layer's parent should be null.");
        }

        [Test]
        [Category("P1")]
        [Description("test remove, remove a view from layer")]
        [Property("SPEC", "Tizen.NUI.Layer.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Remove_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                View view = new View();
                Layer layer = new Layer();
                layer.Add(view);
                layer.Remove(view);
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
        [Description("Test FindChildByName. Search through this view's hierarchy for an view with the given ID.")]
        [Property("SPEC", "Tizen.NUI.Layer.FindChildById M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void FindChildById_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                View child = new View();
                child.Name = "Child";
                Layer layer = new Layer();
                layer.Add(child);
                Window.Instance.AddLayer(layer);
                uint childID = child.ID;
                Tizen.Log.Info(TAG, "childID=" + childID);
                View child1 = layer.FindChildById(childID);
                if(child1 == null)
                {
                    Assert.Fail("FindChild should not be null!");
                }
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
        [Description("Test GetChildAt. Get the child of the layer according to the specific ID.")]
        [Property("SPEC", "Tizen.NUI.Layer.GetChildAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetChildAt_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                View childActor = new View();
                childActor.Name = "Child";
                childActor.Size = new Size(100.0f, 100.0f, 100.0f);
                Layer layer = new Layer();
                layer.Add(childActor);
                Assert.IsNotNull(layer.GetChildAt(0), "Should be not null");
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
        [Description("Test Depth. Check whether Depth returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Layer.Depth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Depth_GET_VALUE()
        {
            /* TEST CODE */
            Layer layer1 = new Layer();
            Layer layer2 = new Layer();
            Assert.AreEqual(0u, layer1.Depth, "The Depth of layer1 should be zeor here.");
            Assert.AreEqual(0u, layer2.Depth, "The Depth of layer2 should be zeor here.");

            Window win = Window.Instance;
            uint layerCnt = win.LayerCount;
            Tizen.Log.Info(TAG, "win.LayerCount=" + layerCnt);

            win.AddLayer(layer1);
            win.AddLayer(layer2);
            Assert.AreEqual(layerCnt, layer1.Depth, "The Depth of layer1 should be " + (layerCnt));
            Assert.AreEqual((layerCnt + 1), layer2.Depth, "The Depth of layer2 should be " + (layerCnt + 1));
        }

        [Test]
        [Category("P1")]
        [Description("Test Raise. Check whether the layer go to the right depth after raise.")]
        [Property("SPEC", "Tizen.NUI.Layer.Raise M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Raise_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                Layer layer1 = new Layer();
                Layer layer2 = new Layer();

                Window stage = Window.Instance;
                stage.AddLayer(layer1);
                stage.AddLayer(layer2);
                layer1.Raise();
                Assert.GreaterOrEqual(layer1.Depth, 2u, "The Depth of layer1 should be 2 here.");
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
        [Description("Test Lower. Check whether the layer go to the right depth after lower.")]
        [Property("SPEC", "Tizen.NUI.Layer.Lower M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Lower_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                Layer layer1 = new Layer();
                Layer layer2 = new Layer();

                Window stage = Window.Instance;
                stage.AddLayer(layer1);
                stage.AddLayer(layer2);
                layer2.Lower();
                Assert.GreaterOrEqual(layer2.Depth, 1u, "The Depth of layer2 should be 1 here.");
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
        [Description("Test RaiseToTop. Check whether the layer go to the top after RaiseToTop.")]
        [Property("SPEC", "Tizen.NUI.Layer.RaiseToTop M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RaiseToTop_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                Layer layer1 = new Layer();
                Layer layer2 = new Layer();

                Window stage = Window.Instance;
                stage.AddLayer(layer1);
                stage.AddLayer(layer2);
                layer1.RaiseToTop();
                Assert.GreaterOrEqual(layer2.Depth, 2u, "The Depth of layer1 should be 2 here.");
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
        [Description("Test LowerToBottom. Check whether the layer go to the bottom after LowerToBottom.")]
        [Property("SPEC", "Tizen.NUI.Layer.LowerToBottom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void LowerToBottom_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                Layer layer1 = new Layer();
                Layer layer2 = new Layer();

                Window stage = Window.Instance;
                stage.AddLayer(layer1);
                stage.AddLayer(layer2);
                layer2.LowerToBottom();
                Assert.AreEqual(0u, layer2.Depth, "The Depth of layer2 should be zero here.");
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
        [Description("Test MoveAbove. Check whether the layer go to the right depth after MoveAbove.")]
        [Property("SPEC", "Tizen.NUI.Layer.MoveAbove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void MoveAbove_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                Layer layer1 = new Layer();
                Layer layer2 = new Layer();

                Window stage = Window.Instance;
                stage.AddLayer(layer1);
                stage.AddLayer(layer2);

                layer1.MoveAbove(layer2);
                Assert.GreaterOrEqual(layer1.Depth, 2u, "The Depth of layer1 should be 2 here.");
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
        [Description("Test MoveBelow. Check whether the layer go to the right depth after MoveAbove.")]
        [Property("SPEC", "Tizen.NUI.Layer.MoveBelow M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void MoveBelow_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                Layer layer1 = new Layer();
                Layer layer2 = new Layer();

                Window stage = Window.Instance;
                stage.AddLayer(layer1);
                stage.AddLayer(layer2);

                layer2.MoveBelow(layer1);
                Assert.GreaterOrEqual(layer1.Depth, 2u, "The Depth of layer1 should be 2 here.");
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
        [Description("Test Behavior. Check whether Behavior is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Layer.Behavior A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Behavior_SET_GET_VALUE()
        {
            /* TEST CODE */
            Layer layer = new Layer();
            layer.Behavior = Layer.LayerBehavior.Layer3D;
            Assert.AreEqual(layer.Behavior, Layer.LayerBehavior.Layer3D, "The Behavior of layer is not correct here.");
        }
    }
}
