using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using DataTire;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using Digiteq.Reports.SCS.Commen;
using Zion.ERP.Reports.DataSets.SCS;
using ZION.ERP.Reports.DataSets.SCS;

namespace Digiteq
{
    public partial class frm_rpt_StockStatement : Form
    {

        
        //form manage
           public int iFormID;

        //for security handle
        public bool bNoAccess;
        public DataTable dtAllDetailRecodes = new DataTable();
        public DataTable dtAllHeaderRecodes = new DataTable();
        
        public static string sitemName = "";
        public static string sStockBalance = "";
        List<tbl_tmpStockTracking> glb_oStockTracking = new List<tbl_tmpStockTracking>();
        dts_scs_Stock_Statement glb_scs_Stock_Statement = new dts_scs_Stock_Statement();


        #region Form Load
        public frm_rpt_StockStatement()
        {
            iFormID = clsSecurity.getFormID(FormName.detailsStockStaement);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_rpt_StockStatement_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Stock Tracking Note", 3, iFormID);
          
            clsFormatter.ApplyGridFormat(dgvDetail, Color.FromArgb(150, 151, 150), Color.Black);
            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString() || clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                dgvDetail.Columns["ItemSubCategoryID"].Visible = true;
            else
            {
                dgvDetail.Columns["ItemSubCategoryID"].Visible = false;                         
            }

            ClearFields();           
        }
        #endregion



        #region btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                rpt_scs_Stock_Statement objRpt = new rpt_scs_Stock_Statement();
                objRpt.SetDataSource(dtAllHeaderRecodes);

                frm_ReportViewer ReportViewer = new frm_ReportViewer();

                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring("Detail Stock Statement");
                objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                ReportViewer.crystalReportViewer1.ReportSource = objRpt;
                ReportViewer.crystalReportViewer1.Refresh();
                ReportViewer.WindowState = FormWindowState.Maximized;
                ReportViewer.ShowDialog();

            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Btn Search
        private void btnSave_Click(object sender, EventArgs e)
        {
            FillDataTable();
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        } 
        #endregion


        #region Clear Fields
        private void ClearFields()
        { 
            txtStoreID.Tag = null;
            txtItemID.Tag = null;
            
            txtItemID.Clear();
            txtStoreID.Clear();

            chkDGN.Checked = true;
            chkDO.Checked = true;
            chkGRN.Checked = true;
            chkIGIN.Checked = true;
            chkIGRN.Checked = true;          
            chkSAN.Checked = true;
            chkSPL.Checked = true;
            chkSRN.Checked = true;
            chkDIS.Checked = true;
            chkFGTN.Checked = true;
            chkLoan.Checked = true;
            chkPRN.Checked = true;            

            dtAllDetailRecodes.Rows.Clear();
            dtAllHeaderRecodes.Rows.Clear();
            dgvDetail.Rows.Clear();
        }
        #endregion

        #region Fill Data Table
        private void FillDataTable()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                ValidateEmptyForeignKey();
                glb_oStockTracking.Clear();
                glb_scs_Stock_Statement.Stock_Statement.Rows.Clear();

                bool bStoreSelected = false, bItemSelected = false, bCategorySelected = false;
                if (txtStoreID.Tag != null && txtStoreID.Tag.ToString().Trim().Length > 0 && txtStoreID.Tag.ToString() != "default")
                    bStoreSelected = true;
                if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0 && txtItemID.Tag.ToString() != "default")
                    bItemSelected = true;
                if (txtItemCategory.Tag != null && txtItemCategory.Tag.ToString().Trim().Length > 0 && txtItemCategory.Tag.ToString() != "default")
                    bCategorySelected = true;

                #region  Fill detail Table

                #region External GRN
                if (chkGRN.Checked)
                {
                    foreach (tbl_scsExternalGoodReceivedNote oGRN in tbl_scsExternalGoodReceivedNote.SelectAll().Where(p => !p.IsDeleted && p.ExternalGoodReceivedNote_ID != "default" &&
                        p.ExternalGoodReceivedNoteDate.Date >= dtpFrom.Value.Date && p.ExternalGoodReceivedNoteDate.Date <= dtpTo.Value.Date))
                    {
                        if (bStoreSelected ? (oGRN.Store_ID == txtStoreID.Tag.ToString() ? true : false) : true)
                        {
                            foreach (tbl_scsExternalGoodReceivedNote_Detail detail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(oGRN.ExternalGoodReceivedNote_ID))
                            {
                                if (bItemSelected ? (detail.Item_ID == txtItemID.Tag.ToString() && txtItemSubCategory.Tag.ToString() == detail.ItemSubCategory_ID &&
                                    txtItemSubCategory.Text.Trim() == detail.ItemSubCategory2_ID && txtItemSerialNo.Tag.ToString() == detail.ItemSerialNo &&
                                    txtItemSerialNo.Text == detail.ItemSerialNo2 ? true : false) : true)
                                {
                                    decimal dQty = detail.Qty, dWeight = detail.Weight;
                                    tbl_tmpStockTracking oTracking = new tbl_tmpStockTracking(oGRN.ExternalGoodReceivedNote_ID, oGRN.ExternalGoodReceivedNoteDate, oGRN.Store_ID, detail.Item_ID,
                                        detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2,
                                        dQty, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, dQty, dWeight, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, dWeight);
                                    glb_oStockTracking.Add(oTracking);
                                }
                            }
                        }
                    }
                }
                #endregion

