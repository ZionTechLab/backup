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
using System.IO;
using System.Collections;
using System.Reflection;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Digiteq.DataSets.SAS;
using Digiteq.DataSets;
using System.Data.SqlClient;


using Microsoft.Win32;
using System.Security.Cryptography;
using System.Windows.Forms.DataVisualization.Charting;


namespace Digiteq
{
    public partial class frm_dashBord : Form
    {
        #region Drag Title bar
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        #region variables
        decimal creditAmount = 0, dNbtTotal = 0, dVatTotal = 0, dSVatTotal = 0, dSRNFIFOCost = 0;
        decimal DebitAmount = 0, dDebitNbtTotal = 0, dDebitVatTotal = 0, dDebitSVatTotal = 0;
        dts_Stock glb_dtsSales = new dts_Stock();
        dtsBills glbDtsBills = new dtsBills();
        dts_Stock glbDtsStock = new dts_Stock();
        //form manage
        public int iFormID;

        //for security handle
        public bool bNoAccess;
        #endregion

        #region Form Load
        public frm_dashBord()
        {
            iFormID = clsSecurity.getFormID(FormName.MISReports);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();

            if (clsCommon.getCompanyImage() != null)
                pbxImage.Image = Image.FromStream(new MemoryStream(clsCommon.getCompanyImage()));

            ClearFields();

        }


        private void frm_dashBord_Load(object sender, EventArgs e)
        {
            btn_Refresh_Click(null, null);

            //lblCOCount.Text = GetCountCO().ToString();
            //lblCOAmount.Text = clsFormatter.FormatDecimalPlaces_Price(GetAmountCO()).ToString();
            //lblDOCount.Text = GetCountDO().ToString();
            //lblDOAmount.Text = clsFormatter.FormatDecimalPlaces_Price(GetAmountDO()).ToString();
            //lblInvCount.Text = GetCountInvoice().ToString();
            //lblInvAmount.Text = clsFormatter.FormatDecimalPlaces_Price(GetAmountInvoice()).ToString();
            //lblRecpCount.Text = GetCountReceipt().ToString();
            //lblRecpAmount.Text = clsFormatter.FormatDecimalPlaces_Price(GetAmountReceipt()).ToString();
            //lblSRNCount.Text = GetCountSRN().ToString();
            //lblSRNAmount.Text = clsFormatter.FormatDecimalPlaces_Price(GetAmountSRN()).ToString();

            //lblPOCount.Text = GetCountPO().ToString();
            //lblPOAmount.Text = clsFormatter.FormatDecimalPlaces_Price(GetAmountPO()).ToString();
            //lblGRNCount.Text = GetCountGRN().ToString();
            //lblGRNAmount.Text = clsFormatter.FormatDecimalPlaces_Price(GetAmountGRN()).ToString();
            //lblPRNCount.Text = GetCountPRN().ToString();
            //lblPRNAmount.Text = clsFormatter.FormatDecimalPlaces_Price(GetAmountPRN()).ToString();
            //lblGINCount.Text = GetCountGIN().ToString();
            //lblGINAmount.Text = clsFormatter.FormatDecimalPlaces_Price(GetAmountGIN()).ToString();
            //lblDGNCount.Text = GetCountDGN().ToString();
            //lblDGNAmount.Text = clsFormatter.FormatDecimalPlaces_Price(GetAmountDGN()).ToString();
            //FillDetails();
            //MessageBox.Show("");

        }
        #endregion

        private void ClearFields()
        {
            dtpFrom.Value = clsSecurity.getServerDateTime();
            dtpTo.Value = clsSecurity.getServerDateTime();

            #region default values
            //lblCOCount.Text = "0";
            //lblCOQty.Text = "0";
            //lblAmntCO.Text = "0.00";
            //lblDOCount.Text = "0";
            //lblDOQty.Text = "0";
            //lblAmntDO.Text = "0.00";
            //lblInvCount.Text = "0";
            //lblInvQty.Text = "0";
            //lblAmntINV.Text = "0.00";
            //lblRecpCount.Text = "0";
            //lblRecpQty.Text = "0";
            //lblAmntRcp.Text = "0.00";
            //lblSRNCount.Text = "0";
            //lblSRNQty.Text = "0";
            //lblAmntSRN.Text = "0.00";

            //lblPOCount.Text = "0";
            //lblPOQty.Text = "0";
            //lblAmntPO.Text = "0.00";
            //lblGRNCount.Text = "0";
            //lblGRNQty.Text = "0";
            //lblAmntGRN.Text = "0.00";
            //lblPRNCount.Text = "0";
            //lblPRNQty.Text = "0";
            //lblAmntPRN.Text = "0.00";
            //lblGINCount.Text = "0";
            //lblGINQty.Text = "0";
            //lblAmntGIN.Text = "0.00";
            //lblDGNCount.Text = "0";
            //lblDGNQty.Text = "0";
            //lblAmntDGN.Text = "0.00";
            //lblADJCount.Text = "0";
            //lblADJQty.Text = "0";
            //lblAmntADJ.Text = "0.00";
            #endregion

            progressBar1.Visible = false;
            txtStore.Visible = false;
            txtItemName.Visible = false;
            txtItemCategory.Visible = false;

            lblAmntDO.Visible = false;
            lblRecQty.Visible = false;
            //lblRecQty.Visible = true;
            lblAmntADJ.Visible = false;
            lblAmntDGN.Visible = false;


        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UpdateNewCustomersList();
            UpdateCancledCashReciepts();
            DailyStatus();
            GetCountCO();
            GetCountDO();
            GetCountInvoice();
            GetCountReceipt();
            GetCountSRN();

            GetCountPO();
            GetCountGRN();
            GetCountPRN();
            GetCountGIN();
            GetCountDGN();
            GetCountADJ();

            Cursor = Cursors.Default;
            //createDailyColectionChart();
            //createDailyColectionChart_New();
        }

        #region Update New Customers
        private void UpdateNewCustomersList()
        {
            DataTable dt_tbl_audBackupLogList = new DataTable();
            SqlConnection scon = DBHandling.GetConnection();
            DateTime dFrom = dtpFrom.Value.Date;
            DateTime dTo = dtpTo.Value.Date;

            //SqlCommand scom = new SqlCommand("SELECT customerName as Customer, dateCreate as CreatedDate FROM tbl_genCustomerMaster WHERE(dateCreate BETWEEN '" + dFrom + "' AND '" + dTo + "')", scon);
            SqlCommand scom = new SqlCommand("SELECT customerName as Customer, cast(dateCreate as date) as CreatedDate FROM tbl_genCustomerMaster WHERE(dateCreate BETWEEN '" + dFrom + "' AND '" + dTo + "')", scon);
            scom.CommandType = CommandType.Text;
            scon.Open();

            SqlDataAdapter da = new SqlDataAdapter(scom);
            da.Fill(dt_tbl_audBackupLogList);

            da.Dispose();
            scon.Close();

            dgvNewCustomers.DataSource = dt_tbl_audBackupLogList;
        }
        #endregion

        #region Update Canceld Cash Receipts
        private void UpdateCancledCashReciepts()
        {
            DateTime dFrom = dtpFrom.Value.Date;
            DateTime dTo = dtpTo.Value.Date;

            int iCount = 0;
            decimal iAmount = 0;
            foreach (tbl_bpsReceipt detail in tbl_bpsReceipt.SelectAll().Where(p => p.Receipt_ID != "default" && p.CashAmount > 0 && p.IsDeleted && p.ReceiptDate.Date >= dFrom && p.ReceiptDate.Date <= dTo))
            {
                ++iCount;
                iAmount = iAmount + detail.CashAmount;
            }

            lblCancRecieptCount.Text = iCount.ToString();
            lblCancRecieptAmount.Text = iAmount > 0 ? clsFormatter.FormatDecimalPlaces_Price(iAmount) : "";
        }
        #endregion

