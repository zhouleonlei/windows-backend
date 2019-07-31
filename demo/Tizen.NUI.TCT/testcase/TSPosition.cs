using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using System.Runtime.InteropServices;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.Position Tests")]
    public class PositionTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("PositionTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali Position constructor test")]
        [Property("SPEC", "Tizen.NUI.Position.Position C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Position_INIT()
        {
            /* TEST CODE */
            var position = new Position();
            Assert.IsInstanceOf<Position>(position, "Should return Position instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali Position constructor test, with three float value")]
        [Property("SPEC", "Tizen.NUI.Position.Position C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single, Single, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Position_INIT_WITH_FLOAT_FLOAT_FLOAT()
        {
            /* TEST CODE */
            var position = new Position(0.5f, 0.5f, 0.5f);
            Assert.IsInstanceOf<Position>(position, "Should return Position instance.");
            Assert.AreEqual(0.5f, position.X, "The X property of position is not correct here.");
            Assert.AreEqual(0.5f, position.Y, "The Y property of position is not correct here.");
            Assert.AreEqual(0.5f, position.Z, "The Z property of position is not correct here.");

        }

        [Test]
        [Category("P1")]
        [Description("dali Position constructor test, with a Position2D instance.")]
        [Property("SPEC", "Tizen.NUI.Position.Position C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Position2D")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Position_INIT_WITH_Position2D()
        {
            /* TEST CODE */
            Position2D position2D = new Position2D(50, 50);
            var position = new Position(position2D);
            Assert.IsInstanceOf<Position>(position, "Should return Position instance.");
            Assert.AreEqual(50.0f, position.X, "The X property of position is not correct here.");
            Assert.AreEqual(50.0f, position.Y, "The Y property of position is not correct here.");
            Assert.AreEqual(0.0f, position.Z, "The Z property of position is not correct here.");

        }

        [Test]
        [Category("P1")]
        [Description("Test X. Check whether X is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Position.X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void X_SET_GET_VALUE()
        {
            /* TEST CODE */
            Position position = new Position(0.5f, 0.5f, 0.5f);

            Assert.AreEqual(0.5f, position.X, "The X property of position is not correct here.");

            position.X = 0.4f;
            Assert.AreEqual(0.4f, position.X, "The X property of position is not correct.");
        }
        [Test]
        [Category("P1")]
        [Description("Test Y. Check whether Y is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Position.Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Y_SET_GET_VALUE()
        {
            /* TEST CODE */
            Position position = new Position(0.5f, 0.5f, 0.5f);

            Assert.AreEqual(0.5f, position.Y, "The Y property of position is not correct here.");

            position.Y = 0.4f;
            Assert.AreEqual(0.4f, position.Y, "The Y property of position is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Z. Check whether Z is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Position.Z A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Z_SET_GET_VALUE()
        {
            /* TEST CODE */
            Position position = new Position(0.5f, 0.5f, 0.5f);
            Assert.AreEqual(0.5f, position.Z, "The Z property of position is not correct here.");

            position.Z = 0.4f;
            Assert.AreEqual(0.4f, position.Z, "The Z property of position is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ParentOriginTop. Check whether ParentOriginTop returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginTop A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ParentOriginTop_GET_VALUE()
        {
            /* TEST CODE */
            float parentOriginTop = Position.ParentOriginTop;
            Assert.AreEqual(0.0f, parentOriginTop, "The value of ParentOriginTop is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ParentOriginBottom. Check whether ParentOriginBottom returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginBottom A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ParentOriginBottom_GET_VALUE()
        {
            /* TEST CODE */
            float parentOriginBottom = Position.ParentOriginBottom;
            Assert.AreEqual(1.0f, parentOriginBottom, "The value of ParentOriginBottom is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ParentOriginLeft. Check whether ParentOriginLeft returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ParentOriginLeft_GET_VALUE()
        {
            /* TEST CODE */
            float parentOriginLeft = Position.ParentOriginLeft;
            Assert.AreEqual(0.0f, parentOriginLeft, "The value of ParentOriginLeft is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ParentOriginRight. Check whether ParentOriginRight returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ParentOriginRight_GET_VALUE()
        {
            /* TEST CODE */
            float parentOriginRight = Position.ParentOriginRight;
            Assert.AreEqual(1.0f, parentOriginRight, "The value of ParentOriginRight is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ParentOriginMiddle. Check whether ParentOriginMiddle returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginMiddle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ParentOriginMiddle_GET_VALUE()
        {
            /* TEST CODE */
            float parentOriginMiddle = Position.ParentOriginMiddle;
            Assert.AreEqual(0.5f, parentOriginMiddle, "The value of ParentOriginMiddle is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ParentOriginTopLeft. Check whether ParentOriginTopLeft returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginTopLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ParentOriginTopLeft_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Position.ParentOriginTopLeft.X, "The value of Position.ParentOriginTopLeft.X is not correct.");
            Assert.AreEqual(0.0f, Position.ParentOriginTopLeft.Y, "The value of Position.ParentOriginTopLeft.Y is not correct.");
            Assert.AreEqual(0.5f, Position.ParentOriginTopLeft.Z, "The value of Position.ParentOriginTopLeft.X is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ParentOriginTopCenter. Check whether ParentOriginTopCenter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginTopCenter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ParentOriginTopCenter_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.5f, Position.ParentOriginTopCenter.X, "The value of Position.ParentOriginTopCenter.X is not correct.");
            Assert.AreEqual(0.0f, Position.ParentOriginTopCenter.Y, "The value of Position.ParentOriginTopCenter.Y is not correct.");
            Assert.AreEqual(0.5f, Position.ParentOriginTopCenter.Z, "The value of Position.ParentOriginTopCenter.Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ParentOriginTopRight. Check whether ParentOriginTopRight returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginTopRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ParentOriginTopRight_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(1.0f, Position.ParentOriginTopRight.X, "The value of Position.ParentOriginTopRight.X is not correct.");
            Assert.AreEqual(0.0f, Position.ParentOriginTopRight.Y, "The value of Position.ParentOriginTopRight.Y is not correct.");
            Assert.AreEqual(0.5f, Position.ParentOriginTopRight.Z, "The value of Position.ParentOriginTopRight.Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ParentOriginCenterLeft. Check whether ParentOriginCenterLeft returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginCenterLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ParentOriginCenterLeft_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Position.ParentOriginCenterLeft.X, "The value of Position.ParentOriginCenterLeft.X is not correct.");
            Assert.AreEqual(0.5f, Position.ParentOriginCenterLeft.Y, "The value of Position.ParentOriginCenterLeft.Y is not correct.");
            Assert.AreEqual(0.5f, Position.ParentOriginCenterLeft.Z, "The value of Position.ParentOriginCenterLeft.Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ParentOriginCenter. Check whether ParentOriginCenter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginCenter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ParentOriginCenter_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.5f, Position.ParentOriginCenter.X, "The value of Position.ParentOriginCenter.X is not correct.");
            Assert.AreEqual(0.5f, Position.ParentOriginCenter.Y, "The value of Position.ParentOriginCenter.Y is not correct.");
            Assert.AreEqual(0.5f, Position.ParentOriginCenter.Z, "The value of Position.ParentOriginCenter.Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ParentOriginCenterRight. Check whether ParentOriginCenterRight returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginCenterRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ParentOriginCenterRight_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(1.0f, Position.ParentOriginCenterRight.X, "The value of Position.ParentOriginCenterRight.X is not correct.");
            Assert.AreEqual(0.5f, Position.ParentOriginCenterRight.Y, "The value of Position.ParentOriginCenterRight.Y is not correct.");
            Assert.AreEqual(0.5f, Position.ParentOriginCenterRight.Z, "The value of Position.ParentOriginCenterRight.Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ParentOriginBottomLeft. Check whether ParentOriginBottomLeft returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginBottomLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ParentOriginBottomLeft_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Position.ParentOriginBottomLeft.X, "The value of Position.ParentOriginBottomLeft.X is not correct.");
            Assert.AreEqual(1.0f, Position.ParentOriginBottomLeft.Y, "The value of Position.ParentOriginBottomLeft.Y is not correct.");
            Assert.AreEqual(0.5f, Position.ParentOriginBottomLeft.Z, "The value of Position.ParentOriginBottomLeft.Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ParentOriginBottomCenter. Check whether ParentOriginBottomCenter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginBottomCenter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ParentOriginBottomCenter_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.5f, Position.ParentOriginBottomCenter.X, "The value of Position.ParentOriginBottomCenter.X is not correct.");
            Assert.AreEqual(1.0f, Position.ParentOriginBottomCenter.Y, "The value of Position.ParentOriginBottomCenter.Y is not correct.");
            Assert.AreEqual(0.5f, Position.ParentOriginBottomCenter.Z, "The value of Position.ParentOriginBottomCenter.Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ParentOriginBottomRight. Check whether ParentOriginBottomRight returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginBottomRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ParentOriginBottomRight_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(1.0f, Position.ParentOriginBottomRight.X, "The value of Position.ParentOriginBottomRight.X is not correct.");
            Assert.AreEqual(1.0f, Position.ParentOriginBottomRight.Y, "The value of Position.ParentOriginBottomRight.Y is not correct.");
            Assert.AreEqual(0.5f, Position.ParentOriginBottomRight.Z, "The value of Position.ParentOriginBottomRight.Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test PivotPointTop. Check whether PivotPointTop returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointTop A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PivotPointTop_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Position.PivotPointTop, "The value of Position.PivotPointTop is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test PivotPointBottom. Check whether PivotPointBottom returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointBottom A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PivotPointBottom_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(1.0f, Position.PivotPointBottom, "The value of Position.PivotPointBottom is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test PivotPointLeft. Check whether PivotPointLeft returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PivotPointLeft_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Position.PivotPointLeft, "The value of Position.PivotPointLeft is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test PivotPointRight. Check whether PivotPointRight returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PivotPointRight_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(1.0f, Position.PivotPointRight, "The value of Position.PivotPointRight is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test PivotPointMiddle. Check whether PivotPointMiddle returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointMiddle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PivotPointMiddle_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.5f, Position.PivotPointMiddle);
        }

        [Test]
        [Category("P1")]
        [Description("Test PivotPointTopLeft. Check whether PivotPointTopLeft returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointTopLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PivotPointTopLeft_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Position.PivotPointTopLeft.X, "The value of Position.PivotPointTopLeft.X is not correct.");
            Assert.AreEqual(0.0f, Position.PivotPointTopLeft.Y, "The value of Position.PivotPointTopLeft.Y is not correct.");
            Assert.AreEqual(0.5f, Position.PivotPointTopLeft.Z, "The value of Position.PivotPointTopLeft.Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test PivotPointTopCenter. Check whether PivotPointTopCenter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointTopCenter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PivotPointTopCenter_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.5f, Position.PivotPointTopCenter.X, "The value of Position.PivotPointTopCenter.X is not correct.");
            Assert.AreEqual(0.0f, Position.PivotPointTopCenter.Y, "The value of Position.PivotPointTopCenter.Y is not correct.");
            Assert.AreEqual(0.5f, Position.PivotPointTopCenter.Z, "The value of Position.PivotPointTopCenter.Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test PivotPointTopRight. Check whether PivotPointTopRight returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointTopRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PivotPointTopRight_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(1.0f, Position.PivotPointTopRight.X, "The value of Position.PivotPointTopRight.X is not correct.");
            Assert.AreEqual(0.0f, Position.PivotPointTopRight.Y, "The value of Position.PivotPointTopRight.Y is not correct.");
            Assert.AreEqual(0.5f, Position.PivotPointTopRight.Z, "The value of Position.PivotPointTopRight.Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test PivotPointCenterLeft. Check whether PivotPointCenterLeft returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointCenterLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PivotPointCenterLeft_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Position.PivotPointCenterLeft.X, "The value of Position.PivotPointCenterLeft.X is not correct.");
            Assert.AreEqual(0.5f, Position.PivotPointCenterLeft.Y, "The value of Position.PivotPointCenterLeft.Y is not correct.");
            Assert.AreEqual(0.5f, Position.PivotPointCenterLeft.Z, "The value of Position.PivotPointCenterLeft.Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test PivotPointCenter. Check whether PivotPointCenter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointCenter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PivotPointCenter_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.5f, Position.PivotPointCenter.X, "The value of Position.PivotPointCenter.X is not correct.");
            Assert.AreEqual(0.5f, Position.PivotPointCenter.Y, "The value of Position.PivotPointCenter.Y is not correct.");
            Assert.AreEqual(0.5f, Position.PivotPointCenter.Z, "The value of Position.PivotPointCenter.Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test PivotPointCenterRight. Check whether PivotPointCenterRight returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointCenterRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PivotPointCenterRight_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(1.0f, Position.PivotPointCenterRight.X, "The value of Position.PivotPointCenterRight.X is not correct.");
            Assert.AreEqual(0.5f, Position.PivotPointCenterRight.Y, "The value of Position.PivotPointCenterRight.Y is not correct.");
            Assert.AreEqual(0.5f, Position.PivotPointCenterRight.Z, "The value of Position.PivotPointCenterRight.Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test PivotPointBottomLeft. Check whether PivotPointBottomLeft returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointBottomLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PivotPointBottomLeft_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Position.PivotPointBottomLeft.X, "The value of Position.PivotPointBottomLeft.X is not correct.");
            Assert.AreEqual(1.0f, Position.PivotPointBottomLeft.Y, "The value of Position.PivotPointBottomLeft.Y is not correct.");
            Assert.AreEqual(0.5f, Position.PivotPointBottomLeft.Z, "The value of Position.PivotPointBottomLeft.Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test PivotPointBottomCenter. Check whether PivotPointBottomCenter returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointBottomCenter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PivotPointBottomCenter_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.5f, Position.PivotPointBottomCenter.X, "The value of Position.PivotPointBottomCenter.X is not correct.");
            Assert.AreEqual(1.0f, Position.PivotPointBottomCenter.Y, "The value of Position.PivotPointBottomCenter.Y is not correct.");
            Assert.AreEqual(0.5f, Position.PivotPointBottomCenter.Z, "The value of Position.PivotPointBottomCenter.Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test PivotPointBottomRight. Check whether PivotPointBottomRight returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointBottomRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PivotPointBottomRight_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(1.0f, Position.PivotPointBottomRight.X, "The value of Position.PivotPointBottomRight.X is not correct.");
            Assert.AreEqual(1.0f, Position.PivotPointBottomRight.Y, "The value of Position.PivotPointBottomRight.Y is not correct.");
            Assert.AreEqual(0.5f, Position.PivotPointBottomRight.Z, "The value of Position.PivotPointBottomRight.Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test this[uint index]. Check whether this[uint index] returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void this_GET_VALUE()
        {
            /* TEST CODE */
            Position position = new Position(100.0f, 200.0f, 300.0f);
            Assert.AreEqual(100.0f, position[0], "The value of index[0] is not correct!");
            Assert.AreEqual(200.0f, position[1], "The value of index[1] is not correct!");
            Assert.AreEqual(300.0f, position[2], "The value of index[2] is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test One. Check whether One returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.One A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void One_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(1.0f, Position.One.X, "The value of Position.One.X is not correct!");
            Assert.AreEqual(1.0f, Position.One.Y, "The value of Position.One.Y is not correct!");
            Assert.AreEqual(1.0f, Position.One.Z, "The value of Position.One.Z is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Zero. Check whether Zero returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.Zero A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Zero_GET_VALUE()
        {
            /* TEST CODE */
            Assert.AreEqual(0.0f, Position.Zero.X, "The value of Position.Zero.X is not correct!");
            Assert.AreEqual(0.0f, Position.Zero.Y, "The value of Position.Zero.Y is not correct!");
            Assert.AreEqual(0.0f, Position.Zero.Z, "The value of Position.Zero.Z is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test EqualTo. Try to compare two Position instance by EqualTo.")]
        [Property("SPEC", "Tizen.NUI.Position.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void EqualTo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position position1 = new Position(1.0f, 2.0f, 3.0f);
            Position position2 = new Position(1.0f, 2.0f, 3.0f);
            Assert.IsTrue((position1.EqualTo(position2)), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test NotEqualTo. Try to compare two Position instance by NotEqualTo.")]
        [Property("SPEC", "Tizen.NUI.Position.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void NotEqualTo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position position1 = new Position(10.0f, 20.0f, 30.0f);
            Position position2 = new Position(1.0f, 2.0f, 3.0f);
            Assert.IsTrue((position1.NotEqualTo(position2)), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator +.")]
        [Property("SPEC", "Tizen.NUI.Position.Addition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Addition_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position position1 = new Position(10.0f, 20.0f, 30.0f);
            Position position2 = new Position(1.0f, 2.0f, 3.0f);
            Position position = position1 + position2;
            Assert.AreEqual(11.0f, position.X, "The X value of the vector is not correct!");
            Assert.AreEqual(22.0f, position.Y, "The Y value of the vector is not correct!");
            Assert.AreEqual(33.0f, position.Z, "The Z value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator -.")]
        [Property("SPEC", "Tizen.NUI.Position.Subtraction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Subtraction_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position position1 = new Position(10.0f, 20.0f, 30.0f);
            Position position2 = new Position(1.0f, 2.0f, 3.0f);
            Position position = position1 - position2;
            Assert.AreEqual(9.0f, position.X, "The X value of the vector is not correct!");
            Assert.AreEqual(18.0f, position.Y, "The Y value of the vector is not correct!");
            Assert.AreEqual(27.0f, position.Z, "The Z value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator -.")]
        [Property("SPEC", "Tizen.NUI.Position.UnaryNegation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void UnaryNegation_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position position1 = new Position(10.0f, 20.0f, 30.0f);
            Position position = -position1;
            Assert.AreEqual(-10.0f, position.X, "The X value of the vector is not correct!");
            Assert.AreEqual(-20.0f, position.Y, "The Y value of the vector is not correct!");
            Assert.AreEqual(-30.0f, position.Z, "The Z value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator *.")]
        [Property("SPEC", "Tizen.NUI.Position.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Position, Position")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Multiply_Position_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position position1 = new Position(10.0f, 20.0f, 30.0f);
            Position position2 = new Position(1.0f, 2.0f, 3.0f);
            Position position = position1 * position2;
            Assert.AreEqual(10.0f, position.X, "The X value of the vector is not correct!");
            Assert.AreEqual(40.0f, position.Y, "The Y value of the vector is not correct!");
            Assert.AreEqual(90.0f, position.Z, "The Z value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator *.")]
        [Property("SPEC", "Tizen.NUI.Position.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Position, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Multiply_FLOAT_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position position1 = new Position(10.0f, 20.0f, 30.0f);
            Position position = position1 * 2.0f;
            Assert.AreEqual(20.0f, position.X, "The X value of the vector is not correct!");
            Assert.AreEqual(40.0f, position.Y, "The Y value of the vector is not correct!");
            Assert.AreEqual(60.0f, position.Z, "The Z value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator /.")]
        [Property("SPEC", "Tizen.NUI.Position.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Position, Position")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Division_Position_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position position1 = new Position(10.0f, 20.0f, 30.0f);
            Position position2 = new Position(1.0f, 2.0f, 3.0f);
            Position position = position1 / position2;
            Assert.AreEqual(10.0f, position.X, "The X value of the vector is not correct!");
            Assert.AreEqual(10.0f, position.Y, "The Y value of the vector is not correct!");
            Assert.AreEqual(10.0f, position.Z, "The Z value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test operator /.")]
        [Property("SPEC", "Tizen.NUI.Position.Division M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Position, Single")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Division_FLOAT_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position position1 = new Position(10.0f, 20.0f, 30.0f);
            Position position = position1 / 10;
            Assert.AreEqual(1.0f, position.X, "The X value of the vector is not correct!");
            Assert.AreEqual(2.0f, position.Y, "The Y value of the vector is not correct!");
            Assert.AreEqual(3.0f, position.Z, "The Z value of the vector is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Equals. Check whether Equals returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Equals_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position position1 = new Position(1.0f, 1.0f, 1.0f);
            Position position2 = new Position(1.0f, 1.0f, 1.0f);

            bool flag = position1.Equals(position2);
            Assert.IsTrue(flag, "Should be true here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test implicit vector3. Try to convert a vector3 instance to a position instance.")]
        [Property("SPEC", "Tizen.NUI.Position.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector3")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void implicit_VECTOR3_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector3 vector = new Vector3(10.0f, 20.0f, 30.0f);
            Position position = vector;
            Assert.AreEqual(position.X, vector.X, "The value of X is not correct.");
            Assert.AreEqual(position.Y, vector.Y, "The value of Y is not correct.");
            Assert.AreEqual(position.Z, vector.Z, "The value of Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test implicit position. Try to convert a position instance to a vector3 instance.")]
        [Property("SPEC", "Tizen.NUI.Position.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Position")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void implicit_POSITION_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position position = new Position(10.0f, 20.0f, 30.0f);
            Vector3 vector = position;
            Assert.AreEqual(position.X, vector.X, "The value of X is not correct.");
            Assert.AreEqual(position.Y, vector.Y, "The value of Y is not correct.");
            Assert.AreEqual(position.Z, vector.Z, "The value of Z is not correct.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetHashCode. Check whether GetHashCode returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Position.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void GetHashCode_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var position = new Position(10.0f, 20.0f, 30.0f);
            var hash = position.GetHashCode();
            Assert.IsNotNull(position, "Can't create success object Position");
            Assert.IsInstanceOf<Position>(position, "Should be an instance of Position type.");
            Assert.IsTrue(hash >= Int32.MinValue && hash <= Int32.MaxValue, "The value of hash is out of Integer range");
        }
    }
}