                #region iGRN - Store
                if (chkIGRN.Checked)
                {
                    foreach (tbl_scsStoreGoodReceiveNote oHeader in tbl_scsStoreGoodReceiveNote.SelectAll().Where(p => !p.IsDeleted && p.StoreGoodReceiveNote_ID != "default" &&
                        p.StoreGoodReceiveNoteDate.Date >= dtpFrom.Value.Date && p.StoreGoodReceiveNoteDate.Date <= dtpTo.Value.Date))
                    {
                        if (bStoreSelected ? (oHeader.ToStore_ID == txtStoreID.Tag.ToString() ? true : false) : true)
                        {
                            foreach (tbl_scsStoreGoodReceiveNote_Detail detail in tbl_scsStoreGoodReceiveNote_Detail.SelectAllByStoreGoodReceiveNote_ID(oHeader.StoreGoodReceiveNote_ID))
                            {
                                if (bItemSelected ? (detail.Item_ID == txtItemID.Tag.ToString() && txtItemSubCategory.Tag.ToString() == detail.ItemSubCategory_ID &&
                                   txtItemSubCategory.Text.Trim() == detail.ItemSubCategory2_ID && txtItemSerialNo.Tag.ToString() == detail.ItemSerialNo &&
                                   txtItemSerialNo.Text == detail.ItemSerialNo2 ? true : false) : true)
                                {
                                    decimal dQty = detail.Qty, dWeight = detail.Weight;
                                    tbl_tmpStockTracking oTracking = new tbl_tmpStockTracking(oHeader.StoreGoodReceiveNote_ID, oHeader.StoreGoodReceiveNoteDate, oHeader.ToStore_ID, detail.Item_ID,
                                        detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2,
                                        0, 0, 0, 0, 0, 0, 0, dQty, 0, 0, 0, 0, 0, 0, dQty, 0, 0, 0, 0, 0, 0, 0, dWeight, 0, 0, 0, 0, 0, 0, dWeight);
                                    glb_oStockTracking.Add(oTracking);
                                }

                            }
                        }
                    }
                }
                #endregion

                #region iGIN Store
                if (chkIGIN.Checked)
                {
                    foreach (tbl_scsStoreGoodIssueNote oHeader in tbl_scsStoreGoodIssueNote.SelectAll().Where(p => !p.IsDeleted && p.StoreGoodIssueNote_ID != "default" &&
                        p.StoreGoodIssueNoteDate.Date >= dtpFrom.Value.Date && p.StoreGoodIssueNoteDate.Date <= dtpTo.Value.Date))
                    {
                        if (bStoreSelected ? (oHeader.FromStore_ID == txtStoreID.Tag.ToString() ? true : false) : true)
                        {
                            foreach (tbl_scsStoreGoodIssueNote_Detail detail in tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(oHeader.StoreGoodIssueNote_ID))
                            {
                                if (bItemSelected ? (detail.Item_ID == txtItemID.Tag.ToString() && txtItemSubCategory.Tag.ToString() == detail.ItemSubCategory_ID &&
                                   txtItemSubCategory.Text.Trim() == detail.ItemSubCategory2_ID && txtItemSerialNo.Tag.ToString() == detail.ItemSerialNo &&
                                   txtItemSerialNo.Text == detail.ItemSerialNo2 ? true : false) : true)
                                {
                                    decimal dQty = detail.Qty, dWeight = detail.Weight;
                                    tbl_tmpStockTracking oTracking = new tbl_tmpStockTracking(oHeader.StoreGoodIssueNote_ID, oHeader.StoreGoodIssueNoteDate, oHeader.FromStore_ID, detail.Item_ID,
                                        detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2,
                                        0, 0, 0, 0, 0, 0, -dQty, 0, 0, 0, 0, 0, 0, 0, -dQty, 0, 0, 0, 0, 0, 0, -dWeight, 0, 0, 0, 0, 0, 0, 0, -dWeight);
                                    glb_oStockTracking.Add(oTracking);
                                }
                            }
                        }
                    }
                }
                #endregion