        #region btn Close
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Daily Status
        private void DailyStatus()
        {
            #region Old
            ////Sales Details
            //DateTime dtNow = clsSecurity.getServerDateTime();
            //DateTime dFrom = dtpFrom.Value.Date;
            //DateTime dTo = dtpTo.Value.Date;

            //decimal dNetSales_ForTheDay = 0, dNetSales_ForTheMonth = 0, dDebitValue_ForTheDay = 0, dDebitValue_ForTheMonth = 0, dCreditNote_Value_ForTheMonth = 0, dCreditNote_Value_ForTheDay = 0;
            //clsMethods_Fin.assingValues_NetSalesAndDebitValue_UptoDate(ref dNetSales_ForTheDay, ref dNetSales_ForTheMonth, ref dDebitValue_ForTheDay, ref dDebitValue_ForTheMonth, dFrom, dTo, clsSecurity.BranchID);
            //clsMethods_Fin.assingValues_CreditNote_WithoutTaxes(ref dCreditNote_Value_ForTheMonth, ref dCreditNote_Value_ForTheDay, dtNow, "");
            ////clsMethods_Fin.assingValues_NetSalesAndDebitValue(ref dNetSales_ForTheDay, ref dNetSales_ForTheMonth, ref dDebitValue_ForTheDay, ref dDebitValue_ForTheMonth, dtNow, sBranch_ID);

            ////lblNetSalesTd.Text = clsFormatter.FormatDecimalPlaces_Price(dNetSales_ForTheDay);
            ////lblDebitNtTd.Text = clsFormatter.FormatDecimalPlaces_Price(dDebitValue_ForTheDay);
            ////lblCreditNtTd.Text = clsFormatter.FormatDecimalPlaces_Price(dCreditNote_Value_ForTheDay);

            //lblNetSalesMn.Text = clsFormatter.FormatDecimalPlaces_Price(dNetSales_ForTheMonth);
            ////lblDebitNtMn.Text = clsFormatter.FormatDecimalPlaces_Price(dDebitValue_ForTheMonth);
            ////lblCreditNtMn.Text = clsFormatter.FormatDecimalPlaces_Price(dCreditNote_Value_ForTheMonth);

            //decimal dSales_ForTheDay = (dNetSales_ForTheDay + dDebitValue_ForTheDay) - dCreditNote_Value_ForTheDay;
            //decimal dSales_ForTheMonth = (dNetSales_ForTheMonth + dDebitValue_ForTheMonth) - dCreditNote_Value_ForTheMonth;
            ////lblTotSalesTd.Text = clsFormatter.FormatDecimalPlaces_Price(dSales_ForTheDay);
            ////lblTotSalesMn.Text = clsFormatter.FormatDecimalPlaces_Price(dSales_ForTheMonth);

            ////Collection Detail
            //decimal dReceipt_Cash_ForTheDay = 0, dReceipt_Cash_ForTheMonth = 0, dReceipt_Cheque_ForTheDay = 0, dReceipt_Cheque_ForTheMonth = 0;
            //clsMethods_Fin.assingValues_Collection_ForDateRange(ref dReceipt_Cash_ForTheDay, ref dReceipt_Cash_ForTheMonth, ref dReceipt_Cheque_ForTheDay, ref dReceipt_Cheque_ForTheMonth, dFrom, dTo, clsSecurity.BranchID);
            //decimal dCollection_ForTheDay = dReceipt_Cash_ForTheDay + dReceipt_Cheque_ForTheDay;
            //decimal dCollection_ForTheMonth = dReceipt_Cash_ForTheMonth + dReceipt_Cheque_ForTheMonth;

            ////lblCashColTd.Text = clsFormatter.FormatDecimalPlaces_Price(dReceipt_Cash_ForTheDay);
            ////lblChqCloTd.Text = clsFormatter.FormatDecimalPlaces_Price(dReceipt_Cheque_ForTheDay);
            ////lblCashColMn.Text = clsFormatter.FormatDecimalPlaces_Price(dReceipt_Cash_ForTheMonth);
            //lblCashCollection.Text = clsFormatter.FormatDecimalPlaces_Price(dReceipt_Cash_ForTheMonth);
            ////lblChqCloMn.Text = clsFormatter.FormatDecimalPlaces_Price(dReceipt_Cheque_ForTheMonth);
            //lblChequeCollection.Text = clsFormatter.FormatDecimalPlaces_Price(dReceipt_Cheque_ForTheMonth);
            ////lblTotColTd.Text = clsFormatter.FormatDecimalPlaces_Price(dCollection_ForTheDay);
            ////lblTotColMn.Text = clsFormatter.FormatDecimalPlaces_Price(dCollection_ForTheMonth);
            //lblTotCollection.Text = clsFormatter.FormatDecimalPlaces_Price(dCollection_ForTheMonth);

            //// Bank Reconciliation 
            //decimal dReturned_Cheque_ForTheDay = 0, dReturned_Cheque_ForTheMonth = 0, dRealized_Cheque_ForTheDay = 0, dRealized_Cheque_ForTheMonth = 0, dDeposit_Cheque_ForTheDay = 0, dDeposit_Cheque_ForTheMonth = 0, dDeposit_Cash_ForTheDay = 0, dDeposit_Cash_ForTheMonth = 0;

            //clsMethods_Fin.assingValues_ChequeReconcile(ref dReturned_Cheque_ForTheDay, ref dReturned_Cheque_ForTheMonth, ref dRealized_Cheque_ForTheDay, ref dRealized_Cheque_ForTheMonth, dtNow, "");
            //clsMethods_Fin.assingValues_ChequeDeposit(ref dDeposit_Cheque_ForTheDay, ref dDeposit_Cheque_ForTheMonth, dtNow, "");
            //clsMethods_Fin.assingValues_CashDeposit(ref dDeposit_Cash_ForTheDay, ref dDeposit_Cash_ForTheMonth, dtNow, "");

            ////lblChqDepTd.Text = clsFormatter.FormatDecimalPlaces_Price(dDeposit_Cheque_ForTheDay);
            ////lblChqRetTd.Text = clsFormatter.FormatDecimalPlaces_Price(dReturned_Cheque_ForTheDay);
            ////lblCashDepTd.Text = clsFormatter.FormatDecimalPlaces_Price(dDeposit_Cash_ForTheDay);
            ////lblChqRlzTd.Text = clsFormatter.FormatDecimalPlaces_Price(dRealized_Cheque_ForTheDay);
            ////lblChqDepMn.Text = clsFormatter.FormatDecimalPlaces_Price(dDeposit_Cheque_ForTheMonth);
            ////lblChqRetMn.Text = clsFormatter.FormatDecimalPlaces_Price(dReturned_Cheque_ForTheMonth);
            ////lblCashDepMn.Text = clsFormatter.FormatDecimalPlaces_Price(dDeposit_Cash_ForTheMonth);
            ////lblChqRlzMn.Text = clsFormatter.FormatDecimalPlaces_Price(dRealized_Cheque_ForTheMonth);

            ////Outstanding Detail / Financial Detail 
            //decimal dChequeInHand = 0, dTotalOutstanding = 0, dTotalOutstandingOver90 = 0, dDepositedButUnrealized = 0, dHoldingCheques = 0;
            //clsMethods_Fin.assingValues_Outstanding_ForDateRange(ref dChequeInHand, ref dTotalOutstanding, ref dTotalOutstandingOver90, ref dDepositedButUnrealized, ref dHoldingCheques, dFrom, dTo, clsSecurity.BranchID);

            ////lblNtRecAmnt.Text = clsFormatter.FormatDecimalPlaces_Price(dTotalOutstanding);
            //////lblChqDepMn.Text = clsFormatter.FormatDecimalPlaces_Price(dTotalOutstanding);
            //lblCusOutstanding.Text = clsFormatter.FormatDecimalPlaces_Price(dTotalOutstanding);
            ////lblChqInHndAmnt.Text = clsFormatter.FormatDecimalPlaces_Price(dChequeInHand);

            ////lblDebOutstndngAmnt.Text = clsFormatter.FormatDecimalPlaces_Price(dTotalOutstandingOver90);
            ////lblChqInHndFn.Text = clsFormatter.FormatDecimalPlaces_Price(dHoldingCheques);
            ////lblChqInHndFnNotRec.Text = clsFormatter.FormatDecimalPlaces_Price(dDepositedButUnrealized);
            ////lblCashDepMn.Text = clsFormatter.FormatDecimalPlaces_Price(dDepositedButUnrealized);
            //lblChqInHand.Text = clsFormatter.FormatDecimalPlaces_Price(dDepositedButUnrealized); 
            #endregion

            try
            {

                //Sales Details
                DateTime dtNow = clsSecurity.getServerDateTime();
                DateTime dFrom = dtpFrom.Value.Date;
                DateTime dTo = dtpTo.Value.Date;

                //decimal dNetSales_ForTheDay = 0, dNetSales_ForTheMonth = 0, dDebitValue_ForTheDay = 0, dDebitValue_ForTheMonth = 0, dCreditNote_Value_ForTheMonth = 0, dCreditNote_Value_ForTheDay = 0;
                //clsMethods_Fin.assingValues_NetSalesAndDebitValue_UptoDate(ref dNetSales_ForTheDay, ref dNetSales_ForTheMonth, ref dDebitValue_ForTheDay, ref dDebitValue_ForTheMonth, dFrom, dTo, clsSecurity.BranchID);

                decimal dNetSales_ForTheMonth = DBHandling.ExecQuery_ReturnDecimal("SELECT [dbo].[Get_NetSaleAmount_ForToDate]('" + clsSecurity.BranchID + "' , '" + dTo.ToString("YYYY-MM-DD") + "')");
                lblNetSalesMn.Text = clsFormatter.FormatDecimalPlaces_Price(dNetSales_ForTheMonth);

                //Collection Detail
                //decimal dReceipt_Cash_ForTheDay = 0, dReceipt_Cash_ForTheMonth = 0, dReceipt_Cheque_ForTheDay = 0, dReceipt_Cheque_ForTheMonth = 0;
                //clsMethods_Fin.assingValues_Collection_ForDateRange(ref dReceipt_Cash_ForTheDay, ref dReceipt_Cash_ForTheMonth, ref dReceipt_Cheque_ForTheDay, ref dReceipt_Cheque_ForTheMonth, dFrom, dTo, clsSecurity.BranchID);

                decimal dReceipt_Cash_ForTheMonth = DBHandling.ExecQuery_ReturnDecimal("select total from [Get_ReceiptAmount_ForPeriod] ('" + clsSecurity.BranchID + "', '" + dFrom.ToString("YYYY-MM-DD") + "', '" + dTo.ToString("YYYY-MM-DD") + "') where paymentMethod_ID = '" + (int)PaymentMethod.Cash + "'");
                decimal dReceipt_Cheque_ForTheMonth = DBHandling.ExecQuery_ReturnDecimal("select total from [Get_ReceiptAmount_ForPeriod] ('" + clsSecurity.BranchID + "', '" + dFrom.ToString("YYYY-MM-DD") + "', '" + dTo.ToString("YYYY-MM-DD") + "') where paymentMethod_ID = '" + (int)PaymentMethod.Cheque + "'");
                decimal dCollection_ForTheMonth = dReceipt_Cash_ForTheMonth + dReceipt_Cheque_ForTheMonth;

                lblCashCollection.Text = clsFormatter.FormatDecimalPlaces_Price(dReceipt_Cash_ForTheMonth);
                lblChequeCollection.Text = clsFormatter.FormatDecimalPlaces_Price(dReceipt_Cheque_ForTheMonth);
                lblTotCollection.Text = clsFormatter.FormatDecimalPlaces_Price(dCollection_ForTheMonth);

                //Outstanding Detail / Financial Detail 
                //decimal dChequeInHand = 0, dTotalOutstanding = 0, dTotalOutstandingOver90 = 0, dDepositedButUnrealized = 0, dHoldingCheques = 0;
                //clsMethods_Fin.assingValues_Outstanding_ForDateRange(ref dChequeInHand, ref dTotalOutstanding, ref dTotalOutstandingOver90, ref dDepositedButUnrealized, ref dHoldingCheques, dFrom, dTo, clsSecurity.BranchID);
                decimal dChequeInHand = 0;
                decimal dTotalOutstanding = 0;
                var vDataTable = DBHandling.ExecQuery("srh_bssCustomerOutstandingSelectAllByCustomerID '%%', 'BRA/0000' , '2001-01-01', '2018-09-01'").Tables[0];
                if (vDataTable.Rows.Count > 0)
                {
                    dChequeInHand = decimal.Parse(vDataTable.AsEnumerable().Where(y => y.Field<int>("isChecueInHand") == 1).Sum(x => x.Field<decimal>("outstanding")).ToString());
                    dTotalOutstanding = decimal.Parse(vDataTable.AsEnumerable().Where(y => y.Field<int>("isChecueInHand") == 0).Sum(x => x.Field<decimal>("outstanding")).ToString());
                }
                lblCusOutstanding.Text = clsFormatter.FormatDecimalPlaces_Price(dTotalOutstanding);
                lblChqInHand.Text = clsFormatter.FormatDecimalPlaces_Price(dChequeInHand);

                decimal dDepositedButUnrealized = DBHandling.ExecQuery_ReturnDecimal("SELECT SUM(amount) FROM tbl_bpsChequeRegister AS P WHERE (paymentMethod_ID = '1') and  [companyBranch_ID] = '" + clsSecurity.BranchID + "' and [isDeleted] = '0' and [isReconcilied] = '0' and [isReIssued] ='0' and [accountReceipt_ID] = 'default' and (CAST(dateDeposited AS date) <= CAST('" + dTo.ToString("YYYY-MM-DD") + "' AS date)) AND (CAST(dateDeposited AS date) >= CAST('" + dFrom.ToString("YYYY-MM-DD") + "' AS date))");
                lblDepNotRealized.Text = clsFormatter.FormatDecimalPlaces_Price(dDepositedButUnrealized);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Get Counts and Amounts
        private void GetCountCO()
        {
            DateTime dFrom = dtpFrom.Value.Date;
            DateTime dTo = dtpTo.Value.Date;

            int iCount = 0;
            decimal dAmount = 0;
            decimal dQty = 0;
            foreach (tbl_sasCustomerOrder detail in tbl_sasCustomerOrder.SelectAll().Where(p => p.CustomerOrder_ID != "default" && !p.IsDeleted && p.CustomerOrderDate.Date >= dFrom && p.CustomerOrderDate.Date <= dTo))
            {
                ++iCount;
                dAmount += detail.GrandTotal;

                foreach (tbl_sasCustomerOrder_Detail detailCO in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(detail.CustomerOrder_ID))
                {
                    dQty += detailCO.Qty;
                }
            }
            lblCOCount.Text = iCount.ToString();
            lblCOQty.Text = dQty > 0 ? clsFormatter.FormatDecimalPlaces_Quantity(dQty) : "0";
            lblAmntCO.Text = dAmount > 0 ? clsFormatter.FormatDecimalPlaces_Price(dAmount) : "0.00";
        }
        private void GetCountDO()
        {
            DateTime dFrom = dtpFrom.Value.Date;
            DateTime dTo = dtpTo.Value.Date;

            int iCount = 0;
            //decimal dAmount = 0;
            decimal dQty = 0;
            foreach (tbl_sasDeliveryOrder detail in tbl_sasDeliveryOrder.SelectAll().Where(p => p.DeliveryOrder_ID != "default" && !p.IsDeleted && p.DeliveryOrderDate.Date >= dFrom && p.DeliveryOrderDate.Date <= dTo))
            {
                ++iCount;
                //dAmount += detail.GrandTotal;
                foreach (tbl_sasDeliveryOrder_Detail detailDO in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(detail.DeliveryOrder_ID))
                {
                    dQty += detailDO.Qty;
                }
            }
            lblDOCount.Text = iCount.ToString();
            lblDOQty.Text = dQty > 0 ? clsFormatter.FormatDecimalPlaces_Quantity(dQty) : "0";
            //lblAmntDO.Text = clsFormatter.FormatDecimalPlaces_Price(dAmount).ToString();

        }

        private void GetCountInvoice()
        {
            DateTime dFrom = dtpFrom.Value.Date;
            DateTime dTo = dtpTo.Value.Date;

            int iCount = 0;
            decimal dAmount = 0;
            decimal dQty = 0;
            foreach (tbl_sasInvoice detail in tbl_sasInvoice.SelectAll().Where(p => p.Invoice_ID != "default" && !p.IsDeleted && p.InvoiceDate.Date >= dFrom && p.InvoiceDate.Date <= dTo))
            {
                ++iCount;
                dAmount += detail.GrandTotal;
                foreach (tbl_sasInvoice_Detail detailInv in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(detail.Invoice_ID))
                {
                    dQty += detailInv.Qty;
                }
            }
            lblInvCount.Text = iCount.ToString();
            lblInvQty.Text = dQty > 0 ? clsFormatter.FormatDecimalPlaces_Quantity(dQty) : "0";
            lblAmntINV.Text = dAmount > 0 ? clsFormatter.FormatDecimalPlaces_Price(dAmount) : "0.00";

        }

        private void GetCountReceipt()
        {
            DateTime dFrom = dtpFrom.Value.Date;
            DateTime dTo = dtpTo.Value.Date;

            int iCount = 0;
            decimal dAmount = 0;
            foreach (tbl_bpsReceipt detail in tbl_bpsReceipt.SelectAll().Where(p => p.Receipt_ID != "default" && !p.IsDeleted && p.ReceiptDate.Date >= dFrom && p.ReceiptDate.Date <= dTo))
            {
                ++iCount;
                dAmount += detail.TotalAmount;
            }
            lblRecpCount.Text = iCount.ToString();
            //lblRecpAmount.Text = clsFormatter.FormatDecimalPlaces_Price(dAmount).ToString();
            lblAmntRcp.Text = dAmount > 0 ? clsFormatter.FormatDecimalPlaces_Price(dAmount) : "0.00";
        }

        private void GetCountSRN()
        {
            DateTime dFrom = dtpFrom.Value.Date;
            DateTime dTo = dtpTo.Value.Date;

            int iCount = 0;
            decimal dAmount = 0;
            decimal dQty = 0;
            foreach (tbl_sasSalesReturnedNote detail in tbl_sasSalesReturnedNote.SelectAll().Where(p => p.SalesReturnedNote_ID != "default" && !p.IsDeleted && p.SalesReturnedNoteDate.Date >= dFrom && p.SalesReturnedNoteDate.Date <= dTo))
            {
                ++iCount;
                dAmount += detail.GrandTotal;
                foreach (tbl_sasSalesReturnedNote_Detail detailSrn in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(detail.SalesReturnedNote_ID))
                {
                    dQty += detailSrn.Qty;
                }
            }
            lblSRNCount.Text = iCount.ToString();
            lblSRNQty.Text = dQty > 0 ? clsFormatter.FormatDecimalPlaces_Quantity(dQty) : "0";
            lblAmntSRN.Text = dAmount > 0 ? clsFormatter.FormatDecimalPlaces_Price(dAmount) : "0.00";
        }

        private void GetCountPO()
        {
            DateTime dFrom = dtpFrom.Value.Date;
            DateTime dTo = dtpTo.Value.Date;

            int iCount = 0;
            decimal dAmount = 0;
            decimal dQty = 0;
            foreach (tbl_scsPurchaseOrder detail in tbl_scsPurchaseOrder.SelectAll().Where(p => p.PurchaseOrder_ID != "default" && !p.IsDeleted && p.PurchaseOrderDate.Date >= dFrom && p.PurchaseOrderDate.Date <= dTo))
            {
                ++iCount;
                dAmount += detail.GrandTotal;
                foreach (tbl_scsPurchaseOrder_Detail detailPO in tbl_scsPurchaseOrder_Detail.SelectAllByPurchaseOrder_ID(detail.PurchaseOrder_ID))
                {
                    dQty += detailPO.Qty;
                }
            }
            lblPOCount.Text = iCount.ToString();
            lblPOQty.Text = dQty > 0 ? clsFormatter.FormatDecimalPlaces_Quantity(dQty) : "0";
            lblAmntPO.Text = dAmount > 0 ? clsFormatter.FormatDecimalPlaces_Price(dAmount) : "0.00";
        }

        private void GetCountGRN()
        {
            DateTime dFrom = dtpFrom.Value.Date;
            DateTime dTo = dtpTo.Value.Date;

            int iCount = 0;
            decimal dAmount = 0;
            decimal dQty = 0;
            foreach (tbl_scsExternalGoodReceivedNote detail in tbl_scsExternalGoodReceivedNote.SelectAll().Where(p => p.ExternalGoodReceivedNote_ID != "default" && !p.IsDeleted && p.ExternalGoodReceivedNoteDate.Date >= dFrom && p.ExternalGoodReceivedNoteDate.Date <= dTo))
            {
                ++iCount;
                dAmount += detail.GrandTotal;
                foreach (tbl_scsExternalGoodReceivedNote_Detail detailGRN in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(detail.ExternalGoodReceivedNote_ID))
                {
                    dQty += detailGRN.Qty;
                }
            }
            lblGRNCount.Text = iCount.ToString();
            lblGRNQty.Text = dQty > 0 ? clsFormatter.FormatDecimalPlaces_Quantity(dQty) : "0";
            lblAmntGRN.Text = dAmount > 0 ? clsFormatter.FormatDecimalPlaces_Price(dAmount) : "0.00";
        }

        private void GetCountPRN()
        {
            DateTime dFrom = dtpFrom.Value.Date;
            DateTime dTo = dtpTo.Value.Date;

            int iCount = 0;
            decimal dAmount = 0;
            decimal dQty = 0;
            foreach (tbl_scsPurchaseReturnedNote detail in tbl_scsPurchaseReturnedNote.SelectAll().Where(p => p.PurchaseReturnedNote_ID != "default" && !p.IsDeleted && p.PurchaseReturnedNoteDate.Date >= dFrom && p.PurchaseReturnedNoteDate.Date <= dTo))
            {
                ++iCount;
                dAmount += detail.GrandTotal;
                foreach (tbl_scsPurchaseReturnedNote_Detail detailPRN in tbl_scsPurchaseReturnedNote_Detail.SelectAllByPurchaseReturnedNote_ID(detail.PurchaseReturnedNote_ID))
                {
                    dQty += detailPRN.Qty;
                }
            }
            lblPRNCount.Text = iCount.ToString();
            lblPRNQty.Text = dQty > 0 ? clsFormatter.FormatDecimalPlaces_Quantity(dQty) : "0";
            lblAmntPRN.Text = dAmount > 0 ? clsFormatter.FormatDecimalPlaces_Price(dAmount) : "0.00";
        }

        private void GetCountGIN()
        {
            DateTime dFrom = dtpFrom.Value.Date;
            DateTime dTo = dtpTo.Value.Date;

            int iCount = 0;
            decimal dAmount = 0;
            decimal dQty = 0;
            foreach (tbl_scsExternalGoodIssueNote detail in tbl_scsExternalGoodIssueNote.SelectAll().Where(p => p.ExternalGoodIssueNote_ID != "default" && !p.IsDeleted && p.ExternalGoodIssueNoteDate.Date >= dFrom && p.ExternalGoodIssueNoteDate.Date <= dTo))
            {
                ++iCount;
                dAmount += detail.GrandTotal;
                foreach (tbl_scsExternalGoodIssueNote_Detail detailGIN in tbl_scsExternalGoodIssueNote_Detail.SelectAllByExternalGoodIssueNote_ID(detail.ExternalGoodIssueNote_ID))
                {
                    dQty += detailGIN.Qty;
                }
            }
            lblGINCount.Text = iCount.ToString();
            lblGINQty.Text = dQty > 0 ? clsFormatter.FormatDecimalPlaces_Quantity(dQty) : "0";
            lblAmntGIN.Text = dAmount > 0 ? clsFormatter.FormatDecimalPlaces_Price(dAmount) : "0.00";
        }

        private void GetCountDGN()
        {
            DateTime dFrom = dtpFrom.Value.Date;
            DateTime dTo = dtpTo.Value.Date;

            int iCount = 0;
            //decimal dAmount = 0;
            decimal dQty = 0;
            foreach (tbl_scsDamagedGoodNote detail in tbl_scsDamagedGoodNote.SelectAll().Where(p => p.DamagedGoodNote_ID != "default" && !p.IsDeleted && p.DamagedGoodNoteDate.Date >= dFrom && p.DamagedGoodNoteDate.Date <= dTo))
            {
                ++iCount;
                foreach (tbl_scsDamagedGoodNote_Detail det in tbl_scsDamagedGoodNote_Detail.SelectAllByDamagedGoodNote_ID(detail.DamagedGoodNote_ID))
                {
                    //dAmount += det.TatalAmount;
                    dQty += det.Qty;
                }
            }
            lblDGNCount.Text = iCount.ToString();
            lblDGNQty.Text = dQty > 0 ? clsFormatter.FormatDecimalPlaces_Quantity(dQty) : "0";
            //lblAmntDGN.Text = clsFormatter.FormatDecimalPlaces_Price(dAmount).ToString();
        }

        private void GetCountADJ()
        {
            DateTime dFrom = dtpFrom.Value.Date;
            DateTime dTo = dtpTo.Value.Date;

            int iCount = 0;
            decimal dQty = 0;
            foreach (tbl_scsStockAdjustment detail in tbl_scsStockAdjustment.SelectAll().Where(p => p.StockAdjustment_ID != "default" && !p.IsDeleted && p.StockAdjustmentDate.Date >= dFrom && p.StockAdjustmentDate.Date <= dTo))
            {
                ++iCount;
                foreach (tbl_scsStockAdjustment_Detail det in tbl_scsStockAdjustment_Detail.SelectAllByStockAdjustment_ID(detail.StockAdjustment_ID))
                {
                    dQty += det.Qty;
                }
            }
            lblADJCount.Text = iCount.ToString();
            lblADJQty.Text = dQty > 0 ? clsFormatter.FormatDecimalPlaces_Quantity(dQty) : "0";
            //lblAmntDGN.Text = clsFormatter.FormatDecimalPlaces_Price(dAmount).ToString();
        }

        //private decimal GetAmountCO()
        //{
        //    DateTime dFrom = dtpFrom.Value.Date;
        //    DateTime dTo = dtpTo.Value.Date;

        //    decimal dAmount = 0;
        //    foreach (tbl_sasCustomerOrder detail in tbl_sasCustomerOrder.SelectAll().Where(p => p.CustomerOrder_ID != "default" && !p.IsDeleted && p.CustomerOrderDate.Date >= dFrom && p.CustomerOrderDate.Date <= dTo))
        //    {
        //        dAmount = dAmount + detail.GrandTotal;
        //    }
        //    return dAmount;
        //}



        //private decimal GetAmountDO()
        //{
        //    DateTime dFrom = dtpFrom.Value.Date;
        //    DateTime dTo = dtpTo.Value.Date;

        //    decimal iAmount = 0;
        //    foreach (tbl_sasDeliveryOrder detail in tbl_sasDeliveryOrder.SelectAll().Where(p => p.DeliveryOrder_ID != "default" && !p.IsDeleted && p.DeliveryOrderDate.Date >= dFrom && p.DeliveryOrderDate.Date <= dTo))
        //    {
        //        iAmount = iAmount + detail.GrandTotal;
        //    }
        //    return iAmount;
        //}



        //private decimal GetAmountInvoice()
        //{
        //    DateTime dFrom = dtpFrom.Value.Date;
        //    DateTime dTo = dtpTo.Value.Date;

        //    decimal iAmount = 0;
        //    foreach (tbl_sasInvoice detail in tbl_sasInvoice.SelectAll().Where(p => p.Invoice_ID != "default" && !p.IsDeleted && p.InvoiceDate.Date >= dFrom && p.InvoiceDate.Date <= dTo))
        //    {
        //        iAmount = iAmount + detail.GrandTotal;
        //    }
        //    return iAmount;
        //}



        //private decimal GetAmountReceipt()
        //{
        //    DateTime dFrom = dtpFrom.Value.Date;
        //    DateTime dTo = dtpTo.Value.Date;

        //    decimal iAmount = 0;
        //    foreach (tbl_bpsReceipt detail in tbl_bpsReceipt.SelectAll().Where(p => p.Receipt_ID != "default" && !p.IsDeleted && p.ReceiptDate.Date >= dFrom && p.ReceiptDate.Date <= dTo))
        //    {
        //        iAmount = iAmount + detail.TotalAmount;
        //    }
        //    return iAmount;
        //}



        //private decimal GetAmountSRN()
        //{
        //    DateTime dFrom = dtpFrom.Value.Date;
        //    DateTime dTo = dtpTo.Value.Date;

        //    decimal iAmount = 0;
        //    foreach (tbl_sasSalesReturnedNote detail in tbl_sasSalesReturnedNote.SelectAll().Where(p => p.SalesReturnedNote_ID != "default" && !p.IsDeleted && p.SalesReturnedNoteDate.Date >= dFrom && p.SalesReturnedNoteDate.Date <= dTo))
        //    {
        //        iAmount = iAmount + detail.GrandTotal;
        //    }
        //    return iAmount;
        //}


        //private decimal GetAmountPO()
        //{
        //    DateTime dFrom = dtpFrom.Value.Date;
        //    DateTime dTo = dtpTo.Value.Date;

        //    decimal iAmount = 0;
        //    foreach (tbl_scsPurchaseOrder detail in tbl_scsPurchaseOrder.SelectAll().Where(p => p.PurchaseOrder_ID != "default" && !p.IsDeleted && p.PurchaseOrderDate.Date >= dFrom && p.PurchaseOrderDate.Date <= dTo))
        //    {
        //        iAmount = iAmount + detail.GrandTotal;
        //    }
        //    return iAmount;
        //}



        //private decimal GetAmountGRN()
        //{
        //    DateTime dFrom = dtpFrom.Value.Date;
        //    DateTime dTo = dtpTo.Value.Date;

        //    decimal iAmount = 0;
        //    foreach (tbl_scsExternalGoodReceivedNote detail in tbl_scsExternalGoodReceivedNote.SelectAll().Where(p => p.ExternalGoodReceivedNote_ID != "default" && !p.IsDeleted && p.ExternalGoodReceivedNoteDate.Date >= dFrom && p.ExternalGoodReceivedNoteDate.Date <= dTo))
        //    {
        //        iAmount = iAmount + detail.GrandTotal;
        //    }
        //    return iAmount;
        //}



        //private decimal GetAmountPRN()
        //{
        //    DateTime dFrom = dtpFrom.Value.Date;
        //    DateTime dTo = dtpTo.Value.Date;

        //    decimal iAmount = 0;
        //    foreach (tbl_scsPurchaseReturnedNote detail in tbl_scsPurchaseReturnedNote.SelectAll().Where(p => p.PurchaseReturnedNote_ID != "default" && !p.IsDeleted && p.PurchaseReturnedNoteDate.Date >= dFrom && p.PurchaseReturnedNoteDate.Date <= dTo))
        //    {
        //        iAmount = iAmount + detail.GrandTotal;
        //    }
        //    return iAmount;
        //}



        //private decimal GetAmountGIN()
        //{
        //    DateTime dFrom = dtpFrom.Value.Date;
        //    DateTime dTo = dtpTo.Value.Date;

        //    decimal iAmount = 0;
        //    foreach (tbl_scsExternalGoodIssueNote detail in tbl_scsExternalGoodIssueNote.SelectAll().Where(p => p.ExternalGoodIssueNote_ID != "default" && !p.IsDeleted && p.ExternalGoodIssueNoteDate.Date >= dFrom && p.ExternalGoodIssueNoteDate.Date <= dTo))
        //    {
        //        iAmount = iAmount + detail.GrandTotal;
        //    }
        //    return iAmount;
        //}



        //private decimal GetAmountDGN()
        //{
        //    DateTime dFrom = dtpFrom.Value.Date;
        //    DateTime dTo = dtpTo.Value.Date;

        //    decimal iAmount = 0;
        //    foreach (tbl_scsDamagedGoodNote detail in tbl_scsDamagedGoodNote.SelectAll().Where(p => p.DamagedGoodNote_ID != "default" && !p.IsDeleted && p.DamagedGoodNoteDate.Date >= dFrom && p.DamagedGoodNoteDate.Date <= dTo))
        //    {
        //        foreach (tbl_scsDamagedGoodNote_Detail det in tbl_scsDamagedGoodNote_Detail.SelectAllByDamagedGoodNote_ID(detail.DamagedGoodNote_ID))
        //        {
        //            iAmount = iAmount + det.TatalAmount;
        //        }
        //    }
        //    return iAmount;
        //} 
        #endregion

        #region Print Method
        private void print(string path, string sReportTitle, string sFormula, Button Button)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Standed Reports";

                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                frm_ReportViewer viewer = new frm_ReportViewer();
                ReportDocument RD = new ReportDocument();
                RD.Load(s_Path);
                clsSecurity.LogonServer(ref RD);
                RD.Refresh();

                RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                if (Button.Name == "btnPerformanceReport")
                {
                    RD.DataDefinition.FormulaFields["TotalCreditAmount"].Text = (-creditAmount).ToString();
                    RD.DataDefinition.FormulaFields["TotalNBTCreditNoteAmount"].Text = (-dNbtTotal).ToString();
                    RD.DataDefinition.FormulaFields["TotalVATCreditNoteAmount"].Text = (-dVatTotal).ToString();
                    RD.DataDefinition.FormulaFields["TotalSVATCreditNoteAmount"].Text = (-dSVatTotal).ToString();

                    RD.DataDefinition.FormulaFields["TotalDebitAmount"].Text = DebitAmount.ToString();
                    RD.DataDefinition.FormulaFields["TotalNBTDebitNoteAmount"].Text = dDebitNbtTotal.ToString();
                    RD.DataDefinition.FormulaFields["TotalVATDebitNoteAmount"].Text = dDebitVatTotal.ToString();
                    RD.DataDefinition.FormulaFields["TotalSVATDebitNoteAmount"].Text = dDebitSVatTotal.ToString();
                    RD.DataDefinition.FormulaFields["ReturnedSalesCost(SRN)"].Text = dSRNFIFOCost.ToString();
                }

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

                creditAmount = 0; dNbtTotal = 0; dVatTotal = 0; dSVatTotal = 0;
                DebitAmount = 0; dDebitNbtTotal = 0; dDebitVatTotal = 0; dDebitSVatTotal = 0; dSRNFIFOCost = 0;
            }

        }
        #endregion

