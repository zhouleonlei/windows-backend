using System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests {

    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.TableView.CellPosition Tests")]

    public class CellPositionTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("CellPositionTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Test CellPosition. Check whether Cell Position construct With rowIndex and columnIndex.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.CellPosition.CellPosition C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        [Property("COVPARAM", "Uint,Uint")]
        public void CellPosition_INIT_WITH_UNIT_UNIT()
        {
            var temPostion = new TableView.CellPosition(2, 1);
            Assert.IsInstanceOf<TableView.CellPosition>(temPostion, "class cell position is created success.");
        }

        [Test]
        [Category("P1")]
        [Description("Test CellPosition. Check whether Cell Position construct with rowIndex, columnIndex, rowSpan and columSpan.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.CellPosition.CellPosition C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        [Property("COVPARAM", "Uint,Uint,Uint,Uint")]
        public void CellPosition_INIT_WITH_UINT_UINT_UINT_UINT()
        {
            var temPostion = new TableView.CellPosition(2, 1, 3, 3);
            Assert.IsInstanceOf<TableView.CellPosition>(temPostion, "class cell position is created success.");
        }

        [Test]
        [Category("P1")]
        [Description("Test CellPosition. Check whether Cell Position construct with rowIdnex, columnIndex and rowSpan.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.CellPosition.CellPosition C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        [Property("COVPARAM", "Uint,Uint,Uint")]
        public void CellPosition_INIT_WITH_UINT_UINT_UINT()
        {
            var temPostion = new TableView.CellPosition(2, 1, 3);
            Assert.IsInstanceOf<TableView.CellPosition>(temPostion, "class cell position is created success.");
        }

        [Test]
        [Category("P1")]
        [Description("Test CellPosition. Check whether Cell Position construct with rowIndex.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.CellPosition.CellPosition C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        [Property("COVPARAM", "Uint")]
        public void CellPosition_INIT_WITH_UINT()
        {
            var temPostion = new TableView.CellPosition(2);
            Assert.IsInstanceOf<TableView.CellPosition>(temPostion, "class cell position is created success.");
        }

        [Test]
        [Category("P1")]
        [Description("Test CellPosition. Check whether Cell Position construct.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.CellPosition.CellPosition C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void CellPosition_INIT()
        {
            var temPostion = new TableView.CellPosition();
            Assert.IsInstanceOf<TableView.CellPosition>(temPostion, "class cell position is created success.");
        }

        [Test]
        [Category("P1")]
        [Description("Test cell position columnIndex.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.CellPosition.columnIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void columnIndex_SET_GET_VALUE()
        {
            TableView.CellPosition cell = new TableView.CellPosition();
            cell.columnIndex = 3;
            Assert.AreEqual(3, cell.columnIndex, "cell position columns index test fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test cell position rowIndex.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.CellPosition.rowIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void rowIndex_SET_GET_VALUE()
        {
            TableView.CellPosition cell = new TableView.CellPosition();
            cell.rowIndex = 3;
            Assert.AreEqual(3, cell.rowIndex, "cell position row index test fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test cell position columnSpan.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.CellPosition.columnSpan A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void columnSpan_SET_GET_VALUE()
        {
            TableView.CellPosition cell = new TableView.CellPosition();
            cell.columnSpan = 3;
            Assert.AreEqual(3, cell.columnSpan, "cell position columns span test fail");
        }

        [Test]
        [Category("P1")]
        [Description("Test cell position rowSpan.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.CellPosition.rowSpan A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void rowSpan_SET_GET_VALUE()
        {
            TableView.CellPosition cell = new TableView.CellPosition();
            cell.rowSpan = 3;
            Assert.AreEqual(3, cell.rowSpan , "cell position row span test fail");
        }

        [Test]
        [Category("P1")]
        [Description("Test cell position ColumnIndex.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.CellPosition.ColumnIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void ColumnIndex_GET_VALUE()
        {
            TableView.CellPosition cell = new TableView.CellPosition(4, 3);
            Assert.AreEqual(3, cell.ColumnIndex, "cell position ColumnIndex test fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test cell position RowIndex.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.CellPosition.RowIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void RowIndex_GET_VALUE()
        {
            TableView.CellPosition cell = new TableView.CellPosition(3);
            Assert.AreEqual(3, cell.RowIndex, "cell position RowIndex test fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test cell position ColumnSpan.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.CellPosition.ColumnSpan A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void ColumnSpan_GET_VALUE()
        {
            TableView.CellPosition cell = new TableView.CellPosition(4, 4, 4, 3);
            Assert.AreEqual(3, cell.ColumnSpan, "cell position ColumnSpan test fail");
        }

        [Test]
        [Category("P1")]
        [Description("Test cell position RowSpan.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.CellPosition.RowSpan A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void RowSpan_GET_VALUE()
        {
            TableView.CellPosition cell = new TableView.CellPosition(4, 4, 3);
            Assert.AreEqual(3, cell.RowSpan, "cell position RowSpan test fail");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the CellPosition.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TableView.CellPosition.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                TableView.CellPosition cell = new TableView.CellPosition();
                cell.Dispose();
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

