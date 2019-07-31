using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.Path Tests")]
    public class PathTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("PathTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali path constructor test, create a Path instance.")]
        [Property("SPEC", "Tizen.NUI.Path.Path C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Path_INIT()
        {
            /* TEST CODE */
            var path = new Path();
            Assert.IsInstanceOf<Path>(path, "Should return Path instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali path AddPoint test, Add some points to path.")]
        [Property("SPEC", "Tizen.NUI.Path.AddPoint M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AddPoint_SET_VALUE()
        {
            /* TEST CODE */
            try
            {
                Position position0 = new Position(30.0f, 80.0f, 0.0f);
                Position position1 = new Position(70.0f, 120.0f, 0.0f);
                Position position2 = new Position(100.0f, 100.0f, 0.0f);

                Path path = new Path();
                path.AddPoint(position0);
                path.AddPoint(position1);
                path.AddPoint(position2);

                Assert.AreEqual(30.0f, path.GetPoint(0).X, "The point0.X is not correct here.");
                Assert.AreEqual(120.0f, path.GetPoint(1).Y, "The point1.Y is not correct here.");
                Assert.AreEqual(0.0f, path.GetPoint(2).Z, "The point2.Z is not correct here.");
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
        [Description("dali path GetPoint test, check whether return the right vlaue")]
        [Property("SPEC", "Tizen.NUI.Path.GetPoint M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetPoint_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position position0 = new Position(30.0f, 80.0f, 0.0f);
            Position position1 = new Position(70.0f, 120.0f, 0.0f);
            Position position2 = new Position(100.0f, 100.0f, 0.0f);

            Path path = new Path();
            path.AddPoint(position0);
            path.AddPoint(position1);
            path.AddPoint(position2);

            Assert.AreEqual(30.0f, path.GetPoint(0).X, "The point0.X is not correct here.");
            Assert.AreEqual(120.0f, path.GetPoint(1).Y, "The point1.Y is not correct here.");
            Assert.AreEqual(0.0f, path.GetPoint(2).Z, "The point2.Z is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("dali path GetPointCount test, check whether return the right vlaue")]
        [Property("SPEC", "Tizen.NUI.Path.GetPointCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetPointCount_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Position position0 = new Position(30.0f, 80.0f, 0.0f);
            Position position1 = new Position(70.0f, 120.0f, 0.0f);
            Position position2 = new Position(100.0f, 100.0f, 0.0f);

            Path path = new Path();
            path.AddPoint(position0);
            path.AddPoint(position1);
            path.AddPoint(position2);

            Assert.AreEqual(3, path.GetPointCount(), "The point count of path is not correct here.");
        }


        [Test]
        [Category("P1")]
        [Description("Test Points, Check whether Points is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Path.Points A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Points_SET_GET_VALUE()
        {
            /* TEST CODE */
            Position position0 = new Position(30.0f, 80.0f, 0.0f);
            Position position1 = new Position(70.0f, 120.0f, 0.0f);
            Position position2 = new Position(100.0f, 100.0f, 0.0f);

            Path path = new Path();
            PropertyArray array = new PropertyArray();
            array.Add(new PropertyValue(position0));
            array.Add(new PropertyValue(position1));
            array.Add(new PropertyValue(position2));
            path.Points = array;

            PropertyArray propertyArray = path.Points;
            Assert.AreEqual(array.Count(), propertyArray.Count());
            for (uint index = 0; index < array.Count(); index++)
            {
                Position pos1 = new Position();
                Position pos2 = new Position();
                propertyArray[index].Get(pos1);
                array[index].Get(pos2);
                Assert.AreEqual(pos2.X, pos1.X, "The point.X is not correct here.");
                Assert.AreEqual(pos2.Y, pos1.Y, "The point.Y is not correct here.");
                Assert.AreEqual(pos2.Z, pos1.Z, "The point.Z is not correct here.");
            }
        }

        [Test]
        [Category("P1")]
        [Description("dali path AddControlPoint test, Add servral control points, and check the points.")]
        [Property("SPEC", "Tizen.NUI.Path.AddControlPoint M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AddControlPoint_SET_VALUE()
        {
            /* TEST CODE */
            Vector3 point0 = new Vector3(30.0f, 80.0f, 0.0f);
            Vector3 point1 = new Vector3(70.0f, 120.0f, 0.0f);

            Path path = new Path();
            path.AddControlPoint(point0);
            path.AddControlPoint(point1);

            Assert.AreEqual(30.0f, path.GetControlPoint(0).X, "The controlPoint0.X is not correct here.");
            Assert.AreEqual(120.0f, path.GetControlPoint(1).Y, "The controlPoint1.Y is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("dali path GetControlPoint test, Accessor for the control points, try to get the control points")]
        [Property("SPEC", "Tizen.NUI.Path.GetControlPoint M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GetControlPoint_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            Vector3 point0 = new Vector3(30.0f, 80.0f, 0.0f);
            Vector3 point1 = new Vector3(70.0f, 120.0f, 0.0f);

            Path path = new Path();
            path.AddControlPoint(point0);
            path.AddControlPoint(point1);

            Assert.AreEqual(30.0f, path.GetControlPoint(0).X, "The controlPoint0.X is not correct here.");
            Assert.AreEqual(120.0f, path.GetControlPoint(1).Y, "The controlPoint1.Y is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("dali path GenerateControlPoints test, test to generat control points.")]
        [Property("SPEC", "Tizen.NUI.Path.GenerateControlPoints M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void GenerateControlPoints_CHECK_STATE()
        {
            /* TEST CODE */
            Path path = new Path();
            path.AddPoint(new Position(50.0f, 50.0f, 0.0f));
            path.AddPoint(new Position(120.0f, 70.0f, 0.0f));
            path.AddPoint(new Position(190.0f, 250.0f, 0.0f));
            path.AddPoint(new Position(260.0f, 260.0f, 0.0f));
            path.AddPoint(new Position(330.0f, 220.0f, 0.0f));
            path.AddPoint(new Position(400.0f, 50.0f, 0.0f));

            path.GenerateControlPoints(0.25f);
            Assert.Less(Math.Abs(path.GetControlPoint(0).X - 68.0f), 1.0f, "The controlPoint0.X is not correct here.");
            Assert.Less(Math.Abs(path.GetControlPoint(0).Y - 55.0f), 1.0f, "The controlPoint0.Y is not correct here.");
            Assert.Less(Math.Abs(path.GetControlPoint(1).X - 107.0f), 1.0f, "The controlPoint1.X is not correct here.");
            Assert.Less(Math.Abs(path.GetControlPoint(1).Y - 58.0f), 1.0f, "The controlPoint1.Y is not correct here.");

            Assert.Less(Math.Abs(path.GetControlPoint(2).X - 156.0f), 1.0f, "The controlPoint2.X is not correct here.");
            Assert.Less(Math.Abs(path.GetControlPoint(2).Y - 102.0f), 1.0f, "The controlPoint2.Y is not correct here.");
            Assert.Less(Math.Abs(path.GetControlPoint(3).X - 152.0f), 1.0f, "The controlPoint3.X is not correct here.");
            Assert.Less(Math.Abs(path.GetControlPoint(3).Y - 220.0f), 1.0f, "The controlPoint3.Y is not correct here.");

            Assert.Less(Math.Abs(path.GetControlPoint(4).X - 204.0f), 1.0f, "The controlPoint4.X is not correct here.");
            Assert.Less(Math.Abs(path.GetControlPoint(4).Y - 261.0f), 1.0f, "The controlPoint4.Y is not correct here.");
            Assert.Less(Math.Abs(path.GetControlPoint(5).X - 243.0f), 1.0f, "The controlPoint5.X is not correct here.");
            Assert.Less(Math.Abs(path.GetControlPoint(5).Y - 263.0f), 1.0f, "The controlPoint5.Y is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("dali path Sample test, calculates position and tangent at that point of the curve.")]
        [Property("SPEC", "Tizen.NUI.Path.Sample M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Sample_CHECK_STATE()
        {
            /* TEST CODE */
            Path path = new Path();
            path.AddPoint(new Position(30.0f, 80.0f, 0.0f));
            path.AddPoint(new Position(70.0f, 120.0f, 0.0f));
            path.AddPoint(new Position(100.0f, 100.0f, 0.0f));
            //Control points for first segment
            path.AddControlPoint(new Vector3(39.0f, 90.0f, 0.0f));
            path.AddControlPoint(new Vector3(56.0f, 119.0f, 0.0f));

            //Control points for second segment
            path.AddControlPoint(new Vector3(78.0f, 120.0f, 0.0f));
            path.AddControlPoint(new Vector3(93.0f, 104.0f, 0.0f));

            Vector3 position = new Vector3();
            Vector3 tangent = new Vector3();
            path.Sample(0.0f, position, tangent);

            Assert.AreEqual(30.0f, position.X, "The position.X is not correct here.");
            Assert.AreEqual(80.0f, position.Y, "The position.Y is not correct here.");
            Assert.Less(Math.Abs(tangent.X - 0.6f), 0.1f, "The tangent.X is not correct here.");
            Assert.Less(Math.Abs(tangent.X - 0.7f), 0.1f, "The tangent.Y is not correct here.");

        }

        [Test]
        [Category("P1")]
        [Description("Test ControlPoints, Check whether ControlPoints is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Path.ControlPoints A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ControlPoints_SET_GET_VALUE()
        {
            /* TEST CODE */
            Vector3 point0 = new Vector3(30.0f, 80.0f, 0.0f);
            Vector3 point1 = new Vector3(70.0f, 120.0f, 0.0f);
            Vector3 point2 = new Vector3(100.0f, 100.0f, 0.0f);

            Path path = new Path();
            PropertyArray array = new PropertyArray();
            array.Add(new PropertyValue(point0));
            array.Add(new PropertyValue(point1));
            array.Add(new PropertyValue(point2));
            path.ControlPoints = array;

            PropertyArray propertyArray = path.ControlPoints;

            Assert.AreEqual(array.Count(), propertyArray.Count(), "The count of the propertyArray is not correct here.");
            for (uint index = 0; index < array.Count(); index++)
            {
                Vector3 pos1 = new Vector3();
                Vector3 pos2 = new Vector3();
                propertyArray[index].Get(pos1);
                array[index].Get(pos2);
                Assert.AreEqual(pos2.X, pos1.X, "The point.X is not correct here.");
                Assert.AreEqual(pos2.Y, pos1.Y, "The point.Y is not correct here.");
                Assert.AreEqual(pos2.Z, pos1.Z, "The point.Z is not correct here.");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Path.")]
        [Property("SPEC", "Tizen.NUI.Path.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                Path path = new Path();
                path.Dispose();
            }
            catch (Exception e)
            {
                Tizen.Log.Error("Test CellPosition.cs", "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
    }
}