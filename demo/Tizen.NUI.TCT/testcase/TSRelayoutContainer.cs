using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.RelayoutContainer Tests")]
    public class RelayoutContainerTests
    {
        private static string TAG = "NUI";
        private static bool _flagAdd;
        internal class MyView : CustomView
        {
            View view;
            static CustomView CreateInstance()
            {
                return new MyView();
            }
            static MyView()
            {
                CustomViewRegistry.Instance.Register(CreateInstance, typeof(MyView));
            }

            public MyView() : base(typeof(MyView).FullName, CustomViewBehaviour.ViewBehaviourDefault)
            {
            }

            public MyView(string typeName, CustomViewBehaviour behaviour) : base(typeName, behaviour)
            {
            }

            public override void OnInitialize()
            {
                view = new BaseComponents.View();
                view.Size2D = new Size2D(200, 200);
                view.BackgroundColor = Color.Red;
                this.Add(view);
            }

            public override Size2D GetNaturalSize()
            {
                return new Size2D(200, 200);
            }

            public override void OnRelayout(Vector2 size, RelayoutContainer container)
            {
                View view = new View();
                view.Size2D = new Size2D(100, 100);
                container.Add(view, new Size2D(100, 100));
                _flagAdd = true;
                base.OnRelayout(size, container);
            }

            public void AddVisual(PropertyMap propertyMap)
            {
                int visualIndex = RegisterProperty("MyVisual", new PropertyValue("MyVisual"), PropertyAccessMode.ReadWrite);
                if (visualIndex > 0)
                {
                    VisualBase visual = VisualFactory.Instance.CreateVisual(propertyMap); // Create a visual for the new one.
                    RegisterVisual(visualIndex, visual);

                    RelayoutRequest();
                }
            }
        }

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("RelayoutContainerTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Add check whether works ok or not.")]
        [Property("SPEC", "Tizen.NUI.RelayoutContainer.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public async Task Add_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            MyView myView = new MyView();
            Assert.IsInstanceOf<MyView>(myView, "Should be an instance of MyView2 type.");
            Window.Instance.Add(myView);
            try
            {
                _flagAdd = false;
                Assert.False(_flagAdd, "Should be false");
                PropertyMap propertyMap = new PropertyMap();
                propertyMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Color));
                propertyMap.Add(ColorVisualProperty.MixColor, new PropertyValue(Color.Blue));
                myView.AddVisual(propertyMap);
                await Task.Delay(1000);
                Assert.True(_flagAdd, "Should be true");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            finally
            {
                Window.Instance.Remove(myView);
            }
        }
    }
}