                #region Delivery Order
                if (chkDO.Checked)
                {
                    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                    {
                        foreach (tbl_sasInvDeliveryOrder oHeader in tbl_sasInvDeliveryOrder.SelectAll().Where(p => !p.IsDeleted && p.IDeliveryOrder_ID != "default" &&
                        p.IDeliveryOrderDate.Date >= dtpFrom.Value.Date && p.IDeliveryOrderDate.Date <= dtpTo.Value.Date))
                        {
                            if (bStoreSelected ? (oHeader.Store_ID == txtStoreID.Tag.ToString() ? true : false) : true)
                            {
                                foreach (tbl_sasInvDeliveryOrder_Detail detail in tbl_sasInvDeliveryOrder_Detail.SelectAllByIDeliveryOrder_ID(oHeader.IDeliveryOrder_ID))
                                {
                                    if (bItemSelected ? (detail.Item_ID == txtItemID.Tag.ToString() && txtItemSubCategory.Tag.ToString() == detail.ItemSubCategory_ID &&
                                        txtItemSubCategory.Text.Trim() == detail.ItemSubCategory2_ID && txtItemSerialNo.Tag.ToString() == detail.ItemSerialNo &&
                                        txtItemSerialNo.Text == detail.ItemSerialNo2 ? true : false) : true)
                                    {
                                        decimal dQty = detail.Qty, dWeight = detail.Weight;
                                        tbl_tmpStockTracking oTracking = new tbl_tmpStockTracking(oHeader.IDeliveryOrder_ID, oHeader.IDeliveryOrderDate, oHeader.Store_ID, detail.Item_ID,
                                            detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -dQty, -dQty, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -dWeight, -dWeight);
                                        glb_oStockTracking.Add(oTracking);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (tbl_sasDeliveryOrder oHeader in tbl_sasDeliveryOrder.SelectAll().Where(p => !p.IsDeleted && p.DeliveryOrder_ID != "default" &&
                        p.DeliveryOrderDate.Date >= dtpFrom.Value.Date && p.DeliveryOrderDate.Date <= dtpTo.Value.Date))
                        {
                            if (bStoreSelected ? (oHeader.Store_ID == txtStoreID.Tag.ToString() ? true : false) : true)
                            {
                                foreach (tbl_sasDeliveryOrder_Detail detail in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oHeader.DeliveryOrder_ID))
                                {
                                    if (bItemSelected ? (detail.Item_ID == txtItemID.Tag.ToString() && txtItemSubCategory.Tag.ToString() == detail.ItemSubCategory_ID &&
                                       txtItemSubCategory.Text.Trim() == detail.ItemSubCategory2_ID && txtItemSerialNo.Tag.ToString() == detail.ItemSerialNo &&
                                       txtItemSerialNo.Text == detail.ItemSerialNo2 ? true : false) : true)
                                    {
                                        decimal dQty = detail.Qty, dWeight = detail.Weight;
                                        tbl_tmpStockTracking oTracking = new tbl_tmpStockTracking(oHeader.DeliveryOrder_ID, oHeader.DeliveryOrderDate, oHeader.Store_ID, detail.Item_ID,
                                            detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -dQty, -dQty, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -dWeight, -dWeight);
                                        glb_oStockTracking.Add(oTracking);
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

                #region Stock Adjustment
                if (chkSAN.Checked)
                {
                    foreach (tbl_scsStockAdjustment oHeader in tbl_scsStockAdjustment.SelectAll().Where(p => !p.IsDeleted && p.StockAdjustment_ID != "default" &&
                        p.StockAdjustmentDate.Date >= dtpFrom.Value.Date && p.StockAdjustmentDate.Date <= dtpTo.Value.Date))
                    {
                        if (bStoreSelected ? (oHeader.Store_ID == txtStoreID.Tag.ToString() ? true : false) : true)
                        {
                            foreach (tbl_scsStockAdjustment_Detail detail in tbl_scsStockAdjustment_Detail.SelectAllByStockAdjustment_ID(oHeader.StockAdjustment_ID))
                            {
                                if (bItemSelected ? (detail.Item_ID == txtItemID.Tag.ToString() && txtItemSubCategory.Tag.ToString() == detail.ItemSubCategory_ID &&
                                      txtItemSubCategory.Text.Trim() == detail.ItemSubCategory2_ID && txtItemSerialNo.Tag.ToString() == detail.ItemSerialNo &&
                                      txtItemSerialNo.Text == detail.ItemSerialNo2 ? true : false) : true)
                                {
                                    decimal dQty = (detail.Qty - detail.OldQty), dWeight = (detail.Weight - detail.OldWeight);                                    
                                    tbl_tmpStockTracking oTracking = new tbl_tmpStockTracking(oHeader.StockAdjustment_ID, oHeader.StockAdjustmentDate, oHeader.Store_ID, detail.Item_ID,
                                        detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2,
                                        0, 0, 0, dQty, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, dQty, 0, 0, 0, dWeight, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, dWeight);
                                    glb_oStockTracking.Add(oTracking);
                                }
                            }
                        }
                    }
                }

                #endregion

                #region Sales Return Note
                if (chkSRN.Checked)
                {
                    foreach (tbl_sasSalesReturnedNote oHeader in tbl_sasSalesReturnedNote.SelectAll().Where(p => !p.IsDeleted && p.SalesReturnedNote_ID != "default" &&
                        p.SalesReturnedNoteDate.Date >= dtpFrom.Value.Date && p.SalesReturnedNoteDate.Date <= dtpTo.Value.Date))
                    {
                        if (bStoreSelected ? (oHeader.Store_ID == txtStoreID.Tag.ToString() ? true : false) : true)
                        {
                            foreach (tbl_sasSalesReturnedNote_Detail detail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oHeader.SalesReturnedNote_ID))
                            {
                                if (bItemSelected ? (detail.Item_ID == txtItemID.Tag.ToString() && txtItemSubCategory.Tag.ToString() == detail.ItemSubCategory_ID &&
                                       txtItemSubCategory.Text.Trim() == detail.ItemSubCategory2_ID && txtItemSerialNo.Tag.ToString() == detail.ItemSerialNo &&
                                       txtItemSerialNo.Text == detail.ItemSerialNo2 ? true : false) : true)
                                {
                                    decimal dQty = detail.Qty, dWeight = detail.Weight;
                                    tbl_tmpStockTracking oTracking = new tbl_tmpStockTracking(oHeader.SalesReturnedNote_ID, oHeader.SalesReturnedNoteDate, oHeader.Store_ID, detail.Item_ID,
                                        detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2,
                                        0, 0, 0, dQty, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, dQty, 0, 0, 0, dWeight, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, dWeight);
                                    glb_oStockTracking.Add(oTracking);
                                }
                            }
                        }
                    }
                }
                #endregion

                #region Finished Good Transfer Note
                if (chkFGTN.Checked)
                {
                    foreach (tbl_scsStoreProduction oHeader in tbl_scsStoreProduction.SelectAll().Where(p => !p.IsDeleted && p.StoreProduction_ID != "default" &&
                        p.StoreProductionDate.Date >= dtpFrom.Value.Date && p.StoreProductionDate.Date <= dtpTo.Value.Date))
                    {
                        if (bStoreSelected ? (oHeader.Store_ID == txtStoreID.Tag.ToString() ? true : false) : true)
                        {
                            foreach (tbl_scsStoreProduction_Detail detail in tbl_scsStoreProduction_Detail.SelectAllByStoreProduction_ID(oHeader.StoreProduction_ID))
                            {
                                if (bItemSelected ? (detail.Item_ID == txtItemID.Tag.ToString() && txtItemSubCategory.Tag.ToString() == detail.ItemSubCategory_ID &&
                                       txtItemSubCategory.Text.Trim() == detail.ItemSubCategory2_ID && txtItemSerialNo.Tag.ToString() == detail.ItemSerialNo &&
                                       txtItemSerialNo.Text == detail.ItemSerialNo2 ? true : false) : true)
                                {
                                    decimal dQty = detail.Qty, dWeight = detail.Weight;
                                    tbl_tmpStockTracking oTracking = new tbl_tmpStockTracking(oHeader.StoreProduction_ID, oHeader.StoreProductionDate, oHeader.Store_ID, detail.Item_ID,
                                        detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2,
                                        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, dQty, 0, dQty, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, dWeight, 0, dWeight);
                                    glb_oStockTracking.Add(oTracking);
                                }
                            }
                        }
                    }
                }
                #endregion

                #region Loan In / Out
                if (chkLoan.Checked)
                {
                    foreach (tbl_scsLoanIn oHeader in tbl_scsLoanIn.SelectAll().Where(p => !p.IsDeleted && p.LoanIn_ID != "default" &&
                        p.LoanInDate.Date >= dtpFrom.Value.Date && p.LoanInDate.Date <= dtpTo.Value.Date))
                    {
                        if (bStoreSelected ? (oHeader.Store_ID == txtStoreID.Tag.ToString() ? true : false) : true)
                        {
                            foreach (tbl_scsLoanIn_Detail detail in tbl_scsLoanIn_Detail.SelectAllByLoanIn_ID(oHeader.LoanIn_ID))
                            {
                                if (bItemSelected ? (detail.Item_ID == txtItemID.Tag.ToString() && txtItemSubCategory.Tag.ToString() == detail.ItemSubCategory_ID &&
                                       txtItemSubCategory.Text.Trim() == detail.ItemSubCategory2_ID && txtItemSerialNo.Tag.ToString() == detail.ItemSerialNo &&
                                       txtItemSerialNo.Text == detail.ItemSerialNo2 ? true : false) : true)
                                {
                                    decimal dQty = detail.Qty, dWeight = detail.Weight;
                                    tbl_tmpStockTracking oTracking = new tbl_tmpStockTracking(oHeader.LoanIn_ID, oHeader.LoanInDate, oHeader.Store_ID, detail.Item_ID,
                                        detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2,
                                        0, 0, 0, 0, 0, 0, 0, 0, dQty, 0, 0, 0, 0, 0, dQty, 0, 0, 0, 0, 0, 0, 0, 0, dWeight, 0, 0, 0, 0, 0, dWeight);
                                    glb_oStockTracking.Add(oTracking);
                                }
                            }
                        }
                    }

                    foreach (tbl_scsLoanOut oHeader in tbl_scsLoanOut.SelectAll().Where(p => !p.IsDeleted && p.LoanOut_ID != "default" &&
                       p.LoanOutDate.Date >= dtpFrom.Value.Date && p.LoanOutDate.Date <= dtpTo.Value.Date))
                    {
                        if (bStoreSelected ? (oHeader.Store_ID == txtStoreID.Tag.ToString() ? true : false) : true)
                        {
                            foreach (tbl_scsLoanOut_Detail detail in tbl_scsLoanOut_Detail.SelectAllByLoanOut_ID(oHeader.LoanOut_ID))
                            {
                                if (bItemSelected ? (detail.Item_ID == txtItemID.Tag.ToString() && txtItemSubCategory.Tag.ToString() == detail.ItemSubCategory_ID &&
                                       txtItemSubCategory.Text.Trim() == detail.ItemSubCategory2_ID && txtItemSerialNo.Tag.ToString() == detail.ItemSerialNo &&
                                       txtItemSerialNo.Text == detail.ItemSerialNo2 ? true : false) : true)
                                {
                                    decimal dQty = detail.Qty, dWeight = detail.Weight;
                                    tbl_tmpStockTracking oTracking = new tbl_tmpStockTracking(oHeader.LoanOut_ID, oHeader.LoanOutDate, oHeader.Store_ID, detail.Item_ID,
                                        detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2,
                                        0, 0, 0, 0, 0, 0, 0, 0, 0, -dQty, 0, 0, 0, 0, -dQty, 0, 0, 0, 0, 0, 0, 0, 0, 0, -dWeight, 0, 0, 0, 0, -dWeight);
                                    glb_oStockTracking.Add(oTracking);
                                }
                            }
                        }
                    }
                }
                #endregion

                #region Purchase Return Note
                if (chkPRN.Checked)
                {
                    foreach (tbl_scsPurchaseReturnedNote oHeader in tbl_scsPurchaseReturnedNote.SelectAll().Where(p => !p.IsDeleted && p.PurchaseReturnedNote_ID != "default" &&
                         p.PurchaseReturnedNoteDate.Date >= dtpFrom.Value.Date && p.PurchaseReturnedNoteDate.Date <= dtpTo.Value.Date))
                    {
                        if (bStoreSelected ? (oHeader.Store_ID == txtStoreID.Tag.ToString() ? true : false) : true)
                        {
                            foreach (tbl_scsPurchaseReturnedNote_Detail detail in tbl_scsPurchaseReturnedNote_Detail.SelectAllByPurchaseReturnedNote_ID(oHeader.PurchaseReturnedNote_ID))
                            {
                                if (bItemSelected ? (detail.Item_ID == txtItemID.Tag.ToString() && txtItemSubCategory.Tag.ToString() == detail.ItemSubCategory_ID &&
                                       txtItemSubCategory.Text.Trim() == detail.ItemSubCategory2_ID && txtItemSerialNo.Tag.ToString() == detail.ItemSerialNo &&
                                       txtItemSerialNo.Text == detail.ItemSerialNo2 ? true : false) : true)
                                {
                                    decimal dQty = detail.Qty, dWeight = detail.Weight;
                                    tbl_tmpStockTracking oTracking = new tbl_tmpStockTracking(oHeader.PurchaseReturnedNote_ID, oHeader.PurchaseReturnedNoteDate, oHeader.Store_ID, detail.Item_ID,
                                        detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2,
                                        0, -dQty, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -dQty, 0, -dWeight, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -dWeight);
                                    glb_oStockTracking.Add(oTracking);
                                }
                            }
                        }
                    }
                }
                #endregion

                #region Item Split Note From/To
                if (chkSPL.Checked)
                {
                    foreach (tbl_scsItemSpred oHeader in tbl_scsItemSpred.SelectAll().Where(p => !p.IsDeleted && p.ItemSpred_ID != "default" &&
                        p.ItemSpredDate.Date >= dtpFrom.Value.Date && p.ItemSpredDate.Date <= dtpTo.Value.Date))
                    {
                        if (bStoreSelected ? ("default" == txtStoreID.Tag.ToString() ? true : false) : true)
                        {
                            foreach (tbl_scsItemSpred_Detail_From detail in tbl_scsItemSpred_Detail_From.SelectAllByItemSpred_ID(oHeader.ItemSpred_ID))
                            {
                                if (bItemSelected ? (detail.Item_ID == txtItemID.Tag.ToString() && txtItemSubCategory.Tag.ToString() == detail.ItemSubCategory_ID &&
                                       txtItemSubCategory.Text.Trim() == detail.ItemSubCategory2_ID && txtItemSerialNo.Tag.ToString() == detail.ItemSerialNo &&
                                       txtItemSerialNo.Text == detail.ItemSerialNo2 ? true : false) : true)
                                {
                                    decimal dQty = detail.Qty, dWeight = detail.Weight;
                                    tbl_tmpStockTracking oTracking = new tbl_tmpStockTracking(oHeader.ItemSpred_ID, oHeader.ItemSpredDate, "default", detail.Item_ID,
                                        detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2,
                                        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -dQty, 0, 0, 0, -dQty, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -dWeight, 0, 0, 0, -dWeight);
                                    glb_oStockTracking.Add(oTracking);
                                }
                            }
                            foreach (tbl_scsItemSpred_Detail_To detail in tbl_scsItemSpred_Detail_To.SelectAllByItemSpred_ID(oHeader.ItemSpred_ID))
                            {
                                if (bItemSelected ? (detail.Item_ID == txtItemID.Tag.ToString() && txtItemSubCategory.Tag.ToString() == detail.ItemSubCategory_ID &&
                                       txtItemSubCategory.Text.Trim() == detail.ItemSubCategory2_ID && txtItemSerialNo.Tag.ToString() == detail.ItemSerialNo &&
                                       txtItemSerialNo.Text == detail.ItemSerialNo2 ? true : false) : true)
                                {
                                    decimal dQty = detail.Qty, dWeight = detail.Weight;
                                    tbl_tmpStockTracking oTracking = new tbl_tmpStockTracking(oHeader.ItemSpred_ID, oHeader.ItemSpredDate, "default", detail.Item_ID,
                                        detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2,
                                        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, dQty, 0, 0, dQty, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, dWeight, 0, 0, dWeight);
                                    glb_oStockTracking.Add(oTracking);
                                }
                            }
                        }
                    }                    
                }
                #endregion
              
                #endregion


                FillHaderTable(glb_oStockTracking);

                //foreach (tbl_tmpStockTracking oTracking in glb_oStockTracking)
                //{ 
                ////glb_scs_Stock_Statement.Stock_Statement.AddStock_StatementRow(oTracking.TransactionDate,"",fa
                //}

            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void FillHaderTable(List<tbl_tmpStockTracking> oStockTrackingList)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Rows.Clear();
                int iRow;

                foreach (var oStockTracking in oStockTrackingList.GroupBy(grp => new { grp.Item_ID, grp.ItemSubcategory_ID, grp.ItemSubcategory_ID2, grp.ItemSerial1, grp.ItemSerial2 }, (Key, group) =>
                    new
                    {
                        ItemID = Key.Item_ID,
                        ItemSubCategoryID = Key.ItemSubcategory_ID,
                        ItemSubCategoryID2 = Key.ItemSubcategory_ID2,
                        ItemSerialNo = Key.ItemSerial1,
                        ItemSerialNo2 = Key.ItemSerial2,
                        qtyGRN = group.Sum(p => p.QtyGRN),
                        qtyPRN = group.Sum(p => p.QtyPRN),
                        qtySRN = group.Sum(p => p.QtySRN),
                        qtySAN = group.Sum(p => p.QtySAN),
                        qtyDGN = group.Sum(p => p.QtyDGN),
                        qtyDIS = group.Sum(p => p.QtyDIS),
                        qtyiGIN = group.Sum(p => p.QtyiGIN),
                        qtyiGRN = group.Sum(p => p.QtyiGRN),
                        qtyLIn = group.Sum(p => p.QtyLIn),
                        qtyLOut = group.Sum(p => p.QtyLOut),
                        qtyISPIn = group.Sum(p => p.QtyISPIn),
                        qtyISPOut = group.Sum(p => p.QtyISPOut),
                        qtyFGTN = group.Sum(p => p.QtyFGTN),
                        qtyDO = group.Sum(p => p.QtyDO),
                        qtyTotal = group.Sum(p => p.QtyTotal),
                        weightGRN = group.Sum(p => p.WeightGRN),
                        weightPRN = group.Sum(p => p.WeightPRN),
                        weightSRN = group.Sum(p => p.WeightSRN),
                        weightSAN = group.Sum(p => p.WeightSAN),
                        weightDGN = group.Sum(p => p.WeightDGN),
                        weightDIS = group.Sum(p => p.WeightDIS),
                        weightiGIN = group.Sum(p => p.WeightiGIN),
                        weightiGRN = group.Sum(p => p.WeightiGRN),
                        weightLIn = group.Sum(p => p.WeightLIn),
                        weightLOut = group.Sum(p => p.WeightLOut),
                        weightISPIn = group.Sum(p => p.WeightISPIn),
                        weightISPOut = group.Sum(p => p.WeightISPOut),
                        weightFGTN = group.Sum(p => p.WeightFGTN),
                        weightDO = group.Sum(p => p.WeightDO),
                        weightTotal = group.Sum(p => p.WeightTotal)
                    }))
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;

                    decimal dFloorStockBalance = 0;
                    if (txtStoreID.Tag != null && txtStoreID.Tag.ToString().Trim().Length > 0 && txtStoreID.Tag.ToString().Trim() != "default")
                    {
                        tbl_genStore_Stock oStock = tbl_genStore_Stock.Select(txtStoreID.Tag.ToString(), oStockTracking.ItemID, "default", oStockTracking.ItemSubCategoryID, oStockTracking.ItemSubCategoryID2, oStockTracking.ItemSerialNo, oStockTracking.ItemSerialNo2);
                        if (oStock != null)
                            dFloorStockBalance = oStock.Weight != 0 ? oStock.Weight : oStock.Qty;
                    }
                    else
                    {
                        foreach (tbl_genStore_Stock oStock in tbl_genStore_Stock.SelectAllByItem_ID(oStockTracking.ItemID).Where(p=> p.ItemSubCategory_ID == oStockTracking.ItemSubCategoryID && p.ItemSubCategory2_ID == oStockTracking.ItemSubCategoryID2 && p.ItemSerialNo == oStockTracking.ItemSerialNo && p.ItemSerialNo2 == oStockTracking.ItemSerialNo2))
                            dFloorStockBalance += oStock.Weight != 0 ? oStock.Weight : oStock.Qty;
                    }

                    Fill_Datagrid(iRow, oStockTracking.ItemID, oStockTracking.ItemSubCategoryID, oStockTracking.ItemSubCategoryID2, oStockTracking.ItemSerialNo, oStockTracking.ItemSerialNo2,
                        oStockTracking.qtyGRN, oStockTracking.qtyPRN, oStockTracking.qtySRN, oStockTracking.qtySAN, oStockTracking.qtyDGN, oStockTracking.qtyDIS, oStockTracking.qtyiGIN, oStockTracking.qtyiGRN,
                        oStockTracking.qtyLIn, oStockTracking.qtyLOut, oStockTracking.qtyISPIn, oStockTracking.qtyISPOut, oStockTracking.qtyFGTN, oStockTracking.qtyDO, oStockTracking.qtyTotal,
                        oStockTracking.weightGRN, oStockTracking.weightPRN, oStockTracking.weightSRN, oStockTracking.weightSAN, oStockTracking.weightDGN, oStockTracking.weightDIS, oStockTracking.weightiGIN, oStockTracking.weightiGRN,
                        oStockTracking.weightLIn, oStockTracking.weightLOut, oStockTracking.weightISPIn, oStockTracking.weightISPOut, oStockTracking.weightFGTN, oStockTracking.weightDO, oStockTracking.weightTotal, dFloorStockBalance);

           
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, string ItemID, string ItemSubCategoryID, string ItemSubCategoryID2, string SerialNo, string SerialNo2,
            decimal qtyGRN, decimal qtyPRN, decimal qtySRN, decimal qtySAN, decimal qtyDGN, decimal qtyDIS, decimal qtyiGIN, decimal qtyiGRN,
            decimal qtyLIn, decimal qtyLOut, decimal qtyISPIn, decimal qtyISPOut, decimal qtyFGTN, decimal qtyDO, decimal qtyTotal,
            decimal weightGRN, decimal weightPRN, decimal weightSRN, decimal weightSAN, decimal weightDGN, decimal weightDIS, decimal weightiGIN, decimal weightiGRN,
            decimal weightLIn, decimal weightLOut, decimal weightISPIn, decimal weightISPOut, decimal weightFGTN, decimal weightDO, decimal weightTotal, decimal FloorStockBalance)
        {
            try
            {               
                if (qtyTotal != 0)
                {
                    dgvDetail["ItemCode", iRow].Value = ItemID;
                    dgvDetail["ItemName", iRow].Value = clsGenaralName.getName_Item(ItemID);
                    dgvDetail["ItemSubCategoryID", iRow].Tag = ItemSubCategoryID;
                    dgvDetail["ItemSubCategoryID", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(ItemSubCategoryID));
                    dgvDetail["ItemSubCategoryID2", iRow].Tag = ItemSubCategoryID2;
                    dgvDetail["ItemSubCategoryID2", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory2(ItemSubCategoryID2));
                    dgvDetail["ItemSerialNo", iRow].Value = SerialNo;
                    dgvDetail["ItemSerialNo2", iRow].Value = SerialNo2;

                    dgvDetail["qtyTotal", iRow].Value = clsFormatter.FormatZeroValueToDash(qtyTotal, 0);
                    dgvDetail["qtyGRN", iRow].Value = clsFormatter.FormatZeroValueToDash(qtyGRN, 0);
                    dgvDetail["qtyPRN", iRow].Value = clsFormatter.FormatZeroValueToDash(qtyPRN, 0);
                    dgvDetail["qtySRN", iRow].Value = clsFormatter.FormatZeroValueToDash(qtySRN, 0);
                    dgvDetail["qtySAN", iRow].Value = clsFormatter.FormatZeroValueToDash(qtySAN, 0);
                    dgvDetail["qtyDGN", iRow].Value = clsFormatter.FormatZeroValueToDash(qtyDGN, 0);
                    dgvDetail["qtyDIS", iRow].Value = clsFormatter.FormatZeroValueToDash(qtyDIS, 0);
                    dgvDetail["qtyiGIN", iRow].Value = clsFormatter.FormatZeroValueToDash(qtyiGIN, 0);
                    dgvDetail["qtyiGRN", iRow].Value = clsFormatter.FormatZeroValueToDash(qtyiGRN, 0);
                    dgvDetail["qtyLIn", iRow].Value = clsFormatter.FormatZeroValueToDash(qtyLIn, 0);
                    dgvDetail["qtyLOut", iRow].Value = clsFormatter.FormatZeroValueToDash(qtyLOut, 0);
                    dgvDetail["qtyISPIn", iRow].Value = clsFormatter.FormatZeroValueToDash(qtyISPIn, 0);
                    dgvDetail["qtyISPOut", iRow].Value = clsFormatter.FormatZeroValueToDash(qtyISPOut, 0);
                    dgvDetail["qtyFGTN", iRow].Value = clsFormatter.FormatZeroValueToDash(qtyFGTN, 0);
                    dgvDetail["qtyDO", iRow].Value = clsFormatter.FormatZeroValueToDash(qtyDO, 0);

                    dgvDetail["weightTotal", iRow].Value = clsFormatter.FormatZeroValueToDash(weightTotal, 2);
                    dgvDetail["weightGRN", iRow].Value = clsFormatter.FormatZeroValueToDash(weightGRN, 2);
                    dgvDetail["weightPRN", iRow].Value = clsFormatter.FormatZeroValueToDash(weightPRN, 2);
                    dgvDetail["weightSRN", iRow].Value = clsFormatter.FormatZeroValueToDash(weightSRN, 2);
                    dgvDetail["weightSAN", iRow].Value = clsFormatter.FormatZeroValueToDash(weightSAN, 2);
                    dgvDetail["weightDGN", iRow].Value = clsFormatter.FormatZeroValueToDash(weightDGN, 2);
                    dgvDetail["weightDIS", iRow].Value = clsFormatter.FormatZeroValueToDash(weightDIS, 2);
                    dgvDetail["weightiGIN", iRow].Value = clsFormatter.FormatZeroValueToDash(weightiGIN, 2);
                    dgvDetail["weightiGRN", iRow].Value = clsFormatter.FormatZeroValueToDash(weightiGRN, 2);
                    dgvDetail["weightLIn", iRow].Value = clsFormatter.FormatZeroValueToDash(weightLIn, 2);
                    dgvDetail["weightLOut", iRow].Value = clsFormatter.FormatZeroValueToDash(weightLOut, 2);
                    dgvDetail["weightISPIn", iRow].Value = clsFormatter.FormatZeroValueToDash(weightISPIn, 2);
                    dgvDetail["weightISPOut", iRow].Value = clsFormatter.FormatZeroValueToDash(weightISPOut, 2);
                    dgvDetail["weightFGTN", iRow].Value = clsFormatter.FormatZeroValueToDash(weightFGTN, 2);
                    dgvDetail["weightDO", iRow].Value = clsFormatter.FormatZeroValueToDash(weightDO, 2);
                }
                else
                    dgvDetail.Rows.RemoveAt(iRow);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Create Data Tables
        private void CreateDataTable_Detail()
        {
            dtAllDetailRecodes.Columns.Clear();
            dtAllDetailRecodes.Columns.Add("NoteDate", typeof(DateTime));
            dtAllDetailRecodes.Columns.Add("table_ID", typeof(string));
            dtAllDetailRecodes.Columns.Add("isDeleted", typeof(bool));

            dtAllDetailRecodes.Columns.Add("store_ID", typeof(string));
            dtAllDetailRecodes.Columns.Add("item_ID", typeof(string));
            dtAllDetailRecodes.Columns.Add("item_Name", typeof(string));
            dtAllDetailRecodes.Columns.Add("itemSubCategory_Name", typeof(string));
            dtAllDetailRecodes.Columns.Add("itemSubCategory_ID", typeof(string));
            dtAllDetailRecodes.Columns.Add("itemSubCategory2_ID", typeof(string));
            dtAllDetailRecodes.Columns.Add("itemSerialNo", typeof(string));
            dtAllDetailRecodes.Columns.Add("itemSerialNo2", typeof(string));

            dtAllDetailRecodes.Columns.Add("GRNqty", typeof(decimal));
            dtAllDetailRecodes.Columns.Add("COqty", typeof(decimal));
            dtAllDetailRecodes.Columns.Add("DOqty", typeof(decimal));
            dtAllDetailRecodes.Columns.Add("SRNqty", typeof(decimal));
            dtAllDetailRecodes.Columns.Add("AdjustmentQty", typeof(decimal));
            dtAllDetailRecodes.Columns.Add("DGNqty", typeof(decimal));
            dtAllDetailRecodes.Columns.Add("DGNDSqty", typeof(decimal));
            dtAllDetailRecodes.Columns.Add("iGRN", typeof(decimal));
            dtAllDetailRecodes.Columns.Add("iGIN", typeof(decimal));
            dtAllDetailRecodes.Columns.Add("QTY", typeof(decimal));
        }

        private void CreateDataTable_Header()
        {
            dtAllHeaderRecodes.Columns.Clear();

            dtAllHeaderRecodes.Columns.Add("store_ID", typeof(string));
            dtAllHeaderRecodes.Columns.Add("StoreName", typeof(string));
            dtAllHeaderRecodes.Columns.Add("item_ID", typeof(string));
            dtAllHeaderRecodes.Columns.Add("item_Name", typeof(string));
            dtAllHeaderRecodes.Columns.Add("itemSubCategory_Name", typeof(string));
            dtAllHeaderRecodes.Columns.Add("itemSubCategory_ID", typeof(string));
            dtAllHeaderRecodes.Columns.Add("itemSubCategory2_ID", typeof(string));
            dtAllHeaderRecodes.Columns.Add("itemSerialNo", typeof(string));
            dtAllHeaderRecodes.Columns.Add("itemSerialNo2", typeof(string));

            dtAllHeaderRecodes.Columns.Add("GRNqty", typeof(decimal));
            dtAllHeaderRecodes.Columns.Add("COqty", typeof(decimal));
            dtAllHeaderRecodes.Columns.Add("DOqty", typeof(decimal));
            dtAllHeaderRecodes.Columns.Add("SRNqty", typeof(decimal));
            dtAllHeaderRecodes.Columns.Add("AdjustmentQty", typeof(decimal));
            dtAllHeaderRecodes.Columns.Add("DGNqty", typeof(decimal));
            dtAllHeaderRecodes.Columns.Add("DGNDSqty", typeof(decimal));
            dtAllHeaderRecodes.Columns.Add("iGRN", typeof(decimal));
            dtAllHeaderRecodes.Columns.Add("iGIN", typeof(decimal));
            dtAllHeaderRecodes.Columns.Add("QTY", typeof(decimal));
            dtAllHeaderRecodes.Columns.Add("StoreQTY", typeof(decimal));
            dtAllHeaderRecodes.Columns.Add("WeightedAverageCostPrice", typeof(decimal));
            dtAllHeaderRecodes.Columns.Add("HighestPurchaseCostPrice", typeof(decimal));

        }
        #endregion


        #region Event DoubleClick
        private void txtStoreID_DoubleClick(object sender, EventArgs e)
        {
            SearchStore();
        }
        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            SearchItem();
        }
        private void txtItemCategory_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterItemCategory(ref txtItemCategory);
        }
        #endregion

        #region Event KeyDown
        private void txtStoreID_KeyDown(object sender, KeyEventArgs e)
        {
            SearchStore();
        }
        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            SearchItem();
        }
        private void txtItemCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterItemCategory(ref txtItemCategory);
            }
        }
        #endregion

        #region Events DataGrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellContentDoubleClick(sender, e);
        }
        #endregion

        #region  Event ValueChanged
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            //string sFinalQuary = "";
            //sFinalQuary = "NoteDate >= '" + dtpFrom.Value.Date.ToShortDateString() + " 12:00:00AM' AND NoteDate <='" + dtpTo.Value.Date.ToShortDateString() + " 11:59:00PM'";
            //Detailsource.Filter = sFinalQuary;
            //FillHaderTable();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            //string sFinalQuary = "";
            //sFinalQuary = " NoteDate >= '" + dtpFrom.Value.Date.ToShortDateString() + " 12:00:00AM' AND NoteDate <='" + dtpTo.Value.Date.ToShortDateString() + " 11:59:00PM'";
            //Detailsource.Filter = sFinalQuary;
            //FillHaderTable();
        }


        #endregion

        #region Event Cell Double click
        private void dgvDetail_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (e.RowIndex >= 0)
                {
                    string sitem_ID, sitemSubCategory_ID, sitemSubCategory2_ID, sitemSerialNo, sitemSerialNo2; 
                    sitem_ID = dgvDetail["ItemCode", e.RowIndex].Value.ToString();
                    sitemName = dgvDetail["item_Name", e.RowIndex].Value.ToString();                   
                    sitemSubCategory_ID = dgvDetail["itemSubCategory_ID", e.RowIndex].Value.ToString();
                    sitemSubCategory2_ID = dgvDetail["itemSubCategory2_ID", e.RowIndex].Value.ToString();
                    sitemSerialNo = dgvDetail["itemSerialNo", e.RowIndex].Value.ToString();
                    sitemSerialNo2 = dgvDetail["itemSerialNo2", e.RowIndex].Value.ToString();

                    if (sitem_ID.Length > 0)
                    {
                        //List<tbl_tmpStockTransactionNote> oStockTransactionList = new List<tbl_tmpStockTransactionNote>();
                        //foreach (tbl_tmpStockTracking oStockTracking in glb_oStockTracking.Where(p=> p.Item_ID == sitem_ID && p.ItemSubcategory_ID == sitemSubCategory_ID && 
                        //    p.ItemSubcategory_ID2 == sitemSubCategory2_ID && p.ItemSerial1 == sitemSerialNo && p.ItemSerial2 == sitemSerialNo2))
                        //{
                        //    tbl_tmpStockTransactionNote oStockTransation = new tbl_tmpStockTransactionNote(oStockTracking.Transaction_ID, oStockTracking.TransactionDate, oStockTracking.QtyTotal); 
                        //    oStockTransactionList.Add(oStockTransation); 
                        //}

                        //frm_rpt_StockTransaction detail = new frm_rpt_StockTransaction();
                        //detail.glb_tbl_tmpStockTransactionNote = oStockTransactionList;
                        //detail.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion



        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtItemID);
                clsCommon.ValidateForeignKey(ref txtStoreID);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Search Methods
        private void SearchStore()
        {
            clsSearch.Search_MasterStore(ref txtStoreID, true);
        }
        private void SearchItem()
        {
            clsHelpMethods_Local.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
        } 
        #endregion

        

       

       
    }
}
