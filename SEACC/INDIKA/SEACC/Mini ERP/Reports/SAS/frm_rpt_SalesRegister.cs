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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DataTire;
using Zion.ERP.Reports.DataSets.SAS;
using Zion.ERP.Reports.DataSets;
using SEACC.DATA.Data.SAS;
using ZION.ERP.Reports.DataSets.SAS;
using ZION.ERP.Reports.DataSets;
namespace Digiteq
{
    public partial class frm_rpt_SalesRegister : MettroForm
    {
        
        //form manage
        public int iFormID;

        //for security handle
        public bool bNoAccess;
        bool bCustomerSelected = false, bCustomerClassSelected = false, bCustomerTypeSelected = false, bCustomerCategorySelected = false, bSelesRepSelected = false,
            bItemSelected = false, bSalesNoteTypeSelected = false, bJobTypeSelected = false, bDOTypeSelected = false, bRouteSelected = false,bCreatedUserSelected=false;

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
                        int iRow = dgvReports.SelectedCells[0].RowIndex;
                        int iReport = int.Parse(dgvReports.Rows[iRow].Cells[0].Value.ToString());
                        enum_ReportName Report = (enum_ReportName)iReport;

                        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(Report)))
                        {
                            string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                            if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                            {
                                #region Filter
                                ProgressBar.Value = 0;
                                bCustomerSelected = false; bCustomerClassSelected = false; bCustomerTypeSelected = false; bCustomerCategorySelected = false; bSelesRepSelected = false;
                                bItemSelected = false; bSalesNoteTypeSelected = false; bJobTypeSelected = false; bRouteSelected = false; bCreatedUserSelected = false;
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
                                if (txtCreatedUser.Tag!= null && txtCreatedUser.Tag.ToString().Trim().Length > 0)
                                    bCreatedUserSelected = true;
                                #endregion

                                #region Selected Filters
                                if (bCustomerSelected)
                                    sFilter += " Customer Name : " + txtCustomer.Text.Trim();

                                if (bSelesRepSelected)
                                    sFilter += " Sales Rep. Name : " + txtSalesRep.Text.Trim();

                                if (bItemSelected)
                                    sFilter += " Item Name : " + txtItemID.Text.Trim();

                                if (bSalesNoteTypeSelected)
                                    sFilter += " Sales Note Type : " + txtSalesNoteType.Tag.ToString();

                                if (bRouteSelected)
                                    sFilter += " Route Code : " + txtRoute.Tag.ToString();

                                if (bItemSelected)
                                    sFilter += " Item Name : " + txtItemID.Text.Trim();

                                if(bCreatedUserSelected)
                                    sFilter += " Created User : " + txtCreatedUser.Text.Trim();

                                if (rdoDeleted.Checked)
                                    sFilter += (sFilter != "" ? " | " : "") + "Cancelled Records Only ";

                                if (rdoActual.Checked)
                                    sFilter += (sFilter != "" ? " | " : "") + "Active records Only ";

                                if (rdoAll.Checked)
                                    sFilter += (sFilter != "" ? " | " : "") + "All Records ";

                                if (cbxApproval.SelectedIndex != 0)
                                    sFilter += (sFilter != "" ? " | " : "") + "Approval :  " + cbxApproval.Text;

                                if (checkBox1.Checked )
                                    sFilter +=  "Current month returns only " ;

                                if (pnlReturnType.Visible)
                                {
                                    if (rdbNew.Checked)
                                        sFilter += (sFilter != "" ? " | " : "") + "New Returns Only ";
                                    if (rdbOld.Checked)
                                        sFilter += (sFilter != "" ? " | " : "") + "Old Returns Only ";
                                }
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
                                        List<tbl_sasSalesReturnedNote> oSRetNote = tbl_sasSalesReturnedNote.SelectForReport(dtpFrom.Value.Date,dtpTo.Value.Date, checkBox1.Checked?"Y":"").Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() &&  p.CompanyBranch_ID == clsSecurity.BranchID).ToList();
                                        //p.SalesReturnedNoteDate.Date >= dtpFrom.Value.Date  && p.SalesReturnedNoteDate.Date <= dtpTo.Value.Date &&
                                        foreach (tbl_sasSalesReturnedNote oSRN in oSRetNote)
                                        {
                                            //add filters - janith
                                            if (rdoDeleted.Checked && !oSRN.IsDeleted)
                                                continue;
                                            else if (rdoActual.Checked && oSRN.IsDeleted)
                                                continue;

                                            if (rdbNew.Checked && !oSRN.isNewReturn)
                                                continue;
                                            else if (rdbOld.Checked && oSRN.isNewReturn)
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

                                                    //tbl_pmsProductionJobRegister oJob = tbl_pmsProductionJobRegister.Select(oDO.Job_ID);
                                                    //if (oJob != null)
                                                    //{
                                                    //    if (bJobTypeSelected)
                                                    //    {
                                                    //        if (oJob.Job_ID == "default")
                                                    //        {
                                                    //            if (txtJobType.Tag.ToString().Trim() != "PJT/009" && txtJobType.Tag.ToString().Trim() != "PJT/010")
                                                    //                continue;
                                                    //        }
                                                    //        else if (oJob.ProductionJobType_ID != txtJobType.Tag.ToString().Trim())
                                                    //            continue;
                                                    //    }
                                                    //    if (oJob.ProductionJobType_ID != "default")
                                                    //    {
                                                    //        sJobTypeID = oJob.ProductionJobType_ID;
                                                    //        sJobTypeName = clsGenaralName.getName_ProductionJobType(oJob.ProductionJobType_ID);
                                                    //    }
                                                    //}
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
                                                            oSRN.Invoice_ID+" - "+oSRN.DatePrinted.ToString("dd-MMM-yyyy"), oSRN.Remark, oSRN.IsWeightCalculation, oSRN.NbtTotal, oSRN.VatTotal, oSRN.DiscountTotal,
                                                            oSRN.IsDeleted, sJobTypeID, sJobTypeName, clsGenaralName.getName_SalesNoteType(oSRN.SalesNoteType_ID), "", 0, 0, "");
                                                }
                                                bItemInserted = false;
                                                #endregion
                                            }
                                            clsHelpMethods_Local.startProgressBar(0, oSRetNote.Count + 2, 1, ProgressBar);
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
                                                clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID), "", "", "", detail.Currency_ID, clsGenaralName.getName_CurrencyCode(detail.Currency_ID), detail.Store_ID, clsGenaralName.getName_Store(detail.Store_ID),
                                                detail.IsSVAT ? oCustomer.SvatRegistrationNo : oCustomer.VatRegistrationNo, oCustomer.NbtRegistrationNo, "", "", "", "", "");

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
                                {
                                    try
                                    {
                                        string sRouteID = "";

                                        glb_dts_sasDeliveryOrder.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.WaitCursor;

                                        List<tbl_sasDeliveryOrder> details = tbl_sasDeliveryOrder
                                            .SelectAllByDateRange(dtpFrom.Value.Date, dtpTo.Value.Date)
                                            .Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString())
                                            .OrderBy(p => p.DeliveryOrderDate).ToList();

                                        switch (cbxApproval.SelectedIndex)
                                        {
                                            case 1:
                                                {
                                                    if (details.Count > 0)
                                                        details = details.Where(r => r.IsApproved).ToList();
                                                }
                                                break;
                                            case 2:
                                                {
                                                    if (details.Count > 0)
                                                        details = details.Where(r => !r.IsApproved).ToList();
                                                }
                                                break;
                                        }

                                        foreach (tbl_sasDeliveryOrder detail in details)
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
                                                SasDeliveryOrder_data data = new SasDeliveryOrder_data();

                                                foreach (SEACC.DATA.Domain.SAS.tbl_sasDeliveryOrder_Detail_View DOdetail in data.SelectAllByDeliveryOrder_ID (detail.DeliveryOrder_ID))
                                                {
                                                    if (bItemSelected)
                                                        if (DOdetail.item_ID != txtItemID.Tag.ToString())
                                                            continue;

                                                    glb_dts_sasDeliveryOrder.dt_deliveryOrderDetail.Adddt_deliveryOrderDetailRow(DOdetail.deliveryOrder_ID, "0", DOdetail.item_ID, clsGenaralName.getName_Item(DOdetail.item_ID), clsGenaralName.getDescription_Item(DOdetail.item_ID), DOdetail.carton_No, DOdetail.qty, DOdetail.weight, clsGenaralName.getName_Uom(DOdetail.packingUom_ID), DOdetail.unitPrice, DOdetail.bIsFreeItem, DOdetail.discountPresentage, DOdetail.discountAmount, DOdetail.tatalAmount, 0, "",DOdetail.store_ID,DOdetail.storeName);
                                                }
                                            }
                                            else
                                                iItemCount = tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(detail.DeliveryOrder_ID).Count();

                                            glb_dts_sasDeliveryOrder.dt_deliveryOrderHeader.Adddt_deliveryOrderHeaderRow(detail.DeliveryOrder_ID, detail.DeliveryOrderDate, "", detail.Customer_ID, clsGenaralName.getName_Customer(detail.Customer_ID), clsGenaralName.getName_CustomerDeliveryAddress(detail.Customer_ID), "", clsGenaralName.getName_BranchCustomer(detail.Customer_ID, int.Parse(detail.Branch_ID)), clsGenaralName.getName_CustomerTelephone(detail.Customer_ID), detail.Store_ID, clsGenaralName.getName_Store(detail.Store_ID), "", clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID),
                                                    detail.Vehicle_No, detail.SubTotal, detail.DiscountTotal, detail.DiscountPercentage, detail.NbtTotal, detail.NbtPercentage, detail.VatTotal, detail.VatPercentage, detail.VatTotal, detail.VatPercentage, detail.GrandTotal, sSalesmanID, detail.IsWeightCalculation, clsGenaralName.getName_Employee(sSalesmanID), detail.IsDeleted, iItemCount, DateTime.MinValue, "", "", "", "", "", "", "");
                                        }

                                        glb_dts_sasDeliveryOrder.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
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
                                            if (rdoDeleted.Checked && !oInvoice.IsDeleted)
                                                continue;

                                            else if (rdoActual.Checked && oInvoice.IsDeleted)
                                                continue;

                                            if (bCreatedUserSelected)
                                            {
                                                if (oInvoice.CreateUser_ID != txtCreatedUser.Tag.ToString())
                                                    continue;
                                            }
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
                                                        //tbl_pmsProductionJobRegister oJob = tbl_pmsProductionJobRegister.Select(oInvoice.Job_ID);
                                                        //if (oJob != null)
                                                        //{
                                                        //    sInvoiceType = clsGenaralName.getName_ProductionJobType(oJob.ProductionJobType_ID);
                                                        //    if (bJobTypeSelected)
                                                        //    {
                                                        //        if (oJob.ProductionJobType_ID != txtJobType.Tag.ToString().Trim())
                                                        //            continue;
                                                        //    }
                                                        //}
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
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("GrandTotal_AllInvoices", clsFormatter.FormatDecimalPlaces_Price(dGrandTotal_AllInvoices), true);

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
            txtCreatedUser.Tag = null;
            checkBox1.Checked = false;
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
            txtCreatedUser.Text = "<<ALL Users>>";

            txtBranch.Text = clsGenaralName.getName_CompanyBranchMaster(clsSecurity.BranchID);
            cbxInvType.SelectedIndex = 3;
            cmbDOType.SelectedIndex = 0;
            cbxApproval.SelectedIndex = 0;
            rdoActual.Checked = true;
            chkUseCustomerMastorSaleRep.Checked = false;
            chkShowAll.Checked = false;

            rdbNew.Checked = true;
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
            clsCommon.SetVisibility_Panel(pnlApproved, false);
            clsCommon.SetVisibility_Panel(pnlReturnType, false);
            clsCommon.SetVisibility_Panel(pnlCreatedUser, false);

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
            {
                Search_CustomerID();
            }
        }
        private void txtSalesRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_SalesRepID();
            }
        }
        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsHelpMethods_Local.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
            }
        }
        private void frm_rpt_ChequeManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
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
            //txtSalesRep.Tag = null;
            //txtSalesRep.Text = "<All SalesReps>";
        }
        private void txtSalesRep_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesRepID();
            //txtCustomer.Tag = null;
            //txtCustomer.Text = "<All Customers>";
        }
        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            clsHelpMethods_Local.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
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
            //if (rdoReconciliatedCheques.Checked || rdoProformaInvoice.Checked)
            //{
            //    if (txtBank.Tag != null && txtBank.Tag.ToString().Length > 0)
            //        clsSearch.passValue_CompanyAccountByBankID(txtBank.Tag.ToString());
            //    else
            //        clsSearch.passValue_CompanyAccount(); 
            //}
            //else
            //{
            //    if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Length > 0)
            //        clsSearch.passValue_CustomerAccountByCustomerID(txtCustomer.Tag.ToString());
            //    else
            //        clsSearch.passValue_CustomerAccount(); 
            //}

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
            {
                //if (frmSearchTransaction.s_SearchText.Length > 0)
                //    txtAccount.Text = frmSearchTransaction.s_SearchID;
                //if (frmSearchTransaction.s_SearchID.Length > 0)
                //    txtAccount.Tag = frmSearchTransaction.s_SearchID;                
            }
        }

        private void txtCreatedUser_DoubleClick(object sender, EventArgs e)
        {
            Form frmhelpsearch = new frmSearchMaster();
            if (clsSecurity.UserIDLoged.Trim().ToUpper() == "DIGITEQ")
                clsSearch.passValue_User(false);
            else
                clsSearch.passValue_User(true);
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtCreatedUser.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtCreatedUser.Tag = frmSearchMaster.s_SearchID;
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

            //Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_CustomerMaster();
            //frmhelpsearch.ShowDialog();

            //if (frmSearchMaster.s_SearchID.Length > 0)
            //{
            //    if (frmSearchMaster.s_SearchText.Length > 0)
            //        txtCustomer.Text = frmSearchMaster.s_SearchText;
            //    if (frmSearchMaster.s_SearchID.Length > 0)
            //        txtCustomer.Tag = frmSearchMaster.s_SearchID;
            //}
        }
        private void Search_BankID()
        {
            //Form frmhelpsearch = new frmSearchMaster();
            //if (rdoProformaInvoice.Checked || rdoReconciliatedCheques.Checked)
            //    clsSearch.passValue_BankCompany();
            //else
            //    clsSearch.passValue_Bank();
            //frmhelpsearch.ShowDialog();

            //if (frmSearchMaster.s_SearchID.Length > 0)
            //{
            //    if (frmSearchMaster.s_SearchText.Length > 0)
            //        txtBank.Text = frmSearchMaster.s_SearchText;
            //    if (frmSearchMaster.s_SearchID.Length > 0)
            //        txtBank.Tag = frmSearchMaster.s_SearchID;
            //}
        }
        private void Search_SalesRepID()
        {
            try
            {
                clsSearch.Search_MasterSalesRep(ref txtSalesRep);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
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

            if (iReportID == (int)enum_ReportName.RG_InvoiceSummary)
            {
                clsCommon.SetVisibility_Panel(pnlCustomer, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);

                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorRoute, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);

                chkUseCustomerMastorSaleRep.Checked = true;
                clsCommon.SetVisibility_Panel(pnlCheckBoxes, true);
                clsCommon.SetVisibility_Panel(pnlInvoiceType, true);
                clsCommon.SetVisibility_Panel(pnlNoteType, true);
                clsCommon.SetEnableDisable_NormalComboBox(cbxInvType, true);
                clsCommon.SetVisibility_Panel(pnlCreatedUser, true);
            }

            if (iReportID == (int)enum_ReportName.RG_SalesReturnSummary || iReportID == (int)enum_ReportName.RG_SalesReturnDetail)
            { 
                clsCommon.SetVisibility_Panel(pnlReturnType, false);
 clsCommon.SetVisibility_Panel(panel3, true);
            }


            #region Customer Order
            //Customer / Sale Rep
            if (iReportID == (int)enum_ReportName.RG_CustomerOrderSummary || iReportID == (int)enum_ReportName.RG_CustomerOrderDetail ||
                iReportID == (int)enum_ReportName.RG_InvoiceDetail  ||
                iReportID == (int)enum_ReportName.RG_SalesReturnSummary || iReportID == (int)enum_ReportName.RG_SalesReturnDetail ||
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

            if (iReportID == (int)enum_ReportName.RG_InvoiceDetail )
            {
                clsCommon.SetVisibility_Panel(pnlInvoiceType, true);
            }

            //Item
            if (iReportID == (int)enum_ReportName.RG_CustomerOrderDetail || iReportID == (int)enum_ReportName.RG_SalesReturnDetail ||
                iReportID == (int)enum_ReportName.RG_InquiryDetail ||
                iReportID == (int)enum_ReportName.RG_InvoiceDetail || iReportID == (int)enum_ReportName.RG_DeliveryOrderDetail ||
                iReportID == (int)enum_ReportName.RG_QuotationDetails || iReportID == (int)enum_ReportName.RG_PerformaInvoiceDetails)
            {
                clsCommon.SetVisibility_Panel(pnlItem, true);
            }
            //Job Type
            if (iReportID == (int)enum_ReportName.RG_SalesReturnDetail || iReportID == (int)enum_ReportName.RG_SalesReturnSummary ||
                iReportID == (int)enum_ReportName.RG_DeliveryOrderSummary || iReportID == (int)enum_ReportName.RG_DeliveryOrderDetail)
            {
                clsCommon.SetVisibility_Panel(pnlJobType, true);
            }

            //Sales Note Type
            if (iReportID == (int)enum_ReportName.RG_SalesReturnSummary || iReportID == (int)enum_ReportName.RG_InvoiceDetail 
               )
            {
                clsCommon.SetVisibility_Panel(pnlNoteType, true);
            }

            if (iReportID == (int)enum_ReportName.RG_SalesReturnSummary || iReportID == (int)enum_ReportName.RG_SalesReturnDetail ||
                iReportID == (int)enum_ReportName.RG_CustomerOrderSummary || iReportID == (int)enum_ReportName.RG_CustomerOrderDetail)
            {
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, false);

                chkUseCustomerMastorSaleRep.Checked = false;
                clsCommon.SetVisibility_Panel(pnlCheckBoxes, false);
            }

            //Invoice
            if (iReportID == (int)enum_ReportName.RG_InvoiceDetail || 
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
            //Approved
            if (iReportID == (int)enum_ReportName.RG_DeliveryOrderDetail || iReportID == (int)enum_ReportName.RG_DeliveryOrderSummary)
            {
                clsCommon.SetVisibility_Panel(pnlApproved, true);
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



#region Events CheckedChange
//private void rdoDailySalesReport_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoConfirmedJobSummary_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoDailySalesReportSummary_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoClosedJobSummary_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoPendingCustomerOrderSummery_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoPendingCustomerOrderDetail_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoPendingInquiryOrderSummery_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoPendingInquiryOrderDetail_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoPendingInquiryItem_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoPendingOrderItem_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoPendingDeliveryItem_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoPendingDeliverySummary_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoPendingDeliveryDetail_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoInvoiceDetail_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoInvoiceSummary_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoRecieptSummary_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoRecieptSummary_Account_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoDailyInvoiceRegister_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoCrediteNote_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoDebitNote_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
#endregion

#region Events CheckedChanged
//private void rdoRegisteredCheques_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoChequeToBeDeposited_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoReIssuedCheques_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoDeposittedCheques_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoReconciliatedCheques_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoChequeReturnedSummery_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoChequeRealizedSummary_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoChequeSummery_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoPendingChequeReconciliate_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdbQuatationSummery_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}

//private void rdbPerformanceSummery_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdbQuataionDetails_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}

//private void rdbProformDet_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}

//private void rdoRecieptSummary_CheckedChanged_1(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}
//private void rdoSalesReturn_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//}

//private void rdoSalesReturnSummary_CheckedChanged(object sender, EventArgs e)
//{
//    clearField();
//    setEnableDisableConctrol();
//    chkIsGroupbyProducionJob.Checked = true;
//}
#endregion

#region Customer oder details
//else if (Report == enum_ReportName.RG_CustomerOrderDetail)
////else if (rdoCustomerOrderDetail.Checked)
//{
//    try
//    {
//        string sRouteID = "";
//        glb_dts_sasCustomerOrder.Clear();
//        glb_dtsReportExport.Clear();
//        Cursor = Cursors.WaitCursor;

//        List<tbl_sasCustomerOrder> oCO = tbl_sasCustomerOrder.SelectAll().Where(p => p.CustomerOrder_ID != "default" && p.CompanyBranch_ID == txtBranch.Tag.ToString() && p.CustomerOrderDate.Date >= dtpFrom.Value.Date && p.CustomerOrderDate.Date <= dtpTo.Value.Date).ToList();

//        foreach (tbl_sasCustomerOrder detail in oCO)
//        {
//            #region Filter - Customer
//            //if (bCustomerSelected)
//            //{
//            //    if (detail.Customer_ID != txtCustomer.Tag.ToString().Trim())
//            //        continue;
//            //}
//            #endregion

//            #region Filter - Deleted Records
//            //if (rdoDeleted.Checked)
//            //{
//            //    if (!detail.IsDeleted)
//            //        continue;
//            //}
//            //else if (rdoActual.Checked)
//            //{
//            //    if (detail.IsDeleted)
//            //        continue;
//            //}
//            #endregion

//            //tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(detail.Customer_ID);
//            //if (oCustomer != null)
//            //{
//            #region Filter - Sales Rep
//            //    string sSalesmanID = oCustomer.SalesRep_ID;

//            //    if (!chkUseCustomerMastorSaleRep.Checked)
//            //    {
//            //        tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
//            //        if (oRef != null && oRef.OrderRefNo_ID != "default")
//            //            sSalesmanID = oRef.Employee_ID;
//            //    }

//            //    if (bSelesRepSelected)
//            //    {
//            //        if (sSalesmanID != txtSalesRep.Tag.ToString().Trim())
//            //            continue;
//            //    }
//            #endregion

//            #region Route
//            //    if (bRouteSelected)
//            //    {
//            //        if (!chkUseCustomerMastorRoute.Checked)
//            //        {
//            //            sRouteID = detail.Route_ID.ToString();
//            //        }
//            //        else
//            //        {
//            //            foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(detail.Customer_ID))
//            //            {
//            //                sRouteID = oRoute.Route_ID.ToString();
//            //                if (txtRoute.Tag.ToString() == sRouteID)
//            //                    break;
//            //            }
//            //        }

//            //        if (txtRoute.Tag.ToString() != sRouteID)
//            //            continue;
//            //    }
//            #endregion
//            //}

//            //glb_dts_sasCustomerOrder.dt_sasCustomerOrder.Adddt_sasCustomerOrderRow(detail.CustomerOrder_ID, detail.CustomerOrderDate, detail.DeliveryDate.Date, detail.DeliveryAddress, clsGenaralName.getName_Customer(detail.Customer_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Remark, detail.Customer_ID, "p_Date", detail.GrandTotal, detail.SubTotal, detail.DiscountTotal, detail.NbtTotal, detail.VatTotal, detail.OtherTaxTotal, detail.AdvanceAmount, detail.Quotation_ID, detail.PurchaseOrder_ID, detail.DiscountPercentage, detail.NbtPercentage, detail.VatPercentage, detail.OtherTaxPercentage, "", "", detail.IsWeightCalculation, detail.IsSeattled, detail.IsDeleted, detail.IsApproved, "", "", "", "", detail.Employee_ID, clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID), "", "", "");

//            //foreach (tbl_sasCustomerOrder_Detail cdetail in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(detail.CustomerOrder_ID))
//            //{
//            //    if (bItemSelected)
//            //        if (cdetail.Item_ID != txtItemID.Tag.ToString())
//            //            continue;

//            //    glb_dts_sasCustomerOrder.dt_sasCustomerOrderDetail.Adddt_sasCustomerOrderDetailRow(cdetail.CustomerOrder_ID, cdetail.Item_ID, clsGenaralName.getName_Item(cdetail.Item_ID), cdetail.Qty, cdetail.Weight, cdetail.UnitPrice, cdetail.BIsFreeItem, cdetail.DiscountPresentage, cdetail.DiscountAmount, cdetail.Remark, cdetail.TatalAmount, "", 0, 0, 0, clsGenaralName.getName_ItemUOM(cdetail.Item_ID), cdetail.WeightPrice, cdetail.QtySettle_DeliveryOrder, clsGenaralName.getName_ItemCategorySub(cdetail.ItemSubCategory_ID));
//            //}
//        }


//        //if (bCustomerSelected)
//        //    sFilter += " Customer Name : " + txtCustomer.Text.Trim();

//        //if (bItemSelected)
//        //    sFilter += " Item Name : " + txtItemID.Text.Trim();

//        //if (rdoDeleted.Checked)
//        //    sFilter += (sFilter != "" ? " | " : "") + "Cancelled Records Only ";
//        //if (rdoActual.Checked)
//        //    sFilter += (sFilter != "" ? " | " : "") + "Active records Only ";
//        //if (rdoAll.Checked)
//        //    sFilter += (sFilter != "" ? " | " : "") + "All Records ";

//        //glb_dts_sasCustomerOrder.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

//        //frm_ReportViewer_New rpt = new frm_ReportViewer_New();
//        ////   rpt.Process_Print((int)enum_ReportName.RG_CustomerOrderDetail);
//        //rpt.print(sReportPath, glb_dts_sasCustomerOrder, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.RG_CustomerOrderDetail));

//    }
//    catch (Exception ex)
//    {
//        clsValidate.WriteErrorLog("", iFormID,ex);
//        SEACCException.Show(ex);
//    }
//    finally
//    {
//        glb_dts_sasCustomerOrder.Clear();
//        glb_dtsReportExport.Clear();
//        Cursor = Cursors.Default;
//    }
//}
#endregion

#region Delivery Summery
//else if (rdoDeliverySummary.Checked)
//{
//    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_DeliveryOrderSummary)))
//    {
//        #region old
//        //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
//        //{
//        //    sFormula = " {vw_rpt_sasInvDeliveryOrder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasInvDeliveryOrder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
//        //    if (bCustomerSelected)
//        //    {
//        //        sFormula += "and {vw_rpt_sasInvDeliveryOrder.customer_ID}= '" + txtCustomer.Tag.ToString().Trim() + "' ";
//        //        sFilter += " User Name : " + txtCustomer.Text.Trim();
//        //    }
//        //    if (bSelesRepSelected)
//        //    {
//        //        sFormula += "and {vw_rpt_sasInvDeliveryOrder.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
//        //        sFilter += " User Name : " + txtSalesRep.Text.Trim();
//        //    }
//        //    if (bJobTypeSelected)
//        //    {
//        //        sFormula += "and {vw_rpt_sasInvDeliveryOrder.productionJobType_ID} = '" + txtJobType.Tag.ToString().Trim() + "'";
//        //        sFilter += " Job Type : " + txtJobType.Text.Trim();
//        //    }

//        //    if (rdoDeleted.Checked)
//        //        sFormula += " and {vw_rpt_sasInvDeliveryOrder.isDeleted} = True";
//        //    if (rdoActual.Checked)
//        //        sFormula += " and {vw_rpt_sasInvDeliveryOrder.isDeleted}= False";
//        //    print("\\reports\\SAS\\Commen\\rpt_sas_DeliveryOrder_Summery_Inv.rpt", " Delivery Order Summary ", sFormula);
//        //}
//        //#endregion

//        //#region AKT
//        //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
//        //{
//        //    try
//        //    {
//        //        Cursor = Cursors.WaitCursor;
//        //        glb_dtsSales.dt_sasDeliveryOrderSummary.Rows.Clear();

//        //        if (bJobTypeSelected)
//        //        {
//        //            if (sFilter.Length > 0)
//        //                sFilter += " | Job Type : " + txtJobType.Text.Trim();
//        //            else
//        //                sFilter += "Job Type : " + txtJobType.Text.Trim();
//        //        }

//        //        /*if (bDOTypeSelected)
//        //        {
//        //            if (sFilter.Length > 0)
//        //                sFilter += "| DO Type" + cmbDOType.SelectedItem.ToString();
//        //            else
//        //                sFilter += "DO Type" + cmbDOType.SelectedItem.ToString();
//        //        }*/

//        //        string sPoID = "";
//        //        List<tbl_sasDeliveryOrder> oDOs = new List<tbl_sasDeliveryOrder>();
//        //        oDOs = (bCustomerSelected) ? tbl_sasDeliveryOrder.SelectAllByCustomer_ID(txtCustomer.Tag.ToString().Trim()).Where(p => p.DeliveryOrderDate.Date >= dtpFrom.Value.Date && p.DeliveryOrderDate.Date <= dtpTo.Value.Date).ToList()
//        //            : tbl_sasDeliveryOrder.SelectAll().Where(p => p.DeliveryOrderDate.Date >= dtpFrom.Value.Date && p.DeliveryOrderDate.Date <= dtpTo.Value.Date).ToList();

//        //        foreach (tbl_sasDeliveryOrder oDO in oDOs)
//        //        {
//        //            #region filter - Cancel records
//        //            if (rdoActual.Checked)
//        //            {
//        //                if (oDO.IsDeleted)
//        //                    continue;
//        //            }
//        //            if (rdoDeleted.Checked)
//        //            {
//        //                if (!oDO.IsDeleted)
//        //                    continue;
//        //            }
//        //            #endregion

//        //            bool bSalesRepOK = true, bActiveOK = true;
//        //            string sSalesman = "";
//        //            // string sJobType = "";
//        //            string sDoType = "";

//        //            #region Filter  -job/Do
//        //            tbl_pmsProductionJobRegister oJob = tbl_pmsProductionJobRegister.Select(oDO.Job_ID);
//        //            if (oJob != null && oJob.ProductionJob_ID != "default")
//        //            {
//        //                if (oJob.ProductionJobType_ID == "PJT/001" || oJob.ProductionJobType_ID == "PJT/002")
//        //                    sDoType = "Kandana";
//        //                else if (oJob.ProductionJobType_ID == "PJT/003" || oJob.ProductionJobType_ID == "PJT/004")
//        //                    sDoType = "Pettah";
//        //                else if (oJob.ProductionJobType_ID == "PJT/007" || oJob.ProductionJobType_ID == "PJT/008")
//        //                    sDoType = "Sample";
//        //                else if (oJob.ProductionJobType_ID == "PJT/009" || oJob.ProductionJobType_ID == "PJT/010")
//        //                    sDoType = "Direct";
//        //                else if (oJob.ProductionJobType_ID == "PJT/013" || oJob.ProductionJobType_ID == "PJT/014")
//        //                    sDoType = "Block";
//        //                else if (oJob.ProductionJobType_ID == "PJT/011" || oJob.ProductionJobType_ID == "PJT/012")
//        //                    sDoType = "Chemical";
//        //                else
//        //                    sDoType = "-";

//        //                if (cmbDOType.Text != "<All Type>")
//        //                {
//        //                    if (cmbDOType.Text.Trim() != sDoType)
//        //                        continue;
//        //                }
//        //            }
//        //            else
//        //            {
//        //                sDoType = "-";
//        //            }
//        //            #endregion

//        //            if (bSelesRepSelected)
//        //            {
//        //                sFilter += " Salesman Name : " + txtSalesRep.Text.Trim();
//        //                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oDO.OrderRefNo_ID);
//        //                if (oRef != null)
//        //                    bSalesRepOK = oRef.Employee_ID == txtSalesRep.Tag.ToString() ? true : false;
//        //            }



//        //            //if (rdoActual.Checked)
//        //            //{
//        //            //if (rdoDeleted.Checked && oDO.IsDeleted == false)
//        //            //    bActiveOK = false;
//        //            //else if (rdoActual.Checked && oDO.IsDeleted)
//        //            //    bActiveOK = false;

//        //            if (bSalesRepOK && bActiveOK)
//        //            {
//        //                List<tbl_sasDeliveryOrder_Detail> oDODetails = tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDO.DeliveryOrder_ID);
//        //                foreach (tbl_sasDeliveryOrder_Detail oDODetail in oDODetails)
//        //                {
//        //                    sPoID = clsHelpMethods.GetPONoByCustomerOrderID(oDO.CustomerOrder_ID);
//        //                    if (oDO.IsDeleted)
//        //                    {
//        //                        glb_dtsSales.dt_sasDeliveryOrderSummary.Adddt_sasDeliveryOrderSummaryRow(oDO.DeliveryOrder_ID, oDO.DeliveryOrderDate, oDO.Job_ID, clsGenaralName.getName_Customer(oDO.Customer_ID), sPoID, clsGenaralName.getName_Item(oDODetail.Item_ID),
//        //                            0, 0, 0, 0, 0, 0, oDO.IsDeleted, sDoType, sSalesman, oDO.GrandTotal);
//        //                    }
//        //                    else
//        //                    {
//        //                        decimal dActualQty = 0, dActualWeight = 0;

//        //                        dActualQty = oDODetail.Qty - oDODetail.QtyReturned;
//        //                        dActualWeight = oDODetail.Weight - oDODetail.WeightReturned;

//        //                        //  sPoID = clsHelpMethods.GetPONoByCustomerOrderID(oDO.CustomerOrder_ID);
//        //                        glb_dtsSales.dt_sasDeliveryOrderSummary.Adddt_sasDeliveryOrderSummaryRow(oDO.DeliveryOrder_ID, oDO.DeliveryOrderDate, oDO.Job_ID != "default" ? oDO.Job_ID : "-", clsGenaralName.getName_Customer(oDO.Customer_ID), sPoID != "default" ? sPoID : "-", clsGenaralName.getName_Item(oDODetail.Item_ID),
//        //                            (oDODetail.IsWeightCalculation ? oDODetail.Weight : oDODetail.Qty), oDODetail.Weight, (oDODetail.IsWeightCalculation ? oDODetail.WeightReturned : oDODetail.QtyReturned), oDODetail.WeightReturned, (oDODetail.IsWeightCalculation ? dActualWeight : dActualQty), dActualWeight, oDO.IsDeleted, sDoType, sSalesman, oDO.GrandTotal);
//        //                    }
//        //                    clsHelpMethods.startProgressBar(0, oDODetails.Count + 2, 1, ProgressBar);
//        //                }
//        //            }
//        //            ProgressBar.Value = 0;
//        //            // }
//        //            //else if (rdoDeleted.Checked)
//        //            //{
//        //            //    if (!oDO.IsDeleted)
//        //            //        bActiveOK = false;

//        //            //    if (bSalesRepOK && bActiveOK)
//        //            //    {
//        //            //        List<tbl_sasDeliveryOrder_Detail> oDODetails = tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDO.DeliveryOrder_ID);
//        //            //        foreach (tbl_sasDeliveryOrder_Detail oDODetail in oDODetails)
//        //            //        {
//        //            //            sPoID = clsHelpMethods.GetPONoByCustomerOrderID(oDO.CustomerOrder_ID);
//        //            //            glb_dtsSales.dt_sasDeliveryOrderSummary.Adddt_sasDeliveryOrderSummaryRow(oDO.DeliveryOrder_ID, oDO.DeliveryOrderDate, oDO.Job_ID, clsGenaralName.getName_Customer(oDO.Customer_ID), sPoID, clsGenaralName.getName_Item(oDODetail.Item_ID),
//        //            //                0, 0, 0, 0, 0, 0, oDO.IsDeleted, sJobType, sSalesman, oDO.GrandTotal);

//        //            //            clsHelpMethods.startProgressBar(0, oDODetails.Count + 2, 1, ProgressBar);
//        //            //        }
//        //            //    }
//        //            //    ProgressBar.Value = 0;
//        //            //}
//        //            //else if (rdoAll.Checked)
//        //            //{
//        //            //    if (bSalesRepOK && bActiveOK)
//        //            //    {
//        //            //        List<tbl_sasDeliveryOrder_Detail> oDODetails = tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDO.DeliveryOrder_ID).ToList();
//        //            //        foreach (tbl_sasDeliveryOrder_Detail oDODetail in oDODetails)
//        //            //        {
//        //            //            decimal dQty = 0, dWeight = 0, dQtyReturned = 0, dWeightReturned = 0, dActualQty = 0, dActualWeight = 0;

//        //            //            dQty = oDO.IsDeleted ? 0 : (oDO.IsWeightCalculation ? oDODetail.Weight : oDODetail.Qty);
//        //            //            dWeight = oDO.IsDeleted ? 0 : oDODetail.Weight;
//        //            //            dQtyReturned = oDO.IsDeleted ? 0 : (oDO.IsWeightCalculation ? oDODetail.WeightReturned : oDODetail.QtyReturned);
//        //            //            dWeightReturned = oDO.IsDeleted ? 0 : oDODetail.WeightReturned;
//        //            //            dActualQty = oDO.IsDeleted ? 0 : (oDO.IsWeightCalculation ? (oDODetail.Weight - oDODetail.WeightReturned) : (oDODetail.Qty - oDODetail.QtyReturned));
//        //            //            dActualWeight = oDO.IsDeleted ? 0 : oDODetail.Weight - oDODetail.WeightReturned;

//        //            //            sPoID = clsHelpMethods.GetPONoByCustomerOrderID(oDO.CustomerOrder_ID);
//        //            //            glb_dtsSales.dt_sasDeliveryOrderSummary.Adddt_sasDeliveryOrderSummaryRow(oDO.DeliveryOrder_ID, oDO.DeliveryOrderDate, oDO.Job_ID, clsGenaralName.getName_Customer(oDO.Customer_ID), sPoID, clsGenaralName.getName_Item(oDODetail.Item_ID),
//        //            //                dQty, dWeight, dQtyReturned, dWeightReturned, dActualQty, dActualWeight, oDO.IsDeleted, sJobType, sSalesman, oDO.GrandTotal);

//        //            //            clsHelpMethods.startProgressBar(0, oDODetails.Count + 2, 1, ProgressBar);
//        //            //        }
//        //            //        ProgressBar.Value = 0;
//        //            //    }
//        //            //}
//        //        }
//        //        print("\\Reports\\SAS\\Commen\\rpt_sas_DeliveryOrder_Summery_AKT_New.rpt", " Delivery Order Summary ", "", "", glb_dtsSales, 0);
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        SEACCException.Show(ex);
//        //    }
//        //    finally
//        //    {
//        //        //ProgressBar.Value = 0;
//        //        Cursor = Cursors.Default;
//        //        glb_dtsSales.dt_sasDeliveryOrderSummary.Rows.Clear();
//        //    }
//        //}
//        #endregion

//        #region MyRegion
//        {
//            try
//            {
//                #region Others
//                Cursor = Cursors.WaitCursor;
//                glb_dtsSales.dt_sasDeliveryOrderSummary.Rows.Clear();

//                string sPoID = "";
//                List<tbl_sasDeliveryOrder> oDOs;

//                oDOs = new List<tbl_sasDeliveryOrder>().Where(p => p.CompanyBranch_ID == clsSecurity.BranchID).ToList();
//                oDOs = (bCustomerSelected) ? tbl_sasDeliveryOrder.SelectAllByCustomer_ID(txtCustomer.Tag.ToString().Trim()).Where(p => p.DeliveryOrderDate.Date >= dtpFrom.Value.Date && p.DeliveryOrderDate.Date <= dtpTo.Value.Date).ToList()
//                    : tbl_sasDeliveryOrder.SelectAll().Where(p => p.DeliveryOrderDate.Date >= dtpFrom.Value.Date && p.DeliveryOrderDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == clsSecurity.BranchID).ToList();

//                foreach (tbl_sasDeliveryOrder oDO in oDOs)
//                {
//                    bool bSalesRepOK = true;// bActiveOK = true;
//                    string sSalesman = "", sRefNo = "";

//                    tbl_pmsProductionJobRegister oJob = tbl_pmsProductionJobRegister.Select(oDO.Job_ID);
//                    if (oJob != null)
//                    {
//                        if (bJobTypeSelected)
//                        {
//                            sFilter += " Job Type : " + txtJobType.Text.Trim();
//                            if (oJob.ProductionJobType_ID != txtJobType.Tag.ToString().Trim() || oJob.Job_ID != "default")
//                            {
//                                continue;
//                            }
//                        }
//                    }

//                    if (rdoActual.Checked)
//                    {
//                        if (oDO.IsDeleted)
//                            continue;
//                    }
//                    if (rdoDeleted.Checked)
//                    {
//                        if (!oDO.IsDeleted)
//                            continue;
//                    }

//                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oDO.OrderRefNo_ID);
//                    if (oRef != null)
//                    {
//                        sRefNo = oRef.OrderRefNo;
//                        sSalesman = clsGenaralName.getName_SalesRep(oRef.Employee_ID);
//                    }
//                    if (bSelesRepSelected)
//                    {
//                        tbl_zOrderRefNo oRef1 = tbl_zOrderRefNo.Select(oDO.OrderRefNo_ID);
//                        if (oRef1 != null)
//                        {
//                            sFilter += " Salesman Name : " + txtSalesRep.Text.Trim();
//                            bSalesRepOK = oRef1.Employee_ID == txtSalesRep.Tag.ToString() ? true : false;
//                        }
//                    }

//                    if (bSalesRepOK)
//                    {
//                        sPoID = clsHelpMethods.GetPONoByCustomerOrderID(oDO.CustomerOrder_ID);
//                        glb_dtsSales.dt_sasDeliveryOrderSummary.Adddt_sasDeliveryOrderSummaryRow(oDO.DeliveryOrder_ID, oDO.DeliveryOrderDate, oDO.Job_ID, clsGenaralName.getName_Customer(oDO.Customer_ID), sPoID, "",
//                            0, 0, 0, 0, 0, 0, oDO.IsDeleted, sRefNo, sSalesman, oDO.GrandTotal);
//                    }
//                    clsHelpMethods.startProgressBar(0, oDOs.Count + 2, 1, ProgressBar);
//                    ProgressBar.Value = 0;

//                }
//                #endregion
//                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
//                    print("\\Reports\\SAS\\Commen\\rpt_sas_DeliveryOrder_Summery_PolyPS.rpt", " Delivery Order Summary", "", "", glb_dtsSales, 0);
//                else
//                    print("\\Reports\\SAS\\Commen\\rpt_sas_DeliveryOrder_Summery.rpt", " Delivery Order Summary ", "", "", glb_dtsSales, 0);
//            }
//            catch (Exception ex)
//            {
//                SEACCException.Show(ex);
//            }
//            finally
//            {
//                Cursor = Cursors.Default;
//                glb_dtsSales.dt_sasDeliveryOrderSummary.Rows.Clear();
//            }
//        }
//        #endregion

//    }
//}
//#endregion

//#region Delivery detail
//else if (rdoDeliveryDetail.Checked)
//{
//    if (true)
//    {
//        MessageBox.Show("Sorry.  This report is under construction..!");
//        //to do merge with summary report
//    }
//    else
//    {
//        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_DeliveryOrderDetail)))
//        {
//            #region idealWheels
//            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
//            {
//                sFormula = " {vw_rpt_sasInvDeliveryOrder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasInvDeliveryOrder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
//                if (bCustomerSelected)
//                {
//                    sFormula += "and  {vw_rpt_sasInvDeliveryOrder.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "' ";
//                    sFilter += " User Name : " + txtCustomer.Text.Trim();
//                }
//                if (bSelesRepSelected)
//                {
//                    sFormula += "and  {vw_rpt_sasInvDeliveryOrder.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
//                    sFilter += " User Name : " + txtSalesRep.Text.Trim();
//                }
//                if (bItemSelected)
//                {
//                    sFormula += "and {vw_rpt_sasInvDeliveryOrder.item_ID} = '" + txtItemID.Tag.ToString().Trim() + "' ";
//                    sFilter += " Item Name : " + txtItemID.Text.Trim();
//                }
//                if (bJobTypeSelected)
//                {
//                    sFormula += "and {vw_rpt_sasInvDeliveryOrder.productionJobType_ID} = '" + txtJobType.Tag.ToString().Trim() + "'";
//                    sFilter += " Job Type : " + txtJobType.Text.Trim();
//                }

//                if (rdoDeleted.Checked)
//                    sFormula += " and {vw_rpt_sasInvDeliveryOrder.isDeleted} = True";
//                if (rdoActual.Checked)
//                    sFormula += " and {vw_rpt_sasInvDeliveryOrder.isDeleted} = False";
//                print("\\reports\\SAS\\Registry\\rpt_sas_DeliveryOrder_RegistryDetail_Inv.rpt", " Delivery Order Summary ", sFormula);
//            }
//            #endregion

//            else
//            {
//                sFormula = " {vw_rpt_sasDeliveryOrder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasDeliveryOrder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

//                #region Fill Do Type

//                if (cmbDOType.Text != "<All Type>")
//                {
//                    if (cmbDOType.Text.Trim() == "Kandana")
//                    {
//                        sFormula += " and ( {vw_rpt_sasDeliveryOrder.productionJobType_ID} = 'PJT/001' or {vw_rpt_sasDeliveryOrder.productionJobType_ID} = 'PJT/002')";
//                    }
//                    else if (cmbDOType.Text.Trim() == "Pettah")
//                    {
//                        sFormula += " and ( {vw_rpt_sasDeliveryOrder.productionJobType_ID} = 'PJT/003' or {vw_rpt_sasDeliveryOrder.productionJobType_ID} = 'PJT/004')";
//                    }
//                    else if (cmbDOType.Text.Trim() == "Direct")
//                    {
//                        sFormula += " and ( {vw_rpt_sasDeliveryOrder.productionJobType_ID} = 'PJT/009' or {vw_rpt_sasDeliveryOrder.productionJobType_ID} = 'PJT/010')";
//                    }
//                    else if (cmbDOType.Text.Trim() == "Block")
//                    {
//                        sFormula += " and ({vw_rpt_sasDeliveryOrder.productionJobType_ID} = 'PJT/013' or {vw_rpt_sasDeliveryOrder.productionJobType_ID} = 'PJT/014')";
//                    }
//                    else if (cmbDOType.Text.Trim() == "Chemical")
//                    {
//                        sFormula += " and ({vw_rpt_sasDeliveryOrder.productionJobType_ID} = 'PJT/011' or {vw_rpt_sasDeliveryOrder.productionJobType_ID} = 'PJT/012')";
//                    }
//                }

//                #endregion

//                if (bCustomerSelected)
//                {
//                    sFormula += "and {vw_rpt_sasDeliveryOrder.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "' ";
//                    sFilter += " User Name : " + txtCustomer.Text.Trim();
//                }
//                if (bSelesRepSelected)
//                {
//                    sFormula += "and {vw_rpt_sasDeliveryOrder.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "' ";
//                    sFilter += " User Name : " + txtSalesRep.Text.Trim();
//                }
//                if (bJobTypeSelected)
//                {
//                    sFormula += " and {vw_rpt_sasDeliveryOrder.productionJobType_ID} = '" + txtJobType.Tag.ToString().Trim() + "' ";
//                    sFilter += " Job Type : " + txtJobType.Text.Trim();
//                }
//                if (bJobTypeSelected)
//                {
//                    sFormula += "and {vw_rpt_sasDeliveryOrder.productionJobType_ID} = '" + txtJobType.Tag.ToString().Trim() + "'";
//                    sFilter += " Job Type : " + txtJobType.Text.Trim();
//                }
//                sFormula += " and {vw_rpt_sasDeliveryOrder.isDeleted} = " + false;

//                print("\\reports\\SAS\\Registry\\rpt_sas_DeliveryOrder_RegistryDetail.rpt", " Delivery Order Detail ", sFormula);
//            }
//        }
//    }
//}
#endregion

#region Sales Return
//if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_SalesReturnSummary)))
//{
//    try
//    {
//        Cursor = Cursors.WaitCursor;
//        glb_dtsSalesReturn.dt_sasSalesReturn.Rows.Clear();

//        //fill data table
//        List<tbl_sasSalesReturnedNote> oSRNs = tbl_sasSalesReturnedNote.SelectAll().Where(p => p.SalesReturnedNoteDate.Date >= dtpFrom.Value.Date && p.SalesReturnedNoteDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == clsSecurity.BranchID).ToList();
//        foreach (tbl_sasSalesReturnedNote oSRN in oSRNs)
//        {
//            bool bSalesRepOK = true, bCustomerOK = true, bActiveOK = true;
//            if (bCustomerSelected)
//            {
//                sFilter += " Customer Name : " + txtCustomer.Text.Trim();
//                bCustomerOK = txtCustomer.Tag.ToString().Trim() == oSRN.Customer_ID ? true : false;
//            }
//            if (bSelesRepSelected)
//            {
//                sFilter += " Salesman Name : " + txtSalesRep.Text.Trim();
//                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oSRN.OrderRefNo_ID);
//                if (oRef != null)
//                    bSalesRepOK = oRef.Employee_ID == txtSalesRep.Tag.ToString() ? true : false;
//            }

//            if (bSalesNoteTypeSelected)
//                if (txtSalesNoteType.Tag.ToString().Trim() != oSRN.SalesNoteType_ID)
//                    continue;

//            if (rdoDeleted.Checked && oSRN.IsDeleted == false)
//                bActiveOK = false;

//            else if (rdoActual.Checked && oSRN.IsDeleted)
//                bActiveOK = false;

//            if (chkEntryError.Checked)
//            {
//                if (!oSRN.IsEntryError)
//                    continue;
//            }
//            else
//            {
//                if (oSRN.IsEntryError)
//                    continue;
//            }

//            if (bCustomerOK && bSalesRepOK && bActiveOK)
//            {
//                decimal dTotalWeight = 0, dTotalQty = 0;
//                foreach (tbl_sasSalesReturnedNote_Detail oSRNDetail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSRN.SalesReturnedNote_ID))
//                {
//                    dTotalWeight += oSRNDetail.Weight;
//                    dTotalQty += oSRNDetail.Qty;
//                }
//                string sProductionJobID = "N/A", sDeliveryOrderID = "N/A", sJobTypeID = " N/A", sJobTypeName = " N/A";
//                tbl_sasDeliveryOrder oDO = tbl_sasDeliveryOrder.Select(oSRN.DeliveryOrder_ID);
//                if (oDO != null && oDO.DeliveryOrder_ID != "default")
//                {
//                    sProductionJobID = oDO.Job_ID;
//                    sDeliveryOrderID = oDO.DeliveryOrder_ID;

//                    tbl_pmsProductionJobRegister oJob = tbl_pmsProductionJobRegister.Select(oDO.Job_ID);
//                    if (oJob != null)
//                    {
//                        if (bJobTypeSelected)
//                        {
//                            if (oJob.Job_ID == "default")
//                            {
//                                if (txtJobType.Tag.ToString().Trim() != "PJT/009" && txtJobType.Tag.ToString().Trim() != "PJT/010")
//                                    continue;
//                            }
//                            else if (txtJobType.Tag != null && txtJobType.Tag.ToString() != "default")
//                            {
//                                if (oJob.ProductionJobType_ID != txtJobType.Tag.ToString().Trim())
//                                    continue;
//                            }
//                        }

//                        if (cmbDOType.Text != "<All Type>")
//                        {
//                            if (cmbDOType.Text.Trim() == "Kandana")
//                            {
//                                if (oJob.ProductionJobType_ID != "PJT/001" && oJob.ProductionJobType_ID != "PJT/002")
//                                    continue;
//                            }
//                            else if (cmbDOType.Text.Trim() == "Pettah")
//                            {
//                                if (oJob.ProductionJobType_ID != "PJT/003" && oJob.ProductionJobType_ID != "PJT/004")
//                                    continue;
//                            }
//                            else if (cmbDOType.Text.Trim() == "Direct")
//                            {
//                                if (oJob.ProductionJobType_ID != "PJT/009" && oJob.ProductionJobType_ID != "PJT/010")
//                                    continue;
//                            }
//                            else if (cmbDOType.Text.Trim() == "Block")
//                            {
//                                if (oJob.ProductionJobType_ID != "PJT/013" && oJob.ProductionJobType_ID != "PJT/014")
//                                    continue;
//                            }
//                            else if (cmbDOType.Text.Trim() == "Chemical")
//                            {
//                                if (oJob.ProductionJobType_ID != "PJT/011" && oJob.ProductionJobType_ID != "PJT/012")
//                                    continue;
//                            }

//                        }

//                        if (oJob.ProductionJobType_ID != "default")
//                        {

//                            sJobTypeID = oJob.ProductionJobType_ID;
//                            sJobTypeName = clsGenaralName.getName_ProductionJobTypeGroup(oJob.ProductionJobType_ID);
//                        }
//                    }
//                }

//                glb_dtsSalesReturn.dt_sasSalesReturn.Adddt_sasSalesReturnRow(oSRN.SalesReturnedNote_ID, oSRN.SalesReturnedNoteDate,
//                clsGenaralName.getName_Customer(oSRN.Customer_ID), oSRN.OrderRefNo_ID, oSRN.GrandTotal, dTotalWeight,
//                dTotalQty, oSRN.IsReturnable, oSRN.IsRefundable, oSRN.IsExcess, sProductionJobID, sDeliveryOrderID,
//                oSRN.Invoice_ID, oSRN.Remark, oSRN.IsWeightCalculation, 0, 0, 0, oSRN.IsDeleted, chkIsGroupbyProducionJob.Checked ? sJobTypeID : "", chkIsGroupbyProducionJob.Checked ? sJobTypeName : "", clsGenaralName.getName_SalesNoteType(oSRN.SalesNoteType_ID), "", 0, 0, "");
//            }
//            clsHelpMethods.startProgressBar(0, oSRNs.Count + 2, 1, ProgressBar);
//        }
//        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
//            print("\\Reports\\SAS\\Registry\\rpt_sas_Register_SalesReturn_Summery_AKT.rpt", "Sales Returned Summary ", glb_dtsSalesReturn.dt_sasSalesReturn);
//        else
//            print("\\Reports\\SAS\\Registry\\rpt_sas_Register_SalesReturn_Summery.rpt", "Sales Returned Summary ", glb_dtsSalesReturn.dt_sasSalesReturn);
//    }
//    catch (Exception ex)
//    {
//        SEACCException.Show(ex);
//    }
//    finally
//    {
//        ProgressBar.Value = 0;
//        Cursor = Cursors.Default;
//        glb_dtsSalesReturn.dt_sasSalesReturn.Rows.Clear();
//    }
//}
#endregion

#region Inquiry Detail
//else if (rdoPendingInquiryOrderDetail.Checked)
//{
//    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_InquiryDetail)))
//    {
//        sFormula = " {vw_rpt_sasInquiry.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasInquiry.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
//        if (bCustomerSelected)
//        {
//            sFormula += "and {vw_rpt_sasInquiry.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "' ";
//            sFilter += " User Name : " + txtCustomer.Text.Trim();
//        }
//        if (bSelesRepSelected)
//        {
//            sFormula += "and {vw_rpt_sasInquiry.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "' ";
//            sFilter += " User Name : " + txtSalesRep.Text.Trim();
//        }
//        if (bItemSelected)
//        {
//            sFormula += "and {vw_rpt_sasInquiry_Detail.item_ID} = '" + txtItemID.Tag.ToString().Trim() + "' ";
//            sFilter += " Item Name : " + txtItemID.Text.Trim();
//        }

//        if (rdoDeleted.Checked)
//            sFormula += " and {vw_rpt_sasInquiry.isDeleted} = True";
//        if (rdoActual.Checked)
//            sFormula += " and {vw_rpt_sasInquiry.isDeleted} = False";

//        //sFormula += "and {vw_rpt_sasInquiry.isDeleted} = " + false;

//        iReportNo = (int)enum_ReportName.RG_InquiryDetail;
//        print("\\reports\\SAS\\Registry\\rpt_sas_Inquiry_Registry_Detail.rpt", " Inquiry Details ", sFormula);
//    }
//}
#endregion

#region Customer Order
#region Old Report
//if (!clsConfig.bDataSetActive_CustomerOrder)
//{
//    if (false)
//    {
//        sFormula = " {vw_rpt_sasCustomerOrder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasCustomerOrder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
//        if (bCustomerSelected)
//        {
//            sFormula += "and {vw_rpt_sasCustomerOrder.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "' ";
//            sFilter += " User Name : " + txtCustomer.Text.Trim();
//        }

//        if (bSelesRepSelected)
//        {
//            sFormula += "and {vw_rpt_sasCustomerOrder.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
//            sFilter += " User Name : " + txtSalesRep.Text.Trim();
//        }
//        if (bItemSelected)
//        {
//            sFormula += "and {vw_rpt_sasCustomerOrder_Detail.item_ID} = '" + txtItemID.Tag.ToString().Trim() + "' ";
//            sFilter += " Item Name : " + txtItemID.Text.Trim();
//        }

//        sFormula += "and {vw_rpt_sasCustomerOrder.isDeleted} = " + false;
//        print("\\reports\\SAS\\Registry\\rpt_sas_CustomerOrder_Registry_Detail.rpt", " Customer Order Detail ", sFormula);
//    }
//    else
//        MessageBox.Show("Sorry.  This report is under construction..!");
//}
#endregion
//if (!clsConfig.bDataSetActive_CustomerOrder)
//{
//    if (false)
//    {
//        sFormula = " {vw_rpt_sasCustomerOrder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasCustomerOrder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "' ";
//        if (bCustomerSelected)
//            sFormula += "and {vw_rpt_sasCustomerOrder.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "' ";
//        sFilter += " User Name : " + txtCustomer.Text.Trim();
//        if (bSelesRepSelected)
//            sFormula += "and {vw_rpt_sasCustomerOrder.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
//        sFilter += " User Name : " + txtSalesRep.Text.Trim();

//        if (rdoDeleted.Checked)
//            sFormula += " and {vw_rpt_sasCustomerOrder.isDeleted} = True";
//        if (rdoActual.Checked)
//            sFormula += " and {vw_rpt_sasCustomerOrder.isDeleted} = False";

//        print("\\reports\\SAS\\Commen\\rpt_sas_CustomerOrder_Summery.rpt", " Customer Order Summary ", sFormula);
//    }
//    else
//        MessageBox.Show("Sorry.  This report is under construction..!");
//}
#endregion

#region Quotation Summery&Detail Old
//sFormula = " {vw_rpt_sasQuotation.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasQuotation.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

//if (bCustomerSelected)
//{
//    sFormula += " and {vw_rpt_sasQuotation.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "' ";
//    sFilter += " User Name : " + txtCustomer.Text.Trim();
//}
//if (bSelesRepSelected)
//{
//    sFormula += " and {vw_rpt_sasQuotation.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "' ";
//    sFilter += " User Name : " + txtSalesRep.Text.Trim();
//}

//if (rdoDeleted.Checked)
//    sFormula += " and {vw_rpt_sasQuotation.isDeleted} = True";
//if (rdoActual.Checked)
//    sFormula += " and {vw_rpt_sasQuotation.isDeleted} = False";

//iReportNo = (int)enum_ReportName.RG_QuotationSummary;
//print("\\reports\\SAS\\Commen\\rpt_sas_Quatation_Summery.rpt", " Quotation Summary ", sFormula);
#endregion

#region Quatation details
//else
//if (rdbQuataionDetails.Checked)
//{
//    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_QuotationDetails)))
//    {

//        sFormula = " {vw_rpt_sasQuotation.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasQuotation.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
//        if (bCustomerSelected)
//        {
//            sFormula += " and {vw_rpt_sasQuotation.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "' ";
//            sFilter += " User Name : " + txtCustomer.Text.Trim();
//        }
//        if (bSelesRepSelected)
//        {
//            sFormula += " and {vw_rpt_sasQuotation.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "' ";
//            sFilter += " User Name : " + txtSalesRep.Text.Trim();
//        }
//        if (bItemSelected)
//        {
//            sFormula += "and {vw_rpt_sasQuotation_Detail.item_ID} = '" + txtItemID.Tag.ToString().Trim() + "' ";
//            sFilter += " Item Name : " + txtItemID.Text.Trim();
//        }

//        if (rdoDeleted.Checked)
//            sFormula += " and {vw_rpt_sasQuotation.isDeleted} = True";
//        if (rdoActual.Checked)
//            sFormula += " and {vw_rpt_sasQuotation.isDeleted} = False";
//        //sFormula += " and {vw_rpt_sasQuotation.isDeleted} = " + false;

//        //print("\\reports\\SAS\\Registry\\rpt_sas_Quotation_Registry_Detail-Copy.rpt", " Quotation Detail ", sFormula);
//        iReportNo = (int)enum_ReportName.RG_QuotationDetails;
//        print("\\reports\\SAS\\Registry\\rpt_sas_Quotation_Registry_Detail.rpt", " Quotation Detail ", sFormula);
//    }
//}
#endregion

#region Old Reports(Views)
//if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_PerformaInvoiceSummary)))
//{


//    sFormula = " {vw_rpt_sasProformaInvoice.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasProformaInvoice.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
//    if (bCustomerSelected)
//    {
//        sFormula += " and {vw_rpt_sasProformaInvoice.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "' ";
//        sFilter += " User Name : " + txtCustomer.Text.Trim();
//    }
//    if (bSelesRepSelected)
//    {
//        sFormula += " and {vw_rpt_sasProformaInvoice.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "' ";
//        sFilter += " User Name : " + txtSalesRep.Text.Trim();
//    }

//    if (rdoDeleted.Checked)
//        sFormula += " and {vw_rpt_sasProformaInvoice.isDeleted} = True";
//    if (rdoActual.Checked)
//        sFormula += " and {vw_rpt_sasProformaInvoice.isDeleted} = False";

//    iReportNo = (int)enum_ReportName.RG_PerformaInvoiceSummary;
//    print("\\reports\\SAS\\Commen\\rpt_sas_Proform_Summery.rpt", " Proforma Invoice Summary ", sFormula);

//}
#endregion

#region Proforma Details(Old Report)
//else if (rdbProformDet.Checked)
//{
//    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_PerformaInvoiceDetails)))
//    {
//        sFormula = " {vw_rpt_sasProformaInvoice.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasProformaInvoice.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

//        if (bCustomerSelected)
//        {
//            sFormula += " and {vw_rpt_sasProformaInvoice.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "' ";
//            sFilter += " User Name : " + txtCustomer.Text.Trim();
//        }
//        if (bSelesRepSelected)
//        {
//            sFormula += " and {vw_rpt_sasProformaInvoice.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "' ";
//            sFilter += " User Name : " + txtSalesRep.Text.Trim();
//        }
//        if (bItemSelected)
//        {
//            sFormula += "and {vw_rpt_sasProformaInvoice_Detail.item_ID} = '" + txtItemID.Tag.ToString().Trim() + "' ";
//            sFilter += " Item Name : " + txtItemID.Text.Trim();
//        }

//        if (rdoDeleted.Checked)
//            sFormula += " and {vw_rpt_sasProformaInvoice.isDeleted} = True";
//        if (rdoActual.Checked)
//            sFormula += " and {vw_rpt_sasProformaInvoice.isDeleted} = False";

//        //sFormula += "and {vw_rpt_sasProformaInvoice.isDeleted} = " + false;

//        iReportNo = (int)enum_ReportName.RG_PerformaInvoiceDetails;
//        print("\\reports\\SAS\\Registry\\rpt_sas_Proformance_Registry_Detail.rpt", " Proforma Invoice Detail ", sFormula);
//    }
//}
#endregion

#region Old Inquiry Summery(View)
//if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_InquirySummary)))
//{
//    sFormula = " {vw_rpt_sasInquiry.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasInquiry.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
//    if (bCustomerSelected)
//        sFormula += "and {vw_rpt_sasInquiry.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "' ";
//    sFilter += " User Name : " + txtCustomer.Text.Trim();
//    if (bSelesRepSelected)
//        sFormula += "and {vw_rpt_sasInquiry.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "' ";
//    sFilter += " User Name : " + txtSalesRep.Text.Trim();

//    if (rdoDeleted.Checked)
//        sFormula += " and {vw_rpt_sasInquiry.isDeleted} = True";
//    if (rdoActual.Checked)
//        sFormula += " and {vw_rpt_sasInquiry.isDeleted} = False";

//    iReportNo = (int)enum_ReportName.RG_InquirySummary;
//    print("\\reports\\SAS\\Commen\\rpt_sas_Inquiry_Summery.rpt", " Inquiry Summary ", sFormula);

//}
#endregion

#region Print Method

#endregion

#region Print Selectection
//private void PrintAll()
//{

//}

//private void PrintCustomerBank()
//{
//    //string selectformula = " and {vwChequeRegister.cust_cod} = '" + txtCustomer.Tag.ToString() + "' and {vwChequeRegister.bank_cod} = '" + txtBank.Tag.ToString() + "'";
//    //string title = "Customer: " + txtCustomer.Text + "       Bank Name: " + txtBank.Text;
//    //if (rdoChequeToBeDeposited.Checked || rdoRegisteredQuotation.Checked)
//    //    print("\\reports\\rptChequeToBeDeposited_CustomerBank.rpt", selectformula, title);
//    //else if (rdoProformaInvoice.Checked)
//    //    print("\\reports\\rptChequeReturned _All.rpt", selectformula, title);            
//}
//private void PrintBankBranch()
//{
//    //string selectformula = " and {vwChequeRegister.bank_cod} = '" + txtBank.Tag.ToString() + "' and {vwChequeRegister.brnch_nam} = '" + cmbBranch.Text.Trim() + "'";
//    //string title = "Bank Name: " + txtBank.Text + "     Branch Name: " + cmbBranch.Text;
//    //if (rdoChequeToBeDeposited.Checked || rdoAll.Checked)
//    //    print("\\reports\\rptChequeToBeDeposited_BankBranch.rpt", selectformula, title);    
//    //else if (rdoChequeReturned.Checked)
//    //    print("\\reports\\rptChequeReturned _All.rpt", selectformula, title);                
//}
//private void PrintBank()
//{
//    //string selectformula = " and {vwChequeRegister.bank_cod} = '" + txtBank.Tag.ToString() + "'";
//    //string title = "Bank Name: " + txtBank.Text;
//    //if (rdoChequeToBeDeposited.Checked || rdoRegisteredQuotation.Checked)
//    //    print("\\reports\\rptChequeToBeDeposited_Bank.rpt", selectformula, title);             
//    //else if (rdoProformaInvoice.Checked)
//    //    print("\\reports\\rptChequeReturned _All.rpt", selectformula, title);             
//}
//private void PrintCustomer()
//{
//    //string selectformula = " and {vwChequeRegister.cust_cod} = '" + txtCustomer.Tag.ToString() + "'";
//    //string title = "Customer: " + txtCustomer.Text;
//    //if (rdoChequeToBeDeposited.Checked || rdoRegisteredQuotation.Checked)
//    //    print("\\reports\\rptChequeToBeDeposited_Customer.rpt", selectformula, title);             
//    //else if (rdoProformaInvoice.Checked)
//    //    print("\\reports\\rptChequeReturned _Customer.rpt", selectformula, title);                
//}
#endregion