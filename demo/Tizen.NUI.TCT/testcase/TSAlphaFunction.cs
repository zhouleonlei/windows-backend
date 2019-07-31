using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.AlphaFunction Tests")]
    public class AlphaFunctionTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("AlphaFunctionTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        private delegate int MethodDelegate(int x, int y);
        private int Add(int x, int y)
        {
            return x + y;
        }

        [Test]
        [Category("P1")]
        [Description("dali alphaFunction constructor test")]
        [Property("SPEC", "Tizen.NUI.AlphaFunction.AlphaFunction C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AlphaFunction_INIT()
        {
            /* TEST CODE */
            var alphaFunction = new AlphaFunction();
            Assert.IsInstanceOf<AlphaFunction>(alphaFunction, "Should return AlphaFunction instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali alphaFunction constructor test, Create an AlphaFunction with BuiltinFunctions.")]
        [Property("SPEC", "Tizen.NUI.AlphaFunction.AlphaFunction C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "BuiltinFunctions")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AlphaFunction_INIT_BUILTINFUNCTIONS()
        {
            /* TEST CODE */
            var alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseIn);
            Assert.IsInstanceOf<AlphaFunction>(alphaFunction, "Should return AlphaFunction instance.");
            Assert.AreEqual(AlphaFunction.BuiltinFunctions.EaseIn, alphaFunction.GetBuiltinFunction(), "The BuiltinFunctions type should be BuiltinFunctions.EaseIn!");
        }

        [Test]
        [Category("P1")]
        [Description("dali alphaFunction constructor test, create an AlphaFunction with two Vector2 instances.")]
        [Property("SPEC", "Tizen.NUI.AlphaFunction.AlphaFunction C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Vector2, Vector2")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AlphaFunction_INIT_WITH_VECTOR2_VECTOR2()
        {
            /* TEST CODE */
            Vector2 controlPoint0 = new Vector2(0.0f, 1.0f);
            Vector2 controlPoint1 = new Vector2(1.0f, 0.0f);
            var alphaFunction = new AlphaFunction(controlPoint0, controlPoint1);
            Assert.IsInstanceOf<AlphaFunction>(alphaFunction, "Should return AlphaFunction instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali alphaFunction constructor test, create an AlphaFunction with System.Delegate.")]
        [Property("SPEC", "Tizen.NUI.AlphaFunction.AlphaFunction C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "System.Delegate")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AlphaFunction_INIT_WITH_DELEGATE()
        {
            /* TEST CODE */
            MethodDelegate method = new MethodDelegate(Add);
            var alphaFunction = new AlphaFunction(method);
            Assert.IsInstanceOf<AlphaFunction>(alphaFunction, "Should return AlphaFunction instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali alphaFunction.GetBezierControlPoints test, check wehther it return the right value.")]
        [Property("SPEC", "Tizen.NUI.AlphaFunction.GetBezierControlPoints M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetBezierControlPoints_GET_VALUE()
        {
            /* TEST CODE */
            Vector2 controlPoint0 = new Vector2(0.0f, 1.0f);
            Vector2 controlPoint1 = new Vector2(1.0f, 0.0f);
            AlphaFunction alphaFunction = new AlphaFunction(controlPoint0, controlPoint1);

            Vector2 con1 = new Vector2();
            Vector2 con2 = new Vector2();
            alphaFunction.GetBezierControlPoints(out con1, out con2);
            Assert.AreEqual(controlPoint0.X, con1.X, "The controlPoint1.X is not correct.");
            Assert.AreEqual(controlPoint0.Y, con1.Y, "The controlPoint1.Y is not correct.");
            Assert.AreEqual(controlPoint1.X, con2.X, "The controlPoint2.X is not correct.");
            Assert.AreEqual(controlPoint1.Y, con2.Y, "The controlPoint2.Y is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("dali alphaFunction.GetBuiltinFunction test, check wehther it return the right value.")]
        [Property("SPEC", "Tizen.NUI.AlphaFunction.GetBuiltinFunction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetBuiltinFunction_GET_VALUE()
        {
            /* TEST CODE */
            AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseIn);
            Assert.AreEqual(AlphaFunction.BuiltinFunctions.EaseIn, alphaFunction.GetBuiltinFunction(), "The BuiltinFunctions type is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("dali alphaFunction.GetMode test, check wehther it return the right value.")]
        [Property("SPEC", "Tizen.NUI.AlphaFunction.GetMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetMode_GET_VALUE()
        {
            /* TEST CODE */
            Vector2 controlPoint0 = new Vector2(0.0f, 1.0f);
            Vector2 controlPoint1 = new Vector2(1.0f, 0.0f);
            AlphaFunction alphaFunction = new AlphaFunction(controlPoint0, controlPoint1);
            Assert.AreEqual(AlphaFunction.Modes.Bezier, alphaFunction.GetMode(), "The Mode type is not correct.");
        }
    }
}
