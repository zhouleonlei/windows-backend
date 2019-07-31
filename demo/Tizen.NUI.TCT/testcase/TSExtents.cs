using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.Extents Tests")]
    public class ExtentsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ExtentsTests");
            App.MainTitleChangeBackgroundColor(null);

        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali Extents constructor test.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Extents.Extents C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Extents_INIT()
        {
            /* TEST CODE */
            var extents = new Extents();
            Assert.IsInstanceOf<Extents>(extents, "Should return Extents instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali Extents constructor test.Check whether object which initialized with four singles is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Extents.Extents C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "UInt16, UInt16, UInt16, UInt16")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Extents_INIT_WITH_INT_INT_INT_INT()
        {
            /* TEST CODE */
            var extents = new Extents(1, 2, 3, 4);
            Assert.IsInstanceOf<Extents>(extents, "Should return Extents instance.");
            Assert.AreEqual(1, extents.Start, "Retrieved extents.Start should be equal to set value");
            Assert.AreEqual(2, extents.End, "Retrieved extents.End should be equal to set value");
            Assert.AreEqual(3, extents.Top, "Retrieved extents.Top should be equal to set value");
            Assert.AreEqual(4, extents.Bottom, "Retrieved extents.Bottom should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("dali Extents constructor test.Check whether object which initialized with Extents instance is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Extents.Extents C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Extents")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Extents_INIT_EXTENTS()
        {
            /* TEST CODE */
            var extents1 = new Extents(1, 2, 3, 4);
            var extents = new Extents(extents1);
            Assert.IsInstanceOf<Extents>(extents, "Should return Extents instance.");
            Assert.AreEqual(1, extents.Start, "Retrieved extents.Start should be equal to set value");
            Assert.AreEqual(2, extents.End, "Retrieved extents.End should be equal to set value");
            Assert.AreEqual(3, extents.Top, "Retrieved extents.Top should be equal to set value");
            Assert.AreEqual(4, extents.Bottom, "Retrieved extents.Bottom should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test EqualTo. Try to compare two Extents instance by EqualTo.")]
        [Property("SPEC", "Tizen.NUI.Extents.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void EqualTo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Extents extents1 = new Extents(1, 2, 3, 4);
            Extents extents2 = extents1;
            Assert.IsTrue((extents1.EqualTo(extents2)), "Should be equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test NotEqualTo. Try to compare two Extents instance by NotEqualTo.")]
        [Property("SPEC", "Tizen.NUI.Extents.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void NotEqualTo_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Extents extents1 = new Extents(1, 2, 3, 4);
            Extents extents2 = new Extents(2, 3, 4, 5);
            Assert.IsTrue((extents1.NotEqualTo(extents2)), "Should be not equal");
        }

        [Test]
        [Category("P1")]
        [Description("Test Start. Check whether Start is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Extents.Start A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Start_SET_GET_VALUE()
        {
            /* TEST CODE */
            Extents extents = new Extents(1, 2, 3, 4);
            Assert.AreEqual(1, extents.Start, "extents.Start should be equal to the set value!");
            extents.Start = 5;
            Assert.AreEqual(5, extents.Start, "extents.Start should be equal to the set value!");
        }

        [Test]
        [Category("P1")]
        [Description("Test End. Check whether End is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Extents.End A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void End_SET_GET_VALUE()
        {
            /* TEST CODE */
            Extents extents = new Extents(1, 2, 3, 4);
            Assert.AreEqual(2, extents.End, "extents.End should be equal to the set value!");
            extents.End = 5;
            Assert.AreEqual(5, extents.End, "extents.End should be equal to the set value!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Top. Check whether Top is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Extents.Top A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Top_SET_GET_VALUE()
        {
            /* TEST CODE */
            Extents extents = new Extents(1, 2, 3, 4);
            Assert.AreEqual(3, extents.Top, "extents.Top should be equal to the set value!");
            extents.Top = 5;
            Assert.AreEqual(5, extents.Top, "extents.Top should be equal to the set value!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Bottom. Check whether Bottom is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Extents.Bottom A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Bottom_SET_GET_VALUE()
        {
            /* TEST CODE */
            Extents extents = new Extents(1, 2, 3, 4);
            Assert.AreEqual(4, extents.Bottom, "extents.Bottom should be equal to the set value!");
            extents.Bottom = 5;
            Assert.AreEqual(5, extents.Bottom, "extents.Bottom should be equal to the set value!");
        }

    }
}
