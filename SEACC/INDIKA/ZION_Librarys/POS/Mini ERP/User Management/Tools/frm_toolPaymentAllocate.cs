using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; 
using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;
using Digiteq.DataSets.SAS;
using CrystalDecisions.CrystalReports.Engine;
using Digiteq.DataSets;


namespace Digiteq
{
    public partial class frm_toolPaymentAllocate : Form
    {
       public int iFormID;
        public static string sAllocateCode = "";
        public static bool bAdvancePayment = false;
        public static bool bPartPayment = false;
        public static bool bOverPayment = false;
        public static bool bActiveAlocationDate = false;
        public static DateTime dtAllocationdate = clsSecurity.getServerDateTime();
        public static bool bAllocationStart = false;

        //Data Set
        dts_sasReceiptAllocation glb_dts_sasReceiptAllocation = new dts_sasReceiptAllocation();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        public frm_toolPaymentAllocate()
        {
            InitializeComponent();
        }

        #region Form Load
        private void frmQuickLogin_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "", 2, iFormID);
            ClearFields();
        }
        #endregion

        #region Btn Login
        private void btnAllocate_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                sAllocateCode = txtAllocationCode.Text;
                bActiveAlocationDate = chkActiveAllocationDate.Checked;
                dtAllocationdate = dtpAllocationDate.Value;
                bAdvancePayment = (rdoAdvancePayment.Checked) ? true : false;
                if (rdoAdvancePayment.Checked)
                    bAdvancePayment = true;
                else if (rdoPartPayment.Checked)
                    bPartPayment = true;
                else if (rdoOverPayment.Checked)
                    bOverPayment = true;
                bAllocationStart = true;                
                this.Close();
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

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
            this.Close();
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            txtAllocationCode.Clear();
            rdoAdvancePayment.Checked = false;
            rdoPartPayment.Checked = false;
            rdoOverPayment.Checked = false;
            chkActiveAllocationDate.Checked = false;
            dtpAllocationDate.Value = clsSecurity.getServerDateTime();

            sAllocateCode = "";
            bAdvancePayment = false;
            bPartPayment = false;
            bOverPayment = false;
            bActiveAlocationDate = false;
            dtAllocationdate = clsSecurity.getServerDateTime();
            bAllocationStart = false;
        }
        #endregion

        private void chkActiveAllocationDate_CheckedChanged(object sender, EventArgs e)
        {
            bActiveAlocationDate = true;
            dtpAllocationDate.Enabled = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (rdoAdvancePayment.Checked || rdoOverPayment.Checked || rdoPartPayment.Checked)
            {

                try
                {
                    Cursor = Cursors.WaitCursor;
                    glb_dts_sasReceiptAllocation.dt_sasSalesReceiptHeader.Rows.Clear();
                    glb_dts_sasReceiptAllocation.dt_sasSalesInvoiceSettled.Rows.Clear();
                    string sCustomerName = string.Empty, sAddressRegister = string.Empty, sSalesRep = string.Empty, sTelephone = string.Empty, sFax = string.Empty, sEmployee_ID = string.Empty, sCurrencyCode = string.Empty;
                  //  string sReciptID = frm_bpsReceipt_Sales.sReciptID;
                    bool bIsSettledOk = false;
                 //   tbl_bpsReceipt receipt = tbl_bpsReceipt.Select(sReciptID);
                 //   tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(receipt.Customer_ID.Trim());
                    //if (oCustomer != null)
                    //{
                    //    sCustomerName = oCustomer.CustomerName;
                    //    sAddressRegister = oCustomer.AddressRegister;
                    //    sTelephone = oCustomer.Telephone;
                    //    sFax = oCustomer.Fax;
                    //    sSalesRep = clsGenaralName.getName_SalesRep(oCustomer.SalesRep_ID);
                    //}


                    //tbl_zOrderRefNo oOrderRefNo = tbl_zOrderRefNo.Select(receipt.OrderRefNo_ID);
                    //if (oOrderRefNo != null)
                    //    sEmployee_ID = oOrderRefNo.Employee_ID;

                  //  tbl_zCurrency oCurrency = tbl_zCurrency.Select(receipt.Currency_ID);
                  //  if (oCurrency != null)
                 //       sCurrencyCode = oCurrency.CurrencyCode;

                    string sAlloID = "";//sInvoiceID = "",
                 // decimal dReceiptTotal = receipt.TotalAmount;
                    decimal dReceiptTotal = 0;
                    List<tbl_sasInvoice_Sattled> oSettlements = new List<tbl_sasInvoice_Sattled>();
                    //foreach (tbl_sasInvoice_Sattled oAllocation in tbl_sasInvoice_Sattled.SelectAllByReceipt_ID(receipt.Receipt_ID))
                    //{
                    //    #region Report Filters
                    //    if (txtAllocationCode.TextLength > 0)
                    //    {
                    //        if (oAllocation.AllocationID != txtAllocationCode.Text.Trim())
                    //            continue;
                    //    }
                    //    if (rdoAdvancePayment.Checked)
                    //    {
                    //        if (!oAllocation.IsAdvancePayment)
                    //            continue;
                    //    }
                    //    if (rdoOverPayment.Checked)
                    //    {
                    //        if (!oAllocation.IsOverPayment)
                    //            continue;
                    //    }
                    //    if (rdoPartPayment.Checked)
                    //    {
                    //        if (oAllocation.IsAdvancePayment || oAllocation.IsOverPayment)
                    //            continue;
                    //    } 
                    //    #endregion
                        
                    //    #region Add Allocation Details
                    //    string sChequRegisterID = string.Empty;
                    //    DateTime dtmInoiceDate = clsSecurity.getServerDateTime();

                    //    tbl_bpsChequeRegister oChqRegister = tbl_bpsChequeRegister.Select(oAllocation.ChequeRegister_ID);
                    //    if (oChqRegister != null)
                    //        sChequRegisterID = oChqRegister.ChequeNumber;

                    //    tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oAllocation.Invoice_ID);
                    //    if (oInvoice != null)
                    //        dtmInoiceDate = oInvoice.InvoiceDate;

                    //    //glb_dts_sasReceiptAllocation.dt_sasSalesInvoiceSettled.Adddt_sasSalesInvoiceSettledRow(oAllocation.Settled_ID, oAllocation.Invoice_ID, receipt.Receipt_ID,
                    //    //    oAllocation.ChequeRegister_ID, oAllocation.CreditNote_ID, oAllocation.AllocationDate, oAllocation.SattledAmount, oAllocation.IsDebit, sChequRegisterID,
                    //    //      dtmInoiceDate, oAllocation.IsAdvancePayment, oAllocation.IsOverPayment,oAllocation.AllocationID);

                    //    dReceiptTotal += oAllocation.SattledAmount;
                    //    bIsSettledOk = true; 
                    //    #endregion
                    //}

                    #region Set Report Title & Total Amount
                    string sReportTital = "";                   
                    if (rdoPartPayment.Checked)
                    {
                        sReportTital = "Recipt";
                        //decimal dOtherAllocationTotal = 0;
                        //foreach (tbl_sasInvoice_Sattled item in tbl_sasInvoice_Sattled.SelectAllByReceipt_ID(receipt.Receipt_ID).Where(p => !p.IsAdvancePayment && !p.IsOverPayment))
                        //    dOtherAllocationTotal += item.SattledAmount;
                        //dReceiptTotal -= dOtherAllocationTotal;
                    }
                    else if (rdoOverPayment.Checked)
                    {
                        sReportTital = "OverPayment Allocation";
                        //decimal dOtherAllocationTotal = 0;
                        //foreach (tbl_sasInvoice_Sattled item in tbl_sasInvoice_Sattled.SelectAllByReceipt_ID(receipt.Receipt_ID).Where(p => p.IsOverPayment))
                        //    dOtherAllocationTotal += item.SattledAmount;
                        //dReceiptTotal -= dOtherAllocationTotal;
                    }
                    else if (rdoAdvancePayment.Checked)
                    {
                        sReportTital = "Allocation of Advanced";
                        //decimal dOtherAllocationTotal = 0;
                        //foreach (tbl_sasInvoice_Sattled item in tbl_sasInvoice_Sattled.SelectAllByReceipt_ID(receipt.Receipt_ID).Where(p => p.IsAdvancePayment))
                        //    dOtherAllocationTotal += item.SattledAmount;
                        //dReceiptTotal -= dOtherAllocationTotal;
                    }
                    #endregion

                    #region Add Report Header Details
                    //glb_dts_sasReceiptAllocation.dt_sasSalesReceiptHeader.Adddt_sasSalesReceiptHeaderRow(receipt.Receipt_ID, receipt.ReceiptDate, receipt.Remark, sCustomerName,
                    //    sAddressRegister, sSalesRep, receipt.CashAmount, receipt.ChequeAmount, 0,0, dReceiptTotal, sTelephone, sFax, oCustomer.Customer_ID, sEmployee_ID, receipt.InvoiceList,
                    //    receipt.DateCreate, receipt.CurrencyRate, sCurrencyCode, receipt.IsDeleted, receipt.IsSalesReceipt, receipt.IsAdvance);                    
                    #endregion

                    #region Set Report Path
                    string s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                    string sGetRptPath = clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_SalesReceipt));
                    if (sGetRptPath != null && sGetRptPath.Length > 0 && sGetRptPath != "hitech")
                    {
                        s_Path += sGetRptPath;
                    } 
                    #endregion

                    #region Print
                    if (bIsSettledOk)
                    //    print(glb_dts_sasReceiptAllocation, s_Path, sAlloID, sReciptID, sReportTital, "", clsAutocode.getReportID(enum_ReportName.NP_SalesReceipt));
                   // else
                        MessageBox.Show("No Allocation Available", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);

                    #endregion
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
                finally
                {

                    Cursor = Cursors.Default;
                    glb_dts_sasReceiptAllocation.dt_sasSalesReceiptHeader.Rows.Clear();
                    glb_dts_sasReceiptAllocation.dt_sasSalesInvoiceSettled.Rows.Clear();

                }

            }
        }

        private void txtAllocationCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                this.Search_Settelment();
            }

        }

        private void txtAllocationCode_DoubleClick(object sender, EventArgs e)
        {
            Search_Settelment();
        }

        #region Search Settelment
        private void Search_Settelment()
        {
            try
            {
                clsSearch.Search_Settelment(ref txtAllocationCode);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }

        }
        #endregion

        #region Print Methord
        public void print(DataSet dtDataSet, string s_Path, string sAllocationID, string sRecieptID, string sReportTitle, string sDuplicateCopy, string sReportID)
        {            
            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sReportTitle, true, false);
            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicateCopy, true, false);
            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true, false);
            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true, false);
            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true, false);
            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true, false);
            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqEmail", clsCommon.getCompanyEmail(), true, false);
            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DateRange", clsSecurity.getServerDateTime().ToShortDateString(), true, false);
            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("UserName", clsSecurity.UserNameLoged, true, false);            

            if (rdoAdvancePayment.Checked || rdoOverPayment.Checked)
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("AllocationCode", clsCommon.fncsetstring(sAllocationID), true, false);

            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
            {
                foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(sRecieptID).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default"))
                {
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ChequeNo", clsCommon.fncsetstring(oCheque.ChequeNumber), true, false);
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ChequeDate", clsCommon.fncsetstring(clsFormatter.FormatDate_Short(oCheque.DateCheque)), true, false);
                }
            }
            string sinvoiceno = "";
            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ceilingAndWallPanal.ToString())
            {
                var oinvoice = tbl_sasInvoice_Sattled.SelectAllByReceipt_ID(sRecieptID).GroupBy(cm => new { cm.Invoice_ID }, (key, group) => new { Invoice_ID = key.Invoice_ID });
                foreach (var oinv in oinvoice)
                {
                    sinvoiceno += oinv.Invoice_ID + " , ";
                }

                if (sinvoiceno.Length > 0)
                    sinvoiceno = sinvoiceno.Substring(0, sinvoiceno.Length - 3);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("InvoiceId", clsCommon.fncsetstring(sinvoiceno), true, false);
            }

            frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
            ReportViewer.print(s_Path, dtDataSet, glb_dtsReportExport.dt_rptParameter, sReportID);

        }
        #endregion


    }
}