        #region Sales Report With Tax
        private void btnSalesReportWithTax_Click(object sender, EventArgs e)
        {
            string sFormula = "";

            sFormula = " {vw_rpt_sasInvoice.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasInvoice.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
            sFormula += " and {vw_rpt_sasInvoice.isDeleted} = false and {vw_rpt_sasInvoice.isOpeningBalance} = False and {vw_rpt_sasInvoice.isReturnedCheque} = False";
            print("\\Reports\\MIS\\Report\\rpt_sas_SalesSummaryWithTaxes.rpt", " Sales Report [with Taxes]", sFormula, btnSalesReportWithTax);
        }
        #endregion

        #region Performance Report
        private void btnPerformanceReport_Click(object sender, EventArgs e)
        {
            string sFormula = "";

            sFormula = " {vw_rpt_sasPerformance_Report.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasPerformance_Report.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
            sFormula += " and {vw_rpt_sasPerformance_Report.customer_ID} <> 'default' ";
            sFormula += " and {vw_rpt_sasPerformance_Report.RCPCheque_Amount} <= 0 ";
            sFormula += " and {vw_rpt_sasPerformance_Report.RCPCash_Amount} <= 0 ";// because profomance date wise report has 0 values when having  RCPCheque_Amount and RCPCash_Amount amount 
            // for that remove the  RCPCheque_Amount and RCPCash_Amount line

            DebitNoteAmounts();
            CreditNoteAmounts();
            SRNCostCalculationAmounts();

            //if (bCustomerSelected)
            //    sFormula += " and {vw_rpt_sasPerformance_Report.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "' ";
            //if (bRoutSelected)
            //    sFormula += " and {vw_rpt_sasPerformance_Report.route_ID} = '" + txtRoute.Tag.ToString().Trim() + "' ";
            //if (bSelesRepSelected)
            //    sFormula += " and {vw_rpt_sasPerformance_Report.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";

            print("\\Reports\\MIS\\Report\\rpt_sas_PerformanceReportDateWise.rpt", "Performance Report Date Wise", sFormula, btnPerformanceReport);
        }
        #endregion

