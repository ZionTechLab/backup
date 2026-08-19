using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DataTire;
using Digiteq.DataSets.SAS;
using Digiteq.DataSets;

namespace Digiteq
{
    public partial class frm_rpt_SalesRegister : MettroForm
    {
        #region Variables
        //form manage
        public int iFormID;

        //for security handle
        public bool bNoAccess;
        bool bCustomerSelected = false, bCustomerClassSelected = false, bCustomerTypeSelected = false, bCustomerCategorySelected = false, bSelesRepSelected = false,
            bItemSelected = false, bSalesNoteTypeSelected = false, bJobTypeSelected = false, bDOTypeSelected = false, bRouteSelected = false;

        //objects from datasets     

        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        dts_sasCustomerOrder glb_dts_sasCustomerOrder = new dts_sasCustomerOrder();
        dts_DeliveryOrders glb_dts_sasDeliveryOrder = new dts_DeliveryOrders();
        dts_sasSalesReturn glb_dtsSalesReturn = new dts_sasSalesReturn();
        dts_sasInvoice glb_dtsSalesInvoice = new dts_sasInvoice();
        dts_Sales glb_dtsSales = new dts_Sales();
        dts_sasQuotation glb_dtsQuotation = new dts_sasQuotation();
        dts_PerformSummery glb_dtsProform = new dts_PerformSummery();
        dts_sasInquiry glb_dtsInquiry = new dts_sasInquiry();



        private int iReportNo;

        #endregion

        #region Form Load
        public frm_rpt_SalesRegister()
        {
            iFormID = clsSecurity.getFormID(FormName.ReportSalesRegister);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;
            InitializeComponent();
        }

        private void frmReportChequeDeposit_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Sales Register", 2, iFormID);
            ThemeColor = clsFormatter.colorSales;

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
                dgvReports.DataSource = DBHandling.ExecQuery("EXEC sp_Reports '" + 6 + "'").Tables[0];
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
                                #region Filter
                                ProgressBar.Value = 0;
                                //get selection controls
                                bCustomerSelected = false; bCustomerClassSelected = false; bCustomerTypeSelected = false; bCustomerCategorySelected = false; bSelesRepSelected = false;
                                bItemSelected = false; bSalesNoteTypeSelected = false; bJobTypeSelected = false; bRouteSelected = false;
                                string sFilter = "";

                                string sDaterange = "From  : " + dtpFrom.Value.Date.ToString("dd-MMM-yyyy") + " TO : " + dtpTo.Value.Date.ToString("dd-MMM-yyyy");

