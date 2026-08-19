using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Digiteq.DataSets.SCS;
using Digiteq.Reports.SCS.Registry;
using DataTire;
using Digiteq_Logic;
using Digiteq.DataSets;


namespace Digiteq
{
    public partial class frm_rpt_StockRegister : MettroForm
    {
        #region Variables
        //form manage
        public int iFormID;

        //for security handle
        //public bool bNoAccess, bDepartmetSelected, bStoreSelected, bSectionSelected;
        public bool bNoAccess, bDepartmetSelected, bSectionSelected;
        bool bStoreSelected = false;

        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        dts_scsPurchaseOrder glb_dts_scsPurchaseOrder = new dts_scsPurchaseOrder();
        dts_scsStockAdjustment glb_dts_scsStockAdjustment = new dts_scsStockAdjustment();
        dts_scs_FDTN glb_dts_scsFGTN = new dts_scs_FDTN();
        dts_scsGoodTransferNote glb_dtsScsGoodTransferNote = new dts_scsGoodTransferNote();
        dts_scsGoodReceivedNote_Gems glb_dtsScsGoodReceivedNote_Gem = new dts_scsGoodReceivedNote_Gems();
        dts_scs_PurchaseRetNote glb_dtsScsPurchaseRetNote = new dts_scs_PurchaseRetNote();
        __dts_scsStoreGoodsIssueNote glb_dts_scsStoreGoodsIssueNote = new __dts_scsStoreGoodsIssueNote();
        dts_scsStoreGoodsReceiveNote glb_dts_scsStoreGoodsReceiveNote = new dts_scsStoreGoodsReceiveNote();
        dts_Stock glb_dts_Stock = new dts_Stock();
        dt_scsSplitNote glb_dts_SplitNote = new dt_scsSplitNote();
        dts_scsDiscardedItemNote glb_dts_DIN = new dts_scsDiscardedItemNote();
        dts_scsExternalGoodIssueNote glb_dtsExternalGoodIssueNote = new dts_scsExternalGoodIssueNote();
        dt_scsSplitNote glb_dtsSplitNote = new dt_scsSplitNote();
        dts_scsPurchaseRequisitionNote glb_dtsPurchaseRequisitionNote = new dts_scsPurchaseRequisitionNote();
        dts_scsDamageGoods glb_dtsDamageGoods = new dts_scsDamageGoods();
        dts_scsStoreRequisitionNote glb_dtsStoreRequisition = new dts_scsStoreRequisitionNote();



        private int iReportNo;
        #endregion

        #region Form Load
        public frm_rpt_StockRegister()
        {
            iFormID = clsSecurity.getFormID(FormName.StockRegisterReport);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_rpt_StockRegister_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Stock Register", 2, iFormID);
            ThemeColor = clsFormatter.colorStock;

            clearField();
            DisplayReports();
        }
        #endregion

        #region Display Reports
        private void DisplayReports()
        {
            try
            {
                dgvReports.Rows.Clear();
                dgvReports.DataSource = DBHandling.ExecQuery("EXEC sp_Reports '" + 7 + "'").Tables[0];
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedCells.Count != 0)
            {
                if (dgvReports.Rows.Count > 0)
                {
                    try
                    {
                        //bool bPermission = false;
                        int iRow = dgvReports.SelectedCells[0].RowIndex;
                        int iReport = int.Parse(dgvReports.Rows[iRow].Cells[0].Value.ToString());
                        enum_ReportName Report = (enum_ReportName)iReport;

                        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(Report)))
                        {
                            string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                            if (clsHelpMethods.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                            {
                                #region Variables
                                //get selection controls
                                bool bStoreSelected = false;
                                bool bSectionSelected = false;
                                bool bDepartmetSelected = false;
                                bool bCustomerSelected = false;
                                bool bSupplierSelected = false;
                                bool bItemIDSelected = false;
                                bool bStockNoteType = false;
                                string sFilter = "", sFormula = "";
                                #endregion

                                #region Filters
                                string sDaterange = "From " + dtpFrom.Value.Date.ToString("dd-MMM-yyyy") + " TO " + dtpTo.Value.Date.ToString("dd-MMM-yyyy");

                                if (txtStore.Tag != null && txtStore.Tag.ToString().Length > 0)
                                    bStoreSelected = true;

                                if (txtSection.Tag != null && txtSection.Tag.ToString().Length > 0)
                                    bSectionSelected = true;

                                if (txtDepartment.Tag != null && txtDepartment.Tag.ToString().Length > 0)
                                    bDepartmetSelected = true;

                                if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Length > 0)
                                    bCustomerSelected = true;

                                if (txtSupplier.Tag != null && txtSupplier.Tag.ToString().Length > 0)
                                    bSupplierSelected = true;

                                if (txtItemID.Tag != null && txtItemID.Tag.ToString().Length > 0)
                                    bItemIDSelected = true;

                                if (txtStockNoteType.Tag != null && txtStockNoteType.Tag.ToString().Length > 0)
                                    bStockNoteType = true;

                                #endregion

                                #region Selected Filters
                                if (bItemIDSelected)
                                    sFilter = " " + lblItemID.Text + " : " + txtItemID.Text.Trim();
                                if (bStoreSelected)
                                    sFilter += (sFilter != "" ? " | " : "") + " " + lblStore.Text + " : " + txtStore.Text.Trim();
                                if (bDepartmetSelected)
                                    sFilter += (sFilter != "" ? " | " : "") + " " + lblDepartment.Text + " : " + txtDepartment.Text.Trim();
                                if (bSectionSelected)
                                    sFilter += (sFilter != "" ? " | " : "") + " " + lblSection.Text + " : " + txtSection.Text.Trim();
                                if (bStockNoteType)
                                    sFilter += (sFilter != "" ? " | " : "") + " " + lblNoteType.Text + " :" + txtStockNoteType.Text;
                                if (bCustomerSelected)
                                    sFilter += (sFilter != "" ? " | " : "") + " " + lblCustomer.Text + " : " + txtCustomer.Text.Trim();
                                if (bSupplierSelected)
                                    sFilter += (sFilter != "" ? " | " : "") + " " + lblSupplier.Text + " : " + txtSupplier.Text.Trim();

                                if (rdoDeleted.Checked)
                                    sFilter += (sFilter != "" ? " | " : "") + "Cancelled Records Only ";
                                if (rdoActual.Checked)
                                    sFilter += (sFilter != "" ? " | " : "") + "Active records Only ";
                                if (rdoAll.Checked)
                                    sFilter += (sFilter != "" ? " | " : "") + "All Records ";
                                #endregion

                                #region Loan In & Out
                                //if (Report == enum_ReportName.RG_LoanIN || Report == enum_ReportName.RG_LoanOut)
                                ////if (rdoLoanOut.Checked || rdoLoanIn.Checked)
                                //{
                                //    try
                                //    {
                                //        Cursor = Cursors.WaitCursor;
                                //        glb_dts_Stock.Clear();

                                //        #region Loan Out
                                //        if (Report == enum_ReportName.RG_LoanOut)
                                //        {
                                //            foreach (tbl_scsLoanOut oLoan in tbl_scsLoanOut.SelectAll().Where(p => p.LoanOutDate.Date >= dtpFrom.Value.Date && p.LoanOutDate.Date <= dtpTo.Value.Date))
                                //            {
                                //                if (rdoDeleted.Checked && !oLoan.IsDeleted)
                                //                    continue;
                                //                else if (rdoActual.Checked && oLoan.IsDeleted)
                                //                    continue;

                                //                if (txtCustomer.Tag != null && oLoan.Customer_ID != txtCustomer.Tag.ToString())
                                //                    continue;
                                //                if (txtSupplier.Tag != null && oLoan.Supplier_ID != txtSupplier.Tag.ToString())
                                //                    continue;

                                //                string sReceiverName = "", sReceiverCode = "";
                                //                if (oLoan.IsForCustomer)
                                //                {
                                //                    sReceiverName = oLoan.Customer_ID != "default" ? clsGenaralName.getName_Customer(oLoan.Customer_ID) : "";
                                //                    sReceiverCode = oLoan.Customer_ID;
                                //                }
                                //                else if (oLoan.IsForSupplier)
                                //                {
                                //                    sReceiverName = oLoan.Supplier_ID != "default" ? clsGenaralName.getName_Supplier(oLoan.Supplier_ID) : "";
                                //                    sReceiverCode = oLoan.Supplier_ID;
                                //                }
                                //                else if (oLoan.IsForOther)
                                //                    sReceiverName = oLoan.ReceiverName;

                                //                foreach (tbl_scsLoanOut_Detail oDetail in tbl_scsLoanOut_Detail.SelectAllByLoanOut_ID(oLoan.LoanOut_ID))
                                //                {
                                //                    if (txtItemID.Tag != null && oDetail.Item_ID != txtItemID.Tag.ToString())
                                //                        continue;

                                //                    glb_dts_Stock.Loan_In_Out_Report.AddLoan_In_Out_ReportRow(oLoan.LoanOut_ID, oLoan.LoanOutDate, sReceiverCode, sReceiverName, oDetail.Item_ID, clsGenaralName.getName_Item(oDetail.Item_ID), oDetail.Qty > 0 ? oDetail.Qty : (oDetail.Weight > 0 ? oDetail.Weight : oDetail.Qty));
                                //                }
                                //            }



                                //            glb_dts_Stock.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Loan Out Report", "", sDaterange, clsSecurity.UserNameLoged, sFilter);
                                //            //iReportNo = (int)enum_ReportName.RG_InquirySummary;
                                //            print("\\reports\\SCS\\Registry\\rpt_scsLoanOut.rpt", "Loan Out Report", "", "", glb_dts_Stock);
                                //        }

                                //        #endregion

                                //        #region Loan In
                                //        else if (Report == enum_ReportName.RG_LoanIN)
                                //        {
                                //            foreach (tbl_scsLoanIn oLoan in tbl_scsLoanIn.SelectAll().Where(p => p.LoanInDate.Date >= dtpFrom.Value.Date && p.LoanInDate.Date <= dtpTo.Value.Date))
                                //            {
                                //                if (rdoDeleted.Checked && !oLoan.IsDeleted)
                                //                    continue;
                                //                else if (rdoActual.Checked && oLoan.IsDeleted)
                                //                    continue;
                                //                if (txtCustomer.Tag != null && oLoan.Customer_ID != txtCustomer.Tag.ToString())
                                //                    continue;
                                //                if (txtSupplier.Tag != null && oLoan.Supplier_ID != txtSupplier.Tag.ToString())
                                //                    continue;
                                //                string sReceiverName = "", sReceiverCode = "";
                                //                if (oLoan.IsForCustomer)
                                //                {
                                //                    sReceiverName = oLoan.Customer_ID != "default" ? clsGenaralName.getName_Customer(oLoan.Customer_ID) : "";
                                //                    sReceiverCode = oLoan.Customer_ID;
                                //                }
                                //                else if (oLoan.IsForSupplier)
                                //                {
                                //                    sReceiverName = oLoan.Supplier_ID != "default" ? clsGenaralName.getName_Supplier(oLoan.Supplier_ID) : "";
                                //                    sReceiverCode = oLoan.Supplier_ID;
                                //                }
                                //                else if (oLoan.IsForOther)
                                //                    sReceiverName = oLoan.ReceiverName;

                                //                foreach (tbl_scsLoanIn_Detail oDetail in tbl_scsLoanIn_Detail.SelectAllByLoanIn_ID(oLoan.LoanIn_ID))
                                //                {
                                //                    if (txtItemID.Tag != null && oDetail.Item_ID != txtItemID.Tag.ToString())
                                //                        continue;

                                //                    glb_dts_Stock.Loan_In_Out_Report.AddLoan_In_Out_ReportRow(oLoan.LoanIn_ID, oLoan.LoanInDate, sReceiverCode, sReceiverName, oDetail.Item_ID, clsGenaralName.getName_Item(oDetail.Item_ID), oDetail.Qty > 0 ? oDetail.Qty : (oDetail.Weight > 0 ? oDetail.Weight : oDetail.Qty));
                                //                }
                                //            }
                                //            if (rdoDeleted.Checked)
                                //                sFilter += (sFilter != "" ? " | " : "") + "Cancelled Records Only ";
                                //            if (rdoActual.Checked)
                                //                sFilter += (sFilter != "" ? " | " : "") + "Active records Only ";
                                //            if (rdoAll.Checked)
                                //                sFilter += (sFilter != "" ? " | " : "") + "All Records ";
                                //            glb_dts_Stock.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Loan In Report", "", sDaterange, clsSecurity.UserNameLoged, sFilter);
                                //            //iReportNo = (int)enum_ReportName.RG_InquirySummary;
                                //            print("\\reports\\SCS\\Registry\\rpt_scsLoanIn.rpt", "Loan In Report", "", "", glb_dts_Stock);

                                //        }
                                //        #endregion
                                //    }
                                //    catch (Exception ex)
                                //    {
                                //        clsValidate.WriteErrorLog("", iFormID,ex);
                                //        SEACCException.Show(ex);
                                //    }
                                //    finally
                                //    {
                                //        Cursor = Cursors.Default;
                                //        glb_dts_Stock.Clear();
                                //    }
                                //}
                                #endregion

                                #region GRN Detail
                                if (Report == enum_ReportName.RG_GRNDetail)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;

                                        glb_dtsScsGoodReceivedNote_Gem.Clear();
                                        glb_dtsReportExport.Clear();

                                        #region GRN_Registry_Detail
                                        foreach (tbl_scsExternalGoodReceivedNote oGRN in tbl_scsExternalGoodReceivedNote.SelectAll().Where(p => p.ExternalGoodReceivedNote_ID != "default" && p.ExternalGoodReceivedNoteDate.Date >= dtpFrom.Value.Date && p.ExternalGoodReceivedNoteDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == txtBranch.Tag.ToString()))
                                        {
                                            bool bStoreOK = true, bSupplierOK = true, bItemOK = true;
                                            decimal dGemWeight = 0;

                                            //add filters - janith
                                            if (rdoDeleted.Checked && !oGRN.IsDeleted)
                                                continue;
                                            else if (rdoActual.Checked && oGRN.IsDeleted)
                                                continue;
                                            //else if (rdoAll.Checked && !detail.IsDeleted && detail.IsDeleted)
                                            //continue;

                                            if (bStoreSelected)
                                                bStoreOK = txtStore.Tag.ToString().Trim() == oGRN.Store_ID ? true : false;
                                            if (bSupplierSelected)
                                                bSupplierOK = txtSupplier.Tag.ToString().Trim() == oGRN.Supplier_ID ? true : false;

                                            if (bStoreOK && bSupplierOK)
                                            {
                                                string sStoreName = clsGenaralName.getName_Store(oGRN.Store_ID);
                                                string sSupplierName = clsGenaralName.getName_Supplier(oGRN.Supplier_ID);
                                                string sStockNoteType = clsGenaralName.getName_StockNoteType(oGRN.StockNoteType_ID);

                                                //foreach (tbl_scsExternalGoodReceivedNote_Detail_Gem oGrnDetail in tbl_scsExternalGoodReceivedNote_Detail_Gem.SelectAllByExternalGoodReceivedNote_ID(oGRN.ExternalGoodReceivedNote_ID))
                                                //{
                                                //    dGemWeight += oGrnDetail.MetalWeight;
                                                //}

                                                glb_dtsScsGoodReceivedNote_Gem.dt_scsGoodReceivedNote.Adddt_scsGoodReceivedNoteRow(oGRN.ExternalGoodReceivedNote_ID, oGRN.ExternalGoodReceivedNoteDate, oGRN.Remark, oGRN.Supplier_ID, sSupplierName, (oGRN.PurchaseOrder_ID) == "default" ? "" : (oGRN.PurchaseOrder_ID), oGRN.Store_ID, oGRN.Currency_ID, oGRN.CurrencyRate, oGRN.PaymentTerms, oGRN.PaymentMode, oGRN.CreditPeriod, oGRN.PaymentDueDate, (oGRN.DeliveryOrderNumber) == "default" ? "" : (oGRN.DeliveryOrderNumber), oGRN.InvoiceNo, oGRN.DiscountPercentage, oGRN.NbtPercentage, oGRN.VatPercentage, oGRN.OtherTaxPercentage, oGRN.SubTotal, oGRN.DiscountTotal, oGRN.NbtTotal, oGRN.VatTotal, oGRN.OtherTaxTotal, oGRN.GrandTotal, (oGRN.CostCenter) == "default" ? "" : (oGRN.CostCenter), sStoreName, sStockNoteType, clsGenaralName.getName_User(oGRN.CreateUser_ID), dGemWeight, oGRN.IsWeightCalculation, oGRN.IsDeleted);
                                                int iLineNo = 0;

                                                foreach (tbl_scsExternalGoodReceivedNote_Detail oGRNDetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(oGRN.ExternalGoodReceivedNote_ID))
                                                {
                                                    if (bItemIDSelected)
                                                        bItemOK = txtItemID.Tag.ToString().Trim() == oGRNDetail.Item_ID ? true : false;
                                                    if (bItemOK)
                                                    {
                                                        string sItemName = clsGenaralName.getName_Item(oGRNDetail.Item_ID);
                                                        glb_dtsScsGoodReceivedNote_Gem.dt_scsGoodReceivedNoteItems.Adddt_scsGoodReceivedNoteItemsRow(iLineNo, oGRN.ExternalGoodReceivedNote_ID, "", oGRNDetail.Item_ID, sItemName, oGRNDetail.ItemSubCategory_ID, oGRNDetail.ItemSubCategory2_ID, oGRNDetail.ItemSerialNo, oGRNDetail.ItemSerialNo2, oGRNDetail.Qty, oGRNDetail.Weight, oGRNDetail.KiloPrice, oGRNDetail.UnitPrice, oGRNDetail.UnitDiscount, oGRNDetail.TotalDiscount, oGRNDetail.TatalAmount, oGRNDetail.Remark, (oGRNDetail.PurchaseReturnedNote_ID) == "default" ? "" : (oGRNDetail.PurchaseReturnedNote_ID));
                                                        iLineNo += 1;
                                                    }
                                                }

                                            }
                                        }
                                        #endregion

                                        glb_dtsScsGoodReceivedNote_Gem.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        //  rpt.Process_Print((int)enum_ReportName.RG_GRNDetail);
                                        rpt.print(sReportPath, glb_dtsScsGoodReceivedNote_Gem, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glb_dtsScsGoodReceivedNote_Gem.dt_scsGoodReceivedNote.Clear();
                                        glb_dtsScsGoodReceivedNote_Gem.dt_scsGoodReceivedNoteItems.Clear();
                                        glb_dtsScsGoodReceivedNote_Gem.dt_scsGoodReceivedNote_Gem.Clear();
                                    }
                                }
                                #endregion

                                #region GRN Summary
                                else if (Report == enum_ReportName.RG_GRNSummary)
                                //else if (rdoGrnSummary.Checked)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;

                                        glb_dtsScsGoodReceivedNote_Gem.Clear();
                                        glb_dtsReportExport.Clear();

                                        #region Fill Detail
                                        bool bIsGemGRN = false;
                                        foreach (tbl_scsExternalGoodReceivedNote oGRN in tbl_scsExternalGoodReceivedNote.SelectAll().Where(p => p.ExternalGoodReceivedNote_ID != "default" && p.ExternalGoodReceivedNoteDate.Date >= dtpFrom.Value.Date && p.ExternalGoodReceivedNoteDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == txtBranch.Tag.ToString()))
                                        {
                                            bool bStoreOK = true, bSupplierOK = true;
                                            decimal dGemWeight = 0, dTotalPrice = 0;

                                            //add filters - janith
                                            if (rdoDeleted.Checked && !oGRN.IsDeleted)
                                                continue;
                                            else if (rdoActual.Checked && oGRN.IsDeleted)
                                                continue;

                                            if (bStoreSelected)
                                                bStoreOK = txtStore.Tag.ToString().Trim() == oGRN.Store_ID ? true : false;
                                            if (bSupplierSelected)
                                                bSupplierOK = txtSupplier.Tag.ToString().Trim() == oGRN.Supplier_ID ? true : false;

                                            if (bIsGemGRN)
                                            {
                                                //foreach (tbl_scsExternalGoodReceivedNote_Detail_Gem oGrnDetailGem in tbl_scsExternalGoodReceivedNote_Detail_Gem.SelectAllByExternalGoodReceivedNote_ID(oGRN.ExternalGoodReceivedNote_ID))
                                                //{
                                                //    dGemWeight += oGrnDetailGem.MetalWeight;
                                                //    dTotalPrice += oGrnDetailGem.SellingPrice;
                                                //}
                                            }
                                            else
                                            {
                                                foreach (tbl_scsExternalGoodReceivedNote_Detail oGrnDetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(oGRN.ExternalGoodReceivedNote_ID))
                                                {
                                                    if (oGRN.IsWeightCalculation)
                                                        dGemWeight += oGrnDetail.Weight;
                                                    else
                                                        dGemWeight += oGrnDetail.Qty;
                                                    dTotalPrice += oGrnDetail.TatalAmount;
                                                }
                                            }

                                            if (bStoreOK && bSupplierOK)
                                            {
                                                string sStoreName = clsGenaralName.getName_Store(oGRN.Store_ID);
                                                string sSupplierName = clsGenaralName.getName_Supplier(oGRN.Supplier_ID);
                                                string sStockNoteType = clsGenaralName.getName_StockNoteType(oGRN.StockNoteType_ID);
                                                glb_dtsScsGoodReceivedNote_Gem.dt_scsGoodReceivedNote.Adddt_scsGoodReceivedNoteRow(oGRN.ExternalGoodReceivedNote_ID, oGRN.ExternalGoodReceivedNoteDate, oGRN.Remark, oGRN.Supplier_ID, sSupplierName, oGRN.PurchaseOrder_ID, oGRN.Store_ID, oGRN.Currency_ID, oGRN.CurrencyRate, oGRN.PaymentTerms, oGRN.PaymentMode, oGRN.CreditPeriod, oGRN.PaymentDueDate, oGRN.DeliveryOrderNumber, oGRN.InvoiceNo, oGRN.DiscountPercentage, oGRN.NbtPercentage, oGRN.VatPercentage, oGRN.OtherTaxPercentage, oGRN.SubTotal, oGRN.DiscountTotal, oGRN.NbtTotal, oGRN.VatTotal, oGRN.OtherTaxTotal, oGRN.GrandTotal > 0 ? oGRN.GrandTotal : dTotalPrice, oGRN.CostCenter, sStoreName, sStockNoteType, clsGenaralName.getName_User(oGRN.CreateUser_ID), dGemWeight, oGRN.IsWeightCalculation, oGRN.IsDeleted);
                                            }
                                        }
                                        #endregion

                                        glb_dtsScsGoodReceivedNote_Gem.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        //  rpt.Process_Print((int)enum_ReportName.RG_GRNSummary);
                                        rpt.print(sReportPath, glb_dtsScsGoodReceivedNote_Gem, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));


                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glb_dtsScsGoodReceivedNote_Gem.dt_scsGoodReceivedNote.Rows.Clear();
                                        glb_dtsScsGoodReceivedNote_Gem.dt_scsGoodReceivedNoteItems.Rows.Clear();
                                    }
                                }