        #region Daily Collection Report
        private void btnDailyCollectionReport_Click(object sender, EventArgs e)
        {
            string sFormula = "";

            sFormula = " {vw_rpt_bpsReceiptHeder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsReceiptHeder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
            sFormula += " and {vw_rpt_bpsReceiptHeder.isDeleted} = false";
            print("\\Reports\\MIS\\Report\\rpt_sas_DailyCollectionReport.rpt", " Daily Sales Collection Report ", sFormula, btnDailyCollectionReport);
        }
        #endregion

        #region btn Age Analysis
        private void btnAgeAnalysis_Click(object sender, EventArgs e)
        {
            string sFormula = "";

            sFormula = "{vw_rpt_sasOutstandingLedger.transactionCode} <> '' ";// " {vw_rpt_sasOutstandingLedger.p_Date}>= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasOutstandingLedger.p_Date}<= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
            print("\\Reports\\MIS\\Report\\rpt_sas_OutstandingDetail_All_Customer_Ageing.rpt", "Age-Analysis (Customer-wise)", sFormula, btnAgeAnalysis);
        }
        #endregion

        #region btn Flow Stock Report
        private void vistaButton1_Click(object sender, EventArgs e)
        {
            #region OLD
            //string sFormula = "{vw_rpt_masStoreStock.storeName} <> 'default'";

            //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
            //    print("\\Reports\\MIS\\Report\\rpt_scs_StockReport_Store_APL_WA.rpt", "FLOOR STOCKS BALANCE (TO-DATE)", sFormula, btnFlowStockReport); 
            #endregion

            Cursor = Cursors.WaitCursor;
            List<string> lstItemType = new List<string>();

            //if (bItemType_Selected)
            //    lstItemType.Add(txtItemType.Tag.ToString());
            MessageBox.Show("not implemented");
          //  Stockreports oStockreport = new Stockreports(false, false, false, txtStore, txtItemName, txtItemCategory, lstItemType, dtpTo.Value.Date.AddDays(1), dtpTo.Value.Date.AddDays(1), enum_CostPriceType.CostPrice1, true);
            //if (chkShowZeroItem.Checked)
            //    oStockreport.bShowAllItems = true;
          //  oStockreport.GenarateFloorStockReport(enum_ReportName.ST_FloorStockReport, ref progressBar1, false, "Floor Stock Report", "", clsSecurity.BranchID);
          //  oStockreport = null;
            Cursor = Cursors.Default;

        }
        #endregion

