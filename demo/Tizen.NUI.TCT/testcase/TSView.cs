using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Tizen.NUI.Test;
using System.Collections.Generic;


namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.View Tests")]
    public class ViewTests
    {
        private string TAG = "NUI";
        private bool _flag = false;
        private string _imagePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        private string _vertexShader = " attribute mediump vec2 aPosition;\n" +
                    " uniform   mediump mat4 uMvpMatrix;\n" +
                    " \n" +
                    " void main()\n" +
                    " {\n" +
                    "   mediump vec4 vertexPosition = vec4(aPosition, 0.0, 1.0);\n" +
                    "   gl_Position = uMvpMatrix * vertexPosition;\n" +
                    " }\n";
        private string _fragmentShader = " uniform mediump vec4 uColor;\n" +
                                        "  \n" +
                                        "  void main()\n" +
                                        "  {\n" +
                                        " gl_FragColor = uColor;\n" +
                                        " }\n";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            _flag = false;
            App.MainTitleChangeText("ViewTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        private void viewEventCallback(object sender, EventArgs e)
        {
            _flag = true;
        }

        [Test]
        [Category("P1")]
        [Description("dali view constructor test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.View C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void View_INIT()
        {
            /* TEST CODE */
            var view = new View();
            Assert.IsInstanceOf<View>(view, "Should return View instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali view constructor test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Add_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                View childActor = new View();
                View parentActor = new View();
                parentActor.Add(childActor);
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
        [Description("Test FindChildByName. Search through this view's hierarchy for an view with the given name.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.FindChildByName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void FindChildByName_CHECK_STATE()
        {
            /* TEST CODE */
            View childActor = new View();
            childActor.Name = "Child";
            View parentActor = new View();
            parentActor.Add(childActor);
            parentActor.FindChildByName("Child");
            Assert.IsTrue((childActor == (parentActor.FindChildByName("Child"))), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetContainerParent. Check GetContainerParent function works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.GetContainerParent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetContainerParent_CHECK_VALUE()
        {
            /* TEST CODE */
            View childActor = new View();
            childActor.Name = "Child";
            View parentActor = new View();
            parentActor.Add(childActor);
            Container container = childActor.GetParent();
            View view = container.GetChildAt(0);
            Assert.IsTrue((view == childActor), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetParent. Check whether GetParent return the correct value.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.GetParent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetParent_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            View Parent = new View();
            View Child = new View();
            Parent.Add(Child);
            Assert.IsNotNull(Child.GetParent(), "The child view's parent should be not null.");
            Assert.AreEqual(Parent, Child.GetParent(), "The child's Parent should be equal to the Parent View here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Children. Check whether Children is readable.")]
        [Property("SPEC", "Tizen.NUI.Container.Children A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Children_READ_ONLY()
        {
            /* TEST CODE */
            View parentContainer = new View();
            View childView = new View();
            parentContainer.Add(childView);
            List<View> children = parentContainer.Children;
            Assert.AreEqual(1, children.Count, "Should be equal to 1");
            Assert.AreEqual(childView, children[0], "The child at the 0 index should be equal to childView");
        }

        [Test]
        [Category("P1")]
        [Description("Test HierarchyDepth. Check whether HierarchyDepth returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.HierarchyDepth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void HierarchyDepth_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            Assert.AreEqual(-1, actor.HierarchyDepth, "The actor is not in the hierarchy");
            Window.Instance.GetDefaultLayer().Add(actor);
            Assert.AreEqual(1, actor.HierarchyDepth, "The actor is in the hierarchy");
            Window.Instance.GetDefaultLayer().Remove(actor);
        }


        [Test]
        [Category("P1")]
        [Description("Test DrawMode. Check whether DrawMode is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.DrawMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task DrawMode_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.DrawMode = DrawModeType.Overlay2D;
            await Task.Delay(20);
            Assert.AreEqual(DrawModeType.Overlay2D, actor.DrawMode, "The actor's ColorMode is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test LayoutDirection. Check whether LayoutDirection is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.LayoutDirection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task LayoutDirection_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.LayoutDirection = ViewLayoutDirectionType.LTR;
            await Task.Delay(20);
            Assert.AreEqual(ViewLayoutDirectionType.LTR, actor.LayoutDirection, "The actor's LayoutDirection is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test InheritLayoutDirection. Check whether InheritLayoutDirection is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.InheritLayoutDirection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task InheritLayoutDirection_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.InheritLayoutDirection = true;
            await Task.Delay(20);
            Assert.IsTrue(actor.InheritLayoutDirection, "The actor's InheritLayoutDirection is not correct");
        }


        [Test]
        [Category("P1")]
        [Description("Test ClippingMode. Check whether ClippingMode is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ClippingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ClippingMode_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.ClippingMode = ClippingModeType.Disabled;
            Assert.AreEqual(ClippingModeType.Disabled, actor.ClippingMode, "The actor's MaximumSize.ClippingMode is not correct, it should ClippingModeType.Disabled");
        }


        [Test]
        [Category("P1")]
        [Description("Test GetChildAt. Retrieve child actor by index.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.GetChildAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetChildAt_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            View childActor1 = new View();
            View parentActor = new View();
            parentActor.Add(childActor1);
            Assert.NotNull(parentActor.GetChildAt(0), "The child at index 0 should be not null");
        }

        [Test]
        [Category("P1")]
        [Description("Test ParentOrigin. Check whether ParentOrigin is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ParentOrigin A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ParentOrigin_SET_GET_VALUE()
        {
            /* TEST CODE */
            View parentActor = new View();
            View childActor = new View();
            Position position = new Position(0.0f, 0.0f, 0.5f);
            childActor.ParentOrigin = position;
            parentActor.Add(childActor);
            Position parentOrigin = childActor.ParentOrigin;
            Assert.AreEqual(position.X, parentOrigin.X, "The ParentOrigin.X of actor should be 0.0f now");
            Assert.AreEqual(position.Y, parentOrigin.Y, "The ParentOrigin.Y of actor should be 0.0f now");
            Assert.AreEqual(position.Z, parentOrigin.Z, "The ParentOrigin.Z of actor should be 0.5f now");
        }

        [Test]
        [Category("P1")]
        [Description("Test PivotPoint. Check whether PivotPoint is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.PivotPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PivotPoint_SET_GET_VALUE()
        {
            /* TEST CODE */
            View parentActor = new View();
            View childActor = new View();
            Position position = new Position(0.0f, 0.0f, 0.5f);
            childActor.PivotPoint = position;
            parentActor.Add(childActor);
            Position anchorPoint = childActor.PivotPoint;
            Assert.AreEqual(position.X, anchorPoint.X, "The PivotPoint.X of actor should be 0.0f now");
            Assert.AreEqual(position.Y, anchorPoint.Y, "The PivotPoint.Y of actor should be 0.0f now");
            Assert.AreEqual(position.Z, anchorPoint.Z, "The PivotPoint.Z of actor should be 0.5f now");
        }

        [Test]
        [Category("P1")]
        [Description("Test Position2D. Check whether Position2D is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Position2D A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Position2D_SET_GET_VALUE()
        {
            /* TEST CODE */
            View parentActor = new View();
            View childActor = new View();
            Position2D position = new Position2D(2, 3);
            childActor.Position2D = position;
            parentActor.Add(childActor);

            await Task.Delay(20);
            Assert.AreEqual(position.X, childActor.Position.X, "The Position.X of actor should be 2 now");
            Assert.AreEqual(position.Y, childActor.Position.Y, "The Position.Y of actor should be 3 now");
        }

        [Test]
        [Category("P1")]
        [Description("Test PositionUsesPivotPoint. Check whether PositionUsesPivotPoint is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.PositionUsesPivotPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task PositionUsesPivotPoint_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.PositionUsesPivotPoint = true;
            actor.PivotPoint = Position.PivotPointCenter;
            Assert.IsTrue(actor.PositionUsesPivotPoint, "The actor.PositionUsesPivotPoint should be true now");
        }

        [Test]
        [Category("P1")]
        [Description("Test WorldPosition. Check whether WorldPosition returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.WorldPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task WorldPosition_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.Size2D = new Size2D(100, 100);
            Position position = new Position(6.0f, 6.0f, 6.0f);
            actor.Position = position;

            actor.PositionUsesPivotPoint = true;
            actor.PivotPoint = PivotPoint.Center;
            actor.ParentOrigin = PivotPoint.Center;

            View parentActor = new View();
            parentActor.Size2D = new Size2D(100, 100);
            Position parentPosition = new Position(1.0f, 2.0f, 3.0f);
            parentActor.Position = parentPosition;

            parentActor.PositionUsesPivotPoint = true;
            parentActor.PivotPoint = PivotPoint.Center;
            parentActor.ParentOrigin = PivotPoint.Center;

            parentActor.Add(actor);

            Window.Instance.GetDefaultLayer().Add(parentActor);

            await Task.Delay(300);

            Assert.AreEqual(parentPosition.X, parentActor.WorldPosition.X, "The WorldPosition.X of parentActor should be 1.0f now");
            Assert.AreEqual(parentPosition.Y, parentActor.WorldPosition.Y, "The WorldPosition.Y of parentActor should be 2.0f now");
            Assert.AreEqual(parentPosition.Z, parentActor.WorldPosition.Z, "The WorldPosition.Z of parentActor should be 3.0f now");
            Assert.AreEqual((position.X + parentPosition.X), actor.WorldPosition.X, "The WorldPosition.X of actor should be 7.0f now");
            Assert.AreEqual((position.Y + parentPosition.Y), actor.WorldPosition.Y, "The WorldPosition.Y of actor should be 8.0f now");
            Assert.AreEqual((position.Z + parentPosition.Z), actor.WorldPosition.Z, "The WorldPosition.Z of actor should be 9.0f now");
            Window.Instance.GetDefaultLayer().Remove(parentActor);
        }

        [Test]
        [Category("P1")]
        [Description("Test AddedToWindow. Test whether the AddedToWindow event will be triggered when the view has been add to the window.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.AddedToWindow E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AddedToWindow_CHECK_EVENT()
        {
            View view = new View();
            view.AddedToWindow += viewEventCallback;
            Window.Instance.GetDefaultLayer().Add(view);
            Assert.IsTrue(_flag, "The AddedToWindow Event has been triggerred!");
            Window.Instance.GetDefaultLayer().Remove(view);
            view.AddedToWindow -= viewEventCallback;
        }

        [Test]
        [Category("P1")]
        [Description("Test Position. Check whether Position is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Position A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Position_SET_GET_VALUE()
        {
            /* TEST CODE */
            View parentActor = new View();
            View childActor = new View();
            Position position = new Position(0.7f, 0.8f, 0.9f);
            childActor.Position = position;
            parentActor.Add(childActor);

            await Task.Delay(20);
            Assert.AreEqual(position.X, childActor.Position.X, "The Position.X of actor should be 0.7f now");
            Assert.AreEqual(position.Y, childActor.Position.Y, "The Position.Y of actor should be 0.8f now");
            Assert.AreEqual(position.Z, childActor.Position.Z, "The Position.Z of actor should be 0.9f now");
        }

        [Test]
        [Category("P1")]
        [Description("Test PositionX. Check whether PositionX is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.PositionX A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task PositionX_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.PositionX = 0.7f;

            await Task.Delay(20);
            Assert.AreEqual(0.7f, actor.PositionX, "The PositionX of actor should be 0.7f now");
        }

        [Test]
        [Category("P1")]
        [Description("Test PositionY. Check whether PositionY is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.PositionY A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task PositionY_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.PositionY = 0.8f;

            await Task.Delay(20);
            float positionY = actor.PositionY;
            Assert.AreEqual(0.8f, positionY, "The positionY of actor should be 0.8f now");

        }

        [Test]
        [Category("P1")]
        [Description("Test PositionZ. Check whether PositionZ is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.PositionZ A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task PositionZ_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.PositionZ = 0.9f;

            await Task.Delay(20);
            Assert.AreEqual(0.9f, actor.PositionZ, "The PositionZ of actor should be 0.9f now");

        }

        [Test]
        [Category("P1")]
        [Description("Test Scale. Check whether Scale is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Scale A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Scale_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector3 scale = new Vector3(10.0f, 10.0f, 10.0f);
            View actor = new View();
            actor.Scale = scale;

            await Task.Delay(20);
            Assert.AreEqual(scale.X, actor.Scale.X, "The Scale.X of actor should be 10.0f now");
            Assert.AreEqual(scale.Y, actor.Scale.Y, "The Scale.Y of actor should be 10.0f now");
            Assert.AreEqual(scale.Z, actor.Scale.Z, "The Scale.Z of actor should be 10.0f now");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScaleX. Check whether ScaleX is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ScaleX A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task ScaleX_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.ScaleX = 10.0f;
            await Task.Delay(20);
            Assert.AreEqual(10.0f, actor.ScaleX, "The ScaleX of actor should be 10.0f now");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScaleY. Check whether ScaleY is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ScaleY A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task ScaleY_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.ScaleY = 10.0f;
            await Task.Delay(20);
            Assert.AreEqual(10.0f, actor.ScaleY, "The ScaleY of actor should be 10.0f now");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScaleZ. Check whether ScaleZ is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ScaleZ A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task ScaleZ_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.ScaleZ = 10.0f;
            await Task.Delay(20);
            Assert.AreEqual(10.0f, actor.ScaleZ, "The ScaleZ of actor should be 10.0f now");
        }


        [Test]
        [Category("P1")]
        [Description("Test Size2D. Check whether Size2D is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Size2D A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Size2D_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            Size2D size = new Size2D(0, 0);
            actor.Size2D = size;
            Size2D actorSize = actor.Size2D;
            await Task.Delay(20);
            Assert.AreEqual(size.Width, actorSize.Width, "The Width of actor should be 100.0f now");
            Assert.AreEqual(size.Height, actorSize.Height, "The Height of actor should be 100.0f now");
        }

        [Test]
        [Category("P1")]
        [Description("Test Size. Check whether Size is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Size A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Size_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            Size size = new Size(0, 0, 0);
            actor.Size = size;
            Window.Instance.GetDefaultLayer().Add(actor);
            Size actorSize = actor.Size;
            await Task.Delay(20);
            Assert.AreEqual(size.Width, actorSize.Width, "The Width of actor should be 100.0f now");
            Assert.AreEqual(size.Height, actorSize.Height, "The Height of actor should be 100.0f now");
            Window.Instance.GetDefaultLayer().Remove(actor);
        }

        [Test]
        [Category("P1")]
        [Description("Test SizeHeight. Check whether SizeHeight is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.SizeHeight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task SizeHeight_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.Size = new Size(100.0f, 100.0f, 100.0f);

            await Task.Delay(20);
            Assert.AreEqual(100.0f, actor.SizeHeight, "The SizeHeight of actor should be 100.0f now");
            actor.SizeHeight = 50.0f;
            Assert.AreEqual(50.0f, actor.SizeHeight, "The SizeHeight of actor should be 50.0f now");
        }


        [Test]
        [Category("P1")]
        [Description("Test SizeWidth. Check whether SizeWidth is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.SizeWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task SizeWidth_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.Size = new Size(100.0f, 100.0f, 100.0f);
            Assert.AreEqual(100.0f, actor.SizeWidth, "The SizeWidth of actor should be 100.0f now");
            actor.SizeWidth = 50.0f;
            await Task.Delay(20);
            Assert.AreEqual(50.0f, actor.SizeWidth, "The SizeWidth of actor should be 50.0f now");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScreenPosition. Check whether ScreenPosition returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ScreenPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task ScreenPosition_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.PivotPoint = PivotPoint.TopLeft;
            actor.Size2D = new Size2D(10, 20);
            actor.Position = new Position(30, 40, 0);

            Window.Instance.GetDefaultLayer().Add(actor);

            await Task.Delay(100);

            Assert.Greater(actor.ScreenPosition.X, 0, "The X of the actor's ScreenPosition is not correct!");
            Assert.Greater(actor.ScreenPosition.Y, 0, "The Y of the actor's ScreenPosition is not correct!");
            Window.Instance.GetDefaultLayer().Remove(actor);
        }

        [Test]
        [Category("P1")]
        [Description("Test Opacity. Check whether Opacity is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Opacity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Opacity_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();

            actor.Opacity = 0.5f;
            await Task.Delay(20);
            Assert.AreEqual(0.5f, actor.Opacity, "The Opacity of actor should be true now");
        }

        [Test]
        [Category("P1")]
        [Description("Test SiblingOrder. Check whether SiblingOrder is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.SiblingOrder A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SiblingOrder_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.SiblingOrder = 0;
            Assert.AreEqual(0, actor.SiblingOrder, "The SiblingOrder of actor should be 1 now");
        }

        [Test]
        [Category("P1")]
        [Description("Test WorldScale. Check whether WorldScale returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.WorldScale A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task WorldScale_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            Vector3 actorScale = new Vector3(2.0f, 2.0f, 2.0f);
            actor.Scale = actorScale;

            View parentActor = new View();
            Vector3 parentScale = new Vector3(1.0f, 2.0f, 1.0f);
            parentActor.Scale = parentScale;
            parentActor.Add(actor);
            Window.Instance.GetDefaultLayer().Add(parentActor);

            await Task.Delay(20);
            Assert.Greater(parentActor.WorldScale.X, 0, "The WorldScale.X of parentActor should be 1.0f now");
            Assert.Greater(parentActor.WorldScale.Y, 0, "The WorldScale.Y of parentActor should be 2.0f now");
            Assert.Greater(parentActor.WorldScale.Z, 0, "The WorldScale.Z of parentActor should be 1.0f now");
            Assert.Greater(actor.WorldScale.X, 0, "The WorldScale.X of actor should be 2.0f now");
            Assert.Greater(actor.WorldScale.Y, 0, "The WorldScale.Y of actor should be 4.0f now");
            Assert.Greater(actor.WorldScale.Z, 0, "The WorldScale.Z of actor should be 2.0f now");
            Window.Instance.GetDefaultLayer().Remove(parentActor);
        }

        [Test]
        [Category("P1")]
        [Description("Test WorldColor. Check whether WorldColor returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.WorldColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task WorldColor_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            Assert.AreEqual(1.0f, actor.WorldColor.A, "The actor's WorldColor.A is not correct");
            Assert.AreEqual(1.0f, actor.WorldColor.B, "The actor's WorldColor.B is not correct");
            Assert.AreEqual(1.0f, actor.WorldColor.G, "The actor's WorldColor.G is not correct");
            Assert.AreEqual(1.0f, actor.WorldColor.R, "The actor's WorldColor.R is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Name. Check whether Name is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Name A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Name_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.Name = "actor";
            Assert.AreEqual("actor", actor.Name, "The actor's Name is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Sensitive. Check whether Sensitive is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Sensitive A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Sensitive_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.Sensitive = false;

            Assert.AreEqual(false, actor.Sensitive, "The actor's Sensitive is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test LeaveRequired. Check whether LeaveRequired is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.LeaveRequired A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void LeaveRequired_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.LeaveRequired = false;
            Assert.IsFalse(actor.LeaveRequired, "The actor's LeaveRequired is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test InheritOrientation. Check whether InheritOrientation is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.InheritOrientation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void InheritOrientation_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.InheritOrientation = false;
            Assert.IsFalse(actor.InheritOrientation, "The actor's InheritOrientation is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test InheritScale. Check whether InheritScale is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.InheritScale A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void InheritScale_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.InheritScale = false;
            Assert.IsFalse(actor.InheritScale, "The actor's InheritScale is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test SizeModeFactor. Check whether SizeModeFactor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.SizeModeFactor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SizeModeFactor_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            Vector3 defaultSizeModeFactor = new Vector3(1.0f, 1.0f, 1.0f);
            Assert.AreEqual(defaultSizeModeFactor.X, actor.SizeModeFactor.X, "The actor's default SizeModeFactor.X is not correct");
            Assert.AreEqual(defaultSizeModeFactor.Y, actor.SizeModeFactor.Y, "The actor's default SizeModeFactor.X is not correct");
            Assert.AreEqual(defaultSizeModeFactor.Z, actor.SizeModeFactor.Z, "The actor's default SizeModeFactor.X is not correct");

            Vector3 sizeModeFactor = new Vector3(2.0f, 3.0f, 4.0f);
            actor.SizeModeFactor = sizeModeFactor;
            Assert.AreEqual(sizeModeFactor.X, actor.SizeModeFactor.X, "The actor's SizeModeFactor.X is not correct");
            Assert.AreEqual(sizeModeFactor.Y, actor.SizeModeFactor.Y, "The actor's SizeModeFactor.X is not correct");
            Assert.AreEqual(sizeModeFactor.Z, actor.SizeModeFactor.Z, "The actor's SizeModeFactor.X is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetSizeModeFactor. Set the Size mode factor of the actor.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.SetSizeModeFactor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SetSizeModeFactor_SET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();

            Vector3 sizeModeFactor = new Vector3(2.0f, 3.0f, 4.0f);
            actor.SetSizeModeFactor(sizeModeFactor);
            Assert.AreEqual(sizeModeFactor.X, actor.SizeModeFactor.X, "The actor's SizeModeFactor.X is not correct");
            Assert.AreEqual(sizeModeFactor.Y, actor.SizeModeFactor.Y, "The actor's SizeModeFactor.X is not correct");
            Assert.AreEqual(sizeModeFactor.Z, actor.SizeModeFactor.Z, "The actor's SizeModeFactor.X is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test WidthResizePolicy. Check whether WidthResizePolicy is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.WidthResizePolicy A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void WidthResizePolicy_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.WidthResizePolicy = ResizePolicyType.FillToParent;
            Assert.AreEqual(ResizePolicyType.FillToParent, actor.WidthResizePolicy, "The actor's WidthResizePolicy is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test HeightResizePolicy. Check whether HeightResizePolicy is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.HeightResizePolicy A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void HeightResizePolicy_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.HeightResizePolicy = ResizePolicyType.FillToParent;
            Assert.AreEqual(ResizePolicyType.FillToParent, actor.HeightResizePolicy, "The actor's HeightResizePolicy is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test SizeScalePolicy. Check whether SizeScalePolicy is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.SizeScalePolicy A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SizeScalePolicy_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.SizeScalePolicy = SizeScalePolicyType.FillWithAspectRatio;
            Assert.AreEqual(SizeScalePolicyType.FillWithAspectRatio, actor.SizeScalePolicy, "The actor's FillWithAspectRatio is not correct");

        }

        [Test]
        [Category("P1")]
        [Description("Test Padding. Check whether Padding is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Padding A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Padding_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            Extents padding = new Extents(1, 2, 3, 4);
            actor.Padding = padding;
            Assert.AreEqual(padding.Start, actor.Padding.Start, "The actor's Padding.Start is not correct");
            Assert.AreEqual(padding.End, actor.Padding.End, "The actor's Padding.End is not correct");
            Assert.AreEqual(padding.Top, actor.Padding.Top, "The actor's Padding.Top is not correct");
            Assert.AreEqual(padding.Bottom, actor.Padding.Bottom, "The actor's Padding.Bottom is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test PaddingEX. Check whether PaddingEX is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.PaddingEX A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PaddingEX_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.PaddingEX = new Extents(100, 100, 100, 100);
            Assert.AreEqual(100, actor.PaddingEX.Start, "The actor's PaddingEX.Start is not correct");
            Assert.AreEqual(100, actor.PaddingEX.End, "The actor's PaddingEX.End is not correct");
            Assert.AreEqual(100, actor.PaddingEX.Top, "The actor's PaddingEX.Top is not correct");
            Assert.AreEqual(100, actor.PaddingEX.Bottom, "The actor's PaddingEX.Bottom is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Margin. Check whether Margin is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Margin A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Margin_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.Margin = new Extents(100, 100, 100, 100);
            Assert.AreEqual(100, actor.Margin.Start, "The actor's Margin.Start is not correct");
            Assert.AreEqual(100, actor.Margin.End, "The actor's Margin.End is not correct");
            Assert.AreEqual(100, actor.Margin.Top, "The actor's Margin.Top is not correct");
            Assert.AreEqual(100, actor.Margin.Bottom, "The actor's Margin.Bottom is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetChildCount. Check whether GetChildCount is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.GetChildCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetChildCount_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            View Parent = new View();
            View Child = new View();
            Parent.Add(Child);
            Assert.AreEqual(1, Parent.GetChildCount(), "The Parent view's child count should be equal to 1.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Parent. Check whether Parent is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Parent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Parent_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            View Parent = new View();
            View Child = new View();
            Parent.Add(Child);
            Assert.IsNotNull(Child.Parent, "The child view's parent should be not null.");
        }

        [Test]
        [Category("P1")]
        [Description("Test MinimumSize. Check whether MinimumSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.MinimumSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void MinimumSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            Size2D minSize = new Size2D(1, 2);
            actor.MinimumSize = minSize;
            Assert.AreEqual(minSize.Width, actor.MinimumSize.Width, "The actor's MinimumSize.Width is not correct");
            Assert.AreEqual(minSize.Height, actor.MinimumSize.Height, "The actor's MinimumSize.Height is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test MaximumSize. Check whether MaximumSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.MaximumSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void MaximumSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            Size2D maxSize = new Size2D(200, 200);
            actor.MaximumSize = maxSize;
            Assert.AreEqual(maxSize.Width, actor.MaximumSize.Width, "The actor's MaximumSize.Width is not correct");
            Assert.AreEqual(maxSize.Height, actor.MaximumSize.Height, "The actor's MaximumSize.Height is not correct");
        }

        [Test]
        [Category("P1")]
        [Description("Test Remove. Check remove a child actor from parent actor.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Remove_CHECK()
        {
            /* TEST CODE */
            try
            {
                View childActor = new View();
                View parentActor = new View();
                parentActor.Add(childActor);
                parentActor.Remove(childActor);
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
        [Description("Test RaiseToTop. Try to raise an actor to the top.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.RaiseToTop M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RaiseToTop_CHECK()
        {
            /* TEST CODE */
            try
            {
                View actorA = new View();
                actorA.ParentOrigin = ParentOrigin.Center;
                actorA.PivotPoint = PivotPoint.Center;
                actorA.WidthResizePolicy = ResizePolicyType.FillToParent;
                actorA.HeightResizePolicy = ResizePolicyType.FillToParent;
                View actorB = new View();
                actorB.ParentOrigin = ParentOrigin.Center;
                actorB.PivotPoint = PivotPoint.Center;
                actorB.WidthResizePolicy = ResizePolicyType.FillToParent;
                actorB.HeightResizePolicy = ResizePolicyType.FillToParent;
                View actorC = new View();
                actorC.ParentOrigin = ParentOrigin.Center;
                actorC.PivotPoint = PivotPoint.Center;
                actorC.WidthResizePolicy = ResizePolicyType.FillToParent;
                actorC.HeightResizePolicy = ResizePolicyType.FillToParent;
                Window.Instance.GetDefaultLayer().Add(actorA);
                Window.Instance.GetDefaultLayer().Add(actorB);
                Window.Instance.GetDefaultLayer().Add(actorC);
                actorC.RaiseToTop();
                Window.Instance.GetDefaultLayer().Remove(actorA);
                Window.Instance.GetDefaultLayer().Remove(actorB);
                Window.Instance.GetDefaultLayer().Remove(actorC);
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
        [Description("Test LowerToBottom. Try to LowerToBottom an actor to the bottom.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.LowerToBottom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void LowerToBottom_CHECK()
        {
            /* TEST CODE */
            try
            {
                View actorA = new View();
                actorA.ParentOrigin = ParentOrigin.Center;
                actorA.PivotPoint = PivotPoint.Center;
                actorA.WidthResizePolicy = ResizePolicyType.FillToParent;
                actorA.HeightResizePolicy = ResizePolicyType.FillToParent;
                View actorB = new View();
                actorB.ParentOrigin = ParentOrigin.Center;
                actorB.PivotPoint = PivotPoint.Center;
                actorB.WidthResizePolicy = ResizePolicyType.FillToParent;
                actorB.HeightResizePolicy = ResizePolicyType.FillToParent;
                View actorC = new View();
                actorC.ParentOrigin = ParentOrigin.Center;
                actorC.PivotPoint = PivotPoint.Center;
                actorC.WidthResizePolicy = ResizePolicyType.FillToParent;
                actorC.HeightResizePolicy = ResizePolicyType.FillToParent;
                Window.Instance.GetDefaultLayer().Add(actorA);
                Window.Instance.GetDefaultLayer().Add(actorB);
                Window.Instance.GetDefaultLayer().Add(actorC);
                actorA.LowerToBottom();
                Window.Instance.GetDefaultLayer().Remove(actorA);
                Window.Instance.GetDefaultLayer().Remove(actorB);
                Window.Instance.GetDefaultLayer().Remove(actorC);
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
        [Description("Test Show.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Show M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Show_CHECK_STATE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.Show();
            await Task.Delay(2000);
            Assert.AreEqual(true, actor.Visibility, "Show() does not work!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Hide.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Hide M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Hide_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                View actor = new View();
                actor.Hide();
                await Task.Delay(2000);
                Assert.AreEqual(false, actor.Visibility, "Hide() does not work!");
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
        [Description("Test IsOnWindow. Check whether IsOnWindow returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.IsOnWindow A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void IsOnWindow_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            Window.Instance.GetDefaultLayer().Add(actor);
            bool isOnStage = actor.IsOnWindow;
            Assert.IsTrue(isOnStage, "The actor is on window now.");
            Window.Instance.GetDefaultLayer().Remove(actor);
        }

        [Test]
        [Category("P1")]
        [Description("Test SetPadding, Set the padding of the actor in layout.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.SetPadding M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SetPadding_SET_VALUE()
        {
            /* TEST CODE */
            try
            {
                View actor = new View();
                actor.SetPadding(new PaddingType(10.0f, 20.0f, 100.0f, 100.0f));
                PaddingType padding = new PaddingType();
                actor.GetPadding(padding);
                Assert.AreEqual(10.0f, padding.Start, "The Start padding is not correct!");
                Assert.AreEqual(20.0f, padding.End, "The End padding is not correct!");
                Assert.AreEqual(100.0f, padding.Top, "The Top padding is not correct!");
                Assert.AreEqual(100.0f, padding.Bottom, "The Bottom padding is not correct!");
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
        [Description("Test GetHeightForWidth. Check whether the actor has the right height with the given width")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.GetHeightForWidth M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetHeightForWidth_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            float height = actor.GetHeightForWidth(1.0f);
            Assert.AreEqual(1.0f, height, "The height got from GetHeightForWidth is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetWidthForHeight. Check whether the actor has the right width with the given height")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.GetWidthForHeight M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetWidthForHeight_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            float width = actor.GetWidthForHeight(1.0f);
            Assert.AreEqual(1.0f, width, "The width got from GetWidthForHeight is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test HeightForWidth. Check whether HeightForWidth is readable and writeable")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.HeightForWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void HeightForWidth_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.HeightForWidth = false;
            Assert.IsFalse(actor.HeightForWidth, "The HeightForWidth is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test WidthForHeight. Check whether WidthForHeight is readable and writeable")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.WidthForHeight M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void WidthForHeight_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.WidthForHeight = false;
            Assert.IsFalse(actor.WidthForHeight, "The WidthForHeight is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetPadding, Get the padding of the actor in layout.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.GetPadding M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetPadding_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.SetPadding(new PaddingType(10.0f, 20.0f, 100.0f, 100.0f));
            PaddingType padding = new PaddingType();
            actor.GetPadding(padding);
            Assert.AreEqual(10.0f, padding.Start, "The Left padding is not correct!");
            Assert.AreEqual(20.0f, padding.End, "The Right padding is not correct!");
            Assert.AreEqual(100.0f, padding.Top, "The Top padding is not correct!");
            Assert.AreEqual(100.0f, padding.Bottom, "The Bottom padding is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the actor.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                View actor = new View();
                actor.Dispose();
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
        [Description("Test WorldOrientation. Check whether WorldOrientation returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.WorldOrientation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task WorldOrientation_SET_VALUE()
        {
            /* TEST CODE */
            Rotation rotation = new Rotation(new Radian(new Degree(90.0f)), Vector3.YAxis);

            View parentActor = new View();
            parentActor.Orientation = rotation;

            Window.Instance.GetDefaultLayer().Add(parentActor);
            View childActor = new View();
            childActor.Orientation = rotation;
            parentActor.Add(childActor);
            await Task.Delay(20);
            Assert.Less(Math.Abs(rotation.Length() - (parentActor.WorldOrientation).Length()), 0.00001, "The parentActor's Orientation is not correct");
            Window.Instance.GetDefaultLayer().Remove(parentActor);
        }

        [Test]
        [Category("P1")]
        [Description("Test Orientation. Check whether Orientation is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Orientation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Orientation_SET_GET_VALUE()
        {
            /* TEST CODE */
            Rotation rotation = new Rotation(new Radian(0.785f), new Vector3(1.0f, 1.0f, 0.0f));

            View actor = new View();
            actor.Orientation = rotation;
            await Task.Delay(20);
            Assert.Less(Math.Abs(rotation.Length() - (actor.WorldOrientation).Length()), 0.00001, "The actor's Orientation is not correct");
        }




        [Test]
        [Category("P1")]
        [Description("dali view ClearBackground test, clear the background of the view.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ClearBackground M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ClearBackground_TEST()
        {
            /* TEST CODE */
            try
            {
                View view = new View();
                view.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                view.ClearBackground();
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
        [Description("Test Focusable. Check whether Focusable is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Focusable A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Focusable_SET_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            view.Focusable = true;
            Assert.IsTrue(view.Focusable, "The view should be focusable now");
        }


        [Test]
        [Category("P1")]
        [Description("Test FlexMargin. Check whether FlexMargin is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.FlexMargin A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void FlexMargin_SET_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            view.FlexMargin = new Vector4(10.0f, 10.0f, 10.0f, 10.0f);
            Assert.AreEqual(10.0f, view.FlexMargin.X, "The FlexMargin.X value of View is not correct!");
            Assert.AreEqual(10.0f, view.FlexMargin.Y, "The FlexMargin.X value of View is not correct!");
            Assert.AreEqual(10.0f, view.FlexMargin.X, "The FlexMargin.Y value of View is not correct!");
            Assert.AreEqual(10.0f, view.FlexMargin.W, "The FlexMargin.Z value of View is not correct!");
        }


        [Test]
        [Category("P1")]
        [Description("Test AlignSelf. Check whether AlignSelf is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.AlignSelf A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AlignSelf_SET_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            view.AlignSelf = 1;
            Assert.AreEqual(1, view.AlignSelf, "The AlignSelf value of View is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Flex. Check whether Flex is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Flex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Flex_SET_GET_VALUE()
        {
            /* TEST CODE */
            FlexContainer flexContainer = new FlexContainer();
            Window.Instance.GetDefaultLayer().Add(flexContainer);
            View view = new View();
            flexContainer.Add(view);

            view.Flex = 2.0f;
            Assert.AreEqual(2.0f, view.Flex, "The Flex value of View is not correct!");
            Window.Instance.GetDefaultLayer().Remove(flexContainer);
        }

        [Test]
        [Category("P1")]
        [Description("Test CellVerticalAlignment. Check whether CellVerticalAlignment is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.CellVerticalAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void CellVerticalAlignment_SET_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            view.CellVerticalAlignment = VerticalAlignmentType.Bottom;
            Assert.AreEqual(VerticalAlignmentType.Bottom, view.CellVerticalAlignment, "The CellVerticalAlignment value of View is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test CellHorizontalAlignment. Check whether CellHorizontalAlignment is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.CellHorizontalAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void CellHorizontalAlignment_SET_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            view.CellHorizontalAlignment = HorizontalAlignmentType.Center;
            Assert.AreEqual(HorizontalAlignmentType.Center, view.CellHorizontalAlignment, "The CellHorizontalAlignment value of View is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test ColumnSpan. Check whether ColumnSpan is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ColumnSpan A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ColumnSpan_SET_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            view.ColumnSpan = 2.0f;
            Assert.AreEqual(2.0f, view.ColumnSpan, "The ColumnSpan value of View is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test RowSpan. Check whether RowSpan is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.RowSpan A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RowSpan_SET_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            view.RowSpan = 2.0f;
            Assert.AreEqual(2.0f, view.RowSpan, "The RowSpan value of View is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test CellIndex. Check whether CellIndex is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.CellIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void CellIndex_SET_GET_VALUE()
        {
            /* TEST CODE */

            TableView table = new TableView(10, 10);
            table.Size = new Size(100.0f, 100.0f, 0.0f);
            Window.Instance.GetDefaultLayer().Add(table);

            View view1 = new View();
            view1.CellIndex = new Vector2(3, 4);
            Assert.AreEqual(3, view1.CellIndex.X);
            Assert.AreEqual(4, view1.CellIndex.Y);
            table.Add(view1);
            Assert.IsTrue(table.GetChildAt(new TableView.CellPosition(3, 4)) == view1, "The child at (3, 4) should be view1!");

            View view2 = new View();
            view2.RowSpan = 3.0f;
            view2.ColumnSpan = 2.0f;
            view2.CellIndex = new Vector2(6, 1);
            table.Add(view2);
            Assert.IsTrue(table.GetChildAt(new TableView.CellPosition(6, 1)) == view2, "The child at (6, 1) should be view2!");
            Assert.IsTrue(table.GetChildAt(new TableView.CellPosition(8, 2)) == view2, "The child at (8, 2) should be view2!");

            View view3 = new View();
            view3.Size = new Size(5.0f, 5.0f, 0.0f);
            view3.CellHorizontalAlignment = HorizontalAlignmentType.Center;
            view3.CellVerticalAlignment = VerticalAlignmentType.Bottom;
            table.Add(view3);
            Assert.IsTrue(table.GetChildAt(new TableView.CellPosition(0, 0)) == view3, "The child at (0, 0) should be view3!");
            Window.Instance.GetDefaultLayer().Remove(table);

        }

        [Test]
        [Category("P1")]
        [Description("Test Background. Check whether Background is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Background A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Background_SET_GET_VALUE()
        {
            /* TEST CODE */
            View view1 = new View();
            PropertyMap map = new PropertyMap();
            map.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Color));
            map.Insert((int)ColorVisualProperty.MixColor, new PropertyValue(new Color(0.0f, 0.0f, 0.0f, 1.0f)));
            view1.Background = map;

            PropertyMap BGMap = view1.Background;
            int type = 0;
            BGMap.Find(Visual.Property.Type).Get(out type);
            Assert.AreEqual((int)Visual.Type.Color, type, "type wrong");
            Vector4 color = new Vector4();
            if ((BGMap.Find((int)ColorVisualProperty.MixColor)).Get(color))
            {
                Assert.AreEqual(0.0f, color.R, "The R property of the clolr is not correct!");
                Assert.AreEqual(0.0f, color.G, "The R property of the clolr is not correct!");
                Assert.AreEqual(0.0f, color.B, "The R property of the clolr is not correct!");
                Assert.AreEqual(1.0f, color.A, "The R property of the clolr is not correct!");
            }
        }


        [Test]
        [Category("P1")]
        [Description("Test Background. Check whether Tooltip is readable and writable")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Tooltip A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Tooltip_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            PropertyMap map = new PropertyMap();
            PropertyMap contentMap = new PropertyMap();
            contentMap.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
            contentMap.Insert((int)TextVisualProperty.Text, new PropertyValue("ToolTip"));
            map.Add(Constants.Tooltip.Property.Content, new PropertyValue(contentMap));
            view.Tooltip = map;
            PropertyMap pMap = view.Tooltip;
            PropertyMap pContentMap = new PropertyMap();
            (pMap.Find(Constants.Tooltip.Property.Content)).Get(pContentMap);
            String str = "";
            pContentMap.Find((int)TextVisualProperty.Text).Get(out str);
            Assert.AreEqual("ToolTip", str, "The value of the string should be ToolTip!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Background. Check whether TooltipText is Writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.TooltipText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void TooltipText_SET_GET_VALUE()
        {
            /* TEST CODE */
            try
            {
                View view = new View();
                view.TooltipText = "ToolTip";
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
        [Description("Test BackgroundColor. Check whether BackgroundColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.BackgroundColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void BackgroundColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            View view1 = new TextLabel("Test");

            view1.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            Assert.AreEqual(0.0f, view1.BackgroundColor.R, "The value of R property of the BackgroundColor is not correct!");
            Assert.AreEqual(0.0f, view1.BackgroundColor.G, "The value of G property of the BackgroundColor is not correct!");
            Assert.AreEqual(0.0f, view1.BackgroundColor.B, "The value of B property of the BackgroundColor is not correct!");
            Assert.AreEqual(1.0f, view1.BackgroundColor.A, "The value of A property of the BackgroundColor is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test BackgroundImage. Check whether BackgroundImage is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.BackgroundImage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void BackgroundImage_SET_GET_VALUE()
        {
            /* TEST CODE */
            String imagePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
            View view1 = new View();
            view1.BackgroundImage = imagePath;
            Assert.AreEqual(imagePath, view1.BackgroundImage, "The value of view1's BackgroundImage is not correct here");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetStyleName. Set the style name of the View.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.SetStyleName A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SetStyleName_SET_VALUE()
        {
            /* TEST CODE */
            View view1 = new View();
            view1.SetStyleName("View");
            Assert.AreEqual("View", view1.StyleName, "The SetStyleName does not work here");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetStyleName. Get the style name of the view.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.GetStyleName A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetStyleName_GET_VALUE()
        {
            /* TEST CODE */
            View view1 = new View();
            view1.StyleName = "View";
            Assert.AreEqual("View", view1.GetStyleName(), "The return value of GetStyleName() is not correct here");
        }

        [Test]
        [Category("P1")]
        [Description("Test StyleName. Check whether StyleName is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.StyleName A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void StyleName_SET_GET_VALUE()
        {
            /* TEST CODE */
            View view1 = new View();
            view1.StyleName = "View";
            Assert.AreEqual("View", view1.StyleName, "The value of view1's StyleName is not correct here");
        }

        [Test]
        [Category("P1")]
        [Description("Test LeftFocusableView. Check whether LeftFocusableView is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.LeftFocusableView A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void LeftFocusableView_SET_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            View leftView = new View();
            Window.Instance.GetDefaultLayer().Add(view);
            Window.Instance.GetDefaultLayer().Add(leftView);
            view.LeftFocusableView = leftView;
            Assert.IsTrue((leftView == view.LeftFocusableView), "The value of view1's LeftFocusableView is not correct here");
            Window.Instance.GetDefaultLayer().Remove(view);
            Window.Instance.GetDefaultLayer().Remove(leftView);
        }

        [Test]
        [Category("P1")]
        [Description("Test RightFocusableView. Check whether RightFocusableView is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.RightFocusableView A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RightFocusableView_SET_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            View rightView = new View();
            Window.Instance.GetDefaultLayer().Add(view);
            Window.Instance.GetDefaultLayer().Add(rightView);
            view.RightFocusableView = rightView;
            Assert.IsTrue((rightView == view.RightFocusableView), "The value of view1's RightFocusableView is not correct here");
            Window.Instance.GetDefaultLayer().Remove(view);
            Window.Instance.GetDefaultLayer().Remove(rightView);
        }

        [Test]
        [Category("P1")]
        [Description("Test UpFocusableView. Check whether UpFocusableView is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.UpFocusableView A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void UpFocusableView_SET_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            View upView = new View();
            Window.Instance.GetDefaultLayer().Add(view);
            Window.Instance.GetDefaultLayer().Add(upView);
            view.UpFocusableView = upView;
            Assert.IsTrue((upView == view.UpFocusableView), "The value of view1's UpFocusableView is not correct here");
            Window.Instance.GetDefaultLayer().Remove(view);
            Window.Instance.GetDefaultLayer().Remove(upView);
        }

        [Test]
        [Category("P1")]
        [Description("Test Visibility. Check whether Visibility return the right value.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Visibility A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Visibility_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            view.Show();
            await Task.Delay(200);
            Assert.IsTrue(view.Visibility, "The value of view.Visibility is not correct here");
        }

        [Test]
        [Category("P1")]
        [Description("Test DownFocusableView. Check whether DownFocusableView is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.DownFocusableView A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void DownFocusableView_SET_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            View downView = new View();
            Window.Instance.GetDefaultLayer().Add(view);
            Window.Instance.GetDefaultLayer().Add(downView);
            view.DownFocusableView = downView;
            Assert.IsTrue((downView == view.DownFocusableView), "The value of view1's DownFocusableView is not correct here");
            Window.Instance.GetDefaultLayer().Remove(view);
            Window.Instance.GetDefaultLayer().Remove(downView);
        }

        [Test]
        [Category("P1")]
        [Description("Test NaturalSize. Check whether NaturalSize is readable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.NaturalSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void NaturalSize_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            Assert.IsInstanceOf<Vector3>(view.NaturalSize, "Should return Vector3 instance.");
            Assert.AreEqual(0, view.NaturalSize.Width, "The value of view's NaturalSize.Width is not correct here");
            Assert.AreEqual(0, view.NaturalSize.Height, "The value of view's NaturalSize.Height is not correct here");

            ImageView image = new ImageView(_imagePath);
            Assert.AreEqual(150, image.NaturalSize.Width, "The value of ImageView's NaturalSize.Width is not correct here");
            Assert.AreEqual(150, image.NaturalSize.Height, "The value of ImageView's NaturalSize.Height is not correct here");
        }

        [Test]
        [Category("P1")]
        [Description("Test NaturalSize2D. Check whether NaturalSize2D is readable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.NaturalSize2D A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void NaturalSize2D_SET_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            Assert.AreEqual(0, view.NaturalSize2D.Width, "The value of view's NaturalSize2D.Width is not correct here");
            Assert.AreEqual(0, view.NaturalSize2D.Height, "The value of view's NaturalSize2D.Height is not correct here");
        }


        [Test]
        [Category("P1")]
        [Description("Test State. Check whether State is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.State A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void State_SET_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            view.State = View.States.Normal;
            Assert.AreEqual(View.States.Normal, view.State, "The value of view's State is not correct here");
        }

        [Test]
        [Category("P1")]
        [Description("Test SubState. Check whether SubState is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.SubState A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SubState_SET_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            view.SubState = View.States.Focused;
            Assert.AreEqual(View.States.Focused, view.SubState, "The value of view's SubState is not correct here");
        }

        [Test]
        [Category("P1")]
        [Description("Test AddRenderer, Check whether AddRenderer works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.AddRenderer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AddRenderer_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Shader shader = new Shader(_vertexShader, _fragmentShader, Shader.Hint.Value.NONE);

            //Create the geometry
            Geometry geometry = new Geometry();
            Renderer renderer = new Renderer(geometry, shader);
            View view = new View();
            Assert.AreEqual(0, view.AddRenderer(renderer), "The index should be zero!");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetRendererAt, Check whether GetRendererAt works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.GetRendererAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetRendererAt_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Shader shader = new Shader(_vertexShader, _fragmentShader, Shader.Hint.Value.NONE);

            //Create the geometry
            Geometry geometry = new Geometry();
            Renderer renderer = new Renderer(geometry, shader);
            View view = new View();
            view.AddRenderer(renderer);
            Renderer renderer1 = view.GetRendererAt(0);
            if (renderer1 == renderer)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false, "GetRendererAt does not work!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test RemoveRenderer, Check whether RemoveRenderer works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.RemoveRenderer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "uint")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RemoveRenderer_CHECK_RETURN_VALUE_WITH_INDEX()
        {
            /* TEST CODE */
            Shader shader = new Shader(_vertexShader, _fragmentShader, Shader.Hint.Value.NONE);

            //Create the geometry
            Geometry geometry = new Geometry();
            Renderer renderer = new Renderer(geometry, shader);
            View view = new View();
            view.AddRenderer(renderer);
            try
            {
                view.RemoveRenderer(0);
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
        [Description("Test RemoveRenderer, Check whether RemoveRenderer works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.RemoveRenderer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Renderer")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RemoveRenderer_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Shader shader = new Shader(_vertexShader, _fragmentShader, Shader.Hint.Value.NONE);

            //Create the geometry
            Geometry geometry = new Geometry();
            Renderer renderer = new Renderer(geometry, shader);
            View view = new View();
            view.AddRenderer(renderer);
            try
            {
                view.RemoveRenderer(renderer);
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
        [Description("Test RendererCount, Check whether RendererCount returns the right or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.RendererCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void RendererCount_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Shader shader = new Shader(_vertexShader, _fragmentShader, Shader.Hint.Value.NONE);

            //Create the geometry
            Geometry geometry = new Geometry();
            Renderer renderer = new Renderer(geometry, shader);
            View view = new View();
            view.AddRenderer(renderer);
            Assert.AreEqual(1, view.RendererCount, "The RendererCount should be equal to 1.");
        }

        [Test]
        [Category("P1")]
        [Description("Test AnimateBackgroundColor, Check whether AnimateBackgroundColor works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.AnimateBackgroundColor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AnimateBackgroundColor_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            Window.Instance.Add(view);
            view.Size2D = new Size2D(100, 100);
            Animation animation = view.AnimateBackgroundColor(new Color(1.0f, 1.0f, 0.0f, 1.0f), 0, 1000);

            Assert.IsNotNull(animation, "The animation should be not null!");
            Assert.IsInstanceOf<Animation>(animation, "Should return a instance of Animation class!");
        }

        [Test]
        [Category("P1")]
        [Description("Test AnimateColor, Check whether AnimateColor works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.AnimateColor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AnimateColor_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            VisualView view = new VisualView();
            Window.Instance.GetDefaultLayer().Add(view);

            ColorVisual visual = new ColorVisual();
            visual.Color = Color.Red;

            view.AddVisual("visual1", visual);

            Animation animation = view.AnimateColor("visual1", new Color(1.0f, 1.0f, 0.0f, 1.0f), 0, 1000);

            Assert.IsNotNull(animation, "The animation should be not null!");
            Assert.IsInstanceOf<Animation>(animation, "Should return a instance of Animation class!");
            Window.Instance.GetDefaultLayer().Remove(view);
        }

        [Test]
        [Category("P1")]
        [Description("Test GetRelayoutSize. Check whether GetRelayoutSize will relayout the actor or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.GetRelayoutSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task GetRelayoutSize_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            Window.Instance.GetDefaultLayer().Add(actor);
            actor.WidthResizePolicy = ResizePolicyType.Fixed;
            actor.Size2D = new Size2D(100, 0);

            await Task.Delay(20);
            Assert.AreEqual(100.0f, actor.GetRelayoutSize(DimensionType.Width), "The GetRelayoutSize does not work here!");
            Window.Instance.GetDefaultLayer().Remove(actor);
        }

        [Test]
        [Category("P1")]
        [Description("Test Unparent. Check whether Unparent will move the view from parent or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Unparent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Unparent_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            Window.Instance.GetDefaultLayer().Add(view);
            try
            {
                view.Unparent();
                Window.Instance.GetDefaultLayer().Remove(view);
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
        [Description("Test IsResourceReady, Check whether IsResourceReady works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.IsResourceReady M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void IsResourceReady_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            view.BackgroundColor = Color.Red;
            view.Size2D = new Size2D(100, 100);
            Assert.IsFalse(view.IsResourceReady(), "Should not be ready before put the View on the window!");

            Window.Instance.GetDefaultLayer().Add(view);
            Assert.IsTrue(view.IsResourceReady(), "Should be true now!");
            Window.Instance.GetDefaultLayer().Remove(view);
        }

        [Test]
        [Category("P1")]
        [Description("Test ScreenToLocal. Check whether the actor has the right position after ScreenTo Local.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ScreenToLocal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task ScreenToLocal_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                View actor = new View();
                actor.PivotPoint = PivotPoint.TopLeft;
                actor.BackgroundColor = Color.Yellow;
                actor.Size = new Size(100.0f, 100.0f, 0.0f);
                actor.Position = new Position(10.0f, 10.0f, 0.0f);
                Window.Instance.GetDefaultLayer().Add(actor);
                await Task.Delay(100);

                float localX, localY;
                bool ret = false;
                ret = actor.ScreenToLocal(out localX, out localY, 50.0f, 50.0f);

                Assert.Greater(localX, 0.0f, "The localX is not correct!");
                Assert.IsTrue(ret, "ScreenToLocal() returns false!");
                Window.Instance.GetDefaultLayer().Remove(actor);
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
        [Description("Test ChildCount.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ChildCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ChildCount_GET_VALUE()
        {
            /* TEST CODE */
            View parentActor = new View();
            View childActor = new View();
            Assert.AreEqual(0, parentActor.ChildCount, "The child count of parentActor should be zero");
            parentActor.Add(childActor);
            Window.Instance.GetDefaultLayer().Add(parentActor);
            Assert.AreEqual(1, parentActor.ChildCount, "The child count of parentActor should be 1");
            Window.Instance.GetDefaultLayer().Remove(parentActor);
        }

        [Test]
        [Category("P1")]
        [Description("Test CurrentPosition. Check whether CurrentPosition returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.CurrentPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task CurrentPosition_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            Position position = new Position(100.0f, 100.0f, 100.0f);
            actor.Position = position;
            await Task.Delay(300);
            Assert.AreEqual(actor.Position.X, actor.CurrentPosition.X, "The X of the actor's CurrentPosition is not correct!");
            Assert.AreEqual(actor.Position.Y, actor.CurrentPosition.Y, "The Y of the actor's CurrentPosition is not correct!");
            Assert.AreEqual(actor.Position.Z, actor.CurrentPosition.Z, "The Z of the actor's CurrentPosition is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test CurrentSize. Check whether CurrentSize returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.CurrentSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task CurrentSize_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.Size2D = new Size2D(100, 100);
            Window.Instance.GetDefaultLayer().Add(actor);
            await Task.Delay(300);
            Assert.AreEqual(100, actor.CurrentSize.Width, "The Width of the actor's CurrentSize is not correct!");
            Assert.AreEqual(100, actor.CurrentSize.Height, "The Height of the actor's CurrentSize is not correct!");
            Window.Instance.GetDefaultLayer().Remove(actor);
        }

        [Test]
        [Category("P1")]
        [Description("Test ID. Check whether ID return the right value.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ID A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ID_GET_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            view.Size2D = new Size2D(200, 200);
            view.BackgroundColor = Color.Red;
            Window.Instance.GetDefaultLayer().Add(view);
            Assert.Greater(view.ID, 0, "Should be greater than zero!");
            Window.Instance.GetDefaultLayer().Remove(view);
        }

        [Test]
        [Category("P1")]
        [Description("Test GetLayer. Check whether GetLayer works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.GetLayer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetLayer_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            view.Size2D = new Size2D(200, 200);
            view.BackgroundColor = Color.Red;
            Window.Instance.GetDefaultLayer().Add(view);
            Layer layer = view.GetLayer();
            Assert.IsNotNull(layer, "The layer of under the view Should be not null!");
            Window.Instance.GetDefaultLayer().Remove(view);
        }

        [Test]
        [Category("P1")]
        [Description("Test DoAction. Check whether DoAction works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.DoAction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void DoAction_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            view.Size2D = new Size2D(200, 200);
            view.BackgroundColor = Color.Red;
            Window.Instance.GetDefaultLayer().Add(view);
            try
            {
                view.DoAction(0, 0, new PropertyValue(0));
                Window.Instance.GetDefaultLayer().Remove(view);
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
        [Description("Test InheritPosition. Check whether InheritPosition is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.InheritPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task InheritPosition_SET_GET_VALUE()
        {
            /* TEST CODE */
            View parentActor = new View();
            parentActor.Size2D = new Size2D(100, 100);
            Position parentPosition = new Position(1.0f, 2.0f, 3.0f);
            parentActor.Position = parentPosition;
            parentActor.PositionUsesPivotPoint = true;
            parentActor.PivotPoint = new Position(0.5f, 0.5f, 0.5f);
            parentActor.ParentOrigin = new Position(0.5f, 0.5f, 0.5f);
            Window.Instance.GetDefaultLayer().Add(parentActor);

            View actor = new View();
            actor.Size2D = new Size2D(100, 100);
            Position position = new Position(10.0f, 11.0f, 12.0f);
            actor.Position = position;
            actor.PositionUsesPivotPoint = true;
            actor.PivotPoint = new Position(0.5f, 0.5f, 0.5f);
            actor.ParentOrigin = new Position(0.5f, 0.5f, 0.5f);
            actor.InheritPosition = true;
            parentActor.Add(actor);

            await Task.Delay(200);
            Assert.GreaterOrEqual(parentActor.WorldPosition.X, 0, "ParentActor's WorldPosition.X is incorrect");
            Assert.GreaterOrEqual(parentActor.WorldPosition.Y, 0, "ParentActor's WorldPosition.Y is incorrect");
            Assert.GreaterOrEqual(parentActor.WorldPosition.Z, 0, "ParentActor's WorldPosition.Z is incorrect");
            Assert.GreaterOrEqual(actor.WorldPosition.X, 0, "ChildActor's WorldPosition.X is incorrect");
            Assert.GreaterOrEqual(actor.WorldPosition.Y, 0, "ChildActor's WorldPosition.Y is incorrect");
            Assert.GreaterOrEqual(actor.WorldPosition.Z, 0, "ChildActor's WorldPosition.Z is incorrect");
            Window.Instance.GetDefaultLayer().Remove(parentActor);
        }

        [Test]
        [Category("P1")]
        [Description("Test VisibilityChanged. Test whether the VisibilityChanged event will be triggered when the visibility of the view has been changed.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.VisibilityChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task VisibilityChanged_CHECK_EVENT()
        {
            View view = new View();
            view.BackgroundColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            view.Size2D = new Size2D(100, 100);
            view.Hide();
            view.VisibilityChanged += viewEventCallback;
            Window.Instance.GetDefaultLayer().Add(view);
            view.Show();
            await Task.Delay(200);
            Assert.IsTrue(_flag, "The VisibilityChanged Event has been triggerred!");
            Window.Instance.GetDefaultLayer().Remove(view);
            view.VisibilityChanged -= viewEventCallback;
        }

        [Test]
        [Category("P1")]
        [Description("Test HasFocus. Check whether the view has the focus.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.HasFocus M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task HasFocus_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            View view = new View();
            view.Focusable = true;
            Window.Instance.GetDefaultLayer().Add(view);
            FocusManager.Instance.SetCurrentFocusView(view);
            await Task.Delay(200);
            Assert.IsTrue(view.HasFocus(), "The view should hold the focus now");
            Window.Instance.GetDefaultLayer().Remove(view);

        }

        [Test]
        [Category("P1")]
        [Description("Test FlexProperty. Check whether the FlexProperty works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.FlexProperty A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void FlexProperty_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual("Flex", View.FlexProperty.PropertyName, "Should be equal to the set value!");
        }

        [Test]
        [Category("P1")]
        [Description("Test FocusGained. Test whether the FocusGained event will be triggered when the view gain the focus.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.FocusGained E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void FocusGained_CHECK_EVENT()
        {
            View view = new View();
            view.Focusable = true;
            Window.Instance.GetDefaultLayer().Add(view);

            view.FocusGained += viewEventCallback;
            FocusManager.Instance.SetCurrentFocusView(view);
            Assert.IsTrue(_flag, "The FocusGained Event not been triggerred!");
            Window.Instance.GetDefaultLayer().Remove(view);
            view.FocusGained -= viewEventCallback;
        }

        [Test]
        [Category("P1")]
        [Description("Test FocusLost. Test whether the FocusLost event will be triggered when the view lost the focus.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.FocusLost E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void FocusLost_CHECK_EVENT()
        {
            View view = new View();
            view.Focusable = true;
            View view2 = new View();
            view2.Focusable = true;
            Window.Instance.GetDefaultLayer().Add(view);
            Window.Instance.GetDefaultLayer().Add(view2);
            view.FocusLost += viewEventCallback;
            FocusManager.Instance.SetCurrentFocusView(view);
            FocusManager.Instance.SetCurrentFocusView(view2);
            Assert.IsTrue(_flag, "The FocusLost Event not been triggerred!");
            Window.Instance.GetDefaultLayer().Remove(view);
            Window.Instance.GetDefaultLayer().Remove(view2);
            view.FocusLost -= viewEventCallback;
        }

        [Test]
        [Category("P1")]
        [Description("Test Relayout. Test whether the Relayout event will be triggered when the view has been removed from the stage.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.Relayout E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Relayout_CHECK_EVENT()
        {
            View view = new View();
            view.HeightResizePolicy = ResizePolicyType.DimensionDependency;

            View parentView = new View();
            parentView.Add(view);
            Window.Instance.GetDefaultLayer().Add(parentView);
            parentView.Size2D = new Size2D(100, 100);
            view.Relayout += viewEventCallback;
            parentView.Size2D = new Size2D(200, 300);
            await Task.Delay(200);
            Assert.IsTrue(_flag, "The OnRelayoutEvent Event has been triggerred!");
            Window.Instance.GetDefaultLayer().Remove(parentView);
            view.Relayout -= viewEventCallback;
        }

        [Test]
        [Category("P1")]
        [Description("Test RemovedFromWindow. Test whether the RemovedFromWindow event will be triggered when the view has been removed from the window.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.RemovedFromWindow E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task RemovedFromWindow_CHECK_EVENT()
        {
            View view = new View();
            view.Size2D = new Size2D(200, 200);
            view.BackgroundColor = Color.Red;
            Window.Instance.GetDefaultLayer().Add(view);
            view.RemovedFromWindow += viewEventCallback;
            Window.Instance.GetDefaultLayer().Remove(view);
            await Task.Delay(20);
            Assert.IsTrue(_flag, "The OffStageEvent Event has been triggerred!");
            Window.Instance.GetDefaultLayer().Remove(view);
            view.RemovedFromWindow -= viewEventCallback;
        }

        [Test]
        [Category("P1")]
        [Description("Test ResourcesLoaded, Check whether ResourcesLoaded works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ResourcesLoaded E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task ResourcesLoaded_CHECK_EVENT()
        {
            /* TEST CODE */
            ImageView view = new ImageView(_imagePath);
            view.ResourcesLoaded += viewEventCallback;
            view.Size2D = new Size2D(100, 100);
            //view.ResourceUrl = image_path;
            Window.Instance.GetDefaultLayer().Add(view);
            Tizen.Log.Debug(TAG, "ResourceUrl=" + _imagePath);
            await Task.Delay(500);
            Assert.IsTrue(_flag, "ResourcesLoaded does not work!");
            Window.Instance.GetDefaultLayer().Remove(view);
            view.ResourcesLoaded -= viewEventCallback;
        }

        [Test]
        [Category("P1")]
        [Description("Test LayoutDirectionChanged. Test whether the LayoutDirectionChanged event will be triggered when the view has been add to the window.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.LayoutDirectionChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task LayoutDirectionChanged_CHECK_EVENT()
        {
            View view = new View();
            view.Name = "View";
            view.LayoutDirection = ViewLayoutDirectionType.RTL;
            view.LayoutDirectionChanged += viewEventCallback;
            Window.Instance.GetDefaultLayer().Add(view);

            view.LayoutDirection = ViewLayoutDirectionType.LTR;
            await Task.Delay(20);
            Assert.IsTrue(_flag, "The LayoutDirectionChanged Event has been triggerred!");
            Window.Instance.GetDefaultLayer().Remove(view);
            view.LayoutDirectionChanged -= viewEventCallback;
        }

        [Test]
        [Category("P1")]
        [Description("Test ChildAdded. Test whether the ChildAdded event will be triggered when the view has been add to the window.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ChildAdded E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public async Task ChildAdded_CHECK_EVENT()
        {
            View childActor = new View();
            View parentActor = new View();
            parentActor.ChildAdded += viewEventCallback;
            Window.Instance.GetDefaultLayer().Add(childActor);
            Window.Instance.GetDefaultLayer().Add(parentActor);
            parentActor.Add(childActor);
            await Task.Delay(20);
            Assert.IsTrue(_flag, "Should be true!");
            Window.Instance.GetDefaultLayer().Remove(childActor);
            Window.Instance.GetDefaultLayer().Remove(parentActor);
            parentActor.ChildAdded -= viewEventCallback;
        }

        [Test]
        [Category("P1")]
        [Description("Test ChildRemoved. Test whether the ChildRemoved event will be triggered when the view has been add to the window.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ChildRemoved E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public async Task ChildRemoved_CHECK_EVENT()
        {
            View childActor = new View();
            View parentActor = new View();
            parentActor.ChildRemoved += viewEventCallback;
            parentActor.Add(childActor);
            await Task.Delay(20);
            parentActor.Remove(childActor);
            await Task.Delay(20);
            Assert.IsTrue(_flag, "Should be true!");
            parentActor.ChildRemoved -= viewEventCallback;
        }
    }
}