                                #endregion

                                #region PO Details
                                else if (Report == enum_ReportName.RG_PODetail) //rdoPODetails.Checked
                                {
                                    #region Old Report
                                    if (false)
                                    {
                                        sFormula = ""; sFilter = "";
                                        sFormula += " {vw_rpt_scsPurchaseOrder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsPurchaseOrder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                        if (rdoDeleted.Checked)
                                            sFormula += " and {vw_rpt_scsPurchaseOrder.isDeleted} =True";
                                        if (rdoActual.Checked)
                                            sFormula += " and {vw_rpt_scsPurchaseOrder.isDeleted} = False";

                                        if (bSupplierSelected)
                                        {
                                            sFormula += " and {vw_rpt_scsPurchaseOrder.supplier_ID}" + " = '" + txtSupplier.Tag.ToString() + "' ";
                                            sFilter += " Supplier Name : " + txtSupplier.Text.Trim();
                                        }

                                        if (bStockNoteType)
                                        {
                                            sFormula += " and {vw_rpt_scsPurchaseOrder.stockNoteType_ID}" + " = '" + txtStockNoteType.Tag.ToString() + "' ";
                                            sFilter += " Note Type : " + txtStockNoteType.Text.Trim();
                                        }

                                        iReportNo = (int)enum_ReportName.RG_POSummary;
                                        print("\\reports\\SCS\\Registry\\rpt_scs_Ex_PO_Summary.rpt", "Purchase Order Register", "[PO Summary]", "  ", sFormula.ToString(), sFilter);
                                    }
                                    #endregion

                                    #region DataSet
                                    else
                                    {
                                        try
                                        {
                                            glb_dts_scsPurchaseOrder.Clear();
                                            glb_dtsReportExport.Clear();
                                            Cursor = Cursors.WaitCursor;

                                            #region Fill Detail
                                            List<tbl_scsPurchaseOrder> oPo = tbl_scsPurchaseOrder.SelectAll().Where(p => p.PurchaseOrder_ID != "default" && p.PurchaseOrderDate.Date >= dtpFrom.Value.Date && p.PurchaseOrderDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == txtBranch.Tag.ToString()).ToList();

                                            foreach (tbl_scsPurchaseOrder detail in oPo)
                                            {
                                                if (bSupplierSelected)
                                                    if (detail.Supplier_ID != txtSupplier.Tag.ToString())
                                                        continue;

                                                if (bStockNoteType)
                                                    if (detail.StockNoteType_ID != txtStockNoteType.Tag.ToString())
                                                        continue;

                                                //add filters - janith
                                                if (rdoDeleted.Checked && !detail.IsDeleted)
                                                    continue;
                                                else if (rdoActual.Checked && detail.IsDeleted)
                                                    continue;
                                                else if (rdoAll.Checked && !detail.IsDeleted && detail.IsDeleted)
                                                    continue;

                                                //    foreach (tbl_scsPurchaseOrder detail in tbl_scsPurchaseOrder.SelectAll().Where(p => p.PurchaseOrder_ID != "default"))
                                                glb_dts_scsPurchaseOrder.dt_scsPurchaseOrder.Adddt_scsPurchaseOrderRow(detail.PurchaseOrder_ID, detail.PurchaseOrderDate, "", "", "", detail.SubTotal, 0, detail.DiscountTotal, 0, detail.VatTotal, detail.GrandTotal, detail.Supplier_ID, clsGenaralName.getName_Supplier(detail.Supplier_ID), clsGenaralName.getSupplierAddressRegister(detail.Supplier_ID), "", "", "", "", "",
                                                    "", "", clsGenaralName.getName_CurrencyCode(detail.Currency_ID), detail.DeliveryTerms, detail.DeliveryAddress, detail.Remark, detail.ForexRate, clsGenaralName.getName_StockNoteType(detail.StockNoteType_ID), detail.DateCreate, detail.CostCenter, detail.OrderdBy, detail.DueDate, detail.QuotaionNo, "", detail.IssuedRefNo_ID, detail.IsDeleted, detail.CreateUser_ID, detail.ApprovedUser_ID, detail.DateCreate, detail.DateApproved, 0, 0, detail.NbtTotal, detail.OtherTaxTotal);

                                                //foreach (tbl_scsPurchaseOrder_Detail pdetail in tbl_scsPurchaseOrder_Detail.SelectAll().Where(p => p.PurchaseOrder_ID != "default" && p.Item_ID != "default"))
                                                foreach (tbl_scsPurchaseOrder_Detail pdetail in tbl_scsPurchaseOrder_Detail.SelectAllByPurchaseOrder_ID(detail.PurchaseOrder_ID))
                                                {
                                                    if (bItemIDSelected)
                                                        if (pdetail.Item_ID != txtItemID.Tag.ToString())
                                                            continue;

                                                    glb_dts_scsPurchaseOrder.dt_scsPurchaseOrder_Detail.Adddt_scsPurchaseOrder_DetailRow(pdetail.PurchaseOrder_ID, pdetail.Qty, clsGenaralName.getName_ItemUOM(pdetail.Item_ID), pdetail.UnitPrice, 0, pdetail.TatalAmount, pdetail.Item_ID, clsGenaralName.getName_Item(pdetail.Item_ID), pdetail.Remark, clsGenaralName.getName_ItemSubCategory(pdetail.ItemSubCategory_ID), clsGenaralName.getName_ItemUOM(pdetail.Item_ID), pdetail.Qty, pdetail.Weight, pdetail.UnitPrice, pdetail.KiloPrice);
                                                }
                                            }
                                            #endregion

                                            glb_dts_scsPurchaseOrder.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter, clsCommon.getCompanyVAT(), clsCommon.getCompanySVAT(), clsCommon.getCompanyBusinessRegisterNo());

                                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            //   rpt.Process_Print((int)enum_ReportName.RG_POSummary);
                                            rpt.print(sReportPath, glb_dts_scsPurchaseOrder, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                        }
                                        catch (Exception ex)
                                        {
                                            clsValidate.WriteErrorLog("", iFormID,ex);
                                            SEACCException.Show(ex);
                                        }
                                        finally
                                        {
                                            glb_dts_scsPurchaseOrder.Clear();
                                            glb_dtsReportExport.Clear();
                                            Cursor = Cursors.Default;
                                        }
                                    }
                                    #endregion
                                }
                                #endregion

                                #region PO Summary
                                else if (Report == enum_ReportName.RG_POSummary) //  rdoPOSummery.Checked
                                {
                                    #region OLD Report
                                    if (false)
                                    {
                                        sFormula = ""; sFilter = "";
                                        sFormula += " {vw_rpt_scsPurchaseOrder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsPurchaseOrder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                        if (rdoDeleted.Checked)
                                            sFormula += " and {vw_rpt_scsPurchaseOrder.isDeleted} =True";
                                        if (rdoActual.Checked)
                                            sFormula += " and {vw_rpt_scsPurchaseOrder.isDeleted} = False";

                                        if (bSupplierSelected)
                                        {
                                            sFormula += " and {vw_rpt_scsPurchaseOrder.supplier_ID}" + " = '" + txtSupplier.Tag.ToString() + "' ";
                                            sFilter += " Supplier ID : " + txtSupplier.Text.Trim();
                                        }
                                        if (bItemIDSelected)
                                        {
                                            sFormula += " and {vw_rpt_scsPurchaseOrder_Details.item_ID}= '" + txtItemID.Tag.ToString() + "' ";
                                            sFilter += " Item ID : " + txtItemID.Text.Trim();
                                        }

                                        iReportNo = (int)enum_ReportName.RG_PODetail;
                                        print("\\reports\\SCS\\Registry\\rpt_scs_Ex_PO_Register_Detail.rpt", " Purchase Order Register ", "[PO Detailed]", "", sFormula, sFilter);
                                    }
                                    #endregion

                                    #region DataSet
                                    else
                                    {
                                        try
                                        {
                                            glb_dts_scsPurchaseOrder.Clear();
                                            glb_dtsReportExport.Clear();
                                            Cursor = Cursors.WaitCursor;

                                            #region Fill Detail
                                            List<tbl_scsPurchaseOrder> oPo = tbl_scsPurchaseOrder.SelectAll().Where(p => p.PurchaseOrder_ID != "default" && p.PurchaseOrderDate.Date >= dtpFrom.Value.Date && p.PurchaseOrderDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == txtBranch.Tag.ToString()).ToList();

                                            int iItemCount = 0;

                                            foreach (tbl_scsPurchaseOrder detail in oPo)
                                            {
                                                if (bSupplierSelected)
                                                    if (detail.Supplier_ID != txtSupplier.Tag.ToString())
                                                        continue;

                                                if (bStockNoteType)
                                                    if (detail.StockNoteType_ID != txtStockNoteType.Tag.ToString())
                                                        continue;

                                                //add filters - janith
                                                if (rdoDeleted.Checked && !detail.IsDeleted)
                                                    continue;
                                                else if (rdoActual.Checked && detail.IsDeleted)
                                                    continue;
                                                else if (rdoAll.Checked && !detail.IsDeleted && detail.IsDeleted)
                                                    continue;

                                                iItemCount = tbl_scsPurchaseOrder_Detail.SelectAllByPurchaseOrder_ID(detail.PurchaseOrder_ID).Count();

                                                glb_dts_scsPurchaseOrder.dt_scsPurchaseOrder.Adddt_scsPurchaseOrderRow(detail.PurchaseOrder_ID, detail.PurchaseOrderDate, "", "", "", detail.SubTotal, 0, detail.DiscountTotal, 0, detail.VatTotal, detail.GrandTotal, detail.Supplier_ID, clsGenaralName.getName_Supplier(detail.Supplier_ID), clsGenaralName.getSupplierAddressRegister(detail.Supplier_ID), "", "", "", "", "", "", "", clsGenaralName.getName_CurrencyCode(detail.Currency_ID), detail.DeliveryTerms, detail.DeliveryAddress, detail.Remark, detail.ForexRate, clsGenaralName.getName_StockNoteType(detail.StockNoteType_ID), detail.DateCreate, detail.CostCenter, detail.OrderdBy, detail.DueDate, detail.QuotaionNo, "", detail.IssuedRefNo_ID, detail.IsDeleted, detail.CreateUser_ID, detail.ApprovedUser_ID, detail.DateCreate, detail.DateApproved, iItemCount, 0, detail.NbtTotal, detail.OtherTaxTotal);
                                            }
                                            #endregion

                                            glb_dts_scsPurchaseOrder.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter, clsCommon.getCompanyVAT(), clsCommon.getCompanySVAT(), clsCommon.getCompanyBusinessRegisterNo());

                                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            //    rpt.Process_Print((int)enum_ReportName.RG_PODetail);
                                            rpt.print(sReportPath, glb_dts_scsPurchaseOrder, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                        }
                                        catch (Exception ex)
                                        {
                                            clsValidate.WriteErrorLog("", iFormID,ex);
                                            SEACCException.Show(ex);
                                        }
                                        finally
                                        {
                                            glb_dts_scsPurchaseOrder.Clear();
                                            glb_dtsReportExport.Clear();
                                            Cursor = Cursors.Default;
                                        }
                                    }
                                    #endregion
                                }
                                #endregion