        #region btn Cheques In Hand
        private void btnChequesInHand_Click(object sender, EventArgs e)
        {
            string sFormula = "";
            // sFormula = "{vw_rpt_bpsChequeRegister.pd_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsChequeRegister.pd_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";


            sFormula += " {vw_rpt_bpsChequeRegister.isDepositted} = False and {vw_rpt_bpsChequeRegister.isReIssued} = False and {vw_rpt_bpsChequeRegister.isDeleted} = False";
            print("\\Reports\\MIS\\Report\\rpt_sas_PendingDepositChequeSummary.rpt", "Cheques In Hand", sFormula, btnChequesInHand);
        }
        #endregion

        #region btn Realized Cheques
        private void btnRealizedCheques_Click(object sender, EventArgs e)
        {
            string sFormula = "";
            sFormula = " {vw_rpt_bpsChequeReconciliation.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsChequeReconciliation.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
            sFormula += " and {vw_rpt_bpsChequeReconciliation.chequeStatus_ID} = '" + clsAutocode.getChequeStatusID(ChequeStatus.Realized) + "'";

            print("\\Reports\\MIS\\Report\\rpt_sas_RealizedChequeSummary.rpt", "Realized Cheque Summary", sFormula, btnRealizedCheques);
        }
        #endregion

        #region btn Deposited Cash Bank AcctWise	 
        private void DepositedCashBankAcctWise_Click(object sender, EventArgs e)
        {
            string sFormula = "";
            sFormula = " {vw_rpt_bpsChequeDeposit.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsChequeDeposit.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

            sFormula += " and {vw_rpt_bpsChequeDeposit_Detail.isDepositted} = True";
            print("\\reports\\BSS\\Registry\\rpt_sas_DepositedChequeSummary.rpt", "Deposited Cheque Summary", sFormula, DepositedCashBankAcctWise);
        }
        #endregion

        #region Invoice Wise FIFO TrackingReport
        private void rdoInvoiceWiseFIFOTrackingReport_Click(object sender, EventArgs e)
        {
            string sFormula = "";
            sFormula = " {vw_rpt_sasInvoice.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasInvoice.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

            print("\\Reports\\MIS\\Report\\rpt_sas_InvoiceFIFOCostCaculation.rpt", " Invoice Wise FIFO Tracking Report ", sFormula, btnInvoiceWiseFIFOTrackingReport);
        }
        #endregion

        #region Performance Report Calculation

        #region Credit Note Amounts Calculation
        private void CreditNoteAmounts()
        {
            List<tbl_bpsCreditNote> details = tbl_bpsCreditNote.SelectAll();
            foreach (tbl_bpsCreditNote detail in details)
            {
                DateTime fDate = new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day);
                DateTime tDate = new DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day);
                DateTime crediteNoteDate = new DateTime(detail.CreditNoteDate.Year, detail.CreditNoteDate.Month, detail.CreditNoteDate.Day);