                                if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Trim().Length > 0)
                                    bCustomerSelected = true;
                                if (txtRoute.Tag != null && txtRoute.Tag.ToString().Trim().Length > 0)
                                    bRouteSelected = true;
                                if (txtCusClass.Tag != null && txtCusClass.Tag.ToString().Trim().Length > 0)
                                    bCustomerClassSelected = true;
                                if (txtCusType.Tag != null && txtCusType.Tag.ToString().Trim().Length > 0)
                                    bCustomerTypeSelected = true;
                                if (txtCusCategory.Tag != null && txtCusCategory.Tag.ToString().Trim().Length > 0)
                                    bCustomerCategorySelected = true;
                                if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Trim().Length > 0)
                                    bSelesRepSelected = true;
                                if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0)
                                    bItemSelected = true;
                                if (txtSalesNoteType.Tag != null && txtSalesNoteType.Tag.ToString().Trim().Length > 0)
                                    bSalesNoteTypeSelected = true;
                                if (txtJobType.Tag != null && txtJobType.Tag.ToString().Trim().Length > 0)
                                    bJobTypeSelected = true;
                                if (cmbDOType.SelectedIndex != 0)
                                    bDOTypeSelected = true;
                                #endregion

                                #region Selected Filters
                                if (txtBranch.Tag != null)
                                    sFilter += " Company Branch : " + txtBranch.Text.Trim();
                                if (bCustomerClassSelected)
                                    sFilter += " Customer Class : " + txtCusClass.Text.Trim();
                                if (bCustomerClassSelected)
                                    sFilter += " Customer Type : " + txtCusType.Text.Trim();
                                if (bCustomerCategorySelected)
                                    sFilter += " Customer Category : " + txtCusCategory.Text.Trim();
                                if (bCustomerSelected)
                                    sFilter += " Customer Name : " + txtCustomer.Text.Trim();
                                if (bSelesRepSelected)
                                    sFilter += " Sales Rep. Name : " + txtSalesRep.Text.Trim();
                                if (bDOTypeSelected)
                                    sFilter += " Do Type : " + cmbDOType.SelectedText.Trim();
                                        
                                if (bSalesNoteTypeSelected)
                                    sFilter += " Sales Note Type : " + txtSalesNoteType.Tag.ToString();
                                if (bRouteSelected)
                                    sFilter += " Route Code : " + txtRoute.Tag.ToString();

                                if (bItemSelected)
                                    sFilter += " Item Name : " + txtItemID.Text.Trim();

                                //add selected filter - janith
                                if (rdoDeleted.Checked)
                                    sFilter += (sFilter != "" ? " | " : "") + "Cancelled Records Only ";
                                if (rdoActual.Checked)
                                    sFilter += (sFilter != "" ? " | " : "") + "Active records Only ";
                                if (rdoAll.Checked)
                                    sFilter += (sFilter != "" ? " | " : "") + "All Records ";

                                #endregion

                                #region Sales Return Summary / Details
                                if (Report == enum_ReportName.RG_SalesReturnDetail || Report == enum_ReportName.RG_SalesReturnSummary)
                                {
                                    string sRouteID = "";
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        bool bOkToInsert = false;
                                        glb_dtsSalesReturn.Clear();

                                        //fill data table
                                        #region Fill Details
                                        List<tbl_sasSalesReturnedNote> oSRetNote = tbl_sasSalesReturnedNote.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && p.SalesReturnedNoteDate.Date >= dtpFrom.Value.Date && p.SalesReturnedNoteDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == clsSecurity.BranchID).ToList();
                                        foreach (tbl_sasSalesReturnedNote oSRN in oSRetNote)
                                        {
                                            //add filters - janith
                                            if (rdoDeleted.Checked && !oSRN.IsDeleted)
                                                continue;
                                            else if (rdoActual.Checked && oSRN.IsDeleted)
                                                continue;

                                            if (bCustomerSelected)
                                            {
                                                if (oSRN.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oSRN.Customer_ID);
                                            if (oCustomer != null)
                                            {
                                                #region Route
                                                if (bRouteSelected)
                                                {
                                                    if (!chkUseCustomerMastorRoute.Checked)
                                                    {
                                                        sRouteID = oSRN.Route_ID.ToString();
                                                    }
                                                    else
                                                    {
                                                        foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oSRN.Customer_ID))
                                                        {
                                                            sRouteID = oRoute.Route_ID.ToString();
                                                            if (txtRoute.Tag.ToString() == sRouteID)
                                                                break;
                                                        }
                                                    }

                                                    if (txtRoute.Tag.ToString() != sRouteID)
                                                        continue;
                                                }
                                                #endregion

                                                if (bCustomerClassSelected)
                                                {
                                                    if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }
                                            }

                                            bool bSalesRepOK = true, bCustomerOK = true; bOkToInsert = true;
                                            if (bCustomerSelected)
                                            {
                                                bCustomerOK = txtCustomer.Tag.ToString().Trim() == oSRN.Customer_ID ? true : false;
                                            }
                                            if (bSelesRepSelected)
                                            {
                                                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oSRN.OrderRefNo_ID);
                                                if (oRef != null)
                                                    bSalesRepOK = oRef.Employee_ID == txtSalesRep.Tag.ToString() ? true : false;
                                            }

                                            bool bItemInserted = false;
                                            if (bCustomerOK && bSalesRepOK)
                                            {
                                                string sProductionJobID = "N/A", sDeliveryOrderID = "N/A", sJobTypeID = " N/A", sJobTypeName = " N/A";
                                                decimal dTotalWeight = 0, dTotalQty = 0;
                                                tbl_sasDeliveryOrder oDO = tbl_sasDeliveryOrder.Select(oSRN.DeliveryOrder_ID);
                                                if (oDO != null && oDO.DeliveryOrder_ID != "default")
                                                {
                                                    sProductionJobID = oDO.Job_ID;
                                                    sDeliveryOrderID = oDO.DeliveryOrder_ID;

                                                    tbl_pmsProductionJobRegister oJob = tbl_pmsProductionJobRegister.Select(oDO.Job_ID);
                                                    if (oJob != null)
                                                    {
                                                        if (bJobTypeSelected)
                                                        {
                                                            if (oJob.Job_ID == "default")
                                                            {
                                                                if (txtJobType.Tag.ToString().Trim() != "PJT/009" && txtJobType.Tag.ToString().Trim() != "PJT/010")
                                                                    continue;
                                                            }
                                                            else if (oJob.ProductionJobType_ID != txtJobType.Tag.ToString().Trim())
                                                                continue;
                                                        }
                                                        if (oJob.ProductionJobType_ID != "default")
                                                        {
                                                            sJobTypeID = oJob.ProductionJobType_ID;
                                                            sJobTypeName = clsGenaralName.getName_ProductionJobType(oJob.ProductionJobType_ID);
                                                        }
                                                    }
                                                }

                                                bool bItemOK = false;

                                                foreach (tbl_sasSalesReturnedNote_Detail oSRNDetail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSRN.SalesReturnedNote_ID))
                                                {
                                                    dTotalWeight += oSRNDetail.Weight;
                                                    dTotalQty += oSRNDetail.Qty;

                                                    if (bItemSelected)
                                                        bItemOK = oSRNDetail.Item_ID == txtItemID.Tag.ToString() ? true : false;
                                                    if (bItemSelected)
                                                        bOkToInsert = (bItemOK) ? true : false;
                                                    else
                                                        bOkToInsert = true;

                                                    if (bOkToInsert)
                                                    {
                                                        #region Invoice Detail
                                                        if (Report == enum_ReportName.RG_SalesReturnDetail)
                                                        {
                                                            glb_dtsSalesReturn.dt_sasSalesReturn_Detail.Adddt_sasSalesReturn_DetailRow(oSRNDetail.SalesReturnedNote_ID, oSRNDetail.Item_ID,
                                                                clsGenaralName.getName_Item(oSRNDetail.Item_ID), oSRNDetail.UnitPrice, oSRNDetail.Qty, oSRNDetail.TatalAmount,
                                                                oSRNDetail.Remark, oSRNDetail.Weight, clsGenaralName.getName_ItemSubCategory(oSRNDetail.ItemSubCategory_ID),
                                                                clsGenaralName.getName_ItemUOM(oSRNDetail.Item_ID), sProductionJobID, sDeliveryOrderID);
                                                            bItemInserted = true;
                                                        }
                                                        #endregion
                                                    }

                                                }
                                                //DT_SalesReturn
                                                #region DT Sales Return
                                                if (bItemSelected)
                                                    bOkToInsert = (bItemInserted) ? true : false;
                                                else
                                                    bOkToInsert = true;
                                                if (bOkToInsert)
                                                {
                                                    glb_dtsSalesReturn.dt_sasSalesReturn.Adddt_sasSalesReturnRow(oSRN.SalesReturnedNote_ID, oSRN.SalesReturnedNoteDate,
                                                            clsGenaralName.getName_Customer(oSRN.Customer_ID), clsGenaralName.getName_BranchCustomer(oSRN.Customer_ID, int.Parse(oSRN.Branch_ID)), clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(oSRN.OrderRefNo_ID)), oSRN.GrandTotal, dTotalWeight,
                                                            dTotalQty, oSRN.IsReturnable, oSRN.IsRefundable, oSRN.IsExcess, sProductionJobID, sDeliveryOrderID,
                                                            oSRN.Invoice_ID, oSRN.Remark, oSRN.IsWeightCalculation, oSRN.NbtTotal, oSRN.VatTotal, oSRN.DiscountTotal, 
                                                            oSRN.IsDeleted, sJobTypeID, sJobTypeName, clsGenaralName.getName_SalesNoteType(oSRN.SalesNoteType_ID), "", 0, 0, "");
                                                }
                                                bItemInserted = false;
                                                #endregion
                                            }
                                            clsHelpMethods.startProgressBar(0, oSRetNote.Count + 2, 1, ProgressBar);
                                        }
                                        #endregion

                                        glb_dtsSalesReturn.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        //   rpt.Process_Print((int)Report);
                                        rpt.print(sReportPath, glb_dtsSalesReturn, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        Cursor = Cursors.Default;
                                        glb_dtsSalesReturn.dt_sasSalesReturn.Rows.Clear();
                                        glb_dtsSalesReturn.dt_sasSalesReturn_Detail.Rows.Clear();
                                    }
                                }
                                #endregion

                                #region Inquiry Summery & Inquiry Detail
                                else if (Report == enum_ReportName.RG_InquiryDetail || Report == enum_ReportName.RG_InquirySummary)
                                {
                                    try
                                    {
                                        glb_dtsInquiry.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.WaitCursor;
                                        string sSalesmanID = "";

                                        foreach (tbl_sasInquiry oInquiry in tbl_sasInquiry.SelectAll().Where(p => p.InquiryDate.Date >= dtpFrom.Value.Date && p.InquiryDate.Date <= dtpTo.Value.Date))
                                        {
                                            #region Filter-Deleted Recorded
                                            if (rdoDeleted.Checked)
                                            {
                                                if (!oInquiry.IsDeleted)
                                                    continue;
                                            }
                                            else if (rdoActual.Checked)
                                            {
                                                if (oInquiry.IsDeleted)
                                                    continue;
                                            }
                                            #endregion

                                            #region Filter-Customer
                                            //if (txtCustomer.Tag != null && txtCustomer.Tag.ToString() != oInquiry.Customer_ID)
                                            //    continue;

                                            if (bCustomerSelected)
                                            {
                                                if (oInquiry.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInquiry.Customer_ID);
                                            if (oCustomer != null)
                                            {
                                                #region Sales Rep
                                                if (chkUseCustomerMastorSaleRep.Checked)
                                                    sSalesmanID = oCustomer.SalesRep_ID;
                                                else
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInquiry.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }

                                                if (bSelesRepSelected)
                                                {
                                                    if (sSalesmanID != txtSalesRep.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                #endregion

                                                if (bCustomerClassSelected)
                                                {
                                                    if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }
                                            }

                                            #endregion

                                            #region Filter-SalesRep
                                            //tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInquiry.Customer_ID);
                                            //string sSalesmanID = oCustomer != null ? oCustomer.SalesRep_ID : "-";

                                            //if (!chkUseCustomerMastorSaleRep.Checked)
                                            //{
                                            //    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInquiry.OrderRefNo_ID);
                                            //    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                            //        sSalesmanID = oRef.Employee_ID;
                                            //}

                                            //if (bSelesRepSelected)
                                            //{
                                            //    if (sSalesmanID != txtSalesRep.Tag.ToString().Trim())
                                            //        continue;
                                            //}
                                            #endregion

                                            glb_dtsInquiry.dt_Inquiry.Adddt_InquiryRow(oInquiry.Inquiry_ID, oInquiry.InquiryDate, oInquiry.OrderRefNo_ID, 
                                                clsGenaralName.getName_Customer(oInquiry.Customer_ID), clsGenaralName.getName_SalesRep(oInquiry.Employee_ID), oInquiry.IsDeleted, "", 
                                                oInquiry.Employee_ID, oInquiry.GrandTotal, clsGenaralName.getName_CurrencyCode(oInquiry.Currency_ID), oInquiry.Customer_ID,
                                                0, 0, 0, 0, 0, 0, 0, 0, 0, "", clsGenaralName.getName_BranchCustomer(oInquiry.Customer_ID, int.Parse(oInquiry.Branch_ID)), 0, false);

                                            if (Report == enum_ReportName.RG_InquiryDetail)
                                            {
                                                foreach (tbl_sasInquiry_Detail detail in tbl_sasInquiry_Detail.SelectAllByInquiry_ID(oInquiry.Inquiry_ID))
                                                {
                                                    glb_dtsInquiry.dt_InquiryDetail.Adddt_InquiryDetailRow(detail.Item_ID, clsGenaralName.getName_Item(detail.Item_ID), detail.Qty, clsGenaralName.getName_Uom(detail.Inquiry_ID), detail.UnitPrice, detail.TatalAmount, detail.Inquiry_ID, "");
                                                }
                                            }
                                        }
                                        glb_dtsInquiry.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsInquiry, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        glb_dtsInquiry.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Customer order Summary / Detail
                                if (Report == enum_ReportName.RG_CustomerOrderSummary || Report == enum_ReportName.RG_CustomerOrderDetail)
                                {
                                    try
                                    {
                                        glb_dts_sasCustomerOrder.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.WaitCursor;

                                        List<tbl_sasCustomerOrder> oCO = tbl_sasCustomerOrder.SelectAll().Where(p => p.CustomerOrder_ID != "default" && p.CompanyBranch_ID == txtBranch.Tag.ToString() && p.CustomerOrderDate.Date >= dtpFrom.Value.Date && p.CustomerOrderDate.Date <= dtpTo.Value.Date).ToList();

                                        string sSalesmanID = "", sRouteID = "";
                                        foreach (tbl_sasCustomerOrder detail in oCO.OrderBy(p => p.CustomerOrderDate))
                                        {
                                            //add filters - janith
                                            if (rdoDeleted.Checked && !detail.IsDeleted)
                                                continue;
                                            else if (rdoActual.Checked && detail.IsDeleted)
                                                continue;

                                            #region Filter - Customer
                                            if (bCustomerSelected)
                                                if (detail.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;
                                            #endregion

                                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(detail.Customer_ID);
                                            if (oCustomer != null)
                                            {
                                                #region Route
                                                if (bRouteSelected)
                                                {
                                                    if (!chkUseCustomerMastorRoute.Checked)
                                                    {
                                                        sRouteID = detail.Route_ID.ToString();
                                                    }
                                                    else
                                                    {
                                                        foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(detail.Customer_ID))
                                                        {
                                                            sRouteID = oRoute.Route_ID.ToString();
                                                            if (txtRoute.Tag.ToString() == sRouteID)
                                                                break;
                                                        }
                                                    }

                                                    if (txtRoute.Tag.ToString() != sRouteID)
                                                        continue;
                                                }
                                                #endregion

                                                if (bCustomerClassSelected)
                                                {
                                                    if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }
                                            }

                                            #region Sales Rep Filter
                                            tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                                            if (oRef != null && oRef.OrderRefNo != "default")
                                                sSalesmanID = oRef.Employee_ID;

                                            if (bSelesRepSelected)
                                                if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                    continue;
                                            #endregion

                                            glb_dts_sasCustomerOrder.dt_sasCustomerOrder.Adddt_sasCustomerOrderRow(detail.CustomerOrder_ID, detail.CustomerOrderDate, detail.DeliveryDate.Date, detail.DeliveryAddress, "", 
                                                oCustomer.CustomerName, oCustomer.AddressRegister, oCustomer.Telephone, clsGenaralName.getName_BranchCustomer(detail.Customer_ID, int.Parse(detail.Branch_ID)), 0, 0, "", clsGenaralName.getName_Employee(detail.Employee_ID), detail.Remark, detail.Customer_ID, "p_Date",
                                                detail.GrandTotal, detail.SubTotal, detail.DiscountTotal, detail.NbtTotal, detail.VatTotal, detail.OtherTaxTotal, detail.AdvanceAmount, "",
                                                detail.Quotation_ID, detail.PurchaseOrder_ID, detail.DiscountPercentage, detail.NbtPercentage, detail.VatPercentage, detail.OtherTaxPercentage, 
                                                "", "", detail.IsWeightCalculation, detail.IsSeattled, detail.IsDeleted, detail.IsApproved, "", "", "", "", detail.Employee_ID, 
                                                clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID), clsGenaralName.getName_User(detail.CreateUser_ID).ToUpper(), "", "", detail.Currency_ID, clsGenaralName.getName_CurrencyCode(detail.Currency_ID), detail.Store_ID, clsGenaralName.getName_Store(detail.Store_ID),
                                                detail.IsSVAT ? oCustomer.SvatRegistrationNo : oCustomer.VatRegistrationNo, oCustomer.NbtRegistrationNo, "", "", "", "", "", detail.DateCreate);

                                            #region Fill Details
                                            if (Report == enum_ReportName.RG_CustomerOrderDetail)
                                            {
                                                foreach (tbl_sasCustomerOrder_Detail cdetail in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(detail.CustomerOrder_ID))
                                                {
                                                    if (bItemSelected)
                                                        if (cdetail.Item_ID != txtItemID.Tag.ToString())
                                                            continue;

                                                    glb_dts_sasCustomerOrder.dt_sasCustomerOrderDetail.Adddt_sasCustomerOrderDetailRow(cdetail.CustomerOrder_ID, cdetail.Item_ID, clsGenaralName.getName_Item(cdetail.Item_ID), cdetail.Qty, cdetail.Weight, cdetail.UnitPrice, cdetail.BIsFreeItem, cdetail.DiscountPresentage, cdetail.DiscountAmount, cdetail.Remark, cdetail.TatalAmount, "", 0, 0, 0, clsGenaralName.getName_ItemUOM(cdetail.Item_ID), cdetail.WeightPrice, cdetail.QtySettle_DeliveryOrder, clsGenaralName.getName_ItemCategorySub(cdetail.ItemSubCategory_ID), clsHelpMethods.GetPLU(detail.Customer_ID, cdetail.Item_ID));
                                                }
                                            }
                                            #endregion
                                        }

                                        glb_dts_sasCustomerOrder.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        // rpt.Process_Print((int)enum_ReportName.RG_CustomerOrderSummary);
                                        rpt.print(sReportPath, glb_dts_sasCustomerOrder, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.RG_CustomerOrderSummary));
                                    }
                                    catch (Exception ex)
                                    {
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        glb_dts_sasCustomerOrder.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Delivery Order Summary / Detail
                                else if (Report == enum_ReportName.RG_DeliveryOrderSummary || Report == enum_ReportName.RG_DeliveryOrderDetail)
                                //else if (rdoDeliverySummary.Checked || rdoDeliveryDetail.Checked)
                                {
                                    try
                                    {
                                        string sRouteID = "";

                                        glb_dts_sasDeliveryOrder.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.WaitCursor;

                                        foreach (tbl_sasDeliveryOrder detail in tbl_sasDeliveryOrder.SelectAllByDateRange(dtpFrom.Value.Date, dtpTo.Value.Date).Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString()).OrderBy(p => p.DeliveryOrderDate))
                                        {
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

                                            #region Filter - Customer
                                            if (bCustomerSelected)
                                            {
                                                if (detail.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;
                                            }
                                            #endregion

                                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(detail.Customer_ID);
                                            if (oCustomer != null)
                                            {
                                                #region Route
                                                if (bRouteSelected)
                                                {
                                                    if (!chkUseCustomerMastorRoute.Checked)
                                                    {
                                                        sRouteID = detail.Route_ID.ToString();
                                                    }
                                                    else
                                                    {
                                                        foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(detail.Customer_ID))
                                                        {
                                                            sRouteID = oRoute.Route_ID.ToString();
                                                            if (txtRoute.Tag.ToString() == sRouteID)
                                                                break;
                                                        }
                                                    }

                                                    if (txtRoute.Tag.ToString() != sRouteID)
                                                        continue;
                                                }
                                                #endregion

                                                if (bCustomerClassSelected)
                                                {
                                                    if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }
                                            }

                                            #region Filter - Sales Rep

                                            string sSalesmanID = oCustomer != null ? oCustomer.SalesRep_ID : "-";

                                            if (!chkUseCustomerMastorSaleRep.Checked)
                                            {
                                                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                                                if (oRef != null && oRef.OrderRefNo_ID != "default")
                                                    sSalesmanID = oRef.Employee_ID;
                                            }

                                            if (bSelesRepSelected)
                                            {
                                                if (sSalesmanID != txtSalesRep.Tag.ToString().Trim())
                                                    continue;
                                            }
                                            #endregion

                                            int iItemCount = 0;
                                            if (Report == enum_ReportName.RG_DeliveryOrderDetail)
                                            {
                                                foreach (tbl_sasDeliveryOrder_Detail DOdetail in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(detail.DeliveryOrder_ID))
                                                {
                                                    if (bItemSelected)
                                                        if (DOdetail.Item_ID != txtItemID.Tag.ToString())
                                                            continue;

                                                    glb_dts_sasDeliveryOrder.dt_deliveryOrderDetail.Adddt_deliveryOrderDetailRow(DOdetail.DeliveryOrder_ID, DOdetail.ItemSerialNo, DOdetail.Item_ID, clsGenaralName.getName_Item(DOdetail.Item_ID), clsGenaralName.getDescription_Item(DOdetail.Item_ID), DOdetail.Carton_No, DOdetail.Qty, DOdetail.Weight, clsGenaralName.getName_Uom(DOdetail.PackingUom_ID), DOdetail.UnitPrice, DOdetail.BIsFreeItem, DOdetail.DiscountPresentage, DOdetail.DiscountAmount, DOdetail.TatalAmount, 0, "");
                                                }
                                            }
                                            else
                                            {
                                                iItemCount = tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(detail.DeliveryOrder_ID).Count();
                                            }

                                            //glb_dts_sasDeliveryOrder.dt_deliveryOrderHeader.Adddt_deliveryOrderHeaderRow(detail.DeliveryOrder_ID, detail.DeliveryOrderDate, "", detail.Customer_ID, clsGenaralName.getName_Customer(detail.Customer_ID), clsGenaralName.getName_CustomerDeliveryAddress(detail.Customer_ID), "", "", clsGenaralName.getName_CustomerTelephone(detail.Customer_ID), detail.Store_ID, clsGenaralName.getName_Store(detail.Store_ID), "", clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID),
                                            //    detail.Vehicle_No, detail.SubTotal, detail.DiscountTotal, detail.DiscountPercentage, detail.NbtTotal, detail.NbtPercentage, detail.VatTotal, detail.VatPercentage, detail.VatTotal, detail.VatPercentage, detail.GrandTotal, detail.Employee_ID, detail.IsWeightCalculation, clsGenaralName.getName_Employee(detail.Employee_ID), detail.IsDeleted, iItemCount);

                                            glb_dts_sasDeliveryOrder.dt_deliveryOrderHeader.Adddt_deliveryOrderHeaderRow(detail.DeliveryOrder_ID, detail.DeliveryOrderDate, "", detail.Customer_ID, clsGenaralName.getName_Customer(detail.Customer_ID), clsGenaralName.getName_CustomerDeliveryAddress(detail.Customer_ID), "", clsGenaralName.getName_BranchCustomer(detail.Customer_ID, int.Parse(detail.Branch_ID)), clsGenaralName.getName_CustomerTelephone(detail.Customer_ID), detail.Store_ID, clsGenaralName.getName_Store(detail.Store_ID), "", clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID),
                                                    detail.Vehicle_No, detail.SubTotal, detail.DiscountTotal, detail.DiscountPercentage, detail.NbtTotal, detail.NbtPercentage, detail.VatTotal, detail.VatPercentage, detail.VatTotal, detail.VatPercentage, detail.GrandTotal, sSalesmanID, detail.IsWeightCalculation, clsGenaralName.getName_Employee(sSalesmanID), detail.IsDeleted, iItemCount, DateTime.MinValue, "", "", "", "", "", "", "", clsGenaralName.getName_User(detail.CreateUser_ID), detail.DateCreate);
                                        }

                                        glb_dts_sasDeliveryOrder.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        //  rpt.Process_Print((int)Report);
                                        rpt.print(sReportPath, glb_dts_sasDeliveryOrder, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        glb_dts_sasDeliveryOrder.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Invoice Summery / Detail
                                else if (Report == enum_ReportName.RG_InvoiceSummary || Report == enum_ReportName.RG_InvoiceDetail)
                                {
                                    try
                                    {
                                        glb_dtsSalesInvoice.Clear();

                                        Cursor = Cursors.WaitCursor;
                                        string sSalesmanID = "", sReportName = "", sInvoiceType = "", sRouteID = "";
                                        decimal dGrandTotal_AllInvoices = 0;

                                        #region Remove PoS Transactions From Invoice Registers Reports - Added by Gayan 2016-07-16
                                        List<tbl_sasInvoice> oInvoices = null;
                                        oInvoices = tbl_sasInvoice.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => p.Invoice_ID != "default" && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date && !p.IsReturnedCheque && !p.IsDebitNote && !p.IsPosInvoice && p.CompanyBranch_ID == clsSecurity.BranchID).ToList();
                                        #endregion

                                        #region Tax Type Filter - Added by Gayan 2016-07-28
                                        if (cbxInvType.Text == "Non Tax")
                                            oInvoices = oInvoices.Where(p => !p.IsVatInvoice && !p.IsSVatInvoice).ToList();
                                        else if (cbxInvType.Text == "VAT")
                                            oInvoices = oInvoices.Where(p => p.IsVatInvoice).ToList();
                                        else if (cbxInvType.Text == "SVAT")
                                            oInvoices = oInvoices.Where(p => p.IsSVatInvoice).ToList();
                                        #endregion

                                        foreach (tbl_sasInvoice oInvoice in oInvoices)
                                        {
                                            bool bInvoiceTypeOK = true;

                                            #region Filters
                                            //add filters - janith
                                            if (rdoDeleted.Checked && !oInvoice.IsDeleted)
                                                continue;
                                            else if (rdoActual.Checked && oInvoice.IsDeleted)
                                                continue;

                                            if (bSalesNoteTypeSelected)
                                            {
                                                if (oInvoice.SalesNoteType_ID != txtSalesNoteType.Tag.ToString())
                                                    continue;
                                            }
                                            if (bCustomerSelected)
                                            {
                                                if (oInvoice.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;
                                            }
                                            #endregion

                                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                            if (oCustomer != null)
                                            {
                                                #region Sales Rep
                                                if (chkUseCustomerMastorSaleRep.Checked)
                                                    sSalesmanID = oCustomer.SalesRep_ID;
                                                else
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }
                                                if (bSelesRepSelected)
                                                {
                                                    if (sSalesmanID != txtSalesRep.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                #endregion

                                                if (bCustomerClassSelected)
                                                {
                                                    if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }                                                

                                                #region Route
                                                if (bRouteSelected)
                                                {
                                                    if (!chkUseCustomerMastorRoute.Checked)
                                                    {
                                                        sRouteID = oInvoice.Route_ID.ToString();
                                                    }
                                                    else
                                                    {
                                                        foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oInvoice.Customer_ID))
                                                        {
                                                            sRouteID = oRoute.Route_ID.ToString();
                                                            if (txtRoute.Tag.ToString() == sRouteID)
                                                                break;
                                                        }
                                                    }

                                                    if (txtRoute.Tag.ToString() != sRouteID)
                                                        continue;
                                                }
                                                #endregion
                                            }

                                            #region Check Invoice Type for both report
                                            switch (cbxInvType.Text)
                                            {
                                                case "Non Tax":
                                                    sReportName = "Non  Tax Invoice Summary";
                                                    bInvoiceTypeOK = !oInvoice.IsSVatInvoice && !oInvoice.IsVatInvoice ? true : false;
                                                    break;
                                                case "VAT":
                                                    sReportName = "VAT Invoice Summary";
                                                    bInvoiceTypeOK = oInvoice.IsVatInvoice ? true : false;
                                                    break;
                                                case "SVAT":
                                                    sReportName = "SVAT Invoice Summary";
                                                    bInvoiceTypeOK = oInvoice.IsSVatInvoice ? true : false;
                                                    break;
                                                case "ALL":
                                                    sReportName = "Invoice Summary";
                                                    break;
                                            }

                                            if (bInvoiceTypeOK)
                                            {
                                                #region AKT Customer - job type
                                                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                                {
                                                    if (oInvoice.Quotation_ID != "default")
                                                    {
                                                        sInvoiceType = "Block Sales";
                                                        if (bJobTypeSelected)
                                                        {
                                                            if (txtJobType.Tag.ToString().Trim() != "PJT/013" && txtJobType.Tag.ToString().Trim() != "PJT/014")
                                                                continue;
                                                        }
                                                    }
                                                    else if (oInvoice.DeliveryOrder_ID != "default" && oInvoice.Job_ID == "default")
                                                    {
                                                        sInvoiceType = "Direct Sales";
                                                        if (bJobTypeSelected)
                                                        {
                                                            if (txtJobType.Tag.ToString().Trim() != "PJT/009" && txtJobType.Tag.ToString().Trim() != "PJT/010")
                                                                continue;
                                                        }
                                                    }
                                                    else if (oInvoice.Job_ID != "default")
                                                    {
                                                        tbl_pmsProductionJobRegister oJob = tbl_pmsProductionJobRegister.Select(oInvoice.Job_ID);
                                                        if (oJob != null)
                                                        {
                                                            sInvoiceType = clsGenaralName.getName_ProductionJobType(oJob.ProductionJobType_ID);
                                                            if (bJobTypeSelected)
                                                            {
                                                                if (oJob.ProductionJobType_ID != txtJobType.Tag.ToString().Trim())
                                                                    continue;
                                                            }
                                                        }
                                                    }

                                                }
                                                #endregion

                                                else
                                                {
                                                    if (clsConfig.bSalesNoteType_SerialNoActiveFor_Invoice)
                                                        sInvoiceType = clsGenaralName.getName_SalesNoteType(oInvoice.SalesNoteType_ID);
                                                    else
                                                        sInvoiceType = (oInvoice.IsVatInvoice) ? "Vat Invoice" : (oInvoice.IsSVatInvoice) ? "SVat Invoice" : "Non Tax Invoice";
                                                }
                                            }
                                            #endregion

                                            #region Multiple Discount Details
                                            //decimal dDiscount1_Precentage = 0, dDiscount2_Precentage = 0, dDiscount3_Precentage = 0, dDiscount1_Total = 0, dDiscount2_Total = 0, dDiscount3_Total = 0;
                                            //tbl_sasInvoice_Discount oDiscount = tbl_sasInvoice_Discount.Select(oInvoice.Invoice_ID);
                                            //if (oDiscount != null && oDiscount.Invoice_ID != "default")
                                            //{
                                            //    dDiscount1_Precentage = oDiscount.DiscountPresentage1;
                                            //    dDiscount2_Precentage = oDiscount.DiscountPresentage2;
                                            //    dDiscount3_Precentage = oDiscount.DiscountPresentage3;

                                            //    dDiscount1_Total = oDiscount.DiscountAmount1;
                                            //    dDiscount2_Total = oDiscount.DiscountAmount2;
                                            //    dDiscount3_Total = oDiscount.DiscountAmount3;
                                            //}
                                            #endregion

                                            #region Fill Invoice Datasset
                                            DateTime dtDoDate = DateTime.MinValue;//Ideall
                                            glb_dtsSalesInvoice.dt_sasInvoice.Adddt_sasInvoiceRow(oInvoice.Invoice_ID, oInvoice.InvoiceDate, oInvoice.Customer_ID, oCustomer.CustomerName, "", "", clsGenaralName.getName_BranchCustomer(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID)), "", "", "", clsGenaralName.getName_SalesRep(sSalesmanID), "", "", "",
                                                oInvoice.IsDeleted, oInvoice.DeliveryOrder_ID, sInvoiceType, oInvoice.SubTotal, oInvoice.DiscountPercentage, oInvoice.DiscountTotal, 0, oInvoice.NbtPercentage, oInvoice.NbtTotal, oInvoice.VatPercentage, oInvoice.VatTotal, oInvoice.OtherTaxPercentage, oInvoice.OtherTaxTotal, 
                                                oInvoice.GrandTotal, "", oInvoice.OrderRefNo_ID, "", "", "", "", "", false, dtDoDate, oInvoice.DiscountPercentage1, oInvoice.DiscountPercentage2, oInvoice.DiscountPercentage3, oInvoice.DiscountTotal1, oInvoice.DiscountTotal2, oInvoice.DiscountTotal3, "", "", "", "", 
                                                oInvoice.IsSVatInvoice, oInvoice.IsVatInvoice, oInvoice.PaymentTerms, oInvoice.Remark, oInvoice.Currency_ID, clsGenaralName.getName_CurrencyCode(oInvoice.Currency_ID), oInvoice.PaymentDueDate);
                                            dGrandTotal_AllInvoices += oInvoice.GrandTotal;
                                            #endregion

                                            #region Invoice Detail
                                            if (Report == enum_ReportName.RG_InvoiceDetail)
                                            {
                                                foreach (tbl_sasInvoice_Detail oInvoiceDetail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID))
                                                {
                                                    if (bItemSelected)
                                                        if (oInvoiceDetail.Item_ID != txtItemID.Tag.ToString())
                                                            continue;
                                                    glb_dtsSalesInvoice.dt_sasInvoice_Detail.Adddt_sasInvoice_DetailRow(oInvoiceDetail.Invoice_ID, oInvoiceDetail.Item_ID, "", oInvoiceDetail.UnitPrice, oInvoiceDetail.Qty, clsGenaralName.getName_Item(oInvoiceDetail.Item_ID), "", clsGenaralName.getName_Uom(oInvoiceDetail.Uom_ID), 0, clsGenaralName.getCategoryID_ItemSubCategory(oInvoiceDetail.ItemSubCategory_ID), oInvoiceDetail.DiscountPresentage, oInvoiceDetail.DiscountAmount, oInvoiceDetail.TatalAmount, oInvoiceDetail.BIsFreeItem, 0, "");
                                                }
                                            }
                                            #endregion
                                        }

                                        if (Report == enum_ReportName.RG_InvoiceSummary)
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("GrandTotal_AllInvoices", clsFormatter.FormatDecimalPlaces_Price(dGrandTotal_AllInvoices), true,false);

                                        glb_dtsSalesInvoice.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                                        ReportViewer.print(sReportPath, glb_dtsSalesInvoice, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        glb_dtsSalesInvoice.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Quotation Summary& Quotation Detail
                                if (Report == enum_ReportName.RG_QuotationSummary || Report == enum_ReportName.RG_QuotationDetails)
                                {
                                    try
                                    {
                                        glb_dtsReportExport.Clear();
                                        glb_dtsQuotation.Clear();
                                        Cursor = Cursors.WaitCursor;
                                        string sSalesmanID = "";

                                        foreach (tbl_sasQuotation detail in tbl_sasQuotation.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && p.QuotationDate.Date >= dtpFrom.Value.Date && p.QuotationDate.Date <= dtpTo.Value.Date).OrderBy(p => p.QuotationDate))
                                        {
                                            #region Filter-Deleted Recorded
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

                                            #region Filter-Customer
                                            //if (txtCustomer.Tag != null && txtCustomer.Tag.ToString() != detail.Customer_ID)
                                            //    continue;

                                            if (bCustomerSelected)
                                            {
                                                if (detail.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(detail.Customer_ID);
                                            if (oCustomer != null)
                                            {
                                                #region Sales Rep
                                                if (chkUseCustomerMastorSaleRep.Checked)
                                                    sSalesmanID = oCustomer.SalesRep_ID;
                                                else
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }

                                                if (bSelesRepSelected)
                                                {
                                                    if (sSalesmanID != txtSalesRep.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                #endregion

                                                if (bCustomerClassSelected)
                                                {
                                                    if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }
                                            }

                                            #endregion

                                            #region Filter-SalesRep
                                            //tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(detail.Customer_ID);
                                            //string sSalesmanID = oCustomer != null ? oCustomer.SalesRep_ID : "-";

                                            //if (!chkUseCustomerMastorSaleRep.Checked)
                                            //{
                                            //    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                                            //    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                            //        sSalesmanID = oRef.Employee_ID;
                                            //}

                                            //if (bSelesRepSelected)
                                            //{
                                            //    if (sSalesmanID != txtSalesRep.Tag.ToString().Trim())
                                            //        continue;
                                            //}
                                            #endregion

                                            glb_dtsQuotation.Quotation.AddQuotationRow(detail.Quotation_ID, detail.QuotationDate, detail.Employee_ID, clsGenaralName.getName_Employee(detail.Employee_ID), 
                                                "", detail.OrderRefNo_ID, detail.ContactName, detail.Customer_ID, clsGenaralName.getName_Customer(detail.Customer_ID), detail.DeliveryAddress, clsGenaralName.getName_BranchCustomer(detail.Customer_ID, int.Parse(detail.Branch_ID)), "", "", "", 
                                                detail.ValiedPeriod, detail.PaymentPeriod, detail.DeliveryPeriod, detail.SubTotal, detail.DiscountPercentage, detail.DiscountTotal, 0, detail.NbtPercentage, 
                                                detail.NbtTotal, detail.VatPercentage, detail.VatTotal, detail.OtherTaxPercentage, detail.OtherTaxTotal, detail.GrandTotal, detail.Remark, 0, detail.IsDeleted);
                                            if (Report == enum_ReportName.RG_QuotationDetails)
                                            {
                                                foreach (tbl_sasQuotation_Detail oDetail in tbl_sasQuotation_Detail.SelectAllByQuotation_ID(detail.Quotation_ID))
                                                {
                                                    glb_dtsQuotation.QuotationDetail.AddQuotationDetailRow(oDetail.Quotation_ID, oDetail.Item_ID, clsGenaralName.getName_Item(oDetail.Item_ID), oDetail.Remark, oDetail.Uom_ID, oDetail.Qty, oDetail.UnitPrice, oDetail.TatalAmount);
                                                }
                                            }
                                        }

                                        glb_dtsQuotation.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsQuotation, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    }
                                    catch (Exception ex)
                                    {
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        glb_dtsQuotation.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Peformance Summary / Detail
                                if (Report == enum_ReportName.RG_PerformaInvoiceSummary || Report == enum_ReportName.RG_PerformaInvoiceDetails)
                                {
                                    try
                                    {
                                        glb_dtsProform.Clear();
                                        Cursor = Cursors.WaitCursor;
                                        string sSalesmanID = "";

                                        foreach (tbl_sasProformaInvoice oInvoice in tbl_sasProformaInvoice.SelectAll().Where(p => p.ProformaInvoiceDate.Date >= dtpFrom.Value.Date && p.ProformaInvoiceDate.Date <= dtpTo.Value.Date))
                                        {
                                            #region Filter-Deleted Recorded
                                            if (rdoDeleted.Checked)
                                            {
                                                if (!oInvoice.IsDeleted)
                                                    continue;
                                            }
                                            else if (rdoActual.Checked)
                                            {
                                                if (oInvoice.IsDeleted)
                                                    continue;
                                            }
                                            #endregion

                                            #region Filter-Customer
                                            //if (txtCustomer.Tag != null && txtCustomer.Tag.ToString() != oInvoice.Customer_ID)
                                            //    continue;

                                            if (bCustomerSelected)
                                            {
                                                if (oInvoice.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                            if (oCustomer != null)
                                            {
                                                #region Sales Rep
                                                if (chkUseCustomerMastorSaleRep.Checked)
                                                    sSalesmanID = oCustomer.SalesRep_ID;
                                                else
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }

                                                if (bSelesRepSelected)
                                                {
                                                    if (sSalesmanID != txtSalesRep.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                #endregion

                                                if (bCustomerClassSelected)
                                                {
                                                    if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }
                                            }

                                            #endregion

                                            #region Filter-SalesRep
                                            //tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                            //string sSalesmanID = oCustomer != null ? oCustomer.SalesRep_ID : "-";
                                            //string sRepName = "";

                                            //tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                            //if (oRef != null && oRef.OrderRefNo_ID != "default")
                                            //{
                                            //    sRepName = clsGenaralName.getName_SalesRep(oRef.Employee_ID);
                                            //}

                                            //if (!chkUseCustomerMastorSaleRep.Checked)
                                            //{
                                            //    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                            //        sSalesmanID = oRef.Employee_ID;
                                            //    //tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                            //    //if (oRef != null && oRef.OrderRefNo_ID != "default")
                                            //    //{
                                            //    //    sSalesmanID = oRef.Employee_ID;
                                            //    //    sRepName = clsGenaralName.getName_SalesRep(oRef.Employee_ID);
                                            //    //}
                                            //}

                                            //if (bSelesRepSelected)
                                            //{
                                            //    if (sSalesmanID != txtSalesRep.Tag.ToString().Trim())
                                            //        continue;
                                            //}
                                            #endregion

                                            glb_dtsProform.dt_Proform.Adddt_ProformRow(oInvoice.ProformaInvoice_ID, clsGenaralName.getName_Customer(oInvoice.Customer_ID), 
                                                oInvoice.ProformaInvoiceDate.Date, clsGenaralName.getName_SalesRep(sSalesmanID), oInvoice.OrderRefNo_ID, oInvoice.GrandTotal, 
                                                oInvoice.Customer_ID, clsGenaralName.getName_BranchCustomer(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID)), "");

                                            if (Report == enum_ReportName.RG_PerformaInvoiceDetails)
                                            {
                                                foreach (tbl_sasProformaInvoice_Detail detail in tbl_sasProformaInvoice_Detail.SelectAllByProformaInvoice_ID(oInvoice.ProformaInvoice_ID))
                                                {
                                                    glb_dtsProform.dt_ProformDetail.Adddt_ProformDetailRow(detail.Item_ID, clsGenaralName.getName_Item(detail.Item_ID), detail.Qty, clsGenaralName.getName_Uom(detail.Uom_ID), detail.UnitPrice, detail.TatalAmount, detail.ProformaInvoice_ID);
                                                }
                                            }
                                        }
                                        glb_dtsProform.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsProform, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        glb_dtsProform.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID, ex);
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

            dtpFrom.Value = clsSecurity.getServerDateTime();
            dtpTo.Value = clsSecurity.getServerDateTime();
        }
        #endregion

        #region ClearField
        private void clearField()
        {
            txtCustomer.Tag = null;
            txtCusClass.Tag = null;
            txtCusType.Tag = null;
            txtCusCategory.Tag = null;
            txtSalesRep.Tag = null;
            txtItemID.Tag = null;
            txtSalesNoteType.Tag = null;
            txtJobType.Tag = null;
            txtRoute.Tag = null;
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

            txtCustomer.Text = "<All Customers>";
            txtCusClass.Text = "<All Classes>";
            txtCusType.Text = "<All Types>";
            txtCusCategory.Text = "<All Categories>";
            txtSalesRep.Text = "<All SalesReps>";
            txtItemID.Text = "<All Items>";
            txtSalesNoteType.Text = "<All Note Types>";
            txtJobType.Text = "<All Job Types>";
            txtRoute.Text = "<All Routes>";
            txtBranch.Text = clsGenaralName.getName_CompanyBranchMaster(clsSecurity.BranchID);
            cbxInvType.SelectedIndex = 3;
            cmbDOType.SelectedIndex = 0;
            rdoActual.Checked = true;
            chkUseCustomerMastorSaleRep.Checked = false;
            chkShowAll.Checked = false;

            chkEntryError.Checked = false;
            chkIsGroupbyProducionJob.Checked = false;
            
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
            clsCommon.SetEnableDisable_NormalRadioButton(rdoDeleted, true);
            clsCommon.SetEnableDisable_NormalRadioButton(rdoActual, true);
            clsCommon.SetEnableDisable_NormalRadioButton(rdoAll, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblItem, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesNoteType, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, true);
            clsCommon.SetEnableDisable_NormalComboBox(cbxInvType, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtJobType, true);

            txtCusCategory.Enabled = true;
            txtCusType.Enabled = true;
            txtCusClass.Enabled = true;

            clsCommon.SetVisibility_Panel(pnlBranch, true);
            clsCommon.SetVisibility_Panel(pnlCustomer, false);
            clsCommon.SetVisibility_Panel(pnlCustomerCategory, true);
            clsCommon.SetVisibility_Panel(pnlCustomerClass, true);
            clsCommon.SetVisibility_Panel(pnlCustomerType, true);
            clsCommon.SetVisibility_Panel(pnlDOType, false);
            clsCommon.SetVisibility_Panel(pnlInvoiceType, false);
            clsCommon.SetVisibility_Panel(pnlItem, false);
            clsCommon.SetVisibility_Panel(pnlJobType, false);
            clsCommon.SetVisibility_Panel(pnlNoteType, false);
            clsCommon.SetVisibility_Panel(pnlRoute, false);
            clsCommon.SetVisibility_Panel(pnlSalesman, false);
            clsCommon.SetVisibility_Panel(pnlCheckBoxes, false);

            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtJobType, false);
            clsCommon.SetEnableDisable_NormalLabel(lblJobType, false);

            clsCommon.SetEnableDisable_NormalRadioButton(rdoDeleted, true);
            clsCommon.SetEnableDisable_NormalRadioButton(rdoActual, true);
            clsCommon.SetEnableDisable_NormalRadioButton(rdoAll, true);

            clsCommon.SetEnableDisable_NormalComboBox(cbxInvType, false);
            clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, false);
            clsCommon.SetEnableDisable_NormalCheckBox(chkEntryError, false);
            clsCommon.SetEnableDisable_NormalCheckBox(chkIsGroupbyProducionJob, false);
        }
        #endregion

        #region KeyDown Events
        private void txtJobType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterProductionJobType(ref txtJobType);
        }

        private void txt_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerID();
        }
        private void txtSalesRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesRepID();
        }
        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsHelpMethods.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
        }
        private void frm_rpt_ChequeManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void txtSalesNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesNoteType();
        }
        #endregion

        #region Events DoublClick
        private void txtJobType_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterProductionJobType(ref txtJobType);
        }

        private void txtBranch_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_CompanyBranch(ref txtBranch);
        }

        private void txtRoute_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterRoute(ref txtRoute);
        }

        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }
        private void txtSalesRep_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesRepID();
        }
        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            clsHelpMethods.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
        }
        private void txtSalesNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesNoteType();
        }
        private void txtCusClass_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerClassID();
        }

        private void txtCusType_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerTypeID();
        }

        private void txtCusCategory_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerCategoryID();
        }
        #endregion

        #region Search Methods
        private void Search_Account()
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
            {
           
            }
        }
        private void Search_CustomerID()
        {
            clsSearch.Search_MasterCustomer(ref txtCustomer, chkShowAll.Checked);

            if (txtCustomer.Tag != null)
            {
                tbl_genCustomerMaster detail = tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString());
                if (detail != null && detail.Customer_ID != "default")
                {
                    txtCusCategory.Tag = detail.CustomerCategory_ID;
                    txtCusCategory.Text = clsGenaralName.getName_CustomerCategory(detail.CustomerCategory_ID);
                    txtCusType.Tag = detail.CustomerType_ID;
                    txtCusType.Text = clsGenaralName.getName_CustomerType(detail.CustomerType_ID);
                    txtCusClass.Tag = detail.CustomerClass_ID;
                    txtCusClass.Text = clsGenaralName.getName_CustomerClass(detail.CustomerClass_ID);

                    txtCusCategory.Enabled = false;
                    txtCusType.Enabled = false;
                    txtCusClass.Enabled = false;
                }
            }

        }

        private void Search_SalesRepID()
        {
            try
            {
                clsSearch.Search_MasterSalesRep(ref txtSalesRep);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_SalesNoteType()
        {
            clsSearch.Search_MasterSalesNoteType(ref txtSalesNoteType);
        }
        #endregion

        #region Set Enable/Disable Controls
        private void setEnableDisableConctrol(int iReportID)
        {
            clearField();

            #region Customer Order
            if (iReportID == (int)enum_ReportName.RG_CustomerOrderSummary || iReportID == (int)enum_ReportName.RG_CustomerOrderDetail ||
                iReportID == (int)enum_ReportName.RG_InvoiceDetail || iReportID == (int)enum_ReportName.RG_InvoiceSummary ||
                iReportID == (int)enum_ReportName.RG_SalesReturnSummary  || iReportID == (int)enum_ReportName.RG_SalesReturnDetail ||
                iReportID == (int)enum_ReportName.RG_InquirySummary || iReportID == (int)enum_ReportName.RG_InquiryDetail ||
                iReportID == (int)enum_ReportName.RG_DeliveryOrderSummary || iReportID == (int)enum_ReportName.RG_DeliveryOrderDetail ||
                iReportID == (int)enum_ReportName.RG_QuotationSummary || iReportID == (int)enum_ReportName.RG_QuotationDetails || 
                iReportID == (int)enum_ReportName.RG_PerformaInvoiceSummary || iReportID == (int)enum_ReportName.RG_PerformaInvoiceDetails)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);

                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorRoute, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);

                chkUseCustomerMastorSaleRep.Checked = true;
                clsCommon.SetVisibility_Panel(pnlCheckBoxes, true);
            }

            if (iReportID == (int)enum_ReportName.RG_InvoiceDetail || iReportID == (int)enum_ReportName.RG_InvoiceSummary)
            {
                clsCommon.SetVisibility_Panel(pnlInvoiceType, true);
            }

            //Item
            if (iReportID == (int)enum_ReportName.RG_CustomerOrderDetail || iReportID == (int)enum_ReportName.RG_SalesReturnDetail ||
                iReportID == (int)enum_ReportName.RG_InquiryDetail ||
                iReportID == (int)enum_ReportName.RG_InvoiceDetail || iReportID == (int)enum_ReportName.RG_DeliveryOrderDetail ||
                iReportID == (int)enum_ReportName.RG_QuotationDetails || iReportID == (int)enum_ReportName.RG_PerformaInvoiceDetails)
            {
                ////clsCommon.SetVisibility_Panel(pnlItem, true);
            }
            //Job Type
            if (iReportID == (int)enum_ReportName.RG_SalesReturnDetail || iReportID == (int)enum_ReportName.RG_SalesReturnSummary ||
                iReportID == (int)enum_ReportName.RG_DeliveryOrderSummary || iReportID == (int)enum_ReportName.RG_DeliveryOrderDetail)
            {
                clsCommon.SetVisibility_Panel(pnlJobType, true);
            }

            //Sales Note Type
            if (iReportID == (int)enum_ReportName.RG_SalesReturnSummary || iReportID == (int)enum_ReportName.RG_InvoiceDetail ||
                iReportID == (int)enum_ReportName.RG_InvoiceSummary)
            {
                clsCommon.SetVisibility_Panel(pnlNoteType, true);
            }

            if(iReportID == (int)enum_ReportName.RG_SalesReturnSummary || iReportID == (int)enum_ReportName.RG_SalesReturnDetail ||
                iReportID == (int)enum_ReportName.RG_CustomerOrderSummary || iReportID == (int)enum_ReportName.RG_CustomerOrderDetail)
            {
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, false);

                chkUseCustomerMastorSaleRep.Checked = false;
                clsCommon.SetVisibility_Panel(pnlCheckBoxes, false);
            }

            //Invoice
            if (iReportID == (int)enum_ReportName.RG_InvoiceDetail || iReportID == (int)enum_ReportName.RG_InvoiceSummary ||
                iReportID == (int)enum_ReportName.RG_CustomerOrderSummary || iReportID == (int)enum_ReportName.RG_CustomerOrderDetail ||
                iReportID == (int)enum_ReportName.RG_SalesReturnSummary || iReportID == (int)enum_ReportName.RG_SalesReturnDetail ||
                iReportID == (int)enum_ReportName.RG_DeliveryOrderSummary || iReportID == (int)enum_ReportName.RG_DeliveryOrderDetail)
            {
                clsCommon.SetEnableDisable_NormalComboBox(cbxInvType, true);
            }

            //Hide Routes
            if (iReportID == (int)enum_ReportName.RG_InquirySummary || iReportID == (int)enum_ReportName.RG_InquiryDetail ||
                iReportID == (int)enum_ReportName.RG_QuotationDetails ||
                iReportID == (int)enum_ReportName.RG_PerformaInvoiceDetails)
            {
                clsCommon.SetVisibility_Panel(pnlRoute, false);
            }
            #endregion
        }
        #endregion

        #region Customer Class/ Type / Category search
        private void Search_CustomerClassID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CustomerClass();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtCusClass.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtCusClass.Tag = frmSearchMaster.s_SearchID;
        }

        private void Search_CustomerTypeID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CustomerType();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtCusType.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtCusType.Tag = frmSearchMaster.s_SearchID;
        }
        private void Search_CustomerCategoryID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CustomerCategory();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtCusCategory.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtCusCategory.Tag = frmSearchMaster.s_SearchID;
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
    }
}