using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;
using System.Threading;
using System.Threading.Tasks;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.TableView Tests")]
    public class TableViewTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("TableViewTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Construct. Check whether Table View construct.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.TableView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        [Property("COVPARAM", "")]
        public void TableView_INIT()
        {
            var temp_view = new TableView();
            Assert.IsInstanceOf<TableView>(temp_view, "Should return Table View instance.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Construct. Check whether Table View construct.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.TableView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        [Property("COVPARAM", "Uint,Uint")]
        public void TableView_INIT_WITH_UNIT_UNIT()
        {
            var temp_view = new TableView(8, 10);
            Assert.IsInstanceOf<TableView>(temp_view, "Should return Table View instance.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Construct. Check whether Table View construct.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.TableView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        [Property("COVPARAM", "TableView")]
        public void TableView_INIT_WITH_TABLEVIEW()
        {
            TableView temp_view = new TableView(8, 10);
            TableView new_view = new TableView(temp_view);
            Assert.IsInstanceOf<TableView>(new_view, "Should return Table View instance.");
            Assert.AreEqual(8, new_view.Rows, "New table is not same rows.");
            Assert.AreEqual(10, new_view.Columns, "New table is not same columns.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Construct. Check whether Table View construct.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void Assign_INIT()
        {
            TableView temp_view = new TableView(8, 10);
            TableView new_view = temp_view;
            Assert.IsInstanceOf<TableView>(new_view, "Should return Table View instance.");
        }

        [Test]
        [Category("P1")]
        [Description("Test AddChild. Check whether table view add child")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.AddChild M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void AddChild_CHECK_RETURN_VALUE()
        {
            TableView testView = new TableView(10, 10);
            View temActor = new View();
            temActor.Name = "ChildActor";
            testView.AddChild(temActor, new TableView.CellPosition(0, 1));

            View resultActor = testView.GetChildAt(new TableView.CellPosition(0, 1));
            Assert.AreEqual(resultActor.Name, "ChildActor", "Test Add Child Return Error");
        }

        [Test]
        [Category("P1")]
        [Description("Get child of table view")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.GetChildAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void GetChildAt_CHECK_RETURN_VALUE()
        {
            TableView testView = new TableView(10, 10);
            View p1 = new View();
            p1.Name = "View 1";

            View p2 = new View();
            p2.Name = "View 2";

            View p3 = new View();
            p3.Name = "View 3";

            testView.AddChild(p1, new TableView.CellPosition(0, 0));
            testView.AddChild(p2, new TableView.CellPosition(5, 5));
            testView.AddChild(p3, new TableView.CellPosition(7, 2));
            View tempActor = testView.GetChildAt(new TableView.CellPosition(5, 5));
            Assert.AreEqual(tempActor.Name, "View 2", "Test Get Child Error");
        }

        [Test]
        [Category("P1")]
        [Description("Remove child of table view")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.RemoveChildAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void RemoveChildAt_CHECK_RETURN_VALUE()
        {
            TableView testView = new TableView(10, 10);
            View p1 = new View();
            p1.Name = "View 1";

            View p2 = new View();
            p2.Name = "View 2";

            View p3 = new View();
            p3.Name = "View 3";

            testView.AddChild(p1, new TableView.CellPosition(0, 0));
            testView.AddChild(p2, new TableView.CellPosition(5, 5));
            testView.AddChild(p3, new TableView.CellPosition(7, 2));
            View tempActor = testView.RemoveChildAt(new TableView.CellPosition(7, 2));
            Assert.AreEqual(tempActor.Name, "View 3", "Test Remove Child Error");
        }

        [Test]
        [Category("P1")]
        [Description("Find position of child")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.FindChildPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void FindChildPosition_CHECK_RETURN_VALUE()
        {
            TableView testView = new TableView(10, 10);
            View p1 = new View();
            p1.Name = "View 1";

            View p2 = new View();
            p2.Name = "View 2";

            View p3 = new View();
            p3.Name = "View 3";

            testView.AddChild(p1, new TableView.CellPosition(0, 0));
            testView.AddChild(p2, new TableView.CellPosition(5, 5));
            testView.AddChild(p3, new TableView.CellPosition(7, 2));
            TableView.CellPosition tempCell = new TableView.CellPosition();
            testView.FindChildPosition(p1, tempCell);
            Assert.AreEqual(tempCell.rowIndex, 0, "Find Child Position RowIndex Error");
            Assert.AreEqual(tempCell.columnIndex, 0, "Find Child Position RowIndex Error");
        }

        [Test]
        [Category("P1")]
        [Description("Insert Row for Table View")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.InsertRow M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void InsertRow_CHECK_VALUE()
        {
            TableView testView = new TableView(10, 10);
            View p1 = new View();
            p1.Name = "View 1";

            View p2 = new View();
            p2.Name = "View 2";

            View p3 = new View();
            p3.Name = "View 3";

            testView.AddChild(p1, new TableView.CellPosition(0, 0));
            testView.AddChild(p2, new TableView.CellPosition(5, 5));
            testView.AddChild(p3, new TableView.CellPosition(7, 2));
            testView.InsertRow(3);
            TableView.CellPosition tempCell = new TableView.CellPosition();
            testView.FindChildPosition(p2, tempCell);
            Assert.AreEqual(tempCell.rowIndex, 6, "Insert Row Error");
        }

        [Test]
        [Category("P1")]
        [Description("Delete Row for Table View")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.DeleteRow M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void DeleteRow_CHECK_VALUE()
        {
            try
            {
                TableView testView = new TableView(10, 10);
                View p1 = new View();
                p1.Name = "View 1";

                View p2 = new View();
                p2.Name = "View 2";

                View p3 = new View();
                p3.Name = "View 3";

                testView.AddChild(p1, new TableView.CellPosition(0, 0));
                testView.AddChild(p2, new TableView.CellPosition(5, 5));
                testView.AddChild(p3, new TableView.CellPosition(7, 2));
                testView.DeleteRow(3);
                TableView.CellPosition tempCell = new TableView.CellPosition();
                testView.FindChildPosition(p2, tempCell);

                Assert.AreEqual(tempCell.rowIndex, 4, "Delete Row Error");
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
        [Description("Insert Column for Table View")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.InsertColumn M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void InsertColumn_CHECK_VALUE()
        {
            try
            {
                TableView testView = new TableView(10, 10);
                View p1 = new View();
                p1.Name = "View 1";

                View p2 = new View();
                p2.Name = "View 2";

                View p3 = new View();
                p3.Name = "View 3";

                testView.AddChild(p1, new TableView.CellPosition(0, 0));
                testView.AddChild(p2, new TableView.CellPosition(5, 5));
                testView.AddChild(p3, new TableView.CellPosition(7, 2));
                testView.InsertColumn(2);
                TableView.CellPosition tempCell = new TableView.CellPosition();
                testView.FindChildPosition(p3, tempCell);
                Assert.AreEqual(tempCell.columnIndex, 3, "Insert Column Error");
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
        [Description("Delete Column for Table View")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.DeleteColumn M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void DeleteColumn_CHECK_VALUE()
        {
            try
            {
                TableView testView = new TableView(10, 10);
                View p1 = new View();
                p1.Name = "View 1";

                View p2 = new View();
                p2.Name = "View 2";

                View p3 = new View();
                p3.Name = "View 3";

                testView.AddChild(p1, new TableView.CellPosition(0, 0));
                testView.AddChild(p2, new TableView.CellPosition(5, 5));
                testView.AddChild(p3, new TableView.CellPosition(7, 2));
                testView.DeleteColumn(1);
                TableView.CellPosition tempCell = new TableView.CellPosition();
                testView.FindChildPosition(p3, tempCell);
                Assert.AreEqual(tempCell.columnIndex, 1, "Delete Column Error");
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
        [Description("Change Rows and Columns of Table View")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.Resize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void Resize_CHECK_VALUE()
        {
            try
            {
                TableView testView = new TableView(10, 10);
                testView.Resize(12, 1);
                Assert.AreEqual(testView.Rows, 12, "Resize Rows Error");
                Assert.AreEqual(testView.Columns, 1, "Resize Columns Error");
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
        [Description("Change Cell Padding of Table View")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.SetCellPadding M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void SetCellPadding_CHECK_VALUE()
        {
            try
            {
                TableView cellTable = new TableView(10, 10);
                cellTable.Size = new Size(100.0f, 100.0f, 0.0f);
                Window.Instance.GetDefaultLayer().Add(cellTable);
                cellTable.SetCellPadding(new Size2D(5, 5));

                View view = new View();
                cellTable.AddChild(view, new TableView.CellPosition(0, 0));
                view.Name = "view for set cell padding";

                Vector2 temPadding = cellTable.GetCellPadding();

                Tizen.Log.Debug(TAG, "temPadding.Width=" + temPadding.Width);
                Tizen.Log.Debug(TAG, "temPadding.Height=" + temPadding.Height);

                Assert.AreEqual(temPadding.Width, 5, "Set Cell Padding Row Error");
                Assert.AreEqual(temPadding.Height, 5, "Set Cell Padding Column Error");
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
        [Description("Check Cell Padding of Table View")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.GetCellPadding M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void GetCellPadding_CHECK_RETURN_VALUE()
        {
            TableView cellTable = new TableView(10, 10);
            cellTable.SetCellPadding(new Size2D(1, 1));
            Vector2 temPadding = cellTable.GetCellPadding();
            Assert.AreEqual(temPadding.Width, 1, "Get Cell Padding Row Error");
            Assert.AreEqual(temPadding.Height, 1, "Get Cell Padding Column Error");
        }

        [Test]
        [Category("P1")]
        [Description("Table View Cell Fit Height Size and Position")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.SetFitHeight M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void SetFitHeight_CHECK_VALUE()
        {
            TableView fitTable = new TableView(10, 10);
            fitTable.Size = new Size(100.0f, 100.0f, 0.0f);
            Window.Instance.GetDefaultLayer().Add(fitTable);

            View view1 = new View();
            View view2 = new View();
            View view3 = new View();

            fitTable.AddChild(view1, new TableView.CellPosition(0, 0));
            fitTable.AddChild(view2, new TableView.CellPosition(0, 1));
            fitTable.AddChild(view3, new TableView.CellPosition(1, 0));

            fitTable.SetFitHeight(0);
            Tizen.Log.Debug(TAG, "fitTable.IsFitHeight(0)=" + fitTable.IsFitHeight(0));
            Tizen.Log.Debug(TAG, "fitTable.IsFitHeight(1)=" + fitTable.IsFitHeight(1));

            Assert.IsTrue(fitTable.IsFitHeight(0), "Get Fit Height Error.");
        }

        [Test]
        [Category("P1")]
        [Description("Table View Cell Fit Check")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.IsFitHeight M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void IsFitHeight_CHECK_RETURN_VALUE()
        {
            TableView fitTable = new TableView(10, 10);
            fitTable.Size = new Size(100.0f, 100.0f, 0.0f);
            View actor1 = new View();
            View actor2 = new View();
            View actor3 = new View();

            fitTable.AddChild(actor1, new TableView.CellPosition(0, 0));
            fitTable.AddChild(actor2, new TableView.CellPosition(0, 1));
            fitTable.AddChild(actor3, new TableView.CellPosition(1, 0));

            fitTable.SetFitHeight(0);

            Assert.IsTrue(fitTable.IsFitHeight(0), "Get Fit Height Error.");
        }

        [Test]
        [Category("P1")]
        [Description("Table View Cell Fit Check -- Width")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.SetFitWidth M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public async Task SetFitWidth_CHECK_VALUE()
        {
            try
            {
                TableView fitTable = new TableView(10, 10);
                fitTable.Size = new Size(100.0f, 100.0f, 0.0f);
                View actor1 = new View();
                View actor2 = new View();
                View actor3 = new View();

                fitTable.AddChild(actor1, new TableView.CellPosition(0, 0));
                fitTable.AddChild(actor2, new TableView.CellPosition(0, 1));
                fitTable.AddChild(actor3, new TableView.CellPosition(1, 0));

                fitTable.SetFitWidth(0);

                Assert.IsTrue(fitTable.IsFitWidth(0), "Check Whether Fit Width.");
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
        [Description("Table View Cell Fit Check -- Width")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.IsFitWidth M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void IsFitWidth_CHECK_RETURN_VALUE()
        {
            TableView fitTable = new TableView(10, 10);
            fitTable.Size = new Size(100.0f, 100.0f, 0.0f);
            View actor1 = new View();
            View actor2 = new View();
            View actor3 = new View();

            fitTable.AddChild(actor1, new TableView.CellPosition(0, 0));
            fitTable.AddChild(actor2, new TableView.CellPosition(0, 1));
            fitTable.AddChild(actor3, new TableView.CellPosition(1, 0));

            fitTable.SetFitWidth(0);

            Assert.IsTrue(fitTable.IsFitWidth(0), "Check Whether Fit Width.");
        }

        [Test]
        [Category("P1")]
        [Description("Set Fixed Height to Row ")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.SetFixedHeight M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public async Task SetFixedHeight_CHECK_VALUE()
        {
            try
            {
                TableView fitTable = new TableView(10, 10);
                View actor1 = new View();
                View actor2 = new View();
                View actor3 = new View();

                fitTable.AddChild(actor1, new TableView.CellPosition(0, 0));
                fitTable.AddChild(actor2, new TableView.CellPosition(0, 1));
                fitTable.AddChild(actor3, new TableView.CellPosition(1, 0));

                fitTable.SetFixedHeight(0, 50.0f);
                Assert.AreEqual(fitTable.GetFixedHeight(0), 50.0f, "Check Fixed Height of Row.");
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
        [Description("Get fixed Height of Row")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.GetFixedHeight M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void GetFixedHeight_CHECK_RETURN_VALUE()
        {
            TableView fitTable = new TableView(10, 10);
            View actor1 = new View();
            View actor2 = new View();
            View actor3 = new View();

            fitTable.AddChild(actor1, new TableView.CellPosition(0, 0));
            fitTable.AddChild(actor2, new TableView.CellPosition(0, 1));
            fitTable.AddChild(actor3, new TableView.CellPosition(1, 0));

            fitTable.SetFixedHeight(0, 50.0f);
            Assert.AreEqual(fitTable.GetFixedHeight(0), 50.0f, "Check Fixed Height of Row.");
        }

        [Test]
        [Category("P1")]
        [Description("Set Relative Height of Row ")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.SetRelativeHeight M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public async Task SetRelativeHeight_CHECK_VALUE()
        {
            try
            {
                TableView fitTable = new TableView(10, 10);
                fitTable.Size = new Size(100.0f, 100.0f, 0.0f);
                View actor1 = new View();
                View actor2 = new View();
                View actor3 = new View();

                fitTable.AddChild(actor1, new TableView.CellPosition(0, 0));
                fitTable.AddChild(actor2, new TableView.CellPosition(0, 1));
                fitTable.AddChild(actor3, new TableView.CellPosition(1, 0));

                fitTable.SetRelativeHeight(0, 0.3f);
                float v1 = fitTable.GetRelativeHeight(0);
                Assert.IsTrue(v1 - 0.3f < 0.001, "Check Relative Height Error.");
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
        [Description("Get Relative Height of Row")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.GetRelativeHeight M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void GetRelativeHeight_CHECK_RETURN_VALUE()
        {
            TableView fitTable = new TableView(10, 10);
            fitTable.Size = new Size(100.0f, 100.0f, 0.0f);
            View actor1 = new View();
            View actor2 = new View();
            View actor3 = new View();

            fitTable.AddChild(actor1, new TableView.CellPosition(0, 0));
            fitTable.AddChild(actor2, new TableView.CellPosition(0, 1));
            fitTable.AddChild(actor3, new TableView.CellPosition(1, 0));

            fitTable.SetRelativeHeight(0, 0.3f);
            float v1 = fitTable.GetRelativeHeight(0);
            Assert.IsTrue(v1 - 0.3f < 0.001, "Check Relative Height Error.");
        }

        [Test]
        [Category("P1")]
        [Description("Table View Set Fixed Width of column.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.SetFixedWidth M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public async Task SetFixedWidth_CHECK_VALUE()
        {
            try
            {
                TableView fitTable = new TableView(10, 10);
                View actor1 = new View();
                View actor2 = new View();
                View actor3 = new View();

                fitTable.AddChild(actor1, new TableView.CellPosition(0, 0));
                fitTable.AddChild(actor2, new TableView.CellPosition(0, 1));
                fitTable.AddChild(actor3, new TableView.CellPosition(1, 0));

                fitTable.SetFixedWidth(0, 20.0f);
                Assert.AreEqual(fitTable.GetFixedWidth(0), 20.0f, "Check Set Fixed Width of Column.");
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
        [Description("Get Fixed Width for column ")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.GetFixedWidth M.")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void GetFixedWidth_CHECK_RETURN_VALUE()
        {
            TableView fitTable = new TableView(10, 10);
            View actor1 = new View();
            View actor2 = new View();
            View actor3 = new View();

            fitTable.AddChild(actor1, new TableView.CellPosition(0, 0));
            fitTable.AddChild(actor2, new TableView.CellPosition(0, 1));
            fitTable.AddChild(actor3, new TableView.CellPosition(1, 0));

            fitTable.SetFixedWidth(0, 20.0f);
            Assert.AreEqual(fitTable.GetFixedWidth(0), 20.0f, "Check Set Fixed Width of Column.");
        }

        [Test]
        [Category("P1")]
        [Description("Set Relative Width for Column")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.SetRelativeWidth M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public async Task SetRelativeWidth_CHECK_VALUE()
        {
            try
            {
                TableView fitTable = new TableView(10, 10);
                fitTable.Size = new Size(100.0f, 100.0f, 0.0f);
                View actor1 = new View();
                View actor2 = new View();
                View actor3 = new View();

                fitTable.AddChild(actor1, new TableView.CellPosition(0, 0));
                fitTable.AddChild(actor2, new TableView.CellPosition(0, 1));
                fitTable.AddChild(actor3, new TableView.CellPosition(1, 0));

                fitTable.SetRelativeWidth(0, 0.2f);
                Assert.AreEqual(fitTable.GetRelativeWidth(0), 0.2f, "Check Set Fixed Width of Column.");
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
        [Description("Get Relative Width for Column")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.GetRelativeWidth M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void GetRelativeWidth_CHECK_RETURN_VALUE()
        {
            TableView fitTable = new TableView(10, 10);
            fitTable.Size = new Size(100.0f, 100.0f, 0.0f);
            View actor1 = new View();
            View actor2 = new View();
            View actor3 = new View();

            fitTable.AddChild(actor1, new TableView.CellPosition(0, 0));
            fitTable.AddChild(actor2, new TableView.CellPosition(0, 1));
            fitTable.AddChild(actor3, new TableView.CellPosition(1, 0));

            fitTable.SetRelativeWidth(0, 0.2f);
            Assert.AreEqual(fitTable.GetRelativeWidth(0), 0.2f, "Check Set Fixed Width of Column.");
        }

        [Test]
        [Category("P1")]
        [Description("Set Cell Alignment of TableView")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.SetCellAlignment M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public async Task SetCellAlignment_CHECK_VALUE()
        {
            try
            {
                TableView fitTable = new TableView(10, 10);
                fitTable.Size = new Size(100.0f, 100.0f, 0.0f);
                View actor1 = new View();
                View actor2 = new View();
                View actor3 = new View();
                actor1.Size = new Size(8.0f, 8.0f, 0.0f);
                fitTable.SetFixedWidth(0, 8.0f);
                fitTable.SetFixedHeight(0, 8.0f);
                fitTable.AddChild(actor1, new TableView.CellPosition(0, 0));
                fitTable.AddChild(actor2, new TableView.CellPosition(0, 1));
                fitTable.AddChild(actor3, new TableView.CellPosition(1, 0));
                Window.Instance.GetDefaultLayer().Add(fitTable);
                fitTable.SetCellAlignment(new TableView.CellPosition(0, 0, 2, 2), HorizontalAlignmentType.Center, VerticalAlignmentType.Top);

                await Task.Delay(20);
                Assert.AreEqual(0.0f, actor1.PositionX, "SetCellPadding Position.X Error");
                Assert.AreEqual(0.0f, actor1.PositionY, "SetCellPadding Position.Y Error");
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
        [Description("Test CellPadding Check Whether the CellPadding is readable and Writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.CellPadding A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]

        public void CellPadding_SET_GET_VALUE()
        {
            TableView fitTable = new TableView(10, 10);
            fitTable.CellPadding = new Vector2(0.5f, 0.5f);
            Assert.AreEqual(0.5f, fitTable.CellPadding.Width, "SELL PADDING WIDTH FAIL.");
            Assert.AreEqual(0.5f, fitTable.CellPadding.Height, "SELL PADDING HEIGHT FAIL.");
        }
        [Test]
        [Category("P1")]
        [Description("Test Rows. Check Whether the Rows is readable and Writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.Rows A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]

        public void Rows_SET_GET_VALUE()
        {
            TableView fitTable = new TableView(10, 10);
            fitTable.Rows = 11;
            Assert.AreEqual(11, fitTable.Rows, "Table Rows Test Fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test LayoutRows. Check Whether the LayoutRows is readable and Writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.LayoutRows A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]

        public void LayoutRows_SET_GET_VALUE()
        {
            TableView fitTable = new TableView(10, 10);
            PropertyMap item1 = new PropertyMap().Add("policy", new PropertyValue("fixed")).Add("value", new PropertyValue(30.0f));
            PropertyMap item2 = new PropertyMap().Add("policy", new PropertyValue("relative")).Add("value", new PropertyValue(0.2f));
            fitTable.LayoutRows = new PropertyMap().Add("1", new PropertyValue(item1)).Add("3", new PropertyValue(item2));

            PropertyMap map1 = new PropertyMap();
            fitTable.LayoutRows.Find(0, "1").Get(map1);
            PropertyMap map2 = new PropertyMap();
            fitTable.LayoutRows.Find(1, "3").Get(map2);
            float v1 = 0.0f, v2 = 0.0f;
            map1.Find(1, "value").Get(out v1);
            map2.Find(1, "value").Get(out v2);

            Assert.AreEqual(30.0f, v1, "Table  Layout Rows Test Fail 1.");
            Assert.AreEqual(0.2f, v2, "Table  Layout Rows Test Fail 2.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Columns. Check Whether the Columns is readable and Writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.Columns A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]

        public void Columns_SET_GET_VALUE()
        {
            TableView fitTable = new TableView(10, 10);
            fitTable.Columns = 11;
            Assert.AreEqual(11, fitTable.Columns, "Table Columns Test Fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test LayoutColumns. Check Whether the LayoutColumns is readable and Writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.LayoutColumns A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]

        public void LayoutColumns_SET_GET_VALUE()
        {
            TableView fitTable = new TableView(10, 10);
            PropertyMap item1 = new PropertyMap().Add("policy", new PropertyValue("fixed")).Add("value", new PropertyValue(30.0f));
            PropertyMap item2 = new PropertyMap().Add("policy", new PropertyValue("relative")).Add("value", new PropertyValue(0.2f));
            fitTable.LayoutColumns = new PropertyMap().Add("1", new PropertyValue(item1)).Add("3", new PropertyValue(item2));

            PropertyMap map1 = new PropertyMap();
            fitTable.LayoutColumns.Find(0, "1").Get(map1);
            PropertyMap map2 = new PropertyMap();
            fitTable.LayoutColumns.Find(1, "3").Get(map2);

            float v1 = 0.0f, v2 = 0.0f;
            map1.Find(1, "value").Get(out v1);
            map2.Find(1, "value").Get(out v2);

            Assert.AreEqual(30.0f, v1, "Table  Layout Columns Test Fail 1.");
            Assert.AreEqual(0.2f, v2, "Table  Layout Columns Test Fail 2.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the TableView.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            try
            {
                TableView tableView = new TableView(10, 10);
                tableView.Dispose();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
    }
}