                decimal dTemNbtTotal = 0;
                decimal dSVATTempTotalAmount = 0;
                if (crediteNoteDate >= fDate && crediteNoteDate <= tDate)
                {
                    if (detail.IsDeleted == false)
                    {
                        if (detail.OtherTaxTotal > 0)//isSVAT
                        {
                            dTemNbtTotal = (detail.TotalAmount / 100);
                            dNbtTotal = dNbtTotal + dTemNbtTotal;
                            creditAmount += (detail.TotalAmount - dTemNbtTotal);
                            dSVatTotal += (detail.TotalAmount * 12) / 100;
                            dVatTotal += 0;
                        }
                        else
                        {
                            dSVATTempTotalAmount = ((detail.TotalAmount / 112) * 100);

                            dTemNbtTotal = (dSVATTempTotalAmount / 100);
                            dNbtTotal = dNbtTotal + dTemNbtTotal;
                            creditAmount += (dSVATTempTotalAmount - dTemNbtTotal);
                            dVatTotal += (dSVATTempTotalAmount * 12) / 100;
                            dSVatTotal += 0;
                        }
                        dTemNbtTotal = 0;
                        dSVATTempTotalAmount = 0;
                    }
                }
            }
        }
        private void CreditNoteAmountsAll()
        {
            List<tbl_bpsCreditNote> details = tbl_bpsCreditNote.SelectAll();
            foreach (tbl_bpsCreditNote detail in details)
            {
                decimal dTemNbtTotal = 0;
                decimal dSVATTempTotalAmount = 0;

                if (detail.CreditNoteDate.Date <= dtpTo.Value.Date)
                {

                    if (detail.IsDeleted == false)
                    {
                        if (detail.OtherTaxTotal > 0)//isSVAT
                        {
                            dTemNbtTotal = (detail.TotalAmount / 100);
                            dNbtTotal = dNbtTotal + dTemNbtTotal;
                            creditAmount += (detail.TotalAmount - dTemNbtTotal);
                            dSVatTotal += (detail.TotalAmount * 12) / 100;
                            dVatTotal += 0;
                        }
                        else
                        {
                            dSVATTempTotalAmount = ((detail.TotalAmount / 112) * 100);

                            dTemNbtTotal = (dSVATTempTotalAmount / 100);
                            dNbtTotal = dNbtTotal + dTemNbtTotal;
                            creditAmount += (dSVATTempTotalAmount - dTemNbtTotal);
                            dVatTotal += (dSVATTempTotalAmount * 12) / 100;
                            dSVatTotal += 0;
                        }
                        dTemNbtTotal = 0;
                        dSVATTempTotalAmount = 0;
                    }
                }
            }

        }
        #endregion

        #region Debit Note Amounts Calculation
        private void DebitNoteAmounts()
        {
            List<tbl_bpsDebitNote> details = tbl_bpsDebitNote.SelectAll();
            foreach (tbl_bpsDebitNote detail in details)
            {
                DateTime fDate = new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day);
                DateTime tDate = new DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day);
                DateTime DebitNoteDate = new DateTime(detail.DebitNoteDate.Year, detail.DebitNoteDate.Month, detail.DebitNoteDate.Day);
                decimal dDebitTemNbtTotal = 0;
                decimal dDebitTemSubTotal = 0;

                if (DebitNoteDate >= fDate && DebitNoteDate <= tDate)
                {
                    if (detail.IsDeleted == false)
                    {
                        DebitAmount += detail.SubTotal;
                        dDebitNbtTotal += 0;
                        dDebitVatTotal += detail.VatTotal;
                        dDebitSVatTotal += 0;


                        //if (detail.OtherTaxTotal > 0)//isSVAT
                        //{
                        //    dDebitTemSubTotal = (detail.TotalAmount / 102) * 100;
                        //    DebitAmount += dDebitTemSubTotal;
                        //    dDebitTemNbtTotal = ((dDebitTemSubTotal * 2) / 100);
                        //    dDebitNbtTotal += dDebitTemNbtTotal;
                        //    dDebitSVatTotal += ((dDebitTemNbtTotal + dDebitTemSubTotal) * 12) / 100;
                        //    dDebitVatTotal += 0;
                        //}
                        //else
                        //{
                        //    dDebitTemSubTotal = (((detail.TotalAmount / 112) * 100) / 102) * 100;
                        //    DebitAmount += dDebitTemSubTotal;

                        //    dDebitTemNbtTotal = ((dDebitTemSubTotal * 2) / 100);
                        //    dDebitNbtTotal += dDebitTemNbtTotal;
                        //    dDebitVatTotal += ((dDebitTemNbtTotal + dDebitTemSubTotal) * 12) / 100;
                        //    dDebitSVatTotal += 0;
                        //}
                        //dDebitTemNbtTotal = 0;
                    }
                }
            }
        }
        private void DebitNoteAmountsAll()
        {
            List<tbl_bpsDebitNote> details = tbl_bpsDebitNote.SelectAll();
            foreach (tbl_bpsDebitNote detail in details)
            {
                if (detail.DebitNoteDate.Date <= dtpTo.Value.Date)
                {
                    if (detail.IsDeleted == false)
                    {
                        DebitAmount += detail.SubTotal;
                        dDebitNbtTotal += 0;
                        dDebitVatTotal += detail.VatTotal;
                        dDebitSVatTotal += 0;

                        //DebitAmount += detail.TotalAmount;
                        ////dDebitNbtTotal += (detail.TotalAmount * 2) / 100;
                        //dDebitVatTotal += detail.VatTotal;
                        //dDebitSVatTotal += detail.OtherTaxTotal;
                    }
                }
            }
        }
        #endregion

        #region Sales Returned Note Cost Calculation
        private void SRNCostCalculationAmounts()
        {
            List<tbl_sasSalesReturnedNote_Detail> details = tbl_sasSalesReturnedNote_Detail.SelectAll();
            foreach (tbl_sasSalesReturnedNote_Detail detail in details)
            {
                tbl_sasSalesReturnedNote SRNNoteDetail = tbl_sasSalesReturnedNote.Select(detail.SalesReturnedNote_ID);
                if (SRNNoteDetail != null)
                {
                    DateTime fDate = new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day);
                    DateTime tDate = new DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day);
                    DateTime SRNNoteDate = new DateTime(SRNNoteDetail.SalesReturnedNoteDate.Year, SRNNoteDetail.SalesReturnedNoteDate.Month, SRNNoteDetail.SalesReturnedNoteDate.Day);

                    if (SRNNoteDate >= fDate && SRNNoteDate <= tDate)
                    {
                        if (SRNNoteDetail.IsDeleted == false)
                        {
                            dSRNFIFOCost += -detail.TatalCost_FIFO;
                        }
                    }
                }
            }
        }
        private void SRNCostCalculationAmountsAll()
        {
            List<tbl_sasSalesReturnedNote_Detail> details = tbl_sasSalesReturnedNote_Detail.SelectAll();
            foreach (tbl_sasSalesReturnedNote_Detail detail in details)
            {
                tbl_sasSalesReturnedNote SRNNoteDetail = tbl_sasSalesReturnedNote.Select(detail.SalesReturnedNote_ID);

                if (SRNNoteDetail != null)
                {
                    if (SRNNoteDetail.SalesReturnedNoteDate.Date <= dtpTo.Value.Date)
                    {
                        if (SRNNoteDetail.IsDeleted == false)
                        {
                            dSRNFIFOCost += -detail.TatalCost_FIFO;
                        }
                    }
                }
            }
        }
        #endregion

        #endregion
        
        #region Data Set Invoice Wise Profit Report
        private DataTable DataSetInvoiceWiseProfitReport()
        {
            foreach (tbl_sasInvoice Invoice in tbl_sasInvoice.SelectAll().Where(p => p.Invoice_ID != "default" && p.IsDeleted == false &&
               p.IsDebitNote == false && p.IsOpeningBalance == false && p.IsReturnedCheque == false && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date))
            {
                glb_dtsSales.dt_sasInvoiceWiseProfit.Adddt_sasInvoiceWiseProfitRow(Invoice.Invoice_ID,
                    Invoice.InvoiceDate, GetEmpName(Invoice.OrderRefNo_ID), Invoice.GrandTotal, TotalInvoiceFIFOCost(Invoice.Invoice_ID),
                    SubTotalAmount(Invoice.Invoice_ID), (SubTotalAmount(Invoice.Invoice_ID) - TotalInvoiceFIFOCost(Invoice.Invoice_ID)), CreditNoteAmountInvoiceWise(Invoice.Invoice_ID), DebitNoteAmount(Invoice.Invoice_ID),
                    (SubTotalAmount(Invoice.Invoice_ID) - TotalInvoiceFIFOCost(Invoice.Invoice_ID)) - CreditNoteAmountInvoiceWise(Invoice.Invoice_ID) + DebitNoteAmount(Invoice.Invoice_ID) + SRNCostCalculationAmounts(Invoice.Invoice_ID),
                    clsGenaralName.getName_Customer(Invoice.Customer_ID), SRNCostCalculationAmounts(Invoice.Invoice_ID));
            }

            return glb_dtsSales.dt_sasInvoiceWiseProfit;
        }
        #endregion

        #region Get Emp Name
        private string GetEmpName(string sOrderRefNo_ID)
        {
            string SRPname = "";
            tbl_zOrderRefNo OderRef = tbl_zOrderRefNo.Select(sOrderRefNo_ID);
            if (OderRef != null)
            {
                tbl_genEmployeeMaster EMPName = tbl_genEmployeeMaster.Select(OderRef.Employee_ID);
                if (EMPName != null)
                {
                    SRPname = EMPName.EmployeeName;
                }
            }
            return SRPname;
        }
        #endregion

        #region Total Invoice FIFO Cost
        private decimal TotalInvoiceFIFOCost(string sInvoiceID)
        {
            decimal dInvoiceFIFOCost = 0;
            foreach (tbl_sasInvoice_Detail item in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(sInvoiceID))
            {
                dInvoiceFIFOCost = dInvoiceFIFOCost + item.TatalCost_FIFO;
            }
            return dInvoiceFIFOCost;
        }
        #endregion

        #region Credit Note Amount
        private decimal CreditNoteAmountInvoiceWise(string sInvoiceID)
        {
            decimal dTotalCreditNote = 0;
            foreach (tbl_bpsCreditNote item in tbl_bpsCreditNote.SelectAllByInvoice_ID(sInvoiceID).Where(p => p.IsDeleted == false && p.CreditNote_ID != "default"))
            {
                dTotalCreditNote = dTotalCreditNote + (item.SubTotal - item.DiscountTotal);
            }
            return dTotalCreditNote;
        }

        #endregion

        #region SRN Cost Calculation Amounts
        private decimal SRNCostCalculationAmounts(string sInvoiceID)
        {
            decimal dSRNCostAmount = 0;
            List<tbl_sasSalesReturnedNote_Detail> details = tbl_sasSalesReturnedNote_Detail.SelectAllByInvoice_ID(sInvoiceID);
            foreach (tbl_sasSalesReturnedNote_Detail detail in details)
            {
                tbl_sasSalesReturnedNote SRNNoteDetail = tbl_sasSalesReturnedNote.Select(detail.SalesReturnedNote_ID);
                if (SRNNoteDetail != null)
                {
                    if (SRNNoteDetail.IsDeleted == false)
                    {
                        dSRNCostAmount += detail.TatalCost_FIFO;
                    }
                }
            }
            return dSRNCostAmount;
        }
        #endregion

        #region DebitNote Note Amount
        private decimal DebitNoteAmount(string sInvoiceID)
        {
            // dtInvoiceWiseProfitReport
            decimal dTotalCreditNote = 0;
            foreach (tbl_bpsDebitNote item in tbl_bpsDebitNote.SelectAllByInvoice_ID(sInvoiceID).Where(p => p.IsDeleted == false && p.DebitNote_ID != "default"))
            {
                dTotalCreditNote = dTotalCreditNote + (item.SubTotal - item.DiscountTotal);
            }
            return dTotalCreditNote;
        }
        #endregion

        #region Sub Total Amount
        private decimal SubTotalAmount(string sInvoiceID)
        {
            decimal dSubTotalAmount = 0;
            tbl_sasInvoice invdetail = tbl_sasInvoice.Select(sInvoiceID);
            if (invdetail != null)
            {
                if (invdetail.IsSVatInvoice)
                {
                    dSubTotalAmount = (invdetail.GrandTotal / 101) * 100;
                }
                else
                {
                    dSubTotalAmount = ((invdetail.GrandTotal / 112) * 100 / 101) * 100;
                }
            }
            return dSubTotalAmount;
        }
        #endregion

        #region Print method for Data Set
        private void print(string path, string sReportTitle, DataTable objDataTable, string sFilter, decimal dOnloanQty)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Standed Reports";
                CrystalDecisions.CrystalReports.Engine.ReportDocument objRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(objDataTable); //(glbDtsSales)

                objRpt.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);

                if (dOnloanQty > 0)
                    objRpt.DataDefinition.FormulaFields["Onloan_Qty"].Text = clsCommon.fncsetstring(clsFormatter.FormatToNumberNoDecimal(dOnloanQty));

                frm_ReportViewer ReportViewer = new frm_ReportViewer();
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

        #region Button
        private void btnStockAgeAnalysis_CostWise_Click(object sender, EventArgs e)
        {
            #region Stock Age Analysis Report
            try
            {
                Cursor = Cursors.WaitCursor;
                glbDtsStock.dt_scsStockMoving.Rows.Clear();
                //foreach (tbl_scsExternalGoodReceivedNote_Detail_FIFO detail in tbl_scsExternalGoodReceivedNote_Detail_FIFO.SelectAll().Where(p => p.Item_ID != "default" && !p.IsSeattled))
                //{

                //    #region MyRegion
                //    decimal dPendingQty = 0, d0to30Days = 0, d31to60Days = 0, d61to90Days = 0, dOver90Days = 0;
                //    string sCategoryName = "", sTypeName = "";

                //    tbl_genItemMaster oItem = tbl_genItemMaster.Select(detail.Item_ID);
                //    if (oItem != null && oItem.Item_ID != "default")
                //    {
                //        sCategoryName = clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID);
                //        sTypeName = clsGenaralName.getName_ItemType(oItem.ItemType_ID);
                //    }
                //    dPendingQty = detail.Qty - detail.SettleQty;
                //    int iAgeing = clsCommon.getDaysUptoDate(detail.ExternalGoodIssueNoteDate);
                //    if (iAgeing <= 30)
                //        d0to30Days += dPendingQty;
                //    else if (iAgeing >= 31 & iAgeing <= 60)
                //        d31to60Days += dPendingQty;
                //    else if (iAgeing >= 61 & iAgeing <= 90)
                //        d61to90Days += dPendingQty;
                //    else if (iAgeing >= 91)
                //        dOver90Days += dPendingQty;
                //    #endregion

                //    glbDtsStock.dt_scsStockMoving.Adddt_scsStockMovingRow(detail.Item_ID, clsGenaralName.getName_Item(detail.Item_ID), clsGenaralName.getName_ItemSubCategory(detail.ItemSubCategory_ID),
                //        sTypeName, sCategoryName, d0to30Days, d31to60Days, d61to90Days, dOver90Days, detail.ExternalGoodReceivedNote_ID, detail.ExternalGoodIssueNoteDate, dPendingQty, detail.QtyPrice,
                //        tbl_scsExternalGoodReceivedNote_Detail_FIFO.SelectAllByItem_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2(detail.Item_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2).Sum(p => (p.Qty - p.SettleQty) * p.QtyPrice));
                //}

                decimal dOnloanQty = 0;
                foreach (tbl_genStore_Stock oStock in tbl_genStore_Stock.SelectAllByStore_ID("STO/0005"))
                {
                    dOnloanQty += oStock.Qty;
                }
                print("\\Reports\\MIS\\Report\\rpt_scs_StockAgeAnalysisReport_CostWise.rpt", " Stocks Age Analysis Report (Cost-Wise)", glbDtsStock.dt_scsStockMoving, "", dOnloanQty);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
                glbDtsStock.dt_scsStockMoving.Rows.Clear();
            }
            #endregion
        }
        private void btnStockAgeAnalysisReportStandard_Click(object sender, EventArgs e)
        {
            #region Stock Age Analysis Report
            try
            {
                Cursor = Cursors.WaitCursor;
                glbDtsStock.dt_scsStockMoving.Rows.Clear();

                //foreach (tbl_scsExternalGoodReceivedNote_Detail_FIFO detail in tbl_scsExternalGoodReceivedNote_Detail_FIFO.SelectAll().Where(p => p.Item_ID != "default" && p.Qty > p.SettleQty))
                //{
                //    decimal dPendingQty = 0, d0to30Days = 0, d31to60Days = 0, d61to90Days = 0, dOver90Days = 0;
                //    string sCategoryName = "", sTypeName = "";

                //    tbl_genItemMaster oItem = tbl_genItemMaster.Select(detail.Item_ID);
                //    if (oItem != null && oItem.Item_ID != "default")
                //    {
                //        sCategoryName = clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID);
                //        sTypeName = clsGenaralName.getName_ItemType(oItem.ItemType_ID);
                //    }
                //    dPendingQty = detail.Qty - detail.SettleQty;
                //    int iAgeing = clsCommon.getDaysUptoDate(detail.ExternalGoodIssueNoteDate);
                //    if (iAgeing <= 30)
                //        d0to30Days += dPendingQty;
                //    else if (iAgeing >= 31 & iAgeing <= 60)
                //        d31to60Days += dPendingQty;
                //    else if (iAgeing >= 61 & iAgeing <= 90)
                //        d61to90Days += dPendingQty;
                //    else if (iAgeing >= 91)
                //        dOver90Days += dPendingQty;

                //    glbDtsStock.dt_scsStockMoving.Adddt_scsStockMovingRow(detail.Item_ID, clsGenaralName.getName_Item(detail.Item_ID), clsGenaralName.getName_ItemSubCategory(detail.ItemSubCategory_ID),
                //        sTypeName, sCategoryName, d0to30Days, d31to60Days, d61to90Days, dOver90Days, detail.ExternalGoodReceivedNote_ID, detail.ExternalGoodIssueNoteDate, dPendingQty, detail.QtyPrice
                //        , tbl_scsExternalGoodReceivedNote_Detail_FIFO.SelectAll().Where(p => p.Item_ID == detail.Item_ID && p.ItemSubCategory_ID == detail.ItemSubCategory_ID).Sum(p => p.Qty));
                //}

                decimal dOnloanQty = 0;
                foreach (tbl_genStore_Stock oStock in tbl_genStore_Stock.SelectAllByStore_ID("STO/0005"))
                {
                    dOnloanQty += oStock.Qty;
                }
                print("\\Reports\\MIS\\Report\\rpt_scs_StockAgeAnalysisReport.rpt", " Stocks Age Analysis Report (Standard)", glbDtsStock.dt_scsStockMoving, "", dOnloanQty);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
                glbDtsStock.dt_scsStockMoving.Rows.Clear();
            }
            #endregion
        }
        private void btnOutstandingChequesAgeAnalysis_Click(object sender, EventArgs e)
        {
            #region Outstanding Cheques Age Analysis (Customer)

            //if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Collection_Report_Aging)))
            //{
            //clear data table
            glbDtsBills.dt_bssOutstandingChequesAgeAnalysis.Rows.Clear();
            DateTime dtNow = clsSecurity.getServerDateTime();
            foreach (tbl_bpsChequeRegister oChequeRegister in tbl_bpsChequeRegister.SelectAll().Where(p => !p.IsDeleted && p.Receipt_ID != "default" && p.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Realized) && p.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_R)
                && p.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C) && p.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O) && p.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Deleted)))
            {

                decimal dTotalChequeAmount = 0, d0to30Days = 0, d31to60Days = 0, d61to90Days = 0, dOver90Days = 0, dPendingRealized = 0, dTotalCheques = 0;
                if (oChequeRegister.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                {
                    if (oChequeRegister.DateCheque.Date >= dtNow.Date)
                    {

                        int iAgeing = clsCommon.getDays(dtNow.Date, oChequeRegister.DateCheque.Date);
                        if (iAgeing <= 30)
                            d0to30Days += oChequeRegister.Amount;
                        else if (iAgeing >= 31 & iAgeing <= 60)
                            d31to60Days += oChequeRegister.Amount;
                        else if (iAgeing >= 61 & iAgeing <= 90)
                            d61to90Days += oChequeRegister.Amount;
                        else if (iAgeing >= 91)
                            dOver90Days += oChequeRegister.Amount;
                    }
                    else
                    {
                        dPendingRealized += oChequeRegister.Amount;
                    }

                    dTotalChequeAmount += oChequeRegister.Amount;
                    dTotalCheques++;

                    glbDtsBills.dt_bssOutstandingChequesAgeAnalysis.Adddt_bssOutstandingChequesAgeAnalysisRow(oChequeRegister.Customer_ID, clsGenaralName.getName_Customer(oChequeRegister.Customer_ID), dTotalChequeAmount,
                        dTotalCheques, dPendingRealized, d0to30Days, d31to60Days, d61to90Days, dOver90Days);
                }
            }
            print("\\Reports\\MIS\\Report\\rpt_bss_OutstandingChequesAgeAnalysis.rpt", "PD Cheque Age-Analysis (By Cheque Date)", glbDtsBills.dt_bssOutstandingChequesAgeAnalysis, "", 0);
            //}

            #endregion
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //createDailyColectionChart();
            //createDailyColectionChart_New();
        }
        private void createDailyColectionChart()
        {
            DateTime dtNow;
            DateTime dtFirstDayOfThisMonth;
            // DateTime dtFirstDayOfThisYear;

            dtNow = clsSecurity.getServerDateTime();
            dtFirstDayOfThisMonth = new DateTime(dtNow.Year, dtNow.Month, 1);

            #region Chart Formating
            clsChart.ChartFormat_Basic(ref chtDailyCollection);

            chtDailyCollection.Titles.Add("Collection Cash/Cheque (Current Month)");
            clsChart.ChartTitleFormat_Basic(ref chtDailyCollection);

            chtDailyCollection.Legends.Clear();
            chtDailyCollection.Legends.Add("Cash");
            chtDailyCollection.Legends.Add("Cheque");
            clsChart.ChartLegendsFormat_Basic(ref chtDailyCollection, "Cash");

            chtDailyCollection.ChartAreas.Clear();
            chtDailyCollection.ChartAreas.Add("ChartArea");
            chtDailyCollection.ChartAreas["ChartArea"].AxisX.Title = "Day";
            chtDailyCollection.ChartAreas["ChartArea"].AxisY.Title = "Amount";
            clsChart.ChartAxisFormat_Basic(ref chtDailyCollection, "ChartArea");

            chtDailyCollection.Series.Clear();
            chtDailyCollection.Series.Add("Cash");
            chtDailyCollection.Series.Add("Cheque");
            #endregion

            var oInputItems = tbl_bpsReceipt.SelectAll().Where(p => !p.IsDeleted && p.ReceiptDate >= dtFirstDayOfThisMonth).
                GroupBy(cm => new { cm.ReceiptDate.Date }, (key, group) => new { ReceiptDate = key.Date, CashAmount = group.Sum(p => p.CashAmount), ChequeAmount = group.Sum(p => p.ChequeAmount) });
            //   decimal dMaxValue_Cheque = oInputItems.Max(p => p.ChequeAmount);
            //   decimal dMaxValue_Cash = oInputItems.Max(p => p.CashAmount);
            foreach (var item in oInputItems)
            {
                chtDailyCollection.Series["Cash"].Points.AddXY(item.ReceiptDate.Day, item.CashAmount);
                chtDailyCollection.Series["Cheque"].Points.AddXY(item.ReceiptDate.Day, item.ChequeAmount);
            }

            //     chtDailyCollection.ChartAreas["ChartArea"].AxisY.Maximum = dMaxValue_Cash > dMaxValue_Cheque ? double.Parse(dMaxValue_Cash.ToString()) : double.Parse(dMaxValue_Cheque.ToString());
            chtDailyCollection.ChartAreas["ChartArea"].AxisX.Minimum = 0;
            chtDailyCollection.ChartAreas["ChartArea"].AxisX.Maximum = (dtNow.Day - dtFirstDayOfThisMonth.Day + 1);
            chtDailyCollection.ChartAreas["ChartArea"].AxisY.Minimum = 0;
        }

        private void createDailyColectionChart_New()
        {
            DateTime dtTo = dtpTo.Value.Date;
            DateTime dtFinYearStartDate;
            string sFinYearID = clsMethods_GL.getFinancialYear_ID(dtTo);
            dtFinYearStartDate = clsMethods_GL.getFinancialYear_StartDate(sFinYearID);
            dtFinYearStartDate = dtpFrom.Value.Date;

            #region Chart Formating
            clsChart.ChartFormat_Basic(ref chtDailyCollection);

            chtDailyCollection.Titles.Add("Collection Cash/Cheque (Current Financial Year)");
            clsChart.ChartTitleFormat_Basic(ref chtDailyCollection);

            chtDailyCollection.Legends.Clear();
            chtDailyCollection.Legends.Add("Cash");
            chtDailyCollection.Legends.Add("Cheque");
            clsChart.ChartLegendsFormat_Basic(ref chtDailyCollection, "Cash");

            chtDailyCollection.ChartAreas.Clear();
            chtDailyCollection.ChartAreas.Add("ChartArea");
            chtDailyCollection.ChartAreas["ChartArea"].AxisX.Title = "Months";
            chtDailyCollection.ChartAreas["ChartArea"].AxisY.Title = "Amount";
            clsChart.ChartAxisFormat_Basic(ref chtDailyCollection, "ChartArea");

            chtDailyCollection.Series.Clear();
            chtDailyCollection.Series.Add("Cash");
            chtDailyCollection.Series.Add("Cheque");
            #endregion

            DateTime firstOfNextMonth = new DateTime(dtFinYearStartDate.Year, dtFinYearStartDate.Month, 1).AddMonths(1);

            DateTime firstNxtMnth = new DateTime(dtFinYearStartDate.Year, dtFinYearStartDate.Month, 1);
            DateTime lastThisMnth = firstOfNextMonth.AddDays(-1);
            int iLastMn = 0;
            while (dtTo.Month != iLastMn)
            {
                decimal dCashAmount = 0;
                decimal dChequeAmount = 0;
                string sMonthName = firstNxtMnth.ToString("MMMM");

                var oInputItems = tbl_bpsReceipt.SelectAll().Where(p => !p.IsDeleted && p.ReceiptDate >= firstNxtMnth.Date && p.ReceiptDate <= lastThisMnth.Date).
                GroupBy(cm => new { cm.ReceiptDate.Date }, (key, group) => new { ReceiptDate = key.Date, CashAmount = group.Sum(p => p.CashAmount), ChequeAmount = group.Sum(p => p.ChequeAmount) });

                foreach (var item in oInputItems)
                {
                    dCashAmount += item.CashAmount;
                    dChequeAmount += item.ChequeAmount;

                    //chtDailyCollection.Series["Cash"].Points.AddXY(item.ReceiptDate.Day, item.CashAmount);
                    //chtDailyCollection.Series["Cheque"].Points.AddXY(item.ReceiptDate.Day, item.ChequeAmount);
                }

                chtDailyCollection.Series["Cash"].Points.AddXY(firstNxtMnth.Month, dCashAmount);
                chtDailyCollection.Series["Cheque"].Points.AddXY(firstNxtMnth.Month, dChequeAmount);

                chtDailyCollection.Series["Cash"].Points.AddXY(sMonthName, dCashAmount);
                chtDailyCollection.Series["Cheque"].Points.AddXY(sMonthName, dChequeAmount);

                firstNxtMnth = new DateTime(firstNxtMnth.Year, firstNxtMnth.Month, 1).AddMonths(1);
                lastThisMnth = firstNxtMnth.AddMonths(1).AddDays(-1);
                iLastMn = firstNxtMnth.AddMonths(-1).Month;
            }


            chtDailyCollection.ChartAreas["ChartArea"].AxisX.Minimum = dtFinYearStartDate.Month;
            //if (lastThisMnth.Month <= dtFinYearStartDate.Month)
            //    chtDailyCollection.ChartAreas["ChartArea"].AxisX.Maximum = lastThisMnth.AddMonths(-1).Month + 12;
            //else
            //    chtDailyCollection.ChartAreas["ChartArea"].AxisX.Maximum = lastThisMnth.AddMonths(-1).Month;

            chtDailyCollection.ChartAreas["ChartArea"].AxisY.Minimum = 0;

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnSalesReport_InvW_Click(object sender, EventArgs e)
        {
            frm_rpt_SalesStrandedReprots oRpt = new frm_rpt_SalesStrandedReprots();
            oRpt.setReport(enum_ReportName.ST_SalesReport_Invoice_Wise);
            //oRpt.setEnableDisableConctrol();
            oRpt.SetParameeters(dtpFrom.Value.Date, dtpTo.Value.Date);
            //   oRpt.Print();
            oRpt = null;
        }

        private void pnlCanceledReciepts_Click(object sender, EventArgs e)
        {
            frm_rpt_BillsRegisterReports oRpt = new frm_rpt_BillsRegisterReports();
            oRpt.AddItemToTypeComboBox();
            oRpt.setReport(enum_ReportName.RG_ReceiptSummary);
            oRpt.setEnableDisableConctrol((int)enum_ReportName.RG_ReceiptSummary);
            oRpt.SetParameeters(dtpFrom.Value.Date, dtpTo.Value.Date, false, true);
            oRpt.Print();
            oRpt = null;
        }

        private void btn_PendingDO_Click(object sender, EventArgs e)
        {
            if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Pending_Delivery_Item_Summary)))
            {
                string sFormula = "";
                sFormula = " {vw_rpt_sasCustomerOrder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasCustomerOrder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'and {vw_rpt_sasCustomerOrder_Detail.qtySettle} < {vw_rpt_sasCustomerOrder_Detail.qty}";
                sFormula += " and {vw_rpt_sasCustomerOrder.isSeattled} = false  and {vw_rpt_sasCustomerOrder.isDeleted} = false ";

                if (clsConfig.bApprovalEnabledCustomerOrder)
                    sFormula += " and {vw_rpt_sasCustomerOrder.isApproved} = true ";

                print("\\reports\\SAS\\Pending\\rpt_sas_CustomerOrder_Item_Summary.rpt", " Pending Customer Order Item Summary", sFormula);
            }
        }

        private void BtnInvoiceWiseProfitReport_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string sReportTitle = "", sReportPath = "";
            try
            {
                sReportTitle = "Invoice WiseProfit Report By Customer";
                sReportPath = "\\Reports\\MIS\\Report\\rpt_sasInvoiceWiseProfitReportByCustomer.rpt";

                print(sReportPath, sReportTitle, DataSetInvoiceWiseProfitReport(), "", 0);
                glb_dtsSales.dt_sasInvoiceWiseProfit.Clear();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void btnInvoiceWiseProfitReportBySalseman_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string sReportTitle = "", sReportPath = "";
            try
            {
                sReportTitle = "Invoice WiseProfit Report By Salesman";
                sReportPath = "\\Reports\\MIS\\Report\\rpt_sasInvoiceWiseProfitReportBySalesman.rpt";

                print(sReportPath, sReportTitle, DataSetInvoiceWiseProfitReport(), "", 0);
                glb_dtsSales.dt_sasInvoiceWiseProfit.Clear();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void vistaButton1_Click_1(object sender, EventArgs e)
        {
            string sFormula = "";
            sFormula = " {vw_rpt_sasPerformance_Report.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasPerformance_Report.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
            sFormula += " and {vw_rpt_sasPerformance_Report.customer_ID} <> 'default' ";
            sFormula += " and {vw_rpt_sasPerformance_Report.subTotal} <> 0 ";
            DebitNoteAmounts();
            CreditNoteAmounts();
            SRNCostCalculationAmounts();

            //rpt_sas_PerformanceReportDateWise
            print("\\Reports\\MIS\\Report\\rpt_sas_PerformanceReportDateWiseDetail.rpt", "Performance Report Details", sFormula);
        }
        #endregion

        #region Print Method
        private void print(string path, string sReportTitle, string sFormula)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Standed Reports";
                ReportDocument RD = new ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                frm_ReportViewer viewer = new frm_ReportViewer();
                RD.Load(s_Path);
                clsSecurity.LogonServer(ref RD);
                RD.Refresh();

                RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);




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

                creditAmount = 0; dNbtTotal = 0; dVatTotal = 0; dSVatTotal = 0;
                DebitAmount = 0; dDebitNbtTotal = 0; dDebitVatTotal = 0; dDebitSVatTotal = 0; dSRNFIFOCost = 0;
            }

        }
        #endregion

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCht_PaymentCollection_Click(object sender, EventArgs e)
        {
            frm_cht_DailyCollection frm = new frm_cht_DailyCollection();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnCht_CustomerWiseSales_Click(object sender, EventArgs e)
        {
            frm_cht_Sales frm = new frm_cht_Sales();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }



    }
}