                                #region Purchase Return Note Details
                                else if (Report == enum_ReportName.RG_PRNDetails)//rdoPRNDetail.Checked
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;

                                        glb_dtsScsPurchaseRetNote.Clear();
                                        glb_dtsReportExport.Clear();

                                        #region Fill Detail
                                        //fill data table
                                        List<tbl_scsPurchaseReturnedNote> oPRNs = new List<tbl_scsPurchaseReturnedNote>();
                                        if (bSupplierSelected)
                                            oPRNs = tbl_scsPurchaseReturnedNote.SelectAllBySupplier_ID(txtSupplier.Tag.ToString()).Where(p => p.PurchaseReturnedNote_ID != "default" && p.PurchaseReturnedNoteDate.Date >= dtpFrom.Value.Date && p.PurchaseReturnedNoteDate.Date <= dtpTo.Value.Date).ToList();
                                        else
                                            oPRNs = tbl_scsPurchaseReturnedNote.SelectAll().Where(p => p.PurchaseReturnedNote_ID != "default" && p.PurchaseReturnedNoteDate.Date >= dtpFrom.Value.Date && p.PurchaseReturnedNoteDate.Date <= dtpTo.Value.Date).ToList();

                                        foreach (tbl_scsPurchaseReturnedNote oPRN in oPRNs.Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString()))
                                        {
                                            bool bStoreOK = true, bSectionOK = true, bDepartmentOK = true;
                                            //add filters - janith
                                            if (rdoDeleted.Checked && !oPRN.IsDeleted)
                                                continue;
                                            else if (rdoActual.Checked && oPRN.IsDeleted)
                                                continue;

                                            if (bStoreSelected)
                                                bStoreOK = txtStore.Tag.ToString().Trim() == oPRN.Store_ID ? true : false;

                                            string storeName = clsGenaralName.getName_Store(oPRN.Store_ID);
                                            tbl_genSupplierMaster oSupplier = tbl_genSupplierMaster.Select(oPRN.Supplier_ID);

                                            if (oSupplier != null && oSupplier.Supplier_ID != "Default")
                                            {
                                                if (bStoreOK && bSectionOK && bDepartmentOK)
                                                {
                                                    glb_dtsScsPurchaseRetNote.dt_scsPurchaseRetNote.Adddt_scsPurchaseRetNoteRow(oPRN.PurchaseReturnedNote_ID, oPRN.PurchaseReturnedNoteDate, oPRN.Supplier_ID, oSupplier.SupplierName, oPRN.ExternalGoodReceivedNote_ID, "", oPRN.Store_ID, oPRN.Currency_ID, oPRN.CurrencyRate, oPRN.Remark, clsGenaralName.getName_AccCostCenter1(oPRN.CostCenter), oPRN.DeliveryOrderNo, oPRN.InvoiceNo, oPRN.SubTotal, oPRN.DiscountTotal, oPRN.GrandTotal, oPRN.CreateUser_ID, oPRN.PostingStatus_ID, storeName, oPRN.VatTotal, oPRN.NbtTotal, oPRN.IsWeightCalculation, oPRN.IsDeleted, 0);
                                                    int iLineNo = 0;
                                                    foreach (tbl_scsPurchaseReturnedNote_Detail oPRNDetail in tbl_scsPurchaseReturnedNote_Detail.SelectAllByPurchaseReturnedNote_ID(oPRN.PurchaseReturnedNote_ID))
                                                    {
                                                        tbl_genItemMaster oItem = tbl_genItemMaster.Select(oPRNDetail.Item_ID);
                                                        if (oItem != null && oItem.Item_ID != "Default")
                                                        {
                                                            glb_dtsScsPurchaseRetNote.dt_PurchaseReturnNoteDetail.Adddt_PurchaseReturnNoteDetailRow(iLineNo, oPRNDetail.PurchaseReturnedNote_ID, oPRNDetail.Item_ID, oItem.ItemName, oPRNDetail.ItemSubCategory_ID, oPRNDetail.ItemSubCategory2_ID, oPRNDetail.ItemSerialNo, oPRNDetail.ItemSerialNo2, oPRNDetail.Qty, oPRNDetail.Weight, oPRNDetail.KiloPrice, oPRNDetail.UnitPrice, oPRNDetail.UnitDiscount, oPRNDetail.TotalDiscount, oPRNDetail.TatalAmount, oPRNDetail.Remark, clsGenaralName.getName_Brand(oItem.Brand_ID), clsGenaralName.getName_ItemUOM(oPRNDetail.Item_ID));
                                                            iLineNo += 1;
                                                        }
                                                    }
                                                }
                                            }
                                            clsHelpMethods.startProgressBar(0, oPRNs.Count + 2, 1, ProgressBar);
                                        }
                                        #endregion

                                        glb_dtsScsPurchaseRetNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        //   rpt.Process_Print((int)enum_ReportName.RG_PRNDetails);
                                        rpt.print(sReportPath, glb_dtsScsPurchaseRetNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        Cursor = Cursors.Default;
                                        glb_dtsScsPurchaseRetNote.dt_scsPurchaseRetNote.Clear();
                                        glb_dtsScsPurchaseRetNote.dt_PurchaseReturnNoteDetail.Clear();
                                    }
                                }
                                #endregion

                                #region Purchase Return Note Summary
                                else if (Report == enum_ReportName.RG_PRNSummary) //rdoPRNSummary.Checked
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;

                                        glb_dtsScsPurchaseRetNote.Clear();
                                        glb_dtsReportExport.Clear();

                                        #region Fill Detail
                                        //fill data table
                                        List<tbl_scsPurchaseReturnedNote> oPRNs = new List<tbl_scsPurchaseReturnedNote>();
                                        if (bSupplierSelected)
                                            oPRNs = tbl_scsPurchaseReturnedNote.SelectAllBySupplier_ID(txtSupplier.Tag.ToString()).Where(p => p.PurchaseReturnedNote_ID != "default" && p.PurchaseReturnedNoteDate.Date >= dtpFrom.Value.Date && p.PurchaseReturnedNoteDate.Date <= dtpTo.Value.Date).ToList();
                                        else
                                            oPRNs = tbl_scsPurchaseReturnedNote.SelectAll().Where(p => p.PurchaseReturnedNote_ID != "default" && p.PurchaseReturnedNoteDate.Date >= dtpFrom.Value.Date && p.PurchaseReturnedNoteDate.Date <= dtpTo.Value.Date).ToList();

                                        foreach (tbl_scsPurchaseReturnedNote oPRN in oPRNs.Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString()))
                                        {
                                            bool bStoreOK = true, bSectionOK = true, bDepartmentOK = true;
                                            int iItemCount = 0;

                                            //add filters - janith
                                            if (rdoDeleted.Checked && !oPRN.IsDeleted)
                                                continue;
                                            else if (rdoActual.Checked && oPRN.IsDeleted)
                                                continue;

                                            if (bStoreSelected)
                                                bStoreOK = txtStore.Tag.ToString().Trim() == oPRN.Store_ID ? true : false;

                                            string sStoreName = clsGenaralName.getName_Store(oPRN.Store_ID);
                                            string sSupplierName = clsGenaralName.getName_Supplier(oPRN.Supplier_ID);
                                            if (bStoreOK && bSectionOK && bDepartmentOK)
                                            {
                                                iItemCount = tbl_scsPurchaseReturnedNote_Detail.SelectAllByPurchaseReturnedNote_ID(oPRN.PurchaseReturnedNote_ID).Count;

                                                glb_dtsScsPurchaseRetNote.dt_scsPurchaseRetNote.Adddt_scsPurchaseRetNoteRow(oPRN.PurchaseReturnedNote_ID, oPRN.PurchaseReturnedNoteDate, oPRN.Supplier_ID, sSupplierName, oPRN.ExternalGoodReceivedNote_ID, "", oPRN.Store_ID, oPRN.Currency_ID, oPRN.CurrencyRate, oPRN.Remark, oPRN.CostCenter, oPRN.DeliveryOrderNo, oPRN.InvoiceNo, oPRN.SubTotal, oPRN.DiscountTotal, oPRN.GrandTotal, oPRN.CreateUser_ID, oPRN.PostingStatus_ID, sStoreName, oPRN.VatTotal, oPRN.NbtTotal, oPRN.IsWeightCalculation, oPRN.IsDeleted, decimal.Parse(iItemCount.ToString()));
                                            }
                                            clsHelpMethods.startProgressBar(0, oPRNs.Count + 2, 1, ProgressBar);
                                        }
                                        #endregion

                                        glb_dtsScsPurchaseRetNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        //  rpt.Process_Print((int)enum_ReportName.RG_PRNSummary);
                                        rpt.print(sReportPath, glb_dtsScsPurchaseRetNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        Cursor = Cursors.Default;
                                        glb_dtsScsPurchaseRetNote.dt_scsPurchaseRetNote.Clear();
                                    }
                                }
                                #endregion

                                #region Store Internal GRN Summary
                                else if (Report == enum_ReportName.RG_Internal_Store_GRN_Summary)//rdbInternalStoreGRN.Checked
                                {

                                    #region Old Report
                                    if (!clsConfig.bDataSetActive_CustomerOrder)
                                    {
                                        sFormula = ""; sFilter = "";

                                        sFormula += " {vw_rpt_scsStoreGoodReceiveNote.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsStoreGoodReceiveNote.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                        if (rdoDeleted.Checked)
                                            sFormula += " and {vw_rpt_scsStoreGoodReceiveNote.isDeleted} =True";
                                        if (rdoActual.Checked)
                                            sFormula += " and {vw_rpt_scsStoreGoodReceiveNote.isDeleted} = False";

                                        if (bStoreSelected)
                                        {
                                            sFormula += " and {vw_rpt_scsStoreGoodReceiveNote.fromStore_ID}= '" + txtStore.Tag.ToString() + "'";
                                            sFilter += " Store ID : " + txtStore.Text.Trim();
                                        }
                                        if (bSectionSelected)
                                        {
                                            sFormula += " and {vw_rpt_scsStoreGoodReceiveNote.fromSection_ID}= '" + txtSection.Tag.ToString() + "'";
                                            sFilter += " Section ID : " + txtSection.Text.Trim();
                                        }
                                        if (bDepartmetSelected)
                                        {
                                            sFormula += " and {vw_rpt_scsStoreGoodReceiveNote.fromDepartment_ID}= '" + txtDepartment.Tag.ToString() + "'";
                                            sFilter += " Department ID : " + txtDepartment.Text.Trim();
                                        }
                                        iReportNo = (int)enum_ReportName.RG_Internal_Store_GRN_Summary;
                                        print("\\reports\\SCS\\Registry\\rpt_scs_Store_iGRN_Summary.rpt", " Store Goods Receipts ", "[iGRN Summary]", "", sFormula.ToString(), sFilter);
                                    }
                                    #endregion

                                    #region DataSet
                                    else
                                    {
                                        try
                                        {
                                            glb_dts_scsStoreGoodsReceiveNote.Clear();
                                            glb_dtsReportExport.Clear();
                                            Cursor = Cursors.WaitCursor;

                                            #region Fill Detail
                                            //List<tbl_genStoreMaster> oStr;

                                            //#region Filter - Store
                                            //if (!bStoreSelected)
                                            //    oStr = tbl_genStoreMaster.SelectAll().ToList();
                                            //else
                                            //    oStr = tbl_genStoreMaster.SelectAll().Where(p => p.Store_ID == txtStore.Tag.ToString()).ToList();
                                            //#endregion

                                            //foreach (tbl_genStoreMaster oStore in oStr.Where(p => p.Store_ID != "default"))
                                            //{

                                            foreach (tbl_scsStoreGoodReceiveNote detail in tbl_scsStoreGoodReceiveNote.SelectAll().Where(p => p.StoreGoodReceiveNote_ID != "default" && p.StoreGoodReceiveNoteDate.Date >= dtpFrom.Value.Date && p.StoreGoodReceiveNoteDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == txtBranch.Tag.ToString()))
                                            {
                                                //foreach (tbl_scsStoreGoodReceiveNote detail in tbl_scsStoreGoodReceiveNote.SelectAllByToStore_ID(oStore.Store_ID).Where(p => p.StoreGoodReceiveNote_ID != "default" && p.StoreGoodReceiveNoteDate.Date >= dtpFrom.Value.Date && p.StoreGoodReceiveNoteDate.Date <= dtpTo.Value.Date))
                                                //{
                                                if (bStoreSelected)
                                                    if (detail.ToStore_ID != txtStore.Tag.ToString())
                                                        continue;

                                                if (bSectionSelected)
                                                    if (detail.FromStore_ID != txtSection.Tag.ToString())
                                                        continue;

                                                #region Filter - Deleted Records
                                                if (rdoDeleted.Checked)
                                                {
                                                    if (!detail.IsDeleted)
                                                        continue;
                                                }
                                                else if (rdoActual.Checked)
                                                {
                                                    if (detail.IsDeleted)
                                                        continue;
                                                }
                                                #endregion

                                                glb_dts_scsStoreGoodsReceiveNote.dt_scsStoreGoodsReceiveNote.Adddt_scsStoreGoodsReceiveNoteRow(detail.StoreGoodReceiveNote_ID, detail.StoreGoodReceiveNoteDate, clsGenaralName.getName_Store(detail.ToStore_ID), clsGenaralName.getName_Store(detail.FromStore_ID), detail.IsDeleted, detail.DateCreate, detail.Remark,"","");

                                            }
                                            // } 
                                            #endregion


                                            glb_dts_scsStoreGoodsReceiveNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            //       rpt.Process_Print((int)enum_ReportName.RG_Internal_Store_GRN_Summary);
                                            rpt.print(sReportPath, glb_dts_scsStoreGoodsReceiveNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                        }
                                        catch (Exception ex)
                                        {
                                            clsValidate.WriteErrorLog("", iFormID,ex);
                                            SEACCException.Show(ex);
                                        }
                                        finally
                                        {
                                            glb_dts_scsStoreGoodsReceiveNote.Clear();
                                            glb_dtsReportExport.Clear();
                                            Cursor = Cursors.Default;
                                        }
                                    }
                                    #endregion
                                }
                                #endregion

                                #region Store Internal-GRN Details
                                else if (Report == enum_ReportName.RG_Internal_Store_GRN_Detail) //rdbInternalStoreGRNDetails.Checked
                                {
                                    #region Old Report
                                    if (!clsConfig.bDataSetActive_iGRN)
                                    {
                                        sFormula = ""; sFilter = "";
                                        sFormula += " {vw_rpt_scsStoreGoodReceiveNote.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsStoreGoodReceiveNote.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                        if (rdoDeleted.Checked)
                                            sFormula += " and {vw_rpt_scsStoreGoodReceiveNote.isDeleted} =True";
                                        if (rdoActual.Checked)
                                            sFormula += " and {vw_rpt_scsStoreGoodReceiveNote.isDeleted} = False";


                                        if (bStoreSelected)
                                        {
                                            sFormula += " and {vw_rpt_scsStoreGoodReceiveNote.fromStore_ID}= '" + txtStore.Tag.ToString() + "'";
                                            sFilter += " Store ID : " + txtStore.Text.Trim();
                                        }
                                        if (bSectionSelected)
                                        {
                                            sFormula += " and {vw_rpt_scsStoreGoodReceiveNote.fromSection_ID}= '" + txtSection.Tag.ToString() + "'";
                                            sFilter += " Section ID : " + txtSection.Text.Trim();
                                        }
                                        if (bDepartmetSelected)
                                        {
                                            sFormula += " and {vw_rpt_scsStoreGoodReceiveNote.fromDepartment_ID}= '" + txtDepartment.Tag.ToString() + "'";
                                            sFilter += " Department ID : " + txtDepartment.Text.Trim();
                                        }
                                        if (bItemIDSelected)
                                        {
                                            sFormula += " and {vw_rpt_scsSectionGoodReceiveNote_Detail.item_ID}= '" + txtItemID.Tag.ToString() + "'";
                                            sFilter += " Item ID : " + txtItemID.Text.Trim();
                                        }

                                        iReportNo = (int)enum_ReportName.RG_Internal_Store_GRN_Detail;
                                        print("\\reports\\SCS\\Registry\\rpt_scs_Store_iGRN_Register_Detail.rpt", " Store Goods Receipts ", "[iGRN Detailed]", "", sFormula.ToString(), sFilter);
                                    }
                                    #endregion

                                    #region DataSet
                                    else
                                    {
                                        try
                                        {
                                            glb_dts_scsStoreGoodsReceiveNote.Clear();
                                            glb_dtsReportExport.Clear();
                                            Cursor = Cursors.WaitCursor;

                                            #region Fill Detail
                                            #region Filter - Store
                                            //if (!bStoreSelected)
                                            //    oStr = tbl_genStoreMaster.SelectAll().ToList();
                                            //else
                                            //    oStr = tbl_genStoreMaster.SelectAll().Where(p=> p.Store_ID == txtStore.Tag.ToString()).ToList();
                                            #endregion

                                            //foreach (tbl_genStoreMaster oStore in oStr.Where(p => p.Store_ID != "default"))
                                            //{
                                            foreach (tbl_scsStoreGoodReceiveNote detail in tbl_scsStoreGoodReceiveNote.SelectAll().Where(p => p.StoreGoodReceiveNote_ID != "default" && p.StoreGoodReceiveNoteDate.Date >= dtpFrom.Value.Date && p.StoreGoodReceiveNoteDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == txtBranch.Tag.ToString()))
                                            {
                                                if (bStoreSelected)
                                                    if (detail.ToStore_ID != txtStore.Tag.ToString())
                                                        continue;

                                                if (bSectionSelected)
                                                    if (detail.FromStore_ID != txtSection.Tag.ToString())
                                                        continue;

                                                #region Filter - Deleted Records
                                                if (rdoDeleted.Checked)
                                                {
                                                    if (!detail.IsDeleted)
                                                        continue;
                                                }
                                                else if (rdoActual.Checked)
                                                {
                                                    if (detail.IsDeleted)
                                                        continue;
                                                }
                                                #endregion

                                                glb_dts_scsStoreGoodsReceiveNote.dt_scsStoreGoodsReceiveNote.Adddt_scsStoreGoodsReceiveNoteRow(detail.StoreGoodReceiveNote_ID, detail.StoreGoodReceiveNoteDate, clsGenaralName.getName_Store(detail.ToStore_ID), clsGenaralName.getName_Store(detail.FromStore_ID), detail.IsDeleted, detail.DateCreate, detail.Remark,"","");


                                                List<tbl_scsStoreGoodReceiveNote_Detail> oGRN_Det = tbl_scsStoreGoodReceiveNote_Detail.SelectAllByStoreGoodReceiveNote_ID(detail.StoreGoodReceiveNote_ID);
                                                if (bItemIDSelected)
                                                    oGRN_Det = oGRN_Det.Where(p => p.Item_ID == txtItemID.Tag.ToString()).ToList();

                                                foreach (tbl_scsStoreGoodReceiveNote_Detail rdetail in oGRN_Det)
                                                {
                                                    glb_dts_scsStoreGoodsReceiveNote.dt_scsStoreGoodsReceiveNote_Detail.Adddt_scsStoreGoodsReceiveNote_DetailRow(rdetail.StoreGoodReceiveNote_ID, rdetail.StoreGoodIssueNote_ID, "", rdetail.Item_ID, clsGenaralName.getName_Item(rdetail.Item_ID), rdetail.ItemSerialNo, "", "", clsGenaralName.getName_Store(detail.FromStore_ID), rdetail.Qty, rdetail.Weight, "", "", detail.ToStore_ID, clsGenaralName.getName_Store(detail.ToStore_ID), 0, rdetail.Remark, rdetail.Job_ID, detail.StoreGoodReceiveNoteDate,"",0,0);
                                                }

                                                //foreach (tbl_scsStoreGoodReceiveNote_Detail rdetail in tbl_scsStoreGoodReceiveNote_Detail.SelectAllByStoreGoodReceiveNote_ID(detail.StoreGoodReceiveNote_ID))
                                                //{
                                                //    List<tbl_genItemMaster> oItm;
                                                //    #region Filter - Item
                                                //    if (!bItemIDSelected)
                                                //        oItm = tbl_genItemMaster.SelectAll().ToList();
                                                //    else
                                                //        oItm = tbl_genItemMaster.SelectAll().Where(p => p.Item_ID == txtItemID.Tag.ToString()).ToList();
                                                //    #endregion

                                                //    glb_dts_scsStoreGoodsReceiveNote.dt_scsStoreGoodsReceiveNote_Detail.Adddt_scsStoreGoodsReceiveNote_DetailRow( rdetail.StoreGoodReceiveNote_ID, rdetail.StoreGoodIssueNote_ID, "", rdetail.Item_ID, clsGenaralName.getName_Item(rdetail.Item_ID), rdetail.ItemSerialNo, "", "", clsGenaralName.getName_Store(detail.FromStore_ID), rdetail.Qty, rdetail.Weight, "", "", detail.ToStore_ID, clsGenaralName.getName_Store(detail.ToStore_ID), 0, rdetail.Remark, rdetail.Job_ID, detail.StoreGoodReceiveNoteDate);
                                                //}
                                            }
                                            // } 
                                            #endregion

                                            glb_dts_scsStoreGoodsReceiveNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            // rpt.Process_Print((int)enum_ReportName.RG_Internal_Store_GRNDetail);
                                            rpt.print(sReportPath, glb_dts_scsStoreGoodsReceiveNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                        }
                                        catch (Exception ex)
                                        {
                                            clsValidate.WriteErrorLog("", iFormID,ex);
                                            SEACCException.Show(ex);
                                        }
                                        finally
                                        {
                                            glb_dts_scsStoreGoodsReceiveNote.Clear();
                                            glb_dtsReportExport.Clear();
                                            Cursor = Cursors.Default;
                                        }
                                    }
                                    #endregion
                                }
                                #endregion

                                #region Good Transfer Note Summary
                                else if (Report == enum_ReportName.RG_Good_Transfer_Note_Summery)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsScsGoodTransferNote.Clear();

                                        #region Fill Detail
                                        List<tbl_scsGoodTransferNote> oGTNs = tbl_scsGoodTransferNote.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => p.GoodTransferNote_ID != "default" && p.GoodTransferNoteDate.Date >= dtpFrom.Value.Date && p.GoodTransferNoteDate.Date <= dtpTo.Value.Date).ToList();
                                        //if (bStoreSelected)
                                        //{
                                        //    oGTNs = oGTNs.Where(r => r.StoreID_From == txtStore.Tag.ToString()).ToList();
                                        //    sFilter = sFilter += " From Store: " + txtStore.Text;
                                        //}
                                        //if (bSectionSelected)
                                        //{
                                        //    oGTNs = oGTNs.Where(r => r.StoreID_To == txtSection.Tag.ToString()).ToList();
                                        //    sFilter = sFilter += " To Store: " + txtSection.Text;
                                        //}

                                        if (bStoreSelected)
                                        {
                                            oGTNs = oGTNs.Where(r => r.StoreID_From == txtStore.Tag.ToString()).ToList();
                                        }
                                        if (bSectionSelected)
                                        {
                                            oGTNs = oGTNs.Where(r => r.StoreID_To == txtSection.Tag.ToString()).ToList();
                                        }


                                        foreach (tbl_scsGoodTransferNote oGTN in oGTNs)
                                        {
                                            decimal dTotQty = 0;
                                            decimal dTotAmount = 0;

                                            //add filters - janith
                                            if (rdoDeleted.Checked && !oGTN.IsDeleted)
                                                continue;
                                            else if (rdoActual.Checked && oGTN.IsDeleted)
                                                continue;

                                            foreach (tbl_scsGoodTransferNote_Detail detail in tbl_scsGoodTransferNote_Detail.SelectAllByGoodTransferNote_ID(oGTN.GoodTransferNote_ID))
                                            {
                                                dTotQty = dTotQty += detail.Qty;
                                                dTotAmount = dTotAmount += detail.TatalAmount;
                                            }

                                            glb_dtsScsGoodTransferNote.dt_scsGoodTransferNote.Adddt_scsGoodTransferNoteRow(oGTN.GoodTransferNote_ID, oGTN.GoodTransferNoteDate, clsGenaralName.getName_Store(oGTN.StoreID_From), clsGenaralName.getName_Store(oGTN.StoreID_To), "", "", oGTN.Remark, dTotQty, dTotAmount, oGTN.IsDeleted,"");
                                        }
                                        #endregion

                                        glb_dtsScsGoodTransferNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        //    rpt.Process_Print((int)enum_ReportName.RG_Good_Transfer_Note_Summery);
                                        rpt.print(sReportPath, glb_dtsScsGoodTransferNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    }
                                    catch (Exception ex)
                                    {
                                        SEACCException.Show(ex);
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                    }
                                    finally
                                    {
                                        glb_dtsScsGoodTransferNote.dt_scsGoodTransferNote.Clear();
                                        glb_dtsScsGoodTransferNote.dt_scsGoodTransferNote_Detail.Clear();

                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Good Transfer Note detail
                                else if (Report == enum_ReportName.RG_Good_Transfer_Note_Details)
                                {
                                    try
                                    {
                                        #region Fill Details
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsScsGoodTransferNote.Clear();

                                        #region Fill Detail
                                        sFormula = ""; sFilter = "";

                                        //List <tbl_scsGoodTransferNote> oGTN = tbl_scsGoodTransferNote.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).Where(p => !p.IsDeleted && p.GoodTransferNote_ID != "default" && p.GoodTransferNoteDate.Date >= dtpFrom.Value.Date && p.GoodTransferNoteDate.Date <= dtpTo.Value.Date).ToList();

                                        //if (bStoreSelected)
                                        //{
                                        //    oGTN = oGTN.Where(p => p.StoreID_From == txtStore.Tag.ToString()).ToList();
                                        //}
                                        //if (bSectionSelected)
                                        //{
                                        //    oGTN = oGTN.Where(p => p.StoreID_To == txtSection.Tag.ToString()).ToList();
                                        //}

                                        List<tbl_scsGoodTransferNote> oGTNs = tbl_scsGoodTransferNote.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => p.GoodTransferNote_ID != "default" && p.GoodTransferNoteDate.Date >= dtpFrom.Value.Date && p.GoodTransferNoteDate.Date <= dtpTo.Value.Date).ToList();
                                        if (bStoreSelected)
                                        {
                                            oGTNs = oGTNs.Where(r => r.StoreID_From == txtStore.Tag.ToString()).ToList();
                                        }
                                        if (bSectionSelected)
                                        {
                                            oGTNs = oGTNs.Where(r => r.StoreID_To == txtSection.Tag.ToString()).ToList();
                                        }

                                        foreach (tbl_scsGoodTransferNote oGTN in oGTNs)
                                        {
                                            //add filters - janith
                                            if (rdoDeleted.Checked && !oGTN.IsDeleted)
                                                continue;
                                            else if (rdoActual.Checked && oGTN.IsDeleted)
                                                continue;

                                            glb_dtsScsGoodTransferNote.dt_scsGoodTransferNote.Adddt_scsGoodTransferNoteRow(oGTN.GoodTransferNote_ID, oGTN.GoodTransferNoteDate, clsGenaralName.getName_Store(oGTN.StoreID_From), clsGenaralName.getName_Store(oGTN.StoreID_To), "", "", oGTN.Remark, 0, 0, oGTN.IsDeleted,"");

                                            foreach (tbl_scsGoodTransferNote_Detail detail in tbl_scsGoodTransferNote_Detail.SelectAllByGoodTransferNote_ID(oGTN.GoodTransferNote_ID))
                                            {
                                                glb_dtsScsGoodTransferNote.dt_scsGoodTransferNote_Detail.Adddt_scsGoodTransferNote_DetailRow(oGTN.GoodTransferNote_ID, detail.Item_Code, detail.ItemSerialNo, "", "", clsGenaralName.getName_Item(detail.Item_Code), clsGenaralName.getName_Uom(detail.Uom), detail.Qty, detail.Weight, detail.TatalAmount, "", 0);
                                            }
                                        }
                                        #endregion
                                        glb_dtsScsGoodTransferNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        //rpt.print("\\Reports\\SCS\\Registry\\rpt_scs_GoodTransferNote_Detail.rpt", glb_dtsScsGoodTransferNote, glb_dtsReportExport.dt_rptParameter);
                                        //     rpt.Process_Print((int)enum_ReportName.RG_Good_Transfer_Note_Details);
                                        rpt.print(sReportPath, glb_dtsScsGoodTransferNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                        #endregion
                                    }
                                    catch (Exception ex)
                                    {
                                        SEACCException.Show(ex);
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                    }
                                    finally
                                    {
                                        glb_dtsScsGoodTransferNote.dt_scsGoodTransferNote.Clear();
                                        glb_dtsScsGoodTransferNote.dt_scsGoodTransferNote_Detail.Clear();

                                        Cursor = Cursors.Default;
                                    }

                                    bStoreSelected = false;
                                }
                                #endregion

                                #region FGTN Summary
                                else if (Report == enum_ReportName.RG_Finished_Goods_Transfer_Note_Summary) // rdoFGTNSummary.Checked
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dts_scsFGTN.Clear();

                                        #region Fill Details
                                        List<tbl_scsStoreProduction> oFGTNs = tbl_scsStoreProduction.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => p.StoreProduction_ID != "default" && p.StoreProductionDate.Date >= dtpFrom.Value.Date && p.StoreProductionDate.Date <= dtpTo.Value.Date).ToList();
                                        foreach (tbl_scsStoreProduction oFGTN in oFGTNs)
                                        {
                                            if (rdoDeleted.Checked && !oFGTN.IsDeleted)
                                                continue;
                                            else if (rdoActual.Checked && oFGTN.IsDeleted)
                                                continue;

                                            bool bStoreOK = true;
                                            if (bStoreSelected)
                                                bStoreOK = txtStore.Tag.ToString().Trim() == oFGTN.Store_ID ? true : false;

                                            if (bStoreOK)
                                            {
                                                glb_dts_scsFGTN.dt_scsStoreProductionSummary.Adddt_scsStoreProductionSummaryRow(oFGTN.StoreProduction_ID, oFGTN.StoreProductionDate, clsGenaralName.getName_Store(oFGTN.Store_ID), oFGTN.Remark, oFGTN.IsDeleted);
                                            }
                                            clsHelpMethods.startProgressBar(0, oFGTNs.Count + 2, 1, ProgressBar);
                                        }
                                        #endregion

                                        glb_dts_scsFGTN.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter, "", "");

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        //rpt.Process_Print((int)sReportName);
                                        rpt.print(sReportPath, glb_dts_scsFGTN, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        Cursor = Cursors.Default;
                                        glb_dts_scsFGTN.Clear();
                                    }
                                }
                                #endregion

                                #region FGTN Details
                                else if (Report == enum_ReportName.RG_Finished_Goods_Transfer_Note_Details) //rdoFGTNDetails.Checked
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dts_scsFGTN.Clear();

                                        #region Fill Detail
                                        List<tbl_scsStoreProduction> oFGNs = tbl_scsStoreProduction.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => p.StoreProduction_ID != "default" && p.StoreProductionDate.Date >= dtpFrom.Value.Date && p.StoreProductionDate.Date <= dtpTo.Value.Date).ToList();
                                        foreach (tbl_scsStoreProduction oFGTN in oFGNs)
                                        {
                                            if (rdoDeleted.Checked && !oFGTN.IsDeleted)
                                                continue;
                                            else if (rdoActual.Checked && oFGTN.IsDeleted)
                                                continue;

                                            bool bStoreOK = true;
                                            if (bStoreSelected)
                                            {
                                                bStoreOK = txtStore.Tag.ToString().Trim() == oFGTN.Store_ID ? true : false;
                                            }

                                            if (bStoreOK)
                                            {
                                                foreach (tbl_scsStoreProduction_Detail oFGINDetails in tbl_scsStoreProduction_Detail.SelectAllByStoreProduction_ID(oFGTN.StoreProduction_ID).Where(p => p.Item_ID != "default" && p.StoreProduction_ID != "default"))
                                                {
                                                    string sBrandModel = clsGenaralName.getName_ItemSubCategory(oFGINDetails.ItemSubCategory_ID);
                                                    sBrandModel = sBrandModel == "default" ? "N/A" : sBrandModel;
                                                    glb_dts_scsFGTN.dt_scsStoreProductionDetails.Adddt_scsStoreProductionDetailsRow(oFGINDetails.Item_ID, clsGenaralName.getName_Item(oFGINDetails.Item_ID), sBrandModel,
                                                    oFGINDetails.Qty, oFGINDetails.Weight, oFGTN.StoreProduction_ID);
                                                }
                                                glb_dts_scsFGTN.dt_scsStoreProductionSummary.Adddt_scsStoreProductionSummaryRow(oFGTN.StoreProduction_ID, oFGTN.StoreProductionDate, clsGenaralName.getName_Store(oFGTN.Store_ID), oFGTN.Remark, oFGTN.IsDeleted);
                                            }
                                            clsHelpMethods.startProgressBar(0, oFGNs.Count + 2, 1, ProgressBar);
                                        }
                                        #endregion

                                        glb_dts_scsFGTN.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter, "", "");


                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        //      rpt.Process_Print((int)sReportName);
                                        rpt.print(sReportPath, glb_dts_scsFGTN, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        Cursor = Cursors.Default;
                                        glb_dts_scsFGTN.Clear();
                                    }
                                }

                                #endregion

                                #region Store Internal GIN Details
                                else if (Report == enum_ReportName.RG_Internal_Store_GIN_Detail)  //rdbInternalStoreGINDetails.Checked
                                {
                                    #region Old Report
                                    if (!clsConfig.bDataSetActive_iGIN)
                                    {
                                        sFormula = ""; sFilter = "";
                                        sFormula += " {vw_rpt_scsStoreGoodIssueNote.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsStoreGoodIssueNote.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                        if (rdoDeleted.Checked)
                                            sFormula += " and {vw_rpt_scsStoreGoodIssueNote.isDeleted} =True";
                                        if (rdoActual.Checked)
                                            sFormula += " and {vw_rpt_scsStoreGoodIssueNote.isDeleted} = False";


                                        if (bStoreSelected)
                                        {
                                            sFormula += " and {vw_rpt_scsStoreGoodIssueNote.toStore_ID}= '" + txtStore.Tag.ToString() + "'";
                                            sFilter += " Store ID : " + txtStore.Text.Trim();
                                        }
                                        if (bSectionSelected)
                                        {
                                            sFormula += " and {vw_rpt_scsStoreGoodIssueNote.toSection_ID}= '" + txtSection.Tag.ToString() + "'";
                                            sFilter += " Section ID : " + txtSection.Text.Trim();
                                        }
                                        if (bDepartmetSelected)
                                        {
                                            sFormula += " and {vw_rpt_scsStoreGoodIssueNote.toDepartment_ID}= '" + txtDepartment.Tag.ToString() + "'";
                                            sFilter += " Department ID : " + txtDepartment.Text.Trim();
                                        }

                                        iReportNo = (int)enum_ReportName.RG_Internal_Store_GIN_Detail;
                                        print("\\reports\\SCS\\Registry\\rpt_scs_Store_iGIN_Register_Detail.rpt", "Store Goods Issues", "[iGIN Detailed]", "  ", sFormula.ToString(), sFilter);
                                    }
                                    #endregion

                                    #region DataSet
                                    else
                                    {
                                        try
                                        {
                                            glb_dts_scsStoreGoodsIssueNote.Clear();
                                            glb_dtsReportExport.Clear();
                                            Cursor = Cursors.WaitCursor;

                                            #region Fill Detail
                                            //List<tbl_genStoreMaster> oStr;

                                            //#region Filter - Store
                                            //if (!bStoreSelected)
                                            //    oStr = tbl_genStoreMaster.SelectAll().ToList();
                                            //else
                                            //    oStr = tbl_genStoreMaster.SelectAll().Where(p => p.Store_ID == txtStore.Tag.ToString()).ToList();
                                            //#endregion

                                            //foreach (tbl_genStoreMaster oStore in oStr.Where(p => p.Store_ID != "default"))
                                            //{
                                            foreach (tbl_scsStoreGoodIssueNote detail in tbl_scsStoreGoodIssueNote.SelectAll().Where(p => p.StoreGoodIssueNote_ID != "default" && p.StoreGoodIssueNoteDate.Date >= dtpFrom.Value.Date && p.StoreGoodIssueNoteDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == txtBranch.Tag.ToString()))
                                            {
                                                if (bStoreSelected)
                                                    if (detail.FromStore_ID != txtStore.Tag.ToString())
                                                        continue;

                                                if (bSectionSelected)
                                                    if (detail.ToStore_ID != txtSection.Tag.ToString())
                                                        continue;

                                                #region Filter - Deleted Records
                                                if (rdoDeleted.Checked)
                                                {
                                                    if (!detail.IsDeleted)
                                                        continue;
                                                }
                                                else if (rdoActual.Checked)
                                                {
                                                    if (detail.IsDeleted)
                                                        continue;
                                                }
                                                #endregion

                                                glb_dts_scsStoreGoodsIssueNote.dt_scsStoreGoodsIssueNote.Adddt_scsStoreGoodsIssueNoteRow(detail.StoreGoodIssueNote_ID, clsGenaralName.getName_Store(detail.FromStore_ID), detail.Remark, detail.IsDeleted, detail.StoreGoodIssueNoteDate, detail.DateCreate, detail.ToStore_ID, clsGenaralName.getName_Store(detail.ToStore_ID), detail.FromStore_ID,"","",DateTime.MinValue);

                                                List<tbl_scsStoreGoodIssueNote_Detail> oGRN_Det = tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(detail.StoreGoodIssueNote_ID);
                                                if (bItemIDSelected)
                                                    oGRN_Det = oGRN_Det.Where(p => p.Item_ID == txtItemID.Tag.ToString()).ToList();

                                                foreach (tbl_scsStoreGoodIssueNote_Detail idetail in oGRN_Det)
                                                {
                                                    glb_dts_scsStoreGoodsIssueNote.dt_scsStoreGoodsIssueNote_Detail.Adddt_scsStoreGoodsIssueNote_DetailRow(idetail.StoreGoodIssueNote_ID, "",
                                                        idetail.Item_ID, clsGenaralName.getName_Item(idetail.Item_ID), "", "", idetail.ItemSerialNo,
                                                        idetail.Qty, idetail.Weight, 0, 0, idetail.UnitPrice, idetail.Remark, "", "", detail.FromStore_ID, idetail.Job_ID, detail.ToStore_ID, clsGenaralName.getName_Store(detail.ToStore_ID), idetail.StoreRequisitionNote_ID, clsGenaralName.getName_Store(detail.FromStore_ID), clsGenaralName.getName_Department(idetail.ToDepartment_ID), idetail.Uom_ID, clsGenaralName.getName_Uom(idetail.Uom_ID),0,0);
                                                }
                                            }
                                            //  } 
                                            #endregion

                                            glb_dts_scsStoreGoodsIssueNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            //     rpt.Process_Print((int)enum_ReportName.RG_Internal_Store_GIN_Detail);
                                            rpt.print(sReportPath, glb_dts_scsStoreGoodsIssueNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                        }
                                        catch (Exception ex)
                                        {
                                            clsValidate.WriteErrorLog("", iFormID,ex);
                                            SEACCException.Show(ex);
                                        }
                                        finally
                                        {
                                            glb_dts_scsStoreGoodsIssueNote.Clear();
                                            glb_dtsReportExport.Clear();
                                            Cursor = Cursors.Default;

                                        }
                                    }
                                    #endregion
                                }
                                #endregion

                                #region Store Internal-GIN Summary
                                else if (Report == enum_ReportName.RG_Internal_Store_GIN_Summary) //rdbInternalStoreGIN.Checked
                                {
                                    #region Old Report
                                    if (!clsConfig.bDataSetActive_CustomerOrder)
                                    {
                                        sFormula = "";
                                        sFormula += " {vw_rpt_scsStoreGoodIssueNote.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsStoreGoodIssueNote.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                        if (rdoDeleted.Checked)
                                            sFormula += " and {vw_rpt_scsStoreGoodIssueNote.isDeleted} =True";
                                        if (rdoActual.Checked)
                                            sFormula += " and {vw_rpt_scsStoreGoodIssueNote.isDeleted} = False";


                                        if (bStoreSelected)
                                        {
                                            sFormula += " and {vw_rpt_scsStoreGoodIssueNote.toStore_ID}= '" + txtStore.Tag.ToString() + "'";
                                            sFilter += " Store ID : " + txtStore.Text.Trim();
                                        }
                                        if (bSectionSelected)
                                        {
                                            sFormula += " and {vw_rpt_scsStoreGoodIssueNote.toSection_ID}= '" + txtSection.Tag.ToString() + "'";
                                            sFilter += " Section ID : " + txtSection.Text.Trim();
                                        }
                                        if (bDepartmetSelected)
                                        {
                                            sFormula += " and {vw_rpt_scsStoreGoodIssueNote.toDepartment_ID}= '" + txtDepartment.Tag.ToString() + "'";
                                            sFilter += " Department ID : " + txtDepartment.Text.Trim();
                                        }

                                        iReportNo = (int)enum_ReportName.RG_Internal_Store_GIN_Summary;
                                        print("\\reports\\SCS\\Registry\\rpt_scs_Store_iGIN_Summary.rpt", "Store Goods Issues", "[iGIN Summary]", " ", sFormula.ToString(), sFilter);
                                    }
                                    #endregion

                                    #region DataSet
                                    else
                                    {
                                        try
                                        {
                                            glb_dts_scsStoreGoodsIssueNote.Clear();
                                            glb_dtsReportExport.Clear();
                                            Cursor = Cursors.WaitCursor;

                                            #region Fill Detail
                                            //List<tbl_genStoreMaster> oStr;

                                            //#region Filter - Store
                                            //if (!bStoreSelected)
                                            //    oStr = tbl_genStoreMaster.SelectAll().ToList();
                                            //else
                                            //    oStr = tbl_genStoreMaster.SelectAll().Where(p => p.Store_ID == txtStore.Tag.ToString()).ToList();
                                            //#endregion

                                            // foreach (tbl_genStoreMaster oStore in oStr.Where(p => p.Store_ID != "default"))
                                            //{
                                            foreach (tbl_scsStoreGoodIssueNote detail in tbl_scsStoreGoodIssueNote.SelectAll().Where(p => p.StoreGoodIssueNote_ID != "default" && p.StoreGoodIssueNoteDate.Date >= dtpFrom.Value.Date && p.StoreGoodIssueNoteDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == txtBranch.Tag.ToString()))
                                            {
                                                if (bStoreSelected)
                                                    if (detail.FromStore_ID != txtStore.Tag.ToString())
                                                        continue;

                                                if (bSectionSelected)
                                                    if (detail.ToStore_ID != txtSection.Tag.ToString())
                                                        continue;

                                                #region Filter - Deleted Records
                                                if (rdoDeleted.Checked)
                                                {
                                                    if (!detail.IsDeleted)
                                                        continue;
                                                }
                                                else if (rdoActual.Checked)
                                                {
                                                    if (detail.IsDeleted)
                                                        continue;
                                                }
                                                #endregion

                                                glb_dts_scsStoreGoodsIssueNote.dt_scsStoreGoodsIssueNote.Adddt_scsStoreGoodsIssueNoteRow(detail.StoreGoodIssueNote_ID, clsGenaralName.getName_Store(detail.FromStore_ID), detail.Remark, detail.IsDeleted, detail.StoreGoodIssueNoteDate, detail.DateCreate, detail.ToStore_ID, clsGenaralName.getName_Store(detail.ToStore_ID), detail.FromStore_ID,"","",DateTime.MinValue);
                                            }
                                            #endregion

                                            glb_dts_scsStoreGoodsIssueNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            //    rpt.Process_Print((int)enum_ReportName.RG_Internal_Store_GIN_Summary);
                                            rpt.print(sReportPath, glb_dts_scsStoreGoodsIssueNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                        }
                                        catch (Exception ex)
                                        {
                                            clsValidate.WriteErrorLog("", iFormID,ex);
                                            SEACCException.Show(ex);
                                        }
                                        finally
                                        {
                                            glb_dts_scsStoreGoodsIssueNote.Clear();
                                            glb_dtsReportExport.Clear();
                                            Cursor = Cursors.Default;

                                        }
                                    }
                                    #endregion
                                }
                                #endregion

                                #region GIN Summary & Detail
                                else if (Report == enum_ReportName.RG_GIN_Summary || Report == enum_ReportName.RG_GIN_Detail)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsReportExport.Clear();
                                        glb_dtsExternalGoodIssueNote.Clear();

                                        #region Fill Detail
                                        foreach (tbl_scsExternalGoodIssueNote Issue in tbl_scsExternalGoodIssueNote.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && p.ExternalGoodIssueNoteDate.Date >= dtpFrom.Value.Date && p.ExternalGoodIssueNoteDate.Date <= dtpTo.Value.Date))
                                        {

                                            #region Filter-Store
                                            if (txtStore.Tag != null && txtStore.Tag.ToString() != Issue.Store_ID)
                                                continue;
                                            #endregion
                                            #region Filter-Deleted Recorded
                                            if (rdoDeleted.Checked)
                                            {
                                                if (!Issue.IsDeleted)
                                                    continue;
                                            }
                                            else if (rdoActual.Checked)
                                            {
                                                if (Issue.IsDeleted)
                                                    continue;
                                            }
                                            #endregion
                                            #region Filter-Customer
                                            if (txtCustomer.Tag != null && txtCustomer.Tag.ToString() != Issue.Customer_ID)
                                                continue;
                                            #endregion
                                            #region Filter-Supplier
                                            if (txtSupplier.Tag != null && txtSupplier.Tag.ToString() != Issue.Supplier_ID)
                                                continue;


                                            #endregion

                                            glb_dtsExternalGoodIssueNote.dt_scsExternalGoodsIssueNote.Adddt_scsExternalGoodsIssueNoteRow(Issue.ExternalGoodIssueNote_ID, Issue.ExternalGoodIssueNoteDate, Issue.ReceiverName, Issue.IssuedRefNo_ID, Issue.Store_ID, clsGenaralName.getName_Store(Issue.Store_ID), Issue.Remark, Issue.IsWeightCalculation, Issue.IsDeleted, clsGenaralName.getName_User(Issue.CreateUser_ID));

                                            if (Report == enum_ReportName.RG_GIN_Detail)
                                            {
                                                foreach (tbl_scsExternalGoodIssueNote_Detail oDetail in tbl_scsExternalGoodIssueNote_Detail.SelectAllByExternalGoodIssueNote_ID(Issue.ExternalGoodIssueNote_ID))
                                                {
                                                    glb_dtsExternalGoodIssueNote.dt_scsExternalGoodsIssueNoteDetail.Adddt_scsExternalGoodsIssueNoteDetailRow(oDetail.ExternalGoodIssueNote_ID, oDetail.Item_ID, clsGenaralName.getName_Item(oDetail.Item_ID), oDetail.Qty, oDetail.Weight, oDetail.KiloPrice, oDetail.Remark);
                                                }
                                            }
                                        }
                                        #endregion

                                        glb_dtsExternalGoodIssueNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsExternalGoodIssueNote, glb_dtsReportExport.dt_rptParameter, clsHelpMethods.GetReportPath(clsAutocode.getReportID(Report)));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        glb_dtsReportExport.Clear();
                                        glb_dtsExternalGoodIssueNote.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region DGN Detailed & Summary
                                else if (Report == enum_ReportName.RG_DGN_Summary || Report == enum_ReportName.RG_DGN_Detail) //rdoDGNSummery.Checked || rdoDGNDetail.Checked
                                {
                                    try
                                    {
                                        glb_dtsReportExport.Clear();
                                        glb_dtsDamageGoods.Clear();
                                        Cursor = Cursors.WaitCursor;

                                        #region Fill Detail
                                        foreach (tbl_scsDamagedGoodNote header in tbl_scsDamagedGoodNote.SelectAll().Where(p => p.DamagedGoodNoteDate.Date >= dtpFrom.Value.Date && p.DamagedGoodNoteDate.Date <= dtpTo.Value.Date))
                                        {
                                            #region Filter-Store
                                            if (txtStore.Tag != null && txtStore.Tag.ToString() != header.Store_ID)
                                                continue;
                                            #endregion

                                            #region Filter-Deleted Recorded
                                            if (rdoDeleted.Checked)
                                            {
                                                if (!header.IsDeleted)
                                                    continue;
                                            }
                                            else if (rdoActual.Checked)
                                            {
                                                if (header.IsDeleted)
                                                    continue;
                                            }
                                            #endregion

                                            glb_dtsDamageGoods.dt_scsDamageGood.Adddt_scsDamageGoodRow(header.DamagedGoodNote_ID, header.DamagedGoodNoteDate, header.Store_ID, clsGenaralName.getName_Store(header.Store_ID), header.Remark, header.IssuedRefNo_ID, header.CreateUser_ID, header.IsSeattled, header.IsDeleted);

                                            if (Report == enum_ReportName.RG_DGN_Detail)
                                            {
                                                foreach (tbl_scsDamagedGoodNote_Detail detail in tbl_scsDamagedGoodNote_Detail.SelectAllByDamagedGoodNote_ID(header.DamagedGoodNote_ID))
                                                {
                                                    glb_dtsDamageGoods.dt_scsDamageGood_Detail.Adddt_scsDamageGood_DetailRow(detail.DamagedGoodNote_ID, detail.Item_ID, clsGenaralName.getName_Item(detail.Item_ID), detail.ItemSubCategory_ID, clsGenaralName.getName_ItemSubCategory(detail.ItemSubCategory_ID), detail.Qty, detail.Weight, clsGenaralName.getName_ItemUOMName(detail.Item_ID), detail.Remark, clsGenaralName.getName_Store(detail.Store_ID));
                                                }
                                            }
                                        }
                                        #endregion

                                        glb_dtsDamageGoods.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter, "", "");

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsDamageGoods, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        glb_dtsDamageGoods.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region DIN Detail & Summary
                                else if (Report == enum_ReportName.RG_DIN_Summary || Report == enum_ReportName.RG_DIN_Detail)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;

                                        glb_dts_DIN.Clear();
                                        glb_dtsReportExport.Clear();

                                        #region Fill Detail
                                        List<tbl_scsDiscardedGoodNote> oDisList;
                                        if (bStoreSelected)
                                            oDisList = tbl_scsDiscardedGoodNote.SelectAll().Where(p => p.Store_ID == txtStore.Tag.ToString() && p.DiscardedGoodNoteDate.Date >= dtpFrom.Value.Date && p.DiscardedGoodNoteDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == txtBranch.Tag.ToString()).ToList();
                                        else
                                            oDisList = tbl_scsDiscardedGoodNote.SelectAll().Where(p => p.DiscardedGoodNoteDate.Date >= dtpFrom.Value.Date && p.DiscardedGoodNoteDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == txtBranch.Tag.ToString()).ToList();

                                        foreach (tbl_scsDiscardedGoodNote oDis in oDisList)
                                        {
                                            #region Filter-Store
                                            if (txtStore.Tag != null && txtStore.Tag.ToString() != oDis.Store_ID)
                                                continue;
                                            #endregion

                                            if (rdoDeleted.Checked && !oDis.IsDeleted)
                                                continue;
                                            else if (rdoActual.Checked && oDis.IsDeleted)
                                                continue;

                                            glb_dts_DIN.dt_DIN.Adddt_DINRow(oDis.DiscardedGoodNote_ID, oDis.DiscardedGoodNoteDate, oDis.Store_ID, clsGenaralName.getName_Store(oDis.Store_ID), oDis.GrandTotal, oDis.Remark, oDis.IsDeleted);

                                            foreach (tbl_scsDiscardedGoodNote_Detail oDisDetails in tbl_scsDiscardedGoodNote_Detail.SelectAllByDiscardedGoodNote_ID(oDis.DiscardedGoodNote_ID))
                                            {
                                                tbl_genItemMaster oItem = tbl_genItemMaster.Select(oDisDetails.Item_ID);
                                                tbl_genItemMaster_Pricing oItemF = tbl_genItemMaster_Pricing.Select(oDisDetails.Item_ID);
                                                if (oItem != null && oItemF != null)
                                                {
                                                    glb_dts_DIN.dt_DIN_Details.Adddt_DIN_DetailsRow(oDisDetails.DiscardedGoodNote_ID, oDisDetails.Item_ID,
                                                        oItem.ItemName, oItem.ItemCategory_ID, "", oItem.ItemCategorySub_ID, "", "", clsGenaralName.getName_ItemUOM(oDisDetails.Item_ID), oDisDetails.DiscardingQty, oDisDetails.DamagedQty, oDisDetails.DiscardingWeight, oDisDetails.SalvageValue, oDisDetails.Remark, oItemF.WeightedAverageCostPrice, oItemF.HighestPurchaseCostPrice);
                                                }
                                            }

                                            clsHelpMethods.startProgressBar(0, oDisList.Count + 2, 1, ProgressBar);
                                        }
                                        #endregion

                                        glb_dts_DIN.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter, "", "");

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        //    rpt.Process_Print((int)enum_ReportName.RG_DIN_Detail);
                                        rpt.print(sReportPath, glb_dts_DIN, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID((Report)));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        Cursor = Cursors.Default;
                                        glb_dts_DIN.Clear();
                                        glb_dtsReportExport.Clear();
                                    }
                                }
                                #endregion

                                #region Store ISR Detail & Summary
                                else if (Report == enum_ReportName.RG_Internal_Store_ISRSummary || Report == enum_ReportName.RG_Internal_Store_ISR_Detail) // rdbInternalStoreSRSummary.Checked || rdbInternalStoreSRDetail.Checked
                                {
                                    try
                                    {
                                        glb_dtsReportExport.Clear();
                                        glb_dtsStoreRequisition.Clear();
                                        Cursor = Cursors.WaitCursor;

                                        #region Fill Detail
                                        foreach (tbl_scsStoreReqositionNote header in tbl_scsStoreReqositionNote.SelectAll().Where(p => p.StoreRecositionNoteDate.Date >= dtpFrom.Value.Date && p.StoreRecositionNoteDate.Date <= dtpTo.Value.Date))
                                        {
                                            #region Filter-Store
                                            if (txtStore.Tag != null && txtStore.Tag.ToString() != header.ToStore_ID)
                                                continue;
                                            #endregion

                                            #region Filter-Deleted Recorded
                                            if (rdoDeleted.Checked)
                                            {
                                                if (!header.IsDeleted)
                                                    continue;
                                            }
                                            else if (rdoActual.Checked)
                                            {
                                                if (header.IsDeleted)
                                                    continue;
                                            }
                                            #endregion

                                            glb_dtsStoreRequisition.dt_scsStoreRequisitionNote.Adddt_scsStoreRequisitionNoteRow(header.StoreRecositionNote_ID, header.PurchaseRequisitionNote_ID, header.StoreRecositionNoteDate, header.Job_ID, header.IssuedRefNo_ID, header.FromStore_ID, clsGenaralName.getName_Store(header.FromStore_ID), header.ToStore_ID, clsGenaralName.getName_Store(header.ToStore_ID), header.ToDepartment_ID, clsGenaralName.getName_Department(header.ToDepartment_ID), header.ToSection_ID, clsGenaralName.getName_Section(header.ToSection_ID), header.ToSection_ID, header.DateCreate, header.Remark, header.IsDeleted);

                                            if (Report == enum_ReportName.RG_Internal_Store_ISR_Detail)
                                            {
                                                foreach (tbl_scsStoreReqositionNote_Detail detail in tbl_scsStoreReqositionNote_Detail.SelectAllByStoreRecositionNote_ID(header.StoreRecositionNote_ID))
                                                {
                                                    glb_dtsStoreRequisition.dt_scsStoreRequisitionNote_Detail.Adddt_scsStoreRequisitionNote_DetailRow(detail.StoreRecositionNote_ID, detail.Item_ID, clsGenaralName.getName_Item(detail.Item_ID), detail.ItemSerialNo, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, clsGenaralName.getName_ItemType(detail.Item_ID), detail.Uom_ID, detail.Qty, detail.Qty, detail.Weight, detail.WeightSettle, detail.UnitPrice, detail.WeightPrice, detail.Remark);
                                                }
                                            }
                                        }
                                        #endregion

                                        glb_dtsStoreRequisition.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsStoreRequisition, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        glb_dtsStoreRequisition.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Purchase Requisition Detail & Summary
                                else if (Report == enum_ReportName.RG_PurchaseRequisitionSummary || Report == enum_ReportName.RG_PurchaseRequisitionDetail)
                                {
                                    #region Fill Detail
                                    try
                                    {
                                        glb_dtsReportExport.Clear();
                                        glb_dtsPurchaseRequisitionNote.Clear();
                                        Cursor = Cursors.WaitCursor;

                                        #region Fill Detail
                                        foreach (tbl_scsPurchaseRequisition header in tbl_scsPurchaseRequisition.SelectAll().Where(p => p.PurchaseRequisitionNoteDate.Date >= dtpFrom.Value.Date && p.PurchaseRequisitionNoteDate.Date <= dtpTo.Value.Date))
                                        {
                                            #region Filter-Store
                                            if (bStoreSelected && txtStore.Tag.ToString() != header.FromStore_ID)
                                                continue;
                                            #endregion
                                            #region Filter-Department
                                            if (bDepartmetSelected && txtDepartment.Tag.ToString() != header.FromDepartment_ID)
                                                continue;
                                            #endregion
                                            #region Filter-Section
                                            if (bSectionSelected && txtSection.Tag.ToString() != header.FromSection_ID)
                                                continue;
                                            #endregion
                                            #region Filter-Deleted Recorded
                                            if (rdoDeleted.Checked)
                                            {
                                                if (!header.IsDeleted)
                                                    continue;
                                            }
                                            else if (rdoActual.Checked)
                                            {
                                                if (header.IsDeleted)
                                                    continue;
                                            }
                                            #endregion

                                            glb_dtsPurchaseRequisitionNote.dt_PurchaseRequisitionNote.Adddt_PurchaseRequisitionNoteRow(header.PurchaseRequisitionNote_ID, 
                                                header.PurchaseRequisitionNoteDate, clsGenaralName.getName_Department(header.FromDepartment_ID), clsGenaralName.getName_Section(header.FromSection_ID), 
                                                clsGenaralName.getName_Store(header.FromStore_ID), clsGenaralName.getName_Area(header.FromSelectArea_ID), header.FromSelectArea_ID, header.FromDepartment_ID, 
                                                header.FromStore_ID, header.Remark, header.Job_ID, header.RequestedBy, header.DateCreate, header.IsDeleted, 1, "", "");

                                            if (Report == enum_ReportName.RG_PurchaseRequisitionDetail)
                                            {
                                                foreach (tbl_scsPurchaseRequisition_Detail detail in tbl_scsPurchaseRequisition_Detail.SelectAllByPurchaseRequisitionNote_ID(header.PurchaseRequisitionNote_ID))
                                                {
                                                    glb_dtsPurchaseRequisitionNote.dt_PurchaseRequisitionNoteDetail.Adddt_PurchaseRequisitionNoteDetailRow(detail.PurchaseRequisitionNote_ID, detail.Item_ID, 
                                                        detail.ItemSubCategory_ID, detail.ItemSerialNo, detail.ItemSubCategory2_ID, detail.ItemSerialNo2, detail.FromSelectArea_ID, detail.FromDepartment_ID, 
                                                        detail.FromSection_ID, detail.FromStore_ID, detail.Qty, detail.QtySettle, detail.Weight, clsGenaralName.getName_UomAndCode(detail.Uom_ID), 
                                                        clsGenaralName.getName_Item(detail.Item_ID), clsGenaralName.getName_Uom(detail.Uom_ID), detail.Remark, 0);
                                                }
                                            }
                                        }
                                        #endregion

                                        glb_dtsPurchaseRequisitionNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsPurchaseRequisitionNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        glb_dtsPurchaseRequisitionNote.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                    #endregion
                                }
                                #endregion

                                #region Item Split Detail & Summary
                                else if (Report == enum_ReportName.RG_ItemSplitSummary || Report == enum_ReportName.RG_ItemSplitDetail)
                                {
                                    #region New Report
                                    try
                                    {
                                        string sItemId = "", sISubCategory = "", sISubCategory2 = "", sIsInOut = "", sRemarks = "";
                                        decimal dQty = 0, dWeight = 0;

                                        glb_dts_SplitNote.Clear();
                                        glb_dtsReportExport.Clear();

                                        #region Fill Detail
                                        Cursor = Cursors.WaitCursor;
                                        string sStoreID = "";

                                        foreach (tbl_scsItemSpred detail in tbl_scsItemSpred.SelectAll().Where(p => p.ItemSpred_ID != "default" && p.ItemSpredDate.Date >= dtpFrom.Value.Date && p.ItemSpredDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == txtBranch.Tag.ToString()))
                                        {
                                            //if (bStoreSelected)
                                            //    if (detail.Store_ID != txtStore.Tag.ToString())
                                            //        continue;
                                            #region Filter
                                            if (rdoDeleted.Checked && !detail.IsDeleted)
                                                continue;
                                            else if (rdoActual.Checked && detail.IsDeleted)
                                                continue;
                                            #endregion

                                            #region From
                                            foreach (tbl_scsItemSpred_Detail_From detailsFrom in tbl_scsItemSpred_Detail_From.SelectAllByItemSpred_ID(detail.ItemSpred_ID))
                                            {

                                                //if (bStoreSelected)
                                                //    if (detailsFrom.Store_ID != txtStore.Tag.ToString())
                                                //        continue;

                                                //sItemId += detailsFrom.Item_ID;
                                                //sISubCategory += detailsFrom.ItemSubCategory_ID;
                                                //sISubCategory2 += detailsFrom.ItemSubCategory2_ID;
                                                //dQty += detailsFrom.Qty;
                                                //dWeight += detailsFrom.Weight;
                                                //sRemarks += detailsFrom.Remark;
                                                //sIsInOut += "Inputs";

                                                sItemId = detailsFrom.Item_ID;
                                                sISubCategory = detailsFrom.ItemSubCategory_ID;
                                                sISubCategory2 = detailsFrom.ItemSubCategory2_ID;
                                                dQty = detailsFrom.Qty;
                                                dWeight = detailsFrom.Weight;
                                                sRemarks = detailsFrom.Remark;
                                                sIsInOut = "Inputs";
                                                sStoreID = detailsFrom.Store_ID;

                                                glb_dts_SplitNote.dt_SplitNote_Detail.Adddt_SplitNote_DetailRow(detail.ItemSpred_ID, sItemId, clsGenaralName.getName_Item(sItemId), sISubCategory, "", sISubCategory2, "", "", "", "", dQty, dWeight, 0, 0, 0, sRemarks, sIsInOut);
                                            }
                                            #endregion

                                            #region To
                                            foreach (tbl_scsItemSpred_Detail_To detailsTo in tbl_scsItemSpred_Detail_To.SelectAllByItemSpred_ID(detail.ItemSpred_ID))
                                            {
                                                //sItemId += detailsTo.Item_ID;
                                                //sISubCategory += detailsTo.ItemSubCategory_ID;
                                                //sISubCategory2 += detailsTo.ItemSubCategory2_ID;
                                                //dQty += detailsTo.Qty;
                                                //dWeight += detailsTo.Weight;
                                                //sRemarks += detailsTo.Remark;
                                                //sIsInOut += "Outputs";

                                                sItemId = detailsTo.Item_ID;
                                                sISubCategory = detailsTo.ItemSubCategory_ID;
                                                sISubCategory2 = detailsTo.ItemSubCategory2_ID;
                                                dQty = detailsTo.Qty;
                                                dWeight = detailsTo.Weight;
                                                sRemarks = detailsTo.Remark;
                                                sIsInOut = "Outputs";

                                                glb_dts_SplitNote.dt_SplitNote_Detail.Adddt_SplitNote_DetailRow(detail.ItemSpred_ID, sItemId, clsGenaralName.getName_Item(sItemId), sISubCategory, "", sISubCategory2, "", "", "", "", dQty, dWeight, 0, 0, 0, sRemarks, sIsInOut);
                                            }
                                            #endregion

                                            if (bStoreSelected)
                                                if (sStoreID != txtStore.Tag.ToString())
                                                    continue;

                                            glb_dts_SplitNote.dt_SplitNote.Adddt_SplitNoteRow(detail.ItemSpred_ID, detail.ItemSpredDate, detail.Remark, sStoreID, clsGenaralName.getName_Store(sStoreID), detail.QtyInputTotal, detail.QtyOutputTotal, detail.WeightInputTotal, detail.WeightOutputTotal, detail.IsChecked, detail.IsApproved, detail.IsFinished, detail.IsDeleted, detail.IsLocked, detail.IsSeattled, detail.CreateUser_ID, clsGenaralName.getName_User(detail.CreateUser_ID));
                                        }
                                        #endregion

                                        glb_dts_SplitNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dts_SplitNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        glb_dts_scsStoreGoodsReceiveNote.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                    #endregion
                                }
                                #endregion

                                #region Stock Adjustment Details & Summary
                                else if (Report == enum_ReportName.RG_Stock_Adjustment_Summery || Report == enum_ReportName.RG_Stock_Adjustment_Details)  //rdoStockAdjustmentSummery.Checked || rdoStockAdjustmentDetail.Checked
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;

                                        glb_dts_scsStockAdjustment.Clear();
                                        glb_dtsReportExport.Clear();
                                        //fill data table
                                        #region Fill Details
                                        List<tbl_scsStockAdjustment> oSANs = tbl_scsStockAdjustment.SelectAll().Where(p => p.StockAdjustment_ID != "default" && p.StockAdjustmentDate.Date >= dtpFrom.Value.Date && p.StockAdjustmentDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == txtBranch.Tag.ToString()).ToList();
                                        foreach (tbl_scsStockAdjustment oSAN in oSANs)
                                        {
                                            bool bStoreOK = true, bSectionOK = true, bDepartmentOK = true;

                                            #region Filters
                                            //add filters - janith
                                            if (rdoDeleted.Checked && !oSAN.IsDeleted)
                                                continue;
                                            else if (rdoActual.Checked && oSAN.IsDeleted)
                                                continue;

                                            if (bStoreSelected)
                                                bStoreOK = txtStore.Tag.ToString().Trim() == oSAN.Store_ID ? true : false;
                                            else if (bDepartmetSelected)
                                                bDepartmentOK = txtDepartment.Tag.ToString().Trim() == oSAN.Department_ID ? true : false;
                                            else if (bSectionSelected)
                                                bSectionOK = txtSection.Tag.ToString().Trim() == oSAN.Section_ID ? true : false;
                                            #endregion

                                            if (bStoreOK && bSectionOK && bDepartmentOK)
                                            {
                                                //change stock adjustment summary data table fill -- early method is below in new method - change by janith
                                                glb_dts_scsStockAdjustment.dt_scsStockAdjustment.Adddt_scsStockAdjustmentRow(oSAN.StockAdjustment_ID, oSAN.StockAdjustmentDate, clsGenaralName.getName_User(oSAN.CreateUser_ID),
                                                      clsGenaralName.getName_Department(oSAN.Department_ID), clsGenaralName.getName_Section(oSAN.Section_ID), clsGenaralName.getName_Store(oSAN.Store_ID), oSAN.Remark, oSAN.IsDeleted);
                                                //glb_dts_scsStockAdjustment.dt_scsStockAdjustment.Rows.Add(oSAN.StockAdjustment_ID, oSAN.StockAdjustmentDate, clsGenaralName.getName_User(oSAN.CreateUser_ID),
                                                //clsGenaralName.getName_Department(oSAN.Department_ID), clsGenaralName.getName_Section(oSAN.Section_ID), clsGenaralName.getName_Store(oSAN.Store_ID), oSAN.Remark);
                                                foreach (tbl_scsStockAdjustment_Detail oSANDetail in tbl_scsStockAdjustment_Detail.SelectAllByStockAdjustment_ID(oSAN.StockAdjustment_ID))
                                                {
                                                    glb_dts_scsStockAdjustment.dt_scsStockAdjustment_Detail.Adddt_scsStockAdjustment_DetailRow(oSANDetail.Item_ID, clsGenaralName.getName_Item(oSANDetail.Item_ID),
                                                       oSANDetail.UnitPrice, oSANDetail.Qty, oSANDetail.Weight, clsGenaralName.getCategoryID_ItemSubCategory(oSANDetail.ItemSubCategory_ID), oSANDetail.StockAdjustment_ID, oSANDetail.OldQty, oSANDetail.OldWeight);
                                                }

                                            }
                                            //clsHelpMethods.startProgressBar(0, oSANs.Count + 2, 1, ProgressBar);
                                        }
                                        #endregion

                                        //if (rdoStockAdjustmentDetail.Checked)
                                        //    print("\\Reports\\SCS\\Registry\\rpt_scs_StockAdjustment_Detail.rpt", " Adjusted Stocks Register ", "[SAN Detailed]", "", glb_dts_scsStockAdjustment);
                                        //else if (rdoStockAdjustmentSummery.Checked)
                                        //    print("\\Reports\\SCS\\Registry\\rpt_scs_StockAdjustment_Summary.rpt", " Adjusted Stocks Register ", "[SAN Summary]", "", glb_dts_scsStockAdjustment);



                                        //change the report display format for new version
                                        glb_dts_scsStockAdjustment.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter, clsCommon.getCompanyVAT(), clsCommon.getCompanySVAT());

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        //      rpt.Process_Print((int)sReportName);
                                        rpt.print(sReportPath, glb_dts_scsStockAdjustment, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        Cursor = Cursors.Default;
                                        glb_dts_scsStockAdjustment.dt_scsStockAdjustment.Rows.Clear();
                                        glb_dts_scsStockAdjustment.dt_scsStockAdjustment_Detail.Rows.Clear();
                                    }
                                }
                                #endregion

                                #region Section Internal-SR Summary
                                else if (Report == enum_ReportName.RG_Internal_Section_iSR_Summary)
                                {
                                    sFormula = ""; sFilter = "";
                                    sFormula += " {vw_rpt_scsSectionRequisitionNote.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsSectionRequisitionNote.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                    if (rdoDeleted.Checked)
                                        sFormula += " and {vw_rpt_scsSectionRequisitionNote.isDeleted} =True";
                                    if (rdoActual.Checked)
                                        sFormula += " and {vw_rpt_scsSectionRequisitionNote.isDeleted} = False";

                                    if (bStoreSelected)
                                    {
                                        sFormula += " and {vw_rpt_scsSectionRequisitionNote.toStore_ID}= '" + txtStore.Tag.ToString() + "'";
                                        sFilter += "Store ID : " + txtStore.Text.Trim();
                                    }
                                    if (bSectionSelected)
                                    {
                                        sFormula += " and {vw_rpt_scsSectionRequisitionNote.toSection_ID}= '" + txtSection.Tag.ToString() + "'";
                                        sFilter += "Section ID : " + txtSection.Text.Trim();
                                    }
                                    if (bDepartmetSelected)
                                    {
                                        sFormula += " and {vw_rpt_scsSectionRequisitionNote.toDepartment_ID}= '" + txtDepartment.Tag.ToString() + "'";
                                        sFilter += "Department ID : " + txtDepartment.Text.Trim();
                                    }

                                    iReportNo = (int)enum_ReportName.RG_Internal_Section_iSR_Summary;
                                    print("\\reports\\SCS\\Registry\\rpt_scs_Section_iSR_Summary.rpt", "Inter-Section Goods Trf. ", "[IST-Prod. Summary]", "", sFormula.ToString(), sFilter);
                                }
                                #endregion

                                #region Section Internal-SR Detail
                                else if (Report == enum_ReportName.RG_Internal_Section_iSR_Detail)
                                {
                                    sFormula = ""; sFilter = "";
                                    sFormula += " {vw_rpt_scsSectionRequisitionNote.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsSectionRequisitionNote.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                    if (rdoDeleted.Checked)
                                        sFormula += " and {vw_rpt_scsSectionRequisitionNote.isDeleted} =True";
                                    if (rdoActual.Checked)
                                        sFormula += " and {vw_rpt_scsSectionRequisitionNote.isDeleted} = False";

                                    if (bStoreSelected)
                                    {
                                        sFormula += " and {vw_rpt_scsSectionRequisitionNote.toStore_ID}= '" + txtStore.Tag.ToString() + "'";
                                        sFilter += "Store ID : " + txtStore.Text.Trim();
                                    }
                                    if (bSectionSelected)
                                    {
                                        sFormula += " and {vw_rpt_scsSectionRequisitionNote.toSection_ID}= '" + txtSection.Tag.ToString() + "'";
                                        sFilter += "Section ID : " + txtSection.Text.Trim();
                                    }
                                    if (bDepartmetSelected)
                                    {
                                        sFormula += " and {vw_rpt_scsSectionRequisitionNote.toDepartment_ID}= '" + txtDepartment.Tag.ToString() + "'";
                                        sFilter += "Department ID : " + txtDepartment.Text.Trim();
                                    }

                                    iReportNo = (int)enum_ReportName.RG_Internal_Section_iSR_Detail;
                                    print("\\reports\\SCS\\Registry\\rpt_scs_Section_iSR_Register_Detail.rpt", " Inter-Section Goods Trf. ", "[IST-Prod. Detailed]", "", sFormula.ToString(), sFilter);
                                }
                                #endregion

                                #region Section Internal-GIN Details
                                else if (Report == enum_ReportName.RG_Internal_Section_GIN_Detail) //rdbInternalSecrtionGINDetail.Checked
                                {
                                    sFormula = "";
                                    sFormula += " {vw_rpt_scsSectionGoodIssueNote.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsSectionGoodIssueNote.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                    if (rdoDeleted.Checked)
                                        sFormula += " and {vw_rpt_scsSectionGoodIssueNote.isDeleted} =True";
                                    if (rdoActual.Checked)
                                        sFormula += " and {vw_rpt_scsSectionGoodIssueNote.isDeleted} = False";


                                    if (bStoreSelected)
                                    {
                                        sFormula += " and {vw_rpt_scsSectionGoodIssueNote.toStore_ID}= '" + txtStore.Tag.ToString() + "'";
                                        sFilter += " Store ID : " + txtStore.Text.Trim();
                                    }
                                    if (bSectionSelected)
                                    {
                                        sFormula += " and {vw_rpt_scsSectionGoodIssueNote.toSection_ID}= '" + txtSection.Tag.ToString() + "'";
                                        sFilter += " Section ID : " + txtSection.Text.Trim();
                                    }
                                    if (bDepartmetSelected)
                                    {
                                        sFormula += " and {vw_rpt_scsSectionGoodIssueNote.toDepartment_ID}= '" + txtDepartment.Tag.ToString() + "'";
                                        sFilter += " Department ID : " + txtDepartment.Text.Trim();
                                    }

                                    iReportNo = (int)enum_ReportName.RG_Internal_Section_GIN_Detail;
                                    print("\\reports\\SCS\\Registry\\rpt_scs_Section_iGIN_Register_Detail.rpt", "Section Goods Issues", "[iGIN Detailed]", "", sFormula.ToString(), sFilter);
                                }
                                #endregion

                                #region Section Internal-GIN Summary
                                else if (Report == enum_ReportName.RG_Internal_Section_GINSummary) //rdbInternalSectionGINSummary.Checked
                                {
                                    sFormula = ""; sFilter = "";
                                    sFormula += " {vw_rpt_scsSectionGoodIssueNote.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsSectionGoodIssueNote.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                    if (rdoDeleted.Checked)
                                        sFormula += " and {vw_rpt_scsSectionGoodIssueNote.isDeleted} =True";
                                    if (rdoActual.Checked)
                                        sFormula += " and {vw_rpt_scsSectionGoodIssueNote.isDeleted} = False";


                                    if (bStoreSelected)
                                    {
                                        sFormula += " and {vw_rpt_scsSectionGoodIssueNote.toStore_ID}= '" + txtStore.Tag.ToString() + "'";
                                        sFilter += " Store ID : " + txtStore.Text.Trim();
                                    }
                                    if (bSectionSelected)
                                    {
                                        sFormula += " and {vw_rpt_scsSectionGoodIssueNote.toSection_ID}= '" + txtSection.Tag.ToString() + "'";
                                        sFilter += " Section ID : " + txtSection.Text.Trim();
                                    }
                                    if (bDepartmetSelected)
                                    {
                                        sFormula += " and {vw_rpt_scsSectionGoodIssueNote.toDepartment_ID}= '" + txtDepartment.Tag.ToString() + "'";
                                        sFilter += " Department ID : " + txtDepartment.Text.Trim();
                                    }

                                    iReportNo = (int)enum_ReportName.RG_Internal_Section_GINSummary;
                                    print("\\reports\\SCS\\Registry\\rpt_scs_Section_iGIN_Summary.rpt", "Section Goods Issues ", "[iGIN Summary]", "", sFormula.ToString(), sFilter);
                                }
                                #endregion

                                #region Section Internal-GRN Summary
                                else if (Report == enum_ReportName.RG_Internal_Section_GRNSummary)
                                {
                                    sFormula = ""; sFilter = "";

                                    sFormula += " {vw_rpt_scsSectionGoodReceiveNote.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsSectionGoodReceiveNote.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                    if (rdoDeleted.Checked)
                                        sFormula += " and {vw_rpt_scsSectionGoodReceiveNote.isDeleted} =True";
                                    if (rdoActual.Checked)
                                        sFormula += " and {vw_rpt_scsSectionGoodReceiveNote.isDeleted} = False";


                                    if (bStoreSelected)
                                    {
                                        sFormula += " and {vw_rpt_scsSectionGoodReceiveNote.fromStore_ID}= '" + txtStore.Tag.ToString() + "'";
                                        sFilter += " Store ID : " + txtStore.Text.Trim();
                                    }
                                    if (bSectionSelected)
                                    {
                                        sFormula += " and {vw_rpt_scsSectionGoodReceiveNote.fromSection_ID}= '" + txtSection.Tag.ToString() + "'";
                                        sFilter += " Section ID : " + txtSection.Text.Trim();
                                    }
                                    if (bDepartmetSelected)
                                    {
                                        sFormula += " and {vw_rpt_scsSectionGoodReceiveNote.fromDepartment_ID}= '" + txtDepartment.Tag.ToString() + "'";
                                        sFilter += " Department ID : " + txtDepartment.Text.Trim();
                                    }

                                    if (rdoDeleted.Checked)
                                        sFilter += (sFilter != "" ? " | " : "") + "Cancelled Records Only ";
                                    if (rdoActual.Checked)
                                        sFilter += (sFilter != "" ? " | " : "") + "Active records Only ";
                                    if (rdoAll.Checked)
                                        sFilter += (sFilter != "" ? " | " : "") + "All Records ";

                                    iReportNo = (int)enum_ReportName.RG_Internal_Section_GRNSummary;
                                    print("\\reports\\SCS\\Registry\\rpt_scs_Section_iGRN_Summary.rpt", "Section Goods Receipts ", "[iGRN Summary]", "", sFormula.ToString(), sFilter);

                                }
                                #endregion

                                #region Section Internal-GRN Details
                                else if (Report == enum_ReportName.RG_Internal_Section_GRNDetail) //rdbInternalSectionGRNDetail.Checked
                                {
                                    sFormula = ""; sFilter = "";
                                    sFormula += " {vw_rpt_scsSectionGoodReceiveNote.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_scsSectionGoodReceiveNote.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                                    if (rdoDeleted.Checked)
                                        sFormula += " and {vw_rpt_scsSectionGoodReceiveNote.isDeleted} =True";

                                    if (rdoActual.Checked)
                                        sFormula += " and {vw_rpt_scsSectionGoodReceiveNote.isDeleted} = False";

                                    if (bStoreSelected)
                                    {
                                        sFormula += " and {vw_rpt_scsSectionGoodReceiveNote.fromStore_ID}= '" + txtStore.Tag.ToString() + "'";
                                        sFilter += " Store ID : " + txtStore.Text.Trim();
                                    }
                                    if (bSectionSelected)
                                    {
                                        sFormula += " and {vw_rpt_scsSectionGoodReceiveNote.fromSection_ID}= '" + txtSection.Tag.ToString() + "'";
                                        sFilter += " Section ID : " + txtSection.Text.Trim();
                                    }
                                    if (bDepartmetSelected)
                                    {
                                        sFormula += " and {vw_rpt_scsSectionGoodReceiveNote.fromDepartment_ID}= '" + txtDepartment.Tag.ToString() + "'";
                                        sFilter += " Department ID : " + txtDepartment.Text.Trim();
                                    }

                                    iReportNo = (int)enum_ReportName.RG_Internal_Section_GRNDetail;
                                    print("\\reports\\SCS\\Registry\\rpt_scs_Section_iGRN_Register_Detail.rpt", "Section Goods Receipts", "[iGRN Detailed]", "", sFormula.ToString(), sFilter);
                                }
                                #endregion

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID,ex);
                        SEACCException.Show(ex);
                    }
                }
            }
        }
        #endregion

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearField();
        }
        #endregion

        #region Clear Field
        private void clearField()
        {
            txtStore.Tag = null;
            txtSupplier.Tag = null;
            txtCustomer.Tag = null;
            txtSection.Tag = null;
            txtDepartment.Tag = null;
            txtItemID.Tag = null;
            txtStockNoteType.Tag = null;
            txtBranch.Tag = clsSecurity.BranchID;

            tbl_genCompanyBranchMaster oBranch = tbl_genCompanyBranchMaster.Select(clsSecurity.BranchID);
            if (oBranch != null)
            {
                if (!oBranch.IsHeadOffice)
                {
                    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBranch, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblBranch, false);
                }
            }

            txtStore.Text = "<All Stores>";
            txtSection.Text = "<All Sections>";
            txtDepartment.Text = "<All Departments>";
            txtCustomer.Text = "<All Customers>";
            txtSupplier.Text = "<All Suppliers>";
            txtItemID.Text = "<All Items>";
            txtStockNoteType.Text = "<All Note Types>";

            txtBranch.Text = clsGenaralName.getName_CompanyBranchMaster(clsSecurity.BranchID);
            //txtStockNoteType.Text = "";
            //clsCommon.SetEnableDisable_NormalLabel(lblStore, true);
            //lblStore.Text = "Store Name";
            //clsCommon.SetEnableDisable_NormalLabel(lblSection, true);
            //lblSection.Text = "Section Name";

            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtStore, true);
            clsCommon.SetEnableDisable_NormalLabel(lblStore, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSection, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSection, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtDepartment, true);
            clsCommon.SetEnableDisable_NormalLabel(lblDepartment, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSupplier, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSupplier, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemID, false);
            clsCommon.SetEnableDisable_NormalLabel(lblItemID, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtStockNoteType, true);
            clsCommon.SetEnableDisable_NormalLabel(lblNoteType, true);

            dtpFrom.Value = clsSecurity.getServerDateTime();
            dtpTo.Value = clsSecurity.getServerDateTime();

            clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
            clsCommon.SetEnableDisable_NormalLabel(lblFrom, true);
            clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblTo, true);

            clsCommon.SetEnableDisable_NormalRadioButton(rdoDeleted, true);
            clsCommon.SetEnableDisable_NormalRadioButton(rdoActual, true);
            clsCommon.SetEnableDisable_NormalRadioButton(rdoAll, true);

            rdoDeleted.Checked = false;
            rdoActual.Checked = true;
            rdoAll.Checked = false;

            ckhShowAll.Checked = false;

            clsCommon.SetVisibility_Panel(pnlBranch, true);
            clsCommon.SetVisibility_Panel(pnlCustomer, false);
            clsCommon.SetVisibility_Panel(pnlDepartment, false);
            clsCommon.SetVisibility_Panel(pnlItem, false);
            clsCommon.SetVisibility_Panel(pnlNoteType, false);
            clsCommon.SetVisibility_Panel(pnlSection, false);
            clsCommon.SetVisibility_Panel(pnlStore, false);
            clsCommon.SetVisibility_Panel(pnlSupplier, false);
        }
        #endregion

        #region Event DoublClick
        private void txtStore_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStore(ref txtStore, true);
        }

        private void txtCustomer_DoubleClick_1(object sender, EventArgs e)
        {
            clsSearch.Search_MasterCustomer(ref txtCustomer, ckhShowAll.Checked);
        }

        private void txtSupplier_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterSupplier(ref txtSupplier);
        }

        private void txtSection_DoubleClick(object sender, EventArgs e)
        {
            if (dgvReports.SelectedCells.Count != 0)
            {
                int iRow = dgvReports.SelectedCells[0].RowIndex;
                int iReport = int.Parse(dgvReports.Rows[iRow].Cells[0].Value.ToString());
                enum_ReportName Report = (enum_ReportName)iReport;

                if (Report == enum_ReportName.RG_Good_Transfer_Note_Summery || Report == enum_ReportName.RG_Good_Transfer_Note_Details ||
                    Report == enum_ReportName.RG_Internal_Store_GIN_Summary || Report == enum_ReportName.RG_Internal_Store_GIN_Detail ||
                    Report == enum_ReportName.RG_Internal_Store_GRN_Summary || Report == enum_ReportName.RG_Internal_Store_GRN_Detail)
                    clsSearch.Search_MasterStore(ref txtSection, true);
                else
                    clsSearch.Search_MasterSection(ref txtSection);
            }
        }

        private void txtDepartment_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterDepartment(ref txtDepartment);
        }

        private void txtItem_DoubleClick(object sender, EventArgs e)
        {
            clsHelpMethods.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
        }

        private void txtStockNoteType_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStockNoteType(ref txtStockNoteType);
        }

        private void txtBranch_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_CompanyBranch(ref txtBranch);
        }
        #endregion

        #region Data Grid Event
        private void dgvReports_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int iReportID = clsValidate.ValidateGridValue(dgvReports, "report_ID", e.RowIndex, 0);
                setEnableDisableConctrol(iReportID);
            }

        }

        private void dgvReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvReports_CellClick(sender, e);
        }
        #endregion

        #region Event Keydown
        private void txtStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterStore(ref txtStore, true);
        }

        private void txtSection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtSection_DoubleClick(null, null);
        }

        private void txtDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterDepartment(ref txtDepartment);
        }

        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterCustomer(ref txtCustomer, ckhShowAll.Checked);
        }

        private void txtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterSupplier(ref txtSupplier);
        }
        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsHelpMethods.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
            }
        }
        private void txtStockNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterStockNoteType(ref txtStockNoteType);
        }
        #endregion

        #region Print Method
        private void print(string path, string sReportTitle1, string sReportTitle2, string sReportTitle3, string sFormula, string sFilter)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Stock Register";
                ReportDocument RD = new ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                frm_ReportViewer viewer = new frm_ReportViewer();
                RD.Load(s_Path);
                clsSecurity.LogonServer(ref RD);
                RD.Refresh();

                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString() || clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                {
                    //if (rdoDINDetail.Checked || rdoDGNDetail.Checked)
                    //{
                    //    RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);
                    //}
                }

                RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                RD.DataDefinition.FormulaFields["ReportTitle1"].Text = clsCommon.fncsetstring(sReportTitle1);
                RD.DataDefinition.FormulaFields["ReportTitle2"].Text = clsCommon.fncsetstring(sReportTitle2);
                RD.DataDefinition.FormulaFields["ReportTitle3"].Text = clsCommon.fncsetstring(sReportTitle3);
                RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + clsFormatter.FormatDate_Short(dtpFrom.Value) + "      To : " + clsFormatter.FormatDate_Short(dtpTo.Value));
                RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                RD.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);

                //if (rdoGrnSummary.Checked)
                //{
                //    if (txtStore.Tag != null)
                //        RD.DataDefinition.FormulaFields["StoreName"].Text = clsCommon.fncsetstring(txtStore.Text);
                //    else
                //        RD.DataDefinition.FormulaFields["StoreName"].Text = clsCommon.fncsetstring("All Stores");
                //}

                //if (rdoDGNDetail.Checked)
                //    RD.DataDefinition.FormulaFields["Damagedstore"].Text = clsCommon.fncsetstring(clsGenaralName.getName_Store(clsConfig.sDamagedGoodsStore));

                viewer.Process_Print(iReportNo);
                viewer.crystalReportViewer1.ReportSource = RD;
                viewer.crystalReportViewer1.SelectionFormula = sFormula;
                viewer.crystalReportViewer1.Visible = true;
                viewer.crystalReportViewer1.DisplayToolbar = true;
                viewer.crystalReportViewer1.CloseView(false);
                viewer.WindowState = FormWindowState.Maximized;

                viewer.ShowDialog();

                RD.Close();
                RD.Dispose();
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
        private void print(string path, string sReportTitle1, string sReportTitle2, string sReportTitle3, DataSet ojbDataSet)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Stock Register", sReportFilter = "";
                //   CrystalDecisions.CrystalReports.Engine.ReportDocument objRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                ReportDocument objRpt = new ReportDocument();

                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(ojbDataSet); //(glbDtsBills);

                objRpt.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                objRpt.DataDefinition.FormulaFields["ReportTitle1"].Text = clsCommon.fncsetstring(sReportTitle1);
                objRpt.DataDefinition.FormulaFields["ReportTitle2"].Text = clsCommon.fncsetstring(sReportTitle2);
                objRpt.DataDefinition.FormulaFields["ReportTitle3"].Text = clsCommon.fncsetstring(sReportTitle3);
                objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                sReportFilter = "";

                if (txtItemID.Tag != null && txtItemID.Tag.ToString().Length > 0)
                    sReportFilter = "Item : " + txtItemID.Text.Trim();

                if (txtStore.Tag != null && txtStore.Tag.ToString().Length > 0)
                    sReportFilter += (sReportFilter != "" ? " | " : "") + "Store : " + txtStore.Text.Trim();

                if (txtDepartment.Tag != null && txtDepartment.Tag.ToString().Length > 0)
                    sReportFilter += (sReportFilter != "" ? " | " : "") + " Department : " + txtDepartment.Text.Trim();

                if (txtSection.Tag != null && txtSection.Tag.ToString().Length > 0)
                    sReportFilter += (sReportFilter != "" ? " | " : "") + " Section : " + txtSection.Text.Trim();

                //if (txtItemID.Tag != null && txtItemID.Tag.ToString().Length > 0)
                //    sReportFilter += (sReportFilter != "" ? " | " : "") + "Item ID :" + txtItemID.Text;

                if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Length > 0)
                    sReportFilter += (sReportFilter != "" ? " | " : "") + "Customer : " + txtCustomer.Text.Trim();

                if (txtSupplier.Tag != null && txtSupplier.Tag.ToString().Length > 0)
                    sReportFilter += (sReportFilter != "" ? " | " : "") + "Supplier : " + txtSupplier.Text.Trim();

                if (rdoDeleted.Checked)
                    sReportFilter += (sReportFilter != "" ? " | " : "") + "Cancelled Records Only ";
                if (rdoActual.Checked)
                    sReportFilter += (sReportFilter != "" ? " | " : "") + "Active records Only ";
                if (rdoAll.Checked)
                    sReportFilter += (sReportFilter != "" ? " | " : "") + "All Records ";

                objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sReportFilter);

                frm_ReportViewer ReportViewer = new frm_ReportViewer();
                ReportViewer.Process_Print(iReportNo);
                ReportViewer.crystalReportViewer1.ReportSource = objRpt;
                ReportViewer.crystalReportViewer1.Refresh();
                ReportViewer.crystalReportViewer1.DisplayToolbar = true;
                ReportViewer.crystalReportViewer1.CloseView(false);
                ReportViewer.WindowState = FormWindowState.Maximized;
                ReportViewer.ShowDialog();

                objRpt.Close();
                objRpt.Dispose();
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
        private void print(string path, string sReportTitle, DataTable objDataTable)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Standed Reports", sReportFilter = "";
                CrystalDecisions.CrystalReports.Engine.ReportDocument objRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(objDataTable); //(glbDtsBills);

                objRpt.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);


                if (txtItemID.Tag != null && txtItemID.Tag.ToString().Length > 0)
                    bItemIDSelected = true;
                if (txtStore.Tag != null && txtStore.Tag.ToString().Length > 0)
                    sReportFilter += "Store ID : " + txtStore.Text.Trim();
                if (txtDepartment.Tag != null && txtDepartment.Tag.ToString().Length > 0)
                    sReportFilter += " Department ID : " + txtDepartment.Text.Trim();
                if (txtSection.Tag != null && txtSection.Tag.ToString().Length > 0)
                    sReportFilter += " Section ID : " + txtSection.Text.Trim();
                if (bItemIDSelected)
                    sReportFilter += "Item ID :" + txtItemID.Text.Trim();
                if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Length > 0)
                    sReportFilter += "Customer ID : " + txtCustomer.Text.Trim();
                if (txtSupplier.Tag != null && txtSupplier.Tag.ToString().Length > 0)
                    sReportFilter += "Supplier ID : " + txtSupplier.Text.Trim();

                if (rdoDeleted.Checked)
                    sReportFilter += (sReportFilter != "" ? " | " : "") + "Cancelled Records Only ";
                if (rdoActual.Checked)
                    sReportFilter += (sReportFilter != "" ? " | " : "") + "Active records Only ";
                if (rdoAll.Checked)
                    sReportFilter += (sReportFilter != "" ? " | " : "") + "All Records ";


                objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sReportFilter);

                frm_ReportViewer ReportViewer = new frm_ReportViewer();
                ReportViewer.Process_Print(iReportNo);
                ReportViewer.crystalReportViewer1.ReportSource = objRpt;
                ReportViewer.crystalReportViewer1.Refresh();
                ReportViewer.crystalReportViewer1.DisplayToolbar = true;
                ReportViewer.crystalReportViewer1.CloseView(false);
                ReportViewer.WindowState = FormWindowState.Maximized;
                ReportViewer.ShowDialog();

                objRpt.Close();
                objRpt.Dispose();
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

        #region Set Enable/Disable Controls
        private void setEnableDisableConctrol(int iReportID)
        {
            clearField();

            if (iReportID == (int)enum_ReportName.RG_ItemSplitSummary || iReportID == (int)enum_ReportName.RG_ItemSplitDetail ||
                iReportID == (int)enum_ReportName.RG_GIN_Detail || iReportID == (int)enum_ReportName.RG_DIN_Summary ||
                iReportID == (int)enum_ReportName.RG_DIN_Detail || iReportID == (int)enum_ReportName.RG_Internal_Store_ISRSummary ||
                iReportID == (int)enum_ReportName.RG_Internal_Store_ISR_Detail || iReportID == (int)enum_ReportName.RG_PRNSummary ||
                iReportID == (int)enum_ReportName.RG_DGN_Summary || iReportID == (int)enum_ReportName.RG_GIN_Summary ||
                iReportID == (int)enum_ReportName.RG_GRNSummary || iReportID == (int)enum_ReportName.RG_GRNDetail ||
                iReportID == (int)enum_ReportName.RG_PRNDetails)
            {
                clsCommon.SetVisibility_Panel(pnlStore, true);
            }


            //Store / Section / Department
            if (iReportID == (int)enum_ReportName.RG_PRNSummary || iReportID == (int)enum_ReportName.RG_PRNDetails ||
                iReportID == (int)enum_ReportName.RG_Stock_Adjustment_Details || iReportID == (int)enum_ReportName.RG_Stock_Adjustment_Summery ||
                iReportID == (int)enum_ReportName.RG_Internal_Store_GIN_Summary || iReportID == (int)enum_ReportName.RG_Internal_Store_GIN_Detail ||
                iReportID == (int)enum_ReportName.RG_Internal_Store_GRN_Summary || iReportID == (int)enum_ReportName.RG_Internal_Store_GRN_Detail ||
                iReportID == (int)enum_ReportName.RG_Internal_Section_iSR_Summary || iReportID == (int)enum_ReportName.RG_DGN_Detail ||
                iReportID == (int)enum_ReportName.RG_PurchaseRequisitionSummary || iReportID == (int)enum_ReportName.RG_PurchaseRequisitionDetail)
            {
                clsCommon.SetVisibility_Panel(pnlStore, true);
                clsCommon.SetVisibility_Panel(pnlSection, true);
                clsCommon.SetVisibility_Panel(pnlDepartment, true);
            }

            //Supplier
            if (iReportID == (int)enum_ReportName.RG_POSummary || iReportID == (int)enum_ReportName.RG_PODetail ||
                iReportID == (int)enum_ReportName.RG_DGN_Summary || iReportID == (int)enum_ReportName.RG_GIN_Summary ||
                iReportID == (int)enum_ReportName.RG_GRNSummary || iReportID == (int)enum_ReportName.RG_GRNDetail ||
                iReportID == (int)enum_ReportName.RG_PRNDetails)
            {
                clsCommon.SetVisibility_Panel(pnlSupplier, true);
            }

            //Customer
            if (iReportID == (int)enum_ReportName.RG_GIN_Summary)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
            }

            //Stock Note Type
            if (iReportID == (int)enum_ReportName.RG_PODetail || iReportID == (int)enum_ReportName.RG_POSummary)
            {
                clsCommon.SetVisibility_Panel(pnlNoteType, true);
            }

            //Hide Department
            if (iReportID == (int)enum_ReportName.RG_Internal_Store_GIN_Summary || iReportID == (int)enum_ReportName.RG_Internal_Store_GIN_Detail ||
            iReportID == (int)enum_ReportName.RG_Internal_Store_GRN_Summary || iReportID == (int)enum_ReportName.RG_Internal_Store_GRN_Detail ||
            iReportID == (int)enum_ReportName.RG_Internal_Section_iSR_Summary)
            {
                clsCommon.SetVisibility_Panel(pnlDepartment, false);
            }

            //Item Only
            //if (iReportID == (int)enum_ReportName.RG_GRNDetail || iReportID == (int)enum_ReportName.RG_PODetail ||
            //    iReportID == (int)enum_ReportName.RG_Internal_Store_GRN_Detail || iReportID == (int)enum_ReportName.RG_Internal_Store_GIN_Detail ||
            //    iReportID == (int)enum_ReportName.RG_Internal_Section_GIN_Detail || iReportID == (int)enum_ReportName.RG_Internal_Section_iSR_Detail ||
            //    iReportID == (int)enum_ReportName.RG_Internal_Section_GRNDetail  )
            //{
            //    clsCommon.SetVisibility_Panel(pnlItem, true);
            //}

            //Section
            if (iReportID == (int)enum_ReportName.RG_Internal_Section_GINSummary || iReportID == (int)enum_ReportName.RG_Internal_Section_GIN_Detail ||
                iReportID == (int)enum_ReportName.RG_Internal_Section_iSR_Detail || iReportID == (int)enum_ReportName.RG_Internal_Section_GRNSummary)
            {
                clsCommon.SetVisibility_Panel(pnlSection, true);
            }

            //From Stores / To Section
            if (iReportID == (int)enum_ReportName.RG_Finished_Goods_Transfer_Note_Summary || iReportID == (int)enum_ReportName.RG_Finished_Goods_Transfer_Note_Details ||
                iReportID == (int)enum_ReportName.RG_Internal_Store_GIN_Summary || iReportID == (int)enum_ReportName.RG_Good_Transfer_Note_Details || iReportID == (int)enum_ReportName.RG_Good_Transfer_Note_Summery ||
                iReportID == (int)enum_ReportName.RG_Internal_Store_GIN_Detail || iReportID == (int)enum_ReportName.RG_Internal_Store_GRN_Summary ||
                iReportID == (int)enum_ReportName.RG_Internal_Section_GRNDetail)
            {
                lblStore.Text = "From Store Name";
                lblSection.Text = "To Store Name";
                txtSection.Text = "<All Stores>";

                clsCommon.SetVisibility_Panel(pnlStore, true);
                clsCommon.SetVisibility_Panel(pnlSection, true);
            }
        }
        #endregion

        #region Search Methods
        private void Search_StockNoteType()
        {
            clsSearch.Search_MasterStockNoteType(ref txtStockNoteType);
        }
        #endregion

        public bool bItemIDSelected { get; set; }

        public bool bCustomerSelected { get; set; }

        public bool bSuplierSelected { get; set; }

    }
}


